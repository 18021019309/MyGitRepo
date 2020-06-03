using FirstPakWebApi.Data.Models;
using FirstPakWebApi.ViewModel;
using System;
using System.Collections.Generic;

namespace FirstPakWebApi.IService
{
    public interface IUserService
    {
        User GetUser(ViewAuth auth);
        IEnumerable<ViewUser> GetAuthList(int page, int limit);
        IEnumerable<ViewDropDownList> GetAuthName();
        ViewUser GetAuthInfoById(int id);
        bool GetCreateAuth(ViewUser user);
        bool UpdateAuthInfo(ViewUser viewUser);
        bool DeleteAuth(params int[] ids);
    }
}
