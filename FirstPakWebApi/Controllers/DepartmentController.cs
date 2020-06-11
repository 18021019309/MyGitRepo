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
    public class DepartmentController : BaseController
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            this._departmentService = departmentService;
        }
        /// <summary>
        /// 获取部门
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult GetDepartments(ViewPage page)
        {
            return Ok(_departmentService.GetDepartments(page.page,page.limit));
        }
        /// <summary>
        /// 获取部门名称
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetDepartmentName()
        {
            return Ok(_departmentService.GetDepartmentName());
        }
        /// <summary>
        /// 添加新部门
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult GetAddDepartment(ViewDepartment department)
        {
            return Ok(_departmentService.AddDepartment(department));
        }
        /// <summary>
        /// 根据Id获取部门信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetDepartmentById(int id)
        {
            return Ok(_departmentService.GetDepartmentById(id));
        }
        /// <summary>
        /// 更新部门信息
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult GetUpdateDepartment(ViewDepartment department)
        {
            return Ok(_departmentService.UpdateDepartment(department));
        }
        /// <summary>
        /// 删除部门
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpDelete]
       public IActionResult DeleteDepartment(params int[] ids)
        {
            return Ok(_departmentService.DeleteDepartment(ids));
        }
        /// <summary>
        /// 获取组织架构信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetOrganizationInfo()
        {
            return Ok(_departmentService.GetOrganization());
        }
    }
}