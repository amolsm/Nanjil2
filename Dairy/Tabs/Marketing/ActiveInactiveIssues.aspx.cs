using Bussiness;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dairy.Tabs.Marketing
{
    public partial class ActiveInactiveIssues : System.Web.UI.Page
    {
        ActiveInactiveIssuesData activeInactiveIssuesData = new ActiveInactiveIssuesData();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
            }

            }
        protected void btnView_click(object sender, EventArgs e)
        {

            DataSet DS = new DataSet();
            string result = string.Empty;

            string StartDate = Convert.ToDateTime(txtStartDate.Text).ToString("dd-MM-yyyy");
            string EndDate = Convert.ToDateTime(txtEndDate.Text).ToString("dd-MM-yyyy");

            DS = activeInactiveIssuesData.viewActiveInactiveIssues(txtStartDate.Text, txtEndDate.Text, dpIssue.SelectedItem.ToString());
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                StringBuilder sb = new StringBuilder();
                int count = 0;
                int qty = 0;
                sb.Append("<style type='text / css'>");
                sb.Append(".tg  { border - collapse:collapse; border - spacing:0; border: none; }");
                sb.Append(".tg .tg-yw4l{vertical-align:top}");
                sb.Append(".tg .tg-baqh{text-align:center;vertical-align:top}");
                sb.Append("</style>");
                sb.Append("<table class='tg' style='page-break-inside:avoid; align:center;'>");
                sb.Append("<colgroup>");
                sb.Append("<col style = 'width:100px'>");
                sb.Append("<col style = 'width:100px'>");
                sb.Append("<col style = 'width:80px'>");
                sb.Append("<col style = 'width:120px'>");
                sb.Append("<col style = 'width:120px'>");
                sb.Append("<col style = 'width:100px'>");
                sb.Append("<col style = 'width:100px'>");
                sb.Append("<col style = 'width:100px'>");
                sb.Append("</colgroup>");

                sb.Append("<tr>");
                sb.Append("<th class='tg-yw4l' rowspan='2'>");
                sb.Append("<img src='/Theme/img/logo.png' class='img-circle' alt='Logo' width='50px' hight='50px'>");
                sb.Append("</th>");

                sb.Append("<th class='tg-baqh' colspan='6' style='text-align:center'>");
                sb.Append("<b>Nanjil Integrated Dairy Devlopment ,Mulagumoodu -629 167,K.K.Dt.</b>");
                //sb.Append("<u> Cash/Credit </u> <br/>");
                sb.Append("</th>");


                // sb.Append("<th class='tg-yw4l' style='text-align:right'>");
                // sb.Append("TIN:330761667331<br>");
                //sb.Append("</th>");

                sb.Append("</tr>");


                sb.Append("<tr style='border-bottom:1px solid'>");

                sb.Append("<td class='tg-yw4l' colspan='6' style='text-align:center'>");

                sb.Append("<u>Issues details Basis of Status</u>");

                sb.Append("</td>");
                sb.Append("</tr>");

                sb.Append("<tr style='border-bottom:1px solid'>");

                // sb.Append("<td class='tg-yw4l' colspan='6' style='text-align:center'>");
                sb.Append("<td>");
                sb.Append("Status : " + dpIssue.SelectedItem.ToString());
                sb.Append("</td>");

                sb.Append("<td>");
                sb.Append("StartDate: " + StartDate);
                sb.Append("</td>");
                sb.Append("<td class='tg-yw4l' style='text-align:right'>");
                sb.Append("EndDate : " + EndDate);
                sb.Append("</td>");

                //   sb.Append("</td>");
                sb.Append("</tr>");



                sb.Append("<tr style='border-bottom:1px solid'>");

                sb.Append("<td>");
                sb.Append("Product ");
                sb.Append("</td>");

                sb.Append("<td>");
                sb.Append("RegisteredDate");
                sb.Append("</td>");

                sb.Append("<td>");
                sb.Append("Issue");
                sb.Append("</td>");

             

                foreach (DataRow row in DS.Tables[0].Rows)
                {

                    sb.Append("<tr style='border-bottom:0.1px'>");

                    sb.Append("<td>");
                    //sb.Append("Item");
                    sb.Append(row["commodityItem"].ToString());
                    sb.Append("</td>");

                    sb.Append("<td>");
                    //sb.Append("Date");
                    sb.Append(row["IssueDateTime"].ToString());
                    sb.Append("</td>");

                    sb.Append("<td>");
                    //sb.Append("ArisedBy");
                    sb.Append(row["IssueCode"].ToString());
                    sb.Append("</td>");

                            


                    sb.Append("<div class='col-md-2'>");
                    sb.Append("&nbsp");
                    sb.Append("</div>");
                    sb.Append("</div>");
                    sb.Append("</div>");
                    sb.Append("</tr>");


                    sb.Append("<div class='row'>");

                    //DS1 = billdata.GenrateBIllDetailsID(Convert.ToInt32(row["orderID"]));

                    sb.Append("</div>");

                }
                result = sb.ToString();
                genratedBIll.Text = result;
                //Session["ctrl"] = sb.ToString();
                Session["ctrl"] = pnlBill;
                //Response.Redirect("/print.aspx", true);
            }
            else
            {
                result = "Issues not FOund";
                genratedBIll.Text = result;

            }
        }
    }
}