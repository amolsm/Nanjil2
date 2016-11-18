using Bussiness;
using Dairy.App_code;
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
    public partial class IndentMaterial : System.Web.UI.Page
    {
        IndentCart indentCart;
        PurchaseData purchaseData;
        DataSet DS;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDwon();
                hftokanno.Value = Comman.Comman.RandomString();
                txtTillDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));

            }
        }

        private void BindDropDwon()
        {
            DataSet DS = new DataSet();


            DS = BindCommanData.BindCommanDropDwon("DeptId as ID", "Dept_Name as Name", "tblDepartment", "Dept_Name is not null");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpDepartment.DataSource = DS;
                dpDepartment.DataBind();
                dpDepartment.Items.Insert(0, new ListItem("--Select Department--", "0"));
            }

            ////DS = BindCommanData.GetEmployeeByUserID(GlobalInfo.Userid);
            ////if (!Comman.Comman.IsDataSetEmpty(DS))
            ////{
            ////    txtEmployee.Text = DS.Tables[0].Rows[0]["EmployeeCode"].ToString() + " "+ DS.Tables[0].Rows[0]["EmployeeName"].ToString();
            ////}

            DS = BindCommanData.BindCommanDropDwon("ItemCategoryId as ID", "ItemCategoryName as Name", "Prchs_ItemCategory", "IsActive = 1");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpCategory.DataSource = DS;
                dpCategory.DataBind();
                dpCategory.Items.Insert(0, new ListItem("--Select Caterogy--", "0"));
            }
        }

        protected void dpCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet DS = new DataSet();

            DS = BindCommanData.BindCommanDropDwon("ItemId as ID", "ItemName as Name", "Prchs_Items", "IsActive = 1 and ItemCategory = " + dpCategory.SelectedItem.Value);
           
                dpItem.DataSource = DS;
                dpItem.DataBind();
                dpItem.Items.Insert(0, new ListItem("--Select Item--", "0"));
            dpSelect();
           }

        private void dpSelect()
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "sel1", "$('#MainContent_dpDepartment').addClass('selectpicker');$('#MainContent_dpDepartment').selectpicker();", true);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "sel2", "$('#MainContent_dpCategory').addClass('selectpicker');$('#MainContent_dpCategory').selectpicker();", true);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "sel3", "$('#MainContent_dpItem').addClass('selectpicker');$('#MainContent_dpItem').selectpicker();", true);

        }

        protected void btnAddItem_Click(object sender, EventArgs e)
        {
            indentCart = new IndentCart();
            purchaseData = new PurchaseData();
            indentCart.Tokan = hftokanno.Value;
            indentCart.IndentBy = GlobalInfo.Userid;
            indentCart.ItemId = Convert.ToInt32(dpItem.SelectedItem.Value);
            indentCart.Quantity = Convert.ToDecimal(txtQuantity.Text);
            indentCart.Purpose = txtPurpose.Text;

            indentCart.Flag = 1; //1 for INSERT 

            bool result = purchaseData.IndentCartDML(indentCart);
            if (result)
            {
                bindCartList(indentCart);
            }
            dpSelect();
        }

        private void bindCartList(IndentCart ic)
        {
            purchaseData = new PurchaseData();
            DS = new DataSet();
            ic.Flag = 0; //Get Full List
            rpAgentOrderdetails.DataSource = purchaseData.GetIndentCartList(ic);
            rpAgentOrderdetails.DataBind();

        }

        protected void rpAgentOrderdetails_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int TempID = 0;
            TempID = Convert.ToInt32(e.CommandArgument);
            switch (e.CommandName)
            {
                case ("delete"):
                    {

                        indentCart = new IndentCart();
                        purchaseData = new PurchaseData();
                        indentCart.IndentCartId = TempID;
                        indentCart.Tokan = hftokanno.Value;
                        indentCart.IndentBy = GlobalInfo.Userid;
                        indentCart.Purpose = string.Empty;
                        indentCart.Flag = 2; //2 for delete
                        purchaseData.IndentCartDML(indentCart);

                        bindCartList(indentCart);
                        //RemoveTempID(TempID);
                        //invocie.TokanId = hftokanno.Value;
                        //invocie.UserID = GlobalInfo.Userid;
                        //BindAgntTempItam(invocie);
                        upMain.Update();

                        break;
                    }

            }
        }

        protected void rpAgentOrderdetails_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }

        

        protected void btnNewIndent_Click(object sender, EventArgs e)
        {

        }

        protected void btnSubmitIndent_Click(object sender, EventArgs e)
        {
            Indent indent = new Indent();
            purchaseData = new PurchaseData();
            IndentCart ic = new IndentCart();
            indent.IndentByEmp = GlobalInfo.Userid;
            indent.IndentDate = DateTime.Now;
          // string temp = (Convert.ToDateTime(txtTillDate.Text)).ToString("dd-MM-yyyy");
            indent.TillDate = (Convert.ToDateTime(txtTillDate.Text)).ToString("dd-MM-yyyy");
            indent.Tokan = hftokanno.Value;
            ic.Tokan = hftokanno.Value;
            
            bool result = purchaseData.SubmitIndent(indent);
            if (result)
            {
                ic.Purpose = string.Empty;
                bindCartList(ic);
                clearFields();
                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                pnlError.Update();
                upMain.Update();
               
            }
            else
            {
                divDanger.Visible = false;
                divwarning.Visible = true;
                divSusccess.Visible = false;
                lblwarning.Text = "Please Contact to Site Admin";
                pnlError.Update();
            }

            dpSelect();
        }

        private void clearFields()
        {
            txtQuantity.Text = string.Empty;
            txtPurpose.Text = string.Empty;
            dpCategory.ClearSelection();
            dpItem.ClearSelection();
        }

        protected void btnRemoveItem_Click(object sender, EventArgs e)
        {

        }
    }
}