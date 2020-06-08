

namespace TilausASPNET.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    public class OrderSummaryData
    {
        // Tilaukset: --------------------------------------
        public int TilausID { get; set; }
        //  public int AsiakasID { get; set; }
        public string Toimitusosoite { get; set; }
        // public string Postinumero { get; set; }
        public Nullable<System.DateTime> Tilauspvm { get; set; }
        public Nullable<System.DateTime> Toimituspvm { get; set; }

        // Tilausrivit: --------------------------------------
        public int TilausriviID { get; set; }
        // public int TilausID { get; set; }
        // public int TuoteID { get; set; }
        public int Maara { get; set; }
        public float TilausAhinta { get; set; }

        // Asiakkaat: --------------------------------------
        public int AsiakasID { get; set; }
        public string AsiakasNimi { get; set; }
        public string Osoite { get; set; }
        //  public string Postinumero { get; set; }

        // Tuotteet:  --------------------------------------
        public int TuoteID { get; set; }
        public string TuoteNimi { get; set; }
        public float TuoteAhinta { get; set; }
        public string ImageLink { get; set; }

        // Postitoimipaikat: -------------------------------

        public string Postinumero { get; set; }
        public string Postitoimipaikka { get; set; }
    }
}