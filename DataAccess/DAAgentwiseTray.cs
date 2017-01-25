using DataAcess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DataAccess
{
    public class DAAgentwiseTray
    {
        DBHelper _DBHelper = new DBHelper();
        DataSet DS;

        public DataSet GetAgentwiseTrayDetails(int DispatchId, string DDate)
        {
            DBParameterCollection paramcollection = new DBParameterCollection();

            paramcollection.Add(new DBParameter("@DispatchId", DispatchId));
            paramcollection.Add(new DBParameter("@DisDate", DDate));
            return _DBHelper.ExecuteDataSet("sp_AgentwiseTrayDetails1", paramcollection, CommandType.StoredProcedure);
        }

        public int AddAgentwiseTrayDetails(int dispatchid, int AgentId, int EmpId, int traydispatched, int returntrays, int salesmanid, int routeid, string date, int excesstrays, int shorttrays)
        {
            int result = 0;
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@dispatchid", dispatchid));
                paramCollection.Add(new DBParameter("@date", date));
                paramCollection.Add(new DBParameter("@traydispatched", traydispatched));
                paramCollection.Add(new DBParameter("@returntrays", returntrays));
                paramCollection.Add(new DBParameter("@excesstrays", excesstrays));
                paramCollection.Add(new DBParameter("@shorttrays", shorttrays));
                paramCollection.Add(new DBParameter("@agentid", AgentId));
                paramCollection.Add(new DBParameter("@Empid", EmpId));
                paramCollection.Add(new DBParameter("@salesmanid", salesmanid));
                paramCollection.Add(new DBParameter("@routeid", routeid));
                //paramCollection.Add(new DBParameter("@flag", flag));

                result = _DBHelper.ExecuteNonQuery("Sp_AddAgentwiseTrayDetails", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                string msg = ex.ToString();
            }

            return result;
        }

        public DataSet GetAgentwiseReturnTraysReport(string startdate, string enddate, int agentid, int flag)
        {
            DataSet DS = new DataSet();
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@AgentwiseDispatchBeginDate", startdate));
                paramCollection.Add(new DBParameter("@AgentwiseDispatchEndDate", enddate));
                paramCollection.Add(new DBParameter("@AgentID", agentid));
                paramCollection.Add(new DBParameter("@flag", flag));
                DS = _DBHelper.ExecuteDataSet("sp_GetAgentwiseReturnTraysReport", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                string msg = ex.ToString();

            }
            return DS;
        }
    }
}