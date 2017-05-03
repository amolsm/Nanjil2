using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bussiness;
using System.Text;

namespace Dairy.Tabs.Procurement
{
    public partial class AddSupplierSchemeBonus : System.Web.UI.Page
    {
        DataSet DS = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindeSupplierSchemeInfo();
                BindDropdown();
                btnAddBonus.Visible = true;
                btnupdateBonus.Visible = false;
                DateTime dt = DateTime.Now;
                txtSchemeBonusYr.Text = dt.Year.ToString();
                txtPaymentDate.Text = DateTime.Now.ToString("yyyy-MM-dd");

            }
        }

        public void BindDropdown()
        {
            //DS = BindCommanData.BindCommanDropDwon("SupplierID ", "SupplierCode +' '+SupplierName as Name  ", "Proc_MilkSuppliersProfile", "IsActive=1 ");
            //if (!Comman.Comman.IsDataSetEmpty(DS))
            //{
            //    dpSupplier.DataSource = DS;
            //    dpSupplier.DataBind();
            //    dpSupplier.Items.Insert(0, new ListItem("--Select Supplier  --", "0"));
            //}
            DS = BindCommanData.BindCommanDropDwon("RouteID ", "RouteCode +' '+RouteName as Name  ", "Proc_MilkCollectionRoute", "IsActive=1 ");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpRoute.DataSource = DS;
                dpRoute.DataBind();
                dpRoute.Items.Insert(0, new ListItem("--Select Route  --", "0"));
            }
        }

        public void ClearTextBox()
        {
            dpRoute.ClearSelection();
            DropDownList1.ClearSelection();
            txtSchemeBonusYr.Text = string.Empty;
            txtBonusAmount.Text = string.Empty;
            txtSchemeAmount.Text = string.Empty;
            txtPaymentDate.Text = string.Empty;

        }
        public void BindeSupplierSchemeInfo()
        {

            ProcurementData pd = new ProcurementData();
            DataSet DS = new DataSet();
            StringBuilder sb = new StringBuilder();
            DS = pd.GetAllSupplierSchemeInfo();
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                rpSchemeInfo.DataSource = DS;
                rpSchemeInfo.DataBind();
            }
        }
        protected void rpSchemeInfo_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {

            divDanger.Visible = false;
            divwarning.Visible = false;
            divSusccess.Visible = false;
            pnlError.Update();
            int SchemeID = 0;
            SchemeID = Convert.ToInt32(e.CommandArgument);
            switch (e.CommandName)
            {
                case ("Edit"):
                    {
                        //lbltital.Text = "Edit Route";
                        hfScheme.Value = SchemeID.ToString();
                        SchemeID = Convert.ToInt32(hfScheme.Value);
                        //BindRouteList();
                        ClearTextBox();
                        GetSupplierSchemeInfobyID(SchemeID);
                        btnAddBonus.Visible = false;
                        btnupdateBonus.Visible = true;
                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }
                case ("delete"):
                    {

                        hfScheme.Value = SchemeID.ToString();
                        SchemeID = Convert.ToInt32(hfScheme.Value);
                        DeleteRoutebyrouteID(SchemeID);
                        BindeSupplierSchemeInfo();
                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }


            }
        }
        public void GetSupplierSchemeInfobyID(int SchemeID)
        {
            DataSet DS = new DataSet();
            ProcurementData pd = new ProcurementData();
            DS = pd.GetSupplierSchemeInfobyID(SchemeID);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpRoute.ClearSelection();
                if (dpRoute.Items.FindByValue(DS.Tables[0].Rows[0]["SupplierID"].ToString()) != null)
                {
                    dpRoute.Items.FindByValue(DS.Tables[0].Rows[0]["SupplierID"].ToString()).Selected = true;
                }
                txtSchemeBonusYr.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["SchemeBonusYear"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["SchemeBonusYear"].ToString();
                txtSchemeAmount.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["SchemeAmount"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["SchemeAmount"].ToString();
                txtBonusAmount.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["BonusAmount"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["BonusAmount"].ToString();
                txtPaymentDate.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["PaymentDateTime"].ToString()) ? string.Empty : Convert.ToDateTime(DS.Tables[0].Rows[0]["PaymentDateTime"]).ToString("yyyy-MM-dd");
                DropDownList1.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["PaymentStatus"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["PaymentStatus"].ToString();
            }
        }
        public void DeleteRoutebyrouteID(int CenterID)
        {


            //int Result = 0;
            //Result = routeDate.InsertRoute(route);
            //if (Result > 0)
            //{

            //    divDanger.Visible = false;
            //    divwarning.Visible = false;
            //    divSusccess.Visible = true;
            //    lblSuccess.Text = "Delete Updated  Successfully";
            //    ClearTextBox();
            //    BindRouteList();
            //    pnlError.Update();
            //    btnAddRoute.Visible = true;
            //    btnupdateroute.Visible = false;
            //    upMain.Update();
            //    uprouteList.Update();
            //}
            //else
            //{
            //    divDanger.Visible = false;
            //    divwarning.Visible = true;
            //    divSusccess.Visible = false;
            //    lblwarning.Text = "Please Contact to Site Admin";
            //    pnlError.Update();

            //}
        }

        protected void btnAddSchemeInfo_Click(object sender, EventArgs e)
        {
            Model.Procurement p = new Model.Procurement();
            ProcurementData pd = new ProcurementData();
            p.SchemeID = 0;
            p.SupplierID = Convert.ToInt32(dpRoute.SelectedValue);
            p.SchemeBonusYr = txtSchemeBonusYr.Text;
            p.SchemeAmount = Convert.ToDouble(txtSchemeAmount.Text);
            p.BonusAmount = Convert.ToDouble(txtBonusAmount.Text);
            p.PaymentStatus = DropDownList1.SelectedItem.Text;
            p.PaymentDateTime = txtPaymentDate.Text;
            p.CreatedBy = App_code.GlobalInfo.Userid;
            p.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
            p.ModifiedBy = App_code.GlobalInfo.Userid;
            p.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");
            p.flag = "Insert";
            int Result = 0;
            Result = pd.InsertSupplierSchemeInfo(p);
            if (Result > 0)
            {

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Supplier Scheme Bonus Add  Successfully";

                ClearTextBox();
                BindeSupplierSchemeInfo();
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

        protected void btnupdateSchemeInfo_Click(object sender, EventArgs e)
        {
            Model.Procurement p = new Model.Procurement();
            ProcurementData pd = new ProcurementData();
            p.SchemeID = string.IsNullOrEmpty(hfScheme.Value) ? 0 : Convert.ToInt32(hfScheme.Value);
            p.SupplierID = Convert.ToInt32(dpRoute.SelectedValue);
            p.SchemeBonusYr = txtSchemeBonusYr.Text;
            p.SchemeAmount = Convert.ToDouble(txtSchemeAmount.Text);
            p.BonusAmount = Convert.ToDouble(txtBonusAmount.Text);
            p.PaymentStatus = DropDownList1.SelectedItem.Text;
            p.PaymentDateTime = txtPaymentDate.Text;

            p.CreatedBy = App_code.GlobalInfo.Userid;
            p.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
            p.ModifiedBy = App_code.GlobalInfo.Userid;
            p.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");

            p.flag = "Update";
            int Result = 0;
            Result = pd.InsertSupplierSchemeInfo(p);
            if (Result > 0)
            {
                //lbltital.Text = "Add Route";
                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Supplier Scheme Bonus Info Updated  Successfully";
                ClearTextBox();
                BindeSupplierSchemeInfo();
                pnlError.Update();
                btnAddBonus.Visible = true;
                btnupdateBonus.Visible = false;
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

        protected void dpRoute_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProcurementData pd = new ProcurementData();
            int RouteID = Convert.ToInt32(dpRoute.SelectedItem.Value);
            DataSet DS = new DataSet();
            DS = pd.GetRouteSchemeBonusbyroute(RouteID);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                txtSchemeAmount.Text = string.Empty;
                txtBonusAmount.Text = string.Empty;
                txtSchemeAmount.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Scheme"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Scheme"].ToString();
                txtBonusAmount.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Bonus"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Bonus"].ToString();

            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert(' Scheme and Bonus not found for this route')", true);
                dpRoute.ClearSelection();
                txtSchemeAmount.Text = string.Empty;
                txtBonusAmount.Text = string.Empty;
            }

        }
    }
}