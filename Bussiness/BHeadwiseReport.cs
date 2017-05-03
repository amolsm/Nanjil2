using DataAccess;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Bussiness
{
    public class BHeadwiseReport
    {
        DBHeadwiseReport dbhr = new DBHeadwiseReport();
        public DataSet HeadwiseDetails(MHeadwiseReport p)
        {
            return dbhr.HeadwiseDetails(p);
        }

        public DataSet Received_Disposed_HeadswiseDeatils(MHeadwiseReport p)
        {
            return dbhr.Received_Disposed_HeadswiseDeatils(p);
        }
    }
}