using KNSSEF.DAL.Interface;
using KNSSEF.Model;
using KNSSUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNSSEF.DAL
{
    public class ReportViewerRepository : IReportViewerRepository
    {

        #region Declare Variable

        private string spName;
        private string spType = string.Empty;
        private Dictionary<string, string> spParams = new Dictionary<string, string>();

        #endregion

        #region IDAL Repository

        public List<Group> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Add(Group entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Group entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Group entity)
        {
            throw new NotImplementedException();

        }

        #endregion

        #region IReportViewerRepository Implementation

        public Group GetDataById(string groupId)
        {
            using (KNSSContext<Group> context = new KNSSContext<Group>())
            {
                return context.DBEntities.Where(i => i.GroupId == groupId).FirstOrDefault();
            }
        }
        #endregion

    }
}
