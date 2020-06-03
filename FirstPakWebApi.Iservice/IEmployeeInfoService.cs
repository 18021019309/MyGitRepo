using FirstPakWebApi.Data.Models;
using FirstPakWebApi.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstPakWebApi.IService
{
    public interface IEmployeeInfoService
    {
        //IEnumerable<ViewEmployeeInfo> GetEmployeeInfo(int page,int limit);
        ViewPageResult<ViewEmployeeInfo> GetEmployeeInfo(int page, int limit);
        IEnumerable<ViewDropDownList> GetEducationLevels();
        ViewEmployeeInfo GetEmployeeInfoById(int id);
        bool GetUpdateEmployeeInfo(ViewEmployeeInfo employeeInfo);
        bool GetAddEmployeeInfo(ViewEmployeeInfo employeeInfo);
        bool DeleteEmployee(params int[] ids);
        IEnumerable<ViewDropDownList> GetEmployeeName();
        ViewEmployeeInfo GetPersonalInfo(int userId);
    }
}
