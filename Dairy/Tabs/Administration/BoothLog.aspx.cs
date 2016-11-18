using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dairy.Tabs.Administration
{
    public partial class BoothLog : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            List<string> d = Application["BoothLoggedIn"] as List<string>;

            if (d != null)
            {

                rpBrandInfo.DataSource = d;
                rpBrandInfo.DataBind();
            }
        }
        protected void rpRouteList_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            List<string> d = Application["BoothLoggedIn"] as List<string>;
            string booth = Convert.ToString(e.CommandArgument);
            //if( users != GlobalInfo.UserName )
            //{ 
            if (d != null)
            {
                lock (d)
                {
                    d.Remove(booth);
                }
            }
            Response.Redirect("BoothLog.aspx");
            //}
        }
    }
}