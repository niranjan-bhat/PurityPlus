using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurityPlus.Services.Interface
{
    public interface IAwsS3Service
    {
        Task<string> UploadProductImage(string imgUrl);
    }
}
