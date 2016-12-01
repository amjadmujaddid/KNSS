using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KNSSService.Contract;
using KNSSService;
using KNSSEF.Model;

namespace AppMockup.Controllers
{

    public class AppMenuController : Controller
    {
        #region Class Attribute and Property

        private IMenuService _menuService = new MenuService();

        #endregion


        public JsonResult GetAllMenu()
        {
            List<Menu> listMenu = new List<Menu>();
            GetAllDataMenuResponse response = _menuService.GetAllDataMenu();
            listMenu.AddRange(response.GroupList);

            return Json(listMenu.ToList(), JsonRequestBehavior.AllowGet);
        }
    }
}




