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
    public partial class AddBank : System.Web.UI.Page
    {
        ProductData productdata;
        Product product;

        DataSet DS = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnAddBankInfo.Visible = true;
                btnupdatebankdetail.Visible = false;
                GetBankDetails();
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
                        lblHeaderTab.Text = "Edit Bank Details";
                        hbankId.Value = Id.ToString();
                        Id = Convert.ToInt32(hbankId.Value);
                        GetBankDetails(Id);
                        //BindRouteList();

                        btnAddBankInfo.Visible = false;
                        btnupdatebankdetail.Visible = true;
                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }
                case ("delete"):
                    {

                        hbankId.Value = Id.ToString();
                        Id = Convert.ToInt32(hbankId.Value);
                        DeleteBankDetails(Id);
                        bindBankList();
                        upMain.Update();
                        uprouteList.Update();
                        break;

                    }


            }


        }
        public void GetBankDetails(int ID)
        {
            DataSet DS = new DataSet();
            ProductData bnkdata = new ProductData();
            DS = bnkdata.GetBankDatabyId(ID);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                txtBankName.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["BankName"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["BankName"].ToString();
                txtbranchname.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["BranchName"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["BranchName"].ToString();
                txtBranchAddress.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["BranchAddress"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["BranchAddress"].ToString();
                txtIfsc.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["IFSCcode"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["IFSCcode"].ToString();


            }
        }

        public void bindBankList()
        {

            ProductData bnkdata = new ProductData();
            DataSet DS = new DataSet();
            StringBuilder sb = new StringBuilder();
            DS = bnkdata.GetBankDetails();
            rpBankList.DataSource = DS;
            rpBankList.DataBind();
        }
        public void ClearTextBox()
        {
            txtBankName.Text = string.Empty;
            txtbranchname.Text = string.Empty;
            txtBranchAddress.Text = string.Empty;
            txtIfsc.Text = string.Empty;
        }
        protected void btnAddBankInfo_click(object sender, EventArgs e)
        {
            productdata = new ProductData();
            product = new Product();
            product.ID = 0;
            product.BankName = string.IsNullOrEmpty(txtBankName.Text.ToString()) ? string.Empty : Convert.ToString(txtBankName.Text);
            product.BranchName = string.IsNullOrEmpty(txtbranchname.Text.ToString()) ? string.Empty : Convert.ToString(txtbranchname.Text);
            product.BranchAddress = string.IsNullOrEmpty(txtBranchAddress.Text.ToString()) ? string.Empty : Convert.ToString(txtBranchAddress.Text);
            product.IFSCCode = string.IsNullOrEmpty(txtIfsc.Text.ToString()) ? string.Empty : Convert.ToString(txtIfsc.Text);
            product.flag = "Insert";
            int Result = 0;
            Result = productdata.AddBankInfo(product);
            if (Result > 0)
            {

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Bank Information Add  Successfully";

                ClearTextBox();
                GetBankDetails();
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
        protected void btnupdatebankdetail_click(object sender, EventArgs e)
        {

            Product product = new Product();
            ProductData productdata = new ProductData();
            product.ID = string.IsNullOrEmpty(hbankId.Value) ? 0 : Convert.ToInt32(hbankId.Value);
            product.BankName = txtBankName.Text;
            product.BranchName = txtbranchname.Text;
            product.BranchAddress = txtBranchAddress.Text;
            product.IFSCCode = txtIfsc.Text;
            if (productdata.UpdateBankInfo(product))
            {
                lblHeaderTab.Text = "Add Bank Details";
                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Route Updated  Successfully";
                ClearTextBox();
                bindBankList();
                pnlError.Update();
                btnAddBankInfo.Visible = true;
                btnupdatebankdetail.Visible = false;
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

        public void GetBankDetails()
        {

            productdata = new ProductData();
            DataSet DS = new DataSet();
            DS = productdata.GetBankDetails();

            if (!Comman.Comman.IsDataSetEmpty(DS))
            {

                rpBankList.DataSource = DS;
                rpBankList.DataBind();
            }


        }
        public int DeleteBankDetails(int ID)
        {

            Product product = new Product();
            ProductData productdata = new ProductData();
            product.ID = string.IsNullOrEmpty(hbankId.Value) ? 0 : Convert.ToInt32(hbankId.Value);
            product.BankName = string.Empty;
            product.BranchName = string.Empty;
            product.BranchAddress = string.Empty;
            product.IFSCCode = string.Empty;
            int Result = 0;
            Result = productdata.DeleteBankDetails(product);
            if (Result > 0)
            {

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Delete Updated  Successfully";
                ClearTextBox();
                GetBankDetails();
                pnlError.Update();
                btnAddBankInfo.Visible = true;
                btnupdatebankdetail.Visible = false;
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

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Tabs/Administration/AddBank.aspx");
        }

       
        
         

        protected void txtIfsc_TextChanged(object sender, EventArgs e)
        {
            productdata = new ProductData();
            DataSet DS = new DataSet();
            DS = productdata.GetBankDetails();
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                foreach (DataRow row in DS.Tables[0].Rows)
                {
                    if (row["IFSCcode"].ToString().Trim() == txtIfsc.Text.ToString().Trim())
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('IFSC Code Already exists')", true);
                        txtIfsc.Text = string.Empty;
                    }

                }
            }
            }
    }
}