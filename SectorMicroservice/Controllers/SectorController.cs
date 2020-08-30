using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SectorMicroservice.Repositories;
using StockMarketCharting.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SectorMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectorController : ControllerBase
    {
        private IRepository<Sector> repository;

        public SectorController(IRepository<Sector> repository)
        {
            this.repository = repository;
        }
        // GET: api/<SectorController>
        [HttpGet]
        public IEnumerable<Sector> Get()
        {
            return repository.Get();
        }

        // GET api/<SectorController>/5
        [HttpGet("{id}")]
        public Object Get(long id)
        {
            var res = repository.Get(id);
            var complist = repository.GetCompanies(res);
            return complist;
        }

        // POST api/<SectorController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SectorController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SectorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
