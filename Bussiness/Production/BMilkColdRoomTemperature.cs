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
    public class BMilkColdRoomTemperature
    {
        DAMilkColdRoomTemperature dacold;
        DataSet DS;

        public int colddata(MMilkColdRoomTemperature receive)
        { 
        dacold=new DAMilkColdRoomTemperature();
            int Result=0;
            try
            {
                Result = dacold.colddata(receive);
            }
            catch (Exception)
            {
                throw;
            }
                return Result;
        }

        public DataSet GetMilkColdRoomTemperatureDetailsById(int Id)
        {
            dacold = new DAMilkColdRoomTemperature();
            return dacold.GetMilkColdRoomTemperatureDetailsById(Id);
        }

        public DataSet GetMilkColdRoomTemperatureDetails(RMRecieve R)
        {
            dacold = new DAMilkColdRoomTemperature();
            return dacold.GetMilkColdRoomTemperatureDetails(R);
        }
    }
}