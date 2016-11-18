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
    public partial class MaterialReceived : System.Web.UI.Page
    {
        PurchaseData purchaseData;
        DataSet DS;
        Order order;
        MRN mrn;
        MRNDetails mrnDetails;
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

            DS.Clear();
            DS = BindCommanData.BindCommanDropDwon("EmployeeID as ID", "EmployeeCode +' ' +EmployeeName as Name", "EmployeeMaster", "IsActive = 1");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpApprovedBy.DataSource = DS;
                dpApprovedBy.DataBind();
                dpApprovedBy.Items.Insert(0, new ListItem("--Select Employee--", "0"));
            }
            DS.Clear();
            DS = BindCommanData.BindCommanDropDwon("EmployeeID as ID", "EmployeeCode +' ' +EmployeeName as Name", "EmployeeMaster", "IsActive = 1");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpReceivedBy.DataSource = DS;
                dpReceivedBy.DataBind();
                dpReceivedBy.Items.Insert(0, new ListItem("--Select Employee--", "0"));
            }
            DS.Clear();
            DS = BindCommanData.BindCommanDropDwon("EmployeeID as ID", "EmployeeCode +' ' +EmployeeName as Name", "EmployeeMaster", "IsActive = 1");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpFinanceMgr.DataSource = DS;
                dpFinanceMgr.DataBind();
                dpFinanceMgr.Items.Insert(0, new ListItem("--Select Employee--", "0"));
            }
            DS.Clear();
            DS = BindCommanData.BindCommanDropDwon("EmployeeID as ID", "EmployeeCode +' ' +EmployeeName as Name", "EmployeeMaster", "IsActive = 1");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpQcBy.DataSource = DS;
                dpQcBy.DataBind();
                dpQcBy.Items.Insert(0, new ListItem("--Select Employee--", "0"));
            }
        }

        protected void dpVendor_SelectedIndexChanged(object sender, EventArgs e)
        {
            DS = new DataSet();
            DS = BindCommanData.BindCommanDropDwon("OrderId as ID", " 'NIDD-PO-' + Convert(nvarchar(max), OrderId) as Name", "Prchs_Order", "Delivered = 0 and VendorId = " + dpVendor.SelectedItem.Value);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpPOCode.DataSource = DS;
                dpPOCode.DataBind();
                dpPOCode.Items.Insert(0, new ListItem("--Select Order--", "0"));
            }
            dpSelect();
        }

        private void dpSelect()
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "sel2", "$('#MainContent_dpVendor').addClass('selectpicker');$('#MainContent_dpVendor').selectpicker();", true);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "sel3", "$('#MainContent_dpPOCode').addClass('selectpicker');$('#MainContent_dpPOCode').selectpicker();", true);

            ScriptManager.RegisterStartupScript(this, this.GetType(), "sel4", "$('#MainContent_dpReceivedBy').addClass('selectpicker');$('#MainContent_dpReceivedBy').selectpicker();", true);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "sel5", "$('#MainContent_dpQcBy').addClass('selectpicker');$('#MainContent_dpQcBy').selectpicker();", true);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "sel6", "$('#MainContent_dpFinanceMgr').addClass('selectpicker');$('#MainContent_dpFinanceMgr').selectpicker();", true);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "sel7", "$('#MainContent_dpApprovedBy').addClass('selectpicker');$('#MainContent_dpApprovedBy').selectpicker();", true);
        }

               

        protected void dpPOCode_SelectedIndexChanged1(object sender, EventArgs e)
        {
            purchaseData = new PurchaseData();
            DS = new DataSet();
            order = new Order();
            order.OrderId = Convert.ToInt32(dpPOCode.SelectedItem.Value);
            order.Flag = 3;
            order.OrderDate = string.Empty;
            rpAgentOrderdetails.DataSource = purchaseData.GetOrderList(order);
            rpAgentOrderdetails.DataBind();

            dpSelect();
        }

        protected void rpAgentOrderdetails_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

       

        protected void txtAcceptedQty_TextChanged(object sender, EventArgs e)
        {
            TextBox tb1 = ((TextBox)(sender));
            RepeaterItem rp1 = ((RepeaterItem)(tb1.NamingContainer));
            //TextBox txtAcceptedQty = (TextBox)rp1.FindControl("txtAcceptedQty");
            Label lbltotal = (Label)rp1.FindControl("lbltotal");
            Label lblPrice = (Label)rp1.FindControl("lblPrice");
            HiddenField hfexcise = (HiddenField)rp1.FindControl("hfExcise");
            HiddenField hfCst = (HiddenField)rp1.FindControl("hfCst");
            HiddenField hfVat = (HiddenField)rp1.FindControl("hfVat");

            lbltotal.Text = (Convert.ToDouble(tb1.Text) * (Convert.ToDouble(lblPrice.Text) + ((Convert.ToDouble(lblPrice.Text)/100)* Convert.ToDouble(hfexcise.Value))+ ((Convert.ToDouble(lblPrice.Text) / 100) * Convert.ToDouble(hfVat.Value))+ ((Convert.ToDouble(lblPrice.Text) / 100) * Convert.ToDouble(hfCst.Value)))).ToString("#0.00");
            calTotal();
            dpSelect();
        }

        private void calTotal()
        {
            total = 0;
            foreach (RepeaterItem item in rpAgentOrderdetails.Controls)
            {
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
            
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            foreach (RepeaterItem item in rpAgentOrderdetails.Items)
            {
                TextBox txtReceivedQty = item.FindControl("txtReceivedQty") as TextBox;
                TextBox txtAcceptedQty = item.FindControl("txtAcceptedQty") as TextBox;
                TextBox txtRejectedQty = item.FindControl("txtRejectedQty") as TextBox;
                Label lblQuantity = item.FindControl("lblQuantity") as Label;
                Label lblPrice = item.FindControl("lblPrice") as Label;
                Label lbltotal = item.FindControl("lbltotal") as Label;
                HiddenField hfItemId = item.FindControl("hfItemId") as HiddenField;
                HiddenField hfId = item.FindControl("hfOrderDetailsId") as HiddenField;
                HiddenField hfCst = item.FindControl("hfCst") as HiddenField;
                HiddenField hfExcise = item.FindControl("hfExcise") as HiddenField;
                HiddenField hfVat = item.FindControl("hfVat") as HiddenField;
                if (hfId != null)
                {
                    mrnDetails = new MRNDetails();
                    purchaseData = new PurchaseData();

                    mrnDetails.ItemId = Convert.ToInt32(hfItemId.Value);
                    mrnDetails.OrderDetailsId = Convert.ToInt32(hfId.Value);
                    mrnDetails.OrderedQty = Convert.ToDouble(lblQuantity.Text);
                    mrnDetails.ReceivedQty = string.IsNullOrEmpty(txtReceivedQty.Text)? 0 : Convert.ToDouble(txtReceivedQty.Text);
                    mrnDetails.AcceptedQty = string.IsNullOrEmpty(txtAcceptedQty.Text) ? 0 : Convert.ToDouble(txtAcceptedQty.Text);
                    mrnDetails.RejectedQty = string.IsNullOrEmpty(txtRejectedQty.Text) ? 0 : Convert.ToDouble(txtRejectedQty.Text);
                    mrnDetails.Price = Convert.ToDecimal(lblPrice.Text);
                    mrnDetails.Cst = Convert.ToDouble(hfCst.Value);
                    mrnDetails.Excise = Convert.ToDouble(hfExcise.Value);
                    mrnDetails.Vat = Convert.ToDouble(hfVat.Value);
                    mrnDetails.Amount = Convert.ToDecimal(lbltotal.Text);
                    mrnDetails.Flag = 1;

                    purchaseData.MrnDML(mrnDetails);
                }
            }
            mrn = new MRN();
            mrn.BillDate = (Convert.ToDateTime(txtBillDate.Text)).ToString("dd-MM-yyyy");
            mrn.BillNo = txtBillNumber.Text;
            mrn.VehicleNo = txtVehicleNo.Text;
            mrn.PRNo = txtPRNo.Text;
            mrn.RequiredFor = txtRequiredFor.Text;
            mrn.Remarks = txtRemarks.Text;
            mrn.CreatedBy = GlobalInfo.Userid;
            mrn.ReceivedBy = Convert.ToInt32(dpReceivedBy.SelectedItem.Value);
            mrn.QCBy = Convert.ToInt32(dpQcBy.SelectedItem.Value);
            mrn.FinMgr = Convert.ToInt32(dpFinanceMgr.SelectedItem.Value);
            mrn.ApprovedBy = Convert.ToInt32(dpApprovedBy.SelectedItem.Value);
            mrn.OrderId = Convert.ToInt32(dpPOCode.SelectedItem.Value);
            mrn.TotalAmt = Convert.ToDecimal(hftotalAmout.Value);

            bool result = purchaseData.MrnDML2(mrn);

            if (result)
            {
                
                ClearTexboxes();
                
                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Material Received Note Submitted Successfully";
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

        private void ClearTexboxes()
        {
            dpVendor.ClearSelection();
            dpPOCode.ClearSelection();
            txtBillNumber.Text = string.Empty;
            txtVehicleNo.Text = string.Empty;
            txtPRNo.Text = string.Empty;
            txtRequiredFor.Text = string.Empty;
            txtRemarks.Text = string.Empty;
            dpReceivedBy.ClearSelection();
            dpQcBy.ClearSelection();
            dpFinanceMgr.ClearSelection();
            dpApprovedBy.ClearSelection();
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

        

        protected void rpAgentOrderdetails_ItemCreated(object sender, RepeaterItemEventArgs e)
        {
            RepeaterItem item = e.Item;
           
        }

        
    }
}