﻿using System;
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
    public class IPODetailsController : ControllerBase
    {
        private IRepository<IPODetailsDto> repository;

        public IPODetailsController(IRepository<IPODetailsDto> repository)
        {
            this.repository = repository;
        }
        // GET: api/<IPODetailsController>
        [HttpGet]
        [Authorize(Roles = "1,2")]
        public IEnumerable<IPODetailsDto> Get() 
        {
            var res = repository.Get();
            return res;
        }

        // GET api/<IPODetailsController>/5
        [HttpGet("{id}")]
        [Authorize(Roles ="1,2")]
        public Object Get(int id) //to get IPO details of a company
        {
            var res = repository.Get(id); 
            return res;
        }

        // POST api/<IPODetailsController>
        [HttpPost]
        [Authorize(Roles ="1")]
        public void Post(IPODetailsDto IPODetail) //to add IPO Details of a company
        {
            var x = repository.Add(IPODetail);
        }

        // PUT api/<IPODetailsController>/5
        [HttpPut("update/{id}")]
        [Authorize(Roles = "1")]
        public void Put(int id, IPODetailsDto IPODetail) //to update
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
