using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Bussiness;
using Model;
using System.Text;

namespace Dairy.Tabs.Procurement
{
    public partial class VehicleMaster : System.Web.UI.Page
    {
        DataSet DS = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindVehicleList();
                BindDropDwon();
                btnAddVehicle.Visible = true;
                btnupdateVehicle.Visible = false;
            }
        }

        public void BindDropDwon()
        {
            DS = BindCommanData.BindCommanDropDwon("id as VahicleID", "VehicleType as VehicleName", "Proc_VehicleType", "id is not null");
            dpVehicleType.DataSource = DS;
            dpVehicleType.DataBind();
            dpVehicleType.Items.Insert(0, new ListItem("--Select Vehicle Model--", "0"));

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

            DS = BindCommanData.BindCommanDropDwon("RouteID ", "RouteCode +' '+RouteName as Name  ", "Proc_MilkCollectionRoute", "IsActive=1 ");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpRoute.DataSource = DS;
                dpRoute.DataBind();
                dpRoute.Items.Insert(0, new ListItem("--Select Route  --", "0"));
            }
        }
        protected void btnAddVehicle_Click(object sender, EventArgs e)
        {
            Model.Procurement p = new Model.Procurement();
            ProcurementData pd = new ProcurementData();
            p.VehicleMasterID = 0;
            //p.VehicleName = txtVehicleName.Text;
            p.VehicleNo = txtVehicleNo.Text;
            p.VehicleID1 = 'V'+ txtVehicleNo.Text;
            p.VehicleOwnerName = txtOwnerName.Text;
            p.OwnerEmail = txtOwnerEmail.Text;
            p.OwnerMobileNo = txtOwnerMobileNo.Text;
            p.TransportType = dpTransportType.SelectedItem.Text;
            p.VehicleType = Convert.ToInt32(dpVehicleType.SelectedItem.Value);
            p.DriverName = txtDriverName.Text;
            p.DriverMobileNo = txtDriverMobile.Text;
            p.OwnerBankName = dpBankName.SelectedItem.Text;
            p.IFSCCode = dpIfscCode.SelectedItem.Text;
            p.BranchName = txtBranchName.Text;
            p.AccountNo = txtAccNo.Text;
            p.RouteID = Convert.ToInt32(dpRoute.SelectedItem.Value);
            p.tdspercentage = Convert.ToDouble(txtTDSPercent.Text);
            p.CreatedBy = App_code.GlobalInfo.Userid;
            if (DropDownList1.SelectedValue == "1")
            {
                p.IsActive = true;
            }
            else if (DropDownList1.SelectedValue == "2")
            {
                p.IsActive = false;
            }
            p.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
            p.ModifiedBy = App_code.GlobalInfo.Userid;
            p.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");
            p.flag = "Insert";
            int Result = 0;
            Result = pd.InsertVehicleDetails(p);
            if (Result > 0)
            {

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Vehicle Record Add  Successfully";

                ClearTextBox();
                BindVehicleList();
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

        public void ClearTextBox()
        {
            txtAccNo.Text = string.Empty;
            txtBranchName.Text = string.Empty;
            txtDriverMobile.Text = string.Empty;
            txtDriverName.Text = string.Empty;
            txtOwnerEmail.Text = string.Empty;
            txtOwnerMobileNo.Text = string.Empty;
            txtOwnerName.Text = string.Empty;
            //txtVehicleName.Text = string.Empty;
            txtVehicleNo.Text = string.Empty;
            //txtVehicleSrNo.Text = string.Empty;
            dpTransportType.ClearSelection();
            dpIfscCode.ClearSelection();
            dpBankName.ClearSelection();
            dpVehicleType.ClearSelection();
            DropDownList1.ClearSelection();
            dpRoute.ClearSelection();
            txtTDSPercent.Text = string.Empty;
        }
        public void BindVehicleList()
        {

            ProcurementData pd = new ProcurementData();
            DataSet DS = new DataSet();
            StringBuilder sb = new StringBuilder();
            DS = pd.GetAllVehicleDetails();
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                    rpVehicleList.DataSource = DS;
                    rpVehicleList.DataBind();
            }
        }

        protected void rpVehicleList_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {

            divDanger.Visible = false;
            divwarning.Visible = false;
            divSusccess.Visible = false;
            pnlError.Update();
            int vehicleid = 0;
            vehicleid = Convert.ToInt32(e.CommandArgument);
            switch (e.CommandName)
            {
                case ("Edit"):
                    {
                        //lbltital.Text = "Edit Route";
                        hfrouteID.Value = vehicleid.ToString();
                        vehicleid = Convert.ToInt32(hfrouteID.Value);
                        //BindRouteList();
                        GetVehicleDetailsbyID(vehicleid);
                        btnAddVehicle.Visible = false;
                        btnupdateVehicle.Visible = true;
                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }
                case ("delete"):
                    {

                        hfrouteID.Value = vehicleid.ToString();
                        vehicleid = Convert.ToInt32(hfrouteID.Value);
                        DeleteVehiclebyvehicleID(vehicleid);
                        BindVehicleList();
                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }


            }
        }


        public void GetVehicleDetailsbyID(int vehicleid)
        {
            DataSet DS = new DataSet();
            ProcurementData pd = new ProcurementData();
            DS = pd.GetVehicleDetailsbyID(vehicleid);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                //txtVehicleSrNo.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["VehicleSrNo"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["VehicleSrNo"].ToString();
                txtVehicleNo.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["VehicleNo"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["VehicleNo"].ToString();
                //txtVehicleName.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["VehicleName"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["VehicleName"].ToString();
                txtOwnerName.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["VehicleOwnerName"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["VehicleOwnerName"].ToString();
                txtOwnerMobileNo.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["OwnerMobileNo"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["OwnerMobileNo"].ToString();
                txtOwnerEmail.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["OwnerEmail"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["OwnerEmail"].ToString();
                txtDriverName.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["DriverName"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["DriverName"].ToString();
                txtDriverMobile.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["DriverMobileNo"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["DriverMobileNo"].ToString();
                txtBranchName.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["BranchName"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["BranchName"].ToString();
                dpIfscCode.ClearSelection();
                if (dpIfscCode.Items.FindByText(DS.Tables[0].Rows[0]["IFSCCode"].ToString()) != null)
                {
                    dpIfscCode.Items.FindByText(DS.Tables[0].Rows[0]["IFSCCode"].ToString()).Selected = true;
                 }
            
                txtAccNo.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["AccountNo"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["AccountNo"].ToString();
                dpRoute.ClearSelection();
                if (dpRoute.Items.FindByValue(DS.Tables[0].Rows[0]["RouteID"].ToString()) != null)
                {
                    dpRoute.Items.FindByValue(DS.Tables[0].Rows[0]["RouteID"].ToString()).Selected = true;
                }
               // txtTax.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Tax"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Tax"].ToString();
                txtTDSPercent.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["TDS"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["TDS"].ToString();
                dpVehicleType.ClearSelection();
                if (dpVehicleType.Items.FindByValue(DS.Tables[0].Rows[0]["VehicleType"].ToString()) != null)
                {
                    dpVehicleType.Items.FindByValue(DS.Tables[0].Rows[0]["VehicleType"].ToString()).Selected = true;
                }
                dpTransportType.ClearSelection();
                if (dpTransportType.Items.FindByText(DS.Tables[0].Rows[0]["TransportType"].ToString()) != null)
                {
                    dpTransportType.Items.FindByText(DS.Tables[0].Rows[0]["TransportType"].ToString()).Selected = true;
                }
                dpBankName.ClearSelection();
                if (dpBankName.Items.FindByText(DS.Tables[0].Rows[0]["OwnerBankName"].ToString()) != null)
                {
                    dpBankName.Items.FindByText(DS.Tables[0].Rows[0]["OwnerBankName"].ToString()).Selected = true;
                }
                DropDownList1.ClearSelection();
                
             
                if (DS.Tables[0].Rows[0]["IsActive"].ToString() == "True")
                {
                    DropDownList1.Items.FindByValue("1").Selected = true;
                }
                else if (DS.Tables[0].Rows[0]["IsActive"].ToString() == "False")
                {
                    DropDownList1.Items.FindByValue("2").Selected = true;
                }

            }
        }
        public void DeleteVehiclebyvehicleID(int vehicleid)
        {

            Model.Procurement p = new Model.Procurement();
            ProcurementData pd = new ProcurementData();
            p.VehicleMasterID = string.IsNullOrEmpty(hfrouteID.Value) ? 0 : Convert.ToInt32(hfrouteID.Value);
            p.VehicleName = string.Empty;
            p.VehicleNo = string.Empty;
            p.VehicleID1 = string.Empty;
            p.VehicleOwnerName = string.Empty;
            p.OwnerEmail = string.Empty;
            p.OwnerMobileNo = string.Empty;
            //p.VehicleSrNo = string.Empty;
            p.tdspercentage = 0;
            p.VehicleType = 0;
            p.DriverName = string.Empty;
            p.DriverMobileNo = string.Empty;
            p.OwnerBankName = dpBankName.SelectedItem.Text;
            p.IFSCCode = dpIfscCode.SelectedItem.Text;
            p.BranchName = string.Empty;
            p.AccountNo = string.Empty;
            p.RouteID = 0;
            p.IsActive = false;
            p.TransportType = dpTransportType.SelectedItem.Text;
            p.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
            p.ModifiedBy = App_code.GlobalInfo.Userid;
            p.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");
            p.flag = "Delete";
            int Result = 0;
            Result = pd.InsertVehicleDetails(p);
            if (Result > 0)
            {

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Delete Updated  Successfully";
                ClearTextBox();
                BindVehicleList();
                pnlError.Update();
                btnAddVehicle.Visible = true;
                btnupdateVehicle.Visible = false;
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
        protected void btnupdateVehicle_Click(object sender, EventArgs e)
        {
            Model.Procurement p = new Model.Procurement();
            ProcurementData pd = new ProcurementData();
            p.VehicleMasterID = string.IsNullOrEmpty(hfrouteID.Value) ? 0 : Convert.ToInt32(hfrouteID.Value);
            //p.VehicleName = txtVehicleName.Text;
            p.VehicleNo = txtVehicleNo.Text;
            p.VehicleID1 = 'V' + txtVehicleNo.Text;
            p.VehicleOwnerName = txtOwnerName.Text;
            p.OwnerEmail = txtOwnerEmail.Text;
            p.OwnerMobileNo = txtOwnerMobileNo.Text;
            p.TransportType = dpTransportType.SelectedItem.Text;
            //p.VehicleSrNo = txtVehicleSrNo.Text;
            p.VehicleType = Convert.ToInt16(dpVehicleType.SelectedItem.Value);
            p.DriverName = txtDriverName.Text;
            p.DriverMobileNo = txtDriverMobile.Text;
            p.OwnerBankName = dpBankName.SelectedItem.Text;
            p.IFSCCode = dpIfscCode.SelectedItem.Text;
            p.BranchName = txtBranchName.Text;
            p.AccountNo = txtAccNo.Text;
            p.RouteID = Convert.ToInt32(dpRoute.SelectedItem.Value);
            if (DropDownList1.SelectedValue == "1")
            {
                p.IsActive = true;
            }
            else if (DropDownList1.SelectedValue == "2")
            {
                p.IsActive = false;
            }
            p.tdspercentage = Convert.ToDouble(txtTDSPercent.Text);
            p.CreatedBy = App_code.GlobalInfo.Userid;
            p.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
            p.ModifiedBy = App_code.GlobalInfo.Userid;
            p.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");
            p.flag = "Update";
            int Result = 0;
            Result = pd.InsertVehicleDetails(p);
            if (Result > 0)
            {
                //lbltital.Text = "Add Route";
                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Vehicle Record Updated  Successfully";
                ClearTextBox();
                BindVehicleList();
                pnlError.Update();
                btnAddVehicle.Visible = true;
                btnupdateVehicle.Visible = false;
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

        protected void txtVehicleNo_TextChanged(object sender, EventArgs e)
        {
            ProcurementData pd = new ProcurementData();
            DataSet DS = new DataSet();
         
            DS = pd.GetAllVehicleDetails();
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                foreach (DataRow row in DS.Tables[0].Rows)
                {
                    if (row["VehicleNo"].ToString().Trim() == txtVehicleNo.Text.ToString().Trim())
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Vehicle No. Already exists')", true);
                        txtVehicleNo.Text = string.Empty;
                    }

                }
            }
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
           Response.Redirect("~/Tabs/Procurement/VehicleMaster.aspx");
        }
    }
}