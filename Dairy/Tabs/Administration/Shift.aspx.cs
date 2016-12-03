using DataAccess.Admin;
using Model.Admin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dairy.Tabs.Administration
{
    public partial class Shift : System.Web.UI.Page
    {
        Shifts shift;
        DBShift dbShift;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetList();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            btnUpdate.Visible = false;
            btnSubmit.Visible = true;
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
        }

        protected void rpShiftList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            divDanger.Visible = false;
            divwarning.Visible = false;
            divSusccess.Visible = false;
            pnlError.Update();
            int BrandID = 0;
            BrandID = Convert.ToInt32(e.CommandArgument);
            switch (e.CommandName)
            {
                case ("Edit"):
                    {

                        hfShiftId.Value = BrandID.ToString();
                        BrandID = Convert.ToInt32(hfShiftId.Value);
                        GetDetailsById(BrandID);

                        uprouteList.Update();
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                        break;
                    }
                case ("delete"):
                    {

                        hfShiftId.Value = BrandID.ToString();
                        BrandID = Convert.ToInt32(hfShiftId.Value);

                        uprouteList.Update();
                        break;
                    }


            }
        }

        private void GetDetailsById(int Id)
        {
            shift = new Shifts();
            dbShift = new DBShift();
            DataSet DS = new DataSet();

            shift.ShiftId = Id;
            shift.ShiftName = string.Empty;
            shift.StartTime = string.Empty;
            shift.Description = string.Empty;
            shift.EndTime = string.Empty;
            shift.Flag = 2;

            DS = dbShift.GetShiftList(shift);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                txtShiftName.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["ShiftName"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["ShiftName"].ToString();
                txtDesciption.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Description"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Description"].ToString();
                txtStartTime.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["StartTime"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["StartTime"].ToString();
                txtEndTime.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["EndTime"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["EndTime"].ToString();
                dpIsActive.ClearSelection();
                if (DS.Tables[0].Rows[0]["IsActive"].ToString() == "True")
                {
                    dpIsActive.Items.FindByValue("1").Selected = true;
                }
                else { dpIsActive.Items.FindByValue("2").Selected = true; }
            }
            btnSubmit.Visible = false;
            btnUpdate.Visible = true;
            upModal.Update();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            shift = new Shifts();
            dbShift = new DBShift();

            shift.ShiftName = string.IsNullOrEmpty(txtShiftName.Text.ToString()) ? string.Empty : Convert.ToString(txtShiftName.Text);
            shift.Description = string.IsNullOrEmpty(txtDesciption.Text.ToString()) ? string.Empty : Convert.ToString(txtDesciption.Text);
            shift.StartTime = string.IsNullOrEmpty(txtStartTime.Text.ToString()) ? string.Empty : Convert.ToDateTime(txtStartTime.Text).ToString("HH:mm");
            shift.EndTime = string.IsNullOrEmpty(txtEndTime.Text.ToString()) ? string.Empty : Convert.ToDateTime(txtEndTime.Text).ToString("HH:mm");
            if (dpIsActive.SelectedItem.Value == "1")
                shift.Status = true;
            else shift.Status = false;

            shift.Flag = 1; //1 for INSERT

            int Result = 0;
            Result = dbShift.ShiftDML(shift);



            if (Result > 0)
            {

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Shift Added  Successfully";

                ClearTextBox();
                GetList();
                pnlError.Update();

                uprouteList.Update();
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

        private void GetList()
        {
            shift = new Shifts();
            dbShift = new DBShift();
            DataSet DS = new DataSet();
            shift.Flag = 0; //Select * 
            shift.ShiftName = string.Empty;
            shift.StartTime = string.Empty;
            shift.Description = string.Empty;
            shift.EndTime = string.Empty;
            DS = dbShift.GetShiftList(shift);

            if (!Comman.Comman.IsDataSetEmpty(DS))
            {

                rpShiftList.DataSource = DS;
                rpShiftList.DataBind();
            }
        }

        private void ClearTextBox()
        {
           
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            shift = new Shifts();
            dbShift = new DBShift();
            shift.ShiftId = Convert.ToInt32(hfShiftId.Value);
            shift.ShiftName = string.IsNullOrEmpty(txtShiftName.Text.ToString()) ? string.Empty : Convert.ToString(txtShiftName.Text);
            shift.Description = string.IsNullOrEmpty(txtDesciption.Text.ToString()) ? string.Empty : Convert.ToString(txtDesciption.Text);
            shift.StartTime = string.IsNullOrEmpty(txtStartTime.Text.ToString()) ? string.Empty : Convert.ToDateTime(txtStartTime.Text).ToString("HH:mm");
            shift.EndTime = string.IsNullOrEmpty(txtEndTime.Text.ToString()) ? string.Empty : Convert.ToDateTime(txtEndTime.Text).ToString("HH:mm");
            if (dpIsActive.SelectedItem.Value == "1")
                shift.Status = true;
            else shift.Status = false;

            shift.Flag = 3; //3 for Update

            int Result = 0;
            Result = dbShift.ShiftDML(shift);



            if (Result > 0)
            {

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Shift Updated  Successfully";

                ClearTextBox();
                GetList();
                pnlError.Update();

                uprouteList.Update();
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
    }
}