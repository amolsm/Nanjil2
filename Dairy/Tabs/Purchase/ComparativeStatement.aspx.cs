using Bussiness;
using Model.Purchase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dairy.Tabs.Purchase
{
    public partial class ComparativeStatement : System.Web.UI.Page
    {
        DataSet DS;
        PurchaseData purchaseData;
        ItemRate itemRate;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDown();
                

            }
        }

        private void BindDropDown()
        {
            DS = new DataSet();


            DS = BindCommanData.BindCommanDropDwon("ItemId as Id", "ItemName as Name", "Prchs_Items", "IsActive = 1");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpItems.DataSource = DS;
                dpItems.DataBind();
                dpItems.Items.Insert(0, new ListItem("--Select Item--", "0"));
            }
        }

        protected void rpItemRatesList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

        protected void dpItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            DS = new DataSet();
            itemRate = new ItemRate();
            purchaseData = new PurchaseData();

            itemRate.ItemId = Convert.ToInt32(dpItems.SelectedItem.Value);
            itemRate.Flag = 3; //
            DS = purchaseData.GetItemRateList(itemRate);
            rpItemRatesList.DataSource = DS;
            rpItemRatesList.DataBind();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "sel1", "$('#MainContent_dpItems').addClass('selectpicker');$('#MainContent_dpItems').selectpicker();", true);
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "sel1", "$('#MainContent_dpItems').addClass('selectpicker');$('#MainContent_dpItems').selectpicker();", true);
        }
    }
}