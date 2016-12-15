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
    public partial class PartywiseDamageReplacementSummary : System.Web.UI.Page
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
                dpBrand.Items.Insert(0, new ListItem("--Select Brand--", "0"));
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

        protected void dpBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet DS = new DataSet();
            DS = BindCommanData.BindCommanDropDwon("TypeID", "TypeName as Name", "TypeMaster", "IsArchive=1 and " + "CategoryID=" + Convert.ToInt32(dpBrand.SelectedItem.Value));
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpType.DataSource = DS;
                dpType.DataBind();
                dpType.Items.Insert(0, new ListItem("--Select Product Type  --", "0"));

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



            string result = string.Empty;
            DS = billdata.PartywiseDamageReturnSummary((Convert.ToDateTime(txtStartDate.Text)).ToString("dd-MM-yyyy"), (Convert.ToDateTime(txtEndDate.Text)).ToString("dd-MM-yyyy"), Convert.ToInt32(dpRoute.SelectedItem.Value), Convert.ToInt32(dpBrand.SelectedItem.Value), Convert.ToInt32(dpType.SelectedItem.Value), Convert.ToInt32(dpCommodity.SelectedItem.Value));
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
                sb.Append("<col style = 'width:120px'>");
                sb.Append("<col style = 'width:120px'>");
                sb.Append("<col style = 'width:120px'>");
                sb.Append("</colgroup>");

                sb.Append("<tr>");
                sb.Append("<th class='tg-yw4l' rowspan='2'>");
                sb.Append("<img src='/Theme/img/logo1.png' class='img-circle' alt='Logo' width='50px' hight='50px'>");
                sb.Append("</th>");

                sb.Append("<th class='tg-baqh' colspan='5' style='text-align:center'>");
                sb.Append("<b>Nanjil Integrated Dairy Development, Mulagumoodu, K.K.Dt.</b>");

                sb.Append("</th>");
                sb.Append("<th class='tg-yw4l' style='text-align:right'>");
                sb.Append("TIN:330761667331<br>");
                sb.Append("</th>");
                sb.Append("</tr>");

                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append("<td class='tg-yw4l' colspan='5' style='text-align:center'>");
                sb.Append("<b><u>DamageReplacement Summary </u> </b><br/>");
                sb.Append("</td>");
                sb.Append("<td class='tg-yw4l' style='text-align:right'>");
                sb.Append("PH:248370,248605");
                sb.Append("</td> </tr>");

                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append("<td colspan='2'>");
                sb.Append(dpRoute.SelectedItem.Text);
                sb.Append("</td>");
                sb.Append("<td >");
                sb.Append(dpBrand.SelectedItem.Text);
                sb.Append("</td>");
                sb.Append("<td >");
                sb.Append(dpType.SelectedItem.Text);
                sb.Append("</td>");
                sb.Append("<td >");
                sb.Append(dpCommodity.SelectedItem.Text);
                sb.Append("</td>");
                sb.Append("<td colspan='2' style='text-align:right'>");
                sb.Append(DateTime.Now.ToString("dd-MM-yyyy HH:mm"));
                sb.Append("</td>");
                sb.Append("</tr>");
                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append("<td colspan='3' style='text-align:left'>");
                sb.Append("Start Date: " + (Convert.ToDateTime(txtStartDate.Text)).ToString("dd-MM-yyyy"));
                sb.Append("</td>");
                sb.Append("<td colspan='4' style='text-align:right'>");
                sb.Append("End Date: " + (Convert.ToDateTime(txtEndDate.Text)).ToString("dd-MM-yyyy"));
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
                sb.Append("<td  style='text-align:center'>");
                sb.Append("<b>Quantity</b>");
                sb.Append("</td>");
                sb.Append("<td style='text-align:center'>");
                sb.Append("<b>Replacement %</b>");
                sb.Append("</td>");
                sb.Append("<td style='text-align:right'>");
                sb.Append("<b>Replacement Qty.</b>");
                sb.Append("</td>");
                sb.Append("</tr>");
                int srno = 0;
                double qty = 0.00;

                double totalqty = 0.00;

                double totalinsamt = 0.00;
                double totalamt = 0.00;


                foreach (DataRow rows in DS.Tables[1].Rows )
                {

                    foreach (DataRow row in DS.Tables[0].Rows)
                    {
                        if (rows["AgentID"].ToString() == row["AgentID"].ToString())
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



                            sb.Append("<td  style='text-align:center'>");
                            try
                            {
                                qty = Convert.ToDouble(row["Quantity"]);
                                totalqty += qty;
                            }
                            catch { }
                            sb.Append(qty.ToString());
                            sb.Append("</td>");






                            sb.Append("<td style='text-align:center'>");
                            //avg = qty / percentage;
                            //totalavg += avg;
                            sb.Append((Convert.ToDecimal(rows["Damagereplacementrate"]).ToString("#.##")));
                            sb.Append("</td>");
                            sb.Append("<td style='text-align:right'>");
                            if (string.IsNullOrEmpty(rows["Damagereplacementrate"].ToString()))
                            {

                                sb.Append("0.00");

                            }
                            else
                            {

                                try
                                {
                                    if (dpType.SelectedItem.Value.ToString() == "1")
                                    {
                                       
                                        
                                       
                                         double price = 0;
                                         foreach (DataRow filter in DS.Tables[2].Rows)
                                        {
                                            if (filter["AgentID"].ToString() == row["AgentID"].ToString())
                                            {
                                                price = Convert.ToDouble(filter["Prize"]);
                                            }
                                        }

                                        totalinsamt = (Convert.ToDouble(qty) * (Convert.ToDouble(rows["Damagereplacementrate"]) / 100) * price);
                                       
                                    }
                                    else
                                    {
                                        totalinsamt = (Convert.ToDouble(qty) * (Convert.ToDouble(rows["Damagereplacementrate"]) / 100));
                                    }
                                    sb.Append(Convert.ToDecimal(totalinsamt).ToString("#0.00"));
                                    totalamt += totalinsamt;
                                }
                                catch { }

                            }

                        }


                    }
                    }

                    sb.Append("</td>");
                    sb.Append("</tr>");
                    sb.Append("<tr style='border-bottom:1px solid'><td colspan='7'></td></tr>");
                    sb.Append("<tr style='border-bottom:1px solid'>");
                    sb.Append("<td colspan = '4'>");
                    sb.Append("<b>Total</b>");
                    sb.Append("</td>");
                    sb.Append("<td  style='text-align:center' >");
                    sb.Append("<b>" + totalqty + "</b>");
                    sb.Append("</td>");
                    sb.Append("<td style='text-align:center'>");
                    sb.Append("</td>");
                    sb.Append("<td style='text-align:right'>");
                    sb.Append("<b>" + (Convert.ToDecimal(totalamt).ToString("#0.00")) + "</b>");
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
                result = "Report not found";
                genratedBIll.Text = result;

            }
        }
    }
}