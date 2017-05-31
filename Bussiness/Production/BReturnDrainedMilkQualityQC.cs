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
    public class BReturnDrainedMilkQualityQC
    {
        DAReturnDrainedMilkQualityQC dadrainedqc;
        DataSet DS;

        public int Draineddata(MReturnDrainedMilkQualityQC recieve)
        {

            dadrainedqc = new DAReturnDrainedMilkQualityQC();
            int Result = 0;
            try
            {
                Result = dadrainedqc.Draineddata(recieve);

            }
            catch (Exception)
            {

                throw;
            }
            return Result;
        }

        public DataSet GetDrainedMilkQCDetabyId(int RMRId)
        {
            dadrainedqc = new DAReturnDrainedMilkQualityQC();
            return dadrainedqc.GetDrainedMilkQCDetabyId(RMRId);
        }

        public DataSet GetDrainedMilkQCDetails(RMRecieve R)
        {
            dadrainedqc = new DAReturnDrainedMilkQualityQC();

            return dadrainedqc.GetDrainedMilkQCDetails(R);
        }
    }
}