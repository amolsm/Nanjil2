using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model
{
    public class Marketings:AgentInfo
    {
        public double TotalSchemeAmt { get; set; }

        public double SchemerefundAmt { get; set; }

        public double balanceAmt { get; set; }

        public string requestdate { get; set; }

        public string refunddate { get; set; }

        public string TokanNo { get; set; }
    }
}