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
    public partial class ViewPurchaseOrder : System.Web.UI.Page
    {
        PurchaseData purchaseData;
        DataSet DS;
        Order order;
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
            order = new Order();
            order.OrderDate = string.IsNullOrEmpty(txtPODate.Text) ? string.Empty : Convert.ToDateTime(txtPODate.Text).ToString("dd-MM-yyyy");
            order.Flag = 1; //for getting Approved Request Details by Date
            DS = purchaseData.GetOrderList(order);
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
            int orderId = 0;
            orderId = Convert.ToInt32(e.CommandArgument);
            switch (e.CommandName)
            {
                case ("View"):
                    {
                        hfId.Value = orderId.ToString();
                        GetDetailsById(orderId);
                        upModal.Update();
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "my1", "$('#Sidebars').addClass('dispnone');", true);
                        break;
                    }

            }
        }

        private void GetDetailsById(int orderId)
        {
            purchaseData = new PurchaseData();
            DS = new DataSet();
            order = new Order();
            string result = string.Empty;
            order.OrderId = orderId;
            order.Flag = 2; //for getting Order Details
            DS = purchaseData.GetOrderList(order);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                StringBuilder sb = new StringBuilder();
                

                sb.Append("<style type='text / css'>");
                sb.Append(".tg  { border - collapse:collapse; border - spacing:0; border: none; } .dispnone {display:none;} ");
                sb.Append("</style>");
                sb.Append("<table class='tg style1' style='page-break-inside:avoid; align:center;'>");
                sb.Append("<colgroup>");
                sb.Append("<col style = 'width:50px'>");
                sb.Append("<col style = 'width:220px'>");
                sb.Append("<col style = 'width:100px'>");
                sb.Append("<col style = 'width:80px'>");
                sb.Append("<col style = 'width:80px'>");
                sb.Append("<col style = 'width:80px'>");
                sb.Append("<col style = 'width:80px'>");
                sb.Append("<col style = 'width:100px'>");
                sb.Append("</colgroup>");

                sb.Append("<tr>");
                sb.Append("<th class='tg-yw4l' rowspan='3' style='border-bottom:1px solid'>");
                sb.Append("<img src='/Theme/img/logo1.png' class='img-circle' alt='Logo' width='50px' hight='50px'>");
                sb.Append("</th>");

                sb.Append("<th class='tg-baqh' colspan='6' style='text-align:center'>");
                sb.Append("<u>Purchase Order </u> <br/>");
                sb.Append("</th>");

                sb.Append("<th class='tg-yw4l' colspan='3' style='text-align:right'>");

                sb.Append("TIN:330761667331<br>");
                sb.Append("</th>");
                sb.Append("</tr>");

                sb.Append("<tr >");
                sb.Append("<td class='tg-yw4l' colspan='6' style='text-align:center; Font-size:15px'>");
                sb.Append("<b>Nanjil Integrated Dairy Development</b>");

                sb.Append("</td>");
                sb.Append("<td class='tg-yw4l' style='text-align:right'>");
                sb.Append("CST: 1078823");
                sb.Append("</td>");
                sb.Append("</tr>");
                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append("<td class='tg-yw4l' colspan='6' style='text-align:center'>");
                sb.Append("<b>5/15, Mulagumoodu, Kanyakumari-629167, TamilNadu,India</b>");

                sb.Append("</td>");
                sb.Append("<td class='tg-yw4l' style='text-align:right'>");
                sb.Append("PH:248370,248605");
                sb.Append("</td>");
                sb.Append("</tr>");

                sb.Append("<tr> <td colspan='8' style=text-align:right; padding-top:10px>");
                sb.Append("Order No: NIDD-PO-" + DS.Tables[0].Rows[0]["OrderId"]);
                sb.Append("</td></tr>");
                sb.Append("<tr> <td colspan='8' style=text-align:right; padding-top:10px>");
                sb.Append("Date : " + DateTime.Now.ToLongDateString());
                sb.Append("</td></tr>");
                sb.Append("<tr> <td style=text-align:right> To, </td> </tr>");
                sb.Append("<tr> <td> &nbsp </td> <td colspan=3> <b>");
                sb.Append(DS.Tables[0].Rows[0]["VendorCode"] + " "+ DS.Tables[0].Rows[0]["VendorName"]);
                sb.Append("</b> </td></tr>");
                sb.Append("<tr> <td> &nbsp </td> <td colspan=3>");
                sb.Append(DS.Tables[0].Rows[0]["Address"]);
                sb.Append("</td></tr>");
                sb.Append("<tr> <td> &nbsp </td> <td colspan=3>");
                sb.Append(DS.Tables[0].Rows[0]["City"]);
                sb.Append("</td></tr>");
                sb.Append("<tr> <td> &nbsp </td> <td colspan=3>");
                sb.Append(DS.Tables[0].Rows[0]["State"]);
                sb.Append("</td></tr>");
                sb.Append("<tr> <td> &nbsp </td> <td colspan=3> Phone:");
                sb.Append(DS.Tables[0].Rows[0]["Mobile"] + " , " + DS.Tables[0].Rows[0]["Phone"]);
                sb.Append("</td></tr>");
                sb.Append("<tr> <td> &nbsp </td> <td colspan=3> Email: ");
                sb.Append(DS.Tables[0].Rows[0]["Email"] );
                sb.Append("</td></tr>");

                sb.Append("<tr><td>&nbsp;</td><tr>");

                sb.Append("<tr> <td style=text-align:right> <b> Dear Sir </b> </td></tr>");
                sb.Append("<tr><td>&nbsp;</td> <td colspan='5'> <b> We are placing the order for followings </b> </td></tr>");
                sb.Append("<tr style='border:solid;border-width:1px;'> <td style='border:solid;border-width:1px;padding:1px; padding-left:3px'>Sr.No</td> <td style='border:solid;border-width:1px;padding:1px; padding-left:3px'>Items</td>");
                sb.Append("<td style='border:solid;border-width:1px;padding:1px; padding-left:3px'>Quantity</td> <td style='border:solid;border-width:1px;padding:1px; padding-left:3px'>Rate</td>");
                sb.Append("<td style='border:solid;border-width:1px;padding:1px; padding-left:3px'>Excise</td> <td style='border:solid;border-width:1px;padding:1px; padding-left:3px'>CST</td>");
                sb.Append("<td style='border:solid;border-width:1px;padding:1px; padding-left:3px'>VAT</td> <td style='border:solid;border-width:1px;padding:1px; padding-left:3px'>Amount </td> </tr>");

                foreach (DataRow row in DS.Tables[1].Rows)
                {
                    sb.Append("<tr style='border:solid;border-width:1px;'>");
                    sb.Append("<td style='border:solid;border-width:1px;padding:1px; padding-left:3px'>");
                    sb.Append(row["srno"].ToString() + "</td>");
                    sb.Append("<td style='border:solid;border-width:1px;padding:1px; padding-left:3px'>");
                    sb.Append(row["ItemName"].ToString() + "</td>");
                    sb.Append("<td style='border:solid;border-width:1px;padding:1px; padding-left:3px'>");
                    sb.Append(row["Quantity"].ToString() + "</td>");
                    sb.Append("<td style='border:solid;border-width:1px;padding:1px; padding-left:3px'>");
                    sb.Append(Convert.ToDecimal(row["Price"]).ToString("#0.00") + "</td>");
                    sb.Append("<td style='border:solid;border-width:1px;padding:1px; padding-left:3px'>");
                    sb.Append(row["Excise"].ToString() + "</td>");
                    
                    sb.Append("<td style='border:solid;border-width:1px;padding:1px; padding-left:3px'>");
                    sb.Append(row["CST"].ToString() + "</td>");
                    sb.Append("<td style='border:solid;border-width:1px;padding:1px; padding-left:3px'>");
                    sb.Append(row["VAT"].ToString() + "</td>");
                    sb.Append("<td style='border:solid;border-width:1px;padding:1px; padding-left:3px'>");
                    sb.Append(Convert.ToDecimal( row["Amt"]).ToString("#0.00") + "</td>");
                    sb.Append("</tr>");
                }
                    
                sb.Append("<tr><td>&nbsp;</td><tr>");
                sb.Append("<tr><td>&nbsp;</td><tr>");
                sb.Append("<tr> <td colspan='4'> <b><u> Terms and Conditions </u></b></td></tr>");
                sb.Append("<tr> <td>&nbsp;</td> <td> <b> Frieght               : </b>" + DS.Tables[0].Rows[0]["Frieght"] + "</td></tr>");
                sb.Append("<tr> <td>&nbsp;</td> <td> <b> Payment Terms         : </b>" + DS.Tables[0].Rows[0]["PaymentTerms"] + "</td></tr>");
                sb.Append("<tr> <td>&nbsp;</td> <td colspan='5'> <b> Billing & Delivery Address :  Nanjil Integrated Dairy Development </b></td></tr>");
                sb.Append("<tr> <td>&nbsp;</td> <td> <b> Amount                : </b>" + Convert.ToDecimal(DS.Tables[0].Rows[0]["TotalAmt"]).ToString("#0.00") + "</td></tr>");
                sb.Append("<tr> <td>&nbsp;</td> <td> <b> Required Date         : </b>" + DS.Tables[0].Rows[0]["TillDate"] + "</td></tr>");
                sb.Append("<tr> <td>&nbsp;</td> <td> <b> Transportation Damage : </b>" + DS.Tables[0].Rows[0]["TransDamage"] + "</td></tr>");
                sb.Append("<tr><td>&nbsp;</td><tr>");
                sb.Append("<tr> <td colspan='4'> &nbsp </td> <td colspan='4' style='text-align:center'> Yours Sincerely </td> </td>");
                sb.Append("<tr> <td colspan='4'> &nbsp </td> <td colspan='4' style='text-align:center'> <b>For Nanjil Integrated Dairy Development</b> </td> </td>");
                sb.Append("<tr><td>&nbsp;</td><tr>");
                sb.Append("<tr><td>&nbsp;</td><tr>");
                if(Convert.ToDecimal(DS.Tables[0].Rows[0]["TotalAmt"]) >49999)
                    sb.Append("<tr> <td colspan='4'> &nbsp </td> <td colspan='4' style='text-align:center'><b> Managing Director</b></td> </td>");
                else
                    sb.Append("<tr> <td colspan='4'> &nbsp </td> <td colspan='4' style='text-align:center'><b> Purchase Manager</b></td> </td>");
                sb.Append("");
                sb.Append("");
                sb.Append("");

                result = sb.ToString();
                RequestDetails.Text = result;

                Session["ctrl"] = pnlRequestDetails;

            }
        }
    }
}