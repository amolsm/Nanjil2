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
    public partial class StaffAccountSalesSummary : System.Web.UI.Page
    {
        BillData billdata = new BillData();
        DataSet DS = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                EmployeeData empData = new EmployeeData();
                //DS = BindCommanData.BindCommanDropDwon("RouteID ", "RouteCode +' '+RouteName as Name  ", "routeMaster", "IsArchive=1");
                //if (!Comman.Comman.IsDataSetEmpty(DS))
                //{
                //    dpRoute.DataSource = DS;
                //    dpRoute.DataBind();
                //    dpRoute.Items.Insert(0, new ListItem("--All Route  --", "0"));
                //}

            }
        }

        protected void btngenrateBill_click(object sender, EventArgs e)
        {



            string result = string.Empty;
            DS = billdata.StaffAccountSalesSummarybyDate((Convert.ToDateTime(txtStartDate.Text)).ToString("dd-MM-yyyy"), (Convert.ToDateTime(txtEndDate.Text)).ToString("dd-MM-yyyy"));
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                StringBuilder sb = new StringBuilder();


                sb.Append("<style type='text / css'>");
                sb.Append(".tg  { border - collapse:collapse; border - spacing:0; border: none; }");
                sb.Append(".tg .tg-yw4l{vertical-align:top}");
                sb.Append(".tg .tg-baqh{text-align:center;vertical-align:top}");
                sb.Append("</style>");
                //sb.Append("<table class='tg style1' style='page-break-inside:avoid; align:center;'>");
                sb.Append("<table class='tg style1'  style=' position:relative;align:center;'>");
                sb.Append("<colgroup>");
                sb.Append("<col style = 'width:80px'>");
                sb.Append("<col style = 'width:100px'>");
                sb.Append("<col style = 'width:100px'>");
                sb.Append("<col style = 'width:100px'>");
                sb.Append("<col style = 'width:100px'>");
                sb.Append("<col style = 'width:100px'>");
             
                sb.Append("</colgroup>");

                sb.Append("<tr>");
                sb.Append("<th class='tg-yw4l' rowspan='2'>");
                sb.Append("<img src='/Theme/img/logo1.png' class='img-circle' alt='Logo' width='50px' hight='50px'>");
                sb.Append("</th>");

                sb.Append("<th class='tg-baqh' colspan='5' style='text-align:center'>");
                sb.Append("<u>Staff A/C Sales Summary </u> <br/>");
                sb.Append("</th>");
                sb.Append("<th class='tg-yw4l' style='text-align:right'>");
                sb.Append("TIN:330761667331<br>");
                sb.Append("</th>");
                sb.Append("</tr>");

                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append("<td class='tg-yw4l' colspan='5' style='text-align:center'>");
                sb.Append("<b>Nanjil Integrated Dairy Development, Mulagumoodu, K.K.Dt.</b>");
                sb.Append("</td>");
                sb.Append("<td class='tg-yw4l' style='text-align:right'>");
                sb.Append("PH:248370,248605");
                sb.Append("</td> </tr>");
                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append("<td class='tg-yw4l' colspan='3' style='text-align:left'>");
                sb.Append("Start Date:" + Convert.ToDateTime(txtStartDate.Text).ToString("dd-MM-yyyy"));
                sb.Append("</td>");
                sb.Append("<td class='tg-yw4l' colspan='3' style='text-align:left'>");
                sb.Append("End Date:" + Convert.ToDateTime(txtEndDate.Text).ToString("dd-MM-yyyy"));
                sb.Append("</td>");
                sb.Append("<td class='tg-yw4l'  style='text-align:right'>");
                sb.Append("Date : " + DateTime.Now.ToString());
                sb.Append("</td>");
                sb.Append("</tr>");
              

                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append("<td>");
                sb.Append("<b>Sr.No.</b>");
                sb.Append("</td>");
                sb.Append("<td>");
                sb.Append("<b>Staff Code</b>");
                sb.Append("</td>");
                sb.Append("<td colspan = '4'>");
                sb.Append("<b>Staff Name</b>");
                sb.Append("</td>");

                sb.Append("<td  style='text-align:right'>");
                sb.Append("<b>Amount</b>");
                sb.Append("</td>");
          
                sb.Append("</tr>");
                int srno = 0;
                double totalamt=0.00;
                foreach (DataRow row in DS.Tables[0].Rows)
                {
                    srno++;
                    sb.Append("<tr>");
                    sb.Append("<td>");
                    sb.Append(srno.ToString());
                    sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append(row["EmployeeCode"].ToString());
                    sb.Append("</td>");
                    sb.Append("<td colspan = '4'>");
                    sb.Append(row["EmployeeName"].ToString());
                    sb.Append("</td>");
                   
                    sb.Append("<td style='text-align:right'>");
                    if (string.IsNullOrEmpty(row["totalreturnAmount"].ToString()))
                    {
                        totalamt += Convert.ToDouble(row["TotalAmount"]);
                        sb.Append(Convert.ToDecimal(row["TotalAmount"]).ToString("#.00"));
                    }
                    else
                    {
                        double amt = (Convert.ToDouble(row["TotalAmount"]) - Convert.ToDouble(row["totalreturnAmount"]));
                        sb.Append(Convert.ToDecimal(amt).ToString("#.00"));
                        totalamt += amt;
                    }
                    sb.Append("</td>");
                    sb.Append("</tr>");
                 

                   
                }
                sb.Append("<tr style='border-bottom:1px solid'> <td colspan = '7'> &nbsp; </td> </tr>");
                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append("<td colspan = '6' style='text-align:left'> ");
                sb.Append("<b>" + "Total Amount" + "</b>");
                sb.Append("</td>");
                sb.Append("<td style='text-align:right'>");
                sb.Append("<b>" + (Convert.ToDecimal(totalamt).ToString("#.00")) + "</b>");
                sb.Append("</td>");
                sb.Append("</tr>");



                result = sb.ToString();
                genratedBIll.Text = result;
                //Session["ctrl"] = sb.ToString();
                Session["ctrl"] = pnlBill;
                //Response.Redirect("/print.aspx", true);

            }


            else
            {
                result = "Report not found";
                genratedBIll.Text = result;

            }
        }
    }
}