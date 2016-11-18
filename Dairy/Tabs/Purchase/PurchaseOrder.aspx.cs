using Bussiness;
using Dairy.App_code;
using Model.Purchase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dairy.Tabs.Purchase
{
    public partial class PurchaseOrder : System.Web.UI.Page
    {
        PurchaseData purchaseData;
        DataSet DS;
        OrderCart orderCart;
        double total = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDown();
                hftokanno.Value = Comman.Comman.RandomString();
            }
        }

        private void BindDropDown()
        {
            DS = new DataSet();
            DS = BindCommanData.BindCommanDropDwon("VendorId as ID", "VendorCode +' ' +VendorName as Name", "Prchs_Vendor", "IsActive = 1");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpVendor.DataSource = DS;
                dpVendor.DataBind();
                dpVendor.Items.Insert(0, new ListItem("--Select Vendor--", "0"));
            }

            DS = BindCommanData.BindTypeDropDwon("RequestDetailsId as ID", "ItemName as Name", "Prchs_RequestDetails", "Prchs_Request", "Prchs_RequestDetails.RequestId = Prchs_Request.RequestId join Prchs_Items  on Prchs_RequestDetails.ItemId = Prchs_Items.ItemId", "Prchs_Request.ReqStatus = 'Approved' and Prchs_RequestDetails.POStat = 0");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpItem.DataSource = DS;
                dpItem.DataBind();
                dpItem.Items.Insert(0, new ListItem("--Select Item--", "0"));
            }
        }

        protected void btnAddItem_Click(object sender, EventArgs e)
        {
            dpVendor.Enabled = false;

            orderCart = new OrderCart();
            purchaseData = new PurchaseData();
            orderCart.Tokan = hftokanno.Value;
            orderCart.CreatedBy = GlobalInfo.Userid;

            orderCart.RequestDetailsId = Convert.ToInt32(dpItem.SelectedItem.Value);
            orderCart.Quantity = Convert.ToDecimal(hfQuantity.Value);
            orderCart.VendorId = Convert.ToInt32(dpVendor.SelectedItem.Value);
            orderCart.Price = Convert.ToDecimal(txtPrice.Text);
            orderCart.Excise = Convert.ToDouble(txtExcise.Text);
            orderCart.cst = Convert.ToDouble(txtCST.Text);
            orderCart.Vat = Convert.ToDouble(txtVat.Text);
            //orderCart.Insurance = Convert.ToDecimal(txtInsurance.Text);
            orderCart.Insurance = 0;
            orderCart.Amt = orderCart.Quantity *(orderCart.Price + (orderCart.Price / 100) * Convert.ToDecimal(orderCart.Excise) + (orderCart.Price / 100) * Convert.ToDecimal(orderCart.cst) + (orderCart.Price / 100) * Convert.ToDecimal(orderCart.Vat) + orderCart.Insurance);

            orderCart.Flag = 1; //1 for INSERT 

            bool result = purchaseData.OrderCartDML(orderCart);
            if (result)
            {
                clearField();
                bindCartList(orderCart);
            }
            dpSelect();
        }

        private void bindCartList(OrderCart orderCart)
        {
            purchaseData = new PurchaseData();
            DS = new DataSet();
            orderCart.Flag = 0; //Get Full List
            rpAgentOrderdetails.DataSource = purchaseData.GetOrderCartList(orderCart);
            rpAgentOrderdetails.DataBind();
        }

        protected void rpAgentOrderdetails_ItemDataBound(object sender, RepeaterItemEventArgs e)
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

        protected void rpAgentOrderdetails_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int TempID = 0;
            TempID = Convert.ToInt32(e.CommandArgument);
            switch (e.CommandName)
            {
                case ("delete"):
                    {

                        orderCart = new OrderCart();
                        purchaseData = new PurchaseData();
                        orderCart.OrderCartId = TempID;
                        orderCart.Tokan = hftokanno.Value;
                        orderCart.CreatedBy = GlobalInfo.Userid;
                        
                        orderCart.Flag = 2; //2 for delete
                        purchaseData.OrderCartDML(orderCart);

                        bindCartList(orderCart);
                        //RemoveTempID(TempID);
                        //invocie.TokanId = hftokanno.Value;
                        //invocie.UserID = GlobalInfo.Userid;
                        //BindAgntTempItam(invocie);
                        upMain.Update();

                        break;
                    }

            }
        }

        protected void btnSubmitPO_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Order order = new Order();
            purchaseData = new PurchaseData();
            orderCart = new OrderCart();

            order.VendorId = Convert.ToInt32(dpVendor.SelectedItem.Value);
            order.CreatedBy = GlobalInfo.Userid;
            order.TillDate = (Convert.ToDateTime(txtTillDate.Text)).ToString("dd-MM-yyyy");
            order.Tokan = hftokanno.Value;
            
                order.Frieght = txtFrieght.Text;
            
            order.PaymentTerms = txtTerms.Text;
            order.TransDamage = txtTrDamage.Text;
            order.Warranty = txtWarranties.Text;
            order.TotalAmt = Convert.ToDecimal(hftotalAmout.Value);
            if (order.TotalAmt > 49999)
                order.MDApproval = "Pending";
            else
                order.MDApproval = "Not Required";
            orderCart.Tokan = hftokanno.Value;

            bool result = purchaseData.SubmitOrder(order);
            if (result)
            {
                
                bindCartList(orderCart);
                clearFields();
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

            dpSelect();
        }

        private void clearFields()
        {
            dpVendor.ClearSelection();
            clearField();
        }

        private void clearField()
        {
            dpItem.ClearSelection();

            txtQuantity.Text = string.Empty;
            txtPrice.Text = string.Empty;
            txtExcise.Text = string.Empty;
            txtVat.Text = string.Empty;
            txtCST.Text = string.Empty;
            //txtInsurance.Text = string.Empty;
            txtFrieght.Text = string.Empty;
            txtTerms.Text = string.Empty;
            txtWarranties.Text = string.Empty;
            txtTrDamage.Text = string.Empty;
        }

        protected void dpItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindTextBoxes();
            dpSelect();


        }

        private void bindTextBoxes()
        {
            DataSet DS = new DataSet();
            DS = BindCommanData.BindTypeDropDwon("Quantity as ID", "UnitName as Name", "Prchs_RequestDetails", "Unit", "Prchs_RequestDetails.UnitId = Unit.UnitID", "RequestDetailsId =" + dpItem.SelectedItem.Value);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                txtQuantity.Text = DS.Tables[0].Rows[0]["ID"].ToString() + " " + DS.Tables[0].Rows[0]["Name"].ToString();
                hfQuantity.Value = DS.Tables[0].Rows[0]["ID"].ToString();
            }

            DS = BindCommanData.BindTypeDropDwon("Price as Price", "ExciseDuty as Excise", "Prchs_RequestDetails", "Prchs_ItemRates", "Prchs_RequestDetails.ItemId = Prchs_ItemRates.ItemId", "Prchs_RequestDetails.RequestDetailsId =" + dpItem.SelectedItem.Value + "and Prchs_ItemRates.VendorId =" + dpVendor.SelectedItem.Value);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                txtPrice.Text = Convert.ToDouble(DS.Tables[0].Rows[0]["Price"]).ToString("#0.00");
                txtExcise.Text = Convert.ToDouble(DS.Tables[0].Rows[0]["Excise"]).ToString("#0.00");
            }
            DS = BindCommanData.BindTypeDropDwon("CST as CST", "Vat as VAT", "Prchs_RequestDetails", "Prchs_ItemRates", "Prchs_RequestDetails.ItemId = Prchs_ItemRates.ItemId", "Prchs_RequestDetails.RequestDetailsId =" + dpItem.SelectedItem.Value + "and Prchs_ItemRates.VendorId =" + dpVendor.SelectedItem.Value);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                txtCST.Text = Convert.ToDouble(DS.Tables[0].Rows[0]["CST"]).ToString("#0.00");
                txtVat.Text = Convert.ToDouble(DS.Tables[0].Rows[0]["VAT"]).ToString("#0.00");
            }
            //DS = BindCommanData.BindTypeDropDwon("Insurance as ins", "Vat as VAT", "Prchs_RequestDetails", "Prchs_ItemRates", "Prchs_RequestDetails.ItemId = Prchs_ItemRates.ItemId", "Prchs_RequestDetails.RequestDetailsId =" + dpItem.SelectedItem.Value + "and Prchs_ItemRates.VendorId =" + dpVendor.SelectedItem.Value);
            //if (!Comman.Comman.IsDataSetEmpty(DS))
            //{
            //    txtInsurance.Text = Convert.ToDouble(DS.Tables[0].Rows[0]["ins"]).ToString("#0.00");
                
            //}
        }

        private void dpSelect()
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "sel2", "$('#MainContent_dpVendor').addClass('selectpicker');$('#MainContent_dpVendor').selectpicker();", true);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "sel3", "$('#MainContent_dpItem').addClass('selectpicker');$('#MainContent_dpItem').selectpicker();", true);

        }

        protected void dpVendor_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindTextBoxes();
            dpSelect();
        }

        protected void chkPrice_CheckedChanged(object sender, EventArgs e)
        {
            if(chkPrice.Checked == true)
                ScriptManager.RegisterStartupScript(this, this.GetType(), "sel22", "$('#MainContent_txtPrice').removeAttr('disabled');", true);
            else
                ScriptManager.RegisterStartupScript(this, this.GetType(), "sel23", "$('#MainContent_txtPrice').attr('disabled', 'disabled');", true);

            dpSelect();
        }

        protected void chkExcise_CheckedChanged(object sender, EventArgs e)
        {
            if (chkExcise.Checked == true)
                ScriptManager.RegisterStartupScript(this, this.GetType(), "sel24", "$('#MainContent_txtExcise').removeAttr('disabled');", true);
            else
                ScriptManager.RegisterStartupScript(this, this.GetType(), "sel25", "$('#MainContent_txtExcise').attr('disabled', 'disabled');", true);

            dpSelect();
        }

        protected void chkCST_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCST.Checked == true)
                ScriptManager.RegisterStartupScript(this, this.GetType(), "sel26", "$('#MainContent_txtCST').removeAttr('disabled');", true);
            else
                ScriptManager.RegisterStartupScript(this, this.GetType(), "sel27", "$('#MainContent_txtCST').attr('disabled', 'disabled');", true);

            dpSelect();
        }

        protected void chkVat_CheckedChanged(object sender, EventArgs e)
        {
            if (chkVat.Checked == true)
                ScriptManager.RegisterStartupScript(this, this.GetType(), "sel28", "$('#MainContent_txtVat').removeAttr('disabled');", true);
            else
                ScriptManager.RegisterStartupScript(this, this.GetType(), "sel29", "$('#MainContent_txtVat').attr('disabled', 'disabled');", true);

            dpSelect();
        }

        //protected void chkInsurance_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chkInsurance.Checked == true)
        //        ScriptManager.RegisterStartupScript(this, this.GetType(), "sel30", "$('#MainContent_txtInsurance').removeAttr('disabled');", true);
        //    else
        //        ScriptManager.RegisterStartupScript(this, this.GetType(), "sel31", "$('#MainContent_txtInsurance').attr('disabled', 'disabled');", true);

        //    dpSelect();
        //}

       
    }
}