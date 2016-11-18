using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;
using DataAcess;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class DBInsertAgentInfo
    {

        DBHelper _DBHelper = new DBHelper();
        public int InsertAgentInfo(AgentInfo agentinfo)
        {
            int result = 0;
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@AgentID", agentinfo.AgentID));
                paramCollection.Add(new DBParameter("@AgentCode", agentinfo.AgentCode));
                paramCollection.Add(new DBParameter("@RouteID", agentinfo.RouteID));
                paramCollection.Add(new DBParameter("@AgentName", agentinfo.AgentName));
                paramCollection.Add(new DBParameter("@DateofJoining", agentinfo.DateofJoining));
                paramCollection.Add(new DBParameter("@AppriveBy", agentinfo.AppriveBy));
                paramCollection.Add(new DBParameter("@Isactive", agentinfo.Status));
             
                paramCollection.Add(new DBParameter("@Agensytype", agentinfo.Agensytype));
                paramCollection.Add(new DBParameter("@Address1", agentinfo.Address1));
                paramCollection.Add(new DBParameter("@Address2", agentinfo.Address2));
                paramCollection.Add(new DBParameter("@Address3", agentinfo.Address3));
                paramCollection.Add(new DBParameter("@Email", agentinfo.Email));
                paramCollection.Add(new DBParameter("@TelephoneNo", agentinfo.TelephoneNo));
                paramCollection.Add(new DBParameter("@MobileNo", agentinfo.MobileNo));
             
                
                paramCollection.Add(new DBParameter("@City", agentinfo.City));
                paramCollection.Add(new DBParameter("@Districk", agentinfo.Districk));
                paramCollection.Add(new DBParameter("@State", agentinfo.State));
                paramCollection.Add(new DBParameter("@Country", agentinfo.Country));
                paramCollection.Add(new DBParameter("@BillingMethod", agentinfo.BillingMethod));
                paramCollection.Add(new DBParameter("@PaymentMode", agentinfo.PaymentType));
                paramCollection.Add(new DBParameter("@DepositeAmount", agentinfo.DepositAmount));
                paramCollection.Add(new DBParameter("@Bankname", agentinfo.BankName));
                paramCollection.Add(new DBParameter("@AccountNo", agentinfo.AccounNo));
                paramCollection.Add(new DBParameter("@AccountType", agentinfo.AccountType));
                paramCollection.Add(new DBParameter("@IFScode", agentinfo.IFSCCode));
                paramCollection.Add(new DBParameter("@Volume", agentinfo.Volume));
                paramCollection.Add(new DBParameter("@NoTrays", agentinfo.NoofTrays));
                paramCollection.Add(new DBParameter("@DoorToDoor", agentinfo.DoortoDoor));


                paramCollection.Add(new DBParameter("@FreezerAvailable", agentinfo.FreezerAvailable));
                paramCollection.Add(new DBParameter("@FreezerRetruns", agentinfo.FreezerRestrun));
                paramCollection.Add(new DBParameter("@Deactivedate", agentinfo.Deactivedate));
                paramCollection.Add(new DBParameter("@DeactiveReason", agentinfo.DeactiveReason));
                paramCollection.Add(new DBParameter("@AmountReturned", agentinfo.AmountReturned));

                paramCollection.Add(new DBParameter("@TraysReturned", agentinfo.TraysReturned));
                paramCollection.Add(new DBParameter("@IsArchive", agentinfo.IsArchive));
                paramCollection.Add(new DBParameter("@SchemeAmount", agentinfo.SchemeAmount));
                paramCollection.Add(new DBParameter("@TotalSchemeAmount", agentinfo.SchemeTotalAmount));
                paramCollection.Add(new DBParameter("@CreatedBy", agentinfo.CreatedBy));
                paramCollection.Add(new DBParameter("@Createddate", agentinfo.Createddate));
                paramCollection.Add(new DBParameter("@ModifiedBy", agentinfo.ModifiedBy));
                paramCollection.Add(new DBParameter("@ModifiedDate", agentinfo.ModifiedDate));
                paramCollection.Add(new DBParameter("@flag", agentinfo.flag));
                result = _DBHelper.ExecuteNonQuery("Sp_InsertAgentInfo", paramCollection, CommandType.StoredProcedure);
                //result = _DBHelper.ExecuteNonQuery("test1", paramCollection, CommandType.StoredProcedure);
                
            }
            catch (SqlException ex)
            {
               // Comman.Comman.msg = ex.ToString();

                if (ex.Message.Contains("UNIQUE KEY constraint"))
                {
                    Comman.Comman.msg = "DUPLICATE AGENT CODE : Agent Code Should be Unique";
                }
                
            }
            return result;
        }
        public DataSet GetAgentbyID(int AgentID)
        {
            DataSet Ds = new DataSet();// result = 0;
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@AgentID",AgentID ));
                Ds = _DBHelper.ExecuteDataSet("Sp_GetAgentIDbyID", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {


            }
            return Ds;
 
        }
        public DataSet GetAllAgentDetails()
        {
            DataSet Ds = new DataSet();// result = 0;
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();               
                Ds = _DBHelper.ExecuteDataSet("sp_GetAllAgentDetails", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {


            }
            return Ds;
 
        }

        

    }
}