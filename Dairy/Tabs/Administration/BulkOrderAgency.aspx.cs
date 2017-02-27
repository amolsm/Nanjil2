using Bussiness;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dairy.Tabs.Administration
{
    public partial class BulkOrderAgency : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDwon();
                hftokanno.Value = Comman.Comman.RandomString();
                txtGentOrderDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
            }
        }
        private void BindDropDwon()
        {
            DataSet DS = new DataSet();
            DS = BindCommanData.BindCommanDropDwon("RouteID ", "RouteCode +' '+RouteName as Name  ", "routeMaster", "IsArchive=1 ");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpagentRoute.DataSource = DS;
                dpagentRoute.DataBind();
                dpagentRoute.Items.Insert(0, new ListItem("--Select Agent Route  --", "0"));

            }
        }
        protected void btnGetPreviousOrder_Click(object sender, EventArgs e)
        {

        }

        protected void btnAgentORderSubmit_Click(object sender, EventArgs e)
        {

        }

        protected void rpAgentOrderdetails_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

        protected void btnSaveChanges_Click(object sender, EventArgs e)
        {

        }
    }
}