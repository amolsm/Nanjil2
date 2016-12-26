using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Bussiness
{
    public class OrderDemandStatementData
    {
        DBOrderDemandStatement dbOrderDemand = new DBOrderDemandStatement();

        public DataSet GetOrderDemandReport(int routeid, int flag)
        {
            return dbOrderDemand.GetRoutewiseOrderDemandReport(routeid, flag);
        }
    }
}