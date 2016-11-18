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
    public partial class Items : System.Web.UI.Page
    {
        PurchaseData purchaseData;
        Item item;
        DataSet DS;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDown();
                GetList();
            }

        }

        private void BindDropDown()
        {
             DS = new DataSet();
            
            DS = BindCommanData.BindCommanDropDwon("ItemCategoryId", "ItemCategoryName as Name", "Prchs_ItemCategory", "IsActive=1 ");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpCategory.DataSource = DS;
                dpCategory.DataBind();
                dpCategory.Items.Insert(0, new ListItem("--Select Category--", "0"));
            }
            DS = BindCommanData.BindCommanDropDwon("RackId", "RackName as Name", "Prchs_Rack", "IsActive=1 ");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpRack.DataSource = DS;
                dpRack.DataBind();
                dpRack.Items.Insert(0, new ListItem("--Select Rack--", "0"));
            }
        }

        private void GetList()
        {
            item = new Item();
            purchaseData = new PurchaseData();
            DataSet DS = new DataSet();
            item.Flag = 0; //Select * 
            item.ItemName = string.Empty;
            item.ItemDescription = string.Empty;

            DS = purchaseData.GetItemList(item);

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
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            item = new Item();
            purchaseData = new PurchaseData();

            item.CategoryId = Convert.ToInt32(dpCategory.SelectedItem.Value);
            item.ItemName = string.IsNullOrEmpty(txtItemName.Text.ToString()) ? string.Empty : Convert.ToString(txtItemName.Text);
            item.ItemDescription = string.IsNullOrEmpty(txtDesciption.Text.ToString()) ? string.Empty : Convert.ToString(txtDesciption.Text);
            if (dpIsActive.SelectedItem.Value == "1")
                item.IsActive = true;
            else item.IsActive = false;

            item.Flag = 1; //1 for INSERT

            int Result = 0;
            Result = purchaseData.ItemDML(item);



            if (Result > 0)
            {
                submitItemRackSection(4);
               // ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('.modal-backdrop').removeClass(.modal-backdrop);", true);
                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Item Added Successfully";

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

        private void submitItemRackSection(int flag, int Itmid=0)
        {
            item = new Item();
            purchaseData = new PurchaseData();
            item.Flag = 6; //deleting existing ItemsRackSections
            item.ItemName = string.Empty;
            item.ItemDescription = string.Empty;
            item.ItemId = Itmid;
            purchaseData.ItemDML(item);

            foreach (ListItem li in lbSection.Items)
            {
                if (li.Selected)
                {
                    try
                    {
                        item.RackId = Convert.ToInt32(dpRack.SelectedItem.Value);
                        item.SectionId = Convert.ToInt32(li.Value);
                        item.Flag = flag; //for Adding(4) or updating ItemsRackSections
                        item.ItemName = string.Empty;
                        item.ItemDescription = string.Empty;
                        item.ItemId = Itmid;
                        int Result = 0;
                        Result = purchaseData.ItemDML(item);

                    }
                    catch (ArgumentException ex)
                    { }
                }

            }
        }

        private void ClearTextBox()
        {
            txtDesciption.Text = string.Empty;
            txtItemName.Text = string.Empty;
            dpCategory.ClearSelection();
            dpIsActive.ClearSelection();
            dpRack.ClearSelection();
            lbSection.Items.Clear();

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            item = new Item();
            purchaseData = new PurchaseData();
            item.ItemId = Convert.ToInt32(hfBrandId.Value);
            item.CategoryId = Convert.ToInt32(dpCategory.SelectedItem.Value);
            item.ItemName = string.IsNullOrEmpty(txtItemName.Text.ToString()) ? string.Empty : Convert.ToString(txtItemName.Text);
            item.ItemDescription = string.IsNullOrEmpty(txtDesciption.Text.ToString()) ? string.Empty : Convert.ToString(txtDesciption.Text);
            if (dpIsActive.SelectedItem.Value == "1")
                item.IsActive = true;
            else item.IsActive = false;

            item.Flag = 3; //3 for update

            int Result = 0;
            Result = purchaseData.ItemDML(item);



            if (Result > 0)
            {
                submitItemRackSection(5, item.ItemId);
                // ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('.modal-backdrop').removeClass(.modal-backdrop);", true);
                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Item Updated Successfully";

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

        protected void rpBrandInfo_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            divDanger.Visible = false;
            divwarning.Visible = false;
            divSusccess.Visible = false;
            pnlError.Update();
            int ItemId = 0;
            ItemId = Convert.ToInt32(e.CommandArgument);
            switch (e.CommandName)
            {
                case ("Edit"):
                    {

                        hfBrandId.Value = ItemId.ToString();
                        ItemId = Convert.ToInt32(hfBrandId.Value);
                        GetDetailsById(ItemId);

                        uprouteList.Update();
                        break;
                    }
                case ("delete"):
                    {

                        hfBrandId.Value = ItemId.ToString();
                        ItemId = Convert.ToInt32(hfBrandId.Value);

                        uprouteList.Update();
                        break;
                    }


            }
        }

        private void GetDetailsById(int itemId)
        {
            item = new Item();
            purchaseData = new PurchaseData();
            DataSet DS = new DataSet();

            item.ItemId = itemId;
            item.ItemName = string.Empty;
            item.ItemDescription = string.Empty;
            item.Flag = 2;

            DS = purchaseData.GetItemList(item);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                txtItemName.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["ItemName"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["ItemName"].ToString();
                txtDesciption.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["ItemDescription"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["ItemDescription"].ToString();
                dpCategory.ClearSelection();
                if (dpCategory.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["ItemCategory"]).ToString()) != null)
                {
                    dpCategory.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["ItemCategory"]).ToString()).Selected = true;
                }
                dpIsActive.ClearSelection();
                if (DS.Tables[0].Rows[0]["IsActive"].ToString() == "True")
                {
                    dpIsActive.Items.FindByValue("1").Selected = true;
                }
                else { dpIsActive.Items.FindByValue("2").Selected = true; }

                dpRack.ClearSelection();
                if (dpRack.Items.FindByValue(Convert.ToInt32(DS.Tables[1].Rows[0]["RackId"]).ToString()) != null)
                {
                    dpRack.Items.FindByValue(Convert.ToInt32(DS.Tables[1].Rows[0]["RackId"]).ToString()).Selected = true;
                }
                string rackid = (DS.Tables[1].Rows[0]["RackId"]).ToString();
                loadListBox(rackid);

                List<string> nams = new List<string>();
                foreach (DataRow row in DS.Tables[1].Rows)
                {
                    //lbSection.Items.FindByValue(Convert.ToInt32(DS.Tables[1].Rows[0]["RackSectionId"]).ToString()).Selected = true;
                    nams.Add(row["RackSectionId"].ToString());
                }
                
               
                foreach (ListItem li in lbSection.Items)
                {
                    if (nams.Contains(li.Value))
                    
                        li.Selected = true;
                }
            }
            btnSubmit.Visible = false;
            btnUpdate.Visible = true;
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);

        }

        protected void dpRack_SelectedIndexChanged(object sender, EventArgs e)
        {
            string rackid = dpRack.SelectedItem.Value;
            loadListBox(rackid);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
        }

        private void loadListBox(string rackid)
        {
            DS = new DataSet();

            DS = BindCommanData.BindCommanDropDwon("RackSectionId", "RackSectionName as Name", "Prchs_RackSections", "RackId =" + rackid);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {

                lbSection.DataSource = DS;

                lbSection.DataBind();
                //dpSection.Items.Insert(0, new ListItem("--Select Section--", "0"));
            }

            Rack rack = new Rack();
            purchaseData = new PurchaseData();
            rack.RackId = Convert.ToInt32(rackid);
            rack.RackName = string.Empty;
            rack.Flag = 10; //Get assigned sections by rackid
            DS = purchaseData.GetRackList(rack);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                lblAssignedSecs.Text ="Assigned Sections : "+ DS.Tables[0].Rows[0]["SecNames"].ToString();
            }
        }

        protected void btnCloseModal_Click(object sender, EventArgs e)
        {
            Response.Redirect("Items.aspx");
        }
    }
}