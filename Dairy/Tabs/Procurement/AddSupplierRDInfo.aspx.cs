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
    public partial class AddSupplierRDInfo : System.Web.UI.Page
    {
        DataSet DS = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindeSupplierRDInfo();
                BindDropdown();
                btnAddRDInfo.Visible = true;
                btnupdateRDInfo.Visible = false;

                txtRDStartDate.Text=DateTime.Now.ToString("yyyy-MM-dd");
                txtRDMaturityDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                txtRDPaymentDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }
        public void BindDropdown()
        {
            DS = BindCommanData.BindCommanDropDwon("SupplierID ", "SupplierCode +' '+SupplierName as Name  ", "Proc_MilkSuppliersProfile", "IsActive=1 ");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpSupplier.DataSource = DS;
                dpSupplier.DataBind();
                dpSupplier.Items.Insert(0, new ListItem("--Select Supplier  --", "0"));
            }

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
            DS = new DataSet();
            DS = BindCommanData.BindCommanDropDwon("RouteID ", "RouteCode +' '+RouteName as Name  ", "Proc_MilkCollectionRoute", "IsActive=1 ");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpRoute.DataSource = DS;
                dpRoute.DataBind();
                dpRoute.Items.Insert(0, new ListItem("--Select Route  --", "0"));
            }
        }


        public void ClearTextBox()
        {
            dpRoute.ClearSelection();
            dpSupplier.ClearSelection();
            DropDownList1.ClearSelection();
            txtRDAmount.Text = string.Empty;
            txtRDRepaymentAmount.Text = string.Empty;
            txtRDMaturityDate.Text = string.Empty;
            txtRDPaymentDate.Text = string.Empty;
            txtRDStartDate.Text = string.Empty;
            dpBankName.ClearSelection();
            dpIfscCode.ClearSelection();
            txtAccountName.Text = string.Empty;
            txtAccountNo.Text = string.Empty;
            txtBranchName.Text = string.Empty;
        }
        public void BindeSupplierRDInfo()
        {

            ProcurementData pd = new ProcurementData();
            DataSet DS = new DataSet();
            StringBuilder sb = new StringBuilder();
            DS = pd.GetAllSupplierRDInfo();
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                rpRDInfo.DataSource = DS;
                rpRDInfo.DataBind();
            }
        }
        protected void rpRDInfo_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {

            divDanger.Visible = false;
            divwarning.Visible = false;
            divSusccess.Visible = false;
            pnlError.Update();
            int RDID = 0;
            RDID = Convert.ToInt32(e.CommandArgument);
            switch (e.CommandName)
            {
                case ("Edit"):
                    {
                        //lbltital.Text = "Edit Route";
                        hfRDID.Value = RDID.ToString();
                        RDID = Convert.ToInt32(hfRDID.Value);
                        //BindRouteList();
                        ClearTextBox();
                        GetSupplierAdvanceInfobyID(RDID);
                        btnAddRDInfo.Visible = false;
                        btnupdateRDInfo.Visible = true;
                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }
                case ("delete"):
                    {

                        hfRDID.Value = RDID.ToString();
                        RDID = Convert.ToInt32(hfRDID.Value);
                        DeleteRDInfoByRDID(RDID);
                        BindeSupplierRDInfo();
                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }


            }
        }
        public void GetSupplierAdvanceInfobyID(int RDID)
        {
            DataSet DS = new DataSet();
            ProcurementData pd = new ProcurementData();
            DS = pd.GetSupplierRDInfobyID(RDID);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpRoute.ClearSelection();
                if (dpRoute.Items.FindByValue(DS.Tables[0].Rows[0]["RouteId"].ToString()) != null)
                {
                    dpRoute.Items.FindByValue(DS.Tables[0].Rows[0]["RouteId"].ToString()).Selected = true;
                }
                dpSupplier.ClearSelection();
                if (dpSupplier.Items.FindByValue(DS.Tables[0].Rows[0]["SupplierID"].ToString()) != null)
                {
                    dpSupplier.Items.FindByValue(DS.Tables[0].Rows[0]["SupplierID"].ToString()).Selected = true;
                }
                txtRDAmount.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["RDAmount"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["RDAmount"].ToString();
                txtRDRepaymentAmount.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["RDRepayment"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["RDRepayment"].ToString();
                //txtRDID.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["RDID"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["RDID"].ToString();
                txtRDMaturityDate.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["RDMaturityDate"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["RDMaturityDate"].ToString();
                txtRDPaymentDate.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["RDPaymentDateTime"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["RDPaymentDateTime"].ToString();
                txtRDStartDate.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["RDStartDate"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["RDStartDate"].ToString();
                DropDownList1.ClearSelection();

                if (DropDownList1.Items.FindByText(DS.Tables[0].Rows[0]["RDStatus"].ToString()) != null)
                {
                    DropDownList1.Items.FindByText(DS.Tables[0].Rows[0]["RDStatus"].ToString()).Selected = true;
                }

                dpBankName.ClearSelection();
                if (dpBankName.Items.FindByText(DS.Tables[0].Rows[0]["BankName"].ToString()) != null)
                {
                    dpBankName.Items.FindByText(DS.Tables[0].Rows[0]["BankName"].ToString()).Selected = true;
                }

                txtAccountNo.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["AccountNo"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["AccountNo"].ToString();
                dpIfscCode.ClearSelection();
                if (dpIfscCode.Items.FindByText(DS.Tables[0].Rows[0]["IFSCCode"].ToString()) != null)
                {
                    dpIfscCode.Items.FindByText(DS.Tables[0].Rows[0]["IFSCCode"].ToString()).Selected = true;
                }

                txtBranchName.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["BranchName"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["BranchName"].ToString();
                txtAccountName.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["AccountName"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["AccountName"].ToString();
            }
        }
        public void DeleteRDInfoByRDID(int RDID)
        {
            Model.Procurement p = new Model.Procurement();
            ProcurementData pd = new ProcurementData();
            p.RDID = string.IsNullOrEmpty(hfRDID.Value) ? 0 : Convert.ToInt32(hfRDID.Value);
            p.RouteID = 0;
            p.SupplierID = 0;
            p.RDStartDate = txtRDStartDate.Text;
            p.RDMaturityDate = txtRDMaturityDate.Text;
            p.RDAmount = 0;
            p.RepaymentAmt = 0;
            p.RDStatus = DropDownList1.SelectedItem.Text;
            p.RDPaymentDateTime = txtRDPaymentDate.Text;
            p.AccounNumber = txtAccountNo.Text;
            p.BankName = dpBankName.SelectedItem.Text;
            p.IFSCCode = dpIfscCode.SelectedItem.Text;
            p.BranchName = txtBranchName.Text;
            p.AccountName = txtAccountName.Text;
            p.CreatedBy = App_code.GlobalInfo.Userid;
            p.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
            p.ModifiedBy = App_code.GlobalInfo.Userid;
            p.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");


            p.flag = "Delete";
            int Result = 0;
            Result = pd.InsertSupplierRDInfo(p);
            if (Result > 0)
            {
                //lbltital.Text = "Add Route";
                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Supplier RD Info Deleted  Successfully";
                ClearTextBox();
                BindeSupplierRDInfo();
                pnlError.Update();
                btnAddRDInfo.Visible = true;
                btnupdateRDInfo.Visible = false;
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

        protected void btnAddRDInfo_Click(object sender, EventArgs e)
        {
            Model.Procurement p = new Model.Procurement();
            ProcurementData pd = new ProcurementData();
            p.RDID = 0;
            p.RouteID = Convert.ToInt32(dpRoute.SelectedValue);
            p.SupplierID = Convert.ToInt32(dpSupplier.SelectedValue);
            p.RDStartDate = txtRDStartDate.Text;
            p.RDMaturityDate = txtRDMaturityDate.Text;
            p.RDAmount = string.IsNullOrEmpty(txtRDAmount.Text.ToString()) ? 0 : Convert.ToDouble(txtRDAmount.Text);
            p.RepaymentAmt = string.IsNullOrEmpty(txtRDRepaymentAmount.Text.ToString()) ? 0 : Convert.ToDouble(txtRDRepaymentAmount.Text);
            p.RDStatus = DropDownList1.SelectedItem.Text;
            p.RDPaymentDateTime = txtRDPaymentDate.Text;
            p.AccounNumber = txtAccountNo.Text;
            p.BankName = dpBankName.SelectedItem.Text;
            p.IFSCCode = dpIfscCode.SelectedItem.Text;
            p.BranchName = txtBranchName.Text;
            p.AccountName = txtAccountName.Text;
            p.CreatedBy = App_code.GlobalInfo.Userid;
            p.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
            p.ModifiedBy = App_code.GlobalInfo.Userid;
            p.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");
            p.flag = "Insert";
            int Result = 0;
            Result = pd.InsertSupplierRDInfo(p);
            if (Result > 0)
            {

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Supplier RD Info Add  Successfully";

                ClearTextBox();
                BindeSupplierRDInfo();
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

        protected void btnupdateRDInfo_Click(object sender, EventArgs e)
        {
            Model.Procurement p = new Model.Procurement();
            ProcurementData pd = new ProcurementData();
            p.RDID = string.IsNullOrEmpty(hfRDID.Value) ? 0 : Convert.ToInt32(hfRDID.Value);
            p.RouteID = Convert.ToInt32(dpRoute.SelectedValue);
            p.SupplierID = Convert.ToInt32(dpSupplier.SelectedValue);
            p.RDStartDate = txtRDStartDate.Text;
            p.RDMaturityDate = txtRDMaturityDate.Text;
            p.RDAmount = string.IsNullOrEmpty(txtRDAmount.Text.ToString()) ? 0 : Convert.ToDouble(txtRDAmount.Text);
            p.RepaymentAmt = string.IsNullOrEmpty(txtRDRepaymentAmount.Text.ToString()) ? 0 : Convert.ToDouble(txtRDRepaymentAmount.Text);
            p.RDStatus = DropDownList1.SelectedItem.Text;
            p.RDPaymentDateTime = txtRDPaymentDate.Text;
            p.AccounNumber = txtAccountNo.Text;
            p.BankName = dpBankName.SelectedItem.Text;
            p.IFSCCode = dpIfscCode.SelectedItem.Text;
            p.BranchName = txtBranchName.Text;
            p.AccountName = txtAccountName.Text;
            p.CreatedBy = App_code.GlobalInfo.Userid;
            p.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
            p.ModifiedBy = App_code.GlobalInfo.Userid;
            p.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");

            p.flag = "Update";
            int Result = 0;
            Result = pd.InsertSupplierRDInfo(p);
            if (Result > 0)
            {
                //lbltital.Text = "Add Route";
                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Supplier RD Info Updated  Successfully";
                ClearTextBox();
                BindeSupplierRDInfo();
                pnlError.Update();
                btnAddRDInfo.Visible = true;
                btnupdateRDInfo.Visible = false;
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
            DS = BindCommanData.BindCommanDropDwon("SupplierID ", "SupplierCode +' '+SupplierName as Name  ", "Proc_MilkSuppliersProfile", "IsActive=1 and RouteId=" + dpRoute.SelectedItem.Value);

            dpSupplier.DataSource = DS;
            dpSupplier.DataBind();
            dpSupplier.Items.Insert(0, new ListItem("--Select Supplier  --", "0"));
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Tabs/Procurement/AddSupplierRDInfo.aspx");
        }
    }
}