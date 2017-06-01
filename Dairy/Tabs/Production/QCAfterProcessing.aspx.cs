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
    public partial class QCAfterProcessing : System.Web.UI.Page
    {
        MQCAfterProcessing mqcp;
        BQCAfterProcessing bqcp;
        DataSet DS = new DataSet();
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDwon();

                //GetQCProcssingDetails();
                //txtDate.Text = Convert.ToString(DateTime.Now.ToString("dd-MM-yyyy"));
                txtDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                txtSearchDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
            }
               
        }
        protected void BindDropDwon()
        {
            DS = new DataSet();
            DS = BindCommanData.BindCommanDropDwon("ShiftId", "ShiftName as Name", "ShiftDetails", "IsActive =1");
            dpShiftDetails.DataSource = DS;
            dpShiftDetails.DataBind();
            dpShiftDetails.Items.Insert(0, new ListItem("--Select Shift--", "0"));

            DS = BindCommanData.BindCommanDropDwon("StatusId", "StatusName as StatusName", "Prod_StatusDetails", "IsActive =1");
            dpAfterProcessingStatus.DataSource = DS;
            dpAfterProcessingStatus.DataBind();
            dpAfterProcessingStatus.Items.FindByText("Release").Enabled = false;
            dpAfterProcessingStatus.Items.FindByText("Hold").Enabled = false;
            dpAfterProcessingStatus.Items.FindByText("Yes").Enabled = false;
            dpAfterProcessingStatus.Items.FindByText("No").Enabled = false;
            dpAfterProcessingStatus.Items.Insert(0, new ListItem("--Status--", "0"));
        }

        protected void GetQCProcssingDetails(RMRecieve R)
        {
            bqcp = new BQCAfterProcessing();
            DataSet DS = new DataSet();
            DS = bqcp.GetQCProcssingDetails(R);

            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                rpQCAfterProcessingList.DataSource = DS;
                rpQCAfterProcessingList.DataBind();
            }
            else
            {
                rpQCAfterProcessingList.DataSource = DS;
                rpQCAfterProcessingList.DataBind();
            }
        }
        protected void rpQCAfterProcessingList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
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
                        lblHeaderTab.Text = "Edit PasteurizationProcess Details";
                        hId.Value = RMRId.ToString();
                        RMRId = Convert.ToInt32(hId.Value);
                        GetQCProcssingDetails(RMRId);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "sel3", "$('#bx1').removeClass('collapsed-box');", true);
                        if (dpAfterProcessingStatus.SelectedIndex==1)
                        {
                            btnAdd.Visible = false;
                            btnUpdate.Visible = true;
                        }
                        else
                        {
                            btnAdd.Visible = true;
                            btnUpdate.Visible = false;

                        }
                    }

                    btnRefresh.Visible = true;
                    upMain.Update();
                    uprouteList.Update();
                    break;
            }
        }

        protected void GetQCProcssingDetails(int RMRId)
        {
            DataSet DS = new DataSet();
            bqcp = new BQCAfterProcessing();
            DS = bqcp.GetQCProcssingDetailsById(RMRId);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                txtBatchCode.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["BatchCode"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["BatchCode"].ToString();
                txtTemperature.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Temperature"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Temperature"].ToString();
                txtOrganolepticTestForSmell.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Smell"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Smell"].ToString();
                txtOrganolepticTestForTaste.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Color"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Color"].ToString();
                txtOrganolepticTestForColour.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Taste"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Taste"].ToString();
                txtAcidity.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Acidity"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Acidity"].ToString();
                txtMBRTStartTime.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["MBRTStartTime"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["MBRTStartTime"].ToString();
                txtMBRTEndTime.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["MBRTEndTime"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["MBRTEndTime"].ToString();
                txtMBRTTotalHours.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["TotalHours"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["TotalHours"].ToString();
                txtFAT.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Fat"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Fat"].ToString();
                txtCLR.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["CLR"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["CLR"].ToString();
                txtSNF.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["SNF"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["SNF"].ToString();
                txtProcessingTime.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["ProcessingTime"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["ProcessingTime"].ToString();
                txtSiloNo.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["SiloNo"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["SiloNo"].ToString();
                txtProcessQty.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["ProcessedQty"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["ProcessedQty"].ToString();
                txtTemperature.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["ProcessTemperature"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["ProcessTemperature"].ToString();
                txtPhosphataseStartingTime.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["PhosStartTime"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["PhosStartTime"].ToString();
                txtPhosphataseEndTime.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["PhosEndTime"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["PhosEndTime"].ToString();
                txtPhosphatasetotalhrs.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["PhosTotalHrs"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["PhosTotalHrs"].ToString();
                txtHomEfficiency.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["HomEfficiency"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["HomEfficiency"].ToString();
                dpShiftDetails.ClearSelection();
                string Shift = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["APQCShiftId"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["APQCShiftId"].ToString();
                if (Shift == "")
                {
                    dpShiftDetails.SelectedIndex = 0;
                }
                else
                {
                    dpShiftDetails.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["APQCShiftId"]).ToString()).Selected = true;
                }

               
                dpAfterProcessingStatus.ClearSelection();
                string AfterProcessingStatus = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["AfterProcessingStatusId"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["AfterProcessingStatusId"].ToString();
                if(AfterProcessingStatus=="")
                {
                    dpAfterProcessingStatus.SelectedIndex = 0;
                }
                else
                {
                    dpAfterProcessingStatus.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["AfterProcessingStatusId"]).ToString()).Selected = true;
                }
               
            }
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            mqcp = new MQCAfterProcessing();
            bqcp = new BQCAfterProcessing();
            int Result = 0;
            mqcp.APQCId = 0;
            mqcp.RMRId = string.IsNullOrEmpty(hId.Value) ? 0 : Convert.ToInt32(hId.Value);
            mqcp.BatchCode = string.IsNullOrEmpty(txtBatchCode.Text) ? string.Empty : txtBatchCode.Text;
            mqcp.APQCDate = Convert.ToDateTime(txtDate.Text).ToString("dd-MM-yyyy");
            mqcp.APQCShiftId = Convert.ToInt32(dpShiftDetails.SelectedItem.Value);
            mqcp.ProcessingTime = string.IsNullOrEmpty(txtProcessingTime.Text) ? string.Empty : txtProcessingTime.Text;
            mqcp.SiloNo = string.IsNullOrEmpty(txtSiloNo.Text) ? 0 : Convert.ToInt32(txtSiloNo.Text);
            mqcp.ProcessedQty = string.IsNullOrEmpty(txtProcessQty.Text) ? 0 : Convert.ToDouble(txtProcessQty.Text);
            mqcp.ProcessTemperature = string.IsNullOrEmpty(txtTemperature.Text) ? 0 : Convert.ToDouble(txtTemperature.Text);
            mqcp.OrganoSmell = string.IsNullOrEmpty(txtOrganolepticTestForSmell.Text) ? string.Empty : txtOrganolepticTestForSmell.Text;
            mqcp.OrganoTaste = string.IsNullOrEmpty(txtOrganolepticTestForTaste.Text) ? string.Empty : txtOrganolepticTestForTaste.Text;
            mqcp.OrganoColor = string.IsNullOrEmpty(txtOrganolepticTestForColour.Text) ? string.Empty : txtOrganolepticTestForColour.Text;
            mqcp.Acidity = string.IsNullOrEmpty(txtAcidity.Text) ? 0 : Convert.ToDouble(txtAcidity.Text);
            mqcp.PhosStartTime = string.IsNullOrEmpty(txtPhosphataseStartingTime.Text) ? string.Empty : txtPhosphataseStartingTime.Text;
            mqcp.PhosEndTime = string.IsNullOrEmpty(txtPhosphataseEndTime.Text) ? string.Empty : txtPhosphataseEndTime.Text;
            mqcp.PhosTotalHrs = string.IsNullOrEmpty(txtPhosphatasetotalhrs.Text) ? string.Empty : txtPhosphatasetotalhrs.Text;
            mqcp.MBRTStartTime = string.IsNullOrEmpty(txtMBRTStartTime.Text) ? string.Empty : txtMBRTStartTime.Text;
            mqcp.MBRTEndTime = string.IsNullOrEmpty(txtMBRTEndTime.Text) ? string.Empty : txtMBRTEndTime.Text;
            mqcp.MBRTTotalHrs = string.IsNullOrEmpty(txtMBRTTotalHours.Text) ? string.Empty : txtMBRTTotalHours.Text;
            mqcp.Fat = string.IsNullOrEmpty(txtFAT.Text) ? 0 : Convert.ToDouble(txtFAT.Text);
            mqcp.SNF = string.IsNullOrEmpty(txtSNF.Text) ? 0 : Convert.ToDouble(txtSNF.Text);
            mqcp.CLR = string.IsNullOrEmpty(txtCLR.Text) ? 0 : Convert.ToDouble(txtCLR.Text);
            mqcp.HomEfficiency = string.IsNullOrEmpty(txtHomEfficiency.Text) ? string.Empty : txtHomEfficiency.Text;
            mqcp.AfterProcessingStatusId = Convert.ToInt32(dpAfterProcessingStatus.SelectedItem.Value);
            mqcp.flag = "Insert";
            Result = bqcp.AfterProcessingQcData(mqcp);
            if (Result > 0)
            {
                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
               
                ScriptManager.RegisterStartupScript(this, this.GetType(), "sel3", "$('#bx1').addClass('collapsed-box');", true);

                //string dates;
                //dates = string.IsNullOrEmpty(txtSearchDate.Text) ? string.Empty : Convert.ToDateTime(txtSearchDate.Text).ToString("dd-MM-yyyy");
                //GetQCProcssingDetails(dates);
                RMRecieve R = new RMRecieve();
                R.RMRDate = Convert.ToDateTime(txtSearchDate.Text);
                GetQCProcssingDetails(R);
                uprouteList.Update();
                lblSuccess.Text = "PasteurizationProcess Data Add  Successfully";
                pnlError.Update();
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

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            mqcp = new MQCAfterProcessing();
            bqcp = new BQCAfterProcessing();
            int Result = 0;
            mqcp.RMRId = string.IsNullOrEmpty(hId.Value) ? 0 : Convert.ToInt32(hId.Value);
            mqcp.BatchCode = string.IsNullOrEmpty(txtBatchCode.Text) ? string.Empty : txtBatchCode.Text;
            mqcp.APQCDate = Convert.ToDateTime(txtDate.Text).ToString("dd-MM-yyyy");
            mqcp.APQCShiftId = Convert.ToInt32(dpShiftDetails.SelectedItem.Value);
            mqcp.ProcessingTime = string.IsNullOrEmpty(txtProcessingTime.Text) ? string.Empty : txtProcessingTime.Text;
            mqcp.SiloNo = string.IsNullOrEmpty(txtSiloNo.Text) ? 0 : Convert.ToInt32(txtSiloNo.Text);
            mqcp.ProcessedQty = string.IsNullOrEmpty(txtProcessQty.Text) ? 0 : Convert.ToDouble(txtProcessQty.Text);
            mqcp.ProcessTemperature = string.IsNullOrEmpty(txtTemperature.Text) ? 0 : Convert.ToDouble(txtTemperature.Text);
            mqcp.OrganoSmell = string.IsNullOrEmpty(txtOrganolepticTestForSmell.Text) ? string.Empty : txtOrganolepticTestForSmell.Text;
            mqcp.OrganoTaste = string.IsNullOrEmpty(txtOrganolepticTestForTaste.Text) ? string.Empty : txtOrganolepticTestForTaste.Text;
            mqcp.OrganoColor = string.IsNullOrEmpty(txtOrganolepticTestForColour.Text) ? string.Empty : txtOrganolepticTestForColour.Text;
            mqcp.Acidity = string.IsNullOrEmpty(txtAcidity.Text) ? 0 : Convert.ToDouble(txtAcidity.Text);
            mqcp.PhosStartTime = string.IsNullOrEmpty(txtPhosphataseStartingTime.Text) ? string.Empty : txtPhosphataseStartingTime.Text;
            mqcp.PhosEndTime = string.IsNullOrEmpty(txtPhosphataseEndTime.Text) ? string.Empty : txtPhosphataseEndTime.Text;
            mqcp.PhosTotalHrs = string.IsNullOrEmpty(txtPhosphatasetotalhrs.Text) ? string.Empty : txtPhosphatasetotalhrs.Text;
            mqcp.MBRTStartTime = string.IsNullOrEmpty(txtMBRTStartTime.Text) ? string.Empty : txtMBRTStartTime.Text;
            mqcp.MBRTEndTime = string.IsNullOrEmpty(txtMBRTEndTime.Text) ? string.Empty : txtMBRTEndTime.Text;
            mqcp.MBRTTotalHrs = string.IsNullOrEmpty(txtMBRTTotalHours.Text) ? string.Empty : txtMBRTTotalHours.Text;
            mqcp.Fat = string.IsNullOrEmpty(txtFAT.Text) ? 0 : Convert.ToDouble(txtFAT.Text);
            mqcp.SNF = string.IsNullOrEmpty(txtSNF.Text) ? 0 : Convert.ToDouble(txtSNF.Text);
            mqcp.CLR = string.IsNullOrEmpty(txtCLR.Text) ? 0 : Convert.ToDouble(txtCLR.Text);
            mqcp.HomEfficiency = string.IsNullOrEmpty(txtHomEfficiency.Text) ? string.Empty : txtHomEfficiency.Text;
            mqcp.AfterProcessingStatusId = Convert.ToInt32(dpAfterProcessingStatus.SelectedItem.Value);
            mqcp.flag = "Update";
            Result = bqcp.AfterProcessingQcData(mqcp);
            if (Result > 0)
            {
                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
              
                ScriptManager.RegisterStartupScript(this, this.GetType(), "sel3", "$('#bx1').addClass('collapsed-box');", true);
               
                //string dates;
                //dates = string.IsNullOrEmpty(txtSearchDate.Text) ? string.Empty : Convert.ToDateTime(txtSearchDate.Text).ToString("dd-MM-yyyy");
                //GetQCProcssingDetails(dates);
                RMRecieve R = new RMRecieve();
                R.RMRDate = Convert.ToDateTime(txtSearchDate.Text);
                GetQCProcssingDetails(R);
                uprouteList.Update();
                lblSuccess.Text = "PasteurizationProcess Data Updated  Successfully";
                pnlError.Update();
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

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void txtBatchCode_TextChanged(object sender, EventArgs e)
        {
            string batchcode = txtBatchCode.Text;
            BQCAfterProcessing bqcp = new BQCAfterProcessing();
            DS = bqcp.GetExistingBatchCode(batchcode);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Batch Code. Already exists.')", true);
                txtBatchCode.Text = string.Empty;
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            RMRecieve R = new RMRecieve();
            ProductionData PD = new ProductionData();
            R.RMRDate = Convert.ToDateTime(txtSearchDate.Text);
            GetQCProcssingDetails(R);        }
    }
}