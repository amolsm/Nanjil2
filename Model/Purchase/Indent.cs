using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model.Purchase
{
    public class Indent
    {
        public int IndentId { get; set; }
       
        public int IndentByEmp { get; set; }
        public DateTime IndentDate { get; set; }
        public string IndentDate1 { get; set; }
        public string TillDate { get; set; }
        public string Tokan { get; set; }
        public int Flag { get; set; }

    }
}