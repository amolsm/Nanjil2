﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Bussiness;
using System.Text;

namespace Dairy.Tabs.Procurement
{
    public partial class MonthlyRawMilkPurchaseSummary : System.Web.UI.Page
    {
        DataSet DS = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDown();
            }

        }
        public void BindDropDown()
        {
            DS = BindCommanData.BindCommanDropDwon("CenterID ", "CenterCode +' '+CenterName as Name  ", "tbl_MilkCollectionCenter", "IsActive=1 ");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpCenter.DataSource = DS;
                dpCenter.DataBind();
                dpCenter.Items.Insert(0, new ListItem("--All Center  --", "0"));
            }
        }

        protected void btnGeneratereport_Click(object sender, EventArgs e)
        {
            Model.Procurement p = new Model.Procurement();
            ProcurementData pd = new ProcurementData();

            p.CenterID = Convert.ToInt32(dpCenter.SelectedItem.Value);
            p.FomDate = Convert.ToDateTime(txtStartDate.Text);
            p.ToDate = Convert.ToDateTime(txtEndDate.Text);
            p.TSStartPercentage = Convert.ToDecimal(txttsstart.Text);
            p.TSEndPercentage = Convert.ToDecimal(txttsend.Text);
            p.IsActive = Convert.ToBoolean(CheckBox1.Checked);
            DataSet DS = new DataSet();
            DS = pd.MonthlyRawMilkPurchaseSummary(p);
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


                sb.Append("</colgroup>");

                sb.Append("<tr>");
                sb.Append("<th class='tg-yw4l' rowspan='2'>");
                sb.Append("<img src='/Theme/img/logo1.png' class='img-circle' alt='Logo' width='50px' hight='50px'>");
                sb.Append("</th>");

                sb.Append("<th class='tg-baqh' colspan='6' style='text-align:center'>");
                sb.Append("<u>Monthly Raw Milk Purchase Summary</u> <br/>");
                sb.Append("</th>");

                sb.Append("<th class='tg-yw4l' style='text-align:right'>");

                sb.Append("TIN:330761667331<br>");
                sb.Append("</th>");
                sb.Append("</tr>");

                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append("<td class='tg-yw4l' colspan='6' style='text-align:center'>");
                sb.Append("<b>Nanjil Integrated Dairy Development, Mulagumoodu, K.K.Dt.</b>");

                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l' style='text-align:right'>");

                sb.Append("PH:248370,248605");

                sb.Append("</td>");
                sb.Append("</tr>");
                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append(" <td colspan='2' style='text-align:left'>");
                sb.Append("Date : " + DateTime.Now.ToString());
                sb.Append("</td>");

                sb.Append("<td colspan='2'>");
                sb.Append(dpCenter.SelectedItem.Text.ToString());
                sb.Append("</td>");
                sb.Append("<td colspan='2'>");
                sb.Append("Start Date : " + Convert.ToDateTime(txtStartDate.Text).ToString("dd-MM-yyyy"));
                sb.Append("</td>");
                sb.Append("<td colspan='2' style='text-align:right'>");
                sb.Append("End Date : " + Convert.ToDateTime(txtEndDate.Text).ToString("dd-MM-yyyy"));
                sb.Append("</td>");
                sb.Append("</tr>");
                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append("<td  style='text-align:left'>");
                sb.Append("<b>Month</b>");
                sb.Append("</td>");
                sb.Append("<td colspan='2' style='text-align:center'>");
                sb.Append("<b>Route</b>");
                sb.Append("</td>");
                sb.Append("<td style='text-align:right'>");
                sb.Append("<b>MilkInLtr.</b>");
                sb.Append("</td>");
                sb.Append("<td style='text-align:right'>");
                sb.Append("<b>FatInKg.</b>");
                sb.Append("</td>");
                sb.Append("<td style='text-align:right'>");
                sb.Append("<b>SNFKg.</b>");
                sb.Append("</td>");
                sb.Append("<td style='text-align:right'>");
                sb.Append("<b>TSKg.</b>");
                sb.Append("</td>");
                sb.Append("<td style='text-align:right'>");
                sb.Append("<b>Amount</b>");
                sb.Append("</td>");



                sb.Append("</tr>");
                sb.Append("<tr>");

                double amt = 0.00;
                int count = 0;
                decimal milkltr = 0;
                decimal totalmilkltr = 0;
                double fatinkg = 0.00;
                double totalfatinkg = 0.00;
                double snfinkg = 0.00;
                double totalsnfinkg = 0.00;
                double tsinkg = 0.00;
                double totaltsinkg = 0.00;
                double totalamt = 0.00;
                foreach (DataRow row in DS.Tables[0].Rows)
                {
                    count++;

                    sb.Append("<td style='text-align:left'>");
                    sb.Append(row["Months"].ToString());
                    sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append(row["RouteCode"].ToString());
                    sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append(row["RouteName"].ToString());
                    sb.Append("</td>");
                    sb.Append("<td style='text-align:right'>");
                    try { milkltr = Convert.ToDecimal(row["MilkInLtr"]); }
                    catch { milkltr = 0; }
                    totalmilkltr += milkltr;
                    sb.Append(Convert.ToDecimal(milkltr).ToString("0.0"));
                    sb.Append("</td>");
                   
                    sb.Append("<td style='text-align:right'>");
                    try { fatinkg = Convert.ToDouble(row["FATInKG"]); }
                    catch { fatinkg = 0; }
                    totalfatinkg += fatinkg;
                    sb.Append(Convert.ToDecimal(fatinkg).ToString("0.00"));
                 
                    sb.Append("</td>");
                    sb.Append("<td style='text-align:right'>");
                    try { snfinkg = Convert.ToDouble(row["SNFInKG"]); }
                    catch { snfinkg = 0; }
                    totalsnfinkg += snfinkg;
                    sb.Append(Convert.ToDecimal(snfinkg).ToString("0.00"));
                   
                    sb.Append("</td>");
                    sb.Append("<td style='text-align:right'>");
                    try { tsinkg = Convert.ToDouble(row["TSInKg"]); }
                    catch { tsinkg = 0; }
                    totaltsinkg += tsinkg;
                    sb.Append(Convert.ToDecimal(tsinkg).ToString("0.00"));

                  
                    sb.Append("</td>");
                    sb.Append("<td style='text-align:right'>");
                    try { amt = Convert.ToDouble(row["Amount"]); }
                    catch { amt = 0; }
                    totalamt += amt;
                    sb.Append(Convert.ToDecimal(amt).ToString("0.00"));
                    
                    sb.Append("</td>");


                    sb.Append("</tr>");
                }
                sb.Append("<tr style='border-bottom:1px solid'><td colspan='8'></td></tr>");
                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append("<td colspan='2' style='text-align:left'>");
                sb.Append("<b>Total :</b>");
                sb.Append("</td>");
                sb.Append("<td>");
                sb.Append("<b>" + count + "</b>");
                sb.Append("</td>");
                sb.Append("<td style='text-align:right'>");
                sb.Append("<b>" + Convert.ToDecimal(totalmilkltr).ToString("0.0") + "</b>");
                sb.Append("</td>");
                sb.Append("<td style='text-align:right'>");
                sb.Append("<b>" + Convert.ToDecimal(totalfatinkg).ToString("0.00") + "</b>");
                sb.Append("</td>");
                sb.Append("<td style='text-align:right'>");
                sb.Append("<b>" + Convert.ToDecimal(totalsnfinkg).ToString("0.00") + "</b>");
                sb.Append("</td>");
                sb.Append("<td style='text-align:right'>");
                sb.Append("<b>" + Convert.ToDecimal(totaltsinkg).ToString("0.00") + "</b>");
                sb.Append("</td>");
                sb.Append("<td style='text-align:right'>");
                sb.Append("<b>" + Convert.ToDecimal(totalamt).ToString("0.00") + "</b>");
                sb.Append("</td>");
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
        }
    }
