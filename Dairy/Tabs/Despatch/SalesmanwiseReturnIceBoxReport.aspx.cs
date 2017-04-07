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
    public partial class SalesmanwiseReturnIceBoxReport : System.Web.UI.Page
    {
        Dispatch dispatch = new Dispatch();
        DispatchData dispatchData = new DispatchData();
        DataSet DS = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DS = BindCommanData.BindCommanDropDwon("EmployeeID", "EmployeeCode +' '+EmployeeName as Name  ", "EmployeeMaster", "IsActive=1 and (Designation='Sales Man' or Designation = 'Driver') ");
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

            int flag = 2;
            DS = dispatchData.GetSalesManWiseReturnedTraysReport((Convert.ToDateTime(txtStartDate.Text)).ToString("dd-MM-yyyy"), (Convert.ToDateTime(txtEndDate.Text)).ToString("dd-MM-yyyy"), Convert.ToInt32(dpSalesMan.SelectedItem.Value),flag);
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
                sb.Append("<u>SalesmanWise Return IceBox Report</u> <br/>");
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
                int outIceBox1 = 0;
                int inIceBox1 = 0;
                int excessIceBox1 = 0;
                int shortIceBox1 = 0;
                int totaloutIceBox1 = 0;
                int totalinIceBox1 = 0;
                int totalexcessIceBox1 = 0;
                int totalshortIceBox1 = 0;

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
                    int outIceBox = 0;
                    int inIceBox = 0;
                    int excessIceBox = 0;
                    int shortIceBox = 0;
                    int totaloutIceBox = 0;
                    int totalinIceBox = 0;
                    int totalexcessIceBox = 0;
                    int totalshortIceBox = 0;
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
                                excessIceBox = inIceBox - outIceBox;
                            }
                            catch { excessIceBox = 0; }
                            if (excessIceBox < 0)
                            { excessIceBox = 0; }
                            sb.Append(excessIceBox.ToString());
                            totalexcessIceBox += excessIceBox;
                            sb.Append("</td>");

                            sb.Append("<td class='tg-yw4l' style='text-align:right'>");
                            try
                            {
                                shortIceBox = outIceBox - inIceBox;
                            }
                            catch { shortIceBox = 0; }
                            if (shortIceBox < 0)
                            { shortIceBox = 0; }
                            sb.Append(shortIceBox.ToString());
                            totalshortIceBox += shortIceBox;
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
                        outIceBox1 = Convert.ToInt32(row["IceBoxDispached"]);
                    }
                    catch { outIceBox1 = 0; }

                    sb.Append("<b>" + outIceBox1.ToString() + "</b>");
                    totaloutIceBox1 += outIceBox1;
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l' style='text-align:right'>");
                    try
                    {
                        inIceBox1 = Convert.ToInt32(row["IceBoxReturned"]);
                    }
                    catch { inIceBox1 = 0; }

                    sb.Append("<b>" + inIceBox1.ToString() + "</b>");
                    totalinIceBox1 += inIceBox1;
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l' style='text-align:right'>");
                    try
                    {
                        excessIceBox1 = inIceBox1 - outIceBox1;
                    }
                    catch { excessIceBox1 = 0; }
                    if (excessIceBox1 < 0)
                    { excessIceBox1 = 0; }
                    sb.Append("<b>" + excessIceBox1.ToString() + "</b>");
                    totalexcessIceBox1 += excessIceBox1;
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l' style='text-align:right'>");
                    try
                    {
                        shortIceBox1 = outIceBox1 - inIceBox1;
                    }
                    catch { shortIceBox1 = 0; }
                    if (shortIceBox1 < 0)
                    { shortIceBox1 = 0; }
                    sb.Append("<b>" + shortIceBox1.ToString() + "</b>");
                    totalshortIceBox1 += shortIceBox1;
                    sb.Append("</td>");

                    sb.Append("</tr>");


                }
                sb.Append("<tr style='border-bottom:1px solid'> <td colspan = '6'> &nbsp; </td> </tr>");
                sb.Append("<tr style='border-bottom:1px solid'>");



                sb.Append("<td class='tg-yw4l' colspan='2' style='text-align:left'>");
                sb.Append("<b>" + "Total&nbsp;&nbsp;" + count1.ToString() + "</b>");
                sb.Append("</td>");



                sb.Append("<td class='tg-yw4l'  style='text-align:right'>");
                sb.Append("<b>" + totaloutIceBox1 + "</b>");
                sb.Append("</td>");



                sb.Append("<td class='tg-yw4l'   style='text-align:right'>");
                sb.Append("<b>" + totalinIceBox1 + "</b>");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l'  style='text-align:right'>");
                sb.Append("<b>" + totalexcessIceBox1 + "</b>");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l'  style='text-align:right'>");
                sb.Append("<b>" + totalshortIceBox1 + "</b>");
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