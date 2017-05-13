using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model
{
    public class MHeadwiseReport
    {
        public DateTime Startdate { get; set; }
        public DateTime Enddate { get; set; }
        public int Head { get; set; }

        public string ParticularType { get; set; }
        public int Particular { get; set; }
    }
}