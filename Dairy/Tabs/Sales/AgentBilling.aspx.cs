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
    public partial class AgentBilling : System.Web.UI.Page
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
               
                lblUser.Text = GlobalInfo.UserName;
                btnPrintAgent.Visible = false;
                int bothID = GlobalInfo.CurrentbothID;
                txtGentOrderDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                
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

         


            //}
           
            DS.Clear();
            DS = BindCommanData.BindCommanDropDwon("AgentID", "AgentCode+' '+AgentName as Name", "AgentMaster", "IsArchive=0 and Isactive=1 and Agensytype='Agency' Order by AgentCode");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpAgent.DataSource = DS;
                dpAgent.DataBind();
                dpAgent.Items.Insert(0, new ListItem("--Select Agent  --", "0"));
            }


            DS.Clear();
            DS = BindCommanData.BindCommanDropDwon("TypeID", "TypeName", "TypeMaster", "IsArchive=1");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpAgentProductType.DataSource = DS;
                dpAgentProductType.DataBind();
                dpAgentProductType.Items.Insert(0, new ListItem("--Select Product Type  --", "0"));





            }
        }
        protected void dpAgentProductType_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            DS = new DataSet();

            DS = BindCommanData.BindTypeDropDwon("Products.productId", "Products.ProductName+' '+Products.Productcode as product", "Products", "BindSlab", "Products.TypeID = Bindslab.TypeID", "Products.TypeID =" + Convert.ToInt32(dpAgentProductType.SelectedItem.Value) + " and BindSlab.AgentID =" + Convert.ToInt32(dpAgent.SelectedItem.Value) + " and BindSlab.SlabID = Products.SlabID order by Products.ProductName");
            // DS = BindCommanData.BindCommanDropDwon("Products.ProductID", "Commodity.CommodityName+' '+Products.ProductName as product", "Commodity, Products", "   Products.CommodityID = Commodity.CommodityID and IsArchive=0 ");
            dpAgentProductdetaisl.DataSource = DS;
            dpAgentProductdetaisl.DataBind();
            dpAgentProductdetaisl.Items.Insert(0, new ListItem("--Select Product  --", "0"));
            dpAgentProductdetaisl.Focus();
            upMain.Update();

            DataSet DS1 = new DataSet();
            DS1=BindCommanData.BindCommanDropDwon("AgentID","PaymentMode","AgentMaster","AgentID="+Convert.ToInt32(dpAgent.SelectedItem.Value));
            dpPaymentMode.DataSource = DS1;
            dpPaymentMode.DataBind();
            dpPaymentMode.Focus();
            upMain.Update();

        }
        protected void dpAgentShemeApplied_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dpAgentShemeApplied.SelectedItem.Value == "1")
            {
                int result = 0;
                DataSet DS = new DataSet();
                Invoice inovice = new Invoice();
                InvoiceData invoiceData = new InvoiceData();
                inovice.AgencyID = Convert.ToInt32(dpAgent.SelectedItem.Value);
                inovice.orderDate = (Convert.ToDateTime(txtGentOrderDate.Text)).ToString("dd-MM-yyyy");
                inovice.UserID = GlobalInfo.Userid;
                inovice.TokanId = hftokanno.Value;
                DS = invoiceData.chkScheme(inovice);
                if (!Comman.Comman.IsDataSetEmpty(DS))
                {
                    result = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Count"].ToString()) ? 0 : Convert.ToInt32(DS.Tables[0].Rows[0]["Count"]);
                    if (result == 0)
                    {
                        AddAgentShemeDetails(Convert.ToInt32(dpAgent.SelectedItem.Value));
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Scheme Already Deposited')", true);
                        //dpAgentShemeApplied.Items.FindByValue("2").Selected = true;
                    }

                }
                else
                {

                }
            }
            dpAgentShemeApplied.Focus();
        }
        public void AddAgentShemeDetails(int dbagentinfo)
        {
            AgentInfoData agentInfoData = new AgentInfoData();
            DataSet DS = new DataSet();
            DS = agentInfoData.GetAgentbyID(dbagentinfo);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {

                //txtSchemeAmount.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["SchemeAmount"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["SchemeAmount"].ToString();
                Invoice invocie = new Invoice();
                InvoiceData invicedata = new InvoiceData();
                invocie.TokanId = hftokanno.Value;
                invocie.UserID = GlobalInfo.Userid;
                invocie.TypeID = 0;
                invocie.ProductID = 0;
                invocie.qty = 0;
                invocie.totalCoast = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["SchemeAmount"].ToString()) ? 0 : Convert.ToDouble(DS.Tables[0].Rows[0]["SchemeAmount"]);
                invocie.SchemeAmount = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["SchemeAmount"].ToString()) ? 0 : Convert.ToDouble(DS.Tables[0].Rows[0]["SchemeAmount"]);
                invocie.TotalSchemeAmount = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["TotalSchemeAmount"].ToString()) ? 0 : Convert.ToDouble(DS.Tables[0].Rows[0]["TotalSchemeAmount"]);
                invocie.TotalSchemeAmount = invocie.TotalSchemeAmount + invocie.SchemeAmount;
                schemeTemp = invocie.TotalSchemeAmount;
                
                if (invocie.SchemeAmount > 0)
                {
                    schemeApplied = true;
                    invicedata.Booth_InsertTempInvoiceItam(invocie);
                    BindAgntTempItam(invocie);
                }
                else
                {
                    schemeApplied = false;
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Scheme not available')", true);
                    dpAgentShemeApplied.ClearSelection();
                }

            }
        }


        protected void dpAgentpre_SelectedIndexChanged(object sender, EventArgs e)
        {
            //DS = BindCommanData.BindTypeDropDwon("TypeMaster.TypeID", "TypeMaster.TypeName as TypeName ", " TypeMaster ", " BindSlab", " TypeMaster.TypeID = BindSlab.TypeID ", "BindSlab.AgentID = 110 ");
            //if (!Comman.Comman.IsDataSetEmpty(DS))
            //{
            //    dpAgentProductType.DataSource = DS;
            //    dpAgentProductType.DataBind();
            //    dpAgentProductType.Items.Insert(0, new ListItem("--Select Product Type  --", "0"));
            //}
            dpAgent.Focus();
        }


        public void dpAgentProductdetaisl_SelectedIndexChanged(object sender, EventArgs e)
        {
            double price = 0;
            DataSet Ds = new DataSet();
            Product product = new Product();
            ProductData productData = new ProductData();
            // upMain.Update();
            product.AgencyID = Convert.ToInt32(dpAgent.SelectedItem.Value);
            product.TypeID = Convert.ToInt32(dpAgentProductType.SelectedItem.Value);
            product.ProductID = Convert.ToInt32(dpAgentProductdetaisl.SelectedItem.Value);
            Ds = productData.GetSlabPriceOnAgentTypeProductIDs(product);

            if (!Comman.Comman.IsDataSetEmpty(Ds))
            {
                hfAgentProductUnitPrice.Value = Ds.Tables[0].Rows[0]["prize"].ToString();


            }
            else
            {
                hfAgentProductUnitPrice.Value = "0";
            }
            dpAgentProductdetaisl.Focus();
        }

        public void BindAgntTempItam(Invoice invocie)
        {
            InvoiceData invicedata = new InvoiceData();
            rpAgentOrderdetails.DataSource = invicedata.GetBoothTempItam(invocie);
            rpAgentOrderdetails.DataBind();

            string result = string.Empty;
            DS = invicedata.GetBoothTempItam(invocie);

            string dates = string.IsNullOrEmpty(txtGentOrderDate.Text) ? string.Empty : (Convert.ToDateTime(txtGentOrderDate.Text)).ToString("dd-MM-yyyy");
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
                    sb.Append(dpAgent.SelectedItem.Text);
                    sb.Append("</td>");

                    sb.Append("<td colspan='2' style='text-align:right; font-size: 80%;'>");
                    sb.Append( DateTime.Now.ToString("yyyyMMdd") + "/" + no.ToString() + "A");
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
                    if (!string.IsNullOrEmpty(row["ProductName"].ToString()))
                    {
                        sb.Append(row["ProductName"].ToString());
                    }
                    else
                    { sb.Append("Scheme "); }
                    
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
        protected void btnAddAgentProductItem_click(object sender, EventArgs e)
        {
            dpAgent.Enabled = false;

            double tempQty = 0;
            DataSet ds = new DataSet();

            Invoice invocie = new Invoice();
            InvoiceData invicedata = new InvoiceData();
            invocie.TokanId = hftokanno.Value;
            invocie.UserID = GlobalInfo.Userid;
            invocie.TypeID = Convert.ToInt32(dpAgentProductType.SelectedItem.Value);
            invocie.ProductID = Convert.ToInt32(dpAgentProductdetaisl.SelectedItem.Value);
            invocie.qty = Convert.ToDouble(txtagentOrderqty.Text);
            invocie.UnitCost = Convert.ToDouble(hfAgentProductUnitPrice.Value);
            invocie.totalCoast = Convert.ToDouble(txtagentOrderqty.Text) * Convert.ToDouble(hfAgentProductUnitPrice.Value);
            tempQty = Convert.ToDouble(txtagentOrderqty.Text);
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
                        BindAgntTempItam(invocie);
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
        protected void btnPrintAgent_click(object sender, EventArgs e)
        {

            Invoice inovice = new Invoice();
            clearAgentValues();
            // ScriptManager.RegisterStartupScript(pnlBill1, pnlBill1.GetType(), "PrintPanel1", "PrintPanel1()", true);
            RemoveAllItam();
            inovice.TokanId = hftokanno.Value;
            inovice.CreatedBy = GlobalInfo.Userid;
            //BindEmployeeOrderDetails(inovice);
            BindAgntTempItam(inovice);

            btnagentItamsremove.Visible = true;
            btnAddAgentProductItem.Visible = true;
            btnAgentNewOrder.Visible = true;
            btnAgentORderSubmit.Visible = true;
            pnlBill1.Visible = true;
            btnPrintAgent.Visible = false;
            txtGentOrderDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));

           
            divDanger.Visible = false;
            divwarning.Visible = false;
            divSusccess.Visible = false;
            pnlError.Update();

        }
        public void btnAgentORderSubmit_click(object sender, EventArgs e)
        {
            int result = 0;
            Invoice inovice = new Invoice();
            InvoiceData invoiceData = new InvoiceData();
            inovice.orderDate = (Convert.ToDateTime(txtGentOrderDate.Text)).ToString("dd-MM-yyyy");
            inovice.AgencyID = Convert.ToInt32(dpAgent.SelectedItem.Value);
            inovice.ShecemeApplied = true;
            

            //salesEmployee
            DataSet ds = new DataSet();
            BillData billData = new BillData();
            ds = billData.getEmployeeByUserId(GlobalInfo.Userid);
            inovice.SaleEmployeeId = string.IsNullOrEmpty(ds.Tables[0].Rows[0]["EmployeeID"].ToString()) ? 0 : Convert.ToInt32(ds.Tables[0].Rows[0]["EmployeeID"]);

            inovice.totalCoast = string.IsNullOrEmpty(hftotalAmout.Value) ? 0 : Comman.Comman.IsValidInteger(hftotalAmout.Value) ? Convert.ToDouble(hftotalAmout.Value) : 0;
            inovice.CreatedBy = GlobalInfo.Userid;
            inovice.CreatedDate = DateTime.Now.ToString("dd/MM/yyyy");
            inovice.TokanId = hftokanno.Value;
            inovice.TotalSchemeAmount = schemeTemp;
            inovice.ShecemeApplied = schemeApplied;
            inovice.orderType = 1;// AgentORder
            inovice.CurrentBoothID = GlobalInfo.CurrentbothID;
            inovice.PaymentMode = dpPaymentMode.SelectedItem.Text;
            DataSet chkds = new DataSet();

            chkds = invoiceData.CheckBoothTemp(inovice,1);
            if (!Comman.Comman.IsDataSetEmpty(chkds))
            { 
                result = invoiceData.BoothInserOrder(inovice);
            }
            if (result > 0)
            {
                updateStock();
                btnAgentORderSubmit.Visible = false;
                btnPrintAgent.Visible = true;
                pnlBills.Visible = true;
                btnagentItamsremove.Visible = false;
                btnAddAgentProductItem.Visible = false;
                btnAgentNewOrder.Visible = false;
                btnAgentORderSubmit.Visible = false;
                pnlBill1.Visible = false;
                lblSuccess.Visible = true;

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;

                pnlError.Update();
                upMain.Update();

                pnlBill1.Enabled = false;

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
        public void clearAgentValues()
        {
            txtagentOrderqty.Text = string.Empty;
            txtGentOrderDate.Text = string.Empty;
            //dpAgentSelasEMployee.ClearSelection();
            //dpagentRoute.ClearSelection();
            dpAgent.ClearSelection();
            dpAgentProductdetaisl.ClearSelection();
            dpAgentProductType.ClearSelection();
            dpAgentShemeApplied.ClearSelection();
            dpPaymentMode.ClearSelection();


        }
        public void btnagentItamsremove_click(object sender, EventArgs e)
        {
            RemoveAllItam();
        }
        public void btnAgentNewOrder_clcik(object sender, EventArgs e)
        {
            clearAgentValues();
            RemoveAllItam();
            upMain.Update();
            dpAgent.Enabled = true;
            txtGentOrderDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
            divDanger.Visible = false;
            divwarning.Visible = false;
            divSusccess.Visible = false;

            pnlError.Update();
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
                    hftotalAmout.Value = total.ToString("#0.00");
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
                        BindAgntTempItam(invocie);
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
    }
}