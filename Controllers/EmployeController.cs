using AutoMapper;
using LegoApi.Data;
using LegoApi.DTO;
using LegoApi.Models;
using LegoApi.Repos;
using LegoApi.Repos.EmployeCongeRepo;
using LegoApi.Repos.EmployeRepo;
using LegoApi.Repos.ServiceRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LegoApi.Controllers
{
    [ApiController]
    [Route("api/v1/employes")]
    public class EmployeController : ControllerBase
    {
        private readonly IEmployeRepo repo;
        private readonly IEmployeCongeRepo repo1;
        private readonly IMapper mapper;

        public EmployeController(IEmployeRepo repo, IEmployeCongeRepo repo1, IMapper mapper)
        {
            this.repo = repo;
            this.repo1 = repo1;
            this.mapper = mapper;
        }

        //Add a developper
        [HttpPost]
        [Route("developpeurs")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(DeveloppeurRead))]
        public IActionResult AddDeveloper([FromBody] DeveloperAdd dev)
        {
            var developer = mapper.Map<Developpeur>(dev);
            repo.AddEmploye(developer);
            return Created("link", mapper.Map<DeveloppeurRead>(developer));
        }

        [HttpDelete]
        [Route("developpeurs/{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult DeleteDeveloppeur(int id)
        {
            repo.DeleteEntity(id);
            return NoContent();
        }

        [HttpGet]
        [Route("developpeurs")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(IEnumerable<DeveloppeurRead>))]
        public IActionResult GetAllDevelopers()
        {
            var devs = repo.getEmployees();
            var devsR = mapper.Map<IEnumerable<DeveloppeurRead>>(devs);
            return Ok(devsR);
        }

        [HttpGet]
        [Route("developpeurs/{id}")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(DeveloppeurRead))]
        public IActionResult GetDeveloperById(int id)
        {
            var devs = repo.GetById(id);
            var devsR = mapper.Map<DeveloppeurRead>(devs);
            return Ok(devsR);
        }

        [HttpPost]
        [Route("developpeurs/{id}/conges")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CongeEmplDTO))]
        public IActionResult AddCongeEmpl([FromBody] EmployeCongeAddDTO conge, int id)
        {
            var empl = repo.GetById(id);
            var cng = mapper.Map<EmployeConge>(conge);
            cng.Employe = empl;
            repo1.AddCongeEmploye(cng);
            return Ok(mapper.Map<CongeEmplDTO>(cng));
        }




    }
}
