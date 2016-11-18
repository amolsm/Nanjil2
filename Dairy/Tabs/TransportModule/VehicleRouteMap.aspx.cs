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
    public partial class VehicleRouteMap : System.Web.UI.Page
    {
        TransportData transportdata;
        Transports transport;
        DataSet DS;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindVehicleRoteMapInfo();
                btnAddVehicleroutemap.Visible = true;
                btnupdateVehicleroutemap.Visible = false;
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
            DS = BindCommanData.BindCommanDropDwon("RouteID", "RouteCode +' '+RouteName as Name  ", "RouteMaster", "IsArchive=1  Order by RouteCode");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dproute.DataSource = DS;
                dproute.DataBind();
                dproute.Items.Insert(0, new ListItem("--Select Route Name--", "0"));
            }

        }
        protected void btnClick_btnAddVehicleroutemap(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                // My credential check code

                transportdata = new TransportData();
                transport = new Transports();
                transport.trVRMID = 0;
                transport.trVehicleNo = Convert.ToInt32(dpVehicleNo.SelectedItem.Value); ;

                transport.trRouteID = Convert.ToInt32(dproute.SelectedItem.Value);
                transport.CreatedBy = GlobalInfo.Userid;
                if (dpIsActive.SelectedItem.Value == "1")
                {
                    transport.IsActive = true;
                }
                else if (dpIsActive.SelectedItem.Text == "2")
                {
                    transport.IsActive = false;
                }
                //product.IsActive = true;
                transport.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
                transport.ModifiedBy = GlobalInfo.Userid;
                transport.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");
                transport.flag = "Insert";
                int Result = 0;
                Result = transportdata.AddVehicleRouteMapInfo(transport);
                if (Result > 0)
                {

                    divDanger.Visible = false;
                    divwarning.Visible = false;
                    divSusccess.Visible = true;
                    lblSuccess.Text = "Vehicle Route Maped  Successfully";

                    ClearTextBox();
                    BindVehicleRoteMapInfo();
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
        protected void btnClick_btnupdateVehicleroutemap(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                // My credential check code


                transportdata = new TransportData();
                transport = new Transports();
                transport.trVRMID = string.IsNullOrEmpty(hfvmapId.Value) ? 0 : Convert.ToInt32(hfvmapId.Value);
                transport.trVehicleNo = Convert.ToInt32(dpVehicleNo.SelectedItem.Value); ;

                transport.trRouteID = Convert.ToInt32(dproute.SelectedItem.Value);
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
                Result = transportdata.AddVehicleRouteMapInfo(transport);
                if (Result > 0)
                {

                    divDanger.Visible = false;
                    divwarning.Visible = false;
                    divSusccess.Visible = true;
                    lblSuccess.Text = "Vehicle Route Map Updated  Successfully";

                    ClearTextBox();
                    BindVehicleRoteMapInfo();
                    pnlError.Update();
                    upMain.Update();
                    uprouteList.Update();
                    btnupdateVehicleroutemap.Visible = false;
                    btnAddVehicleroutemap.Visible = true;

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
            dproute.ClearSelection();
            dpIsActive.ClearSelection();

        }
        protected void rpRouteList_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {

            divDanger.Visible = false;
            divwarning.Visible = false;
            divSusccess.Visible = false;
            pnlError.Update();
            int trVRMID = 0;
            trVRMID = Convert.ToInt32(e.CommandArgument);
            switch (e.CommandName)
            {
                case ("Edit"):
                    {
                        lblHeaderTab.Text = "Edit Vehicle Route Map";
                        hfvmapId.Value = trVRMID.ToString();
                        trVRMID = Convert.ToInt32(hfvmapId.Value);
                        GetTransportModelInfoByID(trVRMID);
                        btnAddVehicleroutemap.Visible = false;
                        btnupdateVehicleroutemap.Visible = true;
                        BindVehicleRoteMapInfo();
                        upMain.Update();

                        uprouteList.Update();
                        break;
                    }
                case ("delete"):
                    {

                        hfvmapId.Value = trVRMID.ToString();
                        trVRMID = Convert.ToInt32(hfvmapId.Value);
                        DeleteMapbyID(trVRMID);
                        BindVehicleRoteMapInfo();
                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }


            }
        }
        public void GetTransportModelInfoByID(int trVRMID)
        {

            transportdata = new TransportData();
            DS = transportdata.GetVehicleRouteMapInfoByID(trVRMID);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {

                dpVehicleNo.ClearSelection();
                if (dpVehicleNo.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["TM_Id"]).ToString()) != null)
                {
                    dpVehicleNo.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["TM_Id"]).ToString()).Selected = true;
                }
                dproute.ClearSelection();
                if (dproute.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["RouteID"]).ToString()) != null)
                {
                    dproute.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["RouteID"]).ToString()).Selected = true;
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

            }
        }
        public void BindVehicleRoteMapInfo()
        {

            transportdata = new TransportData();
            DataSet DS = new DataSet();
            DS = transportdata.GetVehicleRouteMapInfo();

            if (!Comman.Comman.IsDataSetEmpty(DS))
            {

                rpvehicleroutemapInfo.DataSource = DS;
                rpvehicleroutemapInfo.DataBind();
            }
        }
        public void DeleteMapbyID(int trVRMID)
        {

            transportdata = new TransportData();
            transport = new Transports();
            transport.trVRMID = Convert.ToInt32(trVRMID);
            transport.trVehicleNo = 0;
            transport.trRouteID = 0;

            transport.CreatedBy = GlobalInfo.Userid;
            transport.IsActive = true;
            transport.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
            transport.ModifiedBy = GlobalInfo.Userid;
            transport.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");
            transport.flag = "Delete";
            int Result = 0;
            Result = transportdata.AddVehicleRouteMapInfo(transport);
            if (Result > 0)
            {

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Vehicle Route Map Deleted  Successfully";

                ClearTextBox();
                BindVehicleRoteMapInfo();
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
            Response.Redirect("~/Tabs/TransportModule/VehicleRouteMap.aspx");
        }
    }
}