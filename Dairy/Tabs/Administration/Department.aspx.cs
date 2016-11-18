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
    public partial class Department : System.Web.UI.Page
    {
        ProductData productdata;
        Product product;
        DataSet DS;
        protected void Page_Load(object sender, EventArgs e)
        {
            BindTypeInfo();
            btnAddDept.Visible = true;
            btnupdateDept.Visible = false;

        }
        protected void btnClick_btnAddDept(object sender, EventArgs e)
        {

            productdata = new ProductData();
            product = new Product();
            product.DeptId = 0;
            product.DeptName = string.IsNullOrEmpty(txtDeptName.Text.ToString()) ? string.Empty : Convert.ToString(txtDeptName.Text);
            product.DeptHead = string.IsNullOrEmpty(txtDeptHead.Text.ToString()) ? string.Empty : Convert.ToString(txtDeptHead.Text);


            product.Dept_CreatedBy = GlobalInfo.Userid;

            product.Dept_CreatedDate = DateTime.Now.ToString("dd-MM-yyyy");

            product.flag = "Insert";
            int Result = 0;
            Result = productdata.AddDeptInfo(product);
            if (Result > 0)
            {

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Department Add  Successfully";

                ClearTextBox();
                BindTypeInfo();
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
        protected void btnClick_btnupdateDept(object sender, EventArgs e)
        {

            productdata = new ProductData();
            product = new Product();
            product.DeptId = string.IsNullOrEmpty(hfTypeID.Value) ? 0 : Convert.ToInt32(hfTypeID.Value);
            product.DeptName = string.IsNullOrEmpty(txtDeptName.Text.ToString()) ? string.Empty : Convert.ToString(txtDeptName.Text);
            product.DeptHead = string.IsNullOrEmpty(txtDeptHead.Text.ToString()) ? string.Empty : Convert.ToString(txtDeptHead.Text);
            product.Dept_CreatedBy = GlobalInfo.Userid;

            product.Dept_CreatedDate = DateTime.Now.ToString("dd-MM-yyyy");

            product.flag = "Update";
            int Result = 0;
            Result = productdata.AddDeptInfo(product);
            if (Result > 0)
            {

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Department Updated  Successfully";

                ClearTextBox();
                BindTypeInfo();
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
        public void ClearTextBox()
        {
            txtDeptName.Text = string.Empty;
            txtDeptHead.Text = string.Empty;

        }
        protected void rpRouteList_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {

            divDanger.Visible = false;
            divwarning.Visible = false;
            divSusccess.Visible = false;
            pnlError.Update();
            int TypeID = 0;
            TypeID = Convert.ToInt32(e.CommandArgument);
            switch (e.CommandName)
            {
                case ("Edit"):
                    {
                        lblHeaderTab.Text = "Edit Department";
                        hfTypeID.Value = TypeID.ToString();
                        TypeID = Convert.ToInt32(hfTypeID.Value);
                        GetDeptInfobyID(TypeID);
                        btnAddDept.Visible = false;
                        btnupdateDept.Visible = true;
                        BindTypeInfo();
                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }
                case ("delete"):
                    {

                        hfTypeID.Value = TypeID.ToString();
                        TypeID = Convert.ToInt32(hfTypeID.Value);
                        DeleteTypebyID(TypeID);
                        BindTypeInfo();
                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }


            }
        }
        public void GetDeptInfobyID(int DeptId)
        {

            productdata = new ProductData();
            DS = productdata.GetDeptInfobyID(DeptId);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                txtDeptName.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Dept_Name"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Dept_Name"].ToString();
                txtDeptHead.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Dept_Head"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Dept_Head"].ToString();

            }
        }
        public void BindTypeInfo()
        {

            productdata = new ProductData();
            DataSet DS = new DataSet();
            DS = productdata.GetDeptInfo();

            if (!Comman.Comman.IsDataSetEmpty(DS))
            {

                rpTypeMasteInfo.DataSource = DS;
                rpTypeMasteInfo.DataBind();
            }
        }
        public void DeleteTypebyID(int DeptId)
        {

            productdata = new ProductData();
            product = new Product();
            product.DeptId = Convert.ToInt32(DeptId);
            product.DeptName = string.Empty;
            product.DeptHead = string.Empty;
            product.Dept_CreatedBy = GlobalInfo.Userid;

            product.Dept_CreatedDate = DateTime.Now.ToString("dd-MM-yyyy");

            product.flag = "Delete";
            int Result = 0;
            Result = productdata.AddDeptInfo(product);
            if (Result > 0)
            {

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Department Deleted  Successfully";

                ClearTextBox();
                //BindRouteList();
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