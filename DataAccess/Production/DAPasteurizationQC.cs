using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.Production;
using DataAcess;
using System.Data;

namespace DataAccess.Production
{
    public class DAPasteurizationQC
    {
        DBHelper _DBHelper = new DBHelper();
        DataSet DS;
        public int PasteurizationData(MPasteurizationQC receive)
        {
            int result = 0;
            try
            {
                DBParameterCollection paramcollection = new DBParameterCollection();
               
                paramcollection.Add(new DBParameter("@PastQCId", receive.PastQCId));
                paramcollection.Add(new DBParameter("@PastProcessId", receive.PastProcessId));
                paramcollection.Add(new DBParameter("@StdId", receive.StdId));
                paramcollection.Add(new DBParameter("@QualityId", receive.QualityId));
                paramcollection.Add(new DBParameter("@RMRId", receive.RMRId));
                paramcollection.Add(new DBParameter("@PastQCDate", receive.PastQCDate));
                paramcollection.Add(new DBParameter("@PastQCShiftId", receive.PastQCShiftId));
                paramcollection.Add(new DBParameter("@TemperatureHeat", receive.TemperatureHeat));
                paramcollection.Add(new DBParameter("@TempChill", receive.TempChill));
                paramcollection.Add(new DBParameter("@DoneBy", receive.DoneBy));
                paramcollection.Add(new DBParameter("@Remarks", receive.Remarks));
                paramcollection.Add(new DBParameter("@QCStatus", receive.QCStatus));
                paramcollection.Add(new DBParameter("@flag", receive.flag));
                result = _DBHelper.ExecuteNonQuery("sp_Prod_PasteurizationQCDetails", paramcollection, CommandType.StoredProcedure);

            }
            catch (Exception EX)
            {
                string MSG = EX.ToString();
            }
            return result;
        }

        public DataSet GetPasteurizationDetabyId(int RMRId)
        {
            DataSet DS = new DataSet();
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@RMRId", RMRId));
                DS = _DBHelper.ExecuteDataSet("sp_Prod_GetPasteurizationQCDetailsByID", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception EX)                        
            {
                string MSG = EX.ToString();
            }
            return DS;
        }

        public DataSet GetPasteurizationDetails(RMRecieve R)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DataAcess.DBParameter("@date", R.RMRDate));
            return _DBHelper.ExecuteDataSet("sp_Prod_GetPasteurizationQCDetails", paramCollection, CommandType.StoredProcedure);
        }
    }
}