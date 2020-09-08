using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.IdentityModel.Tokens;
//using StockMarket.AdminService.Models;
using UploadMicroservice.Repositories;
using System;
using System.Collections.Generic;
//using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UploadMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize(Roles = "Admin")]
    public class TestController : ControllerBase
    {
        private IRepository repository;

        public TestController(IRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost("/api/test/upload")]
        public IActionResult Upload(IFormFile file1)
        {
            if (file1 == null)
            {
                return BadRequest("must upload a file");
            }
            //check file extension

            try
            {
                var file = Request.Form.Files[0];
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), "UploadFiles");
                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                   repository.UploadExcel(fullPath);
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }



        private IActionResult GenerateJwtToken(string email,
            IdentityUser user)
        {
            //var claims = new List<Claim>
            //{
            //    new Claim(JwtRegisteredClaimNames.Sub, email),
            //    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            //    new Claim(ClaimTypes.NameIdentifier, user.Id)
            //};

            //var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
            //    configuration["JwtKey"]));
            //var creds = new SigningCredentials(key,
            //    SecurityAlgorithms.HmacSha256);
            //// recommednded is 5 mins
            //var expires = DateTime.Now.AddDays(
            //    Convert.ToDouble(configuration["JwtExpireDays"]));

            //var token = new JwtSecurityToken(
            //    configuration["JwtIssuer"],
            //    configuration["JwtIssuer"],
            //    claims,
            //    expires: expires,
            //    signingCredentials: creds
            //);

            //return Ok(new JwtSecurityTokenHandler().WriteToken(token));
            return Ok();
        }
    }
}
