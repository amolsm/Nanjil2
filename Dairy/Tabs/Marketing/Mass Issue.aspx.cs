using Bussiness;
using Model;
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
   
    public partial class Mass_Issue : System.Web.UI.Page
    {
        MassIssueData massIssueData = new MassIssueData();
        MassIssueModel massIssueModel = new MassIssueModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                txtStartDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                txtEndDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
            }
        }
       
        protected void btnView_click(object sender, EventArgs e)
        {
            DataSet DS = new DataSet();
            string result = string.Empty;

            massIssueModel.AllIssue = "AllIssue";
            massIssueModel.SelectedIssue = "SelectedIssue";


            if (dpIssue.SelectedIndex == 0) {
              
                massIssueModel.flag = massIssueModel.AllIssue;
            }
            else
                massIssueModel.flag = massIssueModel.SelectedIssue;

          
            string StartDate = Convert.ToDateTime(txtStartDate.Text).ToString("dd-MM-yyyy");
            string EndDate = Convert.ToDateTime(txtEndDate.Text).ToString("dd-MM-yyyy");


            DS = massIssueData.viewMassIssue(txtStartDate.Text,txtEndDate.Text,dpIssue.SelectedItem.ToString(), massIssueModel.flag);

            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                StringBuilder sb = new StringBuilder();
                   
                sb.Append("<style type='text/css'>");
                sb.Append(".tg  { border - collapse:collapse; border - spacing:0; border: none; }");
                sb.Append(".tg .tg-yw4l{vertical-align:top}");
                sb.Append(".tg .tg-baqh{text-align:center;vertical-align:top}");
                sb.Append("</style>");

                sb.Append("<table class='tg'  style='page-break-inside:avoid; align:center;' >");

                sb.Append("<colgroup>");
                sb.Append("<col style = 'width:70px'>");
                sb.Append("<col style = 'width:50px'>");
                sb.Append("<col style = 'width:40px'>");
                sb.Append("<col style = 'width:50px'>");
                sb.Append("<col style = 'width:50px'>");
                sb.Append("<col style = 'width:50px'>");
                sb.Append("<col style = 'width:50px'>");
                sb.Append("</colgroup>");

                sb.Append("<tr>");
                sb.Append("<th class='tg-yw4l' rowspan='2' font size='6'>");
                sb.Append("<img src='/Theme/img/logo.png' class='img-circle' alt='Logo' width='50px' hight='50px'>");
                sb.Append("</th>");

                sb.Append("<th class='tg-baqh' colspan='14' style='text-align:center'>");
                sb.Append("<b>Nanjil Integrated Dairy Devlopment ,Mulagumoodu -629 167,K.K.Dt.</b>");              
                sb.Append("</th>"); 
                sb.Append("</tr>");

                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append("<td class='tg-yw4l' colspan='18' style='text-align:center'>");
                sb.Append("<u>Issues Details</u>");
                sb.Append("</td>");
                sb.Append("</tr>");

                sb.Append("<tr style='border-bottom:1px solid'>");

                 sb.Append("<td colspan='14' >"); // line to above the start date
                sb.Append("Issue : " + dpIssue.SelectedItem.ToString());
                sb.Append("</td>");
                                 
                sb.Append("</tr>");

                sb.Append("<tr style='border-bottom:1px solid'>");

                sb.Append("<td colspan='12'>"); // line to above the start date
                sb.Append("StartDate: " + StartDate);
                sb.Append("</td>");

                sb.Append("<td colspan='12'>");
                sb.Append("EndDate : " + EndDate);
                sb.Append("</td>");
                sb.Append("</tr>");

              
                sb.Append("<tr style='border-bottom:1px solid'>");

                sb.Append("<td colspan='2'>");
                sb.Append("IssueCode");
                sb.Append("</td>");

                sb.Append("<td>");
                sb.Append("</td>");

                sb.Append("<td colspan='2'>");
                sb.Append("Product");
                sb.Append("</td>");

               
                sb.Append("<td colspan='2'>");
                sb.Append("RegisteredOn");
                sb.Append("</td>");

                sb.Append("<td >");                
                sb.Append("</td>");

                sb.Append("<td colspan='2'>");
                sb.Append("Reg.By");
                sb.Append("</td>");

                sb.Append("<td>");
                sb.Append("</td>");


                sb.Append("<td colspan='3' >");
                sb.Append("Phone");
                sb.Append("</td>");

               
                sb.Append("<td>");
                sb.Append("</td>");


                sb.Append("<td colspan='2'>");
                sb.Append("Action");
                sb.Append("</td>");

                sb.Append("</tr>");
                foreach (DataRow row in DS.Tables[0].Rows)
                {

                    sb.Append("<tr>");

                    sb.Append("<td colspan='2'>");
                    sb.Append(row["IssueCode"].ToString());
                    sb.Append("</td>");

                    sb.Append("<td>");
                    sb.Append("</td>");


                    sb.Append("<td colspan='2'>");
                    sb.Append(row["commodityItem"].ToString());
                    sb.Append("</td>");
                   

                    sb.Append("<td colspan='2'>");

                    sb.Append(Convert.ToDateTime(row["IssueDateTime"]).ToString("dd-MM-yyyy"));
                    sb.Append("</td>");

                    sb.Append("<td>");
                    sb.Append("</td>");


                    sb.Append("<td colspan='2'>");
                   sb.Append(row["IssueArisedBy"].ToString());
                    sb.Append("</td>");

                    sb.Append("<td >");
                    sb.Append("</td>");


                    sb.Append("<td colspan='3'>");                  
                    sb.Append(row["ContactNo"].ToString());
                    sb.Append("</td>");

                    sb.Append("<td>");
                    sb.Append("</td>");

                    sb.Append("<td colspan='2'>");
                    sb.Append(row["Action"].ToString());
                    sb.Append("</td>");


                    sb.Append("</tr>");



                }
             

                result = sb.ToString();
                Issue.Text = result;
                Session["ctrl"] = pnlBill;
               
            }
            else
            {

                result = "Issues not FOund";
                Issue.Text = result;

            }




        }
    }
}