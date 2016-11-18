using Bussiness;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dairy.Tabs.Despatch
{
    public partial class ItemwiseSalesSummary : System.Web.UI.Page
    {
        BillData billdata = new BillData();
        DataSet DS = new DataSet();
        DataSet DS1 = new DataSet();
        double totalstaffamount=0.00;
        double totalagentcreditamount=0.00;
        double totalamount;
        double totalscheme;

        double totalreceipt;
        double totalagentcash;
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
                    dpRoute.Items.Insert(0, new ListItem("--All Route  --", "0"));
                }
                DS = BindCommanData.BindCommanDropDwon("CategoryId", "CategoryName as Name", "Category", "IsActive=1");
                if (!Comman.Comman.IsDataSetEmpty(DS))
                {
                    dpBrand.DataSource = DS;
                    dpBrand.DataBind();
                    dpBrand.Items.Insert(0, new ListItem("--All Brand--", "0"));
                }
                txtStartDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                txtEndDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
            }
        }
        protected void btngenrateBill_click(object sender, EventArgs e)
        {
            string result = string.Empty;
            DS = billdata.GenrateItemwiseSalesSummaryByDate((Convert.ToDateTime(txtStartDate.Text)).ToString("dd-MM-yyyy"), (Convert.ToDateTime(txtEndDate.Text)).ToString("dd-MM-yyyy"), Convert.ToInt32(dpRoute.SelectedItem.Value), Convert.ToInt32(dpBrand.SelectedValue));
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                StringBuilder sb = new StringBuilder();


                sb.Append("<style type='text / css'>");
                sb.Append(".tg  { border - collapse:collapse; border - spacing:0; border: none; }");
                sb.Append(".tg .tg-yw4l{vertical-align:top}");
                sb.Append(".tg .tg-baqh{text-align:center;vertical-align:top}");
                sb.Append("</style>");
                sb.Append("<table class='tg style1' style='page-break-inside:avoid; align:center;'>");
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

                sb.Append("<th class='tg-baqh' colspan='5' style='text-align:center'>");
                sb.Append("<u>Itemwise Sales Summary </u> <br/>");
                sb.Append("</th>");

                sb.Append("<th class='tg-yw4l' style='text-align:right'>");

                sb.Append("TIN:330761667331<br>");
                sb.Append("</th>");
                sb.Append("</tr>");

                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append("<td class='tg-yw4l' colspan='5' style='text-align:center'>");
                sb.Append("<b>Nanjil Integrated Dairy Development, Mulagumoodu, K.K.Dt.</b>");

                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l' style='text-align:right'>");

                sb.Append("PH:248370,248605");

                sb.Append("</td>");

                sb.Append("<tr>");
                sb.Append("<td class='tg-yw4l' colspan='4' style='text-align:left'>");
                sb.Append("Start Date:" + Convert.ToDateTime(txtStartDate.Text).ToString("dd-MM-yyyy"));
                sb.Append("</td>");
                sb.Append("<td class='tg-yw4l' colspan='3' style='text-align:right'>");
                sb.Append("End Date:" + Convert.ToDateTime(txtEndDate.Text).ToString("dd-MM-yyyy"));
                sb.Append("</td>");
                sb.Append("<tr style='border-bottom:2px solid'>");
                sb.Append("<td class='tg-yw4l' colspan='4' style='text-align:left'>");

                if (Convert.ToInt32(dpRoute.SelectedItem.Value) == 0)
                {
                    sb.Append("Route : " + "All");
                }
                else
                {
                    sb.Append("Route : " + dpRoute.SelectedItem.Text.ToString());
                }
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l' colspan='3'  style='text-align:right'>");
                sb.Append("Date : " + DateTime.Now.ToString("dd-MM-yyyy"));
                sb.Append("</td>");
                sb.Append("</tr>");


                sb.Append("<tr style='border-bottom:1px solid'> ");
                sb.Append("<td class='tg-yw4l' colspan='7' style='text-align:left'>");
                if (Convert.ToInt32(dpBrand.SelectedItem.Value) == 0)
                {
                    sb.Append("Brand Name : " + "All");
                }
                else
                {
                    sb.Append("Brand Name : " + dpBrand.SelectedItem.Text.ToString());
                }

                sb.Append("</td>");
                sb.Append("</tr>");

                sb.Append("<tr style='border-bottom:1px solid'>");


                sb.Append("<td class='tg-yw4l' colspan='2' style='text-align:left'>");
                sb.Append("<b>ITEM </b>");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l' colspan='2' style='text-align:center'>");
                sb.Append("<b>Unit Price</b>");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l' colspan='2' style='text-align:center'>");
                sb.Append("<b>Quantity</b>");
                sb.Append("</td>");



                sb.Append("<td class='tg-yw4l'   style='text-align:right'>");
                sb.Append("<b>Amount</b>");
                sb.Append("</td>");

                sb.Append("</tr>");

                foreach (DataRow row2 in DS.Tables[2].Rows)
                {
                    sb.Append("<tr style='border-bottom:1px solid'> <td colspan = '7'> &nbsp; </td> </tr>");
                    sb.Append("<tr style='border-bottom:1px solid'>");


                    sb.Append("<td class='tg-yw4l' colspan='4'  style='text-align:left'>");
                    sb.Append("<b>" + row2["ProductName"] + "</b>");
                    sb.Append("</td>");



                    sb.Append("<td class='tg-yw4l' colspan='2'  style='text-align:center'>");
                    if (row2["totalreturnQuantity"].ToString() == "")
                    {
                        sb.Append("<b>" + row2["SubQuantity"] + "</b>");
                    }
                    else
                    {
                        double subquantity = (Convert.ToDouble(row2["SubQuantity"]) - Convert.ToDouble(row2["totalreturnQuantity"]));
                        sb.Append("<b>" + subquantity + "</b>");
                    }

                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l'  style='text-align:right'>");
                    if (row2["totalreturnAmount"].ToString() == "")
                    {

                        sb.Append("<b>" + (Convert.ToDecimal(row2["SubAmount"]).ToString("#.00")) + "</b>");
                    }
                    else
                    {
                        double subamount = (Convert.ToDouble(row2["SubAmount"]) - Convert.ToDouble(row2["totalreturnAmount"]));
                        sb.Append("<b>" + (Convert.ToDecimal(subamount).ToString("#.00")) + "</b>");

                    }

                    sb.Append("</td>");
                    sb.Append("</tr>");


                    foreach (DataRow row in DS.Tables[0].Rows)
                    {
                        if (row2["ProductName"].ToString() == row["ProductName"].ToString())
                        {
                            sb.Append("<td class='tg-yw4l' colspan='2'  style='text-align:left'>");
                            sb.Append(row["ProductName"].ToString());
                            sb.Append("</td>");

                            sb.Append("<td class='tg-yw4l' colspan='2'   style='text-align:center'>");
                            sb.Append((Convert.ToDecimal(row["Rate"]).ToString("#.00")));
                            sb.Append("</td>");


                            sb.Append("<td class='tg-yw4l' colspan='2'   style='text-align:center'>");
                            if (row["totalreturnQuantity"].ToString() == "")
                            {
                                sb.Append(row["Quantity"].ToString());
                            }
                            else
                            {
                                double quantity = (Convert.ToDouble(row["Quantity"]) - Convert.ToDouble(row["totalreturnQuantity"]));
                                sb.Append(quantity);
                            }
                            sb.Append("</td>");

                            sb.Append("<td class='tg-yw4l'   style='text-align:right'>");
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

                    }





                }

                sb.Append("<tr style='border-bottom:1px solid'> <td colspan = '7'> &nbsp; </td> </tr>");
                sb.Append("<tr style='border-bottom:1px solid'>");


                sb.Append("<td class='tg-yw4l' colspan='4'  style='text-align:left'>");
                sb.Append("<b>" + "Total" + "</b>");
                sb.Append("</td>");


                sb.Append("<td class='tg-yw4l'  colspan='2' style='text-align:center'>");
                double totalquantity;
                if (!DBNull.Value.Equals(DS.Tables[1].Rows[0]["totalreturnQuantity"]))
                {
                    totalquantity = (string.IsNullOrEmpty(DS.Tables[1].Rows[0]["TotalQuantity"].ToString()) ? 0 : Convert.ToDouble(DS.Tables[1].Rows[0]["TotalQuantity"]) - (string.IsNullOrEmpty(DS.Tables[1].Rows[0]["totalreturnQuantity"].ToString()) ? 0 : Convert.ToDouble(DS.Tables[1].Rows[0]["totalreturnQuantity"])));
                    sb.Append("<b>" + totalquantity + "</b>");

                }
                else
                {


                    try
                    {
                        totalquantity = (Convert.ToDouble(DS.Tables[1].Rows[0]["TotalQuantity"]));
                        sb.Append("<b>" + totalquantity + "</b>");
                    }
                    catch (Exception ex)
                    {

                    }
                }

                sb.Append("</td>");


                sb.Append("<td class='tg-yw4l' style='text-align:right'>");
                if (!string.IsNullOrEmpty(DS.Tables[1].Rows[0]["totalreturnAmount"].ToString()))
                {

                    totalamount = (Convert.ToDouble(DS.Tables[1].Rows[0]["TotalAmount"]) - Convert.ToDouble(DS.Tables[1].Rows[0]["totalreturnAmount"]));
                    sb.Append("<b>" + (Convert.ToDecimal(totalamount).ToString("#0.00")) + "</b>");

                }
                else
                {
                    try
                    {
                        totalamount = (Convert.ToDouble(DS.Tables[1].Rows[0]["TotalAmount"]));
                        sb.Append("<b>" + (Convert.ToDecimal(totalamount).ToString("#0.00")) + "</b>");

                    }
                    catch (Exception ex)
                    {

                    }

                }

                sb.Append("</td>");
                sb.Append("</tr>");

                if (Convert.ToInt32(dpBrand.SelectedItem.Value) == 1 || Convert.ToInt32(dpBrand.SelectedItem.Value) == 0)
                {
                    sb.Append("<tr>");
                    sb.Append("<td class='tg-yw4l' colspan='4' style='text-align:left'>");
                    sb.Append("<b>Scheme<b>");
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l' colspan='2' style='text-align:center'>");
                    sb.Append("<b>" + DS.Tables[6].Rows[0]["NumberOfScheme"].ToString() + "</b>");
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l' style='text-align:right'>");
                    totalscheme = string.IsNullOrEmpty(DS.Tables[6].Rows[0]["TotalScheme"].ToString()) ? 0 : Convert.ToDouble(DS.Tables[6].Rows[0]["TotalScheme"]);
                    sb.Append("<b>" + totalscheme.ToString("#0.00") + "</b>");
                    sb.Append("</td>");

                    sb.Append("</tr>");
                }
                sb.Append("<tr style='border-bottom:1px solid'> <td colspan = '7'> &nbsp; </td> </tr>");
                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append("<td  colspan='3' class='tg-yw4l'  style='text-align:left'>");
                //totalamount = (string.IsNullOrEmpty(DS.Tables[1].Rows[0]["TotalAmount"].ToString()) ? 0 : Convert.ToDouble(DS.Tables[1].Rows[0]["TotalAmount"]));
                totalamount += totalscheme;
                sb.Append("Total Amount :   " + "<b>" + (Convert.ToDecimal(totalamount).ToString("#0.00")) + "</b>");

                sb.Append("</td>");
                sb.Append("<td class='tg-yw4l'  style='text-align:right'>");
                sb.Append("Receipt");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l'  style='text-align:center'>");
                try
                {
                    if (DS.Tables[3].Rows[0]["totalreturnAmount"].ToString() == "")
                    {
                        totalagentcash = Convert.ToDouble(DS.Tables[3].Rows[0]["Amount"]);
                        totalagentcash = totalagentcash + totalscheme;
                        sb.Append("<b>" + (Convert.ToDecimal(totalagentcash).ToString("#0.00")) + "</b>");
                    }
                    else
                    {
                        totalagentcash = (Convert.ToDouble(DS.Tables[3].Rows[0]["Amount"]) - Convert.ToDouble(DS.Tables[3].Rows[0]["totalreturnAmount"]));
                        totalagentcash = totalagentcash + totalscheme;
                        sb.Append("<b>" + (Convert.ToDecimal(totalagentcash).ToString("#0.00")) + "</b>");
                    }

                    totalreceipt = totalagentcash + totalscheme;
                }
                catch (Exception ex)
                { }

                //sb.Append("<b>" + (Convert.ToDecimal(totalagentcash).ToString("#0.00")) + "</b>");
                //sb.Append("<b>" + "" + "</b>");
                sb.Append("</td>");
                sb.Append("</td>");
                sb.Append("<td class='tg-yw4l'  style='text-align:right'>");
                sb.Append("Staff & A.C:");
                sb.Append("</td>");
                sb.Append("<td class='tg-yw4l'  style='text-align:right'>");


                try
                {

                    if (DS.Tables[5].Rows[0]["totalreturnAmount"].ToString() == "")
                    {
                        totalstaffamount = Convert.ToDouble(DS.Tables[5].Rows[0]["Amount"]);
                        //sb.Append("<b>" + (Convert.ToDecimal(totalstaffamount).ToString("#0.00")) + "</b>");
                    }
                    else
                    {
                        totalstaffamount = (Convert.ToDouble(DS.Tables[5].Rows[0]["Amount"]) - Convert.ToDouble(DS.Tables[5].Rows[0]["totalreturnAmount"]));
                        //sb.Append("<b>" + (Convert.ToDecimal(totalstaffamount).ToString("#0.00")) + "</b>");
                    }
                }
                catch (Exception ex) { }
                //totalstaffamount = (string.IsNullOrEmpty(DS.Tables[1].Rows[0]["StaffAmount"].ToString()) ? 0 : Convert.ToDouble(DS.Tables[3].Rows[0]["StaffAmount"]));
                try
                    { 
                    if (DS.Tables[4].Rows[0]["totalreturnAmount"].ToString() == "")
                    {

                        totalagentcreditamount = Convert.ToDouble(DS.Tables[4].Rows[0]["Amount"]);
                        //sb.Append("<b>" + (Convert.ToDecimal(totalagentcreditamount).ToString("#0.00")) + "</b>");
                    }
                    else
                    {
                        totalagentcreditamount = (Convert.ToDouble(DS.Tables[4].Rows[0]["Amount"]) - Convert.ToDouble(DS.Tables[6].Rows[4]["totalreturnAmount"]));
                        //sb.Append("<b>" + (Convert.ToDecimal(totalagentcreditamount).ToString("#0.00")) + "</b>");
                    }
                   





                  
                }
                catch (Exception ex) { }
                totalstaffamount += totalagentcreditamount;
                sb.Append("<b>" + (Convert.ToDecimal(totalstaffamount).ToString("#0.00")) + "</b>");
                sb.Append("</td>");



                sb.Append("</tr>");





                result = sb.ToString();
                genratedBIll.Text = result;
                //Session["ctrl"] = sb.ToString();
                Session["ctrl"] = pnlBill;
                //Response.Redirect("/print.aspx", true);

            }
            else
            {
                result = "Order not FOund";
                genratedBIll.Text = result;

            }
        }
    }
}