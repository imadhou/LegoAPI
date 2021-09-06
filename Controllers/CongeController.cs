using AutoMapper;
using LegoApi.DTO;
using LegoApi.Models;
using LegoApi.Repos;
using LegoApi.Repos.CongeRepo;
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
    public class CongeController : ControllerBase
    {
        private readonly ICongeRepo repo;
        private readonly IMapper mapper;

        public CongeController(ICongeRepo repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Conge>))]
        public IActionResult GetAllConges()
        {
            return Ok(repo.getAllConges());
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Conge))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddConge([FromBody] CongeDTO conge)
        {
            {
                if (conge == null)
                {
                    return BadRequest();
                }
                var con = mapper.Map<Conge>(conge);
                repo.AddConge(con);
                return Created("todo", conge);
            }
        }
    }
}