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
    public partial class LocalBilling : System.Web.UI.Page
    {
        DataSet DSSlab;
        DataSet DS;
        double total = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDwon();
                hftokanno.Value = Comman.Comman.RandomString();
                txtCustamerorderDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                lblUser.Text = GlobalInfo.UserName;
                btnPrint.Visible = false;
                int BothID = GlobalInfo.CurrentbothID;
                txtCustamerorderDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
               
            }
        }
        public void BindDropDwon()
        {
            DS = new DataSet();
            DS.Clear();
            DS = BindCommanData.BindCommanDropDwon("TypeID", "TypeName", "TypeMaster", "IsArchive=1");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {


                dpCustomerPRoductType.DataSource = DS;
                dpCustomerPRoductType.DataBind();
                dpCustomerPRoductType.Items.Insert(0, new ListItem("--Select Product Type  --", "0"));

            }
        }
        protected void rpOrderitam_OnDataBinding(object sender, RepeaterItemEventArgs e)
        {

            RepeaterItem item = e.Item;
            if (item.ItemType == ListItemType.AlternatingItem || item.ItemType == ListItemType.Item)
            {
                // HtmlGenericControl li = (HtmlGenericControl)item.FindControl("li");
                Label lbltotal = (Label)item.FindControl("lbltotal");
                Label lblType = (Label)item.FindControl("lblType");
                if (lblType != null && string.IsNullOrEmpty(lblType.Text))
                {
                    lblType.Text = "Scheme Amount";
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
                    hfcutomerTotal.Value = total.ToString("#0.00");
                }

            }
        }
        protected void rpOrderitam_ItemCommand(object sender, RepeaterCommandEventArgs e)
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
                        //BindAgntTempItam(invocie);
                        upMain.Update();

                        break;
                    }

            }
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
            rpCutamoer.DataSource = invicedata.GetBoothTempItam(invocie);
            rpCutamoer.DataBind();
        }
        ///customer
        ///
        public void BindCustomerTempItam(Invoice invocie)
        {
            string result = string.Empty;
            InvoiceData invicedata = new InvoiceData();
            rpCutamoer.DataSource = invicedata.GetBoothTempItam(invocie);
            rpCutamoer.DataBind();
            DS = invicedata.GetBoothTempItam(invocie);
            string dates = string.IsNullOrEmpty(txtCustamerorderDate.Text)? string.Empty: (Convert.ToDateTime(txtCustamerorderDate.Text)).ToString("dd-MM-yyyy");
            DataSet ds = new DataSet();
            int boothIds = GlobalInfo.CurrentbothID;
            ds = invicedata.getBillCount(dates, boothIds);
            string boothcode = Convert.ToString(ds.Tables[1].Rows[0]["AgentCode"]);
            int no = Convert.ToInt32(ds.Tables[0].Rows[0]["Count"]) + 1;
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
                    sb.Append("<td colspan ='2' style='text-align:left; font-size: 80%;'>");
                    sb.Append("Local Sale");
                    sb.Append("</td>");
                    
                    sb.Append("<td>");
                    sb.Append("&nbsp;");
                    sb.Append("</td>");
                    sb.Append("<td colspan='2' style='text-align:right; font-size: 80%;'>");
                    sb.Append("Bill No " + DateTime.Now.ToString("yyyyMMdd") +"/" + no.ToString() + "L");
                    sb.Append("</td>");
                    
                sb.Append("</tr>");

                sb.Append("<tr style='border-bottom:1px solid'>");
                    sb.Append("<td colspan ='2' style='text-align:left; font-size: 80%;'>");
                    sb.Append(DateTime.Now.ToString());
                    sb.Append("</td>");

                    sb.Append("<td>");
                    sb.Append("&nbsp;");
                    sb.Append("</td>");
                    sb.Append("<td colspan='2' style='text-align:right; font-size: 80%;'>");
                    sb.Append(boothcode);
                    sb.Append("</td>");

                sb.Append("</tr>");

                //sb.Append("<tr style='border-bottom:1px solid'> <td colspan = '5'> &nbsp; </td> </tr>");
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
                    sb.Append(row["Qty"].ToString() + " " + row["UnitName"].ToString());
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l' style='text-align:left'>");
                    sb.Append((Convert.ToDecimal(row["UnitCost"]).ToString("#.00")));
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l' style='text-align:right'>");
                    sb.Append((Convert.ToDecimal(row["Total"]).ToString("#.00")));
                    sb.Append("</td>");

                    sb.Append("</tr>");

                }
               // sb.Append("<tr style='border-bottom:1px solid'> <td colspan = '5'> &nbsp; </td> </tr>");

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
                //sb.Append("<tr> <td colspan='5' style='text-align:left> Thanks, Visit Again...!! </td> </tr>" );
               
                result = sb.ToString();
                genratedBIll.Text = result;
                //Session["ctrl"] = sb.ToString();
                Session["ctrl"] = pnlBills;
                //Response.Redirect("/print.aspx", true);

            }
            else
            {
                //result = "No Records Found";
                //genratedBIll.Text = result;

            }
        }
        protected void dpCustomerPRoductType_IndexChanged(object sender, EventArgs e)
        {
            DSSlab = new DataSet();
            Invoice invoiceforSlab = new Invoice();
            invoiceforSlab.SlabName = "MRP";
            InvoiceData invocieDataSlab = new InvoiceData();
            DSSlab = invocieDataSlab.GetSlabID(invoiceforSlab);
           int slabID;
           slabID = Convert.ToInt32(DSSlab.Tables[0].Rows[0]["SlabID"].ToString());
            DS = new DataSet();

            DS = BindCommanData.BindCommanDropDwon("productId", "ProductName+' '+Productcode as product", "Products", "   typeID=" + Convert.ToInt32(dpCustomerPRoductType.SelectedItem.Value) + " and   IsArchive=0 and SlabID = " + slabID + " Order by Products.ProductName");
            //DS = BindCommanData.BindCommanDropDwon("Products.ProductID", "Commodity.CommodityName+' '+Products.ProductName as product", "Commodity, Products", "   Products.CommodityID = Commodity.CommodityID");
            dpCustomerPRoductDetails.DataSource = DS;
            dpCustomerPRoductDetails.DataBind();
            dpCustomerPRoductDetails.Items.Insert(0, new ListItem("--Select Product  --", "0"));
            dpCustomerPRoductDetails.Focus();

            upMain.Update();
        }
        protected void dpCustomerPRoductDetails_IndexChanged(object sender, EventArgs e)
        {
            DS = new DataSet();
            int SlabID;
            Invoice invoice = new Invoice();
            InvoiceData invocieDate = new InvoiceData();
            DSSlab = new DataSet();
            Invoice invoiceforSlab = new Invoice();
            invoiceforSlab.SlabName="MRP";
            InvoiceData invocieDataSlab = new InvoiceData();
            DSSlab = invocieDataSlab.GetSlabID(invoiceforSlab);
            SlabID = Convert.ToInt32(DSSlab.Tables[0].Rows[0]["SlabID"].ToString());
            invoice.SlabID = SlabID;
            invoice.ProductID = Convert.ToInt32(dpCustomerPRoductDetails.SelectedItem.Value);
            DS = invocieDate.GetUnitPriceBysablID(invoice);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {


                hfCustmoerUnitPrice.Value = DS.Tables[0].Rows[0]["Price"].ToString();
            }
            else
            {
                hfCustmoerUnitPrice.Value = "0";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Product IS not Configuer With MRP SLAB')", true);
            }
            dpCustomerPRoductDetails.Focus();
        }

        //
        protected void btnaddCustomeraItam_clcik(object sender, EventArgs e)
        {
            double tempQty = 0;
            Invoice invocie = new Invoice();
            InvoiceData invicedata = new InvoiceData();
            DataSet ds = new DataSet();
            invocie.TokanId = hftokanno.Value;
            invocie.UserID = GlobalInfo.Userid;
            invocie.TypeID = Convert.ToInt32(dpCustomerPRoductType.SelectedItem.Value);
            invocie.ProductID = Convert.ToInt32(dpCustomerPRoductDetails.SelectedItem.Value);
            invocie.qty = Convert.ToDouble(txtcustomerqty.Text);
            invocie.UnitCost = Convert.ToDouble(hfCustmoerUnitPrice.Value);
            invocie.totalCoast = Convert.ToDouble(txtcustomerqty.Text) * Convert.ToDouble(hfCustmoerUnitPrice.Value);
            tempQty= Convert.ToDouble(txtcustomerqty.Text);
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
                        BindCustomerTempItam(invocie);
                        pnlBill.Visible = true;
                        btnPrint.Visible = false;
                        pnlBills.Visible = false;
                        pnlBill.Enabled = true;
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
        public void btnCustomerNewOrder_click(object sender, EventArgs e)
        {
            clearCustomerValues();
            RemoveAllItam();
            upMain.Update();
            Response.Redirect("LocalBilling.aspx");
        }
        public void clearCustomerValues()
        {
            txtCustamerorderDate.Text = string.Empty;
            //dpCustamerroute.ClearSelection();
            //dpCusdamerSalesPersion.ClearSelection();
            dpCustomerPRoductType.ClearSelection();
            dpCustomerPRoductDetails.ClearSelection();
            txtcustomerqty.Text = string.Empty;
            upMain.Update();

        }
        protected void rpCutamoer_ItemCommand(object sender, RepeaterCommandEventArgs e)
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
                        BindCustomerTempItam(invocie);
                        upMain.Update();

                        break;
                    }



            }





        }
        protected void rpCutamoer_OnDataBinding(object sender, RepeaterItemEventArgs e)
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
                    lblFInaltotal.Text = total.ToString();
                    hfcutomerTotal.Value = total.ToString();
                }

            }
        }
        protected void btnPrintCust_click(object sender, EventArgs e)
        {
            //ScriptManager.RegisterStartupScript(pnlBill, pnlBill.GetType(), "PrintPanel", "PrintPanel()", true);
            clearCustomerValues();
            Invoice inovice = new Invoice();
            RemoveAllItam();
            inovice.TokanId = hftokanno.Value;
            inovice.CreatedBy = GlobalInfo.Userid;
            BindCustomerTempItam(inovice);
            
           
            txtCustamerorderDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));


            pnlBills.Visible = true;
            btnCustomerorRemoveAllitam.Visible = true;
            btnaddCustomeraItam.Visible = true;
            btnCustomerNewOrder.Visible = true;
            btnCustomerordersubmit.Visible = true;
            btnPrint.Visible = false;
            divDanger.Visible = false;
            divwarning.Visible = false;
            divSusccess.Visible = false;
            pnlError.Update();
            
        }

        protected void btnCustomerordersubmit_click(object sender, EventArgs e)
        {
           
            pnlBills.Visible = true;
            btnCustomerorRemoveAllitam.Visible = false;
            pnlBill.Visible = false;
            btnaddCustomeraItam.Visible= false;
            btnCustomerNewOrder.Visible = false;
            btnPrint.Visible = true;
            
            int result = 0;
            Invoice inovice = new Invoice();
            InvoiceData invoiceData = new InvoiceData();
            inovice.orderDate = (Convert.ToDateTime(txtCustamerorderDate.Text)).ToString("dd-MM-yyyy");
            inovice.AgencyID = 0;
            inovice.ShecemeApplied = true;

            //salesEmployee
            DataSet ds = new DataSet();
            BillData billData = new BillData();
            ds = billData.getEmployeeByUserId(GlobalInfo.Userid);
            inovice.SaleEmployeeId = string.IsNullOrEmpty(ds.Tables[0].Rows[0]["EmployeeID"].ToString()) ? 0 : Convert.ToInt32(ds.Tables[0].Rows[0]["EmployeeID"]);

            inovice.totalCoast = string.IsNullOrEmpty(hfcutomerTotal.Value) ? 0 : Comman.Comman.IsValidInteger(hfcutomerTotal.Value) ? Convert.ToDouble(hfcutomerTotal.Value) : 0;
            inovice.CreatedBy = GlobalInfo.Userid;
            inovice.CreatedDate = DateTime.Now.ToString("dd/MM/yyyy");
            inovice.TokanId = hftokanno.Value;
            inovice.orderType = 3;// employeeORder
            inovice.CurrentBoothID = GlobalInfo.CurrentbothID;
            DataSet chkds = new DataSet();
            int chkflg = 1;
            chkds = invoiceData.CheckBoothTemp(inovice, chkflg);
            if (!Comman.Comman.IsDataSetEmpty(chkds))
            {
                result = invoiceData.BoothLocalInserOrder(inovice);
            }

            if (result > 0)
            {

                btnCustomerordersubmit.Visible = false;
                btnPrint.Visible = true;

                updateStock();
               
                //BindEmployeeOrderDetails(inovice);
                // BindAgntTempItam(inovice);
                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                pnlError.Update();
                upMain.Update();
                pnlBill.Enabled = false;


                // 
            }
            else
            {
                divDanger.Visible = false;
                divwarning.Visible = true;
                divSusccess.Visible = false;
                lblwarning.Text = "Please Contact to Site Admin";
                pnlError.Update();
                btnPrint.Visible = false;
                btnCustomerordersubmit.Visible = false;
                btnCustomerNewOrder.Visible = true;

            }

        }
        private void updateStock()
        {
            Invoice inv = new Invoice();
            InvoiceData invData = new InvoiceData();
            int boothid = Convert.ToInt32(GlobalInfo.CurrentbothID);

            DataSet DsStock = new DataSet();

            DsStock = invData.GetStock(boothid);

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
                 try
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
                       
                           int x = cmd.ExecuteNonQuery();
                        
                        con.Close();
                    }
                }
                        }
                 catch (Exception ex)
                 {
                     string e = ex.ToString();
                 }
            }
        }
        protected void btnCustomerorRemoveAllitam_clcik(object sender, EventArgs e)
        {

            RemoveAllItam();

            upMain.Update();

        }

    }
}