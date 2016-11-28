using KNSSEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNSSEF.DAL.Interface
{
    public interface IGroupRepository : IDALRepository<Group>
    {
        /// <summary>
        /// Get Data By Id Group
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        Group GetDataById(string groupId);

        /// <summary>
        /// Get List Data Group By Filter
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="groupName"></param>
        /// <returns></returns>
        List<Group> GetDataByFilter(string groupId, string groupName);
    }
}
