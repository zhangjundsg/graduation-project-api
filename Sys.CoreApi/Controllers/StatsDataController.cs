using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sys.IService;
using System.Threading.Tasks;

namespace Sys.CoreApi.Controllers
{
    /// <summary>
    /// 统计数据接口
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class StatsDataController : Controller
    {
        private readonly IStatsDataService _statsData;
        public StatsDataController(IStatsDataService statsData)
        {
            _statsData = statsData;
        }

        [HttpGet]
        public async Task<JsonResult> StatsData()
        {
            var list = await _statsData.FiledStatsData();
            return Json(list);
        }

    }
}
