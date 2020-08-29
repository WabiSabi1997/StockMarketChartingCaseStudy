using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StockExchangeMicroservice.Repositories;
using StockMarketCharting.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StockExchangeMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockExchangeController : ControllerBase
    {
        private IRepository<StockExchange> repository;

        public StockExchangeController(IRepository<StockExchange> repository)
        {
            this.repository = repository;
        }
        // GET: api/<StockExchangeController>
        [HttpGet]
        public IEnumerable<StockExchange> Get()
        {
            return repository.Get();
        }

        // GET api/<StockExchangeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<StockExchangeController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<StockExchangeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StockExchangeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
