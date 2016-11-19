using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bussiness;
using System.Data;
using System.Text;

namespace Dairy.Tabs.Procurement
{
    public partial class AddSuppliersLoanInfo : System.Web.UI.Page
    {
        DataSet DS = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindeSupplierLoanInfo();
                BindDropdown();
                btnLoanadd.Visible = true;
                btnLoanUpdate.Visible = false;
                txtLoanTakenDate.Text = DateTime.Now.ToString("yyyy-MM-dd");


            }
        }

        public void BindDropdown()
        {
            DS = BindCommanData.BindCommanDropDwon("RouteID ", "RouteCode +' '+RouteName as Name  ", "Proc_MilkCollectionRoute", "IsActive=1 ");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpRoute.DataSource = DS;
                dpRoute.DataBind();
                dpRoute.Items.Insert(0, new ListItem("--Select Route  --", "0"));
            }
            DS = BindCommanData.BindCommanDropDwon("SupplierID ", "SupplierCode +' '+SupplierName as Name  ", "Proc_MilkSuppliersProfile", "IsActive=1 ");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpSupplier.DataSource = DS;
                dpSupplier.DataBind();
                dpSupplier.Items.Insert(0, new ListItem("--Select Supplier  --", "0"));
            }

           
            DS = BindCommanData.BindCommanDropDwonDistinct("ID", "BankName as Name", "BankDetails", "ID is not null");
            dpBankName.DataSource = DS;
            dpBankName.DataBind();
            dpBankName.Items.Insert(0, new ListItem("--Select Bank Name--", "0"));

            DS = new DataSet();
            DS = BindCommanData.BindCommanDropDwonDistinct("ID", "IFSCCode as Name", "BankDetails", "ID is not null");
            dpIfscCode.DataSource = DS;
            dpIfscCode.DataBind();
            dpIfscCode.Items.Insert(0, new ListItem("--Select Ifsc Code--", "0"));
        }

        protected void btnClick_btnLoanadd(object sender, EventArgs e)
        {
            Model.Procurement p = new Model.Procurement();
            ProcurementData pd = new ProcurementData();
            p.LoanID = 0;
            p.SupplierID = Convert.ToInt32(dpSupplier.SelectedValue);
            p.LoanType = ddLoanType.SelectedItem.Text;
            p.AccounNumber = txtLoanAccountNo.Text;
            p.LoanAmount =Convert.ToDouble( txtLoanAmt.Text);
            p.LoanTakenDate = txtLoanTakenDate.Text;
            p.LoanDuration =txtLoanDuration.Text;
            p.LoanPaid = Convert.ToDouble(txtLoadPaid.Text);
            p.LoanStatus = DropDownList1.SelectedItem.Text;
            p.BankName = dpBankName.SelectedItem.Text;
            p.BranchName = txtBranchName.Text;
            p.IFSCCode = dpIfscCode.SelectedItem.Text;
            p.Interest = Convert.ToDouble(txtInterest.Text);
            p.LoanBalance = Convert.ToDouble(txtLoanBalance.Text);
            p.CreatedBy = App_code.GlobalInfo.Userid;
            p.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
            p.ModifiedBy = App_code.GlobalInfo.Userid;
            p.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");
            p.flag = "Insert";
            int Result = 0;
            Result = pd.InsertSupplierLoanInfo(p);
            if (Result > 0)
            {

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Supplier Loan Info Add  Successfully";

                ClearTextBox();
                BindeSupplierLoanInfo();
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
        protected void btnClick_btnLoanUpdate(object sender, EventArgs e)
        {
            Model.Procurement p = new Model.Procurement();
            ProcurementData pd = new ProcurementData();
            p.LoanID = string.IsNullOrEmpty(hfLoanID.Value) ? 0 : Convert.ToInt32(hfLoanID.Value);
            p.SupplierID = Convert.ToInt32(dpSupplier.SelectedValue);
            p.LoanType = ddLoanType.SelectedItem.Text;
            p.AccounNumber = txtLoanAccountNo.Text;
            p.LoanAmount = Convert.ToDouble(txtLoanAmt.Text);
            p.LoanTakenDate = txtLoanTakenDate.Text;
            p.LoanDuration = txtLoanDuration.Text;
            p.LoanPaid = Convert.ToDouble(txtLoadPaid.Text);
            p.LoanBalance = Convert.ToDouble(txtLoanBalance.Text);
            p.LoanStatus = DropDownList1.SelectedItem.Text;
            p.BankName = dpBankName.SelectedItem.Text;
            p.BranchName = txtBranchName.Text;
            p.IFSCCode = dpIfscCode.SelectedItem.Text;
            p.Interest = Convert.ToDouble(txtInterest.Text);
            p.LoanBalance = Convert.ToDouble(txtLoanBalance.Text);
            p.CreatedBy = App_code.GlobalInfo.Userid;
            p.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
            p.ModifiedBy = App_code.GlobalInfo.Userid;
            p.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");

            p.flag = "Update";
            int Result = 0;
            Result = pd.InsertSupplierLoanInfo(p);
            if (Result > 0)
            {
                //lbltital.Text = "Add Route";
                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Supplier Loan Info Updated  Successfully";
                ClearTextBox();
                BindeSupplierLoanInfo();
                pnlError.Update();
                btnLoanadd.Visible = true;
                btnLoanUpdate.Visible = false;
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
            ddLoanType.ClearSelection();
            DropDownList1.ClearSelection();
            txtLoanAccountNo.Text = string.Empty;
            txtLoanAmt.Text = string.Empty;
            txtLoanDuration.Text = string.Empty;
            txtLoadPaid.Text = string.Empty;
            txtLoanBalance.Text = string.Empty;
            txtLoanTakenDate.Text = string.Empty;
            txtBranchName.Text = string.Empty;
            txtInterest.Text = string.Empty;
            dpBankName.ClearSelection();
            dpIfscCode.ClearSelection();
            txtInterest.Text = string.Empty;
        }
        public void BindeSupplierLoanInfo()
        {

            ProcurementData pd = new ProcurementData();
            DataSet DS = new DataSet();
            StringBuilder sb = new StringBuilder();
            DS = pd.GetAllSupplierLoanInfo();
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                rpLoanInfoList.DataSource = DS;
                rpLoanInfoList.DataBind();
            }
        }

        protected void rpLoanInfoList_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {

            divDanger.Visible = false;
            divwarning.Visible = false;
            divSusccess.Visible = false;
            pnlError.Update();
            int LoanID = 0;
            LoanID = Convert.ToInt32(e.CommandArgument);
            switch (e.CommandName)
            {
                case ("Edit"):
                    {
                        //lbltital.Text = "Edit Route";
                        hfLoanID.Value = LoanID.ToString();
                        LoanID = Convert.ToInt32(hfLoanID.Value);
                        //BindRouteList();
                        ClearTextBox();
                        GetSupplierLoanInfobyID(LoanID);
                        btnLoanadd.Visible = false;
                        btnLoanUpdate.Visible = true;
                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }
                case ("delete"):
                    {
                        string confirmValue = Request.Form["confirm_value"];
                        if (confirmValue == "Yes")
                        {
                            hfLoanID.Value = LoanID.ToString();
                            LoanID = Convert.ToInt32(hfLoanID.Value);
                            DeleteRoutebyrouteID(LoanID);
                            BindeSupplierLoanInfo();
                            upMain.Update();
                            uprouteList.Update();
                        }
                            break;
                       
                    }


            }
        }
        public void GetSupplierLoanInfobyID(int LoanID)
        {
            DataSet DS = new DataSet();
            ProcurementData pd = new ProcurementData();
            DS = pd.GetSupplierLoanInfobyID(LoanID);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpSupplier.ClearSelection();
                if (dpSupplier.Items.FindByValue(DS.Tables[0].Rows[0]["SupplierID"].ToString()) != null)
                {
                    dpSupplier.Items.FindByValue(DS.Tables[0].Rows[0]["SupplierID"].ToString()).Selected = true;
                }
                ddLoanType.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["LoanType"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["LoanType"].ToString();
                txtLoanAccountNo.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["LoanAccountNo"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["LoanAccountNo"].ToString();
                txtLoanAmt.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["LoanAmount"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["LoanAmount"].ToString();
                txtLoanTakenDate.Text = string.IsNullOrEmpty((DS.Tables[0].Rows[0]["LoanTakenDate"]).ToString()) ? string.Empty : DS.Tables[0].Rows[0]["LoanTakenDate"].ToString();
                txtLoanDuration.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["LoanDuration"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["LoanDuration"].ToString();
                txtLoadPaid.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["LoanPaid"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["LoanPaid"].ToString();
                txtLoanBalance.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["LoanBalance"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["LoanBalance"].ToString();
                DropDownList1.ClearSelection();
                if (DropDownList1.Items.FindByText(DS.Tables[0].Rows[0]["LoanStatus"].ToString())!=null)
                { DropDownList1.Items.FindByText(DS.Tables[0].Rows[0]["LoanStatus"].ToString()).Selected = true; }
                dpBankName.ClearSelection();
                if (dpBankName.Items.FindByText(DS.Tables[0].Rows[0]["BankName"].ToString()) != null)
                { dpBankName.Items.FindByText(DS.Tables[0].Rows[0]["BankName"].ToString()).Selected = true; }
               
                txtBranchName.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["BranchName"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["BranchName"].ToString();
                dpIfscCode.ClearSelection();
                if (dpIfscCode.Items.FindByText(DS.Tables[0].Rows[0]["IFSCCode"].ToString()) != null)
                { dpIfscCode.Items.FindByText(DS.Tables[0].Rows[0]["IFSCCode"].ToString()).Selected = true; }
                
                txtInterest.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Interest"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Interest"].ToString();

            }
        }
        public void DeleteRoutebyrouteID(int CenterID)
        {
           // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Do you want to delete')", true);

            Model.Procurement p = new Model.Procurement();
            ProcurementData pd = new ProcurementData();
            p.LoanID = string.IsNullOrEmpty(hfLoanID.Value) ? 0 : Convert.ToInt32(hfLoanID.Value);
            p.SupplierID = Convert.ToInt32(dpSupplier.SelectedValue);
            p.LoanType = ddLoanType.SelectedItem.Text;
            p.AccounNumber = txtLoanAccountNo.Text;
            p.LoanAmount = 0;
            p.LoanTakenDate = txtLoanTakenDate.Text;
            p.LoanDuration = txtLoanDuration.Text;
            p.LoanPaid =0;
            p.LoanBalance =0;
            p.LoanStatus = DropDownList1.SelectedItem.Text;
            p.BankName = dpBankName.SelectedItem.Text;
            p.BranchName = txtBranchName.Text;
            p.IFSCCode = dpIfscCode.SelectedItem.Text;
            p.Interest = 0;
            p.LoanBalance = 0;
            p.CreatedBy = App_code.GlobalInfo.Userid;
            p.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
            p.ModifiedBy = App_code.GlobalInfo.Userid;
            p.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");

            p.flag = "Delete";
            int Result = 0;
            Result = pd.InsertSupplierLoanInfo(p);
            if (Result > 0)
            {
              

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Delete Updated  Successfully";
                ClearTextBox();
                BindeSupplierLoanInfo();
                pnlError.Update();
                btnLoanadd.Visible = true;
                btnLoanUpdate.Visible = false;
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

        protected void dpRoute_SelectedIndexChanged(object sender, EventArgs e)
        {
            dpSupplier.ClearSelection();
            int routeid=Convert.ToInt32(dpRoute.SelectedItem.Value);
            DS = BindCommanData.BindCommanDropDwon("SupplierID ", "SupplierCode +' '+SupplierName as Name  ", "Proc_MilkSuppliersProfile", "IsActive=1 and RouteID="+routeid);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpSupplier.DataSource = DS;
                dpSupplier.DataBind();
                dpSupplier.Items.Insert(0, new ListItem("--Select Supplier  --", "0"));
            }

        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Tabs/Procurement/AddSuppliersLoanInfo.aspx");
        }

        protected void ddLoanType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProcurementData pd = new ProcurementData();
            DataSet DS = new DataSet();
            DS = pd.GetAllSupplierLoanInfo();
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                foreach (DataRow row in DS.Tables[0].Rows)
                {
                    if (row["SupplierID"].ToString() == dpSupplier.SelectedItem.Value && row["LoanType"].ToString() == ddLoanType.SelectedItem.Text.ToString() && row["LoanStatus"].ToString()=="Open")
                    {
                         ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Supplier Loan Already Exists')", true);
                        ddLoanType.ClearSelection();
                    }
                }
            }
            }
    }
}