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
    public partial class ItemwisePurchaseAgentList : System.Web.UI.Page
    {
        DataSet DS;
        MarketingData marketingdata;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDwon();
                txtStartDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                txtEndDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
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
                dpRoute.Items.Insert(0, new ListItem("-All Route-", "0"));

            }
          
            DS = BindCommanData.BindCommanDropDwon("TypeID", "TypeName as Name", "TypeMaster", "IsArchive=1 ");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpType.DataSource = DS;
                dpType.DataBind();
                dpType.Items.Insert(0, new ListItem("--Select Product Type  --", "0"));

            }
            DS = BindCommanData.BindCommanDropDwon("CommodityID", "CommodityName as Name", "Commodity", "IsArchive=0 ");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpCommodity.DataSource = DS;
                dpCommodity.DataBind();
                dpCommodity.Items.Insert(0, new ListItem("--Select Commodity Type  --", "0"));

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

        protected void btnViewDetails_Click(object sender, EventArgs e)
        {
            string result = string.Empty;
            marketingdata = new MarketingData();
            DS = new DataSet();



            DS = marketingdata.ViewItemwisePurchaseAgentList((Convert.ToDateTime(txtStartDate.Text)).ToString("dd-MM-yyyy"), (Convert.ToDateTime(txtEndDate.Text)).ToString("dd-MM-yyyy"), Convert.ToInt32(dpRoute.SelectedItem.Value), Convert.ToInt32(dpType.SelectedItem.Value), Convert.ToInt32(dpCommodity.SelectedItem.Value));
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
                sb.Append("<col style = 'width:160px'>");
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
                sb.Append("<b><u>ItemWise Purchase Agent List</u> </b><br/>");
                sb.Append("</td>");
                sb.Append("</tr>");

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
                sb.Append("<td colspan='2' style='text-align:right'>");
                sb.Append(DateTime.Now.ToString("dd-mm-yyyy HH:mm"));
                sb.Append("</td>");
                sb.Append("</tr>");
                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append("<td colspan='2' style='text-align:left'>");
                sb.Append("Start Date: " + (Convert.ToDateTime(txtStartDate.Text)).ToString("dd-MM-yyyy"));
                sb.Append("</td>");
                sb.Append("<td colspan='2' style='text-align:right'>");
                sb.Append("End Date: " + (Convert.ToDateTime(txtEndDate.Text)).ToString("dd-MM-yyyy"));
                sb.Append("</td>");
                sb.Append("</tr>");
                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append("<td colspan='2' style='text-align:left'>");
                sb.Append(dpType.SelectedItem.Text.ToString());
                sb.Append("</td>");
                sb.Append("<td colspan='2' style='text-align:right'>");
                sb.Append(dpCommodity.SelectedItem.Text.ToString());
                sb.Append("</td>");
                sb.Append("</tr>");
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

                sb.Append("</tr>");
                int srno = 0;

                foreach (DataRow row in DS.Tables[0].Rows)
                {



                    srno++;
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

                    sb.Append("</tr>");







                }








                result = sb.ToString();
                genratedBIll.Text = result;
                //Session["ctrl"] = sb.ToString();
                Session["ctrl"] = pnlBill;
                //Response.Redirect("/print.aspx", true);

            }
            else
            {
                result = "New Agent List Not found";
                genratedBIll.Text = result;

            }

        }


       
    }


}