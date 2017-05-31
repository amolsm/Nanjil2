using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.Production;
using DataAcess;
using System.Data;

namespace DataAccess.Production
{
    public class DAStandardizationProductsAdded
    {
        DBHelper _DBHelper = new DBHelper();
        DataSet DS;
        public int stdpdata(MStandardizationProductsAdded receive)
        {
            int result = 0;
            try
            {
                DBParameterCollection paramcollection = new DBParameterCollection();
                paramcollection.Add(new DBParameter("@StandardizationProductsAddedId", receive.StandardizationProductsAddedId));
                paramcollection.Add(new DBParameter("@RMRId", receive.RMRId));
                paramcollection.Add(new DBParameter("@StandardizationProductsAddedDate", receive.StandardizationProductsAddedDate));
                paramcollection.Add(new DBParameter("@StandardizationProductsAddedShiftId", receive.StandardizationProductsAddedShiftId));
                paramcollection.Add(new DBParameter("@MilkType", receive.MilkType));
                paramcollection.Add(new DBParameter("@SMPQuantity", receive.SMPQuantity));
                paramcollection.Add(new DBParameter("@Creamkg", receive.Creamkg));
                paramcollection.Add(new DBParameter("@Waterliters", receive.Waterliters));
                paramcollection.Add(new DBParameter("@CondensedMilk", receive.CondensedMilk));
                paramcollection.Add(new DBParameter("@ButterOil", receive.ButterOil));
                paramcollection.Add(new DBParameter("@SkimmedMilk", receive.SkimmedMilk));
                paramcollection.Add(new DBParameter("@Others", receive.Others));
                paramcollection.Add(new DBParameter("@StdStatusId", receive.StdStatusId));
                paramcollection.Add(new DBParameter("@flag", receive.flag));
                result = _DBHelper.ExecuteNonQuery("sp_Prod_StandardizationProductsAddedDetails ", paramcollection, CommandType.StoredProcedure);
            }
            catch (Exception EX)
            {
                String MSG = EX.ToString();
            }
            return result;
        }

        public DataSet GetStandardizationProductsAddedDetailsById(int RMRId)
        {
            DataSet DS = new DataSet();
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@RMRId", RMRId));
                DS = _DBHelper.ExecuteDataSet("sp_Prod_GetStandardizationProductsAddedDetailsById", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception EX)
            {
                string MSG = EX.ToString();
            }

            return DS;
        }

        public DataSet GetStandardizationProductsAddedDetails(RMRecieve R)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@date", R.RMRDate));
            return _DBHelper.ExecuteDataSet("sp_Prod_GetStandardizationProductsAddedDetails", paramCollection, CommandType.StoredProcedure);
        }
    }
}