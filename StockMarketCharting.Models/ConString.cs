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
            //connectionString = "Server=C2WFDOTNET48\\MSSQLSERVER01;";
            connectionString = "Server=tcp:stockmarket1997.database.windows.net,1433;Initial Catalog=StockMarketDBMaster;Persist Security Info=False;User ID=snigdha;Password=asdffdsa@19S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
        }
        public string connectionString { get; }
    }
}
