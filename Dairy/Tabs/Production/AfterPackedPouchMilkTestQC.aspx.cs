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
    public partial class AfterPackedPouchMilkTestQC : System.Web.UI.Page
    {
        MAfterPackedMilkTestQCDetails mqc;
        BAfterPackedMilkTestQCDetails bqc;
        DataSet DS = new DataSet();
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDwon();
                txtDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                txtSearchDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                //GetMilkQCDetails();
                txtBatchCode.ReadOnly = true;

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
            dpPouchMilkTestStatus.DataSource = DS;
            dpPouchMilkTestStatus.DataBind();
            dpPouchMilkTestStatus.Items.FindByText("Release").Enabled = false;
            dpPouchMilkTestStatus.Items.FindByText("Hold").Enabled = false;
            dpPouchMilkTestStatus.Items.FindByText("Yes").Enabled = false;
            dpPouchMilkTestStatus.Items.FindByText("No").Enabled = false;
            dpPouchMilkTestStatus.Items.Insert(0, new ListItem("--Status--", "0"));
        }

       

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            {

                mqc = new MAfterPackedMilkTestQCDetails();
                bqc = new BAfterPackedMilkTestQCDetails();
                int Result = 0;
                mqc.AfterPackedMilkTestQCId = 0;
                mqc.RMRId = string.IsNullOrEmpty(hId.Value) ? 0 : Convert.ToInt32(hId.Value);
                mqc.AfterPackedMilkTestQCDate = Convert.ToDateTime(txtDate.Text.ToString());
                mqc.ShiftId = Convert.ToInt32(dpShiftDetails.SelectedItem.Value);
                mqc.Source = txtSource.Text;
                mqc.Weight = string.IsNullOrEmpty(txtWeight.Text) ? 0 : Convert.ToDouble(txtWeight.Text);
                mqc.Quantity = string.IsNullOrEmpty(txtQuantity.Text) ? 0 : Convert.ToDouble(txtQuantity.Text);
                mqc.Temperature = string.IsNullOrEmpty(txtTemperature.Text) ? 0 : Convert.ToDouble(txtTemperature.Text);
                mqc.FAT = string.IsNullOrEmpty(txtFAT.Text) ? 0 : Convert.ToDouble(txtFAT.Text);
                mqc.CLR = string.IsNullOrEmpty(txtCLR.Text) ? 0 : Convert.ToDouble(txtCLR.Text);
                mqc.SNF = string.IsNullOrEmpty(txtSNF.Text) ? 0 : Convert.ToDouble(txtSNF.Text);
                mqc.QualityStartTime = txtQualityStartTime.Text;
                mqc.Hour1 = string.IsNullOrEmpty(txt1hr.Text) ? string.Empty : txt1hr.Text;
                mqc.Hours2 = string.IsNullOrEmpty(txt2hr.Text) ? string.Empty : txt2hr.Text;
                mqc.Hours3 = string.IsNullOrEmpty(txt3hr.Text) ? string.Empty : txt3hr.Text;
                mqc.Hours4 = string.IsNullOrEmpty(txt4hr.Text) ? string.Empty : txt4hr.Text;
                mqc.Hours5 = string.IsNullOrEmpty(txt5hr.Text) ? string.Empty : txt5hr.Text;
                mqc.Hours6 = string.IsNullOrEmpty(txt6hr.Text) ? string.Empty : txt6hr.Text;
                mqc.Hours7 = string.IsNullOrEmpty(txt7hr.Text) ? string.Empty : txt7hr.Text;
                mqc.Hours8 = string.IsNullOrEmpty(txt8hr.Text) ? string.Empty : txt8hr.Text;
                mqc.TotalHours = string.IsNullOrEmpty(txtTotalHours.Text) ? string.Empty : txtTotalHours.Text;
                mqc.MilkPouchQcStatusId = Convert.ToInt32(dpPouchMilkTestStatus.SelectedItem.Value);
                //mqc.QualityStartTime = Convert.ToString("hh:mm:ss tt");
                //mqc.Hour1 = Convert.ToString("hh:mm:ss tt");
                //mqc.Hours2 = Convert.ToString("hh:mm:ss tt");
                //mqc.Hours3 = Convert.ToString("hh:mm:ss tt");
                //mqc.Hours4 = Convert.ToString("hh:mm:ss tt");
                //mqc.Hours5 = Convert.ToString("hh:mm:ss tt");
                //mqc.Hours6 = Convert.ToString("hh:mm:ss tt");
                //mqc.Hours7 = Convert.ToString("hh:mm:ss tt");
                //mqc.Hours8 = Convert.ToString("hh:mm:ss tt");
                //mqc.TotalHours = Convert.ToString("hh:mm:ss tt");
                mqc.flag = "Insert";
                Result = bqc.milkqc(mqc);
                if (Result > 0)
                {
                    divDanger.Visible = false;
                    divwarning.Visible = false;
                    divSusccess.Visible = true;
                   
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "sel3", "$('#bx1').addClass('collapsed-box');", true);

                    //string dates;
                    //dates = string.IsNullOrEmpty(txtSearchDate.Text) ? string.Empty : Convert.ToDateTime(txtSearchDate.Text).ToString("dd-MM-yyyy");
                    RMRecieve R = new RMRecieve();
                    R.RMRDate = Convert.ToDateTime(txtSearchDate.Text);
                    uprouteList.Update();
                    lblSuccess.Text = "AfterPackedMilkTestQC Data Add  Successfully";
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

                //return Result;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            {

                mqc = new MAfterPackedMilkTestQCDetails();
                bqc = new BAfterPackedMilkTestQCDetails();
                int Result = 0;
               // mqc.AfterPackedMilkTestQCId = 0;
                mqc.RMRId = string.IsNullOrEmpty(hId.Value) ? 0 : Convert.ToInt32(hId.Value);
                mqc.AfterPackedMilkTestQCDate = Convert.ToDateTime(txtDate.Text.ToString());
                mqc.ShiftId = Convert.ToInt32(dpShiftDetails.SelectedItem.Value);
                mqc.Source = txtSource.Text;
                mqc.Weight = string.IsNullOrEmpty(txtWeight.Text) ? 0 : Convert.ToDouble(txtWeight.Text);
                mqc.Quantity = string.IsNullOrEmpty(txtQuantity.Text) ? 0 : Convert.ToDouble(txtQuantity.Text);
                mqc.Temperature = string.IsNullOrEmpty(txtTemperature.Text) ? 0 : Convert.ToDouble(txtTemperature.Text);
                mqc.FAT = string.IsNullOrEmpty(txtFAT.Text) ? 0 : Convert.ToDouble(txtFAT.Text);
                mqc.CLR = string.IsNullOrEmpty(txtCLR.Text) ? 0 : Convert.ToDouble(txtCLR.Text);
                mqc.SNF = string.IsNullOrEmpty(txtSNF.Text) ? 0 : Convert.ToDouble(txtSNF.Text);
                mqc.QualityStartTime = string.IsNullOrEmpty(txtQualityStartTime.Text)?string.Empty:txtQualityStartTime.Text;
                mqc.Hour1 = string.IsNullOrEmpty(txt1hr.Text) ? string.Empty : txt1hr.Text; 
                mqc.Hours2 = string.IsNullOrEmpty(txt2hr.Text) ? string.Empty : txt2hr.Text; 
                mqc.Hours3 = string.IsNullOrEmpty(txt3hr.Text) ? string.Empty : txt3hr.Text; 
                mqc.Hours4 = string.IsNullOrEmpty(txt4hr.Text) ? string.Empty : txt4hr.Text; 
                mqc.Hours5 = string.IsNullOrEmpty(txt5hr.Text) ? string.Empty : txt5hr.Text; 
                mqc.Hours6 = string.IsNullOrEmpty(txt6hr.Text) ? string.Empty : txt6hr.Text; 
                mqc.Hours7 = string.IsNullOrEmpty(txt7hr.Text) ? string.Empty : txt7hr.Text; 
                mqc.Hours8 = string.IsNullOrEmpty(txt8hr.Text) ? string.Empty : txt8hr.Text; 
                mqc.MilkPouchQcStatusId = Convert.ToInt32(dpPouchMilkTestStatus.SelectedItem.Value);
                mqc.TotalHours = string.IsNullOrEmpty(txtTotalHours.Text) ? string.Empty : txtTotalHours.Text; 
                //mqc.QualityStartTime = Convert.ToString("hh:mm:ss tt");
                //mqc.Hour1 = Convert.ToString("hh:mm:ss tt");
                //mqc.Hours2 = Convert.ToString("hh:mm:ss tt");
                //mqc.Hours3 = Convert.ToString("hh:mm:ss tt");
                //mqc.Hours4 = Convert.ToString("hh:mm:ss tt");
                //mqc.Hours5 = Convert.ToString("hh:mm:ss tt");
                //mqc.Hours6 = Convert.ToString("hh:mm:ss tt");
                //mqc.Hours7 = Convert.ToString("hh:mm:ss tt");
                //mqc.Hours8 = Convert.ToString("hh:mm:ss tt");
                //mqc.TotalHours = Convert.ToString("hh:mm:ss tt");
                mqc.flag = "Update";
                Result = bqc.milkqc(mqc);
                if (Result > 0)
                {
                    divDanger.Visible = false;
                    divwarning.Visible = false;
                    divSusccess.Visible = true;
                  
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "sel3", "$('#bx1').addClass('collapsed-box');", true);
                  
                    //string dates;
                    //dates = string.IsNullOrEmpty(txtSearchDate.Text) ? string.Empty : Convert.ToDateTime(txtSearchDate.Text).ToString("dd-MM-yyyy");
                    //uprouteList.Update();
                    RMRecieve R = new RMRecieve();
                    R.RMRDate = Convert.ToDateTime(txtSearchDate.Text);
                    uprouteList.Update();
                    lblSuccess.Text = "AfterPackedMilkTestQC Data Update  Successfully";
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

                //return Result;
            }
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void rpAfterPackedMilkQC_ItemCommand1(object source, RepeaterCommandEventArgs e)
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
                        lblHeaderTab.Text = "Edit PackedData Details";
                        hId.Value = Id.ToString();
                        Id = Convert.ToInt32(hId.Value);
                        GetMilkQCDetails(Id);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "sel3", "$('#bx1').removeClass('collapsed-box');", true);
                        if (dpPouchMilkTestStatus.SelectedIndex == 1)
                        {
                            btnAdd.Visible = false;
                            btnUpdate.Visible = true;
                        }
                        else
                        {
                            btnAdd.Visible = true;
                            btnUpdate.Visible = false;
                        }
                      
                        btnRefresh.Visible = true;
                        // btnUpdate.Visible = true;
                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }
            }
        }

        public void GetMilkQCDetails(int RMRId)
        {
            DataSet DS = new DataSet();
            BAfterPackedMilkTestQCDetails bqc = new BAfterPackedMilkTestQCDetails();
            DS = bqc.GetMilkQCDetailsById(RMRId);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                string DATE = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["AfterPackedMilkTestQCDate"].ToString()) ? string.Empty : Convert.ToDateTime(DS.Tables[0].Rows[0]["AfterPackedMilkTestQCDate"]).ToString("yyyy-MM-dd");
                //sky
                //DateTime date1 = Convert.ToDateTime(DATE, System.Globalization.CultureInfo.GetCultureInfo("ur-PK").DateTimeFormat);
                if (DATE == "")
                {
                    txtDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                }
                else
                {
                    txtDate.Text = DATE;
                }
                dpShiftDetails.ClearSelection();
                string ShiftDetails = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["ShiftId"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["ShiftId"].ToString();
                if (ShiftDetails == "")
                {
                    dpShiftDetails.SelectedIndex = 0;
                }
                else
                {
                    
                        dpShiftDetails.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["ShiftId"]).ToString()).Selected = true;
                    
                }
                txtBatchCode.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["BatchCode"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["BatchCode"].ToString();
                txtSource.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Source"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Source"].ToString();
                txtWeight.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Weight"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Weight"].ToString();
                txtQuantity.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Quantity"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Quantity"].ToString();
                txtTemperature.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Temperature"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Temperature"].ToString();
                txtFAT.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["FAT"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["FAT"].ToString();
                txtCLR.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["CLR"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["CLR"].ToString();
                txtSNF.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["SNF"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["SNF"].ToString();
                txtQualityStartTime.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["QualityStartTime"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["QualityStartTime"].ToString();
                txt1hr.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Hour1"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Hour1"].ToString();
                txt2hr.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Hours2"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Hours2"].ToString();
                txt3hr.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Hours3"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Hours3"].ToString();
                txt4hr.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Hours4"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Hours4"].ToString();
                txt5hr.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Hours5"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Hours5"].ToString();
                txt6hr.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Hours6"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Hours6"].ToString();
                txt7hr.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Hours7"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Hours7"].ToString();
                txt8hr.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Hours8"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Hours8"].ToString();
                txtTotalHours.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["TotalHours"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["TotalHours"].ToString();
                dpPouchMilkTestStatus.ClearSelection();
                string PouchMilkTestStatus = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["MilkPouchQcStatusId"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["MilkPouchQcStatusId"].ToString();
                if(PouchMilkTestStatus=="")
                {
                    dpPouchMilkTestStatus.SelectedIndex = 2;
                }
                else
                {
                    dpPouchMilkTestStatus.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["MilkPouchQcStatusId"]).ToString()).Selected = true;
                }
            }
        }


        public void GetMilkQCDetails(RMRecieve R)
        {

            bqc = new BAfterPackedMilkTestQCDetails();
            DataSet DS = new DataSet();
            DS = bqc.GetMilkQCDetails(R);

            if (!Comman.Comman.IsDataSetEmpty(DS))
            {

                rpAfterPackedMilkQC.DataSource = DS;
                rpAfterPackedMilkQC.DataBind();
            }
            else
            {
                rpAfterPackedMilkQC.DataSource = DS;
                rpAfterPackedMilkQC.DataBind();
            }
            
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                //string dates = Convert.ToDateTime(txtSearchDate.Text).ToString("dd-MM-yyyy");
                //GetMilkQCDetails(dates);
                RMRecieve R = new RMRecieve();
                R.RMRDate = Convert.ToDateTime(txtSearchDate.Text);
                GetMilkQCDetails(R);
            }
            catch (Exception) { }
        }



    }
}