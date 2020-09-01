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
        public Object Get(int id)
        {
            var res = repository.Get(id);
            var complist = repository.GetCompanies(res);
            return complist;
        }

        //[HttpGet("getexchange/{id}")]
        //public Object Get1(int id)
        //{
        //    var res = repository.Get(id);
        //    var list = repository.GetExchange(id);
        //    //res.StockExchangeCompanies = (ICollection<StockExchangeCompany>)list;
        //    //var complist = repository.GetCompanies(res);
        //    return list;
        //}

        // POST api/<StockExchangeController>
        [HttpPost]
        public IActionResult Post([FromForm] StockExchange se)
        {
            if (ModelState.IsValid)
            {
                var isAdded = repository.Add(se);
                if (isAdded)
                {
                    return Created("student", se);
                }
            }
            return BadRequest(ModelState);
        }

        [HttpPost("AddComp")]
        public IActionResult Post([FromQuery] int id, int id2)
        {
            //int id = i[0];
            //int id2 = i[1];
            //int id2 = 3;
            var isAdded = repository.Add(id, id2);
            if (isAdded)
            {
                return Created("Company Added to Stock Exchange with Id", id2);
            }
            else return StatusCode(500, "Internal Server Error");

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
