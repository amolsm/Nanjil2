using Bussiness;
using Dairy.App_code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace Dairy.Tabs.Reception
{
    public partial class CancelOrder : System.Web.UI.Page
    {
        DataSet DS;
        BillData billdata;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DS = new DataSet();
                DS = BindCommanData.BindCommanDropDwon("RouteID ", "RouteCode +' '+RouteName as Name  ", "routeMaster", "IsArchive=1");
                if (!Comman.Comman.IsDataSetEmpty(DS))
                {
                    dpRoute.DataSource = DS;
                    dpRoute.DataBind();
                    dpRoute.Items.Insert(0, new ListItem("--All Route--", "0"));
                }
               
                txtDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));

            }
            if (Context.Session != null && Context.Session.IsNewSession == true &&
    Page.Request.Headers["Cookie"] != null &&
    Page.Request.Headers["Cookie"].IndexOf("ASP.NET_SessionId") >= 0)
            {
                // session has timed out, log out the user
                if (Page.Request.IsAuthenticated)
                {
                    FormsAuthentication.SignOut();
                }
                // redirect to timeout page
                Page.Response.Redirect("/Authentication/LoginT.aspx");
            }
        }

        protected void btnViewDetails_Click(object sender, EventArgs e)
        {
            bindList();
        }

        private void bindList()
        {
            string result = string.Empty;
            billdata = new BillData();
            DS = new DataSet();

            DS = billdata.GetOrdersForCancel((Convert.ToDateTime(txtDate.Text)).ToString("dd-MM-yyyy"), Convert.ToInt32(dpRoute.SelectedItem.Value),0);


            rpOrderList.DataSource = DS;
            rpOrderList.DataBind();
        }

        protected void rpOrderList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            divDanger.Visible = false;
            divwarning.Visible = false;
            divSusccess.Visible = false;
            pnlError.Update();
            int Id = 0;
            Id = Convert.ToInt32(e.CommandArgument);
            switch (e.CommandName)
            {
                case ("Edit"):
                    {

                        hbankId.Value = Id.ToString();
                        Id = Convert.ToInt32(hbankId.Value);
                        CancelOrderById(Id);

                        //uprouteList.Update();
                        break;
                    }
               


            }
        }

        private void CancelOrderById(int id)
        {
            DS = new DataSet();
            billdata = new BillData();
            int flag = 1;
            int CancelBy = GlobalInfo.Userid;
            int result = billdata.CancelOrderById(id, flag, CancelBy,string.Empty);
            if (result > 0)
            {

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Order Cancelled Successfully";
                pnlError.Update();
                bindList();
                uprouteList.Update();
            }
            else
            {
                divDanger.Visible = false;
                divwarning.Visible = true;
                divSusccess.Visible = false;
                lblwarning.Text = "Please Contact to Site Admin";
                pnlError.Update();

            }
        }
    }
}