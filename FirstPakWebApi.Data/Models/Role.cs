using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FirstPakWebApi.Data.Models
{
   public partial class Role
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(20), Required]
        public string  RoleName { get; set; }
        public virtual IEnumerable<UserRole> UserRoles { get; set; }
        public virtual IEnumerable<MenuRole> MenuRoles { get; set; }
        public string Remarks { get; set; }
    }
}
