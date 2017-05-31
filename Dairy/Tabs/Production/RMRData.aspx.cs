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
    public partial class RMRData : System.Web.UI.Page
    {
        RMRecieve rmrdata;
        ProductionData proddata;
        DataSet DS = new DataSet();
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDwon();
               // BindDropDwonQC();
                //GetRMRDetails();
                txtDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                txtSearchDate.Text= Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                txtMilkType.Text = "Raw Milk";
                btnUpdateProductindetail.Visible = false;
                //txtRMRQCStatus.Text = "Pending";

                hideQCStatus.Visible = false;

                dpfinishQC.Items.FindByText("Accepted").Enabled = false;
                dpfinishQC.Items.FindByText("Rejected").Enabled = false;
                dpfinishQC.Items.FindByText("Re-Chilling").Enabled = false;
                dpfinishQC.SelectedIndex = 1;


                dpfinishQC.Enabled = false;
                RFVMBRTStart.Enabled = false;
                    RFVMBRTEnd.Enabled = false;
                    RFVTotalHrs.Enabled = false;
             
            }
        }


        protected void BindDropDwon()
        {
            DS = new DataSet();
            DS = BindCommanData.BindCommanDropDwon("ShiftId", "ShiftName as Name", "ShiftDetails", "IsActive =1");
            dpShiftDetails.DataSource = DS;
            dpShiftDetails.DataBind();
            dpShiftDetails.Items.Insert(0, new ListItem("--Select Shift--", "0"));

            DS = new DataSet();
            DS = BindCommanData.BindCommanDropDwon("QCId", "Status as Name", "QCDetails", "IsActive =1");
            dpfinishQC.DataSource = DS;
            dpfinishQC.DataBind();
            dpfinishQC.Items.Insert(0, new ListItem("--Select Status--", "0"));
        }


        
        protected void btnAddProductionInfo_Click(object sender, EventArgs e)
        {
            rmrdata = new RMRecieve();
            proddata = new ProductionData();
            int Result = 0;
            rmrdata.RMRId = 0;
            rmrdata.RMRDate = Convert.ToDateTime(txtDate.Text.ToString());
            rmrdata.RMRShiftId = Convert.ToInt32(dpShiftDetails.SelectedItem.Value);
            rmrdata.BatchNo = txtBatchNo.Text;
            rmrdata.TankMilkReciptNo = txtTankerReceipitNo.Text;
            rmrdata.TankerNo = txtTankerNo.Text;
            rmrdata.Quantity = string.IsNullOrEmpty(txtQty.Text) ? 0 : Convert.ToDouble(txtQty.Text);
            rmrdata.MilkType = string.IsNullOrEmpty(txtMilkType.Text) ? string.Empty : txtMilkType.Text;
            rmrdata.CreatedBy = GlobalInfo.Userid;
            rmrdata.CreatedDate = Convert.ToDateTime(DateTime.Now).ToString("dd-MM-yyyy"); 
            rmrdata.QCId = Convert.ToInt32(dpfinishQC.SelectedItem.Value);
            rmrdata.MBRTStart = string.IsNullOrEmpty(txtMBRTStartTime.Text) ? string.Empty : txtMBRTStartTime.Text;
            rmrdata.MBRTEnd = string.IsNullOrEmpty(txtMBRTEndTime.Text) ? string.Empty : txtMBRTEndTime.Text;
            rmrdata.TotalHours = string.IsNullOrEmpty(txtTotalHours.Text) ? string.Empty : txtTotalHours.Text;
            rmrdata.IsActive = true;
            rmrdata.flag = "Insert";
           // rmrdata.CheckBatchNo = 0;
            Result = proddata.RMRData(rmrdata);
            if (Result > 0)
            {

                //Response.Redirect(Request.RawUrl);
                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
               
                RMRecieve R = new RMRecieve();
                R.RMRDate = Convert.ToDateTime(txtDate.Text);
               
                GetRMRDetails(R);
                uprouteList.Update();
                lblSuccess.Text = "RMR Data Add  Successfully";
                pnlError.Update();
                
            }
            else if (Result == 100)
            {
                divDanger.Visible = true;
                divwarning.Visible = false;
                divSusccess.Visible = false;
                lblSuccess.Text = "Batch No Already Exist";
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

       

       

        protected void rpRMRList_ItemCommand(object source, RepeaterCommandEventArgs e)
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
                        lblHeaderTab.Text = "Edit RMReceive";
                        hId.Value = RMRId.ToString();
                        RMRId = Convert.ToInt32(hId.Value);
                        GetRMRDetails(RMRId);
                       
                        

                        btnAddProductionInfo.Visible = false;
                        btnUpdateProductindetail.Visible = true;
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


        private void BindRepeater(DataTable dt)
        {
            rpRMRList.DataSource = dt;
            rpRMRList.DataBind();

            if (dt.Rows.Count == 0)
            {
                Control FooterTemplate = rpRMRList.Controls[rpRMRList.Controls.Count - 1].Controls[0];
                FooterTemplate.FindControl("trEmpty").Visible = true;
            }

        }


        public void GetRMRDetails(int RMRId)
        {
            DataSet DS = new DataSet();
            ProductionData proddata = new ProductionData();
            DS = proddata.GetRMRDatabyId(RMRId);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                string DATE = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["RMRDate"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["RMRDate"].ToString();
                //sky
                DateTime date1 = Convert.ToDateTime(DATE, System.Globalization.CultureInfo.GetCultureInfo("ur-PK").DateTimeFormat);
                txtDate.Text = (Convert.ToDateTime(date1).ToString("yyyy-MM-dd"));
                txtBatchNo.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["BatchNo"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["BatchNo"].ToString();
                //txtDate.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Date"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Date"].ToString();
                //dpShiftDetails.SelectedValue = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["ShiftId"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["ShiftId"].ToString();
                dpShiftDetails.ClearSelection();
                if (dpShiftDetails.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["RMRShiftId"]).ToString()) != null)
                {
                    dpShiftDetails.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["RMRShiftId"]).ToString()).Selected = true;
                }
                txtTankerReceipitNo.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["TankMilkReciptNo"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["TankMilkReciptNo"].ToString();
                txtTankerNo.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["TankerNo"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["TankerNo"].ToString();
                txtQty.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Qty"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Qty"].ToString();
                txtMilkType.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["TypeOfMilk"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["TypeOfMilk"].ToString();
                txtMBRTStartTime.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["MBRTStartTime"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["MBRTStartTime"].ToString();
                txtMBRTEndTime.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["MBRTEndTime"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["MBRTEndTime"].ToString();
                txtTotalHours.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["TotalHours"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["TotalHours"].ToString();
                //dpfinishQC.Enabled = true;
                dpfinishQC.ClearSelection();
                if (dpfinishQC.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["QCId"]).ToString()) != null)
                {
                    dpfinishQC.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["QCId"]).ToString()).Selected = true;

                    if (dpfinishQC.SelectedItem.Text == "Accepted")
                    {
                        txtMBRTStartTime.ReadOnly = false;
                        txtMBRTStartTime.Text = Convert.ToString(DateTime.Now.ToString("HH:mm"));
                        txtMBRTEndTime.ReadOnly = false;
                        txtTotalHours.ReadOnly = false;
                        
                        RFVMBRTStart.Enabled = true;
                        RFVMBRTEnd.Enabled = true;
                        RFVTotalHrs.Enabled = true;
                    }
                    else if (dpfinishQC.SelectedItem.Text == "Rejected" || dpfinishQC.SelectedItem.Text == "Pending")
                    {
                        txtMBRTStartTime.ReadOnly = true;
                        txtMBRTEndTime.ReadOnly = true;
                        txtTotalHours.ReadOnly = true;
                    }
                }

                txtRMRQCStatus.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Status"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Status"].ToString();

            }
        }


        protected void btnUpdateProductindetail_Click(object sender, EventArgs e)
        {
            RMRecieve RMR = new RMRecieve();
            ProductionData proddata = new ProductionData();
            RMR.RMRId = string.IsNullOrEmpty(hId.Value) ? 0 : Convert.ToInt32(hId.Value);
            RMR.RMRShiftId = Convert.ToInt32(dpShiftDetails.SelectedItem.Value);
            RMR.RMRDate = Convert.ToDateTime(txtDate.Text.ToString());
            RMR.BatchNo = string.IsNullOrEmpty(txtBatchNo.Text) ? string.Empty : txtBatchNo.Text;
            RMR.TankMilkReciptNo = string.IsNullOrEmpty(txtTankerReceipitNo.Text) ? string.Empty : txtTankerReceipitNo.Text; 
            RMR.TankerNo= string.IsNullOrEmpty(txtTankerNo.Text) ? string.Empty : txtTankerNo.Text; 
            RMR.MilkType = string.IsNullOrEmpty(txtMilkType.Text) ? string.Empty : txtMilkType.Text;
            RMR.Quantity = string.IsNullOrEmpty(txtQty.Text) ? 0 : Convert.ToDouble(txtQty.Text);
            RMR.MBRTStart = string.IsNullOrEmpty(txtMBRTStartTime.Text)? string.Empty : txtMBRTStartTime.Text;
            RMR.MBRTEnd= string.IsNullOrEmpty(txtMBRTEndTime.Text) ? string.Empty : txtMBRTEndTime.Text;
            RMR.TotalHours = string.IsNullOrEmpty(txtTotalHours.Text) ? string.Empty : txtTotalHours.Text;
            RMR.CreatedBy = 0;
            RMR.CreatedDate = Convert.ToDateTime(DateTime.Now).ToString("dd-MM-yyyy"); 

            RMR.flag = "Update";
            int Result = 0;
            Result = proddata.RMRData(RMR);
            if (Result > 0)
            {
               
                lblHeaderTab.Text = "Update RMR  Details";
                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                RMRecieve R = new RMRecieve();
                R.RMRDate = Convert.ToDateTime(txtDate.Text);

                GetRMRDetails(R);
                uprouteList.Update();
                lblSuccess.Text = "RMR Updated  Successfully";
                pnlError.Update();
            }
            else
            {
                divDanger.Visible = false;
                divwarning.Visible = true;
                divSusccess.Visible = false;
                lblwarning.Text = "Please Contact to Site Admin";
                pnlError.Update();


            }
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void txtBatchNo_TextChanged(object sender, EventArgs e)
        {
            string batchno = txtBatchNo.Text;
            ProductionData proddata = new ProductionData();
            DS = proddata.GetExistingBatchNo(batchno);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Batch No. Already exists.')", true);
                txtBatchNo.Text = string.Empty;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                RMRecieve R = new RMRecieve();
                ProductionData PD = new ProductionData();
                R.RMRDate = Convert.ToDateTime(txtSearchDate.Text);
                GetRMRDetails(R);
                //uprouteList.Update();
            }
            catch (Exception) { }
        }
        public void GetRMRDetails(RMRecieve R)
        {

            proddata = new ProductionData();
            DataSet DS = new DataSet();
            DS = proddata.GetRMRDetails(R);

            if (!Comman.Comman.IsDataSetEmpty(DS))
            {

                rpRMRList.DataSource = DS;
                rpRMRList.DataBind();
            }
            else if (DS.Tables[0].Rows.Count == 0)
            {

                //this.BindRepeater(dt);

                rpRMRList.DataSource = DS;
                rpRMRList.DataBind();
            }

        }

    }


}

