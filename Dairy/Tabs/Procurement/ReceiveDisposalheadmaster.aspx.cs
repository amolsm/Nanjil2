using Bussiness;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dairy.Tabs.Procurement
{
    public partial class ReceiveDisposalheadmaster : System.Web.UI.Page
    {
        ProcurementData pd = new ProcurementData();
        Model.Procurement p = new Model.Procurement();
        DataSet DS = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetReceiveDisposeHeadMaster();
                btnAdd.Visible = true;
                btnUpdate.Visible = false;
            }
        }

        private void GetReceiveDisposeHeadMaster()
        {
            pd = new ProcurementData();
            DataSet DS = new DataSet();
            DS = pd.GetReceiveDisposeHeadMaster();

            if (!Comman.Comman.IsDataSetEmpty(DS))
            {

                rpVehicleType.DataSource = DS;
                rpVehicleType.DataBind();
            }

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            pd = new ProcurementData();
            p = new Model.Procurement();
            int Result = 0;
            p.ID = 0;
            p.particular = txtParticular.Text;
            p.purpose = dpStatus.SelectedItem.Text;
            if (dpIsActive.SelectedItem.Value == "1")
            {
                p.IsActive = true;
            }
            else if (dpIsActive.SelectedItem.Text == "2")
            {
                p.IsActive = false;
            }
            p.flag = "Insert";
            Result = pd.InsertReceiveandDisposeMaster(p);
            if (Result > 0)
            {

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Receive & Dispose Head Master Added  Successfully";
                GetReceiveDisposeHeadMaster();

                upMain.Update();

                pnlError.Update();
                uprouteList.Update();
            }
            else
            {
                divDanger.Visible = false;
                divwarning.Visible = true;
                divSusccess.Visible = false;
                lblwarning.Text = "This Record Already exists.";

                pnlError.Update();

            }


        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            pd = new ProcurementData();
            p = new Model.Procurement();
            int Result = 0;

            p.ID = string.IsNullOrEmpty(hfBrandId.Value) ? 0 : Convert.ToInt32(hfBrandId.Value);

            p.particular = txtParticular.Text;
            p.purpose = dpStatus.SelectedItem.Text;
            if (dpIsActive.SelectedItem.Value == "1")
            {
                p.IsActive = true;
            }
            else if (dpIsActive.SelectedItem.Text == "2")
            {
                p.IsActive = false;
            }
            p.flag = "Update";
            Result = pd.InsertReceiveandDisposeMaster(p);
            if (Result > 0)
            {

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Vehicle Type Updated  Successfully";
                GetReceiveDisposeHeadMaster();

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

        private void GetReceiveDisposeHeadMasterId(int ID)
        {
            pd = new ProcurementData();
            DataSet DS = new DataSet();
            DS = pd.GetReceiveDisposeHeadMasterId(ID);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpStatus.ClearSelection();
                if (dpStatus.Items.FindByText(DS.Tables[0].Rows[0]["Purpose"].ToString()) != null)
                {
                    dpStatus.Items.FindByText(DS.Tables[0].Rows[0]["Purpose"].ToString()).Selected = true;
                }
                txtParticular.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Particular"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Particular"].ToString();
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
                        lblHeaderTab.Text = "Edit Receive & Dispose Master";
                        hfBrandId.Value = TypeID.ToString();
                        TypeID = Convert.ToInt32(hfBrandId.Value);
                        GetReceiveDisposeHeadMasterId(TypeID);
                        btnAdd.Visible = false;
                        btnUpdate.Visible = true;

                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }
                case ("delete"):
                    {

                        hfBrandId.Value = TypeID.ToString();
                        TypeID = Convert.ToInt32(hfBrandId.Value);
                        DeleteReceiveandDisposeMaster(TypeID);

                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }


            }
        }

        private void DeleteReceiveandDisposeMaster(int typeID)
        {
            pd = new ProcurementData();
            p = new Model.Procurement();
            int Result = 0;

            p.ID = string.IsNullOrEmpty(hfBrandId.Value) ? 0 : Convert.ToInt32(hfBrandId.Value);

            p.particular = txtParticular.Text;
            p.purpose = dpStatus.SelectedItem.Text;
            p.flag = "Delete";
            Result = pd.InsertReceiveandDisposeMaster(p);
            if (Result > 0)
            {

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Receive and Dispose Master Deleted  Successfully";
                GetReceiveDisposeHeadMaster();

                upMain.Update();

                pnlError.Update();
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
            Response.Redirect("~/Tabs/Procurement/ReceiveDisposalheadmaster.aspx");
        }
    }
}