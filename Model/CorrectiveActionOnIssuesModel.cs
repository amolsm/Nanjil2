using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model
{
    public class CorrectiveActionOnIssuesModel
    {
        public int id { get; set; }
        public string _dateToday { get; set; }
        public string _issue { get; set; }

        public string _issueCode { get; set; }
        public string _Action { get; set; }
        public string _ActionToBeTakenDate { get; set; }
        public string _ActionAdvisedBy { get; set; }
        public string _ActionTakenBy { get; set; }
        public string _FeedBackAfterAction { get; set; }
        public string _issueRegisteredDate { get; set; }
        public string flag { get; set; }

        public int _issuePID { get; set; }


    }
}