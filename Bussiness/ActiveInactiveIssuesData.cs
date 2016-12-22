using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Bussiness
{
    public class ActiveInactiveIssuesData
    {
        DBActiveInactiveIssues dbActiveInactiveIssues = new DBActiveInactiveIssues();
        public DataSet viewActiveInactiveIssues(string StartDate, string EndDate, string selectedIssueStatus)
        {
            return dbActiveInactiveIssues.viewActiveInactiveIssues(StartDate, EndDate, selectedIssueStatus);
        }
    }
}