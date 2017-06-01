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
    public class BPasteurizationQC
    {
        DAPasteurizationQC dapasteurization;
        DataSet DS;
        public int PasteurizationData(MPasteurizationQC recieve)
        {

            dapasteurization = new DAPasteurizationQC();
            int Result = 0;
            try
            {
                Result = dapasteurization.PasteurizationData(recieve);

            }
            catch (Exception)
            {

                throw;
            }
            return Result;
        }

        public DataSet GetPasteurizationDetabyId(int RMRId)
        {
            dapasteurization = new DAPasteurizationQC();
            return dapasteurization.GetPasteurizationDetabyId(RMRId);
        }



        public DataSet GetPasteurizationDetails(RMRecieve R)
        {
            dapasteurization = new DAPasteurizationQC();

            return dapasteurization.GetPasteurizationDetails(R);
        }


    }
}