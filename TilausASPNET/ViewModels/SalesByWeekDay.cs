using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TilausASPNET.ViewModels
{
    public class SalesByWeekDay
    {
        public string Weekday { get; set; }
        public int Orders { get; set; }
    }
}