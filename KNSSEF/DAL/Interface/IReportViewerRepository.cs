using KNSSEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNSSEF.DAL.Interface
{
    public interface IReportViewerRepository : IDALRepository<Report>
    {
        /// <summary>
        /// Get Data By Id Report
        /// </summary>
        /// <param name="reportId"></param>
        /// <returns></returns>
        Report GetDataById(string reportId);
    }
}
