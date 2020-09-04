using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StockMarketCharting.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Username { get; set; }
        [Required]
        [StringLength(50,MinimumLength =6)]
        public string Password { get; set; }

        [Required]
        public int UserType { get; set; } //1 for admin and 2 for user
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required]
        public long Mobile { get; set; } //long makes the validation easier
        
        public bool Confirmed { get; set; }
    }
}
