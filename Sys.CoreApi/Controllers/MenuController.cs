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
        private readonly IMenuList _menuList;
        public MenuController(IMenuList menuList) 
        {
            _menuList = menuList;
        }
        /// <summary>
        /// 获取菜单列表
        /// </summary>
        [HttpGet]
        public JsonResult GetMenuList()
        {
            var MenuList = _menuList.GetMenuList();
            return Json(MenuList);
        }
    }
}
