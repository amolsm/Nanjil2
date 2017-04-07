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
    public partial class SalesmanwiseCartonReport : System.Web.UI.Page
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

        }



        protected void btngenrateBill_Click(object sender, EventArgs e)
        {
            string result = string.Empty;

            int flag = 3;
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
                sb.Append("<u>SalesmanWise Return Carton Report</u> <br/>");
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
                int outcarton1 = 0;
                int incarton1 = 0;
                int excesscarton1 = 0;
                int shortcarton1 = 0;
                int totaloutcarton1 = 0;
                int totalincarton1 = 0;
                int totalexcesscarton1 = 0;
                int totalshortcarton1 = 0;

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
                    int outcarton = 0;
                    int incarton = 0;
                    int excesscarton = 0;
                    int shortcarton = 0;
                    int totaloutcarton = 0;
                    int totalincarton = 0;
                    int totalexcesscarton = 0;
                    int totalshortcarton = 0;
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
                                outcarton = Convert.ToInt32(rows["CartonsDispached"]);
                            }
                            catch { outcarton = 0; }

                            sb.Append(outcarton.ToString());
                            totaloutcarton += outcarton;
                            sb.Append("</td>");

                            sb.Append("<td class='tg-yw4l' style='text-align:right'>");
                            try
                            {
                                incarton = Convert.ToInt32(rows["CartonsReturned"]);
                            }
                            catch { incarton = 0; }

                            sb.Append(incarton.ToString());
                            totalincarton += incarton;
                            sb.Append("</td>");

                            sb.Append("<td class='tg-yw4l' style='text-align:right'>");
                            try
                            {
                                excesscarton = incarton - outcarton;
                            }
                            catch { excesscarton = 0; }
                            if (excesscarton < 0)
                            { excesscarton = 0; }
                            sb.Append(excesscarton.ToString());
                            totalexcesscarton += excesscarton;
                            sb.Append("</td>");

                            sb.Append("<td class='tg-yw4l' style='text-align:right'>");
                            try
                            {
                                shortcarton = outcarton - incarton;
                            }
                            catch { shortcarton = 0; }
                            if (shortcarton < 0)
                            { shortcarton = 0; }
                            sb.Append(shortcarton.ToString());
                            totalshortcarton += shortcarton;
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
                        outcarton1 = Convert.ToInt32(row["CartonsDispached"]);
                    }
                    catch { outcarton1 = 0; }

                    sb.Append("<b>" + outcarton1.ToString() + "</b>");
                    totaloutcarton1 += outcarton1;
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l' style='text-align:right'>");
                    try
                    {
                        incarton1 = Convert.ToInt32(row["CartonsReturned"]);
                    }
                    catch { incarton1 = 0; }

                    sb.Append("<b>" + incarton1.ToString() + "</b>");
                    totalincarton1 += incarton1;
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l' style='text-align:right'>");
                    try
                    {
                        excesscarton1 = incarton1 - outcarton1;
                    }
                    catch { excesscarton1 = 0; }
                    if (excesscarton1 < 0)
                    { excesscarton1 = 0; }
                    sb.Append("<b>" + excesscarton1.ToString() + "</b>");
                    totalexcesscarton1 += excesscarton1;
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l' style='text-align:right'>");
                    try
                    {
                        shortcarton1 = outcarton1 - incarton1;
                    }
                    catch { shortcarton1 = 0; }
                    if (shortcarton1 < 0)
                    { shortcarton1 = 0; }
                    sb.Append("<b>" + shortcarton1.ToString() + "</b>");
                    totalshortcarton1 += shortcarton1;
                    sb.Append("</td>");

                    sb.Append("</tr>");


                }
                sb.Append("<tr style='border-bottom:1px solid'> <td colspan = '6'> &nbsp; </td> </tr>");
                sb.Append("<tr style='border-bottom:1px solid'>");



                sb.Append("<td class='tg-yw4l' colspan='2' style='text-align:left'>");
                sb.Append("<b>" + "Total&nbsp;&nbsp;" + count1.ToString() + "</b>");
                sb.Append("</td>");



                sb.Append("<td class='tg-yw4l'  style='text-align:right'>");
                sb.Append("<b>" + totaloutcarton1 + "</b>");
                sb.Append("</td>");



                sb.Append("<td class='tg-yw4l'   style='text-align:right'>");
                sb.Append("<b>" + totalincarton1 + "</b>");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l'  style='text-align:right'>");
                sb.Append("<b>" + totalexcesscarton1 + "</b>");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l'  style='text-align:right'>");
                sb.Append("<b>" + totalshortcarton1 + "</b>");
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