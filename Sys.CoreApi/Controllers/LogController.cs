using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sys.IService;
using System.Threading.Tasks;

namespace Sys.CoreApi.Controllers
{
    /// <summary>
    /// 日志接口
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class LogController : Controller
    {
        private readonly ILogService _log;
        public LogController(ILogService log)
        {
            _log = log;
        }
        /// <summary>
        /// 获取所有日志
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<JsonResult> GetLogList(int PageIndex,int PageSize)
        {
            var list = await _log.GetLogs(PageIndex, PageSize);
            return Json(list);
        }
    }
}
