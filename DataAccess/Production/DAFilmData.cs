using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.Production;
using DataAcess;
using System.Data;

namespace DataAccess.Production
{
    public class DAFilmData
    {
        DBHelper _DBHelper = new DBHelper();
        DataSet DS;
        //
        public int filmdata(MFilmData receive)
        {
            int result = 0;
            try
            {
                DBParameterCollection paramcollection = new DBParameterCollection();
                paramcollection.Add(new DBParameter("@RMRId", receive.RMRId));
                paramcollection.Add(new DBParameter("@FilmDataId", receive.FilmDataId));
                paramcollection.Add(new DBParameter("@FilmDate", receive.FilmDate));
                paramcollection.Add(new DBParameter("@ShiftId", receive.ShiftId));
                paramcollection.Add(new DBParameter("@Product", receive.Product));
                paramcollection.Add(new DBParameter("@CommodityWise", receive.CommodityWise));
                paramcollection.Add(new DBParameter("@OpeningStock", receive.OpeningStock));
                paramcollection.Add(new DBParameter("@ReceivedQty", receive.ReceivedQty));
                paramcollection.Add(new DBParameter("@CalculateConsumedQty", receive.CalculateConsumedQty));
                paramcollection.Add(new DBParameter("@Wastage", receive.Wastage));
                paramcollection.Add(new DBParameter("@ClosingStock", receive.ClosingStock));
                paramcollection.Add(new DBParameter("@MilkType", receive.MilkType));
                paramcollection.Add(new DBParameter("@FilmDetailsStatusId", receive.FilmDetailsStatusId));
                paramcollection.Add(new DBParameter("@flag", receive.flag));
                result = _DBHelper.ExecuteNonQuery("sp_Prod_FilmDataDetails", paramcollection, CommandType.StoredProcedure);
            }
            catch (Exception EX)
            {
                String MSG = EX.ToString();
            }
            return result;
        }

        public DataSet GetFilmDetailsById(int RMRId)
        {
            DataSet DS = new DataSet();
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@RMRId", RMRId));
                DS = _DBHelper.ExecuteDataSet("sp_Prod_FilmDataDetailsById", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception EX)
            {
                string MSG = EX.ToString();
            }

            return DS;
        }

        public DataSet GetFilmDetails(RMRecieve R)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@date", R.RMRDate));
            return _DBHelper.ExecuteDataSet("sp_Prod_GetFilmDetails", paramCollection, CommandType.StoredProcedure);
        }
    }
}