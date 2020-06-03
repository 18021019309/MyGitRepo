﻿using AutoMapper;
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
    public class DepartmentService: BaseService, IDepartmentService
    {
        public DepartmentService(FirstPakDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public ViewPageResult<ViewDepartment> GetDepartments(int page,int limit)
        {
            return Function(context =>
            {
                return MapPage<Department, ViewDepartment>(context.Departments.PaginationToResult(page, limit));
            });
        }
        public IEnumerable<ViewDropDownList> GetDepartmentName()
        {
            return Function(context =>
            {
                return Mapper.Map<IEnumerable<ViewDropDownList>>(context.Departments.Select(x => new Department { Id = x.Id, DepartmentName = x.DepartmentName }).ToList());
            });
        }
        public ViewDepartment GetDepartmentById(int id)
        {
            return Function(context =>
            {
                return Mapper.Map<ViewDepartment>(context.Departments.FirstOrDefault(x => x.Id == id));
            });
        }
        public bool AddDepartment(ViewDepartment department)
        {
            return Function(context =>
            {
                return Create(Mapper.Map<Department>(department));
            });
        }
        public bool UpdateDepartment(ViewDepartment department)
        {
            return Function(context =>
            {
                return Update(Mapper.Map<Department>(department));
            });
        }
        public bool DeleteDepartment(params int[] ids)
        {
            return Function(context =>
            {
                foreach (var item in ids)
                {
                    var data = context.Departments.FirstOrDefault(x => x.SuperiorDepartmentId == item);
                    if (data == null)
                    {
                        return Delete<Department>(ids);
                    }
                    else
                    {
                        data.SuperiorDepartmentId = 0;
                        context.Attach(data);
                        context.Entry(data).Property(p => p.SuperiorDepartmentId).IsModified = true;
                        context.SaveChanges();
                    }
                }
                return Delete<Department>(ids);
            });
        }
    }
}