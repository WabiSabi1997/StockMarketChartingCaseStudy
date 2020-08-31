using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StockExchangeMicroservice.Repositories;
using StockMarket.AuthService.Repositories;
using StockMarketCharting.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StockMarket.AuthService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IRepositoryAuth<UserEntity> repository;

        public AuthController(IRepositoryAuth<UserEntity>  repository)
        {
            this.repository = repository;

        }

       

        // GET: api/<AuthController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AuthController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string username, string password)
        {
            try
            {
                if (!(string.IsNullOrEmpty(username) && string.IsNullOrEmpty(password)))
                {
                    var result = repository.Login(username, password); //need token and a flag (for valid or invalid login)
                                                                       //if succesful send token
                    if (result.Item1)
                    {
                        return Ok(result.Item2);
                    }
                    //if failed failure has to be sent, inavlid credentials or internal server error
                    else
                    {
                        return BadRequest("Invalid Credentials");
                    }
                }
            }
            catch (Exception ex) //Internal Server error
            {

                return StatusCode(500, "Internal Server Error");
            }
            return BadRequest("Please pass both username and pass");
        }

        // POST api/<AuthController>
        //to register new user and signing up
        [HttpPost]
        public IActionResult Post([FromForm] UserEntity user)
        {
            // Server side validation
            if (ModelState.IsValid)
            {
                //pass to repo so that it can act on it
                var isSuccess = repository.Signup(user);
                if (isSuccess)
                {
                    return Ok("User registered successfully");
                }
                return StatusCode(500, "Internal Server Error");
;
            }

            return BadRequest(ModelState);
        }

      
    }
}
