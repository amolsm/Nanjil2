using Bussiness;
using Dairy.App_code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dairy.Tabs.Administration
{
    public partial class ViewBoothStock : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDown();
            }
        }

        private void BindDropDown()
        {
            DataSet DS = new DataSet();
            DS = BindCommanData.BindCommanDropDwon("AgentID", "AgentCode+' '+AgentName as Name", "AgentMaster", "IsArchive=0 and Agensytype='Booth'");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpAgent.DataSource = DS;
                dpAgent.DataBind();
                dpAgent.Items.Insert(0, new ListItem("--Select Booth --", "0"));
            }
            DS.Clear();
            DS = BindCommanData.BindCommanDropDwon("CategoryId", "CategoryName as Name", "Category", "IsActive=1");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpBrand.DataSource = DS;
                dpBrand.DataBind();
                dpBrand.Items.Insert(0, new ListItem("--All Brand--", "0"));
            }
        }

        protected void btnViewStock_Click(object sender, EventArgs e)
        {
            int boothid = 0;
            int brandid = 0;
            DataSet DS = new DataSet();
            string result = string.Empty;
            BillData billData = new BillData();
            boothid = Convert.ToInt32(dpAgent.SelectedItem.Value);
            brandid = Convert.ToInt32(dpBrand.SelectedItem.Value);
            //DS = billData.getStockforbooth(boothid);
            DS = billData.getStockforboothViewStock(boothid,brandid);
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
                sb.Append("<col style = 'width:200px'>");
                sb.Append("<col style = 'width:200px'>");
                sb.Append("<col style = 'width:200px'>");
                sb.Append("<col style = 'width:200px'>");
                sb.Append("<col style = 'width:200px'>");
                sb.Append("</colgroup>");
                sb.Append("<br/><hr/><br/>");

                sb.Append("<tr>");
                sb.Append("<th class='tg-yw4l' rowspan='2'>");
                sb.Append("<img src='/Theme/img/logo1.png' class='img-circle' alt='Logo' width='50px' hight='50px'>");
                sb.Append("</th>");

                sb.Append("<th class='tg-baqh' colspan='3' style='text-align:center'>");
                sb.Append("<u>Booth Stock</u> <br/>");
                sb.Append("</th>");

                sb.Append("<th class='tg-yw4l' style='text-align:right'>");
                sb.Append("TIN:330761667331<br>");
                sb.Append("</th>");
                sb.Append("</tr>");

                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append("<td class='tg-yw4l' colspan='3'   style='text-align:center'>");
                sb.Append("<b>Nanjil Integrated Dairy Development ,Mulagunoodu, K.K.Dt.</b>");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l' style='text-align:right'>");
                sb.Append("PH:248370,248605");
                sb.Append("</td>");
                sb.Append("</tr>");

                sb.Append("<tr style='border-bottom:1px solid'>");
                    sb.Append("<td>");
                    sb.Append(dpAgent.SelectedItem.Text);
                    sb.Append("</td>");

                    sb.Append("<td colspan ='3' style='text-align:center'>");
                    sb.Append(dpBrand.SelectedItem.Text);
                    sb.Append("</td>");

                    sb.Append("<td style='text-align:right'>");
                    sb.Append(DateTime.Now.ToString("dd-MM-yyyy hh:mm"));
                    sb.Append("</td>");
                sb.Append("</tr>");

                //heading

                sb.Append("<tr style='border-bottom:1px solid' style='text-align:left'>");
                sb.Append("<td >");
                sb.Append("<b> Sr.No. </b> ");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l'  style='text-align:left'>");
                sb.Append("<b> Type Name </b> ");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l'  style='text-align:left'>");
                sb.Append("<b> Commodity Name </b> ");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l'  style='text-align:left'>");
                sb.Append("<b> Product Name </b> ");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l'  style='text-align:right'>");
                sb.Append("<b> Stock Available</b> ");
                sb.Append("</td>");

                sb.Append("</tr>");

                int count = 1;
                foreach (DataRow row in DS.Tables[0].Rows)
                {
                    sb.Append("<tr>");

                    sb.Append("<td  class='tg-yw4l' style='text-align:left'>");
                    sb.Append(count.ToString());
                    sb.Append("</td>");

                    sb.Append("<td  class='tg-yw4l' style='text-align:left'>");
                    sb.Append(row["TypeName"].ToString());
                    sb.Append("</td>");

                    sb.Append("<td  class='tg-yw4l' style='text-align:left'>");
                    sb.Append(row["CommodityName"].ToString());
                    sb.Append("</td>");

                    sb.Append("<td  class='tg-yw4l' style='text-align:left'>");
                    sb.Append(row["ProductName"].ToString());
                    sb.Append("</td>");

                    sb.Append("<td  class='tg-yw4l' style='text-align:right'>");
                    sb.Append(row["StockAvailable"].ToString());
                    sb.Append("</td>");
                    sb.Append("</tr>");

                    count++;
                }
                sb.Append("<tr style='border-Top:1px solid' > ");
                sb.Append("<td colspan ='5' style='text-align:right'>");
                sb.Append("&nbsp;");
                sb.Append("</td>");
                sb.Append("</tr>");

                sb.Append("<tr > ");

                sb.Append("<td  style='text-align:center'>");
                sb.Append("");
                sb.Append("</td>");

                sb.Append("<td  style='text-align:center'>");
                sb.Append("");
                sb.Append("</td>");

                sb.Append("<td  style='text-align:center'>");
                sb.Append("Authorized Person");
                sb.Append("</td>");

                sb.Append("</tr>");




                result = sb.ToString();
                genratedBIll.Text = result;
                //Session["ctrl"] = sb.ToString();
                Session["ctrl1"] = pnlBill;
                //Response.Redirect("/print.aspx", true);

            }
            else
            {
                result = "No Stock Available";
                genratedBIll.Text = result;

            }
            

        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {

        }
    }
}