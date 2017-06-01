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

    public partial class Curd_Processing : System.Web.UI.Page
    {
        MCurdProcessing MCdata;
        BCurdProcessing BCdata;
        DataSet DS = new DataSet();
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDwon();
                //GetCurdProcessDetails();
                txtDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                txtSearchDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                txtBatchNo.ReadOnly = true;
                //txtDate.ReadOnly = true;
                txtMilkType.ReadOnly = true;
                txtQty.ReadOnly = true;
                btnUpdateCurdProcessdetail.Visible = false;
            }
        }

        protected void BindDropDwon()
        {
            DS = new DataSet();
            DS = BindCommanData.BindCommanDropDwon("ShiftId", "ShiftName as Name", "ShiftDetails", "IsActive =1");
            dpCurdProcessShiftId.DataSource = DS;
            dpCurdProcessShiftId.DataBind();
            dpCurdProcessShiftId.Items.Insert(0, new ListItem("--Select Shift--", "0"));

            DS = BindCommanData.BindCommanDropDwon("StatusId", "StatusName as StatusName", "Prod_StatusDetails", "IsActive =1");
            dpCurdProcessingStatusId.DataSource = DS;
            dpCurdProcessingStatusId.DataBind();
            dpCurdProcessingStatusId.Items.FindByText("Release").Enabled = false;
            dpCurdProcessingStatusId.Items.FindByText("Hold").Enabled = false;
            dpCurdProcessingStatusId.Items.FindByText("Yes").Enabled = false;
            dpCurdProcessingStatusId.Items.FindByText("No").Enabled = false;
            dpCurdProcessingStatusId.Items.Insert(0, new ListItem("--Status--", "0"));
        }

        protected void rpCurdProcessingList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
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
                            lblHeaderTab.Text = "Edit Curd Processing Details";
                            hId.Value = Id.ToString();
                            Id = Convert.ToInt32(hId.Value);
                            GetCurdProcessDetails(Id);
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "sel3", "$('#bx1').removeClass('collapsed-box');", true);
                            if (dpCurdProcessingStatusId.SelectedIndex == 1)
                            {
                                btnAddCurdProcessInfo.Visible = false;
                                btnUpdateCurdProcessdetail.Visible = true;
                            }
                            else
                            {
                                btnAddCurdProcessInfo.Visible = true;
                                btnUpdateCurdProcessdetail.Visible = false;
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
        }

        public void GetCurdProcessDetails(RMRecieve R)
        {

            BCdata = new BCurdProcessing();
            DataSet DS = new DataSet();
            DS = BCdata.GetCurdProcessDetails(R);

            if (!Comman.Comman.IsDataSetEmpty(DS))
            {

                rpCurdProcessingList.DataSource = DS;
                rpCurdProcessingList.DataBind();
            }
            else
            {
                rpCurdProcessingList.DataSource = DS;
                rpCurdProcessingList.DataBind();
            }


        }

        public void GetCurdProcessDetails(int RMRId)
        {
            DataSet DS = new DataSet();
            BCurdProcessing BCdata = new BCurdProcessing();
            DS = BCdata.GetCurdProcessDetails(RMRId);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
              
              txtBatchNo.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["BatchNo"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["BatchNo"].ToString();

                if (DS.Tables[0].Rows[0]["CurdProcessDate"].ToString() == "")
                {
                    string DATE = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["RMRDate"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["RMRDate"].ToString();
                    DateTime date1 = Convert.ToDateTime(DATE, System.Globalization.CultureInfo.GetCultureInfo("ur-PK").DateTimeFormat);
                    txtDate.Text = (Convert.ToDateTime(date1).ToString("yyyy-MM-dd"));
                }
                else
                {
                    string DATE = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["CurdProcessDate"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["CurdProcessDate"].ToString();
                    DateTime date1 = Convert.ToDateTime(DATE, System.Globalization.CultureInfo.GetCultureInfo("ur-PK").DateTimeFormat);
                    txtDate.Text = (Convert.ToDateTime(date1).ToString("yyyy-MM-dd"));
                }

                dpCurdProcessShiftId.ClearSelection();
                string CurdProcessShiftId = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["CurdProcessShiftId"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["CurdProcessShiftId"].ToString();
                if(CurdProcessShiftId=="")
                {
                    dpCurdProcessShiftId.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["RMRShiftId"]).ToString()).Selected = true; 
                }
                else
                {
                    dpCurdProcessShiftId.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["CurdProcessShiftId"]).ToString()).Selected = true;
                }
                txtQty.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Qty"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Qty"].ToString();
                txtMilkType.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["TypeOfMilk"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["TypeOfMilk"].ToString();
                txtHeatingTemperature.Text= string.IsNullOrEmpty(DS.Tables[0].Rows[0]["HeatingTemp"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["HeatingTemp"].ToString();
                txtHoldingTime.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["HoldingTime"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["HoldingTime"].ToString();
                txtInoculation.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["InoculationMilkTemp"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["InoculationMilkTemp"].ToString();
                txtCultureName.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["CultureAdd"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["CultureAdd"].ToString();
                txtCulturelotNo.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["CultureLotNo"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["CultureLotNo"].ToString();
                if (DS.Tables[0].Rows[0]["CultureExpDate"].ToString() == "")
                {
                    txtcultureExpDate.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["CultureExpDate"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["CultureExpDate"].ToString();
                }
                else {
                    string DATE1 = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["CultureExpDate"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["CultureExpDate"].ToString();
                    //sky
                    DateTime date2 = Convert.ToDateTime(DATE1, System.Globalization.CultureInfo.GetCultureInfo("ur-PK").DateTimeFormat);
                    txtcultureExpDate.Text = (Convert.ToDateTime(date2).ToString("yyyy-MM-dd"));
                }
                    

                //txtcultureExpDate.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["CultureExpDate"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["CultureExpDate"].ToString();


                txtIncubationStartTime.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["IncubationStartTime"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["IncubationStartTime"].ToString();
                txtIncubationEndTime.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["IncubationEndTime"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["IncubationEndTime"].ToString();
                txtQtyMilkforCanCurd.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["MilkQtyforCanCurd"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["MilkQtyforCanCurd"].ToString();
                txtQtyMilkforCupPouchCurd.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["MilkQtyforCupPouchCurd"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["MilkQtyforCupPouchCurd"].ToString();
                txtPackingStartTime.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["PackingStartTime"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["PackingStartTime"].ToString();
                txtPackingEndTime.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["PackingEndTime"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["PackingEndTime"].ToString();
                txtBatchcode.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["BatchCode"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["BatchCode"].ToString();
                txtColdRoomTemp.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["ColdRoomTemp"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["ColdRoomTemp"].ToString();
                txtProcessedby.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["ProcessedBy"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["ProcessedBy"].ToString();
                txtLabTechnician.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["LabTechnician"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["LabTechnician"].ToString();
                txtVerifiedBy.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["VerifiedBy"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["VerifiedBy"].ToString();
                txtApprovedBy.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["ApprovedBy"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["ApprovedBy"].ToString();
                dpCurdProcessingStatusId.ClearSelection();
                string CurdProcessingStatusId = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["CurdProcessingStatusId"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["CurdProcessingStatusId"].ToString();
                if(CurdProcessingStatusId=="")
                {
                    dpCurdProcessingStatusId.SelectedIndex = 2;
                }
                else
                {
                    dpCurdProcessingStatusId.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["CurdProcessingStatusId"]).ToString()).Selected = true;
                }
            }
        }

        protected void btnAddCurdProcessInfo_Click(object sender, EventArgs e)
        {
            MCdata = new MCurdProcessing();
            BCdata = new BCurdProcessing();
            int Result = 0;
            MCdata.CurdId = 0;
            MCdata.RMRId= string.IsNullOrEmpty(hId.Value) ? 0 : Convert.ToInt32(hId.Value);
            MCdata.CurdProcessDate = Convert.ToDateTime(txtDate.Text).ToString("dd-MM-yyyy");
            MCdata.CurdProcessShiftId = Convert.ToInt32(dpCurdProcessShiftId.SelectedItem.Value); 
            MCdata.HeatingTemp= string.IsNullOrEmpty(txtHeatingTemperature.Text) ? 0 : Convert.ToDouble(txtHeatingTemperature.Text);
            MCdata.HoldingTime= string.IsNullOrEmpty(txtHoldingTime.Text) ? string.Empty : txtHoldingTime.Text;
            MCdata.InoculationMilkTemp= string.IsNullOrEmpty(txtInoculation.Text) ? 0 : Convert.ToDouble(txtInoculation.Text);
            MCdata.CultureAdd = string.IsNullOrEmpty(txtCultureName.Text) ? string.Empty : txtCultureName.Text;
            MCdata.CultureLotNo= string.IsNullOrEmpty(txtCulturelotNo.Text) ? string.Empty : txtCulturelotNo.Text;
            MCdata.CultureExpDate= Convert.ToDateTime(txtcultureExpDate.Text).ToString("dd-MM-yyyy");
            MCdata.IncubationStartTime= string.IsNullOrEmpty(txtIncubationStartTime.Text) ? string.Empty : txtIncubationStartTime.Text;
            MCdata.IncubationEndTime= string.IsNullOrEmpty(txtIncubationStartTime.Text) ? string.Empty : txtIncubationStartTime.Text;
            MCdata.MilkQtyforCanCurd= string.IsNullOrEmpty(txtQtyMilkforCanCurd.Text) ? 0 : Convert.ToDouble(txtQtyMilkforCanCurd.Text);
            MCdata.MilkQtyforCupPouchCurd= string.IsNullOrEmpty(txtQtyMilkforCupPouchCurd.Text) ? 0 : Convert.ToDouble(txtQtyMilkforCupPouchCurd.Text);
            MCdata.PackingStartTime= string.IsNullOrEmpty(txtPackingStartTime.Text) ? string.Empty : txtPackingStartTime.Text;
            MCdata.PackingEndTime = string.IsNullOrEmpty(txtPackingEndTime.Text) ? string.Empty : txtPackingEndTime.Text;
            MCdata.BatchCode = string.IsNullOrEmpty(txtBatchcode.Text) ? string.Empty : txtBatchcode.Text;
            MCdata.ColdRoomTemp = string.IsNullOrEmpty(txtColdRoomTemp.Text) ? 0 : Convert.ToDouble(txtColdRoomTemp.Text);
            MCdata.ProcessedBy = string.IsNullOrEmpty(txtProcessedby.Text) ? string.Empty : txtProcessedby.Text;
            MCdata.LabTechnician = string.IsNullOrEmpty(txtLabTechnician.Text) ? string.Empty : txtLabTechnician.Text;
            MCdata.VerifiedBy = string.IsNullOrEmpty(txtVerifiedBy.Text) ? string.Empty : txtVerifiedBy.Text;
            MCdata.ApprovedBy= string.IsNullOrEmpty(txtApprovedBy.Text) ? string.Empty : txtApprovedBy.Text;
            MCdata.CurdProcessingStatusId = Convert.ToInt32(dpCurdProcessingStatusId.SelectedItem.Value);
            MCdata.flag = "Insert";
            Result = BCdata.CurdProcessData(MCdata);
            if (Result > 0)
            {
                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
               
                ScriptManager.RegisterStartupScript(this, this.GetType(), "sel3", "$('#bx1').addClass('collapsed-box');", true);

                //string dates = string.IsNullOrEmpty(txtSearchDate.Text) ? string.Empty : Convert.ToDateTime(txtSearchDate.Text).ToString("dd-MM-yyyy");
                //GetCurdProcessDetails(dates);
                RMRecieve R = new RMRecieve();
                R.RMRDate = Convert.ToDateTime(txtSearchDate.Text);
                GetCurdProcessDetails(R);
                uprouteList.Update();
                lblSuccess.Text = "Curd Processing Data Added Successfully";
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

        protected void btnUpdateCurdProcessdetail_Click(object sender, EventArgs e)
        {

            MCdata = new MCurdProcessing();
            BCdata = new BCurdProcessing();
            int Result = 0;
            MCdata.CurdId = 0;
            MCdata.RMRId = string.IsNullOrEmpty(hId.Value) ? 0 : Convert.ToInt32(hId.Value);
            MCdata.CurdProcessDate = Convert.ToDateTime(txtDate.Text).ToString("dd-MM-yyyy");
            MCdata.CurdProcessShiftId = Convert.ToInt32(dpCurdProcessShiftId.SelectedItem.Value);
            MCdata.HeatingTemp = string.IsNullOrEmpty(txtHeatingTemperature.Text) ? 0 : Convert.ToDouble(txtHeatingTemperature.Text);
            MCdata.HoldingTime = string.IsNullOrEmpty(txtHoldingTime.Text) ? string.Empty : txtHoldingTime.Text;
            MCdata.InoculationMilkTemp = string.IsNullOrEmpty(txtInoculation.Text) ? 0 : Convert.ToDouble(txtInoculation.Text);
            MCdata.CultureAdd = string.IsNullOrEmpty(txtCultureName.Text) ? string.Empty : txtCultureName.Text;
            MCdata.CultureLotNo = string.IsNullOrEmpty(txtCulturelotNo.Text) ? string.Empty : txtCulturelotNo.Text;
            MCdata.CultureExpDate = Convert.ToDateTime(txtcultureExpDate.Text).ToString("dd-MM-yyyy");
            MCdata.IncubationStartTime = string.IsNullOrEmpty(txtIncubationStartTime.Text) ? string.Empty : txtIncubationStartTime.Text;
            MCdata.IncubationEndTime = string.IsNullOrEmpty(txtIncubationStartTime.Text) ? string.Empty : txtIncubationStartTime.Text;
            MCdata.MilkQtyforCanCurd = string.IsNullOrEmpty(txtQtyMilkforCanCurd.Text) ? 0 : Convert.ToDouble(txtQtyMilkforCanCurd.Text);
            MCdata.MilkQtyforCupPouchCurd = string.IsNullOrEmpty(txtQtyMilkforCupPouchCurd.Text) ? 0 : Convert.ToDouble(txtQtyMilkforCupPouchCurd.Text);
            MCdata.PackingStartTime = string.IsNullOrEmpty(txtPackingStartTime.Text) ? string.Empty : txtPackingStartTime.Text;
            MCdata.PackingEndTime = string.IsNullOrEmpty(txtPackingEndTime.Text) ? string.Empty : txtPackingEndTime.Text;
            MCdata.BatchCode = string.IsNullOrEmpty(txtBatchcode.Text) ? string.Empty : txtBatchcode.Text;
            MCdata.ColdRoomTemp = string.IsNullOrEmpty(txtColdRoomTemp.Text) ? 0 : Convert.ToDouble(txtColdRoomTemp.Text);
            MCdata.ProcessedBy = string.IsNullOrEmpty(txtProcessedby.Text) ? string.Empty : txtProcessedby.Text;
            MCdata.LabTechnician = string.IsNullOrEmpty(txtLabTechnician.Text) ? string.Empty : txtLabTechnician.Text;
            MCdata.VerifiedBy = string.IsNullOrEmpty(txtVerifiedBy.Text) ? string.Empty : txtVerifiedBy.Text;
            MCdata.ApprovedBy = string.IsNullOrEmpty(txtApprovedBy.Text) ? string.Empty : txtApprovedBy.Text;
            MCdata.CurdProcessingStatusId = Convert.ToInt32(dpCurdProcessingStatusId.SelectedItem.Value);
            MCdata.flag = "Update";
            Result = BCdata.CurdProcessData(MCdata);
            if (Result > 0)
            {
                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
               
                ScriptManager.RegisterStartupScript(this, this.GetType(), "sel3", "$('#bx1').addClass('collapsed-box');", true);
             
                //string dates = string.IsNullOrEmpty(txtSearchDate.Text) ? string.Empty : Convert.ToDateTime(txtSearchDate.Text).ToString("dd-MM-yyyy");
                //GetCurdProcessDetails(dates);
                RMRecieve R = new RMRecieve();
                R.RMRDate = Convert.ToDateTime(txtSearchDate.Text);
                GetCurdProcessDetails(R);
                uprouteList.Update();
                lblSuccess.Text = "Curd Processing Data Updated Successfully";
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
            try
            {
                //string dates = Convert.ToDateTime(txtSearchDate.Text).ToString("dd-MM-yyyy");
                //GetCurdProcessDetails(dates);
                RMRecieve R = new RMRecieve();
                ProductionData PD = new ProductionData();
                R.RMRDate = Convert.ToDateTime(txtSearchDate.Text);
                GetCurdProcessDetails(R);
            }
            catch (Exception) { }
           
        }
    }
}