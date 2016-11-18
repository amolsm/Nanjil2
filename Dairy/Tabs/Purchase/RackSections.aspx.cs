using Bussiness;
using Model.Purchase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dairy.Tabs.Purchase
{
    public partial class RackSections : System.Web.UI.Page
    {
        DataSet DS;
        Rack rack;
        PurchaseData purchaseData;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetList();
            }
        }

        private void GetList()
        {
            rack = new Rack();
            purchaseData = new PurchaseData();
            DataSet DS = new DataSet();
            rack.Flag = 0; //Select * 
            rack.RackName = string.Empty;
            //rack.Description = string.Empty;
            DS = purchaseData.GetRackList(rack);

            if (!Comman.Comman.IsDataSetEmpty(DS))
            {

                rpBrandInfo.DataSource = DS;
                rpBrandInfo.DataBind();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            btnUpdate.Visible = false;
            btnSubmit.Visible = true;
           
            upModal.Update();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "sel28", "$('#MainContent_txtSectionCount').removeAttr('disabled');", true);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
        }

        protected void rpBrandInfo_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            divDanger.Visible = false;
            divwarning.Visible = false;
            divSusccess.Visible = false;
            pnlError.Update();
            int RackId = 0;
            RackId = Convert.ToInt32(e.CommandArgument);
            switch (e.CommandName)
            {
                case ("Edit"):
                    {

                        hfBrandId.Value = RackId.ToString();
                        RackId = Convert.ToInt32(hfBrandId.Value);
                        GetDetailsById(RackId);
                        upModal.Update();
                        uprouteList.Update();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "sel29", "$('#MainContent_txtSectionCount').attr('disabled', 'disabled');", true);
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                        break;
                    }
               


            }
        }

        private void GetDetailsById(int rackId)
        {
            rack = new Rack();
            purchaseData = new PurchaseData();
            DataSet DS = new DataSet();
            rack.RackId = rackId;
            rack.Flag = 2; //get by id 
            rack.RackName = string.Empty;
            //rack.Description = string.Empty;
            DS = purchaseData.GetRackList(rack);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                txtRackName.Text = DS.Tables[0].Rows[0]["RackName"].ToString();
                dpIsActive.ClearSelection();
                if (DS.Tables[0].Rows[0]["IsActive"].ToString() == "True")
                {
                    dpIsActive.Items.FindByValue("1").Selected = true;
                }
                else { dpIsActive.Items.FindByValue("2").Selected = true; }

                
                btnUpdate.Visible = true;
                btnSubmit.Visible = false;
                upModal.Update();
                
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            rack = new Rack();
            purchaseData = new PurchaseData();

            rack.RackName = string.IsNullOrEmpty(txtRackName.Text.ToString()) ? string.Empty : Convert.ToString(txtRackName.Text);
            //category.Description = string.IsNullOrEmpty(txtDesciption.Text.ToString()) ? string.Empty : Convert.ToString(txtDesciption.Text);
            if (dpIsActive.SelectedItem.Value == "1")
                rack.IsActive = true;
            else rack.IsActive = false;
            rack.SecCount = Convert.ToInt32(txtSectionCount.Text);
            rack.Flag = 1; //1 for INSERT
            //string secs = Convert.ToDouble(txtSectionCount.Text).ToString("000");
            

            
            int Result = 0;
            Result = purchaseData.RacksDML(rack);



            if (Result > 0)
            {

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Rack Sections Add  Successfully";

                ////ClearTextBox();
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

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            rack = new Rack();
            purchaseData = new PurchaseData();
            rack.RackId = Convert.ToInt32(hfBrandId.Value);
            rack.RackName = string.IsNullOrEmpty(txtRackName.Text.ToString()) ? string.Empty : Convert.ToString(txtRackName.Text);
            
            if (dpIsActive.SelectedItem.Value == "1")
                rack.IsActive = true;
            else rack.IsActive = false;
            
            rack.Flag = 3; //3 for Update



            int Result = 0;
            Result = purchaseData.RacksDML(rack);



            if (Result > 0)
            {

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Rack Edited  Successfully";

                ////ClearTextBox();
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