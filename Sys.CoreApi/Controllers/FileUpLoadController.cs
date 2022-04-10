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
        /// <summary>
        /// 文件上传
        /// </summary>
        /// <param name="file"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> Upload(IFormFile file,string user)
        {
            var result = await _fileUpload.FileUpload(file, user);
            return Json(result);
        }
        /// <summary>
        /// 临时上传
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task UploadTemp(IFormFile file)
        {
            await _fileUpload.TempFileUpload(file);
        }
        /// <summary>
        /// 文件下载
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> DownloadFile()
        {
            var file = await _fileUpload.DownloadFile();
            return File(file, "application/octet-stream","人员信息.xlsx");
        }
    }
}
