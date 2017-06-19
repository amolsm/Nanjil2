using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using Bussiness;
using System.Text;

namespace Dairy.Tabs.Procurement
{
    public partial class Supplierwiserawmilkqtyqlty : System.Web.UI.Page
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
        public void BindDropDown()
        {
            DS = BindCommanData.BindCommanDropDwon("RouteID ", "RouteCode +' '+RouteName as Name  ", "Proc_MilkCollectionRoute", "IsActive=1 ");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpRoute.DataSource = DS;
                dpRoute.DataBind();
                dpRoute.Items.Insert(0, new ListItem("--Select All Route  --", "0"));

            }
        }

        protected void btnGeneratereport_Click(object sender, EventArgs e)
        {
            Model.Procurement p = new Model.Procurement();
            ProcurementData pd = new ProcurementData();

            p.RouteID = Convert.ToInt32(dpRoute.SelectedItem.Value);
            p.FomDate = Convert.ToDateTime(txtStartDate.Text);
            p.ToDate = Convert.ToDateTime(txtEndDate.Text);
            DataSet DS1 = new DataSet();
            DS1 = pd.SupplierWiseMilkqtyandQlty(p);
            string result = string.Empty;
            if (!Comman.Comman.IsDataSetEmpty(DS1))
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

                sb.Append("</colgroup>");

                sb.Append("<tr>");
                sb.Append("<th class='tg-yw4l' rowspan='2'>");
                sb.Append("<img src='/Theme/img/logo1.png' class='img-circle' alt='Logo' width='50px' hight='50px'>");
                sb.Append("</th>");

                sb.Append("<th class='tg-baqh' colspan='6' style='text-align:center;font-size: 120%';>");
                if (Session["CollectionCenterLoggedIn"] != null)
                {
                    sb.Append("<b>" + Session["CollectionCenterLoggedIn"].ToString() + "</b>");
                }
                else
                {
                    sb.Append("<b>Nanjil Integrated Dairy Development, Mulagumoodu, K.K.Dt.</b>");
                    //sb.Append("<b>" + (string.IsNullOrEmpty(DS1.Tables[1].Rows[0]["CenterName"].ToString()) ? string.Empty : DS1.Tables[1].Rows[0]["CenterName"].ToString()) + "</b>"); 
                }
                sb.Append("</th>");

                sb.Append("<th class='tg-yw4l' style='text-align:right'>");

                sb.Append("<br>");
                sb.Append("</th>");
                sb.Append("</tr>");

                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append("<td class='tg-baqh' colspan='6' style='text-align:center'>");
                sb.Append("<b><u>Supplierwise Raw Milk Quantity & Quality Report</u> </b><br/>");

                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l' style='text-align:right'>");

                sb.Append("");

                sb.Append("</td>");
                sb.Append("</tr>");
                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append(" <td colspan='2' style='text-align:left'>");
                string Route="";
                if (dpRoute.SelectedIndex == 0)
                {
                    Route = "All Route";
                    sb.Append(Route);
                }
                else
                {
                   Route=(dpRoute.SelectedItem.Text.ToString());
                    sb.Append(Route);
                }
                sb.Append("</td>");

                sb.Append("<td colspan='3'>");
                sb.Append(DateTime.Now.ToString());
                sb.Append("</td>");
                sb.Append("<td colspan='2' style='text-align:left'>");
                sb.Append("From : " + Convert.ToDateTime(txtStartDate.Text).ToString("dd-MM-yyyy"));
                sb.Append("</td>");
                sb.Append("<td colspan='2' style='text-align:right'>");
                sb.Append("To : " + Convert.ToDateTime(txtEndDate.Text).ToString("dd-MM-yyyy"));
                sb.Append("</td>");
                sb.Append("</tr>");
                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append("<td colspan='2' style='text-align:center'>");
                sb.Append("<b>Supplier</b>");
                sb.Append("</td>");
                sb.Append("<td style='text-align:right'>");
                sb.Append("<b>MilkInLtr</b>");
                sb.Append("</td>");
                sb.Append("<td style='text-align:right'>");
                sb.Append("<b>FAT %</b>");
                sb.Append("</td>");
                sb.Append("<td style='text-align:right'>");
                sb.Append("<b>SNF %</b>");
                sb.Append("</td>");
                sb.Append("<td style='text-align:right'>");
                sb.Append("<b>TS %</b>");
                sb.Append("</td>");
                sb.Append("<td style='text-align:right'>");
                sb.Append("<b>Rate</b>");
                sb.Append("</td>");
                sb.Append("<td style='text-align:right'>");
                sb.Append("<b>Amount</b>");
                sb.Append("</td>");
                sb.Append("</tr>");
                sb.Append("<tr>");
                int count = 0;
                decimal milkinLtr = 0;
                decimal totalmilkinLtr = 0;
                double fatpercentage = 0.00;
                double totalfatpercentage = 0.00;
                double snfpercentage = 0.00;
                double totalsnfpercentage = 0.00;
                double tspercentage = 0.00;
                double totaltspercentage = 0.00;
                double rate = 0.00;
                double totalrate = 0.00;
                double amt = 0.00;
                double totalamt = 0.00;
                double fatkg = 0.00;
                double totfatkg = 0.00;
                double snfkg = 0.00;
                double totsnfkg = 0.00;
                double tskg = 0.00;
                double tottskg = 0.00;
                double milkinkg = 0.00;
                double totmilkinkg = 0.00;
                foreach (DataRow row in DS1.Tables[0].Rows)
                {
                    count++;
                    sb.Append("<td>");
                    sb.Append(row["SupplierCode"].ToString());
                    sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append(row["SupplierName"].ToString());
                    sb.Append("</td>");
                    sb.Append("<td style='text-align:right'>");
                    try { milkinLtr = Convert.ToDecimal(row["MilkInLtr"]); } catch { milkinLtr = 0; }

                    totalmilkinLtr += milkinLtr;

                    try { milkinkg = Convert.ToDouble(row["MilkInKG"]); } catch { milkinkg = 0; }
                    totmilkinkg += milkinkg;
                    sb.Append(Convert.ToDecimal(milkinLtr).ToString("0.0"));
                    sb.Append("</td>");

                    sb.Append("<td style='text-align:right'>");
                    try { fatpercentage = Convert.ToDouble(row["FATPercentage"]); } catch { fatpercentage = 0.00; }

                    totalfatpercentage += fatpercentage;
                    try { fatkg = Convert.ToDouble(row["FATInKG"]); } catch { fatkg = 0; }
                    totfatkg += fatkg;

                    sb.Append(Convert.ToDecimal(fatpercentage).ToString("0.00"));
                    sb.Append("</td>");
                    sb.Append("<td style='text-align:right'>");
                    try { snfpercentage = Convert.ToDouble(row["SNFPercentage"]); } catch { snfpercentage = 0.00; }

                    totalsnfpercentage += snfpercentage;
                    try { snfkg = Convert.ToDouble(row["SNFInKG"]); } catch { snfkg = 0; }
                    totsnfkg += snfkg;

                    sb.Append(Convert.ToDecimal(snfpercentage).ToString("0.00"));

                    sb.Append("</td>");
                    sb.Append("<td style='text-align:right'>");
                    try { tspercentage = Convert.ToDouble(row["TSPercentage"]); } catch { tspercentage = 0.00; }

                    totaltspercentage += tspercentage;

                    try { tskg = Convert.ToDouble(row["TSInKG"]); } catch { tskg = 0; }
                    tottskg += tskg;
                    sb.Append(Convert.ToDecimal(tspercentage).ToString("0.00"));

                    sb.Append("</td>");
                    sb.Append("<td style='text-align:right'>");
                    try { rate = Convert.ToDouble(row["Rate"]); } catch { rate = 0.00; }

                    totalrate += rate;
                    sb.Append(Convert.ToDecimal(rate).ToString("0.00"));


                    sb.Append("</td>");
                    sb.Append("<td style='text-align:right'>");
                    try { amt = Convert.ToDouble(row["Amount"]); } catch { amt = 0.00; }

                    totalamt += amt;
                    sb.Append(Convert.ToDecimal(amt).ToString("0.00"));

                    sb.Append("</td>");

                    sb.Append("</tr>");

                }
                sb.Append("<tr style='border-bottom:1px solid'><td colspan='8'></td></tr>");
                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append("<td colspan='3'>");
                sb.Append("<b>Average</b>");
                sb.Append("</td>");
                sb.Append("<td style='text-align:right'>");
                sb.Append("<b>" + Convert.ToDecimal(totalfatpercentage / count).ToString("0.00") + "</b>");
                sb.Append("</td>");
                sb.Append("<td style='text-align:right'>");
                sb.Append("<b>" + Convert.ToDecimal(totalsnfpercentage / count).ToString("0.00") + "</b>");
                sb.Append("</td>");
                sb.Append("<td style='text-align:right'>");
                sb.Append("<b>" + Convert.ToDecimal(totaltspercentage / count).ToString("0.00") + "</b>");
                sb.Append("</td>");
                sb.Append("<td style='text-align:right'>");
                sb.Append("<b>" + Convert.ToDecimal(totalrate / count).ToString("0.00") + "</b>");
                sb.Append("</td>");
                sb.Append("<td style='text-align:left'>");
                sb.Append("/ Lt.");
                sb.Append("</td>");

                sb.Append("</tr>");
                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append("<td>");
                sb.Append("<b>Total</b>");
                sb.Append("</td>");
                sb.Append("<td>");
                sb.Append("<b>" + count + "</b>");
                sb.Append("</td>");
                sb.Append("<td style='text-align:right'>");
                sb.Append("<b>" + totmilkinkg + "</b>");
                sb.Append("</td>");
                sb.Append("<td style='text-align:right'>");
                sb.Append("<b>" + Convert.ToDecimal(totfatkg).ToString("0.00") + "</b>");
                sb.Append("</td>");
                sb.Append("<td style='text-align:right'>");
                sb.Append("<b>" + Convert.ToDecimal(totalsnfpercentage).ToString("0.00") + "</b>");
                sb.Append("</td>");
                sb.Append("<td style='text-align:right'>");
                sb.Append("<b>" + Convert.ToDecimal(tottskg).ToString("0.00") + "</b>");
                sb.Append("</td>");
                sb.Append("<td style='text-align:right'>");
                sb.Append("<b>" + Convert.ToDecimal(totalrate).ToString("0.00") + "</b>");
                sb.Append("</td>");
                sb.Append("<td style='text-align:right'>");
                sb.Append("<b>" + Convert.ToDecimal(totalamt).ToString("0.00") + "</b>");
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
