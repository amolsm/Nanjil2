using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model
{
    public class IssueRegistrationModel : User
    {
        public int _IssueID { get; set; }
        public string _IssueDateTime { get; set; }
        public string _IssueArisedBy { get; set; }
        public string _IssueAddress { get; set; }
        public string _IssueContactNo { get; set; }
        public string _Issue { get; set; }
        public string _IssueType { get; set; }
        public string _IssueOnBrand { get; set; }
        public string _IssueOnProductType { get; set; }
        public string _IssueCode { get; set; }
        public string _code { get; set; }


        public string _IssueCommodity { get; set; }
        public string _DeviatedQty { get; set; }
        public string _IssueVerifiedBy { get; set; }
        public string _IssueForwardTo{ get; set; }
        public string _IssueEnteredBy { get; set; }
        public string flag { get; set; }



        public string _IssueStartDate { get; set; }
        public string _IssueEndDate { get; set; }
        public string _SelectedIssue { get; set; }
      




    }
}