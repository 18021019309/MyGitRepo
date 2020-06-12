using System;
using System.Collections.Generic;
using System.Text;

namespace FirstPakWebApi.ViewModel
{
    public class ViewDepartment
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentCode { get; set; }
        public int? SuperiorDepartmentId { get; set; }
        public int? Number { get; set; }
        public bool IsDisable { get; set; }
        public int? PrincipalId { get; set; }
        public string Remarks { get; set; }
        public virtual IEnumerable<ViewDepartment> Children { get; set; }

    }
}
