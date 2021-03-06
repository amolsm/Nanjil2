﻿using Bussiness;
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
    public partial class NewAgentlistSummary : System.Web.UI.Page
    {
        DataSet DS;
        MarketingData marketingdata;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
              
                DS = BindCommanData.BindCommanDropDwon("RouteID ", "RouteCode +' '+RouteName as Name  ", "routeMaster", "IsArchive=1");
                if (!Comman.Comman.IsDataSetEmpty(DS))
                {
                    dpRoute.DataSource = DS;
                    dpRoute.DataBind();
                    dpRoute.Items.Insert(0, new ListItem("--All Route--", "0"));
                }
                txtStartDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                txtEndDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
            }
        }

        protected void btnViewDetails_Click(object sender, EventArgs e)
        {
            string result = string.Empty;
            marketingdata = new MarketingData();
            DataSet DS1 = new DataSet();
        
            DS1 = marketingdata.ViewNewAgentList((Convert.ToDateTime(txtStartDate)).ToString("dd-MM-yyyy"), (Convert.ToDateTime(txtEndDate)).ToString("dd-MM-yyyy"), Convert.ToInt32(dpRoute.SelectedItem.Value));
            if (!Comman.Comman.IsDataSetEmpty(DS1))
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
                sb.Append("<col style = 'width:160px'>");
                sb.Append("<col style = 'width:100px'>");
                sb.Append("<col style = 'width:120px'>");
                sb.Append("<col style = 'width:120px'>");
                sb.Append("<col style = 'width:120px'>");
                sb.Append("</colgroup>");

                sb.Append("<tr>");
                sb.Append("<th class='tg-yw4l' rowspan='2'>");
                sb.Append("<img src='/Theme/img/logo1.png' class='img-circle' alt='Logo' width='50px' hight='50px'>");
                sb.Append("</th>");

                sb.Append("<th class='tg-baqh' colspan='5' style='text-align:center'>");
                sb.Append("<b>Nanjil Integrated Dairy Development, Mulagumoodu, K.K.Dt.</b>");
                sb.Append("</th>");
                sb.Append("<th class='tg-yw4l' style='text-align:right'>");
                sb.Append("&nbsp;<br>");
                sb.Append("</th>");
                sb.Append("</tr>");

                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append("<td class='tg-yw4l' colspan='5' style='text-align:center'>");
                sb.Append("<b><u>New Agent List Report </u></b> <br/>");
                sb.Append("</td>");
                sb.Append("<td class='tg-yw4l' style='text-align:right'>");
                sb.Append("PH:248370,248605");
                sb.Append("</td> </tr>");

                sb.Append("<tr style='border-bottom:1px solid'>");

                sb.Append("<td colspan='4'>");
                if (dpRoute.SelectedItem.Value == "0")
                {
                    sb.Append("Route : All");
                }
                else
                {
                    sb.Append("");
                }
                sb.Append("</td>");
                sb.Append("<td colspan='3' style='text-align:right'>");
                sb.Append(DateTime.Now.ToString("dd-MM-yyyy HH:mm"));
                sb.Append("</td>");
                sb.Append("</tr>");
                sb.Append("<tr style='border-bottom:1px solid'>");

                sb.Append("<td colspan='4'>");

                sb.Append(Convert.ToDateTime(txtStartDate.Text).ToString("dd-MM-yyyy"));
               
                sb.Append("</td>");
                sb.Append("<td colspan='3' style='text-align:right'>");
                sb.Append(Convert.ToDateTime(txtEndDate.Text).ToString("dd-MM-yyyy"));
                sb.Append("</td>");
                sb.Append("</tr>");
                sb.Append("<tr>");
                sb.Append("<td>");
                sb.Append("<b>Sr.No.</b>");
                sb.Append("</td>");
                sb.Append("<td colspan='2' style='text-align:center' >");
                sb.Append("<b>Agency</b>");
                sb.Append("</td>");
                sb.Append("<td>");
                sb.Append("&nbsp;");
                sb.Append("</td>");
                sb.Append("<td>");
                sb.Append("<b>JoiningDate</b>");
                sb.Append("</td>");
                sb.Append("<td style='text-align:right'>");
                sb.Append("<b>CreatedBy</b>");
                sb.Append("</td>");
                sb.Append("<td style='text-align:right'>");
                sb.Append("<b>Status</b>");
                sb.Append("</td>");
                sb.Append("</tr>");
                int routcount = 0;
                int count = 0;
                foreach (DataRow rows in DS1.Tables[1].Rows)
                {
                    routcount++;
                    sb.Append("<tr> ");
                    sb.Append("<td colsapn='7'> ");
                    sb.Append("&nbsp;");
                    sb.Append("</td>");
                    sb.Append("</tr> ");
                    sb.Append("<tr style='border-bottom:1px solid'><td colspan='7'></td></tr>");
                    sb.Append("<tr style='border-bottom:1px solid'>");

                    sb.Append("<td colspan='2'>");
                    sb.Append(rows["RouteCode"].ToString());
                    sb.Append("</td>");
                    sb.Append("<td colspan = '5'>");
                    sb.Append(rows["RouteName"].ToString());
                    sb.Append("</td>");
                    sb.Append("</tr>");

                    int srno = 0;
                    
                    foreach (DataRow row in DS1.Tables[0].Rows)
                    {


                        if (rows["RouteId"].ToString() == row["RouteId"].ToString())
                        {

                            srno++;
                            count++;
                            sb.Append("<tr>");
                            sb.Append("<td>");
                            sb.Append(srno.ToString());
                            sb.Append("</td>");
                            sb.Append("<td style='text-align:center'>");
                            sb.Append(row["AgentCode"].ToString());
                            sb.Append("</td>");
                            sb.Append("<td colspan = '2'>");
                            sb.Append(row["AgentName"].ToString());
                            sb.Append("</td>");

                            sb.Append("<td>");
                            sb.Append(row["DateofJoining"].ToString());
                            sb.Append("</td>");
                            sb.Append("<td style='text-align:right'>");
                            sb.Append(row["Name"].ToString());
                            sb.Append("</td>");
                            sb.Append("<td style='text-align:right'>");
                            if (row["Isactive"].ToString() == "True")
                            {
                                sb.Append("Active");
                            }
                            else { sb.Append("InActive"); }

                            sb.Append("</td>");
                            sb.Append("</tr>");


                        }





                    }

                

                }
                sb.Append("<tr> ");
                sb.Append("<td colsapn='7'> ");
                sb.Append("&nbsp;");
                sb.Append("</td>");
                sb.Append("</tr> ");
                sb.Append("<tr style='border-bottom:1px solid'><td colspan='7'></td></tr>");
                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append("<td colspan='2'>");
                sb.Append("Total Route : ");
                sb.Append("</td>");
                sb.Append("<td>");
                sb.Append(routcount.ToString());
                sb.Append("</td>");
                sb.Append("<td colspan='2'>");
                sb.Append(" New Agents :");
                sb.Append("</td>");
                sb.Append("<td colspan='2'>");
                sb.Append(count.ToString());
                sb.Append("</td>");
                sb.Append("</tr>");





                result = sb.ToString();
                genratedBIll.Text = result;
             
                Session["ctrl"] = pnlBill;
               

            }
            else
            {
                result = "New Agent List Not found";
                genratedBIll.Text = result;

            }
        }
    }
}