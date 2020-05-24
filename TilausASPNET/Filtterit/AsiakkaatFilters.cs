using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TilausASPNET.Models;

namespace TilausASPNET.Filtterit
{
    public class AsiakkaatFilters
    {
        public static IQueryable<Asiakkaat> FindSortByName(string findName, IQueryable<Asiakkaat> asiakkaat)
        {
            asiakkaat = asiakkaat.Where(x => x.Nimi.Contains(findName));
            return asiakkaat;
        }
    }
}