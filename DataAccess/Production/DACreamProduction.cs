using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.Production;
using DataAcess;
using System.Data;

namespace DataAccess.Production
{
    public class DACreamProduction
    {
        DBHelper _DBHelper = new DBHelper();
        DataSet DS;
        //
        public int creamdata(MCreamProduction receive)
        {
            int result = 0;
            try
            {
                DBParameterCollection paramcollection = new DBParameterCollection();
                paramcollection.Add(new DBParameter("@RMRId", receive.RMRId));
                paramcollection.Add(new DBParameter("@CreamProductionId", receive.CreamProductionId));
                paramcollection.Add(new DBParameter("@CreamProductionDate", receive.CreamProductionDate));
                paramcollection.Add(new DBParameter("@CreamProductionShiftId", receive.CreamProductionShiftId));
                paramcollection.Add(new DBParameter("@BatchCodeCream", receive.BatchCodeCream));
                paramcollection.Add(new DBParameter("@FAT", receive.FAT));
                paramcollection.Add(new DBParameter("@CreamQty", receive.CreamQty));
                paramcollection.Add(new DBParameter("@CreamStatusId", receive.CreamStatusId));
                paramcollection.Add(new DBParameter("@flag", receive.flag));
                result = _DBHelper.ExecuteNonQuery("sp_Prod_CreamProductionDetails", paramcollection, CommandType.StoredProcedure);

            }
            catch (Exception EX)
            {
                string MSG = EX.ToString();
            }
            return result;
        }
        public DataSet GetCreamDetailsbyId(int RMRId)
        {
            DataSet DS = new DataSet();
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@RMRId", RMRId));
                DS = _DBHelper.ExecuteDataSet("sp_Prod_GetCreamProductionDetailsById", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception EX)
            {
                string MSG = EX.ToString();
            }

            return DS;
        }

        public DataSet GetCreamDetails(RMRecieve R)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DataAcess.DBParameter("@date", R.RMRDate));
            return _DBHelper.ExecuteDataSet("sp_Prod_GetCreamDetails", paramCollection, CommandType.StoredProcedure);
        }

    }
}
