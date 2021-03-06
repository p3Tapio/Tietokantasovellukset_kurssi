﻿using System;
using System.Collections.Generic;

namespace TilausASPNET.Helpperit
{
    public class HenkiloGenerator
    {
        //public static void Main()
        //{
        //    string eNimi = Etunimi();
        //    string sNimi = Sukunimi();
        //    string osoite = Osoite();
        //    string pNro = Postinumero();
        //    string sPosti = eNimi + Sposti();


        //    Console.WriteLine(eNimi + " " + sNimi + "\n" + osoite + "\n" + pNro + "\n" + sPosti);

        //}
        public static string Sposti()
        {


            List<string> loppu = new List<string>()
        {
            "@mail.com",
            "@posti.fi",
            "@osoite.fi",
            "@joku.ch",
            "@yahoo.com",
            "@jotain.fi",
            "@meili.com",
            "@hotmail"

        };
            Random random = new Random();
            int x = random.Next(0, 6);

            return loppu[x];

        }

        public static string Postinumero()
        {
            List<string> nro = new List<string>()
        {
            "01400",
            "02120",
            "10100",
            "15100",
            "16900",
            "20100",
            "24200",
            "33100",
            "44210",
            "53200",
            "65400",
            "76200",
            "87320",
            "90100",
            "96100"
        };

            Random random = new Random();
            int x = random.Next(0, 15);

            return nro[x];

        }
        public static string Osoite()
        {

            List<string> alku = new List<string>()
        {
            "Joku","Jossain", "Missä", "Hieno", "Puna", "Kesä",
              "Syksy", "Talvi","Kukka", "Puu","Jalka","Kahvi","Muki"
        };
            List<string> loppu = new List<string>()
        {
            "kuja", "katu","tie", "tormä","kurvi","tie", "katu"
        };
            string numero = "1234567890";
            string kirjain = "ABCDEFGH";


            Random random = new Random();
            int x = random.Next(0, 13);
            string osoite = alku[x];
            x = random.Next(0, 7);
            osoite += loppu[x] + " ";
            x = random.Next(0, 9);
            osoite += numero[x];
            x = random.Next(0, 10);
            osoite += numero[x] + " ";

            x = random.Next(0, 8);
            osoite += kirjain[x];


            return osoite;

        }

        public static string Etunimi()
        {
            List<string> etunimi = new List<string>()
        {
            "Pertti",
            "Maisa",
            "Pirkko",
            "Liisa",
            "Jorma",
            "Keijo",
            "Sirkku",
            "Kalle",
            "Jussi",
            "Sami",
            "Erkki",
            "Keijo",
            "Sari",
            "Heikki",
            "Salla",
            "Kalevi"
        };


            Random random = new Random();
            int x = random.Next(0, 16);

            return etunimi[x];
        }

        public static string Sukunimi()
        {
            List<string> Sukunimi1 = new List<string>()
        {
            "Joku",
            "Mäki",
            "Kallio",
              "Suku",
              "Joki",
              "Järvi",
              "Pöllö",
              "Metsä",
              "Sauna",
              "Suvi", 
              "Syksy",
              "Vaara",
              "Saari",
                "Puu"
        };
            List<string> Sukunimi2 = new List<string>()
        {
            "la",
            "nen",
            "nen",
            "ko"
        };

            Random random = new Random();
            int suku1 = random.Next(0, 14);
            string sukunimi = Sukunimi1[suku1];
            int suku2 = random.Next(0, 4);
            sukunimi += Sukunimi2[suku2];


            return sukunimi;
        }
        public static int Esimies()
        {

            Random random = new Random();
            return random.Next(0, 5);
        }

    }

}