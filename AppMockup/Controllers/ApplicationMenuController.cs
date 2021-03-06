﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using KNSSService.Contract;
using KNSSService;
using KNSSEF.Model;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace AppMockup.Controllers
{
    [System.Web.Http.RoutePrefix("menu")]
    public class ApplicationMenuController : ApiController
    {
        #region Class Attribute and Property

        private IMenuService _menuService = new MenuService();

        #endregion
        [System.Web.Http.Route("getallmenu")]
        public Menu GetAllMenu()
        {
            List<Menu> listMenu = new List<Menu>();
            GetAllDataMenuResponse response = _menuService.GetAllDataMenu();
            listMenu.AddRange(response.GroupList);

            return Json(listMenu.ToList(), JsonRequestBehavior.AllowGet);
        }
    }
}
