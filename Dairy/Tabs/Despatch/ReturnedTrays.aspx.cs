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
using System.Configuration;
using System.Data.SqlClient;

namespace Dairy.Tabs.Despatch
{
    public partial class ReturnedTrays : System.Web.UI.Page
    {
        DataSet DS = new DataSet();
        static int Row = -1;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                //BindRouteList();
                BindDropDwon();
                //txtOrderDetailsId.Visible = false;

                //  btnPrintSummary.Visible = false;
                //Button btnSubmitModal = (Button)FindControl("btnSubmitModal");
                //btnSubmitModal.Visible = false;
                //  btnSubmitModal.Visible = false;

                //btnAddRoute.Visible = true;
                //btnupdateroute.Visible = false;


            }

        }

        protected void btnClick_btnSearch(object sender, EventArgs e)
        {

            Dispatch dispatch = new Dispatch();

            int id = 0;
            id = Convert.ToInt32(txtDispatchId.Text);

            DispatchData dispatchData = new DispatchData();
            DataSet DS = new DataSet();
            StringBuilder sb = new StringBuilder();



            DS = dispatchData.GetDispatchByID(id);

            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                // int count = Convert.ToInt32(DS.Tables[1].Rows[0]["Id"]);
                //count = count + 1;
                //txtRouteCode.Text = string.Format("R{0:0000}", count);
                rpRouteList.DataSource = DS;
                rpRouteList.DataBind();
                rpRouteList.Visible = true;

                // btnSubmitModal.Visible = true;
                // btnPrintSummary.Visible = false;

                uprouteList.Update();

                // DS.WriteXml(Server.MapPath("~/Tabs/Dispatch/temp.xml"));

                //string str = DS.GetXml();
                //insertDispatchTemp(DS);

            }


        }

        private void insertDispatchTemp(DataSet dS)
        {
            string consString = ConfigurationManager.ConnectionStrings["projectConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(consString))
            {
                using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                {
                    //Set the database table name
                    sqlBulkCopy.DestinationTableName = "DispatchTempDetails";

                    //[OPTIONAL]: Map the DataTable columns with that of the database table
                    sqlBulkCopy.ColumnMappings.Add("OrderID", "DispatchTempOrderId");
                    sqlBulkCopy.ColumnMappings.Add("OrderDetailsID", "DispatchTempOrderDetailsId");
                    sqlBulkCopy.ColumnMappings.Add("Qty", "DispatchTempPrvQty");
                    sqlBulkCopy.ColumnMappings.Add("Qty", "DispatchTempTokanId");
                    con.Open();
                    sqlBulkCopy.WriteToServer(dS.Tables[0]);
                    con.Close();
                }
            }
        }

        protected void btnClick_btnUpdate(object sender, EventArgs e)
        {
            Dispatch disp = new Dispatch();
            DispatchData dispatchData = new DispatchData();


            disp.DispatchId = string.IsNullOrEmpty(txtHidden.Text) ? 0 : Convert.ToInt32(txtHidden.Text);
            disp.Trays = string.IsNullOrEmpty(txtTraysReturn.Text) ? 0 : Convert.ToInt32(txtTraysReturn.Text);
            disp.Cartons = string.IsNullOrEmpty(txtCartonsReturn.Text) ? 0 : Convert.ToInt32(txtCartonsReturn.Text);
            disp.IceBox = string.IsNullOrEmpty(txtIceBoxReturn.Text) ? 0 : Convert.ToInt32(txtIceBoxReturn.Text);
            disp.OtherDisp = string.IsNullOrEmpty(txtOtherReturn.Text) ? 0 : Convert.ToInt32(txtOtherReturn.Text);

            //disp.Quantity = Convert.ToInt32(txtQuantity.Text);

            DS = dispatchData.GetDispatchByID(disp.DispatchId);
            int trays = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["TraysDispached"].ToString()) ? 0 : Convert.ToInt32(DS.Tables[0].Rows[0]["TraysDispached"]);
            int icebox = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["IceBoxDispached"].ToString()) ? 0 : Convert.ToInt32(DS.Tables[0].Rows[0]["IceBoxDispached"]);
            int cartons = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["CartonsDispached"].ToString()) ? 0 : Convert.ToInt32(DS.Tables[0].Rows[0]["CartonsDispached"]);
            int other = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["OtherDispached"].ToString()) ? 0 : Convert.ToInt32(DS.Tables[0].Rows[0]["OtherDispached"]);

            int result = 0;

            if (disp.IceBox >= 0 && disp.Trays >= 0 && disp.Cartons >= 0 && disp.OtherDisp >= 0)
            {
                if (disp.IceBox <= icebox && disp.Trays <= trays && disp.Cartons <= cartons && disp.OtherDisp <= other)
                {

                    DataSet ds = new DataSet();
                    result = dispatchData.updateReturnTrays(disp);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Enter Valid Quantity')", true);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Enter Valid Quantity')", true);
            }


            if (result > 0)
            {

                ClearTextBox();

                //rpRouteList.DataSource = ds;
                //rpRouteList.DataBind();
                rpRouteList.Visible = false;

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Information Updated  Successfully";


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


            DS = new DataSet();
            DS = BindCommanData.BindCommanDropDwon("EmployeeID ", "EmployeeCode +' '+EmployeeName as Name  ", "EmployeeMaster", "IsActive=1 and Designation='Sales' ");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpSalesman.DataSource = DS;
                dpSalesman.DataBind();
                dpSalesman.Items.Insert(0, new ListItem("--Select First Salesman--", "0"));

                dpSalesman2.DataSource = DS;
                dpSalesman2.DataBind();
                dpSalesman2.Items.Insert(0, new ListItem("--Select Second Salesman--", "0"));

            }

            DS = new DataSet();
            DS = BindCommanData.BindCommanDropDwon("DriverId", "Dr_Name as Name  ", "tblDriverDetails", "IsActive='True' ");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpDriver.DataSource = DS;
                dpDriver.DataBind();
                dpDriver.Items.Insert(0, new ListItem("--Select First Driver--", "0"));

                dpDriver2.DataSource = DS;
                dpDriver2.DataBind();
                dpDriver2.Items.Insert(0, new ListItem("--Select Second Driver--", "0"));

            }
            DS = new DataSet();
            DS = BindCommanData.BindCommanDropDwon("TM_Id ", "VehicleNo as Name  ", "tblTransportMaster", "TM_Id is not null");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpVehicle.DataSource = DS;
                dpVehicle.DataBind();
                dpVehicle.Items.Insert(0, new ListItem("--Select Vehicle No--", "0"));
            }

        }
        public void ClearTextBox()
        {
            txtTraysReturn.Text = string.Empty;
            txtIceBoxReturn.Text = string.Empty;
            txtCartonsReturn.Text = string.Empty;
            txtOtherReturn.Text = string.Empty;
        }
        public void BindRouteList()
        {
            DispatchData dispatchData = new DispatchData();
            DataSet DS = new DataSet();
            StringBuilder sb = new StringBuilder();
            RouteData routeDate = new RouteData();


            DS = dispatchData.GetAllOrdersDetails();
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                int count = Convert.ToInt32(DS.Tables[1].Rows[0]["Id"]);
                count = count + 1;
                //txtRouteCode.Text = string.Format("R{0:0000}", count);
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
            int Agentid = 0;
            Agentid = Convert.ToInt32(e.CommandArgument);
            switch (e.CommandName)
            {
                case ("Edit"):
                    {
                        //lbltital.Text = "Edit Route";
                        hfRow.Value = Agentid.ToString();
                        Agentid = Convert.ToInt32(hfRow.Value);
                        //BindRouteList();
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myBox", "<script type='text/javascript'> $('#myBox').removeClass('collapsed-box'); </script>", false);
                        GetRouteDetailsbyID(Agentid);
                        //btnAddRoute.Visible = false;
                        //btnupdateroute.Visible = true;
                        // upMain.Update();
                        uprouteList.Update();
                        break;
                    }
                case ("delete"):
                    {

                        //hfrouteID.Value = routeID.ToString();
                        // routeID = Convert.ToInt32(hfrouteID.Value);
                        // DeleteRoutebyrouteID(routeID);
                        // BindRouteList();
                        //upMain.Update();
                        // uprouteList.Update();
                        break;
                    }


            }
        }
        public void GetRouteDetailsbyID(int id)
        {
            Dispatch dispatch = new Dispatch();


            DispatchData dispatchData = new DispatchData();
            DataSet DS = new DataSet();
            StringBuilder sb = new StringBuilder();



            DS = dispatchData.GetDispatchByID(id);

            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                txtTraysReturn.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["TraysReturned"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["TraysReturned"].ToString();
                txtIceBoxReturn.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["IceBoxReturned"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["IceBoxReturned"].ToString();
                txtCartonsReturn.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["CartonsReturned"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["CartonsReturned"].ToString();
                txtOtherReturn.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["OtherReturned"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["OtherReturned"].ToString();
                txtHidden.Text = id.ToString();

            }
        }
        public void DeleteRoutebyrouteID(int routeID)
        {

            //Route route = new Route();
            //RouteData routeDate = new RouteData();
            //route.RouteID = string.IsNullOrEmpty(hfrouteID.Value) ? 0 : Convert.ToInt32(hfrouteID.Value);
            //route.RouteCode = string.Empty;
            //route.RouteName = string.Empty;
            //route.ASOID = Convert.ToInt32(dpASOID.SelectedItem.Value);
            //route.RouteDesc = string.Empty;
            //route.CreatedBy = GlobalInfo.Userid;
            //route.Discription = txtDsicription.Text;
            //route.IsActive = false;
            //route.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
            //route.ModifiedBy = GlobalInfo.Userid;
            //route.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");
            //route.flag = "Delete";
            //int Result = 0;
            //Result = routeDate.InsertRoute(route);
            //if (Result > 0)
            //{

            //    divDanger.Visible = false;
            //    divwarning.Visible = false;
            //    divSusccess.Visible = true;
            //    lblSuccess.Text = "Delete Updated  Successfully";
            //    ClearTextBox();
            //    BindRouteList();
            //    pnlError.Update();
            //    btnAddRoute.Visible = true;
            //    btnupdateroute.Visible = false;
            //    upMain.Update();
            //    uprouteList.Update();
            //}
            //else
            //{
            //    divDanger.Visible = false;
            //    divwarning.Visible = true;
            //    divSusccess.Visible = false;
            //    lblwarning.Text = "Please Contact to Site Admin";
            //    pnlError.Update();

            //}
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Dispatch dispatch = new Dispatch();
            DispatchData dispatchData = new DispatchData();



            DataSet ds = new DataSet();
            int id = 0;
            ds.ReadXml(Server.MapPath("~/Tabs/Dispatch/temp.xml"));
            ds.Tables[0].Columns.Add("DispatchInfoId", typeof(int));
            id = Convert.ToInt32(ds.Tables[1].Rows[0]["id"]);
            id = id + 1;
            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                ds.Tables[0].Rows[i]["DispatchInfoId"] = id;
            }
            Dispatch disp = new Dispatch();
            DispatchData dispData = new DispatchData();
            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                disp.OrderDetailsId = Convert.ToInt32(ds.Tables[0].Rows[i]["OrderDetailsID"]);

                int x = dispData.UpdateDispatch(disp);
                if (x > 0)
                {
                    continue;
                }
                else { break; }
            }

            string consString = ConfigurationManager.ConnectionStrings["projectConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(consString))
            {
                using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                {
                    //Set the database table name
                    sqlBulkCopy.DestinationTableName = "DispatchDetails";

                    //[OPTIONAL]: Map the DataTable columns with that of the database table
                    sqlBulkCopy.ColumnMappings.Add("DispatchInfoId", "DD_DispatchInfoId");
                    sqlBulkCopy.ColumnMappings.Add("OrderID", "DD_OrderId");
                    sqlBulkCopy.ColumnMappings.Add("OrderDetailsId", "DD_OrderDetailsId");
                    sqlBulkCopy.ColumnMappings.Add("Qty", "DD_NewQuantity");
                    // sqlBulkCopy.ColumnMappings.Add("Country", "DD_OrderDetailsId");
                    //sqlBulkCopy.ColumnMappings.Add("Country", "DD_OrderDetailsId");
                    con.Open();
                    sqlBulkCopy.WriteToServer(ds.Tables[0]);
                    con.Close();
                }
            }

            dispatch.RouteID = Convert.ToInt32(ds.Tables[0].Rows[0]["RouteID"]);
            dispatch.DispatchId = id;
            dispatch.SalesmanFirstId = Convert.ToInt32(dpSalesman.SelectedValue);
            dispatch.SalesmanSecondId = Convert.ToInt32(dpSalesman2.SelectedValue);
            dispatch.DriverFirstId = Convert.ToInt32(dpDriver.SelectedValue);
            dispatch.DriverSecondId = Convert.ToInt32(dpDriver2.SelectedValue);
            dispatch.VehicleId = Convert.ToInt32(dpVehicle.SelectedValue);
            dispatch.Cartons = Convert.ToInt32(txtCartons.Text);
            dispatch.Trays = Convert.ToInt32(txtTraysDispached.Text);
            dispatch.IceBox = Convert.ToInt32(txtIceBox.Text);
            dispatch.OtherDisp = Convert.ToInt32(txtOthers.Text);

            int result = 0;
            result = dispatchData.AddDispatchInfo(dispatch);
            if (result > 0)
            {
                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Information Updated  Successfully";

                clearlist();
                ClearTextBox();
                generateDispatchSummary(id);
                //btnSubmitModal.Visible = false;
                // btnPrintSummary.Visible = true;
                pnlError.Update();

                upMain.Update();
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

        private void generateDispatchSummary(int id)
        {


        }


        private void clearlist()
        {
            // DataSet dats = new DataSet();
            rpRouteList.Visible = false;
            // rpRouteList.DataBind();
            uprouteList.Update();
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {

        }
    }
}
