using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNSSEF.Model
{
    /// <summary>
    /// Provides base class for DTO
    /// </summary>
    [Serializable]
    public class DTOBase
    {
        public Nullable<System.DateTime> CreateDate { get; set; }
        public string CreateBy { get; set; }
        public Nullable<System.DateTime> EditDate { get; set; }
        public string EditBy { get; set; }
    }
}
