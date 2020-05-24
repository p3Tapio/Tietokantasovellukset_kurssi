using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace TilausASPNET.Helpperit
{
    public class AsiakasGenerator
    {
        public static string Osoite()
        {
            return HenkiloGenerator.Osoite();
        }
        public static string Postinumero()
        {
            return HenkiloGenerator.Postinumero();
        }
        public static string Nimi()
        {
            List<string> alku = new List<string>() { "Joku", "Uusi", "Pertin", "Hieno", "Paras" };
            List<string> keski = new List<string> { " Services", "tukku", " Logistics", "valinta", " Business" };
            List<string> loppu = new List<string>() { " Ab", " Oy", " Oyj", " Ky", " Tmi", " Inc" };

            Random random = new Random();
            int x = random.Next(0, 5);
            string nimi = alku[x];
            x = random.Next(0, 5);
            nimi += keski[x];
            x = random.Next(0, 6);
            nimi += loppu[x] + " ";
            return nimi;
        }
    }
}