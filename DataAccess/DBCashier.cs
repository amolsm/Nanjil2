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
                paramCollection.Add(new DBParameter("@Salesmanid", cm.Salesmanid));
                paramCollection.Add(new DBParameter("@trDate", cm.trDate));
                paramCollection.Add(new DBParameter("@netamt", cm.netamt));
                paramCollection.Add(new DBParameter("@payamt", cm.payamt));
                paramCollection.Add(new DBParameter("@rs2000", cm.rs2000));
                paramCollection.Add(new DBParameter("@rs1000", cm.rs1000));
                paramCollection.Add(new DBParameter("@rs500", cm.rs500));
                paramCollection.Add(new DBParameter("@rs100", cm.rs100));
                paramCollection.Add(new DBParameter("@rs50", cm.rs50));
                paramCollection.Add(new DBParameter("@rs20", cm.rs20));
                paramCollection.Add(new DBParameter("@rs10", cm.rs10));
                paramCollection.Add(new DBParameter("@rscoins", cm.rscoins));
                paramCollection.Add(new DBParameter("@TokanId", cm.TokanId));
                paramCollection.Add(new DBParameter("@createdby", cm.createdby));
                paramCollection.Add(new DBParameter("@flag", cm.flag));

                DS = _DBHelper.ExecuteDataSet("sp_addcashtransaction", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                string msg = ex.ToString();

            }
            return DS;
        }

        public int AddAgentCashSales(int trId, string agentId, double agencysales, double paymentsales)
        {
            int Result = 0;
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@trId", trId));
                paramCollection.Add(new DBParameter("@agentId", agentId));
                paramCollection.Add(new DBParameter("@agencysales", agencysales));
                paramCollection.Add(new DBParameter("@paymentsales", paymentsales));
                Result = _DBHelper.ExecuteNonQuery("sp_AddAgentCashSales", paramCollection, CommandType.StoredProcedure);


            }
            catch (Exception ex) { string msg = ex.ToString(); }
            return Result;
        }
    }
}