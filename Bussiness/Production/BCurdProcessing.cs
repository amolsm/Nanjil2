using DataAccess.Production;
using Model.Production;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Bussiness.Production
{
    public class BCurdProcessing
    {
        DACurdProcessing dacurdprocess;
        DataSet DS;

        public int CurdProcessData(MCurdProcessing receive)
        {
            dacurdprocess = new DACurdProcessing();
            int Result = 0;
            try
            {
                Result = dacurdprocess.CurdProcessData(receive);

            }
            catch(Exception)
            {

                throw;
            }
            return Result;
        }

        public DataSet GetCurdProcessDetails(RMRecieve R)
        {
            dacurdprocess = new DACurdProcessing();

            return dacurdprocess.GetCurdProcessDetails(R);
        }
        public DataSet GetCurdProcessDetails(int RMRId)
        {
            dacurdprocess = new DACurdProcessing();
            return dacurdprocess.GetCurdProcessDetails(RMRId);
        }
    }

   
}