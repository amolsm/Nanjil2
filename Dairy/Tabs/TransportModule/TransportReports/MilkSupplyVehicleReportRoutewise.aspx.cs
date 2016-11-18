using Bussiness;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dairy.Tabs.TransportModule.TransportReports
{
    public partial class MilkSupplyVehicleReportRoutewise : System.Web.UI.Page
    {
        TransportData transportdata = new TransportData();
        DataSet DS = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtStartDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                txtEndDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                BindDropDwon();
            }

        }

        public void BindDropDwon()
        
        {
            DS = BindCommanData.BindCommanDropDwon("RouteID", "RouteCode+space(2)+RouteName as Name", "RouteMaster", "IsArchive=1");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dproute.DataSource = DS;
                dproute.DataBind();
                dproute.Items.Insert(0, new ListItem("--All Route--", "0"));
            }
        }

        protected void btngenrateBill_click(object sender, EventArgs e)
        {
            string result = string.Empty;
            double runkm = 0;
            double exces = 0;

            DS = transportdata.VehicleReportRoutewise((Convert.ToDateTime(txtStartDate.Text)).ToString("dd-MM-yyyy"), (Convert.ToDateTime(txtEndDate.Text)).ToString("dd-MM-yyyy"),Convert.ToInt32(dproute.SelectedItem.Value));
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
                sb.Append("<col style = 'width:120px'>");
                sb.Append("<col style = 'width:120px'>");
                sb.Append("<col style = 'width:120px'>");
                sb.Append("<col style = 'width:120px'>");
                sb.Append("<col style = 'width:120px'>");
                sb.Append("<col style = 'width:120px'>");
                sb.Append("<col style = 'width:120px'>");
                sb.Append("<col style = 'width:120px'>");
                sb.Append("<col style = 'width:120px'>");
           
                sb.Append("</colgroup>");

                sb.Append("<tr>");
                sb.Append("<th class='tg-yw4l' rowspan='2'>");
                sb.Append("<img src='/Theme/img/logo1.png' class='img-circle' alt='Logo' width='50px' hight='50px'>");
                sb.Append("</th>");

                sb.Append("<th class='tg-baqh' colspan='8' style='text-align:center'>");
                sb.Append("<u>  Milk Supply Vehicles Report[Routewise]</u> <br/>");
                sb.Append("</th>");

                sb.Append("<th class='tg-yw4l' colspan='2' style='text-align:right'>");

                sb.Append("TIN:330761667331<br>");
                sb.Append("</th>");
                sb.Append("</tr>");

                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append("<td class='tg-yw4l' colspan='8' style='text-align:center'>");
                sb.Append("<b>Nanjil Integrated Dairy Development, Mulagumoodu, K.K.Dt.</b>");

                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l' colspan='2'  style='text-align:right'>");

                sb.Append("PH:248370,248605");

                sb.Append("</td>");

                sb.Append("<tr>");
                sb.Append("<td class='tg-yw4l' colspan='3' style='text-align:left'>");
                sb.Append("Start Date:" + Convert.ToDateTime(txtStartDate.Text).ToString("dd-MM-yyyy"));
                sb.Append("</td>");
                sb.Append("<th class='tg-baqh' colspan='5' style='text-align:center'>");
                sb.Append("Route:"+"<u>"+dproute.SelectedItem.Text.ToString()+"</u> <br/>");
                sb.Append("</th>");
                sb.Append("<td class='tg-yw4l' colspan='2' style='text-align:right'>");
                sb.Append("End Date:" + Convert.ToDateTime(txtEndDate.Text).ToString("dd-MM-yyyy"));
                sb.Append("</td>");
                sb.Append("<tr style='border-bottom:2px solid'>");
                sb.Append("<td class='tg-yw4l' colspan='10' style='text-align:left'>");
                sb.Append("<tr style='border-bottom:1px dotted'> <td colspan = '10'> &nbsp; </td> </tr>");
                sb.Append("<tr style='border-bottom:1px solid'>");

                sb.Append("<td class='tg-yw4l'  style='text-align:center'>");
                sb.Append("<b>Date</b>");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l'  style='text-align:center'>");
                sb.Append("<b>Vehicle</b>");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l'  style='text-align:center'>");
                sb.Append("<b>Driver</b>");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l'  style='text-align:center'>");
                sb.Append("<b>S.Man</b>");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l'  style='text-align:center'>");
                sb.Append("<b>OutTime</b>");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l'  style='text-align:center'>");
                sb.Append("<b>In.Time</b>");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l'  style='text-align:center'>");
                sb.Append("<b>OutKM.</b>");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l'  style='text-align:center'>");
                sb.Append("<b>InKM.</b>");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l'  style='text-align:center'>");
                sb.Append("<b>RunKM.</b>");
                sb.Append("</td>");


                sb.Append("<td class='tg-yw4l'  style='text-align:center'>");
                sb.Append("<b>ExcesKM.</b>");
                sb.Append("</td>");

                sb.Append("</tr>");
                int Entries = 0;
                foreach (DataRow row in DS.Tables[0].Rows)
                {
                    sb.Append("<tr>");
                    sb.Append("<td class='tg-yw4l'  style='text-align:center'>");
                    sb.Append(row["StartDate"].ToString());
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l'  style='text-align:center'>");
                    sb.Append(row["VehicleNo"].ToString());
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l'  style='text-align:center'>");
                    sb.Append(row["FirstDriver"].ToString());
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l'  style='text-align:center'>");
                    sb.Append(row["SalesMan"].ToString());
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l'  style='text-align:center'>");
                    sb.Append(row["OutTime"].ToString());
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l'  style='text-align:center'>");
                    sb.Append(row["InTime"].ToString());
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l'  style='text-align:center'>");
                    sb.Append(row["OutKM"].ToString());
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l'  style='text-align:center'>");
                    sb.Append(row["InKM"].ToString());
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l'  style='text-align:center'>");
                    sb.Append(row["RunKM"].ToString());
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l'  style='text-align:center'>");
                    sb.Append(row["Exces"].ToString());
                    sb.Append("</td>");

                

                   
                    sb.Append("</tr>");
                    runkm=runkm+Convert.ToDouble(row["RunKM"]);
                    exces = exces + Convert.ToDouble(row["Exces"]);
                    Entries++;

                }
                sb.Append("<tr style='border-bottom:1px dotted'> <td colspan = '10'> &nbsp; </td> </tr>");
                sb.Append("<tr style='border-bottom:1px dotted'>");
                sb.Append("<td class='tg-yw4l'  style='text-align:center'>");
                sb.Append("<b>"+"Total:"+"</b>");
                sb.Append("</td>");
                sb.Append("<td class='tg-yw4l'  colspan='7' style='text-align:center'>");

                sb.Append("<b>" + Entries + "&nbsp;&nbsp;" + "Entries" + "</b>");
                sb.Append("</td>");
                sb.Append("<td class='tg-yw4l'   style='text-align:center'>");

                sb.Append("<b>" + runkm + "</b>");
                sb.Append("</td>");
                sb.Append("<td  class='tg-yw4l'  style='text-align:center'>");
                
                sb.Append("<b>" +  exces+ "</b>");
                sb.Append("</td>");
                sb.Append("</tr>");
                sb.Append("</td>");
                sb.Append("</tr>");


             
                result = sb.ToString();
                genratedBIll.Text = result;
                //Session["ctrl"] = sb.ToString();
                Session["ctrl"] = pnlBill;


            }


            else
            {
                result = "Vehicle  Reports Not Found";
                genratedBIll.Text = result;

            }

        }
        }
    }
