using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNSSEF.Model
{
    public class Report : DTOBase
    {
        public int ReportId { get; set; }
        public string ReportCode { get; set; }
        public string ReportName { get; set; }
        public string CategoryId { get; set; }
        public Nullable<bool> Active { get; set; }
        public string ReportFile { get; set; }
        public Nullable<bool> UseSp { get; set; }
        public Nullable<bool> HasParameter { get; set; }
        public string SqlQuery { get; set; }
        public string SqlWhere { get; set; }
        public string SqlOrder { get; set; }
    }
}
