using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthMicroservice.Repositories
{
   public interface IRepository<T>
    {
        bool Signup(T entity);
        Tuple<bool,int,string> Login(string username, string password);
        bool Logout();
    }
}
