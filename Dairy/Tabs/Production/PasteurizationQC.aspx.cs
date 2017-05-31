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
    public partial class Pasteurizationprocess : System.Web.UI.Page
    {

        MPasteurizationQC mdata;
        BPasteurizationQC bdata;
        DataSet DS = new DataSet();
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindDropDwon();
                BindDropDwonQC();
                txtDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                txtSearchDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                //GetPasteurizationDetails();
                txtBatchNo.ReadOnly = true;
               

               
            }
        }

        protected void BindDropDwon()
        {
            DS = new DataSet();
            DS = BindCommanData.BindCommanDropDwon("ShiftId", "ShiftName as Name", "ShiftDetails", "IsActive =1");
            dpShiftDetails.DataSource = DS;
            dpShiftDetails.DataBind();
            dpShiftDetails.Items.Insert(0, new ListItem("--Select Shift--", "0"));
        }

        protected void BindDropDwonQC()
        {
            DS = new DataSet();
            DS = BindCommanData.BindCommanDropDwon("QCId", "Status as Name", "QCDetails", "IsActive =1");

            dpQCDetails.DataSource = DS;
            dpQCDetails.DataBind();
            dpQCDetails.Items.FindByText("Pending").Enabled = false;
            dpQCDetails.Items.FindByText("Re-Chilling").Enabled = false;
            dpQCDetails.Items.Insert(0, new ListItem("--Select Status--", "0"));
        }

        public void GetPasteurizationDetails(RMRecieve R)
        {

            bdata = new BPasteurizationQC();
            DataSet DS = new DataSet();
            DS = bdata.GetPasteurizationDetails(R);

            if (!Comman.Comman.IsDataSetEmpty(DS))
            {

                rpPasteurizationQCList.DataSource = DS;
                rpPasteurizationQCList.DataBind();
            }
            else
            {
                // this.BindRepeater(dt);
                rpPasteurizationQCList.DataSource = DS;
                rpPasteurizationQCList.DataBind();
            }

        }
        private void BindRepeater(DataTable dt)
        {
            rpPasteurizationQCList.DataSource = dt;
            rpPasteurizationQCList.DataBind();

            if (dt.Rows.Count == 0)
            {
                Control FooterTemplate = rpPasteurizationQCList.Controls[rpPasteurizationQCList.Controls.Count - 1].Controls[0];
                FooterTemplate.FindControl("trEmpty").Visible = true;
            }

        }


        public void GetPasteurizationDetails(int RMRId)
        {
            DataSet DS = new DataSet();
            BPasteurizationQC bdata = new BPasteurizationQC();
            DS = bdata.GetPasteurizationDetabyId(RMRId);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {

                string DATE = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["PastProcessDate"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["PastProcessDate"].ToString();
                if (DATE == "")
                {
                    txtDate.Text = "";
                }
                else
                {
                    DateTime date1 = Convert.ToDateTime(DATE, System.Globalization.CultureInfo.GetCultureInfo("ur-PK").DateTimeFormat);
                    txtDate.Text = (Convert.ToDateTime(date1).ToString("yyyy-MM-dd"));
                }
                txtBatchNo.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["BatchNo"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["BatchNo"].ToString();
                txtTemperatureHeat.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["TemperatureHeat"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["TemperatureHeat"].ToString();
                txtTempChill.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["TempChill"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["TempChill"].ToString();
                txtDoneBy.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["DoneBy"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["DoneBy"].ToString();
                txtRemarks.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Remarks"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Remarks"].ToString();
                dpShiftDetails.ClearSelection();

                try
                {
                    if (dpShiftDetails.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["PastQCShiftId"]).ToString()) != null)
                    {
                        dpShiftDetails.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["PastQCShiftId"]).ToString()).Selected = true;
                    }

                }
                catch(InvalidCastException)
                {
                    dpShiftDetails.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["PastShiftId"]).ToString()).Selected = true;
                }
               
                    
              
                dpQCDetails.ClearSelection();
                try
                { 
                if(dpQCDetails.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["QCStatus"]).ToString()) !=null)
                {
                    dpQCDetails.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["QCStatus"]).ToString()).Selected = true;
                }
                }
                catch (InvalidCastException)
                {
                    dpQCDetails.SelectedIndex = 0;
                }
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            MPasteurizationQC mdata = new MPasteurizationQC();
            BPasteurizationQC bdata = new BPasteurizationQC();
            int Result = 0;
            mdata.PastQCId = 0;

            foreach (RepeaterItem item in rpPasteurizationQCList.Items)
            {
                HiddenField hdfID = item.FindControl("hfPastProcessId") as HiddenField;
                if (hdfID != null)
                {
                    mdata.PastProcessId = string.IsNullOrEmpty(hdfID.Value) ? 0 : Convert.ToInt32(hdfID.Value);
                }
            }
            foreach (RepeaterItem item in rpPasteurizationQCList.Items)
            {
                HiddenField hdfID1 = item.FindControl("hfStdId") as HiddenField;
                if (hdfID1 != null)
                {
                    mdata.StdId = string.IsNullOrEmpty(hdfID1.Value) ? 0 : Convert.ToInt32(hdfID1.Value);
                }
            }
            foreach (RepeaterItem item in rpPasteurizationQCList.Items)
            {
                HiddenField hdfID2 = item.FindControl("hfQualityId") as HiddenField;
                if (hdfID2 != null)
                {
                    mdata.QualityId = string.IsNullOrEmpty(hdfID2.Value) ? 0 : Convert.ToInt32(hdfID2.Value);
                }
            }
            mdata.RMRId = string.IsNullOrEmpty(hId.Value) ? 0 : Convert.ToInt32(hId.Value);
            mdata.PastQCDate = Convert.ToDateTime(txtDate.Text).ToString("dd-MM-yyyy");
            mdata.PastQCShiftId = Convert.ToInt32(dpShiftDetails.SelectedItem.Value);
            mdata.TemperatureHeat = string.IsNullOrEmpty(txtTemperatureHeat.Text) ? 0 : Convert.ToDouble(txtTemperatureHeat.Text);
            mdata.TempChill = string.IsNullOrEmpty(txtTempChill.Text) ? 0 : Convert.ToDouble(txtTempChill.Text);
            mdata.DoneBy = txtDoneBy.Text;
            mdata.Remarks = txtRemarks.Text;
            mdata.QCStatus = Convert.ToInt32(dpQCDetails.SelectedItem.Value);
            mdata.flag = "Insert";
            Result = bdata.PasteurizationData(mdata);
            if (Result > 0)
            {
                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Pasteurization Data Add  Successfully";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "sel3", "$('#bx1').addClass('collapsed-box');", true);
                pnlError.Update();
                //string dates;
                //dates = string.IsNullOrEmpty(txtSearchDate.Text) ? string.Empty : Convert.ToDateTime(txtSearchDate.Text).ToString("dd-MM-yyyy");
                RMRecieve R = new RMRecieve();
                R.RMRDate = Convert.ToDateTime(txtSearchDate.Text);
                GetPasteurizationDetails(R);
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

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            MPasteurizationQC mdata = new MPasteurizationQC();
            BPasteurizationQC bdata = new BPasteurizationQC();
            int Result = 0;
            mdata.PastQCId = 0;


           // mdata.RMRId = string.IsNullOrEmpty(hId.Value) ? 0 : Convert.ToInt32(hId.Value);
            mdata.PastQCDate = Convert.ToDateTime(txtDate.Text).ToString("dd-MM-yyyy");
            mdata.PastQCShiftId = Convert.ToInt32(dpShiftDetails.SelectedItem.Value);
            mdata.TemperatureHeat = string.IsNullOrEmpty(txtTemperatureHeat.Text) ? 0 : Convert.ToDouble(txtTemperatureHeat.Text);
            mdata.TempChill = string.IsNullOrEmpty(txtTempChill.Text) ? 0 : Convert.ToDouble(txtTempChill.Text);
            mdata.DoneBy = txtDoneBy.Text;
            mdata.Remarks = txtRemarks.Text;
            mdata.QCStatus = Convert.ToInt32(dpQCDetails.SelectedItem.Value);
            mdata.flag = "Update";
            Result = bdata.PasteurizationData(mdata);
            if (Result > 0)
            {
                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Pasteurization Data Updated  Successfully";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "sel3", "$('#bx1').addClass('collapsed-box');", true);
                pnlError.Update();
                string dates;
                dates = string.IsNullOrEmpty(txtSearchDate.Text) ? string.Empty : Convert.ToDateTime(txtSearchDate.Text).ToString("dd-MM-yyyy");
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
        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }



        protected void rpPasteurizationQCList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            HiddenField hdfID = e.Item.FindControl("hfPastProcessId") as HiddenField;
            HiddenField hdfID1 = e.Item.FindControl("hfStdId") as HiddenField;
            HiddenField hdfID2 = e.Item.FindControl("hfQualityId") as HiddenField;
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
                        GetPasteurizationDetails(Id);
                        if (txtTemperatureHeat.Text == string.Empty && txtTempChill.Text == string.Empty)
                        {
                            btnAdd.Visible = true;
                            btnUpdate.Visible = false;
                            btnRefresh.Visible = true;
                            lblHeaderTab.Text = "Add Pasteurization Details";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "sel3", "$('#bx1').removeClass('collapsed-box');", true);
                        }                      
                        else
                        {
                            btnAdd.Visible = false;
                            btnUpdate.Visible = true;
                            btnRefresh.Visible = true;
                            lblHeaderTab.Text = "Edit Pasteurization Details";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "sel3", "$('#bx1').removeClass('collapsed-box');", true);
                        }
                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //string dates = Convert.ToDateTime(txtSearchDate.Text).ToString("dd-MM-yyyy");
            //GetPasteurizationDetails(dates);
            RMRecieve R = new RMRecieve();
            ProductionData PD = new ProductionData();
            R.RMRDate = Convert.ToDateTime(txtSearchDate.Text);
            GetPasteurizationDetails(R);
        }
    }
}
    