using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TilausASPNET.ViewModels
{
    public class OrderRows
    {
        // Tilaukset: --------------------------------------
        public int TilausID { get; set; }
        
        // Tilausrivit: --------------------------------------
        public int TilausriviID { get; set; }
        public int Maara { get; set; }
        public float TilausAhinta { get; set; }

        // Asiakkaat: --------------------------------------
        public int AsiakasID { get; set; }
       
        // Tuotteet:  --------------------------------------
        public int TuoteID { get; set; }
        public string TuoteNimi { get; set; }
        public float TuoteAhinta { get; set; }
        public string ImageLink { get; set; }
       
    }
}