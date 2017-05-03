using Bussiness;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dairy.Tabs.Procurement
{
    public partial class HardCopyTariff1 : System.Web.UI.Page
    {
        BHardCopyTariff bhardcopytariff = new BHardCopyTariff();
        DataSet DS = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            txtDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        protected void btngenrateBill_Click(object sender, EventArgs e)
        {
            if (dpTariff.SelectedIndex == 1)
            {
                string result = string.Empty;

                DS = bhardcopytariff.GetHardCopyTariff((Convert.ToInt32(dpTariff.SelectedItem.Value)));
                if (!Comman.Comman.IsDataSetEmpty(DS))
                {
                    StringBuilder sb = new StringBuilder();

                    sb.Append("<style type ='text/css'>");
                    sb.Append(".tg  { border-collapse:collapse; border-spacing:0; }");
                    sb.Append(".tg td{ font-family:Arial, sans-serif; font-size:14px; padding: 10px 5px; border-style:solid; border-width:1px; overflow: hidden; word-break:normal; text-align:center;}");
                    sb.Append(".tg th{ font-family:Arial, sans-serif; font-size:14px; font-weight:normal; padding: 10px 5px; border-style:solid; border-width:1px; overflow:hidden; word-break:normal; text-align:center;}");
                    sb.Append(".tg .tg-baqh{text-align:center;vertical-align:top}");
                    sb.Append(".tg.tg-yw4l{ vertical-align:top}");
                    sb.Append(".tg .tg-yw4Q{vertical-align:middle ; padding:5px; border-right-style:hidden;}");
                    sb.Append("@media screen and(max-width:767px) {.tg { width: auto !important; }.tg col { width:auto !important; }.tg-wrap { overflow-x:auto;-webkit-overflow-scrolling:touch; } }</style>");
                    sb.Append("<div class='tg -wrap'><table class='tg'>");

                    sb.Append("<tr>");
                    sb.Append("<th class='tg-yw4Q'>");
                    sb.Append("<img src='/Theme/img/logo1.png' class='img-circle' alt='Logo' width='50px' hight='50px'>");
                    sb.Append("<th class='tg-baqh' colspan='18'><b>Nanjil Milk Plant,   Mulagumoodu, K.K.Dt.</b><br><br><small> CC-Milk Collection Transport Tariff</small></th>");
                    sb.Append("</tr>");

                    sb.Append("<tr>");
                    sb.Append(" <td  colspan='5' align='left' style= 'text-align:left; border-right-width:0px'>");
                    //Tariff: " + dpTariff.SelectedItem.Text.ToString());
                    sb.Append("</td>");
                    sb.Append("<td  colspan='2' align='right' style='border-left-width:0px'>Date: " + Convert.ToDateTime(txtDate.Text).ToString("dd-MM-yyyy"));
                    sb.Append("</tr>");

                    sb.Append("<tr>");
                    sb.Append("<th class='tg-031e'>Sr.No</th>");
                    sb.Append("<th class='tg-yw4l' colspan='2'>Vehicle Model</th>");
                    sb.Append("<th class='tg-yw4l' colspan='2'>KM Low</th>");
                    sb.Append("<th class='tg-yw4l'>KM High</th>");
                    sb.Append("<th class='tg-yw4l'>Amount</th>");
                    //sb.Append("<th class='tg-yw4l'>201-250</th>");
                    //sb.Append("<th class='tg-yw4l' >251-300</th>");
                    //sb.Append("<th class='tg-yw4l'>KM&gt;300</th>");
                    sb.Append("</tr>");
                    sb.Append("<tr>");
                    int count = 0;
                    foreach (DataRow row in DS.Tables[0].Rows)
                    {
                        count++;

                        sb.Append("<td class='tg-031e'>" + count.ToString());
                        sb.Append("</td>");
                        sb.Append("<td class='tg-yw4l' colspan='2'>" + row["VehicleType"].ToString());
                        sb.Append("</td>");
                        sb.Append("<td class='tg-yw4l' colspan='2'>" + Convert.ToDouble(row["KMLow"]).ToString("0.00"));
                        sb.Append("</td>");
                        sb.Append("<td class='tg-yw4l'>" + Convert.ToDouble(row["KMHigh"]).ToString("0.00"));
                        sb.Append("</td>");
                        sb.Append("<td class='tg-yw4l'>" + Convert.ToDouble(row["Amount"]).ToString("0.00"));
                        sb.Append("</td>");
                        //sb.Append("<td class='tg-yw4l'>" + Convert.ToDouble(row["201To250"]).ToString("0.00"));
                        //sb.Append("</td>");
                        //sb.Append("<td class='tg-yw4l' >" + Convert.ToDouble(row["251To300"]).ToString("0.00"));
                        //sb.Append("</td>");
                        //sb.Append("<td class='tg-yw4l'>" + Convert.ToDouble(row["KMGreaterThan300"]).ToString("0.00"));
                        //sb.Append("</td>");
                        sb.Append("</tr>");
                    }
                    sb.Append("</table></div>");

                    result = sb.ToString();
                    genratedBIll.Text = result;

                    Session["ctrl"] = pnlBill;
                }
                else
                {
                    result = "Statement not found";
                    genratedBIll.Text = result;

                }
            }
            else if (dpTariff.SelectedIndex == 2)
            {
                string result = string.Empty;

                DS = bhardcopytariff.GetHardCopyTariff((Convert.ToInt32(dpTariff.SelectedItem.Value)));
                if (!Comman.Comman.IsDataSetEmpty(DS))
                {
                    StringBuilder sb = new StringBuilder();

                    sb.Append("<style type='text/css'>");
                    sb.Append(".tg  { border-collapse:collapse; border-spacing:0;}");

                    sb.Append(".tg td{ font-family:Arial, sans-serif; font-size:14px; padding: 10px 5px; border-style:solid; border-width:1px; overflow:hidden; word-break:normal; text-align:center;}");
                    sb.Append(".tg .tg-yw4Q{vertical-align:middle ; padding:5px; border-right-style:hidden;}");
                    sb.Append(".tg th{ font-family:Arial, sans-serif; font-size:14px; font-weight:normal; padding:10px 5px; border-style:solid; border-width:1px; overflow:hidden; word-break:normal; text-align:center;}");
                    sb.Append(".tg.tg-yw4l{ vertical-align:top}");
                    sb.Append(".tg .tg-baqh{text-align:center;vertical-align:top}");
                    sb.Append("@media screen and(max-width:767px) {.tg { width:auto !important;}.tg col { width:auto !important;}.tg-wrap { overflow-x:auto; -webkit-overflow-scrolling: touch;}}</style>");
                    sb.Append("<div class='tg-wrap'><table class='tg'>");
                    sb.Append("<tr>");
                    sb.Append("<th class='tg-yw4Q'>");
                    sb.Append("<img src='/Theme/img/logo1.png' class='img-circle' alt='Logo' width='50px' hight='50px'>");
                    sb.Append("<th class='tg-baqh' colspan='12'><b>Nanjil Milk Plant,   Mulagumoodu, K.K.Dt.</b><br><small><u>RawMilk Procurement Tariff</u></small></th>");
                    sb.Append("</tr>");

                    sb.Append("<tr>");
                    sb.Append("<td colspan ='4' align='left' style='text-align:left; border-right-width:0px; '>");
                    //Tariff: " + dpTariff.SelectedItem.Text.ToString());
                    sb.Append("<td colspan='7' align='center' style='border-right-width:0px; border-left-width:0px;'> All CCs </td>");
                    sb.Append("<td colspan='2'align='right' style='text-align:right; border-left-width:0px;'> Date: " + Convert.ToDateTime(txtDate.Text).ToString("dd-MM-yyyy"));
                    sb.Append("<tr>");

                    sb.Append("<td class='tg-031e'>cate-<br>gory</td>");
                    sb.Append("<td class='tg-031e'>TS<br> Low</td>");
                    sb.Append("<td class='tg-031e'>TS<br> High</td>");
                    sb.Append("<td class='tg-031e'>TS<br> Rate</td>");
                    sb.Append("<td class='tg-031e'>TS<br> Incr</td>");
                    sb.Append("<td class='tg-031e'>Incen-<br>tive</td>");
                    sb.Append("<td class='tg-031e'>In for<br>Fat%</td>");
                    sb.Append("<td class='tg-031e'>In for <br>Snf%</td>");
                    sb.Append("<td class='tg-031e'>In for <br>TS%</td>");
                    sb.Append("<td class='tg-031e'>Less<br> Scheme</td>");
                    sb.Append("<td class='tg-031e'>Add<br> Bonus</td>");
                    sb.Append("<td class='tg-031e'>Description</td>");
                    sb.Append("<td class='tg-yw4l'>W.E.F.<br>Date</td>");
                    sb.Append("</tr>");

                    sb.Append("<tr>");
                    int count = 0;
                    foreach (DataRow row in DS.Tables[0].Rows)
                    {
                        count++;
                        sb.Append("<td class='tg-031e'> " + row["Category"].ToString());
                        sb.Append("</td>");
                        sb.Append("<td class='tg-031e'> " + row["TSL"].ToString());
                        sb.Append("</td>");
                        sb.Append("<td class='tg-031e'> " + row["TSH"].ToString());
                        sb.Append("</td>");
                        sb.Append("<td class='tg-031e'> " + row["TSRATE"].ToString());
                        sb.Append("</td>");
                        sb.Append("<td class='tg-031e'> " + row["TS_INCR"].ToString());
                        sb.Append("</td>");
                        sb.Append("<td class='tg-031e'> " + row["Incentive"].ToString());
                        sb.Append("</td>");
                        sb.Append("<td class='tg-031e'> " + row["IN_FAT"].ToString());
                        sb.Append("</td>");
                        sb.Append("<td class='tg-031e'> " + row["IN_SNF"].ToString());
                        sb.Append("</td>");
                        sb.Append("<td class='tg-031e'> " + row["IN_TS"].ToString());
                        sb.Append("</td>");
                        sb.Append("<td class='tg-031e'> " + row["Scheme"].ToString());
                        sb.Append("</td>");
                        sb.Append("<td class='tg-031e'> " + row["Bonus"].ToString());
                        sb.Append("</td>");
                        sb.Append("<td class='tg-031e'>" + row["Description"].ToString());
                        sb.Append("</td>");
                        sb.Append("<td class='tg-yw4l'>" + Convert.ToDateTime(row["WEF_DATE"]).ToString("dd-MM-yyyy"));
                        sb.Append("</td>");
                        sb.Append("</tr>");
                    }
                    sb.Append("</table></div>");

                    result = sb.ToString();
                    genratedBIll.Text = result;

                    Session["ctrl"] = pnlBill;
                }
                else
                {
                    result = "Statement not found";
                    genratedBIll.Text = result;

                }
            }
            else if (dpTariff.SelectedIndex == 3)
            {
                string result = string.Empty;

                DS = bhardcopytariff.GetHardCopyTariff((Convert.ToInt32(dpTariff.SelectedItem.Value)));
                if (!Comman.Comman.IsDataSetEmpty(DS))
                {
                    StringBuilder sb = new StringBuilder();

                    sb.Append("<style type ='text/css'>");
                    sb.Append(".tg  { border-collapse:collapse; border-spacing:0;}");
                    sb.Append(".tg td{ font-family:Arial, sans-serif; font-size:14px; padding:10px 5px; border-style:solid; border-width:1px; overflow:hidden; word-break:normal;text-align:center;}");
                    sb.Append(".tg .tg-yw4Q{vertical-align:middle ; padding:5px; border-right-style:hidden; }");
                    sb.Append(".tg th{ font-family:Arial, sans-serif; font-size:14px; font-weight:normal; padding:10px 5px; border-style:solid; border-width:1px; overflow:hidden; word-break:normal;text-align:left;}");
                    sb.Append(".tg .tg-baqh{text-align:center;vertical-align:top}");
                    sb.Append("@media screen and(max-width:767px) {.tg { width:auto !important; }.tg col { width:auto !important;}.tg-wrap { overflow-x:auto; -webkit-overflow-scrolling:touch; } }");

                    sb.Append("</style>");
                    sb.Append("<div class='tg -wrap'><table class='tg'>");

                    sb.Append("<tr>");
                    sb.Append("<th class='tg-yw4Q'>");
                    sb.Append("<img src='/Theme/img/logo1.png' class='img-circle' alt='Logo' width='50px' height='50px'>");
                    sb.Append("<th class='tg-baqh' colspan='10'><b>Nanjil Milk Plant,   Mulagumoodu, K.K.Dt.</b><br><small><u>Raw Milk Purchase Incentive</u></small></th>");
                    sb.Append("</tr>");

                    sb.Append("<tr>");
                    sb.Append("<td colspan ='4' align='left' style='text-align:left; border-right-width:0px; '>");
                    //Tariff:" + dpTariff.SelectedItem.Text.ToString());
                    //sb.Append("<td colspan='2' align='center' style='border-right-width:0px; border-left-width:0px;'> All CCs </td>");
                    sb.Append("<td colspan='3'align='right' style='text-align:right; border-left-width:0px;'> Date: " + Convert.ToDateTime(txtDate.Text).ToString("dd-MM-yyyy"));
                    sb.Append("</tr>");

                    sb.Append("<tr>");
                    sb.Append("<td class='tg-031e' colspan='2'>Category</td>");
                    sb.Append("<td class='tg-031e' colspan='2'>Qty.Low</td>");
                    sb.Append("<td class='tg-031e'>Qty.High</td>");
                    sb.Append("<td class='tg-031e' >Qty.Incentive</td>");
                    sb.Append("<td class='tg-031e'>Description</td>");
                    sb.Append("</tr>");

                    sb.Append("<tr>");
                    int count = 0;
                    foreach (DataRow row in DS.Tables[0].Rows)
                    {
                        count++;
                        sb.Append("<td class='tg-031e' colspan='2'>" + row["QCat"].ToString());
                        sb.Append("</td>");
                        sb.Append("<td class='tg-031e' colspan='2'>" + row["QLow"].ToString());
                        sb.Append("</td>");
                        sb.Append("<td class='tg-031e'>" + row["QHigh"].ToString());
                        sb.Append("</td>");
                        sb.Append("<td class='tg-031e'>" + row["QIncentive"].ToString());
                        sb.Append("</td>");
                        sb.Append("<td class='tg-031e'>" + row["Description"].ToString());
                        sb.Append("</td>");
                        sb.Append("</tr>");
                    }
                    sb.Append("</table></div>");

                    result = sb.ToString();
                    genratedBIll.Text = result;

                    Session["ctrl"] = pnlBill;
                }
                else
                {
                    result = "Statement not found";
                    genratedBIll.Text = result;

                }
            }

        }
    }
}