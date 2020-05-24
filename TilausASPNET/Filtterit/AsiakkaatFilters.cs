using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TilausASPNET.Models;

namespace TilausASPNET.Filtterit
{
    public class AsiakkaatFilters
    {
        public static IQueryable<Asiakkaat> FindSortByName(string findName, string sortOrder, IQueryable<Asiakkaat> asiakkaat)
        {
            switch (sortOrder)
            {
                case "osoite_desc":
                    asiakkaat = asiakkaat.Where(x => x.Nimi.Contains(findName)).OrderByDescending(a => a.Osoite);
                    break;
                case "Nimi":
                    asiakkaat = asiakkaat.Where(x => x.Nimi.Contains(findName)).OrderBy(a => a.Nimi);
                    break;
                case "nimi_desc":
                    asiakkaat = asiakkaat.Where(x => x.Nimi.Contains(findName)).OrderByDescending(a => a.Nimi);
                    break;
                default:
                    asiakkaat = asiakkaat.Where(x => x.Nimi.Contains(findName)).OrderBy(a => a.Nimi);
                    break;
            }
            return asiakkaat;
        }
        public static IQueryable<Asiakkaat> SortAsiakkaat(string sortOrder, IQueryable<Asiakkaat> asiakkaat)
        {

            {
                switch (sortOrder)
                {
                    case "osoite_desc":
                        asiakkaat = asiakkaat.OrderByDescending(a => a.Osoite);
                        break;
                    case "Nimi":
                        asiakkaat = asiakkaat.OrderBy(a => a.Nimi);
                        break;
                    case "nimi_desc":
                        asiakkaat = asiakkaat.OrderByDescending(a => a.Nimi);
                        break;
                    default:
                        asiakkaat = asiakkaat.OrderBy(a => a.Nimi);
                        break;
                }
                return asiakkaat;
            }
        }
    }
}