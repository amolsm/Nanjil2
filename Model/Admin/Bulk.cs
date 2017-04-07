using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model.Admin
{
    public class Bulk
    {
        public int RouteId { get; set; }
        public string OrderDate { get; set; }
        public int Type { get; set; }

        public string Tokan { get; set; }
        public int UserId { get; set; }
        public string Flag { get; set; }
    }
}