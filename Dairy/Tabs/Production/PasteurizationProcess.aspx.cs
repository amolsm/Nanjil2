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
    public partial class PasteurizationProcess : System.Web.UI.Page
    {
        MPastProcess mpast;
        BPastProcess bpast;
        DataSet DS = new DataSet();
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDwon();
                txtDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                txtSearchDate.Text= Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                //GetPastDetails();
                txtBatchNo.ReadOnly=true;
                btnUpdate.Visible = false;
                dpPastProcessDone.Items.FindByText("Release").Enabled = false;
                dpPastProcessDone.Items.FindByText("Hold").Enabled = false;
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
            dpPastProcessDone.DataSource = DS;
            dpPastProcessDone.DataBind();
            dpPastProcessDone.Items.FindByText("Release").Enabled = false;
            dpPastProcessDone.Items.FindByText("Hold").Enabled = false;
            dpPastProcessDone.Items.FindByText("Yes").Enabled = false;
            dpPastProcessDone.Items.FindByText("No").Enabled = false;
            dpPastProcessDone.Items.Insert(0, new ListItem("--Status--","0"));
        }
        public void GetPastDetails(RMRecieve R)
        {

            bpast = new BPastProcess();
            DataSet DS = new DataSet();
            DS = bpast.GetPastDetails(R);

            if (!Comman.Comman.IsDataSetEmpty(DS))
            {

                rpPastProcessList.DataSource = DS;
                rpPastProcessList.DataBind();
            }
          
                else if (DS.Tables[0].Rows.Count == 0)
                {


                    this.BindRepeater(dt);

                }
            
        }
        private void BindRepeater(DataTable dt)
        {
            rpPastProcessList.DataSource = dt;
            rpPastProcessList.DataBind();

            if (dt.Rows.Count == 0)
            {
                Control FooterTemplate = rpPastProcessList.Controls[rpPastProcessList.Controls.Count - 1].Controls[0];
                FooterTemplate.FindControl("trEmpty").Visible = true;
            }

        }


        public void GetPastDetails(int RMRId)
        {
            DataSet DS = new DataSet();
            bpast = new BPastProcess();
            DS = bpast.GetPastDetailsbyId(RMRId);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                string DATE = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["StandardDate"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["StandardDate"].ToString();
                //sky
                DateTime date1 = Convert.ToDateTime(DATE, System.Globalization.CultureInfo.GetCultureInfo("ur-PK").DateTimeFormat);
                txtDate.Text = (Convert.ToDateTime(date1).ToString("yyyy-MM-dd"));
                txtBatchNo.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["BatchNo"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["BatchNo"].ToString();
                //txtDate.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Date"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Date"].ToString();
                //dpShiftDetails.SelectedValue = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["ShiftId"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["ShiftId"].ToString();
                dpShiftDetails.ClearSelection();
                try
                {
                    dpShiftDetails.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["PastShiftId"]).ToString()).Selected = true;
                }
                catch (InvalidCastException)
                {
                    if (dpShiftDetails.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["StdShiftId"]).ToString()) != null)
                    {
                        dpShiftDetails.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["StdShiftId"]).ToString()).Selected = true;
                    }
                }
                txtIBTTemperature.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["IBTTemperature"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["IBTTemperature"].ToString();
                if(DS.Tables[0].Rows[0]["PastStartTime"].ToString()=="")
                {
                    txtPasteurizationstarttime.Text = Convert.ToString(DateTime.Now.ToString("HH:mm"));
                }
                else
                {
                    txtPasteurizationstarttime.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["PastStartTime"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["PastStartTime"].ToString();
                }
                
                txtHeatFirst.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["PastTempHeat1"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["PastTempHeat1"].ToString();
                txtCool1.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Cool1"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Cool1"].ToString();
                txtHeatSecond.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["PastTempHeat2"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["PastTempHeat2"].ToString();
                txtCool2.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Cool2"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Cool2"].ToString();
                txtHeatThird.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["PastTempHeat3"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["PastTempHeat3"].ToString();
                txtCool3.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Cool3"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Cool3"].ToString();
                txtHeatForth.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["PastTempHeat4"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["PastTempHeat4"].ToString();
                txtCool4.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Cool4"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Cool4"].ToString();
                txtHeatFive.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["PastTempHeat5"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["PastTempHeat5"].ToString();
                txtCool5.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Cool5"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Cool5"].ToString();
                txtMilkClosingTime.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["MilkClosingTime"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["MilkClosingTime"].ToString();
                txtDoneBy.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["DoneBy"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["DoneBy"].ToString();

                dpPastProcessDone.ClearSelection();

                string PastProcessDone = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["PastProcessStatusId"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["PastProcessStatusId"].ToString();
                if(PastProcessDone=="")
                {
                    dpPastProcessDone.SelectedIndex = 2;
                }
                else
                {
                    dpPastProcessDone.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["PastProcessStatusId"]).ToString()).Selected = true;
                }
                //try
                //{
                //    dpPastProcessDone.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["PastProcessStatusId"]).ToString()).Selected = true;
                //}
                //catch (InvalidCastException)
                //{
                //    dpPastProcessDone.SelectedIndex = 2;
                //}
            }

        }
     

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void rpPastProcessList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            HiddenField hdfID = e.Item.FindControl("hfStdId") as HiddenField;
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
                        lblHeaderTab.Text = "Edit PasteurizationProcess Details";
                        hId.Value = Id.ToString();
                        Id = Convert.ToInt32(hId.Value);
                        GetPastDetails(Id);
                        //if (txtIBTTemperature.Text == string.Empty && txtPasteurizationstarttime.Text == string.Empty)
                        //{
                        //   btnAdd.Visible = true;
                        //    btnUpdate.Visible = false;
                        //}
                        //else
                        //{
                        //    btnUpdate.Visible = true;
                        //    btnAdd.Visible = false;
                        //}

                        if(dpPastProcessDone.SelectedItem.Text=="Pending")
                        {
                            btnAdd.Visible = true;
                            btnUpdate.Visible = false;
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "sel3", "$('#bx1').removeClass('collapsed-box');", true);
                        }
                        else
                        {
                            btnUpdate.Visible = true;
                            btnAdd.Visible = false;
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "sel3", "$('#bx1').removeClass('collapsed-box');", true);
                        }

                        //btnAdd.Visible = true;
                        //btnUpdate.Visible = true;
                        btnRefresh.Visible = true;
                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            {

                mpast = new MPastProcess();
                bpast = new BPastProcess();
                int Result = 0;
                mpast.pastProcessId = 0;
                mpast.RMRId = string.IsNullOrEmpty(hId.Value) ? 0 : Convert.ToInt32(hId.Value);
                foreach (RepeaterItem item in rpPastProcessList.Items)
                {
                    HiddenField hdfID = item.FindControl("hfStdId") as HiddenField;
                    if (hdfID != null)
                    {
                        mpast.StdId = string.IsNullOrEmpty(hdfID.Value) ? 0 : Convert.ToInt32(hdfID.Value);
                    }
                }
                mpast.PastProcessDate = Convert.ToDateTime(txtDate.Text).ToString("dd-MM-yyyy");
                mpast.PastShiftId = Convert.ToInt32(dpShiftDetails.SelectedItem.Value);
                mpast.IBTTemperature = string.IsNullOrEmpty(txtIBTTemperature.Text) ? 0 : Convert.ToDouble(txtIBTTemperature.Text);
                mpast.PastStartTime = string.IsNullOrEmpty(txtPasteurizationstarttime.Text) ? string.Empty : txtPasteurizationstarttime.Text;
                mpast.PastTempHeat1 = string.IsNullOrEmpty(txtHeatFirst.Text) ? 0 : Convert.ToDouble(txtHeatFirst.Text);
                mpast.Cool1 = string.IsNullOrEmpty(txtCool1.Text) ? 0 : Convert.ToDouble(txtCool1.Text);
                mpast.PastTempHeat2 = string.IsNullOrEmpty(txtHeatSecond.Text) ? 0 : Convert.ToDouble(txtHeatSecond.Text);
                mpast.Cool2 = string.IsNullOrEmpty(txtCool2.Text) ? 0 : Convert.ToDouble(txtCool2.Text);
                mpast.PastTempHeat3 = string.IsNullOrEmpty(txtHeatThird.Text) ? 0 : Convert.ToDouble(txtHeatThird.Text);
                mpast.Cool3 = string.IsNullOrEmpty(txtCool3.Text) ? 0 : Convert.ToDouble(txtCool3.Text);
                mpast.PastTempHeat4 = string.IsNullOrEmpty(txtHeatForth.Text) ? 0 : Convert.ToDouble(txtHeatForth.Text);
                mpast.Cool4 = string.IsNullOrEmpty(txtCool4.Text) ? 0 : Convert.ToDouble(txtCool4.Text);
                mpast.PastTempHeat5 = string.IsNullOrEmpty(txtHeatFive.Text) ? 0 : Convert.ToDouble(txtHeatFive.Text);
                mpast.Cool5 = string.IsNullOrEmpty(txtCool5.Text) ? 0 : Convert.ToDouble(txtCool5.Text);
                mpast.MilkClosingTime = string.IsNullOrEmpty(txtMilkClosingTime.Text) ? string.Empty : txtMilkClosingTime.Text;
                mpast.DoneBy = string.IsNullOrEmpty(txtDoneBy.Text) ? string.Empty : txtDoneBy.Text;
                mpast.pastProcessStatusId = Convert.ToInt32(dpPastProcessDone.SelectedItem.Value);
                mpast.flag = "Insert";
                Result = bpast.pastdata(mpast);
                if (Result > 0)
                {
                    divDanger.Visible = false;
                    divwarning.Visible = false;
                    divSusccess.Visible = true;
                    lblSuccess.Text = "PasteurizationProcess Data Add  Successfully";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "sel3", "$('#bx1').addClass('collapsed-box');", true);
                    pnlError.Update();
                    //string dates;
                    //dates = string.IsNullOrEmpty(txtSearchDate.Text) ? string.Empty : Convert.ToDateTime(txtSearchDate.Text).ToString("dd-MM-yyyy");
                    RMRecieve R = new RMRecieve();
                    R.RMRDate = Convert.ToDateTime(txtSearchDate.Text);
                    GetPastDetails(R);
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

                mpast = new MPastProcess();
                bpast = new BPastProcess();
                int Result = 0;
                mpast.RMRId = string.IsNullOrEmpty(hId.Value) ? 0 : Convert.ToInt32(hId.Value);
                //mpast.pastProcessId = string.IsNullOrEmpty(hId.Value) ? 0 : Convert.ToInt32(hId.Value);
                mpast.PastProcessDate = Convert.ToDateTime(txtDate.Text).ToString("dd-MM-yyyy");
                mpast.PastShiftId = Convert.ToInt32(dpShiftDetails.SelectedItem.Value);
                mpast.IBTTemperature = string.IsNullOrEmpty(txtIBTTemperature.Text) ? 0 : Convert.ToDouble(txtIBTTemperature.Text);
                mpast.PastStartTime =string.IsNullOrEmpty(txtPasteurizationstarttime.Text)?string.Empty : txtPasteurizationstarttime.Text;
                mpast.PastTempHeat1 = string.IsNullOrEmpty(txtHeatFirst.Text) ? 0 : Convert.ToDouble(txtHeatFirst.Text);
                mpast.Cool1 = string.IsNullOrEmpty(txtCool1.Text) ? 0 : Convert.ToDouble(txtCool1.Text);
                mpast.PastTempHeat2 = string.IsNullOrEmpty(txtHeatSecond.Text) ? 0 : Convert.ToDouble(txtHeatSecond.Text);
                mpast.Cool2 = string.IsNullOrEmpty(txtCool2.Text) ? 0 : Convert.ToDouble(txtCool2.Text);
                mpast.PastTempHeat3 = string.IsNullOrEmpty(txtHeatThird.Text) ? 0 : Convert.ToDouble(txtHeatThird.Text);
                mpast.Cool3 = string.IsNullOrEmpty(txtCool3.Text) ? 0 : Convert.ToDouble(txtCool3.Text);
                mpast.PastTempHeat4 = string.IsNullOrEmpty(txtHeatForth.Text) ? 0 : Convert.ToDouble(txtHeatForth.Text);
                mpast.Cool4 = string.IsNullOrEmpty(txtCool4.Text) ? 0 : Convert.ToDouble(txtCool4.Text);
                mpast.PastTempHeat5 = string.IsNullOrEmpty(txtHeatFive.Text) ? 0 : Convert.ToDouble(txtHeatFive.Text);
                mpast.Cool5 = string.IsNullOrEmpty(txtCool5.Text) ? 0 : Convert.ToDouble(txtCool5.Text);
                mpast.MilkClosingTime = string.IsNullOrEmpty(txtMilkClosingTime.Text)?string.Empty:txtMilkClosingTime.Text;
                mpast.DoneBy = string.IsNullOrEmpty(txtDoneBy.Text)?string.Empty:txtDoneBy.Text;
                mpast.pastProcessStatusId = Convert.ToInt32(dpPastProcessDone.SelectedItem.Value);
                mpast.flag = "Update";
                Result = bpast.pastdata(mpast);
                if (Result > 0)
                {
                    divDanger.Visible = false;
                    divwarning.Visible = false;
                    divSusccess.Visible = true;
                    lblSuccess.Text = "PasteurizationProcess Data Update  Successfully";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "sel3", "$('#bx1').addClass('collapsed-box');", true);
                    pnlError.Update();
                    //string dates;
                    //dates = string.IsNullOrEmpty(txtSearchDate.Text) ? string.Empty : Convert.ToDateTime(txtSearchDate.Text).ToString("dd-MM-yyyy");
                    RMRecieve R = new RMRecieve();
                    R.RMRDate = Convert.ToDateTime(txtSearchDate.Text);
                    GetPastDetails(R);
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
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                //string dates = Convert.ToDateTime(txtSearchDate.Text).ToString("dd-MM-yyyy");
                //GetPastDetails(dates);
                RMRecieve R = new RMRecieve();
                R.RMRDate = Convert.ToDateTime(txtSearchDate.Text);
                GetPastDetails(R);
            }
            catch (Exception) { }
          
        }

    }
}