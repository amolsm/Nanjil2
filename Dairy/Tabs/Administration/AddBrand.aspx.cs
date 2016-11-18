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
    public partial class AddBrand : System.Web.UI.Page
    {

        ProductData productdata;
        Product product;
        DataSet DS;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetBrandInfo();
            }
            btnAddBrand.Visible = true;
            btnupdateBrand.Visible = false;

        }




        public void GetBrandInfo()
        {


            productdata = new ProductData();
            DataSet DS = new DataSet();
            DS = productdata.GetBrandInfo();

            if (!Comman.Comman.IsDataSetEmpty(DS))
            {

                rpBrandInfo.DataSource = DS;
                rpBrandInfo.DataBind();
            }

        }

        protected void rpRouteList_ItemCommand(object sender, RepeaterCommandEventArgs e)
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
                        lblHeaderTab.Text = "Edit Brand";
                        hfBrandId.Value = BrandID.ToString();
                        BrandID = Convert.ToInt32(hfBrandId.Value);
                        GetBrandInfoByID(BrandID);
                        btnAddBrand.Visible = false;
                        btnupdateBrand.Visible = true;

                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }
                case ("delete"):
                    {

                        hfBrandId.Value = BrandID.ToString();
                        BrandID = Convert.ToInt32(hfBrandId.Value);
                        DeleteBrandbyID(BrandID);

                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }


            }
        }
        protected void btnClick_btnAddBrandID(object sender, EventArgs e)
        {

            productdata = new ProductData();
            product = new Product();
            product.BrandID = 0;
            product.BrandName = string.IsNullOrEmpty(txtBrand.Text.ToString()) ? string.Empty : Convert.ToString(txtBrand.Text);
            product.TINNumber = string.IsNullOrEmpty(txtTinNo.Text.ToString()) ? string.Empty : Convert.ToString(txtTinNo.Text);
            product.CreatedBy = GlobalInfo.Userid;
            product.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
            product.ModifiedBy = GlobalInfo.Userid;
            product.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");
            product.flag = "Insert";
            int Result = 0;
            Result = productdata.AddBrandInfo(product);



            if (Result > 0)
            {

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Brand Add  Successfully";

                ClearTextBox();
                GetBrandInfo();
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
        protected void btnClick_btnUpdateBrandID(object sender, EventArgs e)
        {

            productdata = new ProductData();
            product = new Product();
            product.BrandID = string.IsNullOrEmpty(hfBrandId.Value) ? 0 : Convert.ToInt32(hfBrandId.Value);
            product.BrandName = string.IsNullOrEmpty(txtBrand.Text.ToString()) ? string.Empty : Convert.ToString(txtBrand.Text);
            product.TINNumber = string.IsNullOrEmpty(txtTinNo.Text.ToString()) ? string.Empty : Convert.ToString(txtTinNo.Text);
            product.CreatedBy = GlobalInfo.Userid;
            product.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
            product.ModifiedBy = GlobalInfo.Userid;
            product.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");
            product.flag = "Update";
            int Result = 0;
            Result = productdata.AddBrandInfo(product);


            if (Result > 0)
            {

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Brand Updated  Successfully";

                ClearTextBox();
                GetBrandInfo();
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
        public void DeleteBrandbyID(int BrandID)
        {

            productdata = new ProductData();
            product = new Product();
            product.BrandID = Convert.ToInt32(BrandID);
            product.BrandName = string.Empty;
            product.TINNumber = string.IsNullOrEmpty(txtTinNo.Text.ToString()) ? string.Empty : Convert.ToString(txtTinNo.Text);
            product.CreatedBy = GlobalInfo.Userid;
            product.IsActive = true;
            product.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
            product.ModifiedBy = GlobalInfo.Userid;
            product.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");
            product.flag = "Delete";
            int Result = 0;
            Result = productdata.AddBrandInfo(product);
            if (Result > 0)
            {

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Brand Deleted  Successfully";

                ClearTextBox();
                GetBrandInfo();
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
            txtBrand.Text = string.Empty;
            txtTinNo.Text = string.Empty;
        }

        public void GetBrandInfoByID(int BrandID)
        {
            productdata = new ProductData();
            DS = productdata.GetBrandInfoByID(BrandID);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                txtBrand.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["CategoryName"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["CategoryName"].ToString();
                txtTinNo.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["TinNumber"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["TinNumber"].ToString();

            }
        }


    }


}
