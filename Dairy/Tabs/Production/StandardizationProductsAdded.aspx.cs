using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using Model.Production;
using System.Data;
using DataAccess.Production;
using Bussiness.Production;
using System.Text;
using Comman;
using Dairy.App_code;
using Dairy;
using Bussiness;

namespace Dairy.Tabs.Production
{
    public partial class StandardizationProductsAdded : System.Web.UI.Page
    {
        MStandardizationProductsAdded mstdpdata;
        BStandardizationProductsAdded bstdpdata;
        DataSet DS = new DataSet();
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDwon();
                txtDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                txtSearchDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                //GetStandardizationProductsAddedDetails();
                txtBatchNo.ReadOnly = true;
                btnUpdate.Visible = false;
            }
        }

        protected void BindDropDwon()
        {
            DS = new DataSet();
            DS = BindCommanData.BindCommanDropDwon("ShiftId", "ShiftName as Name", "ShiftMaster", "IsActive =1");
            dpShiftDetails.DataSource = DS;
            dpShiftDetails.DataBind();
            dpShiftDetails.Items.Insert(0, new ListItem("--Select Shift--", "0"));

            DS = BindCommanData.BindCommanDropDwon("StatusId", "StatusName as StatusName", "Prod_StatusDetails", "IsActive =1");
            dpStdAddDone.DataSource = DS;
            dpStdAddDone.DataBind();
            dpStdAddDone.Items.FindByText("Release").Enabled = false;
            dpStdAddDone.Items.FindByText("Hold").Enabled = false;
            dpStdAddDone.Items.FindByText("Yes").Enabled = false;
            dpStdAddDone.Items.FindByText("No").Enabled = false;
            dpStdAddDone.Items.Insert(0, new ListItem("--Status--", "0"));
        }


        protected void btnAdd_Click(object sender, EventArgs e)
        {
            {

                mstdpdata = new MStandardizationProductsAdded();
                bstdpdata = new BStandardizationProductsAdded();
                int Result = 0;
                mstdpdata.StandardizationProductsAddedId = 0;
               
                mstdpdata.RMRId = string.IsNullOrEmpty(hId.Value) ? 0 : Convert.ToInt32(hId.Value);

                mstdpdata.StandardizationProductsAddedDate = Convert.ToDateTime(txtDate.Text.ToString());
                mstdpdata.StandardizationProductsAddedShiftId = Convert.ToInt32(dpShiftDetails.SelectedItem.Value);
                mstdpdata.MilkType = string.IsNullOrEmpty(txtMilkType.Text) ? string.Empty : txtMilkType.Text; 
                mstdpdata.SMPQuantity = string.IsNullOrEmpty(txtSMPQuantity.Text) ? 0 : Convert.ToDouble(txtSMPQuantity.Text);
                mstdpdata.Creamkg = string.IsNullOrEmpty(txtCreamkg.Text) ? 0 : Convert.ToDouble(txtCreamkg.Text);
                mstdpdata.Waterliters = string.IsNullOrEmpty(txtWaterliters.Text) ? 0 : Convert.ToDouble(txtWaterliters.Text);
                mstdpdata.CondensedMilk = string.IsNullOrEmpty(txtCondensedMilk.Text) ? 0 : Convert.ToDouble(txtCondensedMilk.Text);
                mstdpdata.ButterOil = string.IsNullOrEmpty(txtButterOil.Text) ? 0 : Convert.ToDouble(txtButterOil.Text);
                mstdpdata.SkimmedMilk = string.IsNullOrEmpty(txtSkimmedMilk.Text) ? 0 : Convert.ToDouble(txtSkimmedMilk.Text);
                mstdpdata.Others = string.IsNullOrEmpty(txtOthers.Text) ? string.Empty : txtOthers.Text;
                mstdpdata.StdStatusId = Convert.ToInt32(dpStdAddDone.SelectedItem.Value);
                mstdpdata.flag = "Insert";
                Result = bstdpdata.stdpdata(mstdpdata);
                if (Result > 0)
                {
                    divDanger.Visible = false;
                    divwarning.Visible = false;
                    divSusccess.Visible = true;
                    lblSuccess.Text = "Standardization Products Added Data Add  Successfully";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "sel3", "$('#bx1').addClass('collapsed-box');", true);
                    pnlError.Update();
                    //string dates;
                    //dates = string.IsNullOrEmpty(txtSearchDate.Text) ? string.Empty : Convert.ToDateTime(txtSearchDate.Text).ToString("dd-MM-yyyy");
                    RMRecieve R = new RMRecieve();
                    R.RMRDate = Convert.ToDateTime(txtDate.Text);
                    GetStandardizationProductsAddedDetails(R);
                    uprouteList.Update();
                }
                else
                {
                    divDanger.Visible = false;
                    divwarning.Visible = true;
                    divSusccess.Visible = false;
                    lblSuccess.Text = "Something went wrong plz contact site admin";
                    pnlError.Update();
                }

                //return Result;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            {

                mstdpdata = new MStandardizationProductsAdded();
                bstdpdata = new BStandardizationProductsAdded();
                int Result = 0;
                mstdpdata.StandardizationProductsAddedId = 0;
                mstdpdata.RMRId = string.IsNullOrEmpty(hId.Value) ? 0 : Convert.ToInt32(hId.Value);
                mstdpdata.StandardizationProductsAddedDate = Convert.ToDateTime(txtDate.Text.ToString());
                mstdpdata.StandardizationProductsAddedShiftId = Convert.ToInt32(dpShiftDetails.SelectedItem.Value);
                mstdpdata.MilkType = txtMilkType.Text;
                mstdpdata.SMPQuantity = string.IsNullOrEmpty(txtSMPQuantity.Text) ? 0 : Convert.ToDouble(txtSMPQuantity.Text);
                mstdpdata.Creamkg = string.IsNullOrEmpty(txtCreamkg.Text) ? 0 : Convert.ToDouble(txtCreamkg.Text);
                mstdpdata.Waterliters = string.IsNullOrEmpty(txtWaterliters.Text) ? 0 : Convert.ToDouble(txtWaterliters.Text);
                mstdpdata.CondensedMilk = string.IsNullOrEmpty(txtCondensedMilk.Text) ? 0 : Convert.ToDouble(txtCondensedMilk.Text);
                mstdpdata.ButterOil = string.IsNullOrEmpty(txtButterOil.Text) ? 0 : Convert.ToDouble(txtButterOil.Text);
                mstdpdata.SkimmedMilk = string.IsNullOrEmpty(txtSkimmedMilk.Text) ? 0 : Convert.ToDouble(txtSkimmedMilk.Text);
                mstdpdata.Others = txtOthers.Text;
                mstdpdata.StdStatusId = Convert.ToInt32(dpStdAddDone.SelectedItem.Value);
                mstdpdata.flag = "Update";
                Result = bstdpdata.stdpdata(mstdpdata);
                if (Result > 0)
                {
                    divDanger.Visible = false;
                    divwarning.Visible = false;
                    divSusccess.Visible = true;
                    lblSuccess.Text = "Standardization Products Added Data Update Successfully";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "sel3", "$('#bx1').addClass('collapsed-box');", true);
                    pnlError.Update();
                    //string dates;
                    //dates = string.IsNullOrEmpty(txtSearchDate.Text) ? string.Empty : Convert.ToDateTime(txtSearchDate.Text).ToString("dd-MM-yyyy");
                    RMRecieve R = new RMRecieve();
                    R.RMRDate = Convert.ToDateTime(txtDate.Text);
                    GetStandardizationProductsAddedDetails(R);
                    uprouteList.Update();
                }
                else
                {
                    divDanger.Visible = false;
                    divwarning.Visible = true;
                    divSusccess.Visible = false;
                    lblSuccess.Text = "Something went wrong plz contact site admin";
                    pnlError.Update();
                }

                //return Result;
            }
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void rpStandardizationProductsAdded_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            divDanger.Visible = false;
            divwarning.Visible = false;
            divSusccess.Visible = false;
            pnlError.Update();
            int Id = 0;
            Id = Convert.ToInt32(e.CommandArgument);
            switch (e.CommandName)
            {
                case ("Edit"):
                    {
                        lblHeaderTab.Text = "Edit FilmData Details";
                        hId.Value = Id.ToString();
                        Id = Convert.ToInt32(hId.Value);
                        GetStandardizationProductsAddedDetails(Id);

                        if (dpStdAddDone.SelectedIndex == 2)
                        {
                            btnAdd.Visible = true;
                            btnUpdate.Visible = false;
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "sel3", "$('#bx1').removeClass('collapsed-box');", true);
                        }
                        else if (dpStdAddDone.SelectedIndex == 1)
                        {
                            btnAdd.Visible = false;
                            btnUpdate.Visible = true;
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "sel3", "$('#bx1').removeClass('collapsed-box');", true);
                        }
                        btnRefresh.Visible = true;
                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }
            }
        }
        private void BindRepeater(DataTable dt)
        {
            rpStandardizationProductsAdded.DataSource = dt;
            rpStandardizationProductsAdded.DataBind();

            if (dt.Rows.Count == 0)
            {
                Control FooterTemplate = rpStandardizationProductsAdded.Controls[rpStandardizationProductsAdded.Controls.Count - 1].Controls[0];
                FooterTemplate.FindControl("trEmpty").Visible = true;
            }

        }

        public void GetStandardizationProductsAddedDetails(RMRecieve R)
        {
            bstdpdata = new BStandardizationProductsAdded();
            DataSet DS = new DataSet();
            DS = bstdpdata.GetStandardizationProductsAddedDetails(R);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                rpStandardizationProductsAdded.DataSource = DS;
                rpStandardizationProductsAdded.DataBind();
            }
            else if (DS.Tables[0].Rows.Count == 0)
            {

                rpStandardizationProductsAdded.DataSource = DS;
                rpStandardizationProductsAdded.DataBind();
                //this.BindRepeater(dt);

            }
        }

        public void GetStandardizationProductsAddedDetails(int RMRId)
        {
            DataSet DS = new DataSet();
            bstdpdata = new BStandardizationProductsAdded();
            DS = bstdpdata.GetStandardizationProductsAddedDetailsById(RMRId);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                string DATE = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["QualityDate"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["QualityDate"].ToString();
                //sky
                if (DATE == "")
                {
                    txtDate.Text = Convert.ToString(DateTime.Now.ToString("yyy-MM-dd"));
                }
                else
                {
                    DateTime date1 = Convert.ToDateTime(DATE, System.Globalization.CultureInfo.GetCultureInfo("ur-PK").DateTimeFormat);
                    txtDate.Text = (Convert.ToDateTime(date1).ToString("yyyy-MM-dd"));
                }
                txtBatchNo.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["BatchNo"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["BatchNo"].ToString();
                dpShiftDetails.ClearSelection();
                string Shift = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["QualityShiftId"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["QualityShiftId"].ToString();
                if (Shift == "")
                {
                    dpShiftDetails.SelectedIndex = 0;
                }
                else{
                    //dpShiftDetails.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["StandardizationProductsAddedShiftId"]).ToString()) != null)

                    dpShiftDetails.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["QualityShiftId"]).ToString()).Selected = true;
                }
                txtMilkType.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["TypeOfMilk"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["TypeOfMilk"].ToString();
                txtSMPQuantity.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["SMPQuantity"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["SMPQuantity"].ToString();
                txtCreamkg.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Creamkg"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Creamkg"].ToString();
                txtWaterliters.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Waterliters"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Waterliters"].ToString();
                txtCondensedMilk.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["CondensedMilk"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["CondensedMilk"].ToString();
                txtButterOil.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["ButterOil"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["ButterOil"].ToString();
                txtSkimmedMilk.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["SkimmedMilk"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["SkimmedMilk"].ToString();
                txtOthers.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Others"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Others"].ToString();
                dpStdAddDone.ClearSelection();
                try
                {
                    if (Convert.ToInt32(DS.Tables[0].Rows[0]["StdStatusId"]).ToString() != "")
                    {
                        dpStdAddDone.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["StdStatusId"]).ToString()).Selected = true;
                    }

                }
                catch (InvalidCastException)
                {
                    dpStdAddDone.SelectedIndex = 2;
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                //string dates = Convert.ToDateTime(txtSearchDate.Text).ToString("dd-MM-yyyy");
                //GetStandardizationProductsAddedDetails(dates);
                RMRecieve R = new RMRecieve();
                R.RMRDate = Convert.ToDateTime(txtSearchDate.Text);
                //string dates = Convert.ToDateTime(txtSearchDate.Text).ToString("dd-MM-yyyy");
                GetStandardizationProductsAddedDetails(R);
            }
            catch (Exception) { }
            
        }
    }
}