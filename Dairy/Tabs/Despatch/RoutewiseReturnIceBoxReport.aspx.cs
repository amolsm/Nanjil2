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

namespace Dairy.Tabs.Despatch
{
    public partial class RoutewiseReturnIceBoxReport : System.Web.UI.Page
    {
        Dispatch dispatch = new Dispatch();
        DispatchData dispatchData = new DispatchData();
        DataSet DS = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DS = BindCommanData.BindCommanDropDwon("RouteID ", "RouteCode +' '+RouteName as Name  ", "routeMaster", "IsArchive=1");
                if (!Comman.Comman.IsDataSetEmpty(DS))
                {
                    dpRoute.DataSource = DS;
                    dpRoute.DataBind();
                    dpRoute.Items.Insert(0, new ListItem("--All Route  --", "0"));
                }

            }
        }
        protected void btngenrateBill_Click(object sender, EventArgs e)
        {
            string result = string.Empty;

            int flag = 2;
            DS = dispatchData.GetRoutewiseReturnTraysReport((Convert.ToDateTime(txtStartDate.Text)).ToString("dd-MM-yyyy"), (Convert.ToDateTime(txtEndDate.Text)).ToString("dd-MM-yyyy"), Convert.ToInt32(dpRoute.SelectedItem.Value), flag);
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
                sb.Append("<col style = 'width:200px'>");
                sb.Append("<col style = 'width:200px'>");
                sb.Append("<col style = 'width:100px'>");
                sb.Append("<col style = 'width:100px'>");



                sb.Append("</colgroup>");

                sb.Append("<tr>");
                sb.Append("<th class='tg-yw4l' rowspan='2'>");
                sb.Append("<img src='/Theme/img/logo1.png' class='img-circle' alt='Logo' width='50px' hight='50px'>");
                sb.Append("</th>");

                sb.Append("<th class='tg-baqh' colspan='3' style='text-align:center'>");
                sb.Append("<u>RouteWise Return IceBox Report</u> <br/>");
                sb.Append("</th>");

                sb.Append("<th class='tg-yw4l' style='text-align:right'>");

                sb.Append("TIN:330761667331<br>");
                sb.Append("</th>");
                sb.Append("</tr>");

                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append("<td class='tg-yw4l' colspan='3' style='text-align:center'>");
                sb.Append("<b>Nanjil Integrated Dairy Development, Mulagumoodu, K.K.Dt.</b>");

                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l' style='text-align:right'>");

                sb.Append("PH:248370,248605");

                sb.Append("</td>");

                sb.Append("<tr>");
                sb.Append("<td class='tg-yw4l' colspan='2' style='text-align:left'>");
                sb.Append("Start Date:" + Convert.ToDateTime(txtStartDate.Text).ToString("dd-MM-yyyy"));
                sb.Append("</td>");
                sb.Append("<td class='tg-yw4l' colspan='3' style='text-align:right'>");
                sb.Append("End Date:" + Convert.ToDateTime(txtEndDate.Text).ToString("dd-MM-yyyy"));
                sb.Append("</td>");
                sb.Append("<tr style='border-bottom:2px solid'>");
                sb.Append("<td class='tg-yw4l' colspan='2' style='text-align:left'>");

                if (Convert.ToInt32(dpRoute.SelectedItem.Value) == 0)
                {
                    sb.Append("Route : " + "All");
                }
                else
                {
                    sb.Append("Route : " + dpRoute.SelectedItem.Text.ToString());
                }
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l' colspan='3'  style='text-align:right'>");
                sb.Append("Date : " + DateTime.Now.ToString("dd-MM-yyyy"));
                sb.Append("</td>");
                sb.Append("</tr>");
                sb.Append("<tr style='border-bottom:1px solid'>");


                sb.Append("<td class='tg-yw4l'  style='text-align:left'>");
                sb.Append("<b>Dispatch Date </b>");
                sb.Append("</td>");





                sb.Append("<td class='tg-yw4l'  style='text-align:right'>");
                sb.Append("<b>Out</b>");
                sb.Append("</td>");



                sb.Append("<td class='tg-yw4l'   style='text-align:right'>");
                sb.Append("<b>In</b>");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l'  style='text-align:right'>");
                sb.Append("<b>Excess</b>");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l'  style='text-align:right'>");
                sb.Append("<b>Short</b>");
                sb.Append("</td>");

                sb.Append("</tr>");
                int count1 = 0;
                int outIcebox1 = 0;
                int inIcebox1 = 0;
                int excessIcebox1 = 0;
                int shortIcebox1 = 0;
                int totaloutIcebox1 = 0;
                int totalinIcebox1 = 0;
                int totalexcessIcebox1 = 0;
                int totalshortIcebox1 = 0;

                foreach (DataRow row in DS.Tables[0].Rows)
                {
                    count1++;
                    sb.Append("<tr style='border-bottom:1px solid'> <td colspan = '5'> &nbsp; </td> </tr>");
                    sb.Append("<tr style='border-bottom:1px solid'>");


                    sb.Append("<td class='tg-yw4l' colspan='5'  style='text-align:left'>");
                    sb.Append("<b>" + row["RouteCode"] + "</b>");
                    sb.Append("&nbsp;&nbsp;");
                    sb.Append("<b>" + row["RouteName"] + "</b>");
                    sb.Append("</td>");
                    int count = 0;
                    int outIceBox = 0;
                    int inIceBox = 0;
                    int excessIcebox = 0;
                    int shortIcebox = 0;
                    int totaloutIceBox = 0;
                    int totalinIceBox = 0;
                    int totalexcessIcebox = 0;
                    int totalshortIcebox = 0;
                    foreach (DataRow rows in DS.Tables[1].Rows)
                    {
                        if (row["RouteCode"].ToString() == rows["RouteCode"].ToString())
                        {
                            count++;
                            sb.Append("<tr>");


                            sb.Append("<td class='tg-yw4l'   style='text-align:left'>");
                            sb.Append(rows["DispatchDate"].ToString());
                            sb.Append("</td>");




                            sb.Append("<td class='tg-yw4l' style='text-align:right'>");
                            try
                            {
                                outIceBox = Convert.ToInt32(rows["IceBoxDispached"]);
                            }
                            catch { outIceBox = 0; }

                            sb.Append(outIceBox.ToString());
                            totaloutIceBox += outIceBox;
                            sb.Append("</td>");

                            sb.Append("<td class='tg-yw4l' style='text-align:right'>");
                            try
                            {
                                inIceBox = Convert.ToInt32(rows["IceBoxReturned"]);
                            }
                            catch { inIceBox = 0; }

                            sb.Append(inIceBox.ToString());
                            totalinIceBox += inIceBox;
                            sb.Append("</td>");

                            sb.Append("<td class='tg-yw4l' style='text-align:right'>");
                            try
                            {
                                excessIcebox = inIceBox - outIceBox;
                            }
                            catch { excessIcebox = 0; }
                            if (excessIcebox < 0)
                            { excessIcebox = 0; }
                            sb.Append(excessIcebox.ToString());
                            totalexcessIcebox += excessIcebox;
                            sb.Append("</td>");

                            sb.Append("<td class='tg-yw4l' style='text-align:right'>");
                            try
                            {
                                shortIcebox = outIceBox - inIceBox;
                            }
                            catch { shortIcebox = 0; }
                            if (shortIcebox < 0)
                            { shortIcebox = 0; }
                            sb.Append(shortIcebox.ToString());
                            totalshortIcebox += shortIcebox;
                            sb.Append("</td>");

                            sb.Append("</tr>");

                        }
                    }
                    sb.Append("<tr style='border-bottom:1px solid'> <td colspan = '5'> &nbsp; </td> </tr>");
                    sb.Append("<tr style='border-bottom:1px solid'>");
                    sb.Append("<td class='tg-yw4l' style='text-align:left'>");
                    sb.Append("<b>" + "SubTotal&nbsp;&nbsp;" + count1.ToString() + "</b>");
                    sb.Append("</td>");
                    sb.Append("<td class='tg-yw4l' style='text-align:right'>");
                    try
                    {
                        outIcebox1 = Convert.ToInt32(row["IceBoxDispached"]);
                    }
                    catch { outIcebox1 = 0; }

                    sb.Append("<b>" + outIcebox1.ToString() + "</b>");
                    totaloutIcebox1 += outIcebox1;
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l' style='text-align:right'>");
                    try
                    {
                        inIcebox1 = Convert.ToInt32(row["IceBoxReturned"]);
                    }
                    catch { inIcebox1 = 0; }

                    sb.Append("<b>" + inIcebox1.ToString() + "</b>");
                    totalinIcebox1 += inIcebox1;
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l' style='text-align:right'>");
                    try
                    {
                        excessIcebox1 = inIcebox1 - outIcebox1;
                    }
                    catch { excessIcebox1 = 0; }
                    if (excessIcebox1 < 0)
                    { excessIcebox1 = 0; }
                    sb.Append("<b>" + excessIcebox1.ToString() + "</b>");
                    totalexcessIcebox1 += excessIcebox1;
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l' style='text-align:right'>");
                    try
                    {
                        shortIcebox1 = outIcebox1 - inIcebox1;
                    }
                    catch { shortIcebox1 = 0; }
                    if (shortIcebox1 < 0)
                    { shortIcebox1 = 0; }
                    sb.Append("<b>" + shortIcebox1.ToString() + "</b>");
                    totalshortIcebox1 += shortIcebox1;
                    sb.Append("</td>");

                    sb.Append("</tr>");


                }
                sb.Append("<tr style='border-bottom:1px solid'> <td colspan = '5'> &nbsp; </td> </tr>");
                sb.Append("<tr style='border-bottom:1px solid'>");



                sb.Append("<td class='tg-yw4l'  style='text-align:left'>");
                sb.Append("<b>" + "Total&nbsp;&nbsp;" + count1.ToString() + "</b>");
                sb.Append("</td>");



                sb.Append("<td class='tg-yw4l'  style='text-align:right'>");
                sb.Append("<b>" + totaloutIcebox1 + "</b>");
                sb.Append("</td>");



                sb.Append("<td class='tg-yw4l'   style='text-align:right'>");
                sb.Append("<b>" + totalinIcebox1 + "</b>");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l'  style='text-align:right'>");
                sb.Append("<b>" + totalexcessIcebox1 + "</b>");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l'  style='text-align:right'>");
                sb.Append("<b>" + totalshortIcebox1 + "</b>");
                sb.Append("</td>");

                sb.Append("</tr>");

                result = sb.ToString();
                genratedBIll.Text = result;
                Session["ctrl"] = pnlBill;
            }

            else
            {
                result = "Report Not Found";
                genratedBIll.Text = result;

            }
        }
    }
}