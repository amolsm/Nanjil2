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
    public partial class BindSlab : System.Web.UI.Page
    {
        ProductData productdata;
        Product product;
        DataSet DS;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                bindDropDown();
                BindSlabInfo();
                btnBindSlab.Visible = true;
                btnupdateSlab.Visible = false;
            }

        }

        public void bindDropDown()
        {
            DS = new DataSet();
            productdata = new ProductData();
            DS = BindCommanData.BindCommanDropDwon("AgentID", "AgentName", "AgentMaster", "IsArchive=0");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpAgent.DataSource = DS;
                dpAgent.DataTextField = "AgentName";
                dpAgent.DataValueField = "AgentID";
                dpAgent.DataBind();
                dpAgent.Items.Insert(0, new ListItem("--Select AgentName  --", "0"));

            }
            DS = new DataSet();
            productdata = new ProductData();
            DS = BindCommanData.BindCommanDropDwon("TypeID", "TypeName", "TypeMaster", "IsArchive=1");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpType.DataSource = DS;
                dpType.DataTextField = "TypeName";
                dpType.DataValueField = "TypeID";
                dpType.DataBind();
                dpType.Items.Insert(0, new ListItem("--Select TypeName  --", "0"));

            }
            DS = new DataSet();
            productdata = new ProductData();
            DS = BindCommanData.BindCommanDropDwon("SlabID", "SlabName", "SlabMaster", "IsArchive=0");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpSlab.DataSource = DS;
                dpSlab.DataTextField = "SlabName";
                dpSlab.DataValueField = "SlabID";
                dpSlab.DataBind();
                dpSlab.Items.Insert(0, new ListItem("--Select SlabName  --", "0"));

            }
        }


        protected void dpType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int Agent = Convert.ToInt32(dpAgent.SelectedValue);
            int Type = Convert.ToInt32(dpType.SelectedValue);

            GetAgentBindStatus(Agent, Type);
            dpType.Focus();

        }
        public void GetAgentBindStatus(int Agent, int Type)
        {
            productdata = new ProductData();
            int result;
            DS = productdata.GetAgentBindStatus(Agent, Type);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                result = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Counts"].ToString()) ? 0 : Convert.ToInt32(DS.Tables[0].Rows[0]["Counts"]);
                if (result == 0)
                {

                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('This Product Type Already Bind this Agent')", true);
                    dpType.ClearSelection();

                }

            }
        }
        protected void rpSlab_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {

            divDanger.Visible = false;
            divwarning.Visible = false;
            divSusccess.Visible = false;
            pnlError.Update();
            int BindSlabID = 0;
            BindSlabID = Convert.ToInt32(e.CommandArgument);
            switch (e.CommandName)
            {
                case ("Edit"):
                    {

                        hfBindSlab.Value = BindSlabID.ToString();
                        BindSlabID = Convert.ToInt32(hfBindSlab.Value);
                        GetBindSlabByID(BindSlabID);
                        btnBindSlab.Visible = false;
                        btnupdateSlab.Visible = true;
                        // GetCommodityInfo();
                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }
                case ("delete"):
                    {

                        hfBindSlab.Value = BindSlabID.ToString();
                        BindSlabID = Convert.ToInt32(hfBindSlab.Value);
                        DeleteBindSlabbyID(BindSlabID);
                        BindSlabInfo();
                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }


            }
        }
        protected void btnClick_btnBindSlab(object sender, EventArgs e)
        {

            productdata = new ProductData();
            product = new Product();
            product.BindSlabID = 0;
            product.MonthelyCollection = "0";
            product.TillDateColletion = "0";
            //product.MonthelyCollection = string.IsNullOrEmpty(txtMonthelyCollection.Text.ToString()) ? string.Empty : Convert.ToString(txtMonthelyCollection.Text);
            //product.TillDateColletion = string.IsNullOrEmpty(txtMonthelyCollection.Text.ToString()) ? string.Empty : Convert.ToString(txtMonthelyCollection.Text);
            product.TypeID = string.IsNullOrEmpty(dpType.SelectedValue.ToString()) ? 0 : Convert.ToInt32(dpType.SelectedValue);
            product.SlabID = string.IsNullOrEmpty(dpSlab.SelectedValue.ToString()) ? 0 : Convert.ToInt32(dpSlab.SelectedValue);
            product.AgencyID = string.IsNullOrEmpty(dpAgent.SelectedValue.ToString()) ? 0 : Convert.ToInt32(dpAgent.SelectedValue);
            product.CreatedBy = GlobalInfo.Userid;
            product.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
            product.ModifiedBy = GlobalInfo.Userid;
            product.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");
            product.flag = "Insert";
            int Result = 0;
            Result = productdata.AddBindSlab(product);
            if (Result > 0)
            {

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "BindSlab Info Add  Successfully";

                ClearTextBox();
                BindSlabInfo();
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
        protected void btnClick_btnUpdatSlab(object sender, EventArgs e)
        {

            productdata = new ProductData();
            product = new Product();
            product.BindSlabID = Convert.ToInt32(hfBindSlab.Value);
            product.MonthelyCollection = "0";
            product.TillDateColletion = "0";
            //product.MonthelyCollection = string.IsNullOrEmpty(txtMonthelyCollection.Text.ToString()) ? string.Empty : Convert.ToString(txtMonthelyCollection.Text);
            //product.TillDateColletion = string.IsNullOrEmpty(txtMonthelyCollection.Text.ToString()) ? string.Empty : Convert.ToString(txtMonthelyCollection.Text);
            product.TypeID = string.IsNullOrEmpty(dpType.SelectedValue.ToString()) ? 0 : Convert.ToInt32(dpType.SelectedValue);
            product.SlabID = string.IsNullOrEmpty(dpSlab.SelectedValue.ToString()) ? 0 : Convert.ToInt32(dpSlab.SelectedValue);
            product.AgencyID = string.IsNullOrEmpty(dpAgent.SelectedValue.ToString()) ? 0 : Convert.ToInt32(dpAgent.SelectedValue);
            product.CreatedBy = GlobalInfo.Userid;
            product.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
            product.ModifiedBy = GlobalInfo.Userid;
            product.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");
            product.flag = "Update";
            int Result = 0;
            Result = productdata.AddBindSlab(product);
            if (Result > 0)
            {

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "BindSlab Info Updated  Successfully";

                ClearTextBox();
                BindSlabInfo();
                pnlError.Update();
                upMain.Update();
                uprouteList.Update();
                btnupdateSlab.Visible = false;
                btnBindSlab.Visible = true;
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

        public void DeleteBindSlabbyID(int CommodityID)
        {

            productdata = new ProductData();
            product = new Product();
            product.BindSlabID = Convert.ToInt32(hfBindSlab.Value);
            product.MonthelyCollection = "0";
            product.TillDateColletion = "0";
            //product.MonthelyCollection = string.IsNullOrEmpty(txtMonthelyCollection.Text.ToString()) ? string.Empty : Convert.ToString(txtMonthelyCollection.Text);
            //product.TillDateColletion = string.IsNullOrEmpty(txtMonthelyCollection.Text.ToString()) ? string.Empty : Convert.ToString(txtMonthelyCollection.Text);
            product.TypeID = string.IsNullOrEmpty(dpType.SelectedValue.ToString()) ? 0 : Convert.ToInt32(dpType.SelectedValue);
            product.SlabID = string.IsNullOrEmpty(dpSlab.SelectedValue.ToString()) ? 0 : Convert.ToInt32(dpSlab.SelectedValue);
            product.AgencyID = string.IsNullOrEmpty(dpAgent.SelectedValue.ToString()) ? 0 : Convert.ToInt32(dpAgent.SelectedValue);
            product.CreatedBy = GlobalInfo.Userid;
            product.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
            product.ModifiedBy = GlobalInfo.Userid;
            product.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");
            product.flag = "Delete";
            int Result = 0;
            Result = productdata.AddBindSlab(product);
            if (Result > 0)
            {

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "BindSlab Info Deleted  Successfully";

                ClearTextBox();
                BindSlabInfo();
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

        public void GetBindSlabByID(int BindSlabID)
        {

            productdata = new ProductData();
            DS = productdata.GetBindSlabByID(BindSlabID);
            ClearTextBox();
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                if (dpType.Items.FindByValue(DS.Tables[0].Rows[0]["TypeID"].ToString()) != null)
                {

                    dpType.Items.FindByValue(DS.Tables[0].Rows[0]["TypeID"].ToString()).Selected = true;
                }
                if (dpAgent.Items.FindByValue(DS.Tables[0].Rows[0]["AgentID"].ToString()) != null)
                {

                    dpAgent.Items.FindByValue(DS.Tables[0].Rows[0]["AgentID"].ToString()).Selected = true;
                }
                if (dpSlab.Items.FindByValue(DS.Tables[0].Rows[0]["SlabID"].ToString()) != null)
                {

                    dpSlab.Items.FindByValue(DS.Tables[0].Rows[0]["SlabID"].ToString()).Selected = true;
                }
                //product.MonthelyCollection = "0";
                //product.TillDateColletion = "0";
                //txtMonthelyCollection.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["MonthelyCollection"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["MonthelyCollection"].ToString();
                //txtTillDateCollection.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["TillDateCollection"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["TillDateCollection"].ToString();
            }
        }
        public void BindSlabInfo()
        {
            productdata = new ProductData();
            DataSet DS = new DataSet();
            DS = productdata.BindSlabInfo();

            if (!Comman.Comman.IsDataSetEmpty(DS))
            {

                rpBindSlab.DataSource = DS;
                rpBindSlab.DataBind();
            }
        }
        public void ClearTextBox()
        {
            dpSlab.ClearSelection();
            dpAgent.ClearSelection();
            dpType.ClearSelection();
            //txtTillDateCollection.Text = string.Empty;
            //txtMonthelyCollection.Text = string.Empty;

        }

    }
}