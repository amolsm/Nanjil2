using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Bussiness
{
    public class BAgentwiseTray
    {
        DAAgentwiseTray dat;
        DataSet DS;

        public DataSet GetAgentwiseTrayDetails(int DispatchId, string DDate)
        {
            dat = new DAAgentwiseTray();
            return dat.GetAgentwiseTrayDetails(DispatchId, DDate);
        }


        public int AddAgentwiseTrayDetails(int dispatchid, int AgentId, int EmpId, int traydispatched, int returntrays, int salesmanid, int routeid, string date, int excesstrays, int shorttrays)
        {
            DAAgentwiseTray daagentwisetray = new DAAgentwiseTray();
            return daagentwisetray.AddAgentwiseTrayDetails(dispatchid, AgentId, EmpId, traydispatched, returntrays, salesmanid, routeid, date, excesstrays, shorttrays);
        }

        public DataSet GetAgentwiseReturnTraysReport(string startdate, string enddate, int agentid, int flag)
        {
            DAAgentwiseTray daagentwisetray = new DAAgentwiseTray();
            return daagentwisetray.GetAgentwiseReturnTraysReport(startdate, enddate, agentid, flag);
        }
    }
}