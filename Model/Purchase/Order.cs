using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model.Purchase
{
    public class Order
    {
        public int OrderId { get; set; }
        public string OrderDate { get; set; }
        public int CreatedBy { get; set; }
        public string TillDate { get; set; }

        public int VendorId { get; set; }
        
        public string MDApproval { get; set; }
        public decimal TotalAmt { get; set; }
        
        public string Frieght { get; set; }
        public string PaymentTerms { get; set; }
        public string TransDamage { get; set; }
        public string Warranty { get; set; }
        public string Tokan { get; set; }

        public int Flag { get; set; }
    }
}