using DataAcess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DataAccess
{
    public class DBOrderDemandStatement
    {
        DBHelper _DBHelper = new DBHelper();

        public DataSet GetRoutewiseOrderDemandReport(int routeid, int flag)
        {
            DataSet DS = new DataSet();
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@RouteID", routeid));
                paramCollection.Add(new DBParameter("@flag", flag));
                DS = _DBHelper.ExecuteDataSet("sp_GetRoutewiseOrderDemandStatement", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {


            }
            return DS;
        }
    }
}