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
    public partial class ConsolidatePaymentSummary : System.Web.UI.Page
    {
        DataSet DS = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDown();
                txtStartDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                txtEndDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }
        public void BindDropDown()
        {
            DS = BindCommanData.BindCommanDropDwon("CenterID ", "CenterCode +' '+CenterName as Name  ", "tbl_MilkCollectionCenter", "IsActive=1 ");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpCenter.DataSource = DS;
                dpCenter.DataBind();
                dpCenter.Items.Insert(0, new ListItem("--All Center  --", "0"));
            }

        }

        protected void btnGeneratereport_Click(object sender, EventArgs e)
        {
            Model.Procurement p = new Model.Procurement();
            ProcurementData pd = new ProcurementData();

            p.CenterID = Convert.ToInt32(dpCenter.SelectedItem.Value);
            p.FomDate = Convert.ToDateTime(txtStartDate.Text);
            p.ToDate = Convert.ToDateTime(txtEndDate.Text);
            //  p.RouteID = Convert.ToInt32(dpRoute.SelectedItem.Value);
            DataSet DS = new DataSet();
            DS = pd.ConsolidatePayementSummary(p);
            string result = string.Empty;
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                try
                {
                    DS.Tables[0].PrimaryKey = new[] { DS.Tables[0].Columns["RouteID"] };
                }
                catch (Exception) { }
                try
                {
                    DS.Tables[2].PrimaryKey = new[] { DS.Tables[2].Columns["RouteID"] };
                }
                catch (Exception) { }
                try
                {
                    DS.Tables[3].PrimaryKey = new[] { DS.Tables[3].Columns["RouteID"] };
                }
                catch (Exception) { }
                try
                {
                    DS.Tables[4].PrimaryKey = new[] { DS.Tables[4].Columns["RouteID"] };
                }
                catch (Exception) { }
                try
                {
                    DS.Tables[0].Merge(DS.Tables[2], false, MissingSchemaAction.Add);
                }
                catch (Exception) { }
                try
                {
                    DS.Tables[0].Merge(DS.Tables[3], false, MissingSchemaAction.Add);
                }
                catch (Exception) { }
                try
                {
                    DS.Tables[0].Merge(DS.Tables[4], false, MissingSchemaAction.Add);
                }
                catch (Exception) { }
                try
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

                    sb.Append("</colgroup>");

                    sb.Append("<tr>");
                    sb.Append("<th class='tg-yw4l' rowspan='2'>");
                    sb.Append("<img src='/Theme/img/logo1.png' class='img-circle' alt='Logo' width='50px' hight='50px'>");
                    sb.Append("</th>");

                    sb.Append("<th class='tg-baqh' colspan='7' style='text-align:center'>");
                    sb.Append("<u>Consolidate Payment Summary</u> <br/>");
                    sb.Append("</th>");

                    sb.Append("<th class='tg-yw4l' style='text-align:right'>");

                    sb.Append("GSTIN:&nbsp;33AAECN2463R1Z2<br>");
                    sb.Append("</th>");
                    sb.Append("</tr>");

                    sb.Append("<tr style='border-bottom:1px solid'>");
                    sb.Append("<td class='tg-yw4l' colspan='7' style='text-align:center'>");
                    sb.Append("<b>Nanjil Integrated Dairy Development, Mulagumoodu, K.K.Dt.</b>");

                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l' style='text-align:right'>");

                    sb.Append("PH:248370,248605");

                    sb.Append("</td>");
                    sb.Append("</tr>");
                    sb.Append("<tr style='border-bottom:1px solid'>");
                    sb.Append(" <td colspan='2' style='text-align:left'>");
                    sb.Append("Date : " + DateTime.Now.ToString());
                    sb.Append("</td>");
                    sb.Append("<td colspan='2'>");
                    sb.Append(dpCenter.SelectedItem.Text.ToString());
                    sb.Append("</td>");
                    sb.Append("<td colspan='2' >");
                    sb.Append("");
                    sb.Append("</td>");

                    sb.Append("<td colspan='2' style='text-align:left'>");
                    sb.Append("From : " + Convert.ToDateTime(txtStartDate.Text).ToString("dd-MM-yyyy"));
                    sb.Append("</td>");
                    sb.Append("<td  style='text-align:right'>");
                    sb.Append("To: " + Convert.ToDateTime(txtEndDate.Text).ToString("dd-MM-yyyy"));
                    sb.Append("</td>");
                    sb.Append("</tr>");
                    sb.Append("<tr style='border-bottom:1px solid'>");
                    sb.Append("<td colspan='2' style='text-align:center'>");
                    sb.Append("<b>Route</b>");
                    sb.Append("</td>");
                    sb.Append("<td style='text-align:right'>");
                    sb.Append("<b>MilkInLtr</b>");
                    sb.Append("</td>");
                    sb.Append("<td style='text-align:right'>");
                    sb.Append("<b>Amount</b>");
                    sb.Append("</td>");
                    sb.Append("<td style='text-align:right'>");
                    sb.Append("<b>Scheme</b>");
                    sb.Append("</td>");
                    sb.Append("<td style='text-align:right'>");
                    sb.Append("<b>RD</b>");
                    sb.Append("</td>");
                    sb.Append("<td style='text-align:right'>");
                    sb.Append("<b>Can Loan</b>");
                    sb.Append("</td>");
                    sb.Append("<td style='text-align:right'>");
                    sb.Append("<b>Cash Loan</b>");
                    sb.Append("</td>");
                    sb.Append("<td style='text-align:right'>");
                    sb.Append("<b>Net Amount</b>");
                    sb.Append("</td>");


                    sb.Append("</tr>");
                    sb.Append("<tr>");
                    double milkinlter = 0.00;
                    double scheme = 0.00;
                    double supplierscheme = 0.00;
                    double rd = 0.00;
                    double canloan = 0.00;
                    double casloan = 0.00;
                    double netamt = 0.00;
                    double amt = 0.00;
                    int count = 0;
                    double totalmilkinlter = 0.00;
                    double totalsupplierscheme = 0.00;
                    double totalrd = 0.00;
                    double totalcanloan = 0.00;
                    double totalcasloan = 0.00;
                    double totalnetamt = 0.00;
                    double totalamt = 0.00;
                    foreach (DataRow row in DS.Tables[0].Rows)
                    {

                        foreach (DataRow rows in DS.Tables[1].Rows)
                        {

                            if (row["Category"].ToString() == rows["Category"].ToString())
                            {
                                count++;
                                sb.Append("<td>");
                                sb.Append(row["RouteCode"].ToString());
                                sb.Append("</td>");
                                sb.Append("<td>");
                                sb.Append(row["RouteName"].ToString());
                                sb.Append("</td>");
                                sb.Append("<td style='text-align:right'>");
                                try
                                {
                                    milkinlter = Convert.ToDouble(row["MilkInLtr"]);
                                }
                                catch { milkinlter = 0.00; }
                                sb.Append(Convert.ToDecimal(milkinlter).ToString("0.0"));
                                totalmilkinlter += milkinlter;
                                sb.Append("</td>");
                                sb.Append("<td style='text-align:right'>");
                                try
                                {
                                    amt = Convert.ToDouble(row["Amount"]);
                                }
                                catch { amt = 0.00; }
                                sb.Append(Convert.ToDecimal(amt).ToString("0.00"));
                                totalamt += amt;
                                sb.Append("</td>");
                                sb.Append("<td style='text-align:right'>");
                                try
                                {
                                    scheme = Convert.ToDouble(rows["Scheme"]);
                                }
                                catch { scheme = 0.00; }
                                supplierscheme = scheme * milkinlter;
                                sb.Append(Convert.ToDecimal(supplierscheme).ToString("0.00"));
                                totalsupplierscheme += supplierscheme;
                                sb.Append("</td>");
                                sb.Append("<td style='text-align:right'>");
                                try
                                {
                                    rd = Convert.ToDouble(row["RDAmt"]);
                                }
                                catch { rd = 0.00; }
                                sb.Append(Convert.ToDecimal(rd).ToString("0.00"));
                                totalrd += rd;
                                sb.Append("</td>");
                                sb.Append("<td style='text-align:right'>");

                                try
                                {
                                    canloan = Convert.ToDouble(row["CanLoanPaid"]);
                                }
                                catch { canloan = 0.00; }
                                sb.Append(Convert.ToDecimal(canloan).ToString("0.00"));


                                totalcanloan += canloan;
                                sb.Append("</td>");
                                sb.Append("<td style='text-align:right'>");

                                try
                                {
                                    casloan = Convert.ToDouble(row["CashLoanPaid"]);
                                }
                                catch { casloan = 0.00; }
                                sb.Append(Convert.ToDecimal(casloan).ToString("0.00"));

                                totalcasloan += casloan;
                                sb.Append("</td>");
                                sb.Append("<td style='text-align:right'>");
                                netamt = (amt - (supplierscheme + rd + canloan + casloan));
                                sb.Append(Convert.ToDecimal(netamt).ToString("0.00"));
                                totalnetamt += netamt;
                                sb.Append("</td>");

                                sb.Append("</tr>");
                            }

                        }

                    }
                    sb.Append("<tr style='border-bottom:1px solid'><td colspan='9'></td></tr>");
                    sb.Append("<tr style='border-bottom:1px solid'>");
                    sb.Append("<td  style='text-align:left'>");
                    sb.Append("<b>Total :</b>");
                    sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append("<b>" + count + "</b>");
                    sb.Append("</td>");
                    sb.Append("<td style='text-align:right'>");
                    sb.Append("<b>" + Convert.ToDecimal(totalmilkinlter).ToString("0.00") + "</b>");
                    sb.Append("</td>");
                    sb.Append("<td style='text-align:right'>");
                    sb.Append("<b>" + Convert.ToDecimal(totalamt).ToString("0.00") + "</b>");
                    sb.Append("</td>");
                    sb.Append("<td style='text-align:right'>");
                    sb.Append("<b>" + Convert.ToDecimal(totalsupplierscheme).ToString("0.00") + "</b>");
                    sb.Append("</td>");
                    sb.Append("<td style='text-align:right'>");
                    sb.Append("<b>" + Convert.ToDecimal(totalrd).ToString("0.00") + "</b>");
                    sb.Append("</td>");
                    sb.Append("<td style='text-align:right'>");
                    sb.Append("<b>" + Convert.ToDecimal(totalcanloan).ToString("0.00") + "</b>");
                    sb.Append("</td>");
                    sb.Append("<td style='text-align:right'>");
                    sb.Append("<b>" + Convert.ToDecimal(totalcasloan).ToString("0.00") + "</b>");
                    sb.Append("</td>");
                    sb.Append("<td style='text-align:right'>");
                    sb.Append("<b>" + Convert.ToDecimal(totalnetamt).ToString("0.00") + "</b>");
                    sb.Append("</td>");


                    sb.Append("</tr>");

                    result = sb.ToString();
                    Payment.Text = result;

                    Session["ctrl"] = pnlPayment;
                }

                catch
                {
                    result = "No Records Found";
                    Payment.Text = result;
                }
            }
            else
            {
                result = "No Records Found";
                Payment.Text = result;

            }
            uprouteList.Update();

        }


        protected void dpCenter_SelectedIndexChanged(object sender, EventArgs e)
        {
            //dpRoute.ClearSelection();
            //DS = BindCommanData.BindCommanDropDwon("RouteID ", "RouteCode +' '+RouteName as Name  ", "Proc_MilkCollectionRoute", "IsActive=1 and CenterID=" + dpCenter.SelectedItem.Value);

            //dpRoute.DataSource = DS;
            //dpRoute.DataBind();
            //dpRoute.Items.Insert(0, new ListItem("--Select Route  --", "0"));
        }
    }
}
