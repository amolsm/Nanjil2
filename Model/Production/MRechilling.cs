using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model.Production
{
    public class MRechilling
    {
        public int RMRId { get; set; }
        public int QualityId { get; set; }
        public string BatchNo { get; set; }
        public int ShiftId { get; set; }
        public string Date { get; set; }
        public int SiloNo { get; set; }
        public string TypeOfMilk { get; set; }
        public double Quantity { get; set; }
        public double IBTInTemperature { get; set; }
        public double IBTOutTemperature { get; set; }
        public double MilkInTemperature { get; set; }
        public double MilkOutTemperature { get; set; }
        public string RechilledBy { get; set; }
        public int RechillStatusId { get; set; }
        public string  flag { get; set; }

    }
}