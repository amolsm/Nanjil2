using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using Bussiness;
using System.Data;
using Comman;
using System.Text;
using Dairy.App_code;


namespace Dairy.Tabs.Administration
{
    public partial class EmployeeInfo : System.Web.UI.Page
    {
        DataSet DS = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                BindeEmployeeList();
                BindDropDwon();
                btnEmpadd.Visible = true;
                btnEmpUpdate.Visible = false;
                lblTabName.Text = "Add Employee";
                txtEmpCode.Enabled = false;
                txtJoingDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                

            }

        }
        protected void BindDropDwon()
        {
            //RouteData routeData = new RouteData();
            //DataSet DS = new DataSet();
            //DS = routeData.GetAllRouteDetails();
            //dpRoute.DataSource = DS;
            //dpRoute.DataBind();
            //dpRoute.Items.Insert(0, new ListItem("--Select Route  --", "0"));
            DS = new DataSet();
            DS = BindCommanData.BindCommanDropDwonDistinct("LocId", "City as Name", "StateMaster", "LocId is not null");
            dpCity.DataSource = DS;
            dpCity.DataBind();
            dpCity.Items.Insert(0, new ListItem("--Select City--", "0"));

            DS = new DataSet();
            DS = BindCommanData.BindCommanDropDwonDistinct("LocId", "District as Name", "StateMaster", "LocId is not null");
            dpDistrict.DataSource = DS;
            dpDistrict.DataBind();
            dpDistrict.Items.Insert(0, new ListItem("--Select District--", "0"));

            DS = new DataSet();
            DS = BindCommanData.BindCommanDropDwonDistinct("LocId", "State as Name", "StateMaster", "LocId is not null");
            dpState.DataSource = DS;
            dpState.DataBind();
            dpState.Items.Insert(0, new ListItem("--Select State--", "0"));

            DS = new DataSet();
            DS = BindCommanData.BindCommanDropDwonDistinct("LocId", "Country as Name", "StateMaster", "LocId is not null");
            dpCountry.DataSource = DS;
            dpCountry.DataBind();
            dpCountry.Items.Insert(0, new ListItem("--Select Country--", "0"));

            DS = new DataSet();
            DS = BindCommanData.BindCommanDropDwonDistinct("ID", "BankName as Name", "BankDetails", "ID is not null");
            dpBankName.DataSource = DS;
            dpBankName.DataBind();
            dpBankName.Items.Insert(0, new ListItem("--Select Bank Name--", "0"));

            DS = new DataSet();
            DS = BindCommanData.BindCommanDropDwonDistinct("ID", "BranchName as Name", "BankDetails", "ID is not null");
            dpbranchName.DataSource = DS;
            dpbranchName.DataBind();
            dpbranchName.Items.Insert(0, new ListItem("--Select BranchName--", "0"));
            //santosh
            DS = new DataSet();
            DS = BindCommanData.BindCommanDropDwonDistinct("DesigId", "DesigName", "Designation", "DesigId is not null");
            dpdesignation.DataSource = DS;
            dpdesignation.DataBind();
            dpdesignation.Items.Insert(0, new ListItem("--Select Designation--", "0"));//

            DS = new DataSet();
            //DS = BindCommanData.BindCommanDropDwon("DeptId ", "DeptId +' '+Dept_Name as Name  ", "tblDepartment", "DeptId is not null");
            DS = BindCommanData.BindCommanDropDwonDistinct("DeptId", "Dept_Name", "tblDepartment", "DeptId is not null");
            dpDept.DataSource = DS;
            dpDept.DataBind();
            dpDept.Items.Insert(0, new ListItem("--Select Department--", "0"));

        }

        protected void btnClick_btnAddRoute(object sender, EventArgs e)
        {
            int result = 0;
            Employee emp = new Employee();
            EmployeeData empData = new EmployeeData();
            emp.EmployeeID = 0;
            emp.EmployeeCode = txtEmpCode.Text;
            emp.EmployeeName = txtEmpName.Text;
            emp.FatherName = txtFatherName.Text;
            emp.PFNO = txtPFNo.Text;
            emp.DateofJoining = (Convert.ToDateTime(txtJoingDate.Text)).ToString("dd-MM-yyyy");
            if (dpStatus.SelectedItem.Value == "1")
            {
                emp.IsActive = true;
            }
            else if (dpStatus.SelectedItem.Value == "2")
            {
                emp.IsActive = false;
            }

            emp.Address1 = txtAddress1.Text;
            emp.Address2 = txtAddress2.Text;
            emp.Address3 = txtAddress3.Text;
            emp.EmailID = txtEmail.Text;
            emp.MobileNumber = txtMobile.Text;
            emp.ContactNumber = txtTelephone.Text;
            emp.City = dpCity.SelectedItem.Text;
            emp.Districk = dpDistrict.SelectedItem.Text;
            emp.State = dpState.SelectedItem.Text;
            emp.Country = dpCountry.SelectedItem.Text;
            emp.BankName = dpBankName.Text;
            emp.AccounNo = txtAccountNo.Text;
            emp.IFSCCode = dpbranchName.Text;
            emp.ActiveFrom = (Convert.ToDateTime(txtActiveFrom.Text)).ToString("dd-MM-yyyy");
            emp.DateofJoining = (Convert.ToDateTime(txtJoingDate.Text)).ToString("dd-MM-yyyy");
            emp.Department = dpDept.SelectedItem.Text; ;
            emp.Designation = dpdesignation.SelectedItem.Text;
            emp.SuperViser = txtsupervisor.Text;
            emp.RouteID = 1;
            emp.IsArchive = false;
            emp.CreatedBy = GlobalInfo.Userid;
            emp.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
            emp.ModifiedBy = GlobalInfo.Userid;
            emp.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");
            emp.flag = "Insert";
            if (empData.InserEmployee(emp))
            {

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Employee Add  Successfully";
                ClearTextBox();
                BindeEmployeeList();
                pnlError.Update();
                upMain.Update();
                uprouteList.Update();
                
            }
            else
            {
                divDanger.Visible = false;
                divwarning.Visible = true;
                divSusccess.Visible = false;
                lblWarningHead.Text = "   Please Contact to Site Admin";
                lblwarning.Text =   Comman.Comman.msg.ToString();
                pnlError.Update();

            }




        }
        protected void btnClick_btnUpdate(object sender, EventArgs e)
        {

          
            int result = 0;
            Employee emp = new Employee();
            EmployeeData empData = new EmployeeData();
            emp.EmployeeID = Convert.ToInt32(hfrouteID.Value);
            emp.EmployeeCode = txtEmpCode.Text;
            emp.EmployeeName = txtEmpName.Text;
            emp.FatherName = txtFatherName.Text;
            emp.PFNO = txtPFNo.Text;
            emp.DateofJoining = (Convert.ToDateTime(txtJoingDate.Text)).ToString("dd-MM-yyyy");
            if (dpStatus.SelectedItem.Value == "1")
            {
                emp.IsActive = true;
            }
            else if (dpStatus.SelectedItem.Value == "2")
            {
                emp.IsActive = false;
            }

            emp.Address1 = txtAddress1.Text;
            emp.Address2 = txtAddress2.Text;
            emp.Address3 = txtAddress3.Text;
            emp.EmailID = txtEmail.Text;
            emp.MobileNumber = txtMobile.Text;
            emp.ContactNumber = txtTelephone.Text;
            emp.City = dpCity.SelectedItem.Text;
            emp.Districk = dpDistrict.SelectedItem.Text;
            emp.State = dpState.SelectedItem.Text;
            emp.Country = dpCountry.SelectedItem.Text;
            emp.BankName = dpBankName.Text;
            emp.AccounNo = txtAccountNo.Text;
            emp.IFSCCode = dpbranchName.Text;
            emp.ActiveFrom = (Convert.ToDateTime(txtActiveFrom.Text)).ToString("dd-MM-yyyy");
            emp.DateofJoining = (Convert.ToDateTime(txtJoingDate.Text)).ToString("dd-MM-yyyy");
            emp.Department = dpDept.SelectedItem.Text;
            emp.Designation = dpdesignation.SelectedItem.Text;
            emp.SuperViser = txtsupervisor.Text;
            emp.RouteID = 1;// Convert.ToInt32(dpRoute.SelectedItem.Value);
            emp.IsArchive = false;
            emp.CreatedBy = GlobalInfo.Userid;
            emp.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
            emp.ModifiedBy = GlobalInfo.Userid;
            emp.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");
            emp.flag = "Update";
            if (empData.InserEmployee(emp))
            {

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                btnEmpadd.Visible = true;
                btnEmpUpdate.Visible = false;
                lblSuccess.Text = "Employee Updated  Successfully";
                lblTabName.Text = "Add Employee";
                ClearTextBox();
                BindeEmployeeList();
                pnlError.Update();
                upMain.Update();
                uprouteList.Update();
            }
            else
            {
                divDanger.Visible = false;
                divwarning.Visible = true;
                divSusccess.Visible = false;
                lblWarningHead.Text = "   Please Contact to Site Admin";
                lblwarning.Text = Comman.Comman.msg.ToString(); 
                pnlError.Update();

            }




        }

        public void ClearTextBox()
        {
            txtEmpCode.Text = string.Empty;
            txtEmpName.Text = string.Empty;
            txtFatherName.Text = string.Empty;
            txtPFNo.Text = string.Empty;
            txtJoingDate.Text = string.Empty;
            dpStatus.ClearSelection();

            txtAddress1.Text = string.Empty;
            txtAddress2.Text = string.Empty;
            txtAddress3.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtMobile.Text = string.Empty;

            txtTelephone.Text = string.Empty;
            dpCity.ClearSelection();
            dpDistrict.ClearSelection();
            dpState.ClearSelection();

            dpCountry.ClearSelection();

            dpBankName.ClearSelection();
            txtAccountNo.Text = string.Empty;
            dpbranchName.ClearSelection();
            txtActiveFrom.Text = string.Empty;
            dpDept.ClearSelection();
            dpdesignation.ClearSelection();
            txtsupervisor.Text = string.Empty;
            // dpRoute.ClearSelection(); 

        }
        public void BindeEmployeeList()
        {

            EmployeeData empDate = new EmployeeData();
            DataSet DS = new DataSet();
            StringBuilder sb = new StringBuilder();
            DS = empDate.GetAllEmployeeDetails();
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                int count = Convert.ToInt32(DS.Tables[1].Rows[0]["id"]);
                count = count + 1;
                txtEmpCode.Text = string.Format("E{0:0000}", count++);
                rpRouteList.DataSource = DS;
                rpRouteList.DataBind();
            }
        }

        protected void rpRouteList_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            divDanger.Visible = false;
            divwarning.Visible = false;
            divSusccess.Visible = false;
            pnlError.Update();
            int EmployeeID = 0;
            EmployeeID = Convert.ToInt32(e.CommandArgument);
            switch (e.CommandName)
            {
                case ("Edit"):
                    {

                        hfrouteID.Value = EmployeeID.ToString();
                        EmployeeID = Convert.ToInt32(hfrouteID.Value);

                        BindeEmployeeList();
                        GetEmployeeID(EmployeeID);
                        btnEmpadd.Visible = false;
                        btnEmpUpdate.Visible = true;
                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }
                case ("delete"):
                    {

                        hfrouteID.Value = EmployeeID.ToString();
                        EmployeeID = Convert.ToInt32(hfrouteID.Value);
                        DeleteEmployeeByID(EmployeeID);
                        BindeEmployeeList();
                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }


            }
        }
        public void GetEmployeeID(int employeeID)
        {
            DataSet DS = new DataSet();
            EmployeeData employeeData = new EmployeeData();
            DS = employeeData.GetEmployeeID(employeeID);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                lblHeaderTab.Text = "Edit Agent Info";
                txtEmpCode.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["EmployeeCode"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["EmployeeCode"].ToString();
                txtEmpName.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["EmployeeName"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["EmployeeName"].ToString();
                txtFatherName.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["FatherName"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["FatherName"].ToString();
                txtPFNo.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["PFNO"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["PFNO"].ToString();
                string dateString = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["JoingingDate"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["JoingingDate"].ToString();
             //sky
                DateTime dateString2 = Convert.ToDateTime(dateString, System.Globalization.CultureInfo.GetCultureInfo("ur-PK").DateTimeFormat);
                txtJoingDate.Text = (Convert.ToDateTime(dateString2).ToString("yyyy-MM-dd"));

              
                dpStatus.ClearSelection();
                if (DS.Tables[0].Rows[0]["IsActive"].ToString() == "True")
                {
                    dpStatus.Items.FindByValue("1").Selected = true;
                }
                if (DS.Tables[0].Rows[0]["IsActive"].ToString() == "False")
                {
                    dpStatus.Items.FindByValue("2").Selected = true;
                }

                txtAddress1.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Address1"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Address1"].ToString();
                txtAddress2.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Address2"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Address2"].ToString();
                txtAddress3.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Address3"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Address3"].ToString();
                txtEmail.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Email"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Email"].ToString();
                txtMobile.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["mobile"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["mobile"].ToString();

                txtTelephone.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Phone"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Phone"].ToString();
                dpCity.ClearSelection();
                if (dpCity.Items.FindByText(DS.Tables[0].Rows[0]["City"].ToString()) != null)
                {
                    dpCity.Items.FindByText(DS.Tables[0].Rows[0]["City"].ToString()).Selected = true;
                }
                //dpCity.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["City"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["City"].ToString();
                //dpDistrict.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Districk"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Districk"].ToString();
                dpDistrict.ClearSelection();
                if (dpDistrict.Items.FindByText(DS.Tables[0].Rows[0]["Districk"].ToString()) != null)
                {
                    dpDistrict.Items.FindByText(DS.Tables[0].Rows[0]["Districk"].ToString()).Selected = true;
                }
                dpState.ClearSelection();
                if (dpState.Items.FindByText(DS.Tables[0].Rows[0]["State"].ToString()) != null)
                {
                    dpState.Items.FindByText(DS.Tables[0].Rows[0]["State"].ToString()).Selected = true;
                }

                dpCountry.ClearSelection();
                if (dpCountry.Items.FindByText(DS.Tables[0].Rows[0]["Country"].ToString()) != null)
                {
                    dpCountry.Items.FindByText(DS.Tables[0].Rows[0]["Country"].ToString()).Selected = true;
                }
                //dpBankName.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["BankName"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["BankName"].ToString();
                dpBankName.ClearSelection();
                if (dpBankName.Items.FindByText(DS.Tables[0].Rows[0]["BankName"].ToString()) != null)
                {
                    dpBankName.Items.FindByText(DS.Tables[0].Rows[0]["BankName"].ToString()).Selected = true;
                }
                txtAccountNo.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["AccountNo"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["AccountNo"].ToString();
                dpbranchName.ClearSelection();
                if (dpbranchName.Items.FindByText(DS.Tables[0].Rows[0]["IFCCODE"].ToString()) != null)
                {
                    dpbranchName.Items.FindByText(DS.Tables[0].Rows[0]["IFCCODE"].ToString()).Selected = true;
                }
                //dpIfscCode.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["IFCCODE"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["IFCCODE"].ToString();
                string dateString1 = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["ActiveFrom"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["ActiveFrom"].ToString();
                DateTime dateString3 = Convert.ToDateTime(dateString1, System.Globalization.CultureInfo.GetCultureInfo("ur-PK").DateTimeFormat);
                txtActiveFrom.Text = (Convert.ToDateTime(dateString3).ToString("yyyy-MM-dd"));
                dpDept.ClearSelection();
                if (dpDept.Items.FindByValue(DS.Tables[0].Rows[0]["Department"].ToString()) != null)
                {
                    dpDept.Items.FindByValue(DS.Tables[0].Rows[0]["Department"].ToString()).Selected = true;
                }
                dpdesignation.ClearSelection();
                if (dpdesignation.Items.FindByText(DS.Tables[0].Rows[0]["Designation"].ToString()) != null)
                {
                    dpdesignation.Items.FindByText(DS.Tables[0].Rows[0]["Designation"].ToString()).Selected = true;
                }
                //txtdesignation.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Designation"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Designation"].ToString();
                txtsupervisor.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["SuperViser"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["SuperViser"].ToString();
                //dpRoute.ClearSelection();
                //if (dpRoute.Items.FindByValue( DS.Tables[0].Rows[0]["RouteID"].ToString()) != null)
                //{
                //    dpRoute.Items.FindByValue(DS.Tables[0].Rows[0]["RouteID"].ToString()).Selected = true;
                //}
                lblTabName.Text = "Edit Employee";
                txtEmpCode.Enabled = true;


            }
        }
        public void DeleteEmployeeByID(int EmployeeID)
        {

            int result = 0;
            Employee emp = new Employee();
            EmployeeData empData = new EmployeeData();
            emp.EmployeeID = Convert.ToInt32(hfrouteID.Value);
            emp.EmployeeCode = string.Empty;
            emp.EmployeeName = string.Empty;
            emp.FatherName = string.Empty;
            emp.PFNO = string.Empty;
            emp.DateofJoining = string.Empty;
            emp.IsActive = true;
            emp.Address1 = string.Empty;
            emp.Address2 = string.Empty;
            emp.Address3 = string.Empty;
            emp.EmailID = string.Empty;
            emp.MobileNumber = string.Empty;
            emp.ContactNumber = string.Empty;
            emp.City = string.Empty;
            emp.Districk = string.Empty;
            emp.State = string.Empty;
            emp.Country = string.Empty;
            emp.BankName = string.Empty;
            emp.AccounNo = string.Empty;
            emp.IFSCCode = string.Empty;
            emp.ActiveFrom = string.Empty;
            emp.DateofJoining = string.Empty;
            emp.Department = string.Empty;
            emp.Designation = string.Empty;
            emp.SuperViser = string.Empty;
            emp.RouteID = 1;
            emp.IsArchive = false;
            emp.CreatedBy = GlobalInfo.Userid;
            emp.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
            emp.ModifiedBy = GlobalInfo.Userid;
            emp.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");
            emp.flag = "Delete";
            if (empData.InserEmployee(emp))
            {

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                btnEmpadd.Visible = false;
                btnEmpUpdate.Visible = true;
                lblSuccess.Text = "Employee Delete  Successfully";
                ClearTextBox();
                BindeEmployeeList();
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

      
    }
}