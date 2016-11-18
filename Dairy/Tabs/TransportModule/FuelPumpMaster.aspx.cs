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
    public partial class FuelPumpMaster : System.Web.UI.Page
    {
        TransportData transportdata;
        Transports transport;
        DataSet DS;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindVehicleOperationInfo();
                btnAddFuelPumpDetails.Visible = true;
                btnupdateFuelPumpDetails.Visible = false;
                BindDropDwon();

             
             


            }

        }
        public void BindDropDwon()
        {

            DS = BindCommanData.BindCommanDropDwon("RouteID", "RouteCode +' '+RouteName as Name  ", "RouteMaster", "IsArchive=1  Order by RouteCode");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dproute.DataSource = DS;
                dproute.DataBind();
                dproute.Items.Insert(0, new ListItem("--Select Route Name--", "0"));
            }

            DS = BindCommanData.BindCommanDropDwon("ID ", "CONFIGVALUE  as Name  ", "CONFIGMASTER", "ISACTIVE=1 and CONFIGNAME='Transport' and CONFIGKEY='FuelCompanyName'");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpfuelcompany.DataSource = DS;
                dpfuelcompany.DataBind();
                dpfuelcompany.Items.Insert(0, new ListItem("--Select fuel company  --", "0"));
            }
        }
        protected void btnClick_btnAddFuelPumpDetails(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {

                transportdata = new TransportData();
                transport = new Transports();
                transport.ID = 0;
                transport.fuelpumpname = txtfuelpumpname.Text;

                transport.pumpaddress = txtpumpaddress.Text;

                transport.RouteID = Convert.ToInt32(dproute.SelectedItem.Value);
                transport.fuelcompanyId = Convert.ToInt32(dpfuelcompany.SelectedItem.Value);

                transport.contractstartdate = string.IsNullOrEmpty(txtcontractstartdate.Text) ? string.Empty : (Convert.ToDateTime(txtcontractstartdate.Text)).ToString("dd-MM-yyyy");
                transport.contractenddate = string.IsNullOrEmpty(txtcontractenddate.Text) ? string.Empty : (Convert.ToDateTime(txtcontractenddate.Text)).ToString("dd-MM-yyyy");




                transport.NonRegisterpump = txtregistrationno.Text;
                transport.contractamt = string.IsNullOrEmpty(txtcontractamt.Text) ? 0 : Convert.ToDouble(txtcontractamt.Text);

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

                Result = transportdata.AddFuelPumpMasterInfo(transport);
                if (Result > 0)
                {

                    divDanger.Visible = false;
                    divwarning.Visible = false;
                    divSusccess.Visible = true;
                    lblSuccess.Text = " Fuel Dealer Added  Successfully";

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

        }
        protected void btnClick_btnupdateFuelPumpDetails(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {

                transportdata = new TransportData();
                transport = new Transports();
                transport.ID = string.IsNullOrEmpty(hfvmapId.Value) ? 0 : Convert.ToInt32(hfvmapId.Value);

                transport.fuelpumpname = txtfuelpumpname.Text;

                transport.pumpaddress = txtpumpaddress.Text;

                transport.RouteID = Convert.ToInt32(dproute.SelectedItem.Value);
                transport.fuelcompanyId = Convert.ToInt32(dpfuelcompany.SelectedItem.Value);

                transport.contractstartdate = string.IsNullOrEmpty(txtcontractstartdate.Text) ? string.Empty : (Convert.ToDateTime(txtcontractstartdate.Text)).ToString("dd-MM-yyyy");
                transport.contractenddate = string.IsNullOrEmpty(txtcontractenddate.Text) ? string.Empty : (Convert.ToDateTime(txtcontractenddate.Text)).ToString("dd-MM-yyyy");




                transport.NonRegisterpump = txtregistrationno.Text;
                transport.contractamt = string.IsNullOrEmpty(txtcontractamt.Text) ? 0 : Convert.ToDouble(txtcontractamt.Text);

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
                Result = transportdata.AddFuelPumpMasterInfo(transport);
                if (Result > 0)
                {

                    divDanger.Visible = false;
                    divwarning.Visible = false;
                    divSusccess.Visible = true;
                    lblSuccess.Text = "Fuel Dealer  Updated  Successfully";

                    ClearTextBox();
                    BindVehicleOperationInfo();
                    pnlError.Update();
                    upMain.Update();
                    uprouteList.Update();
                    btnupdateFuelPumpDetails.Visible = false;
                    btnAddFuelPumpDetails.Visible = true;

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
            
            dpIsActive.ClearSelection();
          
            txtcontractamt.Text = string.Empty;
            txtcontractenddate.Text = string.Empty;
            txtcontractstartdate.Text = string.Empty;
            txtfuelpumpname.Text = string.Empty;
            txtpumpaddress.Text = string.Empty;
            txtregistrationno.Text = string.Empty;
            dproute.ClearSelection();
            dpfuelcompany.ClearSelection();


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
                        lblHeaderTab.Text = "Edit Fuel Dealer Info";
                        hfvmapId.Value = VOp.ToString();
                        VOp = Convert.ToInt32(hfvmapId.Value);
                        GetTransportOperationInfoByID(VOp);
                        btnAddFuelPumpDetails.Visible = false;
                        btnupdateFuelPumpDetails.Visible = true;
                        BindVehicleOperationInfo();
                        upMain.Update();

                        uprouteList.Update();
                        break;
                    }
                case ("delete"):
                    {

                        hfvmapId.Value = VOp.ToString();
                        VOp = Convert.ToInt32(hfvmapId.Value);
                        DeleteMapbyID(VOp);
                        BindVehicleOperationInfo();
                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }


            }
        }
        public void GetTransportOperationInfoByID(int Tr_FuelID)
        {

            transportdata = new TransportData();
            DS = transportdata.GetFuelPumpDetailsInfoByID(Tr_FuelID);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {

             

                dpIsActive.ClearSelection();
                if (DS.Tables[0].Rows[0]["IsActive"].ToString() == "True")
                {
                    dpIsActive.Items.FindByValue("1").Selected = true;
                }
                if (DS.Tables[0].Rows[0]["IsActive"].ToString() == "False")
                {
                    dpIsActive.Items.FindByValue("2").Selected = true;
                }
                

                //txtBata.Text = string.IsNullOrEmpty((Convert.ToDecimal(DS.Tables[0].Rows[0]["Bata"]).ToString("#.##"))) ? string.Empty : (Convert.ToDecimal(DS.Tables[0].Rows[0]["Bata"]).ToString("#.##"));

                if (DS.Tables[0].Rows[0]["contractstartdate"].ToString() == "")
                {
                    txtcontractstartdate.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["contractstartdate"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["contractstartdate"].ToString();
                }
                else
                {
                    string startdate = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["contractstartdate"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["contractstartdate"].ToString();
                    //sky
                    DateTime date2 = Convert.ToDateTime(startdate, System.Globalization.CultureInfo.GetCultureInfo("ur-PK").DateTimeFormat);
                    txtcontractstartdate.Text = (Convert.ToDateTime(date2).ToString("yyyy-MM-dd"));
                }
                if (DS.Tables[0].Rows[0]["contractenddate"].ToString() == "")
                {
                    txtcontractenddate.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["contractenddate"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["contractenddate"].ToString();
                }
                else
                {
                    string startdate = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["contractenddate"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["contractenddate"].ToString();
                    //sky
                    DateTime date2 = Convert.ToDateTime(startdate, System.Globalization.CultureInfo.GetCultureInfo("ur-PK").DateTimeFormat);
                    txtcontractenddate.Text = (Convert.ToDateTime(date2).ToString("yyyy-MM-dd"));
                }


                dproute.ClearSelection();
                if (dproute.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["routeId"]).ToString()) != null)
                {
                    dproute.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["routeId"]).ToString()).Selected = true;
                }
                dpfuelcompany.ClearSelection();
                if (dpfuelcompany.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["FuelCompanyId"]).ToString()) != null)
                {
                    dpfuelcompany.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["FuelCompanyId"]).ToString()).Selected = true;
                }
                txtfuelpumpname.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["fuelpumpname"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["fuelpumpname"].ToString();
                txtpumpaddress.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["pumpaddress"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["pumpaddress"].ToString();
                txtregistrationno.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["registrationno"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["registrationno"].ToString();
                txtcontractamt.Text = string.IsNullOrEmpty((Convert.ToDecimal(DS.Tables[0].Rows[0]["contractamt"]).ToString("#.##"))) ? string.Empty : (Convert.ToDecimal(DS.Tables[0].Rows[0]["contractamt"]).ToString("#.##"));
               

            }
        }
        public void BindVehicleOperationInfo()
        {

            transportdata = new TransportData();
            DataSet DS = new DataSet();
            DS = transportdata.GetFuelPumpDetailsInfo();

            if (!Comman.Comman.IsDataSetEmpty(DS))
            {

                rpvehiclefueldetailsInfo.DataSource = DS;
                rpvehiclefueldetailsInfo.DataBind();
            }
        }
        public void DeleteMapbyID(int Tr_FuelID)
        {

            transportdata = new TransportData();
            transport = new Transports();
            transport.ID = Convert.ToInt32(Tr_FuelID);


            transport.fuelpumpname = txtfuelpumpname.Text;

            transport.pumpaddress = txtpumpaddress.Text;

            transport.RouteID = 0;

            transport.fuelcompanyId = 0;
            transport.contractstartdate = "";
            transport.contractenddate = "";




            transport.NonRegisterpump = txtregistrationno.Text;
            transport.contractamt = Convert.ToDouble(txtcontractamt.Text);

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
            transport.flag = "Delete";
            int Result = 0;
            Result = transportdata.AddFuelPumpMasterInfo(transport);
            if (Result > 0)
            {

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Fuel Dealer   Deleted  Successfully";

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
            Response.Redirect("~/Tabs/TransportModule/FuelPumpMaster.aspx");
        }
    }
}