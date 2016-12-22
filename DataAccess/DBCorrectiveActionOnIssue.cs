using DataAcess;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DataAccess
{
    public class DBCorrectiveActionOnIssue
    {
        DBHelper _DBHelper = new DBHelper();
        public int InsertCorrectiveActionOnIssues(CorrectiveActionOnIssuesModel correctiveActionOnIssuesModel)
        {
            int result = 0;
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@ID", correctiveActionOnIssuesModel.id));

                paramCollection.Add(new DBParameter("@TodayDate", correctiveActionOnIssuesModel._dateToday));
                paramCollection.Add(new DBParameter("@Issue", correctiveActionOnIssuesModel._issue));
                paramCollection.Add(new DBParameter("@Action", correctiveActionOnIssuesModel._Action));
                paramCollection.Add(new DBParameter("@ActionToBeTakenDate", correctiveActionOnIssuesModel._ActionToBeTakenDate));
                paramCollection.Add(new DBParameter("@ActionAdvisedBy", correctiveActionOnIssuesModel._ActionAdvisedBy));
                paramCollection.Add(new DBParameter("@ActionTakenBy", correctiveActionOnIssuesModel._ActionTakenBy));
                paramCollection.Add(new DBParameter("@FeedBackAfterTakenAction", correctiveActionOnIssuesModel._FeedBackAfterAction));
                paramCollection.Add(new DBParameter("@issueRegistedDate", correctiveActionOnIssuesModel._issueRegisteredDate));
                paramCollection.Add(new DBParameter("@IssueCode", correctiveActionOnIssuesModel._issueCode));
             //   paramCollection.Add(new DBParameter("@IssueclosedDate", correctiveActionOnIssuesModel._issuePID));
               paramCollection.Add(new DBParameter("@IssueP_ID", correctiveActionOnIssuesModel._issuePID));

                paramCollection.Add(new DBParameter("@flag", correctiveActionOnIssuesModel.flag));
                result = _DBHelper.ExecuteNonQuery("Sp_InsertCorrectiveAction", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception ee)
            {
                throw ee;
            }
            return result;
        }
        public DataSet GetCorrectiveActionInRp()
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            return _DBHelper.ExecuteDataSet("sp_GetCorrectiveInRp", paramCollection, CommandType.StoredProcedure);
        }
        public DataSet GetIssuesPendingDp()
        {
            DataSet DS = new DataSet();
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                //paramCollection.Add(new DBParameter("@ID", Id));
                return _DBHelper.ExecuteDataSet("sp_GetIssuesPendingDp", paramCollection, CommandType.StoredProcedure);
                //DS = _DBHelper.ExecuteDataSet("sp_GetIssuesPendingDp", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception e)
            {
            throw e; }
           // return DS;
        }
        public DataSet GetCorrectiveActiondetailsbyID(int Id)
        {
            DataSet DS = new DataSet();
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@ID", Id));
                DS = _DBHelper.ExecuteDataSet("sp_GetCorrectiveActionDetailsbyId", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            { }
            return DS;
        }
        public DataSet DataExisCorrectiveAction(string Issue)
        {
            DataSet DS = new DataSet();
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@issucode", Issue));
                DS = _DBHelper.ExecuteDataSet("Sp_DataExistCorrectiveActionOnIssue", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            { }
            return DS;
        }
        public DataSet GetIssueRegisteredDate(string Id)
        {
            DataSet DS = new DataSet();
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@Issueid", Id));
                DS = _DBHelper.ExecuteDataSet("sp_GetIssueRegisteredDate", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            { }
            return DS;
        }

        public DataSet GetIssuePID(string issueCode)
        {
            DataSet DS = new DataSet();
           
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@IssueCode", issueCode));
                DS = _DBHelper.ExecuteDataSet("sp_GetIssuePID", paramCollection, CommandType.StoredProcedure);
                
            }
            catch (Exception ee)
            {
                throw ee;
            }
           
                return DS;
          
        }
        public bool UpdateCorrectiveAction(CorrectiveActionOnIssuesModel correctiveActionOnIssuesModel)
        {
            int result = 0;
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@ID", correctiveActionOnIssuesModel.id));
                paramCollection.Add(new DBParameter("@TodayDate", correctiveActionOnIssuesModel._dateToday));
                paramCollection.Add(new DBParameter("@Issue", correctiveActionOnIssuesModel._issue));
                paramCollection.Add(new DBParameter("@Action", correctiveActionOnIssuesModel._Action));
                paramCollection.Add(new DBParameter("@ActionToBeTakenDate", correctiveActionOnIssuesModel._ActionToBeTakenDate));
                paramCollection.Add(new DBParameter("@ActionAdvisedBy", correctiveActionOnIssuesModel._ActionAdvisedBy));
                paramCollection.Add(new DBParameter("@ActionTakenBy", correctiveActionOnIssuesModel._ActionTakenBy));
                paramCollection.Add(new DBParameter("@FeedBackAfterTakenAction", correctiveActionOnIssuesModel._FeedBackAfterAction));
                paramCollection.Add(new DBParameter("@issueRegistedDate", correctiveActionOnIssuesModel._issueRegisteredDate));
                paramCollection.Add(new DBParameter("@IssueCode", correctiveActionOnIssuesModel._issueCode));
                paramCollection.Add(new DBParameter("@IssueP_ID", correctiveActionOnIssuesModel._issuePID));



                paramCollection.Add(new DBParameter("@flag", correctiveActionOnIssuesModel.flag));
                result = _DBHelper.ExecuteNonQuery("Sp_InsertCorrectiveAction", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception ee)
            {
                throw ee;
            }
            if (result > 0)
                return true;
            return false;
        }
       
    }
}