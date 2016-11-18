using Bussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using System.Data;
using Dairy.App_code;

namespace Dairy.Tabs.TransportModule
{
    public partial class FuelDetails : System.Web.UI.Page
    {
        TransportData transportdata;
        Transports transport;
        DataSet DS;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindVehicleOperationInfo();
                btnAddVehicleFuelDetails.Visible = true;
                btnupdateVehicleFuelDetails.Visible = false;
                BindDropDwon();

                //    DateTime dt = DateTime.Parse("12:35 PM");
                //    MKB.TimePicker.TimeSelector.AmPmSpec am_pm;
                //    if (dt.ToString("tt") == "AM")
                //    {
                //        am_pm = MKB.TimePicker.TimeSelector.AmPmSpec.AM;
                //    }
                //    else
                //    {
                //        am_pm = MKB.TimePicker.TimeSelector.AmPmSpec.PM;
                //    }
                //    TimeSelector1.SetTime(dt.Hour, dt.Minute, am_pm);
                txtTime.Text = DateTime.Now.ToString("hh:mm:ss tt");
                txtDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));


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
            DS = BindCommanData.BindCommanDropDwon("Id", "fuelpumpname", "Tr_Fuelpumpmaster", "IsActive=1");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpRegisterpump.DataSource = DS;
                dpRegisterpump.DataTextField = "fuelpumpname";
                dpRegisterpump.DataValueField = "Id";
                dpRegisterpump.DataBind();
                dpRegisterpump.Items.Insert(0, new ListItem("Non Register Pump", "0"));
            }
            DS = BindCommanData.BindCommanDropDwon("ID ", "CONFIGVALUE  as Name  ", "CONFIGMASTER", "ISACTIVE=1 and CONFIGNAME='Transport' and CONFIGKEY='FuelUnitType'");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpUnitType.DataSource = DS;
                dpUnitType.DataTextField = "Name";
                dpUnitType.DataValueField = "ID";
                dpUnitType.DataBind();
                dpUnitType.Items.Insert(0, new ListItem("--Select  UnitType  --", "0"));
            }

            DS = BindCommanData.BindCommanDropDwon("ID ", "CONFIGVALUE  as Name  ", "CONFIGMASTER", "ISACTIVE=1 and CONFIGNAME='Transport' and CONFIGKEY='FuelType'");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpFuelType.DataSource = DS;
                dpFuelType.DataBind();
                dpFuelType.Items.Insert(0, new ListItem("--Select Fuel Type  --", "0"));
            }


        }
        protected void btnClick_btnAddVehicleFuelDetails(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {

                transportdata = new TransportData();
                transport = new Transports();
                transport.Tr_FuelID = 0;
                transport.TM_Id = Convert.ToInt32(dpVehicleNo.SelectedItem.Value);

                transport.FuelRefielDate = (Convert.ToDateTime(txtDate.Text)).ToString("dd-MM-yyyy");
                //txtTime.Text = DateTime.Now.ToString("hh:mm");
                transport.Time = txtTime.Text;



                transport.FuelType = Convert.ToInt32(dpFuelType.SelectedItem.Value);
                transport.FuelQty = Convert.ToDouble(txtQty.Text);


                transport.UnitType = Convert.ToInt32(dpUnitType.SelectedItem.Value);
                transport.Registerpump = Convert.ToInt32(dpRegisterpump.SelectedItem.Value);
                transport.NonRegisterpump = txtnonregisteredpump.Text;
                transport.fuelcostprice = Convert.ToDecimal(txtPrice.Text);
                transport.amount = Convert.ToDouble(txtAmt.Text);
                transport.receiptno = txtReceiptNo.Text;
                transport.CreatedBy = GlobalInfo.Userid;
                //if (dpIsActive.SelectedItem.Value == "1")
                //{
                //    transport.IsActive = true;
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
                transport.flag = "Insert";
                int Result = 0;

                Result = transportdata.AddVehicleFuelDetailsInfo(transport);
                if (Result > 0)
                {

                    divDanger.Visible = false;
                    divwarning.Visible = false;
                    divSusccess.Visible = true;
                    lblSuccess.Text = "Vehicle Fuel Details Added  Successfully";

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
        protected void btnClick_btnupdateVehicleFuelDetails(object sender, EventArgs e)
        {

            if (Page.IsValid)
            {
                transportdata = new TransportData();
                transport = new Transports();
                transport.Tr_FuelID = string.IsNullOrEmpty(hfvmapId.Value) ? 0 : Convert.ToInt32(hfvmapId.Value);

                transport.TM_Id = Convert.ToInt32(dpVehicleNo.SelectedItem.Value);

                transport.FuelRefielDate = (Convert.ToDateTime(txtDate.Text)).ToString("dd-MM-yyyy");
                //txtTime.Text = DateTime.Now.ToString("hh:mm");
                transport.Time = txtTime.Text;


                transport.FuelType = Convert.ToInt32(dpFuelType.SelectedItem.Value);


                transport.FuelQty = Convert.ToDouble(txtQty.Text);

                transport.UnitType = Convert.ToInt32(dpUnitType.SelectedItem.Value);

                transport.Registerpump = Convert.ToInt32(dpRegisterpump.SelectedItem.Value);
                transport.NonRegisterpump = txtnonregisteredpump.Text;
                transport.fuelcostprice = Convert.ToDecimal(txtPrice.Text);
                transport.amount = Convert.ToDouble(txtAmt.Text);
                transport.receiptno = txtReceiptNo.Text;
                transport.CreatedBy = GlobalInfo.Userid;
                //if (dpIsActive.SelectedItem.Value == "1")
                //{
                //    transport.IsActive = true;
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
                transport.flag = "Update";
                int Result = 0;
                Result = transportdata.AddVehicleFuelDetailsInfo(transport);
                if (Result > 0)
                {

                    divDanger.Visible = false;
                    divwarning.Visible = false;
                    divSusccess.Visible = true;
                    lblSuccess.Text = "Vehicle Fuel Details Updated  Successfully";

                    ClearTextBox();
                    BindVehicleOperationInfo();
                    pnlError.Update();
                    upMain.Update();
                    uprouteList.Update();
                    btnupdateVehicleFuelDetails.Visible = false;
                    btnAddVehicleFuelDetails.Visible = true;

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
            dpRegisterpump.ClearSelection();
            txtPrice.Text = string.Empty;
            dpUnitType.ClearSelection();
            dpFuelType.ClearSelection();
            txtQty.Text = string.Empty;
            txtDate.Text = string.Empty;
            txtReceiptNo.Text = string.Empty;
            txtnonregisteredpump.Text = string.Empty;
            txtTime.Text = string.Empty;
            txtAmt.Text = string.Empty;


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
                        lblHeaderTab.Text = "Edit Fuel Details";
                        hfvmapId.Value = VOp.ToString();
                        VOp = Convert.ToInt32(hfvmapId.Value);
                        GetTransportOperationInfoByID(VOp);
                        btnAddVehicleFuelDetails.Visible = false;
                        btnupdateVehicleFuelDetails.Visible = true;
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
            DS = transportdata.GetVehicleFuelDetailsInfoByID(Tr_FuelID);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {

                dpVehicleNo.ClearSelection();
                if (dpVehicleNo.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["TM_Id"]).ToString()) != null)
                {
                    dpVehicleNo.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["TM_Id"]).ToString()).Selected = true;
                }
                dpRegisterpump.ClearSelection();
                if (dpRegisterpump.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["RegisterdPump"]).ToString()) != null)
                {
                    dpRegisterpump.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["RegisterdPump"]).ToString()).Selected = true;
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

                if (DS.Tables[0].Rows[0]["FuelRefielDate"].ToString() == "")
                {
                    txtDate.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["FuelRefielDate"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["FuelRefielDate"].ToString();
                }
                else
                {
                    string startdate = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["FuelRefielDate"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["FuelRefielDate"].ToString();
                    //sky
                    DateTime date2 = Convert.ToDateTime(startdate, System.Globalization.CultureInfo.GetCultureInfo("ur-PK").DateTimeFormat);
                    txtDate.Text = (Convert.ToDateTime(date2).ToString("yyyy-MM-dd"));
                }

                txtTime.Text = string.IsNullOrEmpty((Convert.ToDateTime(DS.Tables[0].Rows[0]["FuelRefielTime"]).ToString("hh:mm"))) ? string.Empty : (Convert.ToDateTime(DS.Tables[0].Rows[0]["FuelRefielTime"]).ToString("hh:mm"));

                dpUnitType.ClearSelection();
                if (dpUnitType.Items.FindByValue(DS.Tables[0].Rows[0]["UnitType"].ToString()) != null)
                {
                    dpUnitType.Items.FindByValue(DS.Tables[0].Rows[0]["UnitType"].ToString()).Selected = true;
                }
                dpFuelType.ClearSelection();
                if (dpFuelType.Items.FindByValue(DS.Tables[0].Rows[0]["FuelType"].ToString()) != null)
                {
                    dpFuelType.Items.FindByValue(DS.Tables[0].Rows[0]["FuelType"].ToString()).Selected = true;
                }
                txtAmt.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Amount"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Amount"].ToString();
                txtQty.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["FuelQty"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["FuelQty"].ToString();
                txtReceiptNo.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["ReceiptNo"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["ReceiptNo"].ToString();
                txtnonregisteredpump.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Nonregisterpump"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Nonregisterpump"].ToString();
                txtPrice.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["FuelCostprice"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["FuelCostprice"].ToString();

            }
        }
        public void BindVehicleOperationInfo()
        {

            transportdata = new TransportData();
            DataSet DS = new DataSet();
            DS = transportdata.GetVehicleFuelDetailsInfo();

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
            transport.Tr_FuelID = Convert.ToInt32(Tr_FuelID);


            transport.TM_Id = 0;

            transport.FuelRefielDate = "";
            txtTime.Text = "";
            transport.Time = txtTime.Text;


            transport.FuelType = Convert.ToInt32(dpFuelType.SelectedItem.Value);




            transport.UnitType = Convert.ToInt32(dpUnitType.SelectedItem.Value);

            transport.NonRegisterpump = txtnonregisteredpump.Text;
            transport.amount = Convert.ToDouble(txtAmt.Text);
            transport.receiptno = txtReceiptNo.Text;
            transport.CreatedBy = GlobalInfo.Userid;
            //if (dpIsActive.SelectedItem.Value == "1")
            //{
            //    transport.IsActive = true;
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
            Result = transportdata.AddVehicleFuelDetailsInfo(transport);
            if (Result > 0)
            {

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Vehicle Fuel Details  Deleted  Successfully";

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

            DS = BindCommanData.BindTypeDropDwon("ID ", "CONFIGVALUE  as Name  ", "CONFIGMASTER", "tblTransportMaster", "CONFIGMASTER.ID = tblTransportMaster.Veh_FuelType", "CONFIGMASTER.ISACTIVE=1 and CONFIGNAME='Transport' and CONFIGKEY='FuelType'and TM_Id=" + Convert.ToInt32(dpVehicleNo.SelectedItem.Value));

            dpFuelType.DataSource = DS;
            dpFuelType.DataBind();
            dpFuelType.Items.Insert(0, new ListItem("--Select Fuel Type  --", "0"));
            dpFuelType.Focus();
        }


        protected void btnClick_btnAddNew(object sender, EventArgs e)
        {
            Response.Redirect("~/Tabs/TransportModule/FuelDetails.aspx");
        }
    }
}