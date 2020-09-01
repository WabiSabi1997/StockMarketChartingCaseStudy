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
       
        private CompanyRepository repository;

        public CompanyController(CompanyRepository repository)
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
        public Object Get(object id)
        {

            var res = repository.Get(id); 
            return res;
        }

        [HttpGet("{id}/ipodetails")]
       /*
        public Object GetIPO(int id)
        {
            var res = repository.GetIPO(id); //have to change this to fetch via IPO Controller
            return res;
        }
       */

        [HttpGet("getprice/{id}/{from}/{to}")]
        public Object GetStockPrice(int id, DateTime from, DateTime to)
        {
            var res = repository.GetStockPrice(id, from, to);
            return res;
        }
        
        // POST api/<CompanyController>
        [HttpPost]
        public void Post([FromForm] Company company)
        {
            //company.Sector.SectorID = id;
            var x = repository.Add(company);
        }

        // PUT api/<CompanyController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromForm] Company company)
        {
            //Find if the company exists in the database
            //var res = repository.Get(id);
            //If the company exists in the database, edit its details.
            //Disconnect the variable res from the context, otherwise clash will occur and can't update the value.
            repository.Update(company);
        }

        // DELETE api/<CompanyController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var res = repository.Get(id);
            var count = repository.Delete(res);
        }
    }
}
