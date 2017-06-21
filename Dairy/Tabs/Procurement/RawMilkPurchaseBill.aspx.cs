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
    public partial class RawMilkPurchaseBill : System.Web.UI.Page
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
            DS = BindCommanData.BindCommanDropDwon("RouteID ", "RouteCode +' '+RouteName as Name  ", "Proc_MilkCollectionRoute", "IsActive=1 ");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpRoute.DataSource = DS;
                dpRoute.DataBind();
                dpRoute.Items.Insert(0, new ListItem("--All Route  --", "0"));

               
            }
            DS = BindCommanData.BindCommanDropDwon("SupplierID ", "SupplierCode +' '+SupplierName as Name  ", "Proc_MilkSuppliersProfile", "IsActive=1 ");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpSupplier.DataSource = DS;
                dpSupplier.DataBind();
                dpSupplier.Items.Insert(0, new ListItem("--All Supplier --", "0"));
            }
        }
        protected void btnGeneratereport_Click(object sender, EventArgs e)
        {
            Model.Procurement p = new Model.Procurement();
            ProcurementData pd = new ProcurementData();

            p.RouteID = Convert.ToInt32(dpRoute.SelectedItem.Value);
            p.SupplierID = Convert.ToInt32(dpSupplier.SelectedItem.Value);
            p.FomDate = Convert.ToDateTime(txtStartDate.Text);
            p.ToDate = Convert.ToDateTime(txtEndDate.Text);
            DataSet DS1 = new DataSet();
            DS1 = pd.RawMilkPurchaseBillSummary(p);
            string result = string.Empty;
            if (!Comman.Comman.IsDataSetEmpty(DS1))
            {
                StringBuilder sb = new StringBuilder();


                sb.Append("<style type='text / css'>");
                sb.Append(".tg  { border - collapse:collapse; border - spacing:0; border: none; } .dispnone {display:none;} ");
                sb.Append("</style>");
                sb.Append("<table class='tg style1' style='page-break-inside:avoid; align:center;'>");
                sb.Append("<colgroup>");
                sb.Append("<col style = 'width:125px'>");
                sb.Append("<col style = 'width:125px'>");
                sb.Append("<col style = 'width:125px'>");
                sb.Append("<col style = 'width:125px'>");
                sb.Append("<col style = 'width:125px'>");
                sb.Append("<col style = 'width:125px'>");
                sb.Append("<col style = 'width:125px'>");
                sb.Append("<col style = 'width:125px'>");

                sb.Append("</colgroup>");

                sb.Append("<tr>");
                sb.Append("<th class='tg-yw4l' rowspan='2'>");
                sb.Append("<img src='/Theme/img/logo1.png' class='img-circle' alt='Logo' width='50px' hight='50px'>");
                sb.Append("</th>");

                sb.Append("<th class='tg-baqh' colspan='6' style='text-align:center;font-size: 120%';>");
                if (Session["CollectionCenterLoggedIn"] != null)
                {
                    sb.Append(Session["CollectionCenterLoggedIn"]);
                }
                else
                {
                    sb.Append("<b>Nanjil Integrated Dairy Development, Mulagumoodu, K.K.Dt.</b>");
                }
                sb.Append("</th>");

                sb.Append("<th class='tg-yw4l' style='text-align:right'>");

                sb.Append("<br>");
                sb.Append("</th>");
                sb.Append("</tr>");

                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append("<td class='tg-baqh' colspan='6' style='text-align:center'>");
                sb.Append("<b><u>Raw Milk Purchase Bill Report</u> </b><br/>");
                sb.Append("</td>");

                sb.Append("<td colspan='3' style='text-align:right'>");
                sb.Append("<b>Date :</b>");
                sb.Append(DateTime.Now.ToString());
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l' style='text-align:right'>");

                sb.Append("");

                sb.Append("</td>");
                sb.Append("</tr>");
                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append(" <td colspan='2' style='text-align:left'>");
                sb.Append(dpRoute.SelectedItem.Text.ToString());
                sb.Append("</td>");

                sb.Append(" <td colspan='2' style='text-align:left'>");
                sb.Append(dpSupplier.SelectedItem.Text.ToString());
                sb.Append("</td>");


                sb.Append("<td colspan='2' style='text-align:right'>");
                sb.Append("From : " + Convert.ToDateTime(txtStartDate.Text).ToString("dd-MM-yyyy"));
                sb.Append("</td>");
                sb.Append("<td colspan='2' style='text-align:right'>");
                sb.Append("To : " + Convert.ToDateTime(txtEndDate.Text).ToString("dd-MM-yyyy"));
                sb.Append("</td>");
                sb.Append("</tr>");
              

                    sb.Append("<tr style='border-bottom:1px solid'>");
                    sb.Append("<td colspan='1' style='text-align:center'>");
                    sb.Append("<b>Date</b>");
                    sb.Append("</td>");

                    sb.Append("<td style='text-align:right'>");
                    sb.Append("<b>Session</b>");
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
                    double scheme = 0.00;
                    int can = 0;
                    double RDAmt = 0.00;
                    double LoanAmt = 0.00;
                    double NetAmt = 0.00;
                foreach (DataRow rows in DS1.Tables[1].Rows)
                {
                    sb.Append("<tr style='border-bottom:1px solid'>");
                    sb.Append(" <td colspan='2' style='text-align:left'>");
                    sb.Append((rows["SupplierName"]).ToString());
                    sb.Append("</td>");
                    sb.Append("</tr>");
                    foreach (DataRow row in DS1.Tables[0].Rows)
                    {
                        count++;
                        if (rows["RouteID"].ToString() == row["RouteID"].ToString())
                        {
                            if (rows["SupplierName"].ToString() == row["SupplierName"].ToString())
                            {
                                //sb.Append("<td>");
                                ////sb.Append(row["SupplierCode"].ToString());
                                //sb.Append("</td>");
                                sb.Append("<td style='text-align:center'>");
                                sb.Append(Convert.ToDateTime(row["_Date"]).ToString("dd-MM-yyyy"));
                                sb.Append("</td>");

                                sb.Append("<td style='text-align:right'>");
                                sb.Append((row["_Session"]).ToString());
                                sb.Append("</td>");

                                sb.Append("<td style='text-align:right'>");
                                try { milkinLtr = Convert.ToDecimal(row["MilkInLtr"]); } catch { milkinLtr = 0; }

                                totalmilkinLtr += milkinLtr;
                                sb.Append(Convert.ToDecimal(milkinLtr).ToString("0.0"));
                                sb.Append("</td>");
                                sb.Append("<td style='text-align:right'>");
                                try { fatpercentage = Convert.ToDouble(row["FATPercentage"]); } catch { fatpercentage = 0.00; }

                                totalfatpercentage += fatpercentage;
                                sb.Append(Convert.ToDecimal(fatpercentage).ToString("0.00"));
                                sb.Append("</td>");
                                sb.Append("<td style='text-align:right'>");
                                try { snfpercentage = Convert.ToDouble(row["SNFPercentage"]); } catch { snfpercentage = 0.00; }

                                totalsnfpercentage += snfpercentage;
                                sb.Append(Convert.ToDecimal(snfpercentage).ToString("0.00"));

                                sb.Append("</td>");
                                sb.Append("<td style='text-align:right'>");
                                try { tspercentage = Convert.ToDouble(row["TSPercentage"]); } catch { tspercentage = 0.00; }

                                totaltspercentage += tspercentage;
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

                                try { scheme = Convert.ToDouble(row["Scheme"]); } catch { amt = 0.00; }

                                try { can = Convert.ToInt32(row["Can"]); } catch { amt = 0.00; }

                                try { RDAmt = Convert.ToDouble(row["RDAmount"]); } catch { RDAmt = 0.00; }

                                try { LoanAmt = Convert.ToDouble(row["LoanAmount"]); } catch { LoanAmt = 0.00; }
                                sb.Append("</tr>");
                            }
                        }
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
                    sb.Append("<b>" + totalmilkinLtr + "</b>");
                    sb.Append("</td>");
                    sb.Append("<td style='text-align:right'>");
                    sb.Append("<b>" + Convert.ToDecimal(totalfatpercentage).ToString("0.00") + "</b>");
                    sb.Append("</td>");
                    sb.Append("<td style='text-align:right'>");
                    sb.Append("<b>" + Convert.ToDecimal(totalsnfpercentage).ToString("0.00") + "</b>");
                    sb.Append("</td>");
                    sb.Append("<td style='text-align:right'>");
                    sb.Append("<b>" + Convert.ToDecimal(totaltspercentage).ToString("0.00") + "</b>");
                    sb.Append("</td>");
                    sb.Append("<td style='text-align:right'>");
                    sb.Append("<b>" + Convert.ToDecimal(totalrate).ToString("0.00") + "</b>");
                    sb.Append("</td>");
                    sb.Append("<td style='text-align:right'>");
                    sb.Append("<b>" + Convert.ToDecimal(totalamt).ToString("0.00") + "</b>");
                    sb.Append("</td>");


                    sb.Append("</tr>");
                }
                    sb.Append("<tr>");
                    sb.Append("<td style='text-align:center' colspan = '2'>");
                    sb.Append("<b>Scheme: </b>");
                    sb.Append("<b>" + Convert.ToDecimal(scheme).ToString("0.00") + "</b>");

                    sb.Append("<td style='text-align:right'>");
                    sb.Append("<b>RD: </b>");
                    sb.Append("<b>" + Convert.ToDecimal(RDAmt).ToString("0.00") + "</b>");
                    sb.Append("</td>");

                    sb.Append("<td style='text-align:right'>");
                    sb.Append("<b>Can: </b>");
                    sb.Append("<b>" + Convert.ToDecimal(can).ToString() + "</b>");
                    sb.Append("</td>");

                    sb.Append("<td style='text-align:center' colspan='2'>");
                    sb.Append("<b>Loan: </b>");
                    sb.Append("<b>" + Convert.ToDecimal(LoanAmt).ToString("0.00") + "</b>");
                    sb.Append("</td>");

                    sb.Append("<td style = 'text-align:right' colspan='3'>");
                    sb.Append("<b> NetAmt: </b>");

                    NetAmt = totalamt - LoanAmt - can - RDAmt - scheme;

                    NetAmt = (NetAmt < 0 ? -NetAmt : NetAmt);

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

        protected void dpRoute_SelectedIndexChanged(object sender, EventArgs e)
        {
            dpSupplier.ClearSelection();
            DS = BindCommanData.BindCommanDropDwon("SupplierID ", "SupplierCode +' '+SupplierName as Name  ", "Proc_MilkSuppliersProfile", "IsActive=1 and RouteID=" + dpRoute.SelectedItem.Value);
            
                dpSupplier.DataSource = DS;
                dpSupplier.DataBind();
                dpSupplier.Items.Insert(0, new ListItem("--Select Supplier --", "0"));
            
        }
    }
}