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
    public class BMilkPackedData
    {
        DAMilkPackedData dapackeddata;
        DataSet DS;

        public int packeddata(MMilkPackedData receive)
        {

            dapackeddata = new DAMilkPackedData();
            int Result = 0;
            try
            {
                Result = dapackeddata.packeddata(receive);

            }
            catch (Exception)
            {

                throw;
            }
            return Result;
        }

        public DataSet GetPackedDetailsbyId(int RMRId)
        {
            dapackeddata = new DAMilkPackedData();
            return dapackeddata.GetPackedDetailsbyId(RMRId);
        }

        public DataSet GetPackedDetails(RMRecieve R)
        {
            dapackeddata = new DAMilkPackedData();
            return dapackeddata.dapackeddata(R);
        }
    }
}