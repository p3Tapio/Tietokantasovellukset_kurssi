using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using TilausASPNET.Models;
using TilausASPNET.ViewModels;

namespace TilausASPNET.Controllers
{
    public class StatisticsController : Controller
    {
        private TilausDBEntities1 db = new TilausDBEntities1();
        // GET: Statistics
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CategorySales()
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("login", "home");
            }
            else
            {

                ViewBag.LoggedStatus = "In";
                string categoryNameList;
                string categorySalesList;

                List<CategorySalesClass> CategorySalesList = new List<CategorySalesClass>();

                var categorySalesData = from cs in db.Category_Sales_for_1997 select cs;

                foreach (Category_Sales_for_1997 sales in categorySalesData)
                {
                    CategorySalesClass OneSale = new CategorySalesClass();
                    OneSale.CategoryName = sales.CategoryName;
                    OneSale.CategorySales = (int)sales.CategorySales;
                    CategorySalesList.Add(OneSale);
                }

                categoryNameList = "'" + string.Join("','", CategorySalesList.Select(n => n.CategoryName).ToList()) + "'";
                categorySalesList = string.Join(",", CategorySalesList.Select(n => n.CategorySales).ToList());

                ViewBag.categoryName = categoryNameList;
                ViewBag.categorySales = categorySalesList;

                return View();
            }
        }
        public ActionResult BestSellersByQuantity()
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("login", "home");
            }
            else
            {
                ViewBag.LoggedStatus = "In";
                string productNameList;
                string productSalesList;

                List<BestSellersByQ> SalesList = new List<BestSellersByQ>();

                var salesData = from sd in db.BestSellersByQuantity select sd;

                foreach (BestSellersByQuantity bs in salesData)
                {
                    BestSellersByQ q = new BestSellersByQ();
                    q.ProductName = bs.ProductName;
                    q.Quantity = (int)bs.QuantitySum;
                    SalesList.Add(q);

                }

                productNameList = "'" + string.Join("','", SalesList.Select(n => n.ProductName).ToList()) + "'";
                productSalesList = string.Join(",", SalesList.Select(n => n.Quantity).ToList());

                ViewBag.productName = productNameList;
                ViewBag.productSales = productSalesList;

                return View();
            }
        }
        public ActionResult BestSellersByPrice()
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("login", "home");
            }
            else
            {
                ViewBag.LoggedStatus = "In";
                string productNameList;
                string productSalesList;

                List<BestSellersByP> SalesList = new List<BestSellersByP>();
                var salesData = from sd in db.BestSellersByPrice select sd;

                foreach (BestSellersByPrice bs in salesData)
                {
                    BestSellersByP p = new BestSellersByP();
                    p.ProductName = bs.ProductName;
                    p.Price = (float)bs.SalesPriceSum;
                    SalesList.Add(p);

                }
                productNameList = "'" + string.Join("','", SalesList.Select(n => n.ProductName).ToList()) + "'";
                productSalesList = string.Join(",", SalesList.Select(n => n.Price).ToList());

                ViewBag.productName = productNameList;
                ViewBag.productSales = productSalesList;

                return View();

            }
        }

        public ActionResult SalesPerWeekDay()
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("login", "home");
            }
            else
            {
                List<SalesByWeekDay> salesdata = new List<SalesByWeekDay>();

                var pvms = from x in db.Orders select x.OrderDate ?? DateTime.Now;
                int mon = 0, tue = 0, wed = 0, thu = 0, fri = 0;
                foreach (var x in pvms)
                {
                    if (x.DayOfWeek.ToString() == "Monday") mon++;
                    else if (x.DayOfWeek.ToString() == "Tuesday") tue++;
                    else if (x.DayOfWeek.ToString() == "Wednesday") wed++;
                    else if (x.DayOfWeek.ToString() == "Thursday") thu++;
                    else if (x.DayOfWeek.ToString() == "Friday") fri++;
                }

                SalesByWeekDay monday = new SalesByWeekDay { Weekday = "Monday", Orders = mon };
                salesdata.Add(monday);

                SalesByWeekDay tuesday = new SalesByWeekDay { Weekday = "Tuesday", Orders = tue };
                salesdata.Add(tuesday);

                SalesByWeekDay wednesday = new SalesByWeekDay { Weekday = "Wednesday", Orders = wed };
                salesdata.Add(wednesday);
                
                SalesByWeekDay thursday = new SalesByWeekDay { Weekday = "Thursday", Orders = thu };
                salesdata.Add(thursday);
                
                SalesByWeekDay friday = new SalesByWeekDay{ Weekday = "Friday", Orders = fri };
                salesdata.Add(friday);

                string weekdays;
                string orders;

                weekdays = "'" + string.Join("','", salesdata.Select(n => n.Weekday).ToList()) + "'";
                orders = string.Join(",", salesdata.Select(n => n.Orders).ToList());

                ViewBag.weekdays = weekdays;
                ViewBag.orders = orders; 

                return View();
            }
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