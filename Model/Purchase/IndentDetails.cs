using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model.Purchase
{
    public class IndentDetails
    {
        public int IndentDetailsId { get; set; }
        public int IndentId { get; set; }
        public int ItemId { get; set; }
        public decimal Quantity { get; set; }

        public string Purpose { get; set; }

        public decimal Delivered { get; set; }

    }
}