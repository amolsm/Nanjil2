using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using System.Data;
using DataAccess;
using System.Text;
using Comman;
using Dairy.App_code;
using Dairy;
using Bussiness;


namespace Dairy
{
    public partial class OrderDemandStatement : System.Web.UI.Page
    {
        OrderDemand orderdemand = new OrderDemand();
        OrderDemandStatementData orderdemanddata = new OrderDemandStatementData();
        DataSet DS = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDwon();
                txtDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));

            }
        }
        protected void BindDropDwon()
        {
            DS = new DataSet();
            DS = BindCommanData.BindCommanDropDwon("RouteID","RouteCode +':  ' +RouteName as Name", "RouteMaster", "IsArchive =1");
            dpRoute.DataSource = DS;
            dpRoute.DataBind();
            dpRoute.Items.Insert(0, new ListItem("--Select Route--", "0"));
        }

        protected void btngenrateBill_Click(object sender, EventArgs e)
        {
            string result = string.Empty;

            int flag = 1;
            DS = orderdemanddata.GetOrderDemandReport((Convert.ToInt32(dpRoute.SelectedItem.Value)), flag);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<style type='text/css'>");
                sb.Append(".tg  {border-collapse:collapse;border-spacing:0;}");
                sb.Append(".tg td{font-family:Arial, sans-serif;font-size:15px;padding:1px 1px; width:30px; border-style:solid;border-width:0.2px;overflow:hidden;word-break:normal;border-bottom: solid 0.2px; align: center; }");
                sb.Append(".tg th{font-family:Arial, sans-serif;font-size:15px;font-weight:normal;padding:10px 5px;border-style:solid;border-width:0.2px;overflow:hidden;word-break:normal;     border-style:none;}");
                sb.Append(".tg .tg-baqh{text-align:center;vertical-align:top}");
                // sb.Append(".tg .tg-031e{text-align:center;vertical-align:top;}");   ////////
                sb.Append(".tg .tg-yw4l{vertical-align:middle ; padding: 5px; border-right-style:hidden;}");

                sb.Append("</style>");
                //sb.Append("<table class='tg' align='center'>");
                sb.Append("<table class='tg style1';");
                sb.Append("<tr>");

                sb.Append("<th class='tg-yw4l'>");
                sb.Append("<img src='/Theme/img/logo1.png' class='img-circle' alt='Logo' width='50px' hight='50px' >");

                sb.Append("<th class='tg-baqh' colspan='18'>Nanjil Milk Plant,   Mulagumoodu, K.K.Dt.<br><small><u>Order Demand Statement</u></small></th>");

                sb.Append("</tr>");

                sb.Append("<tr>");
                sb.Append(" <td  colspan='7' align='left'> Route: " + dpRoute.SelectedItem.Text.ToString());
                sb.Append("</td>");
                sb.Append("<td  colspan='11' align='right'>Date: " + Convert.ToDateTime(txtDate.Text).ToString("dd-MM-yyyy"));
                sb.Append("</tr>");

                sb.Append(" <tr>");
                sb.Append("<td class='tg-031e'  rowspan='2' align='left'>Agt.ID/<br>Emp.ID<br><br>SeqNo</td>");
                sb.Append(" <td class='tg-031e'rowspan='2' align='left' width='30%'>Agency Name/<br>Employee Name</td>");
                sb.Append("<td class='tg-031e' colspan='2' align='center'>T.M.[Lts]</td>");

                sb.Append("<td class='tg-031e' colspan='3' align='center'>D.T.M.[Lts]</td>");

                sb.Append(" <td class='tg-031e'colspan='3' align='center'>S.M.[Lts]</td>");

                sb.Append("<td class='tg-031e' colspan='3' align='center'>F.C.M.[Lts]</td>");

                sb.Append("<td class='tg-031e' align='center'>B.M.</td>");
                sb.Append("<td class='tg-031e' colspan='2' align='center'>Curd[Lts]</td>");

                sb.Append("<td class='tg-031e' colspan='2' align='center'>Cup Curd</td>");

                sb.Append("</tr>");
                sb.Append("<tr>");

                sb.Append(" <td class='tg-031e' align='center'>500</td>");
                sb.Append(" <td class='tg-031e' align='center'>250</td>");
                sb.Append("<td class='tg-031e' align='center'>1000</td>");
                sb.Append("<td class='tg-031e' align='center'>500</td>");
                sb.Append("<td class='tg-031e' align='center'>250</td>");
                sb.Append("<td class='tg-031e' align='center'>1000</td>");
                sb.Append("<td class='tg-031e' align='center'>500</td>");
                sb.Append("<td class='tg-031e' align='center'>200</td>");
                sb.Append("<td class='tg-031e' align='center'>1000</td>");
                sb.Append("<td class='tg-031e' align='center'>500</td>");
                sb.Append("<td class='tg-031e' align='center'>200</td>");
                sb.Append("<td class='tg-031e' align='center'>[Lts]</td>");
                sb.Append("<td class='tg-031e' align='center'>200</td>");
                sb.Append("<td class='tg-031e' align='center'>500</td>");
                sb.Append("<td class='tg-031e' align='center'>60</td>");
                sb.Append("<td class='tg-031e' align='center'>100</td>");
                sb.Append("</tr>");
                int count = 0;
                int billseq = 0;
                foreach (DataRow row in DS.Tables[0].Rows)
                {
                    billseq++;

                    sb.Append("<tr style='page-break-inside:avoid;' height='35' > ");
                    sb.Append("<td class='tg-031e'>");

                    if (string.IsNullOrEmpty(row["AgentCode"].ToString()))
                    {
                        sb.Append(row["EmployeeCode"].ToString() + "<br>");
                    }
                    else
                    {
                        sb.Append(row["AgentCode"].ToString() + "<br>");
                    }
                    //sb.Append(row["SeqId"].ToString() + "<br>");
                    sb.Append(billseq.ToString() + "<br>");
                    sb.Append("</td>");
                    sb.Append("<td class='tg-031e'>");
                    //sb.Append(row["AgentName"].ToString() + "<br>");
                    if (string.IsNullOrEmpty(row["AgentName"].ToString()))
                    {
                        sb.Append(row["EmployeeName"].ToString() + "<br>");
                    }
                    else
                    {
                        sb.Append(row["AgentName"].ToString() + "<br>");
                    }
                    if (string.IsNullOrEmpty(row["MobileNo"].ToString()))
                    {
                        sb.Append("<sub style='text-align:left'>" + row["mobile"].ToString() + "</sub>");
                    }
                    else
                    {
                        sb.Append("<sub style='text-align:left'>" + row["MobileNo"].ToString() + "</sub>");
                    }
                    sb.Append("</td>");
                    if (row["SchAmt"].ToString() == "")

                    {
                        sb.Append(" <td class='tg-031e' style='text-align:center'><hr  style='margin-top:20px; margin-bottom:20px; vertical-align:middle'>");
                        sb.Append("</td>");
                    }
                    else
                    {
                        sb.Append(" <td class='tg-031e' style='text-align:center'><hr style='margin-top:20px; margin-bottom:0px; vertical-align:middle'>" + row["SchAmt"].ToString());   //// scheme
                        sb.Append("</td>");
                    }


                    sb.Append(" <td class='tg-031e'><hr>");
                    sb.Append("<td class='tg-031e'><hr>");
                    sb.Append("<td class='tg-031e'><hr>");
                    sb.Append("<td class='tg-031e'><hr>");
                    sb.Append("<td class='tg-031e'><hr>");
                    sb.Append("<td class='tg-031e'><hr>");
                    sb.Append("<td class='tg-031e'><hr>");
                    sb.Append("<td class='tg-031e'><hr>");
                    sb.Append("<td class='tg-031e'><hr>");
                    sb.Append("<td class='tg-031e'><hr>");
                    sb.Append("<td class='tg-031e'><hr>");
                    sb.Append("<td class='tg-031e'><hr>");
                    sb.Append("<td class='tg-031e'><hr>");
                    sb.Append("<td class='tg-031e'><hr>");
                    sb.Append("<td class='tg-031e'><hr>");
                    sb.Append("</tr>");

                    count++;
                    if (count % 17 == 0 && count != 0)
                    {

                        sb.Append("<style type='text/css'>");
                        sb.Append(".tg  {border-collapse:collapse;border-spacing:0;}");
                        sb.Append(".tg td{font-family:Arial, sans-serif;font-size:15px;padding:1px 1px;border-style:solid;border-width:0.2px;overflow:hidden;word-break:normal;border-bottom: solid 0.2px; align: center; }");
                        sb.Append(".tg th{font-family:Arial, sans-serif;font-size:15px;font-weight:normal;padding:10px 5px;border-style:solid;border-width:0.2px;overflow:hidden;word-break:normal;     border-style:none;}");
                        sb.Append(".tg .tg-baqh{text-align:center;vertical-align:top}");
                        sb.Append(".tg .tg-yw4l{vertical-align:middle ; padding: 5px; border-right-style:hidden;}");
                        sb.Append("</style>");
                        //sb.Append("<table class='tg' align='center'>");
                        sb.Append("<table class='tg style1';");
                        sb.Append("<tr style='page-break-inside:avoid;'>");

                        sb.Append("<th class='tg-yw4l'>");
                        sb.Append("<img src='/Theme/img/logo1.png' class='img-circle' alt='Logo' width='50px' hight='50px' >");

                        sb.Append("<th class='tg-baqh' colspan='18'>Nanjil Milk Plant,   Mulagumoodu, K.K.Dt.<br><small><u>Order Demand Statement</u></small></th>");

                        sb.Append("</tr>");

                        sb.Append("<tr>");
                        sb.Append(" <td  colspan='7' align='left'> Route: " + dpRoute.SelectedItem.Text.ToString());
                        sb.Append("</td>");
                        sb.Append("<td  colspan='11' align='right'>Date: " + Convert.ToDateTime(txtDate.Text).ToString("dd-MM-yyyy"));
                        sb.Append("</tr>");

                        sb.Append(" <tr>");
                        sb.Append("<td class='tg-031e'  rowspan='2' align='left'>Agt.ID/<br>Emp.ID<br><br>SeqNo</td>");
                        sb.Append(" <td class='tg-031e'rowspan='2' align='left' width='30%'>Agency Name /<br>Employee Name</td>");
                        sb.Append("<td class='tg-031e' colspan='2' align='center'>T.M.[Lts]</td>");

                        sb.Append("<td class='tg-031e' colspan='3' align='center'>D.T.M.[Lts]</td>");

                        sb.Append(" <td class='tg-031e'colspan='3' align='center'>S.M.[Lts]</td>");

                        sb.Append("<td class='tg-031e' colspan='3' align='center'>F.C.M.[Lts]</td>");

                        sb.Append("<td class='tg-031e' align='center'>B.M.</td>");
                        sb.Append("<td class='tg-031e' colspan='2' align='center'>Curd[Lts]</td>");

                        sb.Append("<td class='tg-031e' colspan='2' align='center'>Cup Curd</td>");

                        sb.Append("</tr>");
                        sb.Append("<tr>");

                        sb.Append(" <td class='tg-031e' align='center'>500</td>");
                        sb.Append(" <td class='tg-031e' align='center'>250</td>");
                        sb.Append("<td class='tg-031e' align='center'>1000</td>");
                        sb.Append("<td class='tg-031e' align='center'>500</td>");
                        sb.Append("<td class='tg-031e' align='center'>250</td>");
                        sb.Append("<td class='tg-031e' align='center'>1000</td>");
                        sb.Append("<td class='tg-031e' align='center'>500</td>");
                        sb.Append("<td class='tg-031e' align='center'>200</td>");
                        sb.Append("<td class='tg-031e' align='center'>1000</td>");
                        sb.Append("<td class='tg-031e' align='center'>500</td>");
                        sb.Append("<td class='tg-031e' align='center'>200</td>");
                        sb.Append("<td class='tg-031e' align='center'>[Lts]</td>");
                        sb.Append("<td class='tg-031e' align='center'>200</td>");
                        sb.Append("<td class='tg-031e' align='center'>500</td>");
                        sb.Append("<td class='tg-031e' align='center'>60</td>");
                        sb.Append("<td class='tg-031e' align='center'>100</td>");
                        sb.Append("</tr>");


                    }


                }





                sb.Append("</table>");
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