using System;
using System.Linq;
using System.Security.Claims;
using FirstPakWebApi.IService;
using FirstPakWebApi.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstPakWebApi.Controllers
{
    public class PersonalInfoController : BaseController
    {
        private readonly IEmployeeInfoService _employeeInfoService;
        public PersonalInfoController(IEmployeeInfoService employeeInfoService)
        {
            this._employeeInfoService = employeeInfoService;
        }

        /// <summary>
        /// 获取个人信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetPersonalInfo()
        {
            return Ok(_employeeInfoService.GetPersonalInfo(Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault()?.Value)));
        }
        /// <summary>
        /// 修改个人信息
        /// </summary>
        /// <param name="employeeInfo"></param>
        /// <returns></returns>
        [HttpPost]
       public IActionResult GetUpdatePersonalInfo(ViewEmployeeInfo employeeInfo)
        {
            return Ok(_employeeInfoService.GetUpdateEmployeeInfo(employeeInfo));
        }
    }
}