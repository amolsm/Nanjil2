using Bussiness;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using System.Text;

namespace Dairy.Tabs.Procurement
{
    public partial class AddMilkCollectionCenter : System.Web.UI.Page
    {
        DataSet DS = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                BindCollectionCenter();
                BindDropDwon();
                btnAddCollection.Visible = true;
                btnupdateCollection.Visible = false;
                rdNo.Checked = true;
                rdStoreNo.Checked = true;
                rdLABNo.Checked = true;
                rdETPNo.Checked = true;
                rdIBTNo.Checked = true;
                dpState.Text = "TamilNadu";
                dpCountry.Text = "India";
            }
            d1.Visible = false;

        }

        protected void BindDropDwon()
        {
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
            DS = BindCommanData.BindCommanDropDwon("EmployeeID", "EmployeeName as Name", "EmployeeMaster", "EmployeeID is not null");
            dpContactPerson.DataSource = DS;
            dpContactPerson.DataBind();
            dpContactPerson.Items.Insert(0, new ListItem("--Select Contact Person--", "0"));

            //RouteData routeData = new RouteData();
            //DS = BindCommanData.BindCommanDropDwon("RouteID ", "RouteCode +' '+RouteName as Name  ", "Proc_MilkCollectionRoute", "IsActive=1 ");
            //if (!Comman.Comman.IsDataSetEmpty(DS))
            //{
            //    dpRoute.DataSource = DS;
            //    dpRoute.DataBind();
            //    dpRoute.Items.Insert(0, new ListItem("--Select Route  --", "0"));
            //}
        }

        protected void rdYes_CheckedChanged(object sender, EventArgs e)
        {
            d1.Visible = true;
        }

        protected void rdNo_CheckedChanged(object sender, EventArgs e)
        {
            d1.Visible = false;
        }

        protected void btnClick_btnAddCollection(object sender, EventArgs e)
        {
            Model.Procurement p = new Model.Procurement();
            ProcurementData pd = new ProcurementData();
            p.CenterID = 0;
            p.CenterCode = txtCenterCode.Text;
            p.CenterName = txtCenterName.Text;
            //p.RouteID = Convert.ToInt32(dpRoute.SelectedValue);
            p.PhoneNo = txtTelephone.Text;
            p.MobileNo = txtMobile.Text;
            p.EmailID = txtEmail.Text;
            p.Address1 = txtAddress1.Text;
            p.Address2 = txtAddress2.Text;
            p.Address3 = txtAddress3.Text;
            p.City = dpCity.SelectedItem.Text;
            p.District = dpDistrict.SelectedItem.Text;
            p.State = dpState.SelectedItem.Text;
            p.Country = dpCountry.SelectedItem.Text;
            p.ContactPerson = Convert.ToInt32(dpContactPerson.SelectedValue);
            p.BMC = string.IsNullOrEmpty(txtBMC.Text) ? 0 : Convert.ToInt32(txtBMC.Text);////////////////
            p.MilkCan = string.IsNullOrEmpty(txtMilkCan.Text) ? 0 : Convert.ToInt32(txtMilkCan.Text);
            p.Silo = string.IsNullOrEmpty(txtSilo.Text) ? 0 : Convert.ToInt32(txtSilo.Text);
            if (rdETPYes.Checked)
                p.ETP = true;
            else
                p.ETP = false;
            if (rdLABYes.Checked)
                p.LAB = true;
            else
                p.LAB = false;
            if (rdIBTYes.Checked)
                p.IBT = true;
            else
                p.IBT = false;
            if (rdStoreYes.Checked)
                p.Store = true;
            else
                p.Store = false;
            p.CreatedBy = App_code.GlobalInfo.Userid;
            p.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
            p.ModifiedBy = App_code.GlobalInfo.Userid;
            p.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");
            if (rdYes.Checked)
            {
                p.FreezerAvailable = true;
                p.FreezerModel = txtFreezerModel.Text;
                p.Quantity = Convert.ToInt32(txtQuantity.Text);
            }
            if (rdNo.Checked)
            {
                p.FreezerAvailable = false;
                p.FreezerModel = "";
                p.Quantity = 0;
            }
            if (DropDownList1.SelectedValue == "1")
                p.IsActive = true;
            if (DropDownList1.SelectedValue == "2")
                p.IsActive = false;
            p.flag = "Insert";
            int Result = 0;
            Result = pd.InsertMilkCenter(p);
            if (Result > 0)
            {

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Milk Center Add  Successfully";

                ClearTextBox();
                BindCollectionCenter();
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
        protected void btnClick_btnupdateCollection(object sender, EventArgs e)
        {
            Model.Procurement p = new Model.Procurement();
            ProcurementData pd = new ProcurementData();
            p.CenterID = string.IsNullOrEmpty(hfcenterID.Value) ? 0 : Convert.ToInt32(hfcenterID.Value);
            p.CenterCode = txtCenterCode.Text;
            p.CenterName = txtCenterName.Text;
            //p.RouteID = Convert.ToInt32(dpRoute.SelectedValue);
            p.PhoneNo = txtTelephone.Text;
            p.MobileNo = txtMobile.Text;
            p.EmailID = txtEmail.Text;
            p.Address1 = txtAddress1.Text;
            p.Address2 = txtAddress2.Text;
            p.Address3 = txtAddress3.Text;
            p.City = dpCity.SelectedItem.Text;
            p.District = dpDistrict.SelectedItem.Text;
            p.State = dpState.SelectedItem.Text;
            p.Country = dpCountry.SelectedItem.Text;
            p.ContactPerson = Convert.ToInt32(dpContactPerson.SelectedValue);
            p.BMC = Convert.ToInt32(txtBMC.Text);
            p.MilkCan = Convert.ToInt32(txtMilkCan.Text);
            p.Silo = Convert.ToInt32(txtSilo.Text);
            if (rdETPYes.Checked)
                p.ETP = true;
            else
                p.ETP = false;
            if (rdLABYes.Checked)
                p.LAB = true;
            else
                p.LAB = false;
            if (rdIBTYes.Checked)
                p.IBT = true;
            else
                p.IBT = false;
            if (rdStoreYes.Checked)
                p.Store = true;
            else
                p.Store = false;
            p.CreatedBy = App_code.GlobalInfo.Userid;
            p.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
            p.ModifiedBy = App_code.GlobalInfo.Userid;
            p.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");
            if (rdYes.Checked)
            {
                p.FreezerAvailable = true;
                p.FreezerModel = txtFreezerModel.Text;
                p.Quantity = Convert.ToInt32(txtQuantity.Text);
            }
            if (rdNo.Checked)
            {
                p.FreezerAvailable = false;
                p.FreezerModel = "";
                p.Quantity = 0;
            }
            if (DropDownList1.SelectedValue == "1")
                p.IsActive = true;
            if (DropDownList1.SelectedValue == "2")
                p.IsActive = false;
            p.flag = "Update";
            int Result = 0;
            Result = pd.InsertMilkCenter(p);
            if (Result > 0)
            {
                //lbltital.Text = "Add Route";
                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Route Updated  Successfully";
                ClearTextBox();
                BindCollectionCenter();
                pnlError.Update();
                btnAddCollection.Visible = true;
                btnupdateCollection.Visible = false;
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
            txtCenterCode.Text = string.Empty;
            txtCenterName.Text = string.Empty;
            //dpRoute.ClearSelection();
            txtAddress1.Text = string.Empty;
            txtAddress2.Text = string.Empty;
            txtAddress3.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtMobile.Text = string.Empty;
            txtTelephone.Text = string.Empty;
            dpCity.ClearSelection();
            dpDistrict.ClearSelection();
            dpContactPerson.ClearSelection();
            DropDownList1.ClearSelection();
            txtFreezerModel.Text = string.Empty;
            txtQuantity.Text = string.Empty;
            txtSilo.Text = string.Empty;
            txtMilkCan.Text = string.Empty;
            txtBMC.Text = string.Empty;
            rdNo.Checked = true;
            rdStoreNo.Checked = true;
            rdLABNo.Checked = true;
            rdETPNo.Checked = true;
            rdIBTNo.Checked = true;
        }
        public void BindCollectionCenter()
        {

            ProcurementData pd = new ProcurementData();
            DataSet DS = new DataSet();
            StringBuilder sb = new StringBuilder();
            DS = pd.GetAllCenterDetails();
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                if (!string.IsNullOrEmpty(DS.Tables[1].Rows[0]["id"].ToString()))
                {
                    int count = Convert.ToInt32(DS.Tables[1].Rows[0]["id"]);
                    count = count + 1;
                    txtCenterCode.Text = string.Format("C{0:0000}", count);
                    rpCenterList.DataSource = DS;
                    rpCenterList.DataBind();
                }
                else
                {
                    int count = 1;
                    txtCenterCode.Text = string.Format("C{0:0000}", count);
                }
            }
        }

        protected void rpCenterList_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {

            divDanger.Visible = false;
            divwarning.Visible = false;
            divSusccess.Visible = false;
            pnlError.Update();
            int centerID = 0;
            centerID = Convert.ToInt32(e.CommandArgument);
            switch (e.CommandName)
            {
                case ("Edit"):
                    {
                        //lbltital.Text = "Edit Route";
                        hfcenterID.Value = centerID.ToString();
                        centerID = Convert.ToInt32(hfcenterID.Value);
                        //BindRouteList();
                        ClearTextBox();
                        GetRouteDetailsbyID(centerID);
                        btnAddCollection.Visible = false;
                        btnupdateCollection.Visible = true;
                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }
                case ("delete"):
                    {

                        hfcenterID.Value = centerID.ToString();
                        centerID = Convert.ToInt32(hfcenterID.Value);
                        DeleteCenterByCenterID(centerID);
                        BindCollectionCenter();
                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }


            }
        }
        public void GetRouteDetailsbyID(int CenterID)
        {
            DataSet DS = new DataSet();
            ProcurementData pd = new ProcurementData();
            DS = pd.GetCenterDetailsByID(CenterID);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                txtCenterCode.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["CenterCode"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["CenterCode"].ToString();
                txtCenterName.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["CenterName"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["CenterName"].ToString();
                //dpRoute.ClearSelection();
                //if (dpRoute.Items.FindByValue(DS.Tables[0].Rows[0]["RouteID"].ToString()) != null)
                //{
                //    dpRoute.Items.FindByValue(DS.Tables[0].Rows[0]["RouteID"].ToString()).Selected = true;
                //}
                txtAddress1.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Address1"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Address1"].ToString();
                txtAddress2.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Address2"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Address2"].ToString();
                txtAddress3.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Address3"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Address3"].ToString();
                txtMobile.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["MobileNo"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["MobileNo"].ToString();
                txtTelephone.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["PhoneNo"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["PhoneNo"].ToString();
                txtEmail.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Email"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Email"].ToString();
                dpCity.ClearSelection();
                if (dpCity.Items.FindByText(DS.Tables[0].Rows[0]["City"].ToString()) != null)
                {
                    dpCity.Items.FindByText(DS.Tables[0].Rows[0]["City"].ToString()).Selected = true;
                }
                dpDistrict.ClearSelection();
                if (dpDistrict.Items.FindByText(DS.Tables[0].Rows[0]["District"].ToString()) != null)
                {
                    dpDistrict.Items.FindByText(DS.Tables[0].Rows[0]["District"].ToString()).Selected = true;
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
                //dpCity.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["City"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["City"].ToString();
                //dpDistrict.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["District"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["District"].ToString();
                //dpState.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["State"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["State"].ToString();
                //dpCountry.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Country"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Country"].ToString();
                dpContactPerson.ClearSelection();
                if (dpContactPerson.Items.FindByValue(DS.Tables[0].Rows[0]["ContactPerson"].ToString()) != null)
                {
                    dpContactPerson.Items.FindByValue(DS.Tables[0].Rows[0]["ContactPerson"].ToString()).Selected = true;
                }

                if (DS.Tables[0].Rows[0]["FreezerAvailable"].ToString() == "True")
                {
                    rdYes.Checked = true;
                    rdNo.Checked = false;
                    d1.Visible = true;
                    txtFreezerModel.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["FreezerModel"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["FreezerModel"].ToString();
                    txtQuantity.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Quantity"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Quantity"].ToString();
                }
                else if (DS.Tables[0].Rows[0]["FreezerAvailable"].ToString() == "False")
                {
                    rdNo.Checked = true;
                    d1.Visible = false;
                }
                DropDownList1.ClearSelection();
                if (DS.Tables[0].Rows[0]["IsActive"].ToString() == "True")
                {
                    DropDownList1.Items.FindByValue("1").Selected = true;
                }
                else if (DS.Tables[0].Rows[0]["IsActive"].ToString() == "False")
                {
                    DropDownList1.Items.FindByValue("2").Selected = true;
                }

                txtBMC.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["BMC"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["BMC"].ToString();
                txtMilkCan.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["MilkCan"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["MilkCan"].ToString();
                txtSilo.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Silo"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Silo"].ToString();

                if (DS.Tables[0].Rows[0]["IBT"].ToString() == "True")
                {
                    rdIBTYes.Checked = true;
                    rdIBTNo.Checked = false;
                }
                else if (DS.Tables[0].Rows[0]["IBT"].ToString() == "False")
                {
                    rdIBTNo.Checked = true;
                    rdIBTYes.Checked = false;
                }
                if (DS.Tables[0].Rows[0]["ETP"].ToString() == "True")
                {
                    rdETPYes.Checked = true;
                    rdETPNo.Checked = false;
                }
                else if (DS.Tables[0].Rows[0]["ETP"].ToString() == "False")
                {
                    rdETPNo.Checked = true;
                    rdETPYes.Checked = false;
                }
                if (DS.Tables[0].Rows[0]["LAB"].ToString() == "True")
                {
                    rdLABYes.Checked = true;
                    rdLABNo.Checked = false;
                }
                else if (DS.Tables[0].Rows[0]["LAB"].ToString() == "False")
                {
                    rdLABNo.Checked = true;
                    rdLABYes.Checked = false;
                }
                if (DS.Tables[0].Rows[0]["Store"].ToString() == "True")
                {
                    rdStoreYes.Checked = true;
                    rdStoreNo.Checked = false;
                }
                else if (DS.Tables[0].Rows[0]["Store"].ToString() == "False")
                {
                    rdStoreNo.Checked = true;
                    rdStoreYes.Checked = false;
                }
            }
        }
        public void DeleteCenterByCenterID(int CenterID)
        {
            Model.Procurement p = new Model.Procurement();
            ProcurementData pd = new ProcurementData();
            p.CenterID = string.IsNullOrEmpty(hfcenterID.Value) ? 0 : Convert.ToInt32(hfcenterID.Value);
            p.CenterCode = string.Empty;
            p.CenterName = string.Empty;
            //p.RouteID = 0;
            p.PhoneNo = string.Empty;
            p.MobileNo = string.Empty;
            p.EmailID = string.Empty;
            p.Address1 = string.Empty;
            p.Address2 = string.Empty;
            p.Address3 = string.Empty;
            p.City = dpCity.SelectedItem.Text;
            p.District = dpDistrict.SelectedItem.Text;
            p.State = dpState.SelectedItem.Text;
            p.Country = dpCountry.SelectedItem.Text;
            p.ContactPerson = Convert.ToInt32(dpContactPerson.SelectedValue);
            p.BMC = 0;
            p.MilkCan = 0;
            p.Silo = 0;

            p.ETP = false;

            p.ETP = false;

            p.IBT = false;

            p.Store = false;
            p.CreatedBy = App_code.GlobalInfo.Userid;
            p.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
            p.ModifiedBy = App_code.GlobalInfo.Userid;
            p.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");

            p.FreezerAvailable = false;
            p.FreezerModel = "";
            p.Quantity = 0;

            p.IsActive = false;
            p.flag = "Delete";
            int Result = 0;
            Result = pd.InsertMilkCenter(p);
            if (Result > 0)
            {
                //lbltital.Text = "Add Route";
                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Record Deleted  Successfully";
                ClearTextBox();
                BindCollectionCenter();
                pnlError.Update();
                btnAddCollection.Visible = true;
                btnupdateCollection.Visible = false;
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

        protected void txtCenterName_TextChanged(object sender, EventArgs e)
        {
            ProcurementData pd = new ProcurementData();
            DataSet DS = new DataSet();
            DS = pd.GetAllCenterDetails();
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                foreach (DataRow row in DS.Tables[0].Rows)
                {
                    if (row["CenterName"].ToString().Trim() == txtCenterName.Text.ToString().Trim())
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Center Name Already exists')", true);
                        txtCenterName.Text = string.Empty;
                    }
                }
            }
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Tabs/Procurement/AddMilkCollectionCenter.aspx");
        }
    }
}