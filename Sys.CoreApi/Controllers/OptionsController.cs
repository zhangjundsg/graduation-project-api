using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sys.IService;
using Sys.Model.DBModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sys.CoreApi.Controllers
{
    /// <summary>
    /// 系统配置
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class OptionsController : Controller
    {
        private readonly IOptionsService _options;
        public OptionsController(IOptionsService options)
        {
            _options = options;
        }
        /// <summary>
        /// 获取系统参数
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<JsonResult> GetSysOptions()
        {
            var list = await _options.GetAllOptions();
            return Json(list);
        }
        /// <summary>
        /// 修改系统参数
        /// </summary>
        /// <param name="options">参数</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<bool> UpdateSysOptions(Sys_Options options)
        {
            return await _options.UpdateOptions(options);
        }
    }
}
