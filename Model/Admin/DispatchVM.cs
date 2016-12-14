using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model.Admin
{
    public class DispatchVM
    {
        public int DispatchId { get; set; }
        public string Flag { get; set; }

        public double Quantity { get; set; }
        public int EditedBy { get; set; }
    }
}