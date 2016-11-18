using Bussiness;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dairy.Tabs.Marketing
{
    public partial class BillwiseSalesSummaryforMarketing : System.Web.UI.Page
    {
        BillData billdata = new BillData();
        DataSet DS = new DataSet();
        DataSet DS1 = new DataSet();
        double schemeamount;

     
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                EmployeeData empData = new EmployeeData();
                DS = BindCommanData.BindCommanDropDwon("RouteID ", "RouteCode +' '+RouteName as Name  ", "routeMaster", "IsArchive=1");
                if (!Comman.Comman.IsDataSetEmpty(DS))
                {
                    dpRoute.DataSource = DS;
                    dpRoute.DataBind();
                    dpRoute.Items.Insert(0, new ListItem("-All Route-", "0"));
                }
                DS = BindCommanData.BindCommanDropDwon("AgentID", "AgentCode+' '+AgentName as Name", "AgentMaster", "IsArchive=0 and Agensytype='Agency' Order by AgentCode");
                if (!Comman.Comman.IsDataSetEmpty(DS))
                {
                    dpAgent.DataSource = DS;
                    dpAgent.DataBind();
                    dpAgent.Items.Insert(0, new ListItem("-All Agency-", "0"));

                }
                txtStartDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                txtEndDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
            }
        }

        protected void btngenrateBill_click(object sender, EventArgs e)
        {

            double totalScheme = 0;
            double totalamt = 0;
            double totalboothamt = 0;
            double total = 0;
            string result = string.Empty;
            DS = billdata.MarketingBillwiseSalesSummarybyDate((Convert.ToDateTime(txtStartDate.Text)).ToString("dd-MM-yyyy"), (Convert.ToDateTime(txtEndDate.Text)).ToString("dd-MM-yyyy"), Convert.ToInt32(dpRoute.SelectedItem.Value), Convert.ToInt32(dpAgent.SelectedItem.Value));
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                StringBuilder sb = new StringBuilder();


                sb.Append("<style type='text / css'>");
                sb.Append(".tg  { border - collapse:collapse; border - spacing:0; border: none; }");
                sb.Append(".tg .tg-yw4l{vertical-align:top}");
                sb.Append(".tg .tg-baqh{text-align:center;vertical-align:top}");
                sb.Append("</style>");
                //sb.Append("<table class='tg style1' style='page-break-inside:avoid; align:center;'>");
                sb.Append("<table class='tg style1'  style=' position:relative;align:center;'>");
                sb.Append("<colgroup>");
                sb.Append("<col style = 'width:120px'>");
                sb.Append("<col style = 'width:160px'>");
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

                sb.Append("<th class='tg-baqh' colspan='6' style='text-align:center'>");
                sb.Append("<u>Billwise Sales Summary </u> <br/>");
                sb.Append("</th>");

                sb.Append("<th class='tg-yw4l' style='text-align:right'>");

                sb.Append("TIN:330761667331<br>");
                sb.Append("</th>");
                sb.Append("</tr>");

                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append("<td class='tg-yw4l' colspan='6' style='text-align:center'>");
                sb.Append("<b>Nanjil Integrated Dairy Development, Mulagumoodu, K.K.Dt.</b>");

                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l' style='text-align:right'>");

                sb.Append("PH:248370,248605");

                sb.Append("</td>");

                sb.Append("<tr>");
                sb.Append("<td class='tg-yw4l' colspan='6' style='text-align:left'>");
                sb.Append("Start Date:" + Convert.ToDateTime(txtStartDate.Text).ToString("dd-MM-yyyy"));
                sb.Append("</td>");
                sb.Append("<td class='tg-yw4l' colspan='6' style='text-align:right'>");
                sb.Append("End Date:" + Convert.ToDateTime(txtEndDate.Text).ToString("dd-MM-yyyy"));
                sb.Append("</td>");
                sb.Append("<tr style='border-bottom:2px solid'>");
                sb.Append("<td class='tg-yw4l' colspan='3' style='text-align:left'>");
                if (Convert.ToInt32(dpAgent.SelectedItem.Value) == 0)
                {
                    sb.Append("Agent : " + "All");
                }
                else
                {
                    sb.Append("Agent : " + dpAgent.SelectedItem.Text.ToString());
                }
                sb.Append("</td>");
                sb.Append("<td class='tg-yw4l' colspan='3' style='text-align:middle'>");
                if (Convert.ToInt32(dpRoute.SelectedItem.Value) == 0)
                {
                    sb.Append("Route : " + "All");
                }
                else
                {
                    sb.Append("Route : " + dpRoute.SelectedItem.Text.ToString());
                }
               
                sb.Append("</td>");
                sb.Append("<td class='tg-yw4l' colspan='6'  style='text-align:right'>");
                sb.Append("Date : " + DateTime.Now.ToString());
                sb.Append("</td>");
                sb.Append("</tr>");






                foreach (DataRow row2 in DS.Tables[1].Rows)
                {
                    int count = 0;
                    double totalquantity = 0;
                    sb.Append("<tr style='border-bottom:1px solid' style='page-break-inside:avoid; align:center;'> <td colspan = '9'> &nbsp; </td> </tr>");
                    sb.Append("<tr>");
                    sb.Append("<td>");
                    sb.Append("<b>" + row2["OrderDate"].ToString() + "</b>");
                    sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append("&nbsp;");
                    sb.Append("</td>");
                    sb.Append("<td>");
                    if (row2["OrderType"].ToString() == "1")
                    {
                        sb.Append(row2["AgentCode"].ToString());
                    }
                   
                    sb.Append("</td>");
                    sb.Append("<td>");
                    if (row2["OrderType"].ToString() == "1")
                    {
                        sb.Append(row2["Agent"].ToString());
                    }
                   
                    sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append("&nbsp;");
                    sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append("&nbsp;");
                    sb.Append("</td>");

                    sb.Append("<td style='text-align:right'>");
                    sb.Append("<b>" + "Bill No :" + "</b>");
                    sb.Append("</td>");
                    sb.Append("<td style='text-align:right'>");
                    sb.Append("<b>" + row2["BillNumber"].ToString() + "</b>");
                    sb.Append("</td>");
                    sb.Append("</tr>");
                    sb.Append("<tr style='border-bottom:1px dotted'style='page-break-inside:avoid; align:center;'> <td colspan = '9'></td> </tr>");

                    sb.Append("<tr>");
                    sb.Append("<td class='tg-yw4l'  style='text-align:left'>");
                    sb.Append("<b> </b> ");
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l' colspan='2' style='text-align:left'>");
                    sb.Append("<b>ITEM</b>");
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l' colspan='2' style='text-align:left'>");
                    sb.Append("<b>Rate</b>");
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l'  style='text-align:left'>");
                    sb.Append("<b>Quantity</b>");
                    sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append("<b>Unit Type</b>");
                    sb.Append("</td>");
                    sb.Append("<td class='tg-yw4l'  style='text-align:right'>");
                    sb.Append("<b>Amount</b>");
                    sb.Append("</td>");
                    sb.Append("</tr>");
                    foreach (DataRow row in DS.Tables[0].Rows)
                    {
                        if (row2["BillNumber"].ToString() == row["BillNo"].ToString())
                        {
                            count = count + 1;
                            sb.Append("<tr>");
                            sb.Append("<td class='tg-yw4l'   style='text-align:left'>");
                            sb.Append(row["ProductCode"].ToString());
                            sb.Append("</td>");

                            sb.Append("<td class='tg-yw4l' colspan='2'  style='text-align:left'>");
                            sb.Append(row["ITEM"].ToString());
                            sb.Append("</td>");

                            sb.Append("<td class='tg-yw4l'  style='text-align:left'>");
                            sb.Append((Convert.ToDecimal(row["Rate"]).ToString("#.00")));

                            sb.Append("</td>");
                            sb.Append("<td>");
                            sb.Append("");
                            sb.Append("</td>");
                            sb.Append("<td class='tg-yw4l'  style='text-align:left'>");
                            if (row["totalreturnQuantity"].ToString() == "")
                            {
                                totalquantity += Convert.ToDouble(row["Quantity"]);
                                sb.Append(row["Quantity"].ToString());
                            }
                            else
                            {
                                double quantity = (Convert.ToDouble(row["Quantity"]) - Convert.ToDouble(row["totalreturnQuantity"]));
                                sb.Append(quantity);
                                totalquantity += quantity;
                            }

                            sb.Append("</td>");
                            sb.Append("<td>");
                            sb.Append(row["UnitType"].ToString());
                            sb.Append("</td>");
                            sb.Append("<td class='tg-yw4l'  style='text-align:right'>");
                            if (row["totalreturnAmount"].ToString() == "")
                            {
                                sb.Append((Convert.ToDecimal(row["Amount"]).ToString("#.00")));

                            }
                            else
                            {
                                double amount = (Convert.ToDouble(row["Amount"]) - Convert.ToDouble(row["totalreturnAmount"]));
                                sb.Append((Convert.ToDecimal(amount).ToString("#.00")));

                            }
                            sb.Append("</td>");
                            sb.Append("</tr>");
                        }
                        else { }
                    }
                    DS1 = billdata.GetSchemeAmountForBillwiseSalesSummary(row2["BillNumber"]);
                    if (!Comman.Comman.IsDataSetEmpty(DS1))
                    {
                        sb.Append("<tr>");
                        sb.Append("<td class='tg-yw4l'   style='text-align:left'>");
                        sb.Append("&nbsp;");
                        sb.Append("</td>");
                        sb.Append("<td class='tg-yw4l' colspan='4' style='text-align:left'>");
                        sb.Append("Scheme ");
                        sb.Append("</td>");
                        schemeamount = (Convert.ToDouble(DS1.Tables[0].Rows[0]["SchemeAmount"]));
                        sb.Append("<td class='tg-yw4l' colspan='4'  style='text-align:right'>");
                        sb.Append(schemeamount.ToString("#0.00"));
                        sb.Append("</td>");
                        totalScheme = totalScheme + (Convert.ToDouble(DS1.Tables[0].Rows[0]["SchemeAmount"]));
                    }
                    else
                    {
                        schemeamount = 0.0;
                        totalScheme = totalScheme + 0.0;
                      
                    }

                    sb.Append("<tr style='border-bottom:1px dotted'> <td colspan = '9'> &nbsp; </td> </tr>");
                    sb.Append("<tr style='border-bottom:1px solid'>");
                    sb.Append("<td class='tg-yw4l'   style='text-align:left'>");
                    sb.Append(row2["Salesman"].ToString());
                    sb.Append("</td>");
                    sb.Append("<td class='tg-yw4l'   style='text-align:left'>");
                    sb.Append(count.ToString());
                    sb.Append("</td>");
                    sb.Append("<td class='tg-yw4l' colspan='3'  style='text-align:left'>");
                    sb.Append("Total");
                    sb.Append("</td>");
                    sb.Append("<td class='tg-yw4l'  colspan='2'    style='text-align:left'>");
                    sb.Append(totalquantity.ToString());
                    sb.Append("</td>");
                   
                    double amt = 0;
                    if (row2["totalreturnAmount"].ToString() == "")
                    {
                        amt = (Convert.ToDouble(row2["Amount"]));
                        amt += schemeamount;
                     

                    }
                    else
                    {
                        amt = (Convert.ToDouble(row2["Amount"]) - Convert.ToDouble(row2["totalreturnAmount"]));
                        amt += schemeamount;
                        // sb.Append((Convert.ToDecimal(amount).ToString("#.00")));
                    }

                    //sb.Append("<td class='tg-yw4l' colspan='3'  style='text-align:left'>");
                    //if (row2["PaymentMode"].ToString() == "Daily")
                    //    sb.Append("Reciept: " + amt.ToString("#0.00"));
                    //else
                    //    sb.Append("Reciept: 0.00");
                    //sb.Append("</td>");


                  
                    sb.Append("<td class='tg-yw4l'  style='text-align:right'>");

                    sb.Append((Convert.ToDecimal(amt).ToString("#.00")));
                    totalamt += amt;
                    sb.Append("</td>");



                }


                sb.Append("<tr style='border-bottom:1px solid'>");


                sb.Append("<td class='tg-yw4l' style='text-align:left'> ");
                sb.Append("<b>" + "Grand Total" + "</b>");
                sb.Append("</td>");
                sb.Append("<td class='tg-yw4l'   style='text-align:left'>");
                sb.Append("&nbsp;");
                sb.Append("</td>");
                sb.Append("<td class='tg-yw4l' colspan='2'style='text-align:right'> ");
                sb.Append("&nbsp;");
                sb.Append("</td>");
                sb.Append("<td class='tg-yw4l'   style='text-align:right'>");
                sb.Append("&nbsp;");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l'  colspan='2'  style='text-align:right'> ");
                sb.Append("<b>" + "Total Amount" + "</b>");
                sb.Append("</td>");
                sb.Append("<td class='tg-yw4l'   style='text-align:right'>");
               
                sb.Append("<b>" + (Convert.ToDecimal(totalamt).ToString("#.00")) + "</b>");

               
             
                sb.Append("</td>");

                sb.Append("</tr>");


                foreach (DataRow row3 in DS.Tables[3].Rows)
                {
                    int count = 0;
                    double totalquantity = 0;
                    sb.Append("<tr style='border-bottom:1px solid' style='page-break-inside:avoid; align:center;'> <td colspan = '9'> &nbsp; </td> </tr>");
                    sb.Append("<tr>");
                    sb.Append("<td>");
                    sb.Append("<b>" + row3["OrderDate"].ToString() + "</b>");
                    sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append("&nbsp;");
                    sb.Append("</td>");
                    sb.Append("<td>");
                    if (row3["OrderType"].ToString() == "1")
                    {
                        sb.Append(row3["AgentCode"].ToString());
                    }

                    sb.Append("</td>");
                    sb.Append("<td>");
                    if (row3["OrderType"].ToString() == "1")
                    {
                        sb.Append(row3["Agent"].ToString());
                    }

                    sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append("&nbsp;");
                    sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append("&nbsp;");
                    sb.Append("</td>");

                    sb.Append("<td style='text-align:right'>");
                    sb.Append("<b>" + "Bill No :" + "</b>");
                    sb.Append("</td>");
                    sb.Append("<td style='text-align:right'>");
                    sb.Append("<b>" + row3["BillNumber"].ToString() + "</b>");
                    sb.Append("</td>");
                    sb.Append("</tr>");
                    sb.Append("<tr style='border-bottom:1px dotted'style='page-break-inside:avoid; align:center;'> <td colspan = '9'></td> </tr>");

                    sb.Append("<tr>");
                    sb.Append("<td class='tg-yw4l'  style='text-align:left'>");
                    sb.Append("<b> </b> ");
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l' colspan='2' style='text-align:left'>");
                    sb.Append("<b>ITEM</b>");
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l' colspan='2' style='text-align:left'>");
                    sb.Append("<b>Rate</b>");
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l'  style='text-align:left'>");
                    sb.Append("<b>Quantity</b>");
                    sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append("<b>Unit Type</b>");
                    sb.Append("</td>");
                    sb.Append("<td class='tg-yw4l'  style='text-align:right'>");
                    sb.Append("<b>Amount</b>");
                    sb.Append("</td>");
                    sb.Append("</tr>");
                    foreach (DataRow row4 in DS.Tables[2].Rows)
                    {
                        if (row3["BillNumber"].ToString() == row4["BillNo"].ToString())
                        {
                            count = count + 1;
                            sb.Append("<tr>");
                            sb.Append("<td class='tg-yw4l'   style='text-align:left'>");
                            sb.Append(row4["ProductCode"].ToString());
                            sb.Append("</td>");

                            sb.Append("<td class='tg-yw4l' colspan='2'  style='text-align:left'>");
                            sb.Append(row4["ITEM"].ToString());
                            sb.Append("</td>");

                            sb.Append("<td class='tg-yw4l'  style='text-align:left'>");
                            sb.Append((Convert.ToDecimal(row4["Rate"]).ToString("#.00")));

                            sb.Append("</td>");
                            sb.Append("<td>");
                            sb.Append("");
                            sb.Append("</td>");
                            sb.Append("<td class='tg-yw4l'  style='text-align:left'>");
                            
                                totalquantity += Convert.ToDouble(row4["Quantity"]);
                                sb.Append(row4["Quantity"].ToString());
                          

                            sb.Append("</td>");
                            sb.Append("<td>");
                            sb.Append(row4["UnitType"].ToString());
                            sb.Append("</td>");
                            sb.Append("<td class='tg-yw4l'  style='text-align:right'>");

                            sb.Append((Convert.ToDecimal(row4["Amount"]).ToString("#.00")));

                           
                            sb.Append("</td>");
                            sb.Append("</tr>");
                        }
                        else { }
                    }
                    DS1 = billdata.GetSchemeAmountForBillwiseSalesSummary(row3["BillNumber"]);
                    if (!Comman.Comman.IsDataSetEmpty(DS1))
                    {
                        sb.Append("<tr>");
                        sb.Append("<td class='tg-yw4l'   style='text-align:left'>");
                        sb.Append("&nbsp;");
                        sb.Append("</td>");
                        sb.Append("<td class='tg-yw4l' colspan='4' style='text-align:left'>");
                        sb.Append("Scheme ");
                        sb.Append("</td>");
                        schemeamount = (Convert.ToDouble(DS1.Tables[0].Rows[0]["SchemeAmount"]));
                        sb.Append("<td class='tg-yw4l' colspan='4'  style='text-align:right'>");
                        sb.Append(schemeamount.ToString("#0.00"));
                        sb.Append("</td>");
                        totalScheme = totalScheme + (Convert.ToDouble(DS1.Tables[0].Rows[0]["SchemeAmount"]));
                    }
                    else
                    {
                        schemeamount = 0.0;
                        totalScheme = totalScheme + 0.0;

                    }

                    sb.Append("<tr style='border-bottom:1px dotted'> <td colspan = '9'> &nbsp; </td> </tr>");
                    sb.Append("<tr style='border-bottom:1px solid'>");
                    sb.Append("<td class='tg-yw4l'   style='text-align:left'>");
                    sb.Append(row3["Salesman"].ToString());
                    sb.Append("</td>");
                    sb.Append("<td class='tg-yw4l'   style='text-align:left'>");
                    sb.Append(count.ToString());
                    sb.Append("</td>");
                    sb.Append("<td class='tg-yw4l' colspan='3'  style='text-align:left'>");
                    sb.Append("Total");
                    sb.Append("</td>");
                    sb.Append("<td class='tg-yw4l'  colspan='2'    style='text-align:left'>");
                    sb.Append(totalquantity.ToString());
                    sb.Append("</td>");

                    double amt = 0;

                    amt = (Convert.ToDouble(row3["Amount"]));
                        amt += schemeamount;


                   

                    //sb.Append("<td class='tg-yw4l' colspan='3'  style='text-align:left'>");
                    //if (row2["PaymentMode"].ToString() == "Daily")
                    //    sb.Append("Reciept: " + amt.ToString("#0.00"));
                    //else
                    //    sb.Append("Reciept: 0.00");
                    //sb.Append("</td>");



                    sb.Append("<td class='tg-yw4l'  style='text-align:right'>");

                    sb.Append((Convert.ToDecimal(amt).ToString("#.00")));
                    totalboothamt += amt;
                    sb.Append("</td>");



                }


                sb.Append("<tr style='border-bottom:1px solid'>");


                sb.Append("<td class='tg-yw4l' style='text-align:left'> ");
                sb.Append("<b>" + "Grand Total" + "</b>");
                sb.Append("</td>");
                sb.Append("<td class='tg-yw4l'   style='text-align:left'>");
                sb.Append("&nbsp;");
                sb.Append("</td>");
                sb.Append("<td class='tg-yw4l' colspan='2'style='text-align:right'> ");
                sb.Append("&nbsp;");
                sb.Append("</td>");
                sb.Append("<td class='tg-yw4l'   style='text-align:right'>");
                sb.Append("&nbsp;");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l'  colspan='2'  style='text-align:right'> ");
                sb.Append("<b>" + "Total Amount" + "</b>");
                sb.Append("</td>");
                sb.Append("<td class='tg-yw4l'   style='text-align:right'>");

                sb.Append("<b>" + (Convert.ToDecimal(totalboothamt).ToString("#.00")) + "</b>");



                sb.Append("</td>");

                sb.Append("</tr>");

                sb.Append("<td class='tg-yw4l' style='text-align:left'> ");
                sb.Append("<b>" + " Total Amount" + "</b>");
                sb.Append("</td>");
                sb.Append("<td class='tg-yw4l'   style='text-align:left'>");
                sb.Append("&nbsp;");
                sb.Append("</td>");
                sb.Append("<td class='tg-yw4l' colspan='2'style='text-align:right'> ");
                sb.Append("&nbsp;");
                sb.Append("</td>");
                sb.Append("<td class='tg-yw4l'   style='text-align:right'>");
                sb.Append("&nbsp;");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l'  colspan='2'  style='text-align:right'> ");
                sb.Append("<b>" + " " + "</b>");
                sb.Append("</td>");
                sb.Append("<td class='tg-yw4l'   style='text-align:right'>");
                total = totalamt + totalboothamt;
                sb.Append("<b>" + (Convert.ToDecimal(total).ToString("#.00")) + "</b>");



                sb.Append("</td>");

                sb.Append("</tr>");






                result = sb.ToString();
                genratedBIll.Text = result;
               
                Session["ctrl"] = pnlBill;
            

            }


            else
            {
                result = "Bill not found";
                genratedBIll.Text = result;

            }
        }
    }
}