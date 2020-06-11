using FirstPakWebApi.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstPakWebApi.IService
{
    public interface IDepartmentService
    {
        ViewPageResult<ViewDepartment> GetDepartments(int page, int limit);
        bool AddDepartment(ViewDepartment department);
        IEnumerable<ViewDropDownList> GetDepartmentName();
        ViewDepartment GetDepartmentById(int id);
        bool UpdateDepartment(ViewDepartment department);
        bool DeleteDepartment(params int[] ids);
        IEnumerable<ViewOrganization> GetOrganization();
    }
}
