using Bussiness;
using Dairy.App_code;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dairy.Tabs.TransportModule
{
    public partial class TransportBrandMaster : System.Web.UI.Page
    {
        TransportData transportdata;
        Transports transport;
        DataSet DS;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetTransportBrandInfo();
            }
            btnAddBrand.Visible = true;
           
            btnupdateBrand.Visible = false;

        }




        public void GetTransportBrandInfo()
        {


            transportdata = new TransportData();
            DataSet DS = new DataSet();
            DS = transportdata.GetTransportBrandInfo();

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
            int trBrandID = 0;
            trBrandID = Convert.ToInt32(e.CommandArgument);
            switch (e.CommandName)
            {
                case ("Edit"):
                    {
                        lblHeaderTab.Text = "Edit Brand";
                        hfBrandId.Value = trBrandID.ToString();
                        trBrandID = Convert.ToInt32(hfBrandId.Value);
                        GetTansportBrandInfoByID(trBrandID);
                        btnAddBrand.Visible = false;
                        btnupdateBrand.Visible = true;

                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }
                case ("delete"):
                    {

                        hfBrandId.Value = trBrandID.ToString();
                        trBrandID = Convert.ToInt32(hfBrandId.Value);
                        DeleteBrandbyID(trBrandID);

                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }


            }
        }
        protected void btnClick_btnAddBrandID(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                // My credential check code
          

            transportdata = new TransportData();
            transport = new Transports();
            transport.trBrandID = 0;
            transport.trBrandName = string.IsNullOrEmpty(txtBrand.Text.ToString()) ? string.Empty : Convert.ToString(txtBrand.Text);
            transport.CreatedBy = GlobalInfo.Userid;
            transport.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
            transport.ModifiedBy = GlobalInfo.Userid;
            transport.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");
            if (dpIsActive.SelectedItem.Value == "1")
            {
                transport.IsActive = true;
            }
            if (dpIsActive.SelectedItem.Value == "2")
            {
                transport.IsActive = false;
            }
            transport.flag = "Insert";
            int Result = 0;
            Result = transportdata.AddTransportBrandInfo(transport);



            if (Result > 0)
            {

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Transport Brand Add  Successfully";

                ClearTextBox();
                GetTransportBrandInfo();
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
        protected void btnClick_btnUpdateBrandID(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                transportdata = new TransportData();
                transport = new Transports();
                transport.trBrandID = string.IsNullOrEmpty(hfBrandId.Value) ? 0 : Convert.ToInt32(hfBrandId.Value);
                transport.trBrandName = string.IsNullOrEmpty(txtBrand.Text.ToString()) ? string.Empty : Convert.ToString(txtBrand.Text);
                transport.CreatedBy = GlobalInfo.Userid;
                transport.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
                transport.ModifiedBy = GlobalInfo.Userid;
                transport.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");
                if (dpIsActive.SelectedItem.Value == "1")
                {
                    transport.IsActive = true;
                }
                if (dpIsActive.SelectedItem.Value == "2")
                {
                    transport.IsActive = false;
                }
                transport.flag = "Update";
                int Result = 0;
                Result = transportdata.AddTransportBrandInfo(transport);


                if (Result > 0)
                {

                    divDanger.Visible = false;
                    divwarning.Visible = false;
                    divSusccess.Visible = true;
                    lblSuccess.Text = " Transport Brand Updated  Successfully";

                    ClearTextBox();
                    GetTransportBrandInfo();
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
        public void DeleteBrandbyID(int BrandID)
        {

            transportdata = new TransportData();
            transport = new Transports();
            transport.trBrandID = Convert.ToInt32(BrandID);
            transport.trBrandName = string.Empty;

            transport.CreatedBy = GlobalInfo.Userid;
            transport.IsActive = true;
            transport.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
            transport.ModifiedBy = GlobalInfo.Userid;
            transport.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");
            transport.flag = "Delete";
            int Result = 0;
            Result = transportdata.AddTransportBrandInfo(transport);
            if (Result > 0)
            {

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Brand Deleted  Successfully";

                ClearTextBox();
                GetTransportBrandInfo();
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
            dpIsActive.ClearSelection();
        }

        public void GetTansportBrandInfoByID(int trBrandID)
        {
            transportdata = new TransportData();
            DS = transportdata.GetTransportBrandInfoByID(trBrandID);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                txtBrand.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["tr_brand_name"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["tr_brand_name"].ToString();
                dpIsActive.ClearSelection();
                if (DS.Tables[0].Rows[0]["IsActive"].ToString() == "True")
                {
                    dpIsActive.Items.FindByValue("1").Selected = true;
                }
                if (DS.Tables[0].Rows[0]["IsActive"].ToString() == "False")
                {
                    dpIsActive.Items.FindByValue("2").Selected = true;
                }

            }
        }

        protected void btnClick_btnAddNew(object sender, EventArgs e)
        {
            Response.Redirect("~/Tabs/TransportModule/TransportBrandMaster.aspx");
        }
    }
}