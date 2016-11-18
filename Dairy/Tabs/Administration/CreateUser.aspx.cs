using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using Bussiness;
using Dairy.App_code;
using System.Data;
namespace Dairy.Authentication
{
    public partial class CreateUser : System.Web.UI.Page
    {
        DataSet DS = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDwon();
                bindUserList();
                BindActiveAndDeactiveCount();
                btnAddRoute.Visible = true;
                btnupdateroute.Visible = false;
            }

        }

        private void BindDropDwon()
        {
            DS = new DataSet();
            DS = BindCommanData.BindCommanDropDwon("EmployeeID", "EmployeeCode+' '+EmployeeName as Name", "EmployeeMaster", "IsArchive=0 order by EmployeeCode");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpEmployee.DataSource = DS;
                dpEmployee.DataBind();
                dpEmployee.Items.Insert(0, new ListItem("--Select Employee  --", "0"));






            }

        }
        protected void BindActiveAndDeactiveCount()
        {

            DS = BindCommanData.GetAllActiveAndDeactiveCount("Userinfo", "Isactive");
            if (DS.Tables[0].Rows.Count != 0)
                lblActiveCount.Text = DS.Tables[0].Rows[0]["Count"].ToString();
            if (DS.Tables[1].Rows.Count != 0)
                lblDeactive.Text = DS.Tables[1].Rows[0]["Count"].ToString();

        }
        public void bindUserList()
        {
            UserData usersData = new UserData();

            DS = usersData.GetAllUsers();
            rpUserList.DataSource = DS;
            rpUserList.DataBind();

        }
        protected void btnaddUser_click(object sender, EventArgs e)
        {
            User users = new User();
            UserData usersData = new UserData();
            users.UserID = 0;
            users.Name = txtName.Text;
            users.UserName = txtEmail.Text;
            users.EmailID = txtEmail.Text;
            if (dpIsActive.SelectedItem.Value == "1")
            {
                users.IsActive = true;
            }
            else if (dpIsActive.SelectedItem.Text == "2")
            {
                users.IsActive = false;
            }
            users.PassWord = txtPassword.Text;
            users.RoleID = dproles.SelectedItem.Text;
            users.privilege = Convert.ToInt16(dpPrivilege.SelectedItem.Value);
            users.CreatedBy = GlobalInfo.Userid;
            users.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
            users.ModifiedBy = GlobalInfo.Userid;
            users.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");
            users.EmployeeId = Convert.ToInt32(dpEmployee.SelectedItem.Value);
            users.flag = "Insert";
            if (usersData.InsertUser(users))
            {
                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "User Created Successfully";
                bindUserList();
                Clear();
                pnlError.Update();
                upMain.Update();
                uprouteList.Update();
             

            }
            else
            {
                divDanger.Visible = false;
                divwarning.Visible = true;
                divSusccess.Visible = false;
                lblwarning.Text = "Something Went Worng try agean";
                pnlError.Update();

            }


        }
        protected void btnUpdateUser_click(object sender, EventArgs e)
        {
            User users = new User();
            UserData usersData = new UserData();
            users.UserID = string.IsNullOrEmpty(hfUserid.Value) ? 0 : Convert.ToInt32(hfUserid.Value);
            users.Name = txtName.Text;
            users.UserName = txtEmail.Text;
            users.EmailID = txtEmail.Text;
            if (dpIsActive.SelectedItem.Value == "1")
            {
                users.IsActive = true;
            }
            else if (dpIsActive.SelectedItem.Text == "2")
            {
                users.IsActive = false;
            }
            users.PassWord = txtPassword.Text;
            users.RoleID = dproles.SelectedItem.Text;
            users.privilege = Convert.ToInt16(dpPrivilege.SelectedItem.Value);
            users.CreatedBy = GlobalInfo.Userid;
            users.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
            users.ModifiedBy = GlobalInfo.Userid;
            users.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");
            users.EmployeeId = Convert.ToInt32(dpEmployee.SelectedItem.Value);
            users.flag = "Update";
            if (usersData.InsertUser(users))
            {
                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "User Updated Successfully";
                btnAddRoute.Visible = true;
                btnupdateroute.Visible = false;
                Clear();
                pnlError.Update();
                bindUserList();
                upMain.Update();
                uprouteList.Update();
            }
            else
            {
                divDanger.Visible = false;
                divwarning.Visible = true;
                divSusccess.Visible = false;
                lblwarning.Text = "Something Went Worng try agean";
                pnlError.Update();

            }


        }
        public void Clear()
        {
            txtName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtConfromPasword.Text = string.Empty;
            dpIsActive.ClearSelection();
            dpPrivilege.ClearSelection();
            dpEmployee.ClearSelection();
            dproles.ClearSelection();
            upMain.Update();
        }
        protected void rpUserList_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            divDanger.Visible = false;
            divwarning.Visible = false;
            divSusccess.Visible = false;
            pnlError.Update();
            int userid = 0;
            userid = Convert.ToInt32(e.CommandArgument);
            switch (e.CommandName)
            {
                case ("Edit"):
                    {
                        lblHeaderTab.Text = "Edit User";
                        hfUserid.Value = userid.ToString();
                        userid = Convert.ToInt32(hfUserid.Value);
                        GetUserDetailsbyID(userid);
                        btnAddRoute.Visible = false;
                        btnupdateroute.Visible = true;
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "opencollapse", ".collapse('show')", true);
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myBox", "<script type='text/javascript'> $('#myBox').removeClass('collapsed-box'); </script>", false);
                        bindUserList();
                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }
                case ("delete"):
                    {

                        hfUserid.Value = userid.ToString();
                        userid = Convert.ToInt32(hfUserid.Value);
                        //   DeleteRoutebyrouteID(routeID);
                        //   BindRouteList();
                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }


            }
        }
        public void GetUserDetailsbyID(int UserID)
        {
            UserData usersData = new UserData();
            DataSet DS = new DataSet();
            DS = usersData.GetuserDetailsByUserid(UserID);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                txtName.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Name"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Name"].ToString();
                txtEmail.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["UserName"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["UserName"].ToString();
                txtPassword.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["PassWord"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["PassWord"].ToString();
                txtConfromPasword.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["PassWord"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["PassWord"].ToString();
                dpIsActive.ClearSelection();
                if (dpIsActive.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["IsActive"]).ToString()) != null)
                {
                    dpIsActive.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["IsActive"]).ToString()).Selected = true;
                }
                dpEmployee.ClearSelection();
                if (!string.IsNullOrEmpty(DS.Tables[0].Rows[0]["EmployeeId"].ToString()))
                {
                    if (dpEmployee.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["EmployeeId"]).ToString()) != null)
                    {
                        dpEmployee.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["EmployeeId"]).ToString()).Selected = true;
                    }
                }
                dproles.ClearSelection();
                if (dproles.Items.FindByText(DS.Tables[0].Rows[0]["RoleName"].ToString()) != null)
                {
                    dproles.Items.FindByText(DS.Tables[0].Rows[0]["RoleName"].ToString()).Selected = true;
                }

                dpPrivilege.ClearSelection();
                if (dproles.Items.FindByValue(DS.Tables[0].Rows[0]["Privilege"].ToString()) != null)
                {
                    dpPrivilege.Items.FindByValue(string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Privilege"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Privilege"].ToString()).Selected = true;
                }


            }
        }
    }
}