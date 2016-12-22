using DataAccess;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Bussiness
{
    public class CorrectiveActionOnIssuesData
    {
        DBCorrectiveActionOnIssue dbCorrectiveActionOnIssue = new DBCorrectiveActionOnIssue();
        CorrectiveActionOnIssuesModel correctiveActionModel = new CorrectiveActionOnIssuesModel();
        
        public int InsertCorrectiveActionOnIssues(CorrectiveActionOnIssuesModel correctiveActionModel)
        {
            //  dbproduct = new DBProduct();
            return dbCorrectiveActionOnIssue.InsertCorrectiveActionOnIssues(correctiveActionModel);
        }
       
        public DataSet GetCorrectiveActiondetailsbyID(int Id)
        {
            //   DBIssue = new DBProduct();
            return dbCorrectiveActionOnIssue.GetCorrectiveActiondetailsbyID(Id);
        }
        public DataSet DataExisCorrectiveAction(string issuecode)
        {
            //   DBIssue = new DBProduct();
            return dbCorrectiveActionOnIssue.DataExisCorrectiveAction(issuecode);
        }
        
        public DataSet GetIssueRegisteredDate(string Id)
        {
            //   DBIssue = new DBProduct();
            return dbCorrectiveActionOnIssue.GetIssueRegisteredDate(Id);
        }
        public DataSet GetIssuePID(string IssueCode)
        {
            //   DBIssue = new DBProduct();
            return dbCorrectiveActionOnIssue.GetIssuePID(IssueCode);
        }
        public bool UpdateCorrectiveAction( CorrectiveActionOnIssuesModel correctiveActionModel)
        {
            return dbCorrectiveActionOnIssue.UpdateCorrectiveAction(correctiveActionModel);
        }
      
        public DataSet GetIssuesPendingDp()
        {
            //   DBIssue = new DBProduct();
            return dbCorrectiveActionOnIssue.GetIssuesPendingDp();
        }
    }
}