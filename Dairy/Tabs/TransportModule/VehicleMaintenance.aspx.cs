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
    public partial class VehicleMaintenance : System.Web.UI.Page
    {
        TransportData transportdata;
        Transports transport;
        DataSet DS;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindVehicleOperationInfo();
                btnAddVehicleMaintenanceCost.Visible = true;
                btnUpdateMaintenanceCost.Visible = false;
                BindDropDwon();






            }

        }
        public void BindDropDwon()
        {

            DS = BindCommanData.BindCommanDropDwon("TM_Id", "VehicleNo", "tblTransportMaster", "IsActive=1");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpVehicleNo.DataSource = DS;
                dpVehicleNo.DataBind();
                dpVehicleNo.Items.Insert(0, new ListItem("--Select Vehicle Number--", "0"));
            }

            DS = BindCommanData.BindCommanDropDwon("ID ", "CONFIGVALUE  as Name  ", "CONFIGMASTER", "ISACTIVE=1 and CONFIGNAME='Transport' and CONFIGKEY='MaintenanceType'");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpMaintenanceType.DataSource = DS;
                dpMaintenanceType.DataTextField = "Name";
                dpMaintenanceType.DataValueField = "ID";
                dpMaintenanceType.DataBind();
                dpMaintenanceType.Items.Insert(0, new ListItem("--Select  Maintenance Type  --", "0"));
            }





        }
        protected void btnClick_btnAddVehicleMaintenanceCost(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {

                int checkvehicleno;
                checkvehicleno = Convert.ToInt32(dpVehicleNo.SelectedItem.Value);
                if (checkvehicleno != 0)
                {

                    transportdata = new TransportData();
                    transport = new Transports();
                    transport.ID = 0;
                    transport.TM_Id = Convert.ToInt32(dpVehicleNo.SelectedItem.Value);
                    transport.MaintenanceType = string.IsNullOrEmpty(dpMaintenanceType.Text.ToString()) ? 0 : Convert.ToInt32(dpMaintenanceType.SelectedItem.Value);
                    transport.M_Description = txtDescription.Text;
                    transport.DateGiven = string.IsNullOrEmpty(txtmaintenancegivendate.Text.ToString()) ? string.Empty : (Convert.ToDateTime(txtmaintenancegivendate.Text)).ToString("dd-MM-yyyy");

                    transport.datereceived = string.IsNullOrEmpty(txtmaintenancenextdate.Text.ToString()) ? string.Empty : (Convert.ToDateTime(txtmaintenancenextdate.Text)).ToString("dd-MM-yyyy");


                    transport.maintenanceamt = string.IsNullOrEmpty(txtMaintenanceAmt.Text.ToString()) ? 0 : Convert.ToDouble(txtMaintenanceAmt.Text);

                    transport.CreatedBy = GlobalInfo.Userid;
                    //if (dpIsActive.SelectedItem.Value == "1")
                    //{
                    transport.IsActive = true;
                    //}
                    //else if (dpIsActive.SelectedItem.Value == "2")
                    //{
                    //    transport.IsActive = false;
                    //}
                    //else if (dpIsActive.SelectedItem.Value == "0")
                    //{
                    //    transport.IsActive = true;
                    //}

                    transport.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
                    transport.ModifiedBy = GlobalInfo.Userid;
                    transport.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");
                    transport.flag = "Insert";
                    int Result = 0;

                    Result = transportdata.AddVehicleMaintenanceDetailsInfo(transport);
                    if (Result > 0)
                    {

                        divDanger.Visible = false;
                        divwarning.Visible = false;
                        divSusccess.Visible = true;
                        lblSuccess.Text = "Vehicle Maintenance Added  Successfully";

                        ClearTextBox();
                        BindVehicleOperationInfo();
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
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage",
      "alert('Please select Vehicle Number!');", true);
                }

            }
        }
        protected void btnClick_btnUpdateMaintenanceCost(object sender, EventArgs e)
        {

            if (Page.IsValid)
            {

                transportdata = new TransportData();
                transport = new Transports();
                transport.ID = string.IsNullOrEmpty(hfID.Value) ? 0 : Convert.ToInt32(hfID.Value);
                transport.TM_Id = Convert.ToInt32(dpVehicleNo.SelectedItem.Value);
                transport.MaintenanceType = string.IsNullOrEmpty(dpMaintenanceType.Text.ToString()) ? 0 : Convert.ToInt32(dpMaintenanceType.SelectedItem.Value);
                transport.M_Description = txtDescription.Text;
                transport.DateGiven = string.IsNullOrEmpty(txtmaintenancegivendate.Text.ToString()) ? string.Empty : (Convert.ToDateTime(txtmaintenancegivendate.Text)).ToString("dd-MM-yyyy");

                transport.datereceived = string.IsNullOrEmpty(txtmaintenancenextdate.Text.ToString()) ? string.Empty : (Convert.ToDateTime(txtmaintenancenextdate.Text)).ToString("dd-MM-yyyy");



                transport.maintenanceamt = string.IsNullOrEmpty(txtMaintenanceAmt.Text.ToString()) ? 0 : Convert.ToDouble(txtMaintenanceAmt.Text);
                transport.CreatedBy = GlobalInfo.Userid;
                //if (dpIsActive.SelectedItem.Value == "1")
                //{
                transport.IsActive = true;
                //}
                //else if (dpIsActive.SelectedItem.Value == "2")
                //{
                //    transport.IsActive = false;
                //}
                //else if (dpIsActive.SelectedItem.Value == "0")
                //{
                //    transport.IsActive = true;
                //}

                transport.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
                transport.ModifiedBy = GlobalInfo.Userid;
                transport.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");
                transport.flag = "Update";
                int Result = 0;
                Result = transportdata.AddVehicleMaintenanceDetailsInfo(transport);
                if (Result > 0)
                {

                    divDanger.Visible = false;
                    divwarning.Visible = false;
                    divSusccess.Visible = true;
                    lblSuccess.Text = "Vehicle Maintenance  Updated  Successfully";

                    ClearTextBox();
                    BindVehicleOperationInfo();
                    pnlError.Update();
                    upMain.Update();
                    uprouteList.Update();
                    btnUpdateMaintenanceCost.Visible = false;
                    btnAddVehicleMaintenanceCost.Visible = true;

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
            dpVehicleNo.ClearSelection();
            dpMaintenanceType.ClearSelection();

            txtMaintenanceAmt.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtmaintenancegivendate.Text = string.Empty;
            txtmaintenancenextdate.Text = string.Empty;



        }
        protected void rpRouteList_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {

            divDanger.Visible = false;
            divwarning.Visible = false;
            divSusccess.Visible = false;
            pnlError.Update();
            int VOp = 0;
            VOp = Convert.ToInt32(e.CommandArgument);
            switch (e.CommandName)
            {
                case ("Edit"):
                    {
                        lblHeaderTab.Text = "Edit Vehicle Maintenance ";
                        hfID.Value = VOp.ToString();
                        VOp = Convert.ToInt32(hfID.Value);
                        GetVehicleMaintenanceInfoByID(VOp);
                        btnAddVehicleMaintenanceCost.Visible = false;
                        btnUpdateMaintenanceCost.Visible = true;
                        BindVehicleOperationInfo();
                        upMain.Update();

                        uprouteList.Update();
                        break;
                    }
                case ("delete"):
                    {

                        hfID.Value = VOp.ToString();
                        VOp = Convert.ToInt32(hfID.Value);
                        DeleteMapbyID(VOp);
                        BindVehicleOperationInfo();
                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }


            }
        }
        public void GetVehicleMaintenanceInfoByID(int ID)
        {

            transportdata = new TransportData();
            DS = transportdata.GetVehicleMaintenanceInfoByID(ID);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {

                dpVehicleNo.ClearSelection();
                if (dpVehicleNo.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["TM_Id"]).ToString()) != null)
                {
                    dpVehicleNo.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["TM_Id"]).ToString()).Selected = true;
                }
                dpMaintenanceType.ClearSelection();
                if (dpMaintenanceType.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["MaintenanceType"]).ToString()) != null)
                {
                    dpMaintenanceType.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["MaintenanceType"]).ToString()).Selected = true;
                }

                //dpIsActive.ClearSelection();
                //if (DS.Tables[0].Rows[0]["IsActive"].ToString() == "True")
                //{
                //    dpIsActive.Items.FindByValue("1").Selected = true;
                //}
                //if (DS.Tables[0].Rows[0]["IsActive"].ToString() == "False")
                //{
                //    dpIsActive.Items.FindByValue("2").Selected = true;
                //}


                //txtBata.Text = string.IsNullOrEmpty((Convert.ToDecimal(DS.Tables[0].Rows[0]["Bata"]).ToString("#.##"))) ? string.Empty : (Convert.ToDecimal(DS.Tables[0].Rows[0]["Bata"]).ToString("#.##"));



                if (DS.Tables[0].Rows[0]["DateGiven"].ToString() == "")
                {
                    txtmaintenancegivendate.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["DateGiven"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["DateGiven"].ToString();
                }
                else
                {
                    string startdate = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["DateGiven"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["DateGiven"].ToString();
                    //sky
                    DateTime date2 = Convert.ToDateTime(startdate, System.Globalization.CultureInfo.GetCultureInfo("ur-PK").DateTimeFormat);
                    txtmaintenancegivendate.Text = (Convert.ToDateTime(date2).ToString("yyyy-MM-dd"));
                }

                if (DS.Tables[0].Rows[0]["Datereceived"].ToString() == "")
                {
                    txtmaintenancenextdate.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Datereceived"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Datereceived"].ToString();
                }
                else
                {
                    string startdate = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Datereceived"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Datereceived"].ToString();
                    //sky
                    DateTime date2 = Convert.ToDateTime(startdate, System.Globalization.CultureInfo.GetCultureInfo("ur-PK").DateTimeFormat);
                    txtmaintenancenextdate.Text = (Convert.ToDateTime(date2).ToString("yyyy-MM-dd"));
                }

                if (DS.Tables[0].Rows[0]["NextMaintainenceDate"].ToString() == "")
                {
                    txtmaintenancenextdate.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["NextMaintainenceDate"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["NextMaintainenceDate"].ToString();
                }
                else
                {
                    string startdate = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["NextMaintainenceDate"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["NextMaintainenceDate"].ToString();
                    //sky
                    DateTime date2 = Convert.ToDateTime(startdate, System.Globalization.CultureInfo.GetCultureInfo("ur-PK").DateTimeFormat);
                    txtmaintenancenextdate.Text = (Convert.ToDateTime(date2).ToString("yyyy-MM-dd"));
                }



                txtMaintenanceAmt.Text = string.IsNullOrEmpty(Convert.ToDouble(DS.Tables[0].Rows[0]["MaintanceCost"]).ToString("#.##")) ? string.Empty : (Convert.ToDouble(DS.Tables[0].Rows[0]["MaintanceCost"]).ToString("#.##"));
                txtDescription.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["M_Description"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["M_Description"].ToString();






            }
        }
        public void BindVehicleOperationInfo()
        {

            transportdata = new TransportData();
            DataSet DS = new DataSet();
            DS = transportdata.GetVehicleMaintenanceInfo();

            if (!Comman.Comman.IsDataSetEmpty(DS))
            {

                rpmaintenanceInfo.DataSource = DS;
                rpmaintenanceInfo.DataBind();
            }
        }
        public void DeleteMapbyID(int ID)
        {

            transportdata = new TransportData();
            transport = new Transports();
            transport.ID = Convert.ToInt32(ID);


            transport.TM_Id = 0;




            transport.TM_Id = Convert.ToInt32(dpVehicleNo.SelectedItem.Value);
            transport.MaintenanceType = Convert.ToInt32(dpMaintenanceType.SelectedItem.Value);
            transport.M_Description = txtDescription.Text;
            transport.DateGiven = (Convert.ToDateTime(txtmaintenancegivendate.Text)).ToString("dd-MM-yyyy");

            transport.datereceived = (Convert.ToDateTime(txtmaintenancenextdate.Text)).ToString("dd-MM-yyyy");


            transport.maintenanceamt = Convert.ToDouble(txtMaintenanceAmt.Text);

            transport.CreatedBy = GlobalInfo.Userid;
            //if (dpIsActive.SelectedItem.Value == "1")
            //{
            transport.IsActive = true;
            //}
            //else if (dpIsActive.SelectedItem.Text == "2")
            //{
            //    transport.IsActive = false;
            //}
            //DateTime time = DateTime.Parse(string.Format("{0}:{1}:{2} {3}", TimeSelector1.Hour, TimeSelector1.Minute, TimeSelector1.Second, TimeSelector1.AmPm));
            ////product.IsActive = true;
            //time.ToString();
            transport.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
            transport.ModifiedBy = GlobalInfo.Userid;
            transport.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");
            transport.flag = "Delete";
            int Result = 0;
            Result = transportdata.AddVehicleMaintenanceDetailsInfo(transport);
            if (Result > 0)
            {

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Vehicle Maintenance Deleted  Successfully";

                ClearTextBox();
                BindVehicleOperationInfo();
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
            Response.Redirect("~/Tabs/TransportModule/VehicleMaintenance.aspx");
        }
    }
}