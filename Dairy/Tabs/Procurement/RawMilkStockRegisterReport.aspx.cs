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
    public partial class RawMilkStockRegisterReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblerror.Visible = false;
            btnPrint.Visible = false;
            if (!Page.IsPostBack)
                txtDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        protected void btngenrateBill_Click(object sender, EventArgs e)
        {
            try
            {
                //if (dpReport.SelectedIndex != 0)
                {
                    Model.MRawMilkStockRegisterReport p = new Model.MRawMilkStockRegisterReport();
                    BRawMilkStockRegisterReport pd = new BRawMilkStockRegisterReport();

                    p.Date = Convert.ToDateTime(txtDate.Text);
                    //p.Enddate = Convert.ToDateTime(txtEndDate.Text).ToString("dd-MM-yyyy");
                    //p.ReportType = dpReport.SelectedItem.Text;
                    DataSet DS = new DataSet();
                    DS = pd.RawMilkStockRegisterReport(p);
                    string result = string.Empty;
                    //if (dpReport.SelectedIndex == 1)
                    {
                        if (!Comman.Comman.IsDataSetEmpty(DS))
                        {
                            btnPrint.Visible = true;
                            StringBuilder sb = new StringBuilder();

                            sb.Append("<style type='text / css'>");
                            sb.Append(".tg  { border - collapse:collapse; border - spacing:0; border: none; } .dispnone {display:none;} ");
                            sb.Append("</style>");
                            sb.Append("<table class='tg style1' style='page-break-inside:avoid; align:center;'>");
                            sb.Append("<colgroup>");
                            sb.Append("<col style = 'width:90px'>");
                            sb.Append("<col style = 'width:90px'>");
                            sb.Append("<col style = 'width:90px'>");
                            sb.Append("<col style = 'width:90px'>");
                            sb.Append("<col style = 'width:90px'>");
                            sb.Append("<col style = 'width:90px'>");
                            sb.Append("<col style = 'width:90px'>");
                            sb.Append("<col style = 'width:90px'>");
                            sb.Append("<col style = 'width:90px'>");

                            sb.Append("</colgroup>");

                            sb.Append("<tr>");
                            sb.Append("<th class='tg-yw4l' rowspan='1'>");
                            sb.Append("<img src='/Theme/img/logo1.png' class='img-circle' alt='Logo' width='50px' hight='50px'>");
                            sb.Append("</th>");

                            sb.Append("<th class='tg-baqh' colspan='7' style='text-align:center'>");
                            sb.Append("<b>Nanjil Milk Collection Centre,  Mulagumoodu, K.K.Dt.</b>");

                            sb.Append("</th>");

                            sb.Append("<th class='tg-yw4l' colspan='2' style='text-align:right'>");

                            sb.Append("TIN:330761667331<br>");
                            sb.Append("</th>");
                            sb.Append("</tr>");

                            sb.Append("<tr style='border-bottom:1px solid'>");
                            sb.Append("<th class='tg-yw4l' rowspan='1'>");
                            sb.Append("</th>");
                            sb.Append("<td class='tg-yw4l' colspan='7' style='text-align:center'>");
                            sb.Append("<u>Raw Milk Stock Register Report</u> <br/>");
                            sb.Append("</td>");

                            sb.Append("<td class='tg-yw4l' colspan='2' style='text-align:right'>");
                            sb.Append("PH:248370,248605");
                            sb.Append("</td>");
                            //sb.Append("<td></td>");
                            //sb.Append("<td></td>");
                            sb.Append("</tr>");

                            sb.Append("<tr style='border-bottom:1px solid'>");
                            sb.Append(" <td colspan='3' style='text-align:left'>");
                            sb.Append("Date : " + DateTime.Now.ToString());
                            sb.Append("</td>");



                            sb.Append("<td colspan='7' style='text-align:right'>");
                            sb.Append(Convert.ToDateTime(txtDate.Text).ToString("dd-MM-yyyy"));
                            sb.Append("</td>");
                            sb.Append("</tr>");
                            //if (DS.Tables[2] != null)
                               if(DS.Tables[2].Rows.Count > 0)
                            {
                                sb.Append("<tr style='border-bottom:1px solid'>");
                                sb.Append("<td colspan='4' style='text-align:center;' ><b>Opening Stock :" + DS.Tables[1].Rows[0]["OpeningStock"].ToString() + "</b></td>");

                                sb.Append("<td></td>");
                                sb.Append("<td colspan='5' style='text-align:center;' ><b>Closing Stock :" + DS.Tables[1].Rows[0]["ClosingStock"].ToString() + "</b></td>");
                                //sb.Append("<td ><b>"  "</b></td>");
                                sb.Append("</tr>");
                            }

                            sb.Append("<tr style='border-bottom:1px solid'> <td colspan = '10'> &nbsp; </td> </tr>");

                            /////////////////////////////////
                            if (DS.Tables[0].Rows.Count !=  null)
                            {
                                sb.Append("<tr style='border-bottom:1px solid'>");


                                sb.Append("<td colspan='10' align='center'>");
                                sb.Append("<b>Collection</b>");
                                sb.Append("</td>");


                                sb.Append("</tr>");



                                sb.Append("<tr style='border-bottom:1px solid'>");
                                sb.Append("<td colspan='3' style='text-align:left'>");
                                sb.Append("<b>RouteID</b>");
                                sb.Append("</td>");
                                sb.Append("<td colspan='3' style='text-align:center'>");
                                sb.Append("<b>Morning Collection Qty</b>");
                                sb.Append("</td>");
                                sb.Append("<td colspan='4' style='text-align:center'>");
                                sb.Append("<b>Evening Collection Qty</b>");
                                sb.Append("</td>");
                                sb.Append("</tr>");
                                sb.Append("<tr>");

                                int count = 0;
                                double morning = 0.00;
                                double Totmornig = 0.00;
                                double evening = 0.00;
                                double Totevening = 0.00;
                                foreach (DataRow row in DS.Tables[0].Rows)
                                {
                                    count++;

                                    sb.Append("<td colspan='3' style = 'text-align:left'>");
                                    sb.Append(row["Routes"].ToString());
                                    sb.Append("</td>");
                                    sb.Append("<td colspan='3' style = 'text-align:center'>");
                                    try { morning = Convert.ToDouble(row["Morning"]); }
                                    catch { morning = 0.00; }
                                    Totmornig += morning;
                                    sb.Append(morning);
                                    sb.Append("</td>");
                                    sb.Append("<td colspan='4' style = 'text-align:center'>");
                                    try { evening = Convert.ToDouble(row["Evening"]); }
                                    catch { evening = 0.00; }
                                    Totevening += evening;
                                    sb.Append(evening);
                                    sb.Append("</td>");
                                    sb.Append("</tr>");
                                }
                                sb.Append("<tr style='border-bottom:1px solid'><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td></tr>");

                                sb.Append("<tr style='border-bottom:1px solid'>");
                                sb.Append("<td colspan='3' style = 'text-align:left; width:170px'>");
                                sb.Append("<b>Total :</b>");
                                sb.Append("<b>" + count + "</b>");
                                sb.Append("</td>");
                                sb.Append("<td colspan='3' style = 'text-align:center; width:200px'>");
                                sb.Append("<b>" + Totmornig + "</b>");
                                sb.Append("</td>");
                                sb.Append("<td colspan='4' style = 'text-align:center; width:200px'>");
                                sb.Append("<b>" + Totevening + "</b>");
                                sb.Append("</td>");
                                sb.Append("</tr>");
                                sb.Append("<tr style='border-bottom:1px solid'> <td colspan = '10'> &nbsp; </td> </tr>");

                                sb.Append("<style type='text / css'>");
                                sb.Append(".tg  { border - collapse:collapse; border - spacing:0; border: none; } .dispnone {display:none;} ");
                                sb.Append("</style>");
                                sb.Append("<table class='tg style1' style='page-break-inside:avoid; align:center;'>");
                                sb.Append("<colgroup>");
                                sb.Append("<col style = 'width:90px'>");
                                sb.Append("<col style = 'width:90px'>");
                                sb.Append("<col style = 'width:90px'>");
                                sb.Append("<col style = 'width:90px'>");
                                sb.Append("<col style = 'width:90px'>");
                                sb.Append("<col style = 'width:90px'>");
                                sb.Append("<col style = 'width:90px'>");
                                sb.Append("<col style = 'width:90px'>");
                                sb.Append("<col style = 'width:90px'>");

                                sb.Append("</colgroup>");

                                sb.Append("<tr>");

                                sb.Append("</tr>");
                            }

                            if (DS.Tables[1].Rows.Count != null)
                            {
                                sb.Append("<tr style='border-bottom:1px solid'>");


                                sb.Append("<td colspan='10' style='text-align:center'>");
                                sb.Append("<b>Received Particulars</b>");
                                sb.Append("</td>");


                                sb.Append("</tr>");

                                sb.Append("<tr style='border-bottom:1px solid'>");
                                sb.Append("<td style='text-align:left' colspan='2'><b>Particular</b></td>");
                                sb.Append("<td style='text-align:center'><b>Milk In(Ltr)</b></td>");
                                sb.Append("<td style='text-align:center'><b>Time</b></td>");
                                sb.Append("<td style='text-align:center'><b>VehicalNo</b></td>");
                                sb.Append("<td style='text-align:center'><b>BatchNo</b></td>");
                                sb.Append("<td style='text-align:center'><b>Temp</b></td>");
                                sb.Append("<td style='text-align:center'><b>Acidity</b></td>");
                                sb.Append("<td style='text-align:center'><b>FAT%</b></td>");
                                sb.Append("<td style='text-align:center'><b>SNF%</b></td>");
                                sb.Append("</tr>");
                                sb.Append("<tr>");


                                double milkltr = 0.00;
                                double totmilkltr = 0.00;
                                int count = 0;

                                foreach (DataRow row in DS.Tables[1].Rows)
                                {
                                    count++;

                                    sb.Append("<td style = 'text-align:left' colspan='2'>");
                                    sb.Append(row["Particular"].ToString());
                                    sb.Append("</td>");
                                    sb.Append("<td style = 'text-align:center'>");
                                    try { milkltr = Convert.ToDouble(row["MilkInLtr"]); }
                                    catch { milkltr = 0.00; }
                                    totmilkltr += milkltr;
                                    sb.Append(milkltr);
                                    sb.Append("</td>");
                                    sb.Append("<td style = 'text-align:center'>");
                                    sb.Append(row["Session"].ToString());
                                    sb.Append("</td>");
                                    sb.Append("<td style = 'text-align:center'>");
                                    sb.Append(row["VehicalNo"].ToString());
                                    sb.Append("</td>");
                                    sb.Append("<td style = 'text-align:center'>");
                                    sb.Append(row["BatchNo"].ToString());
                                    sb.Append("</td>");
                                    sb.Append("<td style = 'text-align:center'>");
                                    sb.Append(row["Temp"].ToString());
                                    sb.Append("</td>");
                                    sb.Append("<td style = 'text-align:center'>");
                                    sb.Append(row["Acidity"].ToString());
                                    sb.Append("</td>");
                                    sb.Append("<td style = 'text-align:center'>");
                                    sb.Append(row["FATPercentage"].ToString());
                                    sb.Append("</td>");
                                    sb.Append("<td style = 'text-align:center'>");
                                    sb.Append(row["SNFPercentage"].ToString());
                                    sb.Append("</td>");
                                    sb.Append("</tr>");
                                }
                                sb.Append("<tr style='border-bottom:1px solid'><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td></tr>");
                                sb.Append("<tr style='border-bottom:1px solid'>");
                                sb.Append("<td style='text-align:left;' colspan='2'>");
                                sb.Append("<b>Total :</b>");
                                sb.Append("<b>" + count + "</b>");
                                sb.Append("</td>");

                                sb.Append("<td style='text-align:center;'><b>" + totmilkltr + "</b></td>");
                                sb.Append("<td colspan='7'></td>");

                                sb.Append("</tr>");
                                sb.Append("<tr style='border-bottom:1px solid'> <td colspan = '10'> &nbsp; </td> </tr>");

                                sb.Append("<style type='text / css'>");
                                sb.Append(".tg  { border - collapse:collapse; border - spacing:0; border: none; } .dispnone {display:none;} ");
                                sb.Append("</style>");
                                sb.Append("<table class='tg style1' style='page-break-inside:avoid; align:center;'>");
                                sb.Append("<colgroup>");
                                sb.Append("<col style = 'width:90px'>");
                                sb.Append("<col style = 'width:90px'>");
                                sb.Append("<col style = 'width:90px'>");
                                sb.Append("<col style = 'width:90px'>");
                                sb.Append("<col style = 'width:90px'>");
                                sb.Append("<col style = 'width:90px'>");
                                sb.Append("<col style = 'width:90px'>");
                                sb.Append("<col style = 'width:90px'>");
                                sb.Append("<col style = 'width:90px'>");

                                sb.Append("</colgroup>");

                                sb.Append("<tr>");


                                sb.Append("<th class='tg-yw4l' style='text-align:right'>");


                                sb.Append("</th>");
                                sb.Append("</tr>");
                            }
                            if (DS.Tables[2].Rows.Count != null)
                            {
                                sb.Append("<tr style='border-bottom:1px solid'>");


                                sb.Append("<td colspan='10' style='text-align:center'>");
                                sb.Append("<b>Disposed Particulars</b>");
                                sb.Append("</td>");


                                sb.Append("</tr>");
                                sb.Append("<tr style='border-bottom:1px solid'>");
                                sb.Append("<td style='text-align:left' colspan='2'><b>Particular</b></td>");
                                sb.Append("<td style='text-align:center'><b>Milk In(Ltr)</b></td>");
                                sb.Append("<td style='text-align:center'><b>Time</b></td>");
                                sb.Append("<td style='text-align:center'><b>VehicalNo</b></td>");
                                sb.Append("<td style='text-align:center'><b>BatchNo</b></td>");
                                sb.Append("<td style='text-align:center'><b>Temp</b></td>");
                                sb.Append("<td style='text-align:center'><b>Acidity</b></td>");
                                sb.Append("<td style='text-align:center'><b>FAT%</b></td>");
                                sb.Append("<td style='text-align:center'><b>SNF%</b></td>");
                                sb.Append("</tr>");
                                sb.Append("<tr>");

                                double milkltr1 = 0.00;
                                double totmilkltr1 = 0.00;
                                int count = 0;
                                foreach (DataRow row in DS.Tables[2].Rows)
                                {
                                    count++;

                                    sb.Append("<td style = 'text-align:left' colspan='2'>");
                                    sb.Append(row["Particular"].ToString());
                                    sb.Append("</td>");
                                    sb.Append("<td style = 'text-align:center'>");
                                    try { milkltr1 = Convert.ToDouble(row["MilkInLtr"]); }
                                    catch { milkltr1 = 0.00; }
                                    totmilkltr1 += milkltr1;
                                    sb.Append(milkltr1);
                                    sb.Append("</td>");
                                    sb.Append("<td style = 'text-align:center'>");
                                    sb.Append(row["Session"].ToString());
                                    sb.Append("</td>");
                                    sb.Append("<td style = 'text-align:center'>");
                                    sb.Append(row["VehicalNo"].ToString());
                                    sb.Append("</td>");
                                    sb.Append("<td style = 'text-align:center'>");
                                    sb.Append(row["BatchNo"].ToString());
                                    sb.Append("</td>");
                                    sb.Append("<td style = 'text-align:center'>");
                                    sb.Append(row["Temp"].ToString());
                                    sb.Append("</td>");
                                    sb.Append("<td style = 'text-align:center'>");
                                    sb.Append(row["Acidity"].ToString());
                                    sb.Append("</td>");
                                    sb.Append("<td style = 'text-align:center'>");
                                    sb.Append(row["FATPercentage"].ToString());
                                    sb.Append("</td>");
                                    sb.Append("<td style = 'text-align:center'>");
                                    sb.Append(row["SNFPercentage"].ToString());
                                    sb.Append("</td>");
                                    sb.Append("</tr>");
                                }
                                sb.Append("<tr style='border-bottom:1px solid'><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td></tr>");
                                sb.Append("<tr style='border-bottom:1px solid'>");
                                sb.Append("<td  colspan='2' style='text-align:left;'>");
                                sb.Append("<b>Total :</b>");
                                sb.Append("<b>" + count + "</b>");
                                sb.Append("</td>");
                                sb.Append("<td style ='text-align:center'><b>" + totmilkltr1 + "</b></td>");
                                sb.Append("<td></td>");
                                sb.Append("<td></td>");
                                sb.Append("<td></td>");
                                sb.Append("<td></td>");
                                sb.Append("<td></td>");
                                sb.Append("<td></td>");
                                sb.Append("<td></td>");
                                sb.Append("<td></td>");
                                sb.Append("<td></td>");
                                sb.Append("</tr>");
                            }

                            result = sb.ToString();
                            Payment.Text = result;

                            Session["ctrl"] = pnlPayment;

                        }
                        else
                        {
                            btnPrint.Visible = false;
                            result = "No Records Found";
                            Payment.Text = result;

                        }


                    }
                }
            }
            catch (Exception ex)
            {
                string result = string.Empty;
                string msg = ex.Message.ToString();
                result = "No Records Found";
                Payment.Text = result;
            }
        }
    }
}
