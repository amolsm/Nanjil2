using DataAcess;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DataAccess
{
    public class DBRawMilkStockRegisterReport
    {
        DBHelper _DBHelper = new DBHelper();
        public DataSet RawMilkStockRegisterReport(MRawMilkStockRegisterReport p)
        {
            DataSet DS = new DataSet();
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@Date", p.Date));
                //paramCollection.Add(new DBParameter("@Enddate", p.Enddate));
                //paramCollection.Add(new DBParameter("@Reporttype", p.ReportType));
                DS = _DBHelper.ExecuteDataSet("SP_RawMilkStockRegisterReport", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception e)
            { string msg = e.ToString(); }

            return DS;
        }
    }
}