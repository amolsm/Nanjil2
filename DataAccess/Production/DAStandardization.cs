using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.Production;
using DataAcess;
using System.Data;

namespace DataAccess.Production
{
    public class DAStandardization
    {
        DBHelper _DBHelper = new DBHelper();
        DataSet DS;

        public int StdData(MStandardization std)
        {
            int result = 0;
            try

            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@RMRId", std.RMRId));
                paramCollection.Add(new DBParameter("@QualityId", std.QualityId));
                paramCollection.Add(new DBParameter("@StdDate", std.StandardDate));
                paramCollection.Add(new DBParameter("@StdShiftId", std.StdShiftId));
                paramCollection.Add(new DBParameter("@SiloNo", std.SiloNo));
                paramCollection.Add(new DBParameter("@RCMQuantity", std.RCMQuantity));
                paramCollection.Add(new DBParameter("@StdStartTime", std.StandardizationStartTime));
                paramCollection.Add(new DBParameter("@StdEndTime", std.StandardizationEndTime));
                paramCollection.Add(new DBParameter("@CuttingMilkQuantity", std.CuttingMilkQuantity));
                paramCollection.Add(new DBParameter("@CuttingMilkFat", std.CuttingMilkFAT));
                paramCollection.Add(new DBParameter("@CuttingMilkSNF", std.CuttingMilkSNF));
                paramCollection.Add(new DBParameter("@Skim", std.Skim));
                //paramCollection.Add(new DBParameter("@Qty", std.Qty));
                paramCollection.Add(new DBParameter("@SkimFAT", std.SkimFAT));
                paramCollection.Add(new DBParameter("@SkimSNF", std.SkimSNF));
                paramCollection.Add(new DBParameter("@RCM", std.RCM));
                paramCollection.Add(new DBParameter("@SMP", std.SMP));
                paramCollection.Add(new DBParameter("@CreamAdd", std.CreamAdd));
                paramCollection.Add(new DBParameter("@CreamProduced", std.CreamProduced));
                paramCollection.Add(new DBParameter("@StandardizationStatusId", std.StandardizationStatusId));
                //paramCollection.Add(new DBParameter("@TotalQuantity", std.TotalQuantity));
                //paramCollection.Add(new DBParameter("@TypeOfMilk", std.TypeOfMilk));
                paramCollection.Add(new DBParameter("@Remarks", std.Remarks));
                //paramCollection.Add(new DBParameter("@Custom1", std.Custom1));
                //paramCollection.Add(new DBParameter("@Custom2", std.Custom2));
                //paramCollection.Add(new DBParameter("@Custom3", std.Custom3));
                //paramCollection.Add(new DBParameter("@Custom4", std.Custom4));
                //paramCollection.Add(new DBParameter("@Custom5", std.Custom5));
                paramCollection.Add(new DBParameter("@flag", std.flag));
                result = _DBHelper.ExecuteNonQuery("sp_Prod_Standardization", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception EX)
            {

                string MSG = EX.ToString();


            }
            return result;
        }

        public DataSet GetStandardizationDetailsbyID(int RMRId)
        {
            DataSet DS = new DataSet();
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@RMRId", RMRId));
                DS = _DBHelper.ExecuteDataSet("sp_Prod_GetStandardizationDetailsbyID", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception EX)
            {

                string MSG = EX.ToString();


            }
            return DS;
        }

        public DataSet GetStandardizationDetails(RMRecieve R)
        {

            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@date", R.RMRDate));
            return _DBHelper.ExecuteDataSet("[sp_Prod_GetStandardizationInformation]", paramCollection, CommandType.StoredProcedure);
        }
    }
}