using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model.Production
{
    public class MCurdProcessing
    {
        public int CurdId { get; set; }
        public int RMRId { get; set; }
        public int CurdProcessShiftId { get; set; }
        public string CurdProcessDate { get; set; }
        public string BatchNo { get; set; }
        public double Quantity { get; set; }
        public string MilkType { get; set; }
        public double HeatingTemp { get; set; }
        public string HoldingTime { get; set; }
        public double InoculationMilkTemp { get; set; }
        public string CultureAdd { get; set; }
        public string CultureLotNo { get; set; }
        public string CultureExpDate { get; set; }
        public string IncubationStartTime { get; set; }
        public string IncubationEndTime { get; set; }
        public double MilkQtyforCanCurd { get; set; }
        public double MilkQtyforCupPouchCurd { get; set; }
        public string PackingStartTime { get; set; }
        public string PackingEndTime { get; set; }
        public string BatchCode { get; set; }
        public double ColdRoomTemp { get; set; }
        public string ProcessedBy { get; set; }
        public string LabTechnician { get; set; }
        public string VerifiedBy { get; set; }
        public string ApprovedBy { get; set; }
        public int CurdProcessingStatusId { get; set; }
        public string flag { get; set; }
    }
}