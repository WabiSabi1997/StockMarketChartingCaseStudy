using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StockMarketCharting.Models
{
    public class Sector
    {
        [Key]
        public int SectorID { get; set; }
        [Required]
        public string SectorName { get; set; }
        public string Brief { get; set; }

        //np
        public virtual ICollection<Company> Companies { get; set; }
    }
}
