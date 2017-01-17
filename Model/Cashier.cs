using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model
{
    public class Cashier
    {
        public int AgentId { get; set; }
        public int Salesmanid { get; set; }
        public string DispatchDate { get; set; }

        public string trDate { get; set; }

        public double netamt { get; set; }

        public double payamt { get; set; }
        public double rscoins { get; set; }
        public int rs200 { get; set; }
        public int rs100 { get; set; }
        public int rs500 { get; set; }

        public int rs2000 { get; set; }
        public int rs1000 { get; set; }
        public int rs10 { get; set; }
        public int rs20 { get; set; }
        public int rs50 { get; set; }
        public double salesmanamt { get; set; }
        public double salespayamt { get; set; }

        public int createdby { get; set; }
        public string flag { get; set; }
        public string TokanId { get; set; }

    }
}