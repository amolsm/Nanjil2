using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using Bussiness;
using System.Data;
using Comman;
using System.Text;
using Dairy.App_code;
using System.Configuration;
using System.Data.SqlClient;

using System.Web.Services;

namespace Dairy.Tabs.Administration
{
    public partial class CashierSettlement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //BindRouteList();
                BindDropDwon();
            }
        }

        
            
        public void BindDropDwon()
        {


            DataSet DS = new DataSet();
            DS = BindCommanData.BindCommanDropDwon("RouteID ", "RouteCode +' '+RouteName as Name  ", "routeMaster", "IsArchive=1 ");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpagentRoute.DataSource = DS;
                dpagentRoute.DataBind();
                dpagentRoute.Items.Insert(0, new ListItem("--Select Agent Route  --", "0"));
            }
            DS.Clear();
        }

        protected void rpRouteList_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            divDanger.Visible = false;
            divwarning.Visible = false;
            divSusccess.Visible = false;
            pnlError.Update();
            int id = 0;
            id = Convert.ToInt32(e.CommandArgument);


            switch (e.CommandName)
            {
                case ("Edit"):
                    {
                        //lbltital.Text = "Edit Route";
                        hfRow.Value = id.ToString();
                        id = Convert.ToInt32(hfRow.Value);
                        //BindRouteList();

                        GetBillDetailsbyId(id);
                        //btnAddRoute.Visible = false;
                        //btnupdateroute.Visible = true;
                        // upMain.Update();
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "<script type='text/javascript'> $('#myModal').modal('show'); </script>", false);
                        uprouteList.Update();
                        upModal.Update();
                        break;
                    }
                case ("delete"):
                    {

                        //hfrouteID.Value = routeID.ToString();
                        // routeID = Convert.ToInt32(hfrouteID.Value);
                        // DeleteRoutebyrouteID(routeID);
                        // BindRouteList();
                        //upMain.Update();
                        // uprouteList.Update();
                        break;
                    }


            }
        }

        private void GetBillDetailsbyId(int id)
        {
            Dispatch dispatch = new Dispatch();
            DispatchData dispatchData = new DispatchData();
            DataSet DS = new DataSet();
            DS = dispatchData.CashierGetDetailsId(id);

            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                txtAgentName.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["AgentName"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["AgentName"].ToString();
                txtHidden.Text = id.ToString();
                txtPaymentMode.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["BillingType"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["BillingType"].ToString();
                txtTotalBill.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["FinalBillingAmount"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["FinalBillingAmount"].ToString();
                txtPendingBill.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["PendingAmount"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["PendingAmount"].ToString();
                txtReceivedAmount.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["ReceivedAmount"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["ReceivedAmount"].ToString();
                //txtCommodityName.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["CommodityName"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["CommodityName"].ToString();
               // txtAgentName.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["AgentName"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["AgentName"].ToString();

            }
        }
        
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Dispatch dispatch = new Dispatch();
            dispatch.OrderDate = (Convert.ToDateTime(txtOrderDate.Text)).ToString("dd-MM-yyyy");
            dispatch.RouteID = Convert.ToInt32(dpagentRoute.SelectedItem.Value);
            DispatchData dispatchData = new DispatchData();
            DataSet DS = new DataSet();
            
            DS = dispatchData.CashierGetDetails(dispatch);

            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
               
                rpRouteList.DataSource = DS;
                rpRouteList.DataBind();
                rpRouteList.Visible = true;

               
                uprouteList.Update();

                // DS.WriteXml(Server.MapPath("~/Tabs/Dispatch/temp.xml"));

                //string str = DS.GetXml();
                //insertDispatchTemp(DS);

            }
            else { rpRouteList.Visible = false; uprouteList.Update(); }

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Dispatch disp = new Dispatch();
            DispatchData dispatchData = new DispatchData();

            disp.DispatchId = Convert.ToInt32(txtHidden.Text);
            disp.Total = Convert.ToDouble(txtReceivedAmount.Text);
            disp.UserID = Convert.ToInt32(GlobalInfo.Userid);
            disp.OrderDate = DateTime.Now.ToString("dd-MM-yyyy");

            int result = 0;
            DataSet ds = new DataSet();
            result = dispatchData.CashierUpdate(disp);

            if (result > 0)
            {

                ClearTextBox();

               // updatelist();
                //rpRouteList.Visible = false;

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Information Updated  Successfully";


                pnlError.Update();

                upModal.Update();
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

        private void ClearTextBox()
        {
            txtAgentName.Text = string.Empty;
            txtPaymentMode.Text = string.Empty;
            txtPendingBill.Text = string.Empty;
            txtReceivedAmount.Text = string.Empty;
            txtTotalBill.Text = string.Empty;
        }
    }
}