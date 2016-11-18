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
    public partial class Boothitemwisesalessummary : System.Web.UI.Page
    {
        BillData billdata = new BillData();
        DataSet DS = new DataSet();

        String Str;

        string unit;
        dynamic qty;
        dynamic total;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                DS = BindCommanData.BindCommanDropDwon("CategoryId", "CategoryName as Name", "Category", "IsActive=1");
                if (!Comman.Comman.IsDataSetEmpty(DS))
                {
                    dpBrand.DataSource = DS;
                    dpBrand.DataBind();
                    dpBrand.Items.Insert(0, new ListItem("--All Brand--", "0"));
                }
                DS = BindCommanData.BindCommanDropDwon("AgentID", "AgentCode+' '+AgentName as Name", "AgentMaster", "IsArchive=0 and Agensytype='Booth' Order by AgentCode");
                if (!Comman.Comman.IsDataSetEmpty(DS))
                {
                    dpAgent.DataSource = DS;
                    dpAgent.DataBind();
                    dpAgent.Items.Insert(0, new ListItem("--Select Booth  --", "0"));

                }
                txtStartDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                txtEndDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
            }
        }

        protected void btngenrateBill_click(object sender, EventArgs e)
        {
            double noofscheme = 0;
            double totalscheme = 0;
            string result = string.Empty;
            DS = billdata.BoothItemwiseSalesSummaryByDate((Convert.ToDateTime(txtStartDate.Text)).ToString("dd-MM-yyyy"), (Convert.ToDateTime(txtEndDate.Text)).ToString("dd-MM-yyyy"), Convert.ToInt32(dpAgent.SelectedItem.Value), Convert.ToInt32(dpBrand.SelectedValue));
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
                sb.Append("<u>Booth Itemwise Sales Summary </u> <br/>");
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
                sb.Append("<td class='tg-yw4l' colspan='2' style='text-align:left'>");
                sb.Append("Start Date:" + Convert.ToDateTime(txtStartDate.Text).ToString("dd-MM-yyyy"));
                sb.Append("</td>");
                sb.Append("<td class='tg-yw4l' colspan='3' style='text-align:center'>");
                if (Convert.ToInt32(dpBrand.SelectedItem.Value) == 0)
                {
                    sb.Append("Brand Name : " + "All");
                }
                else
                {
                    sb.Append("Brand Name : " + dpBrand.SelectedItem.Text.ToString());
                }
                sb.Append("</td>");
                sb.Append("<td class='tg-yw4l' colspan='2' style='text-align:right'>");
                sb.Append("End Date:" + Convert.ToDateTime(txtEndDate.Text).ToString("dd-MM-yyyy"));
                sb.Append("</td>");
                sb.Append("<tr style='border-bottom:2px solid'>");
                sb.Append("<td class='tg-yw4l' colspan='4' style='text-align:left'>");

                if (Convert.ToInt32(dpAgent.SelectedItem.Value) == 0)
                {
                    sb.Append("Booth : " + "All");
                }
                else
                {
                    sb.Append("Booth : " + dpAgent.SelectedItem.Text.ToString());
                }
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l' colspan='3'  style='text-align:right'>");
                sb.Append("Date : " + DateTime.Now.ToString("dd-MM-yyyy"));
                sb.Append("</td>");
                sb.Append("</tr>");
                sb.Append("</tr>");

                sb.Append("<tr style='border-bottom:1px solid'> ");
                sb.Append("<td class='tg-yw4l' colspan='7' style='text-align:left'>");

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



                sb.Append("<td class='tg-yw4l' style='text-align:right'>");
                sb.Append("<b>Amount</b>");
                sb.Append("</td>");

                sb.Append("</tr>");







                DataTable dt = new DataTable();
                dt = DS.Tables[0];
                DataTable dt1 = new DataTable();
                dt1 = DS.Tables[3];
                dt1.Merge(dt);
                dt1.AcceptChanges();



                DataTable dt2 = new DataTable();
                dt2 = DS.Tables[1];

                DataTable dt3 = new DataTable();
                dt3 = DS.Tables[4];
                dt3.Merge(dt2);
                dt3.AcceptChanges();

                DataTable dt4 = new DataTable();
                dt4 = DS.Tables[2];
                DataTable dt5 = new DataTable();
                dt5 = DS.Tables[5];
                dt5.Merge(dt4);
                dt5.AcceptChanges();


                //find out distict datatable column value
                DataView view = new DataView(dt3);
                DataTable distinctValues = view.ToTable(true, "ProductName", "Unit");
                //DataView view1 = new DataView(dt1);
                //DataTable distinctValues1 = view.ToTable(true, "ProductName");





                //find out all qty amt of distinct product

                foreach (DataRow row6 in distinctValues.Rows)
                {

                    sb.Append("<tr style='border-bottom:1px solid'> <td colspan = '7'> &nbsp; </td> </tr>");
                    sb.Append("<tr style='border-bottom:1px solid'>");


                    foreach (DataRow row5 in dt3.Rows)
                    {

                        if (row6["ProductName"] == row5["ProductName"])
                        {


                            Str = row6["ProductName"].ToString().Replace("''", "");
                            unit = row6["Unit"].ToString();

                            if (Str != "")
                            {

                                qty = dt3.AsEnumerable().Where(row => row.Field<dynamic>("ProductName") == Str).Sum(row => row.Field<double>("Qty"));
                                total = dt3.AsEnumerable().Where(row => row.Field<dynamic>("ProductName") == Str).Sum(row => row.Field<decimal>("Total"));

                            }




                        }
                    }
                    sb.Append("<td class='tg-yw4l' colspan='4'  style='text-align:left'>");
                    sb.Append("<b>" + Str.ToString() + "</b>");
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l' colspan='2'  style='text-align:center'>");
                    sb.Append("<b>" + qty.ToString() + "&nbsp;" + unit.ToString() + "</b>");

                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l'  style='text-align:right'>");
                    sb.Append("<b>" + (Convert.ToDouble(total).ToString("#.00")) + "</b>");


                    sb.Append("</td>");
                    sb.Append("</tr>");
                   // var NewDt1 = dt1.AsEnumerable()
                   //.OrderBy(r => r.Field<decimal>("Rate"))
                   //.CopyToDataTable();
                    foreach (DataRow row8 in dt1.Rows)
                    {
                        if (row6["ProductName"].ToString() == row8["ProductName"].ToString())
                        {

                            sb.Append("<td class='tg-yw4l' colspan='2' style='text-align:left'>");
                            sb.Append(row8["ProductName"].ToString());
                            sb.Append("</td>");

                            sb.Append("<td class='tg-yw4l' colspan='2'  style='text-align:center'>");
                            sb.Append((Convert.ToDecimal(row8["Rate"]).ToString("#.00")));

                            sb.Append("</td>");
                            sb.Append("<td class='tg-yw4l' colspan='2' style='text-align:center'>");
                            sb.Append((Convert.ToDouble(row8["Qty"]).ToString("#.##")) + "&nbsp;" + row8["Unit"].ToString());
                            sb.Append("</td>");
                            sb.Append("<td class='tg-yw4l'  style='text-align:right'>");

                            sb.Append((Convert.ToDouble(row8["total"]).ToString("#.00")));

                            sb.Append("</td>");
                            sb.Append("</tr>");
                        }



                    }


                }




















                sb.Append("<tr style='border-bottom:1px solid'> <td colspan = '7'> &nbsp; </td> </tr>");
                //sb.Append("<tr style='border-bottom:1px solid'>");
                //sb.Append("<td class='tg-yw4l' colspan='4' style='text-align:left'>");
                //sb.Append("<b>" + "Total" + "</b>");
                //sb.Append("</td>");


                //sb.Append("<td class='tg-yw4l' colspan='2' style='text-align:center'>");
                ////object sumObject1;
                ////sumObject1 = dt5.Compute("Sum(Qty)", "");

                ////sb.Append("<b>" + sumObject1.ToString() + "</b>");


                //sb.Append("</td>");



                //// Declare an object variable.
                //object sumObject;
                //sumObject = dt5.Compute("Sum(Total)", "");

                //sb.Append("<td class='tg-yw4l' style='text-align:right'>");


                ////sb.Append("<b>" + sumObject.ToString() + "</b>");
                //try
                //{
                //    double totalamount = Convert.ToDouble(sumObject);

                //    sb.Append("<b>" + (Convert.ToDouble(totalamount).ToString("#.00")) + "</b>");
                //}
                //catch
                //{
                //}

                //sb.Append("</td>");


                //sb.Append("</tr>");
                if(dpBrand.SelectedItem.Value=="1" || dpBrand.SelectedItem.Value=="0")
                { 
                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append("<td class='tg-yw4l' colspan='4' style='text-align:left'>");
                sb.Append("<b>" + "TotalScheme" + "</b>");
                sb.Append("</td>");
                sb.Append("<td class='tg-yw4l' colspan='2' style='text-align:center'>");

                noofscheme = string.IsNullOrEmpty(DS.Tables[6].Rows[0]["NumberOfScheme"].ToString()) ? 0 : Convert.ToDouble(DS.Tables[6].Rows[0]["NumberOfScheme"]);
                sb.Append("<b>" + noofscheme + "</b>");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l' style='text-align:right'>");
                totalscheme = string.IsNullOrEmpty(DS.Tables[6].Rows[0]["TotalScheme"].ToString()) ? 0 : Convert.ToDouble(DS.Tables[6].Rows[0]["TotalScheme"]);
                sb.Append("<b>" + (Convert.ToDouble(totalscheme).ToString("#.00")) + "</b>");
                sb.Append("</td>");
                sb.Append("</tr>");
                }
                sb.Append("<tr style='border-bottom:1px solid'>");
                double agentcreditsales = string.IsNullOrEmpty(DS.Tables[10].Rows[0]["Total"].ToString()) ? 0 : Convert.ToDouble(DS.Tables[10].Rows[0]["Total"]);
                double agentcashsales = string.IsNullOrEmpty(DS.Tables[9].Rows[0]["Total"].ToString()) ? 0 : Convert.ToDouble(DS.Tables[9].Rows[0]["Total"]);
                double employeesales = string.IsNullOrEmpty(DS.Tables[7].Rows[0]["Total"].ToString()) ? 0 : Convert.ToDouble(DS.Tables[7].Rows[0]["Total"]);
                double localsales = string.IsNullOrEmpty(DS.Tables[8].Rows[0]["Total"].ToString()) ? 0 : Convert.ToDouble(DS.Tables[8].Rows[0]["Total"]);
                double cashSale = agentcashsales + totalscheme + localsales;
                double creditSale = agentcreditsales + employeesales;
                double totalSale = cashSale + creditSale;
                sb.Append("<td colspan ='4' style='text-align:left'>");
                sb.Append("<b>" + "Total Cash Sale" + "&nbsp;" + (Convert.ToDecimal(cashSale).ToString("#0.00")) + "</b>");
                sb.Append("</td>");
                sb.Append("<td  colspan ='2' style='text-align:left'>");
                sb.Append("<b>" + "Total Credit Sale" + "&nbsp;" + (Convert.ToDecimal(creditSale).ToString("#0.00")) + "</b>");
                sb.Append("</td>");
                sb.Append("<td style='text-align:right'>");
                sb.Append("<b>" + "Total Sale" + "&nbsp;" + (Convert.ToDecimal(totalSale).ToString("#0.00")) + "</b>");
                sb.Append("</td>");


                sb.Append("</tr>");



                result = sb.ToString();
                genratedBIll.Text = result;

                Session["ctrl"] = pnlBill;


            }
            else
            {
                result = "Order not FOund";
                genratedBIll.Text = result;

            }
        }

    }
}