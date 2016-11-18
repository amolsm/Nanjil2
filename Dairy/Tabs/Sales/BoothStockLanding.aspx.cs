using Bussiness;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Comman;
using Dairy.App_code;
using System.Configuration;
using System.Data.SqlClient;
namespace Dairy.Tabs.Sales
{
    public partial class BoothStockLanding : System.Web.UI.Page
    {
        BillData billdata = new BillData();
        InvoiceData indata = new InvoiceData();
        DataSet DS = new DataSet();
        DataSet DS1 = new DataSet();
        DataSet ds = new DataSet();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
            }
        }

        private void bindStockUser()
        {
            int userid = Convert.ToInt32(GlobalInfo.Userid);
            int boothid = Convert.ToInt32(GlobalInfo.CurrentbothID);
            DS = indata.updateStockUser(boothid, userid );
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
            DS.Tables[0].Columns.Add("UserID", typeof(int));
            for (int i = 0; i <= DS.Tables[0].Rows.Count - 1; i++)
            {
                DS.Tables[0].Rows[i]["UserID"] = userid;
            }
            DS.Tables[0].Columns.Add("ShiftDate", typeof(string));
            for (int i = 0; i <= DS.Tables[0].Rows.Count - 1; i++)
            {
                DS.Tables[0].Rows[i]["ShiftDate"] = DateTime.Now.ToString("dd-MM-yyyy");
            }
            DS.Tables[0].Columns.Add("StartTime", typeof(string));
            for (int i = 0; i <= DS.Tables[0].Rows.Count - 1; i++)
            {
                DS.Tables[0].Rows[i]["StartTime"] = DateTime.Now.ToString("HH:mm");
            }


            
                string constr = ConfigurationManager.ConnectionStrings["projectConnection"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_UserStockUpdate"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@tblStock", DS.Tables[0]);
                        con.Open();
                       int z =  cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
        }

        private void bindstock()
        {
            string result = string.Empty;
            int boothid = Convert.ToInt32(GlobalInfo.CurrentbothID);
            int userid = Convert.ToInt32(GlobalInfo.Userid);
            string ShiftDate = DateTime.Now.ToString("dd-MM-yyyy");
            DS = billdata.getStockforboothLanding(boothid, userid, ShiftDate);
            ds = billdata.getEmployeeByUserId(userid);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                try
                {
                    StringBuilder sb = new StringBuilder();


                    sb.Append("<style type='text / css'>");
                    sb.Append(".tg  { border - collapse:collapse; border - spacing:0; border: none; }");
                    sb.Append(".tg .tg-yw4l{vertical-align:top}");
                    sb.Append(".tg .tg-baqh{text-align:center;vertical-align:top}");
                    sb.Append("</style>");
                    sb.Append("<table class='tg style1' style='page-break-inside:avoid; align:center;'>");
                    sb.Append("<colgroup>");
                    sb.Append("<col style = 'width:120px'>");
                    sb.Append("<col style = 'width:120px'>");
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
                    sb.Append("<u> Current Stock Available </u> <br/>");
                    sb.Append("</th>");

                    sb.Append("<th class='tg-yw4l' style='text-align:right'>");

                    sb.Append("TIN:330761667331<br>");
                    sb.Append("</th>");
                    sb.Append("</tr>");

                    sb.Append("<tr style='border-bottom:1px solid'>");
                    sb.Append("<td class='tg-yw4l' colspan='7' style='text-align:center'>");
                    sb.Append("<b>Nanjil Integrated Dairy Development ,Mulagunoodu, K.K.Dt.</b>");

                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l' style='text-align:right'>");

                    sb.Append("PH:248370,248605");

                    sb.Append("</td>");

                    sb.Append("</tr>");

                    sb.Append("<tr style='border-bottom:1px solid' > ");

                    sb.Append("<td colspan ='2' style='text-align:left'>");
                    sb.Append(DS.Tables[0].Rows[0]["ShiftDate"].ToString());
                    sb.Append("</td>");

                    sb.Append("<td colspan ='5' rowspan='2' style='text-align:center'>");
                    sb.Append(DS.Tables[0].Rows[0]["AgentName"].ToString());
                    sb.Append("</td>");

                    sb.Append("<td colspan ='2' style='text-align:right'>");
                    string empCode = string.IsNullOrEmpty(ds.Tables[0].Rows[0]["EmployeeCode"].ToString()) ? "Employee" : ds.Tables[0].Rows[0]["EmployeeCode"].ToString();
                    string empName = string.IsNullOrEmpty(ds.Tables[0].Rows[0]["EmployeeName"].ToString()) ? "Not Mapped" : ds.Tables[0].Rows[0]["EmployeeName"].ToString();
                    sb.Append(empCode + " " + empName);
                    sb.Append("</td>");

                    sb.Append("</tr>");
                    sb.Append("<tr style='border-bottom:1px solid' > ");

                    sb.Append("<td colspan ='2' style='text-align:left'>");
                    sb.Append("Start Time: " + DS.Tables[0].Rows[0]["StartTime"].ToString());
                    sb.Append("</td>");


                    sb.Append("<td colspan ='2' style='text-align:right'>");
                    sb.Append("End Time: " + DateTime.Now.ToString("HH:mm"));
                    sb.Append("</td>");

                    sb.Append("</tr>");

                    sb.Append("<tr style='border-bottom:1px solid'>");
                    sb.Append("<td>");
                    sb.Append("<b> Type Name </b> ");
                    sb.Append("</td>");

                    sb.Append("<td>");
                    sb.Append("<b> Product Name </b> ");
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l' style='text-align:center'>");
                    sb.Append("<b> Opening Stock </b> ");
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l' style='text-align:center'>");
                    sb.Append("<b> Dispatch </b> ");
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l' style='text-align:center'>");
                    sb.Append("<b> Sales </b> ");
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l' style='text-align:center'>");
                    sb.Append("<b>Return</b> ");
                    sb.Append("</td>");
                                   
                    sb.Append("<td class='tg-yw4l' style='text-align:center'>");
                    sb.Append("<b> Spot Damage </b> ");
                    sb.Append("</td>");


                    sb.Append("<td class='tg-yw4l' style='text-align:center'>");
                    sb.Append("<b>Gift/Others</b> ");
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l' style='text-align:center'>");
                    sb.Append("<b>Closing Stock</b> ");
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l' style='text-align:center'>");
                    sb.Append("<b> </b> ");
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l' style='text-align:center'>");
                    sb.Append("<b></b> ");
                    sb.Append("</td>");

                    sb.Append("</tr>");


                    foreach (DataRow row in DS.Tables[0].Rows)
                    {
                        sb.Append("<tr>");
                        sb.Append("<td>");
                        sb.Append(row["TypeName"].ToString());
                        sb.Append("</td>");

                        sb.Append("<td>");
                        sb.Append(row["ProductName"].ToString());
                        sb.Append("</td>");

                        sb.Append("<td class='tg-yw4l' style='text-align:center'>");
                        sb.Append(row["OpeningQuantity"].ToString());
                        sb.Append("</td>");

                        sb.Append("<td class='tg-yw4l' style='text-align:center'>");
                        sb.Append(row["Dispatch"].ToString());
                        sb.Append("</td>");

                        sb.Append("<td class='tg-yw4l' style='text-align:center'>");
                        sb.Append(row["SaleQuantity"].ToString());
                        sb.Append("</td>");

                        sb.Append("<td class='tg-yw4l' style='text-align:center'>");
                        sb.Append(row["ReturnQuantity"].ToString());
                        sb.Append("</td>");

                        sb.Append("<td class='tg-yw4l' style='text-align:center'>");
                        sb.Append(row["SpotDamage"].ToString());
                        sb.Append("</td>");

                        sb.Append("<td class='tg-yw4l' style='text-align:center'>");
                        sb.Append(row["Others"].ToString());
                        sb.Append("</td>");

                        sb.Append("<td class='tg-yw4l' style='text-align:center'>");
                        sb.Append(row["ClosingQuantity"].ToString());
                        sb.Append("</td>");


                        
                        sb.Append("</tr>");
                    }

                    sb.Append("<tr style='border-Top:1px solid' > ");
                    sb.Append("<td colspan ='10' style='text-align:right'>");
                    sb.Append("&nbsp;");
                    sb.Append("</td>");

                    sb.Append("</tr>");

                    sb.Append("<tr > ");

                    sb.Append("<td colspan ='3' style='text-align:center'>");
                    sb.Append("Handover Given");
                    sb.Append("</td>");

                    sb.Append("<td colspan ='3' style='text-align:center'>");
                    sb.Append("Handover Received");
                    sb.Append("</td>");

                    sb.Append("<td colspan ='3' style='text-align:center'>");
                    sb.Append("Authorized Person");
                    sb.Append("</td>");

                    sb.Append("</tr>");




                    result = sb.ToString();
                    genratedBIll.Text = result;
                    //Session["ctrl"] = sb.ToString();
                    Session["ctrl"] = pnlBill;
                    //Response.Redirect("/print.aspx", true);
                }
                catch (Exception ex)
                {
                    result = "No Stock Available";
                    genratedBIll.Text = result;
                }
            }
            else
            {
                result = "No Stock Available";
                genratedBIll.Text = result;

            }


        }

        protected void btnStart_Click(object sender, EventArgs e)
        {
            
            bindStockUser();
            bindstock();
            updateSalesSummary();
        }

        private void updateSalesSummary()
        {
            double localTotal = 0;
            double AgencyCashSale = 0;
            double AgencyCreditSale = 0;
            double EmpSale = 0;
            double schemeTot = 0;
            string result = string.Empty;
            int boothid = Convert.ToInt32(GlobalInfo.CurrentbothID);
            int userid = Convert.ToInt32(GlobalInfo.Userid);
            string ShiftDate = DateTime.Now.ToString("dd-MM-yyyy");
            DS = billdata.getStockforboothLanding(boothid, userid, ShiftDate);
            ds = billdata.getEmployeeByUserId(userid);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                try
                {
                    StringBuilder sb = new StringBuilder();


                    sb.Append("<style type='text / css'>");
                    sb.Append(".tg  { border - collapse:collapse; border - spacing:0; border: none; }");
                    sb.Append(".tg .tg-yw4l{vertical-align:top}");
                    sb.Append(".tg .tg-baqh{text-align:center;vertical-align:top}");
                    sb.Append("</style>");
                    sb.Append("<table class='tg style1' style='page-break-inside:avoid; align:center;'>");
                    sb.Append("<colgroup>");
                    sb.Append("<col style = 'width:200px'>");
                    sb.Append("<col style = 'width:200px'>");
                    sb.Append("<col style = 'width:200px'>");

                    sb.Append("</colgroup>");
                    sb.Append("<br/><hr/><br/>");
                    sb.Append("<tr>");
                    sb.Append("<th class='tg-yw4l' rowspan='2'>");
                    sb.Append("<img src='/Theme/img/logo1.png' class='img-circle' alt='Logo' width='50px' hight='50px'>");
                    sb.Append("</th>");

                    sb.Append("<th class='tg-baqh'  style='text-align:center'>");
                    sb.Append("<u> Sales Summary </u> <br/>");
                    sb.Append("</th>");

                    sb.Append("<th class='tg-yw4l' style='text-align:right'>");
                    sb.Append("TIN:330761667331<br>");
                    sb.Append("</th>");
                    sb.Append("</tr>");

                    sb.Append("<tr style='border-bottom:1px solid'>");
                    sb.Append("<td class='tg-yw4l'  style='text-align:center'>");
                    sb.Append("<b>Nanjil Integrated Dairy Development ,Mulagunoodu, K.K.Dt.</b>");
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l' style='text-align:right'>");
                    sb.Append("PH:248370,248605");
                    sb.Append("</td>");
                    sb.Append("</tr>");

                    sb.Append("<tr style='border-bottom:1px solid' > ");

                    sb.Append("<td  style='text-align:left'>");
                    sb.Append(DS.Tables[0].Rows[0]["ShiftDate"].ToString());
                    sb.Append("</td>");

                    sb.Append("<td  rowspan='2' style='text-align:center'>");
                    sb.Append(DS.Tables[0].Rows[0]["AgentName"].ToString());
                    sb.Append("</td>");

                    sb.Append("<td  style='text-align:right'>");
                    string empCode = string.IsNullOrEmpty(ds.Tables[0].Rows[0]["EmployeeCode"].ToString()) ? "Employee" : ds.Tables[0].Rows[0]["EmployeeCode"].ToString();
                    string empName = string.IsNullOrEmpty(ds.Tables[0].Rows[0]["EmployeeName"].ToString()) ? "Not Mapped" : ds.Tables[0].Rows[0]["EmployeeName"].ToString();
                    sb.Append(empCode + " " + empName);
                    sb.Append("</td>");

                    sb.Append("</tr>");

                    sb.Append("<tr style='border-bottom:1px solid' > ");

                    sb.Append("<td  style='text-align:left'>");
                    sb.Append("Start Time: " + DS.Tables[0].Rows[0]["StartTime"].ToString());
                    sb.Append("</td>");


                    sb.Append("<td  style='text-align:right'>");
                    sb.Append("End Time: " + DateTime.Now.ToString("HH:mm"));
                    sb.Append("</td>");

                    sb.Append("</tr>");

                    #region Employee Sale

                    sb.Append("<tr style='border-Top:1px solid' > ");
                    sb.Append("<td colspan ='3' style='text-align:left'>");
                    sb.Append("<b>(A) Staff Sale </b>");
                    sb.Append("</td>");

                    sb.Append("<tr style='border-bottom:1px solid' style='text-align:center'>");
                    sb.Append("<td >");
                    sb.Append("<b> Product Name </b> ");
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l'  style='text-align:center'>");
                    sb.Append("<b> Quantity </b> ");
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l'  style='text-align:right'>");
                    sb.Append("<b> Total </b> ");
                    sb.Append("</td>");

                    sb.Append("</tr>");

                    foreach (DataRow row in DS.Tables[4].Rows)
                    {
                        sb.Append("<tr>");

                        sb.Append("<td  class='tg-yw4l' style='text-align:left'>");
                        sb.Append(row["ProductName"].ToString());
                        sb.Append("</td>");

                        sb.Append("<td  class='tg-yw4l' style='text-align:center'>");
                        sb.Append(row["Qty"].ToString() + " " + row["UnitName"].ToString());
                        sb.Append("</td>");

                        sb.Append("<td  class='tg-yw4l' style='text-align:right'>");
                        sb.Append(Convert.ToDouble(row["Total"]).ToString("#0.00"));
                        sb.Append("</td>");
                        sb.Append("</tr>");
                        EmpSale = EmpSale + (string.IsNullOrEmpty(row["Total"].ToString()) ? 0 : Convert.ToDouble(row["Total"]));
                    }
                    sb.Append("<tr style='border-Top:1px solid' > ");
                    sb.Append("<td  style='text-align:right'>");
                    sb.Append("&nbsp;");
                    sb.Append("<td  style='text-align:right'>");
                    sb.Append("Total Amount:");
                    sb.Append("<td  style='text-align:right'>");
                    sb.Append(EmpSale.ToString("#0.00"));
                    sb.Append("</td>");
                    #endregion

                    #region AgencyCreditSale
                    sb.Append("<tr style='border-Top:1px solid' > ");
                    sb.Append("<td colspan ='3' style='text-align:left'>");
                    sb.Append("<b>(B) Agency Credit Sale </b>");
                    sb.Append("</td>");

                    sb.Append("<tr style='border-bottom:1px solid' style='text-align:center'>");
                    sb.Append("<td >");
                    sb.Append("<b> Product Name </b> ");
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l'  style='text-align:center'>");
                    sb.Append("<b> Quantity </b> ");
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l'  style='text-align:right'>");
                    sb.Append("<b> Total </b> ");
                    sb.Append("</td>");

                    sb.Append("</tr>");

                    foreach (DataRow row in DS.Tables[2].Rows)
                    {
                        sb.Append("<tr>");

                        sb.Append("<td  class='tg-yw4l' style='text-align:left'>");
                        sb.Append(row["ProductName"].ToString());
                        sb.Append("</td>");

                        sb.Append("<td  class='tg-yw4l' style='text-align:center'>");
                        sb.Append(row["Qty"].ToString() + " " + row["UnitName"].ToString());
                        sb.Append("</td>");

                        sb.Append("<td  class='tg-yw4l' style='text-align:right'>");
                        sb.Append(Convert.ToDouble(row["Total"]).ToString("#0.00"));
                        sb.Append("</td>");
                        sb.Append("</tr>");
                        AgencyCreditSale = AgencyCreditSale + Convert.ToDouble(row["Total"]);
                    }
                    sb.Append("<tr style='border-Top:1px solid' > ");
                    sb.Append("<td  style='text-align:right'>");
                    sb.Append("&nbsp;");
                    sb.Append("<td  style='text-align:right'>");
                    sb.Append("Total Amount:");
                    sb.Append("<td  style='text-align:right'>");
                    sb.Append(AgencyCreditSale.ToString("#0.00"));
                    sb.Append("</td>");

                    #endregion

                    #region AgencyCashSale
                    sb.Append("<tr style='border-Top:1px solid' > ");
                    sb.Append("<td colspan ='3' style='text-align:left'>");
                    sb.Append("<b>(C) Agency Cash Sale </b>");
                    sb.Append("</td>");

                    sb.Append("<tr style='border-bottom:1px solid' style='text-align:center'>");
                    sb.Append("<td >");
                    sb.Append("<b> Product Name </b> ");
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l'  style='text-align:center'>");
                    sb.Append("<b> Quantity </b> ");
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l'  style='text-align:right'>");
                    sb.Append("<b> Total </b> ");
                    sb.Append("</td>");

                    sb.Append("</tr>");

                    foreach (DataRow row in DS.Tables[1].Rows)
                    {
                        sb.Append("<tr>");

                        sb.Append("<td  class='tg-yw4l' style='text-align:left'>");
                        sb.Append(row["ProductName"].ToString());
                        sb.Append("</td>");

                        sb.Append("<td  class='tg-yw4l' style='text-align:center'>");
                        sb.Append(row["Qty"].ToString() + " " + row["UnitName"].ToString());
                        sb.Append("</td>");

                        sb.Append("<td  class='tg-yw4l' style='text-align:right'>");
                        sb.Append(Convert.ToDouble(row["Total"]).ToString("#0.00"));
                        sb.Append("</td>");
                        sb.Append("</tr>");
                        AgencyCashSale = AgencyCashSale + Convert.ToDouble(row["Total"]);
                    }
                    sb.Append("<tr style='border-Top:1px solid' > ");
                    sb.Append("<td  style='text-align:right'>");
                    sb.Append("&nbsp;");
                    sb.Append("<td  style='text-align:right'>");
                    sb.Append("Total Amount:");
                    sb.Append("<td  style='text-align:right'>");
                    sb.Append(AgencyCashSale.ToString("#0.00"));
                    sb.Append("</td>");

                    #endregion

                    #region Local Sale

                    sb.Append("<tr style='border-Top:1px solid' > ");
                    sb.Append("<td colspan ='3' style='text-align:left'>");
                    sb.Append("<b>(D) Local Sale </b>");
                    sb.Append("</td>");

                    sb.Append("<tr style='border-bottom:1px solid' style='text-align:center'>");
                    sb.Append("<td >");
                    sb.Append("<b> Product Name </b> ");
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l'  style='text-align:center'>");
                    sb.Append("<b> Quantity </b> ");
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l'  style='text-align:right'>");
                    sb.Append("<b> Total </b> ");
                    sb.Append("</td>");

                    sb.Append("</tr>");

                    foreach (DataRow row in DS.Tables[3].Rows)
                    {
                        sb.Append("<tr>");

                        sb.Append("<td  class='tg-yw4l' style='text-align:left'>");
                        sb.Append(row["ProductName"].ToString());
                        sb.Append("</td>");

                        sb.Append("<td  class='tg-yw4l' style='text-align:center'>");
                        sb.Append(row["Qty"].ToString() + " " + row["UnitName"].ToString());
                        sb.Append("</td>");

                        sb.Append("<td  class='tg-yw4l' style='text-align:right'>");
                        sb.Append(Convert.ToDouble(row["Total"]).ToString("#0.00"));
                        sb.Append("</td>");
                        sb.Append("</tr>");
                        localTotal = localTotal + Convert.ToDouble(row["Total"]);
                    }
                    sb.Append("<tr style='border-Top:1px solid' > ");
                    sb.Append("<td  style='text-align:right'>");
                    sb.Append("&nbsp;");
                    sb.Append("<td  style='text-align:right'>");
                    sb.Append("Total Amount:");
                    sb.Append("<td  style='text-align:right'>");
                    sb.Append(localTotal.ToString("#0.00"));
                    sb.Append("</td>");
                    #endregion


                    #region SchemeTotal

                    sb.Append("<tr style='border-Top:1px solid' > ");
                    sb.Append("<td colspan ='3' style='text-align:left'>");
                    sb.Append("<b>(E) Scheme Received </b>");
                    sb.Append("</td>");


                    sb.Append("<tr style='border-Top:1px solid' > ");
                    sb.Append("<td  style='text-align:center'>");
                    sb.Append("Scheme");
                    sb.Append("<td  style='text-align:right'>");
                    sb.Append("Total Amount:");
                    sb.Append("<td  style='text-align:right'>");
                    schemeTot = string.IsNullOrEmpty(DS.Tables[5].Rows[0]["Total"].ToString()) ? 0 : Convert.ToDouble(DS.Tables[5].Rows[0]["Total"]);
                    sb.Append(schemeTot.ToString("#0.00"));
                    sb.Append("</td>");

                    #endregion

                    sb.Append("<tr style='border-Top:1px solid' > ");
                    sb.Append("<td colspan ='3' style='text-align:right'>");
                    sb.Append("&nbsp;");
                    sb.Append("</td>");
                    sb.Append("</tr>");

                    sb.Append("<tr style='border-Top:1px solid' > ");
                    sb.Append("<td style='text-align:left'>");
                    sb.Append("<b> Total Cash Sales <b>");
                    sb.Append("</td>");
                    sb.Append("<td style='text-align:center'>");
                    sb.Append("<b>Total Credit Sale");
                    sb.Append("</td>");
                    sb.Append("<td style='text-align:right'>");
                    sb.Append("<b> Total Sale <b>");
                    sb.Append("</td>");
                    sb.Append("</tr>");
                    double cashSale = AgencyCashSale + localTotal + schemeTot;
                    double creditSale = AgencyCreditSale + EmpSale;
                    double totalSale = cashSale + creditSale;
                    sb.Append("<tr style='border-Top:1px solid' > ");
                    sb.Append("<td style='text-align:left'>");
                    sb.Append("<b>" + cashSale.ToString("#0.00") + "<b>");
                    sb.Append("</td>");
                    sb.Append("<td style='text-align:center'>");
                    sb.Append("<b>" + creditSale.ToString("#0.00") + "<b>");
                    sb.Append("</td>");
                    sb.Append("<td style='text-align:right'>");
                    sb.Append("<b>" + totalSale.ToString("#0.00") + "<b>");
                    sb.Append("</td>");
                    sb.Append("</tr>");

                    sb.Append("<tr style='border-Top:1px solid' > ");
                    sb.Append("<td colspan ='3' style='text-align:right'>");
                    sb.Append("&nbsp;");
                    sb.Append("</td>");
                    sb.Append("</tr>");

                    sb.Append("<tr > ");

                    sb.Append("<td  style='text-align:center'>");
                    sb.Append("Handover Given");
                    sb.Append("</td>");

                    sb.Append("<td  style='text-align:center'>");
                    sb.Append("Handover Received");
                    sb.Append("</td>");

                    sb.Append("<td  style='text-align:center'>");
                    sb.Append("Authorized Person");
                    sb.Append("</td>");

                    sb.Append("</tr>");




                    result = sb.ToString();
                    SalesSummary.Text = result;
                    //Session["ctrl"] = sb.ToString();
                    Session["ctrl1"] = pnlSalesSummary;
                    //Response.Redirect("/print.aspx", true);
                }
                catch (Exception ex)
                { }
            }
            else
            {
                result = "No Sales Available";
                genratedBIll.Text = result;

            }
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            int result;
            int boothid = Convert.ToInt32(GlobalInfo.CurrentbothID);
            int userid = Convert.ToInt32(GlobalInfo.Userid);
            string shiftdate = DateTime.Now.ToString("dd-MM-yyyy");
            string EndTime = DateTime.Now.ToString("hh:mm");
            result = billdata.EndBoothStockUser(boothid, userid, shiftdate, EndTime);
            if (result > 0)
            {

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "User Shift Ended Successfully";

                //ClearTextBox();
                //BindSlabInfo();
                pnlError.Update();
                upMain.Update();
                
                
                //uprouteList.Update();
            }
            else
            {
                divDanger.Visible = false;
                divwarning.Visible = true;
                divSusccess.Visible = false;
                lblwarning.Text = "Please Contact to Site Admin";
                pnlError.Update();

            }

        }
        
    }

       
}