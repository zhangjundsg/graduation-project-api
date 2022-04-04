using Microsoft.AspNetCore.Http;
using Sys.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sys.IService
{
    public interface IFileUploadService
    {
        Task<ResponseDto> FileUpload(IFormFile file,string user);
        Task TempFileUpload(IFormFile file);
    }
}
