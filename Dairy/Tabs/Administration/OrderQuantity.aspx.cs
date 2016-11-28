using Bussiness;
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
    public partial class OrderQuantity : System.Web.UI.Page
    {
        DataSet DS;
        BillData billdata;
        DataSet DS1;
        double TotQuantity;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DS = new DataSet();
                DS = BindCommanData.BindCommanDropDwon("RouteID ", "RouteCode +' '+RouteName as Name  ", "routeMaster", "IsArchive=1");
                if (!Comman.Comman.IsDataSetEmpty(DS))
                {
                    dpRoute.DataSource = DS;
                    dpRoute.DataBind();
                    dpRoute.Items.Insert(0, new ListItem("--All Route--", "0"));
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

        protected void btnViewDetails_Click(object sender, EventArgs e)
        {
            string result = string.Empty;
            billdata = new BillData();
            DS = new DataSet();
            DS1 = new DataSet();

            DS = billdata.ViewOrderQuantities((Convert.ToDateTime(txtDate.Text)).ToString("dd-MM-yyyy"), Convert.ToInt32(dpRoute.SelectedItem.Value), Convert.ToInt32(dpBrand.SelectedValue));
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
                sb.Append("<col style = 'width:160px'>");
                sb.Append("<col style = 'width:140px'>");

                sb.Append("</colgroup>");

                sb.Append("<tr>");
                sb.Append("<th class='tg-yw4l' rowspan='2' >");
                sb.Append("<img src='/Theme/img/logo1.png' class='img-circle' alt='Logo' width='50px' hight='50px'>");
                sb.Append("</th>");

                sb.Append("<th class='tg-baqh'  style='text-align:center; font-size: 80%;'>");
                sb.Append("<u> Order Summary </u> <br/>");
                sb.Append("</th>");

                sb.Append("<th class='tg-yw4l'  style='text-align:right; font-size: 80%;'>");

                sb.Append("TIN:330761667331<br>");
                sb.Append("</th>");
                sb.Append("</tr>");

                sb.Append("<tr style='border-bottom:1px solid'>");


                sb.Append("<td class='tg-yw4l' colspan='3' style='text-align:Left'>");
                sb.Append("<b>Nanjil Integrated Dairy Development, Mulagumoodu,K.K.Dt.Ph:248370,248605</b>");
                sb.Append("</th>");


                sb.Append("</tr>");







                sb.Append("<tr style='border-bottom:2px solid'>");
                sb.Append("<td class='tg-yw4l' colspan='2' style='text-align:left'>");

                if (Convert.ToInt32(dpRoute.SelectedItem.Value) == 0)
                {
                    sb.Append("Route : " + "All");
                }
                else
                {
                    sb.Append("Route : " + dpRoute.SelectedItem.Text.ToString());
                }
                sb.Append("</td>");
                // sb.Append("<td>&nbsp;</td>");
                sb.Append("<td class='tg-yw4l'   style='text-align:right'>");
                sb.Append(Convert.ToDateTime(txtDate.Text).ToString("dd-MM-yyyy"));
                sb.Append("</td>");
                sb.Append("</tr>");
                sb.Append("</tr>");

                sb.Append("<tr style='border-bottom:1px solid'> ");
                sb.Append("<td class='tg-yw4l' colspan='3' style='text-align:left'>");
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

                sb.Append("<td class='tg-yw4l' colspan='2' style='text-align:left'>");
                sb.Append("<b>ITEM </b>");
                sb.Append("</td>");

                //sb.Append("<td>&nbsp;</td>");

                sb.Append("<td class='tg-yw4l'   style='text-align:right'>");
                sb.Append("<b>Quantity</b>");
                sb.Append("</td>");

                //sb.Append("<td class='tg-yw4l'  style='text-align:right'>");
                //sb.Append("<b>Amount</b>");
                //sb.Append("</td>");




                sb.Append("</tr>");


                foreach (DataRow row in DS.Tables[0].Rows)
                {




                    sb.Append("<td class='tg-yw4l' colspan='2'  style='text-align:left'>");
                    sb.Append(row["ITEM"].ToString());
                    sb.Append("</td>");

                    //sb.Append("<td>&nbsp;</td>");

                    sb.Append("<td class='tg-yw4l'   style='text-align:right'>");
                    sb.Append(row["Quantity"].ToString());
                    //+ " " + row["UnitName"].ToString());
                    TotQuantity = TotQuantity + Convert.ToDouble(row["Quantity"]);
                    sb.Append("</td>");

                    //sb.Append("<td class='tg-yw4l'  style='text-align:right'>");
                    //sb.Append((Convert.ToDecimal(row["Amount"]).ToString("#0.00")));
                    //sb.Append("</td>");


                    sb.Append("</tr>");


                }



                sb.Append("<tr style='border-top:1px solid'>");
                sb.Append("<td style='text-align:left;font-size: 80%'>");
                sb.Append(DateTime.Now.ToString("dd/MM/yyyy hh:mm"));
                sb.Append("</td>");
                sb.Append("<td colspan='2' style='text-align:right' >");
                sb.Append("Total:" + TotQuantity.ToString());
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