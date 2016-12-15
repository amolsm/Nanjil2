using DataAcess;
using Model.Admin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DataAccess.Admin
{
    public class DbDispatch
    {
        DBHelper _DBHelper = new DBHelper();
        DataSet DS;
        public DataSet GetDispatchById(DispatchVM d)
        {
            DS = new DataSet();


            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@Id", d.DispatchId));
                paramCollection.Add(new DBParameter("@Quantity", d.Quantity));
                paramCollection.Add(new DBParameter("@Flag", d.Flag));
                
                DS = _DBHelper.ExecuteDataSet("Disp_EditDispatch", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {

                throw;
            }

            return DS;
        }

        public int updateDispatch(DispatchVM d)
        {
            int result = 0;
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@Id", d.DispatchId));
                paramCollection.Add(new DBParameter("@Quantity", d.Quantity));
                paramCollection.Add(new DBParameter("@Flag", d.Flag));
                result = _DBHelper.ExecuteNonQuery("Disp_EditDispatch", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {


            }
            return result;
        }

    }
}