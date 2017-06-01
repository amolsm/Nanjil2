using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.Production;
using DataAcess;
using System.Data;

namespace DataAccess.Production
{
    public class DAReturnDrainedMilkQualityQC
    {
        DBHelper _DBHelper = new DBHelper();
        DataSet DS;

        public int Draineddata(MReturnDrainedMilkQualityQC receive)
        {
            int result = 0;
            try
            {
                DBParameterCollection paramcollection = new DBParameterCollection();

                paramcollection.Add(new DBParameter("@ReturnDrainedMilkQualityQCId", receive.ReturnDrainedMilkQualityQCId));
                paramcollection.Add(new DBParameter("@RMRId", receive.RMRId));
                paramcollection.Add(new DBParameter("@ReturnDrainedMilkQCDate", receive.ReturnDrainedMilkQCDate));
                paramcollection.Add(new DBParameter("@ReturnDrainedMilkQCShiftId", receive.ReturnDrainedMilkQCShiftId));
                paramcollection.Add(new DBParameter("@Source", receive.Source));
                paramcollection.Add(new DBParameter("@Quantity", receive.Quantity));
                paramcollection.Add(new DBParameter("@MBRT", receive.MBRT));
                paramcollection.Add(new DBParameter("@TEMP", receive.TEMP));
                paramcollection.Add(new DBParameter("@Remarks", receive.Remarks));
                paramcollection.Add(new DBParameter("@ReturnDrainedMilkQcStatusId", receive.ReturnDrainedMilkQcStatusId));
                paramcollection.Add(new DBParameter("@flag", receive.flag));
                result = _DBHelper.ExecuteNonQuery("sp_Prod_ReturnDrainedMilkQualityQCDetails", paramcollection, CommandType.StoredProcedure);

            }
            catch (Exception EX)
            {
                string MSG = EX.ToString();
            }
            return result;
        }

        public DataSet GetDrainedMilkQCDetabyId(int RMRId)
        {
            DataSet DS = new DataSet();
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@RMRId", RMRId));
                DS = _DBHelper.ExecuteDataSet("sp_Prod_GetReturnDrainedMilkQCDetailsById", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception EX)
            {
                string MSG = EX.ToString();
            }
            return DS;
        }

        public DataSet GetDrainedMilkQCDetails(RMRecieve R)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@date", R.RMRDate));
            return _DBHelper.ExecuteDataSet("sp_Prod_GetReturnDrainedMilkQCDetails", paramCollection, CommandType.StoredProcedure);
        }
    }
}


