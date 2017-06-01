using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model.Production
{
    public class MMilkProductsTestBeforePackingQC
    {
        public int MilkProductsTestBeforePackingQCId { get; set; }

        public int RMRId { get; set; }

        public DateTime MilkProductsTestBeforePackingQCDate { get; set; }

        public int MilkProductsTestBeforePackingQCShiftId { get; set; }

        public string Particular { get; set; }

        public double Quantity { get; set; }

        public string TestName { get; set; }

        public string Result { get; set; }

        public string Remarks { get; set; }
        public int MilkProdTestBeforePackingQCStatusId { get; set; }
        public string flag { get; set; }
    }
}