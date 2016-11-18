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
    public partial class Dashboard : System.Web.UI.Page
    {
        PurchaseData purchaseData;
        DataSet DS;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                purchaseData = new PurchaseData();
                DS = new DataSet();

                int flag = 1; //for getting new indents
                DS = purchaseData.GetIndentList(flag);
                rpIndentList.DataSource = DS;
                rpIndentList.DataBind();
                lblBoxHeader.Text = "New Indent List";
                upMain.Update();
            }
        }

        protected void TimerCount_Tick(object sender, EventArgs e)
        {
            int cnt = Convert.ToInt32(lblNewIndentCount.Text);
            cnt++;
            lblNewIndentCount.Text = cnt.ToString();
           
        }

        protected void rpIndentList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            
            int IndentId = 0;
            IndentId = Convert.ToInt32(e.CommandArgument);
            
            switch (e.CommandName)
            {
                case ("View"):
                    {
                        hfId.Value = IndentId.ToString();
                        break;
                    }
                
            }
        }

        protected void btnViewIndents_Click(object sender, EventArgs e)
        {
            purchaseData = new PurchaseData();
            DS = new DataSet();

            int flag = 1; //for getting new indents
            DS = purchaseData.GetIndentList(flag);
            rpIndentList.DataSource = DS;
            rpIndentList.DataBind();
            lblBoxHeader.Text = "New Indent List";
            upMain.Update();
        }
    }
}