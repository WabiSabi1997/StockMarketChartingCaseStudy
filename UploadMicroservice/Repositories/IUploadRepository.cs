using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UploadMicroservice.Repositories
{
    public interface IUploadRepository
    {
        void UploadExcel(string filePath);
    }
}
