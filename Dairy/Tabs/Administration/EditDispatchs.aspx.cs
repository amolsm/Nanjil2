using Bussiness;
using Dairy.App_code;
using DataAccess.Admin;
using Model.Admin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dairy.Tabs.Administration
{
    public partial class EditDispatchs : System.Web.UI.Page
    {
        DataSet DS;
        DispatchVM disp;
        DbDispatch db;
        int id ;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindDropDown();
                Session["ID"] = 0;
            }
        }

        private void BindDropDown()
        {
            DS = new DataSet();
            DS = BindCommanData.BindCommanDropDwon("EmployeeID ", "EmployeeCode +' '+EmployeeName as Name  ", "EmployeeMaster", "IsActive=1 and Designation='Sales Man' ");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpSalesman.DataSource = DS;
                dpSalesman.DataBind();
                dpSalesman.Items.Insert(0, new ListItem("--Select First Salesman--", "0"));

                dpSalesman2.DataSource = DS;
                dpSalesman2.DataBind();
                dpSalesman2.Items.Insert(0, new ListItem("--Select Second Salesman--", "0"));

            }

            DS.Clear();
            DS = BindCommanData.BindCommanDropDwon("EmployeeID", "EmployeeCode +' '+EmployeeName as Name", "EmployeeMaster", "IsActive='True' and Designation = 'Driver'");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpDriver.DataSource = DS;
                dpDriver.DataBind();
                dpDriver.Items.Insert(0, new ListItem("--Select First Driver--", "0"));

                dpDriver2.DataSource = DS;
                dpDriver2.DataBind();
                dpDriver2.Items.Insert(0, new ListItem("--Select Second Driver--", "0"));

            }
            DS.Clear();
            DS = BindCommanData.BindCommanDropDwon("TM_Id ", "VehicleNo as Name  ", "tblTransportMaster", "TM_Id is not null");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpVehicle.DataSource = DS;
                dpVehicle.DataBind();
                dpVehicle.Items.Insert(0, new ListItem("--Select Vehicle No--", "0"));
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            disp = new DispatchVM();
            DS = new DataSet();
            db = new DbDispatch();

            disp.DispatchId = Convert.ToInt32(txtDispatchId.Text);
            disp.Flag = "GetById";

            DS = db.GetDispatchById(disp);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                rpRouteList.DataSource = DS;
                rpRouteList.DataBind();
                uprouteList.Update();

                Session["ID"] = Convert.ToInt32(txtDispatchId.Text);

                btnSubmitOne.Visible = true;

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = false;
               
                pnlError.Update();
            }
            else {
                rpRouteList.DataSource = DS;
                rpRouteList.DataBind();
                uprouteList.Update();
                Session["ID"] = 0;
            }
                

            

        }

        

       

        protected void rpRouteList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            divDanger.Visible = false;
            divwarning.Visible = false;
            divSusccess.Visible = false;
            pnlError.Update();

            disp = new DispatchVM();
            DS = new DataSet();
            db = new DbDispatch();

            int Id = 0;
            Id = Convert.ToInt32(e.CommandArgument);
            disp.DispatchId = Id;
            disp.Flag = "GetByDetailsId";

            DS = db.GetDispatchById(disp);
            hfDetailsId.Value = Id.ToString();
            txtProductName.Text = DS.Tables[0].Rows[0]["ProductName"].ToString();
            txtPrvQuantity.Text = DS.Tables[0].Rows[0]["DD_NewQuantity"].ToString();
            txtNewQuantity.Text = string.Empty;
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalEdit", "$('#myModalEdit').modal();", true);
            
        }

        protected void btnEditSubmit_Click(object sender, EventArgs e)
        {
            disp = new DispatchVM();
            DS = new DataSet();
            db = new DbDispatch();

            disp.Flag = "updateQuantity";
            disp.DispatchId = Convert.ToInt32(hfDetailsId.Value);
            disp.Quantity = string.IsNullOrEmpty(txtNewQuantity.Text) ? 0 : Convert.ToDouble(txtNewQuantity.Text);
            if (disp.Quantity > 0)
            {
                int result = 0;
                result = db.updateDispatch(disp);
                if (result > 0)
                {
                    divDanger.Visible = false;
                    divwarning.Visible = false;
                    divSusccess.Visible = true;
                    lblSuccess.Text = "Quantity Edited Successfully..!";
                    pnlError.Update();

                    txtNewQuantity.Text = string.Empty;

                    disp.DispatchId = Convert.ToInt32(txtDispatchId.Text);
                    disp.Flag = "GetById";

                    DS = db.GetDispatchById(disp);
                    if (!Comman.Comman.IsDataSetEmpty(DS))
                    {
                        rpRouteList.DataSource = DS;
                        rpRouteList.DataBind();
                        uprouteList.Update();

                                               
                    }
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "1", "alert('Please Enter Valid Quantity');", true);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "2", "$('#myModalEdit').modal();", true);
            }
        }

        protected void btnSubmitModal_Click(object sender, EventArgs e)
        {
            disp = new DispatchVM();
            DS = new DataSet();
            db = new DbDispatch();

            //string temp = hfId.Value;
            disp.DispatchId = Convert.ToInt32(Session["ID"]);
            disp.EditedBy = GlobalInfo.Userid;
            disp.Salesman1 = Convert.ToInt32(dpSalesman.SelectedItem.Value);
            disp.Salesman2 = Convert.ToInt32(dpSalesman2.SelectedItem.Value);
            disp.Driver1 = Convert.ToInt32(dpDriver.SelectedItem.Value);
            disp.Driver2 = Convert.ToInt32(dpDriver2.SelectedItem.Value);
            disp.VehicleId = Convert.ToInt32(dpVehicle.SelectedItem.Value);
            disp.Trays = string.IsNullOrEmpty(txtTraysDispached.Text) ? 0 : Convert.ToDouble(txtTraysDispached.Text);
            disp.Cartons = string.IsNullOrEmpty(txtCartons.Text) ? 0 : Convert.ToDouble(txtCartons.Text);
            disp.IceBox = string.IsNullOrEmpty(txtIceBox.Text) ? 0 : Convert.ToDouble(txtIceBox.Text);
            disp.Others = string.IsNullOrEmpty(txtOthers.Text) ? 0 : Convert.ToDouble(txtOthers.Text);
            disp.Flag = "updateDisp";
            if (disp.Salesman1 > 0 && disp.Driver1 >0 && disp.VehicleId > 0 && disp.Trays>=0 && disp.Cartons>=0 && disp.IceBox >=0 && disp.Others >=0)
            {
                int result = 0;
                result = db.updateDispatch(disp);
                if (result > 0)
                {
                    divDanger.Visible = false;
                    divwarning.Visible = false;
                    divSusccess.Visible = true;
                    lblSuccess.Text = "Dispatch Edited Successfully..!";
                    pnlError.Update();

                    txtNewQuantity.Text = string.Empty;
                    btnSubmitOne.Visible = false;
                    uprouteList.Update();
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "1", "alert('Please Enter Valid data');", true);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "2", "$('#myModal').modal();", true);
            }
        }

        protected void btnSubmitOne_Click(object sender, EventArgs e)
        {
            disp = new DispatchVM();
            DS = new DataSet();
            db = new DbDispatch();

            //string temp = hfId.Value;
            disp.DispatchId = Convert.ToInt32( Session["ID"]);
            disp.Flag = "GetOtherById";

            DS = db.GetDispatchById(disp);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpSalesman.ClearSelection();
                if (dpSalesman.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["DI_SalesmanFirstID"]).ToString()) != null)
                {
                    dpSalesman.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["DI_SalesmanFirstID"]).ToString()).Selected = true;
                }
                dpSalesman2.ClearSelection();
                if (dpSalesman2.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["DI_SalesmanSecondID"]).ToString()) != null)
                {
                    dpSalesman2.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["DI_SalesmanSecondID"]).ToString()).Selected = true;
                }
                dpDriver.ClearSelection();
                if (dpDriver.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["DI_DriverFirstID"]).ToString()) != null)
                {
                    dpDriver.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["DI_DriverFirstID"]).ToString()).Selected = true;
                }
                dpDriver2.ClearSelection();
                if (dpDriver2.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["DI_DriverSecondID"]).ToString()) != null)
                {
                    dpDriver2.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["DI_DriverSecondID"]).ToString()).Selected = true;
                }
                dpVehicle.ClearSelection();
                if (dpVehicle.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["DI_VehicleID"]).ToString()) != null)
                {
                    dpVehicle.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["DI_VehicleID"]).ToString()).Selected = true;
                }
                txtTraysDispached.Text = DS.Tables[0].Rows[0]["TraysDispached"].ToString();
            txtIceBox.Text = DS.Tables[0].Rows[0]["IceBoxDispached"].ToString();
            txtCartons.Text = DS.Tables[0].Rows[0]["CartonsDispached"].ToString();
                // txtOthers.Text = DS.Tables[0].Rows[0]["OtherDispached"].ToString();
                txtOthers.Text = "10";
               // upModal.Update();
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "10", "showmodal();", true);
            }
        }
    }
}