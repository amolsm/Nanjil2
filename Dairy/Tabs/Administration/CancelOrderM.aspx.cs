using Bussiness;
using Dairy.App_code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dairy.Tabs.Administration
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
            int result = billdata.CancelOrderById(id, flag, CancelBy, string.Empty);
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

        

        protected void lblCancelBooth_Click(object sender, EventArgs e)
        {
            DS = new DataSet();
            billdata = new BillData();
            int flag = 11;
            int id = Convert.ToInt32(hfBoothOrderId.Value);
                //Convert.ToInt32(dpBillType.SelectedItem.Value);
            int CancelBy = GlobalInfo.Userid;
            int result = billdata.CancelOrderById(id, flag, CancelBy, dpBillType.SelectedItem.Text);
            if (result > 0)
            {

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Order Cancelled Successfully";
                pnlError.Update();
                
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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            billdata = new BillData();
            DS = new DataSet();

            DS = billdata.GetOrdersForCancel(txtBillNo.Text.ToString(), Convert.ToInt32(dpBillType.SelectedItem.Value), 10);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                lblBoothName.Text = DS.Tables[0].Rows[0]["Bname"].ToString();
                lblCreatedBy.Text = DS.Tables[0].Rows[0]["ename"].ToString();
                lblTotalBill.Text = DS.Tables[0].Rows[0]["TotalBill"].ToString();
                hfBoothOrderId.Value = DS.Tables[0].Rows[0]["OrderId"].ToString();
                lblCancelBooth.Text = "Cancel";
                string empname;
                string agencyname;
                try
                {
                    empname = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["EmployeeName"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["EmployeeName"].ToString();

                }
                catch (Exception) { empname = string.Empty; }
                try
                {

                    agencyname = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["AgentName"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["AgentName"].ToString();
                }
                catch (Exception) { agencyname = string.Empty; }

                if (empname == string.Empty && agencyname == string.Empty)
                {
                    lblName.Text = "Local Sale";
                }
                else if (!(empname == string.Empty) && agencyname == string.Empty)
                {
                    lblName.Text = DS.Tables[0].Rows[0]["EmployeeCode"].ToString() + ' ' + DS.Tables[0].Rows[0]["EmployeeName"].ToString();
                }
                else if (empname == string.Empty && !(agencyname == string.Empty))
                {
                    lblName.Text = DS.Tables[0].Rows[0]["AgentCode"].ToString() + ' ' + DS.Tables[0].Rows[0]["AgentName"].ToString();
                }

            }
            else {
                lblBoothName.Text = "No Order Found";
                lblName.Text = string.Empty;
                lblCreatedBy.Text = string.Empty;
                lblTotalBill.Text = string.Empty;
                lblCancelBooth.Text = string.Empty;
            }
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            divDanger.Visible = false;
            divwarning.Visible = false;
            divSusccess.Visible = false;
            
            pnlError.Update();

            DS = new DataSet();
            rpOrderList.DataSource = DS;
            rpOrderList.DataBind();

            lblBoothName.Text = "No Order Found";
            lblName.Text = string.Empty;
            lblCreatedBy.Text = string.Empty;
            lblTotalBill.Text = string.Empty;
            lblCancelBooth.Text = string.Empty;
        }
    }
}