using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FirstPakWebApi.Data.Models
{
    public partial class Menu
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(20), Required]
        public string MenuName { get; set; }
        [MaxLength(50), Required]
        public string MenuCode { get; set; }
        [MaxLength(100), Required]
        public string MenuUrl { get; set; }
        [MaxLength(10), Required]
        public string Depth { get; set; }
        public int? ParentId { get; set; }//可为空
        public virtual IEnumerable<Menu> Children { get; set; }
        public virtual IEnumerable<MenuRole> MenuRoles { get; set; }

    }
}
