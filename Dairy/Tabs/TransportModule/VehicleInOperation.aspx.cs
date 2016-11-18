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
    public partial class VehicleInOperation : System.Web.UI.Page
    {
        TransportData transportdata;
        Transports transport;
        DataSet DS;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDwon();
                btnAddInOperation.Visible = true;
                btnUpdateInOpration.Visible = false;
                BindVehicleOperationInfo();
                txtEndTime.Text = DateTime.Now.ToString("HH:mm");
                txtEndDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
               
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
            DS = BindCommanData.BindCommanDropDwon("ID ", "CONFIGVALUE  as Name  ", "CONFIGMASTER", "ISACTIVE=1 and CONFIGNAME='Transport' and CONFIGKEY='FuelType'");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpFuelType.DataSource = DS;
                dpFuelType.DataBind();
                dpFuelType.Items.Insert(0, new ListItem("--Select Fuel Type  --", "0"));
            }
            DS = BindCommanData.BindCommanDropDwon("Id", "fuelpumpname", "Tr_Fuelpumpmaster", "IsActive=1");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpRegisterpump.DataSource = DS;
                dpRegisterpump.DataTextField = "fuelpumpname";
                dpRegisterpump.DataValueField = "Id";
                dpRegisterpump.DataBind();
                dpRegisterpump.Items.Insert(0, new ListItem("--Select Dealer--", "0"));
            }

            DS = BindCommanData.BindCommanDropDwon("ID ", "CONFIGVALUE  as Name  ", "CONFIGMASTER", "ISACTIVE=1 and CONFIGNAME='Transport' and CONFIGKEY='VehicleType'");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpOperations.DataSource = DS;
                dpOperations.DataBind();
                dpOperations.Items.Insert(0, new ListItem("--Select Operations Type  --", "0"));
            }

        }

        protected void dpVehicleNo_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void btnClick_btnAddInOperation(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {

                transportdata = new TransportData();
                transport = new Transports();
                transport.VOp = string.IsNullOrEmpty(lblOperationId.Text) ? 0 : Convert.ToInt32(lblOperationId.Text);
                transport.EndDate = string.IsNullOrEmpty(txtEndDate.Text) ? string.Empty : (Convert.ToDateTime(txtEndDate.Text)).ToString("dd-MM-yyyy");
                transport.EndTime = string.IsNullOrEmpty(txtEndTime.Text) ? string.Empty : (Convert.ToDateTime(txtEndTime.Text)).ToString("HH:mm");
                transport.EndKm = string.IsNullOrEmpty(txtEndKm.Text) ? 0 : Convert.ToDecimal(txtEndKm.Text);
                transport.tollpaid = string.IsNullOrEmpty(txtTollPaid.Text) ? 0 : Convert.ToDouble(txtTollPaid.Text);
                transport.fuelamt = string.IsNullOrEmpty(txtFuelAmt.Text) ? 0 : Convert.ToDouble(txtFuelAmt.Text);
                transport.fuelBillNo = string.IsNullOrEmpty(txtBillNo.Text) ? 0 : Convert.ToInt32(txtBillNo.Text);
                transport.Registerpump = Convert.ToInt32(dpRegisterpump.SelectedItem.Value);
                transport.ModifiedBy = GlobalInfo.Userid;
                transport.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");
                transport.flag = "Update";
                int Result = 0;

                Result = transportdata.AddVehicleInOperationInfo(transport);
                if (Result > 0)
                {

                    divDanger.Visible = false;
                    divwarning.Visible = false;
                    divSusccess.Visible = true;
                    lblSuccess.Text = "Vehicle In Operation Added  Successfully";

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
        protected void btnClick_btnUpdateInOpration(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {

                transportdata = new TransportData();
                transport = new Transports();
                transport.VOp = string.IsNullOrEmpty(lblOperationId.Text) ? 0 : Convert.ToInt32(lblOperationId.Text);
                transport.EndDate = string.IsNullOrEmpty(txtEndDate.Text) ? string.Empty : (Convert.ToDateTime(txtEndDate.Text)).ToString("dd-MM-yyyy");
                transport.EndTime = string.IsNullOrEmpty(txtEndTime.Text) ? string.Empty : (Convert.ToDateTime(txtEndTime.Text)).ToString("HH:mm");
                transport.EndKm = string.IsNullOrEmpty(txtEndKm.Text) ? 0 : Convert.ToDecimal(txtEndKm.Text);
                transport.tollpaid = string.IsNullOrEmpty(txtTollPaid.Text) ? 0 : Convert.ToDouble(txtTollPaid.Text);
                transport.fuelamt = string.IsNullOrEmpty(txtFuelAmt.Text) ? 0 : Convert.ToDouble(txtFuelAmt.Text);
                transport.fuelBillNo = string.IsNullOrEmpty(txtBillNo.Text) ? 0 : Convert.ToInt32(txtBillNo.Text);
                transport.Registerpump = Convert.ToInt32(dpRegisterpump.SelectedItem.Value);
                transport.ModifiedBy = GlobalInfo.Userid;
                transport.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");
                transport.flag = "Update";
                int Result = 0;

                Result = transportdata.AddVehicleInOperationInfo(transport);
                if (Result > 0)
                {

                    divDanger.Visible = false;
                    divwarning.Visible = false;
                    divSusccess.Visible = true;
                    lblSuccess.Text = "Vehicle In Operation Updated  Successfully";

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
        protected void btnClick_btnAddNew(object sender, EventArgs e)
        {
            Response.Redirect("~/Tabs/TransportModule/VehicleInOperation.aspx");
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
                        lblHeaderTab.Text = "Edit Vehicle In Operation";
                        hfvoperationId.Value = VOp.ToString();
                        VOp = Convert.ToInt32(hfvoperationId.Value);
                        GetVehicleInOperationforbyId(VOp);
                        btnAddInOperation.Visible = false;
                        btnUpdateInOpration.Visible = true;
                        BindVehicleOperationInfo();
                        upMain.Update();


                        uprouteList.Update();
                        break;
                    }
                case ("delete"):
                    {

                        hfvoperationId.Value = VOp.ToString();
                        VOp = Convert.ToInt32(hfvoperationId.Value);

                        BindVehicleOperationInfo();
                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }


            }
        }
        public void GetVehicleInOperationforbyId(int VOp)
        {

            transportdata = new TransportData();
            DS = transportdata.GetVehicleInOperationforbyId(VOp);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                lblOperationId.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["VOp"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["VOp"].ToString();
                dpVehicleNo.ClearSelection();
                if (dpVehicleNo.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["TM_Id"]).ToString()) != null)
                {
                    dpVehicleNo.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["TM_Id"]).ToString()).Selected = true;
                }
               
                txtBata.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Bata"].ToString()) ? string.Empty : (Convert.ToDecimal(DS.Tables[0].Rows[0]["Bata"]).ToString("#.##"));
                txtSalesBata.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["SMBata"].ToString()) ? string.Empty : (Convert.ToDecimal(DS.Tables[0].Rows[0]["SMBata"]).ToString("#.##"));
                if (DS.Tables[0].Rows[0]["StartDate"].ToString() == "")
                {
                    txtStartDate.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["StartDate"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["StartDate"].ToString();
                }
                else
                {
                    string startdate = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["StartDate"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["StartDate"].ToString();
                    //sky
                    DateTime date2 = Convert.ToDateTime(startdate, System.Globalization.CultureInfo.GetCultureInfo("ur-PK").DateTimeFormat);
                    txtStartDate.Text = (Convert.ToDateTime(date2).ToString("yyyy-MM-dd"));
                }


                txtStartTime.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["StartTime"].ToString()) ? string.Empty : (Convert.ToDateTime(DS.Tables[0].Rows[0]["StartTime"]).ToString("hh:mm"));


                dpOperations.ClearSelection();
                if (dpOperations.Items.FindByValue(DS.Tables[0].Rows[0]["OperationType"].ToString()) != null)
                {
                    dpOperations.Items.FindByValue(DS.Tables[0].Rows[0]["OperationType"].ToString()).Selected = true;
                }
                txtStartKm.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["StartKm"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["StartKm"].ToString();
                dpRegisterpump.ClearSelection();
                if (dpRegisterpump.Items.FindByValue(DS.Tables[0].Rows[0]["DealerId"].ToString()) != null)
                {
                    dpRegisterpump.Items.FindByValue(DS.Tables[0].Rows[0]["DealerId"].ToString()).Selected = true;
                }
               
               
               
              
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ClearTextBox();
            int Vehicleid = Convert.ToInt32(dpVehicleNo.SelectedItem.Value);
            GetINOperationDetailsbyVechileId(Vehicleid);

        }
        public void GetINOperationDetailsbyVechileId(int Vehicleid)
        {
            transportdata = new TransportData();
            DS = transportdata.GetINOperationDetailsbyVechileId(Vehicleid);
            lblShowMessage.Text = string.Empty;
            lblOperationId.Text = string.Empty;

            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                lblOperationId.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["VOp"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["VOp"].ToString();
                txtBata.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Bata"].ToString()) ? string.Empty : (Convert.ToDecimal(DS.Tables[0].Rows[0]["Bata"]).ToString("#.##"));
                txtSalesBata.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["SMBata"].ToString()) ? string.Empty : (Convert.ToDecimal(DS.Tables[0].Rows[0]["SMBata"]).ToString("#.##"));

                if (DS.Tables[0].Rows[0]["StartDate"].ToString() == "")
                {
                    txtStartDate.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["StartDate"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["StartDate"].ToString();
                }
                else
                {
                    string startdate = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["StartDate"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["StartDate"].ToString();
                    //sky
                    DateTime date2 = Convert.ToDateTime(startdate, System.Globalization.CultureInfo.GetCultureInfo("ur-PK").DateTimeFormat);
                    txtStartDate.Text = (Convert.ToDateTime(date2).ToString("yyyy-MM-dd"));
                }


                txtStartTime.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["StartTime"].ToString()) ? string.Empty : (Convert.ToDateTime(DS.Tables[0].Rows[0]["StartTime"]).ToString("hh:mm"));


                dpOperations.ClearSelection();
                if (dpOperations.Items.FindByValue(DS.Tables[0].Rows[0]["OperationType"].ToString()) != null)
                {
                    dpOperations.Items.FindByValue(DS.Tables[0].Rows[0]["OperationType"].ToString()).Selected = true;
                }
                txtStartKm.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["StartKm"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["StartKm"].ToString();

             
              
               

            }
            if (Comman.Comman.IsDataSetEmpty(DS))
            {

                lblShowMessage.Text = "Vehicle is not in  Operation";

            }
        }

        public void ClearTextBox()
        {

            txtBata.Text = string.Empty;

            txtStartDate.Text = string.Empty;
            txtStartKm.Text = string.Empty;
            txtStartTime.Text = string.Empty;

            //dpDriver.ClearSelection();
            //dpDriver2.ClearSelection();
            dpOperations.ClearSelection();

            //dpSalesman.ClearSelection();
            //txtDispatchDate.Text = string.Empty;
            //txtDispatchTime.Text = string.Empty;
            txtSalesBata.Text = string.Empty;
            //dpSecondSalesmanId.ClearSelection();
            txtSalesBata.Text = string.Empty;




        }

        public void BindVehicleOperationInfo()
        {

            transportdata = new TransportData();
            DataSet DS = new DataSet();
            DS = transportdata.GetVehicleInOperationInfo();

            if (!Comman.Comman.IsDataSetEmpty(DS))
            {

                rpvehicleoperationInfo.DataSource = DS;
                rpvehicleoperationInfo.DataBind();
            }
        }
    }
}