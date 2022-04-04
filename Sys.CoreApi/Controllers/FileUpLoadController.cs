using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sys.Common;
using Sys.IService;
using Sys.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Sys.CoreApi.Controllers
{
    /// <summary>
    /// 文件上传
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class FileUpLoadController : Controller
    {
        private readonly IFileUploadService _fileUpload;
        public FileUpLoadController(IFileUploadService fileUpload)
        {
            _fileUpload = fileUpload;
        }
        [HttpPost]
        public async Task<JsonResult> Upload(IFormFile file,string user)
        {
            var result = await _fileUpload.FileUpload(file, user);
            return Json(result);
        }
        [HttpPost]
        public async Task UploadTemp(IFormFile file)
        {
            await _fileUpload.TempFileUpload(file);
        }
    }
}
