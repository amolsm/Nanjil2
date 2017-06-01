using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.Production;
using DataAcess;
using System.Data;

namespace DataAccess.Production
{
    public class DAMilkProductsTestBeforePackingQC
    {
        DBHelper _DBHelper = new DBHelper();
        DataSet DS;

        public int milkproductdata(MMilkProductsTestBeforePackingQC receive)
    {
        int result = 0;
        try
        {
          DBParameterCollection paramcollection = new DBParameterCollection();
          paramcollection.Add(new DBParameter("@MilkProductsTestBeforePackingQCId", receive.MilkProductsTestBeforePackingQCId));
          paramcollection.Add(new DBParameter("@RMRId", receive.RMRId));
          paramcollection.Add(new DBParameter("@MilkProductsTestBeforePackingQCDate", receive.MilkProductsTestBeforePackingQCDate));
          paramcollection.Add(new DBParameter("@MilkProductsTestBeforePackingQCShiftId", receive.MilkProductsTestBeforePackingQCShiftId));
          paramcollection.Add(new DBParameter("@Particular", receive.Particular));
          paramcollection.Add(new DBParameter("@Quantity", receive.Quantity));
          paramcollection.Add(new DBParameter("@TestName", receive.TestName));
          paramcollection.Add(new DBParameter("@Result", receive.Result));
          paramcollection.Add(new DBParameter("@Remarks", receive.Remarks));
          paramcollection.Add(new DBParameter("@MilkProdTestBeforePackingQCStatusId", receive.MilkProdTestBeforePackingQCStatusId));
          paramcollection.Add(new DBParameter("@flag", receive.flag));
          result = _DBHelper.ExecuteNonQuery("sp_Prod_MilkProductsTestBeforePackingQCDetails ", paramcollection, CommandType.StoredProcedure);
       }
        catch (Exception EX)
        {
            String MSG = EX.ToString();
        }
        return result;
     }

        public DataSet GetMilkProductsTestBeforePackingQCDetailsById(int RMRId)
        {
            DataSet DS = new DataSet();
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@RMRId", RMRId));
                DS = _DBHelper.ExecuteDataSet("sp_Prod_GetMilkProductsTestBeforePackingQCDetailsById", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception EX)
            {
                string MSG = EX.ToString();
            }

            return DS;
        }

        public DataSet GetMilkProductsTestBeforePackingQCDetails(RMRecieve R)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@date", R.RMRDate));
            return _DBHelper.ExecuteDataSet("sp_Prod_GetMilkProductsTestBeforePackingQCDetails", paramCollection, CommandType.StoredProcedure);
        }
    }
}