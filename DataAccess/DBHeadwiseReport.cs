using DataAcess;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DataAccess
{
    public class DBHeadwiseReport
    {
        DBHelper _DBHelper = new DBHelper();
        public DataSet HeadwiseDetails(MHeadwiseReport p)
        {
            DataSet DS = new DataSet();
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@Startdate", p.Startdate));
                paramCollection.Add(new DBParameter("@Enddate", p.Enddate));
                paramCollection.Add(new DBParameter("@Head", p.Head));
                DS = _DBHelper.ExecuteDataSet("SP_HeadwiseReport", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception e)
            { string msg = e.ToString(); }

            return DS;
        }

        public DataSet Received_Disposed_HeadswiseDeatils(MHeadwiseReport p)
        {
            DataSet DS = new DataSet();
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@Startdate", p.Startdate));
                paramCollection.Add(new DBParameter("@Enddate", p.Enddate));
                paramCollection.Add(new DBParameter("@ParticularType", p.ParticularType));
                paramCollection.Add(new DBParameter("@Particular", p.Particular));
                DS = _DBHelper.ExecuteDataSet("SP_Received_Disposed_HeadswiseDeatils", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception e)
            { string msg = e.ToString(); }

            return DS;
        }

    }
}