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
    public class BFinishedGoodsRelease
    {
        DAFinishedGoodsRelease dafinishgoods;
        DataSet DS;
        public int FinishedGoods(MFinishedGoodsRelease receive)
        {
            dafinishgoods = new DAFinishedGoodsRelease();
            int Result = 0;
            try
            {
                Result = dafinishgoods.FinishedGoods(receive);

            }
            catch (Exception)
            {

                throw;
            }
            return Result;
        }

        public DataSet GetFinishedGoodReleaseDetails(RMRecieve R)
        {
            dafinishgoods = new DAFinishedGoodsRelease();

            return dafinishgoods.GetFinishedGoodReleaseDetails(R);
        }
        public DataSet GetFinishedGoodReleaseDetailsById(int RMRId)
        {
            dafinishgoods = new DAFinishedGoodsRelease();
            return dafinishgoods.GetFinishedGoodReleaseDetailsById(RMRId);
        }
    }

   
}