using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model.Production
{
    public class MReturnDrainedMilkQualityQC
    {
        public int ReturnDrainedMilkQualityQCId { get; set; }

        public int RMRId { get; set; }

        public int ReturnDrainedMilkQCShiftId { get; set; }

        public DateTime ReturnDrainedMilkQCDate { get; set; }

        public string Remarks { get; set; }

        public double Quantity { get; set; }

        public double MBRT { get; set; }

        public double TEMP { get; set; }

        public string Source { get; set; }
        public int ReturnDrainedMilkQcStatusId { get; set; }
        public string flag { get; set; }
    }
}