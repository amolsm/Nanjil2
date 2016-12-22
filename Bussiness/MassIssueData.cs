using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Bussiness
{
    public class MassIssueData
    {
        DBMassIssue dbmassIssue = new DBMassIssue();
        public DataSet viewMassIssue(string StartDate, string EndDate, string selectedIssue,string flag)
        {
            return dbmassIssue.viewMassIssue(StartDate, EndDate, selectedIssue,flag);
        }
        public DataSet viewIssuPedingReport(string StartDate, string EndDate, string selectedIssue)
        {
            return dbmassIssue.viewIssuPedingReport(StartDate, EndDate, selectedIssue);
        }
    }
}