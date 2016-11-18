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

namespace Dairy.Tabs.Administration 
{
    public partial class ViewDispatchOrders : System.Web.UI.Page
    {
        DataSet DS = new DataSet();
        static int Row = -1;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                //BindRouteList();
                BindDropDwon();
                txtOrderDetailsId.Visible = false;

                btnPrintSummary.Visible = false;
                btnPrintGatePass.Visible = false;
                //Button btnSubmitModal = (Button)FindControl("btnSubmitModal");
                //btnSubmitModal.Visible = false;
                btnSubmitModal.Visible = false;

                //btnAddRoute.Visible = true;
                //btnupdateroute.Visible = false;
                txtOrderDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
            }

        }

        protected void btnClick_btnSearch(object sender, EventArgs e)
        {

            Dispatch dispatch = new Dispatch();
            dispatch.OrderDate = (Convert.ToDateTime(txtOrderDate.Text)).ToString("dd-MM-yyyy");
            dispatch.RouteID = Convert.ToInt32(dpagentRoute.SelectedItem.Value);
            dispatch.CategoryId = Convert.ToInt32(dpCategory.SelectedItem.Value);

            DispatchData dispatchData = new DispatchData();
            DataSet DS = new DataSet();
            StringBuilder sb = new StringBuilder();



            DS = dispatchData.GetDispatchSearch(dispatch);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {

                int count = Convert.ToInt32(DS.Tables[1].Rows[0]["Id"]);
                count = count + 1;
                //txtRouteCode.Text = string.Format("R{0:0000}", count);
                rpRouteList.DataSource = DS;
                rpRouteList.DataBind();
                rpRouteList.Visible = true;
                if (DS.Tables[0].Rows.Count != 0)
                {
                    btnSubmitModal.Visible = true;
                    btnPrintSummary.Visible = false;
                    btnPrintGatePass.Visible = false;
                }
                uprouteList.Update();
                int type = 0;
                type = Convert.ToInt32(dpCategory.SelectedItem.Value);

                string nm = GlobalInfo.UserName.ToString();

                DS.WriteXml(Server.MapPath("~/Tabs/Dispatch/temp" + nm + ".xml"));
                //DS.WriteXml(Server.MapPath("/Tabs/Dispatch/temp" + nm + ".xml"));

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
            //int Row = 0;
            //hfRow.Value = Row.ToString();
            // int Row = Convert.ToInt32(hfRow.Value);

            // Row = Row - 1;

            DataSet ds = new DataSet();
            string nm = GlobalInfo.UserName.ToString();
            ds.ReadXml(Server.MapPath("~/Tabs/Dispatch/temp" + nm + ".xml"));

            if (!Comman.Comman.IsDataSetEmpty(ds))
            {
                DataColumnCollection columns = ds.Tables[0].Columns;
                if (!columns.Contains("AgentName"))
                {
                    ds.Tables[0].Columns.Add("AgentName", typeof(string));

                    for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                    {
                        ds.Tables[0].Rows[i]["AgentName"] = string.Empty;
                    }
                }

                ds.Tables[0].Rows[Row]["Qty"] = txtQuantity.Text;
                ClearTextBox();
                //string nm = GlobalInfo.UserName.ToString();
                ds.WriteXml(Server.MapPath("~/Tabs/Dispatch/temp" + nm + ".xml"));
                rpRouteList.DataSource = ds;
                rpRouteList.DataBind();

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
            DS = BindCommanData.BindCommanDropDwon("RouteID ", "RouteCode +' '+RouteName as Name  ", "routeMaster", "IsArchive=1 ");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpagentRoute.DataSource = DS;
                dpagentRoute.DataBind();
                dpagentRoute.Items.Insert(0, new ListItem("--Select Route--", "0"));
            }
            DS = new DataSet();
            DS = BindCommanData.BindCommanDropDwon("CategoryId ", "CategoryName as Name  ", "Category", "IsActive=1");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpCategory.DataSource = DS;
                dpCategory.DataBind();
                dpCategory.Items.Insert(0, new ListItem("--Select Brand--", "0"));
            }
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

            DS = new DataSet();
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
            txtQuantity.Text = string.Empty;
            txtAgentName.Text = string.Empty;
            txtCommodityName.Text = string.Empty;
           // txtOrderDate.Text = string.Empty;
            txtOrderDetailsId.Text = string.Empty;
            txtOrderID.Text = string.Empty;
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
            //int Row = 0;
            Row = Convert.ToInt32(e.CommandArgument);
            switch (e.CommandName)
            {
                case ("Edit"):
                    {
                        //lbltital.Text = "Edit Route";
                        hfRow.Value = Row.ToString();
                        Row = Convert.ToInt32(hfRow.Value);
                        //BindRouteList();
                        Row = Row - 1;
                        GetRouteDetailsbyID(Row);
                        //btnAddRoute.Visible = false;
                        //btnupdateroute.Visible = true;
                        // upMain.Update();
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myBox", "<script type='text/javascript'> $('#myBox').removeClass('collapsed-box'); </script>", false);
                        upMain.Update();
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
        public void GetRouteDetailsbyID(int Row)
        {
            Dispatch dispatch = new Dispatch();
            dispatch.OrderDate = (Convert.ToDateTime(txtOrderDate.Text)).ToString("dd-MM-yyyy");
            dispatch.RouteID = Convert.ToInt32(dpagentRoute.SelectedItem.Value);

            DispatchData dispatchData = new DispatchData();
            DataSet DS = new DataSet();


            string nm = GlobalInfo.UserName.ToString();
            DS.ReadXml(Server.MapPath("~/Tabs/Dispatch/temp" + nm + ".xml"));
            //DS = dispatchData.GetDispatchSearch(dispatch);

            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                txtOrderID.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[Row]["OrderID"].ToString()) ? string.Empty : DS.Tables[0].Rows[Row]["OrderID"].ToString();
                txtOrderDetailsId.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[Row]["OrderDetailsId"].ToString()) ? string.Empty : DS.Tables[0].Rows[Row]["OrderDetailsId"].ToString();
                //txtOrderDate.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[Row]["OrderDate"].ToString()) ? string.Empty : DS.Tables[0].Rows[Row]["OrderDate"].ToString();
                txtQuantity.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[Row]["Qty"].ToString()) ? string.Empty : DS.Tables[0].Rows[Row]["Qty"].ToString();
                txtCommodityName.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[Row]["CommodityName"].ToString()) ? string.Empty : DS.Tables[0].Rows[Row]["CommodityName"].ToString();
                //txtAgentName.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[Row]["AgentName"].ToString()) ? string.Empty : DS.Tables[0].Rows[Row]["AgentName"].ToString();

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
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                //ScriptManager.RegisterStartupScript(this, GetType(), "Close Modal Popup", "$('#myModal').modal('data-dismiss')", true);

                Dispatch dispatch = new Dispatch();
                DispatchData dispatchData = new DispatchData();

                DataSet ds = new DataSet();
                int id = 0;
                string nm = GlobalInfo.UserName.ToString();
                ds.ReadXml(Server.MapPath("~/Tabs/Dispatch/temp" + nm + ".xml"));
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
                        sqlBulkCopy.ColumnMappings.Add("UnitCost", "UnitCost");
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
                dispatch.Cartons = (string.IsNullOrEmpty(txtCartons.Text) ? 0 : Convert.ToInt32(txtCartons.Text));
                dispatch.Trays = (string.IsNullOrEmpty(txtTraysDispached.Text) ? 0 : Convert.ToInt32(txtTraysDispached.Text));
                dispatch.IceBox = (string.IsNullOrEmpty(txtIceBox.Text) ? 0 : Convert.ToInt32(txtIceBox.Text));
                dispatch.OtherDisp = (string.IsNullOrEmpty(txtOthers.Text) ? 0 : Convert.ToInt32(txtOthers.Text));
                dispatch.DispatchDate = DateTime.Now.ToString("dd-MM-yyyy");
                dispatch.UserID = GlobalInfo.Userid;
                dispatch.CategoryId = Convert.ToInt32(dpCategory.SelectedItem.Value);
                dispatch.DispatchDateTime = DateTime.Now;
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
                    updatestock(id);
                    generateDispatchSummary(id);
                    generateGatePass(id);
                    btnSubmitModal.Visible = false;
                    btnPrintSummary.Visible = true;
                    btnPrintGatePass.Visible = true;
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
            else
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                //    //UpdatePanel1.Update();
                //    //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You clicked NO!')", true);
            }
        }

        private void updatestock(int id)
        {
            DataSet DS = new DataSet();
            DispatchData dispatchData = new DispatchData();
            string result = string.Empty;
            DS = dispatchData.getStock(id);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                string constr = ConfigurationManager.ConnectionStrings["projectConnection"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_StockUpdateDispatch"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@tblStock", DS.Tables[0]);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
        }

        private void generateDispatchSummary(int id)
        {
            DataSet DS = new DataSet();
            DispatchData dispatchData = new DispatchData();
            string result = string.Empty;
            DS = dispatchData.GenerateDispatchSummary(id);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                StringBuilder sb = new StringBuilder();

                //foreach (DataRow row in DS.Tables[0].Rows)
                //{

                //    int count = 0;
                //    int qty = 0;
                sb.Append("<style type='text / css'>");
                sb.Append(".tg  { border-collapse:collapse; border - spacing:0; border: 0px; }");
                sb.Append(".tg .tg-yw4l{vertical-align:top}");
                sb.Append(".tg .tg-baqh{text-align:center;vertical-align:top}");
                sb.Append("</style>");
                sb.Append("<table class='tg style1' style='page-break-inside:avoid; align:center; '>");
                sb.Append("<colgroup>");
                sb.Append("<col style = 'width:80px'>");
                sb.Append("<col style = 'width:100px'>");
                sb.Append("<col style = 'width:120px'>");
                sb.Append("<col style = 'width:120px'>");
                sb.Append("<col style = 'width:120px'>");
                sb.Append("<col style = 'width:100px'>");
                sb.Append("<col style = 'width:100px'>");
                sb.Append("<col style = 'width:100px'>");
                sb.Append("</colgroup>");

                sb.Append("<tr>");
                sb.Append("<th class='tg-yw4l' rowspan='2'>");
                sb.Append("<img src='/Theme/img/logo1.png' class='img-circle' alt='Logo' width='50px' hight='50px'>");
                sb.Append("</th>");

                sb.Append("<th class='tg-baqh' colspan='6' style='text-align:center'>");
                sb.Append("<u> Dispatch Summary </u> <br/>");
                sb.Append("</th>");

                sb.Append("<th class='tg-yw4l' style='text-align:right'>");

                sb.Append("TIN:330761667331<br>");
                sb.Append("</th>");
                sb.Append("</tr>");

                sb.Append("<tr style='border-bottom:1px solid !important'>");
                sb.Append("<td class='tg-yw4l' colspan='6' style='text-align:center'>");
                sb.Append("<b>Nanjil Integrated Dairy Development ,Mulagumoodu, K.K.Dt.</b>");

                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l' style='text-align:right'>");

                sb.Append("PH:248370,248605");

                sb.Append("</td>");
                sb.Append("<hr>");

                sb.Append("<tr style='border-bottom:0.5px dotted'>");

                sb.Append("<td colspan='2'>");
                sb.Append(DS.Tables[0].Rows[0]["RouteCode"].ToString() + " ");
                sb.Append(DS.Tables[0].Rows[0]["RouteName"].ToString());
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l' colspan='4' style='text-align:center; border-bottom: 0px'>");
                sb.Append("<b><u> " + DS.Tables[0].Rows[0]["CategoryName"].ToString());
                sb.Append("</b></u></td>");


                sb.Append("<td class='tg-yw4l' colspan='2' style='text-align:right'>");
                sb.Append("Date : " + DateTime.Now.ToString("dd-MM-yyyy"));
                sb.Append("</td>");


                sb.Append("</tr>");

                sb.Append("<tr style='border-bottom:0.5px dotted'>");
                sb.Append("<td class='tg-yw4l' colspan='2' style='text-align:left'>");
                sb.Append("Driver : " + DS.Tables[0].Rows[0]["FirstDriver"].ToString());
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l' rowspan='2' colspan='2' style='text-align:center'>");
                sb.Append("GatePass ID: <b> GP" + id.ToString() + "</b>");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l' colspan='2' rowspan='2' style='text-align:center'>");
                sb.Append("Dispatch ID: <b> DS" + id.ToString() + "</b>");
                sb.Append("</td>");


                sb.Append("<td class='tg-yw4l' colspan='2' style='text-align:left'>");
                sb.Append("Salesman I: " + DS.Tables[0].Rows[0]["FirstSalesman"].ToString());
                sb.Append("</td>");
                sb.Append("</tr>");

                sb.Append("<tr style='border-bottom:0.5px dotted'>");
                sb.Append("<td class='tg-yw4l' colspan='2' style='text-align:left'>");
                sb.Append("Driver II : " + DS.Tables[0].Rows[0]["SecondDriver"].ToString());
                sb.Append("</td>");



                sb.Append("<td class='tg-yw4l' colspan='2' style='text-align:left'>");
                sb.Append("Salesman II : " + DS.Tables[0].Rows[0]["SecondSalesman"].ToString());
                sb.Append("</td>");
                sb.Append("</tr>");

                sb.Append("<tr  style='border-bottom:1px solid'>");
                sb.Append("<td class='tg-yw4l' colspan='2' style='text-align:left'>");
                sb.Append("Vehicle No: " + DS.Tables[0].Rows[0]["VehicleNo"].ToString());
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l' colspan='3' style='text-align:left'>");
                sb.Append("Starting Time: " + DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss"));
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l' colspan='3' style='text-align:left'>");
                sb.Append("Ending Time: ");
                sb.Append("</td>");
                sb.Append("</tr>");

                sb.Append("<tr style='border-bottom:1px solid'> <td colspan = '8'> &nbsp; </td> </tr>");

                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append("<td class='tg-yw4l' style='text-align:left'>");
                sb.Append("<b> Sr. No: </b> ");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l'  style='text-align:left'>");
                sb.Append("<b>Product Name </b>");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l' style='text-align:left'>");
                sb.Append("<b>Commodity </b>");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l'  style='text-align:center'>");
                sb.Append("<b>Quantity </b>");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l'  style='text-align:left'>");
                sb.Append("<b>Unit Type </b>");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l'  style='text-align:left'>");
                sb.Append("<b>Spot Damage </b>");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l'  style='text-align:left'>");
                sb.Append("<b>Sales </b>");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l' style='text-align:left'>");
                sb.Append("<b>Return </b>");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l' style='text-align:left'>");
                sb.Append(" ");
                sb.Append("</td>");
                sb.Append("</tr>");
                int cnt = 1;
                foreach (DataRow row in DS.Tables[1].Rows)
                {
                    sb.Append("<tr style='border-bottom:0.5px dotted'>");
                    sb.Append("<td class='tg-yw4l' style='text-align:left'>");
                    sb.Append(cnt.ToString());
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l'  style='text-align:left'>");
                    sb.Append(row["ProductName"].ToString());
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l'  style='text-align:left'>");
                    sb.Append(row["CommodityName"].ToString());
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l'  style='text-align:center'>");
                    sb.Append(row["TotalQuantity"].ToString());
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l'  style='text-align:left'>");
                    sb.Append(row["UnitName"].ToString());
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l' style='text-align:left'>");
                    sb.Append(" ");
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l' style='text-align:left'>");
                    sb.Append(" ");
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l' style='text-align:left'>");
                    sb.Append(" ");
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l' style='text-align:left'>");
                    sb.Append(" ");
                    sb.Append("</td>");
                    sb.Append("</tr>");

                    cnt++;
                }

                sb.Append("<tr style='border-bottom:1px solid'> <td colspan = '8'> &nbsp; </td> </tr>");

                sb.Append("<tr style='border-Top:1px Solid;border-bottom:0.5px dotted'>");


                sb.Append("<td class='tg-yw4l' rowspan='3' style='text-align:left'>");
                sb.Append("<b>Crates Particular </b>");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l'  style='text-align:left'>");
                sb.Append("<b>Item</b>");
                //sb.Append(DS.Tables[0].Rows[0]["ProductName"].ToString());
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l'  style='text-align:left'>");
                sb.Append("<b>Tray</b> ");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l'  style='text-align:left'>");
                sb.Append("<b>Ice Box</b>");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l' colspan='2' style='text-align:left'>");
                sb.Append("<b>Cartons/Ice Pad </b>");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l' colspan='2' style='text-align:left'>");
                sb.Append("<b>Others </b>");
                sb.Append("</td>");

                sb.Append("</tr>");

                sb.Append("<tr style='border-bottom:0.5px dotted'>");


                //sb.Append("<td class='tg-yw4l' rowspan='3' style='text-align:left'>");
                //sb.Append("Crates Perticular ");
                //sb.Append("</td>");

                sb.Append("<td class='tg-yw4l'  style='text-align:left'>");
                sb.Append("<b>Dispatch</b>");
                //sb.Append(DS.Tables[0].Rows[0]["ProductName"].ToString());
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l'  style='text-align:left'>");
                sb.Append(DS.Tables[0].Rows[0]["TraysDispached"].ToString());
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l'  style='text-align:left'>");
                sb.Append(DS.Tables[0].Rows[0]["IceBoxDispached"].ToString());
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l' colspan='2' style='text-align:left'>");
                sb.Append(DS.Tables[0].Rows[0]["CartonsDispached"].ToString());
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l' colspan='2' style='text-align:left'>");
                sb.Append(DS.Tables[0].Rows[0]["OtherDispached"].ToString());
                sb.Append("</td>");




                sb.Append("</tr>");

                sb.Append("<tr style='border-bottom:1px Solid'>");


                //sb.Append("<td class='tg-yw4l' rowspan='3' style='text-align:left'>");
                //sb.Append("Crates Perticular ");
                //sb.Append("</td>");

                sb.Append("<td class='tg-yw4l'  style='text-align:left'>");
                sb.Append("<b>Returned</b>");
                //sb.Append(DS.Tables[0].Rows[0]["ProductName"].ToString());
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l'  style='text-align:center'>");
                sb.Append("");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l'  style='text-align:Center'>");
                sb.Append("");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l' style='text-align:Center'>");
                sb.Append("");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l'  style='text-align:Center'>");
                sb.Append("");
                sb.Append("</td>");

                sb.Append("</tr>");

                sb.Append("<tr>");
                sb.Append("<td class='tg-yw4l' colspan='8' style='text-align:left'>");
                sb.Append("&nbsp;");
                sb.Append("</td>");
                sb.Append("</tr>");
                sb.Append("<tr>");
                sb.Append("<td class='tg-yw4l' colspan='8' style='text-align:left'>");
                sb.Append("&nbsp;");
                sb.Append("</td>");
                sb.Append("</tr>");
                sb.Append("<tr>");
                sb.Append("<td class='tg-yw4l' colspan='8' style='text-align:left'>");
                sb.Append("&nbsp;");
                sb.Append("</td>");
                sb.Append("</tr>");


                sb.Append("<tr>");
                sb.Append("<td class='tg-yw4l'  colspan='3' style='text-align:left'>");
                sb.Append("Dispatch Clerk ");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l'  colspan='2' style='text-align:center'>");
                sb.Append("Production Manager ");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l'  colspan='3' style='text-align:right'>");
                sb.Append("Sales Man ");
                sb.Append("</td>");
                sb.Append("</tr>");







                result = sb.ToString();
                DispatchSummary.Text = result;
                //Session["ctrl"] = sb.ToString();
                Session["ctrl"] = pnlDispatchSummary;
                //Response.Redirect("/print.aspx", true);
                upDispatchSummary.Update();

            }
            else
            {
                result = "Order not FOund";
                DispatchSummary.Text = result;

            }


        }

        private void generateGatePass(int id)
        {
            DataSet DS = new DataSet();
            DispatchData dispatchData = new DispatchData();
            string result = string.Empty;
            DS = dispatchData.GenerateDispatchSummary(id);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                StringBuilder sb = new StringBuilder();

                //foreach (DataRow row in DS.Tables[0].Rows)
                //{

                //    int count = 0;
                //    int qty = 0;
                sb.Append("<style type='text / css'>");
                sb.Append(".tg  { border-collapse:collapse; border - spacing:0; border: 0px; }");
                sb.Append(".tg .tg-yw4l{vertical-align:top}");
                sb.Append(".tg .tg-baqh{text-align:center;vertical-align:top}");
                sb.Append("</style>");
                sb.Append("<table class='tg style1' style='page-break-inside:avoid; align:center; '>");
                sb.Append("<colgroup>");
                sb.Append("<col style = 'width:80px'>");
                sb.Append("<col style = 'width:100px'>");
                sb.Append("<col style = 'width:120px'>");
                sb.Append("<col style = 'width:120px'>");
                sb.Append("<col style = 'width:120px'>");
                sb.Append("<col style = 'width:100px'>");
                sb.Append("<col style = 'width:100px'>");
                sb.Append("<col style = 'width:100px'>");
                sb.Append("</colgroup>");

                sb.Append("<tr>");
                sb.Append("<th class='tg-yw4l' rowspan='2'>");
                sb.Append("<img src='/Theme/img/logo1.png' class='img-circle' alt='Logo' width='50px' hight='50px'>");
                sb.Append("</th>");

                sb.Append("<th class='tg-baqh' colspan='6' style='text-align:center'>");
                sb.Append("<u> Gate Pass </u> <br/>");
                sb.Append("</th>");

                sb.Append("<th class='tg-yw4l' style='text-align:right'>");

                sb.Append("TIN:330761667331<br>");
                sb.Append("</th>");
                sb.Append("</tr>");

                sb.Append("<tr style='border-bottom:1px solid !important'>");
                sb.Append("<td class='tg-yw4l' colspan='6' style='text-align:center'>");
                sb.Append("<b>Nanjil Integrated Dairy Development ,Mulagumoodu, K.K.Dt.</b>");

                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l' style='text-align:right'>");

                sb.Append("PH:248370,248605");

                sb.Append("</td>");
                sb.Append("<hr>");

                sb.Append("<tr style='border-bottom:0.5px dotted'>");

                sb.Append("<td colspan='2'>");
                sb.Append(DS.Tables[0].Rows[0]["RouteCode"].ToString() + " ");
                sb.Append(DS.Tables[0].Rows[0]["RouteName"].ToString());
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l' colspan='4' style='text-align:center; border-bottom: 0px'>");
                sb.Append("<b><u> " + DS.Tables[0].Rows[0]["CategoryName"].ToString());
                sb.Append("</b></u></td>");


                sb.Append("<td class='tg-yw4l' colspan='2' style='text-align:right'>");
                sb.Append("Date : " + DateTime.Now.ToString("dd-MM-yyyy"));
                sb.Append("</td>");


                sb.Append("</tr>");

                sb.Append("<tr style='border-bottom:0.5px dotted'>");
                sb.Append("<td class='tg-yw4l' colspan='2' style='text-align:left'>");
                sb.Append("Driver : " + DS.Tables[0].Rows[0]["FirstDriver"].ToString());
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l' rowspan='2' colspan='2' style='text-align:center'>");
                sb.Append("GatePass ID: <b> GP" + id.ToString() + "</b>");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l' colspan='2' rowspan='2' style='text-align:center'>");
                sb.Append("Dispatch ID: <b> DS" + id.ToString() + "</b>");
                sb.Append("</td>");


                sb.Append("<td class='tg-yw4l' colspan='2' style='text-align:left'>");
                sb.Append("Salesman I: " + DS.Tables[0].Rows[0]["FirstSalesman"].ToString());
                sb.Append("</td>");
                sb.Append("</tr>");

                sb.Append("<tr style='border-bottom:0.5px dotted'>");
                sb.Append("<td class='tg-yw4l' colspan='2' style='text-align:left'>");
                sb.Append("Driver II : " + DS.Tables[0].Rows[0]["SecondDriver"].ToString());
                sb.Append("</td>");



                sb.Append("<td class='tg-yw4l' colspan='2' style='text-align:left'>");
                sb.Append("Salesman II : " + DS.Tables[0].Rows[0]["SecondSalesman"].ToString());
                sb.Append("</td>");
                sb.Append("</tr>");

                sb.Append("<tr  style='border-bottom:1px solid'>");
                sb.Append("<td class='tg-yw4l' colspan='2' style='text-align:left'>");
                sb.Append("Vehicle No: " + DS.Tables[0].Rows[0]["VehicleNo"].ToString());
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l' colspan='3' style='text-align:left'>");
                sb.Append("Starting Time: " + DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss"));
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l' colspan='3' style='text-align:left'>");
                sb.Append("Ending Time: ");
                sb.Append("</td>");
                sb.Append("</tr>");

                sb.Append("<tr style='border-bottom:1px solid'> <td colspan = '8'> &nbsp; </td> </tr>");

                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append("<td class='tg-yw4l' style='text-align:left'>");
                sb.Append("<b> Sr. No: </b> ");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l'  style='text-align:left'>");
                sb.Append("<b>Product Name </b>");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l' style='text-align:left'>");
                sb.Append("<b>Commodity </b>");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l'  style='text-align:center'>");
                sb.Append("<b>Quantity </b>");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l'  style='text-align:left'>");
                sb.Append("<b>Unit Type </b>");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l'  style='text-align:left'>");
                sb.Append("<b></b>");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l' style='text-align:left'>");
                sb.Append("<b> </b>");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l' style='text-align:left'>");
                sb.Append(" ");
                sb.Append("</td>");
                sb.Append("</tr>");

                int cnt = 1;
                foreach (DataRow row in DS.Tables[1].Rows)
                {
                    sb.Append("<tr style='border-bottom:0.5px dotted'>");
                    sb.Append("<td class='tg-yw4l' style='text-align:left'>");
                    sb.Append(cnt.ToString());
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l'  style='text-align:left'>");
                    sb.Append(row["ProductName"].ToString());
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l'  style='text-align:left'>");
                    sb.Append(row["CommodityName"].ToString());
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l'  style='text-align:center'>");
                    sb.Append(row["TotalQuantity"].ToString());
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l' style='text-align:left'>");
                    sb.Append(row["UnitName"].ToString());
                    sb.Append("</td>");


                    sb.Append("<td class='tg-yw4l' style='text-align:left'>");
                    sb.Append(" ");
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l' style='text-align:left'>");
                    sb.Append(" ");
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l' style='text-align:left'>");
                    sb.Append(" ");
                    sb.Append("</td>");
                    sb.Append("</tr>");

                    cnt++;
                }

                sb.Append("<tr style='border-bottom:1px solid'> <td colspan = '8'> &nbsp; </td> </tr>");

                sb.Append("<tr style='border-Top:1px Solid;border-bottom:0.5px dotted'>");


                sb.Append("<td class='tg-yw4l' rowspan='3' style='text-align:left'>");
                sb.Append("<b>Crates Particular </b>");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l'  style='text-align:left'>");
                sb.Append("<b>Item</b>");
                //sb.Append(DS.Tables[0].Rows[0]["ProductName"].ToString());
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l'  style='text-align:left'>");
                sb.Append("<b>Tray</b> ");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l'  style='text-align:left'>");
                sb.Append("<b>Ice Box</b>");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l' colspan='2' style='text-align:left'>");
                sb.Append("<b>Cartons/Ice Pad </b>");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l' colspan='2' style='text-align:left'>");
                sb.Append("<b>Others </b>");
                sb.Append("</td>");

                sb.Append("</tr>");

                sb.Append("<tr style='border-bottom:0.5px dotted'>");


                //sb.Append("<td class='tg-yw4l' rowspan='3' style='text-align:left'>");
                //sb.Append("Crates Perticular ");
                //sb.Append("</td>");

                sb.Append("<td class='tg-yw4l'  style='text-align:left'>");
                sb.Append("<b>Dispatch</b>");
                //sb.Append(DS.Tables[0].Rows[0]["ProductName"].ToString());
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l'  style='text-align:left'>");
                sb.Append(DS.Tables[0].Rows[0]["TraysDispached"].ToString());
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l'  style='text-align:left'>");
                sb.Append(DS.Tables[0].Rows[0]["IceBoxDispached"].ToString());
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l' colspan='2' style='text-align:left'>");
                sb.Append(DS.Tables[0].Rows[0]["CartonsDispached"].ToString());
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l' colspan='2' style='text-align:left'>");
                sb.Append(DS.Tables[0].Rows[0]["OtherDispached"].ToString());
                sb.Append("</td>");




                sb.Append("</tr>");

                sb.Append("<tr style='border-bottom:1px Solid'>");


                //sb.Append("<td class='tg-yw4l' rowspan='3' style='text-align:left'>");
                //sb.Append("Crates Perticular ");
                //sb.Append("</td>");

                sb.Append("<td class='tg-yw4l'  style='text-align:left'>");
                sb.Append("<b>Returned</b>");
                //sb.Append(DS.Tables[0].Rows[0]["ProductName"].ToString());
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l'  style='text-align:center'>");
                sb.Append("");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l'  style='text-align:Center'>");
                sb.Append("");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l' style='text-align:Center'>");
                sb.Append("");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l'  style='text-align:Center'>");
                sb.Append("");
                sb.Append("</td>");

                sb.Append("</tr>");

                sb.Append("<tr>");
                sb.Append("<td class='tg-yw4l' colspan='8' style='text-align:left'>");
                sb.Append("&nbsp;");
                sb.Append("</td>");
                sb.Append("</tr>");
                sb.Append("<tr>");
                sb.Append("<td class='tg-yw4l' colspan='8' style='text-align:left'>");
                sb.Append("&nbsp;");
                sb.Append("</td>");
                sb.Append("</tr>");
                sb.Append("<tr>");
                sb.Append("<td class='tg-yw4l' colspan='8' style='text-align:left'>");
                sb.Append("&nbsp;");
                sb.Append("</td>");
                sb.Append("</tr>");


                sb.Append("<tr>");
                sb.Append("<td class='tg-yw4l'  colspan='3' style='text-align:left'>");
                sb.Append("Dispatch Clerk ");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l'  colspan='2' style='text-align:center'>");
                sb.Append("Production Manager ");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l'  colspan='3' style='text-align:right'>");
                sb.Append("Sales Man ");
                sb.Append("</td>");
                sb.Append("</tr>");







                result = sb.ToString();
                GatePass.Text = result;
                //Session["ctrl"] = sb.ToString();
                Session["ctrl"] = pnlGatePass;
                //Response.Redirect("/print.aspx", true);
                upGatePass.Update();

            }
            else
            {
                result = "Order not FOund";
                GatePass.Text = result;

            }


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

        protected void btnNewDispatch_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewDispatchOrders.aspx");
        }
    }
}