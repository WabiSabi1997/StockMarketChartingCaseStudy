using StockMarketCharting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyMicroservice.Repositories
{
    public interface ICompanyRepository: IRepository<Company>
    {

        object GetStockPrice(int id, DateTime from, DateTime to);
        object GetbyName(string query);


    }
}
