using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model.Production
{
    public class MAfterPackedMilkTestQCDetails
    {
        public int AfterPackedMilkTestQCId { get; set; }

        public int RMRId { get; set; }

        public int QualityId { get; set; }

        public int ShiftId { get; set; }

        public DateTime AfterPackedMilkTestQCDate { get; set; }

        public string Source { get; set; }

        public double Weight { get; set; }

        public double Quantity { get; set; }

        public double Temperature { get; set; }

        public double FAT { get; set; }

        public double CLR { get; set; }

        public double SNF { get; set; }

        public string QualityStartTime { get; set; }

        public string Hour1 { get; set; }

        public string Hours2 { get; set; }

        public string Hours3 { get; set; }

        public string Hours4 { get; set; }

        public string Hours5 { get; set; }

        public string Hours6 { get; set; }

        public string Hours7 { get; set; }

        public string Hours8 { get; set; }

        public string TotalHours { get; set; }
        public int MilkPouchQcStatusId { get; set; }
        public string flag { get; set; }
    }
}