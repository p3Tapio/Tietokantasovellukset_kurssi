using System.Collections.Generic;
using System.Linq;
using TilausASPNET.Models;

namespace TilausASPNET.Helpperi
{
    public class HenkilotFilters
    {
        public static List<Postitoimipaikat> PostiDropDownList(IQueryable<Postitoimipaikat> lista)
        {

            List<Postitoimipaikat> palatuva = new List<Postitoimipaikat>();
            Postitoimipaikat blankko = new Postitoimipaikat { Postinumero = "", Postitoimipaikka = "", PostiNroPaikka = "Valitse hakuehto" };
            palatuva.Add(blankko);

            foreach (Postitoimipaikat postitoim in lista)
            {
                Postitoimipaikat x = new Postitoimipaikat
                {
                    Postinumero = postitoim.Postinumero,
                    Postitoimipaikka = postitoim.Postitoimipaikka,
                    PostiNroPaikka = postitoim.Postinumero + " - " + postitoim.Postitoimipaikka
                };

                palatuva.Add(x);
            }
            return palatuva;
        }
        public static IQueryable<Henkilot> FilterSortLastName(string sortOrder, string searchString1, IQueryable<Henkilot> henkilot)
        {
            switch (sortOrder)
            {
                case "sukunimi_desc":
                    henkilot = henkilot.Where(x => x.Sukunimi.Contains(searchString1)).OrderByDescending(x => x.Sukunimi);
                    break;
                case "etunimi":
                    henkilot = henkilot.Where(x => x.Sukunimi.Contains(searchString1)).OrderBy(x => x.Etunimi);
                    break;
                case "etunimi_desc":
                    henkilot = henkilot.Where(x => x.Sukunimi.Contains(searchString1)).OrderByDescending(x => x.Etunimi);
                    break;
                default:
                    henkilot = henkilot.Where(x => x.Sukunimi.Contains(searchString1)).OrderBy(x => x.Sukunimi);
                    break;

            }
            return henkilot;
        }
        public static IQueryable<Henkilot> FilterSortPostinumero(string sortOrder, string PostinumeroHaku, IQueryable<Henkilot> henkilot)
        {
            switch (sortOrder)
            {
                case "sukunimi_desc":
                    henkilot = henkilot.Where(x => x.Postinumero == PostinumeroHaku).OrderByDescending(x => x.Sukunimi);
                    break;
                case "etunimi":
                    henkilot = henkilot.Where(x => x.Postinumero == PostinumeroHaku).OrderBy(x => x.Etunimi);
                    break;
                case "etunimi_desc":
                    henkilot = henkilot.Where(x => x.Postinumero == PostinumeroHaku).OrderByDescending(x => x.Etunimi);
                    break;
                default:
                    henkilot = henkilot.Where(x => x.Postinumero == PostinumeroHaku).OrderBy(x => x.Sukunimi);
                    break;
            }
            return henkilot;
        }
        public static IQueryable<Henkilot> NoFilterSortHenkilot(string sortOrder, IQueryable<Henkilot> henkilot)
        {

            switch (sortOrder)
            {
                case "sukunimi_desc":
                    henkilot = henkilot.OrderByDescending(x => x.Sukunimi);
                    break;
                case "etunimi":
                    henkilot = henkilot.OrderBy(x => x.Etunimi);
                    break;
                case "etunimi_desc":
                    henkilot = henkilot.OrderByDescending(x => x.Etunimi);
                    break;
                default:
                    henkilot = henkilot.OrderBy(x => x.Sukunimi);
                    break;
            }

            return henkilot;
        }

    }
}