using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dairy.Tabs.Production
{
    public partial class Cold_room_temperature_chart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtTime1.Text = Convert.ToString(DateTime.Now.ToString("HH:mm"));
            txtTime2.Text = Convert.ToString(DateTime.Now.ToString("HH:mm"));
            txtTime3.Text = Convert.ToString(DateTime.Now.ToString("HH:mm"));
            //temp
        }
    }
}