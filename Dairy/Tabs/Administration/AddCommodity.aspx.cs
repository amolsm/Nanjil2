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
    public partial class AddCommodity : System.Web.UI.Page
    {
        ProductData productdata;
        Product product;
        DataSet DS;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindDropDown();
                GetCommodityInfo();
            }
            btnAddRoute.Visible = true;
            btnupdateroute.Visible = false;
        }

        public void bindDropDown()
        {
            DS = new DataSet();
            productdata = new ProductData();
            DS = BindCommanData.BindCommanDropDwon("CategoryId", "CategoryName", "Category", "IsActive=1");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpBrand.DataSource = DS;
                dpBrand.DataBind();
                dpBrand.Items.Insert(0, new ListItem("--Select Brand  --", "0"));
            }
            DS = BindCommanData.BindCommanDropDwon("TypeID", "TypeName", "TypeMaster", "IsArchive=1");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpType.DataSource = DS;
                dpType.DataTextField = "TypeName";
                dpType.DataValueField = "TypeID";
                dpType.DataBind();
                dpType.Items.Insert(0, new ListItem("--Select TypeName  --", "0"));

            }
        }
        protected void rpRouteList_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {

            divDanger.Visible = false;
            divwarning.Visible = false;
            divSusccess.Visible = false;
            pnlError.Update();
            int CommodityID = 0;
            CommodityID = Convert.ToInt32(e.CommandArgument);
            switch (e.CommandName)
            {
                case ("Edit"):
                    {
                        lblHeaderTab.Text = "Edit Commodity";
                        hfCommodityID.Value = CommodityID.ToString();
                        CommodityID = Convert.ToInt32(hfCommodityID.Value);
                        GetCommodityInfobyID(CommodityID);
                        btnAddRoute.Visible = false;
                        btnupdateroute.Visible = true;
                        // GetCommodityInfo();
                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }
                case ("delete"):
                    {

                        hfCommodityID.Value = CommodityID.ToString();
                        CommodityID = Convert.ToInt32(hfCommodityID.Value);
                        DeleteCommoditybyID(CommodityID);

                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }


            }
        }
        protected void dpBrand_SelectedIndexChanged(object sender, EventArgs e)
        {

            DS = BindCommanData.BindCommanDropDwon("TypeID", "TypeName", "TypeMaster", "IsArchive=1 and CategoryId =" + dpBrand.SelectedItem.Value.ToString());
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpType.ClearSelection();
                dpType.DataSource = DS;
                dpType.DataBind();
                dpType.Items.Insert(0, new ListItem("--Select Product Type  --", "0"));
                dpType.Focus();

            }
        }
        protected void btnClick_btnAddTypeID(object sender, EventArgs e)
        {

            productdata = new ProductData();
            product = new Product();
            product.CommodityID = 0;
            product.Commodity = string.IsNullOrEmpty(txtCommodity.Text.ToString()) ? string.Empty : Convert.ToString(txtCommodity.Text);
            product.TypeID = string.IsNullOrEmpty(dpType.SelectedValue.ToString()) ? 0 : Convert.ToInt32(dpType.SelectedValue);
            product.CreatedBy = GlobalInfo.Userid;
            product.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
            product.ModifiedBy = GlobalInfo.Userid;
            product.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");
            if (dpStatus.SelectedItem.Value == "1")
            {
                product.Status = false;
            }
            if (dpStatus.SelectedItem.Value == "2")
            {
                product.Status = true;
            }
            product.flag = "Insert";
            int Result = 0;
            Result = productdata.AddCommodityInfo(product);
            if (Result > 0)
            {

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Commodity Add  Successfully";

                ClearTextBox();
                GetCommodityInfo();
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
            product.CommodityID = string.IsNullOrEmpty(hfCommodityID.Value) ? 0 : Convert.ToInt32(hfCommodityID.Value);
            product.Commodity = string.IsNullOrEmpty(txtCommodity.Text.ToString()) ? string.Empty : Convert.ToString(txtCommodity.Text);
            product.TypeID = string.IsNullOrEmpty(dpType.SelectedValue.ToString()) ? 0 : Convert.ToInt32(dpType.SelectedValue);
            product.CreatedBy = GlobalInfo.Userid;
            product.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
            product.ModifiedBy = GlobalInfo.Userid;
            product.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");
            if (dpStatus.SelectedItem.Value == "1")
            {
                product.Status = false;
            }
            if (dpStatus.SelectedItem.Value == "2")
            {
                product.Status = true;
            }
            product.flag = "Update";
            int Result = 0;
            Result = productdata.AddCommodityInfo(product);
            if (Result > 0)
            {

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Commodity Updated  Successfully";

                ClearTextBox();
                GetCommodityInfo();
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

        public void DeleteCommoditybyID(int CommodityID)
        {

            productdata = new ProductData();
            product = new Product();
            product.CommodityID = Convert.ToInt32(CommodityID);
            product.Commodity = string.Empty;
            product.TypeID = string.IsNullOrEmpty(dpType.SelectedValue.ToString()) ? 0 : Convert.ToInt32(dpType.SelectedValue);
            product.CreatedBy = GlobalInfo.Userid;
            product.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
            product.ModifiedBy = GlobalInfo.Userid;
            product.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");
            if (dpStatus.SelectedItem.Value == "1")
            {
                product.Status = false;
            }
            if (dpStatus.SelectedItem.Value == "2")
            {
                product.Status = true;
            }
            product.flag = "Delete";
            int Result = 0;
            Result = productdata.AddCommodityInfo(product);
            if (Result > 0)
            {

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Commodity Deleted  Successfully";
                ClearTextBox();
                GetCommodityInfo();
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

        public void ClearTextBox()
        {
            txtCommodity.Text = string.Empty;
            dpType.ClearSelection();
            dpBrand.ClearSelection();
            dpStatus.ClearSelection();

        }

        public void GetCommodityInfobyID(int CommodityID)
        {

            productdata = new ProductData();
            DS = productdata.GetCommodityInfoByID(CommodityID);
            dpBrand.ClearSelection();
            dpType.ClearSelection();
            dpStatus.ClearSelection();
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                if (dpBrand.Items.FindByValue(DS.Tables[0].Rows[0]["CategoryId"].ToString()) != null)
                {

                    dpBrand.Items.FindByValue(DS.Tables[0].Rows[0]["CategoryId"].ToString()).Selected = true;
                }
                if (dpType.Items.FindByValue(DS.Tables[0].Rows[0]["TypeID"].ToString()) != null)
                {

                    dpType.Items.FindByValue(DS.Tables[0].Rows[0]["TypeID"].ToString()).Selected = true;
                }
                if (DS.Tables[0].Rows[0]["IsArchive"].ToString() == "True")
                {
                    dpStatus.Items.FindByValue("2").Selected = true;
                }
                if (DS.Tables[0].Rows[0]["IsArchive"].ToString() == "False")
                {
                    dpStatus.Items.FindByValue("1").Selected = true;
                }
                txtCommodity.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["CommodityName"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["CommodityName"].ToString();
            }

        }
        public void GetCommodityInfo()
        {

            productdata = new ProductData();
            DataSet DS = new DataSet();
            DS = productdata.GetCommodityInfo();

            if (!Comman.Comman.IsDataSetEmpty(DS))
            {

                rpTypeMasteInfo.DataSource = DS;
                rpTypeMasteInfo.DataBind();
            }
        }

    }
}