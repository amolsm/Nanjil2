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
    protected void btnCalculate_Click(object sender, EventArgs e)
{
            //  BindGridView();
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
                sb.Append("<col style = 'width:150px'>");
                sb.Append("<col style = 'width:150px'>");
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

                sb.Append("<th class='tg-baqh' colspan='10' style='text-align:center'>");
                sb.Append("<u>Raw Milk Purchase Report </u> <br/>");
                sb.Append("</th>");

                sb.Append("<th class='tg-yw4l' style='text-align:right'>");

                sb.Append("TIN:330761667331<br>");
                sb.Append("</th>");
                sb.Append("</tr>");

                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append("<td class='tg-yw4l' colspan='10' style='text-align:center'>");
                sb.Append("<b>Nanjil Integrated Dairy Development, Mulagumoodu, K.K.Dt.</b>");

                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l' style='text-align:right'>");

                sb.Append("PH:248370,248605");

                sb.Append("</td>");
                sb.Append("</tr>");
                sb.Append("<tr style='border-bottom:1px solid'>");

                sb.Append(" <td  style='text-align:left'>");
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
                sb.Append("<td>");
                sb.Append(Convert.ToDateTime(txtFromDate.Text).ToString("dd-MM-yyyy"));
                sb.Append("</td>");
                sb.Append("<td  style='text-align:right'>");
                sb.Append(Convert.ToDateTime(txtToDate.Text).ToString("dd-MM-yyyy"));
                sb.Append("</td>");
                sb.Append("</tr>");
                sb.Append("<tr style='border-bottom:1px solid'>");

                sb.Append("<td>");
                sb.Append("<b>Sr.No.</b>");
                sb.Append("</td>");

                sb.Append("<td>");
                sb.Append("<b>Date</b>");
                sb.Append("</td>");

                sb.Append("<td colspan='2'>");
                sb.Append("<b>Supplier</b>");
                sb.Append("</td>");

                sb.Append("<td style='text-align:right'>");
                sb.Append("<b>Can</b>");
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
                sb.Append("<b>Amount</b>");
                sb.Append("</td>");

                sb.Append("</tr>");

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
                double amt = 0.00;
                double totalamt = 0.00;
                int can = 0;
                int totalcan = 0;
                double clr = 0.00;
                double totalclr = 0.00;
                int count = 0;
                sb.Append("<tr>");
                foreach (DataRow row in DS1.Tables[0].Rows)
                {
                    count++;

                    sb.Append("<td>");
                    sb.Append(count);
                    sb.Append("</td>");

                    sb.Append("<td>");
                    sb.Append(Convert.ToDateTime(row["_Date"]).ToString("dd-MM-yyyy"));
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
                    try { milkinltr = Convert.ToDecimal(row["MilkInLtr"]); } catch { milkinltr = 0; }

                    totalmilkinltr += milkinltr;
                    sb.Append(Convert.ToDecimal(milkinltr).ToString("0.0"));
                    sb.Append("</td>");

                    sb.Append("<td style='text-align:right'>");
                    try { clr = Convert.ToInt32(row["CLRReading"]); } catch { clr = 0; }

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
                    try { amt = Convert.ToDouble(row["Amount"]); } catch { amt = 0.00; }

                    totalamt += amt;
                    sb.Append(Convert.ToDecimal(amt).ToString("0.00"));
                    sb.Append("</td>");
                    sb.Append("</tr>");
                }
                sb.Append("<tr style='border-bottom:1px solid'><td colspan='12'></td></tr>");
                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append("<td colspan='4'>");
                sb.Append("<b>Total</b>");
                sb.Append("</td>");
                sb.Append("<td style='text-align:right'>");
                sb.Append(totalcan);
                sb.Append("</td>");
                sb.Append("<td style='text-align:right'>");
                sb.Append(Convert.ToDecimal(totalmilkinltr).ToString("0.0"));
                sb.Append("</td>");
                sb.Append("<td style='text-align:right'>");
                sb.Append(Convert.ToDecimal(totalclr).ToString("0.0"));
                sb.Append("</td>");
                sb.Append("<td style='text-align:right'>");
                sb.Append(Convert.ToDecimal(totalfatinper).ToString("0.0"));
                sb.Append("</td>");
                sb.Append("<td style='text-align:right'>");
                sb.Append(Convert.ToDecimal(totalsnf).ToString("0.0"));
                sb.Append("</td>");
                sb.Append("<td style='text-align:right'>");
                sb.Append(Convert.ToDecimal(totalts).ToString("0.0"));
                sb.Append("</td>");
                sb.Append("<td style='text-align:right'>");
                sb.Append(Convert.ToDecimal(totalrpl).ToString("0.00"));
                sb.Append("</td>");
                sb.Append("<td style='text-align:right'>");
                sb.Append(Convert.ToDecimal(totalamt).ToString("0.00"));
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