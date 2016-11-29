//using AppMockup.Models;
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
    public class HomeController : Controller
    {
        //private NORTHWNDEntities db = new NORTHWNDEntities();
        #region Class Attribute and Property

        private IGroupService _groupService = new GroupService();

        #endregion
        public ActionResult Home()
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


        [HttpPost]
        [AcceptVerbs("POST")]
        public JsonResult GetFilteredData(string text)
        {
            List<Group> listGroup = new List<Group>();
            GetDataGroupByFilterRequest request = new GetDataGroupByFilterRequest();
            request.groupId = text;
            request.groupName = text;

            GetDataGroupByFilterResponse response = _groupService.GetDataGroupByFilter(request);
            listGroup.AddRange(response.GroupList);

            return Json(listGroup.ToList(), JsonRequestBehavior.AllowGet);
        }



        //public JsonResult GetAllData()
        //{
        //    var datalistResults = (from p in db.Products
        //                  join c in db.Categories on p.CategoryID equals c.CategoryID
        //                  join s in db.Suppliers on p.SupplierID equals s.SupplierID
        //                  select new
        //                  {
        //                      p.ProductName,
        //                      c.CategoryName,
        //                      p.UnitsInStock,
        //                      p.QuantityPerUnit,
        //                      p.UnitPrice,
        //                      p.UnitsOnOrder,
        //                      s.CompanyName,
        //                      s.City,
        //                      s.Country
        //                  });


        //    return Json(datalistResults.ToList(), JsonRequestBehavior.AllowGet);
        //}


        //public JsonResult GetAllData(string sidx, string sord, int page, int rows, string ProductName, string category)
        //{
        //    int pageIndex = Convert.ToInt32(page) - 1;
        //    int pageSize = rows;
        //    var datalistResults = (from p in db.Products
        //                           join c in db.Categories on p.CategoryID equals c.CategoryID
        //                           join s in db.Suppliers on p.SupplierID equals s.SupplierID
        //                           select new
        //                           {
        //                               p.ProductName,
        //                               c.CategoryName,
        //                               p.UnitsInStock,
        //                               p.QuantityPerUnit,
        //                               p.UnitPrice,
        //                               p.UnitsOnOrder,
        //                               s.CompanyName,
        //                               s.City,
        //                               s.Country
        //                           });
        //    if (!string.IsNullOrEmpty(ProductName))
        //    {
        //        datalistResults.Where(p => p.ProductName.Contains(ProductName));
        //    }
        //    if (!string.IsNullOrEmpty(category))
        //    {
        //        datalistResults.Where(p => p.CategoryName.Contains(category));
        //    }


        //    int totalRecords = datalistResults.Count();
        //    var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);

        //    if (sord.ToUpper() == "DESC")
        //    {
        //        datalistResults = datalistResults.OrderByDescending(s => s.ProductName);
        //        datalistResults = datalistResults.Skip(pageIndex * pageSize).Take(pageSize);
        //    }
        //    else
        //    {
        //        datalistResults = datalistResults.OrderBy(s => s.ProductName);
        //        datalistResults = datalistResults.Skip(pageIndex * pageSize).Take(pageSize);
        //    }
        //    var jsonData = new
        //    {
        //        total = totalPages,
        //        page,
        //        records = totalRecords,
        //        rows = datalistResults
        //    };

        //    return Json(jsonData, JsonRequestBehavior.AllowGet);
        //}
    }
}