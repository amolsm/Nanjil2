using Dairy.App_code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dairy.Tabs.Administration
{
    public class temp
    {
        public string UserName { get; set; }
    }
    public partial class UserLog : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            List<string> d = Application["UsersLoggedIn"] as List<string>;

            if (d != null)
            {
               
                rpBrandInfo.DataSource = d;
                rpBrandInfo.DataBind();
            }
        }
        protected void rpRouteList_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            List<string> d = Application["UsersLoggedIn"] as List<string>;
            string users = Convert.ToString( e.CommandArgument);
            //if( users != GlobalInfo.UserName )
            //{ 
            if (d != null)
            {
                lock (d)
                {
                    d.Remove(users);
                }
            }
            Response.Redirect("UserLog.aspx");
            //}
        }
        }
}