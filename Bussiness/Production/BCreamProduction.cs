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
    public class BCreamProduction
    {
        DACreamProduction dacreamprod;
        DataSet DS;

        public int creamdata(MCreamProduction receive)
        {

            dacreamprod = new DACreamProduction();
            int Result = 0;
            try
            {
                Result = dacreamprod.creamdata(receive);

            }
            catch (Exception)
            {

                throw;
            }
            return Result;
        }

        public DataSet GetCreamDetailsbyId(int Id)
        {
            dacreamprod = new DACreamProduction();
            return dacreamprod.GetCreamDetailsbyId(Id);
        }

        public DataSet GetCreamDetails(RMRecieve R)
        {
            dacreamprod = new DACreamProduction();
            return dacreamprod.GetCreamDetails(R);
        }
    }
}