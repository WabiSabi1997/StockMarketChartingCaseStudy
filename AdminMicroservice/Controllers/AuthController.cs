using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthMicroservice.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StockMarketCharting.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AuthMicroservice.Controllers
{   
    public class AuthDetails
    {
        public int utype;
        public string token;
    }
    [Route("api/[controller]")]
    [ApiController]
    
    public class AuthController : ControllerBase
    {
        private IRepository<User> repository;

        public AuthController(IRepository<User> repository)
        {
            this.repository = repository;
        }
        // GET: api/<AuthController>
        [HttpGet]
      //  [Authorize(Roles = "Admin,User")]
        public IActionResult Get(string username, string password)
        {

            if (!(string.IsNullOrEmpty(username) && string.IsNullOrEmpty(password)))
            {
                try
                {
                    var result = repository.Login(username, password);
                    //success -> token
                    if (result.Item1)
                    {
                        AuthDetails authdetails = new AuthDetails { utype = result.Item2, token = result.Item3 };
                        return Ok(authdetails);
                    }
                    else
                    {
                        return BadRequest("Invalid Credentials");
                    }
                }
                catch (Exception e)
                {

                    return StatusCode(500, e.Message);
                }
            }
            else
            {
                return BadRequest("Please pass both username and password");
            }

            
            //return new string[] { "value1", "value2" };
        }

        // GET api/<AuthController>/5
       /* [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        } */

        // POST api/<AuthController>
        //register new user/signup
        [HttpPost]
       // [Authorize(Roles = "Admin,User")]
        public IActionResult Post(User user)
        {
            //if (ModelState.IsValid)
            //{
            var isSuccess = repository.Signup(user);
            if (isSuccess)
            {
                return Ok("User registered successfully");
            }
            return StatusCode(500, "Internal Server Error");
            //}
            //return BadRequest(ModelState);
        }

    }
}
