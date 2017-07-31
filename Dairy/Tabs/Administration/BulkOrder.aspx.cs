using Bussiness;
using Dairy.App_code;
using DataAccess.Admin;
using Model.Admin;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dairy.Tabs.Administration
{
    public partial class BulkOrder : System.Web.UI.Page
    {
        static int Row = -1;
        static string date=string.Empty;
        static string routenam = string.Empty;
        static string routeid = string.Empty;
        static string typename = string.Empty;
        static string typeid = string.Empty;
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDown();
                hftokanno.Value = Comman.Comman.RandomString();
                btnRefresh.Visible = false;
                btnSubmit.Visible = false;
                txtDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
            }
        }

        private void BindDropDown()
        {
            DataSet DS = new DataSet();
            DS = BindCommanData.BindCommanDropDwon("RouteID ", "RouteCode +' '+RouteName as Name  ", "routeMaster", "IsArchive=1 ");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpRoute.DataSource = DS;
                dpRoute.DataBind();
                dpRoute.Items.Insert(0, new ListItem("--Select Route--", "0"));

            }
        }

        protected void btnGetPreviousOrder_Click(object sender, EventArgs e)
        {
            DataSet DS = new DataSet();
            Bulk b = new Bulk();
            DbBulk dbBulk = new DbBulk();
            b.RouteId = Convert.ToInt32(dpRoute.SelectedItem.Value);
            b.OrderDate = (Convert.ToDateTime(txtDate.Text)).ToString("dd-MM-yyyy");
            b.Type = Convert.ToInt32(dpType.SelectedItem.Value);
            DS = dbBulk.GetPreviousOrders(b);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "1", "<script type='text/javascript'> $('#MainContent_dpRoute').attr('disabled', 'disabled'); </script>", false);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "2", "<script type='text/javascript'> $('#MainContent_dpType').attr('disabled', 'disabled'); </script>", false);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "3", "<script type='text/javascript'> $('#MainContent_txtDate').attr('disabled', 'disabled'); </script>", false);
                string nm = GlobalInfo.UserName.ToString();

                DS.WriteXml(Server.MapPath("~/Tabs/Dispatch/Bulk" + nm + ".xml"));

                btnRefresh.Visible = true;
                btnGetPreviousOrder.Visible = false;
                btnSubmit.Visible = true;
                rpAgentOrderdetails.Visible = true;

                BindRepeaterCart();
                date = txtDate.Text.ToString();
                routenam = dpRoute.SelectedItem.Text;
                routeid = dpRoute.SelectedItem.Value;
                typename = dpType.SelectedItem.Text;
                typeid = dpType.SelectedItem.Value; 





            }
            else
            {
                DataTable dt = new DataTable();
                this.BindRepeater(dt);
                rpAgentOrderdetails.Visible = true;
                upMain.Update();
                date = txtDate.Text.ToString();
            

            }
        }

        private void BindRepeaterCart()
        {
            DataSet ds = new DataSet();
            string nm = GlobalInfo.UserName.ToString();
            ds.ReadXml(Server.MapPath("~/Tabs/Dispatch/Bulk" + nm + ".xml"));
            if (!Comman.Comman.IsDataSetEmpty(ds))
            {
                DataColumnCollection columns = ds.Tables[0].Columns;
                if (!columns.Contains("AgentID"))
                {
                    ds.Tables[0].Columns.Add("AgentID", typeof(string));

                    for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                    {
                        ds.Tables[0].Rows[i]["AgentID"] = string.Empty;
                    }
                }
                rpAgentOrderdetails.DataSource = ds;
                rpAgentOrderdetails.DataBind();
            }
        }

        private void BindRepeater(DataTable dt)
        {
            rpAgentOrderdetails.DataSource = dt;
            rpAgentOrderdetails.DataBind();

            if (dt.Rows.Count == 0)
            {
                Control FooterTemplate = rpAgentOrderdetails.Controls[rpAgentOrderdetails.Controls.Count - 1].Controls[0];
                FooterTemplate.FindControl("trEmpty").Visible = true;
            }

        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            DataSet DS = new DataSet();
            string nm = GlobalInfo.UserName.ToString();
            DS.ReadXml(Server.MapPath("~/Tabs/Dispatch/Bulk" + nm + ".xml"));

            DS.Tables[0].Columns.Add("NewDate", typeof(string));
            string orderDate = (Convert.ToDateTime(txtDate.Text)).ToString("dd-MM-yyyy");
            for (int i = 0; i <= DS.Tables[0].Rows.Count - 1; i++)
            {
                DS.Tables[0].Rows[i]["NewDate"] = orderDate;
            }

            DS.Tables[0].Columns.Add("NewCreatedDate", typeof(string));
            string createdDate = DateTime.Now.ToString("dd-MM-yyyy");
            for (int i = 0; i <= DS.Tables[0].Rows.Count - 1; i++)
            {
                DS.Tables[0].Rows[i]["NewCreatedDate"] = createdDate;
            }

            DS.Tables[0].Columns.Add("Userid", typeof(int));
            int createdby = GlobalInfo.Userid;
            for (int i = 0; i <= DS.Tables[0].Rows.Count - 1; i++)
            {
                DS.Tables[0].Rows[i]["Userid"] = createdby;
            }
            DS.Tables[0].Columns.Add("NewOrderType", typeof(int));
            int OrderType = Convert.ToInt32(dpType.SelectedItem.Value);
            for (int i = 0; i <= DS.Tables[0].Rows.Count - 1; i++)
            {
                DS.Tables[0].Rows[i]["NewOrderType"] = OrderType;
            }
            DS.Tables[0].Columns.Add("Tokan", typeof(string));
            string tokan = hftokanno.Value;
            for (int i = 0; i <= DS.Tables[0].Rows.Count - 1; i++)
            {
                DS.Tables[0].Rows[i]["Tokan"] = tokan;
            }

            string consString = ConfigurationManager.ConnectionStrings["projectConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(consString))
            {
                using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                {
                    //Set the database table name
                    sqlBulkCopy.DestinationTableName = "TempBulkOrder";

                    //[OPTIONAL]: Map the DataTable columns with that of the database table
                    sqlBulkCopy.ColumnMappings.Add("Userid", "UserId");
                    sqlBulkCopy.ColumnMappings.Add("Tokan", "Tokan");
                    sqlBulkCopy.ColumnMappings.Add("TypeId", "TypeId");
                    sqlBulkCopy.ColumnMappings.Add("ProductId", "ProductId");
                    sqlBulkCopy.ColumnMappings.Add("Qty", "Qty");
                    sqlBulkCopy.ColumnMappings.Add("UnitCost", "UnitCost");
                    sqlBulkCopy.ColumnMappings.Add("Total", "Total");
                    sqlBulkCopy.ColumnMappings.Add("TotalBill", "TotalBill");
                    sqlBulkCopy.ColumnMappings.Add("RouteID", "RouteID");
                    if (dpType.SelectedItem.Value == "1")
                        sqlBulkCopy.ColumnMappings.Add("AgentID", "AgentID");
                    if (dpType.SelectedItem.Value == "2")
                        sqlBulkCopy.ColumnMappings.Add("EmployeeID", "EmployeeID");
                    sqlBulkCopy.ColumnMappings.Add("OrderID", "OrderId");
                    sqlBulkCopy.ColumnMappings.Add("NewDate", "OrderDate");
                    sqlBulkCopy.ColumnMappings.Add("NewCreatedDate", "CreatedDate");
                    sqlBulkCopy.ColumnMappings.Add("NewOrderType", "OrderType");
                    con.Open();
                    sqlBulkCopy.WriteToServer(DS.Tables[0]);
                    con.Close();
                }
            }

            //asdf
            Bulk b = new Bulk();
            DbBulk dbBulk = new DbBulk();
            b.Tokan = hftokanno.Value.ToString();
            b.UserId = GlobalInfo.Userid;
            if (dpType.SelectedItem.Value == "1")
                b.Flag = "Agent";
            if (dpType.SelectedItem.Value == "2")
                b.Flag = "Employee";

            int result = dbBulk.SubmitBulkOrders(b);
            if (result > 0)
            {
                btnSubmit.Visible = false;
                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Orders Placed  Successfully";
                DataTable dt = new DataTable();
                rpAgentOrderdetails.DataSource = dt;
                rpAgentOrderdetails.DataBind();

                pnlError.Update();

                upMain.Update();
            }
            else
            {
                btnSubmit.Visible = false;
                divDanger.Visible = true;
                divwarning.Visible = false;
                divSusccess.Visible = false;
                lbldanger.Text = "Something went wrong.. Please Contact Admin";
                DataTable dt = new DataTable();
                rpAgentOrderdetails.DataSource = dt;
                rpAgentOrderdetails.DataBind();

                pnlError.Update();

                upMain.Update();
            }
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Tabs/Administration/BulkOrder.aspx");

        }

        protected void btnSaveModal_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string nm = GlobalInfo.UserName.ToString();
            ds.ReadXml(Server.MapPath("~/Tabs/Dispatch/Bulk" + nm + ".xml"));
            Row = Convert.ToInt32(hfRow.Value);
            Row = Row - 1;
            if (!Comman.Comman.IsDataSetEmpty(ds))
            {
                double qty = Convert.ToDouble(txtQuantity.Text);
                double unitprice = Convert.ToDouble(ds.Tables[0].Rows[Row]["UnitCost"]);
                double tot = qty * unitprice;
                int orderid = Convert.ToInt32(ds.Tables[0].Rows[Row]["OrderID"]);
                double sum = 0;
               

                ds.Tables[0].Rows[Row]["Qty"] = qty.ToString();
                ds.Tables[0].Rows[Row]["Total"] = tot.ToString();

                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    if (item["OrderID"].ToString() == orderid.ToString())
                    {
                        sum = sum + Convert.ToDouble(item["Total"]);
                    }
                }
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    if (item["OrderID"].ToString() == orderid.ToString())
                    {
                        item["TotalBill"] = sum.ToString();
                    }
                }
                ds.WriteXml(Server.MapPath("~/Tabs/Dispatch/Bulk" + nm + ".xml"));

                BindRepeaterCart();
                upMain.Update();
            }
        }

       

        protected void rpAgentOrderdetails_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
          
            Row = Convert.ToInt32(e.CommandArgument);
            switch (e.CommandName)
            {
                case ("Edit"):
                    {
                        
                        hfRow.Value = Row.ToString();
                        Row = Convert.ToInt32(hfRow.Value);
                        
                        Row = Row - 1;
                        GetDetailsbyID(Row);
                      

                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "<script type='text/javascript'> $('#myModal').modal('show'); </script>", false);
                        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myBox", "<script type='text/javascript'> $('#myBox').removeClass('collapsed-box'); </script>", false);
                        upMain.Update();

                        txtDate.Text=date;
                        dpRoute.SelectedItem.Text = routenam;
                        dpRoute.SelectedItem.Value = routeid;
                        dpType.SelectedItem.Text = typename;
                        dpType.SelectedItem.Value = typeid;
                       
                        //uprouteList.Update();
                        break;
                    }
            }
            }

        private void GetDetailsbyID(int row)
        {
                       
            DataSet DS = new DataSet();
            string nm = GlobalInfo.UserName.ToString();
            DS.ReadXml(Server.MapPath("~/Tabs/Dispatch/Bulk" + nm + ".xml"));
            
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                try
                {
                    txtAgent.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[Row]["AgentID"].ToString()) ? string.Empty: DS.Tables[0].Rows[Row]["AgentCode"].ToString() + " " + DS.Tables[0].Rows[Row]["AgentName"].ToString();
                }
                catch { txtAgent.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[Row]["EmployeeID"].ToString()) ? string.Empty : DS.Tables[0].Rows[Row]["EmployeeCode"].ToString() + " " + DS.Tables[0].Rows[Row]["EmployeeName"].ToString(); }
                txtProductName.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[Row]["ProductName"].ToString()) ? string.Empty : DS.Tables[0].Rows[Row]["ProductName"].ToString();
                txtUnitPrice.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[Row]["UnitCost"].ToString()) ? string.Empty : DS.Tables[0].Rows[Row]["UnitCost"].ToString();
                txtQuantity.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[Row]["Qty"].ToString()) ? string.Empty : DS.Tables[0].Rows[Row]["Qty"].ToString();
               

            }
        }
    }
}