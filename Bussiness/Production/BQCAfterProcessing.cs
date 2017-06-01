using System;
using Model.Production;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using DataAccess.Production;
using DataAccess;
using Bussiness;
using Model;
namespace Bussiness.Production
{
    public class BQCAfterProcessing
    {
        DAQCAfterProcessing daqc;
        DataSet DS;

        public int AfterProcessingQcData(MQCAfterProcessing receive)
        {
            daqc = new DAQCAfterProcessing();
            int Result = 0;
            try
            {
                Result = daqc.AfterProcessingQcData(receive);
            }
            catch(Exception)
            {
                throw;
            }
            return Result;
        }

        public DataSet GetQCProcssingDetails(RMRecieve R)
        {
            daqc = new DAQCAfterProcessing();

            return daqc.GetQCProcssingDetails(R);
        }
        public DataSet GetQCProcssingDetailsById(int RMRId)
        {
            daqc = new DAQCAfterProcessing();
            return daqc.GetQCProcssingDetailsById(RMRId);
        }

        public DataSet GetExistingBatchCode(string batchcode)
        {
            daqc = new DAQCAfterProcessing();
            return daqc.GetExistingBatchCode(batchcode);
        }
    }
}