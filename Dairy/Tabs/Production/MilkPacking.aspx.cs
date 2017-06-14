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
    public partial class PackedData : System.Web.UI.Page
    {
        MMilkPackedData mpacked;
        BMilkPackedData bpacked;
        DataSet DS = new DataSet();
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDwon();
                txtDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                txtSearchDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                //GetCreamDetails();
                txtBatchCode.ReadOnly = true;
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
            dpPackingDetailStatus.DataSource = DS;
            dpPackingDetailStatus.DataBind();
            dpPackingDetailStatus.Items.FindByText("Release").Enabled = false;
            dpPackingDetailStatus.Items.FindByText("Hold").Enabled = false;
            dpPackingDetailStatus.Items.FindByText("Yes").Enabled = false;
            dpPackingDetailStatus.Items.FindByText("No").Enabled = false;
            dpPackingDetailStatus.Items.Insert(0, new ListItem("--Status--", "0"));
        }

       

        protected void btnAdd_Click1(object sender, EventArgs e)
        {
            {

                mpacked = new MMilkPackedData();
                bpacked = new BMilkPackedData();
                int Result = 0;
                mpacked.PackedDataId = 0;
                mpacked.RMRId = string.IsNullOrEmpty(hId.Value) ? 0 : Convert.ToInt32(hId.Value);
                mpacked.PackedDate = Convert.ToDateTime(txtDate.Text.ToString());
                mpacked.ShiftId = Convert.ToInt32(dpShiftDetails.SelectedItem.Value);
                mpacked.PackingOperatorName = string.IsNullOrEmpty(txtPackingOperatorName.Text) ? string.Empty : txtPackingOperatorName.Text; 
                mpacked.ReceivedBy = string.IsNullOrEmpty(txtReceivedBy.Text) ? string.Empty : txtReceivedBy.Text; 
                mpacked.TypeOfMilk = string.IsNullOrEmpty(txtTypeOfMilk.Text) ? string.Empty : txtTypeOfMilk.Text; 
                mpacked.QuantityIn1000ML = string.IsNullOrEmpty(txtQuantityIn1000.Text) ? 0 : Convert.ToDouble(txtQuantityIn1000.Text);
                mpacked.QuantityIn500ML = string.IsNullOrEmpty(txtQuantityIn500.Text) ? 0 : Convert.ToDouble(txtQuantityIn500.Text);
                mpacked.QuantityIn450ML = string.IsNullOrEmpty(txtQuantityIn450.Text) ? 0 : Convert.ToDouble(txtQuantityIn450.Text);
                mpacked.QuantityIn250ML = string.IsNullOrEmpty(txtQuantityIn250.Text) ? 0 : Convert.ToDouble(txtQuantityIn250.Text);
                mpacked.QuantityIn200ML = string.IsNullOrEmpty(txtQuantityIn200.Text) ? 0 : Convert.ToDouble(txtQuantityIn200.Text);   
                mpacked.TotalQtyOfMilk = string.IsNullOrEmpty(txtTotalOfMilk.Text) ? 0 : Convert.ToDouble(txtTotalOfMilk.Text);
                mpacked.ColdRoomNo = string.IsNullOrEmpty(txtColdRoomNo.Text) ? string.Empty : txtColdRoomNo.Text;
                mpacked.PackingDetailStatusId = Convert.ToInt32(dpPackingDetailStatus.SelectedItem.Value);
                mpacked.flag = "Insert";
                Result = bpacked.packeddata(mpacked);
                if (Result > 0)
                {
                    divDanger.Visible = false;
                    divwarning.Visible = false;
                    divSusccess.Visible = true;
                   
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "sel3", "$('#bx1').addClass('collapsed-box');", true);

                    //string dates;
                    //dates = string.IsNullOrEmpty(txtSearchDate.Text) ? string.Empty : Convert.ToDateTime(txtSearchDate.Text).ToString("dd-MM-yyyy");
                    //GetCreamDetails(dates);
                    RMRecieve R = new RMRecieve();
                    R.RMRDate = Convert.ToDateTime(txtSearchDate.Text);
                    GetCreamDetails(R);
                    uprouteList.Update();
                    lblSuccess.Text = "Packed Data Add  Successfully";
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

                mpacked = new MMilkPackedData();
                bpacked = new BMilkPackedData();
                int Result = 0;
                //mpacked.PackedDataId = 0;
                mpacked.RMRId = string.IsNullOrEmpty(hId.Value) ? 0 : Convert.ToInt32(hId.Value);
                mpacked.PackedDate = Convert.ToDateTime(txtDate.Text.ToString());
                mpacked.ShiftId = Convert.ToInt32(dpShiftDetails.SelectedItem.Value);
                mpacked.PackingOperatorName = string.IsNullOrEmpty(txtPackingOperatorName.Text) ? string.Empty : txtPackingOperatorName.Text;
                mpacked.ReceivedBy = string.IsNullOrEmpty(txtReceivedBy.Text) ? string.Empty : txtReceivedBy.Text;
                mpacked.TypeOfMilk = string.IsNullOrEmpty(txtTypeOfMilk.Text) ? string.Empty : txtTypeOfMilk.Text;
                mpacked.QuantityIn1000ML = string.IsNullOrEmpty(txtQuantityIn1000.Text) ? 0 : Convert.ToDouble(txtQuantityIn1000.Text);
                mpacked.QuantityIn500ML = string.IsNullOrEmpty(txtQuantityIn500.Text) ? 0 : Convert.ToDouble(txtQuantityIn500.Text);
                mpacked.QuantityIn450ML = string.IsNullOrEmpty(txtQuantityIn450.Text) ? 0 : Convert.ToDouble(txtQuantityIn450.Text);
                mpacked.QuantityIn250ML = string.IsNullOrEmpty(txtQuantityIn250.Text) ? 0 : Convert.ToDouble(txtQuantityIn250.Text);
                mpacked.QuantityIn200ML = string.IsNullOrEmpty(txtQuantityIn200.Text) ? 0 : Convert.ToDouble(txtQuantityIn200.Text);
                mpacked.TotalQtyOfMilk = string.IsNullOrEmpty(txtTotalOfMilk.Text) ? 0 : Convert.ToDouble(txtTotalOfMilk.Text);
                mpacked.ColdRoomNo = string.IsNullOrEmpty(txtColdRoomNo.Text) ? string.Empty : txtColdRoomNo.Text;
                mpacked.PackingDetailStatusId = Convert.ToInt32(dpPackingDetailStatus.SelectedItem.Value);
                mpacked.flag = "Update";
                Result = bpacked.packeddata(mpacked);
                if (Result > 0)
                {
                    divDanger.Visible = false;
                    divwarning.Visible = false;
                    divSusccess.Visible = true;
                 
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "sel3", "$('#bx1').addClass('collapsed-box');", true);

                    //string dates;
                    //dates = string.IsNullOrEmpty(txtSearchDate.Text) ? string.Empty : Convert.ToDateTime(txtSearchDate.Text).ToString("dd-MM-yyyy");
                    //GetCreamDetails(dates);
                    RMRecieve R = new RMRecieve();
                    R.RMRDate = Convert.ToDateTime(txtSearchDate.Text);
                    GetCreamDetails(R);
                    lblSuccess.Text = "Packed Data Update  Successfully";
                    uprouteList.Update();
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

        protected void rpPackedDataList_ItemCommand(object source, RepeaterCommandEventArgs e)
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
                        lblHeaderTab.Text = "Edit PackedData Details";
                        hId.Value = RMRId.ToString();
                        RMRId = Convert.ToInt32(hId.Value);
                        GetPackedDetails(RMRId);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "sel3", "$('#bx1').removeClass('collapsed-box');", true);
                        if (dpPackingDetailStatus.SelectedIndex==1)
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
                        
                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }
            }
        }

        public void GetCreamDetails(RMRecieve R)
        {
            bpacked = new BMilkPackedData();
            DataSet DS = new DataSet();
            DS = bpacked.GetPackedDetails(R);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                rpPackedDataList.DataSource = DS;
                rpPackedDataList.DataBind();
            }
            else if (DS.Tables[0].Rows.Count == 0)
            {
                rpPackedDataList.DataSource = DS;
                rpPackedDataList.DataBind();
            }
        }
        public void GetPackedDetails(int RMRId)
        {
            DataSet DS = new DataSet();
            bpacked = new BMilkPackedData();
            DS = bpacked.GetPackedDetailsbyId(RMRId);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                string DATE = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["PackedDate"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["PackedDate"].ToString();
                //sky
                if (DATE == "")
                {
                    txtDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                }
                else
                {
                    DateTime date1 = Convert.ToDateTime(DATE, System.Globalization.CultureInfo.GetCultureInfo("ur-PK").DateTimeFormat);
                    txtDate.Text = (Convert.ToDateTime(date1).ToString("yyyy-MM-dd"));
                }
                txtBatchCode.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["BatchCode"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["BatchCode"].ToString();
                dpShiftDetails.ClearSelection();
                string ShiftDetails = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["ShiftId"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["ShiftId"].ToString();
                if (ShiftDetails == "")
                {
                    dpShiftDetails.SelectedIndex = 0;
                }
                else
                {
                    //if (dpShiftDetails.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["ShiftId"]).ToString()) != null)
                    {
                        dpShiftDetails.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["ShiftId"]).ToString()).Selected = true;
                    }
                }
                txtPackingOperatorName.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["PackingOperatorName"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["PackingOperatorName"].ToString();
                txtReceivedBy.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["ReceivedBy"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["ReceivedBy"].ToString();
                txtTypeOfMilk.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["TypeOfMilk"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["TypeOfMilk"].ToString();
                txtQuantityIn1000.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["QuantityIn1000ML"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["QuantityIn1000ML"].ToString();
                txtQuantityIn500.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["QuantityIn500ML"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["QuantityIn500ML"].ToString();
                txtQuantityIn450.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["QuantityIn450ML"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["QuantityIn450ML"].ToString();
                txtQuantityIn250.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["QuantityIn250ML"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["QuantityIn250ML"].ToString();
                txtQuantityIn200.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["QuantityIn200ML"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["QuantityIn200ML"].ToString();
                txtTotalOfMilk.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["TotalQtyOfMilk"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["TotalQtyOfMilk"].ToString();
                txtColdRoomNo.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["ColdRoomNo"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["ColdRoomNo"].ToString();

                dpPackingDetailStatus.ClearSelection();
                string PackingDetailStatus = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["PackingDetailStatusId"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["PackingDetailStatusId"].ToString();
                if (PackingDetailStatus == "")
                {
                    dpPackingDetailStatus.SelectedIndex = 2;
                }
                else
                {
                    dpPackingDetailStatus.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["PackingDetailStatusId"]).ToString()).Selected = true;
                }
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                RMRecieve R = new RMRecieve();
                ProductionData PD = new ProductionData();
                R.RMRDate = Convert.ToDateTime(txtSearchDate.Text);
                GetCreamDetails(R);
            }
            catch (Exception) { }
        }
    }
}