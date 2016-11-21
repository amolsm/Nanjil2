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
    public partial class CheckList : System.Web.UI.Page
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
        
            DS = BindCommanData.BindCommanDropDwon("RouteID ", "RouteCode +' '+RouteName as Name  ", "Proc_MilkCollectionRoute", "IsActive=1 ");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpRoute.DataSource = DS;
                dpRoute.DataBind();
                dpRoute.Items.Insert(0, new ListItem("--All Route  --", "0"));
            }

      


        }

        protected void btnCalculate_Click(object sender, EventArgs e)
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
                sb.Append("<u>Check List </u> <br/>");
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
                sb.Append(" <td  style='text-align:left'>");
                sb.Append("Session :" + dpSession.SelectedItem.Text);
                sb.Append("</td>");
                sb.Append(" <td colspan='2' style='text-align:center'>");
                sb.Append(DateTime.Now.ToString());
                sb.Append("</td>");
                sb.Append("<td colspan='2'  style='text-align:center'>");
                sb.Append(App_code.GlobalInfo.UserName);
                sb.Append("</td>");
                sb.Append("<td>");
                sb.Append(dpRoute.SelectedItem.Text.ToString());
                sb.Append("</td>");
                sb.Append("<td>");
                sb.Append(Convert.ToDateTime(txtFromDate.Text).ToString("dd-MM-yyyy"));
                sb.Append("</td>");
                sb.Append("<td>");
                sb.Append(Convert.ToDateTime(txtToDate.Text).ToString("dd-MM-yyyy"));
                sb.Append("</td>");
                sb.Append("</tr>");
                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append("<td>");
                sb.Append("<b>Date</b>");
                sb.Append("</td>");
             
                sb.Append("<td colspan='3'>");
                sb.Append("<b>Supplier</b>");
                sb.Append("</td>");
                sb.Append("<td style='text-align:right'>");
                sb.Append("<b>MilkInLtr</b>");
                sb.Append("</td>");
                sb.Append("<td style='text-align:right'>");
                sb.Append("<b>Fat Perc.</b>");
                sb.Append("</td>");
                sb.Append("<td style='text-align:right'>");
                sb.Append("<b>SNF Perc.</b>");
                sb.Append("</td>");
                sb.Append("<td style='text-align:right'>");
                sb.Append("<b>TS Perc.</b>");
                sb.Append("</td>");


                sb.Append("</tr>");
                sb.Append("<tr>");
                int count=0;
                double milkinltr = 0.00;
                double totalmilklter = 0.00;
                double fatpercent = 0.00;
                double totalfatpercent = 0.00;
                double snfpercent = 0.00;
                double totalsnfpercent = 0.00;
                double tspercent = 0.00;
                double totaltspercent = 0.00;
                foreach (DataRow row in DS1.Tables[0].Rows)
                {
                    count++;
                    sb.Append("<td>");
                    sb.Append(Convert.ToDateTime(row["_Date"]).ToString("dd-MM-yyyy"));
                    sb.Append("</td>");
                    //sb.Append("<td>");
                    //sb.Append(row["_Session"].ToString());
                    //sb.Append("</td>");
                    sb.Append("<td colspan='3'>");
                    sb.Append(row["Supplier"].ToString());
                    sb.Append("</td>");
                    sb.Append("<td style='text-align:right'>");
                    milkinltr = Convert.ToDouble(row["MilkInLtr"]);
                    totalmilklter += milkinltr;
                    sb.Append(milkinltr.ToString());
                    sb.Append("</td>");
                   
                    sb.Append("<td style='text-align:right'> ");
                    fatpercent = Convert.ToDouble(row["FATPercentage"]);
                    totalfatpercent += fatpercent;
                    sb.Append(fatpercent.ToString());
                    sb.Append("</td>");
                 
                    sb.Append("<td style='text-align:right'>");
                    snfpercent = Convert.ToDouble(row["SNFPercentage"]);
                    totalsnfpercent += snfpercent;
                    sb.Append(snfpercent.ToString());
                    sb.Append("</td>");
                   
                    sb.Append("<td style='text-align:right'>");
                    tspercent = Convert.ToDouble(row["TSPercentage"]);
                    totaltspercent += tspercent;
                    sb.Append(tspercent.ToString());
                    sb.Append("</td>");
                

                    sb.Append("</tr>");
                }
                sb.Append("<tr style='border-bottom:1px solid'> <td colspan = '8'> &nbsp; </td> </tr>");
                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append("<td>");
                sb.Append("<b>Count</b>");
                sb.Append("</td>");
                sb.Append("<td colspan='2'>");
                sb.Append("<b>"+count+"</b>");
                sb.Append("</td>");
                sb.Append("<td>");
                sb.Append("");
                sb.Append("</td>");
                sb.Append("<td style='text-align:right'>");
                sb.Append("<b>"+totalmilklter+"</b>");
                sb.Append("</td>");
                sb.Append("<td style='text-align:right'>");
                sb.Append("<b>"+totalfatpercent+"</b>");
                sb.Append("</td>");
                sb.Append("<td style='text-align:right'>");
                sb.Append("<b>"+totalsnfpercent+"</b>");
                sb.Append("</td>");
                sb.Append("<td style='text-align:right'>");
                sb.Append("<b>"+totaltspercent+"</b>");
                sb.Append("</td>");


                sb.Append("</tr>");
                result = sb.ToString();
                CheckLists.Text = result;

                Session["ctrl"] = pnlCheckList;

            }
            else
            {
                result = "No Records Found";
                CheckLists.Text = result;

            }
            uprouteList.Update();

        }
    }
}