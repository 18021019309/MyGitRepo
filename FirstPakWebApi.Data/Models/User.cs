using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FirstPakWebApi.Data.Models
{
    public partial class User
    {
        public User()
        {
            EmployeeInfos = new HashSet<EmployeeInfo>();
        }
        [Key]
        public int Id { get; set; }
        [MaxLength(20), Required]
        public string Account { get; set; }
        [MaxLength(20), Required]
        public string Password { get; set; }
        public virtual IEnumerable<UserRole> UserRoles { get; set; }
        public string Remarks { get; set; }
        public virtual ICollection<EmployeeInfo> EmployeeInfos { get; set; }
    }
}
