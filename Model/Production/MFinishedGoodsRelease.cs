using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model.Production
{
    public class MFinishedGoodsRelease
    {
        public int FinishgoodId { get; set; }
        public int RMRId { get; set; }
        public string FinishedGoodsBatchCode { get; set; }
        public string TypeofMilk { get; set; }
        public string FinishedGoodsQuantity { get; set; }
        public string FinishedGoodsDate { get; set; }
        public int FinishedGoodsShiftId { get; set; }
        public string FinishedGoodsMfgDate { get; set; }
        public int FinishedGoodsStatusId { get; set; }
        public string flag { get; set; }
    }
}