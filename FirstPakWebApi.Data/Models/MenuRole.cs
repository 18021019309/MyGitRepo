using System;
using System.Collections.Generic;
using System.Text;

namespace FirstPakWebApi.Data.Models
{
    public partial class MenuRole
    {
        public int Id { get; set; }
        public int MenuId { get; set; }
        public virtual Menu Menu { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}
