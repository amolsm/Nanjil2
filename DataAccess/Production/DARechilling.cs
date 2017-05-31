using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.Production;
using DataAcess;
using System.Data;
using DataAccess.Production;


namespace DataAccess.Production
{
    public class DARechilling
    {
        DBHelper _DBHelper = new DBHelper();
        DataSet DS;

        public int RechillingData(MRechilling receive)
        {
            int result = 0;
            try
            {
                DBParameterCollection paramcollection = new DBParameterCollection();
                paramcollection.Add(new DBParameter("@RMRId", receive.RMRId));
                paramcollection.Add(new DBParameter("@QualityId", receive.QualityId));
                paramcollection.Add(new DBParameter("@BatchNo", receive.BatchNo));
                paramcollection.Add(new DBParameter("@ShiftId", receive.ShiftId ));
                paramcollection.Add(new DBParameter("@Date", receive.Date));
                paramcollection.Add(new DBParameter("@SiloId", receive.SiloNo));
                paramcollection.Add(new DBParameter("@TypeOfMilk", receive.TypeOfMilk));
                paramcollection.Add(new DBParameter("@Qty", receive.Quantity));
                paramcollection.Add(new DBParameter("@IBTInTemperature", receive.IBTInTemperature));
                paramcollection.Add(new DBParameter("@IBTOutTemperature", receive.IBTOutTemperature));
                paramcollection.Add(new DBParameter("@MilkInTemperature", receive.MilkInTemperature));
                paramcollection.Add(new DBParameter("@MilkOutTemperature", receive.MilkOutTemperature));
                paramcollection.Add(new DBParameter("@RechilledBy", receive.RechilledBy));
                paramcollection.Add(new DBParameter("@RechillStatusId", receive.RechillStatusId));
                paramcollection.Add(new DBParameter("@flag", receive.flag));
                result = _DBHelper.ExecuteNonQuery("sp_Prod_RechillingDetails", paramcollection, CommandType.StoredProcedure);

            }
            catch (Exception EX)
            {
                string MSG = EX.ToString();
            }
            return result;
        }
      
       
        public DataSet GetRechillingDetails(RMRecieve R)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@date", R.RMRDate));
            return _DBHelper.ExecuteDataSet("[sp_Prod_RechillingViewDetails]", paramCollection, CommandType.StoredProcedure);
        }
        public DataSet GetRechillingDataById(int RMRId)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@RMRId", RMRId));
            return _DBHelper.ExecuteDataSet("[sp_Prod_GetRechillingDetailsbyID]", paramCollection, CommandType.StoredProcedure);
        }
    }
}