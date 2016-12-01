using Bussiness;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dairy.Tabs.Administration
{
    public partial class DamageRateSetup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDwon();

            }

        }

        public void BindDropDwon()
        {
            DataSet DS = new DataSet();
            DS = BindCommanData.BindCommanDropDwon("RouteID ", "RouteCode +' '+RouteName as Name  ", "routeMaster", "IsArchive=1 ");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpRoute.DataSource = DS;
                dpRoute.DataBind();
                dpRoute.Items.Insert(0, new ListItem("--Select Agent Route  --", "0"));

            }
            DS = BindCommanData.BindCommanDropDwon("CategoryId", "CategoryName as Name", "Category", "IsActive=1");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpBrand.DataSource = DS;
                dpBrand.DataBind();
                dpBrand.Items.Insert(0, new ListItem("--Select Brand--", "0"));
            }
            DS = BindCommanData.BindCommanDropDwon("TypeID", "TypeName as Name", "TypeMaster", "IsArchive=1 ");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpType.DataSource = DS;
                dpType.DataBind();
                dpType.Items.Insert(0, new ListItem("--Select Product Type  --", "0"));

            }
            DS = BindCommanData.BindCommanDropDwon("CommodityID", "CommodityName as Name", "Commodity", "IsArchive=0 ");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpCommodity.DataSource = DS;
                dpCommodity.DataBind();
                dpCommodity.Items.Insert(0, new ListItem("--Select Commodity Type  --", "0"));

            }
        }


        protected void dpBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet DS = new DataSet();
            DS = BindCommanData.BindCommanDropDwon("TypeID", "TypeName as Name", "TypeMaster", "IsArchive=1 and " + "CategoryID=" + Convert.ToInt32(dpBrand.SelectedItem.Value));
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpType.DataSource = DS;
                dpType.DataBind();
                dpType.Items.Insert(0, new ListItem("--Select Product Type  --", "0"));

            }

        }

        protected void dpType_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet DS = new DataSet();
            DS = BindCommanData.BindCommanDropDwon("CommodityID", "CommodityName as Name", "Commodity", "IsArchive=0  and " + "TypeID=" + Convert.ToInt32(dpType.SelectedItem.Value));
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpCommodity.DataSource = DS;
                dpCommodity.DataBind();
                dpCommodity.Items.Insert(0, new ListItem("Select Commodity", "0"));

            }

        }

        protected void dpRoute_SelectedIndexChanged(object sender, EventArgs e)
        {
            //DataSet ds = new DataSet();
            //DispatchData dispatchdata = new DispatchData();
            //int RouteID = Convert.ToInt32(dpRoute.SelectedItem.Value);
            //ds = dispatchdata.GetAgentforIncentiveSetup(RouteID);
            //if (!Comman.Comman.IsDataSetEmpty(ds))
            //{

            //    rpBrandInfo.DataSource = ds;
            //    rpBrandInfo.DataBind();
            //    //rpBrandInfo.Visible = true;
            //    uprouteList.Update();
            //}

        }
        protected void btnClick_btnShow(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                DataSet ds = new DataSet();
                DispatchData dispatchdata = new DispatchData();
                int RouteID = Convert.ToInt32(dpRoute.SelectedItem.Value);
                int BrandID = Convert.ToInt32(dpBrand.SelectedItem.Value);
                int typeid = Convert.ToInt32(dpType.SelectedItem.Value);
                int commodity = Convert.ToInt32(dpCommodity.SelectedItem.Value);
                ds = dispatchdata.GetAgentforDReplacementSetup(RouteID, BrandID, typeid, commodity);
                if (!Comman.Comman.IsDataSetEmpty(ds))
                {

                    rpBrandInfo.DataSource = ds;
                    rpBrandInfo.DataBind();
                    //rpBrandInfo.Visible = true;
                    uprouteList.Update();
                }
                else
                {
                    rpBrandInfo.DataSource = ds;
                    rpBrandInfo.DataBind();
                    //rpBrandInfo.Visible = true;
                    uprouteList.Update();
                }
            }
        }

        protected void rpRouteList_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            TextBox textmt = e.Item.FindControl("txtdamagereplacerate") as TextBox;
            CheckBox cbxIsActive = e.Item.FindControl("CheckBox1") as CheckBox;
            HiddenField hdfID = e.Item.FindControl("hfAgentId") as HiddenField;
            if (hdfID != null)
            {
                string damagereplacementrate = textmt.Text;
                string agentId = hdfID.Value;
                bool isActive = cbxIsActive.Checked;
                int routeid = Convert.ToInt32(dpRoute.SelectedItem.Value);
                int categoryid = Convert.ToInt32(dpBrand.SelectedItem.Value);
                int typeid = Convert.ToInt32(dpType.SelectedItem.Value);
                int commodityid = Convert.ToInt32(dpCommodity.SelectedItem.Value);
                UpdateRecord(agentId, routeid, categoryid, typeid, commodityid, damagereplacementrate, isActive);
            }
        }

        protected void btnClick_btnAddIncentive(object sender, EventArgs e)
        {
            foreach (RepeaterItem item in rpBrandInfo.Items)
            {
                TextBox textmt = item.FindControl("txtdamagereplacerate") as TextBox;
                CheckBox cbxIsActive = item.FindControl("CheckBox1") as CheckBox;
                HiddenField hdfID = item.FindControl("hfAgentId") as HiddenField;
                if (hdfID != null)
                {
                    string damagereplacementrate = textmt.Text;
                    string agentId = hdfID.Value;
                    bool isActive = cbxIsActive.Checked;
                    int routeid = Convert.ToInt32(dpRoute.SelectedItem.Value);
                    int categoryid = Convert.ToInt32(dpBrand.SelectedItem.Value);
                    int typeid = Convert.ToInt32(dpType.SelectedItem.Value);
                    int commodityid = Convert.ToInt32(dpCommodity.SelectedItem.Value);
                    UpdateRecord(agentId, routeid, categoryid, typeid, commodityid, damagereplacementrate, isActive);
                }
            }
        }

        private void UpdateRecord(string agentId, int routeid, int categoryid, int typeid, int commodityid, string damagereplacementrate, bool isActive)
        {
            int result = 0;
            MarketingData marketingdata = new MarketingData();
            result = marketingdata.AddAgentDamageReplacementRateSetup(agentId, routeid, categoryid, typeid, commodityid, damagereplacementrate, isActive);
            if (result > 0)
            {

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Rate Updated  Successfully";
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

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Tabs/Administration/DamageRateSetup.aspx");
        }
    
    }
}