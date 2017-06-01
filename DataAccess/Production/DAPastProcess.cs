using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.Production;
using DataAcess;
using System.Data;


namespace DataAccess.Production
{
    public class DAPastProcess
    {
        DBHelper _DBHelper = new DBHelper();
        DataSet DS;
        //
        public int pastdata(MPastProcess receive)
        {
            int result = 0;
            try
            {
                DBParameterCollection paramcollection = new DBParameterCollection();
                paramcollection.Add(new DBParameter("@RMRId", receive.RMRId));
                paramcollection.Add(new DBParameter("@StdId", receive.StdId));
                paramcollection.Add(new DBParameter("@pastProcessId", receive.pastProcessId));
                paramcollection.Add(new DBParameter("@PastProcessDate", receive.PastProcessDate));
                paramcollection.Add(new DBParameter("@PastShiftId", receive.PastShiftId));
                paramcollection.Add(new DBParameter("@IBTTemperature", receive.IBTTemperature));
                paramcollection.Add(new DBParameter("@PastStartTime", receive.PastStartTime));
                paramcollection.Add(new DBParameter("@PastTempHeat1", receive.PastTempHeat1));
                paramcollection.Add(new DBParameter("@Cool1", receive.Cool1));
                paramcollection.Add(new DBParameter("@PastTempHeat2", receive.PastTempHeat2));
                paramcollection.Add(new DBParameter("@Cool2", receive.Cool2));
                paramcollection.Add(new DBParameter("@PastTempHeat3", receive.PastTempHeat3));
                paramcollection.Add(new DBParameter("@Cool3", receive.Cool3));
                paramcollection.Add(new DBParameter("@PastTempHeat4", receive.PastTempHeat4));
                paramcollection.Add(new DBParameter("@Cool4", receive.Cool4));
                paramcollection.Add(new DBParameter("@PastTempHeat5", receive.PastTempHeat5));
                paramcollection.Add(new DBParameter("@Cool5", receive.Cool5));
                paramcollection.Add(new DBParameter("@MilkClosingTime", receive.MilkClosingTime));
                paramcollection.Add(new DBParameter("@DoneBy", receive.DoneBy));
                paramcollection.Add(new DataAcess.DBParameter("@PastProcessStatusId", receive.pastProcessStatusId));
                paramcollection.Add(new DBParameter("@flag", receive.flag));
                result = _DBHelper.ExecuteNonQuery("sp_Prod_PasteurizationProcessDetails", paramcollection, CommandType.StoredProcedure);

            }
            catch (Exception EX)
            {
                string MSG = EX.ToString();
            }
            return result;
        }

        public DataSet GetPastDetailsbyId(int RMRId)
        {
            DataSet DS = new DataSet();
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@RMRId", RMRId));
                DS = _DBHelper.ExecuteDataSet("sp_Prod_GetPasteurizationDetailsbyID", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception EX)
            {
                string MSG = EX.ToString();
            }

            return DS;
        }


        public DataSet GetPastDetails(RMRecieve R)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@date", R.RMRDate));
            return _DBHelper.ExecuteDataSet("sp_Prod_GetPasteurizationDetails", paramCollection, CommandType.StoredProcedure);
        }
    }
}