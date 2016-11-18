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
    public partial class BoothSalesAnalysisItemwise : System.Web.UI.Page
    {
        BillData billdata = new BillData();
        DataSet DS = new DataSet();
        DataSet DS1 = new DataSet();
        String Str;
        String Str1;
        dynamic qty;
        dynamic qty1;
        double totalquantity;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                DS = BindCommanData.BindCommanDropDwon("CategoryId", "CategoryName as Name", "Category", "IsActive=1");
                if (!Comman.Comman.IsDataSetEmpty(DS))
                {
                    dpBrand.DataSource = DS;
                    dpBrand.DataBind();
                    dpBrand.Items.Insert(0, new ListItem("--Select Brand--", "0"));

                }
                DS.Clear();
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
            string result = string.Empty;
            DS1 = billdata.BoothSalesAnalysisitemwise2ByDate((Convert.ToDateTime(txtStartDate.Text)).ToString("dd-MM-yyyy"), (Convert.ToDateTime(txtEndDate.Text)).ToString("dd-MM-yyyy"), Convert.ToInt32(dpAgent.SelectedItem.Value), Convert.ToInt32(dpBrand.SelectedValue));
            DS = billdata.BoothSalesAnalysisitemwiseByDate((Convert.ToDateTime(txtStartDate.Text)).ToString("dd-MM-yyyy"), (Convert.ToDateTime(txtEndDate.Text)).ToString("dd-MM-yyyy"), Convert.ToInt32(dpAgent.SelectedItem.Value), Convert.ToInt32(dpBrand.SelectedValue));
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                StringBuilder sb = new StringBuilder();

                DataTable dt1 = new DataTable();
                dt1 = DS1.Tables[0];

                DataTable dt2 = new DataTable();
                dt2 = DS1.Tables[2];
                dt2.Merge(dt1);
                dt2.AcceptChanges();
                DataView view = new DataView(dt2);
                DataTable distinctValues = view.ToTable(true, "ITEM");
                //       var result1 = dt1.AsEnumerable()
                //.Union(dt2.AsEnumerable())
                //.GroupBy(d => d.Field<string>("ProductName"));



                DataTable dt3 = new DataTable();
                dt3 = DS1.Tables[1];

                DataTable dt4 = new DataTable();
                dt4 = DS1.Tables[3];
                dt4.Merge(dt3);
                dt4.AcceptChanges();

                DataView view1 = new DataView(dt4);
                DataTable distinctValues1 = view1.ToTable(true, "ProductType");

                DataTable dt9 = new DataTable();
                dt9 = DS1.Tables[4];

                DataTable dt10 = new DataTable();
                dt10 = DS1.Tables[5];
                dt10.Merge(dt9);
                dt10.AcceptChanges();

                //        var result2 = dt3.AsEnumerable()
                //.Union(dt4.AsEnumerable())
                //.GroupBy(d => d.Field<string>("ProductType"));



                sb.Append("<style type='text / css'>");
                sb.Append(".tg  { border - collapse:collapse; border - spacing:0; border: none; }");
                sb.Append(".tg .tg-yw4l{vertical-align:top}");
                sb.Append(".tg .tg-baqh{text-align:center;vertical-align:top}");
                sb.Append("</style>");
                sb.Append("<table class='tg style1' style='page-break-inside:avoid; align:center;'>");
                sb.Append("<colgroup>");
                sb.Append("<col style = 'width:160px'>");
                sb.Append("<col style = 'width:150px'>");
                sb.Append("<col style = 'width:150px'>");
                sb.Append("<col style = 'width:150px'>");
                sb.Append("<col style = 'width:150px'>");
                sb.Append("<col style = 'width:150px'>");
                sb.Append("<col style = 'width:150px'>");
                sb.Append("<col style = 'width:150px'>");
                sb.Append("</colgroup>");

                sb.Append("<tr>");
                sb.Append("<th class='tg-yw4l' rowspan='2'>");
                sb.Append("<img src='/Theme/img/logo1.png' class='img-circle' alt='Logo' width='50px' hight='50px'>");
                sb.Append("</th>");

                sb.Append("<th class='tg-baqh' colspan='7' style='text-align:center'>");
                sb.Append("<u> Booth Sales Analysis- Itemwise </u> <br/>");
                sb.Append("</th>");

                sb.Append("<th class='tg-yw4l' style='text-align:right'>");

                sb.Append("TIN:330761667331<br>");
                sb.Append("</th>");
                sb.Append("</tr>");

                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append("<td class='tg-yw4l' colspan='7' style='text-align:center'>");
                sb.Append("<b>Nanjil Integrated Dairy Development, Mulagumoodu, K.K.Dt.</b>");

                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l' style='text-align:right'>");

                sb.Append("PH:248370,248605");

                sb.Append("</td>");

                sb.Append("<tr>");
                sb.Append("<td class='tg-yw4l' colspan='5' style='text-align:left'>");
                sb.Append("Start Date:" + Convert.ToDateTime(txtStartDate.Text).ToString("dd-MM-yyyy"));
                sb.Append("</td>");
                sb.Append("<td class='tg-yw4l' colspan='4' style='text-align:right'>");
                sb.Append("End Date:" + Convert.ToDateTime(txtEndDate.Text).ToString("dd-MM-yyyy"));
                sb.Append("</td>");
                sb.Append("</tr>");

                sb.Append("<tr style='border-bottom:2px solid'>");
                sb.Append("<td class='tg-yw4l' colspan='5' style='text-align:left'>");
                if (Convert.ToInt32(dpAgent.SelectedItem.Value) == 0)
                {
                    sb.Append("Booth : " + "All");
                }
                else
                {
                    sb.Append("Booth : " + dpAgent.SelectedItem.Text.ToString());
                }
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l' colspan='4'  style='text-align:right'>");
                sb.Append("Date : " + DateTime.Now.ToString("dd-MM-yyyy"));
                sb.Append("</td>");
                sb.Append("</tr>");
                sb.Append("</tr>");

                sb.Append("<tr style='border-bottom:1px solid'> ");
                sb.Append("<td class='tg-yw4l' colspan='9' style='text-align:left'>");
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


                sb.Append("<td class='tg-yw4l' colspan='2'  style='text-align:left'>");
                sb.Append("<b>ITEM </b>");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l' style='text-align:center'>");
                sb.Append("<b>Despatch</b>");
                sb.Append("</td>");



                sb.Append("<td class='tg-yw4l'  style='text-align:center'>");
                sb.Append("<b>Total Return</b>");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l'  style='text-align:center'>");
                sb.Append("<b>Gift/Other</b>");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l' style='text-align:center'>");
                sb.Append("<b>Good Quality</b>");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l' style='text-align:center'>");
                sb.Append("<b>Spot Damage</b>");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l'  style='text-align:center'>");
                sb.Append("<b>Final Despatch</b>");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l' style='text-align:center'>");
                sb.Append("<b>Sales</b>");
                sb.Append("</td>");


                sb.Append("</tr>");



                foreach (DataRow row2 in DS.Tables[2].Rows)
                {



                    foreach (DataRow row in DS.Tables[0].Rows)
                    {
                        if (row2["ProductType"].ToString() == row["ProductType"].ToString())
                        {


                            sb.Append("<tr>");


                            sb.Append("<td class='tg-yw4l' colspan='2'  style='text-align:left'>");
                            sb.Append(row["ITEM"].ToString());
                            sb.Append("</td>");

                            sb.Append("<td class='tg-yw4l' style='text-align:center'>");
                            sb.Append(row["Despatch"].ToString());
                            sb.Append("</td>");




                            sb.Append("<td class='tg-yw4l' style='text-align:center'>");
                            sb.Append(row["Return"].ToString());
                            sb.Append("</td>");

                            sb.Append("<td class='tg-yw4l' style='text-align:center'>");
                            sb.Append(row["Sample"].ToString());
                            sb.Append("</td>");

                            sb.Append("<td class='tg-yw4l' style='text-align:center'>");
                            sb.Append(row["Quality"].ToString());
                            sb.Append("</td>");


                            sb.Append("<td class='tg-yw4l'style='text-align:center'>");
                            sb.Append(row["SpotDam"].ToString());
                            sb.Append("</td>");

                            sb.Append("<td class='tg-yw4l' style='text-align:center'>");
                            if (row["Return"].ToString() == "")
                            {
                                sb.Append("<b>" + row["Despatch"] + "</b>");
                            }
                            else
                            {
                                try
                                {
                                    double subquantity = (Convert.ToDouble(row["Despatch"]) - Convert.ToDouble(row["Return"]));
                                    sb.Append("<b>" + subquantity + "</b>");
                                }
                                catch (Exception ex)
                                {
                                }

                            }


                            sb.Append("</td>");

                            sb.Append("<td class='tg-yw4l'style='text-align:center'>");
                            foreach (DataRow row6 in distinctValues.Rows)
                            {
                                if (row6["ITEM"].ToString() == row["ITEM"].ToString())
                                {
                                    Str1 = row6["ITEM"].ToString().Replace("''", "");


                                    if (Str1 != "")
                                    {

                                        qty1 = dt2.AsEnumerable().Where(rows => rows.Field<dynamic>("ITEM") == Str1).Sum(rows => rows.Field<double>("Qty"));
                                        sb.Append("<b>" + qty1 + "</b>");

                                    }

                                }
                            }
                            sb.Append("</td>");
                            sb.Append("</tr>");
                        }
                        else { }
                    }


                    sb.Append("<tr style='border-bottom:1px solid'> <td colspan = '9'> &nbsp; </td> </tr>");
                    sb.Append("<tr style='border-bottom:1px solid'>");
                    sb.Append("<td class='tg-yw4l' style='text-align:left'>");
                    sb.Append("SubTotal ");
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l'  style='text-align:center'>");
                    sb.Append(row2["ProductType"].ToString());
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l'   style='text-align:center'>");
                    sb.Append(row2["Despatch"].ToString());
                    sb.Append("</td>");



                    sb.Append("<td class='tg-yw4l' style='text-align:center'>");
                    sb.Append(row2["Return"].ToString());
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l' style='text-align:center'>");
                    sb.Append(row2["Sample"].ToString());
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l' style='text-align:center'>");
                    sb.Append(row2["Quality"].ToString());
                    sb.Append("</td>");


                    sb.Append("<td class='tg-yw4l'  style='text-align:center'>");
                    sb.Append(row2["SpotDam"].ToString());
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l' style='text-align:center'>");
                    if (row2["Return"].ToString() == "")
                    {
                        sb.Append("<b>" + row2["Despatch"] + "</b>");
                    }
                    else
                    {
                        try
                        {
                            double subquantity = (Convert.ToDouble(row2["Despatch"]) - Convert.ToDouble(row2["Return"]));
                            sb.Append("<b>" + subquantity + "</b>");
                        }
                        catch (Exception ex)
                        {
                        }

                    }
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l' style='text-align:center'>");
                    foreach (DataRow row5 in distinctValues1.Rows)
                    {
                        if (row5["ProductType"].ToString() == row2["ProductType"].ToString())
                        {
                            Str = row5["ProductType"].ToString().Replace("''", "");


                            if (Str != "")
                            {

                                qty = dt4.AsEnumerable().Where(row => row.Field<dynamic>("ProductType") == Str).Sum(row => row.Field<double>("Qty"));
                                sb.Append("<b>" + qty + "</b>");

                            }

                        }
                    }

                    sb.Append("</td>");
                    sb.Append("</tr>");



                }




                sb.Append("<tr style='border-bottom:1px solid'> <td colspan = '9'> &nbsp; </td> </tr>");
                sb.Append("<tr style='border-bottom:1px solid'>");

                sb.Append("<td class='tg-yw4l' colspan='2' style='text-align:left'>");
                sb.Append("Grand Total");
                sb.Append("</td>");
                sb.Append("<td class='tg-yw4l'   style='text-align:center'>");
                sb.Append("<b>" + DS.Tables[1].Rows[0]["TotalDespatch"] + "</b>");
                sb.Append("</td>");



                sb.Append("<td class='tg-yw4l' style='text-align:center'>");
                sb.Append("<b>" + DS.Tables[1].Rows[0]["TotalReturn"] + "</b>");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l' style='text-align:center'>");
                sb.Append("<b>" + DS.Tables[1].Rows[0]["TotalSample"] + "</b>");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l' style='text-align:center'>");
                sb.Append("<b>" + DS.Tables[1].Rows[0]["TotalQuality"] + "</b>");
                sb.Append("</td>");


                sb.Append("<td class='tg-yw4l'style='text-align:center'>");
                sb.Append("<b>" + DS.Tables[1].Rows[0]["TotalSpotDam"] + "</b>");
                sb.Append("</td>");


                sb.Append("<td class='tg-yw4l'   style='text-align:center'>");

                if (!DBNull.Value.Equals(DS.Tables[1].Rows[0]["TotalReturn"]))
                {
                    totalquantity = (Convert.ToDouble(DS.Tables[1].Rows[0]["TotalDespatch"]) - Convert.ToDouble(DS.Tables[1].Rows[0]["TotalReturn"]));
                    sb.Append("<b>" + totalquantity + "</b>");
                }
                else
                {


                    try
                    {
                        totalquantity = (Convert.ToDouble(DS.Tables[1].Rows[0]["TotalDespatch"]));
                        sb.Append("<b>" + totalquantity + "</b>");
                    }
                    catch (Exception ex)
                    {

                    }
                }
                sb.Append("</td>");
                sb.Append("<td class='tg-yw4l' style='text-align:center'>");
                object sumObject1;
                sumObject1 = dt10.Compute("Sum(Qty)", "");
                if (totalquantity != 0.0)
                {
                    sb.Append("<b>" + sumObject1.ToString() + "</b>");
                }
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