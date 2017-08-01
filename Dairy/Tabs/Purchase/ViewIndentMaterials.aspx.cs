using Bussiness;
using Model.Purchase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dairy.Tabs.Purchase
{
    public partial class ViewIndentMaterials : System.Web.UI.Page
    {
        PurchaseData purchaseData;
        DataSet DS;
        Indent indent;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtIndDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            purchaseData = new PurchaseData();
            DS = new DataSet();
            indent = new Indent();
            indent.IndentDate1 = string.IsNullOrEmpty(txtIndDate.Text) ? string.Empty : Convert.ToDateTime(txtIndDate.Text).ToString("dd-MM-yyyy");
            indent.Flag = 2; //for getting Approved Request Details by Date
            DS = purchaseData.GetIndentList(indent);
            rpRequestList.DataSource = DS;
            rpRequestList.DataBind();
            //lblBoxHeader.Text = "New Request List";
            upList.Update();
        }
        protected void rpRequestList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            divDanger.Visible = false;
            divwarning.Visible = false;
            divSusccess.Visible = false;
            pnlError.Update();
            int indentId = 0;
            indentId = Convert.ToInt32(e.CommandArgument);
            switch (e.CommandName)
            {
                case ("View"):
                    {
                        hfId.Value = indentId.ToString();
                        GetDetailsById(indentId);
                        hfIndentId.Value = indentId.ToString();
                        upModal.Update();
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "my1", "$('#Sidebars').addClass('dispnone');", true);
                        break;
                    }

            }
        }

        private void GetDetailsById(int indentId)
        {
            purchaseData = new PurchaseData();
            DS = new DataSet();
            indent = new Indent();
            string result = string.Empty;
            indent.IndentId = indentId;
            indent.Flag = 3; //for getting Order Details
            DS = purchaseData.GetIndentList(indent);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                if (DS.Tables[0].Rows[0]["Delivered"].ToString() == "True")
                    dpStatus.Enabled = false;

                rpModal.DataSource = DS;
                rpModal.DataBind();

                btnUpdate.Visible = true;
                btnSubmit.Visible = false;
                upModal.Update();
            }

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            purchaseData = new PurchaseData();
            indent = new Indent();
            indent.IndentId = Convert.ToInt32(hfIndentId.Value);
            indent.Flag = 5; //set status delivered
            int val = Convert.ToInt32(dpStatus.SelectedItem.Value);
            bool result;
            if (val == 1)
               result =  purchaseData.IndentStatus(indent);

        }
    }
}
