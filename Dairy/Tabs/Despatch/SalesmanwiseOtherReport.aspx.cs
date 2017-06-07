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
    public partial class SalesmanwiseOtherReport : System.Web.UI.Page
    {
        Dispatch dispatch = new Dispatch();
        DispatchData dispatchData = new DispatchData();
        DataSet DS = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DS = BindCommanData.BindCommanDropDwon("EmployeeID ", "EmployeeCode +' '+EmployeeName as Name  ", "EmployeeMaster", "IsActive=1 and (Designation='Sales Man' or Designation = 'Driver') ");
                //DS = BindCommanData.BindCommanDropDwon("EmployeeID", "EmployeeCode+' '+EmployeeName as Name", "employeemaster", "IsArchive=0 and (Designation='Sales Man')");
                if (!Comman.Comman.IsDataSetEmpty(DS))
                {
                    dpSalesMan.DataSource = DS;
                    dpSalesMan.DataBind();
                    dpSalesMan.Items.Insert(0, new ListItem("All SalesMan", "0"));


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

            int flag = 4;
            DS = dispatchData.GetSalesManWiseReturnedTraysReport((Convert.ToDateTime(txtStartDate.Text)).ToString("dd-MM-yyyy"), (Convert.ToDateTime(txtEndDate.Text)).ToString("dd-MM-yyyy"), Convert.ToInt32(dpSalesMan.SelectedItem.Value), flag);
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
                sb.Append("<col style = 'width:100px'>");



                sb.Append("</colgroup>");

                sb.Append("<tr>");
                sb.Append("<th class='tg-yw4l' rowspan='2'>");
                sb.Append("<img src='/Theme/img/logo1.png' class='img-circle' alt='Logo' width='50px' hight='50px'>");
                sb.Append("</th>");

                sb.Append("<th class='tg-baqh' colspan='4' style='text-align:center'>");
                sb.Append("<u>SalesmanWise Return Other Report</u> <br/>");
                sb.Append("</th>");

                sb.Append("<th class='tg-yw4l' style='text-align:right'>");

                sb.Append("TIN:330761667331<br>");
                sb.Append("</th>");
                sb.Append("</tr>");

                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append("<td class='tg-yw4l' colspan='4' style='text-align:center'>");
                sb.Append("<b>Nanjil Integrated Dairy Development, Mulagumoodu, K.K.Dt.</b>");

                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l' style='text-align:right'>");

                sb.Append("PH:248370,248605");

                sb.Append("</td>");

                sb.Append("<tr>");
                sb.Append("<td class='tg-yw4l' colspan='3' style='text-align:left'>");
                sb.Append("Start Date:" + Convert.ToDateTime(txtStartDate.Text).ToString("dd-MM-yyyy"));
                sb.Append("</td>");
                sb.Append("<td class='tg-yw4l' colspan='3' style='text-align:right'>");
                sb.Append("End Date:" + Convert.ToDateTime(txtEndDate.Text).ToString("dd-MM-yyyy"));
                sb.Append("</td>");
                sb.Append("<tr style='border-bottom:2px solid'>");
                sb.Append("<td class='tg-yw4l' colspan='3' style='text-align:left'>");

                if (Convert.ToInt32(dpSalesMan.SelectedItem.Value) == 0)
                {
                    sb.Append("Salesman : " + "All");
                }
                else
                {
                    sb.Append("Salesman : " + dpSalesMan.SelectedItem.Text.ToString());
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


                sb.Append("<td class='tg-yw4l'  style='text-align:left'>");
                sb.Append("<b>Route</b>");
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
                int outother1 = 0;
                int inother1 = 0;
                int excessother1 = 0;
                int shortother1 = 0;
                int totaloutother1 = 0;
                int totalinother1 = 0;
                int totalexcessother1 = 0;
                int totalshortother1 = 0;

                foreach (DataRow row in DS.Tables[0].Rows)
                {
                    count1++;
                    sb.Append("<tr style='border-bottom:1px solid'> <td colspan = '6'> &nbsp; </td> </tr>");
                    sb.Append("<tr style='border-bottom:1px solid'>");


                    sb.Append("<td class='tg-yw4l' colspan='6'  style='text-align:left'>");
                    sb.Append("<b>" + row["EmployeeCode"] + "</b>");
                    sb.Append("&nbsp;&nbsp;");
                    sb.Append("<b>" + row["EmployeeName"] + "</b>");
                    sb.Append("</td>");
                    int count = 0;
                    int outother = 0;
                    int inother = 0;
                    int excessother = 0;
                    int shortother = 0;
                    int totaloutother = 0;
                    int totalinother = 0;
                    int totalexcessother = 0;
                    int totalshortother = 0;
                    foreach (DataRow rows in DS.Tables[1].Rows)
                    {
                        if (row["EmployeeCode"].ToString() == rows["EmployeeCode"].ToString())
                        {
                            count++;
                            sb.Append("<tr>");


                            sb.Append("<td class='tg-yw4l'   style='text-align:left'>");
                            sb.Append(rows["DispatchDate"].ToString());
                            sb.Append("</td>");

                            sb.Append("<td class='tg-yw4l'  style='text-align:left'>");
                            sb.Append(rows["RouteCode"].ToString());
                            sb.Append("&nbsp;&nbsp;");
                            sb.Append(rows["RouteName"].ToString());
                            sb.Append("</td>");


                            sb.Append("<td class='tg-yw4l' style='text-align:right'>");
                            try
                            {
                                outother = Convert.ToInt32(rows["OtherDispached"]);
                            }
                            catch { outother = 0; }

                            sb.Append(outother.ToString());
                            totaloutother += outother;
                            sb.Append("</td>");

                            sb.Append("<td class='tg-yw4l' style='text-align:right'>");
                            try
                            {
                                inother = Convert.ToInt32(rows["OtherReturned"]);
                            }
                            catch { inother = 0; }

                            sb.Append(inother.ToString());
                            totalinother += inother;
                            sb.Append("</td>");

                            sb.Append("<td class='tg-yw4l' style='text-align:right'>");
                            try
                            {
                                excessother = inother - outother;
                            }
                            catch { excessother = 0; }
                            if (excessother < 0)
                            { excessother = 0; }
                            sb.Append(excessother.ToString());
                            totalexcessother += excessother;
                            sb.Append("</td>");

                            sb.Append("<td class='tg-yw4l' style='text-align:right'>");
                            try
                            {
                                shortother = outother - inother;
                            }
                            catch { shortother = 0; }
                            if (shortother < 0)
                            { shortother = 0; }
                            sb.Append(shortother.ToString());
                            totalshortother += shortother;
                            sb.Append("</td>");

                            sb.Append("</tr>");

                        }
                    }
                    sb.Append("<tr style='border-bottom:1px solid'> <td colspan = '6'> &nbsp; </td> </tr>");
                    sb.Append("<tr style='border-bottom:1px solid'>");
                    sb.Append("<td class='tg-yw4l' colspan='2' style='text-align:left'>");
                    sb.Append("<b>" + "SubTotal&nbsp;&nbsp;" + count1.ToString() + "</b>");
                    sb.Append("</td>");
                    sb.Append("<td class='tg-yw4l' style='text-align:right'>");
                    try
                    {
                        outother1 = Convert.ToInt32(row["OtherDispached"]);
                    }
                    catch { outother1 = 0; }

                    sb.Append("<b>" + outother1.ToString() + "</b>");
                    totaloutother1 += outother1;
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l' style='text-align:right'>");
                    try
                    {
                        inother1 = Convert.ToInt32(row["OtherReturned"]);
                    }
                    catch { inother1 = 0; }

                    sb.Append("<b>" + inother1.ToString() + "</b>");
                    totalinother1 += inother1;
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l' style='text-align:right'>");
                    try
                    {
                        excessother1 = inother1 - outother1;
                    }
                    catch { excessother1 = 0; }
                    if (excessother1 < 0)
                    { excessother1 = 0; }
                    sb.Append("<b>" + excessother1.ToString() + "</b>");
                    totalexcessother1 += excessother1;
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l' style='text-align:right'>");
                    try
                    {
                        shortother1 = outother1 - inother1;
                    }
                    catch { shortother1 = 0; }
                    if (shortother1 < 0)
                    { shortother1 = 0; }
                    sb.Append("<b>" + shortother1.ToString() + "</b>");
                    totalshortother1 += shortother1;
                    sb.Append("</td>");

                    sb.Append("</tr>");


                }
                sb.Append("<tr style='border-bottom:1px solid'> <td colspan = '6'> &nbsp; </td> </tr>");
                sb.Append("<tr style='border-bottom:1px solid'>");



                sb.Append("<td class='tg-yw4l' colspan='2' style='text-align:left'>");
                sb.Append("<b>" + "Total&nbsp;&nbsp;" + count1.ToString() + "</b>");
                sb.Append("</td>");



                sb.Append("<td class='tg-yw4l'  style='text-align:right'>");
                sb.Append("<b>" + totaloutother1 + "</b>");
                sb.Append("</td>");



                sb.Append("<td class='tg-yw4l'   style='text-align:right'>");
                sb.Append("<b>" + totalinother1 + "</b>");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l'  style='text-align:right'>");
                sb.Append("<b>" + totalexcessother1 + "</b>");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l'  style='text-align:right'>");
                sb.Append("<b>" + totalshortother1 + "</b>");
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