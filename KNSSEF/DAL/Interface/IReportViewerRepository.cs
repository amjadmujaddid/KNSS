using KNSSEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNSSEF.DAL.Interface
{
    public interface IReportViewerRepository : IDALRepository<Group>
    {
        /// <summary>
        /// Get Data By Id Group
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        Group GetDataById(string groupId);
    }
}
