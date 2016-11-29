using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KNSSEF.Model;
using KNSSService.Contract;
using KNSSService;


namespace AppMockup.Controllers
{
    public class GroupController : Controller
    {
        #region Class Attribute and Property

        private IGroupService _groupService = new GroupService();

        #endregion

        // GET: Group
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAllData()
        {
            List<Group> listGroup = new List<Group>();
            GetAllDataGroupResponse response = _groupService.GetAllDataGroup();
            listGroup.AddRange(response.GroupList);

            return Json(listGroup.ToList(), JsonRequestBehavior.AllowGet);
        }
    }
}