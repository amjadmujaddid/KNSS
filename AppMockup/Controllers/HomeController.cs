﻿//using AppMockup.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KNSSService.Contract;
using KNSSService;
using KNSSEF.Model;
using System.IO;

namespace AppMockup.Controllers
{

    [RoutePrefix("home")]
    public class HomeController : Controller
    {
        #region Class Attribute and Property

        private IGroupService _groupService = new GroupService();

        #endregion
        public ActionResult Home()
        {
            return View();
        }

        [Route("grouplist")]
        public JsonResult GetAllData()
        {
            List<Group> listGroup = new List<Group>();
            GetAllDataGroupResponse response = _groupService.GetAllDataGroup();
            listGroup.AddRange(response.GroupList);

            var jsonData = new
            {
                total = 1,
                page = 1,
                records = listGroup.Count,
                rows = (
                  from list in listGroup
                  select new
                  {
                      id = list.GroupId,
                      cell = new string[] {
                        list.GroupId.ToString(), list.GroupName
                    }
                  }).ToArray()
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        [Route("cbogroup")]
        public JsonResult ComboboxGroup()
        {

            List<Group> listGroup = new List<Group>();
            GetAllDataGroupResponse response = _groupService.GetAllDataGroup();
            listGroup.AddRange(response.GroupList);

            return Json(listGroup.ToList(), JsonRequestBehavior.AllowGet);
        }

        [Route("upload")]
        [HttpPost]
        public JsonResult Upload(string file)
        {
            string fileUpload = string.Empty;
            HttpPostedFileBase obj = Request.Files["form_UploadFile"];

            if (fileUpload != null)
            {
                var fileName = Path.GetFileName(obj.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/image/temp"), fileName);
                obj.SaveAs(path);
            }

            return Json(fileUpload, JsonRequestBehavior.AllowGet);

        }
        //[Route("search/{text}")]
        //public JsonResult GetFilteredData(string text)
        //{
        //    List<Group> listGroup = new List<Group>();
        //    GetDataGroupByFilterRequest request = new GetDataGroupByFilterRequest();
        //    request.groupId = text;
        //    request.groupName = text;

        //    GetDataGroupByFilterResponse response = _groupService.GetDataGroupByFilter(request);
        //    listGroup.AddRange(response.GroupList);

        //    var jsonData = new
        //    {
        //        total = 1,
        //        page = 1,
        //        records = listGroup.Count,
        //        rows = (
        //          from list in listGroup
        //          select new
        //          {
        //              id = list.GroupId,
        //              cell = new string[] {
        //                list.GroupId.ToString(), list.GroupName
        //            }
        //          }).ToArray()
        //    };

        //    return Json(listGroup.ToList(), JsonRequestBehavior.AllowGet);
        //}
    }
}