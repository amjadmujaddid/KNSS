using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNSSEF.Model
{
    public class Group
    {
        public string GroupId { get; set; }
        public string GroupName { get; set; }
        public System.DateTime CreateDate { get; set; }
        public string CreateBy { get; set; }
        public System.DateTime EditDate { get; set; }
        public string EditBy { get; set; }
    }
}
