using System;
using System.Collections.Generic;
using System.Text;

namespace StockMarketCharting.Models
{
    public class ConString
    {
        public ConString()
        {
            //connectionString = "Server=RISHABH-JAIN;";
            connectionString = "Server=C2WFDOTNET48\\MSSQLSERVER01;";
        }
        public string connectionString { get; }
    }
}
