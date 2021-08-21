using LegoApi.Data;
using LegoApi.Models;
using LegoApi.Repos;
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
    [Route("api/v1/services")]
    public class ServiceController : ControllerBase
    {
        private readonly IGenericRepo<Service> repo;

        public ServiceController(IGenericRepo<Service> repo)
        {
            this.repo = repo;
        }


        //add a service
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type=typeof(Service))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Add([FromBody] Service service)
        {
            if(service == null)
            {
                return BadRequest();
            }
            await repo.Add(service);
            return Created("todo", service);
        }


        //get all services
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Service>))]
        public async Task<IActionResult> GetAll()
        {
            return Ok( await repo.GetMany());
        }


        //get one by id
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Service))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var serv = await repo.GetById(id);
                if (serv == null)
                {
                    return NotFound();
                }
                return Ok(serv);
            }
            catch (ArgumentException)
            {
                return NotFound();
            }
        }


        //update by id
        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Service))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromBody] Service service, int id)
        {
            try{
                var serv = await repo.GetById(id);
                serv.Nom = service.Nom;
                serv.Locale = service.Locale;
                await repo.Update(serv);
                return Ok(serv);
            }
            catch(ArgumentException)
            {
                return NotFound();
            }
        }




        //delete a service by id
        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await repo.Remove(id);
            }
            catch (ArgumentException)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
