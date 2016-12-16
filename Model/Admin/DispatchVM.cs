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

        public int Salesman1 { get; set; }
        public int Salesman2 { get; set; }
        public int Driver1 { get; set; }
        public int Driver2 { get; set; }
        public int VehicleId { get; set; }
        public double Trays { get; set; }
        public double Cartons { get; set; }
        public double IceBox { get; set; }
        public double Others { get; set; }
    }
}