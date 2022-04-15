using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sys.IService;
using Sys.Model;
using Sys.Model.DBModels;
using System.Threading.Tasks;

namespace Sys.CoreApi.Controllers
{
    /// <summary>
    /// 工资账套接口
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SalaryController : Controller
    {
        private readonly ISalaryService _salary;
        public SalaryController(ISalaryService salary)
        {
            _salary= salary;
        }
        /// <summary>
        /// 获取所有账套数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<JsonResult> GetSalaryData()
        {
            var list = await _salary.GetSalaryDataList();
            return Json(list);
 
        }
        /// <summary>
        /// 更新工资账套
        /// </summary>
        /// <param name="salary">账套</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<JsonResult> UpdateSalary(Sys_Salary salary)
        {
            if (await _salary.UpdateSalary(salary))
            {
                return Json(new ResponseDto() { Code = (int)ResponseCode.Success, Msg = "更新成功！" });
            }
            return Json(new ResponseDto() { Code = (int)ResponseCode.CodeError, Msg = "更新失败！" });
        }
    }
}
