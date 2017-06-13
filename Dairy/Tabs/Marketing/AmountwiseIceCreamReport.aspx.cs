using Bussiness;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using System.Text;

namespace Dairy.Tabs.Marketing
{
    public partial class AmountwiseIceCreamReport : System.Web.UI.Page
    {
        MarketingData marketingdata = new MarketingData();
        DataSet DS = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DS = BindCommanData.BindCommanDropDwon("RouteID ", "RouteCode +' '+RouteName as Name  ", "routeMaster", "IsArchive=1");
                if (!Comman.Comman.IsDataSetEmpty(DS))
                {
                    dpRoute.DataSource = DS;
                    dpRoute.DataBind();
                    dpRoute.Items.Insert(0, new ListItem("-All Route-", "0"));
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
                    dpCommodity.Items.Insert(0, new ListItem("--All Commodity Type  --", "0"));

                }
                txtStartDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                txtEndDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
            }
        }

        protected void btnViewDetails_Click(object sender, EventArgs e)
        {   string result = string.Empty;
            DS = marketingdata.AmountwiseIceCreamReport((Convert.ToDateTime(txtStartDate.Text)).ToString("dd-MM-yyyy"), (Convert.ToDateTime(txtEndDate.Text)).ToString("dd-MM-yyyy"), Convert.ToInt32(dpRoute.SelectedItem.Value), Convert.ToInt32(dpType.SelectedItem.Value), Convert.ToInt32(dpCommodity.SelectedItem.Value), Convert.ToDouble(txtStartAmt.Text),Convert.ToDouble(txtEndAmt.Text));
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                StringBuilder sb = new StringBuilder();
               

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
                sb.Append("<col style = 'width:200px'>");
                sb.Append("<col style = 'width:100px'>");

                sb.Append("</colgroup>");

                sb.Append("<tr>");
                sb.Append("<th class='tg-yw4l' rowspan='2'>");
                sb.Append("<img src='/Theme/img/logo1.png' class='img-circle' alt='Logo' width='50px' hight='50px'>");
                sb.Append("</th>");

                sb.Append("<th class='tg-baqh' colspan='2' style='text-align:center'>");
                sb.Append("<b>Nanjil Integrated Dairy Development, Mulagumoodu, K.K.Dt.PH:248370,248605 </b>");
                sb.Append("</th>");
                sb.Append("<th class='tg-yw4l' style='text-align:right'>");
                sb.Append("TIN:330761667331<br>");
                sb.Append("</th>");
                sb.Append("</tr>");

                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append("<td class='tg-yw4l' colspan='4' style='text-align:center'>");
               
                sb.Append("<b><u>Amountwise Product Type Purchase Agents</u></b> <br/>");
                sb.Append("</td>");
                sb.Append("</tr>");

                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append("<td colspan='2' style='text-align:left'>");
                if (dpRoute.SelectedItem.Value == "0")
                {
                    sb.Append("All Route");
                }
                else
                {
                    sb.Append(dpRoute.SelectedItem.Text);
                }
                sb.Append("</td>");
                sb.Append("<td colspan='2' style='text-align:right'>");
                sb.Append(DateTime.Now.ToString("dd-mm-yyyy HH:mm"));
                sb.Append("</td>");
                sb.Append("</tr>");
                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append("<td colspan='2' style='text-align:left'>");
                if (dpType.SelectedItem.Value == "0")
                {
                    sb.Append("All Product Type");
                }
                else
                {
                    sb.Append(dpType.SelectedItem.Text);
                }
                sb.Append("</td>");
                sb.Append("<td colspan='2' style='text-align:right'>");
                if (dpCommodity.SelectedItem.Value == "0")
                {
                    sb.Append("All Commodity");
                }
                else
                {
                    sb.Append(dpCommodity.SelectedItem.Text);
                }
                sb.Append("</td>");
             
                sb.Append("</tr>");
                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append("<td colspan='2' style='text-align:left'>");
                sb.Append(" StartDate: " + (Convert.ToDateTime(txtStartDate.Text)).ToString("dd-MM-yyyy"));
                sb.Append("</td>");
                sb.Append("<td colspan='2' style='text-align:right'>");
                sb.Append(" EndDate: " + (Convert.ToDateTime(txtEndDate.Text)).ToString("dd-MM-yyyy"));
                sb.Append("</td>");

                sb.Append("</tr>");
                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append("<td colspan='2' style='text-align:left'>");
                sb.Append(" Start Amount : " + txtStartAmt.Text.ToString());
                sb.Append("</td>");
                sb.Append("<td colspan='2' style='text-align:right'>");
                sb.Append(" End Amount : "+ txtEndAmt.Text.ToString());
                sb.Append("</td>");
                sb.Append("</tr>");
                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append("<td>");
                sb.Append("<b>Sr.No.</b>");
                sb.Append("</td>");
                sb.Append("<td>");
                sb.Append("<b>Agency Code</b>");
                sb.Append("</td>");
                sb.Append("<td>");
                sb.Append("<b>Agency Name</b>");
                sb.Append("</td>");
                sb.Append("<td style='text-align:right'>");
                sb.Append("<b>Amount</b>");
                sb.Append("</td>");

                sb.Append("</tr>");
                int srno = 0;
                double amt = 0;
                double totalamt = 0;
           
                foreach (DataRow row in DS.Tables[0].Rows)
                {
                    try { amt = Convert.ToDouble(row["TotalBill"]); } catch { amt = 0; }
                    if (amt >= Convert.ToDouble(txtStartAmt.Text) && amt <= Convert.ToDouble(txtEndAmt.Text))
                    {
                        srno++;
                        sb.Append("<tr>");
                        sb.Append("<td>");
                        sb.Append(srno.ToString());
                        sb.Append("</td>");
                        sb.Append("<td>");
                        sb.Append(row["AgentCode"].ToString());
                        sb.Append("</td>");
                        sb.Append("<td>");
                        sb.Append(row["AgentName"].ToString());
                        sb.Append("</td>");
                        sb.Append("<td style='text-align:right'>");
                        double amt1;
                        try { amt1 = Convert.ToDouble(row["TotalBill"]); } catch { amt1 = 0; };
                        totalamt += amt1;
                        sb.Append(Convert.ToDecimal(amt1).ToString("#.##"));
                        sb.Append("</td>");

                        sb.Append("</tr>");




                    }




                }
                sb.Append("<tr style='border-bottom:1px solid'> <td colspan = '4'> &nbsp; </td> </tr>");
                sb.Append("<tr  style='border-bottom:1px solid'>");
                sb.Append("<td>");
                sb.Append(srno.ToString());
                sb.Append("</td>");
               
                sb.Append("<td colspan='3' style='text-align:right'>");
                sb.Append(Convert.ToDecimal(totalamt).ToString("#.##"));
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
                result = "Report Not found";
                genratedBIll.Text = result;

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
    }
    }
