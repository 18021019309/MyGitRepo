using AutoMapper;
using FirstPakWebApi.Data;
using FirstPakWebApi.IService;
using FirstPakWebApi.ViewModel;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using FirstPakWebApi.Data.Models;

namespace FirstPakWebApi.Service
{
    public class MenuService : BaseService, IMenuService
    {
        public MenuService(FirstPakDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        //public IEnumerable<ViewMenu> GetMenus(int userId)
        //{
        //    return Function(context =>
        //    {
        //        var roleIds = context.UserRoles.Where(x => x.UserId == userId).Select(x => x.RoleId);
        //        var menus = context.MenuRoles.Where(x => roleIds.Contains(x.RoleId)).Select(s => s.Menu).Where(w => w.ParentId == null);
        //        var data = menus.ToList();
        //        return Mapper.Map<IEnumerable<ViewMenu>>(menus.ToList());
        //    });
        //}
        public IEnumerable<ViewMenu> GetMenus(int userId)
        {
            return Function(context =>
            {
                var roleIds = context.UserRoles.Where(x => x.UserId == userId).Select(x => x.RoleId);
                var data = roleIds.ToList();
                var menus = context.MenuRoles.Where(x => roleIds.Contains(x.RoleId)).Select(s => s.Menu);
                var menuData = Mapper.Map<IEnumerable<ViewMenu>>(menus.ToList());
                List<ViewMenu> menu = new List<ViewMenu>();
                foreach (var item in menuData)
                {
                    if (item.ParentId == null)
                    {
                        ViewMenu MenuInfo = new ViewMenu();
                        MenuInfo.Id = item.Id;
                        MenuInfo.MenuName = item.MenuName;
                        MenuInfo.MenuUrl = item.MenuUrl;
                        MenuInfo.MenuCode = item.MenuCode;
                        MenuInfo.Depth = item.Depth;
                        MenuInfo.ParentId = item.ParentId;
                        MenuInfo.Children = GetChildMenu(menuData, item.Id);
                        menu.Add(MenuInfo);
                    }
                }
                return menu;
            });
        }
        private List<ViewMenu> GetChildMenu(IEnumerable<ViewMenu> viewMenus, int menuId)
        {
            List<ViewMenu> menus = new List<ViewMenu>();
            foreach (var item in viewMenus.Where(p => p.ParentId == menuId))
            {
                ViewMenu MenuInfo = new ViewMenu();
                MenuInfo.Id = item.Id;
                MenuInfo.MenuName = item.MenuName;
                MenuInfo.MenuUrl = item.MenuUrl;
                MenuInfo.MenuCode = item.MenuCode;
                MenuInfo.Depth = item.Depth;
                MenuInfo.ParentId = item.ParentId;
                MenuInfo.Children = GetChildMenu(viewMenus, item.Id);
                menus.Add(MenuInfo);
            }
            return menus;
        }
        public bool GetMenuRole(int[] menuIds, int roleId)
        {
            return Function(context =>
            {
                foreach (var item in menuIds)
                {
                    MenuRole menuRole = new MenuRole
                    {
                        MenuId = item,
                        RoleId = roleId
                    };
                    Create<MenuRole>(menuRole);
                }
                return true;
            });
        }
    }
}
