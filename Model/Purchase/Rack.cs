using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model.Purchase
{
    public class Rack
    {
        public int RackId { get; set; }
        public string RackName { get; set; }
        public bool IsActive { get; set; }
        public int SecCount { get; set; }
        public int Flag { get; set; }
    }
}