using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sys.IService;

namespace Sys.CoreApi.Controllers
{
    /// <summary>
    /// 菜单
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MenuController : Controller
    {
        private readonly IMenuService _menuList;
        public MenuController(IMenuService menuList) 
        {
            _menuList = menuList;
        }
        /// <summary>
        /// 获取菜单列表
        /// </summary>
        [HttpGet]
        public JsonResult GetMenuList(int id)
        {
            var list = _menuList.MenuList(id);
            return Json(list);
        }
    }
}
