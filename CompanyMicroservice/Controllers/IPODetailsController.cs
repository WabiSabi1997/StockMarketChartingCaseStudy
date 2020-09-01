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
    public class IPODetailsController : ControllerBase
    {
        private IRepository<IPODetail> repository;

        public IPODetailsController(IRepository<IPODetail> repository)
        {
            this.repository = repository;
        }
        // GET: api/<IPODetailsController>
        [HttpGet]
        public IEnumerable<IPODetail> Get() 
        {
            var res = repository.Get();
            return res;
        }

        // GET api/<IPODetailsController>/5
        [HttpGet("{id}")]
        public Object Get(int id) //to get IPO details of a company
        {
            var res = repository.Get(id); 
            return res;
        }

        // POST api/<IPODetailsController>
        [HttpPost]
        public void Post([FromForm] IPODetail IPODetail) //to add IPO Details of a company
        {
            var x = repository.Add(IPODetail);
        }

        // PUT api/<IPODetailsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromForm] IPODetail IPODetail) //to update
        {
           // check if the IPO exists and only then update -> do this via IPORepository
            repository.Update(IPODetail); 
        }

        // DELETE api/<IPODetailsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
