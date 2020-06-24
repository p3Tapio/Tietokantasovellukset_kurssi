using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TilausASPNET.ViewModels
{
    public class DailyProductSales
    {
        public string ProductName { get; set; }
        public float DailySales { get; set; }
        public string OrderDate { get; set; }
    }
}