using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataCreationMicroservice.StockMarket.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StockExchangeMicroservice.Repositories;
using StockMarketCharting.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StockExchangeMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class StockExchangeController : ControllerBase
    {
        private IRepository<StockExchangeDto> repository;

        public StockExchangeController(IRepository<StockExchangeDto> repository)
        {
            this.repository = repository;
        }

        // GET: api/<StockExchangeController>
        [HttpGet]
        public IEnumerable<StockExchangeDto> Get() // to get a list of StockExchanges
        {
            return repository.Get();
        }

        // GET api/<StockExchangeController>/5
        [HttpGet("getcompanies/{id}")]
        public IActionResult Get(int id) // get companies list, given a StockExchange ID.
        {
            var res = repository.Get(id);
            if (res != null)
            {
                var complist = repository.GetCompanies(res);
                return Ok(complist);
            }
            return NotFound($"No Stock Exchange found with ID:{id}");
        }

        // POST api/<StockExchangeController>
        [HttpPost]
        public IActionResult Post([FromForm] StockExchangeDto se)
        {
            if (ModelState.IsValid)
            {
                var isAdded = repository.Add(se);
                if (isAdded)
                {
                    return Created("Following Stock Exchange was added",se);
                }
                return StatusCode(500,"Internal Server Error, Stock Exchange couldn't be added");
            }
            return BadRequest(ModelState);
        }

        //Additional method to list companies to stock exchange.
        [HttpPost("AddComp")]
        public IActionResult Post([FromQuery] int id, int id2)
        {
            var isAdded = repository.Add(id, id2);
            if (isAdded)
            {
                return Created("Company Added to Stock Exchange with Id", id2);
            }
            else return StatusCode(500, "Internal Server Error");
        }

    }
}
