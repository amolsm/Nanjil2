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
    public partial class RoutewiseSalesSummary : System.Web.UI.Page
    {
        BillData billdata = new BillData();
        DataSet DS = new DataSet();
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
            int srno = 0;
            double AgencyCashSale = 0;
            double AgencyCreditSale = 0;
            double EmpSale = 0;
            double schemeTot = 0;
            double totalScheme = 0;
            string result = string.Empty;
            DS = billdata.GenerateRoteSalesSummary((Convert.ToDateTime(txtStartDate.Text)).ToString("dd-MM-yyyy"), (Convert.ToDateTime(txtEndDate.Text)).ToString("dd-MM-yyyy"), Convert.ToInt32(dpRoute.SelectedItem.Value), Convert.ToInt32(dpBrand.SelectedValue));
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
                sb.Append("<col style = 'width:150px'>");
                sb.Append("<col style = 'width:100px'>");
                sb.Append("<col style = 'width:100px'>");
                sb.Append("<col style = 'width:100px'>");
                sb.Append("<col style = 'width:100px'>");
                sb.Append("<col style = 'width:150px'>");
               
                sb.Append("</colgroup>");

                sb.Append("<tr>");
                sb.Append("<th class='tg-yw4l'  rowspan='2'>");
                sb.Append("<img src='/Theme/img/logo1.png' class='img-circle' alt='Logo' width='50px' hight='50px'>");
                sb.Append("</th>");

                sb.Append("<th class='tg-baqh' colspan='4' style='text-align:center'>");
                sb.Append("<u>   Routewise Sales Summary </u> <br/>");
                sb.Append("</th>");

                sb.Append("<th class='tg-yw4l'  style='text-align:right'>");

                sb.Append("TIN:330761667331<br>");
                sb.Append("</th>");
                sb.Append("</tr>");

                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append("<td class='tg-yw4l' colspan='4' style='text-align:center'>");
                sb.Append("<b>Nanjil Integrated Dairy Development, Mulagumoodu, K.K.Dt.</b>");

                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l'  style='text-align:right'>");

                sb.Append("PH:248370,248605");

                sb.Append("</td>");

                sb.Append("<tr>");
                sb.Append("<td class='tg-yw4l'  style='text-align:left'>");
                sb.Append("Start Date:" + Convert.ToDateTime(txtStartDate.Text).ToString("dd-MM-yyyy"));
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l' colspan='4' style='text-align:center'>");
                if (Convert.ToInt32(dpBrand.SelectedItem.Value) == 0)
                {
                    sb.Append("Brand Name : " + "All Brands");
                }
                else
                {
                    sb.Append("Brand Name : " + dpBrand.SelectedItem.Text.ToString());
                }

                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l'  style='text-align:right'>");
                sb.Append("End Date:" + Convert.ToDateTime(txtEndDate.Text).ToString("dd-MM-yyyy"));
                sb.Append("</td>");

                sb.Append("<tr style='border-bottom:2px solid'>");
                sb.Append("<td class='tg-yw4l' colspan='3' style='text-align:left'>");

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
                sb.Append("</tr>");


                



                #region AgencyCashSale
                sb.Append("<tr style='border-Top:1px solid' > ");
                sb.Append("<td colspan ='6' style='text-align:left'>");
                sb.Append("<b>(A) Agency Cash Sale </b>");
                sb.Append("</td>");

                sb.Append("<tr style='border-bottom:1px solid' >");
                sb.Append("<td  style='text-align:center'>");
                sb.Append("<b> Sr.No </b> ");
                sb.Append("</td>");

                sb.Append("<td  colspan='2' style='text-align:left'>");
                sb.Append("<b> Product Name </b> ");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l'  style='text-align:center'>");

                sb.Append("<b> Quantity </b> ");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l' colspan='2' style='text-align:right'>");
                sb.Append("<b> Total </b> ");
                sb.Append("</td>");

                sb.Append("</tr>");
                srno = 0;
                foreach (DataRow row in DS.Tables[1].Rows)
                {
                    srno++;
                    sb.Append("<tr>");

                    sb.Append("<td  class='tg-yw4l'    style='text-align:center'>");
                    sb.Append(srno.ToString());
                    sb.Append("</td>");

                    sb.Append("<td  class='tg-yw4l' colspan='2'   style='text-align:left'>");
                    sb.Append(row["ITEM"].ToString());
                    sb.Append("</td>");

                    sb.Append("<td  class='tg-yw4l'  style='text-align:center'>");

                     
                    if (string.IsNullOrEmpty(row["totalreturnQuantity"].ToString()))
                    {
                        sb.Append("<b>" + row["Quantity"].ToString() + "</b>");
                    }
                    else
                    {
                        double quantity = (Convert.ToDouble(row["Quantity"]) - Convert.ToDouble(row["totalreturnQuantity"]));
                        sb.Append("<b>" + quantity + "</b>");
                    }
                    sb.Append("</td>");

                    sb.Append("<td  class='tg-yw4l' colspan='2' style='text-align:right'>");
                    if (string.IsNullOrEmpty( row["totalreturnAmount"].ToString()))
                    {
                        sb.Append("<b>" + (Convert.ToDecimal(row["Amount"]).ToString("#0.00")) + "</b>");
                        AgencyCashSale = AgencyCashSale + Convert.ToDouble(row["Amount"]);
                    }
                    else
                    {
                        double amount = (Convert.ToDouble(row["Amount"]) - Convert.ToDouble(row["totalreturnAmount"]));
                        sb.Append("<b>" + (Convert.ToDecimal(amount).ToString("#0.00")) + "</b>");
                        AgencyCashSale = AgencyCashSale + amount;
                    }

                    sb.Append("</td>");
                    sb.Append("</tr>");


                  //  AgencyCashSale = AgencyCashSale + (string.IsNullOrEmpty(row["Amount"].ToString()) ? 0 : Convert.ToDouble(row["Amount"]));
                }
                sb.Append("<tr style='border-Top:1px solid' > ");
                sb.Append("<td colspan='5' style='text-align:right'>");
                sb.Append("Total Amount:");
                
                sb.Append("<td colspan='2' style='text-align:right'>");
                sb.Append("<b>" + (Convert.ToDecimal(AgencyCashSale).ToString("#0.00")) + "</b>");
                sb.Append("</td> </tr>");

                #endregion

                #region AgencyCreditSale
                sb.Append("<tr style='border-Top:1px solid' > ");
                sb.Append("<td colspan ='6' style='text-align:left'>");
                sb.Append("<b>(B) Agency Credit Sale </b>");
                sb.Append("</td>");

                sb.Append("<tr style='border-bottom:1px solid' >");
                sb.Append("<td  style='text-align:center'>");
                sb.Append("<b> Sr.No </b> ");
                sb.Append("</td>");

                sb.Append("<td  colspan='2' style='text-align:left'>");
                sb.Append("<b> Product Name </b> ");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l'  style='text-align:center'>");

                sb.Append("<b> Quantity </b> ");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l' colspan='2' style='text-align:right'>");
                sb.Append("<b> Total </b> ");
                sb.Append("</td>");

                sb.Append("</tr>");
                srno = 0;
                foreach (DataRow row in DS.Tables[2].Rows)
                {
                    srno++;
                    sb.Append("<tr>");

                    sb.Append("<td  class='tg-yw4l'    style='text-align:center'>");
                    sb.Append(srno.ToString());
                    sb.Append("</td>");

                    sb.Append("<td  class='tg-yw4l' colspan='2'   style='text-align:left'>");
                    sb.Append(row["ITEM"].ToString());
                    sb.Append("</td>");

                    sb.Append("<td  class='tg-yw4l'  style='text-align:center'>");


                    if (string.IsNullOrEmpty(row["totalreturnQuantity"].ToString()))
                    {
                        sb.Append("<b>" + row["Quantity"].ToString() + "</b>");
                    }
                    else
                    {
                        double quantity = (Convert.ToDouble(row["Quantity"]) - Convert.ToDouble(row["totalreturnQuantity"]));
                        sb.Append("<b>" + quantity + "</b>");
                    }
                    sb.Append("</td>");

                    sb.Append("<td  class='tg-yw4l' colspan='2' style='text-align:right'>");
                    if (string.IsNullOrEmpty(row["totalreturnAmount"].ToString()))
                    {
                        sb.Append("<b>" + (Convert.ToDecimal(row["Amount"]).ToString("#0.00")) + "</b>");
                        AgencyCreditSale = AgencyCreditSale + Convert.ToDouble(row["Amount"]);
                    }
                    else
                    {
                        double amount = (Convert.ToDouble(row["Amount"]) - Convert.ToDouble(row["totalreturnAmount"]));
                        sb.Append("<b>" + (Convert.ToDecimal(amount).ToString("#0.00")) + "</b>");
                        AgencyCreditSale = AgencyCreditSale + amount;
                    }

                    sb.Append("</td>");
                    sb.Append("</tr>");


                    //  AgencyCashSale = AgencyCashSale + (string.IsNullOrEmpty(row["Amount"].ToString()) ? 0 : Convert.ToDouble(row["Amount"]));
                }
                sb.Append("<tr style='border-Top:1px solid' > ");
                sb.Append("<td colspan='5' style='text-align:right'>");
                sb.Append("Total Amount:");

                sb.Append("<td colspan='2' style='text-align:right'>");
                sb.Append("<b>" + (Convert.ToDecimal(AgencyCreditSale).ToString("#0.00")) + "</b>");
                sb.Append("</td> </tr>");

                #endregion




                #region Employee Sale

                sb.Append("<tr style='border-Top:1px solid' > ");
                sb.Append("<td colspan ='6' style='text-align:left'>");
                sb.Append("<b>(C) Employee Sale </b>");
                sb.Append("</td>");

                sb.Append("<tr style='border-bottom:1px solid' >");
                sb.Append("<td  style='text-align:center'>");
                sb.Append("<b> Sr.No </b> ");
                sb.Append("</td>");

                sb.Append("<td  colspan='2' style='text-align:left'>");
                sb.Append("<b> Product Name </b> ");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l'  style='text-align:center'>");

                sb.Append("<b> Quantity </b> ");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l' colspan='2' style='text-align:right'>");
                sb.Append("<b> Total </b> ");
                sb.Append("</td>");

                sb.Append("</tr>");

                foreach (DataRow row in DS.Tables[3].Rows)
                {
                    srno++;
                    sb.Append("<tr>");

                    sb.Append("<td  class='tg-yw4l'    style='text-align:center'>");
                    sb.Append(srno.ToString());
                    sb.Append("</td>");

                    sb.Append("<td  class='tg-yw4l' colspan='2'   style='text-align:left'>");
                    sb.Append(row["ITEM"].ToString());
                    sb.Append("</td>");

                    sb.Append("<td  class='tg-yw4l'  style='text-align:center'>");


                    if (string.IsNullOrEmpty(row["totalreturnQuantity"].ToString()))
                    {
                        sb.Append("<b>" + row["Quantity"].ToString() + "</b>");
                    }
                    else
                    {
                        double quantity = (Convert.ToDouble(row["Quantity"]) - Convert.ToDouble(row["totalreturnQuantity"]));
                        sb.Append("<b>" + quantity + "</b>");
                    }
                    sb.Append("</td>");

                    sb.Append("<td  class='tg-yw4l' colspan='2' style='text-align:right'>");
                    if (string.IsNullOrEmpty(row["totalreturnAmount"].ToString()))
                    {
                        sb.Append("<b>" + (Convert.ToDecimal(row["Amount"]).ToString("#0.00")) + "</b>");
                        EmpSale = EmpSale + Convert.ToDouble(row["Amount"]);
                    }
                    else
                    {
                        double amount = (Convert.ToDouble(row["Amount"]) - Convert.ToDouble(row["totalreturnAmount"]));
                        sb.Append("<b>" + (Convert.ToDecimal(amount).ToString("#0.00")) + "</b>");
                        EmpSale = EmpSale + amount;
                    }

                    sb.Append("</td>");
                    sb.Append("</tr>");


                    //  AgencyCashSale = AgencyCashSale + (string.IsNullOrEmpty(row["Amount"].ToString()) ? 0 : Convert.ToDouble(row["Amount"]));
                }
                sb.Append("<tr style='border-Top:1px solid' > ");
                sb.Append("<td colspan='5' style='text-align:right'>");
                sb.Append("Total Amount:");

                sb.Append("<td colspan='2' style='text-align:right'>");
                sb.Append("<b>" + (Convert.ToDecimal(EmpSale).ToString("#0.00")) + "</b>");
                sb.Append("</td> </tr>");

                #endregion
                if (Convert.ToInt32(dpBrand.SelectedItem.Value) == 1 || Convert.ToInt32(dpBrand.SelectedItem.Value) == 0)
                {
                    #region SchemeTotal

                    sb.Append("<tr style='border-Top:1px solid' > ");
                    sb.Append("<td colspan ='6' style='text-align:left'>");
                    sb.Append("<b>(D) Scheme Received </b>");
                    sb.Append("</td>");


                    sb.Append("<tr style='border-bottom:1px solid'  style='text-align:left'>");
                    sb.Append("<td  colspan='4' style='text-align:left'>");
                    sb.Append("&nbsp;");
                    sb.Append("</td>");


                    sb.Append("<td class='tg-yw4l'  style='text-align:center'>");

                    sb.Append("<b> No.of Scheme </b> ");
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l'  style='text-align:right'>");
                    sb.Append("<b> Total </b> ");
                    sb.Append("</td>");

                    sb.Append("</tr>");
                    sb.Append("<tr>");

                    sb.Append("<td  class='tg-yw4l' colspan='4'  style='text-align:left'>");
                    sb.Append("Total Amount");
                    sb.Append("</td>");

                    sb.Append("<td  class='tg-yw4l'style='text-align:center'>");
                    totalScheme = string.IsNullOrEmpty(DS.Tables[5].Rows[0]["NumberOfScheme"].ToString()) ? 0 : Convert.ToDouble(DS.Tables[5].Rows[0]["NumberOfScheme"]);
                    sb.Append(totalScheme.ToString());
                    sb.Append("</td>");
                    sb.Append("<td  class='tg-yw4l' style='text-align:right'>");
                    schemeTot = string.IsNullOrEmpty(DS.Tables[5].Rows[0]["TotalScheme"].ToString()) ? 0 : Convert.ToDouble(DS.Tables[5].Rows[0]["TotalScheme"]);
                    sb.Append("<b>" + (Convert.ToDecimal(schemeTot).ToString("#0.00")) + "</b>");
                    sb.Append("</td>");

                    sb.Append("</tr>");



                    #endregion
                }
                sb.Append("<tr style='border-Top:1px solid' > ");
                sb.Append("<td colspan ='6' style='text-align:right'>");
                sb.Append("&nbsp;");
                sb.Append("</td>");
                sb.Append("</tr>");

                sb.Append("<tr style='border-Top:1px solid' > ");
                sb.Append("<td colspan ='3' style='text-align:left'>");
                sb.Append("<b> Total Cash Sales <b>");
                sb.Append("</td>");
                sb.Append("<td colspan ='2' style='text-align:left'>");
                sb.Append("<b>Total Credit Sale");
                sb.Append("</td>");
                sb.Append("<td  style='text-align:right'>");
                sb.Append("<b> Total Sale <b>");
                sb.Append("</td>");
                sb.Append("</tr>");
                double cashSale = AgencyCashSale + schemeTot;
                double creditSale = AgencyCreditSale + EmpSale;
                double totalSale = cashSale + creditSale;
                sb.Append("<tr style='border-Top:1px solid' > ");
                sb.Append("<td colspan ='3' style='text-align:left'>");
                sb.Append("<b>" + (Convert.ToDecimal(cashSale).ToString("#0.00")) + "</b>");
                sb.Append("</td>");
                sb.Append("<td  colspan ='2' style='text-align:left'>");
                sb.Append("<b>" + (Convert.ToDecimal(creditSale).ToString("#0.00")) + "</b>");
                sb.Append("</td>");
                sb.Append("<td style='text-align:right'>");
                sb.Append("<b>" + (Convert.ToDecimal(totalSale).ToString("#0.00")) + "</b>");
                sb.Append("</td>");
                sb.Append("</tr>");
                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append("<td colspan='6'>");
                sb.Append("</td>");
                sb.Append("</tr>");

                #region ItemwiseSummary

                sb.Append("<tr>");
                sb.Append("<td> &nbsp; <td>");
                sb.Append("</tr>");
                
                sb.Append("<tr>");
                sb.Append("<td > <b> Itemwise Summary </b> <td>");
                sb.Append("</tr>");

                sb.Append("<tr  style='border-bottom:1px solid'>");
                sb.Append("<td  style='text-align:center'> <b> Sr.No. </b> </td>");
                sb.Append("<td class='tg-yw4l' colspan='2'  style='text-align:left'>");
                sb.Append("<b>Products</b>");
                sb.Append("</td>");
                sb.Append("<td  style='text-align:center'>");
                sb.Append("<b> Quantity</b>");
                sb.Append("</td>");
                sb.Append("<td colspan='2' style='text-align:right'>");
                sb.Append("<b>Amount</b>");
                sb.Append("</td>");
                sb.Append("</tr>");
                double sumTemp = 0;
                srno = 0;
                foreach (DataRow row4 in DS.Tables[4].Rows)
                {
                    srno++;

                    sb.Append("<tr style='border-bottom:1px solid'>");

                    sb.Append("<td class='tg-yw4l'  style='text-align:center'>");
                    sb.Append(srno.ToString());
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l' colspan='2'  style='text-align:left'>");
                    sb.Append("<b>" + row4["ITEM"] + "</b>");
                    sb.Append("</td>");
                    

                    sb.Append("<td class='tg-yw4l'   style='text-align:center'>");
                    if (string.IsNullOrEmpty(row4["totalreturnQuantity"].ToString()))
                    {

                        sb.Append("<b>" + row4["Quantity"].ToString() + "</b>");
                    }
                    else
                    {
                        double quantity = (Convert.ToDouble(row4["Quantity"]) - Convert.ToDouble(row4["totalreturnQuantity"]));
                        sb.Append("<b>" + quantity + "</b>");
                    }

                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l' colspan='2' style='text-align:right'>");
                    if (string.IsNullOrEmpty(row4["totalreturnAmount"].ToString()))
                    {

                        sb.Append("<b>" + (Convert.ToDecimal(row4["Amount"]).ToString("#0.00")) + "</b>");
                        sumTemp = sumTemp + Convert.ToDouble(row4["Amount"]);
                    }
                    else
                    {
                        double amount = (Convert.ToDouble(row4["Amount"]) - Convert.ToDouble(row4["totalreturnAmount"]));
                        sb.Append("<b>" + (Convert.ToDecimal(amount).ToString("#0.00")) + "</b>");
                        sumTemp = sumTemp + (Convert.ToDouble(row4["Amount"]) - Convert.ToDouble(row4["totalreturnAmount"]));
                    }

                    sb.Append("</td>");
                    sb.Append("</tr>");

                }

                sb.Append("<tr>");
                sb.Append("<td colspan = 4 style='text-align:right'>Total<td>");
                sb.Append("<td  style='text-align:right'><b> " + sumTemp.ToString("#0.00") + "</b><td>");
                sb.Append("</tr>");
                #endregion

                result = sb.ToString();
                genratedBIll.Text = result;
                //Session["ctrl"] = sb.ToString();
                Session["ctrl"] = pnlBill;
                //Response.Redirect("/print.aspx", true);


            }
            else
            {
                result = "Report Not Found";
                genratedBIll.Text = result;

            }


        }
    }
}