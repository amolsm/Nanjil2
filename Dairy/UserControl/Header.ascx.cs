using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dairy.App_code;
namespace Dairy.UserControl
{
    public partial class Header : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
              lblLAstLoginName.Text=GlobalInfo.LlastLogin;
              lblemployeeName1.Text = GlobalInfo.UserName;
            }
        }
    }
}