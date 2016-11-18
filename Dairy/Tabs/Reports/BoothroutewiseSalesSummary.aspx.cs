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
    public partial class BoothroutewiseSalesSummary : System.Web.UI.Page
    {
        BillData billdata = new BillData();
        DataSet DS = new DataSet();
        DataSet DS1 = new DataSet();
        string unit;
        dynamic qty;
        dynamic total;
        string name;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                EmployeeData empData = new EmployeeData();
                DS = BindCommanData.BindCommanDropDwon("AgentID", "AgentCode+' '+AgentName as Name", "AgentMaster", "IsArchive=0 and Agensytype='Booth'");
                if (!Comman.Comman.IsDataSetEmpty(DS))
                {
                    dpAgent.DataSource = DS;
                    dpAgent.DataBind();
                    dpAgent.Items.Insert(0, new ListItem("--Select Booth --", "0"));
                }
                DS = BindCommanData.BindCommanDropDwon("CategoryId", "CategoryName as Name", "Category", "IsActive=1");
                if (!Comman.Comman.IsDataSetEmpty(DS))
                {
                    dpBrand.DataSource = DS;
                    dpBrand.DataBind();
                    dpBrand.Items.Insert(0, new ListItem("--All Brand--", "0"));

                }
                txtDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));

            }
        }

        protected void btngenrateBill_click(object sender, EventArgs e)
        {
            int srno = 0;
            double AgencyCashSale = 0;
            double AgencyCreditSale = 0;
            double LocalSale = 0;
            double EmpSale = 0;
            double schemeTot = 0;
            double totalScheme = 0;
            string result = string.Empty;
            DS = billdata.GenerateBoothRoteSalesSummary((Convert.ToDateTime(txtDate.Text)).ToString("dd-MM-yyyy"), Convert.ToInt32(dpAgent.SelectedItem.Value), Convert.ToInt32(dpBrand.SelectedValue));
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
                sb.Append("<u>   Booth Sales Summary </u> <br/>");
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
                sb.Append("Sales Date:" + Convert.ToDateTime(txtDate.Text).ToString("dd-MM-yyyy"));
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
                sb.Append("");
                sb.Append("</td>");

                sb.Append("<tr style='border-bottom:2px solid'>");
                sb.Append("<td class='tg-yw4l' colspan='3' style='text-align:left'>");

                if (Convert.ToInt32(dpAgent.SelectedItem.Value) == 0)
                {
                    sb.Append("Route : " + "All");
                }
                else
                {
                    sb.Append("Route : " + dpAgent.SelectedItem.Text.ToString());
                }
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l' colspan='3'  style='text-align:right'>");
                sb.Append("Date : " + DateTime.Now.ToString("dd-MM-yyyy"));
                sb.Append("</td>");
                sb.Append("</tr>");
                sb.Append("</tr>");



                #region Employee Sale

                sb.Append("<tr style='border-Top:1px solid' > ");
                sb.Append("<td colspan ='6' style='text-align:left'>");
                sb.Append("<b>(A) Staff Sale </b>");
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



                    sb.Append("<b>" + row["Qty"].ToString() + row["Unit"].ToString() + "</b>");

                    sb.Append("</td>");

                    sb.Append("<td  class='tg-yw4l' colspan='2' style='text-align:right'>");

                    sb.Append("<b>" + (Convert.ToDecimal(row["Total"]).ToString("#0.00")) + "</b>");
                    EmpSale = EmpSale + Convert.ToDouble(row["Total"]);


                    sb.Append("</td>");
                    sb.Append("</tr>");



                }
                sb.Append("<tr style='border-Top:1px solid' > ");
                sb.Append("<td colspan='5' style='text-align:right'>");
                sb.Append("Total Amount:");

                sb.Append("<td colspan='2' style='text-align:right'>");
                sb.Append("<b>" + (Convert.ToDecimal(EmpSale).ToString("#0.00")) + "</b>");
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



                    sb.Append("<b>" + row["Qty"].ToString() + row["Unit"].ToString() + "</b>");

                    sb.Append("</td>");

                    sb.Append("<td  class='tg-yw4l' colspan='2' style='text-align:right'>");

                    sb.Append("<b>" + (Convert.ToDecimal(row["Total"]).ToString("#0.00")) + "</b>");
                    AgencyCreditSale = AgencyCreditSale + Convert.ToDouble(row["Total"]);



                    sb.Append("</td>");
                    sb.Append("</tr>");



                }
                sb.Append("<tr style='border-Top:1px solid' > ");
                sb.Append("<td colspan='5' style='text-align:right'>");
                sb.Append("Total Amount:");

                sb.Append("<td colspan='2' style='text-align:right'>");
                sb.Append("<b>" + (Convert.ToDecimal(AgencyCreditSale).ToString("#0.00")) + "</b>");
                sb.Append("</td> </tr>");

                #endregion

                #region AgencyCashSale
                sb.Append("<tr style='border-Top:1px solid' > ");
                sb.Append("<td colspan ='6' style='text-align:left'>");
                sb.Append("<b>(C) Agency Cash Sale </b>");
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
                foreach (DataRow row in DS.Tables[0].Rows)
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



                    sb.Append("<b>" + row["Qty"].ToString() + row["Unit"].ToString() + "</b>");

                    sb.Append("</td>");

                    sb.Append("<td  class='tg-yw4l' colspan='2' style='text-align:right'>");

                    sb.Append("<b>" + (Convert.ToDecimal(row["Total"]).ToString("#0.00")) + "</b>");
                    AgencyCashSale = AgencyCashSale + Convert.ToDouble(row["Total"]);



                    sb.Append("</td>");
                    sb.Append("</tr>");



                }
                sb.Append("<tr style='border-Top:1px solid' > ");
                sb.Append("<td colspan='5' style='text-align:right'>");
                sb.Append("Total Amount:");

                sb.Append("<td colspan='2' style='text-align:right'>");
                sb.Append("<b>" + (Convert.ToDecimal(AgencyCashSale).ToString("#0.00")) + "</b>");
                sb.Append("</td> </tr>");

                #endregion

                

                #region LocalSale
                sb.Append("<tr style='border-Top:1px solid' > ");
                sb.Append("<td colspan ='6' style='text-align:left'>");
                sb.Append("<b>(D)Local Sale </b>");
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



                    sb.Append("<b>" + row["Qty"].ToString() + row["Unit"].ToString() + "</b>");

                    sb.Append("</td>");

                    sb.Append("<td  class='tg-yw4l' colspan='2' style='text-align:right'>");

                    sb.Append("<b>" + (Convert.ToDecimal(row["Total"]).ToString("#0.00")) + "</b>");
                    LocalSale = LocalSale + Convert.ToDouble(row["Total"]);



                    sb.Append("</td>");
                    sb.Append("</tr>");



                }
                sb.Append("<tr style='border-Top:1px solid' > ");
                sb.Append("<td colspan='5' style='text-align:right'>");
                sb.Append("Total Amount:");

                sb.Append("<td colspan='2' style='text-align:right'>");
                sb.Append("<b>" + (Convert.ToDecimal(LocalSale).ToString("#0.00")) + "</b>");
                sb.Append("</td> </tr>");

                #endregion


                

                if (dpBrand.SelectedItem.Value == "1" || dpBrand.SelectedItem.Value == "0")
                { 
                 #region SchemeTotal

                sb.Append("<tr style='border-Top:1px solid' > ");
                sb.Append("<td colspan ='6' style='text-align:left'>");
                sb.Append("<b>(E) Scheme Received </b>");
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
                totalScheme = string.IsNullOrEmpty(DS.Tables[4].Rows[0]["CountScheme"].ToString()) ? 0 : Convert.ToDouble(DS.Tables[4].Rows[0]["CountScheme"]);
                sb.Append(totalScheme.ToString());
                sb.Append("</td>");
                sb.Append("<td  class='tg-yw4l' style='text-align:right'>");
                schemeTot = string.IsNullOrEmpty(DS.Tables[4].Rows[0]["TotalSchemeAmount"].ToString()) ? 0 : Convert.ToDouble(DS.Tables[4].Rows[0]["TotalSchemeAmount"]);
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
                double cashSale = AgencyCashSale + schemeTot + LocalSale;
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
                DataTable dt = new DataTable();
                dt = DS.Tables[5];
                DataTable dt1 = new DataTable();
                dt1 = DS.Tables[2];
                dt1.Merge(dt);
                dt1.AcceptChanges();

                var query = dt1.AsEnumerable().GroupBy(row => new { Name = row.Field<string>("ITEM"), UnitName = row.Field<string>("Unit") });

                var table2 = dt1.Clone(); // empty table with same schema

                double sumTemp = 0;
                srno = 0;
                foreach (var x in query)
                {
                    srno++;
                    name = x.Key.Name;


                    qty = x.Sum(r => r.Field<double>("Qty"));
                    unit = x.Key.UnitName;
                    total = x.Sum(r => r.Field<decimal>("Total"));

                    table2.Rows.Add(x.Key.Name, qty, x.Key.UnitName, total);


                    sb.Append("<tr style='border-bottom:1px solid'>");

                    sb.Append("<td class='tg-yw4l'  style='text-align:center'>");
                    sb.Append(srno.ToString());
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l' colspan='2'  style='text-align:left'>");
                    sb.Append("<b>" + name.ToString() + "</b>");
                    sb.Append("</td>");


                    sb.Append("<td class='tg-yw4l'   style='text-align:center'>");

                    sb.Append("<b>" + qty.ToString() + unit.ToString() + "</b>");


                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l' colspan='2' style='text-align:right'>");

                    sb.Append("<b>" + total.ToString("#0.00") + "</b>");
                    sumTemp = sumTemp + Convert.ToDouble(total);


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
