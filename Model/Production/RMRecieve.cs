using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model.Production
{
    public class RMRecieve
    {
        public int RMRId { get; set; }
        public int Id { get; set; }
        public DateTime RMRDate { get; set; }
        public int  RMRShiftId { get; set; }

      
        public string TankerNo { get; set; }

        public string MilkType { get; set; }

        public double Quantity { get; set; }

        public string TankMilkReciptNo { get; set; }

        public int CreatedBy { get; set; }

        public string CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public string flag { get; set; }

        public int QCId { get; set; }

        public string MBRTStart { get; set; }

        public string MBRTEnd { get; set; }

        public string TotalHours { get; set; }

        public string ShiftName { get; set; }

        public string BatchNo { get; set; }

        //public int CheckBatchNo { get; set; }
    }
}