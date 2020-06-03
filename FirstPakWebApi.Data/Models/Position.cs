using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FirstPakWebApi.Data.Models
{
    public partial class Position
    {
        public Position()
        {
            EmployeeInfos =new HashSet<EmployeeInfo>();
        }

        [Key]
        public int Id { get; set; }
        [MaxLength(20), Required]
        public string PositionName { get; set; }
        public int? SuperiorId { get; set; }
        public string Remarks { get; set; }
        public virtual ICollection<EmployeeInfo> EmployeeInfos { get; set; }
    }
}
