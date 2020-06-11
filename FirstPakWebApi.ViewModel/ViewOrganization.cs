using System;
using System.Collections.Generic;
using System.Text;

namespace FirstPakWebApi.ViewModel
{
    public class ViewOrganization
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public int? SuperiorDepartmentId { get; set; }
        public virtual IEnumerable<ViewOrganization> Children { get; set; }
    }
}
