using KNSSEF.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KNSSEF.Model;
using KNSSUtility;

namespace KNSSEF.DAL
{
    public class MenuRepository : IMenuRepository
    {
        #region Declare Variable

        private string spName;
        private string spType = string.Empty;
        private Dictionary<string, string> spParams = new Dictionary<string, string>();

        #endregion

        #region IDAL Repository

        public void Add(Menu entity)
        {
            using (var context = new KNSSContext<Menu>())
            {
                Menu data = context.DBEntities.Where(x => x.MenuId == entity.MenuId).FirstOrDefault();

                if (data != null)
                {
                    throw new Exception("Data Already Exist");
                }
                else
                {
                    spName = "uspg_MenuInsert";
                    spType = "add";
                    spParams.Clear();
                    spParams.Add("menuId", entity.MenuId);
                    spParams.Add("menuName", entity.MenuName);
                    spParams.Add("parentId", entity.ParentId);
                    spParams.Add("url", entity.Url);
                    spParams.Add("sort", entity.Sort.ToString());
                    spParams.Add("icon", entity.Icon);
                    spParams.Add("siteMap", entity.SiteMap);
                    spParams.Add("typeMenu", entity.TypeMenu);
                    spParams.Add("isPublic", entity.IsPublic);
                    spParams.Add("createDate", entity.CreateDate.ToString());
                    spParams.Add("createBy", entity.CreateBy);
                    spParams.Add("editDate", entity.EditDate.ToString());
                    spParams.Add("editBy", entity.EditBy);

                    Library.ExecSP(spName, spType, spParams);
                }
            }
        }

        public void Delete(Menu entity)
        {
            using (var context = new KNSSContext<Menu>())
            {
                Menu data = context.DBEntities.Where(x => x.MenuId == entity.MenuId).FirstOrDefault();

                if (data == null)
                {
                    throw new Exception("Data Not Exist");
                }
                else
                {
                    spName = "uspg_MenuDelete";
                    spType = "delete";
                    spParams.Clear();
                    spParams.Add("menuId", entity.MenuId);

                    Library.ExecSP(spName, spType, spParams);
                }
            }
        }

        public List<Menu> GetAll()
        {
            using (var context = new KNSSContext<Menu>())
            {
                return context.Set<Menu>().ToList();
            }
        }

        public void Update(Menu entity)
        {
            using (var context = new KNSSContext<Menu>())
            {
                Menu data = context.DBEntities.Where(i => i.MenuId == entity.MenuId).FirstOrDefault();

                if (data == null)
                {
                    throw new Exception("Data Not Exist");
                }
                else
                {
                    spName = "uspg_MenuUpdate";
                    spType = "edit";
                    spParams.Clear();
                    spParams.Add("menuId", entity.MenuId);
                    spParams.Add("menuName", entity.MenuName);
                    spParams.Add("parentId", entity.ParentId);
                    spParams.Add("url", entity.Url);
                    spParams.Add("sort", entity.Sort.ToString());
                    spParams.Add("icon", entity.Icon);
                    spParams.Add("siteMap", entity.SiteMap);
                    spParams.Add("typeMenu", entity.TypeMenu);
                    spParams.Add("isPublic", entity.IsPublic);
                    spParams.Add("editDate", entity.EditDate.ToString());
                    spParams.Add("editBy", entity.EditBy);

                    Library.ExecSP(spName, spType, spParams);
                }
            }
        }

        #endregion

        #region IMenuRepository Implementation

        public Menu GetDataById(string menuId)
        {
            using (KNSSContext<Menu> context = new KNSSContext<Menu>())
            {
                return context.DBEntities.Where(i => i.MenuId == menuId).FirstOrDefault();
            }
        }

        #endregion
    }
}
