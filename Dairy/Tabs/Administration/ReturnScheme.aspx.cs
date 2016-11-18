using Bussiness;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dairy.Tabs.Administration
{
    public partial class ReturnScheme : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                bindDropDown();
                txtOrderDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
            }

        }

        private void bindDropDown()
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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            DataSet DS = new DataSet();
            Invoice invoice = new Invoice();
            InvoiceData invoiceData = new InvoiceData();

            invoice.orderDate = Convert.ToDateTime(txtOrderDate.Text).ToString("dd-MM-yyyy");
            invoice.ROuteID = Convert.ToInt32(dpagentRoute.SelectedItem.Value);

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
            bool result = false ;
            result = invoiceData.returnSchemeAmount(orderid);

            if (result)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Scheme returned successfully..!!')", true);
                
                DataSet DS = new DataSet();
                Invoice invoice = new Invoice();
                //InvoiceData invoiceData = new InvoiceData();

                invoice.orderDate = Convert.ToDateTime(txtOrderDate.Text).ToString("dd-MM-yyyy");
                invoice.ROuteID = Convert.ToInt32(dpagentRoute.SelectedItem.Value);

                DS = invoiceData.GetSchemeRoutewise(invoice);
                if (!Comman.Comman.IsDataSetEmpty(DS))
                {

                    rpRouteList.DataSource = DS;
                    rpRouteList.DataBind();
                    rpRouteList.Visible = true;


                    uprouteList.Update();

                }
                else {
                    rpRouteList.Visible = false;
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No Scheme Available')", true);
                }
            }

        }
    }
}