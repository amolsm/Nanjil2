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
    public partial class AddLocation : System.Web.UI.Page
    {
        ProductData productdata;
        Product product;

        DataSet DS = new DataSet();
    
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnAddStateInfo.Visible = true;
                btnupdatestatedetail.Visible = false;
                GetStateDetails();
            }
        }
        public void GetStateDetails()
        {

            productdata = new ProductData();
            DataSet DS = new DataSet();
            DS = productdata.GetStateDetails();

            if (!Comman.Comman.IsDataSetEmpty(DS))
            {

                rpBankList.DataSource = DS;
                rpBankList.DataBind();
            }



        }


        protected void btnAddStateInfo_click(object sender, EventArgs e)
        {
            productdata = new ProductData();
            product = new Product();
            product.LocId = 0;
            product.Country = string.IsNullOrEmpty(txtCountryName.Text.ToString()) ? string.Empty : Convert.ToString(txtCountryName.Text);
            product.State = string.IsNullOrEmpty(txtstatename.Text.ToString()) ? string.Empty : Convert.ToString(txtstatename.Text);
            product.District = string.IsNullOrEmpty(txtDistrict.Text.ToString()) ? string.Empty : Convert.ToString(txtDistrict.Text);
            product.City = string.IsNullOrEmpty(txtCity.Text.ToString()) ? string.Empty : Convert.ToString(txtCity.Text);
            //Result = bddata.AddBankInfo(users);
            product.flag = "Insert";
            int Result = 0;
            Result = productdata.AddStateDetails(product);
            if (Result > 0)
            {

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "State Information Add  Successfully";

                ClearTextBox();
                GetStateDetails();
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

        protected void btnupdatestatedetail_click(object sender, EventArgs e)
        {

            Product product = new Product();
            ProductData productdata = new ProductData();
            product.LocId = string.IsNullOrEmpty(hStateId.Value) ? 0 : Convert.ToInt32(hStateId.Value);
            product.Country = txtCountryName.Text;
            product.State = txtstatename.Text;
            product.District = txtDistrict.Text;
            product.City = txtCity.Text;
            //product.flag = "Update";
            //int Result = 0;
            //Result = productdata.AddStateDetails(product);
            if (productdata.InsertState(product))
            {
                lblHeaderTab.Text = "Add Location Details";
                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Location Updated  Successfully";
                ClearTextBox();
                GetStateDetails();
                pnlError.Update();
                btnAddStateInfo.Visible = true;
                btnupdatestatedetail.Visible = false;
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



        protected void rpBankList_ItemCommand(object sender, RepeaterCommandEventArgs e)
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
                        lblHeaderTab.Text = "Edit Location Details";
                        hStateId.Value = Id.ToString();
                        Id = Convert.ToInt32(hStateId.Value);
                        GetStateDetailsbyId(Id);
                        //BindRouteList();

                        btnAddStateInfo.Visible = false;
                        btnupdatestatedetail.Visible = true;
                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }
                case ("delete"):
                    {

                        hStateId.Value = Id.ToString();
                        Id = Convert.ToInt32(hStateId.Value);
                        DeleteLocation(Id);
                        GetStateDetails();
                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }


            }

        }
        public int DeleteLocation(int LocId)
        {

            Product product = new Product();
            ProductData productdata = new ProductData();
            product.LocId = string.IsNullOrEmpty(hStateId.Value) ? 0 : Convert.ToInt32(hStateId.Value);
            product.Country = string.Empty;
            product.District = string.Empty;
            product.State = string.Empty;
            product.City = string.Empty;

            //bkmodel.flag = "Delete";
            int Result = 0;
            Result = productdata.DeleteLocation(product);
            if (Result > 0)
            {

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Delete Updated  Successfully";
                ClearTextBox();
                GetStateDetails();
                pnlError.Update();
                btnAddStateInfo.Visible = true;
                btnupdatestatedetail.Visible = false;
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
        public void ClearTextBox()
        {
            txtCountryName.Text = string.Empty;
            txtstatename.Text = string.Empty;
            txtDistrict.Text = string.Empty;
            txtCity.Text = string.Empty;
        }
        public void GetStateDetailsbyId(int Id)
        {
            DataSet DS = new DataSet();
            ProductData bnkdata = new ProductData();
            DS = bnkdata.GetStateDetailsbyId(Id);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                txtCountryName.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Country"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Country"].ToString();
                txtstatename.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["State"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["State"].ToString();
                txtDistrict.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["District"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["District"].ToString();
                txtCity.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["City"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["City"].ToString();


            }
        }
    }
}