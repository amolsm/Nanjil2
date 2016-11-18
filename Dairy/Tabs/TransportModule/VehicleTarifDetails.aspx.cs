using Bussiness;
using Dairy.App_code;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dairy.Tabs.TransportModule
{
    public partial class VehicleTarifDetails : System.Web.UI.Page
    {
        TransportData transportdata;
        Transports transport;
        DataSet DS;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindVehicleTariffInfo();
                btnAddVehicleTariff.Visible = true;
                btnupdateVehicletariff.Visible = false;
                BindDropDwon();
            }

        }
        public void BindDropDwon()
        {

            DS = BindCommanData.BindCommanDropDwon("tr_model_Id", "tr_model_name", "Tr_Model_Master", "IsActive=1");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpModelNo.DataSource = DS;
                dpModelNo.DataBind();
                dpModelNo.Items.Insert(0, new ListItem("--Select Vehicle Model--", "0"));
            }

            DS = BindCommanData.BindCommanDropDwon("ID ", "CONFIGVALUE  as Name  ", "CONFIGMASTER", "ISACTIVE=1 and CONFIGNAME='Transport' and CONFIGKEY='VehicleTariffOption'");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpSelectOption.DataSource = DS;
                dpSelectOption.DataBind();
                dpSelectOption.Items.Insert(0, new ListItem("--Select Option Type  --", "0"));
            }



        }
        protected void btnClick_btnAddVehicleTariff(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                // My credential check code

                transportdata = new TransportData();
                transport = new Transports();
                transport.V_TrfID = 0;
                transport.trModelID = Convert.ToInt32(dpModelNo.SelectedItem.Value); ;
                transport.troption = Convert.ToInt32(dpSelectOption.SelectedItem.Value);
                transport.tariffamt = Convert.ToDouble(txtTariffamt.Text);
                transport.CreatedBy = GlobalInfo.Userid;
                if (dpIsActive.SelectedItem.Value == "1")
                {
                    transport.IsActive = true;
                }
                else if (dpIsActive.SelectedItem.Text == "2")
                {
                    transport.IsActive = false;
                }

                transport.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
                transport.ModifiedBy = GlobalInfo.Userid;
                transport.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");
                transport.flag = "Insert";
                int Result = 0;
                Result = transportdata.AddVehicleTariffInfo(transport);
                if (Result > 0)
                {

                    divDanger.Visible = false;
                    divwarning.Visible = false;
                    divSusccess.Visible = true;
                    lblSuccess.Text = "Vehicle Tariff Add  Successfully";

                    ClearTextBox();
                    BindVehicleTariffInfo();
                    pnlError.Update();
                    upMain.Update();
                    uprouteList.Update();

                }
                else
                {
                    divDanger.Visible = false;
                    divwarning.Visible = true;
                    divSusccess.Visible = false;
                    lblwarning.Text = "Data Already Exists";
                    pnlError.Update();

                }



            }
        }
        protected void btnClick_btnupdateVehicletariff(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                // My credential check code


                transportdata = new TransportData();
                transport = new Transports();
                transport.V_TrfID = string.IsNullOrEmpty(hfvmapId.Value) ? 0 : Convert.ToInt32(hfvmapId.Value);
                transport.trModelID = Convert.ToInt32(dpModelNo.SelectedItem.Value); ;
                transport.troption = Convert.ToInt32(dpSelectOption.SelectedItem.Value);
                transport.tariffamt = Convert.ToDouble(txtTariffamt.Text);
                transport.CreatedBy = GlobalInfo.Userid;
                if (dpIsActive.SelectedItem.Value == "1")
                {
                    transport.IsActive = true;
                }
                else if (dpIsActive.SelectedItem.Text == "2")
                {
                    transport.IsActive = false;
                }
                transport.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
                transport.ModifiedBy = GlobalInfo.Userid;
                transport.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");
                transport.flag = "Update";
                int Result = 0;
                Result = transportdata.AddVehicleTariffInfo(transport);
                if (Result > 0)
                {

                    divDanger.Visible = false;
                    divwarning.Visible = false;
                    divSusccess.Visible = true;
                    lblSuccess.Text = "Vehicle Tariff Updated  Successfully";

                    ClearTextBox();
                    BindVehicleTariffInfo();
                    pnlError.Update();
                    upMain.Update();
                    uprouteList.Update();
                    btnAddVehicleTariff.Visible = true;
                    btnupdateVehicletariff.Visible = false;

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
        public void ClearTextBox()
        {
            dpModelNo.ClearSelection();
            txtTariffamt.Text = string.Empty;
            dpIsActive.ClearSelection();
            dpSelectOption.ClearSelection();

        }
        protected void rpRouteList_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {

            divDanger.Visible = false;
            divwarning.Visible = false;
            divSusccess.Visible = false;
            pnlError.Update();
            int V_TrfID = 0;
            V_TrfID = Convert.ToInt32(e.CommandArgument);
            switch (e.CommandName)
            {
                case ("Edit"):
                    {
                        lblHeaderTab.Text = "Edit Vehicle Tariff";
                        hfvmapId.Value = V_TrfID.ToString();
                        V_TrfID = Convert.ToInt32(hfvmapId.Value);
                        GetVehicleTariffInfoByID(V_TrfID);
                        btnAddVehicleTariff.Visible = false;
                        btnupdateVehicletariff.Visible = true;
                        BindVehicleTariffInfo();
                        upMain.Update();

                        uprouteList.Update();
                        break;
                    }
                case ("delete"):
                    {

                        hfvmapId.Value = V_TrfID.ToString();
                        V_TrfID = Convert.ToInt32(hfvmapId.Value);
                        DeleteTariffByID(V_TrfID);
                        BindVehicleTariffInfo();
                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }


            }
        }
        public void GetVehicleTariffInfoByID(int V_TrfID)
        {

            transportdata = new TransportData();
            DS = transportdata.GetVehicleTariffInfoByID(V_TrfID);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {

                dpModelNo.ClearSelection();
                if (dpModelNo.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["tr_model_Id"]).ToString()) != null)
                {
                    dpModelNo.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["tr_model_Id"]).ToString()).Selected = true;
                }
                dpSelectOption.ClearSelection();
                if (dpSelectOption.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["tr_option"]).ToString()) != null)
                {
                    dpSelectOption.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["tr_option"]).ToString()).Selected = true;
                }
                txtTariffamt.Text = string.IsNullOrEmpty((Convert.ToDecimal(DS.Tables[0].Rows[0]["Amount"]).ToString("#.##"))) ? string.Empty : (Convert.ToDecimal(DS.Tables[0].Rows[0]["Amount"]).ToString("#.##"));
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
        public void BindVehicleTariffInfo()
        {

            transportdata = new TransportData();
            DataSet DS = new DataSet();
            DS = transportdata.GetVehicleTariffInfo();

            if (!Comman.Comman.IsDataSetEmpty(DS))
            {

                rpvehicleroutemapInfo.DataSource = DS;
                rpvehicleroutemapInfo.DataBind();
            }
        }
        public void DeleteTariffByID(int V_TrfID)
        {

            transportdata = new TransportData();
            transport = new Transports();
            transport.V_TrfID = Convert.ToInt32(V_TrfID);
            transport.trVehicleNo = 0;
            transport.troption = 0;
            transport.tariffamt = 0;
            transport.CreatedBy = GlobalInfo.Userid;
            transport.IsActive = true;
            transport.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
            transport.ModifiedBy = GlobalInfo.Userid;
            transport.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");
            transport.flag = "Delete";
            int Result = 0;
            Result = transportdata.AddVehicleTariffInfo(transport);
            if (Result > 0)
            {

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Vehicle Tariff Deleted  Successfully";

                ClearTextBox();
                BindVehicleTariffInfo();
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
        protected void btnClick_btnAddNew(object sender, EventArgs e)
        {
            Response.Redirect("~/Tabs/TransportModule/VehicleTarifDetails.aspx");
        }
    }
}