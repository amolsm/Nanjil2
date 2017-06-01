using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model.Production
{
    public class MPastProcess   
    {
        public int pastProcessId { get; set; }

        public int RMRId { get; set; }

        public int StdId { get; set; }

        public string PastProcessDate { get; set; }
      
        public int PastShiftId { get; set; }

        public double IBTTemperature { get; set; }

        public string PastStartTime { get; set; }

        public double PastTempHeat1 { get; set; }

        public double Cool1 { get; set; }

        public double PastTempHeat2 { get; set; }

        public double Cool2 { get; set; }

        public double PastTempHeat3 { get; set; }

        public double Cool3 { get; set; }

        public double PastTempHeat4 { get; set; }

        public double Cool4 { get; set; }

        public double PastTempHeat5 { get; set; }

        public double Cool5 { get; set; }

        public string MilkClosingTime { get; set; }

        public string DoneBy { get; set; }

        public string flag { get; set; }

        public string StandardDate { get; set; }

        public int pastProcessStatusId { get; set; }



    }
}