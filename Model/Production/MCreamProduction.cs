using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model.Production
{
    public class MCreamProduction
    {
        public int CreamProductionId { get; set; }

        public int RMRId { get; set; }

        public string BatchNo { get; set; }

        public int CreamProductionShiftId { get; set; }

        public string CreamProductionDate { get; set; }

      
        public string BatchCodeCream { get; set; }

        public double FAT { get; set; }

        public double CreamQty { get; set; }
        public int CreamStatusId { get; set; }
        public string flag { get; set; }
    }
}