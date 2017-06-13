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
                try
                {
                    string str = Convert.ToString(Session["CollectionCenterLoggedIn"]);
                    string str1 = string.Join(string.Empty, str.Skip(5));
                    lblemployeeName1.Text = GlobalInfo.UserName + "<br>" + "<center>" + str1 + "</center>";
                }
                catch (Exception) { }
            }
        }
    }
}