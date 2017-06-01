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
    public partial class Finished_Good_Release : System.Web.UI.Page
    {
        DataSet DS = new DataSet();
        BFinishedGoodsRelease finishBdata;
        MFinishedGoodsRelease finishMdata;
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //GetFinishedGoodReleaseDetails();
                BindDropDwon();
                txtDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                txtMfgDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                txtSearchDate.Text= Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd")); 
                btnUpdateFinishGoodsdetail.Visible = false;
            }
        }

        protected void BindDropDwon()   
        {

            DS = new DataSet();
            DS = BindCommanData.BindCommanDropDwon("ShiftId", "ShiftName as Name", "ShiftDetails", "IsActive =1");
            dpShiftDetails.DataSource = DS;
            dpShiftDetails.DataBind();
            dpShiftDetails.Items.Insert(0, new ListItem("--Select Shift--", "0"));

            DS = BindCommanData.BindCommanDropDwon("StatusId", "StatusName as Name", "Prod_StatusDetails", "IsActive =1");
            dpStatus.DataSource = DS;
            dpStatus.DataBind();
            dpStatus.Items.FindByText("Release").Enabled = false;
            dpStatus.Items.FindByText("Hold").Enabled = false;
            dpStatus.Items.FindByText("Yes").Enabled = false;
            dpStatus.Items.FindByText("No").Enabled = false;
            dpStatus.Items.Insert(0, new ListItem("--Select Staus--", "0"));

           
        }

        public void GetFinishedGoodReleaseDetails(RMRecieve R)
        {

            finishBdata = new BFinishedGoodsRelease();
            DataSet DS = new DataSet();
            DS = finishBdata.GetFinishedGoodReleaseDetails(R);

            if (!Comman.Comman.IsDataSetEmpty(DS))
            {

                rpFinishGoodList.DataSource = DS;
                rpFinishGoodList.DataBind();
            }
            else if (DS.Tables[0].Rows.Count == 0)
            {
                //this.BindRepeater(dt);
                rpFinishGoodList.DataSource = DS;
                rpFinishGoodList.DataBind();
            }
        }
              private void BindRepeater(DataTable dt)
        {
            rpFinishGoodList.DataSource = dt;
            rpFinishGoodList.DataBind();

            if (dt.Rows.Count == 0)
            {
                Control FooterTemplate = rpFinishGoodList.Controls[rpFinishGoodList.Controls.Count - 1].Controls[0];
                FooterTemplate.FindControl("trEmpty").Visible = true;
            }

        }

    
        protected void rpFinishGoodList_ItemCommand(object source, RepeaterCommandEventArgs e)
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
                        //lblHeaderTab.Text = "Edit Good Release Information";
                        hId.Value = RMRId.ToString();
                        RMRId = Convert.ToInt32(hId.Value);
                        GetFinishedGoodReleaseDetails(RMRId);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "sel3", "$('#bx1').removeClass('collapsed-box');", true);
                        // hfrid.Value = RMRId.ToString();

                        if (dpStatus.SelectedIndex == 0)
                        {
                            btnAddFinishGoodsdetail.Visible = true;
                            btnUpdateFinishGoodsdetail.Visible = false;
                            lblHeaderTab.Text = "Add Good Release Information";
                        }
                        else
                        {
                            btnAddFinishGoodsdetail.Visible = false;
                            btnUpdateFinishGoodsdetail.Visible = true;
                            lblHeaderTab.Text = "Edit Good Release Information";
                        }


                        
                        upMain.Update();
                        uprouteList.Update();


                        break;
                    }
                    ////case ("delete"):
                    ////    {

                    ////        hId.Value = Id.ToString();
                    ////        Id = Convert.ToInt32(hId.Value);
                    ////        DeleteRMRDetails(Id);
                    ////        bindRMRList();
                    ////        upMain.Update();
                    ////        uprouteList.Update();
                    ////        break;

                    //    }
            }
        }

        public void GetFinishedGoodReleaseDetails(int RMRId)
        {
            DataSet DS = new DataSet();
            BFinishedGoodsRelease finishBdata = new BFinishedGoodsRelease();
            DS = finishBdata.GetFinishedGoodReleaseDetailsById(RMRId);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                txtBatchNo.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["BatchNo"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["BatchNo"].ToString();
                txtMilkType.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["TypeOfMilk"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["TypeOfMilk"].ToString();
                txtQuantity.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Qty"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Qty"].ToString();

                string DATE = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["FinishedGoodsMfgDate"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["FinishedGoodsMfgDate"].ToString();
                //sky
                if (DATE == "")
                {
                    txtMfgDate.Text = "";
                }
                else
                {
                    DateTime date1 = Convert.ToDateTime(DATE, System.Globalization.CultureInfo.GetCultureInfo("ur-PK").DateTimeFormat);
                    txtMfgDate.Text = (Convert.ToDateTime(date1).ToString("yyyy-MM-dd"));
                    
                }
                txtBatchCode.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["FinishedGoodsBatchCode"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["FinishedGoodsBatchCode"].ToString();

                dpStatus.ClearSelection();
                try
                {
                    if (dpStatus.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["StatusId"]).ToString()) != null)
                    {
                        dpStatus.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["StatusId"]).ToString()).Selected = true;
                    }
                }
                catch(InvalidCastException)
                {
                    dpStatus.SelectedIndex = 0;
                }
                dpShiftDetails.ClearSelection();
                try
                {
                    if (dpShiftDetails.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["FinishedGoodsShiftId"]).ToString())!=null)
                    {
                        dpShiftDetails.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["FinishedGoodsShiftId"]).ToString()).Selected = true;
                    }
                }
                catch (InvalidCastException)
                {
                    dpShiftDetails.SelectedIndex = 0;
                }
            }
        }

        protected void btnAddFinishGoodsdetail_Click(object sender, EventArgs e)
        {
            try
            {
                finishMdata = new MFinishedGoodsRelease();
                finishBdata = new BFinishedGoodsRelease();
                int Result = 0;
                finishMdata.FinishgoodId = 0;
                finishMdata.RMRId = string.IsNullOrEmpty(hId.Value) ? 0 : Convert.ToInt32(hId.Value);
                finishMdata.FinishedGoodsBatchCode = string.IsNullOrEmpty(txtBatchCode.Text) ? string.Empty : txtBatchCode.Text;
                finishMdata.FinishedGoodsDate = Convert.ToDateTime(txtDate.Text).ToString("dd-MM-yyyy");
                finishMdata.FinishedGoodsShiftId = Convert.ToInt32(dpShiftDetails.SelectedItem.Value);
                finishMdata.TypeofMilk = string.IsNullOrEmpty(txtMilkType.Text) ? string.Empty : txtMilkType.Text;
                finishMdata.FinishedGoodsQuantity = string.IsNullOrEmpty(txtQuantity.Text) ? string.Empty : txtQuantity.Text;
                finishMdata.FinishedGoodsMfgDate = Convert.ToDateTime(txtMfgDate.Text).ToString("dd-MM-yyyy");
                finishMdata.FinishedGoodsStatusId = Convert.ToInt32(dpStatus.SelectedItem.Value); 
                finishMdata.flag = "Insert";
                Result = finishBdata.FinishedGoods(finishMdata);
                if (Result > 0)
                {
                    divDanger.Visible = false;
                    divwarning.Visible = false;
                    divSusccess.Visible = true;
                    
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "sel3", "$('#bx1').addClass('collapsed-box');", true);
                  
                    //string dates;
                    //dates = string.IsNullOrEmpty(txtSearchDate.Text) ? string.Empty : Convert.ToDateTime(txtSearchDate.Text).ToString("dd-MM-yyyy");
                    //GetFinishedGoodReleaseDetails(dates);
                    RMRecieve R = new RMRecieve();
                    R.RMRDate = Convert.ToDateTime(txtDate.Text);

                    GetFinishedGoodReleaseDetails(R);
                    uprouteList.Update();
                    lblSuccess.Text = "Finished Goods Added Successfully";
                    pnlError.Update();
                    //ClearField();
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
            catch(FormatException EX)
            {
                string MSG = EX.ToString();
            }
        }

        protected void btnUpdateFinishGoodsdetail_Click(object sender, EventArgs e)
        {
            try
            {
                finishMdata = new MFinishedGoodsRelease();
                finishBdata = new BFinishedGoodsRelease();
                int Result = 0;
                finishMdata.RMRId = string.IsNullOrEmpty(hId.Value) ? 0 : Convert.ToInt32(hId.Value);
                finishMdata.FinishedGoodsBatchCode = string.IsNullOrEmpty(txtBatchCode.Text) ? string.Empty : txtBatchCode.Text;
                finishMdata.FinishedGoodsDate = Convert.ToDateTime(txtDate.Text).ToString("dd-MM-yyyy");
                finishMdata.FinishedGoodsShiftId = Convert.ToInt32(dpShiftDetails.SelectedItem.Value);
                finishMdata.TypeofMilk = string.IsNullOrEmpty(txtMilkType.Text) ? string.Empty : txtMilkType.Text;
                finishMdata.FinishedGoodsQuantity = string.IsNullOrEmpty(txtQuantity.Text) ? string.Empty : txtQuantity.Text;
                finishMdata.FinishedGoodsMfgDate = Convert.ToDateTime(txtMfgDate.Text).ToString("dd-MM-yyyy");
                finishMdata.FinishedGoodsStatusId = Convert.ToInt32(dpStatus.SelectedItem.Value);
                finishMdata.flag = "Update";
                Result = finishBdata.FinishedGoods(finishMdata);
                if (Result > 0)
                {
                    divDanger.Visible = false;
                    divwarning.Visible = false;
                    divSusccess.Visible = true;
                    lblSuccess.Text = "Finished Goods Updated Successfully";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "sel3", "$('#bx1').addClass('collapsed-box');", true);
                    pnlError.Update();
                    //string dates;
                    //dates = string.IsNullOrEmpty(txtSearchDate.Text) ? string.Empty : Convert.ToDateTime(txtSearchDate.Text).ToString("dd-MM-yyyy");
                    //GetFinishedGoodReleaseDetails(dates);
                    RMRecieve R = new RMRecieve();
                    R.RMRDate = Convert.ToDateTime(txtDate.Text);
                    GetFinishedGoodReleaseDetails(R);
                    uprouteList.Update();
                    //ClearField();
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
            catch (FormatException EX)
            {
                string MSG = EX.ToString();
            }
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                //string dates = Convert.ToDateTime(txtSearchDate.Text).ToString("dd-MM-yyyy");
                //GetFinishedGoodReleaseDetails(dates);
                RMRecieve R = new RMRecieve();
                R.RMRDate = Convert.ToDateTime(txtSearchDate.Text);
                GetFinishedGoodReleaseDetails(R);
            }
            catch (Exception) { }
        }

    }
}
