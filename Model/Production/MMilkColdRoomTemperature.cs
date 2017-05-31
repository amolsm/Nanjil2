using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model.Production
{
    public class MMilkColdRoomTemperature
    {
        public int MilkColdRoomTemperaturId { get; set; }

        public int RMRId { get; set; }

        public int MilkColdRoomTemperaturShiftId { get; set; }

        public DateTime MilkColdRoomTemperaturDate { get; set; }

        public string ColdRoomsForMilk { get; set; }

        public string ColdRoom1 { get; set; }

        public string ColdRoom2 { get; set; }

        public string ColdRoom3 { get; set; }

        public string CheckedBy { get; set; }

        public string verifierBy { get; set; }

        public int StatusId { get; set; }

        public string flag { get; set; }

        public string BreakAndDownServices { get; set; }

        public int MilkColdRoomStatusId { get; set; }
    }
}