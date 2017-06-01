using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model.Production
{
    public class MCurdProcessingQC
    {
        public int CurdQCId { get; set; }
        public int CurdId { get; set; }
        public int RMRId { get; set; }
        public string CurdQCDate { get; set; }
        public string BatchNo { get; set; }
        public int CurdQCShiftId { get; set; }
        public string ShiftName { get; set; }
        public string CurdQCProcessTime  { get; set; }
        public int CurdQCSiloNo { get; set; }
        public double CurdQCProcessQty { get; set; }
        public double CurdQCTemp { get; set; }
        public double CurdQCFat { get; set; }
        public double CurdQCCLR { get; set; }
        public double CurdQCSNF { get; set; }
        public double CurdQCAcidity { get; set; }
        public string HomEfficiency { get; set; }
        public string CurdQCTaste { get; set; }
        public string CurdQCSmell { get; set; }
        public string CurdQCColor { get; set; }
        public string CurdQCMBRTStartTime { get; set; }
        public string CurdQCMBRTEndTime { get; set; }
        public string CurdQCMBRTTotalHours { get; set; }
        public string PhosphataseStartTime { get; set; }
        public string PhosphataseEndTime { get; set; }
        public string PhosphataseTotalHours { get; set; }
        public int CurdQCStatusId { get; set; }
        public string flag { get; set; }
    }
}