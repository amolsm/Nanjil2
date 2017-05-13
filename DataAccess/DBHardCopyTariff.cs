using DataAcess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DataAccess
{
    public class DBHardCopyTariff
    {
        DBHelper _DBHelper = new DBHelper();

        public DataSet GetHardCopyTariff(int flag)
        {

            DataSet DS = new DataSet();
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@flag", flag));
                DS = _DBHelper.ExecuteDataSet("sp_HardCopyTariff", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                string msg = ex.ToString();

            }

            return DS;
        }
    }
}