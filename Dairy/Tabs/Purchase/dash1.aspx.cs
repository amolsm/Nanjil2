using Bussiness;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dairy.Tabs.Purchase
{
    public partial class dash1 : System.Web.UI.Page
    {
        DataSet DS;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            DS = new DataSet();
            DS = BindCommanData.BindCommanDropDwon("count(*) as id", "count(*) as Name", "Prchs_Indent", "Delivered = 0");
            
            lblNewIndentCount.Text = DS.Tables[0].Rows[0]["Name"].ToString();
        }
    }
}