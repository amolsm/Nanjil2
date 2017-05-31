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
    public class BStandardizationProductsAdded
    {
        DAStandardizationProductsAdded dastdp;
        DataSet DS;

        public int stdpdata(MStandardizationProductsAdded receive)
        {
            dastdp = new DAStandardizationProductsAdded();
            int Result = 0;
            try
            {

                Result = dastdp.stdpdata(receive);

            }
            catch (Exception)
            {
                throw;
            }
            return Result;
        }
        public DataSet GetStandardizationProductsAddedDetailsById(int Id)
        {
            dastdp = new DAStandardizationProductsAdded();
            return dastdp.GetStandardizationProductsAddedDetailsById(Id);
        }
        public DataSet GetStandardizationProductsAddedDetails(RMRecieve R)
        {
            dastdp = new DAStandardizationProductsAdded();
            return dastdp.GetStandardizationProductsAddedDetails(R);
        }
    }
}