using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.Production;
using DataAcess;
using System.Data;

namespace DataAccess.Production
{
    public class DAHomogenizer
    {
        DBHelper _DBHelper = new DBHelper();
        DataSet DS;

        public int homodata(MHomogenizer receive)
        {
            int result = 0;
            try
            {
                DBParameterCollection paramcollection = new DBParameterCollection();
                //paramcollection.Add(new DBParameter("@HomogenizerId", receive.HomogenizerId));
                paramcollection.Add(new DBParameter("@RMRId", receive.RMRId));
                paramcollection.Add(new DBParameter("@HomogenizerDate", receive.HomogenizerDate));
                paramcollection.Add(new DBParameter("@HomogenizerShiftId", receive.HomogenizerShiftId));
                paramcollection.Add(new DBParameter("@MachineStartTime", receive.MachineStartTime));
                paramcollection.Add(new DBParameter("@MachineEndTime", receive.MachineEndTime));
                paramcollection.Add(new DBParameter("@PressureFirstStage", receive.PressureFirstStage));
                paramcollection.Add(new DBParameter("@PressureSecondStage", receive.PressureSecondStage));
                paramcollection.Add(new DBParameter("@OilleakageId", receive.OilleakageId));
                paramcollection.Add(new DBParameter("@HomogenizedQty", receive.HomogenizedQty));
                paramcollection.Add(new DBParameter("@Technician", receive.Technician));
                paramcollection.Add(new DBParameter("@Homogenized", receive.Homogenized));
                paramcollection.Add(new DBParameter("@Remarks", receive.Remarks));
                paramcollection.Add(new DBParameter("@HomogenizerStatusId", receive.HomogenizerStatusId));

                paramcollection.Add(new DBParameter("@flag", receive.flag));
                result = _DBHelper.ExecuteNonQuery("sp_prod_HomogenizerDetails", paramcollection, CommandType.StoredProcedure);
            }
            catch (Exception EX)
            {
                String MSG = EX.ToString();
            }
            return result;
        }

        public DataSet GetHomogenizerDetailsById(int RMRId)
        {
            DataSet DS = new DataSet();
            try
            {
                DBParameterCollection paramcollection = new DBParameterCollection();
                paramcollection.Add(new DBParameter("@RMRId", RMRId));
                DS = _DBHelper.ExecuteDataSet("sp_Prod_GetHomogenizerDetailsById", paramcollection, CommandType.StoredProcedure);
            }
            catch (Exception EX)
            {
                string MSG = EX.ToString();
            }
            return DS;
        }

        public DataSet GetHomogenizerDetails(RMRecieve R)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DataAcess.DBParameter("@date", R.RMRDate));
            return _DBHelper.ExecuteDataSet("sp_Prod_GetHomogenizerDetails", paramCollection, CommandType.StoredProcedure);
        }
    }
}