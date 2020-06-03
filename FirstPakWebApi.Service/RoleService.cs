using AutoMapper;
using FirstPakWebApi.Data;
using FirstPakWebApi.Data.Models;
using FirstPakWebApi.IService;
using FirstPakWebApi.ViewModel;
using LinqPagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FirstPakWebApi.Service
{
    public class RoleService : BaseService, IRoleService
    {
        public RoleService(FirstPakDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public ViewPageResult<ViewRole> GetRoleList(int page, int limit)
        {
            return Function(context =>
            {
                return MapPage<Role, ViewRole>(context.Roles.PaginationToResult(page, limit));
            });
        }
        public IEnumerable<ViewDropDownList> GetRoleName()
        {
            return Function(context =>
            {
                return Mapper.Map<IEnumerable<ViewDropDownList>>(context.Roles.Select(x => new Role { Id = x.Id, RoleName = x.RoleName })).ToList();
            });
        }
        public ViewRole GetRoleById(int id)
        {
            return Function(context =>
            {
                return Mapper.Map<ViewRole>(context.Roles.FirstOrDefault(x => x.Id == id));
            });
        }
        public bool AddRole(ViewRole role)
        {
            return Function(context =>
            {
                return Create(Mapper.Map<Role>(role));
            });
        }
        public bool UpdateRole(ViewRole role)
        {
            return Function(context =>
            {
                return Update(Mapper.Map<Role>(role));
            });
        }
        public bool DeleteRole(params int[] ids)
        {
            return Function(context =>
            {
                return Delete<Role>(ids);
            });
        }
    }
}
