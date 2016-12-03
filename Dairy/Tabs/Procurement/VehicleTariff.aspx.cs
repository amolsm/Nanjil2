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
using Model;

namespace Dairy.Tabs.Procurement
{
    public partial class VehicleTeriff : System.Web.UI.Page
    {
        DataSet DS = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindVehicleList();
                btnAddVeh.Visible = true;
                btnupdateVeh.Visible = false;
                BindDropDownList();
            }
        }


        public void BindDropDownList()
        {
            DS = BindCommanData.BindCommanDropDwon("id as VahicleID", "VehicleType as VehicleName", "Proc_VehicleType", "id is not null");
            dpVehicleType.DataSource = DS;
            dpVehicleType.DataBind();
            dpVehicleType.Items.Insert(0, new ListItem("--Select Vehicle Model--", "0"));
        }
        protected void btnAddVeh_Click(object sender, EventArgs e)
        {
            Model.Procurement p = new Model.Procurement();
            ProcurementData pd = new ProcurementData();
            p.VehicleID = 0;
            //p.SrNo = txtSrNo.Text;
            p.VehicleType = Convert.ToInt32(dpVehicleType.SelectedItem.Value);
            p.Bata = Convert.ToDouble(txtBata.Text);
            p.KMLow = Convert.ToDouble(txtKMLow.Text);
            p.KMHigh = Convert.ToDouble(txtKMHigh.Text);
          
            p.Amount = Convert.ToDouble(txtAmount.Text);
            //p.KMGreaterThan300 = Convert.ToDouble(txtKMGreater300.Text);
            p.Discription = txtDesc.Text;
            p.CreatedBy = App_code.GlobalInfo.Userid;
            p.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
            p.ModifiedBy = App_code.GlobalInfo.Userid;
            p.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");
            p.flag = "Insert";
            int Result = 0;
            Result = pd.InsertVehicleMaster(p);
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
            txtKMLow.Text = string.Empty;
            txtKMHigh.Text = string.Empty;
          txtAmount.Text = string.Empty;
            txtBata.Text = string.Empty;
          //  txtKMGreater300.Text = string.Empty;
    
           // txtSrNo.Text = string.Empty;
            dpVehicleType.ClearSelection();
            txtDesc.Text = string.Empty;
        }
        public void BindVehicleList()
        {

            ProcurementData pd = new ProcurementData();
            DataSet DS = new DataSet();
            StringBuilder sb = new StringBuilder();
            DS = pd.GetAllVehicleMasterDetails();
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                rpVehicleMaster.DataSource = DS;
                rpVehicleMaster.DataBind();
            }
        }

        protected void rpVehicleMaster_ItemCommand(object sender, RepeaterCommandEventArgs e)
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
                        GetRouteDetailsbyID(vehicleid);
                        btnAddVeh.Visible = false;
                        btnupdateVeh.Visible = true;
                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }
                case ("delete"):
                    {

                        hfrouteID.Value = vehicleid.ToString();
                        vehicleid = Convert.ToInt32(hfrouteID.Value);
                        //DeleteRoutebyrouteID(vehicleid);
                        BindVehicleList();
                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }


            }
        }


        public void GetRouteDetailsbyID(int vehicleid)
        {
            DataSet DS = new DataSet();
            ProcurementData pd = new ProcurementData();
            DS = pd.GetVehicleMasterDetailsbyID(vehicleid);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
              //  txtSrNo.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["SrNo"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["SrNo"].ToString();
                dpVehicleType.ClearSelection();
                if (dpVehicleType.Items.FindByValue(DS.Tables[0].Rows[0]["Vehicle"].ToString()) != null)
                {
                    dpVehicleType.Items.FindByValue(DS.Tables[0].Rows[0]["Vehicle"].ToString()).Selected = true;
                }
                txtBata.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Bata"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Bata"].ToString();
                txtKMLow.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["KMLow"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["KMLow"].ToString();
                txtKMHigh.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["KMHigh"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["KMHigh"].ToString();
                txtAmount.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Amount"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Amount"].ToString();
                //txt251To300.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["251To300"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["251To300"].ToString();
                //txtKMGreater300.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["KMGreaterThan300"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["KMGreaterThan300"].ToString();
                txtDesc.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Discription"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Discription"].ToString();
            }
        }
        //public void DeleteRoutebyrouteID(int routeID)
        //{

        //    Route route = new Route();
        //    RouteData routeDate = new RouteData();
        //    route.RouteID = string.IsNullOrEmpty(hfrouteID.Value) ? 0 : Convert.ToInt32(hfrouteID.Value);
        //    route.RouteCode = string.Empty;
        //    route.RouteName = string.Empty;
        //    route.ASOID = Convert.ToInt32(dpASOID.SelectedItem.Value);
        //    route.Category = Convert.ToInt32(Category.SelectedItem.Value);
        //    route.RouteDesc = string.Empty;
        //    route.CreatedBy = App_code.GlobalInfo.Userid;
        //    route.Discription = txtDesc.Text;
        //    route.IsActive = false;
        //    route.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
        //    route.ModifiedBy = App_code.GlobalInfo.Userid;
        //    route.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");
        //    route.flag = "Delete";
        //    int Result = 0;
        //    Result = routeDate.InsertMilkCollectionRoute(route);
        //    if (Result > 0)
        //    {

        //        divDanger.Visible = false;
        //        divwarning.Visible = false;
        //        divSusccess.Visible = true;
        //        lblSuccess.Text = "Delete Updated  Successfully";
        //        ClearTextBox();
        //        BindRouteList();
        //        pnlError.Update();
        //        btnAddRout.Visible = true;
        //        btnupdateroute.Visible = false;
        //        upMain.Update();
        //        uprouteList.Update();
        //    }
        //    else
        //    {
        //        divDanger.Visible = false;
        //        divwarning.Visible = true;
        //        divSusccess.Visible = false;
        //        lblwarning.Text = "Please Contact to Site Admin";
        //        pnlError.Update();

        //    }
        //}
        protected void btnupdateVeh_Click(object sender, EventArgs e)
        {
            Model.Procurement p = new Model.Procurement();
            ProcurementData pd = new ProcurementData();
            p.VehicleID = string.IsNullOrEmpty(hfrouteID.Value) ? 0 : Convert.ToInt32(hfrouteID.Value);
           // p.SrNo = txtSrNo.Text;
            p.VehicleType = Convert.ToInt16(dpVehicleType.SelectedItem.Value);
            p.Bata = Convert.ToDouble(txtBata.Text);
            p.KMLow = Convert.ToDouble(txtKMLow.Text);
            p.KMHigh = Convert.ToDouble(txtKMHigh.Text);
            //p.V201To250 = Convert.ToDouble(txt201To250.Text);
            //p.V251To300 = Convert.ToDouble(txt251To300.Text);
            //p.KMGreaterThan300 = Convert.ToDouble(txtKMGreater300.Text);
            p.Amount = Convert.ToDouble(txtAmount.Text);
            p.Discription = txtDesc.Text;
            p.CreatedBy = App_code.GlobalInfo.Userid;
            p.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
            p.ModifiedBy = App_code.GlobalInfo.Userid;
            p.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");
            p.flag = "Update";
            int Result = 0;
            Result = pd.InsertVehicleMaster(p);
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
                btnAddVeh.Visible = true;
                btnupdateVeh.Visible = false;
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

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Tabs/Procurement/VehicleTariff.aspx");
        }

    

        protected void txtKMHigh_TextChanged(object sender, EventArgs e)
        {
            ProcurementData pd = new ProcurementData();
            DataSet DS = new DataSet();
            DS = pd.GetAllVehicleMasterDetails();
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                foreach (DataRow row in DS.Tables[0].Rows)
                {
                    if (Convert.ToDecimal(row["KMLow"]).ToString("#.##") == txtKMLow.Text.ToString() && Convert.ToDecimal(row["KMHigh"]).ToString("#.##") == txtKMHigh.Text.ToString() && row["Vehicle"].ToString() == dpVehicleType.SelectedItem.Value)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Already exists')", true);
                        txtKMHigh.Text = string.Empty;
                    }
                }
            }
        }
    }
}