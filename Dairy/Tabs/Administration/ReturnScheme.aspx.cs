using Bussiness;
using Dairy.App_code;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dairy.Tabs.Administration
{
    public partial class ReturnScheme : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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

            if (!IsPostBack)
            {


            }

        }



        protected void btnSearch_Click(object sender, EventArgs e)
        {
            DataSet DS = new DataSet();
            Invoice invoice = new Invoice();
            InvoiceData invoiceData = new InvoiceData();

            //invoice.orderDate = Convert.ToDateTime(txtOrderDate.Text).ToString("dd-MM-yyyy");
            //invoice.ROuteID = Convert.ToInt32(dpagentRoute.SelectedItem.Value);

            invoice.ID = Convert.ToInt32(txtDispatchId.Text);

            DS = invoiceData.GetSchemeRoutewise(invoice);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {

                rpRouteList.DataSource = DS;
                rpRouteList.DataBind();
                rpRouteList.Visible = true;


                uprouteList.Update();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "av", "$('#example1').DataTable();", true);
            }
            else
            {
                rpRouteList.Visible = false;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No Scheme Available')", true);
            }
        }

        protected void rpRouteList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

            divDanger.Visible = false;
            divwarning.Visible = false;
            divSusccess.Visible = false;
            pnlError.Update();
            int orderid = 0;
            orderid = Convert.ToInt32(e.CommandArgument);


            switch (e.CommandName)
            {
                case ("Return"):
                    {
                        // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "confirmMsg", "Confirm() { var confirm_value = document.createElement('INPUT'); confirm_value.type = 'hidden'; confirm_value.name = 'confirm_value'; if (confirm('Do you want to save data?')) { confirm_value.value = 'Yes';} else { confirm_value.value = 'No'; } document.forms[0].appendChild(confirm_value); }", true);

                        string confirmValue = Request.Form["confirm_value"];
                        if (confirmValue == "Yes")
                        {
                            hfRow.Value = orderid.ToString();
                            orderid = Convert.ToInt32(hfRow.Value);

                            deleteScheme(orderid);


                        }



                        // uprouteList.Update();
                        //  upModal.Update();
                        break;
                    }
                case ("delete"):
                    {
                        break;
                    }


            }
        }

        private void deleteScheme(int orderid)
        {
            InvoiceData invoiceData = new InvoiceData();
            bool result = false;
            int returnBy = GlobalInfo.Userid;
            result = invoiceData.returnSchemeAmount(orderid, returnBy);

            if (result)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Scheme returned successfully..!!')", true);

                DataSet DS = new DataSet();
                Invoice invoice = new Invoice();
                //InvoiceData invoiceData = new InvoiceData();


                invoice.ID = Convert.ToInt32(txtDispatchId.Text);
                DS = invoiceData.GetSchemeRoutewise(invoice);
                if (!Comman.Comman.IsDataSetEmpty(DS))
                {

                    rpRouteList.DataSource = DS;
                    rpRouteList.DataBind();
                    rpRouteList.Visible = true;


                    uprouteList.Update();

                }
                else
                {
                    rpRouteList.Visible = false;
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No Scheme Available')", true);
                }
            }

        }
    }
}