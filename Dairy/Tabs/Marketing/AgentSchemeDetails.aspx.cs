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
    public partial class AgentSchemeDetails : System.Web.UI.Page
    {
        BillData billdata = new BillData();
        DataSet DS = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                EmployeeData empData = new EmployeeData();
                DS = BindCommanData.BindCommanDropDwon("RouteID ", "RouteCode +' '+RouteName as Name  ", "routeMaster", "IsArchive=1");
                if (!Comman.Comman.IsDataSetEmpty(DS))
                {
                    dpRoute.DataSource = DS;
                    dpRoute.DataBind();
                    dpRoute.Items.Insert(0, new ListItem("--All Route  --", "0"));
                }
                
            }
        }

        protected void btngenrateBill_click(object sender, EventArgs e)
        {

            

            string result = string.Empty;
            DS = billdata.AgentSchemeDetails(Convert.ToInt32(dpRoute.SelectedItem.Value));
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                DataView view = new DataView(DS.Tables[0]);
                DataTable distinctValues = view.ToTable(true, "RouteCode", "RouteName");
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
                sb.Append("</colgroup>");

                sb.Append("<tr>");
                sb.Append("<th class='tg-yw4l' rowspan='2'>");
                sb.Append("<img src='/Theme/img/logo1.png' class='img-circle' alt='Logo' width='50px' hight='50px'>");
                sb.Append("</th>");

                sb.Append("<th class='tg-baqh' colspan='4' style='text-align:center'>");
                sb.Append("<u>Agency Scheme Details </u> <br/>");
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
                sb.Append("</td> </tr>");

                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append("<td colspan='3'>");
                sb.Append(dpRoute.SelectedItem.Text);
                sb.Append("</td>");
                sb.Append("<td colspan='3' style='text-align:right'>");
                sb.Append(DateTime.Now.ToString("dd-mm-yyyy HH:mm"));
                sb.Append("</td>");
                sb.Append("</tr>");
                int totalentries = 0;
                double routeschemeamt = 0.00;
                double routetotalsheme = 0.00;
                foreach (DataRow rows in distinctValues.Rows)
                {
                    sb.Append("<tr style='border-bottom:1px solid'><td colspan='6'>&nbsp;&nbsp;</td></tr>");
                    totalentries++;
                    sb.Append("<tr style='border-bottom:1px solid'>");
                    sb.Append("<td>");
                    sb.Append("<b>" + totalentries + "</b>");
                    sb.Append("</td>");
                    sb.Append("<td colspan='2'>");
                    sb.Append("<b>" + rows["RouteCode"].ToString() + "</b>");
                    sb.Append("</td>");
                    sb.Append("<td colspan = '3'>");
                    sb.Append("<b>" + rows["RouteName"].ToString() + "</b>");
                    sb.Append("</td>");
                    //sb.Append("<td>");
                    //sb.Append("<b>Route Name</b>");
                    //sb.Append("</td>");

                    sb.Append("</tr>");

                    int srno = 0;
                    double schemeamt = 0.00;
                    double totalsheme = 0.00;
                    foreach (DataRow row in DS.Tables[0].Rows)
                    {
                        if (rows["RouteCode"].ToString() == row["RouteCode"].ToString())
                        {
                            srno++;
                            sb.Append("<tr>");
                            sb.Append("<td>");
                            sb.Append(srno.ToString());
                            sb.Append("</td>");
                            sb.Append("<td>");
                            sb.Append(row["AgentCode"].ToString());
                            sb.Append("</td>");
                            sb.Append("<td colspan = '2'>");
                            sb.Append(row["AgentName"].ToString());
                            sb.Append("</td>");
                            //sb.Append("<td>");
                            //sb.Append(row["RouteName"].ToString()); ;
                            //sb.Append("</td>");
                            sb.Append("<td style='text-align:right'>");
                            sb.Append(Convert.ToDecimal(row["SchemeAmount"]).ToString("#0.00"));
                            sb.Append("</td>");
                            schemeamt += Convert.ToDouble(row["SchemeAmount"]);
                            sb.Append("<td style='text-align:right'>");
                            if (string.IsNullOrEmpty(row["TotalSchemeAmount"].ToString()))
                            {
                                sb.Append("0.00");
                            }
                            else
                            {
                                sb.Append(Convert.ToDecimal(row["TotalSchemeAmount"]).ToString("#0.00"));

                                totalsheme += Convert.ToDouble(row["TotalSchemeAmount"]);
                            }
                            sb.Append("</td>");
                            sb.Append("</tr>");
                        }
                    }

                    sb.Append("<tr style='border-bottom:1px solid'><td colspan='6'></td></tr>");
                    sb.Append("<tr style='border-bottom:1px solid'>");
                    sb.Append("<td>");
                    sb.Append("Total");
                    sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append("Count");
                    sb.Append("</td>");
                    sb.Append("<td colspan='2'>");
                    sb.Append(srno.ToString());
                    sb.Append("</td>");
                    sb.Append("<td style='text-align:right'>");
                    sb.Append(Convert.ToDecimal(schemeamt).ToString("#0.00"));
                    routeschemeamt += schemeamt;
                    sb.Append("</td>");
                    sb.Append("<td style='text-align:right'>");
                    sb.Append(Convert.ToDecimal(totalsheme).ToString("#0.00"));
                    routetotalsheme += totalsheme;
                    sb.Append("</td>");
                    sb.Append("</tr>");

                }

                sb.Append("<tr style='border-bottom:1px solid'><td colspan='6'></td></tr>");
                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append("<td>");
                sb.Append("Total");
                sb.Append("</td>");
                sb.Append("<td>");
                sb.Append("Route Count");
                sb.Append("</td>");
                sb.Append("<td colspan='2'>");
                sb.Append(totalentries.ToString());
                sb.Append("</td>");
                sb.Append("<td style='text-align:right'>");
                sb.Append(Convert.ToDecimal(routeschemeamt).ToString("#0.00"));
                sb.Append("</td>");
                sb.Append("<td style='text-align:right'>");
                sb.Append(Convert.ToDecimal(routetotalsheme).ToString("#0.00"));
                sb.Append("</td>");
                sb.Append("</tr>");

                result = sb.ToString();
                genratedBIll.Text = result;
                //Session["ctrl"] = sb.ToString();
                Session["ctrl"] = pnlBill;
                //Response.Redirect("/print.aspx", true);

            }

            else
            {
                result = "Bill not found";
                genratedBIll.Text = result;

            }
        }
    }
}