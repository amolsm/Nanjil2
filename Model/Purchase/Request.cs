using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model.Purchase
{
    public class Request
    {
        public int RequestId { get; set; }
        public string RequestCode { get; set; }
        public int CreatedBy { get; set; }
        public DateTime RequestDate { get; set; }
        public string ReqDate { get; set; }
        public string ReqStatus { get; set; }
        public string Tokan { get; set; }
        public int Flag { get; set; }

    }
}