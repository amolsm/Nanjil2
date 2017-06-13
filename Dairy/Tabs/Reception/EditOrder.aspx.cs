using Bussiness;
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
    public partial class EditOrder : System.Web.UI.Page
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
                DS = BindCommanData.BindCommanDropDwon("CategoryId", "CategoryName as Name", "Category", "IsActive=1");
                if (!Comman.Comman.IsDataSetEmpty(DS))
                {
                    dpBrand.DataSource = DS;
                    dpBrand.DataBind();
                    dpBrand.Items.Insert(0, new ListItem("--All Brand--", "0"));
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

            DS = billdata.GetOrdersForEdit((Convert.ToDateTime(txtDate.Text)).ToString("dd-MM-yyyy"), Convert.ToInt32(dpRoute.SelectedItem.Value), Convert.ToInt32(dpBrand.SelectedValue));


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
                        GetDetails(Id);
                        
                        //uprouteList.Update();
                        break;
                    }
                case ("delete"):
                    {

                        hbankId.Value = Id.ToString();
                        Id = Convert.ToInt32(hbankId.Value);
                       
                        uprouteList.Update();
                        break;

                    }


            }

        }

        private void GetDetails(int id)
        {
            DS = new DataSet();
            billdata = new BillData();
            int flag = 1;
            double qty = 0;
            DS = billdata.GetOrdersbyOrderDetailsId(id,flag,qty);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                if (!string.IsNullOrEmpty(DS.Tables[0].Rows[0]["ProductName"].ToString()))
                {
                    txtName.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["EmployeeName"].ToString()) ? DS.Tables[0].Rows[0]["AgentName"].ToString() : DS.Tables[0].Rows[0]["EmployeeName"].ToString();
                    txtProductName.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["ProductName"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["ProductName"].ToString();
                    txtPrvQuantity.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Qty"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Qty"].ToString();
                    txtNewQuantity.Text = string.Empty;
                    //txtIfsc.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["IFSCcode"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["IFSCcode"].ToString();
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                }
                else {
                    
                     flag = 3;
                   
                    int result = billdata.EditOrders(id, flag, qty);
                    if (result > 0)
                    {

                        divDanger.Visible = false;
                        divwarning.Visible = false;
                        divSusccess.Visible = true;
                        lblSuccess.Text = "Edited  Successfully";
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

        protected void btnCloseModal_Click(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            
                DS = new DataSet();
                billdata = new BillData();
                int id = Convert.ToInt32(hbankId.Value);
            int result = 0;
                
                double qty = string.IsNullOrEmpty(txtNewQuantity.Text)? 0: Convert.ToDouble(txtNewQuantity.Text);
            if (qty != 0)
            {
                int flag = 2;
                result = billdata.EditOrders(id, flag, qty);
            }
            else
            {
                int flag = 4;
                result = billdata.EditOrders(id, flag, qty);
            }

                if (result > 0)
                {

                    divDanger.Visible = false;
                    divwarning.Visible = false;
                    divSusccess.Visible = true;
                    lblSuccess.Text = "Edited  Successfully";
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