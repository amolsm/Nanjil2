using Bussiness;
using DataAccess;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dairy.Tabs.Marketing
{
    public partial class CorrectiveActionOnIssue : System.Web.UI.Page
    {
       public string issue;
        string issuePid;
        int issuePid1 = 0;
        DBCorrectiveActionOnIssue dbCorrectiveActionOnIssue = new DBCorrectiveActionOnIssue();
        CorrectiveActionOnIssuesModel correctiveActionOnIssuesModel = new CorrectiveActionOnIssuesModel();
        CorrectiveActionOnIssuesData correctiveActionOnIssuesData = new CorrectiveActionOnIssuesData();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                txtDateToday.Text = DateTime.Now.ToString("dd.MM.yyy");
                rpBind();
                BindDropDwon();
                btnupdateCorrectiveActiondetail.Visible = false;
                //lblIssueCode.Visible = false;
            }
        }
        protected void btnAddNew_click(object sender, EventArgs e)
        {
            Response.Redirect("CorrectiveActionOnIssue.aspx");
        }
        public void dpIssueCode_Changed(object sender, EventArgs e)
        {
            DataExisCorrectiveAction();
          
        }       
        protected void btnAddCorrectiveAction_click(object sender, EventArgs e)
        {
           
            try
            {
                DataSet DS = new DataSet();
                DS = correctiveActionOnIssuesData.DataExisCorrectiveAction(dpIssueCode.SelectedItem.ToString());

                if (DS.Tables[0].Rows.Count == 0)
                {

                    DataSet DS1 = new DataSet();
                    DS1 = correctiveActionOnIssuesData.GetIssueRegisteredDate(dpIssueCode.SelectedItem.ToString());

                    issue = string.IsNullOrEmpty(DS1.Tables[0].Rows[0]["Issues"].ToString()) ? string.Empty : DS1.Tables[0].Rows[0]["Issues"].ToString();
                    issuePid = string.IsNullOrEmpty(DS1.Tables[0].Rows[0]["IssueID"].ToString()) ? string.Empty : DS1.Tables[0].Rows[0]["IssueID"].ToString();
                    issuePid1 = Convert.ToInt32(issuePid);
                }
            }
            catch (Exception r) {
                throw r;
            }
                    correctiveActionOnIssuesModel.id = 0;

            correctiveActionOnIssuesModel._dateToday = txtDateToday.Text;
            correctiveActionOnIssuesModel._issue = issue;
            correctiveActionOnIssuesModel._Action = txtAction.Text;
            correctiveActionOnIssuesModel._ActionToBeTakenDate = txtActionTakingDate.Text;
            correctiveActionOnIssuesModel._ActionAdvisedBy = dpActionAdvisedBy.SelectedItem.ToString();
            correctiveActionOnIssuesModel._ActionTakenBy = dpActionTakenBy.SelectedItem.Value.ToString();
            correctiveActionOnIssuesModel._FeedBackAfterAction = dpFeedbackAfterTakenAction.SelectedItem.Value.ToString();
            correctiveActionOnIssuesModel._issueRegisteredDate = txtIssueRegisteredDate.Text;
            correctiveActionOnIssuesModel._issueCode = dpIssueCode.SelectedItem.ToString();

            correctiveActionOnIssuesModel._issuePID = issuePid1;

            correctiveActionOnIssuesModel.flag = "Insert";
            int Result = 0;

            Result = correctiveActionOnIssuesData.InsertCorrectiveActionOnIssues(correctiveActionOnIssuesModel);


            if (Result > 0)
            {
                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "CorrectiveActions Registered  Successfully";              
                rpBind();
                btnupdateCorrectiveActiondetail.Visible = false;
                btnAddCorrectiveAction.Visible = true;
                pnlError.Update();
                upMain.Update();
                uprouteList.Update();
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
        public void BindDropDwon()
        {
            DataSet DS = new DataSet();
          DS= correctiveActionOnIssuesData.GetIssuesPendingDp();
            dpIssueCode.DataSource = DS;         
            dpIssueCode.DataBind();
            dpIssueCode.Items.Insert(0, new ListItem("---Select Issues---", ""));
        }
      
        public void btnupdateCorrectiveActiondetail_click(object sender, EventArgs e)
        {
            string issue=null;

        

                DataSet DS1 = new DataSet();
                DS1 = correctiveActionOnIssuesData.GetIssueRegisteredDate(dpIssueCode.SelectedItem.ToString());

                issue = string.IsNullOrEmpty(DS1.Tables[0].Rows[0]["Issues"].ToString()) ? string.Empty : DS1.Tables[0].Rows[0]["Issues"].ToString();

            issuePid = string.IsNullOrEmpty(DS1.Tables[0].Rows[0]["IssueID"].ToString()) ? string.Empty : DS1.Tables[0].Rows[0]["IssueID"].ToString();
            issuePid1 = Convert.ToInt32(issuePid);


            correctiveActionOnIssuesModel.id = string.IsNullOrEmpty(hCorrectiveActionId.Value) ? 0 : Convert.ToInt32(hCorrectiveActionId.Value);
            correctiveActionOnIssuesModel._dateToday = txtDateToday.Text;
            correctiveActionOnIssuesModel._issue = issue;
            correctiveActionOnIssuesModel._Action = txtAction.Text;
            correctiveActionOnIssuesModel._ActionToBeTakenDate = txtActionTakingDate.Text;
            correctiveActionOnIssuesModel._ActionAdvisedBy = dpActionAdvisedBy.SelectedItem.Value.ToString();
            correctiveActionOnIssuesModel._ActionTakenBy = dpActionTakenBy.SelectedItem.Value.ToString();
            correctiveActionOnIssuesModel._FeedBackAfterAction = dpFeedbackAfterTakenAction.SelectedItem.Value.ToString();
            correctiveActionOnIssuesModel._issueRegisteredDate = txtIssueRegisteredDate.Text;
            correctiveActionOnIssuesModel._issueCode = dpIssueCode.SelectedItem.ToString();
            correctiveActionOnIssuesModel._issuePID = issuePid1;
           // correctiveActionOnIssuesModel._issuePID = issuePid1;

            correctiveActionOnIssuesModel.flag = "Update";
            if (correctiveActionOnIssuesData.UpdateCorrectiveAction(correctiveActionOnIssuesModel))
            {
                lblHeaderTab.Text = "Updated Issue Details";
                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = " Updated  Successfully";               
                rpBind();
                pnlError.Update();
                btnAddCorrectiveAction.Visible = true;
                btnupdateCorrectiveActiondetail.Visible = false;
                upMain.Update();
                uprouteList.Update();
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
        public void rpBind()
        {
            DataSet DS = new DataSet();
            DS = dbCorrectiveActionOnIssue.GetCorrectiveActionInRp();
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                rp.DataSource = DS;
                rp.DataBind();
            }
        }
        protected void rp_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            divDanger.Visible = false;
            divwarning.Visible = false;
            divSusccess.Visible = false;
            pnlError.Update();
            int Id = 0;

            Id = Convert.ToInt32(e.CommandArgument);
            switch (e.CommandName)
            {
                case ("Edit"):
                    {
                        lblHeaderTab.Text = "Edit Corrective Action Details";
                        hCorrectiveActionId.Value = Id.ToString();
                        Id = Convert.ToInt32(hCorrectiveActionId.Value);
                        GetCorrectiveActiondetailsbyID(Id);
                        rpBind();
                        btnAddCorrectiveAction.Visible = false;
                        btnupdateCorrectiveActiondetail.Visible = true;
                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }


            }
        }
        protected void DataExisCorrectiveAction()
        {

            try
            {
                DataSet DS = new DataSet();
                DS = correctiveActionOnIssuesData.DataExisCorrectiveAction(dpIssueCode.SelectedItem.ToString());

                if (DS.Tables[0].Rows.Count == 0)
                {

                    DataSet DS1 = new DataSet();
                    DS1 = correctiveActionOnIssuesData.GetIssueRegisteredDate(dpIssueCode.SelectedItem.ToString());
                    txtIssueRegisteredDate.Text = string.IsNullOrEmpty(DS1.Tables[0].Rows[0]["IssueDateTime"].ToString()) ? string.Empty : DS1.Tables[0].Rows[0]["IssueDateTime"].ToString();
                    divDanger.Visible = false;
                    divwarning.Visible = false;
                    divSusccess.Visible = false;
                    pnlError.Update();
                }
                else
                {
                    divDanger.Visible = false;
                    divwarning.Visible = true;
                    divSusccess.Visible = false;
                    lblwarning.Text = "Already Corrective Action taken on this Issue";
                    pnlError.Update();
                    //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Already Corrective Action taken on this Issue')", true);

                }
            }
            catch (Exception i)
            { throw i; }
        }
        protected void GetCorrectiveActiondetailsbyID(int Id)
        {
            try
            {
                DataSet DS = new DataSet();
                DS = correctiveActionOnIssuesData.GetCorrectiveActiondetailsbyID(Id);
                if (!Comman.Comman.IsDataSetEmpty(DS))
                {
                    txtDateToday.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["TodayDate"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["TodayDate"].ToString();
                    //  txtIssueRegisteredDate.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["IssueDateTime"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["IssueDateTime"].ToString();
                    txtIssueRegisteredDate.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["issueRegistedDate"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["issueRegistedDate"].ToString();

                    dpIssueCode.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["IssueCode"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["IssueCode"].ToString();
                     dpActionAdvisedBy.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["ActionAdvisedBy"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["ActionAdvisedBy"].ToString();
                    dpActionTakenBy.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["ActionTakenBy"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["ActionTakenBy"].ToString();
                    dpFeedbackAfterTakenAction.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["FeedBackAfterActionTaken"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["FeedBackAfterActionTaken"].ToString();
                   
                    txtAction.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Action"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Action"].ToString();
                    txtActionTakingDate.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["ActionToBeTakenDate"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["ActionToBeTakenDate"].ToString();
                    
                         }
            }
            catch (Exception i)
            { throw i; }
        }
    }
}
    
