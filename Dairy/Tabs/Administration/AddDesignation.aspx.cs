using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Dairy.App_code;
using Bussiness;
using Comman;
using Model;
using System.Text;

namespace Dairy.Tabs.Administration
{
    public partial class AddDesignation : System.Web.UI.Page
    {
        ProductData productdata;
        Product product;
        DataSet DS = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnAddDesig.Visible = true;
                btnupdateDesigdetail.Visible = false;
                GetDesigDetails();

            }
        }
        public void GetDesigDetails()
        {
            //int boothid = GlobalInfo.CurrentbothID;
            productdata = new ProductData();
            DataSet DS = new DataSet();
            DS = productdata.GetDesigDetails();

            if (!Comman.Comman.IsDataSetEmpty(DS))
            {

                rpDesigList.DataSource = DS;
                rpDesigList.DataBind();
            }



        }
        protected void btnAddDesig_click(object sender, EventArgs e)
        {
            productdata = new ProductData();
            product = new Product();
            product.DesigId = 0;

            product.DesigName = string.IsNullOrEmpty(txtDesigName.Text.ToString()) ? string.Empty : Convert.ToString(txtDesigName.Text);
            product.Descriptions = string.IsNullOrEmpty(txtDescription.Text.ToString()) ? string.Empty : Convert.ToString(txtDescription.Text);
            product.Responsibility = string.IsNullOrEmpty(txtResp.Text.ToString()) ? string.Empty : Convert.ToString(txtResp.Text);

            product.flag = "Insert";
            int Result = 0;
            Result = productdata.AddDesigDetails(product);
            if (Result > 0)
            {

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Designation Information Add  Successfully";

                ClearTextBox();
                GetDesigDetails();
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
        protected void btnupdateDesigdetail_click(object sender, EventArgs e)
        {

            Product product = new Product();
            ProductData productdata = new ProductData();
            product.DesigId = string.IsNullOrEmpty(hDesigId.Value) ? 0 : Convert.ToInt32(hDesigId.Value);
            product.DesigName = txtDesigName.Text;
            product.Descriptions = txtDescription.Text;
            product.Responsibility = txtResp.Text;


            if (productdata.UpdateDesigDetails(product))
            {
                lblHeaderTab.Text = "Add Designation Details";
                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Designation Updated  Successfully";
                ClearTextBox();
                GetDesigDetails();
                pnlError.Update();
                btnAddDesig.Visible = true;
                btnupdateDesigdetail.Visible = false;
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
        protected void rpDesigList_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            divDanger.Visible = false;
            divwarning.Visible = false;
            divSusccess.Visible = false;
            pnlError.Update();
            int Id = 0;
            Id = Convert.ToInt32(e.CommandArgument);
            switch (e.CommandName)
            {
                case ("Edit"):
                    {
                        lblHeaderTab.Text = "Edit Designation Details";
                        hDesigId.Value = Id.ToString();
                        Id = Convert.ToInt32(hDesigId.Value);
                        GetDesigDetailsbyId(Id);
                        //BindRouteList();

                        btnAddDesig.Visible = false;
                        btnupdateDesigdetail.Visible = true;
                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }
                case ("delete"):
                    {

                        hDesigId.Value = Id.ToString();
                        Id = Convert.ToInt32(hDesigId.Value);
                        DeleteDesigDetails(Id);
                        GetDesigDetails();
                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }


            }

        }

        private int DeleteDesigDetails(int DesigId)
        {
            Product product = new Product();
            ProductData productdata = new ProductData();
            product.DesigId = string.IsNullOrEmpty(hDesigId.Value) ? 0 : Convert.ToInt32(hDesigId.Value);
            product.DesigName = string.Empty;
            product.Descriptions = string.Empty;
            product.Responsibility = string.Empty;


            //bkmodel.flag = "Delete";
            int Result = 0;
            Result = productdata.DeleteDesigDetails(product);
            if (Result > 0)
            {

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Delete Updated  Successfully";
                ClearTextBox();
                GetDesigDetails();
                pnlError.Update();
                btnAddDesig.Visible = true;
                btnupdateDesigdetail.Visible = false;
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
            return Result;
        }

        private void GetDesigDetailsbyId(int Id)
        {
            DataSet DS = new DataSet();
            ProductData bnkdata = new ProductData();
            DS = bnkdata.GetDesigDetailsbyId(Id);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                //txtDesigId.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["DesigId"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["DesigId"].ToString();
                txtDesigName.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["DesigName"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["DesigName"].ToString();
                txtDescription.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Descriptions"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Descriptions"].ToString();
                txtResp.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Responsibility"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Responsibility"].ToString();

            }
        }
        public void ClearTextBox()
        {
            txtDesigName.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtResp.Text = string.Empty;

        }
    }
}