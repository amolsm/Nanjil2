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
    public partial class Configure : System.Web.UI.Page
    {
        TransportData transportdata;
        Transports transport;
        DataSet DS;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetConfigInfo();
            }
            btnAddConfig.Visible = true;
            btnupdateConfig.Visible = false;

        }




        public void GetConfigInfo()
        {


            transportdata = new TransportData();
            DataSet DS = new DataSet();
            DS = transportdata.GetConfigInfo();

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
            int ID = 0;
            ID = Convert.ToInt32(e.CommandArgument);
            switch (e.CommandName)
            {
                case ("Edit"):
                    {
                        lblHeaderTab.Text = "Edit Config";
                        hfBrandId.Value = ID.ToString();
                        ID = Convert.ToInt32(hfBrandId.Value);
                        GetConfigInfoByID(ID);
                        dpConfigkey.Enabled = false;
                        dpConfigName.Enabled = false;
                        btnAddConfig.Visible = false;
                        btnupdateConfig.Visible = true;

                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }
                case ("delete"):
                    {

                        hfBrandId.Value = ID.ToString();
                        ID = Convert.ToInt32(hfBrandId.Value);
                        DeleteConfigbyID(ID);

                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }


            }
        }
        protected void btnClick_btnAddConfig(object sender, EventArgs e)
        {

            transportdata = new TransportData();
            transport = new Transports();
            transport.ID = 0;
            transport.configname = dpConfigName.SelectedItem.Text.ToString();
            transport.configkey = dpConfigkey.SelectedItem.Text.ToString();
            transport.configvalue = string.IsNullOrEmpty(txtConfigvalue.Text.ToString()) ? string.Empty : Convert.ToString(txtConfigvalue.Text);
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
            Result = transportdata.AddConfigInfo(transport);



            if (Result > 0)
            {

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Transport Config Add  Successfully";

                ClearTextBox();
                GetConfigInfo();
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
                    lblwarning.Text = "Data Already Exists";
                }
                else
                {
                    lblwarning.Text = "Please Contact to Site Admin";
                }
                pnlError.Update();


            }


        }
        protected void btnClick_btnUpdateConfig(object sender, EventArgs e)
        {

            transportdata = new TransportData();
            transport = new Transports();
            transport.ID = string.IsNullOrEmpty(hfBrandId.Value) ? 0 : Convert.ToInt32(hfBrandId.Value);
            transport.configname = dpConfigName.SelectedItem.Text.ToString();
            transport.configkey = dpConfigkey.SelectedItem.Text.ToString();
            transport.configvalue = string.IsNullOrEmpty(txtConfigvalue.Text.ToString()) ? string.Empty : Convert.ToString(txtConfigvalue.Text);
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
            Result = transportdata.AddConfigInfo(transport);


            if (Result > 0)
            {

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = " Transport Config Updated  Successfully";
                dpConfigkey.Enabled = true;
                dpConfigName.Enabled = true;
                ClearTextBox();
                GetConfigInfo();
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
        public void DeleteConfigbyID(int ID)
        {

            transportdata = new TransportData();
            transport = new Transports();
            transport.ID = Convert.ToInt32(ID);
            transport.configname = string.Empty;
            transport.configkey = string.Empty;
            transport.configvalue = string.Empty;

            transport.CreatedBy = GlobalInfo.Userid;
            transport.IsActive = true;
            transport.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
            transport.ModifiedBy = GlobalInfo.Userid;
            transport.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");
            transport.flag = "Delete";
            int Result = 0;
            Result = transportdata.AddConfigInfo(transport);
            if (Result > 0)
            {

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Config Deleted  Successfully";

                ClearTextBox();
                GetConfigInfo();
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
            dpConfigName.ClearSelection();
            dpConfigkey.ClearSelection();
            txtConfigvalue.Text = string.Empty;
            dpIsActive.ClearSelection();
        }

        public void GetConfigInfoByID(int ID)
        {
            transportdata = new TransportData();
            DS = transportdata.GetConfigInfoByID(ID);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpConfigName.SelectedItem.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["CONFIGNAME"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["CONFIGNAME"].ToString();
                dpConfigkey.SelectedItem.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["CONFIGKEY"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["CONFIGKEY"].ToString();
                txtConfigvalue.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["CONFIGVALUE"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["CONFIGVALUE"].ToString();
                dpIsActive.ClearSelection();
                if (DS.Tables[0].Rows[0]["ISACTIVE"].ToString() == "True")
                {
                    dpIsActive.Items.FindByValue("1").Selected = true;
                }
                if (DS.Tables[0].Rows[0]["ISACTIVE"].ToString() == "False")
                {
                    dpIsActive.Items.FindByValue("2").Selected = true;
                }

            }
        }

        protected void btnClick_btnAddNew(object sender, EventArgs e)
        {
            Response.Redirect("~/Tabs/TransportModule/Configure.aspx");
        }
    }
}