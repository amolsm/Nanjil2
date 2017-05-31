using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model.Production
{
    public class MTraceabilityMilkQC
    {
        public int TraceabilityMilkQCId { get; set; }

        public int RMRId { get; set; }

        public DateTime CreamAndSkimDate { get; set; }

        public DateTime PackingDate { get; set; }

        public int TraceabilitMilkQCShiftId { get; set; }
        public string TankerCode { get; set; }
        public string TankerNo { get; set; }

        public string SMPBatchCode { get; set; }

        public string TankerPampingTime { get; set; }

        public string ChilledMilkSiloNo { get; set; }

        public string ProcessSiloNo { get; set; }

        public double CreamTemperature { get; set; }

        public double SkimTemperature { get; set; }

        public double FAT { get; set; }

        public string Taste { get; set; }

        public string Smell { get; set; }

        public string Color { get; set; }

        public string PhosphatasTest { get; set; }

        public double Acidity { get; set; }

        public double CLR { get; set; }

        public double SNF { get; set; }

        public string PackedCode { get; set; }

        public string Technician { get; set; }
        public int TraceabilityStatusId { get; set; }
        public string flag { get; set; }
    }
}