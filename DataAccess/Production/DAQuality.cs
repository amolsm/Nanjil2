using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.Production;
using DataAcess;
using System.Data;


namespace DataAccess.Production
{
    public class DAQuality
    {
        DBHelper _DBHelper = new DBHelper();
        DataSet DS;

        public int QualityData(MQuality receive)
        {
            int result = 0;
            try
            {
                DBParameterCollection paramcollection = new DBParameterCollection();
                //paramcollection.Add(new DBParameter("@QCId", receive.QCId));
                paramcollection.Add(new DBParameter("@RMRId", receive.RMRId));
                paramcollection.Add(new DBParameter("@QualityDate", receive.QualityDate));
                paramcollection.Add(new DBParameter("@RMRShiftId", receive.RMRShiftId));
                paramcollection.Add(new DBParameter("@Temperature", receive.Temperature));
                paramcollection.Add(new DBParameter("@Alcohol", receive.Alcohol));
                paramcollection.Add(new DBParameter("@Neutralizer", receive.Neutralizer));
                paramcollection.Add(new DBParameter("@Taste", receive.Taste));
                paramcollection.Add(new DBParameter("@Smell", receive.Smell));
                paramcollection.Add(new DBParameter("@Color", receive.Color));
                paramcollection.Add(new DBParameter("@Acidity", receive.Acidity));
                paramcollection.Add(new DBParameter("@HeatStability", receive.HeatStability));
                paramcollection.Add(new DBParameter("@Fat", receive.Fat));
                paramcollection.Add(new DBParameter("@CLR", receive.CLR));
                paramcollection.Add(new DBParameter("@SNF", receive.CLR));
                paramcollection.Add(new DBParameter("@TestedBy", receive.TestedBy));
                paramcollection.Add(new DBParameter("@VerifiedBy", receive.VerifiedBy));
                paramcollection.Add(new DBParameter("@Others", receive.Others));
                paramcollection.Add(new DBParameter("@Remarks", receive.Remarks));
                paramcollection.Add(new DBParameter("@QCStatus", receive.QCStatus));
                paramcollection.Add(new DBParameter("@flag", receive.flag));
                result = _DBHelper.ExecuteNonQuery("sp_Prod_QualityDetails",  paramcollection, CommandType.StoredProcedure);

            }
            catch (Exception EX)
            {
                string MSG = EX.ToString();
            }
            return result;
        }
      
        public DataSet GetQualityDetails(RMRecieve R)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@date", R.RMRDate));
            return (_DBHelper.ExecuteDataSet("sp_Prod_GetQualityInformation", paramCollection, CommandType.StoredProcedure));
        }

        public DataSet GetQualityDetailsById(int RMRId)
        {
            DataSet DS = new DataSet();
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                //return _DBHelper.ExecuteDataSet("sp_QualityDetails", paramCollection, CommandType.StoredProcedure);
                paramCollection.Add(new DBParameter("@RMRId", RMRId));
                DS = _DBHelper.ExecuteDataSet("sp_Prod_GetQualityDetailsbyID", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception EX)
            {
                string MSG = EX.ToString();
            }
            return DS;
        }
    }
  }
