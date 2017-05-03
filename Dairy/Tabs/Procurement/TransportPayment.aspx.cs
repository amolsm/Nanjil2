using Bussiness;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dairy.Tabs.Procurement
{
    public partial class TransportPayment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtStartDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                txtEndDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
            }
        }

        protected void btnGeneratereport_Click(object sender, EventArgs e)
        {
            Model.MTransportPayment p = new Model.MTransportPayment();
            BTransportpayment pd = new BTransportpayment();

            //p.Startdate = Convert.ToDateTime(txtStartDate.Text).ToString("dd-MM-yyyy");
            //p.Enddate = Convert.ToDateTime(txtEndDate.Text).ToString("dd-MM-yyyy");
            p.Startdate = Convert.ToDateTime(txtStartDate.Text);
            p.Enddate = Convert.ToDateTime(txtEndDate.Text);
            p.Vehicletype = dpVehicletype.SelectedItem.Text;
            DataSet DS = new DataSet();
            DS = pd.TransportPaymentDetails(p);
            string result = string.Empty;
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("<style type='text / css'>");
                sb.Append(".tg  { border - collapse:collapse; border - spacing:0; border: none; } .dispnone {display:none;} ");
                sb.Append("</style>");
                sb.Append("<table class='tg style1' style='page-break-inside:avoid; align:center;'>");
                sb.Append("<colgroup>");
                sb.Append("<col style = 'width:90px'>");
                sb.Append("<col style = 'width:90px'>");
                sb.Append("<col style = 'width:90px'>");
                sb.Append("<col style = 'width:90px'>");
                sb.Append("<col style = 'width:90px'>");
                sb.Append("<col style = 'width:90px'>");
                sb.Append("<col style = 'width:90px'>");
                sb.Append("<col style = 'width:90px'>");
                sb.Append("<col style = 'width:90px'>");

                sb.Append("</colgroup>");

                sb.Append("<tr>");
                sb.Append("<th class='tg-yw4l' rowspan='2'>");
                sb.Append("<img src='/Theme/img/logo1.png' class='img-circle' alt='Logo' width='50px' hight='50px'>");
                sb.Append("</th>");

                sb.Append("<th class='tg-baqh' colspan='6' style='text-align:center'>");
                sb.Append("<b>Nanjil Milk Collection Centre,  Mulagumoodu, K.K.Dt.</b>");

                sb.Append("</th colspan='3'>");

                sb.Append("<th class='tg-yw4l' style='text-align:right'>");

                sb.Append("TIN:330761667331<br>");
                sb.Append("</th>");
                sb.Append("</tr>");

                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append("<td class='tg-yw4l' colspan='6' style='text-align:center'>");
                sb.Append("<u>Vehiclewise Opereation Report</u> <br/>");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l' style='text-align:right'>");
                sb.Append("PH:248370,248605");
                sb.Append("</td>");
                //sb.Append("<td></td>");
                //sb.Append("<td></td>");

                sb.Append("</tr>");
                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append(" <td colspan='3' style='text-align:left'>");
                sb.Append("Date : " + DateTime.Now.ToString());
                sb.Append("</td>");

                sb.Append("<td colspan='3'>");
                sb.Append("<b>Vehicle Type:</b> " + dpVehicletype.SelectedItem.Text.ToString());
                //+ "&nbsp;" + DS.Tables[1].Rows[0]["VehicleType"].ToString());
                sb.Append("</td>");

                sb.Append("<td style='text-align:right'>");
                sb.Append(Convert.ToDateTime(txtStartDate.Text).ToString("dd-MM-yyyy"));
                sb.Append("</td>");
                sb.Append("<td  style='text-align:right'>");
                sb.Append(Convert.ToDateTime(txtEndDate.Text).ToString("dd-MM-yyyy"));
                sb.Append("</td>");
                sb.Append("</tr>");
                sb.Append("<tr style='border-bottom:1px solid'>");

                sb.Append("<td style='text-align:left'>");
                sb.Append("<b>Vehicle No</b>");
                sb.Append("</td>");
                sb.Append("<td style='text-align:left'>");
                sb.Append("<b>Owner Name</b>");
                sb.Append("</td>");
                sb.Append("<td style='text-align:left'>");
                sb.Append("<b>Acc.No</b>");
                sb.Append("</td>");
                sb.Append("<td style='text-align:left'>");
                sb.Append("<b>Route</b>");
                sb.Append("</td>");
                sb.Append("<td style='text-align:left'>");
                sb.Append("<b>Tot.KMs</b>");
                sb.Append("</td>");
                sb.Append("<td style='text-align:left'>");
                sb.Append("<b>Tot.Amt</b>");
                sb.Append("</td>");
                sb.Append("<td style='text-align:left'>");
                sb.Append("<b>TDS</b>");
                sb.Append("</td>");
                sb.Append("<td style='text-align:left'>");
                sb.Append("<b>Ins.Amt</b>");
                sb.Append("</td>");

                sb.Append("</tr>");
                sb.Append("<tr>");

                int count = 0;
                double totlKm = 0.00;
                double TotKM = 0.00;
                double amt = 0.00;
                double totamt = 0.00;
                double tds = 0.00;
                double tottds = 0.00;
                double insamt = 0.00;
                double totinsamt = 0.00;
                double NetAmt = 0.00;
                foreach (DataRow row in DS.Tables[0].Rows)
                {
                    count++;
                    //sb.Append("<td>");
                    //sb.Append(row["Date"].ToString());
                    //sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append(row["VehicleNo"].ToString());
                    sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append(row["VehicleOwnerName"].ToString());
                    sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append(row["AccountNo"].ToString());
                    sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append(row["RouteID"].ToString());
                    sb.Append("</td>");
                    sb.Append("<td>");
                    try { totlKm = Convert.ToDouble(row["TotalKm"]); }
                    catch { totlKm = 0.00; }
                    TotKM += totlKm;
                    sb.Append(Convert.ToDecimal(totlKm).ToString("0.00"));
                    sb.Append("</td>");
                    sb.Append("</td>");
                    sb.Append("<td style='text-align:left'>");
                    try { amt = Convert.ToDouble(row["Amount"]); }
                    catch { amt = 0.00; }
                    totamt += amt;
                    sb.Append(Convert.ToDecimal(amt).ToString("0.00"));
                    sb.Append("</td>");
                    sb.Append("<td style='text-align:left'>");
                    try { tds = Convert.ToDouble(row["TDS"]); }
                    catch { tds = 0.00; }
                    tottds += tds;
                    sb.Append(Convert.ToDecimal(tds).ToString("0.00"));
                    sb.Append("</td>");

                    sb.Append("<td style='text-align:left'>");
                    try { insamt = Convert.ToDouble(row["InsAmount"]); }
                    catch { insamt = 0.00; }
                    sb.Append(Convert.ToDecimal(insamt).ToString("0.00"));
                    sb.Append("</td>");

                    sb.Append("</tr>");
                }

                sb.Append("<tr style='border-bottom:1px solid'><td colspan='10'></td></tr>");
                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append("<td  style='text-align:left'>");
                sb.Append("<b>Total :</b>");
                sb.Append("</td>");
                sb.Append("<td>");
                sb.Append("<b>" + count + "</b>");
                sb.Append("</td>");
                sb.Append("<td></td>");
                sb.Append("<td></td>");
                sb.Append("<td>");
                sb.Append("<b>" + Convert.ToDecimal(TotKM).ToString("0.00") + "</b>");
                sb.Append("</td>");
                sb.Append("<td>");
                sb.Append("<b>" + Convert.ToDecimal(totamt).ToString("0.00") + "</b>");
                sb.Append("</td>");
                sb.Append("<td>");
                sb.Append("<b>" + Convert.ToDecimal(tottds).ToString("0.00") + "</b>");
                sb.Append("</td>");
                sb.Append("<td>");
                sb.Append("<b>" + Convert.ToDecimal(totinsamt).ToString("0.00") + "</b>");
                sb.Append("</td>");

                sb.Append("<tr style='border-bottom:1px solid'>");
                NetAmt = totamt - tottds - totinsamt;
                sb.Append("<td colspan='6'>");
                sb.Append("</td>");
                sb.Append("<td style= 'text-align:left'>");
                sb.Append("<b>Net Amount :</b>");
                sb.Append("</td>");
                sb.Append("<td>");
                sb.Append("<b>" + Convert.ToDecimal(NetAmt).ToString("0.00") + "</b>");
                sb.Append("</td>");
                sb.Append("</tr>");
                result = sb.ToString();
                Payment.Text = result;

                Session["ctrl"] = pnlPayment;

            }
            else
            {
                result = "No Records Found";
                Payment.Text = result;

            }
            uprouteList.Update();
        }
    }
}