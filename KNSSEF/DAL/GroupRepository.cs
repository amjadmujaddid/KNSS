using KNSSEF.DAL.Interface;
using KNSSEF.Model;
using KNSSEF.SPFunction;
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

        private string spName = "spGroup";
        private Dictionary<string, string> spParams;

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

                    spParams.Clear();
                    spParams.Add("option", "1");
                    spParams.Add("groupId", entity.GroupId);
                    spParams.Add("groupName", entity.GroupName);
                    spParams.Add("createDate", entity.CreateDate.ToString());
                    spParams.Add("createBy", entity.CreateBy);
                    spParams.Add("editDate", entity.EditDate.ToString());
                    spParams.Add("editBy", entity.EditBy);

                    Func.ExecDataBySp(spName, spParams);
                }
            }
        }

        public void Delete(Group entity)
        {
            spParams.Clear();
            spParams.Add("option", "3");
            spParams.Add("groupId", entity.GroupId);

            Func.ExecDataBySp(spName, spParams);
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
                    //TBD for error exception data not exist
                    throw new Exception("Data Not Exist");
                }
                else
                {
                    data.GroupName = entity.GroupName;
                    data.EditBy = entity.EditBy;
                    data.EditDate = DateTime.Now;
                    context.SaveChanges();
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

        #endregion

    }
}
