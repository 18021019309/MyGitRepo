using System;
using System.Collections.Generic;
using System.Text;

namespace FirstPakWebApi.Data.Models
{
   public interface IEntity
    {
        int Id { get; set; }
    }
    public partial class EmployeeInfo : IEntity { }
    public partial class User : IEntity { }
    public partial class Menu : IEntity { }
    public partial class MenuRole : IEntity { }
    public partial class Department : IEntity { }
    public partial class Position : IEntity { }
    public partial class Role : IEntity { }
    public partial class UserRole : IEntity { }


}
