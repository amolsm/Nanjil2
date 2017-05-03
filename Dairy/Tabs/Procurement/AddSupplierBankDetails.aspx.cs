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
    public partial class AddSupplierBankDetails : System.Web.UI.Page
    {
        DataSet DS = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindBankInfoList();
                BindDropDwon();
                btnTariffAdd.Visible = true;
                btnTariffUpdate.Visible = false;


            }
        }

        protected void BindDropDwon()
        {
            DS = new DataSet();
            DS = BindCommanData.BindCommanDropDwonDistinct("ID", "BankName as Name", "BankDetails", "ID is not null");
            dpBankName.DataSource = DS;
            dpBankName.DataBind();
            dpBankName.Items.Insert(0, new ListItem("--Select Bank Name--", "0"));

            DS = new DataSet();
            DS = BindCommanData.BindCommanDropDwonDistinct("ID", "IFSCCode as Name", "BankDetails", "ID is not null");
            dpIfscCode.DataSource = DS;
            dpIfscCode.DataBind();
            dpIfscCode.Items.Insert(0, new ListItem("--Select Ifsc Code--", "0"));

            DS = BindCommanData.BindCommanDropDwon("SupplierID ", "SupplierCode +' '+SupplierName as Name  ", "Proc_MilkSuppliersProfile", "IsActive=1 ");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpSupplier.DataSource = DS;
                dpSupplier.DataBind();
                dpSupplier.Items.Insert(0, new ListItem("--Select Supplier  --", "0"));
            }
        }

        protected void btnClick_btnTariffAdd(object sender, EventArgs e)
        {
            Model.Procurement p = new Model.Procurement();
            ProcurementData pd = new ProcurementData();
            p.BankDetailsID = 0;
            p.SupplierID = Convert.ToInt32(dpSupplier.SelectedValue);
            p.AccounNumber = txtAccountNo.Text;
            p.AccountType = DropDownList1.SelectedItem.Text;
            p.BankName = dpBankName.SelectedItem.Text;
            p.IFSCCode = dpIfscCode.SelectedItem.Text;
            p.BankAddress = txtAddress.Text;
            p.BranchName = txtBranchName.Text;
            p.AccountType = DropDownList1.SelectedItem.Text;

            p.CreatedBy = App_code.GlobalInfo.Userid;
            p.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
            p.ModifiedBy = App_code.GlobalInfo.Userid;
            p.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");
            p.flag = "Insert";
            int Result = 0;
            Result = pd.InsertSupplierBankDetails(p);
            if (Result > 0)
            {

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "SupplierBank Details Add  Successfully";

                ClearTextBox();
                BindBankInfoList();
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
        protected void btnClick_btnTariffUpdate(object sender, EventArgs e)
        {
            Model.Procurement p = new Model.Procurement();
            ProcurementData pd = new ProcurementData();
            p.BankDetailsID = string.IsNullOrEmpty(hfBankID.Value) ? 0 : Convert.ToInt32(hfBankID.Value);
            p.SupplierID = Convert.ToInt32(dpSupplier.SelectedValue);
            p.AccounNumber = txtAccountNo.Text;
            p.AccountType = DropDownList1.SelectedItem.Text;
            p.BankName = dpBankName.SelectedItem.Text;
            p.IFSCCode = dpIfscCode.SelectedItem.Text;
            p.BankAddress = txtAddress.Text;
            p.BranchName = txtBranchName.Text;
            p.AccountType = DropDownList1.SelectedItem.Text;

            p.CreatedBy = App_code.GlobalInfo.Userid;
            p.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
            p.ModifiedBy = App_code.GlobalInfo.Userid;
            p.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");

            p.flag = "Update";
            int Result = 0;
            Result = pd.InsertSupplierBankDetails(p);
            if (Result > 0)
            {
                //lbltital.Text = "Add Route";
                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "SupplierBank Details Updated  Successfully";
                ClearTextBox();
                BindBankInfoList();
                pnlError.Update();
                btnTariffAdd.Visible = true;
                btnTariffUpdate.Visible = false;
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
            dpSupplier.ClearSelection();
            txtAccountNo.Text = string.Empty;
            DropDownList1.ClearSelection();
            dpIfscCode.ClearSelection();
            dpBankName.ClearSelection();
            txtAddress.Text = string.Empty;
            txtBranchName.Text = string.Empty;

        }
        public void BindBankInfoList()
        {

            ProcurementData pd = new ProcurementData();
            DataSet DS = new DataSet();
            StringBuilder sb = new StringBuilder();
            DS = pd.GetAllSupplierBankDetails();
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                rpBankInfoList.DataSource = DS;
                rpBankInfoList.DataBind();
            }
        }

        protected void rpBankInfoList_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {

            divDanger.Visible = false;
            divwarning.Visible = false;
            divSusccess.Visible = false;
            pnlError.Update();
            int BankDetailID = 0;
            BankDetailID = Convert.ToInt32(e.CommandArgument);
            switch (e.CommandName)
            {
                case ("Edit"):
                    {
                        //lbltital.Text = "Edit Route";
                        hfBankID.Value = BankDetailID.ToString();
                        BankDetailID = Convert.ToInt32(hfBankID.Value);
                        //BindRouteList();
                        ClearTextBox();
                        GetSupplierBankDetailsbyID(BankDetailID);
                        btnTariffAdd.Visible = false;
                        btnTariffUpdate.Visible = true;
                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }
                case ("delete"):
                    {

                        hfBankID.Value = BankDetailID.ToString();
                        BankDetailID = Convert.ToInt32(hfBankID.Value);
                        DeleteRoutebyrouteID(BankDetailID);
                        BindBankInfoList();
                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }


            }
        }
        public void GetSupplierBankDetailsbyID(int BankDetailID)
        {
            DataSet DS = new DataSet();
            ProcurementData pd = new ProcurementData();
            DS = pd.GetSupplierBankDetailsbyID(BankDetailID);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpSupplier.ClearSelection();
                if (dpSupplier.Items.FindByValue(DS.Tables[0].Rows[0]["SupplierID"].ToString()) != null)
                {
                    dpSupplier.Items.FindByValue(DS.Tables[0].Rows[0]["SupplierID"].ToString()).Selected = true;
                }
                dpBankName.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["BankName"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["BankName"].ToString();
                txtAccountNo.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["AccountNo"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["AccountNo"].ToString();
                DropDownList1.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["AccountType"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["AccountType"].ToString();
                dpIfscCode.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["IFSCCode"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["IFSCCode"].ToString();
                txtAddress.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["BankAddress"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["BankAddress"].ToString();
                txtBranchName.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["BranchName"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["BranchName"].ToString();

            }
        }
        public void DeleteRoutebyrouteID(int CenterID)
        {


            //int Result = 0;
            //Result = routeDate.InsertRoute(route);
            //if (Result > 0)
            //{

            //    divDanger.Visible = false;
            //    divwarning.Visible = false;
            //    divSusccess.Visible = true;
            //    lblSuccess.Text = "Delete Updated  Successfully";
            //    ClearTextBox();
            //    BindRouteList();
            //    pnlError.Update();
            //    btnAddRoute.Visible = true;
            //    btnupdateroute.Visible = false;
            //    upMain.Update();
            //    uprouteList.Update();
            //}
            //else
            //{
            //    divDanger.Visible = false;
            //    divwarning.Visible = true;
            //    divSusccess.Visible = false;
            //    lblwarning.Text = "Please Contact to Site Admin";
            //    pnlError.Update();

            //}
        }
    }
}