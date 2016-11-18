using System;
using System.Collections.Generic;
using System.Data;
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
using DataAcess;
using System.Web.Services;
using System.Data.SqlClient;
using System.Configuration;

namespace Dairy.Tabs.Administration
{
    public partial class PlaceOrderEmpRoutewise : System.Web.UI.Page
    { 
        string result = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDwon();
                hftokanno.Value = Comman.Comman.RandomString();
                txtGentOrderDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
            }
        }
        private void BindDropDwon()
        {
            DataSet DS = new DataSet();
            DS = BindCommanData.BindCommanDropDwon("RouteID ", "RouteCode +' '+RouteName as Name  ", "routeMaster", "IsArchive=1 ");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpagentRoute.DataSource = DS;
                dpagentRoute.DataBind();
                dpagentRoute.Items.Insert(0, new ListItem("--Select Agent Route  --", "0"));

            }
        }
        protected void btnGetPreviousOrder_Click(object sender, EventArgs e)
        {
            double consume = 0;
            DataSet DS = new DataSet();
            Invoice invoice = new Invoice();
            Invoice invocie = new Invoice();
            InvoiceData invoiceData = new InvoiceData();
            invoice.ROuteID = Convert.ToInt32(dpagentRoute.SelectedItem.Value);
            invoice.orderDate = (Convert.ToDateTime(txtGentOrderDate.Text)).ToString("dd-MM-yyyy");
            DS = invoiceData.GetPreviousDayOrderRouteWiseEmp(invoice);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                 rpAgentOrderdetails.Visible = true;
                 foreach (DataRow row in DS.Tables[0].Rows)
                 {
                     DataSet DS2 = new DataSet();
                     Product product = new Product();
                     ProductData productData = new ProductData();
                     product.AgencyID = 1;
                     product.EmployeeId = string.IsNullOrEmpty(row["EmployeeID"].ToString()) ? 0 : Convert.ToInt32(row["EmployeeID"]);
                     product.orderDate = DateTime.Now.ToString("dd-MM-yyyy").ToString();
                     DS2 = productData.GetTotalCount(product);
                     if (!Comman.Comman.IsDataSetEmpty(DS2))
                     {
                         consume = string.IsNullOrEmpty(DS2.Tables[0].Rows[0]["count"].ToString()) ? 0 : Convert.ToDouble(DS2.Tables[0].Rows[0]["count"]);
                     }
                     else
                     {
                         consume = 0;
                     }
                     invocie.TokanId = hftokanno.Value;
                     invocie.UserID = GlobalInfo.Userid;
                     invocie.AgentName = Convert.ToString(row["EmployeeName"]);
                     invocie.ProductID = string.IsNullOrEmpty(row["ProductID"].ToString()) ? 0 : Convert.ToInt32(row["ProductID"]);
                     invocie.qty = string.IsNullOrEmpty(row["Qty"].ToString()) ? 0 : Convert.ToDouble(row["Qty"]);
                                            
                     invocie.TypeID = string.IsNullOrEmpty(row["TypeID"].ToString()) ? 0 : Convert.ToInt32(row["TypeID"]);
                     invocie.AgencyID = string.IsNullOrEmpty(row["EmployeeID"].ToString()) ? 0 : string.IsNullOrEmpty(row["EmployeeID"].ToString()) ? 0 : Convert.ToInt32(row["EmployeeID"]);
                     invocie.orderid = string.IsNullOrEmpty(row["OrderID"].ToString()) ? 0 : Convert.ToInt32(row["OrderID"]);
                     invocie.ROuteID = string.IsNullOrEmpty(row["RouteID"].ToString()) ? 0 : Convert.ToInt32(row["RouteID"]);
                     invocie.ShecemeApplied = Convert.ToBoolean(row["ShcemheApplied"]);
                     invocie.AgentCode = string.IsNullOrEmpty(row["EmployeeCode"].ToString()) ? string.Empty : Convert.ToString(row["EmployeeCode"]);
                    invocie.BillSeq = string.IsNullOrEmpty(row["BillSeq"].ToString()) ? 0 : Convert.ToInt32(row["BillSeq"]);
                    if (consume > 30)
                     {
                         double price = 0;
                         double qty = 0;
                         Invoice inv = new Invoice();
                         DataSet ds4 = new DataSet();
                         inv.ProductID = string.IsNullOrEmpty(row["ProductID"].ToString()) ? 0 : Convert.ToInt32(row["ProductID"]);
                         ds4 = invoiceData.getBulkEmpSlabPrice(inv);
                         if (!Comman.Comman.IsDataSetEmpty(ds4))
                         {
                             price = string.IsNullOrEmpty(ds4.Tables[0].Rows[0]["price"].ToString()) ? 0 : Convert.ToDouble(ds4.Tables[0].Rows[0]["price"]);

                         }
                         qty = string.IsNullOrEmpty(row["Qty"].ToString()) ? 0 : Convert.ToDouble(row["Qty"]);


                         invocie.UnitCost = price;
                         invocie.totalCoast = price * qty;
                     
                     }
                     else
                     {
                         invocie.UnitCost = string.IsNullOrEmpty(row["UnitCost"].ToString()) ? 0 : Convert.ToDouble(row["UnitCost"]);
                         invocie.totalCoast = string.IsNullOrEmpty(row["Total"].ToString()) ? 0 : Convert.ToDouble(row["Total"]);
                     
                     }

                     invoiceData.InsertTempBulkItam(invocie);
                     BindAgntTempItam(invocie);

                 }
            }
        }

        private void BindAgntTempItam(Invoice invocie)
        {
            InvoiceData invicedata = new InvoiceData();
            rpAgentOrderdetails.DataSource = invicedata.GetBulkTempItam(invocie);
            rpAgentOrderdetails.DataBind();
        }
        protected void btnAgentORderSubmit_Click(object sender, EventArgs e)
        {
            updateOrderID();
            submitOrders();
            updateBillno();
        }
        private void updateOrderID()
        {
            DataSet DS = new DataSet();
            Invoice invoice = new Invoice();
            Invoice invocie = new Invoice();
            InvoiceData invoiceData = new InvoiceData();
            invocie.TokanId = hftokanno.Value;
            invocie.UserID = GlobalInfo.Userid;
            DS = invoiceData.GetDetailsforUpdateOrderID(invocie);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                DS.Tables[0].Columns.Add("NewOrderID", typeof(int));
                int newID = Convert.ToInt32(DS.Tables[1].Rows[0]["MaxID"]);
                newID = newID + 1;
                for (int i = 0; i <= DS.Tables[0].Rows.Count - 1; i++)
                {
                    DS.Tables[0].Rows[i]["NewOrderID"] = newID;
                    newID++;
                }

                foreach (DataRow row in DS.Tables[0].Rows)
                {
                    int ids = Convert.ToInt32(row["OrderID"]);
                    int newid = Convert.ToInt32(row["NewOrderID"]);
                    bool x = invoiceData.UpdateOrderID(ids, newid);
                }
            }
        }

        private void submitOrders()
        {
            DataSet DS = new DataSet();
            Invoice invoice = new Invoice();
            Invoice invocie = new Invoice();
            InvoiceData invoiceData = new InvoiceData();
            invocie.TokanId = hftokanno.Value;
            invocie.UserID = GlobalInfo.Userid;
            DS = invoiceData.GetOrdersForSubmit(invocie);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                try
                {
                    DS.Tables[0].Columns.Add("OrderDate", typeof(string));
                    string orderDate = (Convert.ToDateTime(txtGentOrderDate.Text)).ToString("dd-MM-yyyy");
                    for (int i = 0; i <= DS.Tables[0].Rows.Count - 1; i++)
                    {
                        DS.Tables[0].Rows[i]["OrderDate"] = orderDate;
                    }

                    DS.Tables[0].Columns.Add("CreatedDate", typeof(string));
                    string createdDate = DateTime.Now.ToString("MM-dd-yyyy");
                    for (int i = 0; i <= DS.Tables[0].Rows.Count - 1; i++)
                    {
                        DS.Tables[0].Rows[i]["CreatedDate"] = createdDate;
                    }

                    DS.Tables[0].Columns.Add("CreatedBy", typeof(int));
                    int createdby = GlobalInfo.Userid;
                    for (int i = 0; i <= DS.Tables[0].Rows.Count - 1; i++)
                    {
                        DS.Tables[0].Rows[i]["CreatedBy"] = createdby;
                    }
                    DS.Tables[0].Columns.Add("OrderType", typeof(int));
                    int OrderType = 2;
                    for (int i = 0; i <= DS.Tables[0].Rows.Count - 1; i++)
                    {
                        DS.Tables[0].Rows[i]["OrderType"] = OrderType;
                    }
                    string consString = ConfigurationManager.ConnectionStrings["projectConnection"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(consString))
                    {
                        using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                        {
                            //Set the database table name
                            sqlBulkCopy.DestinationTableName = "OrderMaster";

                            //[OPTIONAL]: Map the DataTable columns with that of the database table
                            sqlBulkCopy.ColumnMappings.Add("AgentID", "EmployeeID");
                            sqlBulkCopy.ColumnMappings.Add("OrderDate", "OrderDate");
                            sqlBulkCopy.ColumnMappings.Add("RouteID", "RouteID");
                            sqlBulkCopy.ColumnMappings.Add("TotalBill", "TotalBill");
                            sqlBulkCopy.ColumnMappings.Add("CreatedBy", "CreatedBy");
                            sqlBulkCopy.ColumnMappings.Add("CreatedDate", "CreatedDate");
                            sqlBulkCopy.ColumnMappings.Add("OrderType", "OrderType");
                            sqlBulkCopy.ColumnMappings.Add("ShcemheApplied", "ShcemheApplied");
                            sqlBulkCopy.ColumnMappings.Add("BillSeq", "BillSeq");
                            con.Open();
                            sqlBulkCopy.WriteToServer(DS.Tables[0]);
                            con.Close();
                        }
                        using (SqlBulkCopy sqlBulkCopy1 = new SqlBulkCopy(con))
                        {
                            //Set the database table name
                            sqlBulkCopy1.DestinationTableName = "OrderDetails";

                            //[OPTIONAL]: Map the DataTable columns with that of the database table
                            sqlBulkCopy1.ColumnMappings.Add("NewOrderID", "OrderId");
                            sqlBulkCopy1.ColumnMappings.Add("TypeId", "TypeID");
                            sqlBulkCopy1.ColumnMappings.Add("ProductID", "ProductID");
                            sqlBulkCopy1.ColumnMappings.Add("Qty", "Qty");
                            sqlBulkCopy1.ColumnMappings.Add("UnitCost", "UnitCost");
                            sqlBulkCopy1.ColumnMappings.Add("Total", "Total");
                            con.Open();
                            sqlBulkCopy1.WriteToServer(DS.Tables[1]);
                            con.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    string e = ex.ToString();
                }

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Order Placed  Successfully";
                DataTable dt = new DataTable();
                rpAgentOrderdetails.DataSource = dt;
                rpAgentOrderdetails.DataBind();

                pnlError.Update();

                upMain.Update();
                //uprouteList.Update();
            }
        }

        private void updateBillno()
        {
            DataSet DS = new DataSet();
            InvoiceData invoiceData = new InvoiceData();
            DS = invoiceData.GetDetailsBulkBillNo();
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                foreach (DataRow row in DS.Tables[0].Rows)
                {
                    int ids = Convert.ToInt32(row["OrderID"]);
                    string orderdate = Convert.ToString(row["OrderDate"]);
                    bool x = invoiceData.updateBillNo(ids, orderdate);
                }
            }
        }

        protected void rpOrderitam_ItemCommand(object sender, RepeaterCommandEventArgs e)
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
                        getBulkOrderDetailsForEdit(Id);
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "<script type='text/javascript'> $('#myModal').modal('show'); </script>", false);
                        
                        break;
                    }
                case ("delete"):
                    {

                        
                        DeleteOrderItems(Id);
                        //upMain.Update();
                        break;

                    }


            }
        }
        private void DeleteOrderItems(int Id)
        {
            InvoiceData invoiceData = new InvoiceData();
            bool result = invoiceData.DeleteBulkOrderItems(Id);
            if (result)
            {
                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Order Item Deleted Successfully";
                pnlError.Update();
                binddetails();
                upMain.Update();
            }
        }
        private void getBulkOrderDetailsForEdit(int Id)
        {
            DataSet DS = new DataSet();
            //Invoice invoice = new Invoice();

            InvoiceData invoiceData = new InvoiceData();

            DS = invoiceData.getBulkOrderDetailsForEdit(Id);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                txtAgentID.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["AgentCode"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["AgentCode"].ToString();
                txtAgentName.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["AgentName"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["AgentName"].ToString();
                txtProductName.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["ProductName"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["ProductName"].ToString();
                txtUnitPrice.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["UnitCost"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["UnitCost"].ToString();
                txtQuantity.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Qty"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Qty"].ToString();
                txtHidden.Text = Id.ToString();

            }
        }
        protected void rpOrderitam_OnDataBinding(object sender, RepeaterItemEventArgs e)
        {


        }

        protected void btnSaveChanges_Click(object sender, EventArgs e)
        {
            DataSet DS = new DataSet();
            Invoice invoice = new Invoice();

            InvoiceData invoiceData = new InvoiceData();

            invoice.ID = Convert.ToInt32(txtHidden.Text);
            invoice.qty = Convert.ToDouble(txtQuantity.Text);
            invoice.totalCoast = Convert.ToDouble(txtUnitPrice.Text) * Convert.ToDouble(txtQuantity.Text);
            bool result = invoiceData.UpdateBulkOrderEditItem(invoice);
            if (result)
            {
                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Order Item Edited Successfully";
                pnlError.Update();
                binddetails();
                upMain.Update();
            }
        }
        private void binddetails()
        {
            Invoice inv = new Invoice();
            inv.UserID = GlobalInfo.Userid;
            inv.TokanId = hftokanno.Value;
            BindAgntTempItam(inv);
        }
    }
}