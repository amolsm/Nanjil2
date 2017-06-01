using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.Production;
using DataAcess;
using System.Data;

namespace DataAccess.Production
{
    public class DAFinishedGoodsRelease
    {
        DBHelper _DBHelper = new DBHelper();
        DataSet DS;

        public int FinishedGoods(MFinishedGoodsRelease receive)
        {
            int result = 0;
            try
            {
                DBParameterCollection paramcollection = new DBParameterCollection();
                paramcollection.Add(new DBParameter("@RMRId", receive.RMRId));
                paramcollection.Add(new DBParameter("@FinishedGoodsBatchCode", receive.FinishedGoodsBatchCode));
                paramcollection.Add(new DBParameter("@FinishedGoodsDate", receive.FinishedGoodsDate));
                paramcollection.Add(new DBParameter("@FinishedGoodsShiftId", receive.FinishedGoodsShiftId));
                paramcollection.Add(new DBParameter("@TypeOfMilk", receive.TypeofMilk));
                paramcollection.Add(new DBParameter("@FinishedGoodsQuantity", receive.FinishedGoodsQuantity));
                paramcollection.Add(new DBParameter("@FinishedGoodsMfgDate", receive.FinishedGoodsMfgDate));
                paramcollection.Add(new DBParameter("@FinishedGoodsStatusId", receive.FinishedGoodsStatusId));
                paramcollection.Add(new DBParameter("@flag", receive.flag));
                result = _DBHelper.ExecuteNonQuery("sp_Prod_FinishedGoodsDetails", paramcollection, CommandType.StoredProcedure);
            }
            catch (Exception EX)
            {
                string MSG = EX.ToString();
            }
            return result;

        }
        public DataSet GetFinishedGoodReleaseDetails(RMRecieve R)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DataAcess.DBParameter("@date", R.RMRDate));
            return (_DBHelper.ExecuteDataSet("sp_Prod_GetFinishedGoodsInformation", paramCollection, CommandType.StoredProcedure));
        }
        public DataSet GetFinishedGoodReleaseDetailsById(int RMRId)
        {
            DataSet DS = new DataSet();
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                //return _DBHelper.ExecuteDataSet("sp_QualityDetails", paramCollection, CommandType.StoredProcedure);
                paramCollection.Add(new DBParameter("@RMRId", RMRId));
                DS = _DBHelper.ExecuteDataSet("sp_Prod_GetFinishedGoodReleaseDetailsById", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception EX)
            {
                string MSG = EX.ToString();
            }
            return DS;
        }
    }
}