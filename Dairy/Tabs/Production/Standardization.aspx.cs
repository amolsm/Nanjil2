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
using Bussiness;
using Bussiness.Production;
using System.Text;
using Comman;
using Dairy.App_code;
using Dairy;

namespace Dairy.Tabs.Production
{
    public partial class Standardization : System.Web.UI.Page
    {
        MStandardization stdmdata;
        BStandardization stdbdata;
        DataSet DS = new DataSet();
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //GetStandardizationDetails();
                BindDropDwon();
                txtDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                txtSearchDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                //txtStandardizationStartTime.Text = Convert.ToString(DateTime.Now.ToString("HH:mm"));
                //txtDate.ReadOnly = true;
                txtBatchNo.ReadOnly = true;
                //dpShiftDetails.Enabled = false;
                hideStdDone.Visible = true;
                txtStatushide.Visible = false;
                dpStandardDone.Items.FindByText("Release").Enabled = false;
                dpStandardDone.Items.FindByText("Hold").Enabled = false;
                //txtStatus.Text = "Pending";
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
            dpStandardDone.DataSource = DS;
            dpStandardDone.DataBind();
            dpStandardDone.Items.FindByText("Release").Enabled = false;
            dpStandardDone.Items.FindByText("Hold").Enabled = false;
            dpStandardDone.Items.FindByText("Yes").Enabled = false;
            dpStandardDone.Items.FindByText("No").Enabled = false;
            dpStandardDone.Items.Insert(0, new ListItem("--Status--", "0"));
        }

        protected void rpStandardizationList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            HiddenField hdfID = e.Item.FindControl("hfQualityId") as HiddenField;
            
            divDanger.Visible = false;
            divwarning.Visible = false;
            divSusccess.Visible = false;
            pnlError.Update();
            int RMRId = 0;
            RMRId = Convert.ToInt32(e.CommandArgument);
            switch (e.CommandName)
            {
                case ("Edit"):
                    {
                        lblHeaderTab.Text = "Edit Standardization Details";
                        hId.Value = RMRId.ToString();
                 
                        RMRId = Convert.ToInt32(hId.Value);
                        GetStandardizationDetails(RMRId);

                        //if(txtStandardizationStartTime.Text==string.Empty && txtStandardizationEndTime.Text==string.Empty)
                        if(dpStandardDone.SelectedItem.Text=="Pending")
                        {
                            btnUpdateProductindetail.Visible = false;
                            btnAddProductionInfo.Visible = true;
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "sel3", "$('#bx1').removeClass('collapsed-box');", true);
                        }
                        else
                        {
                            btnUpdateProductindetail.Visible = true;
                            btnAddProductionInfo.Visible = false;
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "sel3", "$('#bx1').removeClass('collapsed-box');", true);
                        }
                        //btnAddProductionInfo.Visible = true;
                        //btnUpdateProductindetail.Visible = true;
                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }
            }
        }

        private void BindRepeater(DataTable dt)
        {
            rpStandardizationList.DataSource = dt;
            rpStandardizationList.DataBind();

            if (dt.Rows.Count == 0)
            {
                Control FooterTemplate = rpStandardizationList.Controls[rpStandardizationList.Controls.Count - 1].Controls[0];
                FooterTemplate.FindControl("trEmpty").Visible = true;
            }

        }

        public void GetStandardizationDetails(int RMRId)
        {
            DataSet DS = new DataSet();
            stdbdata = new BStandardization();
            DS = stdbdata.GetStandardizationDetailsbyId(RMRId);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                //string DATE = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["QualityDate"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["QualityDate"].ToString();
                ////sky
                //DateTime date1 = Convert.ToDateTime(DATE, System.Globalization.CultureInfo.GetCultureInfo("ur-PK").DateTimeFormat);
                //txtDate.Text = (Convert.ToDateTime(date1).ToString("yyyy-MM-dd"));

                txtDate.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["QualityDate"].ToString()) ? string.Empty : Convert.ToDateTime(DS.Tables[0].Rows[0]["QualityDate"]).ToString("yyyy-MM-dd");
                txtBatchNo.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["BatchNo"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["BatchNo"].ToString();
                txtSiloNo.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["SiloNo"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["SiloNo"].ToString();
                txtRCMQty.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["RCMQuantity"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["RCMQuantity"].ToString();
                dpShiftDetails.ClearSelection();
                try
                {
                   dpShiftDetails.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["StdShiftId"]).ToString()).Selected = true;
                }
                catch(InvalidCastException)
                {
                    dpShiftDetails.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["QualityShiftId"]).ToString()).Selected = true;
                }
                   
                txtFat.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Fat"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Fat"].ToString();
                txtSnf.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["SNF"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["SNF"].ToString();
                txtRCMQty.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["RCMQuantity"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["RCMQuantity"].ToString();
                if (DS.Tables[0].Rows[0]["StandardizationStartTime"].ToString() =="")
                {
                    txtStandardizationStartTime.Text = Convert.ToString(DateTime.Now.ToString("HH:mm"));
                }
                else
                {
                    txtStandardizationStartTime.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["StandardizationStartTime"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["StandardizationStartTime"].ToString();
                  
                }
                txtStandardizationEndTime.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["StandardizationEndTime"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["StandardizationEndTime"].ToString();
                txtCuttingMilkQuantity.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["CuttingMilkQuantity"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["CuttingMilkQuantity"].ToString();
                txtCuttingMilkFat.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["CuttingMilkFat"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["CuttingMilkFat"].ToString();
                txtCuttingMilkSnf.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["CuttingMilkSNF"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["CuttingMilkSNF"].ToString();
                txtSkim.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Skim"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Skim"].ToString();
                txtSkimFat.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["SkimFAT"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["SkimFAT"].ToString();
                txtSkimSnf.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["SkimSNF"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["SkimSNF"].ToString();
                txtRcm.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["RCM"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["RCM"].ToString();
                txtSmpAdd.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["SMP"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["SMP"].ToString();
                txtCreamAdd.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["CreamAdd"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["CreamAdd"].ToString();
                txtCreamProduced.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["CreamProduced"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["CreamProduced"].ToString();
                txtTotalQuantity.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Qty"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Qty"].ToString();
                txtTypeOfMilk.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["TypeOfMilk"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["TypeOfMilk"].ToString();
                txtRemarks.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Remarks"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Remarks"].ToString();
                if (DS.Tables[0].Rows[0]["StatusName"].ToString() != null)
                {
                    txtStatus.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["StatusName"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["StatusName"].ToString();
                }
                else
                {
                    txtStatus.Text = dpStandardDone.SelectedItem.Text;
                }
                dpStandardDone.ClearSelection();
                try
                {
                    if (Convert.ToInt32(DS.Tables[0].Rows[0]["StandardizationStatusId"]).ToString() !="")
                    {
                        dpStandardDone.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["StandardizationStatusId"]).ToString()).Selected = true;
                    }
                  
                }
                catch(InvalidCastException)
                {
                    dpStandardDone.SelectedIndex = 2;
                }
            }
        }

        public void GetStandardizationDetails(RMRecieve R)
        {

            stdbdata = new BStandardization();
            DataSet DS = new DataSet();
            DS = stdbdata.GetStandardizationDetails(R);

            if (!Comman.Comman.IsDataSetEmpty(DS))
            {

                rpStandardizationList.DataSource = DS;
                rpStandardizationList.DataBind();
            }
            else if ( DS.Tables[0].Rows.Count == 0)
            {

                //this.BindRepeater(dt);
                rpStandardizationList.DataSource = DS;
                rpStandardizationList.DataBind();
            }


        }

        protected void btnAddProductionInfo_Click(object sender, EventArgs e)
        {

            stdmdata = new MStandardization();
            stdbdata = new BStandardization();
            int Result = 0;
            stdmdata.StdId = 0;
            stdmdata.RMRId = string.IsNullOrEmpty(hId.Value) ? 0 : Convert.ToInt32(hId.Value);
            foreach (RepeaterItem item in rpStandardizationList.Items)
            {
                HiddenField hdfID = item.FindControl("hfQualityId") as HiddenField;
                if (hdfID != null)
                {
                    stdmdata.QualityId = string.IsNullOrEmpty(hdfID.Value) ? 0 : Convert.ToInt32(hdfID.Value);
                }
            }
                stdmdata.StandardDate = DateTime.Now.ToString();
                stdmdata.StdShiftId = Convert.ToInt32(dpShiftDetails.SelectedItem.Value);
                stdmdata.SiloNo = string.IsNullOrEmpty(txtSiloNo.Text) ? string.Empty : txtSiloNo.Text;
                stdmdata.RCMQuantity = string.IsNullOrEmpty(txtRCMQty.Text) ? 0 : Convert.ToDouble(txtRCMQty.Text);
                stdmdata.StandardizationStartTime = string.IsNullOrEmpty(txtStandardizationStartTime.Text) ? string.Empty : txtStandardizationStartTime.Text;
                stdmdata.StandardizationEndTime = string.IsNullOrEmpty(txtStandardizationEndTime.Text) ? string.Empty : txtStandardizationEndTime.Text;
                stdmdata.CuttingMilkQuantity = string.IsNullOrEmpty(txtCuttingMilkQuantity.Text) ? 0 : Convert.ToDouble(txtCuttingMilkQuantity.Text);
                stdmdata.CuttingMilkFAT = string.IsNullOrEmpty(txtCuttingMilkFat.Text) ? 0 : Convert.ToDouble(txtCuttingMilkFat.Text);
                stdmdata.CuttingMilkSNF = string.IsNullOrEmpty(txtCuttingMilkSnf.Text) ? 0 : Convert.ToDouble(txtCuttingMilkSnf.Text);
                stdmdata.Skim = string.IsNullOrEmpty(txtSkim.Text) ? 0 : Convert.ToDouble(txtSkim.Text);
                stdmdata.SkimFAT = string.IsNullOrEmpty(txtSkimFat.Text) ? 0 : Convert.ToDouble(txtSkimFat.Text);
                stdmdata.SkimSNF = string.IsNullOrEmpty(txtSkimSnf.Text) ? 0 : Convert.ToDouble(txtSkimSnf.Text);
                stdmdata.RCM = string.IsNullOrEmpty(txtRcm.Text) ? 0 : Convert.ToDouble(txtRcm.Text);
                stdmdata.SMP = string.IsNullOrEmpty(txtRcm.Text) ? 0 : Convert.ToDouble(txtRcm.Text);
                stdmdata.CreamAdd = string.IsNullOrEmpty(txtCreamAdd.Text) ? 0 : Convert.ToDouble(txtCreamAdd.Text);
                stdmdata.CreamProduced = string.IsNullOrEmpty(txtCreamAdd.Text) ? 0 : Convert.ToDouble(txtCreamAdd.Text);
                //stdmdata.TotalQuantity = string.IsNullOrEmpty(txtTotalQuantity.Text) ? 0 : Convert.ToDouble(txtTotalQuantity.Text);
                //stdmdata.TypeOfMilk = string.IsNullOrEmpty(txtTypeOfMilk.Text) ? string.Empty : txtTypeOfMilk.Text;
                stdmdata.Remarks = string.IsNullOrEmpty(txtRemarks.Text) ? string.Empty : txtRemarks.Text; 
                stdmdata.StandardizationStatusId = Convert.ToInt32(dpStandardDone.SelectedItem.Value);
                stdmdata.flag = "Insert";
                Result = stdbdata.StandardizationData(stdmdata);

                if (Result > 0)
                {
                    divDanger.Visible = false;
                    divwarning.Visible = false;
                    divSusccess.Visible = true;
                    lblSuccess.Text = "Data Added  Successfully";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "sel3", "$('#bx1').addClass('collapsed-box');", true);
                pnlError.Update();
                //string dates;
                //dates = string.IsNullOrEmpty(txtSearchDate.Text) ? string.Empty : Convert.ToDateTime(txtSearchDate.Text).ToString("dd-MM-yyyy");
                RMRecieve R = new RMRecieve();
                R.RMRDate = Convert.ToDateTime(txtSearchDate.Text);
                GetStandardizationDetails(R);
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
        
        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void btnUpdateProductindetail_Click(object sender, EventArgs e)
        {
            stdmdata = new MStandardization();
            stdbdata = new BStandardization();
            int Result = 0;
            stdmdata.RMRId = string.IsNullOrEmpty(hId.Value) ? 0 : Convert.ToInt32(hId.Value);
            stdmdata.StandardDate = DateTime.Now.ToString();
            stdmdata.StdShiftId = Convert.ToInt32(dpShiftDetails.SelectedItem.Value);
            stdmdata.SiloNo = string.IsNullOrEmpty(txtSiloNo.Text) ? string.Empty : txtSiloNo.Text;
            stdmdata.RCMQuantity = string.IsNullOrEmpty(txtRCMQty.Text) ? 0 : Convert.ToDouble(txtRCMQty.Text);
            stdmdata.StandardizationStartTime = txtStandardizationStartTime.Text;
            stdmdata.StandardizationEndTime = txtStandardizationEndTime.Text;
            stdmdata.CuttingMilkQuantity = string.IsNullOrEmpty(txtCuttingMilkQuantity.Text) ? 0 : Convert.ToDouble(txtCuttingMilkQuantity.Text);
            stdmdata.CuttingMilkFAT = string.IsNullOrEmpty(txtCuttingMilkFat.Text) ? 0 : Convert.ToDouble(txtCuttingMilkFat.Text);
            stdmdata.CuttingMilkSNF = string.IsNullOrEmpty(txtCuttingMilkSnf.Text) ? 0 : Convert.ToDouble(txtCuttingMilkSnf.Text);
            stdmdata.Skim = string.IsNullOrEmpty(txtSkim.Text) ? 0 : Convert.ToDouble(txtSkim.Text);
            stdmdata.SkimFAT = string.IsNullOrEmpty(txtSkimFat.Text) ? 0 : Convert.ToDouble(txtSkimFat.Text);
            stdmdata.SkimSNF = string.IsNullOrEmpty(txtSkimSnf.Text) ? 0 : Convert.ToDouble(txtSkimSnf.Text);
            stdmdata.RCM = string.IsNullOrEmpty(txtRcm.Text) ? 0 : Convert.ToDouble(txtRcm.Text);
            stdmdata.SMP = string.IsNullOrEmpty(txtRcm.Text) ? 0 : Convert.ToDouble(txtRcm.Text);
            stdmdata.CreamAdd = string.IsNullOrEmpty(txtCreamAdd.Text) ? 0 : Convert.ToDouble(txtCreamAdd.Text);
            stdmdata.CreamProduced = string.IsNullOrEmpty(txtCreamAdd.Text) ? 0 : Convert.ToDouble(txtCreamAdd.Text);
            stdmdata.Remarks = txtRemarks.Text;
            stdmdata.StandardizationStatusId = Convert.ToInt32(dpStandardDone.SelectedItem.Value);
            //stdmdata.Custom1 = txtCustom1.Text;
            //stdmdata.Custom2 = txtCustom2.Text;
            //stdmdata.Custom3 = txtCustom3.Text;
            //stdmdata.Custom4 = txtCustom4.Text;
            //stdmdata.Custom5 = txtCustom5.Text;
            stdmdata.flag = "Update";
            Result = stdbdata.StandardizationData(stdmdata);

            if (Result > 0)
            {
                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Data Updated  Successfully";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "sel3", "$('#bx1').addClass('collapsed-box');", true);
                pnlError.Update();
                //string dates;
                //dates = string.IsNullOrEmpty(txtSearchDate.Text) ? string.Empty : Convert.ToDateTime(txtSearchDate.Text).ToString("dd-MM-yyyy");
                RMRecieve R = new RMRecieve();
                R.RMRDate = Convert.ToDateTime(txtSearchDate.Text);
                GetStandardizationDetails(R);
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
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                //string dates = Convert.ToDateTime(txtSearchDate.Text).ToString("dd-MM-yyyy");
                //GetStandardizationDetails(dates);
                RMRecieve R = new RMRecieve();
                R.RMRDate = Convert.ToDateTime(txtSearchDate.Text);
                GetStandardizationDetails(R);

            }
            catch (Exception)
            {
               
            }
            
        }

    }
}
    
