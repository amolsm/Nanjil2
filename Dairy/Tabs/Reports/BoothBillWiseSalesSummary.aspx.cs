using Bussiness;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dairy.Tabs.Reports
{
    public partial class BoothBillWiseSalesSummary : System.Web.UI.Page
    {
        BillData billdata = new BillData();
        DataSet DS = new DataSet();
        DataSet DS1 = new DataSet();
        DataSet DS2 = new DataSet();
        string result = string.Empty;
        string result1 = string.Empty;
        double schemeamount;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                DataSet DS = new DataSet();
                DS = BindCommanData.BindCommanDropDwon("AgentID", "AgentCode+' '+AgentName as Name", "AgentMaster", "IsArchive=0 and Agensytype='Booth'");
                if (!Comman.Comman.IsDataSetEmpty(DS))
                {
                    dpAgent.DataSource = DS;
                    dpAgent.DataBind();
                    dpAgent.Items.Insert(0, new ListItem("--Select Booth --", "0"));
                }
                txtStartDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                //txtEndDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
            }
        }




        private void allSales()
        {
            double totalScheme = 0;
            DS = billdata.BoothBillwiseSalesSummaryByDate((Convert.ToDateTime(txtStartDate.Text)).ToString("dd-MM-yyyy"), Convert.ToInt32(dpAgent.SelectedItem.Value), Convert.ToInt32(dpEmployee.SelectedItem.Value));
            //local
            DataSet DSL = new DataSet();
            DSL = billdata.BoothLocalBillwiseSalesSummaryByDate((Convert.ToDateTime(txtStartDate.Text)).ToString("dd-MM-yyyy"), Convert.ToInt32(dpAgent.SelectedItem.Value), Convert.ToInt32(dpEmployee.SelectedItem.Value));
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                StringBuilder sb = new StringBuilder();

                #region AgentEmp

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
                sb.Append("<u> Booth Billwise Sales Summary </u> <br/>");
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

                //sb.Append("<tr>");
                //sb.Append("<td class='tg-yw4l' colspan='6' style='text-align:left'>");
                //sb.Append("Start Date:" + Convert.ToDateTime(txtStartDate.Text).ToString("dd-MM-yyyy"));
                //sb.Append("</td>");
                //sb.Append("<td class='tg-yw4l' colspan='2' style='text-align:right'>");
                //sb.Append("End Date:" + Convert.ToDateTime(txtEndDate.Text).ToString("dd-MM-yyyy"));
                //sb.Append("</td>");
                sb.Append("<tr style='border-bottom:2px solid'>");
                sb.Append("<td class='tg-yw4l' colspan='6' style='text-align:left'>");
                if (Convert.ToInt32(dpAgent.SelectedItem.Value) == 1)
                {
                    sb.Append("Booth : " + "All");
                }
                else
                {
                    sb.Append("Booth : " + dpAgent.SelectedItem.Text.ToString());
                }
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l' colspan='2'  style='text-align:right'>");
                sb.Append("Date : " + DateTime.Now.ToString("dd-MM-yyyy"));
                sb.Append("</td>");
                sb.Append("</tr>");






                foreach (DataRow row2 in DS.Tables[1].Rows)
                {

                    sb.Append("<tr style='border-bottom:1px solid' style='page-break-inside:avoid; align:center;'> <td colspan = '8'> &nbsp; </td> </tr>");
                    sb.Append("<tr>");
                    sb.Append("<td>");
                    sb.Append("<b>" + row2["OrderDate"].ToString() + "</b>");
                    sb.Append("</td>");
                    sb.Append("<td colspan='2'>");
                    if (Convert.ToInt32(dpAgent.SelectedItem.Value) == 1)
                    {
                        sb.Append(row2["BoothCode"].ToString() + "&nbsp;" + row2["Booth"].ToString());
                    }
                    else
                    {
                        sb.Append(dpAgent.SelectedItem.Text.ToString());
                    }
                    sb.Append("</td>");

                    sb.Append("<td>");
                    if (row2["OrderType"].ToString() == "1")
                    {
                        sb.Append(row2["AgentCode"].ToString());
                    }
                    if (row2["OrderType"].ToString() == "2")
                    {
                        sb.Append(row2["EmployeeCode"].ToString());
                    }
                    sb.Append("</td>");
                    sb.Append("<td colspan='2'>");
                    if (row2["OrderType"].ToString() == "1")
                    {
                        sb.Append(row2["Agent"].ToString());
                    }
                    if (row2["OrderType"].ToString() == "2")
                    {
                        sb.Append(row2["Employee"].ToString());
                    }
                    sb.Append("</td>");



                    sb.Append("<td style='text-align:right'>");
                    sb.Append("<b>" + "Bill No :" + "</b>");
                    sb.Append("</td>");
                    sb.Append("<td style='text-align:right'>");
                    sb.Append("<b>" + row2["BillNo"].ToString() + "</b>");
                    sb.Append("</td>");
                    sb.Append("</tr>");
                    sb.Append("<tr style='border-bottom:1px dotted'style='page-break-inside:avoid; align:center;'> <td colspan = '9'></td> </tr>");

                    sb.Append("<tr>");


                    sb.Append("<td class='tg-yw4l' colspan='3' style='text-align:left'>");
                    sb.Append("<b>ITEM</b>");
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l' colspan='2' style='text-align:left'>");
                    sb.Append("<b>Rate</b>");
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l'  style='text-align:left'>");
                    sb.Append("<b>Quantity</b>");
                    sb.Append("</td>");
                    sb.Append("<td >");
                    sb.Append("<b>Unit Type</b>");
                    sb.Append("</td>");
                    sb.Append("<td class='tg-yw4l'  style='text-align:right'>");
                    sb.Append("<b>Amount</b>");
                    sb.Append("</td>");
                    sb.Append("</tr>");
                    foreach (DataRow row in DS.Tables[0].Rows)
                    {
                        if (row2["BillNo"].ToString() == row["BillNo"].ToString())
                        {
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

                            sb.Append(row["Qty"].ToString());


                            sb.Append("</td>");
                            sb.Append("<td>");
                            sb.Append(row["UnitType"].ToString());
                            sb.Append("</td>");
                            sb.Append("<td class='tg-yw4l'  style='text-align:right'>");
                            sb.Append((Convert.ToDecimal(row["Total"]).ToString("#.00")));


                            sb.Append("</td>");
                            sb.Append("</tr>");
                        }
                        else { }
                    }
                    DS2 = billdata.GetSchemeAmountForBoothBillwiseSalesSummary(row2["BillNo"]);
                    if (!Comman.Comman.IsDataSetEmpty(DS2))
                    {
                        sb.Append("<tr>");
                        sb.Append("<td class='tg-yw4l'   style='text-align:left'>");
                        sb.Append("&nbsp;");
                        sb.Append("</td>");
                        sb.Append("<td class='tg-yw4l' colspan='4' style='text-align:left'>");
                        sb.Append("Scheme ");
                        sb.Append("</td>");
                        schemeamount = (Convert.ToDouble(DS2.Tables[0].Rows[0]["SchemeAmount"]));
                        sb.Append("<td class='tg-yw4l' colspan='4'  style='text-align:right'>");
                        sb.Append(schemeamount);
                        sb.Append("</td>");
                        totalScheme = totalScheme + (Convert.ToDouble(DS2.Tables[0].Rows[0]["SchemeAmount"]));
                    }
                    else
                    {
                        schemeamount = 0.0;
                        totalScheme = totalScheme + 0.0;
                        //sb.Append(schemeamount);
                    }


                    sb.Append("<tr style='border-bottom:1px dotted'> <td colspan = '8'> &nbsp; </td> </tr>");
                    sb.Append("<tr style='border-bottom:1px solid'>");
                    sb.Append("<td class='tg-yw4l' colspan='2'  style='text-align:left'>");
                    sb.Append(row2["SalesEmployee"].ToString());
                    sb.Append("</td>");

                    sb.Append("<td> &nbsp; </td>");
                    double amt = (Convert.ToDouble(row2["Total"]));
                    amt += schemeamount;
                    sb.Append("<td colpsan=3>");
                    if (row2["PaymentMode"].ToString() == "Daily")
                        sb.Append("Reciept: " + amt.ToString("#0.00"));
                    else
                        sb.Append("Reciept: 0.00");
                    sb.Append("</td>");


                    sb.Append("<td> &nbsp; </td>");
                    sb.Append("<td> &nbsp; </td>");
                    sb.Append("<td> Total </td>");
                    sb.Append("<td class='tg-yw4l'  style='text-align:right'>");



                    sb.Append((Convert.ToDecimal(amt).ToString("#0.00")));

                    sb.Append("</td>");



                }
                #endregion

                //Local
                #region Local
                foreach (DataRow row2 in DSL.Tables[1].Rows)
                {

                    sb.Append("<tr style='border-bottom:1px solid' style='page-break-inside:avoid; align:center;'> <td colspan = '9'> &nbsp; </td> </tr>");
                    sb.Append("<tr>");
                    sb.Append("<td>");
                    sb.Append("<b>" + row2["OrderDate"].ToString() + "</b>");
                    sb.Append("</td>");
                    sb.Append("<td colspan='2'>");
                    if (Convert.ToInt32(dpAgent.SelectedItem.Value) == 1)
                    {
                        sb.Append(row2["BoothCode"].ToString() + "&nbsp;" + row2["Booth"].ToString());
                    }
                    else
                    {
                        sb.Append(dpAgent.SelectedItem.Text.ToString());
                    }
                    sb.Append("</td>");

                    sb.Append("<td>");
                    sb.Append("&nbsp;");
                    sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append("Local Sale");
                    sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append("&nbsp;");
                    sb.Append("</td>");


                    sb.Append("<td style='text-align:right'>");
                    sb.Append("<b>" + "Bill No :" + "</b>");
                    sb.Append("</td>");
                    sb.Append("<td style='text-align:right'>");
                    sb.Append("<b>" + row2["BillNo"].ToString() + "</b>");
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
                    foreach (DataRow row in DSL.Tables[0].Rows)
                    {
                        if (row2["BillNo"].ToString() == row["BillNo"].ToString())
                        {
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

                            sb.Append(row["Qty"].ToString());


                            sb.Append("</td>");
                            sb.Append("<td>");
                            sb.Append(row["UnitType"].ToString());
                            sb.Append("</td>");
                            sb.Append("<td class='tg-yw4l'  style='text-align:right'>");

                            sb.Append((Convert.ToDecimal(row["Total"]).ToString("#.00")));

                            sb.Append("</td>");
                            sb.Append("</tr>");
                        }
                        else { }
                    }

                    sb.Append("<tr style='border-bottom:1px dotted'> <td colspan = '9'> &nbsp; </td> </tr>");
                    sb.Append("<tr style='border-bottom:1px solid'>");
                    sb.Append("<td class='tg-yw4l' colspan='2'  style='text-align:left'>");
                    sb.Append(row2["SalesEmployee"].ToString());
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l' colspan='2'  style='text-align:left'>");
                    sb.Append("Total :");
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l'   style='text-align:left'>");
                    sb.Append("&nbsp;");
                    //sb.Append("<b>" + "Bill No :" + row2["BillNumber"].ToString() + "</b>");
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l'  style='text-align:left'>");

                    sb.Append(row2["Qty"].ToString());

                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l' colspan='2' style='text-align:right'>");

                    sb.Append((Convert.ToDecimal(row2["Total"]).ToString("#.00")));

                    sb.Append("</td>");



                }

                #endregion

                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append("<td class='tg-yw4l'  colspan='5' >");
                sb.Append("Total Amount");
                sb.Append("</td>");
                sb.Append("<td class='tg-yw4l' colspan='2'> ");
                sb.Append("&nbsp;");
                sb.Append("</td>");
                sb.Append("<td class='tg-yw4l'   style='text-align:right'>");
                double totalamount;

                try
                {
                    totalamount = (Convert.ToDouble(DSL.Tables[2].Rows[0]["TotalAmount"])) + (Convert.ToDouble(DS.Tables[2].Rows[0]["TotalAmount"]));
                    totalamount += totalScheme;
                    sb.Append("<b>" + (Convert.ToDouble(totalamount).ToString("#0.00")) + "</b>");

                }
                catch (Exception ex)
                {

                }


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

        //public void AgentandEmployeeSales()
        //{
        //    double totalScheme = 0;
        //    DS = billdata.BoothBillwiseSalesSummaryByDate((Convert.ToDateTime(txtStartDate.Text)).ToString("dd-MM-yyyy"),Convert.ToInt32(dpAgent.SelectedItem.Value), Convert.ToInt32(dpEmployee.SelectedItem.Value));
        //    if (!Comman.Comman.IsDataSetEmpty(DS))
        //    {
        //        StringBuilder sb = new StringBuilder();


        //        sb.Append("<style type='text / css'>");
        //        sb.Append(".tg  { border - collapse:collapse; border - spacing:0; border: none; }");
        //        sb.Append(".tg .tg-yw4l{vertical-align:top}");
        //        sb.Append(".tg .tg-baqh{text-align:center;vertical-align:top}");
        //        sb.Append("</style>");
        //        //sb.Append("<table class='tg style1' style='page-break-inside:avoid; align:center;'>");
        //        sb.Append("<table class='tg style1'  style=' position:relative;align:center;'>");
        //        sb.Append("<colgroup>");
        //        sb.Append("<col style = 'width:120px'>");
        //        sb.Append("<col style = 'width:160px'>");
        //        sb.Append("<col style = 'width:100px'>");
        //        sb.Append("<col style = 'width:100px'>");
        //        sb.Append("<col style = 'width:100px'>");
        //        sb.Append("<col style = 'width:100px'>");
        //        sb.Append("<col style = 'width:100px'>");
        //        sb.Append("<col style = 'width:100px'>");
        //        sb.Append("</colgroup>");

        //        sb.Append("<tr>");
        //        sb.Append("<th class='tg-yw4l' rowspan='2'>");
        //        sb.Append("<img src='/Theme/img/logo1.png' class='img-circle' alt='Logo' width='50px' hight='50px'>");
        //        sb.Append("</th>");

        //        sb.Append("<th class='tg-baqh' colspan='6' style='text-align:center'>");
        //        sb.Append("<u> Booth Agent and Employee Billwise Sales Summary </u> <br/>");
        //        sb.Append("</th>");

        //        sb.Append("<th class='tg-yw4l' style='text-align:right'>");

        //        sb.Append("TIN:330761667331<br>");
        //        sb.Append("</th>");
        //        sb.Append("</tr>");

        //        sb.Append("<tr style='border-bottom:1px solid'>");
        //        sb.Append("<td class='tg-yw4l' colspan='6' style='text-align:center'>");
        //        sb.Append("<b>Nanjil Integrated Dairy Development, Mulagumoodu, K.K.Dt.</b>");

        //        sb.Append("</td>");

        //        sb.Append("<td class='tg-yw4l' style='text-align:right'>");

        //        sb.Append("PH:248370,248605");

        //        sb.Append("</td>");

        //        sb.Append("<tr>");
        //        sb.Append("<td class='tg-yw4l' colspan='6' style='text-align:left'>");
        //        sb.Append("Start Date:" + Convert.ToDateTime(txtStartDate.Text).ToString("dd-MM-yyyy"));
        //        sb.Append("</td>");
        //        sb.Append("<td class='tg-yw4l' colspan='2' style='text-align:right'>");
        //       // sb.Append("End Date:" + Convert.ToDateTime(txtEndDate.Text).ToString("dd-MM-yyyy"));
        //        sb.Append("</td>");
        //        sb.Append("<tr style='border-bottom:2px solid'>");
        //        sb.Append("<td class='tg-yw4l' colspan='6' style='text-align:left'>");
        //        if (Convert.ToInt32(dpAgent.SelectedItem.Value) == 1)
        //        {
        //            sb.Append("Booth : " + "All");
        //        }
        //        else
        //        {
        //            sb.Append("Booth : " + dpAgent.SelectedItem.Text.ToString());
        //        }
        //        sb.Append("</td>");

        //        sb.Append("<td class='tg-yw4l' colspan='2'  style='text-align:right'>");
        //        sb.Append("Date : " + DateTime.Now.ToString("dd-MM-yyyy"));
        //        sb.Append("</td>");
        //        sb.Append("</tr>");






        //        foreach (DataRow row2 in DS.Tables[1].Rows)
        //        {

        //            sb.Append("<tr style='border-bottom:1px solid' style='page-break-inside:avoid; align:center;'> <td colspan = '8'> &nbsp; </td> </tr>");
        //            sb.Append("<tr>");
        //            sb.Append("<td>");
        //            sb.Append("<b>" + row2["OrderDate"].ToString() + "</b>");
        //            sb.Append("</td>");
        //            sb.Append("<td colspan='2'>");
        //            if (Convert.ToInt32(dpAgent.SelectedItem.Value) == 1)
        //            {
        //                sb.Append(row2["BoothCode"].ToString() + "&nbsp;" + row2["Booth"].ToString());
        //            }
        //            else
        //            {
        //                sb.Append(dpAgent.SelectedItem.Text.ToString());
        //            }
        //            sb.Append("</td>");

        //            sb.Append("<td>");
        //            if (row2["OrderType"].ToString() == "1")
        //            {
        //                sb.Append(row2["AgentCode"].ToString());
        //            }
        //            if (row2["OrderType"].ToString() == "2")
        //            {
        //                sb.Append(row2["EmployeeCode"].ToString());
        //            }
        //            sb.Append("</td>");
        //            sb.Append("<td colspan='2'>");
        //            if (row2["OrderType"].ToString() == "1")
        //            {
        //                sb.Append(row2["Agent"].ToString());
        //            }
        //            if (row2["OrderType"].ToString() == "2")
        //            {
        //                sb.Append(row2["Employee"].ToString());
        //            }
        //            sb.Append("</td>");



        //            sb.Append("<td style='text-align:right'>");
        //            sb.Append("<b>" + "Bill No :" + "</b>");
        //            sb.Append("</td>");
        //            sb.Append("<td style='text-align:right'>");
        //            sb.Append("<b>" + row2["BillNo"].ToString() + "</b>");
        //            sb.Append("</td>");
        //            sb.Append("</tr>");
        //            sb.Append("<tr style='border-bottom:1px dotted'style='page-break-inside:avoid; align:center;'> <td colspan = '9'></td> </tr>");

        //            sb.Append("<tr>");


        //            sb.Append("<td class='tg-yw4l' colspan='3' style='text-align:left'>");
        //            sb.Append("<b>ITEM</b>");
        //            sb.Append("</td>");

        //            sb.Append("<td class='tg-yw4l' colspan='2' style='text-align:left'>");
        //            sb.Append("<b>Rate</b>");
        //            sb.Append("</td>");

        //            sb.Append("<td class='tg-yw4l'  style='text-align:left'>");
        //            sb.Append("<b>Quantity</b>");
        //            sb.Append("</td>");
        //            sb.Append("<td >");
        //            sb.Append("<b>Unit Type</b>");
        //            sb.Append("</td>");
        //            sb.Append("<td class='tg-yw4l'  style='text-align:right'>");
        //            sb.Append("<b>Amount</b>");
        //            sb.Append("</td>");
        //            sb.Append("</tr>");
        //            foreach (DataRow row in DS.Tables[0].Rows)
        //            {
        //                if (row2["BillNo"].ToString() == row["BillNo"].ToString())
        //                {
        //                    sb.Append("<tr>");
        //                    sb.Append("<td class='tg-yw4l'   style='text-align:left'>");
        //                    sb.Append(row["ProductCode"].ToString());
        //                    sb.Append("</td>");

        //                    sb.Append("<td class='tg-yw4l' colspan='2'  style='text-align:left'>");
        //                    sb.Append(row["ITEM"].ToString());
        //                    sb.Append("</td>");

        //                    sb.Append("<td class='tg-yw4l'  style='text-align:left'>");
        //                    sb.Append((Convert.ToDecimal(row["Rate"]).ToString("#.00")));
        //                    sb.Append("</td>");
        //                    sb.Append("<td>");
        //                    sb.Append("");
        //                    sb.Append("</td>");
        //                    sb.Append("<td class='tg-yw4l'  style='text-align:left'>");

        //                    sb.Append(row["Qty"].ToString());


        //                    sb.Append("</td>");
        //                    sb.Append("<td>");
        //                    sb.Append(row["UnitType"].ToString());
        //                    sb.Append("</td>");
        //                    sb.Append("<td class='tg-yw4l'  style='text-align:right'>");
        //                    sb.Append((Convert.ToDecimal(row["Total"]).ToString("#.00")));


        //                    sb.Append("</td>");
        //                    sb.Append("</tr>");
        //                }
        //                else { }
        //            }

        //            DS2 = billdata.GetSchemeAmountForBoothBillwiseSalesSummary(row2["BillNo"]);
        //            if (!Comman.Comman.IsDataSetEmpty(DS2))
        //            {
        //                sb.Append("<tr>");
        //                sb.Append("<td class='tg-yw4l'   style='text-align:left'>");
        //                sb.Append("&nbsp;");
        //                sb.Append("</td>");
        //                sb.Append("<td class='tg-yw4l' colspan='4' style='text-align:left'>");
        //                sb.Append("Scheme ");
        //                sb.Append("</td>");
        //                schemeamount = (Convert.ToDouble(DS2.Tables[0].Rows[0]["SchemeAmount"]));
        //                sb.Append("<td class='tg-yw4l' colspan='4'  style='text-align:right'>");
        //                sb.Append(schemeamount);
        //                sb.Append("</td>");
        //                totalScheme = totalScheme + (Convert.ToDouble(DS2.Tables[0].Rows[0]["SchemeAmount"]));
        //            }
        //            else
        //            {
        //                schemeamount = 0.0;
        //                totalScheme = totalScheme + 0.0;
        //                //sb.Append(schemeamount);
        //            }


        //            sb.Append("<tr style='border-bottom:1px dotted'> <td colspan = '8'> &nbsp; </td> </tr>");
        //            sb.Append("<tr style='border-bottom:1px solid'>");
        //            sb.Append("<td class='tg-yw4l' colspan='2'  style='text-align:left'>");
        //            sb.Append(row2["SalesEmployee"].ToString());
        //            sb.Append("</td>");

        //            sb.Append("<td> &nbsp; </td>");
        //            double amt = (Convert.ToDouble(row2["Total"]));
        //            amt += schemeamount;
        //            sb.Append("<td colpsan=3>");
        //            if (row2["PaymentMode"].ToString() == "Daily")
        //                sb.Append("Reciept: " + amt.ToString("#0.00"));
        //            else
        //                sb.Append("Reciept: 0.00");
        //            sb.Append("</td>");


        //            sb.Append("<td> &nbsp; </td>");
        //            sb.Append("<td> &nbsp; </td>");
        //            sb.Append("<td> Total </td>");
        //            sb.Append("<td class='tg-yw4l'  style='text-align:right'>");



        //            sb.Append((Convert.ToDecimal(amt).ToString("#0.00")));

        //            sb.Append("</td>");




        //        }


        //        sb.Append("<tr style='border-bottom:1px solid'>");
        //        sb.Append("<td class='tg-yw4l'  colspan='7' >");
        //        sb.Append("Total Amount");
        //        sb.Append("</td>");

        //        sb.Append("<td class='tg-yw4l'   style='text-align:right'>");
        //        double totalamount;

        //        try
        //        {
        //            totalamount = (Convert.ToDouble(DS.Tables[2].Rows[0]["TotalAmount"]));
        //            totalamount += totalScheme;
        //            sb.Append("<b>" + (Convert.ToDecimal(totalamount).ToString("#.00")) + "</b>");
        //        }
        //        catch (Exception ex)
        //        {

        //        }


        //        sb.Append("</td>");

        //        sb.Append("</tr>");
        //        result = sb.ToString();
        //        genratedBIll.Text = result;

        //        Session["ctrl"] = pnlBill;

        //    }


        //    else
        //    {
        //        result = "Bill not found";
        //        genratedBIll.Text = result;

        //    }
        //}

        //public void LocalSales()
        //{

        //    DS = billdata.BoothLocalBillwiseSalesSummaryByDate((Convert.ToDateTime(txtStartDate.Text)).ToString("dd-MM-yyyy"), (Convert.ToDateTime(txtEndDate.Text)).ToString("dd-MM-yyyy"), Convert.ToInt32(dpAgent.SelectedItem.Value));
        //    if (!Comman.Comman.IsDataSetEmpty(DS))
        //    {

        //        StringBuilder sb = new StringBuilder();


        //        sb.Append("<style type='text / css'>");
        //        sb.Append(".tg  { border - collapse:collapse; border - spacing:0; border: none; }");
        //        sb.Append(".tg .tg-yw4l{vertical-align:top}");
        //        sb.Append(".tg .tg-baqh{text-align:center;vertical-align:top}");
        //        sb.Append("</style>");
        //        //sb.Append("<table class='tg style1' style='page-break-inside:avoid; align:center;'>");
        //        sb.Append("<table class='tg style1'  style=' position:relative;align:center;'>");
        //        sb.Append("<colgroup>");
        //        sb.Append("<col style = 'width:120px'>");
        //        sb.Append("<col style = 'width:160px'>");
        //        sb.Append("<col style = 'width:100px'>");
        //        sb.Append("<col style = 'width:100px'>");
        //        sb.Append("<col style = 'width:100px'>");
        //        sb.Append("<col style = 'width:100px'>");
        //        sb.Append("<col style = 'width:100px'>");
        //        sb.Append("<col style = 'width:100px'>");
        //        sb.Append("</colgroup>");

        //        sb.Append("<tr>");
        //        sb.Append("<th class='tg-yw4l' rowspan='2'>");
        //        sb.Append("<img src='/Theme/img/logo1.png' class='img-circle' alt='Logo' width='50px' hight='50px'>");
        //        sb.Append("</th>");

        //        sb.Append("<th class='tg-baqh' colspan='6' style='text-align:center'>");
        //        sb.Append("<u> Booth Customer Billwise Sales Summary </u> <br/>");
        //        sb.Append("</th>");

        //        sb.Append("<th class='tg-yw4l' style='text-align:right'>");

        //        sb.Append("TIN:330761667331<br>");
        //        sb.Append("</th>");
        //        sb.Append("</tr>");

        //        sb.Append("<tr style='border-bottom:1px solid'>");
        //        sb.Append("<td class='tg-yw4l' colspan='6' style='text-align:center'>");
        //        sb.Append("<b>Nanjil Integrated Dairy Development, Mulagumoodu, K.K.Dt.</b>");

        //        sb.Append("</td>");

        //        sb.Append("<td class='tg-yw4l' style='text-align:right'>");

        //        sb.Append("PH:248370,248605");

        //        sb.Append("</td>");

        //        sb.Append("<tr>");
        //        sb.Append("<td class='tg-yw4l' colspan='6' style='text-align:left'>");
        //        sb.Append("Start Date:" + Convert.ToDateTime(txtStartDate.Text).ToString("dd-MM-yyyy"));
        //        sb.Append("</td>");
        //        sb.Append("<td class='tg-yw4l' colspan='6' style='text-align:right'>");
        //        //  sb.Append("End Date:" + Convert.ToDateTime(txtEndDate.Text).ToString("dd-MM-yyyy"));
        //        sb.Append("</td>");
        //        sb.Append("<tr style='border-bottom:2px solid'>");
        //        sb.Append("<td class='tg-yw4l' colspan='6' style='text-align:left'>");
        //        if (Convert.ToInt32(dpAgent.SelectedItem.Value) == 1)
        //        {
        //            sb.Append("Booth : " + "All");
        //        }
        //        else
        //        {
        //            sb.Append("Booth : " + dpAgent.SelectedItem.Text.ToString());
        //        }
        //        sb.Append("</td>");

        //        sb.Append("<td class='tg-yw4l' colspan='6'  style='text-align:right'>");
        //        sb.Append("Date : " + DateTime.Now.ToString("dd-MM-yyyy"));
        //        sb.Append("</td>");
        //        sb.Append("</tr>");






        //        foreach (DataRow row2 in DS.Tables[1].Rows)
        //        {

        //            sb.Append("<tr style='border-bottom:1px solid' style='page-break-inside:avoid; align:center;'> <td colspan = '9'> &nbsp; </td> </tr>");
        //            sb.Append("<tr>");
        //            sb.Append("<td>");
        //            sb.Append("<b>" + row2["OrderDate"].ToString() + "</b>");
        //            sb.Append("</td>");
        //            sb.Append("<td colspan='2'>");
        //            if (Convert.ToInt32(dpAgent.SelectedItem.Value) == 1)
        //            {
        //                sb.Append(row2["BoothCode"].ToString() + "&nbsp;" + row2["Booth"].ToString());
        //            }
        //            else
        //            {
        //                sb.Append(dpAgent.SelectedItem.Text.ToString());
        //            }
        //            sb.Append("</td>");

        //            sb.Append("<td>");
        //            sb.Append("&nbsp;");
        //            sb.Append("</td>");
        //            sb.Append("<td>");
        //            sb.Append("Local Sale");
        //            sb.Append("</td>");
        //            sb.Append("<td>");
        //            sb.Append("&nbsp;");
        //            sb.Append("</td>");


        //            sb.Append("<td style='text-align:right'>");
        //            sb.Append("<b>" + "Bill No :" + "</b>");
        //            sb.Append("</td>");
        //            sb.Append("<td style='text-align:right'>");
        //            sb.Append("<b>" + row2["BillNo"].ToString() + "</b>");
        //            sb.Append("</td>");
        //            sb.Append("</tr>");
        //            sb.Append("<tr style='border-bottom:1px dotted'style='page-break-inside:avoid; align:center;'> <td colspan = '9'></td> </tr>");

        //            sb.Append("<tr>");
        //            sb.Append("<td class='tg-yw4l'  style='text-align:left'>");
        //            sb.Append("<b> </b> ");
        //            sb.Append("</td>");

        //            sb.Append("<td class='tg-yw4l' colspan='2' style='text-align:left'>");
        //            sb.Append("<b>ITEM</b>");
        //            sb.Append("</td>");

        //            sb.Append("<td class='tg-yw4l' colspan='2' style='text-align:left'>");
        //            sb.Append("<b>Rate</b>");
        //            sb.Append("</td>");

        //            sb.Append("<td class='tg-yw4l'  style='text-align:left'>");
        //            sb.Append("<b>Quantity</b>");
        //            sb.Append("</td>");
        //            sb.Append("<td>");
        //            sb.Append("<b>Unit Type</b>");
        //            sb.Append("</td>");
        //            sb.Append("<td class='tg-yw4l'  style='text-align:right'>");
        //            sb.Append("<b>Amount</b>");
        //            sb.Append("</td>");
        //            sb.Append("</tr>");
        //            foreach (DataRow row in DS.Tables[0].Rows)
        //            {
        //                if (row2["BillNo"].ToString() == row["BillNo"].ToString())
        //                {
        //                    sb.Append("<tr>");
        //                    sb.Append("<td class='tg-yw4l'   style='text-align:left'>");
        //                    sb.Append(row["ProductCode"].ToString());
        //                    sb.Append("</td>");

        //                    sb.Append("<td class='tg-yw4l' colspan='2'  style='text-align:left'>");
        //                    sb.Append(row["ITEM"].ToString());
        //                    sb.Append("</td>");

        //                    sb.Append("<td class='tg-yw4l'  style='text-align:left'>");
        //                    sb.Append((Convert.ToDecimal(row["Rate"]).ToString("#.00")));

        //                    sb.Append("</td>");
        //                    sb.Append("<td>");
        //                    sb.Append("");
        //                    sb.Append("</td>");
        //                    sb.Append("<td class='tg-yw4l'  style='text-align:left'>");

        //                    sb.Append(row["Qty"].ToString());


        //                    sb.Append("</td>");
        //                    sb.Append("<td>");
        //                    sb.Append(row["UnitType"].ToString());
        //                    sb.Append("</td>");
        //                    sb.Append("<td class='tg-yw4l'  style='text-align:right'>");

        //                    sb.Append((Convert.ToDecimal(row["Total"]).ToString("#.00")));

        //                    sb.Append("</td>");
        //                    sb.Append("</tr>");
        //                }
        //                else { }
        //            }

        //            sb.Append("<tr style='border-bottom:1px dotted'> <td colspan = '9'> &nbsp; </td> </tr>");
        //            sb.Append("<tr style='border-bottom:1px solid'>");
        //            sb.Append("<td class='tg-yw4l' colspan='2'  style='text-align:left'>");
        //            sb.Append(row2["SalesEmployee"].ToString());
        //            sb.Append("</td>");

        //            sb.Append("<td class='tg-yw4l' colspan='2'  style='text-align:left'>");
        //            sb.Append("Total :");
        //            sb.Append("</td>");

        //            sb.Append("<td class='tg-yw4l'   style='text-align:left'>");
        //            sb.Append("&nbsp;");
        //            //sb.Append("<b>" + "Bill No :" + row2["BillNumber"].ToString() + "</b>");
        //            sb.Append("</td>");

        //            sb.Append("<td class='tg-yw4l'  style='text-align:left'>");

        //            sb.Append(row2["Qty"].ToString());

        //            sb.Append("</td>");

        //            sb.Append("<td class='tg-yw4l' colspan='2' style='text-align:right'>");

        //            sb.Append((Convert.ToDecimal(row2["Total"]).ToString("#.00")));

        //            sb.Append("</td>");



        //        }


        //        sb.Append("<tr style='border-bottom:1px solid'>");
        //        sb.Append("<td class='tg-yw4l'  colspan='5' >");
        //        sb.Append("Total Amount");
        //        sb.Append("</td>");
        //        sb.Append("<td class='tg-yw4l' colspan='2'> ");
        //        sb.Append("&nbsp;");
        //        sb.Append("</td>");
        //        sb.Append("<td class='tg-yw4l'   style='text-align:right'>");
        //        double totalamount;

        //        try
        //        {
        //            totalamount = (Convert.ToDouble(DS.Tables[2].Rows[0]["TotalAmount"]));
        //            sb.Append("<b>" + (Convert.ToDecimal(totalamount).ToString("#.00")) + "</b>");

        //        }
        //        catch (Exception ex)
        //        {

        //        }


        //        sb.Append("</td>");

        //        sb.Append("</tr>");
        //        result = sb.ToString();
        //        genratedBIll.Text = result;

        //        Session["ctrl"] = pnlBill;


        //    }



        //    else
        //    {
        //        result1 = "Bill not found";
        //        genratedBIll.Text = result1;

        //    }
        //}

        protected void dpAgent_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            DataSet DS = new DataSet();
            DS = BindCommanData.BindBoothUserDropDwon(Convert.ToDateTime(txtStartDate.Text).ToString("dd-MM-yyyy"), Convert.ToInt32(dpAgent.SelectedItem.Value));
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpEmployee.DataSource = DS;
                dpEmployee.DataBind();
                dpEmployee.Items.Insert(0, new ListItem("--Select Employee--", "0"));
            }
            else { dpEmployee.DataSource = DS; dpEmployee.DataBind(); }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            allSales();
        }
    }
}