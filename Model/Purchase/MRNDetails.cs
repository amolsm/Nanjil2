using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model.Purchase
{
    public class MRNDetails
    {
        public int Id { get; set; }
        public int OrderDetailsId { get; set; }
        public int ItemId { get; set; }
        public double OrderedQty { get; set; }
        public double ReceivedQty { get; set; }
        public double AcceptedQty { get; set; }
        public double RejectedQty { get; set; }
        public decimal Price { get; set; }
        public double Excise { get; set; }
        public double Vat { get; set; }
        public double Cst { get; set; }
        public decimal Amount { get; set; }
        public int Flag { get; set; }
    }
}