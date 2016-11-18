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
    public partial class JOBCard : System.Web.UI.Page
    {
        TransportData transportdata;
        Transports transport;
        DataSet DS;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                BindDropDwon();
                BindVehicleOperationInfo();
                btnAddJobCard.Visible = true;
                btnUpdateJobCard.Visible = false;
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
        }

        protected void btnClick_btnAddJobCard(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                transportdata = new TransportData();
                transport = new Transports();
                transport.ID = 0;
                transport.VOp = Convert.ToInt32(txtVOpId.Text);
                transport.Brake = txtBrake.Text;
                transport.Light = txtLight.Text;
                transport.TyreCon = txtTyreCondition.Text;
                transport.damage = txtDamages.Text;
                transport.other = txtOthers.Text;

                transport.oillevel = txtOilLevel.Text;
                transport.battery = txtBattery.Text;
                transport.crownjointsound = txtCrownnandJointSound.Text;
                transport.clutchcon = txtClutchCondition.Text;
                transport.stearingvobling = txtStearingVobling.Text;
                transport.suspension = txtSuspension.Text;
                transport.gearbox = txtGearBox.Text;
                transport.CreatedBy = GlobalInfo.Userid;
                transport.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
                transport.flag = "Insert";
                int Result = 0;
                Result = transportdata.AddVehicleJOBCardInfo(transport);
                if (Result > 0)
                {

                    divDanger.Visible = false;
                    divwarning.Visible = false;
                    divSusccess.Visible = true;
                    lblSuccess.Text = "Vehicle Operation  Added  Successfully";

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

        protected void btnClick_btnUpdateJobCard(object sender, EventArgs e)
        {
            transportdata = new TransportData();
            transport = new Transports();
            transport.ID = string.IsNullOrEmpty(hfJOBCardInfo.Value) ? 0 : Convert.ToInt32(hfJOBCardInfo.Value);
            transport.VOp = Convert.ToInt32(txtVOpId.Text);
            transport.Brake = txtBrake.Text;
            transport.Light = txtLight.Text;
            transport.TyreCon = txtTyreCondition.Text;
            transport.damage = txtDamages.Text;
            transport.other = txtOthers.Text;

            transport.oillevel = txtOilLevel.Text;
            transport.battery = txtBattery.Text;
            transport.crownjointsound = txtCrownnandJointSound.Text;
            transport.clutchcon = txtClutchCondition.Text;
            transport.stearingvobling = txtStearingVobling.Text;
            transport.suspension = txtSuspension.Text;
            transport.gearbox = txtGearBox.Text;
            transport.flag = "Update";
            int Result = 0;
            Result = transportdata.AddVehicleJOBCardInfo(transport);
            if (Result > 0)
            {

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Vehicle Operation  Updated  Successfully";

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
            Response.Redirect("~/Tabs/TransportModule/JOBCard.aspx");
        }

        public void ClearTextBox()
        {
            txtOutKM.Text = string.Empty;
            txtVOpId.Text = string.Empty;
            txtInKM.Text= string.Empty;
            txtInDate.Text=string.Empty;
            txtOutDate.Text= string.Empty;
            txtOutTime.Text= string.Empty;
            txtInTime.Text= string.Empty;
            txtSalesMan.Text= string.Empty;
            txtDriver.Text= string.Empty;
            txtRunKM.Text= string.Empty;
            txtDieselLtr.Text= string.Empty;
            txtAmt.Text = string.Empty;
            txtRouteId.Text = string.Empty;
            txtDamages.Text = string.Empty;
            txtBrake.Text = string.Empty;
            txtOilLevel.Text = string.Empty;
            txtBattery.Text = string.Empty;
            txtCrownnandJointSound.Text = string.Empty;
            txtClutchCondition.Text = string.Empty;
            txtStearingVobling.Text = string.Empty;
            txtSuspension.Text = string.Empty;
            txtGearBox.Text = string.Empty;
        }

        public void BindVehicleOperationInfo()
        {

            transportdata = new TransportData();
            DataSet DS = new DataSet();
            DS = transportdata.GetVehicleJOBCardInfo();

            if (!Comman.Comman.IsDataSetEmpty(DS))
            {

                rpJOBCardInfo.DataSource = DS;
                rpJOBCardInfo.DataBind();
            }
        }

        protected void rpJOBCardInfo_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {
        }

        protected void dpVehicleNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id;
            id=Convert.ToInt32(dpVehicleNo.SelectedItem.Value);
             GetJOBCardInfoByID(id);

        }

        public void GetJOBCardInfoByID(int ID)
        {

            transportdata = new TransportData();
            DS = transportdata.GetJOBCardInfoByID(ID);
            ClearTextBox();
            lblShowMessage.Text = string.Empty;
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
               
     
                txtOutKM.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["StartKm"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["StartKm"].ToString();
                txtInKM.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["EndKm"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["EndKm"].ToString();
                txtVOpId.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["VOp"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["VOp"].ToString();
                txtInDate.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["EndDate"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["EndDate"].ToString();
                txtOutDate.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["StartDate"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["StartDate"].ToString();
                txtOutTime.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["StartTime"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["StartTime"].ToString();
                txtInTime.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["EndTime"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["EndTime"].ToString();
                txtSalesMan.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Salesman"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Salesman"].ToString();
                txtDriver.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Driver"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Driver"].ToString();
                txtRunKM.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["TotalKm"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["TotalKm"].ToString();
                txtDieselLtr.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["FuelLtr"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["FuelLtr"].ToString();
                txtAmt.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["FuelAmount"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["FuelAmount"].ToString();
                txtRouteId.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["TransportRoute"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["TransportRoute"].ToString();

            }
            if (Comman.Comman.IsDataSetEmpty(DS))
            {
                lblShowMessage.Text = "Operation Not Completed yet ";
            }
        }
    }
}