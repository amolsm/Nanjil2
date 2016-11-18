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
    public partial class ItemwiseOrderSummary : System.Web.UI.Page
    {
        BillData billdata = new BillData();
        DataSet DS = new DataSet();
        DataSet DS1 = new DataSet();
        double totalstaffamount=0.00;
        double totalagentcreditamount=0.00;
        double totalscheme;
        double totalamount;
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
            DS = billdata.GenrateReportByDate((Convert.ToDateTime(txtStartDate.Text)).ToString("dd-MM-yyyy"), (Convert.ToDateTime(txtEndDate.Text)).ToString("dd-MM-yyyy"), Convert.ToInt32(dpRoute.SelectedItem.Value), Convert.ToInt32(dpBrand.SelectedValue));
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
                sb.Append("<col style = 'width:140px'>");
                sb.Append("<col style = 'width:140px'>");
                sb.Append("<col style = 'width:140px'>");
                sb.Append("<col style = 'width:100px'>");
                sb.Append("<col style = 'width:100px'>");
                sb.Append("<col style = 'width:100px'>");
                sb.Append("</colgroup>");

                sb.Append("<tr>");
                sb.Append("<th class='tg-yw4l' rowspan='2'>");
                sb.Append("<img src='/Theme/img/logo1.png' class='img-circle' alt='Logo' width='50px' hight='50px'>");
                sb.Append("</th>");

                sb.Append("<th class='tg-baqh' colspan='4' style='text-align:center'>");
                sb.Append("<u> Itemwise Order Summary </u> <br/>");
                sb.Append("</th>");

                sb.Append("<th class='tg-yw4l' style='text-align:right'>");

                sb.Append("TIN:330761667331<br>");
                sb.Append("</th>");
                sb.Append("</tr>");

                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append("<td class='tg-yw4l' colspan='4' style='text-align:center'>");
                sb.Append("<b>Nanjil Integrated Dairy Development, Mulagumoodu, K.K.Dt.</b>");

                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l' style='text-align:right'>");

                sb.Append("PH:248370,248605");

                sb.Append("</td>");

                sb.Append("<tr>");
                sb.Append("<td class='tg-yw4l' colspan='3' style='text-align:left'>");
                sb.Append("Start Date:" + Convert.ToDateTime(txtStartDate.Text).ToString("dd-MM-yyyy"));
                sb.Append("</td>");
                sb.Append("<td class='tg-yw4l' colspan='3' style='text-align:right'>");
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

                sb.Append("<tr style='border-bottom:1px solid'> ");
                sb.Append("<td class='tg-yw4l' colspan='6' style='text-align:left'>");
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

                sb.Append("<td class='tg-yw4l' colspan='3' style='text-align:left'>");
                sb.Append("<b>ITEM </b>");
                sb.Append("</td>");


                sb.Append("<td class='tg-yw4l' colspan='2'  style='text-align:center'>");
                sb.Append("<b>Quantity</b>");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l'  style='text-align:right'>");
                sb.Append("<b>Amount</b>");
                sb.Append("</td>");




                sb.Append("</tr>");


                foreach (DataRow row in DS.Tables[0].Rows)
                {




                    sb.Append("<td class='tg-yw4l' colspan='3'  style='text-align:left'>");
                    sb.Append(row["ITEM"].ToString());
                    sb.Append("</td>");



                    sb.Append("<td class='tg-yw4l' colspan='2'  style='text-align:center'>");
                    sb.Append(row["Quantity"].ToString());
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l'  style='text-align:right'>");
                    sb.Append((Convert.ToDecimal(row["Amount"]).ToString("#0.00")));
                    sb.Append("</td>");


                    sb.Append("</tr>");


                }

                if (Convert.ToInt32(dpBrand.SelectedItem.Value) == 1|| Convert.ToInt32(dpBrand.SelectedItem.Value) == 0)
                {
                    sb.Append("<tr style='border-bottom:1px solid'> <td colspan = '6'> &nbsp; </td> </tr>");
                    sb.Append("<tr style='border-bottom:1px solid'>");
                    sb.Append("<td  colspan='2' class='tg-yw4l'  style='text-align:left'>");
                    sb.Append("<b>" + "Total Scheme" + "</b>");
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l'  style='text-align:center'>");
                    sb.Append("&nbsp;");
                    sb.Append("</td>");
                    sb.Append("<td class='tg-yw4l' colspan='2'  style='text-align:center'>");
                    double noofscheme;
                    try
                    {
                        noofscheme = (string.IsNullOrEmpty(DS.Tables[4].Rows[0]["NumberOfScheme"].ToString()) ? 0 : Convert.ToDouble(DS.Tables[4].Rows[0]["NumberOfScheme"]));
                        sb.Append("<b>" + noofscheme + "</b>");
                    }
                    catch (Exception ex)
                    { }



                    sb.Append("</td>");



                    sb.Append("<td class='tg-yw4l' style='text-align:right'>");

                    try
                    {
                        totalscheme = (Convert.ToDouble(DS.Tables[4].Rows[0]["TotalScheme"]));
                        sb.Append("<b>" + (Convert.ToDecimal(totalscheme).ToString("#0.00")) + "</b>");

                    }
                    catch (Exception ex)
                    {

                    }
                    sb.Append("</td>");
                    sb.Append("</tr>");

                }

                sb.Append("<tr style='border-bottom:1px solid'> <td colspan = '6'> &nbsp; </td> </tr>");
                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append("<td  colspan='2' class='tg-yw4l'  style='text-align:left'>");
                totalamount = (string.IsNullOrEmpty(DS.Tables[1].Rows[0]["totalAmount"].ToString()) ? 0 : Convert.ToDouble(DS.Tables[1].Rows[0]["totalAmount"]));
                totalamount += totalscheme;
                sb.Append("Total Amt:" + "<b>" + (Convert.ToDecimal(totalamount).ToString("#0.00")) + "</b>");

                sb.Append("</td>");
                sb.Append("<td class='tg-yw4l'  style='text-align:right'>");
                sb.Append("Receipt");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l'  style='text-align:center'>");
                try
                {
                    totalagentcash = (string.IsNullOrEmpty(DS.Tables[2].Rows[0]["AgentAmount"].ToString()) ? 0 : Convert.ToDouble(DS.Tables[2].Rows[0]["AgentAmount"]));
                    totalreceipt = totalagentcash + totalscheme;
                }
                catch (Exception ex)
                { }

                sb.Append("<b>" + (Convert.ToDecimal(totalreceipt).ToString("#0.00")) + "</b>");
                sb.Append("</td>");
                sb.Append("</td>");
                sb.Append("<td class='tg-yw4l'  style='text-align:right'>");
                sb.Append("Staff & A.C:");
                sb.Append("</td>");
                sb.Append("<td class='tg-yw4l'  style='text-align:right'>");


                try
                {

                    totalstaffamount = (string.IsNullOrEmpty(DS.Tables[3].Rows[0]["StaffAmount"].ToString()) ? 0 : Convert.ToDouble(DS.Tables[3].Rows[0]["StaffAmount"]));
                }
                catch (Exception ex) { }


                try
                {

                    totalagentcreditamount = (string.IsNullOrEmpty(DS.Tables[5].Rows[0]["AgentCreditAmount"].ToString()) ? 0 : Convert.ToDouble(DS.Tables[5].Rows[0]["AgentCreditAmount"]));

                 
                    }
                    catch (Exception ex)
                { string msg = ex.ToString(); }
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