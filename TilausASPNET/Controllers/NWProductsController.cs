using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using TilausASPNET.Models;
using TilausASPNET.ViewModels;


namespace TilausASPNET.Controllers
{
    public class NWProductsController : Controller
    {
        private TilausDBEntities1 db = new TilausDBEntities1();

        // GET: NWProducts
        public ActionResult Index(int? page, int? pagesize)
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("login", "home");
            }
            else
            {
                ViewBag.LoggedStatus = "In";

                int pageSize = (pagesize ?? 20);
                int pageNumber = (page ?? 1);

                var products = (from x in db.Products select x);
                products = products.OrderBy(x => x.ProductName);

                return View(products.ToPagedList(pageNumber, pageSize));
            }
        }
        public ActionResult _ProductSalesPerDate(string productName)
        {
            if (String.IsNullOrEmpty(productName)) productName = "Lakkalikööri";

            List<DailyProductSales> dailyProductSalesList = new List<DailyProductSales>();

            var orderSummary = from pds in db.ProductDailySales
                               where pds.ProductName == productName
                               orderby pds.OrderDate
                               select new DailyProductSales
                               {
                                   OrderDate = SqlFunctions.DateName("year", pds.OrderDate) + "." + SqlFunctions.DateName("MM", pds.OrderDate) + "." + SqlFunctions.DateName("day", pds.OrderDate),
                                   DailySales = (float)pds.DailySales,
                                   ProductName = pds.ProductName
                               };

            return Json(orderSummary, JsonRequestBehavior.AllowGet);
        }
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
