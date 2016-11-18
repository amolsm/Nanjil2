using Bussiness;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dairy.Tabs.Administration
{
    public partial class UnitMaster : System.Web.UI.Page
    {
        ProductData productdata;
        Product product;
        DataSet DS;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindUnitInfo();
                btnAddUnit.Visible = true;
                btnUpdateUnit.Visible = false;

            }

        }
        public void BindUnitInfo()
        {

            productdata = new ProductData();
            DataSet DS = new DataSet();
            DS = productdata.GetUnitInfo();

            if (!Comman.Comman.IsDataSetEmpty(DS))
            {

                rpTypeMasteInfo.DataSource = DS;
                rpTypeMasteInfo.DataBind();
            }
        }
        protected void btnClick_btnAddUnit(object sender, EventArgs e)
        {
            productdata = new ProductData();
            product = new Product();
            product.UnitID = 0;
            product.UnitName = string.IsNullOrEmpty(txtUnit.Text.ToString()) ? string.Empty : Convert.ToString(txtUnit.Text);

            if (dpIsActive.SelectedItem.Value == "1")
            {
                product.IsActive = false;
            }
            if (dpIsActive.SelectedItem.Value == "2")
            {
                product.IsActive = true;
            }
            product.flag = "Insert";
            int Result = 0;
            Result = productdata.AddUnitInfo(product);
            if (Result > 0)
            {

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Unit Add  Successfully";

                ClearTextBox();
                BindUnitInfo();
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
        protected void btnClick_btnUpdateUnit(object sender, EventArgs e)
        {
            productdata = new ProductData();
            product = new Product();
            product.UnitID = string.IsNullOrEmpty(hfTypeID.Value) ? 0 : Convert.ToInt32(hfTypeID.Value);
            product.UnitName = string.IsNullOrEmpty(txtUnit.Text.ToString()) ? string.Empty : Convert.ToString(txtUnit.Text);

            if (dpIsActive.SelectedItem.Value == "1")
            {
                product.IsActive = false;
            }
            if (dpIsActive.SelectedItem.Value == "2")
            {
                product.IsActive = true;
            }
            product.flag = "Update";
            int Result = 0;
            Result = productdata.AddUnitInfo(product);
            if (Result > 0)
            {

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Unit Updated  Successfully";

                ClearTextBox();
                BindUnitInfo();
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
        protected void rpRouteList_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            divDanger.Visible = false;
            divwarning.Visible = false;
            divSusccess.Visible = false;
            pnlError.Update();
            int UnitID = 0;
            UnitID = Convert.ToInt32(e.CommandArgument);
            switch (e.CommandName)
            {
                case ("Edit"):
                    {
                        lblHeaderTab.Text = "Edit Unit Type";
                        hfTypeID.Value = UnitID.ToString();
                        UnitID = Convert.ToInt32(hfTypeID.Value);
                        GetUnitInfobyID(UnitID);
                        btnAddUnit.Visible = false;
                        btnUpdateUnit.Visible = true;
                        BindUnitInfo(); ;
                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }
            }
        }
        public void GetUnitInfobyID(int UnitID)
        {

            productdata = new ProductData();
            DS = productdata.GetUnitInfobyID(UnitID);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                txtUnit.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["UnitName"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["UnitName"].ToString();
                dpIsActive.ClearSelection();
                if (DS.Tables[0].Rows[0]["IsArchive"].ToString() == "True")
                {
                    dpIsActive.Items.FindByValue("2").Selected = true;
                }
                if (DS.Tables[0].Rows[0]["IsArchive"].ToString() == "False")
                {
                    dpIsActive.Items.FindByValue("1").Selected = true;
                }


            }
        }
        public void ClearTextBox()
        {
            txtUnit.Text = string.Empty;

            dpIsActive.ClearSelection();

        }
    }
}