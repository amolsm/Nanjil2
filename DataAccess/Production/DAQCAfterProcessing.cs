using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.Production;
using DataAcess;
using System.Data;

namespace DataAccess.Production
{
    public class DAQCAfterProcessing
    {
        DBHelper _DBHelper = new DBHelper();
        DataSet DS;

        public int AfterProcessingQcData(MQCAfterProcessing receive)
        {
            int result = 0;
            try
            {
                DBParameterCollection paramcollection = new DBParameterCollection();
                paramcollection.Add(new DBParameter("@RMRId", receive.RMRId));
                paramcollection.Add(new DBParameter("@BatchCode", receive.BatchCode));
                paramcollection.Add(new DBParameter("@APQCDate", receive.APQCDate));
                paramcollection.Add(new DBParameter("@APQCShiftId", receive.APQCShiftId));
                paramcollection.Add(new DBParameter("@ProcessingTime", receive.ProcessingTime));
                paramcollection.Add(new DBParameter("@SiloNo", receive.SiloNo));
                paramcollection.Add(new DBParameter("@ProcessedQty", receive.ProcessedQty));
                paramcollection.Add(new DBParameter("@ProcessTemperature", receive.ProcessTemperature));
                paramcollection.Add(new DBParameter("@OrganoSmell", receive.OrganoSmell));
                paramcollection.Add(new DBParameter("@OrganoTaste", receive.OrganoTaste));
                paramcollection.Add(new DBParameter("@OrganoColor", receive.OrganoColor));
                paramcollection.Add(new DBParameter("@Acidity", receive.Acidity));
                paramcollection.Add(new DBParameter("@PhosStartTime", receive.PhosStartTime));
                paramcollection.Add(new DBParameter("@PhosEndTime", receive.PhosEndTime));
                paramcollection.Add(new DBParameter("@PhosTotalHrs", receive.PhosTotalHrs));
                paramcollection.Add(new DBParameter("@MBRTStartTime", receive.MBRTStartTime));
                paramcollection.Add(new DBParameter("@MBRTEndTime", receive.MBRTEndTime));
                paramcollection.Add(new DBParameter("@MBRTTotalHrs", receive.MBRTTotalHrs));
                paramcollection.Add(new DBParameter("@Fat", receive.Fat));
                paramcollection.Add(new DBParameter("@CLR", receive.CLR));
                paramcollection.Add(new DBParameter("@SNF", receive.SNF));
                paramcollection.Add(new DBParameter("@HomEfficiency", receive.HomEfficiency));
                paramcollection.Add(new DBParameter("@AfterProcessingStatusId", receive.AfterProcessingStatusId));

                paramcollection.Add(new DBParameter("@flag", receive.flag));
                result = _DBHelper.ExecuteNonQuery("sp_Prod_QCAfterProcessingDetails", paramcollection, CommandType.StoredProcedure);
            }
            catch (Exception EX)
            {
                string MSG = EX.ToString();
            }
            return result;
        }

        public DataSet GetQCProcssingDetails(RMRecieve R)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@date", R.RMRDate));
            return _DBHelper.ExecuteDataSet("[sp_Prod_GetQCProcssingDetails]", paramCollection, CommandType.StoredProcedure);
        }
        public DataSet GetQCProcssingDetailsById(int RMRId)
        {
            DataSet DS = new DataSet();
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@RMRId", RMRId));
                DS = _DBHelper.ExecuteDataSet("sp_Prod_GetQCProcssingDetailsById", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception EX)
            {
                string MSG = EX.ToString();
            }

            return DS;
        }
        public DataSet GetExistingBatchCode(string batchcode)
        {
            DataSet DS = new DataSet();
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@batchcode", batchcode));
                DS = _DBHelper.ExecuteDataSet("sp_Prod_GetExistingBatchCode", paramCollection, CommandType.StoredProcedure);

            }
            catch { }
            return DS;
        }
    }
  
}