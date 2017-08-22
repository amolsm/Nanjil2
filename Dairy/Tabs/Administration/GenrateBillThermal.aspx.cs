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
    public partial class GenrateBillThermal : System.Web.UI.Page
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

                DS = BindCommanData.BindCommanDropDwon("EmployeeID", "EmployeeCode+' '+EmployeeName as Name", "employeemaster", "IsArchive=0 and (Designation='Sales Man' or Designation='Driver')");
                if (!Comman.Comman.IsDataSetEmpty(DS))
                {
                    dpAgentSelasEMployee.DataSource = DS;
                    dpAgentSelasEMployee.DataBind();
                    dpAgentSelasEMployee.Items.Insert(0, new ListItem("Agent Sales Person", "0"));


                }
                txtDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
            }
        }
        protected void btngenrateBill_click(object sender, EventArgs e)
        {

            string result = string.Empty;
            billdata.GenrateBillPre((Convert.ToDateTime(txtDate.Text)).ToString("dd-MM-yyyy"), Convert.ToInt32(dpRoute.SelectedItem.Value), Convert.ToInt32(dpAgentSelasEMployee.SelectedItem.Value));
            billdata.GenrateBillPre1((Convert.ToDateTime(txtDate.Text)).ToString("dd-MM-yyyy"), Convert.ToInt32(dpRoute.SelectedItem.Value), Convert.ToInt32(dpAgentSelasEMployee.SelectedItem.Value));
            billdata.GenrateBillPre2((Convert.ToDateTime(txtDate.Text)).ToString("dd-MM-yyyy"), Convert.ToInt32(dpRoute.SelectedItem.Value), Convert.ToInt32(dpAgentSelasEMployee.SelectedItem.Value));

            DS = billdata.GenrateBillByDate((Convert.ToDateTime(txtDate.Text)).ToString("dd-MM-yyyy"), Convert.ToInt32(dpRoute.SelectedItem.Value), Convert.ToInt32(dpAgentSelasEMployee.SelectedItem.Value));
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                if (DS.Tables[2] != null && DS.Tables[2].Rows.Count > 0)
                {
                    //Duplicate Bill
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('One Duplicate Bill Found of " + DS.Tables[2].Rows[0]["AgentCode"].ToString() + " AgentCode')", true);
                    btnPrint.Visible = false;
                }
                else if (DS.Tables[3] != null && DS.Tables[3].Rows.Count > 0)
                {
                    //empty
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage2", "alert('One Empty Bill Found!')", true);
                    btnPrint.Visible = false;
                }
                else if (DS.Tables[4] != null && DS.Tables[5] != null)
                {
                    string tempAgentID = string.Empty;
                    bool temp = false;
                    //one item
                    foreach (DataRow row5 in DS.Tables[4].Rows)
                    {
                        string chk = row5["AgentID"].ToString();
                        foreach (DataRow row6 in DS.Tables[5].Rows)
                        {
                            if (chk == row6["AgentID"].ToString())
                            {
                                tempAgentID = row5["AgentCode"].ToString();
                                temp = true;
                                break;
                            }
                        }
                    }
                    if (temp)
                    {
                        //only scheme
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage3", "alert('One Bill with Only Scheme Found AgentCode:" + tempAgentID + "')", true);
                        btnPrint.Visible = false;
                    }
                    else if (DS.Tables[6] != null && DS.Tables[6].Rows.Count != 0)
                    {
                        //Double Scheme
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage6", "alert('One Double Scheme Found! AgentCode: " + DS.Tables[6].Rows[0]["AgentCode"].ToString() + "')", true);
                        btnPrint.Visible = false;
                    }
                    else
                    {
                        btnPrint.Visible = true;
                    }

                }
                else if (DS.Tables[6] != null && DS.Tables[6].Rows.Count != 0)
                {
                    //Double Scheme
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage4", "alert('One Double Scheme Found! AgentCode: " + DS.Tables[6].Rows[0]["AgentCode"].ToString() + "')", true);
                    btnPrint.Visible = false;
                }
                else
                {
                    btnPrint.Visible = true;
                }

                #region printbill
                StringBuilder sb = new StringBuilder();

                foreach (DataRow row in DS.Tables[0].Rows)
                {

                    int count = 0;
                    double qty = 0;
                    #region sant
                    sb.Append("<style type='text / css'>");
                    sb.Append(".tg  { border - collapse:collapse; border - spacing:0; border: none;  }");
                    sb.Append(".tg .tg-yw4l{vertical-align:top}");
                    sb.Append(".tg .tg-baqh{text-align:center;vertical-align:top}");
                    sb.Append("</style>");
                    sb.Append("<table class='style1' style='page-break-inside:avoid;font-family: sans-serif;padding-right: 10px;align:center;'>");
                    sb.Append("<colgroup>");
                    sb.Append("<col style = 'width:30px'>");
                    sb.Append("<col style = 'width:80px'>");
                    sb.Append("<col style = 'width:20px'>");
                    sb.Append("<col style = 'width:20px'>");
                    sb.Append("<col style = 'width:70px'>");
                    sb.Append("<col style = 'width:100px'>");

                    sb.Append("</colgroup>");

                    sb.Append("<tr>");
                    sb.Append("<th class='tg-yw4l' rowspan='2'>");
                    sb.Append("<img src='/Theme/img/logo1.png' class='img-circle' alt='Logo' width='80px' hight='80px'>");
                    sb.Append("</th>");

                    sb.Append("<th class='tg-baqh' colspan='3' style='text-align:center; font-size: 90%;'>");
                    sb.Append("<u> Cash/Credit Bill </u> <br/>");
                    sb.Append("</th>");

                    sb.Append("<th class='tg-yw4l' colspan='2' style='text-align:right; font-size: 80%;'>");

                    sb.Append("GSTIN:&nbsp;33AAECN2463R1Z2<br>");
                    sb.Append("</th>");
                    sb.Append("</tr>");

                    sb.Append("<tr style='border-bottom:1px solid'>");
                    sb.Append("<td class='tg-yw4l' colspan='5' style='text-align:Left'>");
                    sb.Append("<b>Nanjil Integrated Dairy Development, Mulagumoodu,K.K.Dt. TollFree:18004258370,18004258881</b>");

                    sb.Append("</td>");


                    //sb.Append("<td class='tg-yw4l'  colspan='2' style='text-align:right; font-size: 80%;'>");

                    //sb.Append("PH:248370,248605");

                    //sb.Append("</td>");
                    sb.Append("</tr>");

                    sb.Append("<tr>");


                    sb.Append("<td colspan='3'>");

                    sb.Append(row["orderDate"].ToString());

                    sb.Append("</td>");
                    sb.Append("<td colspan='3' style='text-align:right;'>");

                    sb.Append("<b>" + row["BillNo"].ToString() + "</b>");

                    sb.Append("</td>");


                    sb.Append("</tr>");
                    sb.Append("<tr style='border-bottom:1px solid'>");
                    sb.Append("<td colspan='3'>");

                    if (row["OrderType"].ToString() == "1")
                    {
                        sb.Append(row["agentCode"].ToString());
                        sb.Append("&nbsp;");
                        sb.Append(row["agentname"].ToString());
                    }
                    if (row["OrderType"].ToString() == "2")
                    {
                        sb.Append(row["employeeCode"].ToString());
                        sb.Append("&nbsp;");
                        sb.Append(row["employeeName"].ToString());
                    }


                    sb.Append("<td colspan='3'style='text-align:right' >");

                    //sb.Append(row["routeCode"].ToString());
                    //sb.Append("&nbsp;");
                    sb.Append(row["RouteName"].ToString());
                    sb.Append("</td>");
                    //sb.Append("<td");
                    //sb.Append("&nbsp;");
                    //sb.Append("</td>");




                    sb.Append("</tr>");


                    //sb.Append("<div class='row'>");

                    DS1 = billdata.GenrateBIllDetailsID(Convert.ToInt32(row["orderID"]));
                    if (!Comman.Comman.IsDataSetEmpty(DS1))
                    {


                        sb.Append("<tr>");
                        // sb.Append("<div class='col-md-12' >");



                        //sb.Append("<td>");
                        ////  sb.Append("<div class='col-md-1'>");
                        //sb.Append("SrNO");
                        ////  sb.Append("</div>");
                        //sb.Append("</td>");

                        sb.Append("<td colspan='2'style='text-align:left'>");
                        //sb.Append("<div class='col-md-3'>");
                        sb.Append("Items");
                        // sb.Append("</div>");
                        sb.Append("</td>");



                        sb.Append("<td colspan='2' style='text-align:center'>");
                        //  sb.Append("<div class='col-md-2'>");
                        sb.Append("Qty.");
                        //  sb.Append("</div>");
                        sb.Append("</td>");



                        sb.Append("<td style='text-align:right'>");
                        // sb.Append("<div class='col-md-2'>");
                        sb.Append("Price");
                        // sb.Append("</div>");
                        sb.Append("</td>");

                        sb.Append("<td style='text-align:right'>");
                        sb.Append("Amt");
                        sb.Append("</td> </tr>");

                        //first
                        foreach (DataRow row1 in DS1.Tables[0].Rows)
                        {
                            if (row1["qty"].ToString() != "0")
                            {

                                sb.Append("<tr>");



                                if (row1["total"].ToString() != "0.0000")
                                {
                                    count = count + 1;
                                    sb.Append("<td colspan='2' style='text-align:left; padding-top:5px; font-size:19px' >");
                                    if (row1["itam"].ToString() == "")
                                    {
                                        sb.Append("Scheme");
                                    }
                                    else
                                    {
                                        sb.Append(row1["itam"].ToString());
                                    }
                                    sb.Append("</td>");



                                    if (row1["qty"].ToString() == "0")
                                    {

                                        sb.Append("<td style='text-align:right; padding-top:5px'>");
                                        sb.Append("&nbsp;");

                                        sb.Append("</td>");

                                        sb.Append("<td style='text-align:left; padding-top:5px'>");
                                        sb.Append("&nbsp;");

                                        sb.Append("</td>");

                                        sb.Append("<td style='text-align:right; padding-top:5px'>");
                                        sb.Append("&nbsp;");
                                        sb.Append("</td>");


                                    }
                                    else
                                    {
                                        sb.Append("<td style='text-align:right; padding-top:5px'>");
                                        sb.Append(row1["qty"].ToString());
                                        sb.Append("</td>");
                                        sb.Append("<td style='text-align:left; padding-top:5px'>");
                                        sb.Append(row1["UnitName"].ToString());
                                        sb.Append("</td>");
                                        qty = qty + Convert.ToDouble(row1["qty"].ToString());
                                        sb.Append("<td style='text-align:right; padding-top:5px'>");
                                        sb.Append((Convert.ToDecimal(row1["unitcost"]).ToString("#.00")));
                                        sb.Append("</td>");
                                    }

                                    sb.Append("<td style='text-align:right; padding-top:5px; font-size:19px'>");
                                    sb.Append((Convert.ToDecimal(row1["total"]).ToString("#.00")));
                                    sb.Append("</td>");
                                }
                            }
                        }
                        //second
                        foreach (DataRow row1 in DS1.Tables[0].Rows)
                        {
                            if (row1["qty"].ToString() == "0")
                            {

                                sb.Append("<tr>");



                                if (row1["total"].ToString() != "0.0000")
                                {
                                    count = count + 1;
                                    sb.Append("<td colspan='2' style='text-align:left; padding-top:5px; font-size:19px' >");
                                    if (row1["itam"].ToString() == "")
                                    {
                                        sb.Append("Scheme");
                                    }
                                    else
                                    {
                                        sb.Append(row1["itam"].ToString());
                                    }
                                    sb.Append("</td>");



                                    if (row1["qty"].ToString() == "0")
                                    {

                                        sb.Append("<td style='text-align:right; padding-top:5px'>");
                                        sb.Append("&nbsp;");

                                        sb.Append("</td>");

                                        sb.Append("<td style='text-align:left; padding-top:5px'>");
                                        sb.Append("&nbsp;");

                                        sb.Append("</td>");

                                        sb.Append("<td style='text-align:right; padding-top:5px'>");
                                        sb.Append("&nbsp;");
                                        sb.Append("</td>");


                                    }
                                    else
                                    {
                                        sb.Append("<td style='text-align:right; padding-top:5px'>");
                                        sb.Append(row1["qty"].ToString());
                                        sb.Append("</td>");
                                        sb.Append("<td style='text-align:left; padding-top:5px'>");
                                        sb.Append(row1["UnitName"].ToString());
                                        sb.Append("</td>");
                                        qty = qty + Convert.ToDouble(row1["qty"].ToString());
                                        sb.Append("<td style='text-align:right; padding-top:5px'>");
                                        sb.Append((Convert.ToDecimal(row1["unitcost"]).ToString("#.00")));
                                        sb.Append("</td>");
                                    }

                                    sb.Append("<td style='text-align:right; padding-top:5px; font-size:19px'>");
                                    sb.Append((Convert.ToDecimal(row1["total"]).ToString("#.00")));
                                    sb.Append("</td>");
                                }
                            }
                        }

                    }

                    sb.Append("</tr>");


                    sb.Append("<tr style='border-bottom:1px solid; border-top: 1px solid'>");

                    //sb.Append("<td>");
                    //sb.Append("S.M.ID ");
                    //sb.Append(DS.Tables[1].Rows[0]["employeeCode"]);
                    //sb.Append("</td>");



                    sb.Append("<td colspan='2'>");
                    sb.Append("Receipt  <b> <p style='font-size:20px'>");
                    if (row["PaymentMode"].ToString() == "Monthly")
                    {
                        sb.Append("0.00 </b>");
                    }
                    if (row["OrderType"].ToString() == "2")
                    {
                        sb.Append("0.00 </b>");
                    }
                    if (row["PaymentMode"].ToString() == "Daily")
                    {

                        sb.Append("<b>" + (Convert.ToDecimal(row["totalBill"]).ToString("#.00") + "</b>"));
                    }
                    sb.Append("</p></td>");

                    sb.Append("<td style='text-align:right'>");
                    sb.Append(qty);

                    sb.Append("</td>");
                    sb.Append("<td style='text-align:left'>");
                    sb.Append("&nbsp;");

                    sb.Append("</td>");

                    sb.Append("<td style='text-align:right'>");
                    sb.Append("");
                    sb.Append("</td>");

                    sb.Append("<td style='text-align: right; '>");
                    sb.Append("Total <p style='font-size:20px'><b>" + (Convert.ToDecimal(row["totalBill"]).ToString("#.00") + "</b></p>"));
                    sb.Append("</td>");

                    //sb.Append("</div>");

                    sb.Append("</tr>");

                    sb.Append("<tr>");



                    sb.Append("<td colspan='2'>");
                    sb.Append(DS.Tables[1].Rows[0]["employeeCode"] + " " + DS.Tables[1].Rows[0]["employeeName"]);
                    sb.Append("</td>");


                    sb.Append("<td colspan='2'>");
                    //sb.Append(DS.Tables[1].Rows[0]["mobile"]);
                    sb.Append("&nbsp;");
                    sb.Append("</td>");




                    sb.Append("<td colspan='2' style='text-align:right;font-size: 80%;'>");
                    sb.Append(DateTime.Now.ToString("dd/MM/yyyy hh:mm"));
                    sb.Append("</td>");


                    sb.Append("</tr>");
                    sb.Append("<tr> <td colspan='2'>");
                    sb.Append(DS.Tables[1].Rows[0]["mobile"]);
                    sb.Append("&nbsp;");
                    sb.Append("</td> </tr>");
                    sb.Append("<tr>");
                    sb.Append("<td colspan = '6'style='text-align:center'> ");
                    sb.Append("Thank You..!!");
                    sb.Append("</td>");



                    sb.Append("<tr style='border-top: 1px dotted'>");
                    sb.Append("<td colspan = '6' style='text-align:center'> ");
                    sb.Append("&nbsp;");
                    sb.Append("</td>");
                    sb.Append("</tr >");
                    sb.Append("<tr >");
                    sb.Append("<td colspan = '6' style='text-align:center'> ");
                    sb.Append("&nbsp;");
                    sb.Append("</td>");
                    sb.Append("</tr >");
                    sb.Append("<tr >");
                    sb.Append("<td colspan = '6' style='text-align:center'> ");
                    sb.Append("&nbsp;");
                    sb.Append("</td>");
                    sb.Append("</tr >");

                    sb.Append("<tr style='border-bottom:1px solid;'>");
                    sb.Append("<td colspan = '6' style='text-align:center'> ");
                    sb.Append("&nbsp;");
                    sb.Append("</td>");
                    sb.Append("</tr >");

                    #endregion



                }




                result = sb.ToString();
                genratedBIll.Text = result;
                //Session["ctrl"] = sb.ToString();
                Session["ctrl"] = pnlBill;
                //Response.Redirect("/print.aspx", true);
                #endregion
            }
            else
            {
                result = "Order not FOund";
                genratedBIll.Text = result;

            }


        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {

                DataSet DS3 = new DataSet();
                BillData printbilldata = new BillData();

                DS3 = printbilldata.UpdatePrintedBillByDate((Convert.ToDateTime(txtDate.Text)).ToString("dd-MM-yyyy"), Convert.ToInt32(dpRoute.SelectedItem.Value), Convert.ToInt32(dpAgentSelasEMployee.SelectedItem.Value));
            }
            catch
            {
                txtDate.Focus();
                dpAgentSelasEMployee.Focus();
                dpRoute.Focus();
            }
        }
    }
}