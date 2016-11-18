using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model.Purchase
{
    public class RackSections
    {
        public int RackSectionsId { get; set; }
        public string RackSectionName { get; set; }
        public int RackId { get; set; }
        public int IsActive { get; set; }
    }
}