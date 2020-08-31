using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyMicroservice.Repositories;
using Microsoft.AspNetCore.Mvc;
using StockMarketCharting.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CompanyMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private IRepository<Company> repository;

        public CompanyController(IRepository<Company> repository)
        {
            this.repository = repository;
        }
        // GET: api/<CompanyController>
        [HttpGet]
        public IEnumerable<Company> Get()
        {
            var res = repository.Get();
            return res;
        }

        // GET api/<CompanyController>/5
        [HttpGet("getbyname")]
        public IActionResult Get(string query)
        {
            var res = repository.GetbyName(query);
            if (res == null)
            {
                return NotFound("No such company in the database");
            }
            return Ok(res);
        }

        [HttpGet("{id}/companydetails")]
        public Object Get(int id)
        {
            var res = repository.GetIPO(id);
            return res;
        }

        [HttpGet("{id}/ipodetails")]
        public Object GetIPO(int id)
        {
            var res = repository.GetIPO(id);
            return res;
        }

        [HttpGet("getprice/{id}/{from}/{to}")]
        public Object GetStockPrice(int id, DateTime from, DateTime to)
        {
            var res = repository.GetStockPrice(id, from, to);
            return res;
        }
        
        // POST api/<CompanyController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CompanyController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CompanyController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
