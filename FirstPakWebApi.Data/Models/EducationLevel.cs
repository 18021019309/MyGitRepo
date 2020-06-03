using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FirstPakWebApi.Data.Models
{
    public partial class EducationLevel
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(20), Required]
        public string EducationName { get; set; }
    }
}
