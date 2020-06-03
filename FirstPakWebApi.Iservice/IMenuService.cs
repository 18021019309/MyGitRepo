using FirstPakWebApi.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstPakWebApi.IService
{
    public interface IMenuService
    {
        IEnumerable<ViewMenu> GetMenus(int userId);
        bool GetMenuRole(int[] menuIds, int roleId);
    }
}
