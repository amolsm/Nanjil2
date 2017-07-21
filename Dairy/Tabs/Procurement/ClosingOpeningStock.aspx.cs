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
    public partial class ClosingOpeningStock : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnreport.Visible = false;
                lblerror.Visible = false;
                txtDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                txtDate1.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                txtDate2.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
            }
        }

        protected void txtDate_TextChanged(object sender, EventArgs e)
        {
            ProcurementData pd = new ProcurementData();
            DataSet DS = new DataSet();
            Model.Procurement p = new Model.Procurement();
            p.ToDate = Convert.ToDateTime(txtDate.Text);
            p.flag1 = "Text";
            DS = pd.ClosingStock(p);

            if (DS.Tables[0].Rows.Count > 0)
            {
                btnUpdate.Enabled = true;
                foreach (DataRow row in DS.Tables[0].Rows)
                {
                    txtmorning.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Morningcollection"].ToString()) ? "0.00" : DS.Tables[0].Rows[0]["Morningcollection"].ToString();
                    txtevening.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["eveningcollection"].ToString()) ? "0.00" : DS.Tables[0].Rows[0]["eveningcollection"].ToString();
                    txtreceived.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Receivedcollection"].ToString()) ? "0.00" : DS.Tables[0].Rows[0]["Receivedcollection"].ToString();
                    txtdisposal.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Disposalcollection"].ToString()) ? "0.00" : DS.Tables[0].Rows[0]["Disposalcollection"].ToString(); ;
                    txtclosing.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["closingstock"].ToString()) ? "0.00" : DS.Tables[0].Rows[0]["closingstock"].ToString();
                    txtopen.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["OpeningStock"].ToString()) ? "0.00" : DS.Tables[0].Rows[0]["OpeningStock"].ToString();
                    txttotalmilk.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["TotalMilkCollection"].ToString()) ? "0.00" : DS.Tables[0].Rows[0]["TotalMilkCollection"].ToString();
                    txtinput.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["adjustment"].ToString()) ? "0.00" : DS.Tables[0].Rows[0]["adjustment"].ToString();
                }

            }
            else
            {
                txtmorning.Text = "0.00";
                txtevening.Text = "0.00";
                txtreceived.Text = "0.00";
                txtdisposal.Text = "0.00";
                txtclosing.Text = "0.00";
                txtopen.Text = "0.00";
                txttotalmilk.Text = "0.00";
                txtinput.Text = "0.00";

            }

        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            ProcurementData pd = new ProcurementData();
            DataSet DS = new DataSet();
            Model.Procurement p = new Model.Procurement();
            p.ToDate = Convert.ToDateTime(txtDate.Text);
            p.flag1 = "Text";
            DS = pd.ClosingStock(p);

            if (DS.Tables[0].Rows.Count > 0)
            {
                p.ToDate = Convert.ToDateTime(txtDate.Text);
                p.abjust = txtinput.Text;
                int Result = 0;
                Result = pd.UpdateStock(p);
                if (Result > 0)
                {

                    divDanger.Visible = false;
                    divwarning.Visible = false;
                    divSusccess.Visible = true;
                    lblSuccess.Text = "Stock Record Add  Successfully";
                    pnlError.Update();
                    upMain.Update();
                    //uprouteList.Update();
                }
                else
                {
                    divDanger.Visible = false;
                    divwarning.Visible = true;
                    divSusccess.Visible = false;
                    lblwarning.Text = "Please Contact to Site Admin";
                    pnlError.Update();

                }
            }

            else
            {
                lblerror.Visible = true;
            }
        }
        protected void btnView_Click(object sender, EventArgs e)
        {
            //if (txtDate1.Text != "" && txtDate2.Text != "")
            //{
            ProcurementData pd = new ProcurementData();
            DataSet DS1 = new DataSet();
            Model.Procurement p = new Model.Procurement();
            p.ToDate1 = Convert.ToDateTime(txtDate1.Text);
            p.ToDate2 = Convert.ToDateTime(txtDate2.Text);
            p.flag1 = "Date";
            string result = string.Empty;
            DS1 = pd.ClosingStock(p);
            if (!Comman.Comman.IsDataSetEmpty(DS1))
            {
                btnreport.Visible = true;
                StringBuilder sb = new StringBuilder();

                sb.Append("<style type='text / css'>");
                sb.Append(".tg  { border-collapse:collapse; border-spacing:0; border:none; } .dispnone {display:none;} .control-sidebar{display:none;} ");
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
                sb.Append("<th class='tg-yw4l' rowspan='1'>");
                sb.Append("<img src='/Theme/img/logo1.png' class='img-circle' alt='Logo' width='50px' hight='50px'>");
                sb.Append("</th>");

                sb.Append("<th class='tg-baqh' colspan='7' style='text-align:center'>");
                sb.Append("<b>Nanjil Milk Collection Centre,  Mulagumoodu, K.K.Dt.</b>");

                sb.Append("</th colspan='7'>");

                sb.Append("<th class='tg-yw4l' >");

                sb.Append("GSTIN:&nbsp;33AAECN2463R1Z2<br>");
                sb.Append("</th>");
                sb.Append("</tr>");

                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append("<th class='tg-yw4l' rowspan='1'>");
                sb.Append("</th>");
                sb.Append("<td class='tg-yw4l' colspan='7' style='text-align:center'>");
                sb.Append("<b><u>Opening/Closing Stock</u></b> <br/>");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l' >");
                sb.Append("<b>PH:248370,248605</b>");
                sb.Append("</td>");

                sb.Append("</tr>");
                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append(" <td colspan='4' style='text-align:left'>");
                sb.Append("<b>Date :</b> " + DateTime.Now.ToString());
                sb.Append("</td>");

                sb.Append("<td colspan='4' style='text-align:right'>");
                sb.Append("<b>From</b>  " +Convert.ToDateTime(txtDate1.Text).ToString("dd-MM-yyyy"));
                sb.Append("</td>");
                sb.Append("<td colspan='2' style='text-align:right'>");
                sb.Append("<b>  To</b>  "+Convert.ToDateTime(txtDate2.Text).ToString("dd-MM-yyyy"));
                sb.Append("</td>");
                //sb.Append("<b>Report Type:</b> Opening/Closing Stock ");
                //+ "&nbsp;" + DS.Tables[1].Rows[0]["VehicleType"].ToString());
                sb.Append("</td>");

                sb.Append("<td style='text-align:right'>");
                //sb.Append(Convert.ToDateTime(txtDate.Text).ToString("dd-MM-yyyy"));
                sb.Append("</td>");
                sb.Append("</tr>");
                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append("<td style='text-align:center' colspan='1'><b>Date</b></td>");
                sb.Append("<td style='text-align:center'><b>Opening Stock</b></td>");
                sb.Append("<td style='text-align:center'><b>Morning Collection</b></td>");
                sb.Append("<td style='text-align:center'><b>Evening Collection</b></td>");
                sb.Append("<td style='text-align:center'><b>Received Collection</b></td>");
                sb.Append("<td style='text-align:center'><b>Disposal Collection</b></td>");
                sb.Append("<td style='text-align:center'><b>Closing Stock</b></td>");
                sb.Append("<td style='text-align:center'><b>Total Milk Collection</b></td>");
                sb.Append("<td style='text-align:center'><b>Adjustment</b></td>");
                sb.Append("</tr>");
                sb.Append("<tr>");

                int count = 0;
                double morning = 0.00;
                double Totmornig = 0.00;
                double evening = 0.00;
                double Totevening = 0.00;
                double received = 0.00;
                double Totreceived = 0.00;
                double disposal = 0.00;
                double Totdisposal = 0.00;
                double closing = 0.00;
                double Totclosing = 0.00;
                double opening = 0.00;
                double Totopening = 0.00;
                double milk = 0.00;
                double Totmilk = 0.00;
                double adjust = 0.00;
                double Totadjust = 0.00;
                foreach (DataRow row in DS1.Tables[0].Rows)
                {

                    count++;
                    sb.Append("<td style = 'text-align:center' colspan='1'>");
                    sb.Append(Convert.ToDateTime(row["Date"]).ToString("dd-MM-yyyy"));
                    sb.Append("</td>");
                    sb.Append("<td style = 'text-align:center'>");
                    try { opening = Convert.ToDouble(row["OpeningStock"]); }
                    catch { opening = 0.00; }
                    Totopening += opening;
                    sb.Append(opening);
                    sb.Append("</td>");
                    sb.Append("<td style = 'text-align:center'>");
                    try { morning = Convert.ToDouble(row["Morningcollection"]); }
                    catch { morning = 0.00; }
                    Totmornig += morning;
                    sb.Append(morning);
                    sb.Append("</td>");
                    sb.Append("<td style = 'text-align:center'>");
                    try { evening = Convert.ToDouble(row["eveningcollection"]); }
                    catch { evening = 0.00; }
                    Totevening += evening;
                    sb.Append(evening);
                    sb.Append("</td>");
                    sb.Append("<td style = 'text-align:center'>");
                    try { received = Convert.ToDouble(row["Receivedcollection"]); }
                    catch { received = 0.00; }
                    Totreceived += received;
                    sb.Append(received);
                    sb.Append("</td>");
                    sb.Append("<td style = 'text-align:center'>");
                    try { disposal = Convert.ToDouble(row["Disposalcollection"]); }
                    catch { disposal = 0.00; }
                    Totdisposal += disposal;
                    sb.Append(disposal);
                    sb.Append("</td>");
                    sb.Append("<td style = 'text-align:center'>");
                    try { closing = Convert.ToDouble(row["closingstock"]); }
                    catch { closing = 0.00; }
                    Totclosing += closing;
                    sb.Append(closing);
                    sb.Append("</td>");
                    sb.Append("<td style = 'text-align:center'>");
                    try { milk = Convert.ToDouble(row["TotalMilkCollection"]); }
                    catch { milk = 0.00; }
                    Totmilk += milk;
                    sb.Append(milk);
                    sb.Append("<td style = 'text-align:center'>");
                    try { adjust = Convert.ToDouble(row["adjustment"]); }
                    catch { adjust = 0.00; }
                    Totadjust += adjust;
                    sb.Append(adjust);
                    sb.Append("</td>");
                    sb.Append("</tr>");
                }
                sb.Append("<tr style='border-bottom:1px solid'><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td></tr>");
                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append("<td style='text-align:center;' colspan='1'>");
                sb.Append("<b>Total :</b>");
                sb.Append("<b>" + count + "</b>");
                sb.Append("</td>");
                sb.Append("<td style='text-align:center; '><b>" + Totopening + "</b></td>");
                sb.Append("<td style='text-align:center; '><b>" + Totmornig + "</b></td>");
                sb.Append("<td style='text-align:center; '><b>" + Totevening + "</b></td>");
                sb.Append("<td style='text-align:center; '><b>" + Totreceived + "</b></td>");
                sb.Append("<td style='text-align:center; '><b>" + Totdisposal + "</b></td>");
                sb.Append("<td style='text-align:center; '><b>" + Totclosing + "</b></td>");
                sb.Append("<td style='text-align:center; '><b>" + Totmilk + "</b></td>");
                sb.Append("<td style='text-align:center; '><b>" + Totadjust + "</b></td>");
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
        }
    }
}