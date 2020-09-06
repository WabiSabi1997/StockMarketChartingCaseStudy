using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyMicroservice.Repositories;
using DataCreationMicroservice.StockMarket.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StockMarketCharting.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CompanyMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CompanyController : ControllerBase
    {
        private ICompanyRepository repository;

        public CompanyController(ICompanyRepository repository)
        {
            this.repository = repository;       
        }
        // GET: api/<CompanyController>
        [HttpGet]
        [Authorize(Roles = "1,2")]
        public IEnumerable<CompanyDto> Get()
        {
            var res = repository.Get();
            return res;
        }

        // GET api/<CompanyController>/5
        [HttpGet("getcompaniesbyname")]
        [Authorize(Roles = "Admin,User")]
        public IActionResult Get(string query)
        {
            var res = repository.GetbyName(query);
            if (res == null)
            {
                return NotFound("No such company in the database");
            }
            return Ok(res);
        }

        [HttpGet("getcompanydetails/{id}")]
        [Authorize(Roles = "Admin,User")]
        public IActionResult Get(object id)
        {
            var res = repository.Get(id);
            if(res == null)
            {
                return NotFound("No company found with a name matching this query");
            }
            return Ok(res);
        }

        [HttpGet("getstockprice/{id}/{from}/{to}")]
        [Authorize(Roles = "Admin,User")]
        public Object GetStockPrice(int id, DateTime from, DateTime to)
        {
            var res = repository.GetStockPrice(id, from, to);
            return res;
        }
        
        // POST api/<CompanyController>
        [HttpPost]
       // [Authorize(Roles = "Admin")]
        public void Post([FromForm] CompanyDto companyDto)
        {
            var x = repository.Add(companyDto);
        }

        // PUT api/<CompanyController>/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public void Put(int id, [FromForm] CompanyDto companyDto)
        {
            //Find if the company exists in the database
            //var res = repository.Get(id);
            //If the company exists in the database, edit its details.
            //Disconnect the variable res from the context, otherwise clash will occur and can't update the value.
            repository.Update(companyDto);
        }

        // DELETE api/<CompanyController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public void Delete(int id)
        {
            var res = repository.Get(id);
            var count = repository.Delete(res);
        }
    }
}
