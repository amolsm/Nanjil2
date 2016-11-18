using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model.Purchase
{
    public class ItemRate
    {
        public int ItemRatesId { get; set; }
        public int VendorId { get; set; }
        public int ItemId { get; set; }

        public double Quantity { get; set; }
        public int UnitId { get; set; }
        public decimal Price { get; set; }
        public decimal Shipping { get; set; }
        public double Excise { get; set; }
        public double CST { get; set; }
        public double VAT { get; set; }
        public decimal Insurance { get; set; }
        public decimal Freight { get; set; }
        public decimal TotalPrice { get; set; }
        public int Flag { get; set; }
    }
}