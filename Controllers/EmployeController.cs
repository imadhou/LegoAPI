using AutoMapper;
using LegoApi.Data;
using LegoApi.DTO;
using LegoApi.Errors;
using LegoApi.Models;
using LegoApi.Repos;
using LegoApi.Repos.CongeRepo;
using LegoApi.Repos.EmployeCongeRepo;
using LegoApi.Repos.EmployeRepo;
using LegoApi.Repos.ServiceRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace LegoApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/employes")]
    public class EmployeController : ControllerBase
    {
        private readonly IEmployeRepo repo;
        private readonly IEmployeCongeRepo repo1;
        private readonly IMapper mapper;
        private readonly IServiceRepo sRepo;
        private readonly ICongeRepo cRepo;

        public EmployeController(
            IEmployeRepo repo,
            IEmployeCongeRepo repo1,
            IMapper mapper,
            IServiceRepo sRepo,
            ICongeRepo cRepo
            )
        {
            this.repo = repo;
            this.repo1 = repo1;
            this.mapper = mapper;
            this.sRepo = sRepo;
            this.cRepo = cRepo;
        }

        //Add a developper
        //1- Required fields
        //2- Validate input
        //3- Check existance of service
        //4- Check unique email
        //5- Insert data
        [HttpPost]
        [Route("developpeurs")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(DeveloppeurRead))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddDeveloper([FromBody] DeveloperAdd dev)
        {

            var foundService = sRepo.GetServiceByID(dev.ServiceID);
            if(foundService == null)
            {
                throw new RequiredFieldNotFoundException("ServiceId", dev.ServiceID.ToString());
            }
            var devFound = repo.GetByEmail(dev.Email);
            if(devFound != null)
            {
                throw new InUseException("email", dev.Email);
            }
            var developer = mapper.Map<Developpeur>(dev);
            repo.AddEmploye(developer);
            var devRead = mapper.Map<DeveloppeurRead>(developer);
            return Created(new Uri(uriString: $"https://localhost:5001/api/v1/employes/developpeurs/{devRead.ID}"), devRead);
        }


        //Delete a developer
        //1- check existance of dev
        //2- delete dev
        [HttpDelete]
        [Route("developpeurs/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult DeleteDeveloppeur(int id)
        {
            var foundDev = repo.GetById(id);
            if(foundDev == null)
            {
                throw new RequiredFieldNotFoundException("Id", id.ToString());
            }
            repo.DeleteEntity(id);
            return NoContent();
        }


        //Get all devs TODO: filtering and sorting and aggregation
        //
        [HttpGet]
        [Route("developpeurs")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<DeveloppeurRead>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetAllDevelopers()
        {
            var devs = repo.getEmployees();
            var devsR = mapper.Map<IEnumerable<DeveloppeurRead>>(devs);
            return Ok(devsR);
        }


        //Get a dev by id
        //1- Check existance of dev
        [HttpGet]
        [Route("developpeurs/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DeveloppeurRead))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetDeveloperById(int id)
        {
            var devs = repo.GetById(id);
            if(devs == null)
            {
                throw new RessourceNotFoundException("Developpeur", id.ToString());
            }
            var devsR = mapper.Map<DeveloppeurRead>(devs);
            return Ok(devsR);
        }



        //Add a conge for employe
        //1- Check input
        //2- Check dev
        //3- Check conge
        //4- Check if dev elligible for conge
        [HttpPost]
        [Route("developpeurs/{id}/conges")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CongeEmplDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddCongeEmpl([FromBody] EmployeCongeAddDTO conge, int id)
        {
            var empl = repo.GetById(id);
            if(empl == null)
            {
                throw new RessourceNotFoundException("Developpeur", id.ToString());
            }

            var foundConge = cRepo.GetCongeById(conge.CongeID);
            if(foundConge == null)
            {
                throw new RequiredFieldNotFoundException("CongeId", conge.CongeID.ToString());
            }

            var totalConges = repo.TotalConges(id, conge.DateDebut.Year);
            if(totalConges >= 30)
            {
                return Ok("Employe a commulé l'integralité de ces congés pour cette année");
            }
            var cng = mapper.Map<EmployeConge>(conge);
            cng.Employe = empl;
            repo1.AddCongeEmploye(cng);
            return Ok(mapper.Map<CongeEmplDTO>(cng));
        }


        //Update a developer TODO
        //-1 Check dev
        //-2 Check service
        //-3 update
        //[HttpPut]
        //[Route("developpeurs/{id}")]
        //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DeveloppeurRead))]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        
    }
}
