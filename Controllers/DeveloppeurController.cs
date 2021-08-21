using LegoApi.Models;
using LegoApi.Repos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LegoApi.Controllers
{
    [ApiController]
    [Route("/api/v1/developpeurs")]
    public class DeveloppeurController: ControllerBase
    {
        private readonly Repos.IGenericRepo<Developpeur> repo;
        private readonly IGenericRepo<EmployeConge> empcng;
        private readonly IGenericRepo2<Developpeur> devrep;

        public DeveloppeurController(IGenericRepo<Developpeur> repo, IGenericRepo<EmployeConge> empcng, IGenericRepo2<Developpeur> devrep)
        {
            this.repo = repo;
            this.empcng = empcng;
            this.devrep = devrep;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Developpeur>))]
        public IActionResult GetAllDevss()
        {
            return Ok(devrep.GetMuliple(include:(
                s => s.Include(s => s.EmployeConges)
                )));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Developpeur))]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(devrep.GetFirstOrDefault(
                predicate: d => d.ID == id,
                include: s => s.Include(s=> s.EmployeConges)
                ));
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
