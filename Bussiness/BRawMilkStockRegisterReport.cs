using DataAccess;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Bussiness
{
    public class BRawMilkStockRegisterReport
    {
        DBRawMilkStockRegisterReport dbtp = new DBRawMilkStockRegisterReport();
        public DataSet RawMilkStockRegisterReport(MRawMilkStockRegisterReport p)
        {
            return dbtp.RawMilkStockRegisterReport(p);
        }
    }
}