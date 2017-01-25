using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model
{
    public class MAgentwiseTray
    {
        public int DispatchId { get; set; }
        public int AgentId { get; set; }
        public int EmpId { get; set; }
        public int TraysDispached { get; set; }
        public int ReturnTrays { get; set; }
        public string flag { get; set; }
        public int salesmanid { get; set; }
    }
}