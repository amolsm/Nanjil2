using Bussiness;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dairy.Tabs.Procurement
{
    public partial class IncentiveTarrif : System.Web.UI.Page
    {
        DataSet DS = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindIncentiveList();
                btnAddTariff.Visible = true;
                btnupdateTariff.Visible = false;

            }
        }

        protected void btnAddTariff_Click(object sender, EventArgs e)
        {
            ProcurementData pd = new ProcurementData();
            Model.Procurement p = new Model.Procurement();
            int result = 0;
            p.ID = 0;
            p.QCat = txtQCat.Text.ToString();
            p.QLow = string.IsNullOrEmpty(txtQLow.Text) ? 0 : Convert.ToDecimal(txtQLow.Text);
            p.QHigh = string.IsNullOrEmpty(txtQHigh.Text) ? 0 : Convert.ToDecimal(txtQHigh.Text);
            p.QIncentive = string.IsNullOrEmpty(txtQIncentive.Text) ? 0 : Convert.ToDecimal(txtQIncentive.Text);
            p.Description = string.IsNullOrEmpty(txtDesc.Text) ? string.Empty : txtDesc.Text;

            if (dpStatus.SelectedItem.Value == "1")
            {
                p.IsActive = true;
            }
            if (dpStatus.SelectedItem.Value == "0")
            {
                p.IsActive = false;
            }
            p.flag = "Insert";
            result = pd.AllIncentiveTariff(p);
            if (result > 0)
            {

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Incentive Tariff Added  Successfully";
                BindIncentiveList();

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

        private void BindIncentiveList()
        {
            ProcurementData pd = new ProcurementData();
            DataSet DS = new DataSet();
            DS = pd.GetIncentivetariff();
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                rpIncentiveTariff.DataSource = DS;
                rpIncentiveTariff.DataBind();
            }
        }

        protected void btnupdateTariff_Click(object sender, EventArgs e)
        {
            ProcurementData pd = new ProcurementData();
            Model.Procurement p = new Model.Procurement();
            int result = 0;
            p.ID = string.IsNullOrEmpty(hftariff.Value) ? 0 : Convert.ToInt32(hftariff.Value);
            p.QCat = txtQCat.Text.ToString();
            p.QLow = string.IsNullOrEmpty(txtQLow.Text) ? 0 : Convert.ToDecimal(txtQLow.Text);
            p.QHigh = string.IsNullOrEmpty(txtQHigh.Text) ? 0 : Convert.ToDecimal(txtQHigh.Text);
            p.QIncentive = string.IsNullOrEmpty(txtQIncentive.Text) ? 0 : Convert.ToDecimal(txtQIncentive.Text);
            p.Description = string.IsNullOrEmpty(txtDesc.Text) ? string.Empty : txtDesc.Text;
            if (dpStatus.SelectedItem.Value == "1")
            {
                p.IsActive = true;
            }
            if (dpStatus.SelectedItem.Value == "0")
            {
                p.IsActive = false;
            }
            p.flag = "Update";
            result = pd.AllIncentiveTariff(p);
            if (result > 0)
            {

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Incentive Tariff Updated  Successfully";
                BindIncentiveList();

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

        protected void rpIncentiveTariff_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            divDanger.Visible = false;
            divwarning.Visible = false;
            divSusccess.Visible = false;
            pnlError.Update();
            int incentivetariffid = 0;
            incentivetariffid = Convert.ToInt32(e.CommandArgument);
            switch (e.CommandName)
            {
                case ("Edit"):
                    {

                        hftariff.Value = incentivetariffid.ToString();
                        incentivetariffid = Convert.ToInt32(hftariff.Value);
                        GetIncentiveTariffbyID(incentivetariffid);
                        btnAddTariff.Visible = false;
                        btnupdateTariff.Visible = true;
                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }
                    //case ("delete"):
                    //    {

                    //        hftariff.Value = incentivetariffid.ToString();
                    //        incentivetariffid = Convert.ToInt32(hftariff.Value);
                    //        DeleteIncentiveTariffbyId(incentivetariffid);
                    //        BindIncentiveList();
                    //        upMain.Update();
                    //        uprouteList.Update();
                    //        break;
                    //    }


            }
        }

        private void DeleteIncentiveTariffbyId(int incentivetariffid)
        {
            ProcurementData pd = new ProcurementData();
            Model.Procurement p = new Model.Procurement();
            int result = 0;
            p.ID = string.IsNullOrEmpty(hftariff.Value) ? 0 : Convert.ToInt32(hftariff.Value);
            p.QCat = txtQCat.Text.ToString();
            p.QLow = string.IsNullOrEmpty(txtQLow.Text) ? 0 : Convert.ToDecimal(txtQLow.Text);
            p.QHigh = string.IsNullOrEmpty(txtQHigh.Text) ? 0 : Convert.ToDecimal(txtQHigh.Text);
            p.QIncentive = string.IsNullOrEmpty(txtQIncentive.Text) ? 0 : Convert.ToDecimal(txtQIncentive.Text);
            if (dpStatus.SelectedItem.Value == "1")
            {
                p.IsActive = true;
            }
            if (dpStatus.SelectedItem.Value == "0")
            {
                p.IsActive = false;
            }
            p.flag = "Delete";
            result = pd.AllIncentiveTariff(p);
            if (result > 0)
            {

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Incentive Tariff Deleted  Successfully";
                BindIncentiveList();

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

        private void GetIncentiveTariffbyID(int incentivetariffid)
        {
            DataSet DS = new DataSet();
            ProcurementData pd = new ProcurementData();
            DS = pd.GetIncentiveTariffbyID(incentivetariffid);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                txtQCat.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["QCat"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["QCat"].ToString();
                dpStatus.ClearSelection();
                if (DS.Tables[0].Rows[0]["IsActive"].ToString() == "True")
                {
                    dpStatus.Items.FindByValue("1").Selected = true;
                }
                if (DS.Tables[0].Rows[0]["IsActive"].ToString() == "False")
                {
                    dpStatus.Items.FindByValue("0").Selected = true;
                }
                txtQLow.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["QLow"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["QLow"].ToString();
                txtQHigh.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["QHigh"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["QHigh"].ToString();
                txtQIncentive.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["QIncentive"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["QIncentive"].ToString();
                txtDesc.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Description"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Description"].ToString();
            }
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Tabs/Procurement/IncentiveTarrif.aspx");
        }

        //protected void txtQCat_TextChanged(object sender, EventArgs e)
        //{
        //    string Qcategory = txtQCat.Text;
        //    ProcurementData pd = new ProcurementData();
        //    DS = pd.GetExistingQcategory(Qcategory);
        //    if (!Comman.Comman.IsDataSetEmpty(DS))
        //    {
        //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Quality Catogory Already exists.')", true);
        //        txtQCat.Text = string.Empty;
        //    }
        //}
    }
}