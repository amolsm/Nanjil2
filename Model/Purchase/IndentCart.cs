using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model.Purchase
{
    public class IndentCart
    {
        public int IndentCartId { get; set; }
        public string Tokan { get; set; }
        public int IndentBy { get; set; }
        public int ItemId { get; set; }
        public decimal Quantity { get; set; }
        public string Purpose { get; set; }
        public int Flag { get; set; }

    }
}