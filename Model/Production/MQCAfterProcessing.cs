using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model.Production
{
    public class MQCAfterProcessing
    {
        public int APQCId { get; set; }
        public int RMRId { get; set; }
        public string BatchCode { get; set; }
        public string APQCDate { get; set; }
        public int APQCShiftId { get; set; }
        public string ProcessingTime { get; set; }
        public int SiloNo { get; set; }
        public double ProcessedQty { get; set; }
        public double ProcessTemperature { get; set; }
        public string OrganoSmell { get; set; }
        public string OrganoTaste { get; set; }
        public string OrganoColor { get; set; }
        public double Acidity { get; set; }
        public string PhosStartTime { get; set; }
        public string PhosEndTime { get; set; }
        public string PhosTotalHrs { get; set; }
        public string MBRTStartTime { get; set; }
        public string MBRTEndTime { get; set; }
        public string MBRTTotalHrs { get; set; }
        public double Fat { get; set; }
        public double CLR { get; set; }
        public double SNF { get; set; }
        public string HomEfficiency { get; set; }
        public int AfterProcessingStatusId { get; set; }
        public string flag { get; set; }

    }
}