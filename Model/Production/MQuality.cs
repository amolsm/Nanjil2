using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model.Production
{
    public class MQuality:RMRecieve
    {
       public int QualityId { get; set; }
        public DateTime QualityDate { get; set; }
        public double Temperature { get; set; }
        public double Alcohol { get; set; }
        public double Neutralizer { get; set; }
        public string Taste { get; set; }
        public string Smell { get; set; }
        public string Color { get; set; }
        public double Acidity { get; set; }
        public double HeatStability { get; set; }
        public double Fat { get; set; }
        public double CLR { get; set; }
        public double SNF { get; set; }
        public string TestedBy { get; set; }
        public string VerifiedBy { get; set; }
        public string Others { get; set; }
        public string Remarks { get; set; }
        public int QCStatus { get; set; }
        public string flag { get; set; }


    }
}