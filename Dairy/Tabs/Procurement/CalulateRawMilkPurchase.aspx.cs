using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using System.Text;
using System.Data;
using Bussiness;
using System.IO;

namespace Dairy.Tabs.Procurement
{
    public partial class CalulateRawMilkPurchase : System.Web.UI.Page
    {
        DataSet DS = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDown();
                txtFromDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                txtToDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
            }
        }

        protected void BindDropDown()
        {
            RouteData routeData = new RouteData();
            DS = BindCommanData.BindCommanDropDwon("RouteID ", "RouteCode +' '+RouteName as Name  ", "Proc_MilkCollectionRoute", "IsActive=1 ");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpRoute.DataSource = DS;
                dpRoute.DataBind();
                dpRoute.Items.Insert(0, new ListItem("--All Route  --", "0"));
            }

            //DS = BindCommanData.BindCommanDropDwon("CenterID ", "CenterCode +' '+CenterName as Name  ", "tbl_MilkCollectionCenter", "IsActive=1 ");
            //if (!Comman.Comman.IsDataSetEmpty(DS))
            //{
            //    dpCenter.DataSource = DS;
            //    dpCenter.DataBind();
            //    dpCenter.Items.Insert(0, new ListItem("--Select Center  --", "0"));
            //}


        }

        //private void BindGridView()
        //{ 

        //    Model.Procurement p = new Model.Procurement();
        //    ProcurementData pd = new ProcurementData();
        //    p.CollectionID = 6;//Convert.ToInt32(dpCenter.SelectedItem.Value);
        //    p.RouteID = Convert.ToInt32(dpRoute.SelectedItem.Value);
        //    p.FomDate = Convert.ToDateTime(txtFromDate.Text);
        //    p.ToDate = Convert.ToDateTime(txtToDate.Text);
        //    if(dpSession.SelectedItem.Value=="0")
        //    { p.Session = null; }
        //    else { p.Session = dpSession.SelectedItem.Text.ToString(); }
        //    p.ModifiedBy = App_code.GlobalInfo.Userid;
        //    p.ModifiedDate = DateTime.Now.ToString();
        //    int Result = 0;
        //    DataSet DS1 = new DataSet();
        //    DS1 = pd.CalculateBill(p);

        //    GridView1.DataSource = DS1;
        //    GridView1.DataBind();
        //    int totalcan = DS1.Tables[0].AsEnumerable().Sum(row => row.Field<int>("Can"));
        //    decimal totalmilkinLtr = DS1.Tables[0].AsEnumerable().Sum(row => row.Field<decimal>("MilkInLtr"));
        //    decimal totalclr = DS1.Tables[0].AsEnumerable().Sum(row => row.Field<decimal>("CLRReading"));
        //    decimal totalfat = DS1.Tables[0].AsEnumerable().Sum(row => row.Field<decimal>("FATPercentage"));
        //    decimal totalsnf = DS1.Tables[0].AsEnumerable().Sum(row => row.Field<decimal>("SNFPercentage"));
        //    decimal totalts= DS1.Tables[0].AsEnumerable().Sum(row => row.Field<decimal>("TSPercentage"));
        //    decimal totalrpl = DS1.Tables[0].AsEnumerable().Sum(row => row.Field<decimal>("RPL"));
        //    decimal totalamt = DS1.Tables[0].AsEnumerable().Sum(row => row.Field<decimal>("Amount"));

        //    GridView1.FooterRow.Cells[1].Text = "Total";
        //    GridView1.FooterRow.Cells[1].HorizontalAlign = HorizontalAlign.Right;
        //    GridView1.FooterRow.Cells[2].Text = totalcan.ToString();
        //    GridView1.FooterRow.Cells[3].Text = totalmilkinLtr.ToString("N2");
        //    GridView1.FooterRow.Cells[4].Text = totalclr.ToString("N2");
        //    GridView1.FooterRow.Cells[5].Text = totalfat.ToString("N2");
        //    GridView1.FooterRow.Cells[6].Text = totalsnf.ToString("N2");
        //    GridView1.FooterRow.Cells[7].Text = totalts.ToString("N2");
        //    GridView1.FooterRow.Cells[8].Text = totalrpl.ToString("N2");
        //    GridView1.FooterRow.Cells[9].Text = totalamt.ToString("N2");
        //    divDanger.Visible = false;
        //    divwarning.Visible = false;

        //    //divSusccess.Visible = true;
        //    //lblSuccess.Text = "Bill Calculated Successfully";
        //    uprouteList.Update();
        //    pnlError.Update();
        //    upMain.Update();

        //}

        protected void btnShow_Click(object sender, EventArgs e)
        {
            Report("1");
        }

        protected void btnCalculate_Click(object sender, EventArgs e)
        {
            string confirmValue = string.Empty;
            confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                
                //  BindGridView();
                Report("2");
            }
            

        }

        protected void Report(string flag)
        {
            Model.Procurement p = new Model.Procurement();
            ProcurementData pd = new ProcurementData();
            p.CollectionID = 6;//Convert.ToInt32(dpCenter.SelectedItem.Value);
            p.RouteID = Convert.ToInt32(dpRoute.SelectedItem.Value);
            p.FomDate = Convert.ToDateTime(txtFromDate.Text);
            p.ToDate = Convert.ToDateTime(txtToDate.Text);
            if (dpSession.SelectedItem.Value == "0")
            { p.Session = null; }
            else { p.Session = dpSession.SelectedItem.Text.ToString(); }

            p.ModifiedBy = App_code.GlobalInfo.Userid;
            p.ModifiedDate = DateTime.Now.ToString();
            p.flag = flag;
            DataSet DS1 = new DataSet();
            DS1 = pd.CalculateBill(p);

            string result = string.Empty;
            if (!Comman.Comman.IsDataSetEmpty(DS1))
            {
                StringBuilder sb = new StringBuilder();


                sb.Append("<style type='text / css'>");
                sb.Append(".tg  { border - collapse:collapse; border - spacing:0; border: none; } .dispnone {display:none;} ");
                sb.Append("</style>");
                sb.Append("<table class='tg style1' style='page-break-inside:avoid; align:center;'>");
                sb.Append("<colgroup>");
                sb.Append("<col style = 'width:50px'>");
                sb.Append("<col style = 'width:100px'>");
                sb.Append("<col style = 'width:200px'>");
                sb.Append("<col style = 'width:50px'>");
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

                sb.Append("<th class='tg-baqh' colspan='11' style='text-align:center'>");
                if (Session["CollectionCenterLoggedIn"] != null)
                {
                    sb.Append("<b>" + Session["CollectionCenterLoggedIn"].ToString() + "</b>");
                }
                else
                {
                    sb.Append("<b>Nanjil Integrated Dairy Development, Mulagumoodu, K.K.Dt.</b>");
                }
                sb.Append("</th>");

                sb.Append("<th class='tg-yw4l' style='text-align:right'>");

                sb.Append("TIN:330761667331<br>");
                sb.Append("</th>");
                sb.Append("</tr>");

                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append("<td class='tg-yw4l' colspan='11' style='text-align:center'>");

                sb.Append("<b><u>Raw Milk Purchase Report </u></b> <br/>");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l' style='text-align:right'>");

                sb.Append("PH:248370,248605");

                sb.Append("</td>");
                sb.Append("</tr>");
                sb.Append("<tr style='border-bottom:1px solid'>");

                sb.Append(" <td colspan='2' style='text-align:left'>");
                sb.Append("Session :" + dpSession.SelectedItem.Text);
                sb.Append("</td>");

                sb.Append(" <td colspan='3' style='text-align:left'>");
                sb.Append("Date :" + DateTime.Now.ToString());
                sb.Append("</td>");

                sb.Append("<td colspan='3' style='text-align:center'>");
                sb.Append(App_code.GlobalInfo.UserName);
                sb.Append("</td>");
                sb.Append("<td colspan='3'>");
                sb.Append(dpRoute.SelectedItem.Text.ToString());
                sb.Append("</td>");

                sb.Append("<td style='text-align:right'>");
                sb.Append(Convert.ToDateTime(txtFromDate.Text).ToString("dd-MM-yyyy"));
                sb.Append("</td>");
                sb.Append("<td style='text-align:right'>");
                sb.Append(Convert.ToDateTime(txtToDate.Text).ToString("dd-MM-yyyy"));
                sb.Append("</td>");

                sb.Append("</td>");
                sb.Append("</tr>");
              

                decimal milkinkg = 0;
                decimal totalmilkinkg = 0;
                decimal milkinltr = 0;
                decimal totalmilkinltr = 0;
                double fatinper = 0.00;
                double totalfatinper = 0.00;

                double snf = 0.00;
                double totalsnf = 0.00;

                double ts = 0.00;
                double totalts = 0.00;

                double rpl = 0.00;
                double totalrpl = 0.00;

                double Amount = 0.00;
                double amt = 0.00;
                double totalamt = 0.00;
                int can = 0;
                int totalcan = 0;
                double clr = 0.00;
                double totalclr = 0.00;


                decimal totmillkg = 0;
                decimal totmilkltr = 0;
                int totcan = 0;

                double totamt = 0.00;
                double totrpl = 0.00;
                string Date;
                int count = 0;
                int totcount = 0;
                double Incentive = 0.00;
                double inc = 0.00;
                double totalinc = 0.00;
                double inc1 = 0.00;
               
                foreach (DataRow rows in DS1.Tables[1].Rows)
                {
                    count = 0;
                    totalfatinper = 0.00;
                    totalsnf = 0.00;
                    totalmilkinkg = 0;
                    totalmilkinltr = 0;
                    totalcan = 0;
                    totalts = 0.00;
                    totalclr = 0.00;
                    totalrpl = 0.00;
                    totalamt = 0.00;
                    sb.Append("<tr style='border-bottom:1px solid'> <td colspan = '13'> &nbsp; </td> </tr>");
                    sb.Append("<tr style='border-bottom:1px solid'>");
                    sb.Append("<td  colspan='4' style='font-weight:bold'>");
                    Date = Convert.ToDateTime(rows["_Date"]).ToString("dd-MM-yyyy");
                    sb.Append("<b>Date : </b>" + Date.ToString());
                    sb.Append("</td>");
                    sb.Append("<td  colspan='4' style='font-weight:bold; text-align:Center' >");///////////
                    sb.Append("<b>Route : </b>" + rows["RouteName"].ToString());
                    sb.Append("</td>");
                    sb.Append("<td  colspan='5' style='font-weight:bold; text-align:right' >");
                    sb.Append("<b>Time : </b>" + rows["_Session"].ToString());
                    sb.Append("</td>");
                    sb.Append("</tr>");
                    sb.Append("<tr style='border-bottom:1px solid'>");

                    sb.Append("<td>");
                    sb.Append("<b>Sr.No.</b>");
                    sb.Append("</td>");



                    sb.Append("<td colspan='2'>");
                    sb.Append("<b>Supplier</b>");
                    sb.Append("</td>");

                    sb.Append("<td style='text-align:right'>");
                    sb.Append("<b>Can</b>");
                    sb.Append("</td>");

                    sb.Append("<td  style='text-align:right'>");
                    sb.Append("<b>MilkInKG</b>");
                    sb.Append("</td>");

                    sb.Append("<td  style='text-align:right'>");
                    sb.Append("<b>MilkInLtr</b>");
                    sb.Append("</td>");

                    sb.Append("<td style='text-align:right'>");
                    sb.Append("<b>CLR</b>");
                    sb.Append("</td>");

                    sb.Append("<td style='text-align:right'>");
                    sb.Append("<b>Fat %</b>");
                    sb.Append("</td>");
                    sb.Append("<td style='text-align:right'>");
                    sb.Append("<b>SNF %</b>");
                    sb.Append("</td>");
                    sb.Append("<td style='text-align:right'>");
                    sb.Append("<b>TS %</b>");
                    sb.Append("</td>");
                    sb.Append("<td style='text-align:right'>");
                    sb.Append("<b>RPL</b>");
                    sb.Append("</td>");
                    sb.Append("<td style='text-align:right'>");
                    sb.Append("<b>Incentive</b>");
                    sb.Append("</td>");
                    sb.Append("<td style='text-align:right'>");
                    sb.Append("<b>Amount</b>");
                    sb.Append("</td>");
                    sb.Append("</tr>");
                    sb.Append("</tr>");
                    sb.Append("<tr>");
                    foreach (DataRow row in DS1.Tables[0].Rows)
                    {
                        if (rows["_Date"].ToString() == row["_Date"].ToString())
                        {
                            if (rows["RouteName"].ToString() == row["RouteName"].ToString())
                            {
                                if (rows["_Session"].ToString() == row["_Session"].ToString())                                  
                                {
                                    count++;

                                    sb.Append("<td>");
                                    sb.Append(count);
                                    sb.Append("</td>");



                                    sb.Append("<td colspan='2'>");
                                    sb.Append(row["Supplier"].ToString());
                                    sb.Append("</td>");

                                    sb.Append("<td style='text-align:right'>");
                                    try { can = Convert.ToInt32(row["Can"]); } catch { can = 0; }

                                    totalcan += can;
                                    sb.Append(row["Can"].ToString());
                                    sb.Append("</td>");

                                    sb.Append("<td style='text-align:right'>");
                                    try { milkinkg = Convert.ToDecimal(row["MilkInKG"]); } catch { milkinkg = 0; }

                                    totalmilkinkg += milkinkg;
                                    sb.Append(Convert.ToDecimal(milkinkg).ToString("0.0"));
                                    sb.Append("</td>");

                                    sb.Append("<td style='text-align:right'>");
                                    try { milkinltr = Convert.ToDecimal(row["MilkInLtr"]); } catch { milkinltr = 0; }

                                    totalmilkinltr += milkinltr;
                                    sb.Append(Convert.ToDecimal(milkinltr).ToString("0.0"));
                                    sb.Append("</td>");

                                    sb.Append("<td style='text-align:right'>");
                                    try { clr = Convert.ToDouble(row["CLRReading"]); } catch { clr = 0; }

                                    totalclr += clr;
                                    sb.Append(Convert.ToDecimal(clr).ToString("0.0"));
                                    sb.Append("</td>");

                                    sb.Append("<td style='text-align:right'>");
                                    try { fatinper = Convert.ToDouble(row["FATPercentage"]); } catch { fatinper = 0.00; }

                                    totalfatinper += fatinper;
                                    sb.Append(Convert.ToDecimal(fatinper).ToString("0.0"));
                                    sb.Append("</td>");
                                    sb.Append("<td style='text-align:right'>");
                                    try { snf = Convert.ToDouble(row["SNFPercentage"]); } catch { snf = 0.00; }

                                    totalsnf += snf;
                                    sb.Append(Convert.ToDecimal(snf).ToString("0.0"));
                                    sb.Append("</td>");
                                    sb.Append("<td style='text-align:right'>");
                                    try { ts = Convert.ToDouble(row["TSPercentage"]); } catch { ts = 0.00; }

                                    totalts += ts;
                                    sb.Append(Convert.ToDecimal(ts).ToString("0.0"));
                                    sb.Append("</td>");
                                    sb.Append("<td style='text-align:right'>");
                                    try { rpl = Convert.ToDouble(row["RPL"]); } catch { rpl = 0.00; }

                                    totalrpl += rpl;
                                    sb.Append(Convert.ToDecimal(rpl).ToString("0.00"));
                                    sb.Append("</td>");

                                    sb.Append("<td style='text-align:right'>");
                                    try { inc = Convert.ToDouble(row["QtyIncentive"]); } catch { inc = 0.00; }
                                    try { inc1= Convert.ToDouble(row["Incentive"]); } catch { inc1 = 0.00; }
                                    //try { inct = }
                                    Incentive =  inc+inc1;
                                    totalinc += Incentive;
                                    sb.Append(Convert.ToDecimal(Incentive).ToString("0.00"));
                                    sb.Append("</td>");

                                    sb.Append("<td style='text-align:right'>");
                                    try { amt = Convert.ToDouble(row["Amount"]); } catch { amt = 0.00; }
                                    Amount = amt;
                                        //rpl + Incentive * Convert.ToDouble(milkinltr);
                                    totalamt += Amount;
                                    sb.Append(Convert.ToDecimal(Amount).ToString("0.00"));
                                    sb.Append("</td>");
                                    sb.Append("</tr>");
                                }
                            }
                        }
                    }
                    sb.Append("<tr style='border-bottom:1px solid'><td colspan='13'></td></tr>");
                    sb.Append("<tr style='border-bottom:1px solid'>");
                    sb.Append("<td colspan='4'>");
                    sb.Append("Average :");
                    sb.Append("</td>");
                    sb.Append("<td style='text-align:right'>");
                    sb.Append("");
                    sb.Append("</td>");
                    sb.Append("<td style='text-align:right'>");
                    sb.Append("");
                    sb.Append("</td>");
                    sb.Append("<td style='text-align:right'>");
                    sb.Append("");
                    sb.Append("</td>");
                    sb.Append("<td style='text-align:right'>");



                    sb.Append("<b>" + Convert.ToDecimal(totalfatinper / count).ToString("0.0") + "</b>");

                    sb.Append("</td>");
                    sb.Append("<td style='text-align:right'>");

                    sb.Append("<b>" + Convert.ToDecimal(totalsnf / count).ToString("0.00") + "</b>");
                    sb.Append("</td>");
                    sb.Append("<td style='text-align:right'>");

                    sb.Append("<b>" + Convert.ToDecimal(totalts / count).ToString("0.0") + "</b>");
                    sb.Append("</td>");
                    sb.Append("<td style='text-align:right'>");

                    sb.Append("<b>" + Convert.ToDecimal(totalrpl / count).ToString("0.00") + "</b>");
                    sb.Append("</td>");
                    sb.Append("<td style='text-align:left'>");
                    sb.Append("/Ltr.");
                    sb.Append("</td>");
                    sb.Append("<td style='text-align:left'>");
                    sb.Append("");
                    sb.Append("</td>");
                    sb.Append("</tr>");
                    sb.Append("<tr style='border-bottom:1px solid'>");
                    sb.Append("<td >");
                    sb.Append("<b>Total :</b>");
                    sb.Append("</td>");
                    sb.Append("<td colspan='2'>");
                    sb.Append("<b>" + count + "</b>");
                    sb.Append("</td>");
                    sb.Append("<td style='text-align:right'>");
                    sb.Append("<b>" + totalcan);
                    sb.Append("</td>");

                    sb.Append("<td style='text-align:right'>");
                    sb.Append("<b>" + Convert.ToDecimal(totalmilkinkg).ToString("0.0") + "</b>");
                    sb.Append("</td>");

                    sb.Append("<td style='text-align:right' >");
                    sb.Append("<b>" + Convert.ToDecimal(totalmilkinltr).ToString("0.0") + "</b>");
                    sb.Append("</td>");

                    sb.Append("<td style='text-align:right' colspan='7'>");
                    sb.Append("<b>" + Convert.ToDecimal(totalamt).ToString("0.00") + "</b>");
                    sb.Append("</td>");
                    sb.Append("</tr>");

                    totcount += count;
                    totcan += totalcan;
                    totmillkg += totalmilkinkg;
                    totmilkltr += totalmilkinltr;
                    totamt += totalamt;
                    totrpl += totalrpl;

                }

                sb.Append("<tr style='border-bottom:1px solid'> <td colspan = '9'> &nbsp; </td> </tr>");

                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append("<td>");
                sb.Append("<b>Count</b>");
                sb.Append("</td>");
                sb.Append("<td colspan='2'>");
                sb.Append("<b>" + totcount + "</b>");
                sb.Append("</td>");

                sb.Append("<td style='text-align:right'>");
                sb.Append("<b>" + totcan + "</b>");
                sb.Append("</td>");
                sb.Append("<td style='text-align:right'>");
                sb.Append("<b>" + totmillkg + "</b>");
                sb.Append("</td>");
                sb.Append("<td style='text-align:right'>");
                sb.Append("<b>" + totmilkltr + "</b>");
                sb.Append("</td>");

                sb.Append("<td colspan='7' style='text-align:right'>");
                sb.Append("<b>" + Convert.ToDecimal(totamt).ToString("00.00") + "</b>");
                sb.Append("</td>");


                sb.Append("</tr>");

                result = sb.ToString();
                Bill.Text = result;

                Session["ctrl"] = pnlBill;


            }
            else
            {
                result = "No Records Found";
                Bill.Text = result;

            }
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }


        //protected void btnPrint_Click(object sender, EventArgs e)
        //{

        //    Model.Procurement p = new Model.Procurement();
        //    ProcurementData pd = new ProcurementData();
        //    p.CollectionID = 6;//Convert.ToInt32(dpCenter.SelectedItem.Value);
        //    p.RouteID = Convert.ToInt32(dpRoute.SelectedItem.Value);
        //    p.FomDate = Convert.ToDateTime(txtFromDate.Text);
        //    p.ToDate = Convert.ToDateTime(txtToDate.Text);
        //    if (dpSession.SelectedItem.Value == "0")
        //    { p.Session = null; }
        //    else { p.Session = dpSession.SelectedItem.Text.ToString(); }

        //    p.ModifiedBy = App_code.GlobalInfo.Userid;
        //    p.ModifiedDate = DateTime.Now.ToString();

        //    DataSet DS1 = new DataSet();
        //    DS1 = pd.CalculateBill(p);

        //    string result = string.Empty;
        //    if (!Comman.Comman.IsDataSetEmpty(DS1))
        //    {
        //        StringBuilder sb = new StringBuilder();


        //        sb.Append("<style type='text / css'>");
        //        sb.Append(".tg  { border - collapse:collapse; border - spacing:0; border: none; } .dispnone {display:none;} ");
        //        sb.Append("</style>");
        //        sb.Append("<table class='tg style1' style='page-break-inside:avoid; align:center;'>");
        //        sb.Append("<colgroup>");
        //        sb.Append("<col style = 'width:150px'>");
        //        sb.Append("<col style = 'width:150px'>");
        //        sb.Append("<col style = 'width:50px'>");
        //        sb.Append("<col style = 'width:100px'>");
        //        sb.Append("<col style = 'width:100px'>");
        //        sb.Append("<col style = 'width:100px'>");
        //        sb.Append("<col style = 'width:100px'>");
        //        sb.Append("<col style = 'width:100px'>");
        //        sb.Append("<col style = 'width:100px'>");
        //        sb.Append("<col style = 'width:100px'>");
        //        sb.Append("<col style = 'width:100px'>");
        //        sb.Append("</colgroup>");

        //        sb.Append("<tr>");
        //        sb.Append("<th class='tg-yw4l' rowspan='2'>");
        //        sb.Append("<img src='/Theme/img/logo1.png' class='img-circle' alt='Logo' width='50px' hight='50px'>");
        //        sb.Append("</th>");

        //        sb.Append("<th class='tg-baqh' colspan='9' style='text-align:center'>");
        //        sb.Append("<u>Raw Milk Purchase Report </u> <br/>");
        //        sb.Append("</th>");

        //        sb.Append("<th class='tg-yw4l' style='text-align:right'>");

        //        sb.Append("TIN:330761667331<br>");
        //        sb.Append("</th>");
        //        sb.Append("</tr>");

        //        sb.Append("<tr style='border-bottom:1px solid'>");
        //        sb.Append("<td class='tg-yw4l' colspan='9' style='text-align:center'>");
        //        sb.Append("<b>Nanjil Integrated Dairy Development, Mulagumoodu, K.K.Dt.</b>");

        //        sb.Append("</td>");

        //        sb.Append("<td class='tg-yw4l' style='text-align:right'>");

        //        sb.Append("PH:248370,248605");

        //        sb.Append("</td>");
        //        sb.Append("</tr>");
        //        sb.Append("<tr style='border-bottom:1px solid'>");
        //        sb.Append(" <td colspan='3' style='text-align:left'>");
        //        sb.Append("Date :" + DateTime.Now.ToString());
        //        sb.Append("</td>");

        //        sb.Append("<td colspan='3' style='text-align:center'>");
        //        sb.Append(App_code.GlobalInfo.UserName);
        //        sb.Append("</td>");
        //        sb.Append("<td colspan='3'>");
        //        sb.Append(dpRoute.SelectedItem.Text.ToString());
        //        sb.Append("</td>");
        //        sb.Append("<td>");
        //        sb.Append(Convert.ToDateTime(txtFromDate.Text).ToString("dd-MM-yyyy"));
        //        sb.Append("</td>");
        //        sb.Append("<td  style='text-align:right'>");
        //        sb.Append(Convert.ToDateTime(txtToDate.Text).ToString("dd-MM-yyyy"));
        //        sb.Append("</td>");
        //        sb.Append("</tr>");
        //        sb.Append("<tr style='border-bottom:1px solid'>");
        //        sb.Append("<td>");
        //        sb.Append("<b>Date</b>");
        //        sb.Append("</td>");

        //        sb.Append("<td colspan='2'>");
        //        sb.Append("<b>Supplier</b>");
        //        sb.Append("</td>");

        //        sb.Append("<td style='text-align:right'>");
        //        sb.Append("<b>Can</b>");
        //        sb.Append("</td>");

        //        sb.Append("<td  style='text-align:right'>");
        //        sb.Append("<b>MilkInLtr</b>");
        //        sb.Append("</td>");

        //        sb.Append("<td style='text-align:right'>");
        //        sb.Append("<b>CLR</b>");
        //        sb.Append("</td>");

        //        sb.Append("<td style='text-align:right'>");
        //        sb.Append("<b>Fat %</b>");
        //        sb.Append("</td>");
        //        sb.Append("<td style='text-align:right'>");
        //        sb.Append("<b>SNF %</b>");
        //        sb.Append("</td>");
        //        sb.Append("<td style='text-align:right'>");
        //        sb.Append("<b>TS %</b>");
        //        sb.Append("</td>");
        //        sb.Append("<td style='text-align:right'>");
        //        sb.Append("<b>RPL</b>");
        //        sb.Append("</td>");
        //        sb.Append("<td style='text-align:right'>");
        //        sb.Append("<b>Amount</b>");
        //        sb.Append("</td>");

        //        sb.Append("</tr>");

        //        double milkinltr = 0.00;
        //        double totalmilkinltr = 0.00;
        //        double fatinper = 0.00;
        //        double totalfatinper = 0.00;
        //        double snf = 0.00;
        //        double totalsnf = 0.00;
        //        double ts = 0.00;
        //        double totalts = 0.00;
        //        double rpl = 0.00;
        //        double totalrpl = 0.00;
        //        double amt = 0.00;
        //        double totalamt = 0.00;
        //        int can = 0;
        //        int totalcan = 0;
        //        double clr = 0.00;
        //        double totalclr = 0.00;
        //        sb.Append("<tr>");
        //        foreach (DataRow row in DS1.Tables[0].Rows)
        //        {

        //            sb.Append("<td>");
        //            sb.Append(Convert.ToDateTime(row["_Date"]).ToString("dd-MM-yyyy"));
        //            sb.Append("</td>");

        //            sb.Append("<td colspan='2'>");
        //            sb.Append(row["Supplier"].ToString());
        //            sb.Append("</td>");

        //            sb.Append("<td style='text-align:right'>");
        //            try { can = Convert.ToInt32(row["Can"]); } catch { can = 0; }

        //            totalcan += can;
        //            sb.Append(row["Can"].ToString());
        //            sb.Append("</td>");

        //            sb.Append("<td style='text-align:right'>");
        //            try { milkinltr = Convert.ToDouble(row["MilkInLtr"]); } catch { milkinltr = 0.00; }

        //            totalmilkinltr += milkinltr;
        //            sb.Append(Convert.ToDecimal(row["MilkInLtr"]).ToString("0.0"));
        //            sb.Append("</td>");

        //            sb.Append("<td style='text-align:right'>");
        //            try { clr = Convert.ToInt32(row["CLRReading"]); } catch { clr = 0; }

        //            totalclr += clr;
        //            sb.Append(Convert.ToDecimal(row["CLRReading"]).ToString("0.0"));
        //            sb.Append("</td>");

        //            sb.Append("<td style='text-align:right'>");
        //            try { fatinper = Convert.ToDouble(row["FATPercentage"]); } catch { fatinper = 0.00; }

        //            totalfatinper += fatinper;
        //            sb.Append(Convert.ToDecimal(row["FATPercentage"]).ToString("0.0"));
        //            sb.Append("</td>");
        //            sb.Append("<td style='text-align:right'>");
        //            try { snf = Convert.ToDouble(row["SNFPercentage"]); } catch { snf = 0.00; }

        //            totalsnf += snf;
        //            sb.Append(Convert.ToDecimal(row["SNFPercentage"]).ToString("0.0"));
        //            sb.Append("</td>");
        //            sb.Append("<td style='text-align:right'>");
        //            try { ts = Convert.ToDouble(row["TSPercentage"]); } catch { ts = 0.00; }

        //            totalts += ts;
        //            sb.Append(Convert.ToDecimal(row["TSPercentage"]).ToString("0.0"));
        //            sb.Append("</td>");
        //            sb.Append("<td style='text-align:right'>");
        //            try { rpl = Convert.ToDouble(row["RPL"]); } catch { rpl = 0.00; }

        //            totalrpl += rpl;
        //            sb.Append(Convert.ToDecimal(row["RPL"]).ToString("0.00"));
        //            sb.Append("</td>");
        //            sb.Append("<td style='text-align:right'>");
        //            try { amt = Convert.ToDouble(row["Amount"]); } catch { amt = 0.00; }

        //            totalamt += amt;
        //            sb.Append(Convert.ToDecimal(row["Amount"]).ToString("0.00"));
        //            sb.Append("</td>");
        //            sb.Append("</tr>");
        //        }
        //        sb.Append("<tr style='border-bottom:1px solid'><td colspan='11'></td></tr>");
        //        sb.Append("<tr style='border-bottom:1px solid'>");
        //        sb.Append("<td colspan='3'>");
        //        sb.Append("<b>Total</b>");
        //        sb.Append("</td>");
        //        sb.Append("<td>");
        //        sb.Append(totalcan);
        //        sb.Append("</td>");
        //        sb.Append("<td style='text-align:right'>");
        //        sb.Append(Convert.ToDecimal(totalmilkinltr).ToString("0.0"));
        //        sb.Append("</td>");
        //        sb.Append("<td style='text-align:right'>");
        //        sb.Append(Convert.ToDecimal(totalclr).ToString("0.0"));
        //        sb.Append("</td>");
        //        sb.Append("<td style='text-align:right'>");
        //        sb.Append(Convert.ToDecimal(totalfatinper).ToString("0.0"));
        //        sb.Append("</td>");
        //        sb.Append("<td style='text-align:right'>");
        //        sb.Append(Convert.ToDecimal(totalsnf).ToString("0.0"));
        //        sb.Append("</td>");
        //        sb.Append("<td style='text-align:right'>");
        //        sb.Append(Convert.ToDecimal(totalts).ToString("0.0"));
        //        sb.Append("</td>");
        //        sb.Append("<td style='text-align:right'>");
        //        sb.Append(Convert.ToDecimal(totalrpl).ToString("0.00"));
        //        sb.Append("</td>");
        //        sb.Append("<td style='text-align:right'>");
        //        sb.Append(Convert.ToDecimal(totalamt).ToString("0.00"));
        //        sb.Append("</td>");
        //        sb.Append("</tr>");
        //        result = sb.ToString();
        //        RequestDetails.Text = result;

        //        Session["ctrl"] = pnlRequestDetails;

        //    }
        //    else
        //    {
        //        result = "No Records Found";
        //        RequestDetails.Text = result;

        //    }


        //    upModal.Update();
        //    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);

        //}

        //protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    GridView1.PageIndex = e.NewPageIndex;
        //    this.BindGridView();
        //}
    }
}