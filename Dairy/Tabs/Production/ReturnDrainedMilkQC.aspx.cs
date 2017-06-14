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
    public partial class ReturnDrainedMilkQC : System.Web.UI.Page
    {
        MReturnDrainedMilkQualityQC mdrainedqc;
        BReturnDrainedMilkQualityQC bdrainedqc;
        DataSet DS = new DataSet();
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDwon();
                txtDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                txtSearchDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                //GetDrainedMilkQCDetails();
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
            dpDrainedMilkQCStatusId.DataSource = DS;
            dpDrainedMilkQCStatusId.DataBind();
            dpDrainedMilkQCStatusId.Items.FindByText("Release").Enabled = false;
            dpDrainedMilkQCStatusId.Items.FindByText("Hold").Enabled = false;
            dpDrainedMilkQCStatusId.Items.FindByText("Yes").Enabled = false;
            dpDrainedMilkQCStatusId.Items.FindByText("No").Enabled = false;
            dpDrainedMilkQCStatusId.Items.Insert(0, new ListItem("--Status--", "0"));
        }

        public void GetDrainedMilkQCDetails(RMRecieve R)
        {

            bdrainedqc = new BReturnDrainedMilkQualityQC();
            DataSet DS = new DataSet();
            DS = bdrainedqc.GetDrainedMilkQCDetails(R);

            if (!Comman.Comman.IsDataSetEmpty(DS))
            {

                rpReturnDrainedMilkQC.DataSource = DS;
                rpReturnDrainedMilkQC.DataBind();
            }
            else
            {
                rpReturnDrainedMilkQC.DataSource = DS;
                rpReturnDrainedMilkQC.DataBind();
            }

        }

        protected void rpReturnDrainedMilkQC_ItemCommand(object source, RepeaterCommandEventArgs e)
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
                       
                        hId.Value = Id.ToString();
                        Id = Convert.ToInt32(hId.Value);
                        GetDrainedMilkQCDetails(Id);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "sel3", "$('#bx1').removeClass('collapsed-box');", true);
                        if (dpDrainedMilkQCStatusId.SelectedIndex==1)
                        {
                            lblHeaderTab.Text = "Edit ReturnDrainedMilkData Details";
                            btnAdd.Visible = false;
                            btnUpdate.Visible = true;
                        }
                        else
                        {
                            lblHeaderTab.Text = "Add ReturnDrainedMilkData Details";
                            btnAdd.Visible = true;
                            btnUpdate.Visible = false;
                        }
                      
                        btnRefresh.Visible = true;
                       
                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }
            }
        }

        public void GetDrainedMilkQCDetails(int RMRId)
        {
            DataSet DS = new DataSet();
            bdrainedqc = new BReturnDrainedMilkQualityQC();
            DS = bdrainedqc.GetDrainedMilkQCDetabyId(RMRId);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                string DATE = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["ReturnDrainedMilkQCDate"].ToString()) ? string.Empty : Convert.ToDateTime(DS.Tables[0].Rows[0]["ReturnDrainedMilkQCDate"]).ToString("yyyy-MM-dd");
                //sky
                if (DATE == "")
                {
                    txtDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                }
                else
                {
                    DateTime date1 = Convert.ToDateTime(DATE, System.Globalization.CultureInfo.GetCultureInfo("ur-PK").DateTimeFormat);
                    txtDate.Text = DATE;
                }
                txtBatchNo.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["BatchNo"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["BatchNo"].ToString();
                //txtDate.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Date"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Date"].ToString();
                //dpShiftDetails.SelectedValue = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["ShiftId"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["ShiftId"].ToString();
                dpShiftDetails.ClearSelection();
                string ShiftDetails = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["ReturnDrainedMilkQCShiftId"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["ReturnDrainedMilkQCShiftId"].ToString();
                if (ShiftDetails == "")
                {
                    dpShiftDetails.SelectedIndex = 0;
                }
                else
                {                    
                        dpShiftDetails.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["ReturnDrainedMilkQCShiftId"]).ToString()).Selected = true;                   
                }
                txtSource.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Source"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Source"].ToString();
                txtQuantity.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Quantity"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Quantity"].ToString();
                txtMBRT.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["MBRT"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["MBRT"].ToString();
                txtTEMP.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["TEMP"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["TEMP"].ToString();
                txtRemarks.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Remarks"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Remarks"].ToString();
                dpDrainedMilkQCStatusId.ClearSelection();
                string DrainedMilkStatus = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["ReturnDrainedMilkQcStatusId"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["ReturnDrainedMilkQcStatusId"].ToString();
                if(DrainedMilkStatus=="")
                {
                    dpDrainedMilkQCStatusId.SelectedIndex = 2;
                }
                else
                {
                    dpDrainedMilkQCStatusId.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["ReturnDrainedMilkQcStatusId"]).ToString()).Selected = true;
                }
            }
        }

        protected void btnAdd_Click1(object sender, EventArgs e)
        {
            {

                mdrainedqc = new MReturnDrainedMilkQualityQC();
                bdrainedqc = new BReturnDrainedMilkQualityQC();
                int Result = 0;
                mdrainedqc.ReturnDrainedMilkQualityQCId = 0;
                mdrainedqc.RMRId = string.IsNullOrEmpty(hId.Value) ? 0 : Convert.ToInt32(hId.Value);
                mdrainedqc.ReturnDrainedMilkQCDate = Convert.ToDateTime(txtDate.Text.ToString());
                mdrainedqc.ReturnDrainedMilkQCShiftId = Convert.ToInt32(dpShiftDetails.SelectedItem.Value);
                mdrainedqc.Source =string.IsNullOrEmpty(txtSource.Text)?string.Empty:(txtSource.Text);
                mdrainedqc.Quantity = string.IsNullOrEmpty(txtQuantity.Text) ? 0 : Convert.ToDouble(txtQuantity.Text);
                mdrainedqc.MBRT = string.IsNullOrEmpty(txtMBRT.Text) ? 0 : Convert.ToDouble(txtMBRT.Text);
                mdrainedqc.TEMP = string.IsNullOrEmpty(txtTEMP.Text) ? 0 : Convert.ToDouble(txtTEMP.Text);
                mdrainedqc.Remarks =string.IsNullOrEmpty(txtRemarks.Text)?string.Empty:(txtRemarks.Text);
                mdrainedqc.ReturnDrainedMilkQcStatusId = Convert.ToInt32(dpDrainedMilkQCStatusId.SelectedItem.Value);
                mdrainedqc.flag = "Insert";
                Result = bdrainedqc.Draineddata(mdrainedqc);
                if (Result > 0)
                {
                    divDanger.Visible = false;
                    divwarning.Visible = false;
                    divSusccess.Visible = true;
                   
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "sel3", "$('#bx1').addClass('collapsed-box');", true);

                    //string dates = string.IsNullOrEmpty(txtSearchDate.Text) ? string.Empty : Convert.ToDateTime(txtSearchDate.Text).ToString("dd-MM-yyyy");
                    //GetDrainedMilkQCDetails(dates);
                    RMRecieve R = new RMRecieve();
                    R.RMRDate = Convert.ToDateTime(txtSearchDate.Text);
                    GetDrainedMilkQCDetails(R);
                    uprouteList.Update();
                    lblSuccess.Text = "ReturnDrainedMilkQualityQC Data Added  Successfully";
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

      

     

        protected void btnUpdate_Click1(object sender, EventArgs e)
        {
            {

                mdrainedqc = new MReturnDrainedMilkQualityQC();
                bdrainedqc = new BReturnDrainedMilkQualityQC();
                int Result = 0;
                mdrainedqc.RMRId = string.IsNullOrEmpty(hId.Value) ? 0 : Convert.ToInt32(hId.Value);
                mdrainedqc.ReturnDrainedMilkQCDate = Convert.ToDateTime(txtDate.Text.ToString());
                mdrainedqc.ReturnDrainedMilkQCShiftId = Convert.ToInt32(dpShiftDetails.SelectedItem.Value);
                mdrainedqc.Source = string.IsNullOrEmpty(txtSource.Text) ? string.Empty : (txtSource.Text);
                mdrainedqc.Quantity = string.IsNullOrEmpty(txtQuantity.Text) ? 0 : Convert.ToDouble(txtQuantity.Text);
                mdrainedqc.MBRT = string.IsNullOrEmpty(txtMBRT.Text) ? 0 : Convert.ToDouble(txtMBRT.Text);
                mdrainedqc.TEMP = string.IsNullOrEmpty(txtTEMP.Text) ? 0 : Convert.ToDouble(txtTEMP.Text);
                mdrainedqc.Remarks = string.IsNullOrEmpty(txtRemarks.Text) ? string.Empty : (txtRemarks.Text);
                mdrainedqc.ReturnDrainedMilkQcStatusId = Convert.ToInt32(dpDrainedMilkQCStatusId.SelectedItem.Value);
                mdrainedqc.flag = "Update";
                Result = bdrainedqc.Draineddata(mdrainedqc);
                if (Result > 0)
                {
                    divDanger.Visible = false;
                    divwarning.Visible = false;
                    divSusccess.Visible = true;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "sel3", "$('#bx1').addClass('collapsed-box');", true);
                    //string dates = string.IsNullOrEmpty(txtSearchDate.Text) ? string.Empty : Convert.ToDateTime(txtSearchDate.Text).ToString("dd-MM-yyyy");
                    //GetDrainedMilkQCDetails(dates);
                    RMRecieve R = new RMRecieve();
                    R.RMRDate = Convert.ToDateTime(txtSearchDate.Text);
                    GetDrainedMilkQCDetails(R);
                    uprouteList.Update();
                    lblSuccess.Text = "ReturnDrainedMilkQualityQC Data Updated  Successfully";
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

        protected void btnRefresh_Click1(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                RMRecieve R = new RMRecieve();
                ProductionData PD = new ProductionData();
                R.RMRDate = Convert.ToDateTime(txtSearchDate.Text);
                GetDrainedMilkQCDetails(R);
            }
            catch (Exception) { }
        }
    }
}