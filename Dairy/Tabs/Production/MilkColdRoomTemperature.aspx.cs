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
    public partial class ColdRoomTemperatureForMilk : System.Web.UI.Page
    {
        MMilkColdRoomTemperature mcold;
        BMilkColdRoomTemperature bcold;
        DataSet DS = new DataSet();
        DataTable dt = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDwon();
                BindDropDwonStatus();
                txtDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                txtSearchDate.Text= Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                //GetMilkColdRoomTemperatureDetails();
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
            dpStatusDetailsId.DataSource = DS;
            dpStatusDetailsId.DataBind();
            dpStatusDetailsId.Items.Insert(0, new ListItem("--Select Status--", "0"));
            dpStatusDetailsId.Items.FindByText("Release").Enabled = false;
            dpStatusDetailsId.Items.FindByText("Hold").Enabled = false;
            dpStatusDetailsId.Items.FindByText("Yes").Enabled = false;
            dpStatusDetailsId.Items.FindByText("No").Enabled = false;
        }

       

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            {

                mcold = new MMilkColdRoomTemperature();
                bcold = new BMilkColdRoomTemperature();
                int Result = 0;
                mcold.MilkColdRoomTemperaturId = 0;
                mcold.RMRId = string.IsNullOrEmpty(hId.Value) ? 0 : Convert.ToInt32(hId.Value);
                mcold.MilkColdRoomTemperaturDate = Convert.ToDateTime(txtDate.Text.ToString());
                mcold.MilkColdRoomTemperaturShiftId = Convert.ToInt32(dpShiftDetails.SelectedItem.Value);
                //mcold.ColdRoomsForMilk = txtColdRoomsForMilk.Text;
                mcold.ColdRoom1 = txtColdRoom1.Text;
                mcold.ColdRoom2 = txtColdRoom2.Text;
                mcold.ColdRoom3 = txtColdRoom3.Text;
                mcold.CheckedBy = txtCheckedBy.Text;
                mcold.verifierBy = txtverifierBy.Text;
                mcold.BreakAndDownServices = txtBreakDownAndServices.Text;
                mcold.MilkColdRoomStatusId = Convert.ToInt32(dpStatusDetailsId.SelectedItem.Value);
                mcold.flag = "Insert";
                Result = bcold.colddata(mcold);
                if (Result > 0)
                {
                    divDanger.Visible = false;
                    divwarning.Visible = false;
                    divSusccess.Visible = true;
                    
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "sel3", "$('#bx1').addClass('collapsed-box');", true);

                    //string dates;
                    //dates = string.IsNullOrEmpty(txtSearchDate.Text) ? string.Empty : Convert.ToDateTime(txtSearchDate.Text).ToString("dd-MM-yyyy");
                    //GetMilkColdRoomTemperatureDetails(dates);
                    RMRecieve R = new RMRecieve();
                    R.RMRDate = Convert.ToDateTime(txtSearchDate.Text);
                    GetMilkColdRoomTemperatureDetails(R);
                    uprouteList.Update();
                    lblSuccess.Text = "MilkColdRoomTemperature Data Added Successfully";
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

                mcold = new MMilkColdRoomTemperature();
                bcold = new BMilkColdRoomTemperature();
                int Result = 0;
                mcold.MilkColdRoomTemperaturId = 0;
                mcold.RMRId = string.IsNullOrEmpty(hId.Value) ? 0 : Convert.ToInt32(hId.Value);
                mcold.MilkColdRoomTemperaturDate = Convert.ToDateTime(txtDate.Text.ToString());
                mcold.MilkColdRoomTemperaturShiftId = Convert.ToInt32(dpShiftDetails.SelectedItem.Value);
                //mcold.ColdRoomsForMilk = txtColdRoomsForMilk.Text;
                mcold.ColdRoom1 = txtColdRoom1.Text;
                mcold.ColdRoom2 = txtColdRoom2.Text;
                mcold.ColdRoom3 = txtColdRoom3.Text;
                mcold.CheckedBy = txtCheckedBy.Text;
                mcold.verifierBy = txtverifierBy.Text;
                mcold.BreakAndDownServices = txtBreakDownAndServices.Text;
                mcold.MilkColdRoomStatusId = Convert.ToInt32(dpStatusDetailsId.SelectedItem.Value);
                mcold.flag = "Update";
                Result = bcold.colddata(mcold);
                if (Result > 0)
                {
                    divDanger.Visible = false;
                    divwarning.Visible = false;
                    divSusccess.Visible = true;
                   
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "sel3", "$('#bx1').addClass('collapsed-box');", true);
                  
                    //string dates;
                    //dates = string.IsNullOrEmpty(txtSearchDate.Text) ? string.Empty : Convert.ToDateTime(txtSearchDate.Text).ToString("dd-MM-yyyy");
                    //GetMilkColdRoomTemperatureDetails(dates);
                    RMRecieve R = new RMRecieve();
                    R.RMRDate = Convert.ToDateTime(txtSearchDate.Text);
                    GetMilkColdRoomTemperatureDetails(R);
                    uprouteList.Update();
                    lblSuccess.Text = "MilkColdRoomTemperature Data Updated Successfully";
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

        protected void rpMilkColdRoomTemperature_ItemCommand(object source, RepeaterCommandEventArgs e)
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
                        lblHeaderTab.Text = "Edit FilmData Details";
                        hId.Value = Id.ToString();
                        Id = Convert.ToInt32(hId.Value);
                        GetMilkColdRoomTemperatureDetails(Id);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "sel3", "$('#bx1').removeClass('collapsed-box');", true);
                        if (dpStatusDetailsId.SelectedIndex==1)
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

        public void GetMilkColdRoomTemperatureDetails(RMRecieve R)
        {
            bcold = new BMilkColdRoomTemperature();
            DataSet DS = new DataSet();
            DS = bcold.GetMilkColdRoomTemperatureDetails(R);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                rpMilkColdRoomTemperature.DataSource = DS;
                rpMilkColdRoomTemperature.DataBind();
            }
            else if (DS.Tables[0].Rows.Count == 0)
            {
                rpMilkColdRoomTemperature.DataSource = DS;
                rpMilkColdRoomTemperature.DataBind();
            }
        }

        public void GetMilkColdRoomTemperatureDetails(int RMRId)
        {
            DataSet DS = new DataSet();
            bcold = new BMilkColdRoomTemperature();
            DS = bcold.GetMilkColdRoomTemperatureDetailsById(RMRId);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                string DATE = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["MilkColdRoomTemperaturDate"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["MilkColdRoomTemperaturDate"].ToString();
                if (DATE == "")
                {
                    txtDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                }
                else
                {
                    DateTime date1 = Convert.ToDateTime(DATE, System.Globalization.CultureInfo.GetCultureInfo("ur-PK").DateTimeFormat);
                    txtDate.Text = (Convert.ToDateTime(date1).ToString("yyyy-MM-dd"));
                }
                txtBatchNo.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["BatchNo"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["BatchNo"].ToString();
                dpShiftDetails.ClearSelection();
                string ShiftDetails = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["MilkColdRoomTemperaturShiftId"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["MilkColdRoomTemperaturShiftId"].ToString();
                if(ShiftDetails=="")
                {
                    dpShiftDetails.SelectedIndex = 0;
                }
                else
                {
                    dpShiftDetails.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["MilkColdRoomTemperaturShiftId"]).ToString()).Selected = true;
                }
               
                //txtColdRoomsForMilk.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["ColdRoomsForMilk"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["ColdRoomsForMilk"].ToString();
                txtColdRoom1.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["ColdRoom1"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["ColdRoom1"].ToString();
                txtColdRoom2.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["ColdRoom2"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["ColdRoom2"].ToString();
                txtColdRoom3.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["ColdRoom3"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["ColdRoom3"].ToString();
                txtCheckedBy.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["CheckedBy"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["CheckedBy"].ToString();
                txtverifierBy.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["verifierBy"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["verifierBy"].ToString();
                txtBreakDownAndServices.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["BreakAndDownServices"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["BreakAndDownServices"].ToString();
                dpStatusDetailsId.ClearSelection();
                string StatusDetailsId = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["MilkColdRoomStatusId"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["MilkColdRoomStatusId"].ToString();
                if(StatusDetailsId=="")
                {
                    dpStatusDetailsId.SelectedIndex = 2;
                }
                else
                {
                    dpStatusDetailsId.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["MilkColdRoomStatusId"]).ToString()).Selected = true;
                }
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                //string dates = Convert.ToDateTime(txtSearchDate.Text).ToString("dd-MM-yyyy");
                //GetMilkColdRoomTemperatureDetails(dates);
                RMRecieve R = new RMRecieve();
                R.RMRDate = Convert.ToDateTime(txtSearchDate.Text);
                GetMilkColdRoomTemperatureDetails(R);
            }
            catch (Exception) { }
        }
    }
}