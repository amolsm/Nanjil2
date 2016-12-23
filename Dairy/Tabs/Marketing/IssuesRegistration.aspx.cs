using Bussiness;
using Dairy.App_code;
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
    public partial class IssuesRegistration : System.Web.UI.Page
    {
        DataSet DS;
        IssueRegistrationModel issueRegistrationModel = new IssueRegistrationModel();
        DBIssueRegistration dbIssueRegistration = new DBIssueRegistration();
        IssuesRegistrationData issueRegistrationData = new IssuesRegistrationData();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                txtIssueEnteredBy.Text = Convert.ToString(GlobalInfo.UserName);

                DateTime dt = DateTime.Now;
                GetIssueIDFromDBIssuesRegistration();
                BindDropDwon();
                rpBind();
                btnupdateIssuedetail.Visible = false;
            }
        }
        protected void rpBind()
        {
            DataSet DS = new DataSet();
            DS = dbIssueRegistration.GetIssueInRp();
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                rp.DataSource = DS;
                rp.DataBind();
            }
        }

        protected void BindDropDwon()
        {
            DS = new DataSet();
            DS.Clear();
            DS = BindCommanData.BindCommanDropDwon("CategoryID", "CategoryName as Name", "Category", "IsActive=1");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpBrand.DataSource = DS;
                dpBrand.DataBind();
                dpBrand.Items.Insert(0, new ListItem("--Select Brand  --", ""));
            }



        }
        protected void GetIssueIDFromDBIssuesRegistration()
        {
            try
            {
                string ID;
                DS = dbIssueRegistration.GetIssueID();
                if (DS.Tables[0].Rows.Count == 0)
                {
                    ID = "0";
                }
                else
                {


                    ID = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["IssueID"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["IssueID"].ToString();
                }

                int id = Convert.ToInt32(ID);
                int idd = id + 1;
                txtIssueID.Text = "IS000" + idd;

            }
            catch (Exception e)
            {
                throw e;
            }

        }
        protected void btnAddIssueRegisteration_click(object sender, EventArgs e)
        {
            issueRegistrationModel._IssueID = 0;
            issueRegistrationModel._IssueDateTime = txtIssueRegisteredDate.Text;

            issueRegistrationModel._IssueArisedBy = dpIssueArisedBy.SelectedItem.ToString();
            issueRegistrationModel._IssueContactNo = txtContactNumber.Text;
            issueRegistrationModel._Issue = txtIssueID.Text + dpIssues.SelectedItem.ToString();
            issueRegistrationModel._IssueType = dpIssueType.SelectedItem.ToString();
            issueRegistrationModel._IssueOnBrand = dpBrand.SelectedItem.Value.ToString();
            issueRegistrationModel._IssueCommodity = dpCommodity.SelectedItem.Value.ToString();
            issueRegistrationModel._DeviatedQty = txtDeviatedQty.Text;
            issueRegistrationModel._IssueVerifiedBy = dpVerifiedBy.SelectedItem.Value.ToString();
            issueRegistrationModel._IssueForwardTo = dpIssueForwaredTo.SelectedItem.Value.ToString();
            issueRegistrationModel._IssueEnteredBy = txtIssueEnteredBy.Text;
            issueRegistrationModel._IssueOnProductType = dpProductType.SelectedItem.Value.ToString();
            issueRegistrationModel._IssueCode = dpIssues.SelectedItem.ToString();
            issueRegistrationModel._code = txtIssueID.Text;

            issueRegistrationModel.flag = "Insert";
            int Result = 0;
            Result = issueRegistrationData.InsertIssue(issueRegistrationModel);
            if (Result > 0)
            {
                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Issue registered  Successfully";
                rpBind();
                btnupdateIssuedetail.Visible = false;
                btnAddIssueRegisteration.Visible = true;
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
        protected void btnAddNew_click(object sender, EventArgs e)
        {
            Response.Redirect("IssuesRegistration.aspx");
        }
        protected void btnupdateIssuedetail_click(object sender, EventArgs e)
        {
            issueRegistrationModel._IssueID = string.IsNullOrEmpty(hIssueId.Value) ? 0 : Convert.ToInt32(hIssueId.Value);

            issueRegistrationModel._IssueDateTime = txtIssueRegisteredDate.Text;
            issueRegistrationModel._IssueArisedBy = dpIssueArisedBy.SelectedItem.ToString();
            issueRegistrationModel._IssueContactNo = txtContactNumber.Text;
            issueRegistrationModel._Issue = txtIssueID.Text + dpIssues.SelectedItem.ToString();
            issueRegistrationModel._IssueType = dpIssueType.SelectedItem.ToString();
            issueRegistrationModel._IssueOnBrand = dpBrand.SelectedItem.Value.ToString();
            issueRegistrationModel._IssueCommodity = dpCommodity.SelectedItem.Value.ToString();
            issueRegistrationModel._DeviatedQty = txtDeviatedQty.Text;
            issueRegistrationModel._IssueVerifiedBy = dpVerifiedBy.SelectedItem.Value.ToString();
            issueRegistrationModel._IssueForwardTo = dpIssueForwaredTo.SelectedItem.Value.ToString();
            issueRegistrationModel._IssueEnteredBy = txtIssueEnteredBy.Text;
            issueRegistrationModel._IssueOnProductType = dpProductType.SelectedItem.Value.ToString();
            issueRegistrationModel._IssueCode = dpIssues.SelectedItem.ToString();
            issueRegistrationModel._code = txtIssueID.Text;

            issueRegistrationModel.flag = "Update";
            if (issueRegistrationData.UpdateIssues(issueRegistrationModel))
            {
                lblHeaderTab.Text = "Updated Issue Details";
                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = " Updated  Successfully";
                rpBind();
                pnlError.Update();
                btnAddIssueRegisteration.Visible = true;
                btnupdateIssuedetail.Visible = false;
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

        protected void dpProductType_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            DS = BindCommanData.BindCommanDropDwon("CommodityID", "CommodityName as Name", "Commodity", "IsArchive=0 and " + "TypeID=" + Convert.ToInt32(dpProductType.SelectedItem.Value));
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpCommodity.DataSource = DS;
                dpCommodity.DataBind();
                dpCommodity.Items.Insert(0, new ListItem("--Select Item  --", ""));
            }
        }
        protected void dpBrand_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            dpProductType.ClearSelection();
            DataSet DS = new DataSet();
            DS = BindCommanData.BindCommanDropDwon("TypeID", "TypeName as Name", "TypeMaster", "IsArchive=1 and " + "CategoryID=" + Convert.ToInt32(dpBrand.SelectedItem.Value));
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpProductType.DataSource = DS;
                dpProductType.DataBind();
                dpProductType.Items.Insert(0, new ListItem("--Select Product Type  --", ""));
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
                        lblHeaderTab.Text = "Edit Location Details";
                        hIssueId.Value = Id.ToString();
                        Id = Convert.ToInt32(hIssueId.Value);
                        GetIssueDetailsbyId(Id);
                        rpBind();
                        btnAddIssueRegisteration.Visible = false;
                        btnupdateIssuedetail.Visible = true;
                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }
            }
        }

        public void GetIssueDetailsbyId(int Id)
        {
            try
            {
                DataSet DS = new DataSet();
                DS = issueRegistrationData.GetIssueDetailsbyId(Id);
                if (!Comman.Comman.IsDataSetEmpty(DS))
                {
                    txtIssueID.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["code"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["code"].ToString();
                    txtIssueRegisteredDate.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["IssueDateTime"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["IssueDateTime"].ToString();
                    dpIssueArisedBy.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["IssueArisedBy"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["IssueArisedBy"].ToString();
                    txtContactNumber.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["ContactNo"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["ContactNo"].ToString();
                    dpIssues.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Issues"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Issues"].ToString();
                    dpIssueType.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["IssueType"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["IssueType"].ToString();
                    dpBrand.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["IssueOnBrand"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["IssueOnBrand"].ToString();
                    dpProductType.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["IssueOnProductType"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["IssueOnProductType"].ToString();
                    dpCommodity.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["IssueCommodity"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["IssueCommodity"].ToString();
                    txtDeviatedQty.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["DeviatedQty"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["DeviatedQty"].ToString();
                    dpVerifiedBy.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["IssueVerifiedBy"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["IssueVerifiedBy"].ToString();
                    dpIssueForwaredTo.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["IssueForwardTo"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["IssueForwardTo"].ToString();
                    txtIssueEnteredBy.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["IssueEnteredBy"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["IssueEnteredBy"].ToString();
                }
            }
            catch (Exception i)
            { throw i; }
        }

    }


}
