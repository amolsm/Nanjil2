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
    public partial class VendorRegistration : System.Web.UI.Page
    {
        Vendor vendor;
        PurchaseData purchaseData;
        DataSet DS;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDown();
                GetList();
            }
        }

        private void BindDropDown()
        {
            DS = new DataSet();
            DS = BindCommanData.BindCommanDropDwonDistinct("LocId", "City as Name", "StateMaster", "LocId is not null");
            dpCity.DataTextField = "Name";
            //dpCity.DataValueField = "LocId";
            dpCity.DataSource = DS;
            dpCity.DataBind();
            dpCity.Items.Insert(0, new ListItem("--Select City--", "0"));

            

            DS = new DataSet();
            DS = BindCommanData.BindCommanDropDwonDistinct("LocId", "State as Name", "StateMaster", "LocId is not null");
           // dpState.DataValueField = "LocId";
            dpState.DataTextField = "Name";
            dpState.DataSource = DS;
            dpState.DataBind();
            dpState.Items.Insert(0, new ListItem("--Select State--", "0"));
        }

        private void GetList()
        {
            vendor = new Vendor();
            purchaseData = new PurchaseData();
            DataSet DS = new DataSet();
            vendor.Flag = 0; //Select * 
            vendor.VendorCode = string.Empty;
            vendor.VendorName = string.Empty;
            vendor.Address = string.Empty;
            vendor.City = string.Empty;
            vendor.State = string.Empty;
            vendor.Mobile = string.Empty;
            vendor.Phone = string.Empty;
            vendor.Email = string.Empty;
            DS = purchaseData.GetVendorsList(vendor);

            if (!Comman.Comman.IsDataSetEmpty(DS))
            {

                rpBrandInfo.DataSource = DS;
                rpBrandInfo.DataBind();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            btnUpdate.Visible = false;
            btnSubmit.Visible = true;
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);

        }

        protected void rpBrandInfo_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            divDanger.Visible = false;
            divwarning.Visible = false;
            divSusccess.Visible = false;
            pnlError.Update();
            int BrandID = 0;
            BrandID = Convert.ToInt32(e.CommandArgument);
            switch (e.CommandName)
            {
                case ("Edit"):
                    {

                        hfBrandId.Value = BrandID.ToString();
                        BrandID = Convert.ToInt32(hfBrandId.Value);
                        GetDetailsById(BrandID);

                        uprouteList.Update();
                        break;
                    }
                case ("delete"):
                    {

                        hfBrandId.Value = BrandID.ToString();
                        BrandID = Convert.ToInt32(hfBrandId.Value);

                        uprouteList.Update();
                        break;
                    }


            }
        }

        private void GetDetailsById(int brandID)
        {
            vendor = new Vendor();
            purchaseData = new PurchaseData();
            DataSet DS = new DataSet();
            vendor.Flag = 2; //Get by ID
            vendor.VendorId = brandID;

            vendor.VendorCode = string.Empty;
            vendor.VendorName = string.Empty;
            vendor.Address = string.Empty;
            vendor.City = string.Empty;
            vendor.State = string.Empty;
            vendor.Mobile = string.Empty;
            vendor.Phone = string.Empty;
            vendor.Email = string.Empty;

            DS = purchaseData.GetVendorsList(vendor);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                txtVendorCode.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["VendorCode"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["VendorCode"].ToString();
                txtVendorName.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["VendorName"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["VendorName"].ToString();
                txtAddress.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Address"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Address"].ToString();
                txtMobile.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Mobile"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Mobile"].ToString();
                txtPhone.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Phone"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Phone"].ToString();
                txtEmail.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Email"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Email"].ToString();

                dpIsActive.ClearSelection();
                if (DS.Tables[0].Rows[0]["Isactive"].ToString() == "True")
                {
                    dpIsActive.Items.FindByValue("1").Selected = true;
                }
                if (DS.Tables[0].Rows[0]["Isactive"].ToString() == "False")
                {
                    dpIsActive.Items.FindByValue("2").Selected = true;
                }
                dpCity.ClearSelection();
                if (dpCity.Items.FindByText(DS.Tables[0].Rows[0]["City"].ToString()) != null)
                {
                    dpCity.Items.FindByText(DS.Tables[0].Rows[0]["City"].ToString()).Selected = true;
                }
                dpState.ClearSelection();
                if (dpState.Items.FindByText(DS.Tables[0].Rows[0]["State"].ToString()) != null)
                {
                    dpState.Items.FindByText(DS.Tables[0].Rows[0]["State"].ToString()).Selected = true;
                }
            }
            btnSubmit.Visible = false;
            btnUpdate.Visible = true;
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            vendor = new Vendor();
            purchaseData = new PurchaseData();

            vendor.VendorName = string.IsNullOrEmpty(txtVendorName.Text.ToString()) ? string.Empty : Convert.ToString(txtVendorName.Text);
            vendor.VendorCode = string.IsNullOrEmpty(txtVendorCode.Text.ToString()) ? string.Empty : Convert.ToString(txtVendorCode.Text);
            vendor.Address = string.IsNullOrEmpty(txtAddress.Text.ToString()) ? string.Empty : Convert.ToString(txtAddress.Text);
            vendor.Mobile = string.IsNullOrEmpty(txtMobile.Text.ToString()) ? string.Empty : Convert.ToString(txtMobile.Text);
            vendor.Phone = string.IsNullOrEmpty(txtPhone.Text.ToString()) ? string.Empty : Convert.ToString(txtPhone.Text);
            vendor.Email = string.IsNullOrEmpty(txtEmail.Text.ToString()) ? string.Empty : Convert.ToString(txtEmail.Text);
            if (dpIsActive.SelectedItem.Value == "1")
                vendor.IsActive = true;
            else vendor.IsActive = false;
            vendor.City = dpCity.SelectedItem.Text.ToString();
            vendor.State = dpState.SelectedItem.Text.ToString();

            vendor.Flag = 1; //1 for INSERT

            int Result = 0;

            Result = purchaseData.VendorDML(vendor);



            if (Result > 0)
            {

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Vendor Added  Successfully";

                ClearTextBox();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "rem1", "$('.modal-backdrop').remove();", true);
                GetList();
                pnlError.Update();
                uprouteList.Update();
                
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
            txtVendorCode.Text = string.Empty;
            txtVendorName.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtMobile.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtEmail.Text = string.Empty;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            vendor = new Vendor();
            purchaseData = new PurchaseData();
            vendor.VendorId = string.IsNullOrEmpty(hfBrandId.Value) ? 0 : Convert.ToInt32(hfBrandId.Value);
            vendor.VendorName = string.IsNullOrEmpty(txtVendorName.Text.ToString()) ? string.Empty : Convert.ToString(txtVendorName.Text);
            vendor.VendorCode = string.IsNullOrEmpty(txtVendorCode.Text.ToString()) ? string.Empty : Convert.ToString(txtVendorCode.Text);
            vendor.Address = string.IsNullOrEmpty(txtAddress.Text.ToString()) ? string.Empty : Convert.ToString(txtAddress.Text);
            vendor.Mobile = string.IsNullOrEmpty(txtMobile.Text.ToString()) ? string.Empty : Convert.ToString(txtMobile.Text);
            vendor.Phone = string.IsNullOrEmpty(txtPhone.Text.ToString()) ? string.Empty : Convert.ToString(txtPhone.Text);
            vendor.Email = string.IsNullOrEmpty(txtEmail.Text.ToString()) ? string.Empty : Convert.ToString(txtEmail.Text);
            if (dpIsActive.SelectedItem.Value == "1")
                vendor.IsActive = true;
            else vendor.IsActive = false;
            vendor.City = dpCity.SelectedItem.Text.ToString();
            vendor.State = dpState.SelectedItem.Text.ToString();

            vendor.Flag = 3; //3 for update

            int Result = 0;

            Result = purchaseData.VendorDML(vendor);



            if (Result > 0)
            {

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Brand Add  Successfully";

                ClearTextBox();
                GetList();
                pnlError.Update();

                uprouteList.Update();
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
    }
}