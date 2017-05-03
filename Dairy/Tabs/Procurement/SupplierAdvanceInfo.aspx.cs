using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bussiness;
using System.Text;

namespace Dairy.Tabs.Procurement
{
    public partial class SupplierAdvanceInfo : System.Web.UI.Page
    {
        DataSet DS = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindeSupplierAdvanceInfo();
                BindDropdown();
                btnAddAdvanceInfo.Visible = true;
                btnupdateAdvanceInfo.Visible = false;

            }
        }
        public void BindDropdown()
        {
            DS = BindCommanData.BindCommanDropDwon("VehicleMasterID ", "VehicleNo as Name  ", "Proc_VehicleMaster", "IsActive=1 ");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpVehical.DataSource = DS;
                dpVehical.DataBind();
                dpVehical.Items.Insert(0, new ListItem("--Select Vehical  --", "0"));
            }
        }


        public void ClearTextBox()
        {
            dpVehical.ClearSelection();
            txtAdvanceAmount.Text = string.Empty;
            txtAdvanceBalance.Text = string.Empty;
            txtAdvanceDate.Text = string.Empty;
            txtAdvanceDeducted.Text = string.Empty;
            txtDeductDate.Text = string.Empty;

        }
        public void BindeSupplierAdvanceInfo()
        {

            ProcurementData pd = new ProcurementData();
            DataSet DS = new DataSet();
            StringBuilder sb = new StringBuilder();
            DS = pd.GetAllSupplierAdvanceInfo();
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                rpAdvanceInfo.DataSource = DS;
                rpAdvanceInfo.DataBind();
            }
        }
        protected void rpAdvanceInfo_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {

            divDanger.Visible = false;
            divwarning.Visible = false;
            divSusccess.Visible = false;
            pnlError.Update();
            int AdvanceID = 0;
            AdvanceID = Convert.ToInt32(e.CommandArgument);
            switch (e.CommandName)
            {
                case ("Edit"):
                    {
                        //lbltital.Text = "Edit Route";
                        hfAdvanceID.Value = AdvanceID.ToString();
                        AdvanceID = Convert.ToInt32(hfAdvanceID.Value);
                        //BindRouteList();
                        ClearTextBox();
                        GetSupplierAdvanceInfobyID(AdvanceID);
                        btnAddAdvanceInfo.Visible = false;
                        btnupdateAdvanceInfo.Visible = true;
                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }
                case ("delete"):
                    {

                        hfAdvanceID.Value = AdvanceID.ToString();
                        AdvanceID = Convert.ToInt32(hfAdvanceID.Value);
                        DeleteRoutebyrouteID(AdvanceID);
                        BindeSupplierAdvanceInfo();
                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }


            }
        }
        public void GetSupplierAdvanceInfobyID(int LoanID)
        {
            DataSet DS = new DataSet();
            ProcurementData pd = new ProcurementData();
            DS = pd.GetSupplierAdvanceInfobyID(LoanID);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpVehical.ClearSelection();
                if (dpVehical.Items.FindByValue(DS.Tables[0].Rows[0]["VehicalID"].ToString()) != null)
                {
                    dpVehical.Items.FindByValue(DS.Tables[0].Rows[0]["VehicalID"].ToString()).Selected = true;
                }
                txtAdvanceAmount.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["AdvanceAmount"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["AdvanceAmount"].ToString();
                txtAdvanceDate.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["AdvanceDateTime"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["AdvanceDateTime"].ToString();
                txtAdvanceDeducted.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["AdvanceDeducted"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["AdvanceDeducted"].ToString();
                txtAdvanceBalance.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["AdvanceBalance"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["AdvanceBalance"].ToString();
                txtDeductDate.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["DeductDateTime"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["DeductDateTime"].ToString();
                txtInterest.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Interest"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Interest"].ToString();
                txtInstallments.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Installments"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Installments"].ToString();
                txtInstallAmt.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["InstallmentAmt"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["InstallmentAmt"].ToString();

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

        protected void btnAddAdvanceInfo_Click(object sender, EventArgs e)
        {
            Model.Procurement p = new Model.Procurement();
            ProcurementData pd = new ProcurementData();
            p.AdvanceID = 0;
            p.VehicleID = Convert.ToInt32(dpVehical.SelectedValue);
            p.AdvanceAmount = Convert.ToDouble(txtAdvanceAmount.Text);
            p.AdvanceDateTime = txtAdvanceDate.Text;
            p.AdvanceDeducted = Convert.ToDouble(txtAdvanceDeducted.Text);
            p.AdvanceBalance = Convert.ToDouble(txtAdvanceBalance.Text);
            p.DeductDateTime = txtDeductDate.Text;
            p.Interest = Convert.ToDouble(txtInterest.Text);
            p.Installments = Convert.ToInt32(txtInstallments.Text);
            p.InstallmentAmount = Convert.ToDouble(txtInstallAmt.Text);
            p.CreatedBy = App_code.GlobalInfo.Userid;
            p.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
            p.ModifiedBy = App_code.GlobalInfo.Userid;
            p.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");
            p.flag = "Insert";
            int Result = 0;
            Result = pd.InsertSupplierAdvanceInfo(p);
            if (Result > 0)
            {

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Supplier Advance Info Add  Successfully";

                ClearTextBox();
                BindeSupplierAdvanceInfo();
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

        protected void btnupdateAdvanceInfo_Click(object sender, EventArgs e)
        {
            Model.Procurement p = new Model.Procurement();
            ProcurementData pd = new ProcurementData();
            p.AdvanceID = string.IsNullOrEmpty(hfAdvanceID.Value) ? 0 : Convert.ToInt32(hfAdvanceID.Value);
            p.VehicleID = Convert.ToInt32(dpVehical.SelectedValue);
            p.AdvanceAmount = Convert.ToDouble(txtAdvanceAmount.Text);
            p.AdvanceDateTime = txtAdvanceDate.Text;
            p.AdvanceDeducted = Convert.ToDouble(txtAdvanceDeducted.Text);
            p.AdvanceBalance = Convert.ToDouble(txtAdvanceBalance.Text);
            p.DeductDateTime = txtDeductDate.Text;
            p.Interest = Convert.ToDouble(txtInterest.Text);
            p.Installments = Convert.ToInt32(txtInstallments.Text);
            p.InstallmentAmount = Convert.ToDouble(txtInstallAmt.Text);
            p.CreatedBy = App_code.GlobalInfo.Userid;
            p.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
            p.ModifiedBy = App_code.GlobalInfo.Userid;
            p.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");

            p.flag = "Update";
            int Result = 0;
            Result = pd.InsertSupplierAdvanceInfo(p);
            if (Result > 0)
            {
                //lbltital.Text = "Add Route";
                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Supplier Advance Info Updated  Successfully";
                ClearTextBox();
                BindeSupplierAdvanceInfo();
                pnlError.Update();
                btnAddAdvanceInfo.Visible = true;
                btnupdateAdvanceInfo.Visible = false;
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

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Tabs/Procurement/SupplierAdvanceInfo.aspx");
        }
    }
}