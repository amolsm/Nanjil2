using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Bussiness
{
    public class BHardCopyTariff
    {
        DBHardCopyTariff dbhardcopytariff = new DBHardCopyTariff();

        public DataSet GetHardCopyTariff(int flag)
        {
            return dbhardcopytariff.GetHardCopyTariff(flag);
        }
    }
}