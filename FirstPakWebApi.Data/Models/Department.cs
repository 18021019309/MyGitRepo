using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FirstPakWebApi.Data.Models
{
    public partial class Department
    {
        public Department()
        {
            EmployeeInfos = new HashSet<EmployeeInfo>(); 
        }
        [Key]
        public int Id { get; set; }
        [MaxLength(20), Required]
        public string DepartmentName { get; set; }
        public string DepartmentCode { get; set; }
        public int? SuperiorDepartmentId { get; set; }
        public int? Number { get; set; }
        public bool IsDisable { get; set; }
        public int? PrincipalId { get; set; }
        public string Remarks { get; set; }
        public virtual EmployeeInfo EmployeeInfo { get; set; }
        public virtual ICollection<EmployeeInfo> EmployeeInfos { get; set; }
    }
}
