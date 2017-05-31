using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.Production;
using DataAcess;
using System.Data;

namespace DataAccess
{
    public class DBProduction
    {

        DBHelper _DBHelper = new DBHelper();
        DataSet DS;
        public int RMRData(RMRecieve receive)
        {
            int result = 0;
            try

            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@RMRId", receive.RMRId));
                paramCollection.Add(new DBParameter("@RMRShiftId", receive.RMRShiftId));
                paramCollection.Add(new DBParameter("@RMRDate", receive.RMRDate));
                paramCollection.Add(new DBParameter("@BatchNo", receive.BatchNo));
                paramCollection.Add(new DBParameter("@TankMilkReciptNo", receive.TankMilkReciptNo));
                paramCollection.Add(new DBParameter("@TankerNo", receive.TankerNo));
                paramCollection.Add(new DBParameter("@TypeOfMilk", receive.MilkType));
                paramCollection.Add(new DBParameter("@Qty", receive.Quantity));
                paramCollection.Add(new DBParameter("@CreatedBy", receive.CreatedBy));
                paramCollection.Add(new DBParameter("@CreatedDate", receive.CreatedDate));
                paramCollection.Add(new DBParameter("@RMRQCStatus", receive.QCId));
                paramCollection.Add(new DBParameter("@MBRTStart", receive.MBRTStart));
                paramCollection.Add(new DBParameter("@MBRTEnd", receive.MBRTEnd));
                paramCollection.Add(new DBParameter("@TotalHours", receive.TotalHours));
                paramCollection.Add(new DBParameter("@flag", receive.flag));
                //paramCollection.Add(new DBParameter("@CheckBatchNo", receive.CheckBatchNo));
                result = _DBHelper.ExecuteNonQuery("sp_Prod_RMReceived", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception EX)
            {

                string MSG = EX.ToString();


            }
            return result;
        }

        public DataSet GetExistingBatchNo(string batchno)
        {
            DataSet DS = new DataSet();
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@batchno", batchno));
                DS = _DBHelper.ExecuteDataSet("sp_Prod_GetExistingBatchNo", paramCollection, CommandType.StoredProcedure);

            }
            catch { }
            return DS;
        }
        public DataSet GetRMRDetailsbyID(int RMRId)
        {
            DataSet DS = new DataSet();
            try
            {


                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@RMRId", RMRId));
                DS = _DBHelper.ExecuteDataSet("sp_Prod_GetRMRDetailsbyID", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception EX)
            {
                string MSG = EX.ToString();
            }
            return DS;
        }

        public DataSet GetRMRDetails(RMRecieve R)
        {
            DataSet DS = new DataSet();
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@date", R.RMRDate));
                return _DBHelper.ExecuteDataSet("sp_Prod_GetRMRInformation", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception EX)
            {
                string MSG = EX.ToString();
            }
            return DS;

        }
    }
}