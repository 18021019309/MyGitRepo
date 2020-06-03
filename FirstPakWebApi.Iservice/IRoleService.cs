using FirstPakWebApi.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstPakWebApi.IService
{
    public interface IRoleService
    {
        ViewPageResult<ViewRole> GetRoleList(int page, int limit);
        IEnumerable<ViewDropDownList> GetRoleName();
        ViewRole GetRoleById(int id);
        bool AddRole(ViewRole role);
        bool UpdateRole(ViewRole role);
        bool DeleteRole(params int[] ids);
    }
}
