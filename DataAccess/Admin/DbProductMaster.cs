using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAcess;
using Model.Admin;
using System.Data;

namespace DataAccess.Admin
{
    public class DbProductMaster
    {
        DBHelper _DBHelper = new DBHelper();
        DataSet DS;

        public int DML(productMaster pm)
        {
            int result = 0;
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@Id", pm.ProductMasterId));
                paramCollection.Add(new DBParameter("@name", pm.Name));
                
                paramCollection.Add(new DBParameter("@Status", pm.IsActive));
                paramCollection.Add(new DBParameter("@Flag", pm.Flag));
                result = _DBHelper.ExecuteNonQuery("SpShiftDML", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {

                return -999;
            }
            return result;
        }

        public DataSet GetShiftList(Shifts shift)
        {
            DS = new DataSet();


            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@Id", shift.ShiftId));
                paramCollection.Add(new DBParameter("@name", shift.ShiftName));
                paramCollection.Add(new DBParameter("@Desc", shift.Description));
                paramCollection.Add(new DBParameter("@StartTime", shift.StartTime));
                paramCollection.Add(new DBParameter("@EndTime", shift.EndTime));
                paramCollection.Add(new DBParameter("@Status", shift.Status));
                paramCollection.Add(new DBParameter("@Flag", shift.Flag));
                DS = _DBHelper.ExecuteDataSet("SpShiftDML", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {

                throw;
            }

            return DS;
        }
    }
}