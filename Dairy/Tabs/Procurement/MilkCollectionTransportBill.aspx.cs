using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Bussiness;
using System.Text;

namespace Dairy.Tabs.Procurement
{
    public partial class MilkCollectionTransportBill : System.Web.UI.Page
    {
        DataSet DS = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDown();
                txtStartDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                txtEndDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
            }
        }
        protected void BindDropDown()
        {

            DS = BindCommanData.BindCommanDropDwon("VehicleMasterID ", "VehicleNo", "Proc_VehicleMaster", "IsActive=1 Order by VehicleNo Asc");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpVehicleNo.DataSource = DS;
                dpVehicleNo.DataBind();
                dpVehicleNo.Items.Insert(0, new ListItem("--Select Vehicle No.  --", "0"));
            }
        }
        protected void btnGeneratereport_Click(object sender, EventArgs e)
        {
            Model.Procurement p = new Model.Procurement();
            ProcurementData pd = new ProcurementData();


            p.FomDate = Convert.ToDateTime(txtStartDate.Text);
            p.ToDate = Convert.ToDateTime(txtEndDate.Text);
            p.VehicleNo = dpVehicleNo.SelectedItem.Text;
            DataSet DS = new DataSet();
            DS = pd.MilkCollectionTransportBill(p);
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



                sb.Append("</colgroup>");

                sb.Append("<tr>");
                sb.Append("<th class='tg-yw4l' rowspan='2'>");
                sb.Append("<img src='/Theme/img/logo1.png' class='img-circle' alt='Logo' width='50px' hight='50px'>");
                sb.Append("</th>");

                sb.Append("<th class='tg-baqh' colspan='5' style='text-align:center'>");
                if (Session["CollectionCenterLoggedIn"] != null)
                {
                    sb.Append("<b>" + Session["CollectionCenterLoggedIn"].ToString() + "</b>");
                }
                else
                {
                    sb.Append("<b>Nanjil Milk Collection Centre,Naguneri</b>");
                }
                    sb.Append("</th>");

                sb.Append("<th class='tg-yw4l' style='text-align:right'>");

                sb.Append("TIN:330761667331<br>");
                sb.Append("</th>");
                sb.Append("</tr>");

                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append("<td class='tg-yw4l' colspan='5' style='text-align:center'>");
                sb.Append("<u>Milk Collection Transporting Bill</u> <br/>");

                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l' style='text-align:right'>");

                sb.Append("PH:248370,248605");

                sb.Append("</td>");
                sb.Append("</tr>");
                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append(" <td colspan='2' style='text-align:left'>");
                sb.Append("Date : " + DateTime.Now.ToString());
                sb.Append("</td>");

                sb.Append("<td colspan='3'>");
                sb.Append(dpVehicleNo.SelectedItem.Text.ToString() + "&nbsp;" + DS.Tables[1].Rows[0]["VehicleType"].ToString());
                sb.Append("</td>");
                sb.Append("<td>");
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
                sb.Append("<td colspan='2' style='text-align:center'>");
                sb.Append("<b>Route</b>");
                sb.Append("</td>");
                sb.Append("<td style='text-align:right'>");
                sb.Append("<b>KM.</b>");
                sb.Append("</td>");
                sb.Append("<td style='text-align:right'>");
                sb.Append("<b>Amount</b>");
                sb.Append("</td>");
                sb.Append("<td style='text-align:right'>");
                sb.Append("<b>Bata</b>");
                sb.Append("</td>");
                sb.Append("<td style='text-align:right'>");
                sb.Append("<b>Total Amount</b>");
                sb.Append("</td>");




                sb.Append("</tr>");
                sb.Append("<tr>");

                double amt = 0.00;
                int count = 0;

                double km = 0.00;
                double totalkm = 0.00;
                double bata = 0.00;
                double totalbata = 0.00;
                double totalamt = 0.00;
                double totalnetamt = 0.00;
                double netamt = 0.00;
                foreach (DataRow row in DS.Tables[0].Rows)
                {
                    count++;

                    sb.Append("<td style='text-align:left'>");
                    sb.Append(Convert.ToDateTime(row["Date"]).ToString("dd-MM-yyyy"));
                    sb.Append("</td>");
                    sb.Append("<td>");
                    //sb.Append(row["RouteCode"].ToString());
                    sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append(row["RouteName"].ToString());
                    sb.Append("</td>");
                    sb.Append("<td style='text-align:right'>");
                    try { km = Convert.ToDouble(row["TotalKM"]); }
                    catch { km = 0.00; }
                    totalkm += km;
                    sb.Append(Convert.ToDecimal(km).ToString("0.00"));
                    sb.Append("</td>");

                    sb.Append("<td style='text-align:right'>");
                    try { amt = Convert.ToDouble(row["Amount"]); }
                    catch { amt = 0.0; }
                    totalamt += amt;
                    sb.Append(Convert.ToDecimal(amt).ToString("0.00"));

                    sb.Append("</td>");
                    sb.Append("<td style='text-align:right'>");
                    try { bata = Convert.ToDouble(row["Bata"]); }
                    catch { bata = 0; }
                    totalbata += bata;
                    sb.Append(Convert.ToDecimal(bata).ToString("0.00"));

                    sb.Append("</td>");
                    sb.Append("<td style='text-align:right'>");
                    netamt = amt + bata;
                    totalnetamt += netamt;
                    sb.Append(Convert.ToDecimal(netamt).ToString("0.00"));


                    sb.Append("</td>");


                    sb.Append("</tr>");
                }
                sb.Append("<tr style='border-bottom:1px solid'><td colspan='8'></td></tr>");
                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append("<td colspan='2' style='text-align:left'>");
                sb.Append("<b>Total :</b>");
                sb.Append("</td>");
                sb.Append("<td>");
                sb.Append("<b>" + count + "</b>");
                sb.Append("</td>");
                sb.Append("<td style='text-align:right'>");
                sb.Append("<b>" + Convert.ToDecimal(totalkm).ToString("0.0") + "</b>");
                sb.Append("</td>");
                sb.Append("<td style='text-align:right'>");
                sb.Append("<b>" + Convert.ToDecimal(totalamt).ToString("0.00") + "</b>");
                sb.Append("</td>");
                sb.Append("<td style='text-align:right'>");
                sb.Append("<b>" + Convert.ToDecimal(totalbata).ToString("0.00") + "</b>");
                sb.Append("</td>");
                sb.Append("<td style='text-align:right'>");
                sb.Append("<b>" + Convert.ToDecimal(totalnetamt).ToString("0.00") + "</b>");
                sb.Append("</td>");

                sb.Append("</tr>");
                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append("<td colspan='3' style='text-align:left'> <b>Driver Name: " + DS.Tables[1].Rows[0]["VehicleOwnerName"].ToString()+"</b></td>");
                sb.Append("<td colspan='3' style='text-align:left'> <b>A/c.No: " + DS.Tables[1].Rows[0]["AccountNo"].ToString() + "</b></td>");
                sb.Append("<td colspan='3' style='text-align:right'><b> IFSC: " + DS.Tables[1].Rows[0]["IFSCCode"].ToString() + "</b> </td>");
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
