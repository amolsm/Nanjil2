using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Bussiness;
using Model;
using Dairy.App_code;
using System.Text;

namespace Dairy.Tabs.Marketing
{
    public partial class AgencyCloserScreen : System.Web.UI.Page
    {
        Dispatch d;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hftokanno.Value = Comman.Comman.RandomString();
                DataSet DS = new DataSet();

                DS = BindCommanData.BindCommanDropDwon("AgentID", "AgentCode+' '+AgentName as Name", "AgentMaster", "IsArchive=0 and Agensytype='Agency' Order by AgentCode");
                if (!Comman.Comman.IsDataSetEmpty(DS))
                {
                    dpAgent.DataSource = DS;
                    dpAgent.DataBind();
                    dpAgent.Items.Insert(0, new ListItem("--Select Agency  --", "0"));




                }
            }

        }

        protected void btnShowAgentDetails_click(object sender, EventArgs e)
        {


            DataSet ds = new DataSet();
            DispatchData dispatchdata = new DispatchData();
            int AgentID = Convert.ToInt32(dpAgent.SelectedItem.Value);
            string AgentName = dpAgent.SelectedItem.Text;
            ds = dispatchdata.GetAgentInfoForAgentCloser(AgentID);
            if (!Comman.Comman.IsDataSetEmpty(ds))
            {
                rpAgentInfo.DataSource = ds;
                rpAgentInfo.DataBind();
                //rpBrandInfo.Visible = true;
                upMain.Update();
            }
        }

        protected void rpAgentInfo_ItemCommand(object sender, EventArgs e)
        {
        }

        protected void btnSubmit_click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                DataSet ds = new DataSet();
                DispatchData dispatchdata = new DispatchData();
                d = new Dispatch();
                d.AgentID = Convert.ToInt32(dpAgent.SelectedItem.Value);
                d.comment = txtComment.Text;
                d.loanpaid = Chkloanpaid.Checked;
                d.shemepaid = ChkSchemepaid.Checked;
                d.incentivepaid = ChkIncentivepaid.Checked;
                d.depositrefund = ChkDepositRefund.Checked;
                d.freezerreturn = ChkFreezer.Checked;
                d.Chillpad = ChkChillpad.Checked;
                d.Traysreturn = ChkTray.Checked;
                d.IsActive = CheckCloseAgent.Checked;
                d.closedby = GlobalInfo.Userid;
                d.tokanid = hftokanno.Value;
                int Result = 0;

                Result = dispatchdata.AgencyCloserbyAgentID(d);

                if (Result > 0)
                {

                    divDanger.Visible = false;
                    divwarning.Visible = false;
                    divSusccess.Visible = true;
                    lblSuccess.Text = "Agent  Closed  Successfully";

                    BindAgencyCloserScreenInfo();
                    btnPrint.Visible = true;
                    pnlError.Update();
                    upMain.Update();

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

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Tabs/Marketing/AgencyCloserScreen.aspx");
        }

        public void BindAgencyCloserScreenInfo()
        {

           
            DispatchData dispatchdata = new DispatchData();
            d = new Dispatch();
            DataSet DS = new DataSet();
            d.AgentID = Convert.ToInt32(dpAgent.SelectedItem.Value);
            d.closedby = GlobalInfo.Userid;
            d.tokanid = hftokanno.Value;
            DS = dispatchdata.PrintAgencyCloserInfo(d);
            string result = string.Empty;
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
                sb.Append("<col style = 'width:150px'>");
                sb.Append("<col style = 'width:150px'>");
                sb.Append("<col style = 'width:120px'>");
                sb.Append("<col style = 'width:120px'>");
                sb.Append("<col style = 'width:100px'>");

                sb.Append("</colgroup>");

                sb.Append("<tr>");
                sb.Append("<th class='tg-yw4l' rowspan='2'>");
                sb.Append("<img src='/Theme/img/logo1.png' class='img-circle' alt='Logo' width='50px' hight='50px'>");
                sb.Append("</th>");

                sb.Append("<th class='tg-baqh' colspan='2' style='text-align:center; font-size: 80%;'>");
                sb.Append("<u> Agency Closer Bill  </u> <br/>");
                sb.Append("</th>");

                sb.Append("<th class='tg-yw4l' colspan='2' style='text-align:right; font-size: 80%;'>");

                sb.Append("TIN:330761667331<br>");
                sb.Append("</th>");
                sb.Append("</tr>");
                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append("<td class='tg-yw4l' colspan='4' style='text-align:Left'>");
                sb.Append("<b>Nanjil Integrated Dairy Development, Mulagumoodu, K.K.Dt.  Ph:248370, 248605</b>");

                sb.Append("</td>");
                sb.Append("</tr>");

                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append("<td colspan ='2' style='text-align:left; font-size: 80%;'>");
                sb.Append("Agency Closer");
                sb.Append("</td>");

                sb.Append("<td>");
                sb.Append("&nbsp;");
                sb.Append("</td>");
                sb.Append("<td colspan='2' style='text-align:right; font-size: 80%;'>");
                sb.Append("Agency Closer No ");
                sb.Append("</td>");

                sb.Append("</tr>");

                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append("<td colspan ='2' style='text-align:left; font-size: 80%;'>");
                sb.Append(DateTime.Now.ToString());
                sb.Append("</td>");

                sb.Append("<td>");
                sb.Append("&nbsp;");
                sb.Append("</td>");
                sb.Append("<td colspan='2' style='text-align:right; font-size: 80%;'>");
                sb.Append("<b>" + DS.Tables[0].Rows[0]["id"] + "</b>");
                sb.Append("</td>");

                sb.Append("</tr>");

                //sb.Append("<tr style='border-bottom:1px solid'> <td colspan = '5'> &nbsp; </td> </tr>");
                sb.Append("<tr style='border-bottom:0.5px solid'>");




                sb.Append("<td colspan='2'>");

                sb.Append("Route" + "&nbsp;" + "<b>" + DS.Tables[0].Rows[0]["Route"] + "</b>");

                sb.Append("</td>");

                sb.Append("<td colspan='3'>");

                sb.Append("Agent" + "&nbsp;" + "<b>" + DS.Tables[0].Rows[0]["Agent"] + "</b>");

                sb.Append("</td>");
                sb.Append("</tr>");



                sb.Append("<tr>");
                sb.Append("<td style='text-align:left'>");
                sb.Append("<u>"+"Payment Details :"+"</u>");
                sb.Append("</td>");
                sb.Append("</tr>");
                sb.Append("<tr>");
                sb.Append("<td  style='text-align:left'>");
                string loanpaid = string.Empty;
                if (DS.Tables[0].Rows[0]["loanpaid"].ToString() == "True")
                {
                    loanpaid = "Yes";
                }
                else { loanpaid = "No"; }
                sb.Append("Loan Paid :" + "&nbsp;" + "<b>" + loanpaid + "</b>");

                sb.Append("</td>");
                sb.Append("<td colspan='2' style='text-align:left'>");
                string schemepaid = string.Empty;
                if (DS.Tables[0].Rows[0]["schemepaid"].ToString() == "True")
                {
                    schemepaid = "Yes";
                }
                else { schemepaid = "No"; }
                sb.Append("Scheme Paid :" + "&nbsp;" + "<b>" + schemepaid + "</b>");


                sb.Append("</td>");
                sb.Append("<td colspan='2' style='text-align:left'>");
                string incentivepaid = string.Empty;
                if (DS.Tables[0].Rows[0]["incentivepaid"].ToString() == "True")
                {
                    incentivepaid = "Yes";
                }
                else { incentivepaid = "No"; }
                sb.Append("IncentivePaid:" + "&nbsp;" + "<b>" + incentivepaid + "</b>");

                sb.Append("</td>");
                sb.Append("</tr>");
                sb.Append("<tr>");
                sb.Append("<td  style='text-align:left'>");
                string depositrefund = string.Empty;
                if (DS.Tables[0].Rows[0]["depositrefund"].ToString() == "True")
                {
                    depositrefund = "Yes";
                }
                else { depositrefund = "No"; }
                sb.Append("Deposit Refund :" + "&nbsp;" + "<b>" + depositrefund + "</b>");

                sb.Append("</td>");


                sb.Append("</tr>");

                sb.Append("<tr>");
                sb.Append("<td style='text-align:left'>");
                sb.Append("<u>"+"Item Returns :"+"</u>");
                sb.Append("</td>");
                sb.Append("</tr>");
                sb.Append("<tr>");
                sb.Append("<td  style='text-align:left'>");
                string freezerreturn = string.Empty;
                if (DS.Tables[0].Rows[0]["freezerreturn"].ToString() == "True")
                {
                    freezerreturn = "Yes";
                }
                else { freezerreturn = "No"; }
                sb.Append("Freezer:" + "&nbsp;" + "<b>" + freezerreturn + "</b>");

                sb.Append("</td>");
                sb.Append("<td style='text-align:left'>");
                string chillpaid = string.Empty;
                if (DS.Tables[0].Rows[0]["chillpaid"].ToString() == "True")
                {
                    chillpaid = "Yes";
                }
                else { chillpaid = "No"; }
                sb.Append("Chillpad :" + "&nbsp;" + "<b>" + chillpaid + "</b>");


                sb.Append("</td>");
                sb.Append("<td  style='text-align:left'>");
                string trays = string.Empty;
                if (DS.Tables[0].Rows[0]["trays"].ToString() == "True")
                {
                    trays = "Yes";
                }
                else { trays = "No"; }
                sb.Append("Trays:" + "&nbsp;" + "<b>" + trays + "</b>");

                sb.Append("</td>");
               
          
           


                   sb.Append("</tr>");
                    sb.Append("<tr style='border-bottom:0.5px solid'><td colspan='5'></td></tr>");
                    sb.Append("<tr style='border-bottom:0.5px solid'>");
                    sb.Append("<td colspan='5'> ");
                    sb.Append("Approved By: " + "<b>" + DS.Tables[0].Rows[0]["Name"] + "</b>");
                    sb.Append("</td> ");
                    sb.Append("</tr>");


             
                

        

                result = sb.ToString();
                genratedBIll.Text = result;
                //Session["ctrl"] = sb.ToString();
                Session["ctrl"] = pnlBills;
                //Response.Redirect("/print.aspx", true);

            }
            else
            {
                //result = "No Records Found";
                //genratedBIll.Text = result;

            }
        }
    }
}