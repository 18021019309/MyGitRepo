using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FirstPakWebApi.Data.Models
{
    public partial class EmployeeInfo
    {
        public EmployeeInfo()
        {
            Departments = new HashSet<Department>();
        }
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// 用户
        /// </summary>
        public virtual User User { get; set; }
        public int? UserId { get; set; }
        /// <summary>
        /// 员工姓名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 联系方式
        /// </summary>
        public string Tel { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public int? Sex { get; set; }
        /// <summary>
        /// 年龄
        /// </summary>
        public int? Age { get; set; }
        /// <summary>
        /// 入职时间
        /// </summary>
        public DateTime? EntryTime { get; set; }
        /// <summary>
        /// 薪水
        /// </summary>
        public string Salary { get; set; }
        public string ID_Card { get; set; }
        /// <summary>
        /// 职位
        /// </summary>
        public virtual Position Position { get; set; }
        public int? PositionId { get; set; }

        /// <summary>
        /// 部门
        /// </summary>
        public virtual Department Department { get; set; }
        public int? DepartmentId { get; set; }
        /// <summary>
        /// 教育程度
        /// </summary>
        public virtual EducationLevel EducationLevel { get; set; }
        public int? EducationLevelId { get; set; }
        public string Remarks { get; set; }
        public virtual ICollection<Department> Departments { get; set; }
    }
}
