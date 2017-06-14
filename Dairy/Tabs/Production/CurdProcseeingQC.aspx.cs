using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using Model.Production;
using System.Data;
using DataAccess;
using Bussiness.Production;
using System.Text;
using Comman;
using Dairy.App_code;
using Dairy;
using Bussiness;

namespace Dairy.Tabs.Production
{
    public partial class CurdProcseeingQC : System.Web.UI.Page
    {
        MCurdProcessingQC MCQCdata;
        BCurdProcessingQC BCQCdata;
        DataSet DS = new DataSet();
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDwon();
                //GetCurdProcessQCDetails();
                txtCurdQCDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                txtSearchDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                dpQCDetails.Items.FindByText("Pending").Enabled = false;
                dpQCDetails.Items.FindByText("Re-Chilling").Enabled = false;
            }

        }
        protected void BindDropDwon()
        {
            DS = new DataSet();
            DS = BindCommanData.BindCommanDropDwon("ShiftId", "ShiftName as Name", "ShiftMaster", "IsActive =1");
            dpCurdQCShift.DataSource = DS;
            dpCurdQCShift.DataBind();
            dpCurdQCShift.Items.Insert(0, new ListItem("--Select Shift--", "0"));

            //DS = new DataSet();
            DS = BindCommanData.BindCommanDropDwon("QCId", "Status as Name", "QCDetails", "IsActive =1");
            dpQCDetails.DataSource = DS;
            dpQCDetails.DataBind();
            dpQCDetails.Items.Insert(0, new ListItem("--Select Status--", "0"));
        }

        public void GetCurdProcessQCDetails(RMRecieve R)
        {

            BCQCdata = new BCurdProcessingQC();
            DataSet DS = new DataSet();
            DS = BCQCdata.GetCurdProcessQCDetails(R);

            if (!Comman.Comman.IsDataSetEmpty(DS))
            {

                rpCurdProcessingQCList.DataSource = DS;
                rpCurdProcessingQCList.DataBind();
            }
            else
            {
                rpCurdProcessingQCList.DataSource = DS;
                rpCurdProcessingQCList.DataBind();
            }


        }
        protected void rpCurdProcessingQCList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            HiddenField hdfID = e.Item.FindControl("hfCurdId") as HiddenField;
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
                        lblHeaderTab.Text = "Edit Curd Processing QC Details";
                        hId.Value = Id.ToString();
                        Id = Convert.ToInt32(hId.Value);
                        GetCurdProcessQCDetails(Id);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "sel3", "$('#bx1').removeClass('collapsed-box');", true);
                        if (dpQCDetails.SelectedIndex ==2)
                        {
                            btnAddCurdProcessQCInfo.Visible = false;
                            btnUpdateCurdProcessQCdetail.Visible = true;
                        }
                        else
                        {
                            btnAddCurdProcessQCInfo.Visible = true;
                            btnUpdateCurdProcessQCdetail.Visible = false;
                        }
                        btnRefresh.Visible = true;

                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }
                    //case ("delete"):
                    //    {

                    //        hId.Value = Id.ToString();
                    //        Id = Convert.ToInt32(hId.Value);
                    //        DeleteRMRDetails(Id);
                    //        bindRMRList();
                    //        upMain.Update();
                    //        uprouteList.Update();
                    //        break;

                    //    }
            }
        }

        public void GetCurdProcessQCDetails(int RMRId)
        {
            DataSet DS = new DataSet();
            BCurdProcessingQC BCQCdata = new BCurdProcessingQC();
            DS = BCQCdata.GetCurdProcessQCDetails(RMRId);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                txtBatchNo.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["BatchNo"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["BatchNo"].ToString();
                if (DS.Tables[0].Rows[0]["CurdProcessDate"].ToString() == "")
                {
                    txtCurdQCDate.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["CurdProcessDate"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["CurdProcessDate"].ToString();
                }
                else
                {
                    string DATE1 = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["CurdProcessDate"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["CurdProcessDate"].ToString();
                    //sky
                    DateTime date2 = Convert.ToDateTime(DATE1, System.Globalization.CultureInfo.GetCultureInfo("ur-PK").DateTimeFormat);
                    txtCurdQCDate.Text = (Convert.ToDateTime(date2).ToString("yyyy-MM-dd"));
                }

                dpCurdQCShift.ClearSelection();
                string CurdQCShift = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["CurdQCShiftId"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["CurdQCShiftId"].ToString();
                if(CurdQCShift=="")
                {
                    dpCurdQCShift.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["CurdProcessShiftId"]).ToString()).Selected = true;
                }
               else
                {
                    dpCurdQCShift.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["CurdQCShiftId"]).ToString()).Selected = true;
                }

                txtProcessingTime.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["CurdQCProcessTime"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["CurdQCProcessTime"].ToString();
                txtSiloNo.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["CurdQCSiloNo"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["CurdQCSiloNo"].ToString();
                txtProcessQty.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["CurdQCProcessQty"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["CurdQCProcessQty"].ToString();
                txtTemperature.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["CurdQCTemp"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["CurdQCTemp"].ToString();
                txtFat.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["CurdQCFat"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["CurdQCFat"].ToString();
                txtCLR.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["CurdQCCLR"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["CurdQCCLR"].ToString();
                txtSNF.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["CurdQCSNF"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["CurdQCSNF"].ToString();
                txtAcidity.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["CurdQCAcidity"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["CurdQCAcidity"].ToString();
                txtHomEfficiency.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["HomEfficiency"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["HomEfficiency"].ToString();
                txtTaste.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["CurdQCTaste"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["CurdQCTaste"].ToString();
                txtSmell.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["CurdQCSmell"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["CurdQCSmell"].ToString();
                txtColor.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["CurdQCColor"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["CurdQCColor"].ToString();
                txtMBRTStartTime.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["CurdQCMBRTStartTime"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["CurdQCMBRTStartTime"].ToString();
                txtMBRTEndTime.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["CurdQCMBRTEndTime"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["CurdQCMBRTEndTime"].ToString();
                txtMBRTTotalHours.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["CurdQCMBRTTotalHours"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["CurdQCMBRTTotalHours"].ToString();
                txtPhosphataseStartTime.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["PhosphataseStartTime"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["PhosphataseStartTime"].ToString();
                txtPhosphataseEndTime.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["PhosphataseEndTime"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["PhosphataseEndTime"].ToString();
                txtPhosphataseTotalHours.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["PhosphataseTotalHours"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["PhosphataseTotalHours"].ToString();

                dpQCDetails.ClearSelection();
                string QCDetails = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["QCId"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["QCId"].ToString();
                if(QCDetails=="")
                {
                    dpQCDetails.SelectedIndex = 0;
                }
                else
                {
                    dpQCDetails.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["QCId"]).ToString()).Selected = true;
                }
              
            } 

        }

        protected void btnAddCurdProcessQCInfo_Click(object sender, EventArgs e)
        {
            MCQCdata = new MCurdProcessingQC();
            BCQCdata = new BCurdProcessingQC();
            int Result = 0;
            MCQCdata.CurdQCId = 0;

            
            foreach (RepeaterItem item in rpCurdProcessingQCList.Items)
            {
                HiddenField hdfID = item.FindControl("hfCurdId") as HiddenField;
                if (hdfID != null)
                {
                    MCQCdata.CurdId = string.IsNullOrEmpty(hdfID.Value) ? 0 : Convert.ToInt32(hdfID.Value);
                }
            }
            MCQCdata.RMRId = string.IsNullOrEmpty(hId.Value) ? 0 : Convert.ToInt32(hId.Value);
            MCQCdata.BatchNo = string.IsNullOrEmpty(txtBatchNo.Text) ? string.Empty : txtBatchNo.Text; 
            MCQCdata.CurdQCDate = Convert.ToDateTime(txtCurdQCDate.Text).ToString("dd-MM-yyyy");
            MCQCdata.CurdQCShiftId = Convert.ToInt32(dpCurdQCShift.SelectedItem.Value); ;
            MCQCdata.CurdQCProcessTime = string.IsNullOrEmpty(txtProcessingTime.Text) ? string.Empty : txtProcessingTime.Text;
            MCQCdata.CurdQCSiloNo = Convert.ToInt32(txtSiloNo.Text);
            MCQCdata.CurdQCProcessQty = string.IsNullOrEmpty(txtProcessQty.Text) ? 0 : Convert.ToDouble(txtProcessQty.Text);
            MCQCdata.CurdQCTemp = string.IsNullOrEmpty(txtTemperature.Text) ? 0 : Convert.ToDouble(txtTemperature.Text);
            MCQCdata.CurdQCFat = string.IsNullOrEmpty(txtFat.Text) ? 0 : Convert.ToDouble(txtFat.Text);
            MCQCdata.CurdQCCLR = string.IsNullOrEmpty(txtCLR.Text) ? 0 : Convert.ToDouble(txtCLR.Text);
            MCQCdata.CurdQCSNF = string.IsNullOrEmpty(txtSNF.Text) ? 0 : Convert.ToDouble(txtSNF.Text);
            MCQCdata.CurdQCAcidity = string.IsNullOrEmpty(txtAcidity.Text) ? 0 : Convert.ToDouble(txtAcidity.Text);
            MCQCdata.HomEfficiency = string.IsNullOrEmpty(txtHomEfficiency.Text) ? string.Empty : txtHomEfficiency.Text;
            MCQCdata.CurdQCTaste = string.IsNullOrEmpty(txtTaste.Text) ? string.Empty : txtTaste.Text;
            MCQCdata.CurdQCSmell = string.IsNullOrEmpty(txtSmell.Text) ? string.Empty : txtSmell.Text;
            MCQCdata.CurdQCColor = string.IsNullOrEmpty(txtColor.Text) ? string.Empty : txtColor.Text;
            MCQCdata.PhosphataseStartTime= string.IsNullOrEmpty(txtPhosphataseStartTime.Text) ? string.Empty : txtPhosphataseStartTime.Text;
            MCQCdata.PhosphataseEndTime = string.IsNullOrEmpty(txtPhosphataseEndTime.Text) ? string.Empty : txtPhosphataseEndTime.Text;
            MCQCdata.PhosphataseTotalHours = string.IsNullOrEmpty(txtPhosphataseTotalHours.Text) ? string.Empty : txtPhosphataseTotalHours.Text;
            MCQCdata.CurdQCMBRTStartTime = string.IsNullOrEmpty(txtMBRTStartTime.Text) ? string.Empty : txtMBRTStartTime.Text;
            MCQCdata.CurdQCMBRTEndTime = string.IsNullOrEmpty(txtMBRTEndTime.Text) ? string.Empty : txtMBRTEndTime.Text;
            MCQCdata.CurdQCMBRTTotalHours = string.IsNullOrEmpty(txtMBRTTotalHours.Text) ? string.Empty : txtMBRTTotalHours.Text;
            MCQCdata.CurdQCStatusId = Convert.ToInt32(dpQCDetails.SelectedItem.Value);
            MCQCdata.flag = "Insert";
            Result = BCQCdata.CurdProcessQCData(MCQCdata);
            if (Result > 0)
            {
                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
              
                ScriptManager.RegisterStartupScript(this, this.GetType(), "sel3", "$('#bx1').addClass('collapsed-box');", true);

                //string dates;
                //dates = string.IsNullOrEmpty(txtSearchDate.Text) ? string.Empty : Convert.ToDateTime(txtSearchDate.Text).ToString("dd-MM-yyyy");
                //GetCurdProcessQCDetails(dates);
                RMRecieve R = new RMRecieve();
                R.RMRDate = Convert.ToDateTime(txtSearchDate.Text);
                GetCurdProcessQCDetails(R);
                uprouteList.Update();
                lblSuccess.Text = "Data Added Successfully";
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

        protected void btnUpdateCurdProcessQCdetail_Click(object sender, EventArgs e)
        {
            MCQCdata = new MCurdProcessingQC();
            BCQCdata = new BCurdProcessingQC();
            int Result = 0;
           
            MCQCdata.RMRId = string.IsNullOrEmpty(hId.Value) ? 0 : Convert.ToInt32(hId.Value);
            MCQCdata.BatchNo = string.IsNullOrEmpty(txtBatchNo.Text) ? string.Empty : txtBatchNo.Text;
            MCQCdata.CurdQCDate = Convert.ToDateTime(txtCurdQCDate.Text).ToString("dd-MM-yyyy");
            MCQCdata.CurdQCShiftId = Convert.ToInt32(dpCurdQCShift.SelectedItem.Value); 
            MCQCdata.CurdQCProcessTime = string.IsNullOrEmpty(txtProcessingTime.Text) ? string.Empty : txtProcessingTime.Text;
            MCQCdata.CurdQCSiloNo = Convert.ToInt32(txtSiloNo.Text);
            MCQCdata.CurdQCProcessQty = string.IsNullOrEmpty(txtProcessQty.Text) ? 0 : Convert.ToDouble(txtProcessQty.Text);
            MCQCdata.CurdQCTemp = string.IsNullOrEmpty(txtTemperature.Text) ? 0 : Convert.ToDouble(txtTemperature.Text);
            MCQCdata.CurdQCFat = string.IsNullOrEmpty(txtFat.Text) ? 0 : Convert.ToDouble(txtFat.Text);
            MCQCdata.CurdQCCLR = string.IsNullOrEmpty(txtCLR.Text) ? 0 : Convert.ToDouble(txtCLR.Text);
            MCQCdata.CurdQCSNF = string.IsNullOrEmpty(txtSNF.Text) ? 0 : Convert.ToDouble(txtSNF.Text);
            MCQCdata.CurdQCAcidity = string.IsNullOrEmpty(txtAcidity.Text) ? 0 : Convert.ToDouble(txtAcidity.Text);
            MCQCdata.HomEfficiency = string.IsNullOrEmpty(txtHomEfficiency.Text) ? string.Empty : txtHomEfficiency.Text;
            MCQCdata.CurdQCTaste = string.IsNullOrEmpty(txtTaste.Text) ? string.Empty : txtTaste.Text;
            MCQCdata.CurdQCSmell = string.IsNullOrEmpty(txtSmell.Text) ? string.Empty : txtSmell.Text;
            MCQCdata.CurdQCColor = string.IsNullOrEmpty(txtColor.Text) ? string.Empty : txtColor.Text;
            MCQCdata.PhosphataseStartTime = string.IsNullOrEmpty(txtPhosphataseStartTime.Text) ? string.Empty : txtPhosphataseStartTime.Text;
            MCQCdata.PhosphataseEndTime = string.IsNullOrEmpty(txtPhosphataseEndTime.Text) ? string.Empty : txtPhosphataseEndTime.Text;
            MCQCdata.PhosphataseTotalHours = string.IsNullOrEmpty(txtPhosphataseTotalHours.Text) ? string.Empty : txtPhosphataseTotalHours.Text;
            MCQCdata.CurdQCMBRTStartTime = string.IsNullOrEmpty(txtMBRTStartTime.Text) ? string.Empty : txtMBRTStartTime.Text;
            MCQCdata.CurdQCMBRTEndTime = string.IsNullOrEmpty(txtMBRTEndTime.Text) ? string.Empty : txtMBRTEndTime.Text;
            MCQCdata.CurdQCMBRTTotalHours = string.IsNullOrEmpty(txtMBRTTotalHours.Text) ? string.Empty : txtMBRTTotalHours.Text;
            MCQCdata.CurdQCStatusId = Convert.ToInt32(dpQCDetails.SelectedItem.Value);
            MCQCdata.flag = "Update";
            Result = BCQCdata.CurdProcessQCData(MCQCdata);
            if (Result > 0)
            {
                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
               
                ScriptManager.RegisterStartupScript(this, this.GetType(), "sel3", "$('#bx1').addClass('collapsed-box');", true);
                //string dates;
                //dates = string.IsNullOrEmpty(txtSearchDate.Text) ? string.Empty : Convert.ToDateTime(txtSearchDate.Text).ToString("dd-MM-yyyy");
                //GetCurdProcessQCDetails(dates);
                RMRecieve R = new RMRecieve();
                R.RMRDate = Convert.ToDateTime(txtSearchDate.Text);
                GetCurdProcessQCDetails(R);
                uprouteList.Update();
                lblSuccess.Text = "Data Updated Successfully";
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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try {
                //string dates = Convert.ToDateTime(txtSearchDate.Text).ToString("dd-MM-yyyy");
                //GetCurdProcessQCDetails(dates);
                RMRecieve R = new RMRecieve();
                ProductionData PD = new ProductionData();
                R.RMRDate = Convert.ToDateTime(txtSearchDate.Text);
                GetCurdProcessQCDetails(R);
            }
            catch (Exception) { }
            }
    }
}