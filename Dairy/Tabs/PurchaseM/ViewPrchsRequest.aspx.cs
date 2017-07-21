using Bussiness;
using Dairy.App_code;
using Model.Purchase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dairy.Tabs.PurchaseM
{
    public partial class ViewPrchsRequest : System.Web.UI.Page
    {
        PurchaseData purchaseData;
        DataSet DS;
        Request request;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                purchaseData = new PurchaseData();
                DS = new DataSet();
                request = new Request();

                request.Flag = 1; //for getting Pending Request 
                DS = purchaseData.GetRequestList(request);
                rpRequestList.DataSource = DS;
                rpRequestList.DataBind();
                lblBoxHeader.Text = "New Request List";
                upList.Update();
            }
        }

        protected void rpRequestList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            divDanger.Visible = false;
            divwarning.Visible = false;
            divSusccess.Visible = false;
            pnlError.Update();
            int RequestId = 0;
            RequestId = Convert.ToInt32(e.CommandArgument);
            switch (e.CommandName)
            {
                case ("View"):
                    {
                        hfId.Value = RequestId.ToString();
                        GetDetailsById(RequestId);
                        upModal.Update();
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "my1", "$('#Sidebars').addClass('dispnone');", true);
                        break;
                    }
               
            }
        }

        private void GetDetailsById(int requestId)
        {
            purchaseData = new PurchaseData();
            DS = new DataSet();
            request = new Request();
            string result = string.Empty;
            request.RequestId = requestId;
            request.Flag = 2; //for getting Request Details
            DS = purchaseData.GetRequestList(request);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                StringBuilder sb = new StringBuilder();
                if (DS.Tables[1].Rows[0]["ReqStatus"].ToString() != "Pending")
                {
                    dpReqStatus.Visible = false;
                    BtnSubmitStatus.Visible = false;

                }
                else {
                    dpReqStatus.Visible = true;
                    BtnSubmitStatus.Visible = true;
                }
                lblReqStatus.Text = "Status " + DS.Tables[1].Rows[0]["ReqStatus"].ToString();

                sb.Append("<style type='text / css'>");
                sb.Append(".tg  { border - collapse:collapse; border - spacing:0; border: none; } .dispnone {display:none;}");
                sb.Append("</style>");
                sb.Append("<table class='tg style1' style='page-break-inside:avoid; align:center;'>");
                sb.Append("<colgroup>");
                sb.Append("<col style = 'width:100px'>");
                sb.Append("<col style = 'width:100px'>");
                sb.Append("<col style = 'width:100px'>");
                sb.Append("<col style = 'width:100px'>");
                sb.Append("<col style = 'width:100px'>");
                sb.Append("<col style = 'width:100px'>");
                sb.Append("<col style = 'width:100px'>");
                sb.Append("<col style = 'width:100px'>");
                sb.Append("</colgroup>");

                sb.Append("<tr>");
                sb.Append("<th class='tg-yw4l' rowspan='2' style='border-bottom:1px solid'>");
                sb.Append("<img src='/Theme/img/logo1.png' class='img-circle' alt='Logo' width='50px' hight='50px'>");
                sb.Append("</th>");

                sb.Append("<th class='tg-baqh' colspan='6' style='text-align:center'>");
                sb.Append("<u>Purchase Request </u> <br/>");
                sb.Append("</th>");

                sb.Append("<th class='tg-yw4l' colspan='3' style='text-align:right'>");

                sb.Append("GSTIN:&nbsp;33AAECN2463R1Z2<br>");
                sb.Append("</th>");
                sb.Append("</tr>");

                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append("<td class='tg-yw4l' colspan='6' style='text-align:center'>");
                sb.Append("<b>Nanjil Integrated Dairy Development, Mulagumoodu, K.K.Dt.</b>");

                sb.Append("</td>");
                sb.Append("<td class='tg-yw4l' style='text-align:right'>");
                sb.Append("PH:248370,248605");
                sb.Append("</td>");

                sb.Append("<tr style='border-bottom:1px solid'><td colspan='3'>");
                sb.Append("Request Date :" + (Convert.ToDateTime( DS.Tables[1].Rows[0]["ReqDate"])).ToString("dd-MM-yyyy"));
                sb.Append("</td>");
                sb.Append("<td colspan='2' style='text-align:center'>" );
                sb.Append("Status: <b>" + DS.Tables[0].Rows[0]["ReqStatus"] +"</b>");
                sb.Append("</td>");
                sb.Append("<td colspan='3' style='text-align:right'>");
                sb.Append("Request By: " + DS.Tables[1].Rows[0]["EmployeeCode"] + " " + DS.Tables[1].Rows[0]["EmployeeName"]); 
                sb.Append("</td>");
                sb.Append("</tr>");

                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append("<td> Sr.No </td>");
                sb.Append("<td colspan='2'>Item</td>");
                sb.Append("<td>Quantity</td>");
                sb.Append("<td>Stock</td>");
                sb.Append("<td>Specification</td>");
                sb.Append("<td>Purpose</td>");
                sb.Append("<td>Remarks</td></tr>");
                foreach (DataRow row in DS.Tables[0].Rows)
                {
                    sb.Append("<tr> <td>");
                    sb.Append(row["srno"].ToString());
                    sb.Append("</td> <td colspan='2'> ");
                    sb.Append(row["ItemName"].ToString());
                    sb.Append("</td> <td> ");
                    sb.Append(row["Quantity"].ToString() +" "+ row["UnitName"].ToString());
                    sb.Append("</td> <td> ");
                    sb.Append(row["Stock"].ToString());
                    sb.Append("</td> <td> ");
                    sb.Append(row["Specification"].ToString());
                    sb.Append("</td> <td> ");
                    sb.Append(row["Purpose"].ToString());
                    sb.Append("</td> <td> ");
                    sb.Append(row["Remark"].ToString());
                    sb.Append("</td> </tr> ");
                }
                    
                
                sb.Append("<tr style='border-top:1px solid'> <td colspan='8'> &nbsp; </td> </tr>");
                sb.Append("<tr> <td colspan='8'> &nbsp; </td></tr>");
                sb.Append("<tr> <td colspan='4'> Request By: " + DS.Tables[1].Rows[0]["EmployeeCode"] + " " + DS.Tables[1].Rows[0]["EmployeeName"]);
                sb.Append("</td> ");
                try
                {
                    string temp = DS.Tables[0].Rows[0]["ReqStatus"].ToString();
                    if ( temp== "Pending") { 
                    sb.Append("<td colspan='4' > &nbsp;");
                    sb.Append("</td> ");
                    }
                    if (temp== "Approved")
                    {
                        sb.Append("<td colspan='4' > Approved By: " + DS.Tables[2].Rows[0]["EmployeeCode"] + " " + DS.Tables[2].Rows[0]["EmployeeName"]);
                        sb.Append("</td> ");
                    }
                    if (temp == "Rejected")
                    {
                        sb.Append("<td colspan='4' > Rejected By: " + DS.Tables[2].Rows[0]["EmployeeCode"] + " " + DS.Tables[2].Rows[0]["EmployeeName"]);
                        sb.Append("</td> ");
                    }
                }
                catch (Exception)
                {

                    sb.Append("<td colspan='4' > &nbsp; ");
                    sb.Append("</td> ");
                }
                

                sb.Append("</tr>");
                sb.Append("");
                sb.Append("");
                sb.Append("");
                sb.Append("");
                sb.Append("");

                result = sb.ToString();
                RequestDetails.Text = result;

                Session["ctrl"] = pnlRequestDetails;

            }

          }

        protected void btnCloseModal_Click(object sender, EventArgs e)
        {

        }

        protected void BtnSubmitStatus_Click(object sender, EventArgs e)
        {
            purchaseData = new PurchaseData();
            DS = new DataSet();
            request = new Request();

            request.RequestId = Convert.ToInt32(hfId.Value);
            request.ReqStatus = dpReqStatus.SelectedItem.Text.ToString();
            request.CreatedBy = GlobalInfo.Userid; 
            request.Flag = 3; //3 for updating status

            bool result = purchaseData.SubmitRequestStatus(request);
            if (result)
            {
                GetDetailsById(request.RequestId);
                upModal.Update();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "my1", "$('#Sidebars').addClass('dispnone');", true);
            }
        }
    }
}