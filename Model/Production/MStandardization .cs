using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model.Production
{
    public class MStandardization
    {
        public int RMRId { get; set; }
        public int StdId { get; set; }
        public int QualityId { get; set; }
        public string StandardDate { get; set; }
        public int StdShiftId { get; set; }
        public string SiloNo { get; set; }
        public double RCMQuantity { get; set; }
        public string StandardizationStartTime { get; set; }
        public string StandardizationEndTime { get; set; }
        public double CuttingMilkQuantity { get; set; }
        public double CuttingMilkFAT { get; set; }
        public double CuttingMilkSNF { get; set; }
        public double Skim { get; set; }
        public double SkimFAT { get; set; }
        public double SkimSNF { get; set; }
        public double RCM { get; set; }
        public double SMP { get; set; }
        public double CreamAdd { get; set; }
        public double CreamProduced { get; set; }
        public double TotalQuantity { get; set; }
        public string TypeOfMilk { get; set; }
        public string Remarks { get; set; }
        public string Custom1 { get; set; }
        public string Custom2 { get; set; }
        public string Custom3 { get; set; }
        public string Custom4 { get; set; }
        public string Custom5 { get; set; }
        public string StatusName { get; set; }
        public int StandardizationStatusId { get; set; }
        public string flag { get; set; }

    }
}