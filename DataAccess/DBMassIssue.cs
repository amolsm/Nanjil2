using DataAcess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DataAccess
{
    public class DBMassIssue
    {
        DBHelper _DBHelper = new DBHelper();
        
        public DataSet viewMassIssue(string StartDate, string EndDate, string selectedIssue,string flag)
        {

            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@StartDate",StartDate));
            paramCollection.Add(new DBParameter("@EndDate",EndDate));
            paramCollection.Add(new DBParameter("@selectedIssue",selectedIssue));
            paramCollection.Add(new DBParameter("@flag", flag));
            return _DBHelper.ExecuteDataSet("sp_GetMassIssueReport", paramCollection, CommandType.StoredProcedure);
        }
        public DataSet viewIssuPedingReport(string StartDate, string EndDate, string selectedIssue)
        {

            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@StartDate", StartDate));
            paramCollection.Add(new DBParameter("@EndDate", EndDate));
            paramCollection.Add(new DBParameter("@selectedIssue", selectedIssue));
            return _DBHelper.ExecuteDataSet("sp_GetIssuesPendingReport", paramCollection, CommandType.StoredProcedure);
        }
    }
}