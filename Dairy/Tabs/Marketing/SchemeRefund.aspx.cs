using Bussiness;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Model;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dairy.App_code;
using System.Text;

namespace Dairy.Tabs.Marketing
{
    public partial class SchemeRefund : System.Web.UI.Page
    {
        DataSet DS = new DataSet();
        Marketings marketing = new Marketings();
        MarketingData marketingdata = new MarketingData();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                hftokanno.Value = Comman.Comman.RandomString();
                lblUser.Text = GlobalInfo.UserName;
                BindDropDown();
               
            }
            txtrefunddate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
        }

        protected void btnAddSchemeRefund_Click(object sender, EventArgs e)
        {
               
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Javascript", "javascript:Confirm(); ", true);
                string confirmValue = Request.Form["confirm_value"];
              start:
                if (confirmValue == "Yes")
                      goto start;
                {
                    
                    marketingdata = new MarketingData();
                    marketing = new Marketings();
                    marketing.RouteID = Convert.ToInt32(dpRoute.SelectedItem.Value);
                    marketing.AgentID = Convert.ToInt32(dpAgent.SelectedItem.Value);
                    marketing.TotalSchemeAmt = Convert.ToDouble(txtTotalSchemeAmt.Text);
                    marketing.SchemerefundAmt = Convert.ToDouble(txtrefundAmt.Text);
                    marketing.balanceAmt = Convert.ToDouble(txtbalanceamt.Text);
                    marketing.requestdate = string.IsNullOrEmpty(txtrequesteddate.Text) ? string.Empty : (Convert.ToDateTime(txtrequesteddate.Text)).ToString("dd-MM-yyyy");
                    marketing.refunddate = string.IsNullOrEmpty(txtrefunddate.Text) ? string.Empty : (Convert.ToDateTime(txtrefunddate.Text)).ToString("dd-MM-yyyy");
                    marketing.CreatedBy = GlobalInfo.Userid;
                    marketing.TokanNo = hftokanno.Value;
                    int Result = 0;

                    Result = marketingdata.AddSchemeRefund(marketing);
                    if (Result > 0)
                    {

                        divDanger.Visible = false;
                        divwarning.Visible = false;
                        divSusccess.Visible = true;
                        lblSuccess.Text = " SchemeRefund Added  Successfully";

                        ClearTextBox();
                        BindSchemeRefundInfo();
                        btnPrint.Visible = true;
                        pnlError.Update();
                        upMain.Update();
                        //uprouteList.Update();
                    }
                    else
                    {
                        divDanger.Visible = false;
                        divwarning.Visible = true;
                        btnPrint.Visible = false;
                        divSusccess.Visible = false;
                        lblwarning.Text = "Please Contact to Site Admin";
                        pnlError.Update();

                    }
                }

            
            
         


            }

     

     

        public void BindDropDown()
        {
            DataSet DS = new DataSet();

            DS = BindCommanData.BindCommanDropDwon("AgentID", "AgentCode+' '+AgentName as Name", "AgentMaster", "IsArchive=0 and Agensytype='Agency' Order by AgentCode");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpAgent.DataSource = DS;
                dpAgent.DataBind();
                dpAgent.Items.Insert(0, new ListItem("--Select Agency  --", "0"));
            }
            DS = BindCommanData.BindCommanDropDwon("RouteID ", "RouteCode +' '+RouteName as Name  ", "routeMaster", "IsArchive=1");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpRoute.DataSource = DS;
                dpRoute.DataBind();
                dpRoute.Items.Insert(0, new ListItem("--All Route  --", "0"));
            }
        }

        protected void dpAgent_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            MarketingData marketingdata = new MarketingData();
            int AgentID = Convert.ToInt32(dpAgent.SelectedItem.Value);
            string AgentName = dpAgent.SelectedItem.Text;
            ds = marketingdata.GetAgentInfoForSchemeRefund(AgentID);
            if (!Comman.Comman.IsDataSetEmpty(ds))
            {
                txtTotalSchemeAmt.Text = string.IsNullOrEmpty(ds.Tables[0].Rows[0]["TotalSchemeAmount"].ToString()) ? string.Empty : ds.Tables[0].Rows[0]["TotalSchemeAmount"].ToString();
              

            }
            else
            {
                
                 ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Scheme Not Available')", true);

                 dpAgent.ClearSelection();
                   
                txtTotalSchemeAmt.Text = string.Empty;
               
                txtbalanceamt.Text = string.Empty;
                txtrefundAmt.Text = string.Empty;
                
            }
        }

        protected void dpRoute_SelectedIndexChanged(object sender, EventArgs e)
        {
            DS = BindCommanData.BindCommanDropDwon("AgentID", "AgentName+' '+AgentCode as Name", "AgentMaster", "RouteID=" + dpRoute.SelectedItem.Value.ToString() + "and IsArchive=0 and Agensytype='Agency'");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpAgent.ClearSelection();
                dpAgent.DataSource = DS;
                dpAgent.DataBind();
                dpAgent.Items.Insert(0, new ListItem("--Select Agent  --", "0"));
            }
            dpRoute.Focus();
        }


        public void BindSchemeRefundInfo()
        {

            marketingdata = new MarketingData();
            marketing=new Marketings();
            DataSet DS = new DataSet();
            marketing.AgentID = Convert.ToInt32(dpAgent.SelectedItem.Value);
            marketing.CreatedBy = GlobalInfo.Userid;
            marketing.TokanNo = hftokanno.Value;
            DS = marketingdata.GetSchemeRefundInfo(marketing);
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
                sb.Append("<u> Scheme Refund </u> <br/>");
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
                    sb.Append("Scheme Refund");
                    sb.Append("</td>");
                    
                    sb.Append("<td>");
                    sb.Append("&nbsp;");
                    sb.Append("</td>");
                    sb.Append("<td colspan='2' style='text-align:right; font-size: 80%;'>");
                    sb.Append("SchemeRefund No " );
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
                    sb.Append("<b>" + DS.Tables[0].Rows[0]["ID"] + "</b>");
                    sb.Append("</td>");

                sb.Append("</tr>");

                //sb.Append("<tr style='border-bottom:1px solid'> <td colspan = '5'> &nbsp; </td> </tr>");
                sb.Append("<tr style='border-bottom:0.5px solid'>");


               

                sb.Append("<td colspan='2'>");

                sb.Append("Route" +"&nbsp;"+ "<b>" + DS.Tables[0].Rows[0]["Route"] + "</b>");

                sb.Append("</td>");

                sb.Append("<td colspan='5'>");

                sb.Append("Agent" +"&nbsp;"+ "<b>" + DS.Tables[0].Rows[0]["Agent"] + "</b>");

                sb.Append("</td>");
                sb.Append("</tr>");
             
                sb.Append("<tr style='border-bottom:0.5px solid'>");
                sb.Append("<td style='text-align:left'>");
                sb.Append("RequestDate");

                sb.Append("</td>");
                sb.Append("<td style='text-align:left'>");
                sb.Append("RefundDate");
              

                sb.Append("</td>");
                sb.Append("<td style='text-align:center'>");

                sb.Append("TotalSchemeAmount");

                sb.Append("</td>");
                sb.Append("<td style='text-align:center'>");

                sb.Append("RefundAmount");

                sb.Append("</td>");
                sb.Append("<td style='text-align:right'>");

                sb.Append("BalanceAmount");

                sb.Append("</td>");

             
                sb.Append("</tr>");
                sb.Append("<tr style='border-bottom:0.5px solid'>");
                foreach (DataRow row in DS.Tables[0].Rows)
                {
                    sb.Append("<td class='tg-yw4l' style='text-align:left'>");
                    sb.Append(row["RequestedDate"].ToString());
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l' style='text-align:left'>");
                    sb.Append(row["RefundDate"].ToString());
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l' style='text-align:center'>");
                    sb.Append(row["TotalSchemeAmt"].ToString());
                    sb.Append("</td>");



                    sb.Append("<td class='tg-yw4l' style='text-align:center'>");
                    sb.Append(row["RefundAmt"].ToString());
                    sb.Append("</td>");


                    sb.Append("<td class='tg-yw4l' style='text-align:right'>");
                    sb.Append(row["Balance"].ToString());
                    sb.Append("</td>");

                    sb.Append("</tr>");
                    sb.Append("<tr style='border-bottom:0.5px solid'>");

                    sb.Append("<td colspan='5'> ");
                    sb.Append("Approved By: " + "<b>" + DS.Tables[0].Rows[0]["Name"] + "</b>");
                    sb.Append("</td> ");
                    sb.Append("</tr>");
                  

                }
                sb.Append("<tr>");
                sb.Append("<td colspan='5' style='text-align:center >");
                sb.Append(" Thanks, Visit Again...!!");
                sb.Append("</td >");
                sb.Append("</tr >");
             
              
               
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
        

        protected void rpSchemeRefundInfo_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

        protected void txtrefundAmt_TextChanged(object sender, EventArgs e)
        {
            double totalscheme=Convert.ToDouble(txtTotalSchemeAmt.Text);
            double totalrefundamt = Convert.ToDouble(txtrefundAmt.Text);
             double balanceamt = totalscheme - totalrefundamt;
             txtbalanceamt.Text = Convert.ToString(balanceamt); 
        }

        public void ClearTextBox()
        {
            txtbalanceamt.Text = string.Empty;
            txtrefundAmt.Text = string.Empty;
            txtrefunddate.Text = string.Empty;
            txtrequesteddate.Text = string.Empty;
            txtTotalSchemeAmt.Text = string.Empty;

        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Tabs/Marketing/SchemeRefund.aspx");
        }

    }
}