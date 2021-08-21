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
    [Route("/api/v1/conges")]
    public class CongeController: ControllerBase
    {
        private readonly IGenericRepo<Conge> repo;

        public CongeController(IGenericRepo<Conge> repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Conge>))]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await repo.GetMany());
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Conge))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Add([FromBody] Conge conge)
        {
            if(conge == null)
            {
                return BadRequest();
            }
            await repo.Add(conge);
            return Created("todo", conge);
        }
    }
}
