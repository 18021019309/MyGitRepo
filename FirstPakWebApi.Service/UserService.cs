using AutoMapper;
using FirstPakWebApi.Data;
using FirstPakWebApi.Data.Models;
using FirstPakWebApi.IService;
using FirstPakWebApi.ViewModel;
using LinqPagination;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FirstPakWebApi.Service
{
    public class UserService : BaseService, IUserService
    {
        public UserService(FirstPakDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public User GetUser(ViewAuth auth)
            => Function(context => context
                    .Users.Include(x => x.UserRoles)
                    .FirstOrDefault(u =>
                          u.Account == auth.Account
                        & u.Password == auth.Password));


        public IEnumerable<ViewUser> GetAuthList(int page, int limit)
        {
            return Function(context =>
            {
                return context.UserRoles.Pagination(page, limit).ToList().GroupBy(p => p.UserId)
                .Select(s => new ViewUser
                {
                    //UserId = s.Key,
                    Id = s.FirstOrDefault().User.Id,
                    Account = s.FirstOrDefault().User.Account,
                    Password = s.FirstOrDefault().User.Password,
                    Remarks=s.FirstOrDefault().User.Remarks,
                    RoleIds = s.Select(x => x.RoleId).ToList(),
                });

            });
        }
        //public ViewPageResult<ViewUser> GetAuth(int page,int limit)
        //{
        //    return Function(context =>
        //    {
        //        var data = context.UserRoles.ToList().GroupBy(p => p.UserId)
        //        .Select(s => new ViewUser
        //        {
        //            Id = s.FirstOrDefault().User.Id,
        //            Account = s.FirstOrDefault().User.Account,
        //            Password = s.FirstOrDefault().User.Password,
        //            RoleIds = s.Select(x => x.RoleId).ToList(),
        //        }).PaginationToResult(page, limit);
        //    });
        //}
        public IEnumerable<ViewDropDownList> GetAuthName()
        {
            return Function(context =>
            {
                return Mapper.Map<IEnumerable<ViewDropDownList>>(context.Users.Select(x => new User { Id = x.Id, Account = x.Account }).ToList());
            });
        }
        public ViewUser GetAuthInfoById(int id)
        {
            return Function(context =>
            {
                return context.UserRoles.ToList().GroupBy(p => p.UserId)
                .Select(s => new ViewUser
                {
                    Id = s.FirstOrDefault().User.Id,
                    Account = s.FirstOrDefault().User.Account,
                    Password = s.FirstOrDefault().User.Password,
                    Remarks = s.FirstOrDefault().User.Remarks,
                    RoleIds = s.Select(x => x.RoleId).ToList(),
                }).FirstOrDefault(w => w.Id == id);

            });
        }
        public bool GetCreateAuth(ViewUser user)
        {
            return Function(context =>
            {
                bool result = Create(Mapper.Map<User>(user));
                if (result)
                {
                    int userId = context.Users.Where(w => w.Account == user.Account & w.Password == user.Password).Select(x => x.Id).FirstOrDefault();
                    foreach (var item in user.RoleIds)
                    {
                        UserRole userRole = new UserRole
                        {
                            UserId = userId,
                            RoleId = item
                        };
                        Create(userRole);
                    }
                    return true;
                }       
                return false;
            });
        }
        public bool UpdateAuthInfo(ViewUser viewUser)
        {
            return Function(context =>
            {
                context.RemoveRange(context.UserRoles.Where(x => x.UserId == viewUser.Id));
                var result=context.SaveChanges();
                if (result>0)
                {
                    foreach (var item in viewUser.RoleIds)
                    {
                        UserRole userRole = new UserRole
                        {
                            UserId = viewUser.Id,
                            RoleId = item
                        };
                        Create(userRole);
                    }
                    return Update(Mapper.Map<User>(viewUser));
                }
                return false;
            });
        }
        public bool DeleteAuth(params int[] ids)
        {
            return Function(context =>
            {
                return Delete<User>(ids);
            });
        }
    }
}
