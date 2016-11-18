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
    public partial class AddProduct : System.Web.UI.Page
    {
        ProductData productdata;
        Product product;
        DataSet DS;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindProduct();
                BindDropDown();
                btnAddProduct.Visible = true;
                btnupdateProduct.Visible = false;
                //txtProductName.ReadOnly = true;
            }
        }


        public void BindDropDown()
        {
            DS = new DataSet();
            productdata = new ProductData();
            DS = BindCommanData.BindCommanDropDwon("TypeID", "TypeName as Name", "TypeMaster", "IsArchive=1");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpType.DataSource = DS;
                dpType.DataTextField = "Name";
                dpType.DataValueField = "TypeID";
                dpType.DataBind();
                dpType.Items.Insert(0, new ListItem("--Select TypeName  --", "0"));

            }



            DS = BindCommanData.BindCommanDropDwon("CategoryId", "CategoryName as Name", "Category", "IsActive=1");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpBrand.DataSource = DS;
                dpBrand.DataBind();
                dpBrand.Items.Insert(0, new ListItem("--Select Brand--", "0"));
            }

            //DS = BindCommanData.BindCommanDropDwon("StateID", "StateName", "State", "IsArchive=0");
            //if (!Comman.Comman.IsDataSetEmpty(DS))
            //{
            //    dpState.DataSource = DS;
            //    dpState.DataTextField = "StateName";
            //    dpState.DataValueField = "StateID";
            //    dpState.DataBind();
            //    dpState.Items.Insert(0, new ListItem("--Select StateName  --", "0"));

            //}

            DS = BindCommanData.BindCommanDropDwon("SlabID", "SlabName", "SlabMaster", "IsArchive=0");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpSlab.DataSource = DS;
                dpSlab.DataTextField = "SlabName";
                dpSlab.DataValueField = "SlabID";
                dpSlab.DataBind();
                dpSlab.Items.Insert(0, new ListItem("--Select SlabName  --", "0"));

            }
            DS = BindCommanData.BindCommanDropDwon("CommodityID", "CommodityName", "Commodity", "IsArchive=0");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpCommodity.DataSource = DS;
                dpCommodity.DataTextField = "CommodityName";
                dpCommodity.DataValueField = "CommodityID";
                dpCommodity.DataBind();
                dpCommodity.Items.Insert(0, new ListItem("--Select Commodity--", "0"));

            }

            DS = BindCommanData.BindCommanDropDwon("UnitID", "UnitName", "Unit", "IsArchive=0");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpUnit.DataSource = DS;
                dpUnit.DataTextField = "UnitName";
                dpUnit.DataValueField = "UnitID";
                dpUnit.DataBind();
                dpUnit.Items.Insert(0, new ListItem("--Select UnitName  --", "0"));

            }
            DS = new DataSet();
            DS = BindCommanData.BindCommanDropDwonDistinct("LocId", "State as Name", "StateMaster", "LocId is not null");
            dpState.DataSource = DS;
            dpState.DataBind();
            dpState.Items.Insert(0, new ListItem("--Select State--", "0"));
        }

        public void BindProduct()
        {
            productdata = new ProductData();
            DataSet DS = new DataSet();
            DS = productdata.BindProduct();

            if (!Comman.Comman.IsDataSetEmpty(DS))
            {

                rpProductInfo.DataSource = DS;
                rpProductInfo.DataBind();
            }

        }

        protected void btnClick_btnAddProducrID(object sender, EventArgs e)
        {

            productdata = new ProductData();
            product = new Product();
            product.ProductID = 0;
            product.ProductName = txtProductName.Text ;
            product.ProductCode = "A123";

            product.TypeID = string.IsNullOrEmpty(dpType.SelectedItem.ToString()) ? 0 : Convert.ToInt32(dpType.SelectedValue);
            product.CommodityID = string.IsNullOrEmpty(dpCommodity.SelectedItem.ToString()) ? 0 : Convert.ToInt32(dpCommodity.SelectedValue);
            product.BrandID = string.IsNullOrEmpty(dpBrand.SelectedItem.ToString()) ? 0 : Convert.ToInt32(dpBrand.SelectedValue);
            product.State = Convert.ToString(dpState.SelectedValue);
            product.SlabID = string.IsNullOrEmpty(dpSlab.SelectedItem.ToString()) ? 0 : Convert.ToInt32(dpSlab.SelectedValue);


            product.Quantity = string.IsNullOrEmpty(txtQuantity.Text.ToString()) ? 0.0 : Convert.ToDouble(txtQuantity.Text);

            product.UnitID = string.IsNullOrEmpty(dpUnit.SelectedItem.ToString()) ? 0 : Convert.ToInt32(dpUnit.SelectedValue);
            product.TypeID = string.IsNullOrEmpty(dpType.SelectedItem.ToString()) ? 0 : Convert.ToInt32(dpType.SelectedValue);
            product.Prize = string.IsNullOrEmpty(txtPrize.Text.ToString()) ? 0.0 : Convert.ToDouble(txtPrize.Text);
            product.SlabCode = "";
            product.CreatedBy = GlobalInfo.Userid;
            product.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
            product.ModifiedBy = GlobalInfo.Userid;
            product.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");
            product.flag = "Insert";
            int Result = 0;
            Result = productdata.AddProductInfo(product);



            if (Result > 0)
            {
               // txtProductName.ReadOnly = true;

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Product Add  Successfully";
                clearText();
                BindProduct();
                btnupdateProduct.Visible = false;
                btnAddProduct.Visible = true;
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

        protected void dpType_SelectedIndexChanged(object sender, EventArgs e)
        {

            DS = new DataSet();
            DS = BindCommanData.BindCommanDropDwon("CommodityID", "CommodityName as Name", "Commodity", "   typeID=" + Convert.ToInt32(dpType.SelectedItem.Value) + " and   IsArchive=0");
            // DS = BindCommanData.BindCommanDropDwon("CommodityID", "CommodityName", "Commodity", "IsArchive=0");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpCommodity.DataSource = DS;
                dpCommodity.DataTextField = "Name";
                dpCommodity.DataValueField = "CommodityID";
                dpCommodity.DataBind();
                dpCommodity.Items.Insert(0, new ListItem("--Select CommodityName  --", "0"));
                dpCommodity.Focus();

            }
        }
        protected void btnClick_btnUpdateProductID(object sender, EventArgs e)
        {

            productdata = new ProductData();
            product = new Product();
            product.ProductID = Convert.ToInt32(hfProductID.Value);
            //product.ProductName = "XYZ";
            product.ProductCode = "B122";
            product.ProductName = txtProductName.Text.ToString();
            product.TypeID = string.IsNullOrEmpty(dpType.SelectedItem.ToString()) ? 0 : Convert.ToInt32(dpType.SelectedValue);
            product.CommodityID = string.IsNullOrEmpty(dpCommodity.SelectedItem.ToString()) ? 0 : Convert.ToInt32(dpCommodity.SelectedValue);
            product.BrandID = string.IsNullOrEmpty(dpBrand.SelectedItem.ToString()) ? 0 : Convert.ToInt32(dpBrand.SelectedValue);
            product.State = Convert.ToString(dpState.SelectedValue);
            product.SlabID = string.IsNullOrEmpty(dpSlab.SelectedItem.ToString()) ? 0 : Convert.ToInt32(dpSlab.SelectedValue);


            product.Quantity = string.IsNullOrEmpty(txtQuantity.Text.ToString()) ? 0.0 : Convert.ToDouble(txtQuantity.Text);

            product.UnitID = string.IsNullOrEmpty(dpUnit.SelectedItem.ToString()) ? 0 : Convert.ToInt32(dpUnit.SelectedValue);
            product.TypeID = string.IsNullOrEmpty(dpType.SelectedItem.ToString()) ? 0 : Convert.ToInt32(dpType.SelectedValue);
            product.Prize = string.IsNullOrEmpty(txtPrize.Text.ToString()) ? 0.0 : Convert.ToDouble(txtPrize.Text);
            product.SlabCode = "";
            product.CreatedBy = GlobalInfo.Userid;
            product.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
            product.ModifiedBy = GlobalInfo.Userid;
            product.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");
            product.flag = "Update";
            int Result = 0;
            Result = productdata.UpdateProductInfo(product);



            if (Result > 0)
            {

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Product Updated  Successfully";
                clearText();
                BindProduct();
                btnupdateProduct.Visible = false;
                btnAddProduct.Visible = true;
                pnlError.Update();
                upMain.Update();
                uprouteList.Update();
               // txtProductName.ReadOnly = true;
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

        public void clearText()
        {
            dpBrand.ClearSelection();
            dpCommodity.ClearSelection();
            dpSlab.ClearSelection();
            dpState.ClearSelection();
            dpType.ClearSelection();
            dpUnit.ClearSelection();
            txtPrize.Text = string.Empty;
            txtProduct.Text = string.Empty;
            txtQuantity.Text = string.Empty;
            txtProductName.Text = string.Empty;
        }


        protected void rpRouteList_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {

            divDanger.Visible = false;
            divwarning.Visible = false;
            divSusccess.Visible = false;
            pnlError.Update();
            int ProductID = 0;
            ProductID = Convert.ToInt32(e.CommandArgument);
            switch (e.CommandName)
            {
                case ("Edit"):
                    {
                        txtProductName.ReadOnly = false;

                        lblHeaderTab.Text = "Edit Product";
                        hfProductID.Value = ProductID.ToString();
                        ProductID = Convert.ToInt32(hfProductID.Value);
                        GetProductByID(ProductID);
                        btnAddProduct.Visible = false;
                        btnupdateProduct.Visible = true;

                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }
                case ("delete"):
                    {

                        hfProductID.Value = ProductID.ToString();
                        ProductID = Convert.ToInt32(hfProductID.Value);
                        DeleteByProductID(ProductID);

                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }


            }
        }



        public void GetProductByID(int ProductID)
        {
            productdata = new ProductData();
            DS = productdata.GetProductByID(ProductID);
            clearText();
            txtProduct.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["ProductCode"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["ProductCode"].ToString();
            txtProductName.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["ProductName"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["ProductName"].ToString();
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {

                if (dpType.Items.FindByValue(DS.Tables[0].Rows[0]["TypeID"].ToString()) != null)
                {

                    dpType.Items.FindByValue(DS.Tables[0].Rows[0]["TypeID"].ToString()).Selected = true;
                }
                if (dpCommodity.Items.FindByValue(DS.Tables[0].Rows[0]["CommodityID"].ToString()) != null)
                {

                    dpCommodity.Items.FindByValue(DS.Tables[0].Rows[0]["CommodityID"].ToString()).Selected = true;
                }
                if (dpBrand.Items.FindByValue(DS.Tables[0].Rows[0]["BrandID"].ToString()) != null)
                {

                    dpBrand.Items.FindByValue(DS.Tables[0].Rows[0]["BrandID"].ToString()).Selected = true;
                }
                if (dpState.Items.FindByValue(DS.Tables[0].Rows[0]["State"].ToString()) != null)
                {

                    dpState.Items.FindByValue(DS.Tables[0].Rows[0]["State"].ToString()).Selected = true;
                }
                if (dpSlab.Items.FindByValue(DS.Tables[0].Rows[0]["SlabID"].ToString()) != null)
                {

                    dpSlab.Items.FindByValue(DS.Tables[0].Rows[0]["SlabID"].ToString()).Selected = true;
                }

                txtQuantity.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Quantity"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Quantity"].ToString();
                if (dpUnit.Items.FindByValue(DS.Tables[0].Rows[0]["UnitID"].ToString()) != null)
                {

                    dpUnit.Items.FindByValue(DS.Tables[0].Rows[0]["UnitID"].ToString()).Selected = true;
                }

                txtPrize.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Prize"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Prize"].ToString();


            }
        }

        public void DeleteByProductID(int ProductID)
        {
            productdata = new ProductData();
            product = new Product();
            product.ProductID = Convert.ToInt32(hfProductID.Value);


            product.TypeID = string.IsNullOrEmpty(dpType.SelectedItem.ToString()) ? 0 : Convert.ToInt32(dpType.SelectedValue);
            product.CommodityID = string.IsNullOrEmpty(dpCommodity.SelectedItem.ToString()) ? 0 : Convert.ToInt32(dpCommodity.SelectedValue);
            product.BrandID = string.IsNullOrEmpty(dpBrand.SelectedItem.ToString()) ? 0 : Convert.ToInt32(dpBrand.SelectedValue);
            product.State = Convert.ToString(dpState.SelectedValue);
            product.SlabID = string.IsNullOrEmpty(dpSlab.SelectedItem.ToString()) ? 0 : Convert.ToInt32(dpSlab.SelectedValue);


            product.Quantity = string.IsNullOrEmpty(txtQuantity.Text.ToString()) ? 0.0 : Convert.ToDouble(txtQuantity.Text);

            product.Quantity = string.IsNullOrEmpty(dpUnit.SelectedItem.ToString()) ? 0 : Convert.ToInt32(dpUnit.SelectedValue);
            product.TypeID = string.IsNullOrEmpty(dpType.SelectedItem.ToString()) ? 0 : Convert.ToInt32(dpType.SelectedValue);
            product.Prize = string.IsNullOrEmpty(txtPrize.Text.ToString()) ? 0.0 : Convert.ToDouble(txtPrize.Text);
            product.SlabCode = "";
            product.CreatedBy = GlobalInfo.Userid;
            product.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
            product.ModifiedBy = GlobalInfo.Userid;
            product.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");
            product.flag = "Delete";
            int Result = 0;
            Result = productdata.AddProductInfo(product);



            if (Result > 0)
            {

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Product Deleted  Successfully";
                clearText();
                BindProduct();
                btnupdateProduct.Visible = false;
                btnAddProduct.Visible = true;
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
        protected void dpBrand_SelectedIndexChanged(object sender, EventArgs e)
        {

            DS = BindCommanData.BindCommanDropDwon("TypeID", "TypeName as Name", "TypeMaster", "IsArchive=1 and CategoryId =" + dpBrand.SelectedItem.Value.ToString());
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpType.ClearSelection();
                dpType.DataSource = DS;
                dpType.DataBind();
                dpType.Items.Insert(0, new ListItem("--Select Product Type  --", "0"));
                dpType.Focus();

            }
        }

    }
}