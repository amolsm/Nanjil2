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
    public partial class ProductSupplyOutOperation : System.Web.UI.Page
    {
        TransportData transportdata;
        Transports transport;
        DataSet DS;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnAddVehicleOperation.Visible = true;
                btnupdateVehicleOperation.Visible = false;
                BindVehicleOperationInfo();
                BindDropDwon();
                txtStartDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                txtStartTime.Text = DateTime.Now.ToString("HH:mm");
               
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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ClearTextBox();
            int Vehicleid = Convert.ToInt32(dpVehicleNo.SelectedItem.Value);
            int routeid = Convert.ToInt32(dproute.SelectedItem.Value);
            GetOutOperationDetailsbyVechileId(routeid, Vehicleid);
            
        }
        public void GetOutOperationDetailsbyVechileId(int routeid, int Vehicleid)
        {
            transportdata = new TransportData();
            DS = transportdata.GetOutOperationDetailsbyVechileId(routeid, Vehicleid);
            lblShowMessage.Text = string.Empty;
            lblDispatchId.Text = string.Empty;
           
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                lblDispatchId.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["DispatchId"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["DispatchId"].ToString();
              
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
                if (DS.Tables[0].Rows[0]["DispatchDate"].ToString() == "")
                {
                    txtDispatchDate.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["DispatchDate"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["DispatchDate"].ToString();
                }
                else
                {
                    string startdate = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["DispatchDate"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["DispatchDate"].ToString();
                    //sky
                    DateTime date2 = Convert.ToDateTime(startdate, System.Globalization.CultureInfo.GetCultureInfo("ur-PK").DateTimeFormat);
                    txtDispatchDate.Text = (Convert.ToDateTime(date2).ToString("yyyy-MM-dd"));
                }
                txtDispatchTime.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["DispatchTime"].ToString()) ? string.Empty : (Convert.ToDateTime(DS.Tables[0].Rows[0]["DispatchTime"]).ToString("hh:mm"));
                txtSchedueOutTime.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["ScheduleOutTime"].ToString()) ? string.Empty : (Convert.ToDateTime(DS.Tables[0].Rows[0]["ScheduleOutTime"]).ToString("hh:mm"));
                txtScheduleEndTime.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["ScheduleInTime"].ToString()) ? string.Empty : (Convert.ToDateTime(DS.Tables[0].Rows[0]["ScheduleInTime"]).ToString("hh:mm"));

              

            }
            if (Comman.Comman.IsDataSetEmpty(DS))
            {
                
                lblShowMessage.Text = "Vehicle is not in Product Supply Operation";
               
            }
        }
        protected void btnClick_btnAddVehicleOperation(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {

                transportdata = new TransportData();
                transport = new Transports();
                transport.VOp = 0;
                transport.dispatchId = string.IsNullOrEmpty(lblDispatchId.Text) ? 0 : Convert.ToInt32(lblDispatchId.Text);
                transport.StartDate = string.IsNullOrEmpty(txtStartDate.Text) ? string.Empty : (Convert.ToDateTime(txtStartDate.Text)).ToString("dd-MM-yyyy");
                transport.StartTime = string.IsNullOrEmpty(txtStartTime.Text) ? string.Empty : (Convert.ToDateTime(txtStartTime.Text)).ToString("HH:mm");
                transport.scheduleOuttime = string.IsNullOrEmpty(txtSchedueOutTime.Text) ? string.Empty : (Convert.ToDateTime(txtSchedueOutTime.Text)).ToString("HH:mm");
                transport.scheduleIntime = string.IsNullOrEmpty(txtScheduleEndTime.Text) ? string.Empty : (Convert.ToDateTime(txtScheduleEndTime.Text)).ToString("HH:mm");
                transport.StartKm = string.IsNullOrEmpty(txtStartKm.Text) ? 0 : Convert.ToDecimal(txtStartKm.Text);
                transport.bata = string.IsNullOrEmpty(txtBata.Text) ? 0 : Convert.ToDecimal(txtBata.Text);
                transport.salesbata = string.IsNullOrEmpty(txtSalesBata.Text) ? 0 : Convert.ToDecimal(txtSalesBata.Text);
                transport.operationtype = Convert.ToInt32(dpOperations.SelectedItem.Value);
                transport.FirstDriver = Convert.ToInt32(dpDriver.SelectedItem.Value);
                transport.SecondDriver = Convert.ToInt32(dpDriver2.SelectedItem.Value);
                transport.SalesmanId = Convert.ToInt32(dpSalesman.SelectedItem.Value);
                transport.SecondSalesmanId = Convert.ToInt32(dpSecondSalesmanId.SelectedItem.Value);
                transport.CreatedBy = GlobalInfo.Userid;
                transport.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
                transport.ModifiedBy = GlobalInfo.Userid;
                transport.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");
                transport.IsActive = true;
                transport.flag = "Add";
                int Result = 0;
                Result = transportdata.AddVehicleProductOutOperationInfo(transport);
                if (Result > 0)
                {

                    divDanger.Visible = false;
                    divwarning.Visible = false;
                    divSusccess.Visible = true;
                    lblSuccess.Text = "Vehicle Operation Updated  Successfully";

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
                        lblHeaderTab.Text = "Edit Vehicle Operation";
                        hfvoperationId.Value = VOp.ToString();
                        VOp = Convert.ToInt32(hfvoperationId.Value);
                        GetVehicleOperationforproductbyId(VOp);
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
                     
                        BindVehicleOperationInfo();
                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }


            }
        }
              public void BindVehicleOperationInfo()

              {

                  transportdata = new TransportData();
                  DataSet DS = new DataSet();
                  DS = transportdata.GetVehicleProductOutOperationInfo();

                  if (!Comman.Comman.IsDataSetEmpty(DS))
                  {

                      rpvehicleoperationInfo.DataSource = DS;
                      rpvehicleoperationInfo.DataBind();
                  }
              }

                   public void ClearTextBox()
               {
           
            txtBata.Text = string.Empty;
           
          
            txtStartKm.Text = string.Empty;
         
           
            dpDriver.ClearSelection();
            dpDriver2.ClearSelection();
            dpOperations.ClearSelection();
         
            dpSalesman.ClearSelection();
            txtDispatchDate.Text = string.Empty;
            txtDispatchTime.Text = string.Empty;
            txtSalesBata.Text = string.Empty;
            dpSecondSalesmanId.ClearSelection();
            txtSalesBata.Text = string.Empty;
          
          


        }

         protected void btnClick_btnAddNew(object sender, EventArgs e)
        {
            Response.Redirect("~/Tabs/TransportModule/ProductSupplyOutOperation.aspx");
        }

         public void GetVehicleOperationforproductbyId(int VOp)
         {

             transportdata = new TransportData();
             DS = transportdata.GetVehicleOperationforproductbyId(VOp);
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
                 lblDispatchId.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["DispatchId"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["DispatchId"].ToString();

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
                 txtSalesBata.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["SMBata"].ToString()) ? string.Empty : (Convert.ToDecimal(DS.Tables[0].Rows[0]["SMBata"]).ToString("#.##"));
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
                 if (DS.Tables[0].Rows[0]["DispatchDate"].ToString() == "")
                 {
                     txtDispatchDate.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["DispatchDate"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["DispatchDate"].ToString();
                 }
                 else
                 {
                     string startdate = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["DispatchDate"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["DispatchDate"].ToString();
                     //sky
                     DateTime date2 = Convert.ToDateTime(startdate, System.Globalization.CultureInfo.GetCultureInfo("ur-PK").DateTimeFormat);
                     txtDispatchDate.Text = (Convert.ToDateTime(date2).ToString("yyyy-MM-dd"));
                 }
                 txtDispatchTime.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["DispatchTime"].ToString()) ? string.Empty : (Convert.ToDateTime(DS.Tables[0].Rows[0]["DispatchTime"]).ToString("hh:mm"));
                 txtSchedueOutTime.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["ScheduleTime"].ToString()) ? string.Empty : (Convert.ToDateTime(DS.Tables[0].Rows[0]["ScheduleTime"]).ToString("hh:mm"));
                 txtScheduleEndTime.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["EndScheduleTime"].ToString()) ? string.Empty : (Convert.ToDateTime(DS.Tables[0].Rows[0]["EndScheduleTime"]).ToString("hh:mm"));

             }
         }

         protected void btnClick_btnupdateVehicleOperation(object sender, EventArgs e)
         {
             if (Page.IsValid)
             {

                 transportdata = new TransportData();
                 transport = new Transports();
                 transport.VOp = string.IsNullOrEmpty(hfvoperationId.Value) ? 0 : Convert.ToInt32(hfvoperationId.Value);
                 transport.dispatchId = string.IsNullOrEmpty(lblDispatchId.Text) ? 0 : Convert.ToInt32(lblDispatchId.Text);
                 transport.StartDate = string.IsNullOrEmpty(txtStartDate.Text) ? string.Empty : (Convert.ToDateTime(txtStartDate.Text)).ToString("dd-MM-yyyy");
                 transport.StartTime = string.IsNullOrEmpty(txtStartTime.Text) ? string.Empty : (Convert.ToDateTime(txtStartTime.Text)).ToString("HH:mm");
                 transport.scheduleOuttime = string.IsNullOrEmpty(txtSchedueOutTime.Text) ? string.Empty : (Convert.ToDateTime(txtSchedueOutTime.Text)).ToString("HH:mm");
                 transport.scheduleIntime = string.IsNullOrEmpty(txtScheduleEndTime.Text) ? string.Empty : (Convert.ToDateTime(txtScheduleEndTime.Text)).ToString("HH:mm");
                 transport.StartKm = string.IsNullOrEmpty(txtStartKm.Text) ? 0 : Convert.ToDecimal(txtStartKm.Text);
                 transport.bata = string.IsNullOrEmpty(txtBata.Text) ? 0 : Convert.ToDecimal(txtBata.Text);
                 transport.salesbata = string.IsNullOrEmpty(txtSalesBata.Text) ? 0 : Convert.ToDecimal(txtSalesBata.Text);
                 transport.operationtype = Convert.ToInt32(dpOperations.SelectedItem.Value);
                 transport.FirstDriver = Convert.ToInt32(dpDriver.SelectedItem.Value);
                 transport.SecondDriver = Convert.ToInt32(dpDriver2.SelectedItem.Value);
                 transport.SalesmanId = Convert.ToInt32(dpSalesman.SelectedItem.Value);
                 transport.SecondSalesmanId = Convert.ToInt32(dpSecondSalesmanId.SelectedItem.Value);
                 transport.CreatedBy = GlobalInfo.Userid;
                 transport.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
                 transport.ModifiedBy = GlobalInfo.Userid;
                 transport.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");
                 transport.IsActive = true;
                 transport.flag = "Add";
                 int Result = 0;
                 Result = transportdata.AddVehicleProductOutOperationInfo(transport);
                 if (Result > 0)
                 {

                     divDanger.Visible = false;
                     divwarning.Visible = false;
                     divSusccess.Visible = true;
                     lblSuccess.Text = "Vehicle Operation Updated  Successfully";

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
    }
       
  }
    
