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
                paramCollection.Add(new DBParameter("@EditedBy", d.EditedBy));
                paramCollection.Add(new DBParameter("@Salesman1", d.Salesman1));
                paramCollection.Add(new DBParameter("@Salesman2", d.Salesman2));
                paramCollection.Add(new DBParameter("@Driver1", d.Driver1));
                paramCollection.Add(new DBParameter("@Driver2", d.Driver2));
                paramCollection.Add(new DBParameter("@Vehicle", d.VehicleId));
                paramCollection.Add(new DBParameter("@Trays", d.Trays));
                paramCollection.Add(new DBParameter("@Cartons", d.Cartons));
                paramCollection.Add(new DBParameter("@IceBox", d.IceBox));
                paramCollection.Add(new DBParameter("@Others", d.Others));
                result = _DBHelper.ExecuteNonQuery("Disp_EditDispatch", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {


            }
            return result;
        }

        

    }
}