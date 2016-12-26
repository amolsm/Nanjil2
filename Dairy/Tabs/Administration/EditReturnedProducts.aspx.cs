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
    public partial class EditReturnedProducts : System.Web.UI.Page
    {
        DataSet DS;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDown();
                
                txtOrderDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                
            }
        }

        private void BindDropDown()
        {
            DS = new DataSet();
            DS = BindCommanData.BindCommanDropDwon("RouteID ", "RouteCode +' '+RouteName as Name  ", "routeMaster", "IsArchive=1 ");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpagentRoute.DataSource = DS;
                dpagentRoute.DataBind();
                dpagentRoute.Items.Insert(0, new ListItem("--Select Agent Route  --", "0"));
            }
            DS.Clear();
            DS = new DataSet();
            DS = BindCommanData.BindCommanDropDwon("CategoryId ", "CategoryName as Name  ", "Category", "IsActive=1");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpCategory.DataSource = DS;
                dpCategory.DataBind();
                dpCategory.Items.Insert(0, new ListItem("--Select Brand--", "0"));
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Dispatch dispatch = new Dispatch();
            dispatch.DispatchDate = (Convert.ToDateTime(txtOrderDate.Text)).ToString("dd-MM-yyyy");
            dispatch.CategoryId = Convert.ToInt32(dpCategory.SelectedItem.Value);
            dispatch.flag = "Edit";
            dispatch.RouteID = Convert.ToInt32(dpagentRoute.SelectedItem.Value);
            DispatchData dispatchData = new DispatchData();
            DataSet DS = new DataSet();
            
            DS = dispatchData.GetDispatchByAgentID(dispatch);

            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                
                rpRouteList.DataSource = DS;
                rpRouteList.DataBind();
                rpRouteList.Visible = true;

                uprouteList.Update();
                
            }
            else { rpRouteList.Visible = false; uprouteList.Update(); }


        }
        public void ClearTextBox()
        {
            txtDispQuantity.Text = string.Empty;
            txtGoodQuality.Text = string.Empty;
            txtSampleReturn.Text = string.Empty;
            txtSpotDamaged.Text = string.Empty;
            txtAgentName.Text = string.Empty;
            txtCommodityName.Text = string.Empty;
            //txtOrderDate.Text = string.Empty;
            //txtOrderDetailsId.Text = string.Empty;
            //txtOrderID.Text = string.Empty;
        }
        protected void btnFinalSubmit_Click(object sender, EventArgs e)
        {

        }

        protected void btnSubmitModal_Click(object sender, EventArgs e)
        {

        }

        protected void rpRouteList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }
    }
}