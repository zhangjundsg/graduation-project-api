using Microsoft.AspNetCore.Http;
using Sys.Common;
using Sys.IRepository;
using Sys.IService;
using Sys.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Sys.Service
{
    public class FileUploadService : IFileUploadService
    {
        private readonly IUserRepository _userRepository;
        public FileUploadService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<ResponseDto> FileUpload(IFormFile file, string user)
        {
            var size = AppConfigurtaion.GetConfigStr("FileOptions:fileSize");
            var fileType = AppConfigurtaion.GetConfigObj("FileOptions:fileType");
            var filePath = Path.Combine(AppConfigurtaion.GetConfigObj("FileOptions:filePath"), user);
            if (file.Length > Convert.ToInt64(size))
            {
                return new ResponseDto() { Code = (int)ResponseCode.CodeError, Msg = "文件过大！" };
            }
            if (!fileType.Contains(Path.GetExtension(file.FileName)))
            {
                return new ResponseDto() { Code = (int)ResponseCode.CodeError, Msg = "类型错误！" };
            }
            if (file.Length > 0)
            {
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                using (var stream = File.Create(Path.Combine(filePath, file.FileName)))
                {
                    await file.CopyToAsync(stream);
                }
                return new ResponseDto() { Code = (int)ResponseCode.Success, Msg = "上传成功！" };
            }
            return new ResponseDto() { Code = (int)ResponseCode.CodeError, Msg = "未知错误！" };
        }
        public async Task TempFileUpload(IFormFile file)
        {
            var filePath = @"E:\System_Uploads";
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            if (file.Length > 0)
            {
                using (var stream = File.Create(Path.Combine(filePath, file.FileName)))
                {
                    await file.CopyToAsync(stream);
                }
            }
        }
        public async Task<byte[]> DownloadFile()
        {
            var data = await _userRepository.GetAll();
            var listheader = new List<string> { "编号", "姓名", "加入时间", "邮箱", "职位", "部门" };
            return ExcelHelper.CreateExcelFromList(data,listheader);
        }
    }
}
