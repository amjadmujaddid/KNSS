using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNSSEF.Model
{
    public class Menu
    {
        public string MenuId { get; set; }
        public string MenuName { get; set; }
        public string ParentId { get; set; }
        public string Url { get; set; }
        public Nullable<int> Sort { get; set; }
        public string Icon { get; set; }
        public string SiteMap { get; set; }
        public string TypeMenu { get; set; }
        public string IsPublic { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public string CreateBy { get; set; }
        public Nullable<System.DateTime> EditDate { get; set; }
        public string EditBy { get; set; }
    }
}
