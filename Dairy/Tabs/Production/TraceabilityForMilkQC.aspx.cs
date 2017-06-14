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
    public partial class TraceabilityForMilkQC : System.Web.UI.Page
    {
        MTraceabilityMilkQC mtracqc;
        BTraceabilityMilkQC btracqc;
        DataSet DS=new DataSet();
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDwon();
                txtSkimDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                txtPackingDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                txtSearchDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                //GetTraceabilityDetails();
                txtBatchNo.ReadOnly = true;
              
            }
        }

        protected void BindDropDwon()
        {
            DS = new DataSet();
            DS = BindCommanData.BindCommanDropDwon("ShiftId", "ShiftName as Name", "ShiftMaster", "IsActive =1");
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

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            {

                mtracqc = new MTraceabilityMilkQC();
                btracqc = new BTraceabilityMilkQC();
                int Result = 0;
                mtracqc.TraceabilityMilkQCId = 0;
                mtracqc.RMRId = string.IsNullOrEmpty(hId.Value) ? 0 : Convert.ToInt32(hId.Value);
                mtracqc.CreamAndSkimDate = Convert.ToDateTime(txtSkimDate.Text.ToString());
                mtracqc.PackingDate = Convert.ToDateTime(txtPackingDate.Text.ToString());
                mtracqc.TraceabilitMilkQCShiftId = Convert.ToInt32(dpShiftDetails.SelectedItem.Value);
                mtracqc.TankerCode = string.IsNullOrEmpty(txtTankerCode.Text) ? string.Empty : txtTankerCode.Text;
                mtracqc.SMPBatchCode = string.IsNullOrEmpty(txtSMPBatchcode.Text) ? string.Empty : txtSMPBatchcode.Text;
                mtracqc.TankerPampingTime = string.IsNullOrEmpty(txtPumpinghr.Text) ? string.Empty : txtPumpinghr.Text;
                mtracqc.ChilledMilkSiloNo =string.IsNullOrEmpty(txtChilledMilkSiloNo.Text) ? string.Empty : txtChilledMilkSiloNo.Text;
                mtracqc.ProcessSiloNo = string.IsNullOrEmpty(txtProcessSiloNo.Text) ?string.Empty : txtProcessSiloNo.Text;
                mtracqc.CreamTemperature = string.IsNullOrEmpty(txtCreamTemperature.Text) ? 0 : Convert.ToDouble(txtCreamTemperature.Text);
                mtracqc.SkimTemperature = string.IsNullOrEmpty(txtSkimTemperature.Text) ? 0 : Convert.ToDouble(txtSkimTemperature.Text);
                mtracqc.FAT = string.IsNullOrEmpty(txtFAT.Text) ? 0 : Convert.ToDouble(txtFAT.Text);
                mtracqc.Taste = string.IsNullOrEmpty(txtTaste.Text) ? string.Empty : txtTaste.Text;
                mtracqc.Smell = string.IsNullOrEmpty(txtSmell.Text) ? string.Empty : txtSmell.Text;
                mtracqc.Color = string.IsNullOrEmpty(txtColor.Text) ? string.Empty : txtColor.Text;
                mtracqc.PhosphatasTest = string.IsNullOrEmpty(txtPhosphataseTest.Text)?string.Empty :txtPhosphataseTest.Text;
                mtracqc.Acidity = string.IsNullOrEmpty(txtAcidity.Text) ? 0 : Convert.ToDouble(txtAcidity.Text);
                mtracqc.CLR = string.IsNullOrEmpty(txtCLR.Text) ? 0 : Convert.ToDouble(txtCLR.Text);
                //mtracqc.Color = string.IsNullOrEmpty(txtColor.Text) ? 0 : Convert.ToDouble(txtColor.Text);
                mtracqc.PackedCode = string.IsNullOrEmpty(txtPacketCode.Text)? string.Empty : txtPacketCode.Text;
                mtracqc.SNF = string.IsNullOrEmpty(txtSNF.Text) ? 0 : Convert.ToDouble(txtSNF.Text);
                mtracqc.Technician = string.IsNullOrEmpty(txtTechnician.Text) ? string.Empty : txtTechnician.Text;
                mtracqc.TraceabilityStatusId = Convert.ToInt32(dpStatus.SelectedItem.Value);
                mtracqc.flag = "Insert";
                Result = btracqc.tracqcdata(mtracqc);
                if (Result > 0)
                {
                    divDanger.Visible = false;
                    divwarning.Visible = false;
                    divSusccess.Visible = true;
                    lblSuccess.Text = "Traceability Data Added Successfully";
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

                //return Result;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            {

                mtracqc = new MTraceabilityMilkQC();
                btracqc = new BTraceabilityMilkQC();
                int Result = 0;
                mtracqc.RMRId = string.IsNullOrEmpty(hId.Value) ? 0 : Convert.ToInt32(hId.Value);
                mtracqc.CreamAndSkimDate = Convert.ToDateTime(txtSkimDate.Text.ToString());
                mtracqc.PackingDate = Convert.ToDateTime(txtPackingDate.Text.ToString());
                mtracqc.TraceabilitMilkQCShiftId = Convert.ToInt32(dpShiftDetails.SelectedItem.Value);
                mtracqc.TankerCode = string.IsNullOrEmpty(txtTankerCode.Text) ? string.Empty : txtTankerCode.Text;
                mtracqc.SMPBatchCode = string.IsNullOrEmpty(txtSMPBatchcode.Text) ? string.Empty : txtSMPBatchcode.Text;
                mtracqc.TankerPampingTime = string.IsNullOrEmpty(txtPumpinghr.Text) ? string.Empty : txtPumpinghr.Text;
                mtracqc.ChilledMilkSiloNo = string.IsNullOrEmpty(txtChilledMilkSiloNo.Text) ? string.Empty : txtChilledMilkSiloNo.Text;
                mtracqc.ProcessSiloNo = string.IsNullOrEmpty(txtProcessSiloNo.Text) ? string.Empty : txtProcessSiloNo.Text;
                mtracqc.CreamTemperature = string.IsNullOrEmpty(txtCreamTemperature.Text) ? 0 : Convert.ToDouble(txtCreamTemperature.Text);
                mtracqc.SkimTemperature = string.IsNullOrEmpty(txtSkimTemperature.Text) ? 0 : Convert.ToDouble(txtSkimTemperature.Text);
                mtracqc.FAT = string.IsNullOrEmpty(txtFAT.Text) ? 0 : Convert.ToDouble(txtFAT.Text);
                mtracqc.Taste = string.IsNullOrEmpty(txtTaste.Text) ? string.Empty : txtTaste.Text;
                mtracqc.Smell = string.IsNullOrEmpty(txtSmell.Text) ? string.Empty : txtSmell.Text;
                mtracqc.Color = string.IsNullOrEmpty(txtColor.Text) ? string.Empty : txtColor.Text;
                mtracqc.PhosphatasTest = string.IsNullOrEmpty(txtPhosphataseTest.Text) ? string.Empty : txtPhosphataseTest.Text;
                mtracqc.Acidity = string.IsNullOrEmpty(txtAcidity.Text) ? 0 : Convert.ToDouble(txtAcidity.Text);
                mtracqc.CLR = string.IsNullOrEmpty(txtCLR.Text) ? 0 : Convert.ToDouble(txtCLR.Text);
                //mtracqc.Color = string.IsNullOrEmpty(txtColor.Text) ? 0 : Convert.ToDouble(txtColor.Text);
                mtracqc.PackedCode = string.IsNullOrEmpty(txtPacketCode.Text) ? string.Empty : txtPacketCode.Text;
                mtracqc.SNF = string.IsNullOrEmpty(txtSNF.Text) ? 0 : Convert.ToDouble(txtSNF.Text);
                mtracqc.Technician = string.IsNullOrEmpty(txtTechnician.Text) ? string.Empty : txtTechnician.Text;
                mtracqc.TraceabilityStatusId = Convert.ToInt32(dpStatus.SelectedItem.Value);
                mtracqc.flag = "Update";
                Result = btracqc.tracqcdata(mtracqc);
                if (Result > 0)
                {
                    divDanger.Visible = false;
                    divwarning.Visible = false;
                    divSusccess.Visible = true;
                    lblSuccess.Text = "Traceability Data Updated  Successfully";
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

                //return Result;
            }
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void rpTraceabilityQC_ItemCommand(object source, RepeaterCommandEventArgs e)
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
                        GetTraceabilityDetails(Id);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "sel3", "$('#bx1').removeClass('collapsed-box');", true);
                        if (dpStatus.SelectedIndex ==1)
                        {
                            btnAdd.Visible = false;
                            btnUpdate.Visible = true;
                            lblHeaderTab.Text = "Edit Traceability Details";
                        }
                 else
                        {
                            btnAdd.Visible = true;
                            btnUpdate.Visible = false;
                            lblHeaderTab.Text = "Add Traceability Details";
                        }
                        btnRefresh.Visible = true;
                        
                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }
            }
        }

        public void GetTraceabilityDetails(RMRecieve R)
        {
            btracqc = new BTraceabilityMilkQC();
            DataSet DS = new DataSet();
            DS = btracqc.GetTraceabilityDetails(R);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                rpTraceabilityQC.DataSource = DS;
                rpTraceabilityQC.DataBind();
            }
            else
            {
                rpTraceabilityQC.DataSource = DS;
                rpTraceabilityQC.DataBind();
            }
        }


        public void GetTraceabilityDetails(int RMRId)
        {
            DataSet DS = new DataSet();
            btracqc = new BTraceabilityMilkQC();
            DS = btracqc.GetTraceabilityQCDetailsById(RMRId);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                string DATE = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["CreamAndSkimDate"].ToString()) ? string.Empty : Convert.ToDateTime(DS.Tables[0].Rows[0]["CreamAndSkimDate"]).ToString("yyyy-MM-dd");
                txtSkimDate.Text = DATE;
                string DATE1 = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["PackingDate"].ToString()) ? string.Empty : Convert.ToDateTime(DS.Tables[0].Rows[0]["PackingDate"]).ToString("yyyy-MM-dd");
                txtPackingDate.Text = DATE1;
                
                txtBatchNo.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["BatchNo"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["BatchNo"].ToString();
                dpShiftDetails.ClearSelection();
                try
                {
                    if (dpShiftDetails.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["TraceabilitMilkQCShiftId"]).ToString()) != null)
                    {
                        dpShiftDetails.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["TraceabilitMilkQCShiftId"]).ToString()).Selected = true;
                    }
                }
                catch(InvalidCastException)
                {
                    dpShiftDetails.SelectedIndex = 0;
                }
                txtTankerCode.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["TankerCode"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["TankerCode"].ToString();
                txtSMPBatchcode.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["SMPBatchCode"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["SMPBatchCode"].ToString();
                txtPumpinghr.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["TotalHours"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["TotalHours"].ToString();
                txtChilledMilkSiloNo.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["ChilledMilkSiloNo"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["ChilledMilkSiloNo"].ToString();
                txtProcessSiloNo.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["ProcessSiloNo"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["ProcessSiloNo"].ToString();
                txtCreamTemperature.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["CreamTemperature"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["CreamTemperature"].ToString();
                txtSkimTemperature.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["SkimTemperature"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["SkimTemperature"].ToString();
                txtFAT.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["FAT"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["FAT"].ToString();
                txtTaste.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Taste"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Taste"].ToString();
                txtSmell.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Smell"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Smell"].ToString();
                txtColor.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Color"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Color"].ToString();
                txtPhosphataseTest.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["PhosphatasTest"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["PhosphatasTest"].ToString();
                txtPacketCode.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["PackedCode"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["PackedCode"].ToString();
                txtAcidity.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Acidity"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Acidity"].ToString();
                txtCLR.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["CLR"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["CLR"].ToString();
                txtSNF.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["SNF"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["SNF"].ToString();
                txtTechnician.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Technician"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Technician"].ToString();

                dpStatus.ClearSelection();
                string TraceabilityStatusId = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["TraceabilityStatusId"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["TraceabilityStatusId"].ToString();
                if(TraceabilityStatusId=="")
                {
                    dpStatus.SelectedIndex = 2;
                }
                else
                {
                    dpStatus.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["TraceabilityStatusId"]).ToString()).Selected = true;
                }
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                //string dates = Convert.ToDateTime(txtSearchDate.Text).ToString("dd-MM-yyyy");
                //GetTraceabilityDetails(dates);
                RMRecieve R = new RMRecieve();
                ProductionData PD = new ProductionData();
                R.RMRDate = Convert.ToDateTime(txtSearchDate.Text);
                GetTraceabilityDetails(R);
            }
            catch (Exception) { }
        }
    }
}