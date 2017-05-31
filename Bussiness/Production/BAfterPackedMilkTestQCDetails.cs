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
    public class BAfterPackedMilkTestQCDetails
    {
        DAAfterPackedMilkTestQCDetails damilkqc;
       // DataSet DS;

        public int milkqc(MAfterPackedMilkTestQCDetails receive)
        {
            damilkqc = new DAAfterPackedMilkTestQCDetails();
            int Result = 0;
            try
            {

                Result = damilkqc.milkqc(receive);

            }
            catch (Exception)
            {
                throw;
            }
            return Result;
        }

        public DataSet GetMilkQCDetailsById(int Id)
        {
            damilkqc = new DAAfterPackedMilkTestQCDetails();
            return damilkqc.GetMilkQCDetailsById(Id);
        }
        public DataSet GetMilkQCDetails(RMRecieve R)
        {
            damilkqc = new DAAfterPackedMilkTestQCDetails();
            return damilkqc.GetMilkQCDetails(R);
        }
    }
}