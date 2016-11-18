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
    public partial class InsuranceMaintenance : System.Web.UI.Page
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

           
            DS = BindCommanData.BindCommanDropDwon("ID ", "CONFIGVALUE  as Name  ", "CONFIGMASTER", "ISACTIVE=1 and CONFIGNAME='Transport' and CONFIGKEY='Insuranceprovider'");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpVeh_InsProvider.DataSource = DS;
                dpVeh_InsProvider.DataBind();
                dpVeh_InsProvider.Items.Insert(0, new ListItem("--Select Insurance Provider  --", "0"));
            }
            DS = BindCommanData.BindCommanDropDwon("TM_Id ", "Veh_InsPolicyNo  as Name  ", "tblTransportMaster", "ISACTIVE=1");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpVeh_InsPolicyNo.DataSource = DS;
                dpVeh_InsPolicyNo.DataBind();
                dpVeh_InsPolicyNo.Items.Insert(0, new ListItem("--Select Insurance Policy Number  --", "0"));
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

                    transport.InsProvider = string.IsNullOrEmpty(dpVeh_InsProvider.Text.ToString()) ? 0 : Convert.ToInt32(dpVeh_InsProvider.SelectedItem.Value);
                    transport.InsPolicyNo = string.IsNullOrEmpty(dpVeh_InsPolicyNo.Text.ToString()) ? string.Empty : Convert.ToString(dpVeh_InsPolicyNo.SelectedItem.Text);
                    transport.InspaidDate = string.IsNullOrEmpty(txtInsuransepaidDate.Text.ToString()) ? string.Empty : (Convert.ToDateTime(txtInsuransepaidDate.Text)).ToString("dd-MM-yyyy");
                    transport.Insnextduedate = string.IsNullOrEmpty(txtnextinspaiddate.Text.ToString()) ? string.Empty : (Convert.ToDateTime(txtnextinspaiddate.Text)).ToString("dd-MM-yyyy");


                    transport.insuranceamt = string.IsNullOrEmpty(txtVehicleInsuraceAmt.Text.ToString()) ? 0 : Convert.ToDouble(txtVehicleInsuraceAmt.Text);



                    transport.CreatedBy = GlobalInfo.Userid;
                    if (dpIsActive.SelectedItem.Value == "1")
                    {
                        transport.IsActive = true;
                    }
                    else if (dpIsActive.SelectedItem.Value == "2")
                    {
                        transport.IsActive = false;
                    }
                    else if (dpIsActive.SelectedItem.Value == "0")
                    {
                        transport.IsActive = true;
                    }

                    transport.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
                    transport.ModifiedBy = GlobalInfo.Userid;
                    transport.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");
                    transport.flag = "Insert";
                    int Result = 0;

                    Result = transportdata.AddVehicleInsuanceDetailsInfo(transport);
                    if (Result > 0)
                    {

                        divDanger.Visible = false;
                        divwarning.Visible = false;
                        divSusccess.Visible = true;
                        lblSuccess.Text = "Vehicle Insurance Added  Successfully";

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
                        lblwarning.Text = "Data Already exists";
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


                transport.InsProvider = string.IsNullOrEmpty(dpVeh_InsProvider.Text.ToString()) ? 0 : Convert.ToInt32(dpVeh_InsProvider.SelectedItem.Value);
                transport.InsPolicyNo = string.IsNullOrEmpty(dpVeh_InsPolicyNo.Text.ToString()) ? string.Empty : Convert.ToString(dpVeh_InsPolicyNo.SelectedItem.Text);
                transport.InspaidDate = string.IsNullOrEmpty(txtInsuransepaidDate.Text.ToString()) ? string.Empty : (Convert.ToDateTime(txtInsuransepaidDate.Text)).ToString("dd-MM-yyyy");
                transport.Insnextduedate = string.IsNullOrEmpty(txtnextinspaiddate.Text.ToString()) ? string.Empty : (Convert.ToDateTime(txtnextinspaiddate.Text)).ToString("dd-MM-yyyy");



                transport.insuranceamt = string.IsNullOrEmpty(txtVehicleInsuraceAmt.Text.ToString()) ? 0 : Convert.ToDouble(txtVehicleInsuraceAmt.Text);


                transport.CreatedBy = GlobalInfo.Userid;
                if (dpIsActive.SelectedItem.Value == "1")
                {
                    transport.IsActive = true;
                }
                else if (dpIsActive.SelectedItem.Value == "2")
                {
                    transport.IsActive = false;
                }
                else if (dpIsActive.SelectedItem.Value == "0")
                {
                    transport.IsActive = true;
                }

                transport.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
                transport.ModifiedBy = GlobalInfo.Userid;
                transport.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");
                transport.flag = "Update";
                int Result = 0;
                Result = transportdata.AddVehicleInsuanceDetailsInfo(transport);
                if (Result > 0)
                {

                    divDanger.Visible = false;
                    divwarning.Visible = false;
                    divSusccess.Visible = true;
                    lblSuccess.Text = "Vehicle Insurance  Updated  Successfully";

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
          
            txtVehicleInsuraceAmt.Text = string.Empty;
        
         
          
        
            dpVeh_InsPolicyNo.ClearSelection();
            dpVeh_InsProvider.ClearSelection();
            txtnextinspaiddate.Text = string.Empty;
            txtInsuransepaidDate.Text = string.Empty;


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
                        lblHeaderTab.Text = "Edit Transport Maintenance ";
                        hfID.Value = VOp.ToString();
                        VOp = Convert.ToInt32(hfID.Value);
                        GetVehicleInsuranceInfoByID(VOp);
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
        public void GetVehicleInsuranceInfoByID(int ID)
        {

            transportdata = new TransportData();
            DS = transportdata.GetVehicleInsuranceInfoByID(ID);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {

                dpVehicleNo.ClearSelection();
                if (dpVehicleNo.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["TM_Id"]).ToString()) != null)
                {
                    dpVehicleNo.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["TM_Id"]).ToString()).Selected = true;
                }


                dpIsActive.ClearSelection();
                if (DS.Tables[0].Rows[0]["IsActive"].ToString() == "True")
                {
                    dpIsActive.Items.FindByValue("1").Selected = true;
                }
                if (DS.Tables[0].Rows[0]["IsActive"].ToString() == "False")
                {
                    dpIsActive.Items.FindByValue("2").Selected = true;
                }



                txtVehicleInsuraceAmt.Text = string.IsNullOrEmpty(Convert.ToDouble(DS.Tables[0].Rows[0]["InsuranceAmt"]).ToString("#.##")) ? string.Empty : (Convert.ToDouble(DS.Tables[0].Rows[0]["InsuranceAmt"]).ToString("#.##"));
                if (DS.Tables[0].Rows[0]["InspaidDate"].ToString() == "")
                {
                    txtInsuransepaidDate.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["InspaidDate"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["InspaidDate"].ToString();
                }
                else
                {
                    string startdate = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["InspaidDate"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["InspaidDate"].ToString();
                    //sky
                    DateTime date2 = Convert.ToDateTime(startdate, System.Globalization.CultureInfo.GetCultureInfo("ur-PK").DateTimeFormat);
                    txtInsuransepaidDate.Text = (Convert.ToDateTime(date2).ToString("yyyy-MM-dd"));
                }

                if (DS.Tables[0].Rows[0]["Insnextduedate"].ToString() == "")
                {
                    txtnextinspaiddate.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Insnextduedate"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Insnextduedate"].ToString();
                }
                else
                {
                    string startdate = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Insnextduedate"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Insnextduedate"].ToString();
                    //sky
                    DateTime date2 = Convert.ToDateTime(startdate, System.Globalization.CultureInfo.GetCultureInfo("ur-PK").DateTimeFormat);
                    txtnextinspaiddate.Text = (Convert.ToDateTime(date2).ToString("yyyy-MM-dd"));
                }

                dpVeh_InsProvider.ClearSelection();
                if (dpVeh_InsProvider.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["InsProvider"]).ToString()) != null)
                {
                    dpVeh_InsProvider.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["InsProvider"]).ToString()).Selected = true;
                }

                dpVeh_InsPolicyNo.ClearSelection();
                if (dpVeh_InsPolicyNo.Items.FindByText(Convert.ToString(DS.Tables[0].Rows[0]["InsPolicyNo"]).ToString()) != null)
                {
                    dpVeh_InsPolicyNo.Items.FindByText(Convert.ToString(DS.Tables[0].Rows[0]["InsPolicyNo"]).ToString()).Selected = true;
                }

            }
        }
        public void BindVehicleOperationInfo()
        {

            transportdata = new TransportData();
            DataSet DS = new DataSet();
            DS = transportdata.GetVehicleInsuranceInfo();

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
         
            transport.insuranceamt = Convert.ToDouble(txtVehicleInsuraceAmt.Text);
        


          

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
            Result = transportdata.AddVehicleInsuanceDetailsInfo(transport);
            if (Result > 0)
            {

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Vehicle Insurance Deleted  Successfully";

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


        protected void dpVehicleNo_IndexChanged(object sender, EventArgs e)
        {
            DS = new DataSet();

            DS = BindCommanData.BindTypeDropDwon("ID ", "CONFIGVALUE  as Name  ", "CONFIGMASTER", "tblTransportMaster", "CONFIGMASTER.ID = tblTransportMaster.Veh_InsProvider", "CONFIGMASTER.ISACTIVE=1 and CONFIGNAME='Transport' and CONFIGKEY='Insuranceprovider'and TM_Id=" + Convert.ToInt32(dpVehicleNo.SelectedItem.Value));

            dpVeh_InsProvider.DataSource = DS;
            dpVeh_InsProvider.DataBind();
            dpVeh_InsProvider.Items.Insert(0, new ListItem("--Select Insurance Provider  --", "0"));
            dpVeh_InsProvider.Focus();

            DS = new DataSet();
            DS = BindCommanData.BindCommanDropDwon("TM_Id ", "Veh_InsPolicyNo  as Name  ", "tblTransportMaster", "ISACTIVE=1 and TM_Id=" + Convert.ToInt32(dpVehicleNo.SelectedItem.Value));
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpVeh_InsPolicyNo.DataSource = DS;
                dpVeh_InsPolicyNo.DataBind();
                dpVeh_InsPolicyNo.Items.Insert(0, new ListItem("--Select Insurance Policy Number  --", "0"));
                dpVeh_InsPolicyNo.Focus();
            }

        }

        protected void btnClick_btnAddNew(object sender, EventArgs e)
        {
            Response.Redirect("~/Tabs/TransportModule/InsuranceMaintenance.aspx");
        }
    }
}