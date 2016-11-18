using Bussiness;
using Dairy.App_code;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dairy.Tabs.TransportModule
{
    public partial class TransportDetails : System.Web.UI.Page
    {
        DispatchData dispatchdata;
        Dispatch dispatch;
        DataSet DS = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnAddTransportInfo.Visible = true;
                btnupdateTransportdetail.Visible = false;
                GetTransportDetails();
                txtVeh_InsLast.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                txtVeh_InsStart.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));

                DS = BindCommanData.BindCommanDropDwon("ID ", "CONFIGVALUE  as Name  ", "CONFIGMASTER", "ISACTIVE=1 and CONFIGNAME='Transport' and CONFIGKEY='VehicleType'");
                if (!Comman.Comman.IsDataSetEmpty(DS))
                {
                    dpVeh_Type.DataSource = DS;
                    dpVeh_Type.DataBind();
                    dpVeh_Type.Items.Insert(0, new ListItem("--Select Vehicle Type  --", "0"));
                }
                DS = BindCommanData.BindCommanDropDwon("ID ", "CONFIGVALUE  as Name  ", "CONFIGMASTER", "ISACTIVE=1 and CONFIGNAME='Transport' and CONFIGKEY='Insuranceprovider'");
                if (!Comman.Comman.IsDataSetEmpty(DS))
                {
                    dpVeh_InsProvider.DataSource = DS;
                    dpVeh_InsProvider.DataBind();
                    dpVeh_InsProvider.Items.Insert(0, new ListItem("--Select Insurance Provider  --", "0"));
                }
                DS = BindCommanData.BindCommanDropDwon("ID ", "CONFIGVALUE  as Name  ", "CONFIGMASTER", "ISACTIVE=1 and CONFIGNAME='Transport' and CONFIGKEY='Fueltype'");
                if (!Comman.Comman.IsDataSetEmpty(DS))
                {
                    dpVeh_FuelType.DataSource = DS;
                    dpVeh_FuelType.DataBind();
                    dpVeh_FuelType.Items.Insert(0, new ListItem("--Select Fuel Type  --", "0"));
                }
                DS = BindCommanData.BindCommanDropDwon("ID ", "CONFIGVALUE  as Name  ", "CONFIGMASTER", "ISACTIVE=1 and CONFIGNAME='Transport' and CONFIGKEY='Ownershiptype'");
                if (!Comman.Comman.IsDataSetEmpty(DS))
                {
                    dpVeh_OwnershipType.DataSource = DS;
                    dpVeh_OwnershipType.DataBind();
                    dpVeh_OwnershipType.Items.Insert(0, new ListItem("--Select Ownership Type  --", "0"));
                }
                DS = BindCommanData.BindCommanDropDwon("tr_brand_Id ", "tr_brand_name  as Name  ", "Tr_Brand_Master", "IsActive=1");
                if (!Comman.Comman.IsDataSetEmpty(DS))
                {
                    dpVehicleBrand.DataSource = DS;
                    dpVehicleBrand.DataBind();
                    dpVehicleBrand.Items.Insert(0, new ListItem("--Select Vehicle Brand  --", "0"));
                }
                DS = BindCommanData.BindCommanDropDwon("tr_model_Id ", "tr_model_name  as Name  ", "Tr_Model_Master", "IsActive=1");
                if (!Comman.Comman.IsDataSetEmpty(DS))
                {
                    dpVeh_Model.DataSource = DS;
                    dpVeh_Model.DataBind();
                    dpVeh_Model.Items.Insert(0, new ListItem("--Select Vehicle Model  --", "0"));
                }

                DS = BindCommanData.BindCommanDropDwon("ID ", "CONFIGVALUE  as Name  ", "CONFIGMASTER", "ISACTIVE=1 and CONFIGNAME='Transport' and CONFIGKEY='BankName'");
                if (!Comman.Comman.IsDataSetEmpty(DS))
                {
                    dpBank.DataSource = DS;
                    dpBank.DataBind();
                    dpBank.Items.Insert(0, new ListItem("--Select BankName  --", "0"));
                }
            }

        }

        protected void rpTransportList_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {

            divDanger.Visible = false;
            divwarning.Visible = false;
            divSusccess.Visible = false;
            pnlError.Update();
            int Id = 0;
            Id = Convert.ToInt32(e.CommandArgument);
            switch (e.CommandName)
            {
                case ("Edit"):
                    {
                        lblHeaderTab.Text = "Edit Transport Details";
                        htransId.Value = Id.ToString();
                        Id = Convert.ToInt32(htransId.Value);
                        GetTransportDatabyId(Id);
                        //BindRouteList();

                        btnAddTransportInfo.Visible = false;
                        btnupdateTransportdetail.Visible = true;
                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }
                case ("delete"):
                    {

                        htransId.Value = Id.ToString();
                        Id = Convert.ToInt32(htransId.Value);
                        DeleteTransportDetails(Id);
                        bindTransportList();
                        upMain.Update();
                        uprouteList.Update();
                        break;

                    }


            }


        }
        public void GetTransportDatabyId(int TM_Id)
        {
            DataSet DS = new DataSet();
            DispatchData transdata = new DispatchData();
            DS = transdata.GetTransportDatabyId(TM_Id);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                txtVehicleNo.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["VehicleNo"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["VehicleNo"].ToString();
                dpVehicleBrand.ClearSelection();
                if (dpVehicleBrand.Items.FindByValue(DS.Tables[0].Rows[0]["VehicleBrand"].ToString()) != null)
                {
                    dpVehicleBrand.Items.FindByValue(DS.Tables[0].Rows[0]["VehicleBrand"].ToString()).Selected = true;
                }
                dpVeh_Model.ClearSelection();
                if (dpVeh_Model.Items.FindByValue(DS.Tables[0].Rows[0]["Veh_Model"].ToString()) != null)
                {
                    dpVeh_Model.Items.FindByValue(DS.Tables[0].Rows[0]["Veh_Model"].ToString()).Selected = true;
                }

                txtVeh_Year.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Veh_Year"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Veh_Year"].ToString();
                dpVeh_Type.ClearSelection();
                if (dpVeh_Type.Items.FindByText(DS.Tables[0].Rows[0]["Veh_Type"].ToString()) != null)
                {
                    dpVeh_Type.Items.FindByText(DS.Tables[0].Rows[0]["Veh_Type"].ToString()).Selected = true;
                }
                txtVeh_Reg.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Veh_Reg"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Veh_Reg"].ToString();
                txtVeh_ChassisNo.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Veh_ChassisNo"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Veh_ChassisNo"].ToString();
                txtVeh_EngineNo.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Veh_EngineNo"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Veh_EngineNo"].ToString();
                dpVeh_InsProvider.ClearSelection();
                if (dpVeh_InsProvider.Items.FindByValue(DS.Tables[0].Rows[0]["Veh_InsProvider"].ToString()) != null)
                {
                    dpVeh_InsProvider.Items.FindByValue(DS.Tables[0].Rows[0]["Veh_InsProvider"].ToString()).Selected = true;
                }

                txtVeh_InsPolicyNo.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Veh_InsPolicyNo"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Veh_InsPolicyNo"].ToString();


                if (DS.Tables[0].Rows[0]["Veh_InsStart"].ToString() == "")
                {
                    txtVeh_InsStart.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Veh_InsStart"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Veh_InsStart"].ToString();
                }
                else
                {
                    string insDue = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Veh_InsStart"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Veh_InsStart"].ToString();
                    //sky
                    DateTime insDue1 = Convert.ToDateTime(insDue, System.Globalization.CultureInfo.GetCultureInfo("ur-PK").DateTimeFormat);
                    txtVeh_InsStart.Text = (Convert.ToDateTime(insDue1).ToString("yyyy-MM-dd"));
                }

                if (DS.Tables[0].Rows[0]["Veh_InsLast"].ToString() == "")
                {
                    txtVeh_InsLast.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Veh_InsLast"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Veh_InsLast"].ToString();
                }
                else
                {
                    string insDue2 = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Veh_InsLast"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Veh_InsLast"].ToString();
                    DateTime ins2 = Convert.ToDateTime(insDue2, System.Globalization.CultureInfo.GetCultureInfo("ur-PK").DateTimeFormat);
                    txtVeh_InsLast.Text = (Convert.ToDateTime(ins2).ToString("yyyy-MM-dd"));
                }
                txtInsAmount.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["InsAmount"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["InsAmount"].ToString();
                dpVeh_OwnershipType.ClearSelection();
                if (dpVeh_OwnershipType.Items.FindByText(DS.Tables[0].Rows[0]["Veh_OwnershipType"].ToString()) != null)
                {
                    dpVeh_OwnershipType.Items.FindByText(DS.Tables[0].Rows[0]["Veh_OwnershipType"].ToString()).Selected = true;
                }

                txtVeh_OwnerName.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Veh_OwnerName"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Veh_OwnerName"].ToString();
                txtVeh_ContactNo.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Veh_ContactNo"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Veh_ContactNo"].ToString();
                txtVeh_OwnerAddress.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Veh_OwnerAddress"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Veh_OwnerAddress"].ToString();
                dpVeh_FuelType.ClearSelection();
                if (dpVeh_FuelType.Items.FindByValue(DS.Tables[0].Rows[0]["Veh_FuelType"].ToString()) != null)
                {
                    dpVeh_FuelType.Items.FindByValue(DS.Tables[0].Rows[0]["Veh_FuelType"].ToString()).Selected = true;
                }
                dpBank.ClearSelection();
                if (dpBank.Items.FindByValue(DS.Tables[0].Rows[0]["BankId"].ToString()) != null)
                {
                    dpBank.Items.FindByValue(DS.Tables[0].Rows[0]["BankId"].ToString()).Selected = true;
                }
                txtBankAc.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["BankAc"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["BankAc"].ToString();

                dpIsActive.ClearSelection();
                if (DS.Tables[0].Rows[0]["IsActive"].ToString() == "True")
                {
                    dpIsActive.Items.FindByValue("1").Selected = true;
                }
                if (DS.Tables[0].Rows[0]["IsActive"].ToString() == "False")
                {
                    dpIsActive.Items.FindByValue("2").Selected = true;
                }

            }
        }

        public void bindTransportList()
        {

            DispatchData transdata = new DispatchData();
            DataSet DS = new DataSet();
            StringBuilder sb = new StringBuilder();
            DS = transdata.GetTransportDetails();
            rpTransportList.DataSource = DS;
            rpTransportList.DataBind();
        }
        public void ClearTextBox()
        {
            txtVehicleNo.Text = string.Empty;
            dpVehicleBrand.ClearSelection();
            dpVeh_Model.ClearSelection();
            txtVeh_Year.Text = string.Empty;
            //-------------------------------------
            dpVeh_Type.ClearSelection();
            txtVeh_Reg.Text = string.Empty;
            txtVeh_ChassisNo.Text = string.Empty;
            txtVeh_EngineNo.Text = string.Empty;
            //---------------------------------------
            dpVeh_InsProvider.ClearSelection();

            txtVeh_InsPolicyNo.Text = string.Empty;
            txtVeh_InsStart.Text = string.Empty;
            //------------------------------------
            txtVeh_InsLast.Text = string.Empty;
            txtInsAmount.Text = string.Empty;
            dpVeh_OwnershipType.ClearSelection();
            txtVeh_OwnerName.Text = string.Empty;
            txtVeh_ContactNo.Text = string.Empty;
            //---------------------------------------------
            txtVeh_OwnerAddress.Text = string.Empty;
            dpVeh_FuelType.ClearSelection();
            dpBank.ClearSelection();
            txtBankAc.Text = string.Empty;
            dpIsActive.ClearSelection();
        }


        protected void btnAddTransportInfo_click(object sender, EventArgs e)
        {
            dispatchdata = new DispatchData();
            dispatch = new Dispatch();
            dispatch.TM_Id = 0;
            dispatch.VehicleNo = string.IsNullOrEmpty(txtVehicleNo.Text.ToString()) ? string.Empty : Convert.ToString(txtVehicleNo.Text);
            dispatch.VehicleBrand = string.IsNullOrEmpty(dpVehicleBrand.SelectedItem.Value.ToString()) ? 0 : Convert.ToInt32(dpVehicleBrand.SelectedItem.Value);
            dispatch.Veh_Model = string.IsNullOrEmpty(dpVeh_Model.SelectedItem.Value.ToString()) ? 0 : Convert.ToInt32(dpVeh_Model.SelectedItem.Value);
            dispatch.Veh_Year = string.IsNullOrEmpty(txtVeh_Year.Text.ToString()) ? string.Empty : Convert.ToString(txtVeh_Year.Text);
            dispatch.Veh_Type = string.IsNullOrEmpty(dpVeh_Type.SelectedItem.Text.ToString()) ? string.Empty : Convert.ToString(dpVeh_Type.SelectedItem.Text);
            dispatch.Veh_Reg = string.IsNullOrEmpty(txtVeh_Reg.Text.ToString()) ? string.Empty : Convert.ToString(txtVeh_Reg.Text);
            dispatch.Veh_ChassisNo = string.IsNullOrEmpty(txtVeh_ChassisNo.Text.ToString()) ? string.Empty : Convert.ToString(txtVeh_ChassisNo.Text);
            dispatch.Veh_EngineNo = string.IsNullOrEmpty(txtVeh_EngineNo.Text.ToString()) ? string.Empty : Convert.ToString(txtVeh_EngineNo.Text);
            dispatch.Veh_InsProvider = string.IsNullOrEmpty(dpVeh_InsProvider.SelectedItem.Text.ToString()) ? 0 : Convert.ToInt32(dpVeh_InsProvider.SelectedItem.Value);
            dispatch.Veh_InsPolicyNo = string.IsNullOrEmpty(txtVeh_InsPolicyNo.Text.ToString()) ? string.Empty : Convert.ToString(txtVeh_InsPolicyNo.Text);
            dispatch.Veh_InsStart = string.IsNullOrEmpty(txtVeh_InsStart.Text.ToString()) ? string.Empty : (Convert.ToDateTime(txtVeh_InsStart.Text)).ToString("dd-MM-yyyy");
            dispatch.Veh_InsLast = string.IsNullOrEmpty(txtVeh_InsLast.Text.ToString()) ? string.Empty : (Convert.ToDateTime(txtVeh_InsLast.Text)).ToString("dd-MM-yyyy");
            dispatch.Veh_InsAmount = string.IsNullOrEmpty(txtInsAmount.Text.ToString()) ? 0 : Convert.ToDouble(txtInsAmount.Text);
            dispatch.Veh_OwnershipType = string.IsNullOrEmpty(dpVeh_OwnershipType.Text.ToString()) ? string.Empty : Convert.ToString(dpVeh_OwnershipType.SelectedItem.Text);
            dispatch.Veh_OwnerName = string.IsNullOrEmpty(txtVeh_OwnerName.Text.ToString()) ? string.Empty : Convert.ToString(txtVeh_OwnerName.Text);
            dispatch.Veh_ContactNo = string.IsNullOrEmpty(txtVeh_ContactNo.Text.ToString()) ? string.Empty : Convert.ToString(txtVeh_ContactNo.Text);
            dispatch.Veh_OwnerAddress = string.IsNullOrEmpty(txtVeh_OwnerAddress.Text.ToString()) ? string.Empty : Convert.ToString(txtVeh_OwnerAddress.Text);
            dispatch.Veh_FuelType = string.IsNullOrEmpty(dpVeh_FuelType.Text.ToString()) ? 0 : Convert.ToInt32(dpVeh_FuelType.SelectedItem.Value);
            dispatch.BankId = string.IsNullOrEmpty(dpBank.Text.ToString()) ? 0 : Convert.ToInt32(dpBank.SelectedItem.Value);
            dispatch.BankAc = string.IsNullOrEmpty(txtBankAc.Text.ToString()) ? string.Empty : Convert.ToString(txtBankAc.Text);
            dispatch.CreatedBy = GlobalInfo.Userid;
            dispatch.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
            if (dpIsActive.SelectedItem.Value == "1")
            {
                dispatch.IsActive = true;
            }
            if (dpIsActive.SelectedItem.Value == "2")
            {
                dispatch.IsActive = false;
            }

            int Result = 0;
            Result = dispatchdata.AddTransportInfo(dispatch);
            if (Result > 0)
            {

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Transport Information Add  Successfully";

                ClearTextBox();
                GetTransportDetails();
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


        protected void btnupdateTransportdetail_click(object sender, EventArgs e)
        {
            Dispatch dispatch = new Dispatch();

            DispatchData dispatchdata = new DispatchData();
            dispatch.TM_Id = string.IsNullOrEmpty(htransId.Value) ? 0 : Convert.ToInt32(htransId.Value);
            dispatch.VehicleNo = txtVehicleNo.Text;
            dispatch.VehicleBrand = string.IsNullOrEmpty(dpVehicleBrand.SelectedItem.Value.ToString()) ? 0 : Convert.ToInt32(dpVehicleBrand.SelectedItem.Value);
            dispatch.Veh_Model = string.IsNullOrEmpty(dpVeh_Model.SelectedItem.Value.ToString()) ? 0 : Convert.ToInt32(dpVeh_Model.SelectedItem.Value);
            dispatch.Veh_Year = txtVeh_Year.Text;
            dispatch.Veh_Type = string.IsNullOrEmpty(dpVeh_Type.SelectedItem.Text.ToString()) ? string.Empty : Convert.ToString(dpVeh_Type.SelectedItem.Text);

            dispatch.Veh_Reg = txtVeh_Reg.Text;
            dispatch.Veh_ChassisNo = txtVeh_ChassisNo.Text;
            dispatch.Veh_EngineNo = txtVeh_EngineNo.Text;
            dispatch.Veh_InsProvider = string.IsNullOrEmpty(dpVeh_InsProvider.SelectedItem.Text.ToString()) ? 0 : Convert.ToInt32(dpVeh_InsProvider.SelectedItem.Value);


            dispatch.Veh_InsPolicyNo = txtVeh_InsPolicyNo.Text;
            dispatch.Veh_InsStart = string.IsNullOrEmpty(txtVeh_InsStart.Text) ? string.Empty : (Convert.ToDateTime(txtVeh_InsStart.Text)).ToString("dd-MM-yyyy");
            //------------------------------------
            dispatch.Veh_InsLast = string.IsNullOrEmpty(txtVeh_InsLast.Text) ? string.Empty : (Convert.ToDateTime(txtVeh_InsLast.Text)).ToString("dd-MM-yyyy");
            dispatch.Veh_InsAmount = string.IsNullOrEmpty(txtInsAmount.Text.ToString()) ? 0 : Convert.ToDouble(txtInsAmount.Text);
            dispatch.Veh_OwnershipType = string.IsNullOrEmpty(dpVeh_OwnershipType.SelectedItem.Text.ToString()) ? string.Empty : Convert.ToString(dpVeh_OwnershipType.SelectedItem.Text);
            dispatch.Veh_OwnerName = txtVeh_OwnerName.Text;
            dispatch.Veh_ContactNo = txtVeh_ContactNo.Text;
            //---------------------------------------------
            dispatch.Veh_OwnerAddress = txtVeh_OwnerAddress.Text;
            dispatch.Veh_FuelType = string.IsNullOrEmpty(dpVeh_FuelType.SelectedItem.Text.ToString()) ? 0 : Convert.ToInt32(dpVeh_FuelType.SelectedItem.Value);
            dispatch.BankId = string.IsNullOrEmpty(dpBank.Text.ToString()) ? 0 : Convert.ToInt32(dpBank.SelectedItem.Value);
            dispatch.BankAc = string.IsNullOrEmpty(txtBankAc.Text.ToString()) ? string.Empty : Convert.ToString(txtBankAc.Text);
            if (dpIsActive.SelectedItem.Value == "1")
            {
                dispatch.IsActive = true;
            }
            if (dpIsActive.SelectedItem.Value == "2")
            {
                dispatch.IsActive = false;
            }
            dispatch.CreatedBy = GlobalInfo.Userid;
            dispatch.Createddate = DateTime.Now.ToString("dd-MM-yyyy");

            if (dispatchdata.UpdateTransportInfo(dispatch))
            {
                lblHeaderTab.Text = "Add Transport Details";
                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Transport Updated  Successfully";
                ClearTextBox();
                bindTransportList();
                pnlError.Update();
                btnAddTransportInfo.Visible = true;
                btnupdateTransportdetail.Visible = false;
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



        public int DeleteTransportDetails(int TM_Id)
        {

            Dispatch dispatch = new Dispatch();
            DispatchData dispatchdata = new DispatchData();
            dispatch.TM_Id = string.IsNullOrEmpty(htransId.Value) ? 0 : Convert.ToInt32(htransId.Value);
            dispatch.VehicleBrand = 0;
            dispatch.Veh_Model = 0;
            dispatch.Veh_Year = string.Empty;
            //-------------------------------------
            dispatch.Veh_Type = string.Empty;
            dispatch.Veh_Reg = string.Empty;
            dispatch.Veh_ChassisNo = string.Empty;
            dispatch.Veh_EngineNo = string.Empty;
            //---------------------------------------
            dispatch.Veh_InsProvider = 0;

            dispatch.Veh_InsPolicyNo = string.Empty;
            dispatch.Veh_InsStart = string.Empty;
            //------------------------------------
            dispatch.Veh_InsLast = string.Empty;
            dispatch.Veh_OwnershipType = string.Empty;
            dispatch.Veh_OwnerName = string.Empty;
            dispatch.Veh_ContactNo = string.Empty;
            //---------------------------------------------
            dispatch.Veh_OwnerAddress = string.Empty;
            dispatch.Veh_FuelType = 0;
            dispatch.BankAc = string.Empty;
            dispatch.BankId = 0;
            int Result = 0;
            Result = dispatchdata.DeleteTransportDetails(dispatch);
            if (Result > 0)
            {

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Delete Updated  Successfully";
                ClearTextBox();
                GetTransportDetails();
                pnlError.Update();
                btnAddTransportInfo.Visible = true;
                btnupdateTransportdetail.Visible = false;
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
            return Result;
        }

        public void GetTransportDetails()
        {

            dispatchdata = new DispatchData();
            DataSet DS = new DataSet();
            DS = dispatchdata.GetTransportDetails();

            if (!Comman.Comman.IsDataSetEmpty(DS))
            {

                rpTransportList.DataSource = DS;
                rpTransportList.DataBind();
            }
        }
        protected void dpVehicleBrand_SelectedIndexChanged(object sender, EventArgs e)
        {

            DS = BindCommanData.BindCommanDropDwon("tr_model_Id", "tr_model_name as Name", "Tr_Model_Master", "IsActive=1 and tr_brand_Id =" + dpVehicleBrand.SelectedItem.Value.ToString());
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpVeh_Model.ClearSelection();
                dpVeh_Model.DataSource = DS;
                dpVeh_Model.DataBind();
                dpVeh_Model.Items.Insert(0, new ListItem("--Select Vehicle Model --", "0"));
                dpVeh_Model.Focus();

            }
        }
    }
}