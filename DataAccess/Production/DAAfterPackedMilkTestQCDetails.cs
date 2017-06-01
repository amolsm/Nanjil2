using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.Production;
using DataAcess;
using System.Data;

namespace DataAccess.Production
{
    public class DAAfterPackedMilkTestQCDetails
    {
        DBHelper _DBHelper = new DBHelper();
        DataSet DS;
        //
        public int milkqc(MAfterPackedMilkTestQCDetails receive)
        {
            int result = 0;
            try
            {
                DBParameterCollection paramcollection = new DBParameterCollection();
                paramcollection.Add(new DBParameter("@RMRId", receive.RMRId));
                paramcollection.Add(new DBParameter("@AfterPackedMilkTestQCId", receive.AfterPackedMilkTestQCId));
                paramcollection.Add(new DBParameter("@AfterPackedMilkTestQCDate", receive.AfterPackedMilkTestQCDate));
                paramcollection.Add(new DBParameter("@ShiftId", receive.ShiftId));
                paramcollection.Add(new DBParameter("@Source", receive.Source));
                paramcollection.Add(new DBParameter("@Weight", receive.Weight));
                paramcollection.Add(new DBParameter("@Quantity", receive.Quantity));
                paramcollection.Add(new DBParameter("@Temperature", receive.Temperature));
                paramcollection.Add(new DBParameter("@FAT", receive.FAT));
                paramcollection.Add(new DBParameter("@CLR", receive.CLR));
                paramcollection.Add(new DBParameter("@SNF", receive.SNF));
                paramcollection.Add(new DBParameter("@QualityStartTime", receive.QualityStartTime));
                paramcollection.Add(new DBParameter("@Hour1", receive.Hour1));
                paramcollection.Add(new DBParameter("@Hours2", receive.Hours2));
                paramcollection.Add(new DBParameter("@Hours3", receive.Hours3));
                paramcollection.Add(new DBParameter("@Hours4", receive.Hours4));
                paramcollection.Add(new DBParameter("@Hours5", receive.Hours5));
                paramcollection.Add(new DBParameter("@Hours6", receive.Hours6));
                paramcollection.Add(new DBParameter("@Hours7", receive.Hours7));
                paramcollection.Add(new DBParameter("@Hours8", receive.Hours8));
                paramcollection.Add(new DBParameter("@TotalHours", receive.TotalHours));
                paramcollection.Add(new DBParameter("@MilkPouchQcStatusId", receive.MilkPouchQcStatusId));
                paramcollection.Add(new DBParameter("@flag", receive.flag));
                result = _DBHelper.ExecuteNonQuery("sp_Prod_AfterPackedPouchMilkTestQCDetails", paramcollection, CommandType.StoredProcedure);
            }
            catch (Exception EX)
            {
                String MSG = EX.ToString();
            }
            return result;
        }

        public DataSet GetMilkQCDetailsById(int RMRId)
        {
            DataSet DS = new DataSet();
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@RMRId", RMRId));
                DS = _DBHelper.ExecuteDataSet("sp_Prod_GetAfterMilkTestQCDetailsById", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception EX)
            {
                string MSG = EX.ToString();
            }

            return DS;
        }

        public DataSet GetMilkQCDetails(RMRecieve R)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@date", R.RMRDate));
            return _DBHelper.ExecuteDataSet("sp_Prod_GetAfterMilkTestQCDetails", paramCollection, CommandType.StoredProcedure);
        }
    }
}