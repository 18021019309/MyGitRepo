using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstPakWebApi.ViewModel
{
    public class ViewMenuRole
    {
        //public int Id { get; set; }
        public int RoleId { get; set; }
        [IgnoreMap]
        public List<int> MenuIds { get; set; }
    }
}
