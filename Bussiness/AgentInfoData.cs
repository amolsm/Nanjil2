using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;
using DataAccess;
using System.Data;

namespace Bussiness
{
    public class AgentInfoData
    {
        DBInsertAgentInfo dbagentinfo = new DBInsertAgentInfo();
        public int InsertAgentInfo(AgentInfo agentiinfo)
        {
            return dbagentinfo.InsertAgentInfo(agentiinfo);
 
        }
        public DataSet GetAgentbyID(int AgentID)
        {

            return dbagentinfo.GetAgentbyID(AgentID);
        }
        public DataSet GetAllAgentDetails()
        {
            return dbagentinfo.GetAllAgentDetails();
        }
    }
}