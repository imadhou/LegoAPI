using LegoApi.Models;
using LegoApi.Repos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LegoApi.Controllers
{
    [ApiController]
    [Route("/api/v1/developpeurs")]
    public class DeveloppeurController: ControllerBase
    {
        private readonly Repos.IGenericRepo<Developpeur> repo;
        private readonly IGenericRepo<EmployeConge> empcng;

        public DeveloppeurController(IGenericRepo<Developpeur> repo, IGenericRepo<EmployeConge> empcng)
        {
            this.repo = repo;
            this.empcng = empcng;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Developpeur>))]
        public async Task<IActionResult> GetAllDevs()
        {
            return Ok(await repo.GetMany());
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Developpeur))]
        public async Task<IActionResult> AddDev([FromBody] Developpeur developpeur)
        {
            await repo.Add(developpeur);
            return Created("todo", developpeur);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EmployeConge))]
        [Route("conges/{id}")]
        public async Task<IActionResult> AddCongeForDev([FromBody] EmployeConge employeConge, int id)
        {

            await empcng.Add(employeConge);
            var emp = await repo.GetById(id);
            return Ok(employeConge);
        }
    }
}
