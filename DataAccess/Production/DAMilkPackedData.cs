using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.Production;
using DataAcess;
using System.Data;

namespace DataAccess.Production
{
    public class DAMilkPackedData
    {
        DBHelper _DBHelper = new DBHelper();
        DataSet DS;
        //
        public int packeddata(MMilkPackedData receive)
        {
            int result = 0;
            try
            {
                DBParameterCollection paramcollection = new DBParameterCollection();
                paramcollection.Add(new DBParameter("@PackedDataId", receive.PackedDataId));
                paramcollection.Add(new DBParameter("@RMRId", receive.RMRId));
                paramcollection.Add(new DBParameter("@ShiftId", receive.ShiftId));
                paramcollection.Add(new DBParameter("@PackedDate", receive.PackedDate));
                paramcollection.Add(new DBParameter("@PackingOperatorName", receive.PackingOperatorName));
                paramcollection.Add(new DBParameter("@ReceivedBy", receive.ReceivedBy));
                paramcollection.Add(new DBParameter("@TypeOfMilk", receive.TypeOfMilk));
                paramcollection.Add(new DBParameter("@QuantityIn1000ML", receive.QuantityIn1000ML));
                paramcollection.Add(new DBParameter("@QuantityIn500ML", receive.QuantityIn500ML));
                paramcollection.Add(new DBParameter("@QuantityIn450ML", receive.QuantityIn450ML));
                paramcollection.Add(new DBParameter("@QuantityIn250ML", receive.QuantityIn250ML));
                paramcollection.Add(new DBParameter("@QuantityIn200ML", receive.QuantityIn200ML));
                paramcollection.Add(new DBParameter("@TotalQtyOfMilk", receive.TotalQtyOfMilk));
                paramcollection.Add(new DBParameter("@ColdRoomNo", receive.ColdRoomNo));
                paramcollection.Add(new DBParameter("@PackingDetailStatusId", receive.PackingDetailStatusId));
                paramcollection.Add(new DBParameter("@flag", receive.flag));
                result = _DBHelper.ExecuteNonQuery("sp_Prod_MilkPackedDataDetails", paramcollection, CommandType.StoredProcedure);

            }
            catch (Exception EX)
            {
                string MSG = EX.ToString();
            }
            return result;
        }
        public DataSet GetPackedDetailsbyId(int RMRId)
        {
            DataSet DS = new DataSet();
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@RMRId", RMRId));
                DS = _DBHelper.ExecuteDataSet("sp_Prod_MilkPackedDataDetailsById", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception EX)
            {
                string MSG = EX.ToString();
            }

            return DS;
        }

        public DataSet dapackeddata(RMRecieve R)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DataAcess.DBParameter("@date", R.RMRDate));
            return _DBHelper.ExecuteDataSet("sp_Prod_GetMilkPackedDetails", paramCollection, CommandType.StoredProcedure);
        }

    }
}