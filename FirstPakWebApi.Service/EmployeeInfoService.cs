using AutoMapper;
using FirstPakWebApi.Data;
using FirstPakWebApi.Data.Models;
using FirstPakWebApi.IService;
using FirstPakWebApi.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using LinqPagination;

namespace FirstPakWebApi.Service
{
    public class EmployeeInfoService : BaseService, IEmployeeInfoService
    {
        public EmployeeInfoService(FirstPakDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        //public IEnumerable<ViewEmployeeInfo> GetEmployeeInfo(int page,int limit)
        //{
        //    return Function(context =>
        //    {
        //        return Mapper.Map<IEnumerable<ViewEmployeeInfo>>(context.EmployeeInfos.Pagination(page, limit).ToList());
        //        //var data = context.EmployeeInfos.PaginationToResult(page, pageSize);
        //        //return new List<ViewEmployeeInfo>();
        //        //var data = context.EmployeeInfos.ToList();
        //        //return Mapper.Map<IEnumerable<ViewEmployeeInfo>>(context.EmployeeInfos.ToList());
        //    });
        //}
        public ViewPageResult<ViewEmployeeInfo> GetEmployeeInfo(int page, int limit)
        {
            return Function(context =>
            {
                var data = context.EmployeeInfos.PaginationToResult(page, limit);
                return MapPage<EmployeeInfo, ViewEmployeeInfo>(context.EmployeeInfos.PaginationToResult(page, limit));
            });
        }
        public ViewEmployeeInfo GetEmployeeInfoById(int id)
        {
            return Function(context =>
            {
                return Mapper.Map<ViewEmployeeInfo>(context.EmployeeInfos.FirstOrDefault(e => e.Id == id));
            });
        }
        public IEnumerable<ViewDropDownList> GetEducationLevels()
        {
            return Function(context =>
            {
                return Mapper.Map<IEnumerable<ViewDropDownList>>(context.EducationLevels.ToList());
            });
        }
        public bool GetUpdateEmployeeInfo(ViewEmployeeInfo employeeInfo)
        {
            return Function(context =>
            {
                return Update(Mapper.Map<EmployeeInfo>(employeeInfo));
            });
        }
        public bool GetAddEmployeeInfo(ViewEmployeeInfo employeeInfo)
        {
            return Function(context =>
            {
                return Create(Mapper.Map<EmployeeInfo>(employeeInfo));
            });
        }
        public IEnumerable<ViewDropDownList> GetEmployeeName()
        {
            return Function(context =>
            {
                return Mapper.Map<IEnumerable<ViewDropDownList>>(context.EmployeeInfos.Select(x => new EmployeeInfo { Id = x.Id, UserName = x.UserName }).ToList());
            });
        }
        public bool DeleteEmployee(params int[] ids)
        {
            return Function(context =>
            {
                return Delete<EmployeeInfo>(ids);
            });
        }
        public ViewEmployeeInfo GetPersonalInfo(int userId)
        {
            return Function(context =>
            {
                var data = Mapper.Map<ViewEmployeeInfo>(context.EmployeeInfos.FirstOrDefault(e => e.User.Id == userId));
                if (data == null)
                {
                    return new ViewEmployeeInfo { Remarks = "不存在与该账号匹配的员工信息！" };
                }
                else
                {
                    return data;
                }
            });
        }
      
    }
}

