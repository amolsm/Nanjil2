using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model.Purchase
{
    public class MRN
    {
        public int MRNId { get; set; }
        public int CreatedBy { get; set; }
        public int VendorId { get; set; }
        public string PRNo { get; set; }
        public string DepartmentName { get; set; }
        public int OrderId { get; set; }
        public string BillNo { get; set; }
        public string BillDate { get; set; }
        public string RequiredFor { get; set; }
        public string Remarks { get; set; }
        public int ReceivedBy { get; set; }
        public int QCBy { get; set; }
        public int ApprovedBy { get; set; }
        public string VehicleNo { get; set; }
        public int FinMgr { get; set; }

        public decimal TotalAmt { get; set; }
    }
}