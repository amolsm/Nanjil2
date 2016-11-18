using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model.Purchase
{
    public class Item
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public int CategoryId { get; set; }
        public bool IsActive { get; set; }

        public int RackId { get; set; }
        public int SectionId { get; set; }
        public int Flag { get; set; }

    }
}