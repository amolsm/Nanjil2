using DataAccess.Production;
using Model.Production;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Bussiness.Production
{

    public class BCurdProcessingQC
    {
        DACurdProcessingQC dacurdprocessqc;
        DataSet DS;

        public int CurdProcessQCData(MCurdProcessingQC receive)
        {
            dacurdprocessqc = new DACurdProcessingQC();
            int Result = 0;
            try
            {
                Result = dacurdprocessqc.CurdProcessQCData(receive);

            }
            catch (Exception)
            {

                throw;
            }
            return Result;
        }

        public DataSet GetCurdProcessQCDetails(RMRecieve R)
        {
            dacurdprocessqc = new DACurdProcessingQC();

            return dacurdprocessqc.GetCurdProcessQCDetails(R);
        }
        public DataSet GetCurdProcessQCDetails(int RMRId)
        {
            dacurdprocessqc = new DACurdProcessingQC();
            return dacurdprocessqc.GetCurdProcessQCDetails(RMRId);
        }
    }
}