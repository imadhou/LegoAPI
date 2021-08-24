using AutoMapper;
using LegoApi.Data;
using LegoApi.DTO;
using LegoApi.Models;
using LegoApi.Repos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LegoApi.Controllers
{
    [ApiController]
    [Route("/api/v1/developpeurs")]
    public class DeveloppeurController : ControllerBase
    {
        private readonly LegoApiContext ctx;
        private readonly IMapper mapper;
        private readonly IGenericRepo<Developpeur> repo;
        private readonly IGenericRepo<EmployeConge> empcng;
        private readonly IGenericRepo2<Developpeur> devrep;

        public DeveloppeurController(LegoApiContext ctx, IMapper mapper, IGenericRepo<Developpeur> repo, IGenericRepo<EmployeConge> empcng, IGenericRepo2<Developpeur> devrep)
        {
            this.ctx = ctx;
            this.mapper = mapper;
            this.repo = repo;
            this.empcng = empcng;
            this.devrep = devrep;
        }

        //get all devs (only personal informations and service id)
        //TODO filtering and ordring
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Developpeur>))]
        public async Task <IActionResult> GetAllDevss()
        {
            var a = await devrep.GetEntities(
                predicate: d => d.Experience > 2,
                orderBy: (d => d.OrderBy(d1 => d1.Experience)),
                groupBy: d => d.Langage,
                include: d => d.Include(s => s.EmployeConges)
                );
            return Ok(a) ;
        }

        //get a specific developer by his ID including his Congees
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Developpeur))]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            var dv = devrep.GetFirstOrDefault(
                predicate: d => d.ID == id,
                include: s => s.Include(s => s.EmployeConges).ThenInclude(d => d.Conge)
                );

            var vd = mapper.Map<DeveloppeurRead>(dv);
            return Ok(vd);
        }

        //Adding a new dev
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(DevCr))]
        public async Task<IActionResult> AddDev([FromBody] DevCr developpeur)
        {
            var cm = mapper.Map<Developpeur>(developpeur);
            await repo.Add(cm);
            var mc = mapper.Map<DevCr>(cm);

            return Created("todo", mc);
        }

        //Adding a Conge for a dev
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EmployeConge))]
        [Route("conges")]
        public async Task<IActionResult> AddCongeForDev([FromBody] EmployeConge employeConge)
        {

            await empcng.Add(employeConge);
            return Ok(employeConge);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Employe))]
        [Route("conges")]
        public async Task<IActionResult> UpdateConge([FromBody] EmployeConge employeConge)
        {
            await empcng.Update(employeConge);
            var emp = devrep.GetFirstOrDefault(predicate: e => e.ID == employeConge.EmployeId);
            return Ok(emp);
        }
    }
}
