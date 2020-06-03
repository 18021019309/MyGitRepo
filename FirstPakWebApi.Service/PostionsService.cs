using AutoMapper;
using FirstPakWebApi.Data;
using FirstPakWebApi.Data.Models;
using FirstPakWebApi.IService;
using FirstPakWebApi.ViewModel;
using LinqPagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace FirstPakWebApi.Service
{
    public class PostionsService : BaseService, IPostionsService
    {
        public PostionsService(FirstPakDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public ViewPageResult<ViewPosition> GetPostions(int page, int limit)
        {
            return Function(context =>
            {
                return MapPage<Position, ViewPosition>(context.Positions.PaginationToResult(page, limit));
            });
        }
        public IEnumerable<ViewDropDownList> GetPostionName()
        {
            return Function(context =>
            {
                return Mapper.Map<IEnumerable<ViewDropDownList>>(context.Positions.Select(x => new Position { Id = x.Id, PositionName = x.PositionName })).ToList();
            });
        }
        public ViewPosition GetPostionById (int id)
        {
            return Function(context =>
            {
                return Mapper.Map<ViewPosition>(context.Positions.FirstOrDefault(x => x.Id == id));
            });
        }
        public bool AddPostion(ViewPosition position)
        {
            return Function(context =>
            {
                return Create(Mapper.Map<Position>(position));
            });
        }
        public bool UpdatePostion(ViewPosition position)
        {
            return Function(context =>
            {
                return Update(Mapper.Map<Position>(position));
            });
        }
        public bool DeletePostion(params int[] ids)
        {
            return Function(context =>
            {
                foreach (var item in ids)
                {
                    var data = context.Positions.FirstOrDefault(x => x.SuperiorId == item);
                    if (data == null)
                    {
                        return Delete<Position>(ids);
                    }
                    else
                    {
                        data.SuperiorId = 0;
                        context.Attach(data);
                        context.Entry(data).Property(p => p.SuperiorId).IsModified = true;
                        context.SaveChanges();
                    }
                }
                return Delete<Position>(ids);
            });
        }

    }

}
