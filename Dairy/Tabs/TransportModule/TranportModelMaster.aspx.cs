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
    public partial class TranportModelMaster : System.Web.UI.Page
    {
        TransportData transportdata;
        Transports transport;
        DataSet DS;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindTransportModelInfo();
                btnAddRoute.Visible = true;
                btnupdateroute.Visible = false;
                BindDropDwon();
            }

        }
        public void BindDropDwon()
        {

            DS = BindCommanData.BindCommanDropDwon("tr_brand_Id", "tr_brand_name", "Tr_Brand_Master", "IsActive=1");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpBrand.DataSource = DS;
                dpBrand.DataBind();
                dpBrand.Items.Insert(0, new ListItem("--Select Transport Brand--", "0"));
            }

        }
        protected void btnClick_btnAddTypeID(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {

                transportdata = new TransportData();
                transport = new Transports();
                transport.trModelID = 0;
                transport.trModelName = string.IsNullOrEmpty(txtModel.Text.ToString()) ? string.Empty : Convert.ToString(txtModel.Text);

                transport.trBrandID = Convert.ToInt32(dpBrand.SelectedItem.Value);
                transport.CreatedBy = GlobalInfo.Userid;
                if (dpIsActive.SelectedItem.Value == "1")
                {
                    transport.IsActive = true;
                }
                else if (dpIsActive.SelectedItem.Text == "2")
                {
                    transport.IsActive = false;
                }
                //product.IsActive = true;
                transport.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
                transport.ModifiedBy = GlobalInfo.Userid;
                transport.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");
                transport.flag = "Insert";
                int Result = 0;
                Result = transportdata.AddTransportModelInfo(transport);
                if (Result > 0)
                {

                    divDanger.Visible = false;
                    divwarning.Visible = false;
                    divSusccess.Visible = true;
                    lblSuccess.Text = "Transport Model Add  Successfully";

                    ClearTextBox();
                    BindTransportModelInfo();
                    pnlError.Update();
                    upMain.Update();
                    uprouteList.Update();
                }
                else
                {
                    divDanger.Visible = false;
                    divwarning.Visible = true;
                    divSusccess.Visible = false;
                    if (Result == -2627)
                    {
                        lblwarning.Text = "Data  Already Exists";
                    }
                    else
                    {
                        lblwarning.Text = "Please Contact to Site Admin";
                    }
                    pnlError.Update();

                }

            }


        }
        protected void btnClick_btnUpdateTypeID(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {

                transportdata = new TransportData();
                transport = new Transports();
                transport.trModelID = string.IsNullOrEmpty(hfTypeID.Value) ? 0 : Convert.ToInt32(hfTypeID.Value);
                transport.trModelName = string.IsNullOrEmpty(txtModel.Text.ToString()) ? string.Empty : Convert.ToString(txtModel.Text);
                transport.CreatedBy = GlobalInfo.Userid;
                if (dpIsActive.SelectedItem.Value == "1")
                {
                    transport.IsActive = true;
                }
                else if (dpIsActive.SelectedItem.Text == "2")
                {
                    transport.IsActive = false;
                }
                transport.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
                transport.ModifiedBy = GlobalInfo.Userid;
                transport.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");
                transport.flag = "Update";
                int Result = 0;
                Result = transportdata.AddTransportModelInfo(transport);
                if (Result > 0)
                {

                    divDanger.Visible = false;
                    divwarning.Visible = false;
                    divSusccess.Visible = true;
                    lblSuccess.Text = "Transport Model Updated  Successfully";

                    ClearTextBox();
                    BindTransportModelInfo();
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

        }
        public void ClearTextBox()
        {
            dpBrand.ClearSelection();
            txtModel.Text = string.Empty;
            dpIsActive.ClearSelection();

        }
        protected void rpRouteList_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {

            divDanger.Visible = false;
            divwarning.Visible = false;
            divSusccess.Visible = false;
            pnlError.Update();
            int trModelID = 0;
            trModelID = Convert.ToInt32(e.CommandArgument);
            switch (e.CommandName)
            {
                case ("Edit"):
                    {
                        lblHeaderTab.Text = "Edit Product Type";
                        hfTypeID.Value = trModelID.ToString();
                        trModelID = Convert.ToInt32(hfTypeID.Value);
                        GetTransportModelInfoByID(trModelID);
                        btnAddRoute.Visible = false;
                        btnupdateroute.Visible = true;
                        BindTransportModelInfo();
                        upMain.Update();
                       
                        uprouteList.Update();
                        break;
                    }
                case ("delete"):
                    {

                        hfTypeID.Value = trModelID.ToString();
                        trModelID = Convert.ToInt32(hfTypeID.Value);
                        DeleteTypebyID(trModelID);
                        BindTransportModelInfo();
                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }


            }
        }
        public void GetTransportModelInfoByID(int trModelID)
        {

            transportdata = new TransportData();
            DS = transportdata.GetTransportModelInfoByID(trModelID);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                txtModel.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["tr_model_name"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["tr_model_name"].ToString();
                dpIsActive.ClearSelection();
                dpIsActive.ClearSelection();
                if (DS.Tables[0].Rows[0]["IsActive"].ToString() == "True")
                {
                    dpIsActive.Items.FindByValue("1").Selected = true;
                }
                if (DS.Tables[0].Rows[0]["IsActive"].ToString() == "False")
                {
                    dpIsActive.Items.FindByValue("2").Selected = true;
                }
                dpBrand.ClearSelection();
                if (dpBrand.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["tr_brand_Id"]).ToString()) != null)
                {
                    dpBrand.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["tr_brand_Id"]).ToString()).Selected = true;
                }

            }
        }
        public void BindTransportModelInfo()
        {

            transportdata = new TransportData();
            DataSet DS = new DataSet();
            DS = transportdata.GetTransportModelInfo();

            if (!Comman.Comman.IsDataSetEmpty(DS))
            {

                rpTypeMasteInfo.DataSource = DS;
                rpTypeMasteInfo.DataBind();
            }
        }
        public void DeleteTypebyID(int trModelID)
        {

            transportdata = new TransportData();
            transport = new Transports();
            transport.trModelID = Convert.ToInt32(trModelID);
            transport.trModelName = string.Empty;
            transport.trBrandID = 0;
          
            transport.CreatedBy = GlobalInfo.Userid;
            transport.IsActive = true;
            transport.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
            transport.ModifiedBy = GlobalInfo.Userid;
            transport.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");
            transport.flag = "Delete";
            int Result = 0;
            Result = transportdata.AddTransportModelInfo(transport);
            if (Result > 0)
            {

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Transport Model Deleted  Successfully";

                ClearTextBox();
                BindTransportModelInfo();
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

        protected void btnClick_btnAddNew(object sender, EventArgs e)
        {
            Response.Redirect("~/Tabs/TransportModule/TranportModelMaster.aspx");
        }
    }
}