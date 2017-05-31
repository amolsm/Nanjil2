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

    public class BQuality
    {
        DAQuality daquality;
        DataSet DS;
        public int QualityData(MQuality recieve)
        {

            daquality = new DAQuality();
            int Result = 0;
            try
            {
                Result = daquality.QualityData(recieve);

            }
            catch (Exception)
            {

                throw;
            }
            return Result;
        }

        public DataSet GetQualityDetails(RMRecieve R)
        {
            daquality = new DAQuality();

            return daquality.GetQualityDetails(R);
        }
        public DataSet GetQualityDetailsById(int RMRId)
             {
              daquality = new DAQuality();
              return daquality.GetQualityDetailsById(RMRId);
           }

       
        //public DataSet GetQualityDetabyId(int Id)
        //{
        //    bquality = new BQuality();
        //    return bquality.GetQualityDetabyId(Id);
        //}

        //public DataSet GetQltyDetails()
        //{
        //    bquality = new BQuality();

        //    return bquality.GetQltyDetails();
        //}

        //public DataSet GetQualityDetails()
        //{
        //    bquality = new BQuality();

        //    return bquality.GetQualityDetails();
        //}
    }
}