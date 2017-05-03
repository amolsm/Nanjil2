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
    public partial class VehiclewiseOperationStatementReport : System.Web.UI.Page
    {
        DataSet DS = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDown();
                txtStartDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                txtEndDate.Text= DateTime.Now.ToString("yyyy-MM-dd");
            }
        }
        protected void BindDropDown()
        {

            DS = BindCommanData.BindCommanDropDwon("VehicleMasterID ", "VehicleNo", "Proc_VehicleMaster", "IsActive=1 ");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpVehicleNo.DataSource = DS;
                dpVehicleNo.DataBind();
                dpVehicleNo.Items.Insert(0, new ListItem("--Select All Vehicle No.  --", "0"));
            }
        }
        protected void btnGeneratereport_Click(object sender, EventArgs e)
        {
            Model.Procurement p = new Model.Procurement();
            ProcurementData pd = new ProcurementData();


            p.FomDate = Convert.ToDateTime(txtStartDate.Text);
            p.ToDate = Convert.ToDateTime(txtEndDate.Text);
            if (Convert.ToInt32(dpVehicleNo.SelectedItem.Value)==0)
            {
                p.VehicleNo = "0";
            }
            else
            {
                p.VehicleNo = dpVehicleNo.SelectedItem.Text;
            }
           
            DataSet DS = new DataSet();
            DS = pd.VehiclewiseOperationStatementReport(p);
            string result = string.Empty;
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                StringBuilder sb = new StringBuilder();


                sb.Append("<style type='text / css'>");
                sb.Append(".tg  { border - collapse:collapse; border - spacing:0; border: none; } .dispnone {display:none;} ");
                sb.Append("</style>");
                sb.Append("<table class='tg style1' style='page-break-inside:avoid; align:center;'>");
                sb.Append("<colgroup>");
                sb.Append("<col style = 'width:100px'>");
                sb.Append("<col style = 'width:100px'>");
                sb.Append("<col style = 'width:100px'>");
                sb.Append("<col style = 'width:100px'>");
                sb.Append("<col style = 'width:100px'>");
                sb.Append("<col style = 'width:100px'>");
                sb.Append("<col style = 'width:100px'>");
                sb.Append("<col style = 'width:100px'>");
                sb.Append("<col style = 'width:100px'>");
                sb.Append("<col style = 'width:100px'>");
                sb.Append("<col style = 'width:100px'>");
                sb.Append("<col style = 'width:100px'>");
                sb.Append("<col style = 'width:100px'>");
                sb.Append("<col style = 'width:100px'>");
                sb.Append("</colgroup>");

                sb.Append("<tr>");
                sb.Append("<th class='tg-yw4l' rowspan='2'>");
                sb.Append("<img src='/Theme/img/logo1.png' class='img-circle' alt='Logo' width='50px' hight='50px'>");
                sb.Append("</th>");

                sb.Append("<th class='tg-baqh' colspan='12' style='text-align:center'>");
                sb.Append("<b>Nanjil Milk Collection Centre,  Mulagumoodu, K.K.Dt.</b>");

                sb.Append("</th colspan='3'>");

                sb.Append("<th class='tg-yw4l' style='text-align:right'>");

                sb.Append("TIN:330761667331<br>");
                sb.Append("</th>");
                sb.Append("</tr>");

                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append("<td class='tg-yw4l' colspan='12' style='text-align:center'>");
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

                sb.Append("<td colspan='9'>");
                //sb.Append(dpVehicleNo.SelectedItem.Text.ToString() + "&nbsp;" + DS.Tables[1].Rows[0]["VehicleType"].ToString());
                sb.Append("</td>");
                //sb.Append("<td></td>");
                //sb.Append("<td></td>");
                //sb.Append("<td></td>");
                sb.Append("<td style='text-align:right'>");
                sb.Append(Convert.ToDateTime(txtStartDate.Text).ToString("dd-MM-yyyy"));
                sb.Append("</td>");
                sb.Append("<td  style='text-align:right'>");
                sb.Append(Convert.ToDateTime(txtEndDate.Text).ToString("dd-MM-yyyy"));
                sb.Append("</td>");
                sb.Append("</tr>");
                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append("<td  style='text-align:left'>");
                sb.Append("<b>Date</b>");
                sb.Append("</td>");
                //sb.Append("<td colspan='2' style='text-align:center'>");
                //sb.Append("<b>Route</b>");
                //sb.Append("</td>");

                sb.Append("<td style='text-align:left'>");
                sb.Append("<b>Vehicle No</b>");
                sb.Append("</td>");

                sb.Append("<td style='text-align:left'>");
                sb.Append("<b>Route</b>");
                sb.Append("</td>");

                sb.Append("<td style='text-align:left'>");
                sb.Append("<b>MornIn</b>");
                sb.Append("</td>");
                sb.Append("<td style='text-align:left'>");
                sb.Append("<b>MornOut</b>");
                sb.Append("</td>");
                sb.Append("<td style='text-align:left'>");
                sb.Append("<b>EveIn</b>");
                sb.Append("</td>");
                sb.Append("<td style='text-align:left'>");
                sb.Append("<b>EveOut</b>");
                sb.Append("</td>");
                sb.Append("<td style='text-align:left'>");
                sb.Append("<b>MornCanIn</b>");
                sb.Append("</td>");
                sb.Append("<td style='text-align:left'>");
                sb.Append("<b>MornCanOut</b>");
                sb.Append("</td>");
                sb.Append("<td style='text-align:left'>");
                sb.Append("<b>EveCanIn</b>");
                sb.Append("</td>");
                sb.Append("<td style='text-align:left'>");
                sb.Append("<b>EveCanOut</b>");
                sb.Append("</td>");
                sb.Append("<td style='text-align:left'>");
                sb.Append("<b>MornKm</b>");
                sb.Append("</td>");
                sb.Append("<td style='text-align:left'>");
                sb.Append("<b>EveKm</b>");
                sb.Append("</td>");
                sb.Append("<td style='text-align:left'>");
                sb.Append("<b>Amount</b>");
                sb.Append("</td>");
                //sb.Append("<td style='text-align:center'>");
                //sb.Append("<b>Remark</b>");
                //sb.Append("</td>");
                sb.Append("</tr>");
                sb.Append("<tr>");

                int count = 0;
                double MornKm = 0.00;
                double totMornKm = 0.00;
                double EveKm = 0.00;
                double totEveKm = 0.00;
                double Amt = 0.00;
                double totAmt = 0.00;
                foreach (DataRow row in DS.Tables[0].Rows)
                {
                    count++;
                    sb.Append("<td style='text-align:left'>");
                    sb.Append(Convert.ToDateTime(row["Date"]).ToString("dd-MM-yyyy"));
                    sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append(row["VehicleNo"].ToString());
                    sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append(row["RouteName"].ToString());
                    sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append(row["MorningInTime"].ToString());
                    sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append(row["MorningOutTime"].ToString());
                    sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append(row["EveningInTime"].ToString());
                    sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append(row["EveningOutTime"].ToString());
                    sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append(row["MorningInCan"].ToString());
                    sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append(row["MorningOutCan"].ToString());
                    sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append(row["EveningInCan"].ToString());
                    sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append(row["EveningOutCan"].ToString());
                    sb.Append("</td>");
                    sb.Append("<td>");
                    try { MornKm = Convert.ToDouble(row["MorningKM"]); }
                    catch { MornKm = 0.00; }
                    totMornKm += MornKm;
                    sb.Append(Convert.ToDecimal(MornKm).ToString("0.00"));
                    sb.Append("</td>");
                    sb.Append("<td>");
                    try { EveKm = Convert.ToDouble(row["EveningKM"]); }
                    catch { EveKm = 0.00; }
                    totEveKm += EveKm;
                    sb.Append(Convert.ToDecimal(EveKm).ToString("0.00"));
                    sb.Append("</td>");
                    sb.Append("<td>");
                    try { Amt = Convert.ToDouble(row["Amount"]); }
                    catch { Amt = 0.00; }
                    totAmt += Amt;
                    sb.Append(Convert.ToDecimal(Amt).ToString("0.00"));
                    sb.Append("</td>");
                    //sb.Append("<td style='text-align:center'>");
                    //sb.Append(row["Remarks"].ToString());
                    //sb.Append("</td>");

                    sb.Append("</tr>");
                }

                sb.Append("<tr style='border-bottom:1px solid'><td colspan='14'></td></tr>");
                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append("<td colspan='2' style='text-align:left'>");
                sb.Append("<b>Total :</b>");
                sb.Append("</td>");
                sb.Append("<td colspan='9'>");
                sb.Append("<b>" + count + "</b>");
                sb.Append("</td>");
                //sb.Append("<td></td>");
                //sb.Append("<td></td>");
                //sb.Append("<td></td>");
                //sb.Append("<td></td>");
                //sb.Append("<td></td>");
                //sb.Append("<td></td>");

                sb.Append("<td style='text-align:left'>");
                sb.Append("<b>" + Convert.ToDecimal(totMornKm).ToString("0.00") + "</b>");
                sb.Append("</td>");
                sb.Append("<td style='text-align:left'>");
                sb.Append("<b>" + Convert.ToDecimal(totEveKm).ToString("0.00") + "</b>");
                sb.Append("</td>");
                sb.Append("<td style='text-align:left'>");
                sb.Append("<b>" + Convert.ToDecimal(totAmt).ToString("0.00") + "</b>");
                sb.Append("</td>");
                sb.Append("<td></td>");
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
