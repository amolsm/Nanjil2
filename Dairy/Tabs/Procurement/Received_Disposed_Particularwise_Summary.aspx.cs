using Bussiness;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dairy.Tabs.Procurement
{
    public partial class Received_Disposed_Particularwise_Summary : System.Web.UI.Page
    {
        DataSet DS = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                BindDropDown();
                txtStartDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                txtEndDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
            }
        }

        protected void BindDropDown()
        {
            RouteData routeData = new RouteData();
            DS = BindCommanData.BindCommanDropDwon("ID ", "Particular as Name  ", "Proc_ReceiveandDisposalMaster", "IsActive=1 ");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpParticular.DataSource = DS;
                dpParticular.DataBind();
                dpParticular.Items.Insert(0, new ListItem("--Select All--", "0"));


            }


        }

        protected void btnGeneratereport_Click(object sender, EventArgs e)
        {
            Model.MHeadwiseReport p = new Model.MHeadwiseReport();
            BHeadwiseReport pd = new BHeadwiseReport();

            p.Startdate = Convert.ToDateTime(txtStartDate.Text);
            p.Enddate = Convert.ToDateTime(txtEndDate.Text);
            if (Convert.ToInt32(dpParticularType.SelectedItem.Value) == 0)
            {
                p.ParticularType = "All";
            }
            else
            {
                p.ParticularType = dpParticularType.SelectedItem.Text;
            }
            if (Convert.ToInt32(dpParticular.SelectedItem.Value) == 0)
            {
                p.Particular = 0;
            }
            else
            {
                p.Particular = Convert.ToInt32(dpParticular.SelectedItem.Value);
            }
            DataSet DS = new DataSet();
            DS = pd.Received_Disposed_HeadswiseDeatils(p);
            string result = string.Empty;
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("<style type='text / css'>");
                sb.Append(".tg  { border - collapse:collapse; border - spacing:0; border: none; } .dispnone {display:none;} ");
                sb.Append("</style>");
                sb.Append("<table class='tg style1' style='page-break-inside:avoid; align:center;'>");
                sb.Append("<colgroup>");
                sb.Append("<col style = 'width:100px'>");
                sb.Append("<col style = 'width:100px'>");
                sb.Append("<col style = 'width:100px'>");
                sb.Append("<col style = 'width:100px'>");


                sb.Append("</colgroup>");

                sb.Append("<tr>");
                sb.Append("<th class='tg-yw4l' rowspan='2'>");
                sb.Append("<img src='/Theme/img/logo1.png' class='img-circle' alt='Logo' width='50px' hight='50px'>");
                sb.Append("</th>");

                sb.Append("<th class='tg-baqh' colspan='3' style='text-align:center'>");
                sb.Append("<b> " + (DS.Tables[0].Rows[0]["CenterName"].ToString()) + "</b>"); //////////// 

                sb.Append("</th colspan='3'>");

                sb.Append("<th class='tg-yw4l' style='text-align:right'>");

                //sb.Append("TIN:330761667331<br>");
                sb.Append("</th>");
                sb.Append("</tr>");

                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append("<td class='tg-yw4l' colspan='3' style='text-align:center'>");
                sb.Append("<u>Received/Dispose Headwise Details</u> <br/>");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l' style='text-align:right'>");
                //sb.Append("PH:248370,248605");
                sb.Append("</td>");


                sb.Append("</tr>");
                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append(" <td colspan='2' style='text-align:left'>");
                sb.Append("Date : " + DateTime.Now.ToString("dd-MM-yyyy"));
                sb.Append("</td>");

                sb.Append("<td colspan='1'>");
                //sb.Append("Head Type: " + dpHead.SelectedItem.Text.ToString());
                //+ "&nbsp;" + DS.Tables[1].Rows[0]["VehicleType"].ToString());
                sb.Append("</td>");

                sb.Append("<td style='text-align:right'>");
                sb.Append(Convert.ToDateTime(txtStartDate.Text).ToString("dd-MM-yyyy"));
                sb.Append("</td>");
                sb.Append("<td  style='text-align:right'>");
                sb.Append(Convert.ToDateTime(txtEndDate.Text).ToString("dd-MM-yyyy"));
                sb.Append("</td>");
                sb.Append("</tr>");
                sb.Append("<tr style='border-bottom:1px solid'>");

                //sb.Append("<td style='text-align:left'>");
                //sb.Append("<b>Date</b>");
                //sb.Append("</td>");
                sb.Append("<td style='text-align:left' colspan='2'>");
                sb.Append("<b>Particular</b>");
                sb.Append("</td>");
                sb.Append("<td style='text-align:left' colspan='2'>");
                sb.Append("<b>Receiving Qty </b>");
                sb.Append("</td>");
                sb.Append("<td style='text-align:left'>");
                sb.Append("<b>Disposing Qty</b>");
                sb.Append("</td>");


                sb.Append("</tr>");
                sb.Append("<tr>");
                int count = 0;
                double RecQty = 0.00;
                double totRecQty = 0.00;
                double DispQty = 0.00;
                double totDispQty = 0.00;
                double time = 0.00;
                //double MornKm = 0.00;
                //double totMornKm = 0.00;
                //double EveKm = 0.00;
                //double totEveKm = 0.00;
                //double Amt = 0.00;
                //double totAmt = 0.00;
                foreach (DataRow row in DS.Tables[0].Rows)
                {
                    count++;
                    //sb.Append("<td style='text-align:left'>");
                    //sb.Append(Convert.ToDateTime(row["Date"]).ToString("dd-MM-yyyy"));
                    //sb.Append("</td>");

                    sb.Append("<td colspan='2'>");
                    sb.Append(row["Particular"].ToString());
                    sb.Append("</td>");
                    if (row["Purpose"].ToString() == "Receive")
                    {
                        sb.Append("<td colspan='2' >");
                        try { RecQty = Convert.ToDouble(row["RecQty"]); }
                        catch { RecQty = 0.00; }
                        totRecQty += RecQty;
                        sb.Append(Convert.ToDecimal(RecQty).ToString("0.00"));

                        sb.Append("</td>");

                        sb.Append("<td>");

                        DispQty = 0.00;
                        totDispQty += DispQty;
                        sb.Append(Convert.ToDecimal(DispQty).ToString("0.00"));
                        sb.Append("</td>");
                    }
                    else
                    {
                        sb.Append("<td colspan='2' >");

                        RecQty = 0.00;
                        totRecQty += RecQty;
                        sb.Append(Convert.ToDecimal(RecQty).ToString("0.00"));

                        sb.Append("</td>");
                        sb.Append("<td>");
                        try { DispQty = Convert.ToDouble(row["DispQty"]); }
                        catch { DispQty = 0.00; }
                        totDispQty += DispQty;
                        sb.Append(Convert.ToDecimal(DispQty).ToString("0.00"));
                        sb.Append("</td>");

                    }
                    sb.Append("</tr>");
                }

                sb.Append("<tr style='border-bottom:1px solid'><td colspan='10'></td></tr>");
                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append("<td  style='text-align:left'>");
                sb.Append("<b>Total :" + count + "</b>");
                sb.Append("</td>");



                sb.Append("<td></td>");


                sb.Append("<td colspan='2'>");
                sb.Append("<b>" + totRecQty + "</b>");
                sb.Append("</td>");
                sb.Append("<td>");
                sb.Append("<b>" + totDispQty + "</b>");
                sb.Append("</td>");
                sb.Append("<td></td>");
                sb.Append("<td>");

                sb.Append("</td>");
                sb.Append("<td></td>");
                sb.Append("</tr>");

                result = sb.ToString();
                Payment.Text = result;
                Session["ctrl"] = pnlPayment;
            }
            else
            {
                result = "No Records Found";
                Payment.Text = result;
            }
            uprouteList.Update();
        }

        protected void dpParticularType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dpParticularType.SelectedItem.Value != "0")
            {
                dpParticular.ClearSelection();
                DS = BindCommanData.BindCommanDropDwon("ID", "Particular as Name  ", "Proc_ReceiveandDisposalMaster", "IsActive=1 and Purpose='" + dpParticularType.SelectedItem.Text + "'");

                dpParticular.DataSource = DS;
                dpParticular.DataBind();
                dpParticular.Items.Insert(0, new ListItem("--Select Particular  --", "0"));
            }
            else
            {
                dpParticular.ClearSelection();
                BindDropDown();
            }

        }
    }
}