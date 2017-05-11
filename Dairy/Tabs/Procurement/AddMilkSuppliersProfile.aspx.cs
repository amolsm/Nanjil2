using Bussiness;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dairy.Tabs.Procurement
{
    public partial class AddMilkSuppliersProfile : System.Web.UI.Page
    {
        DataSet DS = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindSupplierList();
                BindDropDwon();
                btnSupplieradd.Visible = true;
                btnSupplierUpdate.Visible = false;
                dpState.Text = "TamilNadu";
                dpCountry.Text = "India";
                txtJoiningDate.Text = DateTime.Now.ToString("yyyy-MM-dd");

            }
        }

        public void BindDropDwon()
        {
            DS = new DataSet();
            DS = BindCommanData.BindCommanDropDwonDistinct("LocId", "City as Name", "StateMaster", "LocId is not null");
            dpCity.DataSource = DS;
            dpCity.DataBind();
            dpCity.Items.Insert(0, new ListItem("--Select City--", "0"));

            DS = new DataSet();
            DS = BindCommanData.BindCommanDropDwonDistinct("LocId", "District as Name", "StateMaster", "LocId is not null");
            dpDistrict.DataSource = DS;
            dpDistrict.DataBind();
            dpDistrict.Items.Insert(0, new ListItem("--Select District--", "0"));

            DS = new DataSet();
            DS = BindCommanData.BindCommanDropDwonDistinct("LocId", "State as Name", "StateMaster", "LocId is not null");
            dpState.DataSource = DS;
            dpState.DataBind();
            dpState.Items.Insert(0, new ListItem("--Select State--", "0"));

            DS = new DataSet();
            DS = BindCommanData.BindCommanDropDwonDistinct("LocId", "Country as Name", "StateMaster", "LocId is not null");
            dpCountry.DataSource = DS;
            dpCountry.DataBind();
            dpCountry.Items.Insert(0, new ListItem("--Select Country--", "0"));

            DS = BindCommanData.BindCommanDropDwon("CenterID ", "CenterCode +' '+CenterName as Name  ", "tbl_MilkCollectionCenter", "IsActive=1 ");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpCenter.DataSource = DS;
                dpCenter.DataBind();
                dpCenter.Items.Insert(0, new ListItem("--Select Center  --", "0"));
            }

            RouteData routeData = new RouteData();
            DS = BindCommanData.BindCommanDropDwon("RouteID ", "RouteCode +' '+RouteName as Name  ", "Proc_MilkCollectionRoute", "IsActive=1 ");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpRoute.DataSource = DS;
                dpRoute.DataBind();
                dpRoute.Items.Insert(0, new ListItem("--Select Route  --", "0"));
            }

            //DS = new DataSet();
            //DS = BindCommanData.BindCommanDropDwonDistinct("ID", "BankName as Name", "BankDetails", "ID is not null");
            //dpBankName.DataSource = DS;
            //dpBankName.DataBind();
            //dpBankName.Items.Insert(0, new ListItem("--Select Bank Name--", "0"));

            DS = new DataSet();
            DS = BindCommanData.BindCommanDropDwon("ID", "IFSCCode as Name", "BankDetails", "ID is not null");
            dpIfscCode.DataSource = DS;
            dpIfscCode.DataBind();
            dpIfscCode.Items.Insert(0, new ListItem("--Select Ifsc Code--", "0"));
        }

        protected void btnClick_btnSupplieradd(object sender, EventArgs e)
        {
            Model.Procurement p = new Model.Procurement();
            ProcurementData pd = new ProcurementData();
            p.SupplierID = 0;
            p.SupplierCode = txtSupplierCode.Text;
            p.SupplierName = txtSupplierName.Text;
            p.CenterID = Convert.ToInt32(dpCenter.SelectedValue);
            p.RouteID = Convert.ToInt32(dpRoute.SelectedValue);
            p.SupplierAliasName = txtSupplierAliasName.Text;
            p.JoiningDate = txtJoiningDate.Text;
            if (DropDownList1.SelectedValue == "1")
                p.IsActive = true;
            if (DropDownList1.SelectedValue == "2")
                p.IsActive = false;
            p.Address1 = txtAddress1.Text;
            p.Address2 = txtAddress2.Text;
            p.Address3 = txtAddress3.Text;
            p.EmailID = txtEmail.Text;
            p.MobileNo = txtMobile.Text;
            p.PhoneNo = txtTelephone.Text;
            p.City = dpCity.SelectedItem.Text;
            p.District = dpDistrict.SelectedItem.Text;
            p.State = dpState.SelectedItem.Text;
            p.Country = dpCountry.SelectedItem.Text;
            //p.BankDetailsID = Convert.ToInt32( txtBankDetailID.Text);
            //p.IncentiveTillDate =Convert.ToDouble( txtIncentive.Text);
            //p.ReccDeposit = Convert.ToDouble(txtDeposit.Text);
            //p.Bonus = Convert.ToDouble(txtBonus.Text);
            //p.AdvaceGiven = Convert.ToDouble(txtAdvanceGiven.Text);
            //p.SchemeAmount = Convert.ToDouble(txtScheme.Text);
            p.CreatedBy = App_code.GlobalInfo.Userid;
            p.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
            p.ModifiedBy = App_code.GlobalInfo.Userid;
            p.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");
            //p.BankDetailsID = 0;
            p.SupplierID = 0;
            p.AccounNumber = txtAccountNo.Text;
            p.AccountType = string.Empty;
            p.BankName = string.Empty;
            p.IFSCCode = string.Empty;
            p.BankAddress = string.Empty;
            p.BranchName = string.Empty;
            p.BankDetailsID = Convert.ToInt32(dpIfscCode.SelectedItem.Value);
            p.AccountName = txtAccountName.Text;
            p.flag = "Insert";
            int Result = 0;
            Result = pd.InsertSupplierPrfile(p);
            if (Result > 0)
            {

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Supplier Profile Add  Successfully";

                ClearTextBox();
                BindSupplierList();
                pnlError.Update();
                upMain.Update();
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
        protected void btnClick_btnSupplierUpdate(object sender, EventArgs e)
        {
            Model.Procurement p = new Model.Procurement();
            ProcurementData pd = new ProcurementData();
            p.SupplierID = string.IsNullOrEmpty(hfprofileID.Value) ? 0 : Convert.ToInt32(hfprofileID.Value);
            p.SupplierCode = txtSupplierCode.Text;
            p.SupplierName = txtSupplierName.Text;
            p.CenterID = Convert.ToInt32(dpCenter.SelectedValue);
            p.RouteID = Convert.ToInt32(dpRoute.SelectedValue);
            p.SupplierAliasName = txtSupplierAliasName.Text;
            p.JoiningDate = txtJoiningDate.Text;
            if (DropDownList1.SelectedValue == "1")
                p.IsActive = true;
            if (DropDownList1.SelectedValue == "2")
                p.IsActive = false;
            p.Address1 = txtAddress1.Text;
            p.Address2 = txtAddress2.Text;
            p.Address3 = txtAddress3.Text;
            p.EmailID = txtEmail.Text;
            p.MobileNo = txtMobile.Text;
            p.PhoneNo = txtTelephone.Text;
            p.City = dpCity.SelectedItem.Text;
            p.District = dpDistrict.SelectedItem.Text;
            p.State = dpState.SelectedItem.Text;
            p.Country = dpCountry.SelectedItem.Text;
            //p.BankDetailsID = Convert.ToInt32(txtBankDetailID.Text);
            //p.IncentiveTillDate = Convert.ToDouble(txtIncentive.Text);
            //p.ReccDeposit = Convert.ToDouble(txtDeposit.Text);
            //p.Bonus = Convert.ToDouble(txtBonus.Text);
            //p.AdvaceGiven = Convert.ToDouble(txtAdvanceGiven.Text);
            //p.SchemeAmount = Convert.ToDouble(txtScheme.Text);
            p.CreatedBy = App_code.GlobalInfo.Userid;
            p.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
            p.ModifiedBy = App_code.GlobalInfo.Userid;
            p.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");
            p.BankDetailsID = string.IsNullOrEmpty(HiddenField1.Value) ? 0 : Convert.ToInt32(HiddenField1.Value);
            p.SupplierID = string.IsNullOrEmpty(hfprofileID.Value) ? 0 : Convert.ToInt32(hfprofileID.Value);
            p.AccounNumber = txtAccountNo.Text;
            p.AccountType = string.Empty;
            p.BankName = string.Empty;
            p.IFSCCode = string.Empty;
            p.BankAddress = string.Empty;
            p.BranchName = string.Empty;
            //p.AccountType = DropDownList2.SelectedItem.Text;
            p.AccountName = txtAccountName.Text;
            p.BankId = Convert.ToInt32(dpIfscCode.SelectedItem.Value);
            p.flag = "Update";
            int Result = 0;
            Result = pd.InsertSupplierPrfile(p);
            if (Result > 0)
            {
                //lbltital.Text = "Add Route";
                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Supplier Profile  Updated  Successfully";
                ClearTextBox();
                BindSupplierList();
                pnlError.Update();
                btnSupplieradd.Visible = true;
                btnSupplierUpdate.Visible = false;
                upMain.Update();
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

        public void ClearTextBox()
        {
            txtSupplierCode.Text = string.Empty;
            txtSupplierName.Text = string.Empty;
            dpCenter.ClearSelection();
            dpRoute.ClearSelection();
            txtSupplierAliasName.Text = string.Empty;
            txtJoiningDate.Text = string.Empty;
            txtAddress1.Text = string.Empty;
            txtAddress2.Text = string.Empty;
            txtAddress3.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtMobile.Text = string.Empty;
            txtTelephone.Text = string.Empty;
            dpCity.ClearSelection();
            dpDistrict.ClearSelection();
            //txtBankDetailID.Text = string.Empty;
            DropDownList1.ClearSelection();
            //txtIncentive.Text = string.Empty;
            //txtDeposit.Text = string.Empty;
            //txtBonus.Text = string.Empty;
            //txtAdvanceGiven.Text = string.Empty;
            //txtScheme.Text = string.Empty;
            txtAccountNo.Text = string.Empty;
            //DropDownList2.ClearSelection();
            dpIfscCode.ClearSelection();
            //dpBankName.ClearSelection();
            //txtAddress.Text = string.Empty;
            //txtBranchName.Text = string.Empty;
            txtAccountName.Text = string.Empty;
        }
        public void BindSupplierList()
        {

            ProcurementData pd = new ProcurementData();
            DataSet DS = new DataSet();
            StringBuilder sb = new StringBuilder();
            DS = pd.GetAllSupplierProfiles();
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                if (!string.IsNullOrEmpty(DS.Tables[1].Rows[0]["id"].ToString()))
                {
                    int count = Convert.ToInt32(DS.Tables[1].Rows[0]["id"]);
                    count = count + 1;
                    //txtSupplierCode.Text = string.Format("S{0:0000}", count);
                    txtSupplierCode.Text = Convert.ToString(count);
                    txtSupplierCode.ReadOnly = false;
                    rpSupplierProfList.DataSource = DS;
                    rpSupplierProfList.DataBind();
                }
                else
                {
                    int count = 1;
                    //txtSupplierCode.Text = string.Format("S{0:0000}", count);
                    txtSupplierCode.Text =Convert.ToString(count);
                    txtSupplierCode.ReadOnly = false;
                }
            }
        }

        protected void rpSupplierProfList_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {

            divDanger.Visible = false;
            divwarning.Visible = false;
            divSusccess.Visible = false;
            pnlError.Update();
            int SupplierID = 0;
            SupplierID = Convert.ToInt32(e.CommandArgument);
            switch (e.CommandName)
            {
                case ("Edit"):
                    {
                        //lbltital.Text = "Edit Route";
                        hfprofileID.Value = SupplierID.ToString();
                        SupplierID = Convert.ToInt32(hfprofileID.Value);
                        //BindRouteList();
                        ClearTextBox();
                        GetSupplierProfilebyID(SupplierID);
                        btnSupplieradd.Visible = false;
                        btnSupplierUpdate.Visible = true;
                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }
                case ("delete"):
                    {

                        hfprofileID.Value = SupplierID.ToString();
                        SupplierID = Convert.ToInt32(hfprofileID.Value);
                        DeleteSupplierByID(SupplierID);
                        BindSupplierList();
                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }


            }
        }
        public void GetSupplierProfilebyID(int SupplierID)
        {
            DataSet DS = new DataSet();
            ProcurementData pd = new ProcurementData();
            DS = pd.GetSupplierProfilebyID(SupplierID);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                txtSupplierCode.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["SupplierCode"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["SupplierCode"].ToString();
                txtSupplierCode.ReadOnly = false;
                txtSupplierName.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["SupplierName"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["SupplierName"].ToString();
                dpCenter.ClearSelection();
                if (dpCenter.Items.FindByValue(DS.Tables[0].Rows[0]["CenterID"].ToString()) != null)
                {
                    dpCenter.Items.FindByValue(DS.Tables[0].Rows[0]["CenterID"].ToString()).Selected = true;
                }
                dpRoute.ClearSelection();
                if (dpRoute.Items.FindByValue(DS.Tables[0].Rows[0]["RouteID"].ToString()) != null)
                {
                    dpRoute.Items.FindByValue(DS.Tables[0].Rows[0]["RouteID"].ToString()).Selected = true;
                }
                txtSupplierAliasName.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["SupplierAliasName"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["SupplierAliasName"].ToString();
                txtJoiningDate.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["JoiningDate"].ToString()) ? string.Empty : Convert.ToDateTime(DS.Tables[0].Rows[0]["JoiningDate"]).ToString("yyyy-MM-dd");
                txtAddress1.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Address1"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Address1"].ToString();
                txtAddress2.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Address2"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Address2"].ToString();
                txtAddress3.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Address3"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Address3"].ToString();
                txtMobile.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Mobile"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Mobile"].ToString();
                txtTelephone.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Phone"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Phone"].ToString();
                txtEmail.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Email"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Email"].ToString();
                dpCity.ClearSelection();
                if (dpCity.Items.FindByText(DS.Tables[0].Rows[0]["City"].ToString()) != null)
                {
                    dpCity.Items.FindByText(DS.Tables[0].Rows[0]["City"].ToString()).Selected = true;
                }
                dpDistrict.ClearSelection();
                if (dpDistrict.Items.FindByText(DS.Tables[0].Rows[0]["District"].ToString()) != null)
                {
                    dpDistrict.Items.FindByText(DS.Tables[0].Rows[0]["District"].ToString()).Selected = true;
                }
                dpState.ClearSelection();
                if (dpState.Items.FindByText(DS.Tables[0].Rows[0]["Stae"].ToString()) != null)
                {
                    dpState.Items.FindByText(DS.Tables[0].Rows[0]["Stae"].ToString()).Selected = true;
                }
                dpCountry.ClearSelection();
                if (dpCountry.Items.FindByText(DS.Tables[0].Rows[0]["Country"].ToString()) != null)
                {
                    dpCountry.Items.FindByText(DS.Tables[0].Rows[0]["Country"].ToString()).Selected = true;
                }


                //txtBankDetailID.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["BankDetailsID"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["BankDetailsID"].ToString();
                //txtIncentive.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["IncentiveTillDate"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["IncentiveTillDate"].ToString();
                //txtDeposit.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["ReccDeposit"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["ReccDeposit"].ToString();
                //txtBonus.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Bonus"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Bonus"].ToString();
                //txtAdvanceGiven.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["AdvGiven"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["AdvGiven"].ToString();
                //txtScheme.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["SchemeTillDate"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["SchemeTillDate"].ToString();
                DropDownList1.ClearSelection();
                if (DS.Tables[0].Rows[0]["IsActive"].ToString() == "True")
                {
                    DropDownList1.Items.FindByValue("1").Selected = true;
                }
                else if (DS.Tables[0].Rows[0]["IsActive"].ToString() == "False")
                {
                    DropDownList1.Items.FindByValue("2").Selected = true;
                }
                HiddenField1.Value = string.IsNullOrEmpty(DS.Tables[1].Rows[0]["BankDetailID"].ToString()) ? string.Empty : DS.Tables[1].Rows[0]["BankDetailID"].ToString();
                //dpBankName.ClearSelection();
                //if (dpBankName.Items.FindByText(DS.Tables[1].Rows[0]["BankName"].ToString()) != null)
                //{
                //    dpBankName.Items.FindByText(DS.Tables[1].Rows[0]["BankName"].ToString()).Selected = true;
                //}

                txtAccountNo.Text = string.IsNullOrEmpty(DS.Tables[1].Rows[0]["AccountNo"].ToString()) ? string.Empty : DS.Tables[1].Rows[0]["AccountNo"].ToString();
                //DropDownList2.ClearSelection();
                //if (DropDownList2.Items.FindByText(DS.Tables[1].Rows[0]["AccountType"].ToString()) != null)
                //{
                //    DropDownList2.Items.FindByText(DS.Tables[1].Rows[0]["AccountType"].ToString()).Selected = true;
                //}
                dpIfscCode.ClearSelection();
                if (dpIfscCode.Items.FindByValue(DS.Tables[1].Rows[0]["BankId"].ToString()) != null)
                {
                    dpIfscCode.Items.FindByValue(DS.Tables[1].Rows[0]["BankId"].ToString()).Selected = true;
                }
                //txtAddress.Text = string.IsNullOrEmpty(DS.Tables[1].Rows[0]["BankAddress"].ToString()) ? string.Empty : DS.Tables[1].Rows[0]["BankAddress"].ToString();
                //txtBranchName.Text = string.IsNullOrEmpty(DS.Tables[1].Rows[0]["BranchName"].ToString()) ? string.Empty : DS.Tables[1].Rows[0]["BranchName"].ToString();
                txtAccountName.Text = string.IsNullOrEmpty(DS.Tables[1].Rows[0]["AccountName"].ToString()) ? string.Empty : DS.Tables[1].Rows[0]["AccountName"].ToString();
            }
        }
        public void DeleteSupplierByID(int SupplierID)
        {


            Model.Procurement p = new Model.Procurement();
            ProcurementData pd = new ProcurementData();
            p.SupplierID = string.IsNullOrEmpty(hfprofileID.Value) ? 0 : Convert.ToInt32(hfprofileID.Value);
            p.SupplierCode = string.Empty;
            p.SupplierName = string.Empty;
            p.CenterID = 0;
            p.RouteID = 0;
            p.SupplierAliasName = string.Empty;
            p.JoiningDate = string.Empty;
            p.IsActive = false;
            p.Address1 = string.Empty;
            p.Address2 = string.Empty;
            p.Address3 = string.Empty;
            p.EmailID = string.Empty;
            p.MobileNo = string.Empty;
            p.PhoneNo = string.Empty;
            p.City = dpCity.SelectedItem.Text;
            p.District = dpDistrict.SelectedItem.Text;
            p.State = dpState.SelectedItem.Text;
            p.Country = dpCountry.SelectedItem.Text;
            //p.BankDetailsID = Convert.ToInt32(txtBankDetailID.Text);
            //p.IncentiveTillDate = 0.0;
            //p.ReccDeposit = 0.0;
            //p.Bonus = 0.0;
            //p.AdvaceGiven = 0.0;
            //p.SchemeAmount = 0.0;
            p.CreatedBy = App_code.GlobalInfo.Userid;
            p.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
            p.ModifiedBy = App_code.GlobalInfo.Userid;
            p.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");
            p.BankDetailsID = string.IsNullOrEmpty(HiddenField1.Value) ? 0 : Convert.ToInt32(HiddenField1.Value);
            p.SupplierID = string.IsNullOrEmpty(hfprofileID.Value) ? 0 : Convert.ToInt32(hfprofileID.Value);
            p.AccounNumber = string.Empty;
            p.AccountType = DropDownList1.SelectedItem.Text;
            //p.BankName = dpBankName.SelectedItem.Text;
            p.IFSCCode = dpIfscCode.SelectedItem.Text;
            p.BankAddress = string.Empty;
            p.BranchName = string.Empty;
            p.AccountType = DropDownList1.SelectedItem.Text;
            p.AccountName = string.Empty;
            p.flag = "Delete";
            int Result = 0;
            Result = pd.InsertSupplierPrfile(p);
            if (Result > 0)
            {
                //lbltital.Text = "Add Route";
                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Supplier Profile  Deleted  Successfully";
                ClearTextBox();
                BindSupplierList();
                pnlError.Update();
                btnSupplieradd.Visible = true;
                btnSupplierUpdate.Visible = false;
                upMain.Update();
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

        protected void btnClick_btnAddNew(object sender, EventArgs e)
        {
            Response.Redirect("~/Tabs/Procurement/AddMilkSuppliersProfile.aspx");
        }

        protected void dpCenter_SelectedIndexChanged(object sender, EventArgs e)
        {
            dpRoute.ClearSelection();
            DS = BindCommanData.BindCommanDropDwon("RouteID ", "RouteCode +' '+RouteName as Name  ", "Proc_MilkCollectionRoute", "IsActive=1 and CenterID=" + dpCenter.SelectedItem.Value);

            dpRoute.DataSource = DS;
            dpRoute.DataBind();
            dpRoute.Items.Insert(0, new ListItem("--Select Route  --", "0"));
        }
    }
}