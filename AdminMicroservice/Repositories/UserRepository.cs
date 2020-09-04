//using AuthMicroservice.Contexts;
using DataCreationMicroservice.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using StockMarketCharting.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AuthMicroservice.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private StockMarketContext context;
        private IConfiguration configuration;

        public UserRepository(StockMarketContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }
        public Tuple<bool,string> Login(string username, string password)
        {
            try
            {
                Tuple<bool, string> result;
                var user = context.Users.FirstOrDefault(u => u.Username == username && u.Password == password && u.Confirmed);
                if (user == null)
                {
                    result = new Tuple<bool, string>(false, "");
                }
                else
                {
                    var token = GenerateJwtToken(user);
                    result = new Tuple<bool, string>(true, token);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string GenerateJwtToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role, user.UserType.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                configuration["JwtKey"]));
            var creds = new SigningCredentials(key,
                SecurityAlgorithms.HmacSha256);
            // recommednded is 5 mins
            var expires = DateTime.Now.AddDays(
                Convert.ToDouble(configuration["JwtExpireDays"]));

            var token = new JwtSecurityToken(
                configuration["JwtIssuer"],
                configuration["JwtIssuer"],
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
            //return Ok();
        }

        public bool Logout()
        {
            throw new NotImplementedException();
        }

        public bool Signup(User entity)
        {
            try
            {
                entity.Confirmed = true;
                context.Users.Add(entity);
                int updates = context.SaveChanges();
                if (updates > 0)
                {
                    return true;
                }
                return false;

            }
            catch(Exception e)
            {
                return false;
            }
        }
    }
}
