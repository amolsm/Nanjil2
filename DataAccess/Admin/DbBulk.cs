using DataAcess;
using Model.Admin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DataAccess.Admin
{
    public class DbBulk
    {
        DBHelper _DBHelper = new DBHelper();
        DataSet DS;
        public DataSet GetPreviousOrders(Bulk b)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@RouteID ", b.RouteId));
            paramCollection.Add(new DBParameter("@OrderDate ", b.OrderDate));
            paramCollection.Add(new DBParameter("@TypeId ", b.Type));
            return _DBHelper.ExecuteDataSet("GetPreviousDayOrders", paramCollection, CommandType.StoredProcedure);
        }

        public int SubmitBulkOrders(Bulk b)
        {
            int result = 0;
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                
                paramCollection.Add(new DBParameter("@Tokan", b.Tokan));
                paramCollection.Add(new DBParameter("@UserId", b.UserId));
                paramCollection.Add(new DBParameter("@Flag", b.Flag));
                result = _DBHelper.ExecuteNonQuery("SubmitBulkOrders", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {


            }
            return result;
        }
    }
}