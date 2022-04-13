using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sys.IService;
using Sys.Model;
using Sys.Model.DBModels;
using System.Threading.Tasks;

namespace Sys.CoreApi.Controllers
{
    /// <summary>
    /// 部门信息
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        /// <summary>
        /// 获取所有部门信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<JsonResult> GetAllDepartment()
        {
            var list = await _departmentService.GetDepartmentList();
            return Json(list);
        }
        /// <summary>
        /// 添加部门
        /// </summary>
        /// <param name="depart">部门信息</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> AddDepartment(Sys_Department depart)
        {
            if (await _departmentService.InsertDepartObj(depart))
            {
                return Json(new ResponseDto() { Code = (int)ResponseCode.Success, Msg = "添加成功！" });
            } 
            return Json(new ResponseDto() { Code = (int)ResponseCode.CodeError, Msg = "添加失败！" });
        }
        /// <summary>
        /// 更新部门信息
        /// </summary>
        /// <param name="depart">部门信息</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<JsonResult> UpdateDepartment(Sys_Department depart)
        {
            if (await _departmentService.UpdateDepartObj(depart))
            {
                return Json(new ResponseDto() { Code = (int)ResponseCode.Success, Msg = "更新成功！" });
            }
            return Json(new ResponseDto() { Code = (int)ResponseCode.CodeError, Msg = "更新失败！" });
        }
       /// <summary>
       /// 删除部门
       /// </summary>
       /// <param name="id">部门ID</param>
       /// <returns></returns>
        [HttpDelete]
        public async Task<JsonResult> DeleteDepartment(int id)
        {
            if (await _departmentService.DeleteDepartObj(id))
            {
                return Json(new ResponseDto() { Code = (int)ResponseCode.Success, Msg = "删除成功！" });
            }
            return Json(new ResponseDto() { Code = (int)ResponseCode.CodeError, Msg = "删除失败！当前部门有关联数据！" });
        }
    }
}
