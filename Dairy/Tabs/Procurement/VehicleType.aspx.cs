using Bussiness;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;

namespace Dairy.Tabs.Procurement
{
    public partial class VehicleType : System.Web.UI.Page
    {
        ProcurementData pd = new ProcurementData();
        Model.Procurement p = new Model.Procurement();
        DataSet DS = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetVehicleType();
                btnAddVehicleType.Visible = true;
                benUpdateVehicleType.Visible = false;
            }
        }

        protected void btnAddVehicleType_Click(object sender, EventArgs e)
        {
            pd = new ProcurementData();
            p = new Model.Procurement();
            int Result = 0;
            p.VehicleType = 0;
            p.VehicleTypeName = txtVehicleType.Text;
            if (dpStatus.SelectedItem.Value == "1")
            {
                p.IsActive = true;
            }
            if (dpStatus.SelectedItem.Value == "0")
            {
                p.IsActive = false;
            }
            p.flag = "Insert";
            Result = pd.InsertVehicleType(p);
            if (Result > 0)
            {

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Vehicle Model Added  Successfully";
                GetVehicleType();

                upMain.Update();

                pnlError.Update();
                uprouteList.Update();
            }
            else
            {
                divDanger.Visible = false;
                divwarning.Visible = true;
                divSusccess.Visible = false;
                lblwarning.Text = "   Please Contact to Site Admin";

                pnlError.Update();

            }

        }

        protected void benUpdateVehicleType_Click(object sender, EventArgs e)
        {
            pd = new ProcurementData();
            p = new Model.Procurement();
            int Result = 0;

            p.VehicleType = string.IsNullOrEmpty(hfBrandId.Value) ? 0 : Convert.ToInt32(hfBrandId.Value);
            p.VehicleTypeName = txtVehicleType.Text;
            if (dpStatus.SelectedItem.Value == "1")
            {
                p.IsActive = true;
            }
            if (dpStatus.SelectedItem.Value == "0")
            {
                p.IsActive = false;
            }
            p.flag = "Update";
            Result = pd.InsertVehicleType(p);
            if (Result > 0)
            {

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Vehicle Model Updated  Successfully";
                GetVehicleType();

                upMain.Update();

                pnlError.Update();
                uprouteList.Update();
            }
            else
            {
                divDanger.Visible = false;
                divwarning.Visible = true;
                divSusccess.Visible = false;
                lblwarning.Text = "   Please Contact to Site Admin";

                pnlError.Update();

            }

        }

        protected void rpVehicleType_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            divDanger.Visible = false;
            divwarning.Visible = false;
            divSusccess.Visible = false;
            pnlError.Update();
            int TypeID = 0;
            TypeID = Convert.ToInt32(e.CommandArgument);
            switch (e.CommandName)
            {
                case ("Edit"):
                    {
                        lblHeaderTab.Text = "Edit Brand";
                        hfBrandId.Value = TypeID.ToString();
                        TypeID = Convert.ToInt32(hfBrandId.Value);
                        GetVehicleTypeById(TypeID);
                        btnAddVehicleType.Visible = false;
                        benUpdateVehicleType.Visible = true;

                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }
                case ("delete"):
                    {

                        hfBrandId.Value = TypeID.ToString();
                        TypeID = Convert.ToInt32(hfBrandId.Value);
                        DeleteTypeID(TypeID);

                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }


            }
        }

        private void DeleteTypeID(int typeID)
        {
            pd = new ProcurementData();
            p = new Model.Procurement();
            int Result = 0;
            p.VehicleType = string.IsNullOrEmpty(hfBrandId.Value) ? 0 : Convert.ToInt32(hfBrandId.Value);
            p.VehicleTypeName = "";
            if (dpStatus.SelectedItem.Value == "1")
            {
                p.IsActive = true;
            }
            if (dpStatus.SelectedItem.Value == "0")
            {
                p.IsActive = false;
            }
            p.flag = "Delete";
            Result = pd.InsertVehicleType(p);
            if (Result > 0)
            {

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Vehicle Model Deleted  Successfully";
                GetVehicleType();

                upMain.Update();

                pnlError.Update();
                uprouteList.Update();
            }
            else
            {
                divDanger.Visible = false;
                divwarning.Visible = true;
                divSusccess.Visible = false;
                lblwarning.Text = "   Please Contact to Site Admin";

                pnlError.Update();

            }
        }

        private void GetVehicleTypeById(int typeID)
        {
            pd = new ProcurementData();
            DataSet DS = new DataSet();
            DS = pd.GetVehicleTypeById(typeID);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpStatus.ClearSelection();
                if (DS.Tables[0].Rows[0]["IsActive"].ToString() == "True")
                {
                    dpStatus.Items.FindByValue("1").Selected = true;
                }
                if (DS.Tables[0].Rows[0]["IsActive"].ToString() == "False")
                {
                    dpStatus.Items.FindByValue("2").Selected = true;
                }
                txtVehicleType.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["VehicleType"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["VehicleType"].ToString();

            }
        }

        public void GetVehicleType()
        {

            pd = new ProcurementData();
            DataSet DS = new DataSet();
            DS = pd.GetVehicleType();

            if (!Comman.Comman.IsDataSetEmpty(DS))
            {

                rpVehicleType.DataSource = DS;
                rpVehicleType.DataBind();
            }



        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Tabs/Procurement/VehicleType.aspx");
        }

        protected void txtVehicleType_TextChanged(object sender, EventArgs e)
        {
            pd = new ProcurementData();
            DataSet DS = new DataSet();
            DS = pd.GetVehicleType();

            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                foreach (DataRow row in DS.Tables[0].Rows)
                {
                    if (row["VehicleType"].ToString() == txtVehicleType.Text.ToString())
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Vehicle Model Already exists')", true);
                        txtVehicleType.Text = string.Empty;
                    }

                }
            }
        }
    }
}