using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using AutoMapper;
using FirstPakWebApi.Data;
using FirstPakWebApi.Data.Models;
using FirstPakWebApi.ViewModel;
using LinqPagination;
using Microsoft.EntityFrameworkCore;

namespace FirstPakWebApi.Service
{
    public class BaseService
    {
        private FirstPakDbContext context { get; set; }
        protected IMapper Mapper;

        protected BaseService(FirstPakDbContext context, IMapper mapper)
        {
            this.context = context;
            Mapper = mapper;
        }

        protected T Function<T>(Func<FirstPakDbContext, T> @func) => func(context);

        protected void Action<T>(Action<FirstPakDbContext> @action) => action(context);
        protected ViewPageResult<Describe> MapPage<Source, Describe>(PageResult<Source> source) => Mapper.Map<ViewPageResult<Describe>>(source);
        protected ViewPageResult<Source> MapPage<Source>(PageResult<Source> source) => Mapper.Map<ViewPageResult<Source>>(source);
        protected bool Create<T>(T model) where T : class, IEntity
        {
            return Function(context =>
            {
                var entry = context.Attach(model);
                entry.State = EntityState.Added;
                return context.SaveChanges() > 0;
            });
        }
        protected bool Update<T>(T model, params Expression<Func<T, object>>[] prop) where T : class, IEntity
        {
            return Function(context =>
            {
                var entry = context.Attach(model);
                entry.State = EntityState.Modified;
                foreach (var item in prop)
                {
                    entry.Property(item).IsModified = false;
                }
                return context.SaveChanges() > 0;
            });
        }
        protected bool Delete<T>(params int[] keys) where T : class, IEntity
        {
            return Function(context =>
            {
                context.RemoveRange(context.Set<T>().Where(x => keys.Contains(x.Id)));
                return context.SaveChanges() > 0;
            });
        }

    }
}
