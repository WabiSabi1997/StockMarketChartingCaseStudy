using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UploadMicroservice.Repositories
{
    public interface IRepository
    {
        void UploadExcel(string filePath);
    }
}
