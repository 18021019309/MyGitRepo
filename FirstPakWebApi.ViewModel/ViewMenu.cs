using System;
using System.Collections.Generic;

namespace FirstPakWebApi.ViewModel
{
    public class ViewMenu
    {
        public int Id { get; set; }
        public string MenuName { get; set; }
        public string MenuCode { get; set; }
        public string MenuUrl { get; set; }
        public string Depth { get; set; }
        public int? ParentId { get; set; }
        public virtual IEnumerable<ViewMenu> Children { get; set; }
    }
}
