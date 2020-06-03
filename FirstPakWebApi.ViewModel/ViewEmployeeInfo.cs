using System;
using System.Collections.Generic;
using System.Text;

namespace FirstPakWebApi.ViewModel
{
    public class ViewEmployeeInfo
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string Name { get; set; }
        //public string NickName { get; set; }
        public string Password { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
        public int? Sex { get; set; }
        public int? Age { get; set; }
        public DateTime? EntryTime { get; set; }
        public string Salary { get; set; }
        public string ID_Card { get; set; }
        public int? PositionId { get; set; }
        public int? DepartmentId { get; set; }
        public int? EducationLevelId { get; set; }
        public string Remarks { get; set; }
    }
}
