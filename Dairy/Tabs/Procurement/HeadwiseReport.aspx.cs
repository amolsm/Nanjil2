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
    public partial class HeadwiseReport : System.Web.UI.Page
    {
        DataSet DS = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                //BindDropDown();
                txtEndDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                txtStartDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
            }
        }
        //protected void BindDropDown()
        //{

        //    DS = BindCommanData.BindCommanDropDwon("ID ", "Particular", "Proc_ReceiveandDisposalMaster", "IsActive=1 ");
        //    if (!Comman.Comman.IsDataSetEmpty(DS))
        //    {
        //        dpHead.DataSource = DS;
        //        dpHead.DataBind();
        //        dpHead.Items.Insert(0, new ListItem("--Select Head--", "0"));
        //    }
        //}
        protected void btnGeneratereport_Click(object sender, EventArgs e)
        {
            Model.MHeadwiseReport p = new Model.MHeadwiseReport();
            BHeadwiseReport pd = new BHeadwiseReport();

            p.Startdate = Convert.ToDateTime(txtStartDate.Text);
            p.Enddate = Convert.ToDateTime(txtEndDate.Text);
            if (dpHead.SelectedItem.Value == "0")
            { p.Head = 0; }
            else
            {
                p.Head = Convert.ToInt32(dpHead.SelectedItem.Value);
            }
            DataSet DS = new DataSet();
            DS = pd.HeadwiseDetails(p);
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
                sb.Append("<col style = 'width:100px'>");
                sb.Append("<col style = 'width:100px'>");
                sb.Append("<col style = 'width:100px'>");
                sb.Append("<col style = 'width:100px'>");
                sb.Append("<col style = 'width:100px'>");

                sb.Append("</colgroup>");

                sb.Append("<tr>");
                sb.Append("<th class='tg-yw4l' rowspan='2'>");
                sb.Append("<img src='/Theme/img/logo1.png' class='img-circle' alt='Logo' width='50px' hight='50px'>");
                sb.Append("</th>");

                sb.Append("<th class='tg-baqh' colspan='7' style='text-align:center'>");
                sb.Append("<b> " + (DS.Tables[0].Rows[0]["CenterName"].ToString()) + "</b>"); //////////// 

                sb.Append("</th colspan='3'>");

                sb.Append("<th class='tg-yw4l' style='text-align:right'>");

                sb.Append("TIN:330761667331<br>");
                sb.Append("</th>");
                sb.Append("</tr>");

                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append("<td class='tg-yw4l' colspan='7' style='text-align:center'>");
                sb.Append("<u>RawMilkReceiving/Disposing Reports</u> <br/>");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l' style='text-align:right'>");
                sb.Append("PH:248370,248605");
                sb.Append("</td>");


                sb.Append("</tr>");
                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append(" <td colspan='3' style='text-align:left'>");
                sb.Append("Date : " + DateTime.Now.ToString("dd-MM-yyyy"));
                sb.Append("</td>");

                sb.Append("<td colspan='4'>");
                sb.Append("Head Type: " + dpHead.SelectedItem.Text.ToString());

                sb.Append("</td>");

                sb.Append("<td style='text-align:right'>");
                sb.Append(Convert.ToDateTime(txtStartDate.Text).ToString("dd-MM-yyyy"));
                sb.Append("</td>");
                sb.Append("<td  style='text-align:right'>");
                sb.Append(Convert.ToDateTime(txtEndDate.Text).ToString("dd-MM-yyyy"));
                sb.Append("</td>");
                sb.Append("</tr>");

                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append("</tr>");

                sb.Append("<tr style='border-bottom:1px solid'>");

                sb.Append("<td style='text-align:left'>");
                sb.Append("<b>Date</b>");
                sb.Append("</td>");
                sb.Append("<td style='text-align:left'>");
                sb.Append("<b>Qty</b>");
                sb.Append("</td>");
                sb.Append("<td style='text-align:left'>");
                sb.Append("<b>Time</b>");
                sb.Append("</td>");
                sb.Append("<td style='text-align:left'>");
                sb.Append("<b>Vehicle No</b>");
                sb.Append("</td>");
                sb.Append("<td style='text-align:left'>");
                sb.Append("<b>Batch No</b>");
                sb.Append("</td>");
                sb.Append("<td style='text-align:left'>");
                sb.Append("<b>Temp</b>");
                sb.Append("</td>");
                sb.Append("<td style='text-align:left'>");
                sb.Append("<b>Acidity</b>");
                sb.Append("</td>");
                sb.Append("<td style='text-align:left'>");
                sb.Append("<b>FAT</b>");
                sb.Append("</td>");
                sb.Append("<td style='text-align:left'>");
                sb.Append("<b>SNF</b>");
                sb.Append("</td>");

                sb.Append("</tr>");
                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append("<td colspan='9' style='text-align:left'>");
                sb.Append("<b>"+DS.Tables[0].Rows[0]["Purpose"].ToString() +"</b>");
                sb.Append("</td>");
                sb.Append("</tr>");
                sb.Append("<tr>");
                int count = 0;
                double Qty = 0.00;
                double totQty = 0.00;
                double time = 0.00;

                foreach (DataRow row in DS.Tables[0].Rows)
                {

                    count++;

                    sb.Append("<td style='text-align:left'>");
                    sb.Append(Convert.ToDateTime(row["Date"]).ToString("dd-MM-yyyy"));
                    sb.Append("</td>");

                    sb.Append("<td>");

                    try { Qty = Convert.ToDouble(row["Qty"]); }
                    catch { Qty = 0.00; }
                    totQty += Qty;
                    sb.Append(Convert.ToDecimal(Qty).ToString("0.00"));
                    sb.Append("</td>");
                    sb.Append("<td>");

                    try { time = Convert.ToDouble(row["Session"]); }
                    catch { time = 0.00; }

                    sb.Append(Convert.ToDecimal(time).ToString("0.00"));
                    sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append(row["VehicalNo"].ToString());
                    sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append(row["BatchNo"].ToString());
                    sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append(row["Temp"].ToString());
                    sb.Append("</td>");

                    sb.Append("<td>");
                    sb.Append(row["Acidity"].ToString());
                    sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append(row["FATPercentage"].ToString());
                    sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append(row["SNFPercentage"].ToString());
                    sb.Append("</td>");

                    sb.Append("</tr>");
                    
                }
                sb.Append("<tr style='border-bottom:1px solid'><td colspan='13'></td></tr>");
                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append("<td  style='text-align:left'>");
                sb.Append("<b>Total :" + count + "</b>");
                sb.Append("</td>");

                sb.Append("<td colspan='12'>");
                sb.Append("<b>" + totQty + "</b>");
                sb.Append("</td>");
                if (Convert.ToInt32(dpHead.SelectedItem.Value) == 0)
                {
                    if (DS.Tables[1] != null && DS.Tables[1].Rows.Count > 0)
                    {
                        //sb.Append("<tr style='border-bottom:1px solid'><td colspan='13'></td></tr>");
                        int count1 = 0;
                        sb.Append("<tr style='border-bottom:1px solid'>");
                        sb.Append("<td colspan='9' style='text-align:left'>");
                        sb.Append("<b>" + DS.Tables[1].Rows[0]["Purpose"].ToString() + "</b>");
                        sb.Append("</td>");
                        sb.Append("</tr>");
                        foreach (DataRow rows in DS.Tables[1].Rows)
                        {
                            count1++;
                           
                            sb.Append("<td style='text-align:left'>");
                            sb.Append(Convert.ToDateTime(rows["Date"]).ToString("dd-MM-yyyy"));
                            sb.Append("</td>");

                            sb.Append("<td>");

                            try { Qty = Convert.ToDouble(rows["Qty"]); }
                            catch { Qty = 0.00; }
                            totQty += Qty;
                            sb.Append(Convert.ToDecimal(Qty).ToString("0.00"));
                            sb.Append("</td>");
                            sb.Append("<td>");

                            try { time = Convert.ToDouble(rows["Session"]); }
                            catch { time = 0.00; }

                            sb.Append(Convert.ToDecimal(time).ToString("0.00"));
                            sb.Append("</td>");
                            sb.Append("<td>");
                            sb.Append(rows["VehicalNo"].ToString());
                            sb.Append("</td>");
                            sb.Append("<td>");
                            sb.Append(rows["BatchNo"].ToString());
                            sb.Append("</td>");
                            sb.Append("<td>");
                            sb.Append(rows["Temp"].ToString());
                            sb.Append("</td>");

                            sb.Append("<td>");
                            sb.Append(rows["Acidity"].ToString());
                            sb.Append("</td>");
                            sb.Append("<td>");
                            sb.Append(rows["FATPercentage"].ToString());
                            sb.Append("</td>");
                            sb.Append("<td>");
                            sb.Append(rows["SNFPercentage"].ToString());
                            sb.Append("</td>");

                            sb.Append("</tr>");
                        }
                        sb.Append("<tr style='border-bottom:1px solid'><td colspan='13'></td></tr>");
                        sb.Append("<tr style='border-bottom:1px solid'>");
                        sb.Append("<td  style='text-align:left'>");
                        sb.Append("<b>Total :" + count1 + "</b>");
                        sb.Append("</td>");

                        sb.Append("<td>");
                        sb.Append("<b>" + totQty + "</b>");
                        sb.Append("</td>");

                        sb.Append("<td></td>");
                        sb.Append("<td></td>");
                        sb.Append("<td></td>");
                        sb.Append("<td></td>");
                        sb.Append("<td></td>");
                        sb.Append("<td></td>");
                        sb.Append("<td></td>");
                        sb.Append("</tr>");
                    }
                }


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
    }
}
    

