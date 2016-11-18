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
    public partial class Categories : System.Web.UI.Page
    {
        Category category;
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
            category = new Category();
            purchaseData = new PurchaseData();
            DataSet DS = new DataSet();
            category.Flag = 0; //Select * 
            category.CategoryName = string.Empty;
            category.Description = string.Empty;
            DS = purchaseData.GetCategoryList(category);

            if (!Comman.Comman.IsDataSetEmpty(DS))
            {

                rpBrandInfo.DataSource = DS;
                rpBrandInfo.DataBind();
            }
        }

        protected void rpBrandInfo_ItemCommand(object source, RepeaterCommandEventArgs e)
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
                        
                        hfBrandId.Value = BrandID.ToString();
                        BrandID = Convert.ToInt32(hfBrandId.Value);
                        GetDetailsById(BrandID);
                       
                        uprouteList.Update();
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                        break;
                    }
                case ("delete"):
                    {

                        hfBrandId.Value = BrandID.ToString();
                        BrandID = Convert.ToInt32(hfBrandId.Value);
                       
                        uprouteList.Update();
                        break;
                    }


            }
        }

        private void GetDetailsById(int brandID)
        {
            category = new Category();
            purchaseData = new PurchaseData();
            DataSet DS = new DataSet();

            category.CategoryId = brandID;
            category.CategoryName = string.Empty;
            category.Description = string.Empty;
            category.Flag = 2;

            DS = purchaseData.GetCategoryList(category);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                txtCategoryName.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["ItemCategoryName"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["ItemCategoryName"].ToString();
                txtDesciption.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["ItemCategoryDesc"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["ItemCategoryDesc"].ToString();
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

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            btnUpdate.Visible = false;
            btnSubmit.Visible = true;
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            category = new Category();
            purchaseData = new PurchaseData();
           
            category.CategoryName = string.IsNullOrEmpty(txtCategoryName.Text.ToString()) ? string.Empty : Convert.ToString(txtCategoryName.Text);
            category.Description = string.IsNullOrEmpty(txtDesciption.Text.ToString()) ? string.Empty : Convert.ToString(txtDesciption.Text);
            if (dpIsActive.SelectedItem.Value == "1")
                category.IsActive = true;
            else category.IsActive = false;

            category.Flag = 1; //1 for INSERT

            int Result = 0;
            Result = purchaseData.CategoryDML(category);



            if (Result > 0)
            {

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Category Added  Successfully";

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

        private void ClearTextBox()
        {
            txtCategoryName.Text = string.Empty;
            txtDesciption.Text = string.Empty;
            dpIsActive.ClearSelection();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

            category = new Category();
            purchaseData = new PurchaseData();
            category.CategoryId = string.IsNullOrEmpty(hfBrandId.Value) ? 0 : Convert.ToInt32(hfBrandId.Value);
            category.CategoryName = string.IsNullOrEmpty(txtCategoryName.Text.ToString()) ? string.Empty : Convert.ToString(txtCategoryName.Text);
            category.Description = string.IsNullOrEmpty(txtDesciption.Text.ToString()) ? string.Empty : Convert.ToString(txtDesciption.Text);
            if (dpIsActive.SelectedItem.Value == "1")
                category.IsActive = true;
            else category.IsActive = false;

            category.Flag = 3; //3 for update

            int Result = 0;
            Result = purchaseData.CategoryDML(category);



            if (Result > 0)
            {

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Category Updated  Successfully";

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