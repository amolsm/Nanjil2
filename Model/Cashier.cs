using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model
{
    public class Cashier
    {
        public int AgentId { get; set; }
        public int RouteID { get; set; }
        public int BrandId { get; set; }
        public int Salesmanid { get; set; }
        public string DispatchDate { get; set; }

        public string trDate { get; set; }

        public double netamt { get; set; }

        public double payamt { get; set; }
        public double rscoins { get; set; }
        public int P2000 { get; set; }
        public int P1000 { get; set; }
        public int P500 { get; set; }
        public int P100 { get; set; }
        public int P50 { get; set; }
        public int P20 { get; set; }
        public int P10 { get; set; }
        public int P5 { get; set; }
        public int P2 { get; set; }
        public int P1 { get; set; }
        public int M2000 { get; set; }
        public int M1000 { get; set; }
        public int M500 { get; set; }
        public int M100 { get; set; }
        public int M50 { get; set; }
        public int M20 { get; set; }
        public int M10 { get; set; }
        public int M5 { get; set; }
        public int M2 { get; set; }
        public int M1 { get; set; }

        public double salesmanamt { get; set; }
        public double salespayamt { get; set; }

        public int createdby { get; set; }
        public string flag { get; set; }
        public string TokanId { get; set; }

    }
}