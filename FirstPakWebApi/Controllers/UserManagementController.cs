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
    public class UserManagementController : BaseController
    {
        private readonly IEmployeeInfoService _employeeInfoService;
        public UserManagementController(IEmployeeInfoService employeeInfoService)
        {
            this._employeeInfoService = employeeInfoService;
        }
        /// <summary>
        /// 获取员工列表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult GetEmployeeInfo(ViewPage viewPage)
        {
            var data = _employeeInfoService.GetEmployeeInfo(viewPage.page, viewPage.limit); //分页成功
            return Ok(data);
        }
        /// <summary>
        /// 获取员工姓名
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetEmployeeName()
        {
            return Ok(_employeeInfoService.GetEmployeeName());
        }
        /// <summary>
        /// 根据员工Id获取员工信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("id")]
        public IActionResult GetEmployeeInfoById(int id)
        {
            var data = _employeeInfoService.GetEmployeeInfoById(id);
            if (data == null)
                return Ok(new { msg = "不存在该员工信息，获取失败！" });

            return Ok(data);
        }
        /// <summary>
        /// 获取教育水平
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetEducationLevels()
        {
            return Ok(_employeeInfoService.GetEducationLevels());
        }
        /// <summary>
        /// 添加新员工
        /// </summary>
        /// <param name="employeeInfo"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddEmployeeInfo(ViewEmployeeInfo employeeInfo)
        {
            return Ok(_employeeInfoService.GetAddEmployeeInfo(employeeInfo));
        }
        /// <summary>
        /// 更新员工信息 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="employeeInfo"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult UpdateEmployeeInfo(int id, ViewEmployeeInfo employeeInfo)
        {
            if (id != employeeInfo.Id)
                return BadRequest();

            return Ok(_employeeInfoService.GetUpdateEmployeeInfo(employeeInfo));
        }
        /// <summary>
        /// 删除员工信息
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult GetDeleteEmployee(params int[] ids)
        {
            return Ok(_employeeInfoService.DeleteEmployee(ids));
        }
        /// <summary>
        /// 根据部门ID获取员工信息
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetEmployeeInfoByDepartmentId(int departmentId)
        {
            return Ok(_employeeInfoService.GetEmployeeInfoByDepartmentId(departmentId));
        }
    }
}