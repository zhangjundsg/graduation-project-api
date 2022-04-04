using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sys.IService;
using Sys.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sys.CoreApi.Controllers
{
    /// <summary>
    /// 菜单
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class MenuController : Controller
    {
        private readonly IMenuService _menuService;
        public MenuController(IMenuService menuService) 
        {
            _menuService = menuService;
        }
        /// <summary>
        /// 根据用户ID获取菜单
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<JsonResult> GetMenuList(int id)
        {
            var list = await _menuService.MenuListByID(id);
            return Json(list);
        }
       /// <summary>
       /// 获取所有菜单
       /// </summary>
       /// <returns></returns>
        [HttpGet]
        public async Task<JsonResult> GetAllMenuList()
        {
            var list = await _menuService.AllMenuList();
            return Json(list);
        }
        /// <summary>
        /// 根据角色ID获取菜单数组
        /// </summary>
        /// <param name="roleID">角色ID</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<JsonResult> GetMenuArray(int roleID)
        {
            var list = await _menuService.MenuArrayByRoleID(roleID);
            return Json(list);
        }
        /// <summary>
        /// 更新角色菜单
        /// </summary>
        /// <param name="menuDto">菜单数据及角色id</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> UpdateMenu([FromBody] UpdateMenuDto menuDto)
        {
            if (await _menuService.UpdateMenu(menuDto.roleID, menuDto.menuID))
            {
                return Json(new ResponseDto() { Code = (int)ResponseCode.Success, Msg = "更新成功" });
            }
            return Json(new ResponseDto() { Code = (int)ResponseCode.CodeError, Msg = "更新失败" });
        }

    }
}
