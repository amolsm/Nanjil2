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
    public class BTraceabilityMilkQC
    {
        DATraceabilityMilkQC datracqc;
        DataSet DS;

        public int tracqcdata(MTraceabilityMilkQC receive)
        {
            datracqc = new DATraceabilityMilkQC();
            int Result = 0;
            try
            {

                Result = datracqc.tracqcdata(receive);

            }
            catch (Exception)
            {
                throw;
            }
            return Result;
    }

        public DataSet GetTraceabilityQCDetailsById(int Id)
        {
            datracqc = new DATraceabilityMilkQC();
            return datracqc.GetTraceabilityQCDetailsById(Id);
        }
        public DataSet GetTraceabilityDetails(RMRecieve R)
        {
            datracqc = new DATraceabilityMilkQC();
            return datracqc.GetTraceabilityDetails(R);
        }
    }
}