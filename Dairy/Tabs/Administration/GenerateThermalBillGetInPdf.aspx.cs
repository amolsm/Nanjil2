using Bussiness;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.IO;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;

namespace Dairy.Tabs.Administration
{
    public partial class GenerateThermalBillGetInPdf : System.Web.UI.Page
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
                    dpRoute.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select Route  --", "0"));
                }

                DS = BindCommanData.BindCommanDropDwon("EmployeeID", "EmployeeCode+' '+EmployeeName as Name", "employeemaster", "IsArchive=0 and (Designation='Sales Man' or Designation='Driver')");
                if (!Comman.Comman.IsDataSetEmpty(DS))
                {
                    dpAgentSelasEMployee.DataSource = DS;
                    dpAgentSelasEMployee.DataBind();
                    dpAgentSelasEMployee.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Agent Sales Person", "0"));


                }
                txtDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
            }
        }

        protected void btngenrateBillinPdf_Click(object sender, EventArgs e)
        {

            string result = string.Empty;
            DS = billdata.GenrateBillByDate((Convert.ToDateTime(txtDate.Text)).ToString("dd-MM-yyyy"), Convert.ToInt32(dpRoute.SelectedItem.Value), Convert.ToInt32(dpAgentSelasEMployee.SelectedItem.Value));
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                if (DS.Tables[2] != null && DS.Tables[2].Rows.Count > 0)
                {
                    //Duplicate Bill
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('One Duplicate Bill Found of " + DS.Tables[2].Rows[0]["AgentCode"].ToString() + " AgentCode')", true);
                   
                }
                else if (DS.Tables[3] != null && DS.Tables[3].Rows.Count > 0)
                {
                    //empty
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage2", "alert('One Empty Bill Found!')", true);
                   
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
                   
                    }
                    else if (DS.Tables[6] != null && DS.Tables[6].Rows.Count != 0)
                    {
                        //Double Scheme
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage6", "alert('One Double Scheme Found! AgentCode: " + DS.Tables[6].Rows[0]["AgentCode"].ToString() + "')", true);
                       
                    }
                    else
                    {
                        
                    }

                }
                else if (DS.Tables[6] != null && DS.Tables[6].Rows.Count != 0)
                {
                    //Double Scheme
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage4", "alert('One Double Scheme Found! AgentCode: " + DS.Tables[6].Rows[0]["AgentCode"].ToString() + "')", true);
                   
                }
                else
                {
                    
                }

                #region printbill
                StringBuilder sb = new StringBuilder();

                foreach (DataRow row in DS.Tables[0].Rows)
                {

                    int count = 0;
                    double qty = 0;
                    #region sant
                    sb.AppendLine("<style type='text / css'>");
                    sb.AppendLine(".tg  { border - collapse:collapse; border - spacing:0; border: none;  }");
                    sb.AppendLine(".tg .tg-yw4l{vertical-align:top}");
                    sb.AppendLine(".tg .tg-baqh{text-align:center;vertical-align:top}");
                    sb.AppendLine("</style>");
                    sb.AppendLine("<table class='style1' style='page-break-inside:avoid;font-family: sans-serif;padding-right: 10px;align:center;'>");
                    sb.AppendLine("<colgroup>");
                    sb.AppendLine("<col style = 'width:30px'/>");
                    sb.AppendLine("<col style = 'width:80px'/>");
                    sb.AppendLine("<col style = 'width:20px'/>");
                    sb.AppendLine("<col style = 'width:20px'/>");
                    sb.AppendLine("<col style = 'width:70px'/>");
                    sb.AppendLine("<col style = 'width:100px'/>");

                    sb.AppendLine("</colgroup>");

                    sb.AppendLine("<tr>");
                    sb.AppendLine("<th class='tg-yw4l' rowspan='2'>");
                    sb.AppendLine("<img src='/Theme/img/logo1.png' class='img-circle' alt='Logo' width='80px' hight='80px'/>");
                    sb.AppendLine("</th>");

                    sb.AppendLine("<th class='tg-baqh' colspan='3' style='text-align:center; font-size: 90%;'>");
                    sb.AppendLine("<u> Cash/Credit Bill </u> <br/>");
                    sb.AppendLine("</th>");

                    sb.AppendLine("<th class='tg-yw4l' colspan='2' style='text-align:right; font-size: 80%;'>");

                    sb.AppendLine("GSTIN:&nbsp;33AAECN2463R1Z2<br/>");
                    sb.AppendLine("</th>");
                    sb.AppendLine("</tr>");

                    sb.AppendLine("<tr style='border-bottom:1px solid'>");
                    sb.AppendLine("<td class='tg-yw4l' colspan='5' style='text-align:Left'>");
                    sb.AppendLine("<b>Nanjil Integrated Dairy Development, Mulagumoodu,K.K.Dt. TollFree:18004258370,18004258881</b>");

                    sb.AppendLine("</td>");


                  
                    sb.AppendLine("</tr>");

                    sb.AppendLine("<tr>");


                    sb.AppendLine("<td colspan='3'>");

                    sb.AppendLine(row["orderDate"].ToString());

                    sb.AppendLine("</td>");
                    sb.AppendLine("<td colspan='3' style='text-align:right;'>");

                    sb.AppendLine("<b>" + row["BillNo"].ToString() + "</b>");

                    sb.AppendLine("</td>");


                    sb.AppendLine("</tr>");
                    sb.AppendLine("<tr style='border-bottom:1px solid'>");
                    sb.AppendLine("<td colspan='3'>");

                    if (row["OrderType"].ToString() == "1")
                    {
                        sb.AppendLine(row["agentCode"].ToString());
                        sb.AppendLine("&nbsp;");
                        sb.AppendLine(row["agentname"].ToString());
                    }
                    if (row["OrderType"].ToString() == "2")
                    {
                        sb.AppendLine(row["employeeCode"].ToString());
                        sb.AppendLine("&nbsp;");
                        sb.AppendLine(row["employeeName"].ToString());
                    }
                    sb.AppendLine("</td>");

                    sb.AppendLine("<td colspan='3'style='text-align:right'>");

                    //sb.AppendLine(row["routeCode"].ToString());
                    //sb.AppendLine("&nbsp;");
                    sb.AppendLine(row["RouteName"].ToString());
                    sb.AppendLine("</td>");
                    //sb.AppendLine("<td");
                    //sb.AppendLine("&nbsp;");
                    //sb.AppendLine("</td>");




                    sb.AppendLine("</tr>");

   

                    DS1 = billdata.GenrateBIllDetailsID(Convert.ToInt32(row["orderID"]));
                    if (!Comman.Comman.IsDataSetEmpty(DS1))
                    {


                        sb.AppendLine("<tr>");
                       

                        sb.AppendLine("<td colspan='2'style='text-align:left'>");
                       
                        sb.AppendLine("Items");
                  
                        sb.AppendLine("</td>");



                        sb.AppendLine("<td colspan='2' style='text-align:center'>");
                      
                        sb.AppendLine("Qty.");
                        sb.AppendLine("</td>");



                        sb.AppendLine("<td style='text-align:right'>");
                       
                        sb.AppendLine("Price");
                      
                        sb.AppendLine("</td>");

                        sb.AppendLine("<td style='text-align:right'>");
                        sb.AppendLine("Amt");
                        sb.AppendLine("</td>");
                        sb.AppendLine("</tr>");

                        //first
                     
                        foreach (DataRow row1 in DS1.Tables[0].Rows)
                        {
                            if (row1["qty"].ToString() != "0")
                            {



                                sb.AppendLine("<tr>");

                                if (row1["total"].ToString() != "0.0000")
                                {
                                    count = count + 1;
                                    sb.AppendLine("<td colspan='2' style='text-align:left; padding-top:5px; font-size:19px' >");
                                    if (row1["itam"].ToString() == "")
                                    {
                                        sb.AppendLine("Scheme");
                                    }
                                    else
                                    {
                                        sb.AppendLine(row1["itam"].ToString());
                                    }
                                    sb.AppendLine("</td>");



                                    if (row1["qty"].ToString() == "0")
                                    {

                                        sb.AppendLine("<td style='text-align:right; padding-top:5px'>");
                                        sb.AppendLine("&nbsp;");

                                        sb.AppendLine("</td>");

                                        sb.AppendLine("<td style='text-align:left; padding-top:5px'>");
                                        sb.AppendLine("&nbsp;");

                                        sb.AppendLine("</td>");

                                        sb.AppendLine("<td style='text-align:right; padding-top:5px'>");
                                        sb.AppendLine("&nbsp;");
                                        sb.AppendLine("</td>");


                                    }
                                    else
                                    {
                                        sb.AppendLine("<td style='text-align:right; padding-top:5px'>");
                                        sb.AppendLine(row1["qty"].ToString());
                                        sb.AppendLine("</td>");
                                        sb.AppendLine("<td style='text-align:left; padding-top:5px'>");
                                        sb.AppendLine(row1["UnitName"].ToString());
                                        sb.AppendLine("</td>");
                                        qty = qty + Convert.ToDouble(row1["qty"].ToString());
                                        sb.AppendLine("<td style='text-align:right; padding-top:5px'>");
                                        sb.AppendLine((Convert.ToDecimal(row1["unitcost"]).ToString("#.00")));
                                        sb.AppendLine("</td>");
                                    }

                                    sb.AppendLine("<td style='text-align:right; padding-top:5px; font-size:19px'>");
                                    sb.AppendLine((Convert.ToDecimal(row1["total"]).ToString("#.00")));
                                    sb.AppendLine("</td>");
                                    sb.AppendLine("</tr>");
                                }
                                
                            }
                        }
                      
                        //second
                     
                        foreach (DataRow row1 in DS1.Tables[0].Rows)
                        {
                            if (row1["qty"].ToString() == "0")
                            {
                                sb.AppendLine("<tr>");




                                if (row1["total"].ToString() != "0.0000")
                                {
                                    count = count + 1;
                                    sb.AppendLine("<td colspan='2' style='text-align:left; padding-top:5px; font-size:19px' >");
                                    if (row1["itam"].ToString() == "")
                                    {
                                        sb.AppendLine("Scheme");
                                    }
                                    else
                                    {
                                        sb.AppendLine(row1["itam"].ToString());
                                    }
                                    sb.AppendLine("</td>");



                                    if (row1["qty"].ToString() == "0")
                                    {

                                        sb.AppendLine("<td style='text-align:right; padding-top:5px'>");
                                        sb.AppendLine("&nbsp;");

                                        sb.AppendLine("</td>");

                                        sb.AppendLine("<td style='text-align:left; padding-top:5px'>");
                                        sb.AppendLine("&nbsp;");

                                        sb.AppendLine("</td>");

                                        sb.AppendLine("<td style='text-align:right; padding-top:5px'>");
                                        sb.AppendLine("&nbsp;");
                                        sb.AppendLine("</td>");


                                    }
                                    else
                                    {
                                        sb.AppendLine("<td style='text-align:right; padding-top:5px'>");
                                        sb.AppendLine(row1["qty"].ToString());
                                        sb.AppendLine("</td>");
                                        sb.AppendLine("<td style='text-align:left; padding-top:5px'>");
                                        sb.AppendLine(row1["UnitName"].ToString());
                                        sb.AppendLine("</td>");
                                        qty = qty + Convert.ToDouble(row1["qty"].ToString());
                                        sb.AppendLine("<td style='text-align:right; padding-top:5px'>");
                                        sb.AppendLine((Convert.ToDecimal(row1["unitcost"]).ToString("#.00")));
                                        sb.AppendLine("</td>");
                                    }

                                    sb.AppendLine("<td style='text-align:right; padding-top:5px; font-size:19px'>");
                                    sb.AppendLine((Convert.ToDecimal(row1["total"]).ToString("#.00")));
                                    sb.AppendLine("</td>");
                                    sb.AppendLine("</tr>");
                                }
                                
                            }
                        }

                    }

                 


                    sb.AppendLine("<tr style='border-bottom:1px solid; border-top: 1px solid'>");

                   



                    sb.AppendLine("<td colspan='2'>");
                    sb.AppendLine("Receipt   <p style='font-size:20px'>");
                    if (row["PaymentMode"].ToString() == "Monthly")
                    {
                        sb.AppendLine("<b>0.00 </b>");
                    }
                    if (row["OrderType"].ToString() == "2")
                    {
                        sb.AppendLine("0.00 </b>");
                    }
                    if (row["PaymentMode"].ToString() == "Daily")
                    {

                        sb.AppendLine("<b>" + (Convert.ToDecimal(row["totalBill"]).ToString("#.00") + "</b>"));
                    }
                    sb.AppendLine("</p></td>");

                    sb.AppendLine("<td style='text-align:right'>");
                    sb.AppendLine(qty.ToString());

                    sb.AppendLine("</td>");
                    sb.AppendLine("<td style='text-align:left'>");
                    sb.AppendLine("&nbsp;");

                    sb.AppendLine("</td>");

                    sb.AppendLine("<td style='text-align:right'>");
                    sb.AppendLine("");
                    sb.AppendLine("</td>");

                    sb.AppendLine("<td style='text-align: right; '>");
                    sb.AppendLine("Total <p style='font-size:20px'><b>" + (Convert.ToDecimal(row["totalBill"]).ToString("#.00") + "</b></p>"));
                    sb.AppendLine("</td>");
                    
                    sb.AppendLine("</tr>");

                    sb.AppendLine("<tr>");



                    sb.AppendLine("<td colspan='2'>");
                    sb.AppendLine(DS.Tables[1].Rows[0]["employeeCode"] + " " + DS.Tables[1].Rows[0]["employeeName"]);
                    sb.AppendLine("</td>");


                    sb.AppendLine("<td colspan='2'>");
                  
                    sb.AppendLine("&nbsp;");
                    sb.AppendLine("</td>");




                    sb.AppendLine("<td colspan='2' style='text-align:right;font-size: 80%;'>");
                    sb.AppendLine(DateTime.Now.ToString("dd/MM/yyyy hh:mm"));
                    sb.AppendLine("</td>");


                    sb.AppendLine("</tr>");
                    sb.AppendLine("<tr> <td colspan='2'>");
                    sb.AppendLine(DS.Tables[1].Rows[0]["mobile"].ToString());
                    sb.AppendLine("&nbsp;");
                    sb.AppendLine("</td> </tr>");
                    sb.AppendLine("<tr>");
                    sb.AppendLine("<td colspan = '6'style='text-align:center'> ");
                    sb.AppendLine("Thank You..!!");
                    sb.AppendLine("</td>");



                    sb.AppendLine("<tr style='border-top: 1px dotted'>");
                    sb.AppendLine("<td colspan = '6' style='text-align:center'> ");
                    sb.AppendLine("&nbsp;");
                    sb.AppendLine("</td>");
                    sb.AppendLine("</tr>");
                    sb.AppendLine("<tr>");
                    sb.AppendLine("<td colspan = '6' style='text-align:center'> ");
                    sb.AppendLine("&nbsp;");
                    sb.AppendLine("</td>");
                    sb.AppendLine("</tr>");
                    sb.AppendLine("<tr>");
                    sb.AppendLine("<td colspan = '6' style='text-align:center'> ");
                    sb.AppendLine("&nbsp;");
                    sb.AppendLine("</td>");
                    sb.AppendLine("</tr>");

                    sb.AppendLine("<tr style='border-bottom:1px solid;'>");
                    sb.AppendLine("<td colspan = '6' style='text-align:center'> ");
                    sb.AppendLine("&nbsp;");
                    sb.AppendLine("</td>");
                    sb.AppendLine("</tr>");

                    #endregion



                }
                result = sb.ToString();
             
                Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                pdfDoc.Open();
                StringReader sr = new StringReader(result);
                XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc,sr);
                pdfDoc.Close();
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=GenerateBill.pdf");
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Write(pdfDoc);
                Response.End();

                #endregion
            }
            else
            {
                result = "Order not FOund";
               
            }

          
        }
         

        }
    }
 
