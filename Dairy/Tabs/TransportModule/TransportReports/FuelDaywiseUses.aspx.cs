using Bussiness;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dairy.Tabs.TransportModule.TransportReports
{
    public partial class FuelDaywiseUses : System.Web.UI.Page
    {
        TransportData transportdata = new TransportData();
        DataSet DS = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtStartDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                txtEndDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
            }
        }

        protected void btngenrateBill_click(object sender, EventArgs e)
        {
            string result = string.Empty;
            double FuelLtr = 0;
            double Amt = 0;

            DS = transportdata.FuelDailyUses((Convert.ToDateTime(txtStartDate.Text)).ToString("dd-MM-yyyy"), (Convert.ToDateTime(txtEndDate.Text)).ToString("dd-MM-yyyy"));
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("<style type='text / css'>");
                sb.Append(".tg  { border - collapse:collapse; border - spacing:0; border: none; }");
                sb.Append(".tg .tg-yw4l{vertical-align:top}");
                sb.Append(".tg .tg-baqh{text-align:center;vertical-align:top}");
                sb.Append("</style>");
                sb.Append("<table class='tg style1' style='page-break-inside:avoid; align:center;'>");
                sb.Append("<colgroup>");
                sb.Append("<col style = 'width:120px'>");
                sb.Append("<col style = 'width:120px'>");
                sb.Append("<col style = 'width:120px'>");
                sb.Append("<col style = 'width:120px'>");
                sb.Append("<col style = 'width:120px'>");
                //sb.Append("<col style = 'width:120px'>");

                sb.Append("</colgroup>");

                sb.Append("<tr>");
                sb.Append("<th class='tg-yw4l' rowspan='2'>");
                sb.Append("<img src='/Theme/img/logo1.png' class='img-circle' alt='Logo' width='50px' hight='50px'>");
                sb.Append("</th>");

                sb.Append("<th class='tg-baqh' colspan='3' style='text-align:center'>");
                sb.Append("<u> Total Fuel Uses Details -Datewise </u> <br/>");
                sb.Append("</th>");

                sb.Append("<th class='tg-yw4l' colspan='2' style='text-align:right'>");

                sb.Append("TIN:330761667331<br>");
                sb.Append("</th>");
                sb.Append("</tr>");

                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append("<td class='tg-yw4l' colspan='3' style='text-align:center'>");
                sb.Append("<b>Nanjil Integrated Dairy Development, Mulagumoodu, K.K.Dt.</b>");

                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l' colspan='2'  style='text-align:right'>");

                sb.Append("PH:248370,248605");

                sb.Append("</td>");

                sb.Append("<tr>");
                sb.Append("<td class='tg-yw4l' colspan='3' style='text-align:left'>");
                sb.Append("Start Date:" + Convert.ToDateTime(txtStartDate.Text).ToString("dd-MM-yyyy"));
                sb.Append("</td>");
                sb.Append("<td class='tg-yw4l' colspan='2' style='text-align:right'>");
                sb.Append("End Date:" + Convert.ToDateTime(txtEndDate.Text).ToString("dd-MM-yyyy"));
                sb.Append("</td>");
                sb.Append("<tr style='border-bottom:2px solid'>");
                sb.Append("<td class='tg-yw4l' colspan='5' style='text-align:left'>");
                sb.Append("<tr style='border-bottom:1px dotted'> <td colspan = '5'> &nbsp; </td> </tr>");
                sb.Append("<tr style='border-bottom:1px solid'>");

                sb.Append("<td class='tg-yw4l'  style='text-align:left'>");
                sb.Append("<b>Sr.No</b>");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l' style='text-align:left'>");
                sb.Append("<b>Date</b>");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l'  style='text-align:center'>");
                sb.Append("<b>FuelLts.</b>");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l' colspan='2'  style='text-align:right'>");
                sb.Append("<b>Amount</b>");
                sb.Append("</td>");

              
               

                sb.Append("</tr>");
                int Entries = 0;
                foreach (DataRow row in DS.Tables[0].Rows)
                {
                    Entries++;
                    sb.Append("<tr>");

                    sb.Append("<td class='tg-yw4l'  style='text-align:left'>");
                    sb.Append(Entries.ToString());
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l'  style='text-align:left'>");
                    sb.Append(row["RefielDate"].ToString());
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l'   style='text-align:center'>");
                    sb.Append(row["FuelLts"].ToString());
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l' colspan='2' style='text-align:right'>");
                    sb.Append(Convert.ToDecimal(row["Amount"]).ToString("#.00"));
                    sb.Append("</td>");

                   
                    sb.Append("</tr>");
                    FuelLtr = FuelLtr + Convert.ToDouble(row["FuelLts"]);
                    Amt = Amt + Convert.ToDouble(row["Amount"]);
                  

                }
                sb.Append("<tr style='border-bottom:1px dotted'> <td colspan = '5'> &nbsp; </td> </tr>");
                sb.Append("<tr style='border-bottom:1px dotted'>");

                sb.Append("<td  class='tg-yw4l'  style='text-align:left'>");
                sb.Append("<b>" + Entries + "&nbsp;&nbsp;" + "Entries" + "</b>");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l'  style='text-align:left'>");
                sb.Append("<b>" + "Total:" + "</b>");
                sb.Append("</td>");
              
                sb.Append("<td class='tg-yw4l'  style='text-align:center'>");
              
                sb.Append("<b>" + FuelLtr + "</b>");
                sb.Append("</td>");
              
                sb.Append("<td class='tg-yw4l' colspan='2' style='text-align:right'>");
              
                sb.Append("<b>" + Convert.ToDecimal(Amt).ToString("#.00") + "</b>");
                sb.Append("</td>");
             
                sb.Append("</tr>");
                sb.Append("</td>");
                sb.Append("</tr>");



                result = sb.ToString();
                genratedBIll.Text = result;
                //Session["ctrl"] = sb.ToString();
                Session["ctrl"] = pnlBill;


            }


            else
            {
                result = "Fuel List Details Not Found";
                genratedBIll.Text = result;

            }

        }
    }
}