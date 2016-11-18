using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dairy.App_code;
using Comman;
namespace Dairy
{
    public partial class Print : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Control ctrl = (Control)Session["ctrl"]; 
            PrintHelper.PrintWebControl(ctrl);
        }
    }
}