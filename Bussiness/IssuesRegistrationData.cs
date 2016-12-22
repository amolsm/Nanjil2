using DataAccess;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Bussiness
{
    public class IssuesRegistrationData
    {
        DBIssueRegistration DBIssue = new DBIssueRegistration();
        public int InsertIssue(IssueRegistrationModel issueModel)
        {
            //  dbproduct = new DBProduct();
            return DBIssue.InsertIssueRegistration(issueModel);

        }
        public DataSet GetIssueDetailsbyId(int Id)
        {
         //   DBIssue = new DBProduct();
            return DBIssue.GetIssueDetailsbyId(Id);
        }
        public bool UpdateIssues(IssueRegistrationModel issueModel)
        {           
            return DBIssue.UpdateIssues(issueModel);
        }
        public int DeleteIssue(IssueRegistrationModel issueModel)
        {
            //dbproduct = new DBProduct();
            return DBIssue.DeleteIssue(issueModel);
        }
    }
}