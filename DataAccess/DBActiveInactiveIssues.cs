using DataAcess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DataAccess
{
    public class DBActiveInactiveIssues
    {
        DBHelper _DBHelper = new DBHelper();
        public DataSet viewActiveInactiveIssues(string StartDate, string EndDate, string selectedIssueStatus)
        {
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@StartDate", StartDate));
                paramCollection.Add(new DBParameter("@EndDate", EndDate));
                paramCollection.Add(new DBParameter("@selectedIssueStatus", selectedIssueStatus));
                return _DBHelper.ExecuteDataSet("sp_GetActiveInactiveIssues", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception ee)
            {
                throw ee;
            }
        }
    }
}