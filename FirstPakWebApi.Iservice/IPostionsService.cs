using FirstPakWebApi.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstPakWebApi.IService
{
    public interface IPostionsService
    {
        ViewPageResult<ViewPosition> GetPostions(int page, int limit);
        IEnumerable<ViewDropDownList> GetPostionName();
        ViewPosition GetPostionById(int id);
        bool AddPostion(ViewPosition position);
        bool UpdatePostion(ViewPosition position);
        bool DeletePostion(params int[] ids);
    }
}
