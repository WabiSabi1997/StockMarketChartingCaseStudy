using System;
using System.Collections.Generic;
using System.Text;

namespace StockMarketCharting.Models
{
    public class UserEntity
    {
        public long ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public char UserType { get; set; }
        public string Email { get; set; }
        public int Mobile { get; set; }
        public bool Confirmed { get; set; }
    }
}
