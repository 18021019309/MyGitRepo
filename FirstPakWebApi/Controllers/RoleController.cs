using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstPakWebApi.IService;
using FirstPakWebApi.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstPakWebApi.Controllers
{
    public class RoleController : BaseController
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            this._roleService = roleService;
        }
        /// <summary>
        /// 获取角色
        /// </summary>
        /// <param name="viewPage"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult GetRoleList(ViewPage viewPage)
        {
            return Ok(_roleService.GetRoleList(viewPage.page,viewPage.limit));
        }
        /// <summary>
        /// 获取角色名称
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetRoleName()
        {
            return Ok(_roleService.GetRoleName());
        }
        /// <summary>
        /// 根据Id获取角色信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetRoleById(int id)
        {
            return Ok(_roleService.GetRoleById(id));
        }
        /// <summary>
        /// 添加新角色
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult GetAddRole(ViewRole role)
        {
            return Ok(_roleService.AddRole(role));
        }
        /// <summary>
        /// 更新角色信息
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult GetUpdateRole(ViewRole role)
        {
            return Ok(_roleService.UpdateRole(role));
        }
        /// <summary>
        /// 删除角色信息
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult GetDeleteRole(params int[] ids)
        {
            return Ok(_roleService.DeleteRole(ids));

        }
    }
}