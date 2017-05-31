using DataAccess.Production;
using Model.Production;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Bussiness.Production
{
    public class BStandardization
    {
        DAStandardization dastd;
        DataSet Ds;

        public int StandardizationData(MStandardization recieve)
        {

            dastd = new DAStandardization();
            int Result = 0;
            try
            {
                Result = dastd.StdData(recieve);

            }
            catch (Exception)
            {

                throw;
            }
            return Result;
        }
        public DataSet GetStandardizationDetailsbyId(int RMRId)
        {
            dastd = new DAStandardization();
            return dastd.GetStandardizationDetailsbyID(RMRId);
        }

        public DataSet GetStandardizationDetails(RMRecieve R)
        {
            dastd = new DAStandardization();

            return dastd.GetStandardizationDetails(R);
        }
    }
}