using Bussiness;
using Model;
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
    public partial class RefundSchemeSummary : System.Web.UI.Page
    {
        DataSet DS = new DataSet();
        Marketings marketing = new Marketings();
        MarketingData marketingdata = new MarketingData();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDown();
                txtStartDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                txtEndDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
            }
        }

        public void BindDropDown()
        {
            DataSet DS = new DataSet();

            DS = BindCommanData.BindCommanDropDwon("AgentID", "AgentCode+' '+AgentName as Name", "AgentMaster", "IsArchive=0 and Agensytype='Agency' Order by AgentCode");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpAgent.DataSource = DS;
                dpAgent.DataBind();
                dpAgent.Items.Insert(0, new ListItem("--All Agency  --", "0"));
            }
            DS = BindCommanData.BindCommanDropDwon("RouteID ", "RouteCode +' '+RouteName as Name  ", "routeMaster", "IsArchive=1");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpRoute.DataSource = DS;
                dpRoute.DataBind();
                dpRoute.Items.Insert(0, new ListItem("--All Route  --", "0"));
            }
        }

        protected void dpRoute_SelectedIndexChanged(object sender, EventArgs e)
        {
            DS = BindCommanData.BindCommanDropDwon("AgentID", "AgentCode+' '+AgentName as Name", "AgentMaster", "RouteID=" + dpRoute.SelectedItem.Value.ToString() + "and IsArchive=0 and Agensytype='Agency' and TotalSchemeAmount <> 0 Order by AgentCode");
            
                dpAgent.ClearSelection();
                dpAgent.DataSource = DS;
                dpAgent.DataBind();
                dpAgent.Items.Insert(0, new ListItem("--All Agent  --", "0"));
           
            dpRoute.Focus();
        }

        protected void btngenrateBill_Click(object sender, EventArgs e)
        {
            double totalSchemeamt = 0;
            double totalrefundamt = 0;
            double balanceamt = 0;
            string result = string.Empty;
            DS = marketingdata.AgentRefundSchemeSummary((Convert.ToDateTime(txtStartDate.Text)).ToString("dd-MM-yyyy"), (Convert.ToDateTime(txtEndDate.Text)).ToString("dd-MM-yyyy"), Convert.ToInt32(dpRoute.SelectedItem.Value), Convert.ToInt32(dpAgent.SelectedItem.Value));
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                DataView view = new DataView(DS.Tables[0]);
                DataTable distinctValues = view.ToTable(true, "AgentCode", "AgentName");
                StringBuilder sb = new StringBuilder();
                sb.Append("<style type='text / css'>");
                sb.Append(".tg  { border - collapse:collapse; border - spacing:0; border: none; }");
                sb.Append(".tg .tg-yw4l{vertical-align:top}");
                sb.Append(".tg .tg-baqh{text-align:center;vertical-align:top}");
                sb.Append("</style>");
                sb.Append("<table class='tg style1' style='page-break-inside:avoid; align:center;'>");
                sb.Append("<colgroup>");
                sb.Append("<col style = 'width:150px'>");
                sb.Append("<col style = 'width:150px'>");
                sb.Append("<col style = 'width:120px'>");
                sb.Append("<col style = 'width:120px'>");
                sb.Append("<col style = 'width:100px'>");
               

                sb.Append("</colgroup>");

                sb.Append("<tr>");
                sb.Append("<th class='tg-yw4l' rowspan='2'>");
                sb.Append("<img src='/Theme/img/logo1.png' class='img-circle' alt='Logo' width='50px' hight='50px'>");
                sb.Append("</th>");

                sb.Append("<th class='tg-baqh' colspan='3' style='text-align:center; font-size: 80%;'>");
                sb.Append("<b>Nanjil Integrated Dairy Development, Mulagumoodu, K.K.Dt. Ph:248370,248605</b>");
                sb.Append("</th>");

                sb.Append("<th class='tg-yw4l'  style='text-align:right; font-size: 80%;'>");

                sb.Append("GSTIN:&nbsp;33AAECN2463R1Z2<br>");
                sb.Append("</th>");
                sb.Append("</tr>");
                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append("<td class='tg-yw4l' colspan='5' style='text-align:Left'>");
               
                sb.Append("<b><u> Scheme Refund </u> </b><br/>");
                sb.Append("</td>");
                sb.Append("</tr>");

            

             

                //sb.Append("<tr style='border-bottom:1px solid'> <td colspan = '5'> &nbsp; </td> </tr>");
                sb.Append("<tr style='border-bottom:0.5px solid'>");




                sb.Append("<td colspan='2'>");

                if (Convert.ToInt32(dpRoute.SelectedItem.Value) == 0)
                {
                    sb.Append("Route : " + "All");
                }
                else
                {
                    sb.Append("Route : " + dpRoute.SelectedItem.Text.ToString());
                }

                sb.Append("</td>");

                sb.Append("<td colspan='3'>");

                if (Convert.ToInt32(dpAgent.SelectedItem.Value) == 0)
                {
                    sb.Append("Agent : " + "All");
                }
                else
                {
                    sb.Append("Agent : " + dpAgent.SelectedItem.Text.ToString());
                }

                sb.Append("</td>");
                sb.Append("</tr>");

             

            
                int totalcount = 0;
                int totalentries = 0;
                foreach (DataRow rows in distinctValues.Rows)
                {

                    totalcount++;
                 
                    sb.Append("<tr style='border-bottom:1px dotted'> <td colspan = '5'>&nbsp; </td> </tr>");
                    sb.Append("<tr>");
                    sb.Append("<td class='tg-yw4l' colspan='5' style='text-align:left'>");
                    sb.Append(rows["AgentCode"].ToString() + "&nbsp;" + rows["AgentName"].ToString());
                    sb.Append("</td>");


                    sb.Append("</tr>");
                    sb.Append("<tr style='border-bottom:1px dotted'> <td colspan = '5'> </td> </tr>");
                    sb.Append("<tr style='border-bottom:0.5px solid'>");
                    sb.Append("<td style='text-align:left'>");
                    sb.Append("RequestDate");

                    sb.Append("</td>");
                    sb.Append("<td style='text-align:left'>");
                    sb.Append("RefundDate");


                    sb.Append("</td>");
                    sb.Append("<td style='text-align:center'>");

                    sb.Append("TotalSchemeAmt.");

                    sb.Append("</td>");
                    sb.Append("<td style='text-align:center'>");

                    sb.Append("RefundAmt.");

                    sb.Append("</td>");
                    sb.Append("<td style='text-align:right'>");

                    sb.Append("BalanceAmt.");

                    sb.Append("</td>");

                    //sb.Append("<td style='text-align:right'>");

                    //sb.Append("Approved By");

                    //sb.Append("</td>");
                    sb.Append("</tr>");
                
                 

                    int count = 0;
                   
                    foreach (DataRow row in DS.Tables[0].Rows)
                    {
                        if (rows["AgentCode"].ToString() == row["AgentCode"].ToString())
                        {
                            count++;
                         
                            sb.Append("<tr>");
                            sb.Append("<td class='tg-yw4l' style='text-align:left'>");
                            sb.Append(row["RequestedDate"].ToString());
                            sb.Append("</td>");

                            sb.Append("<td class='tg-yw4l' style='text-align:left'>");
                            sb.Append(row["RefundDate"].ToString());
                            sb.Append("</td>");

                            sb.Append("<td class='tg-yw4l' style='text-align:center'>");
                            totalSchemeamt += Convert.ToDouble(row["TotalSchemeAmt"]);
                            sb.Append((Convert.ToDecimal(row["TotalSchemeAmt"]).ToString("#.00")));
                            sb.Append("</td>");



                            sb.Append("<td class='tg-yw4l' style='text-align:center'>");
                            totalrefundamt += Convert.ToDouble(row["RefundAmt"]);
                            sb.Append((Convert.ToDecimal(row["RefundAmt"]).ToString("#.00")));
                            sb.Append("</td>");


                            sb.Append("<td class='tg-yw4l' style='text-align:right'>");
                            balanceamt += Convert.ToDouble(row["Balance"]);
                            sb.Append((Convert.ToDecimal(row["Balance"]).ToString("#.00")));
                            sb.Append("</td>");




                            //sb.Append("<td class='tg-yw4l' style='text-align:right'> ");
                            //sb.Append(row["Name"].ToString());
                            //sb.Append("</td> ");

                            sb.Append("</tr>");
                        }
                      

                    }
                    sb.Append("<tr style='border-bottom:1px dotted'> <td colspan = '5'> &nbsp; </td> </tr>");
                    sb.Append("<tr style='border-bottom:0.5px solid'>");
                    sb.Append("<td colspan='2'>");
                    sb.Append("Entries :&nbsp;" + count.ToString());
                    totalentries += count;
                    sb.Append("</td >");
                    sb.Append("<td style='text-align:center' >");
                    //sb.Append((Convert.ToDecimal(totalSchemeamt).ToString("#.00")));
                    sb.Append("</td >");
                    sb.Append("<td style='text-align:center'>");
                    //sb.Append((Convert.ToDecimal(totalrefundamt).ToString("#.00")));
                    sb.Append("</td >");
                    sb.Append("<td style='text-align:right' >");
                    //sb.Append((Convert.ToDecimal(balanceamt).ToString("#.00")));
                    sb.Append("</td >");
                    //sb.Append("<td style='text-align:right' >");
                    //sb.Append("&nbsp;");
                    //sb.Append("</td >");
                    sb.Append("</tr >");
                  
               
                }
                sb.Append("<tr style='border-bottom:1px dotted'> <td colspan = '5'> &nbsp; </td> </tr>");
                sb.Append("<tr style='border-bottom:0.5px solid'>");
                sb.Append("<td colspan='2'>");
                sb.Append("Total Agent :&nbsp;" + totalcount.ToString());
               
                sb.Append("</td >");
                sb.Append("<td style='text-align:center' >");
                sb.Append("Total Entries :&nbsp;" + totalentries.ToString());
                sb.Append("</td >");
                sb.Append("<td style='text-align:center'>");
                //sb.Append((Convert.ToDecimal(totalrefundamt).ToString("#.00")));
                sb.Append("</td >");
                sb.Append("<td style='text-align:right' >");
                //sb.Append((Convert.ToDecimal(balanceamt).ToString("#.00")));
                sb.Append("</td >");
                //sb.Append("<td style='text-align:right' >");
                //sb.Append("&nbsp;");
                //sb.Append("</td >");
                sb.Append("</tr >");
               


                result = sb.ToString();
                genratedBIll.Text = result;
                //Session["ctrl"] = sb.ToString();
                Session["ctrl"] = pnlBill;
                //Response.Redirect("/print.aspx", true);

            }
            else
            {
                result = "No Records Found";
                genratedBIll.Text = result;

            }
        }
           
    }
}