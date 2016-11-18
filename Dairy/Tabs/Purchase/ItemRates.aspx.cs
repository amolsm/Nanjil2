using Bussiness;
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
    public partial class ItemRates : System.Web.UI.Page
    {
        DataSet DS;
        PurchaseData purchaseData;
        ItemRate itemRate;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDown();
               
            }
        }

        private void BindDropDown()
        {
            DataSet DS = new DataSet();


            DS = BindCommanData.BindCommanDropDwon("VendorId as Id", "VendorCode +' '+ VendorName as Name", "Prchs_Vendor", "IsActive = 1");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpVendor.DataSource = DS;
                dpVendor.DataBind();
                dpVendor.Items.Insert(0, new ListItem("--Select Vendor--", "0"));

                dpVendor1.DataSource = DS;
                dpVendor1.DataBind();
                dpVendor1.Items.Insert(0, new ListItem("--Select Vendor--", "0"));
            }

            //DS = BindCommanData.BindCommanDropDwon("VendorId as Id", "VendorCode +' '+ VendorName as Name", "Prchs_Vendor", "IsActive = 1");
            //if (!Comman.Comman.IsDataSetEmpty(DS))
            //{
                
            //}

            DS = BindCommanData.BindCommanDropDwon("ItemId as Id", "ItemName as Name", "Prchs_Items", "IsActive = 1");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpItem.DataSource = DS;
                dpItem.DataBind();
                dpItem.Items.Insert(0, new ListItem("--Select Item--", "0"));
            }

            DS = BindCommanData.BindCommanDropDwon("UnitID as Id", "UnitName as Name", "Unit", "UnitID is not null");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpUnit.DataSource = DS;
                dpUnit.DataBind();
                dpUnit.Items.Insert(0, new ListItem("--Select Unit--", "0"));
            }

        }

        protected void rpItemRatesList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            divDanger.Visible = false;
            divwarning.Visible = false;
            divSusccess.Visible = false;
            //pnlError.Update();
            int ItemRateId = 0;
            ItemRateId = Convert.ToInt32(e.CommandArgument);
            switch (e.CommandName)
            {
                case ("Edit"):
                    {

                        hfItemRatesId.Value = ItemRateId.ToString();
                        ItemRateId = Convert.ToInt32(hfItemRatesId.Value);
                        GetDetailsById(ItemRateId);
                        upModal.Update();
                        uprouteList.Update();
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", " $('#myModal').modal();", true);
                      
                        SelDropDown();
                      
                        break;
                    }
               


            }
        }

        private void GetDetailsById(int itemRateId)
        {
            itemRate = new ItemRate();
            purchaseData = new PurchaseData();
            DataSet DS = new DataSet();

            itemRate.ItemRatesId = itemRateId;
            
            itemRate.Flag = 2;

            DS = purchaseData.GetItemRateList(itemRate);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpVendor1.ClearSelection();
                if (dpVendor1.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["VendorId"]).ToString()) != null)
                {
                    dpVendor1.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["VendorId"]).ToString()).Selected = true;
                }
                
                dpItem.ClearSelection();
                if (dpItem.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["ItemId"]).ToString()) != null)
                {
                    dpItem.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["ItemId"]).ToString()).Selected = true;
                }

                txtQuantity.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Quantity"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Quantity"].ToString();

                dpUnit.ClearSelection();
                if (dpUnit.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["UnitId"]).ToString()) != null)
                {
                    dpUnit.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["UnitId"]).ToString()).Selected = true;
                }
                txtPrice.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Price"].ToString()) ? string.Empty : Convert.ToDecimal( DS.Tables[0].Rows[0]["Price"]).ToString("#0.00");
                txtExcise.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["ExciseDuty"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["ExciseDuty"].ToString();
                txtShipping.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Shipping"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Shipping"].ToString();
                txtCst.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["CST"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["CST"].ToString();
                txtVat.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Vat"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Vat"].ToString();
                txtInsurance.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Insurance"].ToString()) ? string.Empty : Convert.ToDecimal(DS.Tables[0].Rows[0]["Insurance"]).ToString("#0.00");
                txtFreight.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["FreightCharges"].ToString()) ? string.Empty : Convert.ToDecimal(DS.Tables[0].Rows[0]["FreightCharges"]).ToString("#0.00");
                txtTotalPrice.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["TotalPrice"].ToString()) ? string.Empty : Convert.ToDecimal(DS.Tables[0].Rows[0]["TotalPrice"]).ToString("#0.00");

            }
            btnSubmit.Visible = false;
            btnUpdate.Visible = true;
            
            
            
        }

        

        private void UpdateList(int id)
        {
            DS = new DataSet();
            itemRate = new ItemRate();
            purchaseData = new PurchaseData();

            itemRate.VendorId = id;
            itemRate.Flag = 1; //1 for get by VendorId
            DS = purchaseData.GetItemRateList(itemRate);
            rpItemRatesList.DataSource = DS;
            rpItemRatesList.DataBind();
            SelDropDown();
        }

        private void SelDropDown()
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "sel1", "$('#MainContent_dpVendor').addClass('selectpicker');$('#MainContent_dpVendor').selectpicker();", true);
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            btnUpdate.Visible = false;
            btnSubmit.Visible = true;
            upModal.Update();
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            itemRate = new ItemRate();
            purchaseData = new PurchaseData();

            itemRate.VendorId = Convert.ToInt32(dpVendor1.SelectedItem.Value);
            itemRate.ItemId = Convert.ToInt32(dpItem.SelectedItem.Value);
            itemRate.Quantity = string.IsNullOrEmpty(txtQuantity.Text.ToString()) ? 0 : Convert.ToDouble(txtQuantity.Text);
            itemRate.UnitId = Convert.ToInt32(dpUnit.SelectedItem.Value);
            itemRate.Quantity = string.IsNullOrEmpty(txtQuantity.Text.ToString()) ? 0 : Convert.ToDouble(txtQuantity.Text);
            itemRate.Price = string.IsNullOrEmpty(txtPrice.Text.ToString()) ? 0 : Convert.ToDecimal(txtPrice.Text);
            itemRate.Shipping = string.IsNullOrEmpty(txtShipping.Text.ToString()) ? 0 : Convert.ToDecimal(txtShipping.Text);
            itemRate.Excise = string.IsNullOrEmpty(txtExcise.Text.ToString()) ? 0 : Convert.ToDouble(txtExcise.Text);
            itemRate.CST = string.IsNullOrEmpty(txtCst.Text.ToString()) ? 0 : Convert.ToDouble(txtCst.Text);
            itemRate.VAT = string.IsNullOrEmpty(txtVat.Text.ToString()) ? 0 : Convert.ToDouble(txtVat.Text);
            itemRate.Insurance = string.IsNullOrEmpty(txtInsurance.Text.ToString()) ? 0 : Convert.ToDecimal(txtInsurance.Text);
            itemRate.Freight = string.IsNullOrEmpty(txtFreight.Text.ToString()) ? 0 : Convert.ToDecimal(txtFreight.Text);
            itemRate.TotalPrice = string.IsNullOrEmpty(txtTotalPrice.Text.ToString()) ? 0 : Convert.ToDecimal(txtTotalPrice.Text);

            itemRate.Flag = 1; //1 for INSERT

            int Result = 0;
            Result = purchaseData.ItemRatesDML(itemRate);



            if (Result > 0)
            {
               
                // ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('.modal-backdrop').removeClass(.modal-backdrop);", true);
                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Item Rate Added Successfully";

               ClearTextBox();
               
                pnlError.Update();
                UpdateList(itemRate.VendorId);
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

        private void ClearTextBox()
        {
            dpVendor1.ClearSelection();
            dpItem.ClearSelection();
            dpUnit.ClearSelection();
            txtQuantity.Text = string.Empty;
            txtPrice.Text = string.Empty;
            txtShipping.Text = "0";
            txtExcise.Text = "0";
            txtCst.Text = "0";
            txtVat.Text = "0";
            txtInsurance.Text = "0";
            txtFreight.Text = "0";
            txtTotalPrice.Text = string.Empty;
        }

        protected void btnCloseModal_Click(object sender, EventArgs e)
        {
            ClearTextBox();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            itemRate = new ItemRate();
            purchaseData = new PurchaseData();
            itemRate.ItemRatesId = Convert.ToInt32(hfItemRatesId.Value);
            itemRate.VendorId = Convert.ToInt32(dpVendor1.SelectedItem.Value);
            itemRate.ItemId = Convert.ToInt32(dpItem.SelectedItem.Value);
            itemRate.Quantity = string.IsNullOrEmpty(txtQuantity.Text.ToString()) ? 0 : Convert.ToDouble(txtQuantity.Text);
            itemRate.UnitId = Convert.ToInt32(dpUnit.SelectedItem.Value);
            itemRate.Quantity = string.IsNullOrEmpty(txtQuantity.Text.ToString()) ? 0 : Convert.ToDouble(txtQuantity.Text);
            itemRate.Price = string.IsNullOrEmpty(txtPrice.Text.ToString()) ? 0 : Convert.ToDecimal(txtPrice.Text);
            itemRate.Shipping = string.IsNullOrEmpty(txtShipping.Text.ToString()) ? 0 : Convert.ToDecimal(txtShipping.Text);
            itemRate.Excise = string.IsNullOrEmpty(txtExcise.Text.ToString()) ? 0 : Convert.ToDouble(txtExcise.Text);
            itemRate.CST = string.IsNullOrEmpty(txtCst.Text.ToString()) ? 0 : Convert.ToDouble(txtCst.Text);
            itemRate.VAT = string.IsNullOrEmpty(txtVat.Text.ToString()) ? 0 : Convert.ToDouble(txtVat.Text);
            itemRate.Insurance = string.IsNullOrEmpty(txtInsurance.Text.ToString()) ? 0 : Convert.ToDecimal(txtInsurance.Text);
            itemRate.Freight = string.IsNullOrEmpty(txtFreight.Text.ToString()) ? 0 : Convert.ToDecimal(txtFreight.Text);
            itemRate.TotalPrice = string.IsNullOrEmpty(txtTotalPrice.Text.ToString()) ? 0 : Convert.ToDecimal(txtTotalPrice.Text);

            itemRate.Flag = 2; //1 for Update

            int Result = 0;
            Result = purchaseData.ItemRatesDML(itemRate);



            if (Result > 0)
            {

                // ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('.modal-backdrop').removeClass(.modal-backdrop);", true);
                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Item Rate Updated Successfully";

                ClearTextBox();
                
                pnlError.Update();
                UpdateList(itemRate.VendorId);
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


        #region TextChangesEvents

        private void CalculateTotalPrice()
        {
            txtTotalPrice.Text = ((string.IsNullOrEmpty(txtPrice.Text) ? 0 : Convert.ToDecimal(txtPrice.Text)) + (string.IsNullOrEmpty(txtPrice.Text) ? 0 : Convert.ToDecimal(txtShipping.Text)) + ((string.IsNullOrEmpty(txtPrice.Text) ? 0 : Convert.ToDecimal(txtPrice.Text)) / 100 * (string.IsNullOrEmpty(txtExcise.Text) ? 0 : Convert.ToDecimal(txtExcise.Text))) + ((string.IsNullOrEmpty(txtPrice.Text) ? 0 : Convert.ToDecimal(txtPrice.Text)) / 100 * (string.IsNullOrEmpty(txtCst.Text) ? 0 : Convert.ToDecimal(txtCst.Text))) + ((string.IsNullOrEmpty(txtPrice.Text) ? 0 : Convert.ToDecimal(txtPrice.Text)) / 100 * (string.IsNullOrEmpty(txtVat.Text) ? 0 : Convert.ToDecimal(txtVat.Text))) + (string.IsNullOrEmpty(txtInsurance.Text) ? 0 : Convert.ToDecimal(txtInsurance.Text)) + (string.IsNullOrEmpty(txtFreight.Text) ? 0 : Convert.ToDecimal(txtFreight.Text))).ToString();

            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
        }

        protected void txtPrice_TextChanged(object sender, EventArgs e)
        {
            CalculateTotalPrice();
        }

        

        protected void txtShipping_TextChanged(object sender, EventArgs e)
        {
            CalculateTotalPrice();
        }

        protected void txtExcise_TextChanged(object sender, EventArgs e)
        {
            CalculateTotalPrice();
        }

        protected void txtCst_TextChanged(object sender, EventArgs e)
        {
            CalculateTotalPrice();
        }

        protected void txtVat_TextChanged(object sender, EventArgs e)
        {
            CalculateTotalPrice();
        }

        protected void txtInsurance_TextChanged(object sender, EventArgs e)
        {
            CalculateTotalPrice();
        }

        protected void txtFreight_TextChanged(object sender, EventArgs e)
        {
            CalculateTotalPrice();
        }

        #endregion

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dpVendor.SelectedItem.Value);

            UpdateList(id);
        }
    }
}