using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model.Purchase
{
    public class RequestCart
    {
        public int RequestCartId { get; set; }
        public string Tokan { get; set; }
        public int RequestBy { get; set; }
        public int ItemId { get; set; }
        public int VendorId { get; set; }
        public decimal Quantity { get; set; }
        public int UnitId { get; set; }
        public string Specification { get; set; }
        public string Purpose { get; set; }
        public string Remark { get; set; }
        public int Flag { get; set; }
    }
}