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
    public class GroupRepository : IGroupRepository
    {

        #region Declare Variable

        private string spName;
        private string spType = string.Empty;
        private Dictionary<string, string> spParams = new Dictionary<string, string>();

        #endregion

        #region IDAL Repository

        public void Add(Group entity)
        {
            using (var context = new KNSSContext<Group>())
            {
                Group data = context.DBEntities.Where(x => x.GroupId == entity.GroupId).FirstOrDefault();

                if (data != null)
                {
                    throw new Exception("Data Already Exist");
                }
                else
                {
                    spName = "uspg_GroupInsert";
                    spType = "add";
                    spParams.Clear();
                    spParams.Add("groupId", entity.GroupId);
                    spParams.Add("groupName", entity.GroupName);
                    spParams.Add("createDate", entity.CreateDate.ToString());
                    spParams.Add("createBy", entity.CreateBy);
                    spParams.Add("editDate", entity.EditDate.ToString());
                    spParams.Add("editBy", entity.EditBy);

                    Library.ExecSP(spName, spType, spParams);
                }
            }
        }

        public void Delete(Group entity)
        {
            using (var context = new KNSSContext<Group>())
            {
                Group data = context.DBEntities.Where(x => x.GroupId == entity.GroupId).FirstOrDefault();

                if (data == null)
                {
                    throw new Exception("Data Not Exist");
                }
                else
                {
                    spName = "uspg_GroupDelete";
                    spType = "delete";
                    spParams.Clear();
                    spParams.Add("groupId", entity.GroupId);

                    Library.ExecSP(spName, spType, spParams);
                }
            }
        }

        public List<Group> GetAll()
        {
            using (var context = new KNSSContext<Group>())
            {
                return context.Set<Group>().ToList();
            }
        }

        public void Update(Group entity)
        {
            using (var context = new KNSSContext<Group>())
            {
                Group data = context.DBEntities.Where(i => i.GroupId == entity.GroupId).FirstOrDefault();

                if (data == null)
                {
                    throw new Exception("Data Not Exist");
                }
                else
                {
                    spName = "uspg_GroupUpdate";
                    spType = "edit";
                    spParams.Clear();
                    spParams.Add("groupId", entity.GroupId);
                    spParams.Add("groupName", entity.GroupName);
                    spParams.Add("editDate", entity.EditDate.ToString());
                    spParams.Add("editBy", entity.EditBy);

                    Library.ExecSP(spName, spType, spParams);
                }
            }
        }

        #endregion

        #region IGroupRepository Implementation

        public Group GetDataById(string groupId)
        {
            using (KNSSContext<Group> context = new KNSSContext<Group>())
            {
                return context.DBEntities.Where(i => i.GroupId == groupId).FirstOrDefault();
            }
        }

        public List<Group> GetDataByFilter(string groupId, string groupName)
        {
            using (KNSSContext<Group> context = new KNSSContext<Group>()) 
            {
                return context.DBEntities.Where(i => i.GroupId.Contains(groupId) && i.GroupName.Contains(groupName)).ToList();
            }
        }

        #endregion

    }
}
