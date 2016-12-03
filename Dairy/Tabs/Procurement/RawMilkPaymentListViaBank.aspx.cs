using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using Bussiness;
using System.Text;
using System.IO;


namespace Dairy.Tabs.Procurement
{
    public partial class RawMilkPaymentListViaBank : System.Web.UI.Page
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
            DS = BindCommanData.BindCommanDropDwon("RouteID ", "RouteCode +' '+RouteName as Name  ", "Proc_MilkCollectionRoute", "IsActive=1 ");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpRoute.DataSource = DS;
                dpRoute.DataBind();
                dpRoute.Items.Insert(0, new ListItem("--All Route  --", "0"));

            }
            DS = BindCommanData.BindCommanDropDwonDistinct("ID", "BankName as Name", "BankDetails", "ID is not null");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpBankName.DataSource = DS;
                dpBankName.DataBind();
                dpBankName.Items.Insert(0, new ListItem("--All Bank Name--", "0"));
            }

            DS = BindCommanData.BindCommanDropDwonDistinct("ID", "IFSCCode as Name", "BankDetails", "ID is not null");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpIfscCode.DataSource = DS;
                dpIfscCode.DataBind();
                dpIfscCode.Items.Insert(0, new ListItem("--All Ifsc Code--", "0"));
            }
        }
        protected void btnGeneratereport_Click(object sender, EventArgs e)
        {
            Model.Procurement p = new Model.Procurement();
            ProcurementData pd = new ProcurementData();

            p.RouteID = Convert.ToInt32(dpRoute.SelectedItem.Value);
            p.FomDate = Convert.ToDateTime(txtStartDate.Text);
            p.ToDate = Convert.ToDateTime(txtEndDate.Text);
            if(dpBankName.SelectedItem.Value=="0")
            { p.BankName = "0"; }
            else { p.BankName = dpBankName.SelectedItem.Text; }
           if(dpIfscCode.SelectedItem.Value=="0")
            { p.IFSCCode = "0"; }
            else { p.IFSCCode = dpIfscCode.SelectedItem.Text; }
            DataSet DS1 = new DataSet();
            DS1 = pd.RawMilkPaymentListViaBank(p);
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
                sb.Append("<u>Raw Milk Payment List Via Bank</u> <br/>");
                sb.Append("</th>");

                sb.Append("<th class='tg-yw4l' style='text-align:right'>");

                sb.Append("<br>");
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
                sb.Append(dpRoute.SelectedItem.Text.ToString());
                sb.Append("</td>");
                sb.Append("<td colspan='2'>");
                sb.Append("Date : " + Convert.ToDateTime(txtStartDate.Text).ToString("dd-MM-yyyy"));
                sb.Append("</td>");
                sb.Append("<td colspan='2'>");
                sb.Append("To : " + Convert.ToDateTime(txtEndDate.Text).ToString("dd-MM-yyyy"));
                sb.Append("</td>");
                sb.Append("</tr>");
                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append("<td colspan='2' style='text-align:center'>");
                sb.Append("<b>Supplier</b>");
                sb.Append("</td>");
                sb.Append("<td>");
                sb.Append("<b>Bank A/C No.</b>");
                sb.Append("</td>");
                sb.Append("<td>");
                sb.Append("<b>Loan A/C No.</b>");
                sb.Append("</td>");
                sb.Append("<td>");
                sb.Append("<b>A/C Name</b>");
                sb.Append("</td>");
                sb.Append("<td>");
                sb.Append("<b>Bank Loan</b>");
                sb.Append("</td>");
                sb.Append("<td>");
                sb.Append("<b>Amount</b>");
                sb.Append("</td>");
                sb.Append("<td>");
                sb.Append("<b>Net Amount</b>");
                sb.Append("</td>");
                sb.Append("</tr>");
                sb.Append("<tr>");
                int count=0;
                double netamt=0;
                double loanamt=0;
                double loanpaid=0;
                double totalnetamt=0;
                double totalloanamt=0;
                double totalloanpaid=0;
                foreach (DataRow row in DS1.Tables[0].Rows)
                {
                    count++;
                    sb.Append("<td>");
                    sb.Append(row["SupplierCode"].ToString());
                    sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append(row["SupplierName"].ToString());
                    sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append(row["AccountNo"].ToString());
                    sb.Append("</td>");
                  
                    sb.Append("<td>");
                    sb.Append(row["LoanAccountNo"].ToString());
                    sb.Append("</td>");

                    sb.Append("<td>");
                    sb.Append(row["AccountName"].ToString());
                    sb.Append("</td>");

                    sb.Append("<td>");
                    try { loanamt = Convert.ToDouble(row["LoanAmount"]); }
                    catch { loanamt = 0.00; }
                    totalloanamt += loanamt;
                    sb.Append(loanamt);
                    sb.Append("</td>");
                    sb.Append("<td>");
                    try { loanpaid = Convert.ToDouble(row["LoanAmtPaid"]); }
                    catch { loanpaid = 0.00; }
                    totalloanpaid += loanpaid;
                    sb.Append(loanpaid);
                    sb.Append("</td>");
                    sb.Append("<td>");
                    netamt = loanamt - loanpaid;
                    totalnetamt += netamt;
                    sb.Append(netamt);
                    sb.Append("</td>");

                    sb.Append("</tr>");
                }
                sb.Append("<tr style='border-bottom:1px solid'><td colspan='8'></td></tr>");
                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append("<td  style='text-align:left'>");
                sb.Append("<b>Total</b>");
                sb.Append("</td>");
                sb.Append("<td colspan='4' style='text-align:left'>");
                sb.Append("<b>"+count+"</b>");
                sb.Append("</td>");
                sb.Append("<td>");
                sb.Append("<b>"+totalloanamt+"</b>");
                sb.Append("</td>");
                sb.Append("<td>");
                sb.Append("<b>"+totalloanpaid+"</b>");
                sb.Append("</td>");
                sb.Append("<td>");
                sb.Append("<b>"+totalnetamt+"</b>");
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

        protected void btnExporttoexcell_Click(object sender, EventArgs e)
        {
            Model.Procurement p = new Model.Procurement();
            ProcurementData pd = new ProcurementData();

            p.RouteID = Convert.ToInt32(dpRoute.SelectedItem.Value);
            p.FomDate = Convert.ToDateTime(txtStartDate.Text);
            p.ToDate = Convert.ToDateTime(txtEndDate.Text);
            if (dpBankName.SelectedItem.Value == "0")
            { p.BankName = "0"; }
            else { p.BankName = dpBankName.SelectedItem.Text; }
            if (dpIfscCode.SelectedItem.Value == "0")
            { p.IFSCCode = "0"; }
            else { p.IFSCCode = dpIfscCode.SelectedItem.Text; }
            DataSet DS = new DataSet();
            DS = pd.RawMilkPaymentListViaBank(p);
            string result = string.Empty;
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                Response.ClearContent();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "Customers.xls"));
                Response.ContentType = "application/ms-excel";
                DataTable dt = DS.Tables[0];
                string str = string.Empty;
                foreach (DataColumn dtcol in dt.Columns)
                {
                    Response.Write(str + dtcol.ColumnName);
                    str = "\t";
                }
                Response.Write("\n");
                foreach (DataRow dr in dt.Rows)
                {
                    str = "";
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        Response.Write(str + Convert.ToString(dr[j]));
                        str = "\t";
                    }
                    Response.Write("\n");
                }
                Response.End();
            }

        }

        protected void btnExportinText_Click(object sender, EventArgs e)
        {

        }
    }
    }
