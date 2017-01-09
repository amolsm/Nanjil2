using Bussiness;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dairy.Tabs.Administration
{
    public partial class Cashier : System.Web.UI.Page
    {
        DataSet DS = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                BindDropDwon();
            }

        }


        public void BindDropDwon()
        {
            DS = BindCommanData.BindCommanDropDwon("EmployeeID", "EmployeeCode+' '+EmployeeName as Name", "employeemaster", "IsArchive=0 and (Designation='Sales Man' or Designation='Driver')");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpSalesman.DataSource = DS;
                dpSalesman.DataBind();
                dpSalesman.Items.Insert(0, new ListItem("Agent Sales Person", "0"));


            }
            txtOrderDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));

        }


        protected void btnSearch_Click(object sender, EventArgs e)
        {
            double agentcredit = 0.00;
            double emp = 0.00;
            double agentcash = 0.00;
            double totalsales = 0.00;
            DataSet ds = new DataSet();
            DispatchData dispatchData = new DispatchData();
            string Date = Convert.ToDateTime(txtOrderDate.Text).ToString("dd-MM-yyyy");
          
            int salesmanid = Convert.ToInt32(dpSalesman.SelectedItem.Value);
            ds = dispatchData.GetCashier(Date, salesmanid);
            if (!Comman.Comman.IsDataSetEmpty(ds) )
            {
                if (ds.Tables[3].Rows.Count != 0)
                {
                    rpRouteList.DataSource = ds.Tables[3];
                    rpRouteList.DataBind();
                    uprouteList.Update();
                }
                else
                {
                    DataTable dt = new DataTable();
                    this.BindRepeater(dt);
                    rpRouteList.Visible = true;
                    uprouteList.Update();
                }
             
                
                try {
                    agentcredit = Convert.ToDouble(ds.Tables[0].Rows[0]["AgencySale"]);
                } catch { agentcredit = 0.00; }
                try
                {
                    agentcash = Convert.ToDouble(ds.Tables[1].Rows[0]["AgencySale"]);
                }
                catch { agentcash = 0.00; }
                try
                {
                    emp = Convert.ToDouble(ds.Tables[2].Rows[0]["EmployeeSale"]);
                }
                catch { emp = 0.00; }
                totalsales = agentcredit+agentcash + emp;
                Label1.Text = totalsales.ToString();
                Label2.Text = emp.ToString();
                Label3.Text = agentcredit.ToString();
                Label4.Text = agentcash.ToString();

            }
            else
            {
                DataTable dt = new DataTable();
                this.BindRepeater(dt);
                rpRouteList.Visible = true;
                uprouteList.Update();
                Label1.Text = string.Empty;
                Label2.Text = string.Empty;
                Label3.Text = string.Empty;
                Label4.Text = string.Empty ;
            }

        }

       

        private void BindRepeater(DataTable dt)
        {
            rpRouteList.DataSource = dt;
            rpRouteList.DataBind();

            if (dt.Rows.Count == 0)
            {
                Control FooterTemplate = rpRouteList.Controls[rpRouteList.Controls.Count - 1].Controls[0];
                FooterTemplate.FindControl("trEmpty").Visible = true;
            }

        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        protected void rpRouteList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            divDanger.Visible = false;
            divwarning.Visible = false;
            divSusccess.Visible = false;
            pnlError.Update();
            int salesmanid = 0;
            salesmanid = Convert.ToInt32(e.CommandArgument);


            switch (e.CommandName)
            {
                case ("Edit"):
                    {
                        //lbltital.Text = "Edit Route";
                        hfRow.Value = salesmanid.ToString();
                        salesmanid = Convert.ToInt32(hfRow.Value);
                        //BindRouteList();

                      //  GetRouteDetailsbyID(salesmanid);
                        //btnAddRoute.Visible = false;
                        //btnupdateroute.Visible = true;
                        // upMain.Update();
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "<script type='text/javascript'> $('#myModal').modal('show'); </script>", false);
                        // uprouteList.Update();
                        //  upModal.Update();
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
    }
}