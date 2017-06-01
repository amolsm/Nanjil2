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
    public partial class AgentSlabReportList : System.Web.UI.Page
    {
        DataSet DS;
        MarketingData marketingdata;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDownList();
                txtStartDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                txtEndDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));


            }
        }
        public void BindDropDownList()
        {
            DS = new DataSet();
            DS = BindCommanData.BindCommanDropDwon("RouteID ", "RouteCode +' '+RouteName as Name  ", "routeMaster", "IsArchive=1");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpRoute.DataSource = DS;
                dpRoute.DataBind();
                dpRoute.Items.Insert(0, new ListItem("--All Route--", "0"));
            }

            DS = BindCommanData.BindCommanDropDwon("TypeID", "TypeName as Name", "TypeMaster", "IsArchive=1 ");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpProductType.DataSource = DS;
                dpProductType.DataBind();
                dpProductType.Items.Insert(0, new ListItem("--Select Product Type  --", "0"));
            }
            DS = BindCommanData.BindCommanDropDwon("SlabID", "SlabName as Name", "SlabMaster", "IsArchive=0 ");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpSlab.DataSource = DS;
                dpSlab.DataBind();
                dpSlab.Items.Insert(0, new ListItem("-- All Slab --", "0"));
            }


        }
        protected void btnViewDetails_Click(object sender, EventArgs e)
        {
            string result = string.Empty;
            marketingdata = new MarketingData();
            DS = new DataSet();


            DS = marketingdata.ViewAgentSlabReportList((Convert.ToDateTime(txtStartDate.Text)).ToString("dd-MM-yyyy"), (Convert.ToDateTime(txtEndDate.Text)).ToString("dd-MM-yyyy"), Convert.ToInt32(dpRoute.SelectedItem.Value), Convert.ToInt32(dpSlab.SelectedItem.Value), Convert.ToInt32(dpProductType.SelectedItem.Value));
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                StringBuilder sb = new StringBuilder();
                try
                {
                    DS.Tables[0].PrimaryKey = new[] { DS.Tables[0].Columns["AgentID"] };
                    DS.Tables[0].PrimaryKey = new[] { DS.Tables[0].Columns["AgentCode"] };
                    DS.Tables[1].PrimaryKey = new[] { DS.Tables[0].Columns["AgentID"] };
                    DS.Tables[1].PrimaryKey = new[] { DS.Tables[0].Columns["AgentCode"] };
                }
                catch (Exception) { }

                try
                {
                    DS.Tables[0].Merge(DS.Tables[1], false, MissingSchemaAction.Add);

                }
                catch (Exception) { }
                try
                {
                    DS.Tables[3].PrimaryKey = new[] { DS.Tables[3].Columns["AgentID"] };
                    DS.Tables[3].PrimaryKey = new[] { DS.Tables[3].Columns["AgentCode"] };
                }
                catch (Exception) { }
                try
                {
                    DS.Tables[0].Merge(DS.Tables[3], false, MissingSchemaAction.Add);

                }
                catch (Exception) { }

                sb.Append("<style type='text / css'>");
                sb.Append(".tg  { border - collapse:collapse; border - spacing:0; border: none; }");
                sb.Append(".tg .tg-yw4l{vertical-align:top}");
                sb.Append(".tg .tg-baqh{text-align:center;vertical-align:top}");
                sb.Append("</style>");
                //sb.Append("<table class='tg style1' style='page-break-inside:avoid; align:center;'>");
                sb.Append("<table class='tg style1'  style=' position:relative;align:center;'>");
                sb.Append("<colgroup>");
                sb.Append("<col style = 'width:80px'>");
                sb.Append("<col style = 'width:100px'>");
                sb.Append("<col style = 'width:160px'>");
                sb.Append("<col style = 'width:100px'>");
                sb.Append("<col style = 'width:100px'>");
                sb.Append("<col style = 'width:100px'>");


                sb.Append("</colgroup>");

                sb.Append("<tr>");
                sb.Append("<th class='tg-yw4l' rowspan='2'>");
                sb.Append("<img src='/Theme/img/logo1.png' class='img-circle' alt='Logo' width='50px' hight='50px'>");
                sb.Append("</th>");

                sb.Append("<th class='tg-baqh' colspan='4' style='text-align:center'>");
                sb.Append("<b>Nanjil Integrated Dairy Development, Mulagumoodu, K.K.Dt.</b>");
                sb.Append("</th>");
                sb.Append("<th class='tg-yw4l' style='text-align:right'>");
                sb.Append("&nbsp;<br>");
                sb.Append("</th>");
                sb.Append("</tr>");

                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append("<td class='tg-yw4l' colspan='4' style='text-align:center'>");

                sb.Append("<b><u>AgentList Basis Of Slab Report</u> </b><br/>");
                sb.Append("</td>");
                sb.Append("<td class='tg-yw4l' style='text-align:right'>");
                sb.Append("PH:248370,248605");
                sb.Append("</td> </tr>");

                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append("<td colspan='2'>");
                if (dpRoute.SelectedItem.Value == "0")
                {
                    sb.Append("All Route");
                }
                else
                {
                    sb.Append(dpRoute.SelectedItem.Text);
                }

                sb.Append("</td>");
                sb.Append("<td  colspan='2' style='text-align:right'>");
                sb.Append(Convert.ToDateTime(txtStartDate.Text).ToString("dd-MM-yyyy"));
                sb.Append("</td>");
                sb.Append("<td  colspan='2' style='text-align:right'>");
                sb.Append(Convert.ToDateTime(txtEndDate.Text).ToString("dd-MM-yyyy"));

                sb.Append("</td>");
                sb.Append("</tr>");
                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append("<td colspan='2' style='text-align:left'>");
                if (dpSlab.SelectedItem.Value == "0")
                {
                    sb.Append("All Slab");
                }
                else
                {
                    sb.Append(dpSlab.SelectedItem.Text);
                }
                sb.Append("</td>");
                sb.Append("<td colspan='2' style='text-align:left'>");
                sb.Append(dpProductType.SelectedItem.Text);
                sb.Append("</td>");
                sb.Append("<td colspan='2' style='text-align:right'>");
                sb.Append(DateTime.Now.ToString("dd-MM-yyyy HH:mm"));

                sb.Append("</td>");
                sb.Append("</tr>");

                sb.Append("<tr><td colspan='6'>&nbsp;</td></tr>");
                sb.Append("<tr style='border-bottom:1px solid'><td colspan='6'></td></tr>");

                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append("<td>");
                sb.Append("<b>Sr.No.</b>");
                sb.Append("</td>");
                sb.Append("<td>");
                sb.Append("<b>Agency Code</b>");
                sb.Append("</td>");
                sb.Append("<td colspan = '2'>");
                sb.Append("<b>Agency Name</b>");
                sb.Append("</td>");
                sb.Append("<td>");
                sb.Append("<b>TotalQty.</b>");
                sb.Append("</td>");
                sb.Append("<td>");
                sb.Append("<b>Average</b>");
                sb.Append("</td>");


                sb.Append("</tr>");
                int srno = 0;
                DateTime olddate = Convert.ToDateTime(txtStartDate.Text);
                DateTime newdate = Convert.ToDateTime(txtEndDate.Text);
                TimeSpan ts = newdate - olddate;
                int differenceInDays = ts.Days + 1;
                int routsno = 0;
                double totalqty = 0;
                double totalavg = 0;
                foreach (DataRow rows in DS.Tables[2].Rows)
                {
                    routsno++;
                    sb.Append("<tr style='border-bottom:1px solid'>");
                    sb.Append("<td colspan='6'>");
                    sb.Append(rows["SlabName"].ToString());
                    sb.Append("</td>");
                    sb.Append("</tr>");
                    //sb.Append("<tr><td colspan='6'>&nbsp;</td></tr>");
                    //sb.Append("<tr style='border-bottom:1px solid'><td colspan='6'></td></tr>");
                    sb.Append("<tr style='border-bottom:1px solid'>");
                    sb.Append("<td>");
                    sb.Append(routsno.ToString());
                    sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append(rows["RouteCode"].ToString());
                    sb.Append("</td>");
                    sb.Append("<td colspan = '4'>");
                    sb.Append(rows["RouteName"].ToString());
                    sb.Append("</td>");
                    sb.Append("</tr>");
                    double qty = 0;
                    double avg = 0;
                    double qty1 = 0;
                    double qty2 = 0;
                    double subtotalqty = 0;
                    double subtotalavg = 0;
                    int subcountsrno = 0;
                    foreach (DataRow row in DS.Tables[0].Rows)
                    {
                        if (row["AgentName"].ToString() != "" && rows["SlabID"].ToString() == row["SlabID"].ToString())
                        {
                            if (row["AgentName"].ToString() != "" && rows["RouteID"].ToString() == row["RouteID"].ToString())
                            {
                                srno++;
                                subcountsrno++;
                                sb.Append("<tr>");
                                sb.Append("<td>");
                                sb.Append(srno.ToString());
                                sb.Append("</td>");
                                sb.Append("<td>");
                                sb.Append(row["AgentCode"].ToString());
                                sb.Append("</td>");
                                sb.Append("<td colspan = '2'>");
                                sb.Append(row["AgentName"].ToString());
                                sb.Append("</td>");
                                sb.Append("<td>");
                                try { qty1 = Convert.ToDouble(row["Quantity"]); } catch { qty1 = 0; }
                                try
                                { qty2 = Convert.ToDouble(row["Quantity1"]); }
                                catch { qty2 = 0; }
                                qty = qty1 + qty2;
                                sb.Append(Convert.ToDecimal(qty).ToString("#.##"));
                                sb.Append("</td>");
                                sb.Append("<td>");
                                try
                                {

                                   
                                    subtotalqty += qty;
                                    totalqty += qty;
                                    avg = qty / differenceInDays;
                                    subtotalavg += avg;
                                    totalavg += avg;
                                    sb.Append(Convert.ToDecimal(avg).ToString("#.##"));
                                }
                                catch { sb.Append("&nbsp;"); qty = 0; avg = 0; }

                                sb.Append("</td>");

                                sb.Append("</tr>");


                            }

                        }


                    }
                    sb.Append("<tr style='border-bottom:1px solid'><td colspan='6'></td></tr>");
                    sb.Append("<tr style='border-bottom:1px solid'>");
                    sb.Append("<td colspan = '4'>");
                    sb.Append(subcountsrno.ToString());
                    sb.Append("</td>");
                    sb.Append("<td >");
                    sb.Append(Convert.ToDecimal(subtotalqty).ToString("#.##"));
                    sb.Append("</td>");
                    sb.Append("<td >");
                    sb.Append(Convert.ToDecimal(subtotalavg).ToString("#.##"));
                    sb.Append("</td>");
                    sb.Append("</tr>");
                    sb.Append("<tr><td colspan='6'>&nbsp;</td></tr>");
                    sb.Append("<tr style='border-bottom:1px solid'><td colspan='6'></td></tr>");
                }
                sb.Append("<tr style='border-bottom:1px solid'><td colspan='6'></td></tr>");
                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append("<td colspan = '4'>");
                sb.Append(srno.ToString());
                sb.Append("</td>");
                sb.Append("<td >");
                sb.Append(Convert.ToDecimal(totalqty).ToString("#.##"));
                sb.Append("</td>");
                sb.Append("<td >");
                sb.Append(Convert.ToDecimal(totalavg).ToString("#.##"));
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
                result = " Report Not found";
                genratedBIll.Text = result;

            }

        }
    }
}