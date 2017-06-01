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
    public class BPastProcess
    {
        DAPastProcess dapast;
        DataSet Ds;
        
        //

        public int pastdata(MPastProcess receive)
        {

            dapast = new DAPastProcess();
            int Result = 0;
            try
            {
                Result = dapast.pastdata(receive);

            }
            catch (Exception)
            {

                throw;
            }
            return Result;
        }

             public DataSet GetPastDetailsbyId(int RMRId)
        {
            dapast = new DAPastProcess();
            return dapast.GetPastDetailsbyId(RMRId);
        }

        public DataSet GetPastDetails(RMRecieve R)
        {
            dapast = new DAPastProcess();

            return dapast.GetPastDetails(R);
        }
    }
}