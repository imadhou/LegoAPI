using AutoMapper;
using LegoApi.Data;
using LegoApi.DTO;
using LegoApi.Models;
using LegoApi.Repos;
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
    [Route("api/v1/services")]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceRepo repo;

        public ServiceController(IServiceRepo repo)
        {
            this.repo = repo;
        }


        //add a service
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type=typeof(Service))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Add([FromBody] Service service)
        {
            if(service == null)
            {
                return BadRequest();
            }
            repo.AddService(service);
            return Created("todo", service);
        }


        //get all services
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Service>))]
        public IActionResult GetAll()
        {
            var services = repo.GetAllServices();
            Console.WriteLine(services.Count());
            return Ok(services);
        }


        ////get one by id
        //[HttpGet]
        //[Route("{id}")]
        //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Service))]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public async Task<IActionResult> GetById(int id)
        //{
        //    try
        //    {
        //        var serv = await repo.GetById(id);
        //        if (serv == null)
        //        {
        //            return NotFound();
        //        }
        //        return Ok(serv);
        //    }
        //    catch (ArgumentException)
        //    {
        //        return NotFound();
        //    }
        //}


        ////update by id
        //[HttpPut]
        //[Route("{id}")]
        //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Service))]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public async Task<IActionResult> Update([FromBody] Service service, int id)
        //{
        //    try{
        //        var serv = await repo.GetById(id);
        //        serv.Nom = service.Nom;
        //        serv.Locale = service.Locale;
        //        await repo.Update(serv);
        //        return Ok(serv);
        //    }
        //    catch(ArgumentException)
        //    {
        //        return NotFound();
        //    }
        //}




        ////delete a service by id
        //[HttpDelete]
        //[Route("{id}")]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    try
        //    {
        //        await repo.Remove(id);
        //    }
        //    catch (ArgumentException)
        //    {
        //        return NotFound();
        //    }
        //    return NoContent();
        //}
    }
}
