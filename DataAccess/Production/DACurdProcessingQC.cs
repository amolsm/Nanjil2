using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.Production;
using DataAcess;
using System.Data;


namespace DataAccess.Production
{
    public class DACurdProcessingQC
    {
        DBHelper _DBHelper = new DBHelper();
        DataSet DS;

        public int CurdProcessQCData(MCurdProcessingQC recieve)
        {
            int result = 0;
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@CurdQCId", recieve.CurdQCId));
                paramCollection.Add(new DBParameter("@CurdId", recieve.CurdId));
                paramCollection.Add(new DBParameter("@RMRId", recieve.RMRId));
                paramCollection.Add(new DBParameter("@BatchNo", recieve.BatchNo));
                paramCollection.Add(new DBParameter("@CurdQCDate", recieve.CurdQCDate));
                paramCollection.Add(new DBParameter("@CurdQCShiftId", recieve.CurdQCShiftId));
                paramCollection.Add(new DBParameter("@CurdQCProcessTime", recieve.CurdQCProcessTime));
                paramCollection.Add(new DBParameter("@CurdQCSiloNo", recieve.CurdQCSiloNo));
                paramCollection.Add(new DBParameter("@CurdQCProcessQty", recieve.CurdQCProcessQty));
                paramCollection.Add(new DBParameter("@CurdQCTemp", recieve.CurdQCTemp));
                paramCollection.Add(new DBParameter("@CurdQCFat", recieve.CurdQCFat));
                paramCollection.Add(new DBParameter("@CurdQCCLR", recieve.CurdQCCLR));
                paramCollection.Add(new DBParameter("@CurdQCSNF", recieve.CurdQCSNF));
                paramCollection.Add(new DBParameter("@CurdQCAcidity", recieve.CurdQCAcidity));
                paramCollection.Add(new DBParameter("@HomEfficiency", recieve.HomEfficiency));
                paramCollection.Add(new DBParameter("@CurdQCTaste", recieve.CurdQCTaste));
                paramCollection.Add(new DBParameter("@CurdQCSmell", recieve.CurdQCSmell));
                paramCollection.Add(new DBParameter("@CurdQCColor", recieve.CurdQCColor));
                paramCollection.Add(new DBParameter("@CurdQCMBRTStartTime", recieve.CurdQCMBRTStartTime));
                paramCollection.Add(new DBParameter("@CurdQCMBRTEndTime", recieve.CurdQCMBRTEndTime));
                paramCollection.Add(new DBParameter("@CurdQCMBRTTotalHours", recieve.CurdQCMBRTTotalHours));
                paramCollection.Add(new DBParameter("@PhosphataseStartTime", recieve.PhosphataseStartTime));
                paramCollection.Add(new DBParameter("@PhosphataseEndTime", recieve.PhosphataseEndTime));
                paramCollection.Add(new DBParameter("@PhosphataseTotalHours", recieve.PhosphataseTotalHours));
                paramCollection.Add(new DBParameter("@CurdQCStatusId", recieve.CurdQCStatusId));
                paramCollection.Add(new DBParameter("@flag", recieve.flag));
                result = _DBHelper.ExecuteNonQuery("sp_Prod_CurdProcessingQC", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception EX)
            {
                string MSG = EX.ToString();
            }

            return result;

        }
        public DataSet GetCurdProcessQCDetails(RMRecieve R)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@date", R.RMRDate));
            return _DBHelper.ExecuteDataSet("sp_Prod_GetCurdProcessQCInfo", paramCollection, CommandType.StoredProcedure);
        }

        public DataSet GetCurdProcessQCDetails(int RMRId)
        {
            DataSet DS = new DataSet();
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@RMRId", RMRId));
                DS = _DBHelper.ExecuteDataSet("[sp_Prod_GetCurdProcessQCDetailsbyID ]", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception EX)
            {
                string MSG = EX.ToString();
            }
            return DS;
        }
    }
}