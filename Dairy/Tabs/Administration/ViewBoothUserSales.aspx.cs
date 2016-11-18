using Bussiness;
using Dairy.App_code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dairy.Tabs.Administration
{
    public partial class ViewBoothUserSales : System.Web.UI.Page
    {
        dynamic qty;
        dynamic total;
        string unt;
        string name;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDwon();
                //hftokanno.Value = Comman.Comman.RandomString();
                txtDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
            }
        }

        private void BindDropDwon()
        {
            DataSet DS = new DataSet();
            DS = BindCommanData.BindCommanDropDwon("AgentID", "AgentCode+' '+AgentName as Name", "AgentMaster", "IsArchive=0 and Agensytype='Booth'");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpAgent.DataSource = DS;
                dpAgent.DataBind();
                dpAgent.Items.Insert(0, new ListItem("--Select Booth --", "0"));
            }
            DS.Clear();
            DS = BindCommanData.BindCommanDropDwon("CategoryId", "CategoryName as Name", "Category", "IsActive=1");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpBrand.DataSource = DS;
                dpBrand.DataBind();
                dpBrand.Items.Insert(0, new ListItem("--All Brand--", "0"));
            }
        }

        protected void dpAgent_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet DS = new DataSet();
            DS = BindCommanData.BindBoothUserDropDwon( Convert.ToDateTime(txtDate.Text).ToString("dd-MM-yyyy") , Convert.ToInt32(dpAgent.SelectedItem.Value));
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpEmployee.DataSource = DS;
                dpEmployee.DataBind();
                dpEmployee.Items.Insert(0, new ListItem("--Select Employee--", "0"));
            }
            else { dpEmployee.DataSource = DS; dpEmployee.DataBind(); }
        }

        protected void btnViewSales_Click(object sender, EventArgs e)
        {
            DataSet DS = new DataSet();
            BillData billdata = new BillData();
            double localTotal = 0;
            double AgencyCashSale = 0;
            double AgencyCreditSale = 0;
            double EmpSale = 0;
            double schemeTot = 0;
            string result = string.Empty;
            int boothid = Convert.ToInt32(dpAgent.SelectedItem.Value);
            int userid = Convert.ToInt32(dpEmployee.SelectedItem.Value);
            string ShiftDate = Convert.ToDateTime(txtDate.Text).ToString("dd-MM-yyyy");
            int brandid = Convert.ToInt32(dpBrand.SelectedItem.Value);
            DS = billdata.getBoothUserSales(boothid, userid, ShiftDate, brandid);
            if (!Comman.Comman.IsDataSetEmpty(DS))
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
                sb.Append(DS.Tables[6].Rows[0]["EmployeeCode"].ToString() + " " + DS.Tables[6].Rows[0]["EmployeeName"].ToString());
                sb.Append("</td>");

                sb.Append("</tr>");

                sb.Append("<tr style='border-bottom:1px solid' > ");

                sb.Append("<td  style='text-align:left'>");
                sb.Append("Start Time: " + DS.Tables[0].Rows[0]["StartTime"].ToString());
                sb.Append("</td>");


                sb.Append("<td  style='text-align:right'>");
                sb.Append("End Time: " + DS.Tables[0].Rows[0]["EndTime"].ToString());
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
                    sb.Append(Convert.ToDecimal(row["Total"]).ToString("#.00"));
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
                sb.Append(EmpSale.ToString("#.00"));
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
                    sb.Append(Convert.ToDecimal(row["Total"]).ToString("#.00"));
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
                sb.Append(AgencyCreditSale.ToString("#.00"));
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
                    sb.Append(Convert.ToDecimal(row["Total"]).ToString("#.00"));
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
                sb.Append(AgencyCashSale.ToString("#.00"));
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
                    sb.Append(Convert.ToDecimal(row["Total"]).ToString("#.00"));
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
                sb.Append(localTotal.ToString("#.00"));
                sb.Append("</td>");
                #endregion

                if(brandid == 1 || brandid == 0)
                { 
                #region SchemeTotal

                sb.Append("<tr style='border-Top:1px solid' > ");
                sb.Append("<td colspan ='3' style='text-align:left'>");
                sb.Append("<b>(E) Scheme Received </b>");
                sb.Append("</td>");


                sb.Append("<tr style='border-Top:1px solid' > ");
                sb.Append("<td  style='text-align:right'>");
                sb.Append("&nbsp;");
                sb.Append("<td  style='text-align:right'>");
                sb.Append("Total Amount:");
                sb.Append("<td  style='text-align:right'>");
                schemeTot = string.IsNullOrEmpty(DS.Tables[5].Rows[0]["Total"].ToString()) ? 0 : Convert.ToDouble(DS.Tables[5].Rows[0]["Total"]);
                sb.Append(schemeTot.ToString("#.00"));
                sb.Append("</td>");

                    #endregion
                }
                sb.Append("<tr style='border-Top:1px solid' > ");
                sb.Append("<td colspan ='3' style='text-align:right'>");
                sb.Append("&nbsp;");
                sb.Append("</td>");
                sb.Append("</tr>");

                sb.Append("<tr style='border-Top:1px solid' > ");
                sb.Append("<td style='text-align:left'>");
                sb.Append("<b> Total Cash Sales <b>");
                sb.Append("</td>");
                sb.Append("<td style='text-align:left'>");
                sb.Append("<b>Total Credit Sale");
                sb.Append("</td>");
                sb.Append("<td style='text-align:left'>");
                sb.Append("<b> Total Sale <b>");
                sb.Append("</td>");
                sb.Append("</tr>");
                double cashSale = AgencyCashSale + localTotal + schemeTot;
                double creditSale = AgencyCreditSale + EmpSale;
                double totalSale = cashSale + creditSale;
                sb.Append("<tr style='border-Top:1px solid' > ");
                sb.Append("<td style='text-align:left'>");
                sb.Append("<b>" + cashSale.ToString("#.00") + "<b>");
                sb.Append("</td>");
                sb.Append("<td style='text-align:left'>");
                sb.Append("<b>" + creditSale.ToString("#.00") + "<b>");
                sb.Append("</td>");
                sb.Append("<td style='text-align:left'>");
                sb.Append("<b>" + totalSale.ToString("#.00") + "<b>");
                sb.Append("</td>");
                sb.Append("</tr>");

                sb.Append("<tr style='border-Top:1px solid' > ");
                sb.Append("<td colspan ='3' style='text-align:right'>");
                sb.Append("&nbsp;");
                sb.Append("</td>");
                sb.Append("</tr>");

                #region Itemwise SUmmary
                sb.Append("<tr>");
                sb.Append("<td> &nbsp; <td>");
                sb.Append("</tr>");

                sb.Append("<tr>");
                sb.Append("<td > <b> Itemwise Summary Cash Sale</b> <td>");
                sb.Append("</tr>");

                sb.Append("<tr  style='border-bottom:1px solid'>");
                    //sb.Append("<td  style='text-align:center'> <b> Sr.No. </b> </td>");
                    sb.Append("<td class='tg-yw4l'  style='text-align:left'>");
                    sb.Append("<b>Products</b>");
                    sb.Append("</td>");
                    sb.Append("<td  style='text-align:center'>");
                    sb.Append("<b> Quantity</b>");
                    sb.Append("</td>");
                    sb.Append("<td style='text-align:right'>");
                    sb.Append("<b>Amount</b>");
                    sb.Append("</td>");
                sb.Append("</tr>");

                DataTable dt = new DataTable();
                dt = DS.Tables[7];
                DataTable dt1 = new DataTable();
                dt1 = DS.Tables[3];
                dt1.Merge(dt);
                dt1.AcceptChanges();
                //var query = dt1.AsEnumerable().GroupBy(row => new { Name = row.Field<string>("ProductName"),
                //            unit = row.Field<string>("UnitName") });

                var query = dt1.AsEnumerable().GroupBy(row => new { Name = row.Field<string>("ProductName"), unit = row.Field<string>("UnitName") });
                var table2 = dt1.Clone(); // empty table with same schema

                double sumTemp = 0;
                int sr = 0;
                foreach (var x in query)
                {
                    sr++;
                    name = x.Key.Name;
                    unt = x.Key.unit;

                    qty = x.Sum(r => r.Field<double>("Qty"));
                    //unt = x.(r => r.Field<string>("UnitName"));
                    total = x.Sum(r => r.Field<decimal>("Total"));

                    table2.Rows.Add(x.Key.Name, qty, total, x.Key.unit);

                    sb.Append("<tr  style='border-bottom:1px solid'>");
                    //sb.Append("<td  style='text-align:left'>");
                    //sb.Append(sr.ToString());
                    //sb.Append(" </td>");
                    sb.Append("<td class='tg-yw4l' style='text-align:left'>");
                    sb.Append(name.ToString());
                    sb.Append("</td>");
                    sb.Append("<td  style='text-align:center'>");
                    sb.Append(qty.ToString() + " " + unt.ToString());
                    sb.Append("</td>");
                    sb.Append("<td  style='text-align:right'>");
                    sumTemp = sumTemp + Convert.ToDouble(total);
                    sb.Append(total.ToString("#0.00"));
                    sb.Append("</td>");
                    sb.Append("</tr>");
                }

                sb.Append("<tr> <td style='text-align:right'> </td> <td> Total </td> <td style='text-align:right'>");
                sb.Append(sumTemp.ToString("#0.00" + "</td></tr>"));

                    #endregion




                    result = sb.ToString();
                genratedBIll.Text = result;
                //Session["ctrl"] = sb.ToString();
                Session["ctrl1"] = pnlBill;
                //Response.Redirect("/print.aspx", true);

            }
            else
            {
                result = "No Sales Available";
                genratedBIll.Text = result;

            }
        }
    }
}