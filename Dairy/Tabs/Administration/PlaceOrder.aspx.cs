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
    public partial class PlaceOrder : System.Web.UI.Page
    {
        DataSet DS;
        double total = 0;
        double totsum = 0;
        //double schemeTemp = 0;
        public static double schemeTemp = 0;

        public static bool schemeApplied = false;
      
        public static int PrvAgentID = 0;
        public static int PrvOrderID = 0;
    
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                BindDropDwon();
                hftokanno.Value = Comman.Comman.RandomString();
               // txtAgentId.Text = "0";
                //string script = "$(document).ready(function () { $('[id*=dpAgent]').onchange(); });";
                //ClientScript.RegisterStartupScript(this.GetType(), "load", script, true);
                txtGentOrderDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                txtEmployeeOrderDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));

            }
           
            
        }

        [WebMethod]
        public static string[] GetCustomers(string prefix)
        {
            List<string> customers = new List<string>();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["projectConnection"].ConnectionString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "select AgentName, AgentID from AgentMaster where AgentName like @SearchText + '%'";
                    cmd.Parameters.AddWithValue("@SearchText", prefix);
                    cmd.Connection = conn;
                    conn.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            customers.Add(string.Format("{0}-{1}", sdr["AgentName"], sdr["AgentID"]));
                        }
                    }
                    conn.Close();
                }
            }
            return customers.ToArray();
        }

        
        //protected void OnTextChanged(object sender, EventArgs e)
        [WebMethod]
        public static void OnTextChanged(int id)
        {
              //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You clicked YES!')", true);
                Invoice invocie = new Invoice();
                InvoiceData invicedata = new InvoiceData();
                PlaceOrder po = new PlaceOrder();
                //invocie.AgencyID = Convert.ToInt32(dpAgent.SelectedItem.Value);
                //invocie.AgencyID = Convert.ToInt32(po.txtAgentId.Text);
                invocie.AgencyID = id;
                DataSet DS = new DataSet();
                DS = invicedata.GetPreviousDayOrder(invocie);
                if (!Comman.Comman.IsDataSetEmpty(DS))
                {
                    /* Nee to Implement */

                   // po.RemoveAllItam();
                    
                    //foreach (DataRow row in DS.Tables[0].Rows)
                    //{
                    //    invocie.TokanId = po.hftokanno.Value;
                    //    invocie.UserID = GlobalInfo.Userid;
                    //    invocie.ProductID = Convert.ToInt32(row["ProductID"]);
                    //    invocie.qty = Convert.ToInt32(row["Qty"]);
                    //    invocie.UnitCost = Convert.ToDouble(row["UnitCost"]);
                    //    invocie.totalCoast = Convert.ToDouble(row["Total"]);
                    //    invocie.TypeID = Convert.ToInt32(row["TypeID"]);
                    //    invicedata.InsertTempInvoiceItam(invocie);
                    //    po.BindAgntTempItam(invocie);
                                               
                    //    po.txtagentOrderqty.Text = "0";
                    //}

                

            }
            
        }

        protected void hfAgentAuto_Changed(object sender, EventArgs e)
        {
            
           

        }


        #region ChangesTabOnRedioButton

        public void rbAgent_chamged(object sender, EventArgs e)
        {
            pnlAgentOrder.Visible = true;
            pnlEmployee.Visible = false;

            upMain.Update();
            pnlError.Update();
            RemoveAllEmployeeItam();
            divDanger.Visible = false;
            divwarning.Visible = false;
            divSusccess.Visible = false;
          
        }
        public void rbEmployee_chamged(object sender, EventArgs e)
        {
            pnlAgentOrder.Visible = false;
            pnlEmployee.Visible = true;

            upMain.Update();
            RemoveAllItam();
            pnlError.Update();
            divDanger.Visible = false;
            divwarning.Visible = false;
            divSusccess.Visible = false;
        }
        public void rbCustomer_chamged(object sender, EventArgs e)
        {
            pnlAgentOrder.Visible = false;
            pnlEmployee.Visible = false;

            upMain.Update();
        }

        #endregion

        public void BindDropDwon()
        {
            DS = new DataSet();
            DS = BindCommanData.BindCommanDropDwon("RouteID ", "RouteCode +' '+RouteName as Name  ", "routeMaster", "IsArchive=1 ");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpagentRoute.DataSource = DS;
                dpagentRoute.DataBind();
                dpagentRoute.Items.Insert(0, new ListItem("--Select Agent Route  --", "0"));

                dpEmploueeRoute.DataSource = DS;
                dpEmploueeRoute.DataBind();
                dpEmploueeRoute.Items.Insert(0, new ListItem("--Select Agent Route  --", "0"));

            }
            DS.Clear();
            DS = BindCommanData.BindCommanDropDwon("EmployeeID", "EmployeeCode+' '+EmployeeName as Name", "employeemaster", "IsActive=1");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                //dpAgentSelasEMployee.DataSource = DS;
                //dpAgentSelasEMployee.DataBind();
                //dpAgentSelasEMployee.Items.Insert(0, new ListItem("--Select Agent Sales Person  --", "0"));

                //dpEmploueeSalesPErsion.DataSource = DS;
                //dpEmploueeSalesPErsion.DataBind();
                //dpEmploueeSalesPErsion.Items.Insert(0, new ListItem("--Select Employee Sales Person  --", "0"));


                dpEmployee.DataSource = DS;
                dpEmployee.DataBind();
                dpEmployee.Items.Insert(0, new ListItem("--Select Employee  --", "0"));



            }
            DS = BindCommanData.BindCommanDropDwon("AgentID", "AgentCode+' '+AgentName as Name", "AgentMaster", "IsArchive=0 and Isactive=1 and Agensytype='Agency' Order by AgentCode");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpAgent.DataSource = DS;
                dpAgent.DataBind();
                dpAgent.Items.Insert(0, new ListItem("--Select Agent  --", "0"));
            }
            DS.Clear();
            DS = BindCommanData.BindCommanDropDwon("CategoryId", "CategoryName", "Category", "IsActive=1");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpBrand.DataSource = DS;
                dpBrand.DataBind();
                dpBrand.Items.Insert(0, new ListItem("--Select Brand  --", "0"));
            }

            DS.Clear();
            DS = BindCommanData.BindCommanDropDwon("TypeID", "TypeName", "TypeMaster", "IsArchive=1 ");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpAgentProductType.DataSource = DS;
                dpAgentProductType.DataBind();
                dpAgentProductType.Items.Insert(0, new ListItem("--Select Product Type  --", "0"));



                dpEmployeeProductType.DataSource = DS;
                dpEmployeeProductType.DataBind();
                dpEmployeeProductType.Items.Insert(0, new ListItem("--Select Product Type  --", "0"));


            }
        }
        protected void dpAgentProductType_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            DS = new DataSet();

            //  DS = BindCommanData.BindTypeDropDwon("Products.productId", "ProductName+' '+Productcode as product", " TypeMaster ", " BindSlab", " TypeMaster.TypeID = BindSlab.TypeID ", "BindSlab.AgentID = 110 ");

            DS = BindCommanData.BindTypeDropDwon("Products.productId", "Products.ProductName+' '+Products.Productcode as product", "Products", "BindSlab", "Products.TypeID = Bindslab.TypeID", "Products.TypeID =" + Convert.ToInt32(dpAgentProductType.SelectedItem.Value) + " and BindSlab.AgentID =" + Convert.ToInt32(dpAgent.SelectedItem.Value) + " and BindSlab.SlabID = Products.SlabID and BindSlab.IsArchive=0 order by Products.ProductName");

            // DS = BindCommanData.BindCommanDropDwon("Products.ProductID", "Commodity.CommodityName+' '+Products.ProductName as product", "Commodity, Products", "   Products.CommodityID = Commodity.CommodityID");

            dpAgentProductdetaisl.DataSource = DS;
            dpAgentProductdetaisl.DataBind();
            dpAgentProductdetaisl.Items.Insert(0, new ListItem("--Select Product  --", "0"));
            dpAgentProductdetaisl.Focus();
            upMain.Update();


        }

        #region AddAgentSheme
        protected void dpAgentShemeApplied_SelectedIndexChanged(object sender, EventArgs e)
        {
            schemeApplied = false;
            if (dpAgentShemeApplied.SelectedItem.Value == "1")
            {
                int result = 0;
                Invoice inovice = new Invoice();
                InvoiceData invoiceData = new InvoiceData();
                inovice.TokanId = hftokanno.Value;
                inovice.UserID = GlobalInfo.Userid;
                inovice.AgencyID = Convert.ToInt32(dpAgent.SelectedItem.Value);
                inovice.orderDate = (Convert.ToDateTime(txtGentOrderDate.Text)).ToString("dd-MM-yyyy");
                DataSet DS = new DataSet();
                DS = invoiceData.chkScheme(inovice);
                if (!Comman.Comman.IsDataSetEmpty(DS))
                {
                    result = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Count"].ToString()) ? 0 : Convert.ToInt32(DS.Tables[0].Rows[0]["Count"]);
                    int res = string.IsNullOrEmpty(DS.Tables[1].Rows[0]["CountTemp"].ToString()) ? 0 : Convert.ToInt32(DS.Tables[1].Rows[0]["CountTemp"]);
                    if (result == 0 && res ==0)
                    { AddAgentShemeDetails(Convert.ToInt32(dpAgent.SelectedItem.Value)); }
                    else
                    { ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Scheme Already Deposited')", true);

                    dpAgentShemeApplied.ClearSelection();
                    }
                }
                else
                {
                    schemeTemp = 0;

                    //dpAgentShemeApplied.Text = "Not Apply";
                }
            }
            else
            {

            }
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
                    invicedata.InsertTempInvoiceItam(invocie);
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
        #endregion


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
            rpAgentOrderdetails.DataSource = invicedata.GetTempItam(invocie);
            rpAgentOrderdetails.DataBind();
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
            Invoice invocie = new Invoice();
            InvoiceData invicedata = new InvoiceData();
            invocie.AgencyID = Convert.ToInt32(dpAgent.SelectedItem.Value);
            invocie.ROuteID = Convert.ToInt32(dpagentRoute.SelectedItem.Value);
            DS = invicedata.GetPreviousDayOrder(invocie);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                RemoveAllItam();

                PrvAgentID = Convert.ToInt32(DS.Tables[0].Rows[0]["AgentID"]);
                PrvOrderID = Convert.ToInt32(DS.Tables[0].Rows[0]["OrderID"]);


                foreach (DataRow row in DS.Tables[0].Rows)
                {
                    invocie.TokanId = hftokanno.Value;
                    invocie.UserID = GlobalInfo.Userid;
                    invocie.ProductID = Convert.ToInt32(row["ProductID"]);
                    invocie.qty = Convert.ToDouble(row["Qty"]);
                    invocie.UnitCost = Convert.ToDouble(row["UnitCost"]);
                    invocie.totalCoast = Convert.ToDouble(row["Total"]);
                    invocie.TypeID = Convert.ToInt32(row["TypeID"]);
                    totsum = totsum + Convert.ToDouble(row["Total"]);
                    invicedata.InsertTempInvoiceItam(invocie);
                    BindAgntTempItam(invocie);



                    //Label lblFInaltotal = Label.FindControl("lblFInaltotal");
                    //Label lblFInaltotal = (Label)rpAgentOrderdetails.Items[0].FindControl("lblFInaltotal");
                    //lblFInaltotal.Text = totsum.ToString();
                    // txtGentOrderDate.Text= DateTime.Now.ToString("MM-dd-yyyy");
                    txtagentOrderqty.Text = "0";
                }

            }
            else
            {
                PrvOrderID = 0;
                RemoveAllItam();
            }


            dpAgent.Focus();
       


        }

        
        protected void btnAddAgentProductItem_click(object sender, EventArgs e)
        {
          

            totsum = 0;
            Invoice invocie = new Invoice();
            InvoiceData invicedata = new InvoiceData();
            invocie.TokanId = hftokanno.Value;
            invocie.UserID = GlobalInfo.Userid;
            invocie.TypeID = Convert.ToInt32(dpAgentProductType.SelectedItem.Value);
            invocie.ProductID = Convert.ToInt32(dpAgentProductdetaisl.SelectedItem.Value);
            invocie.qty = Convert.ToDouble(txtagentOrderqty.Text);
            invocie.UnitCost = Convert.ToDouble(hfAgentProductUnitPrice.Value);
            invocie.totalCoast = Convert.ToDouble(txtagentOrderqty.Text) * Convert.ToDouble(hfAgentProductUnitPrice.Value);
            int flag = 1;
            bool result = invicedata.CheckTempInvoiceItam(invocie, flag);
                if(!result)
                {
                invicedata.InsertTempInvoiceItam(invocie);
                BindAgntTempItam(invocie);
                }
            else{
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Item already exists')", true);
                }
        }
        public void btnAgentORderSubmit_click(object sender, EventArgs e)
        {
            
            totsum = 0;
            int result = 0;
            Invoice inovice = new Invoice();
            InvoiceData invoiceData = new InvoiceData();
            inovice.orderDate = (Convert.ToDateTime(txtGentOrderDate.Text)).ToString("dd-MM-yyyy");
            inovice.AgencyID = Convert.ToInt32(dpAgent.SelectedItem.Value);

            inovice.ROuteID = Convert.ToInt32(dpagentRoute.SelectedItem.Value);
            inovice.SaleEmployeeId = 0;//Convert.ToInt32(dpAgentSelasEMployee.SelectedItem.Value);
            inovice.totalCoast = string.IsNullOrEmpty(hftotalAmout.Value) ? 0 : Comman.Comman.IsValidInteger(hftotalAmout.Value) ? Convert.ToDouble(hftotalAmout.Value) : 0;
            inovice.CreatedBy = GlobalInfo.Userid;
            inovice.CreatedDate = DateTime.Now.ToString("MM-dd-yyyy");
            inovice.TokanId = hftokanno.Value;
            inovice.TotalSchemeAmount = schemeTemp;
            inovice.ShecemeApplied = schemeApplied;
            inovice.orderid = PrvOrderID; //previous order id
            inovice.orderType = 1;// Agent order

            DataSet chkds = new DataSet();
            int chkflg = 2;
            chkds = invoiceData.CheckBoothTemp(inovice, chkflg);
            if (!Comman.Comman.IsDataSetEmpty(chkds))
            {
                result = invoiceData.InsertOrder(inovice);
            }
            if (result > 0)
            {
              
                btnAddAgentProductItem.Visible = false;
                btnagentItamsremove.Visible = false;
                btnAgentORderSubmit.Visible = false;
               
                clearAgentValues();
                txtagentOrderqty.Text = "0";
                BindAgntTempItam(inovice);
                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                schemeApplied = false;
                pnlError.Update();
                PrvOrderID = 0;
                schemeTemp = 0;
                upMain.Update();

               
               
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
        public void clearAgentValues()
        {
            txtagentOrderqty.Text = string.Empty;
           // txtGentOrderDate.Text = string.Empty;
            //dpAgentSelasEMployee.ClearSelection();
            //dpagentRoute.ClearSelection();
            dpAgent.ClearSelection();
            dpAgentProductdetaisl.ClearSelection();
            dpAgentProductType.ClearSelection();
            dpAgentShemeApplied.ClearSelection();


        }
        public void btnagentItamsremove_click(object sender, EventArgs e)
        {
            totsum = 0;
            RemoveAllItam();
            //clearAgentValues();
        }
        
        public void btnAgentNewOrder_clcik(object sender, EventArgs e)
        {
           
            dpAgent.Enabled = true;
            totsum = 0;
            PrvOrderID = 0;
            schemeTemp = 0;
            clearAgentValues();
            //DataSet Ds = new DataSet();
            //dpagentRoute.DataSource = Ds;
            //dpagentRoute.DataBind();
            dpAgentProductdetaisl.Items.Clear();
            RemoveAllItam();
            divDanger.Visible = false;
            divwarning.Visible = false;
            divSusccess.Visible = false;

            btnAddAgentProductItem.Visible = true;
            btnagentItamsremove.Visible = true;
            btnAgentORderSubmit.Visible = true;
            pnlError.Update();
            upMain.Update();
      
         
            //Redirect("~/Tabs/Administration/PlaceOrder.aspx");
           

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
                if (lblFInaltotal != null && totsum ==0 )
                {
                    lblFInaltotal.Text = total.ToString("#0.00");
                    hftotalAmout.Value = total.ToString("#0.00");
                }
                else if (lblFInaltotal != null && totsum != 0)
                {
                    lblFInaltotal.Text = totsum.ToString("#0.00");
                    hftotalAmout.Value = totsum.ToString("#0.00");
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
            invicedata.TempDelete(tempID);

        }
        public void RemoveAllItam()
        {
            Invoice invocie = new Invoice();
            InvoiceData invicedata = new InvoiceData();
            invocie.TokanId = hftokanno.Value;
            invocie.UserID = GlobalInfo.Userid;
            invicedata.DeleteItes(invocie);
            BindAgntTempItam(invocie);
            upMain.Update();
        }

        //employee

        protected void dpEmployeeProducttype_IndexChanged(object sender, EventArgs e)
        {
            DS = new DataSet();

            //string ptype = Convert.ToString(dpEmployeeProductType.SelectedItem.Text);
            int ptype = Convert.ToInt32(dpEmployeeProductType.SelectedItem.Value);
            double count = string.IsNullOrEmpty(hfTotalCansume.Value) ? 0 :  Convert.ToDouble(hfTotalCansume.Value) ;
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
            Invoice inovicesa = new Invoice();
            InvoiceData invoiceDatasa = new InvoiceData();
            inovicesa.orderDate = (Convert.ToDateTime(txtEmployeeOrderDate.Text)).ToString("dd-MM-yyyy");
            inovicesa.ROuteID = Convert.ToInt32(dpEmploueeRoute.SelectedItem.Value);
            inovicesa.EmployeeID = Convert.ToInt32(dpEmployee.SelectedItem.Value);
            inovicesa.orderType = 2;// employeeORder
            DataSet ckpreviousemporder = new DataSet();
            ckpreviousemporder = invoiceDatasa.Checkempduplicateorder(inovicesa);
            if (!Comman.Comman.IsDataSetEmpty(ckpreviousemporder))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "confirm", "confirm('On This Route Employee Order Already exists')", true);
                dpEmployee.ClearSelection();
            }
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
                double count = string.IsNullOrEmpty(hfTotalCansume.Value) ? 0 :  Convert.ToDouble(hfTotalCansume.Value) ;
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

            Invoice invocie = new Invoice();
            InvoiceData invicedata = new InvoiceData();
            invocie.TokanId = hftokanno.Value;
            invocie.UserID = GlobalInfo.Userid;
            invocie.TypeID = Convert.ToInt32(dpEmployeeProductType.SelectedItem.Value);
            invocie.ProductID = Convert.ToInt32(dpEmployeeProductDetails.SelectedItem.Value);
            invocie.qty = Convert.ToDouble(txtQtyEmployee.Text);
            invocie.UnitCost = Convert.ToDouble(hfEmployeeProductUnitPrice.Value);
            invocie.totalCoast = Convert.ToDouble(txtQtyEmployee.Text) * Convert.ToDouble(hfEmployeeProductUnitPrice.Value);
            //invicedata.InsertTempInvoiceItam(invocie);
            //BindEmployeeOrderDetails(invocie);
            //upMain.Update();
            int flag = 1;
            bool result = invicedata.CheckTempInvoiceItam(invocie, flag);
            if (!result)
            {
                invicedata.InsertTempInvoiceItam(invocie);
                BindEmployeeOrderDetails(invocie);
                upMain.Update();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Item already exists')", true);
            }

        }
        public void BindEmployeeOrderDetails(Invoice invocie)
        {
            InvoiceData invicedata = new InvoiceData();
            rpEmployeeDetails.DataSource = invicedata.GetTempItam(invocie);
            rpEmployeeDetails.DataBind();
        }
        protected void btnEmployeeNewOrder_click(object sender, EventArgs e)
        {
          
            ClereEmployee();
            RemoveAllEmployeeItam();
            upMain.Update();
            dpEmployeeProductDetails.Items.Clear();
            btnAddEmployeeOrderItem.Visible = true;
            Button1.Visible = true;
            Button2.Visible = true;

            divDanger.Visible = false;
            divwarning.Visible = false;
            divSusccess.Visible = false;
            pnlError.Update();
            upMain.Update();


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
                    hfemployeeTotalBill.Value = total.ToString("#0.00");
                }

            }
        }

        protected void btnemployeeOrdersubmit_click(object sender, EventArgs e)
        {
           
            int result = 0;
            Invoice inovice = new Invoice();
            InvoiceData invoiceData = new InvoiceData();
            inovice.orderDate =  (Convert.ToDateTime(txtEmployeeOrderDate.Text)).ToString("dd-MM-yyyy");
            inovice.AgencyID = 0;
            inovice.ShecemeApplied = true;
            inovice.ROuteID = Convert.ToInt32(dpEmploueeRoute.SelectedItem.Value);
            inovice.SaleEmployeeId = 0;// Convert.ToInt32(dpEmploueeSalesPErsion.SelectedItem.Value);
            inovice.EmployeeID = Convert.ToInt32(dpEmployee.SelectedItem.Value);
            inovice.totalCoast = string.IsNullOrEmpty(hfemployeeTotalBill.Value) ? 0 : Comman.Comman.IsValidInteger(hfemployeeTotalBill.Value) ? Convert.ToDouble(hfemployeeTotalBill.Value) : 0;
            inovice.CreatedBy = GlobalInfo.Userid;
            inovice.CreatedDate = DateTime.Now.ToString("MM-dd-yyyy");
            inovice.TokanId = hftokanno.Value;
            inovice.orderType = 2;// employeeORder

            DataSet chkds = new DataSet();
            int chkflg = 2;
            chkds = invoiceData.CheckBoothTemp(inovice, chkflg);
        
            if (!Comman.Comman.IsDataSetEmpty(chkds))
            {
               
                    result = invoiceData.InsertOrder(inovice);
              
            }
            if (result > 0)
            {
              
                btnAddEmployeeOrderItem.Visible = false;
                Button1.Visible = false;
                Button2.Visible = false;
                ClereEmployee();
                txtagentOrderqty.Text = "0";
                inovice.TokanId = hftokanno.Value;
                inovice.CreatedBy = GlobalInfo.Userid;
                BindEmployeeOrderDetails(inovice);
                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                pnlError.Update();
                upMain.Update();
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
        public void ClereEmployee()
        {
            //txtEmployeeOrderDate.Text = string.Empty;
            dpEmployee.ClearSelection();
            // dpSelaesPerson.ClearSelection();
            //dpEmploueeRoute.ClearSelection();
            txtQtyEmployee.Text = string.Empty;
            dpEmployeeProductDetails.ClearSelection();
            // dpEmploueeSalesPErsion.ClearSelection();
            dpEmployeeProductType.ClearSelection();

        }

        protected void dpBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            DS = BindCommanData.BindCommanDropDwon("TypeID", "TypeName", "TypeMaster", "IsArchive=1 and CategoryId =" + dpBrand.SelectedItem.Value.ToString());
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpAgentProductType.ClearSelection();
                dpAgentProductType.DataSource = DS;
                dpAgentProductType.DataBind();
                dpAgentProductType.Items.Insert(0, new ListItem("--Select Product Type  --", "0"));
                dpAgentProductType.Focus();

            }
        }
        protected void dpagentRoute_SelectedIndexChanged(object sender, EventArgs e)
        {

            //DS = BindCommanData.BindCommanDropDwon("AgentID", "AgentName+' '+AgentCode as Name", "AgentMaster", "RouteID=" + dpagentRoute.SelectedItem.Value.ToString() + "and IsArchive=0 and Agensytype='Agency'");
            //if (!Comman.Comman.IsDataSetEmpty(DS))
            //{
            //    dpAgent.ClearSelection();
            //    dpAgent.DataSource = DS;
            //    dpAgent.DataBind();
            //    dpAgent.Items.Insert(0, new ListItem("--Select Agent  --", "0"));
            //}
            dpagentRoute.Focus();
        }
        public void btnemployeeRemoveAllItem_click(object sender, EventArgs e)
        {
            RemoveAllEmployeeItam();
        }
       
          public void RemoveAllEmployeeItam()
        {
             Invoice invocie = new Invoice();
            InvoiceData invicedata = new InvoiceData();
            invocie.TokanId = hftokanno.Value;
            invocie.UserID = GlobalInfo.Userid;
            invicedata.DeleteItes(invocie);
            BindEmployeeOrderDetails(invocie);
            upMain.Update();
        }
         


    }
}