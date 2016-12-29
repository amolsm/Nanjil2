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
    public partial class EditReturnScheme : System.Web.UI.Page
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
            int flag = 0;
            DS = billdata.GetEditReturnSchemeDetails((Convert.ToDateTime(txtDate.Text)).ToString("dd-MM-yyyy"), Convert.ToInt32(dpRoute.SelectedItem.Value),flag);


            rpOrderList.DataSource = DS;
            rpOrderList.DataBind();
        }
        protected void rpOrderList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            divDanger.Visible = false;
            divwarning.Visible = false;
            divSusccess.Visible = false;
            pnlError.Update();
            int orderid = 0;
            orderid = Convert.ToInt32(e.CommandArgument);


            switch (e.CommandName)
            {
                case ("Edit"):
                    {
                        string confirmValue = Request.Form["confirm_value"];
                        if (confirmValue == "Yes")
                        {
                            hOrderId.Value = orderid.ToString();
                            orderid = Convert.ToInt32(hOrderId.Value);

                            AddSchemeOnRollback(orderid);


                        }
                        break;
                    }
                case ("delete"):
                    {
                        break;
                    }


            }
        }

        private void AddSchemeOnRollback(int orderid)
        {
            InvoiceData invoiceData = new InvoiceData();
            bool result = false;
            
            result = invoiceData.AddSchemeOnRollback(orderid);

            if (result)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Scheme rollback successfully..!!')", true);
                bindList();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Scheme not rolledback..!!')", true);
                bindList();
            }
            }

        }
    }

