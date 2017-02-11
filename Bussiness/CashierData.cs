using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;
using DataAccess;
using System.Data;

namespace Bussiness
{
    public class CashierData
    {
        DBCashier dbcashier = new DBCashier();
        public DataSet AddCashierInfo(Cashier cm)
        {
            return dbcashier.AddCashierInfo(cm);
        }

        public int AddAgentCashSales(int trId, string agentId, double agencysales, double paymentsales, string DdId)
        {
            return dbcashier.AddAgentCashSales(trId, agentId, agencysales, paymentsales, DdId);
        }
    }
}