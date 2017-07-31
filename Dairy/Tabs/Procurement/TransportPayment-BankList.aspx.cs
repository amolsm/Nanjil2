using Bussiness;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dairy.Tabs.Procurement
{
    public partial class TransportPayment_BankList : System.Web.UI.Page
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
                if (Session["CollectionCenterLoggedIn"] != null)
                {
                    sb.Append("<b>" + Session["CollectionCenterLoggedIn"].ToString() + "</b>");
                }
                else
                {
                    sb.Append("<b>Nanjil Milk Collection Centre,  Mulagumoodu, K.K.Dt.</b>");
                }
                sb.Append("</th colspan='3'>");

                sb.Append("<th class='tg-yw4l' style='text-align:right'>");

                sb.Append("TIN:330761667331<br>");
                sb.Append("</th>");
                sb.Append("</tr>");

                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append("<td class='tg-yw4l' colspan='6' style='text-align:center'>");
                sb.Append("<u>Transport Payment-BankList Report</u> <br/>");
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
                sb.Append("<b>Sr.No</b>");
                sb.Append("</td>");
                sb.Append("<td style='text-align:left' colspan='2'>");
                sb.Append("<b>Party Name</b>");
                sb.Append("</td>");
                sb.Append("<td style='text-align:left' colspan='2'>");
                sb.Append("<b>IFSC</b>");
                sb.Append("</td>");
                sb.Append("<td style='text-align:left' colspan='2'>");
                sb.Append("<b>Acc.No</b>");
                sb.Append("</td>");
                sb.Append("<td style='text-align:left'>");
                sb.Append("<b>Net Amt</b>");
                sb.Append("</td>");
               
                sb.Append("</tr>");
                sb.Append("<tr>");

                int count = 0;
                double amt = 0.00; 
                double NetAmt = 0.00;
                foreach (DataRow row in DS.Tables[0].Rows)
                {
                    count++;
                    sb.Append("<td>");
                    sb.Append("<b>" + count + "</b>");
                    sb.Append("</td>");
                    sb.Append("<td style='text-align:left' colspan='2'>");
                    sb.Append(row["VehicleOwnerName"].ToString());
                    sb.Append("</td>");
                    sb.Append("<td style='text-align:left' colspan='2'>");
                    sb.Append(row["IFSCCode"].ToString());
                    sb.Append("</td>");
                    sb.Append("<td style='text-align:left' colspan='2'>");
                    sb.Append(row["AccountNo"].ToString());
                    sb.Append("</td>");
                    sb.Append("<td>");
                    try { amt = Convert.ToDouble(row["Amount"]); }
                    catch { amt = 0.00; }
                    NetAmt += amt;
                    sb.Append(Convert.ToDecimal(amt).ToString("0.00"));
                    //sb.Append(row["Amount"].ToString());
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
                sb.Append("<td colspan='4'>");
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

        protected void btnExportinText_Click(object sender, EventArgs e)
        {

            Model.MTransportPayment p = new Model.MTransportPayment();
            BTransportpayment pd = new BTransportpayment();
            p.flag = "Notepad";
            p.Vehicletype = dpVehicletype.SelectedItem.Text;
            p.Startdate = Convert.ToDateTime(txtStartDate.Text);
            p.Enddate = Convert.ToDateTime(txtEndDate.Text);
           
            DataSet DS1 = new DataSet();
            DS1 = pd.TransportPaymentDetails(p);


            //SqlCommand cmd = new SqlCommand(strQuery);
            //DataTable dt = GetData(cmd);

            //Create a dummy GridView
            string result = string.Empty;
            if (!Comman.Comman.IsDataSetEmpty(DS1))
            {

                DataSet DS2 = new DataSet();
               DS2 = pd.TransportPaymentBankListExcel(p);
                GridView GridView1 = new GridView();
                GridView1.ShowHeader = false;
                GridView1.AllowPaging = false;
                GridView1.DataSource = DS2;
                GridView1.DataBind();
                string txt = string.Empty;
                foreach (TableCell cell in GridView1.HeaderRow.Cells)
                {
                    //Add the Header row for Text file.
                    // txt += cell.Text + "\t\t";
                }
                //txt += "\r\n";
                Response.Clear();
                Response.Buffer = true;

                string filename = dpVehicletype.SelectedItem.Text;
                    //DS2.Tables[1].Rows[0]["CenterCode"] + "" + "_" + dpIfscCode.SelectedItem.Text + "" + "_" + DateTime.Now.ToString("dd-MM-yyyy").ToString();

                Response.AddHeader("content-disposition", "attachment;filename= " + filename + ".txt");

                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);

                Response.ContentType = "application/vnd.text";


                foreach (GridViewRow row in GridView1.Rows)
                {

                    foreach (TableCell cell in row.Cells)
                    {
                        //Add the Data rows.
                        txt += cell.Text;
                    }

                    //Add new line.
                    txt += "\r\n";
                }

                Response.Output.Write(txt.ToString());

                Response.End();
            }
            else
            {
                result = "No Records to download";
                Payment.Text = result;
            }
        }

        protected void btnExporttoexcell_Click1(object sender, EventArgs e)
        {

            Model.MTransportPayment p = new Model.MTransportPayment();
            BTransportpayment pd = new BTransportpayment();
            p.flag = "Excel";
            p.Vehicletype = dpVehicletype.SelectedItem.Text;
            p.Startdate = Convert.ToDateTime(txtStartDate.Text);
            p.Enddate = Convert.ToDateTime(txtEndDate.Text);
            DataSet DS1 = new DataSet();
            DS1 = pd.TransportPaymentDetails(p);




            //Create a dummy GridView
            string result = string.Empty;
            if (!Comman.Comman.IsDataSetEmpty(DS1))
            {

                DataSet DS2 = new DataSet();
                DS2 = pd.TransportPaymentBankListExcel(p);
                GridView GridView1 = new GridView();
                GridView1.ShowHeader = true;
                GridView1.AllowPaging = false;
                GridView1.DataSource = DS2;
                GridView1.DataBind();

                Response.Clear();
                Response.Buffer = true;
                string filename = "Demo";
                //string filename = DS2.Tables[1].Rows[0]["CenterCode"] + "" + "_" + dpIfscCode.SelectedItem.Text + "" + "_" + DateTime.Now.ToString("dd-MM-yyyy").ToString();
                //string filename = DS2.Tables[1].Rows[0]["CenterCode"]+"" + "_" + DS2.Tables[0].Rows[0]["IFSCCode"] + "" + "_" + DateTime.Now.ToString("dd-MM-yyyy").ToString();                
                Response.AddHeader("content-disposition", "attachment;filename= " + filename + ".xls");

                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    //Apply text style to each Row                  

                    GridView1.Rows[i].Attributes.Add("class", "textmode");
                }
                GridView1.RenderControl(hw);

                //style to format numbers to string
                string style = @"<style> .textmode { mso-number-format:\@; } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
            else
            {
                result = "No Records to download";
                Payment.Text = result;
            }
        }

    }
}