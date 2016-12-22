using DataAcess;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DataAccess
{
    public class DBIssueRegistration
    {
        DBHelper _DBHelper = new DBHelper();
        DataSet DS;
        
        public int InsertIssueRegistration(IssueRegistrationModel issueRegistrationModel)
        {
            int result = 0;
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@IssueID", issueRegistrationModel._IssueID));

                paramCollection.Add(new DBParameter("@IssueDateTime", issueRegistrationModel._IssueDateTime));
                paramCollection.Add(new DBParameter("@IssueArisedBy", issueRegistrationModel._IssueArisedBy));
               // paramCollection.Add(new DBParameter("@Address", issueRegistrationModel._IssueAddress));
                paramCollection.Add(new DBParameter("@ContactNo", issueRegistrationModel._IssueContactNo));
                paramCollection.Add(new DBParameter("@IssueCode", issueRegistrationModel._Issue));
                paramCollection.Add(new DBParameter("@IssueType", issueRegistrationModel._IssueType));
                paramCollection.Add(new DBParameter("@IssueOnBrand", issueRegistrationModel._IssueOnBrand));
                paramCollection.Add(new DBParameter("@IssueCommodity", issueRegistrationModel._IssueCommodity));
                paramCollection.Add(new DBParameter("@DeviatedQty", issueRegistrationModel._DeviatedQty));
                paramCollection.Add(new DBParameter("@IssueVerifiedBy", issueRegistrationModel._IssueVerifiedBy));
                paramCollection.Add(new DBParameter("@IssueForwardTo", issueRegistrationModel._IssueForwardTo));
                paramCollection.Add(new DBParameter("@IssueEnteredBy", issueRegistrationModel._IssueEnteredBy));
                paramCollection.Add(new DBParameter("@IssueOnProductType", issueRegistrationModel._IssueOnProductType));
                paramCollection.Add(new DBParameter("@Issues", issueRegistrationModel._IssueCode));
                paramCollection.Add(new DBParameter("@code", issueRegistrationModel._code));

                paramCollection.Add(new DBParameter("@flag", issueRegistrationModel.flag));

                result = _DBHelper.ExecuteNonQuery("Sp_InsertIssuesRegistration", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception ee)
            {  }
            return result;
        }
        public bool UpdateIssues(IssueRegistrationModel issueRegistrationModel)
        {
            int result = 0;
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@IssueID", issueRegistrationModel._IssueID));

                paramCollection.Add(new DBParameter("@IssueDateTime", issueRegistrationModel._IssueDateTime));
                paramCollection.Add(new DBParameter("@IssueArisedBy", issueRegistrationModel._IssueArisedBy));
                // paramCollection.Add(new DBParameter("@Address", issueRegistrationModel._IssueAddress));
                paramCollection.Add(new DBParameter("@ContactNo", issueRegistrationModel._IssueContactNo));
                paramCollection.Add(new DBParameter("@IssueCode", issueRegistrationModel._Issue));
                paramCollection.Add(new DBParameter("@IssueType", issueRegistrationModel._IssueType));
                paramCollection.Add(new DBParameter("@IssueOnBrand", issueRegistrationModel._IssueOnBrand));
                paramCollection.Add(new DBParameter("@IssueCommodity", issueRegistrationModel._IssueCommodity));
                paramCollection.Add(new DBParameter("@DeviatedQty", issueRegistrationModel._DeviatedQty));
                paramCollection.Add(new DBParameter("@IssueVerifiedBy", issueRegistrationModel._IssueVerifiedBy));
                paramCollection.Add(new DBParameter("@IssueForwardTo", issueRegistrationModel._IssueForwardTo));
                paramCollection.Add(new DBParameter("@IssueEnteredBy", issueRegistrationModel._IssueEnteredBy));
                paramCollection.Add(new DBParameter("@IssueOnProductType", issueRegistrationModel._IssueOnProductType));
                paramCollection.Add(new DBParameter("@Issues", issueRegistrationModel._IssueCode));
                paramCollection.Add(new DBParameter("@code", issueRegistrationModel._code));
                paramCollection.Add(new DBParameter("@flag", issueRegistrationModel.flag));
             
                result = _DBHelper.ExecuteNonQuery("Sp_InsertIssuesRegistration", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception ee)
            {
                throw ee;
            }
            if (result > 0)
                return true;
            return false;
        }
        public DataSet BindBrandDropDwon()
        {
            DataSet DS = new DataSet();
            DBParameterCollection paramCollection = new DBParameterCollection();
            return _DBHelper.ExecuteDataSet("sp_GetBrandInfo");

        }
        public DataSet GetIssueInRp()
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            return _DBHelper.ExecuteDataSet("sp_GetIssueInRp", paramCollection, CommandType.StoredProcedure);
        }
        public DataSet GetIssueID()
        {
            DataSet DS=new DataSet();       
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();              
                DS = _DBHelper.ExecuteDataSet("sp_GetIssueID", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception E)
            {
                throw E;             
            }
             return DS;
        }
        public DataSet GetIssueDetailsbyId(int Id)
        {
            DataSet DS = new DataSet();
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@IssueID", Id));
                DS = _DBHelper.ExecuteDataSet("sp_GetIssueDetailsbyId", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {}
            return DS;
        }
        public int DeleteIssue(IssueRegistrationModel issueModel)
        {

            DBParameterCollection paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@IssueID ", issueModel._IssueCode));
            return _DBHelper.ExecuteNonQuery("sp_DeleteIssue", paramCollection, CommandType.StoredProcedure);

        }

    }
    
}