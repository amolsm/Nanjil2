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


namespace Dairy.Tabs.Procurement
{
    public partial class RawMilkTariff : System.Web.UI.Page
    {
        DataSet DS = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindRawMilkTerrifList();
                btnAddRaw.Visible = true;
                btnupdateRaw.Visible = false;
                txtWEF_DATE.Text = DateTime.Now.ToString("yyyy/MM/dd");
            }
        }


        protected void btnAddRaw_Click(object sender, EventArgs e)
        {
            decimal tsl = Convert.ToDecimal(txtTSL.Text);
            decimal tsh = Convert.ToDecimal(txtTSH.Text);
            if (tsl < tsh)
            {
                Model.Procurement p = new Model.Procurement();
                ProcurementData pd = new ProcurementData();
                p.RawMilkTarrifID = 0;
                p.Category = Convert.ToInt32(Category.SelectedItem.Value);
                p.TSL = Convert.ToDecimal(txtTSL.Text);
                p.TSH = Convert.ToDecimal(txtTSH.Text);
                p.TSRATE = Convert.ToDecimal(txtTSRate.Text);
                p.TS_INCR = 0;
                p.Incentive = string.IsNullOrEmpty(txtIncentive.Text) ? 0 : Convert.ToInt32(txtIncentive.Text);
                p.IN_FAT = string.IsNullOrEmpty(txtIN_FAT.Text) ? 0 : Convert.ToInt32(txtIN_FAT.Text);
                p.IN_SNF = string.IsNullOrEmpty(txtIN_SNF.Text) ? 0 : Convert.ToInt32(txtIN_SNF.Text);
                p.IN_TS = string.IsNullOrEmpty(txtIN_TS.Text) ? 0 : Convert.ToInt32(txtIN_TS.Text);
                p.Bonus1 = string.IsNullOrEmpty(txtBonus.Text) ? 0 : Convert.ToDecimal(txtBonus.Text);
                p.Scheme = string.IsNullOrEmpty(txtScheme.Text) ? 0 : Convert.ToDecimal(txtScheme.Text);
                p.WEF_DATE = Convert.ToDateTime(txtWEF_DATE.Text);
                p.CreatedBy = App_code.GlobalInfo.Userid;
                p.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
                p.ModifiedBy = App_code.GlobalInfo.Userid;
                p.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");
                p.flag = "Insert";
                int Result = 0;
                DS = pd.CheckAvailability(p);
                if (Comman.Comman.IsDataSetEmpty(DS))
                {
                    Result = pd.InsertRawMilkTarrif(p);
                    if (Result > 0)
                    {

                        divDanger.Visible = false;
                        divwarning.Visible = false;
                        divSusccess.Visible = true;
                        lblSuccess.Text = "Raw Milk Tarrif Record Add  Successfully";

                        ClearTextBox();
                        BindRawMilkTerrifList();
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
                else
                {
                    divDanger.Visible = false;
                    divwarning.Visible = true;
                    divSusccess.Visible = false;
                    lblwarning.Text = "Same Record is Already Avaialble";
                    pnlError.Update();
                }
            }
            else
            {
                divDanger.Visible = false;
                divwarning.Visible = true;
                divSusccess.Visible = false;
                lblwarning.Text = "TSL must be a less than TSH";
                pnlError.Update();
            }
        }

        public void ClearTextBox()
        {
            txtWEF_DATE.Text = string.Empty;
            txtTSRate.Text = string.Empty;
            //txtTS_INCR.Text = string.Empty;
            txtScheme.Text = string.Empty;
            txtIncentive.Text = string.Empty;
            txtIN_TS.Text = string.Empty;
            txtIN_SNF.Text = string.Empty;
            txtIN_FAT.Text = string.Empty;
            txtBonus.Text = string.Empty;
            Category.ClearSelection();
            txtTSL.Text = string.Empty;
            txtTSH.Text = string.Empty;
        }
        public void BindRawMilkTerrifList()
        {

            ProcurementData pd = new ProcurementData();
            DataSet DS = new DataSet();
            StringBuilder sb = new StringBuilder();
            DS = pd.GetAllRawMilkTarrifDetails();
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                rpRawMilkTarrif.DataSource = DS;
                rpRawMilkTarrif.DataBind();
            }
        }

        protected void rpRawMilkTarrif_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {

            divDanger.Visible = false;
            divwarning.Visible = false;
            divSusccess.Visible = false;
            pnlError.Update();
            int rawid = 0;
            rawid = Convert.ToInt32(e.CommandArgument);
            switch (e.CommandName)
            {
                case ("Edit"):
                    {
                        //lbltital.Text = "Edit Route";
                        hfrouteID.Value = rawid.ToString();
                        rawid = Convert.ToInt32(hfrouteID.Value);
                        //BindRouteList();
                        GetRouteDetailsbyID(rawid);
                        btnAddRaw.Visible = false;
                        btnupdateRaw.Visible = true;
                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }
                case ("delete"):
                    {

                        hfrouteID.Value = rawid.ToString();
                        rawid = Convert.ToInt32(hfrouteID.Value);
                        DeleteRoutebyrouteID(rawid);
                        BindRawMilkTerrifList();
                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }


            }
        }


        public void GetRouteDetailsbyID(int rawid)
        {
            DataSet DS = new DataSet();
            ProcurementData pd = new ProcurementData();
            DS = pd.GetRawMilkTarrifDetailsbyID(rawid);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                Category.ClearSelection();
                if (Category.Items.FindByValue(DS.Tables[0].Rows[0]["Category"].ToString()) != null)
                {
                    Category.Items.FindByValue(DS.Tables[0].Rows[0]["Category"].ToString()).Selected = true;
                }
               
                //decimal tsl = Convert.ToDecimal(DS.Tables[0].Rows[0]["TSL"].ToString());

                //string str = tsl.ToString("G29");
                //txtTSL.Text = str;
                txtTSL.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["TSL"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["TSL"].ToString();
                //decimal tsh = Convert.ToDecimal(DS.Tables[0].Rows[0]["TSH"].ToString());

                //string str1 = tsh.ToString("G29");
                txtTSH.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["TSH"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["TSH"].ToString();
             
                txtBonus.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Bonus"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Bonus"].ToString();
                txtIN_FAT.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["IN_FAT"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["IN_FAT"].ToString();
                txtIN_SNF.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["IN_SNF"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["IN_SNF"].ToString();
                txtIN_TS.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["IN_TS"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["IN_TS"].ToString();
                txtIncentive.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Incentive"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Incentive"].ToString();
                txtScheme.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Scheme"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Scheme"].ToString();
                //txtTS_INCR.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["TS_INCR"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["TS_INCR"].ToString();
                txtTSRate.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["TSRATE"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["TSRATE"].ToString();
                txtWEF_DATE.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["WEF_DATE"].ToString()) ? string.Empty : Convert.ToDateTime(DS.Tables[0].Rows[0]["WEF_DATE"]).ToString("yyyy-MM-dd");


            }
        }
        public void DeleteRoutebyrouteID(int rawid)
        {

            Model.Procurement p = new Model.Procurement();
            ProcurementData pd = new ProcurementData();
            p.RawMilkTarrifID = string.IsNullOrEmpty(hfrouteID.Value) ? 0 : Convert.ToInt32(hfrouteID.Value);
            p.Category = Convert.ToInt32(Category.SelectedItem.Value);
            p.TSL = string.IsNullOrEmpty(txtTSL.Text) ? 0 :Convert.ToDecimal(txtTSL.Text);
            p.TSH = string.IsNullOrEmpty(txtTSH.Text) ? 0 : Convert.ToDecimal(txtTSH.Text);
            p.TSRATE = string.IsNullOrEmpty(txtTSRate.Text) ? 0 : Convert.ToDecimal(txtTSRate.Text);
            p.TS_INCR = 0;
            p.Incentive = string.IsNullOrEmpty(txtIncentive.Text) ? 0 : Convert.ToInt32(txtIncentive.Text);
            p.IN_FAT = string.IsNullOrEmpty(txtIN_FAT.Text) ? 0 : Convert.ToInt32(txtIN_FAT.Text);
            p.IN_SNF = string.IsNullOrEmpty(txtIN_SNF.Text) ? 0 : Convert.ToInt32(txtIN_SNF.Text);
            p.IN_TS = string.IsNullOrEmpty(txtIN_TS.Text) ? 0 : Convert.ToInt32(txtIN_TS.Text);
            p.Bonus1 = string.IsNullOrEmpty(txtBonus.Text) ? 0 : Convert.ToDecimal(txtBonus.Text);
            p.Scheme = string.IsNullOrEmpty(txtScheme.Text) ? 0 : Convert.ToDecimal(txtScheme.Text);
            p.WEF_DATE = Convert.ToDateTime(txtWEF_DATE.Text);
            p.CreatedBy = App_code.GlobalInfo.Userid;
            p.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
            p.ModifiedBy = App_code.GlobalInfo.Userid;
            p.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");
            p.flag = "Delete";
            int Result = 0;
            Result = pd.InsertRawMilkTarrif(p);
            if (Result > 0)
            {
                //lbltital.Text = "Add Route";
                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Raw Milk Tarrif Record Deleted Succefully  Successfully";
                ClearTextBox();
                BindRawMilkTerrifList();
                pnlError.Update();
                btnAddRaw.Visible = true;
                btnupdateRaw.Visible = false;
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
        protected void btnupdateRaw_Click(object sender, EventArgs e)
        {
            decimal tsl = Convert.ToDecimal(txtTSL.Text);
            decimal tsh = Convert.ToDecimal(txtTSH.Text);
            if (tsl < tsh)
            {
                Model.Procurement p = new Model.Procurement();
                ProcurementData pd = new ProcurementData();
                p.RawMilkTarrifID = string.IsNullOrEmpty(hfrouteID.Value) ? 0 : Convert.ToInt32(hfrouteID.Value);
                p.Category = Convert.ToInt32(Category.SelectedItem.Value);
                p.TSL = Convert.ToDecimal(txtTSL.Text);
                p.TSH = Convert.ToDecimal(txtTSH.Text);
                p.TSRATE = Convert.ToDecimal(txtTSRate.Text);
                p.TS_INCR = 0;
                p.Incentive = string.IsNullOrEmpty(txtIncentive.Text) ? 0 : Convert.ToInt32(txtIncentive.Text);
                p.IN_FAT = string.IsNullOrEmpty(txtIN_FAT.Text) ? 0 : Convert.ToInt32(txtIN_FAT.Text);
                p.IN_SNF = string.IsNullOrEmpty(txtIN_SNF.Text) ? 0 : Convert.ToInt32(txtIN_SNF.Text);
                p.IN_TS = string.IsNullOrEmpty(txtIN_TS.Text) ? 0 : Convert.ToInt32(txtIN_TS.Text);
                p.Bonus1 = string.IsNullOrEmpty(txtBonus.Text) ? 0 : Convert.ToDecimal(txtBonus.Text);
                p.Scheme = string.IsNullOrEmpty(txtScheme.Text) ? 0 : Convert.ToDecimal(txtScheme.Text);
                p.WEF_DATE = Convert.ToDateTime(txtWEF_DATE.Text);
                p.CreatedBy = App_code.GlobalInfo.Userid;
                p.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
                p.ModifiedBy = App_code.GlobalInfo.Userid;
                p.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");
                p.flag = "Update";
                int Result = 0;
                Result = pd.InsertRawMilkTarrif(p);
                if (Result > 0)
                {
                    //lbltital.Text = "Add Route";
                    divDanger.Visible = false;
                    divwarning.Visible = false;
                    divSusccess.Visible = true;
                    lblSuccess.Text = "Raw Milk Tarrif Record Updated  Successfully";
                    ClearTextBox();
                    BindRawMilkTerrifList();
                    pnlError.Update();
                    btnAddRaw.Visible = true;
                    btnupdateRaw.Visible = false;
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
            else
            {
                divDanger.Visible = false;
                divwarning.Visible = true;
                divSusccess.Visible = false;
                lblwarning.Text = "TSL must be a less than TSH";
                pnlError.Update();
            }
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Tabs/Procurement/RawMilkTariff.aspx");

        }

        protected void Category_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ProcurementData pd = new ProcurementData();
            //DataSet DS = new DataSet();
            //StringBuilder sb = new StringBuilder();
            //DS = pd.GetAllRawMilkTarrifDetails();
            //if (!Comman.Comman.IsDataSetEmpty(DS))
            //{
            //    foreach(DataRow row in DS.Tables[0].Rows)
            //    {
            //        if (row["CategoryName"].ToString() == Category.SelectedItem.Text.ToString())
            //        {
            //            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Raw Milk Tariff for this category already assigned')", true);
            //            Category.ClearSelection();
            //        }
            //    }
            //}
        }
    }
}