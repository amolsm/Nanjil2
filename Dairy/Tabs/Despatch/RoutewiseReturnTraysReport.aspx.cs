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
    public partial class RoutewiseReturnTraysReport : System.Web.UI.Page
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
            DS = dispatchData.GetRoutewiseReturnTraysReport((Convert.ToDateTime(txtStartDate.Text)).ToString("dd-MM-yyyy"), (Convert.ToDateTime(txtEndDate.Text)).ToString("dd-MM-yyyy"), Convert.ToInt32(dpRoute.SelectedItem.Value));
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
                sb.Append("<col style = 'width:100px'>");
           
                sb.Append("</colgroup>");

                sb.Append("<tr>");
                sb.Append("<th class='tg-yw4l' rowspan='2'>");
                sb.Append("<img src='/Theme/img/logo1.png' class='img-circle' alt='Logo' width='50px' hight='50px'>");
                sb.Append("</th>");

                sb.Append("<th class='tg-baqh' colspan='5' style='text-align:center'>");
                sb.Append("<u>RouteWise Return Trays Report</u> <br/>");
                sb.Append("</th>");

                sb.Append("<th class='tg-yw4l' style='text-align:right'>");

                sb.Append("TIN:330761667331<br>");
                sb.Append("</th>");
                sb.Append("</tr>");

                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append("<td class='tg-yw4l' colspan='5' style='text-align:center'>");
                sb.Append("<b>Nanjil Integrated Dairy Development, Mulagumoodu, K.K.Dt.</b>");

                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l' style='text-align:right'>");

                sb.Append("PH:248370,248605");

                sb.Append("</td>");

                sb.Append("<tr>");
                sb.Append("<td class='tg-yw4l' colspan='4' style='text-align:left'>");
                sb.Append("Start Date:" + Convert.ToDateTime(txtStartDate.Text).ToString("dd-MM-yyyy"));
                sb.Append("</td>");
                sb.Append("<td class='tg-yw4l' colspan='3' style='text-align:right'>");
                sb.Append("End Date:" + Convert.ToDateTime(txtEndDate.Text).ToString("dd-MM-yyyy"));
                sb.Append("</td>");
                sb.Append("<tr style='border-bottom:2px solid'>");
                sb.Append("<td class='tg-yw4l' colspan='4' style='text-align:left'>");

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

                sb.Append("<td class='tg-yw4l'  style='text-align:center'>");
                sb.Append("<b>First Salesman</b>");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l'  style='text-align:center'>");
                sb.Append("<b>Second Salesman</b>");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l'  style='text-align:right'>");
                sb.Append("<b>Trays</b>");
                sb.Append("</td>");



                sb.Append("<td class='tg-yw4l'   style='text-align:right'>");
                sb.Append("<b>IceBox</b>");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l'  style='text-align:right'>");
                sb.Append("<b>Cartons</b>");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l'  style='text-align:right'>");
                sb.Append("<b>Other</b>");
                sb.Append("</td>");

                sb.Append("</tr>");
                int count = 0;
                int trays = 0;
                int totaltrays = 0;
                int icebox = 0;
                int totalicebox = 0;
                int carton = 0;
                int totalcarton = 0;
                int other = 0;
                int totalother = 0;
                foreach (DataRow row in DS.Tables[0].Rows)
                {
                    count++;
                    sb.Append("<tr>");


                    sb.Append("<td class='tg-yw4l'   style='text-align:left'>");
                    sb.Append(row["DispatchDate"].ToString());
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l' style='text-align:center'>");
                    sb.Append(row["FirstSalesman"].ToString());
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l' style='text-align:center'>");
                    sb.Append(row["SecondSalesman"].ToString());
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l' style='text-align:right'>");
                    try
                    {
                        trays = Convert.ToInt32(row["TraysReturned"]);
                    }
                    catch { trays = 0; }
                    totaltrays += trays;
                    sb.Append(trays.ToString());
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l' style='text-align:right'>");
                    try
                    {
                        icebox = Convert.ToInt32(row["IceBoxReturned"]);
                    }
                    catch { icebox = 0; }

                    sb.Append(icebox.ToString());
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l' style='text-align:right'>");
                    try
                    {
                        carton = Convert.ToInt32(row["CartonsReturned"]);
                    }
                    catch { carton = 0; }
                    sb.Append(carton.ToString());
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l' style='text-align:right'>");
                    try
                    {
                        other = Convert.ToInt32(row["OtherReturned"]);
                    }
                    catch { other = 0; }
                    sb.Append(other.ToString());
                    sb.Append("</td>");

                    sb.Append("</tr>");

                }
                sb.Append("<tr style='border-bottom:1px solid'>");


                sb.Append("<td class='tg-yw4l'  style='text-align:left'>");
                sb.Append("<b>Total</b>");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l' colspan='2' style='text-align:center'>");
                sb.Append("<b>"+count+"</b>");
                sb.Append("</td>");

          

                sb.Append("<td class='tg-yw4l'  style='text-align:right'>");
                sb.Append("<b>Trays</b>");
                sb.Append("</td>");



                sb.Append("<td class='tg-yw4l'   style='text-align:right'>");
                sb.Append("<b>IceBox</b>");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l'  style='text-align:right'>");
                sb.Append("<b>Cartons</b>");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l'  style='text-align:right'>");
                sb.Append("<b>Other</b>");
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