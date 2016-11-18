using Bussiness;
using Dairy.App_code;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dairy.Tabs.TransportModule
{
    public partial class VehicleOperations : System.Web.UI.Page
    {
        TransportData transportdata;
        Transports transport;
        DataSet DS;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindVehicleOperationInfo();
                btnAddVehicleOperation.Visible = true;
                btnupdateVehicleOperation.Visible = false;
                BindDropDwon();

           
                txtStartTime.Text = DateTime.Now.ToString("HH:mm");

                txtStartDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }

        }
        public void BindDropDwon()
        {

            DS = BindCommanData.BindCommanDropDwon("TM_Id", "VehicleNo", "tblTransportMaster", "IsActive=1");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpVehicleNo.DataSource = DS;
                dpVehicleNo.DataBind();
                dpVehicleNo.Items.Insert(0, new ListItem("--Select Vehicle Number--", "0"));
            }
            DS = BindCommanData.BindCommanDropDwon("RouteID", "RouteCode +' '+RouteName as Name  ", "RouteMaster", "IsArchive=1  Order by RouteCode");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dproute.DataSource = DS;
                dproute.DataBind();
                dproute.Items.Insert(0, new ListItem("--Select Route Name--", "0"));
            }
            DS = new DataSet();
            DS = BindCommanData.BindCommanDropDwon("EmployeeID", "EmployeeName as Name  ", "EmployeeMaster", "IsActive='True' and Designation = 'Driver'");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpDriver.DataSource = DS;
                dpDriver.DataBind();
                dpDriver.Items.Insert(0, new ListItem("--Select First Driver--", "0"));

                dpDriver2.DataSource = DS;
                dpDriver2.DataBind();
                dpDriver2.Items.Insert(0, new ListItem("--Select Second Driver--", "0"));

            }

            DS = BindCommanData.BindCommanDropDwon("EmployeeID", "EmployeeName as Name  ", "EmployeeMaster", "IsActive='True' and Designation = 'Sales Man'");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpSalesman.DataSource = DS;
                dpSalesman.DataBind();
                dpSalesman.Items.Insert(0, new ListItem("--Select First Salesman--", "0"));

                dpSecondSalesmanId.DataSource = DS;
                dpSecondSalesmanId.DataBind();
                dpSecondSalesmanId.Items.Insert(0, new ListItem("--Select Second Salesman--", "0"));
            }
            DS = BindCommanData.BindCommanDropDwon("ID ", "CONFIGVALUE  as Name  ", "CONFIGMASTER", "ISACTIVE=1 and CONFIGNAME='Transport' and CONFIGKEY='VehicleType'");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpOperations.DataSource = DS;
                dpOperations.DataBind();
                dpOperations.Items.Insert(0, new ListItem("--Select Operations Type  --", "0"));
            }
         
           

        }
        protected void btnClick_btnAddVehicleOperation(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {

                transportdata = new TransportData();
                transport = new Transports();
                transport.VOp = 0;
                transport.TM_Id = Convert.ToInt32(dpVehicleNo.SelectedItem.Value);

                transport.StartDate = string.IsNullOrEmpty(txtStartDate.Text) ? string.Empty : (Convert.ToDateTime(txtStartDate.Text)).ToString("dd-MM-yyyy");
             
                transport.StartTime = string.IsNullOrEmpty(txtStartTime.Text) ? string.Empty : (Convert.ToDateTime(txtStartTime.Text)).ToString("HH:mm");


              


                transport.RouteID = Convert.ToInt32(dproute.SelectedItem.Value);
                transport.StartKm = string.IsNullOrEmpty(txtStartKm.Text) ? 0 : Convert.ToDecimal(txtStartKm.Text);
               
                transport.FirstDriver = string.IsNullOrEmpty(dpDriver.SelectedItem.Value) ? 0 : Convert.ToInt32(dpDriver.SelectedItem.Value);
                transport.SecondDriver = Convert.ToInt32(dpDriver2.SelectedItem.Value);

                transport.operationtype = Convert.ToInt32(dpOperations.SelectedItem.Value);
                transport.bata = string.IsNullOrEmpty(txtBata.Text) ? 0 : Convert.ToDecimal(txtBata.Text);
                transport.salesbata = string.IsNullOrEmpty(txtSalesBata.Text) ? 0 : Convert.ToDecimal(txtSalesBata.Text);
                transport.CreatedBy = GlobalInfo.Userid;
             
                transport.IsActive = true;
             
                transport.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
                transport.ModifiedBy = GlobalInfo.Userid;
                transport.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");
                transport.SalesmanId = Convert.ToInt32(dpSalesman.SelectedItem.Value);
                transport.SecondSalesmanId = Convert.ToInt32(dpSecondSalesmanId.SelectedItem.Value);
             
                transport.flag = "Insert";
                int Result = 0;

                Result = transportdata.AddVehicleOperationInfo(transport);
                if (Result > 0)
                {

                    divDanger.Visible = false;
                    divwarning.Visible = false;
                    divSusccess.Visible = true;
                    lblSuccess.Text = "Vehicle Out Operation Added  Successfully";

                    ClearTextBox();
                    BindVehicleOperationInfo();
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
        protected void btnClick_btnupdateVehicleOperation(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {

                transportdata = new TransportData();
                transport = new Transports();
                transport.VOp = string.IsNullOrEmpty(hfvoperationId.Value) ? 0 : Convert.ToInt32(hfvoperationId.Value);
                transport.TM_Id = Convert.ToInt32(dpVehicleNo.SelectedItem.Value);
                transport.StartDate = string.IsNullOrEmpty(txtStartDate.Text) ? string.Empty : (Convert.ToDateTime(txtStartDate.Text)).ToString("dd-MM-yyyy");

                transport.StartTime = string.IsNullOrEmpty(txtStartTime.Text) ? string.Empty : (Convert.ToDateTime(txtStartTime.Text)).ToString("HH:mm");

             
                transport.RouteID = Convert.ToInt32(dproute.SelectedItem.Value);
                transport.StartKm = string.IsNullOrEmpty(txtStartKm.Text) ? 0 : Convert.ToDecimal(txtStartKm.Text);

               transport.FirstDriver = Convert.ToInt32(dpDriver.SelectedItem.Value);
                transport.SecondDriver = Convert.ToInt32(dpDriver2.SelectedItem.Value);
                transport.operationtype = Convert.ToInt32(dpOperations.SelectedItem.Value);
                transport.bata = string.IsNullOrEmpty(txtBata.Text) ? 0 : Convert.ToDecimal(txtBata.Text);
                transport.salesbata = string.IsNullOrEmpty(txtSalesBata.Text) ? 0 : Convert.ToDecimal(txtSalesBata.Text);

                transport.CreatedBy = GlobalInfo.Userid;
              
                transport.IsActive = true;
            
                transport.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
                transport.ModifiedBy = GlobalInfo.Userid;
                transport.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");
                transport.SalesmanId = Convert.ToInt32(dpSalesman.SelectedItem.Value);
                transport.SecondSalesmanId = Convert.ToInt32(dpSecondSalesmanId.SelectedItem.Value);
        
              
           
       
                transport.flag = "Update";
                int Result = 0;
                Result = transportdata.AddVehicleOperationInfo(transport);
                if (Result > 0)
                {

                    divDanger.Visible = false;
                    divwarning.Visible = false;
                    divSusccess.Visible = true;
                    lblSuccess.Text = "Vehicle Out Operation Updated  Successfully";

                    ClearTextBox();
                    BindVehicleOperationInfo();
                    pnlError.Update();
                    upMain.Update();
                    uprouteList.Update();
                    btnupdateVehicleOperation.Visible = false;
                    btnAddVehicleOperation.Visible = true;

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
        public void ClearTextBox()
        {
            dpVehicleNo.ClearSelection();
            dproute.ClearSelection();
            txtBata.Text = string.Empty;
        
            txtStartDate.Text = string.Empty;
            txtStartKm.Text = string.Empty;
            txtStartTime.Text = string.Empty;
       
            dpDriver.ClearSelection();
            dpDriver2.ClearSelection();
            dpOperations.ClearSelection();
        
            dpSalesman.ClearSelection();
       
        
            txtSalesBata.Text = string.Empty;
            dpSecondSalesmanId.ClearSelection();
            txtSalesBata.Text = string.Empty;
            transport.scheduleIntime = string.Empty;
            transport.scheduleOuttime = string.Empty;
       


        }
        protected void rpRouteList_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {

            divDanger.Visible = false;
            divwarning.Visible = false;
            divSusccess.Visible = false;
            pnlError.Update();
            int VOp = 0;
            VOp = Convert.ToInt32(e.CommandArgument);
            switch (e.CommandName)
            {
                case ("Edit"):
                    {
                        lblHeaderTab.Text = "Edit Vehicle Out Operation";
                        hfvoperationId.Value = VOp.ToString();
                        VOp = Convert.ToInt32(hfvoperationId.Value);
                        GetTransportOperationInfoByID(VOp);
                        btnAddVehicleOperation.Visible = false;
                        btnupdateVehicleOperation.Visible = true;
                        BindVehicleOperationInfo();
                        upMain.Update();
                       

                        uprouteList.Update();
                        break;
                    }
                case ("delete"):
                    {

                        hfvoperationId.Value = VOp.ToString();
                        VOp = Convert.ToInt32(hfvoperationId.Value);
                        DeleteMapbyID(VOp);
                        BindVehicleOperationInfo();
                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }


            }
        }
        public void GetTransportOperationInfoByID(int VOp)
        {

            transportdata = new TransportData();
            DS = transportdata.GetVehicleOperationInfoByID(VOp);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {

                dpVehicleNo.ClearSelection();
                if (dpVehicleNo.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["TM_Id"]).ToString()) != null)
                {
                    dpVehicleNo.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["TM_Id"]).ToString()).Selected = true;
                }
                dproute.ClearSelection();
                if (dproute.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["RouteID"]).ToString()) != null)
                {
                    dproute.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["RouteID"]).ToString()).Selected = true;
                }
           
                dpDriver.ClearSelection();
                if (dpDriver.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["FirstDriver"]).ToString()) != null)
                {
                    dpDriver.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["FirstDriver"]).ToString()).Selected = true;
                }
                dpDriver2.ClearSelection();
                if (dpDriver2.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["SecondDriver"]).ToString()) != null)
                {
                    dpDriver2.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["SecondDriver"]).ToString()).Selected = true;
                }
                txtBata.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Bata"].ToString()) ? string.Empty : (Convert.ToDecimal(DS.Tables[0].Rows[0]["Bata"]).ToString("#.##"));

                if (DS.Tables[0].Rows[0]["StartDate"].ToString() == "")
                {
                    txtStartDate.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["StartDate"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["StartDate"].ToString();
                }
                else
                {
                    string startdate = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["StartDate"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["StartDate"].ToString();
                    //sky
                    DateTime date2 = Convert.ToDateTime(startdate, System.Globalization.CultureInfo.GetCultureInfo("ur-PK").DateTimeFormat);
                    txtStartDate.Text = (Convert.ToDateTime(date2).ToString("yyyy-MM-dd"));
                }
              
                txtStartTime.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["StartTime"].ToString()) ? string.Empty : (Convert.ToDateTime(DS.Tables[0].Rows[0]["StartTime"]).ToString("hh:mm"));
             
                dpOperations.ClearSelection();
                if (dpOperations.Items.FindByValue(DS.Tables[0].Rows[0]["OperationType"].ToString()) != null)
                {
                    dpOperations.Items.FindByValue(DS.Tables[0].Rows[0]["OperationType"].ToString()).Selected = true;
                }
                txtStartKm.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["StartKm"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["StartKm"].ToString();
              
                dpSalesman.ClearSelection();
                if (dpSalesman.Items.FindByValue(DS.Tables[0].Rows[0]["SalesmanId"].ToString()) != null)
                {
                    dpSalesman.Items.FindByValue(DS.Tables[0].Rows[0]["SalesmanId"].ToString()).Selected = true;
                }
                dpSecondSalesmanId.ClearSelection();
                if (dpSecondSalesmanId.Items.FindByValue(DS.Tables[0].Rows[0]["SecondSalesman"].ToString()) != null)
                {
                    dpSecondSalesmanId.Items.FindByValue(DS.Tables[0].Rows[0]["SecondSalesman"].ToString()).Selected = true;
                }
               
             
               
                txtSalesBata.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["SMBata"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["SMBata"].ToString();
            
            }
        }
        public void BindVehicleOperationInfo()
        {

            transportdata = new TransportData();
            DataSet DS = new DataSet();
            DS = transportdata.GetVehicleOperationInfo();

            if (!Comman.Comman.IsDataSetEmpty(DS))
            {

                rpvehicleoperationInfo.DataSource = DS;
                rpvehicleoperationInfo.DataBind();
            }
        }
        public void DeleteMapbyID(int VOp)
        {

            transportdata = new TransportData();
            transport = new Transports();
            transport.VOp = Convert.ToInt32(VOp);
            transport.TM_Id = 0;
            transport.StartDate = txtStartDate.Text;

            transport.StartTime = txtStartTime.Text;
          
            transport.RouteID = 0;
            transport.StartKm = 0;
            transport.EndKm = 0;
            transport.FirstDriver = 0;
            transport.SecondDriver = 0;
            transport.operationtype = 0;
            transport.bata = 0;
            transport.tollpaid = 0;

            transport.CreatedBy = GlobalInfo.Userid;
            transport.IsActive = true;
            transport.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
            transport.ModifiedBy = GlobalInfo.Userid;
            transport.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");
            transport.SalesmanId = Convert.ToInt32(dpSalesman.SelectedItem.Value);
            transport.SecondSalesmanId = Convert.ToInt32(dpSecondSalesmanId.SelectedItem.Value);
         
      
          
            transport.flag = "Delete";
            int Result = 0;
            Result = transportdata.AddVehicleOperationInfo(transport);
            if (Result > 0)
            {

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Vehicle Out Operation  Deleted  Successfully";

                ClearTextBox();
                BindVehicleOperationInfo();
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
        protected void btnClick_btnAddNew(object sender, EventArgs e)
        {
            Response.Redirect("~/Tabs/TransportModule/VehicleOperations.aspx");
        }
    }
}