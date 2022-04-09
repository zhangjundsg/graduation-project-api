using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sys.IService;
using Sys.Model;
using Sys.Model.DBModels;
using System.Threading.Tasks;

namespace Sys.CoreApi.Controllers
{
    /// <summary>
    /// 提交申请
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class FiledOperateController : Controller
    {
        private readonly IFiledOperateService _filedOperate;
        public FiledOperateController(IFiledOperateService filedOperate)
        {
            _filedOperate = filedOperate;
        }
        /// <summary>
        /// 提交申请
        /// </summary>
        /// <param name="filed"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> FiledOperate(Sys_FiledList filed)
        {
            if (await _filedOperate.AddFiled(filed))
            {
                return Json(new ResponseDto() { Code = (int)ResponseCode.Success, Msg = "提交申请成功！" });
            }
            return Json(new ResponseDto() { Code = (int)ResponseCode.CodeError, Msg = "提交申请失败！" });
        }
        /// <summary>
        /// 获取指定ID申请列表
        /// </summary>
        /// <param name="id">用户id</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<JsonResult> GetFiledList(int id)
        {
            var list = await _filedOperate.GetFiledById(id);
            return Json(list);
        }

    }
}
