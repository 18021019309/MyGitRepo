using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstPakWebApi.ViewModel
{
    public class ViewUser
    {
        public int Id { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public string Remarks { get; set; }
        [IgnoreMap]
        public List<int> RoleIds { get; set; }
    }
}
