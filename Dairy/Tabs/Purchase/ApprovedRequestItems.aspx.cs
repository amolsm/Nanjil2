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
    public partial class ApprovedRequestItems : System.Web.UI.Page
    {
        PurchaseData purchaseData;
        DataSet DS;
        Request request;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            purchaseData = new PurchaseData();
            DS = new DataSet();
            request = new Request();
            request.ReqDate = string.IsNullOrEmpty(txtRequestDate.Text) ? string.Empty: Convert.ToDateTime(txtRequestDate.Text).ToString("dd-MM-yyyy");
            request.Flag = 4; //for getting Approved Request Details by Date
            DS = purchaseData.GetRequestList(request);
            rpRequestList.DataSource = DS;
            rpRequestList.DataBind();
            //lblBoxHeader.Text = "New Request List";
            upList.Update();
        }
    }
}