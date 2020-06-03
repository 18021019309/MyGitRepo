using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstPakWebApi.ViewModel
{
    public class ViewPageResult<T>
    {
        public int TotalCount { get; private set; }
        public IEnumerable<T> DataSource { get; private set; }
        [IgnoreMap]
        public string Msg { get; set; } = "成功";
    }
}
