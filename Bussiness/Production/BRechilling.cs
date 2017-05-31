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
    public class BRechilling
    {
        DARechilling darechilling;
        DataSet DS;

        public int RechillingData(MRechilling receive)
        {

            darechilling = new DARechilling();
            int Result = 0;
            try
            {
                Result = darechilling.RechillingData(receive);

            }
            catch (Exception)
            {

                throw;
            }
            return Result;
        }

        public DataSet GetRechillingDetails(RMRecieve R)
        {
            darechilling = new DARechilling();

            return darechilling.GetRechillingDetails(R);
        }
        public DataSet GetRechillingDataById(int RMRId) 
        {
            darechilling = new DARechilling();
            return darechilling.GetRechillingDataById(RMRId);
        }

    }
}