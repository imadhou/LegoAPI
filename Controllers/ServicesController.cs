using LegoApi.Data;
using LegoApi.Models;
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
    public class ServicesController : ControllerBase
    {
        private readonly LegoApiContext context;

        public ServicesController(LegoApiContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<Service> GetAllServices()
        {
            return this.context.Services;
        }

        [HttpPost]
        public async Task<Service> AddService([FromBody] Service service)
        {
            this.context.Add(service);
            await this.context.SaveChangesAsync();
            return service;
        }

        [HttpGet]
        [Route("{id}")]
        public Service GetGamebyId(int id)
        {
            return this.context.Services.FirstOrDefault(s => s.ID == id);   
        }
    }
}
