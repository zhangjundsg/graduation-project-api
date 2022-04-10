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
        /// <summary>
        /// 获取申请列表
        /// </summary>
        /// <param name="index">当前页</param>
        /// <param name="pageSize">页大小</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<JsonResult> GetFiledListAll(int index,int pageSize)
        {
            var list = await _filedOperate.GetAllFiled(index, pageSize);
            return Json(list);
        }
        /// <summary>
        /// 获取申请统计
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<JsonResult> GetFiledStats()
        {
            var list = await _filedOperate.Getstats();
            return Json(list);
        }
        [HttpPut]
        public async Task<JsonResult> UpdateFiledStats(Sys_FiledList filed)
        {
            if (await _filedOperate.UpdataFiled(filed))
            {
                return Json(new ResponseDto() { Code = (int)ResponseCode.Success, Msg = "已审核！" });
            }
            return Json(new ResponseDto() { Code = (int)ResponseCode.CodeError, Msg = "审核失败" });
        }
    }
}
