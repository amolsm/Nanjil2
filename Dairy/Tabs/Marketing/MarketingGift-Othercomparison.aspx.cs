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
    public partial class Marketing_Gift_Othercomparison : System.Web.UI.Page
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
                txtStart1Date.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                txtEnd1Date.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                txtStart2Date.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                txtEnd2Date.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
            }
        }

        protected void btngenrateBill_Click(object sender, EventArgs e)
        {

            DateTime olddate = Convert.ToDateTime(txtStart1Date.Text);
            DateTime newdate = Convert.ToDateTime(txtEnd1Date.Text);
            TimeSpan ts = newdate - olddate;
            int differenceInDays = ts.Days + 1;

            DateTime olddate1 = Convert.ToDateTime(txtStart2Date.Text);
            DateTime newdate1 = Convert.ToDateTime(txtEnd2Date.Text);
            TimeSpan ts1 = newdate1 - olddate1;
            int differenceInDays1 = ts1.Days + 1;

            string result = string.Empty;

            DS = billdata.GiftOtherComparisonReportbyDate((Convert.ToDateTime(txtStart1Date.Text)).ToString("dd-MM-yyyy"), (Convert.ToDateTime(txtEnd1Date.Text)).ToString("dd-MM-yyyy"), (Convert.ToDateTime(txtStart2Date.Text)).ToString("dd-MM-yyyy"), (Convert.ToDateTime(txtEnd2Date.Text)).ToString("dd-MM-yyyy"), Convert.ToInt32(dpRoute.SelectedItem.Value), Convert.ToInt32(dpBrand.SelectedValue));
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                StringBuilder sb = new StringBuilder();
                //for subtotal quantity
                try
                {
                    DS.Tables[3].PrimaryKey = new[] { DS.Tables[3].Columns["TypeID"] };
                    DS.Tables[3].PrimaryKey = new[] { DS.Tables[3].Columns["TypeName"] };
                }
                catch (Exception) { }
                try
                {
                    DS.Tables[4].PrimaryKey = new[] { DS.Tables[4].Columns["TypeID"] };
                    DS.Tables[4].PrimaryKey = new[] { DS.Tables[4].Columns["TypeName"] };

                }
                catch (Exception) { }
                try
                {
                    DS.Tables[3].Merge(DS.Tables[4], false, MissingSchemaAction.Add);

                }
                catch (Exception) { }

                //--------for product quantity

                try
                {
                    DS.Tables[0].PrimaryKey = new[] { DS.Tables[0].Columns["ITEM"] };
                }
                catch (Exception) { }
                try
                {
                    DS.Tables[0].PrimaryKey = new[] { DS.Tables[0].Columns["ITEM"] };
                }
                catch (Exception) { }
                try
                {
                    DS.Tables[0].Merge(DS.Tables[1], false, MissingSchemaAction.Add);

                }
                catch (Exception) { }
                try
                {

                    sb.Append("<style type='text / css'>");
                    sb.Append(".tg  { border - collapse:collapse; border - spacing:0; border: none; }");
                    sb.Append(".tg .tg-yw4l{vertical-align:top}");
                    sb.Append(".tg .tg-baqh{text-align:center;vertical-align:top}");
                    sb.Append("</style>");
                    //sb.Append("<table class='tg style1' style='page-break-inside:avoid; align:center;'>");
                    sb.Append("<table class='tg style1'  style=' position:relative;align:center;'>");
                    sb.Append("<colgroup>");
                    sb.Append("<col style = 'width:40px'>");
                    sb.Append("<col style = 'width:200px'>");
                    sb.Append("<col style = 'width:100px'>");
                    sb.Append("<col style = 'width:100px'>");
                    sb.Append("<col style = 'width:120px'>");
                    sb.Append("<col style = 'width:100px'>");
                    sb.Append("<col style = 'width:100px'>");
                    sb.Append("<col style = 'width:100px'>");
                    sb.Append("</colgroup>");

                    sb.Append("<tr>");
                    sb.Append("<th class='tg-yw4l' rowspan='2'>");
                    sb.Append("<img src='/Theme/img/logo1.png' class='img-circle' alt='Logo' width='50px' hight='50px'>");
                    sb.Append("</th>");

                    sb.Append("<th class='tg-baqh' colspan='7' style='text-align:center'>");
                    sb.Append("<b>Nanjil Integrated Dairy Development, Mulagumoodu, K.K.Dt.</b>");

                    sb.Append("</th>");
                    sb.Append("<th class='tg-yw4l' style='text-align:right'>");
                    // sb.Append("TIN:" + DS.Tables[2].Rows[0]["TinNumber"].ToString() + "<br>");
                    sb.Append("GSTIN:&nbsp;33AAECN2463R1Z2<br>");
                    sb.Append("</th>");
                    sb.Append("</tr>");

                    sb.Append("<tr style='border-bottom:1px solid'>");
                    sb.Append("<td class='tg-yw4l' colspan='7' style='text-align:center'>");
                    sb.Append("<b><u>Marketing Gift/Other Comparison Reports </u></b> <br/>");
                    sb.Append("</td>");
                    sb.Append("<td class='tg-yw4l' style='text-align:right'>");
                    sb.Append("PH:248370,248605");
                    sb.Append("</td> </tr>");

                    sb.Append("<tr style='border-bottom:1px solid'>");
                    sb.Append("<td colspan='2'>");
                    sb.Append("Route :" + "&nbsp;" + dpRoute.SelectedItem.Text);
                    sb.Append("</td>");
                    sb.Append("<td colspan='6'>");
                    sb.Append("Brand :" + "&nbsp;" + dpBrand.SelectedItem.Text);
                    sb.Append("</td>");
                    sb.Append("<td  style='text-align:right'>");
                    sb.Append(DateTime.Now.ToString("dd-mm-yyyy HH:mm"));
                    sb.Append("</td>");
                    sb.Append("</tr>");

                    sb.Append("<tr style='border-bottom:1px solid'>");
                    sb.Append("<td rowspan='2'>");
                    sb.Append("<b>Sr.No.</b>");
                    sb.Append("</td>");
                    sb.Append("<td rowspan='2'>");
                    sb.Append("<b>ITEM</b>");
                    sb.Append("</td>");

                    sb.Append("<td style='font-size: 80%;'>");
                    sb.Append("<b>" + (Convert.ToDateTime(txtStart1Date.Text)).ToString("dd-MM-yyyy") + "</b>");
                    sb.Append("</td>");
                    sb.Append("<td colspan='2' style='text-align:center;font-size: 80%;'>");
                    sb.Append("<b>" + (Convert.ToDateTime(txtEnd1Date.Text)).ToString("dd-MM-yyyy") + "</b>");
                    sb.Append("</td>");


                    sb.Append("<td style='text-align:center;font-size: 80%;'>");
                    sb.Append("<b>" + (Convert.ToDateTime(txtStart2Date.Text)).ToString("dd-MM-yyyy") + "</b>");
                    sb.Append("</td>");
                    sb.Append("<td style='text-align:right;font-size: 80%;'>");
                    sb.Append("<b>" + (Convert.ToDateTime(txtEnd2Date.Text)).ToString("dd-MM-yyyy") + "</b>");
                    sb.Append("</td>");

                    sb.Append("<td rowspan='2' style='text-align:right'>");
                    sb.Append("<b>Diff.Quantity</b>");
                    sb.Append("</td>");

                    sb.Append("<td rowspan='2' style='text-align:right'>");
                    sb.Append("<b>Avg.Diff.</b>");
                    sb.Append("</td>");

                    sb.Append("</tr>");
                    sb.Append("<tr style='border-bottom:1px solid'>");
                    sb.Append("<td>");
                    sb.Append("<b>Total Qty</b>");
                    sb.Append("</td>");
                    sb.Append("<td colspan='2' style='text-align:center'>");
                    sb.Append("<b>Average</b>");
                    sb.Append("</td>");


                    sb.Append("<td style='text-align:center'>");
                    sb.Append("<b>Total Qty</b>");
                    sb.Append("</td>");
                    sb.Append("<td style='text-align:right'>");
                    sb.Append("<b>Average</b>");

                    sb.Append("</td>");


                    sb.Append("</tr>");
                    int srno = 0;


                    DataView view = DS.Tables[0].DefaultView;
                    view.Sort = "TypeID ASC";
                    DataTable sortagent = view.ToTable();
                    DataView view1 = DS.Tables[3].DefaultView;
                    view1.Sort = "TypeID ASC";
                    DataTable sorttype = view1.ToTable();
                    double qty = 0.00;
                    double qty1 = 0.00;
                    double diffavg = 0.00;
                    double avg = 0.00;
                    double avg1 = 0.00;
                    double totalqty = 0.00;
                    double totalavg = 0.00;
                    double totalqty1 = 0.00;
                    double totalavg1 = 0.00;
                    double totaldiff = 0.00;
                    double diffqty = 0.00;
                    double totaldiffqty = 0.00;
                    double subavg = 0.00;
                    double subavg1 = 0.00;

                    foreach (DataRow row2 in sorttype.Rows)
                    {
                        sb.Append("<tr> <td colspan = '9'> &nbsp; </td> </tr>");

                        foreach (DataRow row in sortagent.Rows)
                        {


                            if (row2["TypeID"].ToString() == row["TypeID"].ToString() || row2["TypeID"].ToString() == row["TypeID1"].ToString())
                            {

                                srno++;

                                sb.Append("<tr>");
                                sb.Append("<td>");
                                sb.Append(srno.ToString());
                                sb.Append("</td>");
                                sb.Append("<td>");
                                sb.Append(row["ITEM"].ToString());
                                sb.Append("</td>");


                                sb.Append("<td>");
                                try
                                {
                                    qty = Convert.ToDouble(row["Quantity"]);
                                    totalqty += qty;
                                }
                                catch { qty = 0.00; }
                                sb.Append(qty.ToString());
                                sb.Append("</td>");
                                sb.Append("<td colspan='2' style='text-align:center'>");

                                avg = qty / differenceInDays;
                                totalavg += avg;
                                sb.Append(Convert.ToDecimal(avg).ToString("0.00"));
                                sb.Append("</td>");
                                try
                                {
                                    qty1 = Convert.ToDouble(row["Quantity1"]);
                                    totalqty1 += qty1;
                                }
                                catch { qty1 = 0.00; }
                                sb.Append("<td style='text-align:center'>");
                                sb.Append(qty1.ToString());
                                sb.Append("</td>");


                                avg1 = qty1 / differenceInDays1;
                                totalavg1 += avg1;
                                sb.Append("<td style='text-align:right'>");
                                sb.Append(Convert.ToDecimal(avg1).ToString("0.00"));
                                sb.Append("</td>");

                                sb.Append("<td  style='text-align:right'>");
                                diffqty = qty1 - qty;
                                totaldiffqty += diffqty;
                                sb.Append(Convert.ToDecimal(diffqty).ToString("0.00"));
                                sb.Append("</td>");


                                sb.Append("<td  style='text-align:right'>");

                                diffavg = avg1 - avg;
                                totaldiff += diffavg;
                                sb.Append(Convert.ToDecimal(diffavg).ToString("0.00"));
                                sb.Append("</td>");
                                sb.Append("</tr>");


                            }


                            else { }
                        }

                        sb.Append("<tr style='border-bottom:1px solid' > <td colspan = '9'> &nbsp; </td> </tr>");
                        sb.Append("<tr style='border-bottom:1px solid'>");
                        sb.Append("<td >");
                        sb.Append("<b>" + srno.ToString() + "</b>");
                        sb.Append("</td>");
                        sb.Append("<td >");
                        sb.Append(row2["TypeName"].ToString());
                        sb.Append("</td>");

                        sb.Append("<td>");
                        double subqty = 0.00;
                        try
                        {

                            subqty = Convert.ToDouble(row2["Quantity"]);
                            subavg = subqty / differenceInDays;

                        }
                        catch { subqty = 0.00; subavg = 0.00; }
                        sb.Append(subqty.ToString());
                        sb.Append("</td>");
                        sb.Append("<td colspan='2' style='text-align:center'>");
                        sb.Append("<b>" + Convert.ToDecimal(subavg).ToString("0.00") + "</b>");
                        sb.Append("</td>");


                        sb.Append("<td style='text-align:center'>");
                        double subqty1 = 0.00;
                        try
                        {

                            subqty1 = Convert.ToDouble(row2["Quantity1"]);
                            subavg1 = subqty1 / differenceInDays1;

                        }
                        catch { subqty1 = 0.00; subavg1 = 0.00; }
                        sb.Append(subqty1.ToString());
                        sb.Append("</td>");
                        sb.Append("<td style='text-align:right'>");
                        sb.Append("<b>" + Convert.ToDecimal(subavg1).ToString("0.00") + "</b>");
                        sb.Append("</td>");

                        sb.Append("<td  style='text-align:right'>");
                        double diffsubqty = subqty1 - subqty;
                        sb.Append("<b>" + Convert.ToDecimal(diffsubqty).ToString("0.00") + "</b>");
                        sb.Append("</td>");

                        sb.Append("<td  style='text-align:right'>");
                        double diffsubavg = subavg1 - subavg;
                        sb.Append("<b>" + Convert.ToDecimal(diffsubavg).ToString("0.00") + "</b>");
                        sb.Append("</td>");
                        sb.Append("</tr>");
                    }


                    sb.Append("<tr style='border-bottom:1px solid' > <td colspan = '9'> &nbsp; </td> </tr>");
                    sb.Append("<tr style='border-bottom:1px solid'>");
                    sb.Append("<td >");
                    sb.Append("<b>" + srno.ToString() + "</b>");
                    sb.Append("</td>");
                    sb.Append("<td >");
                    sb.Append("<b>Total:</b>");
                    sb.Append("</td>");

                    sb.Append("<td>");
                    sb.Append("<b>" + totalqty.ToString() + "</b>");
                    sb.Append("</td>");
                    sb.Append("<td colspan='2' style='text-align:center'>");
                    sb.Append("<b>" + Convert.ToDecimal(totalavg).ToString("0.00") + "</b>");
                    sb.Append("</td>");


                    sb.Append("<td style='text-align:center'>");
                    sb.Append("<b>" + totalqty1.ToString() + "</b>");
                    sb.Append("</td>");
                    sb.Append("<td style='text-align:right'>");
                    sb.Append("<b>" + Convert.ToDecimal(totalavg1).ToString("0.00") + "</b>");
                    sb.Append("</td>");

                    sb.Append("<td  style='text-align:right'>");
                    sb.Append("<b>" + Convert.ToDecimal(totaldiffqty).ToString("0.00") + "</b>");
                    sb.Append("</td>");

                    sb.Append("<td  style='text-align:right'>");
                    sb.Append("<b>" + Convert.ToDecimal(totaldiff).ToString("0.00") + "</b>");
                    sb.Append("</td>");



                    sb.Append("</tr>");




                    result = sb.ToString();
                    genratedBIll.Text = result;

                    Session["ctrl"] = pnlBill;


                }

                catch (Exception)
                {
                    result = "Comparison Report not found";
                    genratedBIll.Text = result;
                }

            }
            else
            {
                result = "Comparison Report not found";
                genratedBIll.Text = result;

            }
        }
    }
}