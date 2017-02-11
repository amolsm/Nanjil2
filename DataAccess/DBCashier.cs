using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;
using System.Data;
using DataAcess;

namespace DataAccess
{
    public class DBCashier
    {
        DBHelper _DBHelper = new DBHelper();

        public DataSet AddCashierInfo(Cashier cm)
        {
            DataSet DS = new DataSet();
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
               
                paramCollection.Add(new DBParameter("@DispatchDate", cm.DispatchDate));
                paramCollection.Add(new DBParameter("@BrandId", cm.BrandId));
                paramCollection.Add(new DBParameter("@salesmanid", cm.Salesmanid));
                paramCollection.Add(new DBParameter("@netamt", cm.netamt));
                paramCollection.Add(new DBParameter("@payamt", cm.payamt));
                paramCollection.Add(new DBParameter("@P2000", cm.P2000));
                paramCollection.Add(new DBParameter("@P1000", cm.P1000));
                paramCollection.Add(new DBParameter("@P500", cm.P500));
                paramCollection.Add(new DBParameter("@P100", cm.P100));
                paramCollection.Add(new DBParameter("@P50", cm.P50));
                paramCollection.Add(new DBParameter("@P20", cm.P20));
                paramCollection.Add(new DBParameter("@P10", cm.P10));
                paramCollection.Add(new DBParameter("@P5", cm.P5));
                paramCollection.Add(new DBParameter("@P2", cm.P2));
                paramCollection.Add(new DBParameter("@P1", cm.P1));
                paramCollection.Add(new DBParameter("@M2000", cm.M2000));
                paramCollection.Add(new DBParameter("@M1000", cm.M1000));
                paramCollection.Add(new DBParameter("@M500", cm.M500));
                paramCollection.Add(new DBParameter("@M100", cm.M100));
                paramCollection.Add(new DBParameter("@M50", cm.M50));
                paramCollection.Add(new DBParameter("@M20", cm.M20));
                paramCollection.Add(new DBParameter("@M10", cm.M10));
                paramCollection.Add(new DBParameter("@M5", cm.M5));
                paramCollection.Add(new DBParameter("@M2", cm.M2));
                paramCollection.Add(new DBParameter("@M1", cm.M1));
                paramCollection.Add(new DBParameter("@tokanid", cm.TokanId));
                paramCollection.Add(new DBParameter("@createdby", cm.createdby));
                paramCollection.Add(new DBParameter("@RouteID", cm.RouteID));
                paramCollection.Add(new DBParameter("@flag", cm.flag));

                DS = _DBHelper.ExecuteDataSet("sp_addcashtransaction", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                string msg = ex.ToString();

            }
            return DS;
        }

        public int AddAgentCashSales(int trId, string agentId, double agencysales, double paymentsales, string ddId)
        {
            int Result = 0;
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@trId", trId));
                paramCollection.Add(new DBParameter("@agentId", agentId));
                paramCollection.Add(new DBParameter("@agencysales", agencysales));
                paramCollection.Add(new DBParameter("@paymentsales", paymentsales));
                paramCollection.Add(new DBParameter("@DispatchDetailsId", Convert.ToInt32(ddId)));
                Result = _DBHelper.ExecuteNonQuery("sp_AddAgentCashSales", paramCollection, CommandType.StoredProcedure);


            }
            catch (Exception ex) { string msg = ex.ToString(); }
            return Result;
        }
    }
}