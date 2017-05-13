using DataAcess;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DataAccess
{
    public class DBTransportpayment
    {
        DBHelper _DBHelper = new DBHelper();
        public DataSet TransportPaymentDetails(MTransportPayment p)
        {
            DataSet DS = new DataSet();
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@Startdate", p.Startdate));
                paramCollection.Add(new DBParameter("@Enddate", p.Enddate));
                paramCollection.Add(new DBParameter("@Vehicletype", p.Vehicletype));
                DS = _DBHelper.ExecuteDataSet("SP_TransportPayment", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception e)
            { string msg = e.ToString(); }

            return DS;
        }
    }
}