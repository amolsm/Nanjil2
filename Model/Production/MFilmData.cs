using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model.Production
{
    public class MFilmData
    {

        public int FilmDataId { get; set; }

        public int RMRId { get; set; }

        public int ShiftId { get; set; }

        public DateTime FilmDate { get; set; }

        public string Product { get; set; }

        public string CommodityWise { get; set; }

        public double OpeningStock { get; set; }

        public double ReceivedQty { get; set; }

        public double CalculateConsumedQty { get; set; }

        public double Wastage { get; set; }

        public double ClosingStock { get; set; }

        public string MilkType { get; set; }

        public int FilmDetailsStatusId { get; set; }
        public string flag { get; set; }

    }
}