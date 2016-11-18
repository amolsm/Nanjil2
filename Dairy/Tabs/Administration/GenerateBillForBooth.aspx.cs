using Bussiness;
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
    public partial class GenerateBillForBooth : System.Web.UI.Page
    {
        BillData billdata = new BillData();
        DataSet DS = new DataSet();
        DataSet DS1 = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                EmployeeData empData = new EmployeeData();
                DS = BindCommanData.BindCommanDropDwon("RouteID ", "RouteCode +' '+RouteName as Name  ", "routeMaster", "IsArchive=1");
                if (!Comman.Comman.IsDataSetEmpty(DS))
                {
                    dpRoute.DataSource = DS;
                    dpRoute.DataBind();
                    dpRoute.Items.Insert(0, new ListItem("--Select Route  --", "0"));
                }

                //DS = BindCommanData.BindCommanDropDwon("EmployeeID", "EmployeeCode+' '+EmployeeName as Name", "employeemaster", "IsArchive=0");
                //if (!Comman.Comman.IsDataSetEmpty(DS))
                //{
                //    dpAgentSelasEMployee.DataSource = DS;
                //    dpAgentSelasEMployee.DataBind();
                //    dpAgentSelasEMployee.Items.Insert(0, new ListItem("Agent Sales Person", "0"));


                //}
                txtDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
            }
        }
        protected void btngenrateBill_click(object sender, EventArgs e)
        {
            string result = string.Empty;
            DS = billdata.GenrateBillForBoothByDate((Convert.ToDateTime(txtDate.Text)).ToString("dd-MM-yyyy"), Convert.ToInt32(dpRoute.SelectedItem.Value));
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                StringBuilder sb = new StringBuilder();

                foreach (DataRow row in DS.Tables[0].Rows)
                {

                    int count = 0;
                    double qty = 0;
                    sb.Append("<style type='text / css'>");
                    sb.Append(".tg  { border - collapse:collapse; border - spacing:0; border: none; }");
                    sb.Append(".tg .tg-yw4l{vertical-align:top}");
                    sb.Append(".tg .tg-baqh{text-align:center;vertical-align:top}");
                    sb.Append("</style>");
                    sb.Append("<table class='tg style1' style='page-break-inside:avoid; align:center;'>");
                    sb.Append("<colgroup>");
                    sb.Append("<col style = 'width:100px'>");
                    sb.Append("<col style = 'width:80px'>");
                    sb.Append("<col style = 'width:80px'>");
                    sb.Append("<col style = 'width:120px'>");
                    sb.Append("<col style = 'width:120px'>");
                    sb.Append("<col style = 'width:100px'>");
                    sb.Append("<col style = 'width:100px'>");
                    sb.Append("<col style = 'width:100px'>");
                    sb.Append("</colgroup>");

                    sb.Append("<tr>");
                    sb.Append("<th class='tg-yw4l' rowspan='2'>");
                    sb.Append("<img src='/Theme/img/logo.png' class='img-circle' alt='Logo' width='50px' hight='50px'>");
                    sb.Append("</th>");

                    sb.Append("<th class='tg-baqh' colspan='6' style='text-align:center'>");
                    sb.Append("<u> Cash/Credit Bill </u> <br/>");
                    sb.Append("</th>");

                    sb.Append("<th class='tg-yw4l' style='text-align:right'>");

                    sb.Append("TIN:330761667331<br>");
                    sb.Append("</th>");
                    sb.Append("</tr>");

                    sb.Append("<tr style='border-bottom:1px solid'>");
                    sb.Append("<td class='tg-yw4l' colspan='6' style='text-align:center'>");
                    sb.Append("<b>Nanjil Integrated Dairy Devlopment ,Mulagunoodu -629 167,K.K.Dt.</b>");

                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l' style='text-align:right'>");

                    sb.Append("PH:248370,248605");

                    sb.Append("</td>");


                    sb.Append("<tr style='border-bottom:0.5px dotted'>");


                    sb.Append("<td>");

                    sb.Append(row["orderDate"].ToString());

                    sb.Append("</td>");

                    sb.Append("<td>");

                    sb.Append("&nbsp;");

                    sb.Append("</td>");

                    sb.Append("<td>");

                    sb.Append(row["agentCode"].ToString());

                    sb.Append("</td>");

                    sb.Append("<td>");

                    sb.Append(row["agentname"].ToString());

                    sb.Append("</td>");

                    sb.Append("<td colspan='2'>");
                    sb.Append("Route : " + dpRoute.SelectedItem.Text.ToString());
                    sb.Append("</td>");
                    sb.Append("<td>"); sb.Append("</td>");
                    sb.Append("<td>");

                    sb.Append(row["OrderCode"].ToString());

                    sb.Append("</td>");


                    sb.Append("<div class='col-md-2'>");
                    sb.Append("&nbsp");
                    sb.Append("</div>");
                    sb.Append("</div>");
                    sb.Append("</div>");
                    sb.Append("</tr>");


                    sb.Append("<div class='row'>");

                    DS1 = billdata.GenrateBIllDetailsID(Convert.ToInt32(row["orderID"]));
                    if (!Comman.Comman.IsDataSetEmpty(DS1))
                    {


                        sb.Append("<tr>");
                        // sb.Append("<div class='col-md-12' >");

                        sb.Append("<td>");
                        // sb.Append("<div class='col-md-2'>");
                        sb.Append("&nbsp");
                        //sb.Append("</div>");
                        sb.Append("</td>");

                        sb.Append("<td>");
                        // sb.Append("<div class='col-md-2'>");
                        sb.Append("&nbsp");
                        //sb.Append("</div>");
                        sb.Append("</td>");

                        sb.Append("<td>");
                        //  sb.Append("<div class='col-md-1'>");
                        sb.Append("SrNO");
                        //  sb.Append("</div>");
                        sb.Append("</td>");

                        sb.Append("<td>");
                        //sb.Append("<div class='col-md-3'>");
                        sb.Append("Items");
                        // sb.Append("</div>");
                        sb.Append("</td>");

                        sb.Append("<td>");
                        // sb.Append("<div class='col-md-2'>");
                        sb.Append("&nbsp");
                        //sb.Append("</div>");
                        sb.Append("</td>");

                        sb.Append("<td>");
                        //  sb.Append("<div class='col-md-2'>");
                        sb.Append("Qty");
                        //  sb.Append("</div>");
                        sb.Append("</td>");

                        sb.Append("<td>");
                        // sb.Append("<div class='col-md-2'>");
                        sb.Append("Unit Price");
                        // sb.Append("</div>");
                        sb.Append("</td>");

                        sb.Append("<td>");
                        // sb.Append("<div class='col-md-2'>");
                        sb.Append("Total");
                        // sb.Append("</div>");
                        sb.Append("</div>");
                        sb.Append("<td>");


                        foreach (DataRow row1 in DS1.Tables[0].Rows)
                        {

                            //style='border-bottom:1px solid #000'
                            // sb.Append("<div class='col-md-12'  >");
                            count = count + 1;

                            //sb.Append("<div class='col-md-2'>");
                            // sb.Append(" ");
                            //  sb.Append("</div>");
                            //  sb.Append("<div class='col-md-1'>");

                            sb.Append("<tr>");


                            sb.Append("<td>");
                            sb.Append("&nbsp");
                            sb.Append("</td>");

                            sb.Append("<td>");
                            sb.Append("&nbsp");
                            sb.Append("</td>");

                            sb.Append("<td>");
                            sb.Append(count);
                            sb.Append("</td>");

                            if (count == 1 && row1["itam"].ToString() == "")
                            {
                                sb.Append("<td colspan='2'>");
                                sb.Append("Scheme");
                                sb.Append("</td>");
                            }
                            else
                            {
                                sb.Append("<td colspan='2'>");
                                sb.Append(row1["itam"].ToString());
                                sb.Append("</td>");
                            }


                            if (count == 1 && row1["qty"].ToString() == "0")
                            {
                                sb.Append("<td>");
                                sb.Append("&nbsp;");
                                sb.Append("</td>");

                                sb.Append("<td>");
                                sb.Append("&nbsp;");
                                sb.Append("</td>");
                            }
                            else
                            {
                                sb.Append("<td>");
                                sb.Append(row1["qty"].ToString());
                                qty = qty + Convert.ToDouble(row1["qty"].ToString());
                                sb.Append("</td>");


                                sb.Append("<td>");
                                sb.Append(row1["unitcost"].ToString());
                                sb.Append("</td>");
                            }

                            sb.Append("<td>");
                            sb.Append(row1["total"].ToString());
                            sb.Append("</td>");


                        }

                    }

                    sb.Append("</div>");


                    sb.Append("<tr style='border-bottom:0.5px dotted'>");

                    sb.Append("<td>");
                    sb.Append("S.M ID:" + row["SECode"].ToString());
                    sb.Append("</td>");

                    sb.Append("<td>");
                    sb.Append("&nbsp");
                    sb.Append("</td>");

                    sb.Append("<td>");
                    sb.Append("&nbsp;");
                    sb.Append("</td>");

                    sb.Append("<td colspan='2'>");
                    sb.Append("Receipt<b>");
                    if (row["PaymentMode"].ToString() == "Monthly")
                    {
                        sb.Append("0.00 </b>");
                    }
                    else
                    {
                        //string total = row["totalBill"].ToString();
                        //total = string.Format("{0.00}", total);
                        //sb.Append(total);
                        sb.AppendFormat("<b>" + row["totalBill"].ToString() + "</b>");
                    }
                    sb.Append("</td>");

                    sb.Append("<td>");
                    sb.Append(qty);
                    sb.Append("</td>");

                    sb.Append("<td>");
                    sb.Append("Total");
                    sb.Append("</td>");

                    sb.Append("<td>");
                    sb.AppendFormat("<b>" + row["totalBill"].ToString() + "</b>");
                    sb.Append("</td>");

                    sb.Append("</div>");

                    sb.Append("</tr>");

                    sb.Append("<tr>");
                    sb.Append("<div class='row'>");


                    sb.Append("<td colspan='3'>");
                    sb.Append(row["SEName"].ToString());
                    sb.Append("</td>");


                    sb.Append("<td colspan='2'>");
                    sb.Append(row["SEMobile"].ToString());
                    sb.Append("</td>");

                    sb.Append("<td>");
                    sb.Append("&nbsp");
                    sb.Append("</td>");



                    sb.Append("<td colspan='2' style='text-align:right'>");
                    sb.Append(DateTime.Now.ToString("dd/MM/yyyy hh:mm"));
                    sb.Append("</td>");

                    sb.Append("</div>");
                    sb.Append("</tr>");
                    sb.Append("<hr/>"); sb.Append("<hr/>");


                    // om.orderID,om.orderCode,om.totalBill,
                    //am.agentName,am.agentCode,
                    //em.employeeCode,em.employeeName


                }





                result = sb.ToString();
                genratedBIll.Text = result;
                //Session["ctrl"] = sb.ToString();
                Session["ctrl"] = pnlBill;
                //Response.Redirect("/print.aspx", true);

            }
            else
            {
                result = "Order not FOund";
                genratedBIll.Text = result;

            }


        }
    }
}