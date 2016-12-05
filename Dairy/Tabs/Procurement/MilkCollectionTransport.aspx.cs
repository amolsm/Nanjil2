using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using Bussiness;

namespace Dairy.Tabs.Procurement
{
    public partial class MilkCollectionTransport : System.Web.UI.Page
    {
        DataSet DS = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                BindMilkCollectionList();
                BindDropDown();
                btnAddMilkTransport.Visible = true;
                btnupdateMilkTransport.Visible = false;
                txtDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }

        protected void BindDropDown()
        {
            RouteData routeData = new RouteData();
            DS = BindCommanData.BindCommanDropDwon("RouteID ", "RouteCode +' '+RouteName as Name  ", "Proc_MilkCollectionRoute", "IsActive=1 ");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpRoute.DataSource = DS;
                dpRoute.DataBind();
                dpRoute.Items.Insert(0, new ListItem("--Select Route  --", "0"));
            }
            DS = BindCommanData.BindCommanDropDwon("VehicleMasterID ", "VehicleNo", "Proc_VehicleMaster", "IsActive=1 ");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpVehicleNo.DataSource = DS;
                dpVehicleNo.DataBind();
                dpVehicleNo.Items.Insert(0, new ListItem("--Select Vehicle No.  --", "0"));
            }

        }
        public void BindMilkCollectionList()
        {

            ProcurementData pd = new ProcurementData();
            DataSet DS = new DataSet();
            StringBuilder sb = new StringBuilder();
            DS = pd.GetAllMilkCollectionTransportDetails();
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                rpMilkCollectionList.DataSource = DS;
                rpMilkCollectionList.DataBind();
            }
        }

        protected void rpMilkCollectionList_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {

            divDanger.Visible = false;
            divwarning.Visible = false;
            divSusccess.Visible = false;
            pnlError.Update();
            int MilkCollectionid = 0;
            MilkCollectionid = Convert.ToInt32(e.CommandArgument);
            switch (e.CommandName)
            {
                case ("Edit"):
                    {
                        //lbltital.Text = "Edit Route";
                        hfMilkCollectionID.Value = MilkCollectionid.ToString();
                        MilkCollectionid = Convert.ToInt32(hfMilkCollectionID.Value);
                        BindMilkCollectionList();
                        GetMilkCollectionTransportDetailsbyID(MilkCollectionid);
                        btnAddMilkTransport.Visible = false;
                        btnupdateMilkTransport.Visible = true;
                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }
                case ("delete"):
                    {

                        hfMilkCollectionID.Value = MilkCollectionid.ToString();
                        MilkCollectionid = Convert.ToInt32(hfMilkCollectionID.Value);
                        DeleteMilkCollectionTransportbyID(MilkCollectionid);
                        BindMilkCollectionList();
                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }


            }
        }

        protected void btnAddMilkCollection_Click(object sender, EventArgs e)
        {
            Model.Procurement p = new Model.Procurement();
            ProcurementData pd = new ProcurementData();
            p.MilkCollectionTransportID = 0;
            p.Date = Convert.ToDateTime(txtDate.Text);
            p.VehicleNo = dpVehicleNo.SelectedItem.Text;
            p.RouteID =Convert.ToInt32(dpRoute.SelectedItem.Value);
            p.MorningKM = Convert.ToDouble(txtMorningKM.Text);
            p.EveningKM = Convert.ToDouble(txtEveningKM.Text);
            p.Bata = Convert.ToDouble(txtBata.Text);
            p.InstallmentAmount = Convert.ToDouble(txtAmount.Text);
            p.MorningInTime = txtMorningInTime.Text;
            p.MorningOutTime = txtMorningOutTime.Text;
            p.EveningInTime = txtEveningInTime.Text;
            p.EveningOutTime = txtEveningOutTime.Text;
            p.MorningInCan = txtMCanIn.Text;
            p.MorningOutCan = txtMCanOut.Text;
            p.EveningInCan = txtEInCan.Text;
            p.EveningOutCan = txtEOutCan.Text;
            p.DriverName = txtDriverName.Text;
            p.Remarks = txtRemarks.Text;
            p.CreatedBy = App_code.GlobalInfo.Userid;
            p.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
            p.ModifiedBy = App_code.GlobalInfo.Userid;
            p.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");
            p.flag = "Insert";
            int Result = 0;
            Result = pd.InsertMilkCollectionTransportDetails(p);
            if (Result > 0)
            {

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Milk Collection Transport Record Add  Successfully";

                ClearTextBox();
                BindMilkCollectionList();
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
            dpVehicleNo.ClearSelection();
            txtDate.Text = string.Empty;
            txtEveningKM.Text = string.Empty;
            txtMorningKM.Text = string.Empty;
            txtAmount.Text = string.Empty;
            txtBata.Text = string.Empty;
            dpRoute.ClearSelection();
            txtRemarks.Text = string.Empty;
            txtTotalKM.Text = string.Empty;
            txtMorningInTime.Text = string.Empty;
            txtMorningOutTime.Text = string.Empty;
            txtMCanIn.Text = string.Empty;
            txtMCanOut.Text = string.Empty;
            txtEveningInTime.Text = string.Empty;
            txtEveningOutTime.Text = string.Empty;
            txtDriverName.Text = string.Empty;
            txtEInCan.Text = string.Empty;
            txtEOutCan.Text = string.Empty;

        }

        public void GetMilkCollectionTransportDetailsbyID(int milkcollectionid)
        {
            DataSet DS = new DataSet();
            ProcurementData pd = new ProcurementData();
            DS = pd.GetMilkCollectionTransportDetailsbyID(milkcollectionid);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpVehicleNo.ClearSelection();
                if (dpVehicleNo.Items.FindByText(DS.Tables[0].Rows[0]["VehicalNo"].ToString()) != null)
                {
                    dpVehicleNo.Items.FindByText(DS.Tables[0].Rows[0]["VehicalNo"].ToString()).Selected = true;
                }
                //dpVehicleNo.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["VehicalNo"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["VehicalNo"].ToString();
                txtDate.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Date"].ToString()) ? string.Empty : Convert.ToDateTime(DS.Tables[0].Rows[0]["Date"]).ToString("yyyy-MM-dd");
                txtEveningKM.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["EveningKM"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["EveningKM"].ToString();
                txtMorningKM.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["MorningKM"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["MorningKM"].ToString();
                txtAmount.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Amount"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Amount"].ToString();
                txtBata.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Bata"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Bata"].ToString();
                txtMorningInTime.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["MorningInTime"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["MorningInTime"].ToString();
                txtMorningOutTime.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["MorningOutTime"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["MorningOutTime"].ToString();
                txtMCanIn.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["MorningInCan"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["MorningInCan"].ToString();
                txtMCanOut.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["MorningOutCan"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["MorningOutCan"].ToString();
                txtEInCan.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["EveningInCan"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["EveningInCan"].ToString();
                txtEOutCan.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["EveningOutCan"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["EveningOutCan"].ToString();

                txtEveningInTime.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["EveningInTime"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["EveningInTime"].ToString();
                txtEveningOutTime.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["EveningOutTime"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["EveningOutTime"].ToString();
                txtDriverName.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["DriverName"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["DriverName"].ToString();
                txtRemarks.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Remarks"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Remarks"].ToString();
                txtTotalKM.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["TotalKM"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["TotalKM"].ToString();
                dpRoute.ClearSelection();
                if (dpRoute.Items.FindByValue(DS.Tables[0].Rows[0]["RouteID"].ToString()) != null)
                {
                    dpRoute.Items.FindByValue(DS.Tables[0].Rows[0]["RouteID"].ToString()).Selected = true;
                }
            }
        }
        public void DeleteMilkCollectionTransportbyID(int collectionid)
        {


            Model.Procurement p = new Model.Procurement();
            ProcurementData pd = new ProcurementData();
            p.MilkCollectionTransportID = string.IsNullOrEmpty(hfMilkCollectionID.Value) ? 0 : Convert.ToInt32(hfMilkCollectionID.Value); ;
            p.Date = Convert.ToDateTime(txtDate.Text);
            p.VehicleNo = dpVehicleNo.SelectedItem.Text;
            p.RouteID = 0;
            p.MorningKM = 0;
            p.EveningKM = 0;
            p.Bata = 0;
            p.InstallmentAmount = 0;
            p.MorningInTime = txtMorningInTime.Text;
            p.MorningOutTime = txtMorningOutTime.Text;
            p.EveningInTime = txtEveningInTime.Text;
            p.EveningOutTime = txtEveningOutTime.Text;
            p.MorningInCan = txtMCanIn.Text;
            p.MorningOutCan = txtMCanOut.Text;
            p.EveningInCan = txtEInCan.Text;
            p.EveningOutCan = txtEOutCan.Text;
            p.DriverName = txtDriverName.Text;
            p.Remarks = txtRemarks.Text;
            p.CreatedBy = App_code.GlobalInfo.Userid;
            p.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
            p.ModifiedBy = App_code.GlobalInfo.Userid;
            p.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");
            p.flag = "Delete";
            int Result = 0;
            Result = pd.InsertMilkCollectionTransportDetails(p);
            if (Result > 0)
            {
                //lbltital.Text = "Add Route";
                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Milk Collection Record Deleted  Successfully";
                ClearTextBox();
                BindMilkCollectionList();
                pnlError.Update();
                btnAddMilkTransport.Visible = true;
                btnupdateMilkTransport.Visible = false;
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
        protected void btnupdateMilkCollection_Click(object sender, EventArgs e)
        {
            Model.Procurement p = new Model.Procurement();
            ProcurementData pd = new ProcurementData();
            p.MilkCollectionTransportID = string.IsNullOrEmpty(hfMilkCollectionID.Value) ? 0 : Convert.ToInt32(hfMilkCollectionID.Value); ;
            p.Date = Convert.ToDateTime(txtDate.Text);
            p.VehicleNo = dpVehicleNo.SelectedItem.Text;
            p.RouteID = Convert.ToInt32(dpRoute.SelectedItem.Value);
            p.MorningKM = Convert.ToDouble(txtMorningKM.Text);
            p.EveningKM = Convert.ToDouble(txtEveningKM.Text);
            p.Bata = Convert.ToDouble(txtBata.Text);
            p.InstallmentAmount = Convert.ToDouble(txtAmount.Text);
            p.MorningInTime = txtMorningInTime.Text;
            p.MorningOutTime = txtMorningOutTime.Text;
            p.EveningInTime = txtEveningInTime.Text;
            p.EveningOutTime = txtEveningOutTime.Text;
            p.MorningInCan = txtMCanIn.Text;
            p.MorningOutCan = txtMCanOut.Text;
            p.EveningInCan = txtEInCan.Text;
            p.EveningOutCan = txtEOutCan.Text;
            p.DriverName = txtDriverName.Text;
            p.Remarks = txtRemarks.Text;
            p.CreatedBy = App_code.GlobalInfo.Userid;
            p.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
            p.ModifiedBy = App_code.GlobalInfo.Userid;
            p.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");
            p.flag = "Update";
            int Result = 0;
            Result = pd.InsertMilkCollectionTransportDetails(p);
            if (Result > 0)
            {
                //lbltital.Text = "Add Route";
                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Milk Collection Record Updated  Successfully";
                ClearTextBox();
                BindMilkCollectionList();
                pnlError.Update();
                btnAddMilkTransport.Visible = true;
                btnupdateMilkTransport.Visible = false;
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

        protected void txtEveningKM_TextChanged(object sender, EventArgs e)
        {
            int MorningKM;
            int EveningKM;
            double totalkm;

            MorningKM= string.IsNullOrEmpty(txtMorningKM.Text) ? 0 : Convert.ToInt32(txtMorningKM.Text);
            EveningKM= string.IsNullOrEmpty(txtEveningKM.Text) ? 0 : Convert.ToInt32(txtEveningKM.Text);
            totalkm = Convert.ToDouble(MorningKM + EveningKM);
            txtTotalKM.Text = totalkm.ToString();
            DS = BindCommanData.BindCommanDropDwon("VehicleMasterID ", "VehicleType", "Proc_VehicleMaster", "IsActive=1 and VehicleMasterID=" + dpVehicleNo.SelectedItem.Value);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                int modelid;
                double tds;
                double amt;
                var vehiclemodelid = DS.Tables[0].AsEnumerable().Select(r => r.Field<int>("VehicleType")).ToList();
                modelid = Convert.ToInt32(vehiclemodelid[0]);
                DataSet ds = new DataSet();
                ProcurementData pd = new ProcurementData();
                ds = pd.GetBataandAmountOfVehicleonbasisofmodelid(modelid,Convert.ToInt32(dpVehicleNo.SelectedItem.Value));
                if (!Comman.Comman.IsDataSetEmpty(DS))
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        if (Convert.ToDouble(row["KMLow"]) <= totalkm && Convert.ToDouble(row["KMHigh"]) >= totalkm)
                        {
                            txtBata.Text = Convert.ToDecimal(row["Bata"]).ToString("#.##");
                        }
                    }
                    tds= Convert.ToDouble(ds.Tables[1].Rows[0]["TDS"]);
                    amt = totalkm+(totalkm * tds/100) ;
                    txtAmount.Text = amt.ToString();
                }

                }
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
           Response.Redirect("~/Tabs/Procurement/MilkCollectionTransport.aspx");
        }

        protected void dpVehicleNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            DS = BindCommanData.BindCommanDropDwon("VehicleMasterID ", "DriverName", "Proc_VehicleMaster", "IsActive=1 and VehicleMasterID="+dpVehicleNo.SelectedItem.Value);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
               
                    var dname = DS.Tables[0].AsEnumerable().Select(r => r.Field<string>("DriverName")).ToList();
                    txtDriverName.Text = dname[0].ToString();
            }
        }
    }
}