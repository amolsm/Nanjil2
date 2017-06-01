using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model.Production
{
    public class MPasteurizationQC
    {
        public int PastQCId { get; set; }

        public int PastProcessId { get; set; }

        public int StdId { get; set; }

        public int QualityId { get; set; }
        public int RMRId { get; set; }

        public string BatchNo { get; set; }

        public int PastQCShiftId { get; set; }

        public string PastQCDate { get; set; }

        public double TemperatureHeat { get; set; }

        public double TempChill { get; set; }

        public string DoneBy { get; set; }

        public string Remarks { get; set; }

        public int QCStatus { get; set; }

        public string flag { get; set; }
    }
}