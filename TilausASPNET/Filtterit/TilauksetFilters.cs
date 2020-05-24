using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TilausASPNET.Models;

namespace TilausASPNET.Filtterit
{
    public class TilauksetFilters
    {
        public static List<Asiakkaat> AsiakkaatDropDownList(IQueryable<Asiakkaat> lista)
        {
            TilausDBEntities db = new TilausDBEntities();
            List<Asiakkaat> palautettava = new List<Asiakkaat>();
            Asiakkaat blankko = new Asiakkaat { AsiakasID = 0, Nimi = "Valitse asiakas", Osoite = "", Postinumero = "" };
            palautettava.Add(blankko);
            foreach (Asiakkaat asiakas in lista)
            {
                Asiakkaat x = new Asiakkaat
                {
                    AsiakasID = asiakas.AsiakasID,
                    Nimi = asiakas.Nimi,
                    Postinumero = asiakas.Postinumero,
                    Osoite = asiakas.Osoite
                };
                // dropdowniin vain asiakkaat jotka ovat tehneet tilauksia:
                var z = db.Tilaukset.FirstOrDefault(y => y.AsiakasID == x.AsiakasID);
                if (z != null)
                {
                    palautettava.Add(x);
                }

            }
            return palautettava;
        }
    }
}