using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model.Production
{
    public class MStandardizationProductsAdded
    {
        public int StandardizationProductsAddedId { get; set; }

        public int RMRId { get; set; }

        public DateTime StandardizationProductsAddedDate { get; set; }

        public int StandardizationProductsAddedShiftId { get; set; }

        public string MilkType { get; set; }

        public double SMPQuantity { get; set; }

        public double Creamkg { get; set; }

        public double Waterliters { get; set; }

        public double CondensedMilk { get; set; }

        public double ButterOil { get; set; }

        public double SkimmedMilk { get; set; }

        public string Others { get; set; }
        public int StdStatusId { get; set; }
        public string flag { get; set; }
    }
}