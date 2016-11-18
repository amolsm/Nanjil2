using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using Bussiness;

using Comman;
using System.Text;
using Dairy.App_code;
using System.Configuration;
using System.Data.SqlClient;

namespace Dairy.Tabs.Sales
{
    public partial class EmployeeBilling : System.Web.UI.Page
    {
        DataSet DS;
        double total = 0;
        public static double schemeTemp { get; set; }
        public static bool schemeApplied = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDwon();
                hftokanno.Value = Comman.Comman.RandomString();
                //txtCustamerorderDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                lblUser.Text = GlobalInfo.UserName;
                btnPrintEmp.Visible = false;
                txtEmployeeOrderDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
            }

        }
        public void BindDropDwon()
        {
            DS = new DataSet();
            //DS = BindCommanData.BindCommanDropDwon("RouteID ", "RouteCode +' '+RouteName as Name  ", "routeMaster", "IsArchive=1 ");
            //if (!Comman.Comman.IsDataSetEmpty(DS))
            //{
            //    dpagentRoute.DataSource = DS;
            //    dpagentRoute.DataBind();
            //    dpagentRoute.Items.Insert(0, new ListItem("--Select Agent Route  --", "0"));

            //dpEmploueeRoute.DataSource = DS;
            //dpEmploueeRoute.DataBind();
            //dpEmploueeRoute.Items.Insert(0, new ListItem("--Select Employee Route  --", "0"));

            //dpCustamerroute.DataSource = DS;
            //dpCustamerroute.DataBind();
            //dpCustamerroute.Items.Insert(0, new ListItem("--Select Custamer Route  --", "0"));


            //}
            //DS.Clear();
            DS = BindCommanData.BindCommanDropDwon("EmployeeID", "EmployeeCode+' '+EmployeeName as Name", "employeemaster", "IsActive=1");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                

                dpEmployee.DataSource = DS;
                dpEmployee.DataBind();
                dpEmployee.Items.Insert(0, new ListItem("--Select Employee  --", "0"));



            }



            DS.Clear();
            DS = BindCommanData.BindCommanDropDwon("TypeID", "TypeName", "TypeMaster", "IsArchive=1");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {




                dpEmployeeProductType.DataSource = DS;
                dpEmployeeProductType.DataBind();
                dpEmployeeProductType.Items.Insert(0, new ListItem("--Select Product Type  --", "0"));



            }
        }

        protected void dpEmployeeProducttype_IndexChanged(object sender, EventArgs e)
        {
            DS = new DataSet();

            //string ptype = Convert.ToString(dpEmployeeProductType.SelectedItem.Text);
            int ptype = Convert.ToInt32(dpEmployeeProductType.SelectedItem.Value);
            double count = string.IsNullOrEmpty(hfTotalCansume.Value) ? 0 : Convert.ToDouble(hfTotalCansume.Value);
            if (count > 30 && ptype == 1)
            {
                DS = BindCommanData.BindCommanDropDwon("productId", "ProductName+' '+Productcode as product", "Products", "   typeID=" + Convert.ToInt32(dpEmployeeProductType.SelectedItem.Value) + " and   IsArchive=0 and SlabID = 3 order by ProductName");
                //DS = BindCommanData.BindCommanDropDwon("Products.ProductID", "Commodity.CommodityName+' '+Products.ProductName as product", "Commodity, Products", "   Products.CommodityID = Commodity.CommodityID");

                dpEmployeeProductDetails.DataSource = DS;
                dpEmployeeProductDetails.DataBind();
                dpEmployeeProductDetails.Items.Insert(0, new ListItem("--Select Product  --", "0"));
                dpEmployeeProductDetails.Focus();
            }
            else
            {
                DS = BindCommanData.BindCommanDropDwon("productId", "ProductName+' '+Productcode as product", "Products", "   typeID=" + Convert.ToInt32(dpEmployeeProductType.SelectedItem.Value) + " and   IsArchive=0 and SlabID = 2 order by ProductName");
                //DS = BindCommanData.BindCommanDropDwon("Products.ProductID", "Commodity.CommodityName+' '+Products.ProductName as product", "Commodity, Products", "   Products.CommodityID = Commodity.CommodityID");

                dpEmployeeProductDetails.DataSource = DS;
                dpEmployeeProductDetails.DataBind();
                dpEmployeeProductDetails.Items.Insert(0, new ListItem("--Select Product  --", "0"));
                dpEmployeeProductDetails.Focus();
            }

            {
            }

            upMain.Update();
        }
        protected void dpEmployee_IndexChanged(object sender, EventArgs e)
        {
            int count = 0;
            DS = new DataSet();
            Product product = new Product();
            ProductData productData = new ProductData();
            product.AgencyID = 1;
            product.EmployeeId = Convert.ToInt32(dpEmployee.SelectedItem.Value);
            product.orderDate = DateTime.Now.ToString("dd-MM-yyyy").ToString();
            DS = productData.GetTotalCount(product);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                hfTotalCansume.Value = DS.Tables[0].Rows[0]["count"].ToString();

            }
            else
            {
                hfTotalCansume.Value = "0";
            }
            dpEmployee.Focus();
        }
        protected void dpEmployeeProductDetails_IndexChanged(object sender, EventArgs e)
        {

            DS = new DataSet();
            Invoice invoice = new Invoice();
            InvoiceData invocieDate = new InvoiceData();
            if ((dpEmployeeProductType.SelectedItem.Value) == "1") //1 for Milk 
            {
                double count = string.IsNullOrEmpty(hfTotalCansume.Value) ? 0 : Convert.ToDouble(hfTotalCansume.Value);
                if (count <= 30)
                {

                    invoice.SlabID = 2;
                    invoice.ProductID = Convert.ToInt32(dpEmployeeProductDetails.SelectedItem.Value);
                    DS = invocieDate.GetUnitPriceBysablID(invoice);
                    if (!Comman.Comman.IsDataSetEmpty(DS))
                    {
                        hfEmployeeProductUnitPrice.Value = DS.Tables[0].Rows[0]["Price"].ToString();
                    }
                    else
                    {
                        hfEmployeeProductUnitPrice.Value = "0";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Product IS not Configuer With STAFF SLAB')", true);
                    }

                }
                else
                {
                    invoice.SlabID = 3; //Milk Slab-C
                    invoice.ProductID = Convert.ToInt32(dpEmployeeProductDetails.SelectedItem.Value);
                    DS = invocieDate.GetUnitPriceBysablID(invoice);
                    if (!Comman.Comman.IsDataSetEmpty(DS))
                    {
                        hfEmployeeProductUnitPrice.Value = DS.Tables[0].Rows[0]["Price"].ToString();
                    }
                    else
                    {
                        hfEmployeeProductUnitPrice.Value = "0";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Product IS not Configuer With SLAB')", true);
                    }
                }
            }
            else
            {
                invoice.SlabID = 2; //7 for Staff Slab
                invoice.ProductID = Convert.ToInt32(dpEmployeeProductDetails.SelectedItem.Value);
                DS = invocieDate.GetUnitPriceBysablID(invoice);
                if (!Comman.Comman.IsDataSetEmpty(DS))
                {
                    hfEmployeeProductUnitPrice.Value = "0";
                    hfEmployeeProductUnitPrice.Value = DS.Tables[0].Rows[0]["Price"].ToString();
                }
                else
                {
                    hfEmployeeProductUnitPrice.Value = "0";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Product IS not Configuer With Staff SLAB')", true);
                }
            }
            dpEmployeeProductDetails.Focus();
        }




        protected void btnAddEmployeeOrderItem_clcik(object sender, EventArgs e)
        {
            double tempQty = 0;
            DataSet ds = new DataSet();

            Invoice invocie = new Invoice();
            InvoiceData invicedata = new InvoiceData();
            invocie.TokanId = hftokanno.Value;
            invocie.UserID = GlobalInfo.Userid;
            invocie.TypeID = Convert.ToInt32(dpEmployeeProductType.SelectedItem.Value);
            invocie.ProductID = Convert.ToInt32(dpEmployeeProductDetails.SelectedItem.Value);
            invocie.qty = Convert.ToDouble(txtQtyEmployee.Text);
            invocie.UnitCost = Convert.ToDouble(hfEmployeeProductUnitPrice.Value);
            invocie.totalCoast = Convert.ToDouble(txtQtyEmployee.Text) * Convert.ToDouble(hfEmployeeProductUnitPrice.Value);
            tempQty = Convert.ToDouble(txtQtyEmployee.Text);
            invocie.orderDate = DateTime.Now.ToString("dd-MM-yyyy");
            invocie.CurrentBoothID = GlobalInfo.CurrentbothID;
            int flag = 2;
            bool result = invicedata.CheckTempInvoiceItam(invocie, flag);
            if (!result)
            {
                ds = invicedata.checkStock(invocie);
                if (!Comman.Comman.IsDataSetEmpty(ds))
                {
                    double temp = Convert.ToDouble(ds.Tables[0].Rows[0]["avail"]);

                    if (temp >= tempQty)
                    {

                        invicedata.Booth_InsertTempInvoiceItam(invocie);
                        BindEmployeeOrderDetails(invocie);
                        upMain.Update();
                        pnlBills.Visible = false;
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "alertMessage", "alertMessage();", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "alertMessage", "alertMessage();", true);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Item already exists')", true);
            }
        }
        public void BindEmployeeOrderDetails(Invoice invocie)
        {
            InvoiceData invicedata = new InvoiceData();
            rpEmployeeDetails.DataSource = invicedata.GetBoothTempItam(invocie);
            rpEmployeeDetails.DataBind();
            string result = string.Empty;
            DS = invicedata.GetBoothTempItam(invocie);

            string dates = string.IsNullOrEmpty(txtEmployeeOrderDate.Text) ? string.Empty : (Convert.ToDateTime(txtEmployeeOrderDate.Text)).ToString("dd-MM-yyyy");
            int boothIds = GlobalInfo.CurrentbothID;
            DataSet ds = new DataSet();
            ds = invicedata.getBoothAgentBillCount(dates, boothIds);
            int no = Convert.ToInt32(ds.Tables[0].Rows[0]["Count"]) + 1;
            string boothcode = Convert.ToString(ds.Tables[1].Rows[0]["AgentCode"]);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<style type='text / css'>");
                sb.Append(".tg  { border - collapse:collapse; border - spacing:0; border: none; }");
                sb.Append(".tg .tg-yw4l{vertical-align:top}");
                sb.Append(".tg .tg-baqh{text-align:center;vertical-align:top}");
                sb.Append("</style>");
                sb.Append("<table class='tg style1' style='page-break-inside:avoid; align:center;'>");
                sb.Append("<colgroup>");
                sb.Append("<col style = 'width:150px'>");
                sb.Append("<col style = 'width:150px'>");
                sb.Append("<col style = 'width:120px'>");
                sb.Append("<col style = 'width:120px'>");
                sb.Append("<col style = 'width:100px'>");

                sb.Append("</colgroup>");

                sb.Append("<tr>");
                sb.Append("<th class='tg-yw4l' rowspan='2'>");
                sb.Append("<img src='/Theme/img/logo1.png' class='img-circle' alt='Logo' width='50px' hight='50px'>");
                sb.Append("</th>");

                sb.Append("<th class='tg-baqh' colspan='2' style='text-align:center; font-size: 80%;'>");
                sb.Append("<u> Cash/Credit Bill </u> <br/>");
                sb.Append("</th>");

                sb.Append("<th class='tg-yw4l' colspan='2' style='text-align:right; font-size: 80%;'>");

                sb.Append("TIN:330761667331<br>");
                sb.Append("</th>");
                sb.Append("</tr>");

                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append("<td class='tg-yw4l' colspan='4' style='text-align:Left'>");
                sb.Append("<b>Nanjil Integrated Dairy Development, Mulagumoodu, K.K.Dt.  Ph:248370, 248605</b>");

                sb.Append("</td>");

                //sb.Append("<td class='tg-yw4l'  colspan='2' style='text-align:right; font-size: 80%;'>");

                //sb.Append("PH:248370,248605");

                //sb.Append("</td>");
                sb.Append("</tr>");

                sb.Append("<tr style='border-bottom:1px solid'>");
                    sb.Append("<td colspan='3'>");
                    sb.Append(dpEmployee.SelectedItem.Text);
                    sb.Append("</td>");

                    sb.Append("<td colspan='2' style='text-align:right; font-size: 80%;'>");
                    sb.Append(DateTime.Now.ToString("yyyyMMdd") + "/" + no.ToString() + "S");
                    sb.Append("</td>");
                sb.Append("</tr>");

                sb.Append("<tr style='border-bottom:1px solid'>");
                    sb.Append("<td colspan='3' style='text-align:left; font-size: 80%;'>");
                    sb.Append(DateTime.Now.ToString());
                    sb.Append("</td>");

                    sb.Append("<td colspan='2' style='text-align:right; font-size: 90%;'>");
                    sb.Append(boothcode.ToString());
                    sb.Append("</td>");
                sb.Append("</tr>");

                sb.Append("<tr style='border-bottom:0.5px solid'>");
                sb.Append("<td colspan='2'>");
                sb.Append("Product Name");
                sb.Append("</td>");

                sb.Append("<td>");
                sb.Append("Qty.");
                sb.Append("</td>");
                sb.Append("<td>");

                sb.Append("Price");

                sb.Append("</td>");

                sb.Append("<td style='text-align:center'>");

                sb.Append("Amount");

                sb.Append("</td>");
                sb.Append("</tr>");

                foreach (DataRow row in DS.Tables[0].Rows)
                {
                    sb.Append("<tr>");
                    sb.Append("<td class='tg-yw4l'  style='text-align:left' colspan='2'>");
                    sb.Append(row["ProductName"].ToString());
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l'  style='text-align:left'>");
                    sb.Append(row["Qty"].ToString() +" "+ row["UnitName"].ToString());
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l' style='text-align:left'>");
                    sb.Append((Convert.ToDecimal(row["UnitCost"]).ToString("#.00")));
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l' style='text-align:right'>");
                    sb.Append((Convert.ToDecimal(row["Total"]).ToString("#.00")));
                    sb.Append("</td>");

                    sb.Append("</tr>");


                }
                sb.Append("<tr style='border-bottom:1px solid'> <td colspan = '5'> &nbsp; </td> </tr>");
                sb.Append("<tr style='border-bottom:1px solid'> ");

                sb.Append("<td>");
                sb.Append("&nbsp;");
                sb.Append("</td>");
                sb.Append("<td>");
                sb.Append("&nbsp;");
                sb.Append("</td>");

                sb.Append("<td colspan='2'>");
                sb.Append("Total Amount: ");
                sb.Append("</td>");
                sb.Append("<td style='text-align:right'> <b>");
                sb.Append(total.ToString("#0.00"));
                sb.Append("</b> </td>");

                sb.Append("</tr>");
                sb.Append("<tr > <td colspan = '5'style='text-align:center > Thanks, Visit Again...!! </td> </tr>");

                result = sb.ToString();
                genratedBIll.Text = result;
                //Session["ctrl"] = sb.ToString();
                Session["ctrl"] = pnlBills;
                //Response.Redirect("/print.aspx", true);

            }
            else
            {
                result = "No Records Found";
                genratedBIll.Text = result;

            }
        }
        protected void btnEmployeeNewOrder_click(object sender, EventArgs e)
        {
            divDanger.Visible = false;
            divwarning.Visible = false;
            divSusccess.Visible = false;
            pnlError.Update();
            ClereEmployee();
            RemoveAllItam();
            txtEmployeeOrderDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));

        }
        protected void rpEmployeeID_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {


            int TempID = 0;
            TempID = Convert.ToInt32(e.CommandArgument);
            switch (e.CommandName)
            {
                case ("delete"):
                    {


                        Invoice invocie = new Invoice();
                        RemoveTempID(TempID);
                        invocie.TokanId = hftokanno.Value;
                        invocie.UserID = GlobalInfo.Userid;
                        BindEmployeeOrderDetails(invocie);
                        upMain.Update();

                        break;
                    }



            }





        }
        protected void rpEmployeeID_OnDataBinding(object sender, RepeaterItemEventArgs e)
        {

            RepeaterItem item = e.Item;
            if (item.ItemType == ListItemType.AlternatingItem || item.ItemType == ListItemType.Item)
            {
                // HtmlGenericControl li = (HtmlGenericControl)item.FindControl("li");
                Label lbltotal = (Label)item.FindControl("lbltotal");
                Label lblType = (Label)item.FindControl("lblType");
                if (lblType != null && string.IsNullOrEmpty(lblType.Text))
                {
                    lblType.Text = "shechem Amount";
                }
                if (lbltotal != null)
                {
                    total = total + (string.IsNullOrEmpty(lbltotal.Text) ? 0 : Convert.ToDouble(lbltotal.Text));
                }
            }
            if (item.ItemType == ListItemType.Footer || item.ItemType == ListItemType.Item)
            {
                // HtmlGenericControl li = (HtmlGenericControl)item.FindControl("li");
                Label lblFInaltotal = (Label)item.FindControl("lblFInaltotal");
                if (lblFInaltotal != null)
                {
                    lblFInaltotal.Text = total.ToString("#0.00");
                    hfemployeeTotalBill.Value = total.ToString("#0.00");
                }

            }
        }
        protected void btnPrintEmp_click(object sender, EventArgs e)
        {

            Invoice inovice = new Invoice();
            ClereEmployee();
            inovice.TokanId = hftokanno.Value;
            inovice.CreatedBy = GlobalInfo.Userid;
            BindEmployeeOrderDetails(inovice);
            pnlBills.Visible = false;
            pnlBill2.Visible = true;
            btnAddEmployeeOrderItem.Visible = true;
            btnEmployeeNewOrder.Visible = true;
            btnRemoveOrder.Visible = true;
            btnPrintEmp.Visible = false;
            Button1.Visible = true;
            txtEmployeeOrderDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));

            
            divDanger.Visible = false;
            divwarning.Visible = false;
            divSusccess.Visible = false;
            pnlError.Update();

        }

        protected void btnemployeeOrdersubmit_click(object sender, EventArgs e)
        {
            if (dpEmployee.SelectedItem.Value != "0")
            {
                int result = 0;
                Invoice inovice = new Invoice();
                InvoiceData invoiceData = new InvoiceData();
                inovice.orderDate = (Convert.ToDateTime(txtEmployeeOrderDate.Text)).ToString("dd-MM-yyyy");
                inovice.AgencyID = 0;
                inovice.ShecemeApplied = true;

                //salesEmployee
                DataSet ds = new DataSet();
                BillData billData = new BillData();
                ds = billData.getEmployeeByUserId(GlobalInfo.Userid);
                inovice.SaleEmployeeId = string.IsNullOrEmpty(ds.Tables[0].Rows[0]["EmployeeID"].ToString()) ? 0 : Convert.ToInt32(ds.Tables[0].Rows[0]["EmployeeID"]);

                inovice.EmployeeID = Convert.ToInt32(dpEmployee.SelectedItem.Value);
                inovice.totalCoast = string.IsNullOrEmpty(hfemployeeTotalBill.Value) ? 0 : Comman.Comman.IsValidInteger(hfemployeeTotalBill.Value) ? Convert.ToDouble(hfemployeeTotalBill.Value) : 0;
                inovice.CreatedBy = GlobalInfo.Userid;
                inovice.CreatedDate = DateTime.Now.ToString("dd/MM/yyyy");
                inovice.TokanId = hftokanno.Value;
                inovice.orderType = 2;// employeeORder
                inovice.CurrentBoothID = GlobalInfo.CurrentbothID;
                inovice.PaymentMode = "Employee";

                DataSet chkds = new DataSet();
                chkds = invoiceData.CheckBoothTemp(inovice,1);
                if (!Comman.Comman.IsDataSetEmpty(chkds))
                {
                    result = invoiceData.BoothInserOrder(inovice);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Add Items')", true);
                }
                if (result > 0)
                {
                    //ScriptManager.RegisterStartupScript(pnlBill2, pnlBill2.GetType(), "PrintPanel2", "PrintPanel2()", true))
                    updateStock();
                    btnPrintEmp.Visible = true;
                    Button1.Visible = false;
                    btnAddEmployeeOrderItem.Visible = false;
                    btnEmployeeNewOrder.Visible = false;
                    btnRemoveOrder.Visible = false;
                    pnlBill2.Visible = false;
                    pnlBills.Visible = true;
                    divDanger.Visible = false;
                    divwarning.Visible = false;
                    divSusccess.Visible = true;
                    pnlError.Update();
                    upMain.Update();
                    pnlBill2.Enabled = false;

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
            else
            {
               // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select Employee')", true);
            }
        }
        private void updateStock()
        {
            Invoice inv = new Invoice();
            InvoiceData invData = new InvoiceData();
            int boothid = Convert.ToInt32(GlobalInfo.CurrentbothID);

            DataSet DsStock = new DataSet();

            DsStock = invData.GetStockAgent(boothid);

            DsStock.Tables[0].Columns.Add("UserID", typeof(int));
            int userid = GlobalInfo.Userid;
            for (int i = 0; i <= DsStock.Tables[0].Rows.Count - 1; i++)
            {
                DsStock.Tables[0].Rows[i]["UserID"] = userid;
            }
            DsStock.Tables[0].Columns.Add("ShiftDate", typeof(string));
            for (int i = 0; i <= DsStock.Tables[0].Rows.Count - 1; i++)
            {
                DsStock.Tables[0].Rows[i]["ShiftDate"] = DateTime.Now.ToString("dd-MM-yyyy");
            }

            if (!Comman.Comman.IsDataSetEmpty(DsStock))
            {
                string constr = ConfigurationManager.ConnectionStrings["projectConnection"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_StockUpdateReturn"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@tblStock", DsStock.Tables[0]);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
        }
        public void ClereEmployee()
        {
            txtEmployeeOrderDate.Text = string.Empty;
            dpEmployee.ClearSelection();
            // dpSelaesPerson.ClearSelection();
            //dpEmploueeRoute.ClearSelection();
            txtQtyEmployee.Text = string.Empty;
            dpEmployeeProductDetails.ClearSelection();
            //dpEmploueeSalesPErsion.ClearSelection();
            dpEmployeeProductType.ClearSelection();

        }

        protected void RemoveTempID(int tempID)
        {
            InvoiceData invicedata = new InvoiceData();
            invicedata.BoothTempDelete(tempID);

        }
        public void RemoveAllItam()
        {
            Invoice invocie = new Invoice();
            InvoiceData invicedata = new InvoiceData();
            invocie.TokanId = hftokanno.Value;
            invocie.UserID = GlobalInfo.Userid;
            invicedata.DeleteBoothTempItems(invocie);
            BindAgntTempItam(invocie);
            upMain.Update();
        }
        public void BindAgntTempItam(Invoice invocie)
        {
            InvoiceData invicedata = new InvoiceData();
            rpEmployeeDetails.DataSource = invicedata.GetBoothTempItam(invocie);
            rpEmployeeDetails.DataBind();
        }

        protected void btnRemoveOrder_click(object sender, EventArgs e)
        {
            RemoveAllItam();
        }


    }
}