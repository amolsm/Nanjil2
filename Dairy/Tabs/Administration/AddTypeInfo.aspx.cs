using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using Bussiness;
using System.Data;
using Comman;
using System.Text;
using Dairy.App_code;

namespace Dairy.Tabs.Administration
{
    public partial class AddTypeInfo : System.Web.UI.Page
    {
        ProductData productdata;
        Product product;
        DataSet DS;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindTypeInfo();
                btnAddRoute.Visible = true;
                btnupdateroute.Visible = false;
                BindDropDwon();
            }

        }
        public void BindDropDwon()
        {

            DS = BindCommanData.BindCommanDropDwon("CategoryId", "CategoryName", "Category", "IsActive=1");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpCategory.DataSource = DS;
                dpCategory.DataBind();
                dpCategory.Items.Insert(0, new ListItem("--Select Brand--", "0"));
            }

        }
        protected void btnClick_btnAddTypeID(object sender, EventArgs e)
        {

            productdata = new ProductData();
            product = new Product();
            product.TypeID = 0;
            product.TypeName = string.IsNullOrEmpty(txtAddType.Text.ToString()) ? string.Empty : Convert.ToString(txtAddType.Text);

            product.CategoryId = Convert.ToInt32(dpCategory.SelectedItem.Value);
            product.CreatedBy = GlobalInfo.Userid;
            if (dpIsActive.SelectedItem.Value == "1")
            {
                product.IsActive = true;
            }
            else if (dpIsActive.SelectedItem.Text == "2")
            {
                product.IsActive = false;
            }
            //product.IsActive = true;
            product.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
            product.ModifiedBy = GlobalInfo.Userid;
            product.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");
            product.flag = "Insert";
            int Result = 0;
            Result = productdata.AddTypeInfo(product);
            if (Result > 0)
            {

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Product type Add  Successfully";

                ClearTextBox();
                BindTypeInfo();
                pnlError.Update();
                upMain.Update();
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
        protected void btnClick_btnUpdateTypeID(object sender, EventArgs e)
        {


            productdata = new ProductData();
            product = new Product();
            product.TypeID = string.IsNullOrEmpty(hfTypeID.Value) ? 0 : Convert.ToInt32(hfTypeID.Value);
            product.TypeName = string.IsNullOrEmpty(txtAddType.Text.ToString()) ? string.Empty : Convert.ToString(txtAddType.Text);
            product.CreatedBy = GlobalInfo.Userid;
            if (dpIsActive.SelectedItem.Value == "1")
            {
                product.IsActive = true;
            }
            else if (dpIsActive.SelectedItem.Text == "2")
            {
                product.IsActive = false;
            }
            product.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
            product.ModifiedBy = GlobalInfo.Userid;
            product.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");
            product.flag = "Update";
            int Result = 0;
            Result = productdata.AddTypeInfo(product);
            if (Result > 0)
            {

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Product type Updated  Successfully";

                ClearTextBox();
                BindTypeInfo();
                pnlError.Update();
                upMain.Update();
                uprouteList.Update();
                btnupdateroute.Visible = false;
                btnAddRoute.Visible = true;
                
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
        public void ClearTextBox()
        {
            dpCategory.ClearSelection();
            txtAddType.Text = string.Empty;
            dpIsActive.ClearSelection();

        }
        protected void rpRouteList_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {

            divDanger.Visible = false;
            divwarning.Visible = false;
            divSusccess.Visible = false;
            pnlError.Update();
            int TypeID = 0;
            TypeID = Convert.ToInt32(e.CommandArgument);
            switch (e.CommandName)
            {
                case ("Edit"):
                    {
                        lblHeaderTab.Text = "Edit Product Type";
                        hfTypeID.Value = TypeID.ToString();
                        TypeID = Convert.ToInt32(hfTypeID.Value);
                        GetTypeInfobyID(TypeID);
                        btnAddRoute.Visible = false;
                        btnupdateroute.Visible = true;
                        BindTypeInfo();
                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }
                case ("delete"):
                    {

                        hfTypeID.Value = TypeID.ToString();
                        TypeID = Convert.ToInt32(hfTypeID.Value);
                        DeleteTypebyID(TypeID);
                        BindTypeInfo();
                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }


            }
        }
        public void GetTypeInfobyID(int TypeID)
        {

            productdata = new ProductData();
            DS = productdata.GetTypeInfobyID(TypeID);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                txtAddType.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["TypeName"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["TypeName"].ToString();
                dpIsActive.ClearSelection();
                if (dpIsActive.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["IsActive"]).ToString()) != null)
                {
                    dpIsActive.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["IsActive"]).ToString()).Selected = true;
                }
                dpCategory.ClearSelection();
                if (dpCategory.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["CategoryID"]).ToString()) != null)
                {
                    dpCategory.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["CategoryID"]).ToString()).Selected = true;
                }

            }
        }
        public void BindTypeInfo()
        {

            productdata = new ProductData();
            DataSet DS = new DataSet();
            DS = productdata.GetTypeInfo();

            if (!Comman.Comman.IsDataSetEmpty(DS))
            {

                rpTypeMasteInfo.DataSource = DS;
                rpTypeMasteInfo.DataBind();
            }
        }
        public void DeleteTypebyID(int TypeID)
        {

            productdata = new ProductData();
            product = new Product();
            product.TypeID = Convert.ToInt32(TypeID);
            product.TypeName = string.Empty;

            product.CreatedBy = GlobalInfo.Userid;
            product.IsActive = true;
            product.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
            product.ModifiedBy = GlobalInfo.Userid;
            product.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");
            product.flag = "Delete";
            int Result = 0;
            Result = productdata.AddTypeInfo(product);
            if (Result > 0)
            {

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Type Deleted  Successfully";

                ClearTextBox();
                //BindRouteList();
                pnlError.Update();
                upMain.Update();
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