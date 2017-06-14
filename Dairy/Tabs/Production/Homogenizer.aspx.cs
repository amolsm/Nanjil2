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
    public partial class Homogenizer : System.Web.UI.Page
    {
        MHomogenizer mhomo;
        BHomogenizer bhomo;
        DataSet DS = new DataSet();
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDwon();
                BindDropDwonStatus();
                BindDropDwonOilLeakage();
                txtHomogenizerDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                txtSearchDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                //GetHomogenizerDetails();
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
        }

        protected void BindDropDwonStatus()
        {
            DS = new DataSet();
            DS = BindCommanData.BindCommanDropDwon("StatusId", "StatusName as Name", "Prod_StatusDetails", "IsActive =1");
            dpStatusDetails.DataSource = DS;
            dpStatusDetails.DataBind();
            dpStatusDetails.Items.FindByText("Release").Enabled = false;
            dpStatusDetails.Items.FindByText("Hold").Enabled = false;
            dpStatusDetails.Items.FindByText("Yes").Enabled = false;
            dpStatusDetails.Items.FindByText("No").Enabled = false;
            dpStatusDetails.Items.Insert(0, new ListItem("--Select Status--", "0"));
        }

        protected void BindDropDwonOilLeakage()
        {
            DS = new DataSet();
            DS = BindCommanData.BindCommanDropDwon("StatusId", "StatusName as Name", "Prod_StatusDetails", "IsActive =1");
            dpOilLeakage.DataSource = DS;
            dpOilLeakage.DataBind();
            dpOilLeakage.Items.FindByText("Release").Enabled = false;
            dpOilLeakage.Items.FindByText("Hold").Enabled = false;
            dpOilLeakage.Items.FindByText("Complete").Enabled = false;
            dpOilLeakage.Items.FindByText("Pending").Enabled = false;
            dpOilLeakage.Items.Insert(0, new ListItem("--Select Status--", "0"));
        }


        protected void btnAdd_Click(object sender, EventArgs e)
        {
            {

                mhomo = new MHomogenizer();
                bhomo = new BHomogenizer();
                int Result = 0;
                mhomo.HomogenizerId = 0;
                mhomo.RMRId = string.IsNullOrEmpty(hId.Value) ? 0 : Convert.ToInt32(hId.Value);
                mhomo.HomogenizerDate = Convert.ToDateTime(txtHomogenizerDate.Text.ToString());
                mhomo.HomogenizerShiftId = Convert.ToInt32(dpShiftDetails.SelectedItem.Value);
                mhomo.PressureFirstStage = string.IsNullOrEmpty(txtPressureFisrtStage.Text) ? 0 : Convert.ToDouble(txtPressureFisrtStage.Text);
                mhomo.PressureSecondStage = string.IsNullOrEmpty(txtPressureSecondStage.Text) ? 0 : Convert.ToDouble(txtPressureSecondStage.Text);
                //mhomo.Oilleakage = string.IsNullOrEmpty(txtOilleakage.Text) ? 0 : Convert.ToDouble(txtOilleakage.Text);
                mhomo.OilleakageId = Convert.ToInt32(dpOilLeakage.SelectedItem.Value);
                mhomo.HomogenizedQty = string.IsNullOrEmpty(txtQtyHomogenized.Text) ? 0 : Convert.ToDouble(txtQtyHomogenized.Text);
                mhomo.Technician = txtTechnician.Text;
                //mhomo.Homogenized = txtHomogenized.Text;
                mhomo.Remarks = txtRemarks.Text;
                mhomo.MachineStartTime = txtStartingTime.Text;
                mhomo.MachineEndTime = txtEndTime.Text;
                mhomo.Technician = txtTechnician.Text;
                mhomo.HomogenizerStatusId = Convert.ToInt32(dpStatusDetails.SelectedItem.Value);
                mhomo.flag = "Insert";
                Result = bhomo.homodata(mhomo);
                if (Result > 0)
                {
                    divDanger.Visible = false;
                    divwarning.Visible = false;
                    divSusccess.Visible = true;
                   
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "sel3", "$('#bx1').addClass('collapsed-box');", true);
                    //string dates;
                    //dates = string.IsNullOrEmpty(txtSearchDate.Text) ? string.Empty : Convert.ToDateTime(txtSearchDate.Text).ToString("dd-MM-yyyy");
                    //GetHomogenizerDetails(dates);
                    RMRecieve R = new RMRecieve();
                    R.RMRDate = Convert.ToDateTime(txtSearchDate.Text);
                    GetHomogenizerDetails(R);
                    uprouteList.Update();
                    lblSuccess.Text = "Homogenizer Data Add  Successfully";
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

                mhomo = new MHomogenizer();
                bhomo = new BHomogenizer();
                int Result = 0;
                mhomo.HomogenizerId = 0;
                mhomo.RMRId = string.IsNullOrEmpty(hId.Value) ? 0 : Convert.ToInt32(hId.Value);
                mhomo.HomogenizerDate = Convert.ToDateTime(txtHomogenizerDate.Text.ToString());
                mhomo.HomogenizerShiftId = Convert.ToInt32(dpShiftDetails.SelectedItem.Value);
                //mhomo.StatusId = Convert.ToInt32(dpStatusDetails.SelectedItem.Value);
                mhomo.PressureFirstStage = string.IsNullOrEmpty(txtPressureFisrtStage.Text) ? 0 : Convert.ToDouble(txtPressureFisrtStage.Text);
                mhomo.PressureSecondStage = string.IsNullOrEmpty(txtPressureSecondStage.Text) ? 0 : Convert.ToDouble(txtPressureSecondStage.Text);
                // mhomo.Oilleakage = string.IsNullOrEmpty(txtOilleakage.Text) ? 0 : Convert.ToDouble(txtOilleakage.Text);

                mhomo.OilleakageId = Convert.ToInt32(dpOilLeakage.SelectedItem.Value);

                mhomo.HomogenizedQty = string.IsNullOrEmpty(txtQtyHomogenized.Text) ? 0 : Convert.ToDouble(txtQtyHomogenized.Text);
                mhomo.Technician = txtTechnician.Text;
                //mhomo.Homogenized = txtHomogenized.Text;
                mhomo.Remarks = txtRemarks.Text;
                mhomo.MachineStartTime = txtStartingTime.Text;
                mhomo.MachineEndTime = txtEndTime.Text;
                mhomo.Technician = txtTechnician.Text;
                mhomo.HomogenizerStatusId = Convert.ToInt32(dpStatusDetails.SelectedItem.Value);
                mhomo.flag = "Update";
                Result = bhomo.homodata(mhomo);
                if (Result > 0)
                {
                    divDanger.Visible = false;
                    divwarning.Visible = false;
                    divSusccess.Visible = true;                   
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "sel3", "$('#bx1').addClass('collapsed-box');", true);                  
                    //string dates;
                    //dates = string.IsNullOrEmpty(txtSearchDate.Text) ? string.Empty : Convert.ToDateTime(txtSearchDate.Text).ToString("dd-MM-yyyy");
                    //GetHomogenizerDetails(dates);
                    RMRecieve R = new RMRecieve();
                    R.RMRDate = Convert.ToDateTime(txtSearchDate.Text);
                    GetHomogenizerDetails(R);
                    uprouteList.Update();
                    lblSuccess.Text = "Homogenizer Data Update  Successfully";
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

        protected void rpHomogenizer_ItemCommand(object source, RepeaterCommandEventArgs e)
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
                        lblHeaderTab.Text = "Edit Traceability Details";
                        hId.Value = Id.ToString();
                        Id = Convert.ToInt32(hId.Value);

                        GetHomogenizerDetails(Id);

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "sel3", "$('#bx1').removeClass('collapsed-box');", true);

                        txtStartingTime.Text = Convert.ToString(DateTime.Now.ToString("HH:mm"));



                        if (txtStartingTime.Text == string.Empty || txtEndTime.Text == string.Empty)
                        {
                            dpStatusDetails.SelectedItem.Text = "Pending";
                        }
                        else
                        {
                            dpStatusDetails.SelectedItem.Text = "Complete";
                        }

                        if (dpStatusDetails.SelectedItem.Text == "Pending")
                        {
                            btnAdd.Visible = true;
                            btnUpdate.Visible = false;

                        }
                        else
                        {
                            btnUpdate.Visible = true;
                            btnAdd.Visible = false;
                        }
                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }
            }
        }

        public void GetHomogenizerDetails(RMRecieve R)
        {
            bhomo = new BHomogenizer();
            DataSet DS = new DataSet();
            DS = bhomo.GetHomogenizerDetails(R);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                rpHomogenizer.DataSource = DS;
                rpHomogenizer.DataBind();
            }
            else if (DS.Tables[0].Rows.Count == 0)
            {
                //this.BindRepeater(dt);
                rpHomogenizer.DataSource = DS;
                rpHomogenizer.DataBind();
            }
        }
        private void BindRepeater(DataTable dt)
        {
            rpHomogenizer.DataSource = dt;
            rpHomogenizer.DataBind();

            if (dt.Rows.Count == 0)
            {
                Control FooterTemplate = rpHomogenizer.Controls[rpHomogenizer.Controls.Count - 1].Controls[0];
                FooterTemplate.FindControl("trEmpty").Visible = true;
            }

        }

        public void GetHomogenizerDetails(int RMRId)
        {
            DataSet DS = new DataSet();
            bhomo = new BHomogenizer();
            DS = bhomo.GetHomogenizerDetailsById(RMRId);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                string DATE = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["HomogenizerDate"].ToString()) ? string.Empty : Convert.ToDateTime(DS.Tables[0].Rows[0]["HomogenizerDate"]).ToString("yyyy-MM-dd");
                if (DATE == "")
                {
                    txtHomogenizerDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));

                }
                else
                {
                    txtHomogenizerDate.Text = DATE;

                }
                txtBatchNo.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["BatchNo"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["BatchNo"].ToString();

                dpShiftDetails.ClearSelection();
                try
                {
                    if (dpShiftDetails.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["HomogenizerShiftId"]).ToString()) != null)
                    {
                        dpShiftDetails.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["HomogenizerShiftId"]).ToString()).Selected = true;
                    }
                }
                catch (InvalidCastException)
                {
                    dpShiftDetails.SelectedIndex = 0;
                }
                //dpStatusDetails.ClearSelection();
                //if (dpStatusDetails.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["StatusId"]).ToString()) != null)
                //{
                //    dpStatusDetails.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["StatusId"]).ToString()).Selected = true;
                //}
                txtPressureFisrtStage.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["PressureFirstStage"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["PressureFirstStage"].ToString();
                txtPressureSecondStage.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["PressureSecondStage"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["PressureSecondStage"].ToString();
                //txtOilleakage.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Oilleakage"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Oilleakage"].ToString();
                dpOilLeakage.ClearSelection();
                try
                {
                    if (dpOilLeakage.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["OilleakageId"]).ToString()) != null)
                    {
                        dpOilLeakage.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["OilleakageId"]).ToString()).Selected = true;
                    }
                }
                catch (InvalidCastException)
                {
                    dpOilLeakage.SelectedIndex = 0;
                }
                txtQtyHomogenized.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["HomogenizedQty"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["HomogenizedQty"].ToString();
                txtTechnician.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Technician"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Technician"].ToString();
                //txtHomogenized.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Homogenized"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Homogenized"].ToString();
                txtRemarks.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Remarks"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Remarks"].ToString();
                txtStartingTime.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["MachineStartTime"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["MachineStartTime"].ToString();
                txtEndTime.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["MachineEndTime"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["MachineEndTime"].ToString();

                dpStatusDetails.ClearSelection();
                string StatusDetails = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["HomogenizerStatusId"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["HomogenizerStatusId"].ToString();

                if (StatusDetails == "")
                {
                    dpStatusDetails.SelectedIndex = 2;

                }
                else
                {
                    dpStatusDetails.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["HomogenizerStatusId"]).ToString()).Selected = true;
                }
                //try
                //{
                //    dpStatusDetails.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["HomogenizerStatusId"]).ToString()).Selected = true;
                //}
                //catch (InvalidCastException)
                //{
                //    dpStatusDetails.SelectedIndex = 2;
                //}
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try {
                //string dates = Convert.ToDateTime(txtSearchDate.Text).ToString("dd-MM-yyyy");
                //GetHomogenizerDetails(dates);
                RMRecieve R = new RMRecieve();
                ProductionData PD = new ProductionData();
                R.RMRDate = Convert.ToDateTime(txtSearchDate.Text);
                GetHomogenizerDetails(R);
            }
            catch (Exception) { }
    }
    }
}