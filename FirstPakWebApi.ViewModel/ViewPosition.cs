using System;
using System.Collections.Generic;
using System.Text;

namespace FirstPakWebApi.ViewModel
{
    public class ViewPosition
    {
        public int Id { get; set; }
        public string PositionName { get; set; }
        public int? SuperiorId { get; set; }
        public string Remarks { get; set; }
    }
}
