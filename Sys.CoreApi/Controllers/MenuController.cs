using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sys.IRepository;
using Sys.Model.DBModel;
using System.Collections.Generic;
using System.Linq;

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
        private readonly IMenu _menu;
        public MenuController(IMenu menu) 
        {
            _menu = menu;
        }
        /// <summary>
        /// 获取菜单列表
        /// </summary>
        [HttpGet]
        public List<MenuInformation> GetMenuList()
        {
            var MenuList = _menu.MenuList().ToList();
            return MenuList;
        }
    }
}
