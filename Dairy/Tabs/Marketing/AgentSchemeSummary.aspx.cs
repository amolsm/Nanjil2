using Bussiness;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dairy.Tabs.Marketing
{
    public partial class AgentSchemeSummary : System.Web.UI.Page
    {
        BillData billdata = new BillData();
        DataSet DS = new DataSet();
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
                    dpRoute.Items.Insert(0, new ListItem("--Select  Route  --", "0"));
                }

                DS = BindCommanData.BindCommanDropDwon("AgentID", "AgentCode+' '+AgentName as Name", "AgentMaster", "IsArchive=0 and SchemeAmount!=0.00 and Agensytype='Agency' Order by AgentCode");
                if (!Comman.Comman.IsDataSetEmpty(DS))
                {
                    dpAgent.DataSource = DS;
                    dpAgent.DataBind();
                    dpAgent.Items.Insert(0, new ListItem("--All Agency  --", "0"));
                }

                txtStartDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                txtEndDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));

            }
        }

        protected void btngenrateBill_click(object sender, EventArgs e)
        {



            string result = string.Empty;
            DS = billdata.AgentSchemeSummaryOpeningClosing((Convert.ToDateTime(txtStartDate.Text)).ToString("dd-MM-yyyy"), (Convert.ToDateTime(txtEndDate.Text)).ToString("dd-MM-yyyy"), Convert.ToInt32(dpRoute.SelectedItem.Value), Convert.ToInt32(dpAgent.SelectedItem.Value));
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                StringBuilder sb = new StringBuilder();
                try
                {
                    DS.Tables[1].PrimaryKey = new[] { DS.Tables[1].Columns["AgentCode"] };
                    DS.Tables[1].PrimaryKey = new[] { DS.Tables[1].Columns["AgentName"] };
                    DS.Tables[2].PrimaryKey = new[] { DS.Tables[2].Columns["AgentCode"] };
                    DS.Tables[2].PrimaryKey = new[] { DS.Tables[2].Columns["AgentName"] };
                    DS.Tables[3].PrimaryKey = new[] { DS.Tables[3].Columns["AgentCode"] };
                    DS.Tables[3].PrimaryKey = new[] { DS.Tables[3].Columns["AgentName"] };
                }
                catch (Exception) { }

                try
                {
                    DS.Tables[1].Merge(DS.Tables[2], false, MissingSchemaAction.Add);
                    DS.Tables[1].Merge(DS.Tables[3], false, MissingSchemaAction.Add);
                   
                }
                catch (Exception) { }

                sb.Append("<style type='text / css'>");
                sb.Append(".tg  { border - collapse:collapse; border - spacing:0; border: none; }");
                sb.Append(".tg .tg-yw4l{vertical-align:top}");
                sb.Append(".tg .tg-baqh{text-align:center;vertical-align:top}");
                sb.Append("</style>");
                //sb.Append("<table class='tg style1' style='page-break-inside:avoid; align:center;'>");
                sb.Append("<table class='tg style1'  style=' position:relative;align:center;'>");
                sb.Append("<colgroup>");
                sb.Append("<col style = 'width:80px'>");
                sb.Append("<col style = 'width:100px'>");
                sb.Append("<col style = 'width:160px'>");
                sb.Append("<col style = 'width:100px'>");
                sb.Append("<col style = 'width:120px'>");
                sb.Append("<col style = 'width:120px'>");
                sb.Append("</colgroup>");

                sb.Append("<tr>");
                sb.Append("<th class='tg-yw4l' rowspan='2'>");
                sb.Append("<img src='/Theme/img/logo1.png' class='img-circle' alt='Logo' width='50px' hight='50px'>");
                sb.Append("</th>");

                sb.Append("<th class='tg-baqh' colspan='4' style='text-align:center'>");
                sb.Append("<b>Nanjil Integrated Dairy Development, Mulagumoodu, K.K.Dt.</b>");
                sb.Append("</th>");
                sb.Append("<th class='tg-yw4l' style='text-align:right'>");
                sb.Append("TIN:330761667331<br>");
                sb.Append("</th>");
                sb.Append("</tr>");

                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append("<td class='tg-yw4l' colspan='4' style='text-align:center'>");
                
                sb.Append("<b><u>  Agency Scheme Summary </u> </b><br/>");
                sb.Append("</td>");
                sb.Append("<td class='tg-yw4l' style='text-align:right'>");
                sb.Append("PH:248370,248605");
                sb.Append("</td> </tr>");

                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append("<td colspan='2'>");
                sb.Append(dpRoute.SelectedItem.Text);
                sb.Append("</td>");
                sb.Append("<td colspan='2' style='text-align:right'>");
                sb.Append(Convert.ToDateTime(txtStartDate.Text).ToString("dd-MM-yyyy"));
                sb.Append("</td>");
                sb.Append("<td colspan='2' style='text-align:right'>");
                sb.Append(Convert.ToDateTime(txtEndDate.Text).ToString("dd-MM-yyyy"));
                sb.Append("</td>");
                sb.Append("</tr>");

            
                sb.Append("<tr style='border-bottom:1px solid'>");



                
                sb.Append("<td>");
                sb.Append("&nbsp;");
                sb.Append("</td>");
                sb.Append("<td colspan = '2'>");
                sb.Append("Date");
                sb.Append("</td>");
                sb.Append("<td colspan = '2'>");
                sb.Append("Scheme");
                sb.Append("</td>");
                sb.Append("<td>");
                sb.Append("&nbsp;");
                sb.Append("</td>");
                sb.Append("</tr>");
               


               

                double openingbalance = 0;
                double closingbalance = 0;
              
                foreach (DataRow row in DS.Tables[1].Rows)
                {
                    sb.Append("<tr style='border-bottom:1px solid'><td colspan='6'></td></tr>");
                    sb.Append("<tr style='border-bottom:1px solid'>");

                    sb.Append("<td>");
                    sb.Append("<b>"+row["AgentCode"].ToString()+"</b>");
                    sb.Append("</td>");
                    sb.Append("<td colspan='3'>");
                    sb.Append("<b>" + row["AgentName"].ToString() + "</b>");
                    sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append("Previous Balance");
                    sb.Append("</td>");

                    sb.Append("<td  style='text-align:right'>");
                   
                    
                        double totalschemamt = 0;
                        double openingb = 0;
                        totalschemamt = Convert.ToDouble(row["TotalSchemeAmount"]);
                    try
                    {
                        openingb = Convert.ToDouble(row["OpeningScheme"]);
                    }
                    catch { openingb = 0; }
                        openingbalance = totalschemamt - openingb;
                  
                    sb.Append("<b>" + openingbalance + "</b>");
                    sb.Append("</td>");

                    sb.Append("</tr>");
                    int srno = 0;
                    double totalscheme = 0;
                    foreach (DataRow rowr in DS.Tables[0].Rows)
                    {
                        srno++;
                        if (row["AgentCode"].ToString() == rowr["AgentCode"].ToString())
                        {
                            sb.Append("<tr>");
                            sb.Append("<td>");
                            sb.Append(srno.ToString());
                            sb.Append("</td>");
                            sb.Append("<td colspan = '2'>");
                            sb.Append(rowr["OrderDate"].ToString());
                            sb.Append("</td>");
                            sb.Append("<td colspan = '3'>");
                            double scheme = 0;
                            try { scheme = Convert.ToDouble(rowr["Scheme"]); } catch { scheme = 0; }

                            totalscheme += scheme;
                            sb.Append(scheme.ToString());
                            sb.Append("</td>");
                        
                            sb.Append("</tr>");
                            sb.Append("<tr><td colspan='6'>&nbsp;</td></tr>");
                        }
                    }
                    sb.Append("<tr style='border-bottom:1px dotted'><td colspan='6'></td></tr>");
                    sb.Append("<tr style='border-bottom:1px solid'>");
                    sb.Append("<td>");
                    sb.Append(srno.ToString());
                    sb.Append("</td>");
                    sb.Append("<td colspan = '2'>");
                    sb.Append("Total :");
                    sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append(totalscheme);
                    sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append("Closing Balance");
                    sb.Append("</td>");

                    sb.Append("<td style='text-align:right'>");
                   
                  

                        double closingb = 0;
                        double totalschemamt1 = 0;
                        totalschemamt1 = Convert.ToDouble(row["TotalSchemeAmount"]);
                    try
                    {
                        closingb = Convert.ToDouble(row["ClosingScheme"]);
                    }
                    catch { closingb = 0; }
                    closingbalance = totalschemamt1 - closingb;
                   
                    sb.Append("<b>"+ closingbalance + "</b>");
                 
                    sb.Append("</td>");
                    sb.Append("</tr>");
                    sb.Append("<tr><td colspan='6'>&nbsp;</td></tr>");

                }





                result = sb.ToString();
                genratedBIll.Text = result;
                //Session["ctrl"] = sb.ToString();
                Session["ctrl"] = pnlBill;
                //Response.Redirect("/print.aspx", true);

            }


            else
            {
                result = "Bill not found";
                genratedBIll.Text = result;

            }
        }

        protected void dpRoute_SelectedIndexChanged(object sender, EventArgs e)
        {
            DS = BindCommanData.BindCommanDropDwon("AgentID", "AgentCode+' '+AgentName as Name", "AgentMaster", "IsArchive=0 and Agensytype='Agency'  and RouteId="+dpRoute.SelectedItem.Value+ "Order by AgentCode");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpAgent.DataSource = DS;
                dpAgent.DataBind();
                dpAgent.Items.Insert(0, new ListItem("--All Agency  --", "0"));
            }
            
        }
    }
}