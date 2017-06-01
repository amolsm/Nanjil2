using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model.Production
{
    public class MHomogenizer
    {
        public int HomogenizerId { get; set; }

        public int RMRId { get; set; }

        public DateTime HomogenizerDate { get; set; }

        public int HomogenizerShiftId { get; set; }

        public string MachineStartTime { get; set; }

        public string MachineEndTime { get; set; }

        public double PressureFirstStage { get; set; }

        public double PressureSecondStage { get; set; }

        public int OilleakageId { get; set; }

        public double HomogenizedQty { get; set; }

        public string Technician { get; set; }

        public string Homogenized { get; set; }

        public string Remarks { get; set; }

        public int HomogenizerStatusId { get; set; }

        public string flag { get; set; }
    }
}