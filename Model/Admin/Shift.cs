using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model.Admin
{
    public class Shifts
    {
        public int ShiftId { get; set; }
        public string ShiftName { get; set; }
        public string Description { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public bool Status { get; set; }
        public int Flag { get; set; }
    }
}