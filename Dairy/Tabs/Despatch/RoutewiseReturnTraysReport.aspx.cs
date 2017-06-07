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
using System.Web.Security;

namespace Dairy.Tabs.Despatch
{
    public partial class RoutewiseReturnTraysReport : System.Web.UI.Page
    {
        Dispatch dispatch = new Dispatch();
        DispatchData dispatchData = new DispatchData();
        DataSet DS = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtStartDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                txtEndDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));

                DS = BindCommanData.BindCommanDropDwon("RouteID ", "RouteCode +' '+RouteName as Name  ", "routeMaster", "IsArchive=1");
                if (!Comman.Comman.IsDataSetEmpty(DS))
                {
                    dpRoute.DataSource = DS;
                    dpRoute.DataBind();
                    dpRoute.Items.Insert(0, new ListItem("--All Route  --", "0"));
                }

            }
            if (Context.Session != null && Context.Session.IsNewSession == true &&
    Page.Request.Headers["Cookie"] != null &&
    Page.Request.Headers["Cookie"].IndexOf("ASP.NET_SessionId") >= 0)
            {
                // session has timed out, log out the user
                if (Page.Request.IsAuthenticated)
                {
                    FormsAuthentication.SignOut();
                }
                // redirect to timeout page
                Page.Response.Redirect("/Authentication/LoginT.aspx");
            }
        }
        protected void btngenrateBill_Click(object sender, EventArgs e)
        {
            string result = string.Empty;

            int flag = 1;
            DS = dispatchData.GetRoutewiseReturnTraysReport((Convert.ToDateTime(txtStartDate.Text)).ToString("dd-MM-yyyy"), (Convert.ToDateTime(txtEndDate.Text)).ToString("dd-MM-yyyy"), Convert.ToInt32(dpRoute.SelectedItem.Value),flag);
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
                sb.Append("<u>RouteWise Return Trays Report</u> <br/>");
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
                int outtrays1 = 0;
                int intrays1 = 0;
                int excesstrays1 = 0;
                int shorttrays1 = 0;
                int totalouttrays1 = 0;
                int totalintrays1 = 0;
                int totalexcesstrays1 = 0;
                int totalshorttrays1 = 0;

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
                    int outtrays = 0;
                    int intrays = 0;
                    int excesstrays = 0;
                    int shorttrays = 0;
                    int totalouttrays = 0;
                    int totalintrays = 0;
                    int totalexcesstrays = 0;
                    int totalshorttrays = 0;
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
                                outtrays = Convert.ToInt32(rows["TraysDispached"]);
                            }
                            catch { outtrays = 0; }

                            sb.Append(outtrays.ToString());
                            totalouttrays += outtrays;
                            sb.Append("</td>");

                            sb.Append("<td class='tg-yw4l' style='text-align:right'>");
                            try
                            {
                                intrays = Convert.ToInt32(rows["TraysReturned"]);
                            }
                            catch { intrays = 0; }

                            sb.Append(intrays.ToString());
                            totalintrays += intrays;
                            sb.Append("</td>");

                            sb.Append("<td class='tg-yw4l' style='text-align:right'>");
                            try
                            {
                                excesstrays = intrays - outtrays;
                            }
                            catch { excesstrays = 0; }
                            if (excesstrays < 0)
                            { excesstrays = 0; }
                            sb.Append(excesstrays.ToString());
                            totalexcesstrays += excesstrays;
                            sb.Append("</td>");

                            sb.Append("<td class='tg-yw4l' style='text-align:right'>");
                            try
                            {
                                shorttrays = outtrays - intrays;
                            }
                            catch { shorttrays = 0; }
                            if (shorttrays < 0)
                            { shorttrays = 0; }
                            sb.Append(shorttrays.ToString());
                            totalshorttrays += shorttrays;
                            sb.Append("</td>");

                            sb.Append("</tr>");

                        }
                    }
                    sb.Append("<tr style='border-bottom:1px solid'> <td colspan = '5'> &nbsp; </td> </tr>");
                    sb.Append("<tr style='border-bottom:1px solid'>");
                    sb.Append("<td class='tg-yw4l' style='text-align:left'>");
                    sb.Append("<b>"+"SubTotal&nbsp;&nbsp;"+count1.ToString()+"</b>");
                    sb.Append("</td>");
                    sb.Append("<td class='tg-yw4l' style='text-align:right'>");
                    try
                    {
                        outtrays1 = Convert.ToInt32(row["TraysDispached"]);
                    }
                    catch { outtrays1 = 0; }

                    sb.Append("<b>"+outtrays1.ToString()+"</b>");
                    totalouttrays1 += outtrays1;
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l' style='text-align:right'>");
                    try
                    {
                        intrays1 = Convert.ToInt32(row["TraysReturned"]);
                    }
                    catch { intrays1 = 0; }

                    sb.Append("<b>"+intrays1.ToString()+ "</b>");
                    totalintrays1 += intrays1;
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l' style='text-align:right'>");
                    try
                    {
                        excesstrays1 = intrays1 - outtrays1;
                    }
                    catch { excesstrays1 = 0; }
                    if (excesstrays1 < 0)
                    { excesstrays1 = 0; }
                    sb.Append("<b>"+excesstrays1.ToString()+ "</b>");
                    totalexcesstrays1 += excesstrays1;
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l' style='text-align:right'>");
                    try
                    {
                        shorttrays1 = outtrays1 - intrays1;
                    }
                    catch { shorttrays1 = 0; }
                    if (shorttrays1 < 0)
                    { shorttrays1 = 0; }
                    sb.Append("<b>"+shorttrays1.ToString()+ "</b>");
                    totalshorttrays1 += shorttrays1;
                    sb.Append("</td>");

                    sb.Append("</tr>");


                }
                sb.Append("<tr style='border-bottom:1px solid'> <td colspan = '5'> &nbsp; </td> </tr>");
                sb.Append("<tr style='border-bottom:1px solid'>");

              

                sb.Append("<td class='tg-yw4l'  style='text-align:left'>");
                sb.Append("<b>" + "Total&nbsp;&nbsp;" + count1.ToString() + "</b>");
                sb.Append("</td>");

          

                sb.Append("<td class='tg-yw4l'  style='text-align:right'>");
                sb.Append("<b>"+totalouttrays1+"</b>");
                sb.Append("</td>");



                sb.Append("<td class='tg-yw4l'   style='text-align:right'>");
                sb.Append("<b>"+totalintrays1+"</b>");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l'  style='text-align:right'>");
                sb.Append("<b>"+totalexcesstrays1+"</b>");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l'  style='text-align:right'>");
                sb.Append("<b>"+totalshorttrays1+"</b>");
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