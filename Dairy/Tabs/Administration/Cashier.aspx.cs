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
            DataSet ds = new DataSet();
            DispatchData dispatchData = new DispatchData();
            string Date = Convert.ToDateTime(txtOrderDate.Text).ToString("dd-MM-yyyy");
          
            int salesmanid = Convert.ToInt32(dpSalesman.SelectedItem.Value);
            ds = dispatchData.GetCashier(Date, salesmanid);
            if (!Comman.Comman.IsDataSetEmpty(ds))
            {
                try
                {
                    ds.Tables[0].PrimaryKey = new[] { ds.Tables[0].Columns["DI_SalesmanFirstId"] };
                }
                catch (Exception) { }
                try
                {
                    ds.Tables[1].PrimaryKey = new[] { ds.Tables[1].Columns["DI_SalesmanFirstId"] };
                }
                catch (Exception) { }

                try
                {
                    ds.Tables[0].Merge(ds.Tables[1], false, MissingSchemaAction.Add);
                }
                catch (Exception) { }
                if (ds.Tables[0].Rows.Count != 0)
                {
                    DataSet tds = new DataSet();
                    //Create transaction details  DataTable.
                    DataTable tbl = new DataTable();
                    // tbl = ds.Tables.Add("Transaction");
                    tbl.Columns.Add("SalesmanId", typeof(int));
                    tbl.Columns.Add("StaffAccount", typeof(double));
                    tbl.Columns.Add("AgentAccount", typeof(double));
                    tbl.Columns.Add("TotalSaleAmount", typeof(double));

                    foreach (DataRow row in ds.Tables[2].Rows)
                    {
                        foreach (DataRow rows in ds.Tables[0].Rows)
                        {

                            if (row["DI_SalesmanFirstId"].ToString() == rows["DI_SalesmanFirstId"].ToString())
                            {
                                double totalsalesamt = 0.00;
                                double agentaccount = 0.00;
                                double staffaccount = 0.00;
                                DataRow trow = tbl.NewRow();
                                trow["SalesmanId"] = rows["DI_SalesmanFirstId"];


                                try { agentaccount = Convert.ToDouble(rows["AgencySale"]); }
                                catch { agentaccount = 0.00; }
                                trow["AgentAccount"] = agentaccount;
                                totalsalesamt += agentaccount;

                                try { staffaccount = Convert.ToDouble(rows["EmployeeSale"]); }
                                catch { staffaccount = 0.00; }
                                trow["StaffAccount"] = staffaccount;
                                totalsalesamt += staffaccount;

                                trow["TotalSaleAmount"] = totalsalesamt;



                                tbl.Rows.Add(trow);

                            }

                        }
                    }
                    tds.Tables.Add(tbl);
                    rpRouteList.DataSource = tds;
                    rpRouteList.DataBind();
                    //rpBrandInfo.Visible = true;
                    uprouteList.Update();


                }
               

            }
            else
            {
                DataTable dt = new DataTable();
                this.BindRepeater(dt);
                rpRouteList.Visible = true;
                uprouteList.Update();

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