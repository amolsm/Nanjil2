using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model.Production
{
    public class MMilkPackedData
    {
        public int PackedDataId { get; set; }

        public int RMRId { get; set; }

        public int ShiftId { get; set; }

        public DateTime PackedDate { get; set; }

        public string PackingOperatorName { get; set; }

        public string ReceivedBy { get; set; }

        public string TypeOfMilk { get; set; }

        public double QuantityIn1000ML { get; set; }

        public double QuantityIn500ML { get; set; }

        public double QuantityIn450ML { get; set; }

        public double QuantityIn250ML { get; set; }

        public double QuantityIn200ML { get; set; }

        public double CurdCupQty { get; set; }

        public double Curd500MLQty { get; set; }

        public double Curd450MLQty { get; set; }

        public double ButterMilk200ML { get; set; }

        public double TotalQtyOfMilk { get; set; }

        public double TotalQtyOfCurd { get; set; }

        public string Total { get; set; }

        public string ColdRoomNo { get; set; }

        public int PackingDetailStatusId { get; set; }
        public string flag { get; set; }
    }
}