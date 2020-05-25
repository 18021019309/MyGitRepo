using FirstPakWebApi.IService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FirstPakWebApi.Controllers
{
    public class MenuController : BaseController
    {
        IMenuService _menuiService;
        public MenuController(IMenuService menuiService)
        {
            this._menuiService = menuiService;
        }
        /// <summary>
        /// 获取菜单列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetMenus()
        {
            var userId = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);
            return Ok(_menuiService.GetMenus(Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value)));
        }
        /// <summary>
        /// 为菜单分配角色
        /// </summary>
        /// <param name="menuIds"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult getMenuRole(int[] menuIds,int roleId)
        {
            return Ok(_menuiService.GetMenuRole(menuIds,roleId));
        }
        /// <summary>
        /// 根据角色ID获取菜单权限
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetMenuRoleByRoleId(int roleId)
        {
            return Ok(_menuiService.GetMenuRoleById(roleId));
        }
    }
}
