using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
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

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IEnumerable<Sector> Get() // Get all the sectors, just an accesory function. 
        {
            return repository.Get();
        }

        [HttpGet("getcompanies/{id}")]
        //[Authorize(Roles = "Admin,User")]
        public IActionResult Get(int id) // Get all the companies in a particular Sector
        {
            var res = repository.Get(id);
            if (res != null)
            {
                var complist = repository.GetCompanies(res);
                return Ok(complist);
            }
            return NotFound("No sector exists with this id");
        }

        //Get price list for a particular sector for a date-range
        [HttpGet("getprice/{id}/{from}/{to}")]
        [Authorize(Roles = "Admin,User")]
        public Object GetSectorPrice(int id, DateTime from, DateTime to)
        {
            var res = repository.GetSectorPrice(id, from, to);
            return res;
        }

        // Adding Sectors
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Post([FromForm] Sector sector)
        {
            var x = repository.Add(sector);
            if (x)
            {
                return Created("Sector added to database",sector);
            }
            return StatusCode(500, "Internal Server Error, Sector couldn't be added");
        }
    }
}
