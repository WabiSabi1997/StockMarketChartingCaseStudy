using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StockMarketCharting.Models
{
    public class UserEntity
    {
        public long ID { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public char UserType { get; set; }
        //Change to enum with User and Admin
        [EmailAddress]
        public string Email { get; set; }
        public long Mobile { get; set; }
        public bool Confirmed { get; set; }
    }
}
