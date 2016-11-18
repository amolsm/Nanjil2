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
    public partial class AddSlab : System.Web.UI.Page
    {
        ProductData productdata;
        Product product;
        DataSet DS;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetSlabInfo();
            }
            btnAddSlab.Visible = true;
            btnupdateSlab.Visible = false;

        }




        public void GetSlabInfo()
        {


            productdata = new ProductData();
            DataSet DS = new DataSet();
            DS = productdata.GetSlabInfo();

            if (!Comman.Comman.IsDataSetEmpty(DS))
            {

                rpSlabInfo.DataSource = DS;
                rpSlabInfo.DataBind();
            }

        }

        protected void rpRouteList_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {

            divDanger.Visible = false;
            divwarning.Visible = false;
            divSusccess.Visible = false;
            pnlError.Update();
            int SlabID = 0;
            SlabID = Convert.ToInt32(e.CommandArgument);
            switch (e.CommandName)
            {
                case ("Edit"):
                    {
                        lblHeaderTab.Text = "Edit Slab";
                        hfSlabId.Value = SlabID.ToString();
                        SlabID = Convert.ToInt32(hfSlabId.Value);
                        GetSlabInfoByID(SlabID);
                        btnAddSlab.Visible = false;
                        btnupdateSlab.Visible = true;

                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }
                case ("delete"):
                    {

                        hfSlabId.Value = SlabID.ToString();
                        SlabID = Convert.ToInt32(hfSlabId.Value);
                        DeleteSlabbyID(SlabID);

                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }


            }
        }
        protected void btnClick_btnAddSlabID(object sender, EventArgs e)
        {

            productdata = new ProductData();
            product = new Product();
            product.SlabID = 0;
            product.SlabName = string.IsNullOrEmpty(txtSlab.Text.ToString()) ? string.Empty : Convert.ToString(txtSlab.Text);
            product.SlabDisc = string.IsNullOrEmpty(txtSlabDisc.Text.ToString()) ? string.Empty : Convert.ToString(txtSlabDisc.Text);
            product.CreatedBy = GlobalInfo.Userid;
            product.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
            product.ModifiedBy = GlobalInfo.Userid;
            product.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");
            product.flag = "Insert";
            int Result = 0;
            Result = productdata.AddSlabInfo(product);



            if (Result > 0)
            {

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Slab Add  Successfully";

                ClearTextBox();
                GetSlabInfo();
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
        protected void btnClick_btnUpdateSlabID(object sender, EventArgs e)
        {

            productdata = new ProductData();
            product = new Product();
            product.SlabID = string.IsNullOrEmpty(hfSlabId.Value) ? 0 : Convert.ToInt32(hfSlabId.Value);
            product.SlabName = string.IsNullOrEmpty(txtSlab.Text.ToString()) ? string.Empty : Convert.ToString(txtSlab.Text);
            product.SlabDisc = string.IsNullOrEmpty(txtSlabDisc.Text.ToString()) ? string.Empty : Convert.ToString(txtSlabDisc.Text);
            product.CreatedBy = GlobalInfo.Userid;
            product.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
            product.ModifiedBy = GlobalInfo.Userid;
            product.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");
            product.flag = "Update";
            int Result = 0;
            Result = productdata.AddSlabInfo(product);


            if (Result > 0)
            {

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Slab Updated  Successfully";

                ClearTextBox();
                GetSlabInfo();
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
        public void DeleteSlabbyID(int SlabID)
        {

            productdata = new ProductData();
            product = new Product();
            product.SlabID = Convert.ToInt32(SlabID);
            product.SlabName = string.Empty;
            product.SlabDisc = string.Empty;
            product.CreatedBy = GlobalInfo.Userid;
            product.IsActive = true;
            product.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
            product.ModifiedBy = GlobalInfo.Userid;
            product.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");
            product.flag = "Delete";
            int Result = 0;
            Result = productdata.AddSlabInfo(product);
            if (Result > 0)
            {

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Slab Deleted  Successfully";

                ClearTextBox();
                GetSlabInfo();
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
            txtSlab.Text = string.Empty;
            txtSlabDisc.Text = string.Empty;
        }

        public void GetSlabInfoByID(int SlabID)
        {
            productdata = new ProductData();
            DS = productdata.GetSlabInfoByID(SlabID);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                txtSlab.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["SlabName"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["SlabName"].ToString();
                txtSlabDisc.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["SlabDisc"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["SlabDisc"].ToString();

            }
        }

    }
}