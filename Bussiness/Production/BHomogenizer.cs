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
    public class BHomogenizer
    {
        DAHomogenizer dahomo;
        DataSet DS;

        public int homodata(MHomogenizer receive)
        { 
            dahomo=new DAHomogenizer();
            int Result = 0;

            try
            { 

            Result=dahomo.homodata(receive);

            }
            catch (Exception)
            {
                throw;
            }
                return Result;
        }

        public DataSet GetHomogenizerDetailsById(int Id)
        {
            dahomo = new DAHomogenizer();
            return dahomo.GetHomogenizerDetailsById(Id);
        }

        public DataSet GetHomogenizerDetails(RMRecieve R)
        {
            dahomo = new DAHomogenizer();
            return dahomo.GetHomogenizerDetails(R);
        }
    }
}