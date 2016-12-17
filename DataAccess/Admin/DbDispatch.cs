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
        public DataSet GetDispatchById(Model.Admin.DispatchVM disp)
        {
            DS = new DataSet();


            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@Id", disp.DispatchId));
                paramCollection.Add(new DBParameter("@Quantity", disp.Quantity));
                paramCollection.Add(new DBParameter("@Flag", disp.Flag));
                
                DS = _DBHelper.ExecuteDataSet("Disp_EditDispatch", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {

                throw;
            }

            return DS;
        }

        public int updateDispatch(Model.Admin.DispatchVM disp)
        {
            int result = 0;
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@Id", disp.DispatchId));
                paramCollection.Add(new DBParameter("@Quantity", disp.Quantity));
                paramCollection.Add(new DBParameter("@Flag", disp.Flag));
                paramCollection.Add(new DBParameter("@EditedBy", disp.EditedBy));
                paramCollection.Add(new DBParameter("@Salesman1", disp.Salesman1));
                paramCollection.Add(new DBParameter("@Salesman2", disp.Salesman2));
                paramCollection.Add(new DBParameter("@Driver1", disp.Driver1));
                paramCollection.Add(new DBParameter("@Driver2", disp.Driver2));
                paramCollection.Add(new DBParameter("@Vehicle", disp.VehicleId));
                paramCollection.Add(new DBParameter("@Trays", disp.Trays));
                paramCollection.Add(new DBParameter("@Cartons", disp.Cartons));
                paramCollection.Add(new DBParameter("@IceBox", disp.IceBox));
                paramCollection.Add(new DBParameter("@Others", disp.Others));
                result = _DBHelper.ExecuteNonQuery("Disp_EditDispatch", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {


            }
            return result;
        }

        

    }
}