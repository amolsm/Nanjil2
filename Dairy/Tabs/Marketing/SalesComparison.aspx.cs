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
    public partial class SalesComparison : System.Web.UI.Page
    {
        BillData billdata = new BillData();
        DataSet DS = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDwon();
                txtStartDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                txtEndDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                txtStart2Date.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                txtEnd2Date.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
            }
        }


        public void BindDropDwon()
        {
            DataSet DS = new DataSet();
            DS = BindCommanData.BindCommanDropDwon("RouteID ", "RouteCode +' '+RouteName as Name  ", "routeMaster", "IsArchive=1 ");
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
            DS = BindCommanData.BindCommanDropDwon("TypeID", "TypeName as Name", "TypeMaster", "IsArchive=1 ");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpType.DataSource = DS;
                dpType.DataBind();
                dpType.Items.Insert(0, new ListItem("--All Product Type  --", "0"));

            }
            DS = BindCommanData.BindCommanDropDwon("CommodityID", "CommodityName as Name", "Commodity", "IsArchive=0 ");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpCommodity.DataSource = DS;
                dpCommodity.DataBind();
                dpCommodity.Items.Insert(0, new ListItem("--All Commodity   --", "0"));

            }
        }

        protected void dpBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet DS = new DataSet();
            DS = BindCommanData.BindCommanDropDwon("TypeID", "TypeName as Name", "TypeMaster", "IsArchive=1 and " + "CategoryID=" + Convert.ToInt32(dpBrand.SelectedItem.Value));
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpType.DataSource = DS;
                dpType.DataBind();
                dpType.Items.Insert(0, new ListItem("--All Product Type  --", "0"));

            }

        }

        protected void dpType_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet DS = new DataSet();
            DS = BindCommanData.BindCommanDropDwon("CommodityID", "CommodityName as Name", "Commodity", "IsArchive=0  and " + "TypeID=" + Convert.ToInt32(dpType.SelectedItem.Value));
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpCommodity.DataSource = DS;
                dpCommodity.DataBind();
                dpCommodity.Items.Insert(0, new ListItem("All Commodity", "0"));

            }

        }
        protected void btngenrateBill_click(object sender, EventArgs e)
        {

            DateTime olddate = Convert.ToDateTime(txtStartDate.Text);
            DateTime newdate = Convert.ToDateTime(txtEndDate.Text);
            TimeSpan ts = newdate - olddate;
            int differenceInDays = ts.Days + 1;

            DateTime olddate1 = Convert.ToDateTime(txtStart2Date.Text);
            DateTime newdate1 = Convert.ToDateTime(txtEnd2Date.Text);
            TimeSpan ts1 = newdate1 - olddate1;
            int differenceInDays1 = ts1.Days + 1;

            string result = string.Empty;
            DS = billdata.SalesComparisionreportbyDate((Convert.ToDateTime(txtStartDate.Text)).ToString("dd-MM-yyyy"), (Convert.ToDateTime(txtEndDate.Text)).ToString("dd-MM-yyyy"), (Convert.ToDateTime(txtStart2Date.Text)).ToString("dd-MM-yyyy"), (Convert.ToDateTime(txtEnd2Date.Text)).ToString("dd-MM-yyyy"), Convert.ToInt32(dpRoute.SelectedItem.Value), Convert.ToInt32(dpBrand.SelectedValue), Convert.ToInt32(dpType.SelectedValue), Convert.ToInt32(dpCommodity.SelectedValue));
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                StringBuilder sb = new StringBuilder();


                try
                {
                    DS.Tables[0].PrimaryKey = new[] { DS.Tables[0].Columns["AgentCode"] };
                    DS.Tables[0].PrimaryKey = new[] { DS.Tables[0].Columns["AgentName"] };
                }
                catch (Exception) { }
                try
                {
                    DS.Tables[2].PrimaryKey = new[] { DS.Tables[2].Columns["AgentCode"] };
                    DS.Tables[2].PrimaryKey = new[] { DS.Tables[2].Columns["AgentName"] };
                }
                catch (Exception) { }
                try
                {
                    DS.Tables[0].Merge(DS.Tables[2], false, MissingSchemaAction.Add);

                }
                catch (Exception) { }
                try
                {
                    DS.Tables[1].PrimaryKey = new[] { DS.Tables[1].Columns["AgentCode"] };
                    DS.Tables[1].PrimaryKey = new[] { DS.Tables[1].Columns["AgentName"] };
                }
                catch (Exception) { }
                try
                {
                    DS.Tables[3].PrimaryKey = new[] { DS.Tables[3].Columns["AgentCode"] };
                    DS.Tables[3].PrimaryKey = new[] { DS.Tables[3].Columns["AgentName"] };
                }
                catch (Exception) { }
                try
                {
                    DS.Tables[1].Merge(DS.Tables[3], false, MissingSchemaAction.Add);

                }
                catch (Exception) { }
                try
                {
                    DS.Tables[0].PrimaryKey = new[] { DS.Tables[0].Columns["AgentCode"] };
                    DS.Tables[0].PrimaryKey = new[] { DS.Tables[0].Columns["AgentName"] };
                }
                catch (Exception) { }
                try
                {
                    DS.Tables[1].PrimaryKey = new[] { DS.Tables[1].Columns["AgentCode"] };
                    DS.Tables[1].PrimaryKey = new[] { DS.Tables[1].Columns["AgentName"] };
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
                    sb.Append("<col style = 'width:100px'>");
                    sb.Append("<col style = 'width:100px'>");
                    sb.Append("<col style = 'width:100px'>");
                    sb.Append("<col style = 'width:100px'>");
                    sb.Append("<col style = 'width:150px'>");
                    sb.Append("</colgroup>");

                    sb.Append("<tr>");
                    sb.Append("<th class='tg-yw4l' rowspan='2'>");
                    sb.Append("<img src='/Theme/img/logo1.png' class='img-circle' alt='Logo' width='50px' hight='50px'>");
                    sb.Append("</th>");

                    sb.Append("<th class='tg-baqh' colspan='7' style='text-align:center'>");
                    sb.Append("<b>Nanjil Integrated Dairy Development, Mulagumoodu, K.K.Dt.</b>");
                    sb.Append("</th>");
                    sb.Append("<th class='tg-yw4l' style='text-align:right'>");
                    // sb.Append("TIN:" + DS.Tables[4].Rows[0]["TinNumber"].ToString() + "<br>");
                    sb.Append("");
                    sb.Append("</th>");
                    sb.Append("</tr>");

                    sb.Append("<tr style='border-bottom:1px solid'>");
                    sb.Append("<td class='tg-yw4l' colspan='7' style='text-align:center'>");
                    sb.Append("<u> Agentwise Sales Comparison Report </u> <br/>");

                    sb.Append("</td>");
                    sb.Append("<td class='tg-yw4l' style='text-align:right'>");
                    //sb.Append("PH:248370,248605");
                    sb.Append("");
                    sb.Append("</td> </tr>");

                    sb.Append("<tr style='border-bottom:1px solid'>");
                    sb.Append("<td colspan='2'>");
                    if (dpRoute.SelectedValue == "0")
                    {
                        sb.Append("All Route");
                    }
                    else { sb.Append(dpRoute.SelectedItem.Text); }

                    sb.Append("</td>");
                    sb.Append("<td colspan='2'>");
                    if (dpBrand.SelectedValue == "0")
                    {
                        sb.Append("All Brand");
                    }
                    else { sb.Append(dpBrand.SelectedItem.Text); }

                    sb.Append("</td>");
                    sb.Append("<td colspan='2'>");
                    if (dpType.SelectedValue == "0")
                    {
                        sb.Append("All Product Type");
                    }
                    else { sb.Append(dpType.SelectedItem.Text); }

                    sb.Append("</td>");
                    sb.Append("<td colspan='2'>");
                    if (dpCommodity.SelectedValue == "0")
                    {
                        sb.Append("All Commodity");
                    }
                    else { sb.Append(dpCommodity.SelectedItem.Text); }


                    sb.Append("</td>");
                    sb.Append("<td  style='text-align:right;font-size: 80%;'>");
                    sb.Append(DateTime.Now.ToString("dd-MM-yyyy HH:mm"));
                    sb.Append("</td>");
                    sb.Append("</tr>");

                    sb.Append("<tr style='border-bottom:1px solid'>");
                    sb.Append("<td rowspan='2'>");
                    sb.Append("<b>Sr.No.</b>");
                    sb.Append("</td>");
                    sb.Append("<td rowspan='2'>");
                    sb.Append("<b>Agency</b>");
                    sb.Append("</td>");

                    sb.Append("<td style='font-size: 80%;'>");
                    sb.Append("<b>" + (Convert.ToDateTime(txtStartDate.Text)).ToString("dd-MM-yyyy") + "</b>");
                    sb.Append("</td>");
                    sb.Append("<td colspan='2'style='text-align:center;font-size: 80%;'>");
                    sb.Append("<b>" + (Convert.ToDateTime(txtEndDate.Text)).ToString("dd-MM-yyyy") + "</b>");
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
                    sb.Append("<td colspan='2'  style='text-align:center'>");
                    sb.Append("<b>Average</b>");
                    sb.Append("</td>");


                    sb.Append("<td  style='text-align:center'>");
                    sb.Append("<b>Total Qty</b>");
                    sb.Append("</td>");
                    sb.Append("<td style='text-align:right'>");
                    sb.Append("<b>Average</b>");

                    sb.Append("</td>");


                    sb.Append("</tr>");
                    int srno = 0;


                    DataView view = DS.Tables[0].DefaultView;
                    view.Sort = "AgentCode";
                    DataTable sortagent = view.ToTable();

                    double qty = 0.00;
                    double qty1 = 0.00;
                    double qty2 = 0.00;
                    double qty3 = 0.00;
                    double diffavg = 0.00;
                    double avg = 0.00;
                    double avg1 = 0.00;
                    double totalqty = 0.00;
                    double totalavg = 0.00;
                    double totalqty1 = 0.00;
                    double totalavg1 = 0.00;
                    double diffqty = 0.00;
                    double totaldiffqty = 0.00;
                    double totaldiff = 0.00;

                    foreach (DataRow row in sortagent.Rows)
                    {

                        srno++;

                        sb.Append("<tr>");
                        sb.Append("<td>");
                        sb.Append(srno.ToString());
                        sb.Append("</td>");
                        sb.Append("<td>");
                        sb.Append(row["AgentCode"].ToString() + "&nbsp;" + row["AgentName"].ToString());
                        sb.Append("</td>");



                        sb.Append("<td>");
                        try
                        {
                            qty = Convert.ToDouble(row["Quantity"]);
                        }
                        catch { }
                        try
                        {
                            qty2 = Convert.ToDouble(row["Quantity2"]);

                        }
                        catch { }
                        double sumqty = qty + qty2;
                        totalqty += sumqty;
                        sb.Append(Convert.ToDecimal(sumqty).ToString("0.00"));
                        sb.Append("</td>");
                        sb.Append("<td colspan='2' style='text-align:center'>");
                        avg = sumqty / differenceInDays;
                        totalavg += avg;
                        sb.Append(Convert.ToDecimal(avg).ToString("0.00"));
                        sb.Append("</td>");




                        sb.Append("<td  style='text-align:center'>");
                        try
                        {
                            qty1 = Convert.ToDouble(row["Quantity1"]);
                        }
                        catch { }
                        try
                        {
                            qty3 = Convert.ToDouble(row["Quantity3"]);

                        }
                        catch { }
                        double sumqty1 = qty1 + qty3;
                        totalqty1 += sumqty1;
                        sb.Append(Convert.ToDecimal(sumqty1).ToString("0.00"));
                        sb.Append("</td>");


                        avg1 = sumqty1 / differenceInDays1;
                        totalavg1 += avg1;
                        sb.Append("<td style='text-align:right'>");
                        sb.Append(Convert.ToDecimal(avg1).ToString("0.00"));
                        sb.Append("</td>");

                        sb.Append("<td style='text-align:right'>");
                        diffqty = sumqty1 - sumqty;
                        totaldiffqty += diffqty;
                        sb.Append(Convert.ToDecimal(diffqty).ToString("0.00"));
                        sb.Append("</td>");

                        sb.Append("<td  style='text-align:right'>");

                        diffavg = avg1 - avg;

                        totaldiff += diffavg;
                        sb.Append(Convert.ToDecimal(diffavg).ToString("0.00"));
                        sb.Append("</td>");
                        sb.Append("</tr>");
                        sb.Append("<tr> <td colspan = '9'> &nbsp; </td> </tr>");

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
                    sb.Append("<td colspan='2'  style='text-align:center'>");
                    sb.Append("<b>" + Convert.ToDecimal(totalavg).ToString("0.00") + "</b>");
                    sb.Append("</td>");


                    sb.Append("<td  style='text-align:center'>");
                    sb.Append("<b>" + totalqty1.ToString() + "</b>");
                    sb.Append("</td>");
                    sb.Append("<td style='text-align:right'>");
                    sb.Append("<b>" + Convert.ToDecimal(totalavg1).ToString("0.00") + "</b>");
                    sb.Append("</td>");

                    sb.Append("<td  style='text-align:right'>");
                    sb.Append("<b>" + Convert.ToDecimal(totaldiffqty).ToString("0.00") + "</b>");
                    sb.Append("</td>");

                    sb.Append("<td style='text-align:right'>");
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