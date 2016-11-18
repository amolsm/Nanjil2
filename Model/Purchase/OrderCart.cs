using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model.Purchase
{
    public class OrderCart
    {
        public int OrderCartId { get; set; }
        public string Tokan { get; set; }
        public int CreatedBy { get; set; }
        public int ItemId { get; set; }
        public int RequestDetailsId { get; set; }
        public int VendorId { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }

        public double Excise { get; set; }
        public double Vat { get; set; }
        public double cst { get; set; }
        public decimal Insurance { get; set; }
        public decimal Amt { get; set; }
        public int Flag { get; set; }
    }
}