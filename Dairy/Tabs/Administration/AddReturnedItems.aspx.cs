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

using System.Web.Services;



namespace Dairy.Tabs.Administration
{
    public partial class AddReturnedItems : System.Web.UI.Page
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

                //btnPrintSummary.Visible = false;
                //Button btnSubmitModal = (Button)FindControl("btnSubmitModal");
                //btnSubmitModal.Visible = false;
                // btnSubmitModal.Visible = false;
                txtOrderDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                //btnAddRoute.Visible = true;
                //btnupdateroute.Visible = false;
            }

        }



        protected void btnClick_btnSearch(object sender, EventArgs e)
        {

            Dispatch dispatch = new Dispatch();
            dispatch.DispatchDate = (Convert.ToDateTime(txtOrderDate.Text)).ToString("dd-MM-yyyy");
            //String.Format("{0:dd/MM/yyyy}", dispatch.OrderDate);
            dispatch.CategoryId = Convert.ToInt32(dpCategory.SelectedItem.Value);
            // dispatch.OrderDate = a.ToString();
            //dispatch.OrderDate = txtOrderDate.Text;
            // dispatch.AgentID = Convert.ToInt32(dpAgent.SelectedItem.Value);
            dispatch.RouteID = Convert.ToInt32(dpagentRoute.SelectedItem.Value);
            DispatchData dispatchData = new DispatchData();
            DataSet DS = new DataSet();
            StringBuilder sb = new StringBuilder();



            DS = dispatchData.GetDispatchByAgentID(dispatch);

            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                // int count = Convert.ToInt32(DS.Tables[1].Rows[0]["Id"]);
                //count = count + 1;
                //txtRouteCode.Text = string.Format("R{0:0000}", count);
                rpRouteList.DataSource = DS;
                rpRouteList.DataBind();
                rpRouteList.Visible = true;

                //btnSubmitModal.Visible = true;
                //btnPrintSummary.Visible = false;

                uprouteList.Update();

                // DS.WriteXml(Server.MapPath("~/Tabs/Dispatch/temp.xml"));

                //string str = DS.GetXml();
                //insertDispatchTemp(DS);

            }
            else { rpRouteList.Visible = false; uprouteList.Update(); }


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
            double temp = string.IsNullOrEmpty(txtDispQuantity.Text) ? 0 : Convert.ToDouble(txtDispQuantity.Text);
            disp.DispatchId = string.IsNullOrEmpty(txtHidden.Text) ? 0 : Convert.ToInt32(txtHidden.Text);
            //disp.Quantity = Convert.ToInt32(txtQuantity.Text);
            disp.ReturnSample = string.IsNullOrEmpty(txtSampleReturn.Text) ? 0 : Convert.ToDouble(txtSampleReturn.Text);
            disp.ReturnSpotDamage = string.IsNullOrEmpty(txtSpotDamaged.Text) ? 0 : Convert.ToDouble(txtSpotDamaged.Text);
            disp.ReturnGoodQuality = string.IsNullOrEmpty(txtGoodQuality.Text) ? 0 : Convert.ToDouble(txtGoodQuality.Text);
            if (disp.ReturnSample >= 0 && disp.ReturnSpotDamage >= 0 && disp.ReturnGoodQuality >= 0)
            {
                if (temp <= (disp.ReturnSample + disp.ReturnGoodQuality + disp.ReturnSpotDamage))
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                }
                else
                {
                    try
                    {

                        int result = 0;
                        DataSet ds = new DataSet();
                        result = dispatchData.updateReturnItems(disp);

                        if (result > 0)
                        {

                            ClearTextBox();

                            //updatelist();
                            //rpRouteList.Visible = false;

                            divDanger.Visible = false;
                            divwarning.Visible = false;
                            divSusccess.Visible = true;
                            lblSuccess.Text = "Information Updated  Successfully";



                            pnlError.Update();

                            //upMain.Update();
                            updatelist();
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
                    catch
                    {
                        lblwarning.Text = "Invalid entry";
                    }
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Enter Valid Quantity')", true);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
            }


        }


        private void updatelist()
        {
            DataSet DS = new DataSet();
            Dispatch dispatch = new Dispatch();
            dispatch.DispatchDate = (Convert.ToDateTime(txtOrderDate.Text)).ToString("dd-MM-yyyy");
            dispatch.RouteID = Convert.ToInt32(dpagentRoute.SelectedItem.Value);
            dispatch.CategoryId = Convert.ToInt32(dpCategory.SelectedItem.Value);
            DispatchData dispatchData = new DispatchData();

            DS = dispatchData.GetDispatchByAgentID(dispatch);

            if (!Comman.Comman.IsDataSetEmpty(DS))
            {

                rpRouteList.DataSource = DS;
                rpRouteList.DataBind();
                rpRouteList.Visible = true;


                uprouteList.Update();


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
                dpagentRoute.Items.Insert(0, new ListItem("--Select Agent Route  --", "0"));
            }
            DS.Clear();
            DS = new DataSet();
            DS = BindCommanData.BindCommanDropDwon("CategoryId ", "CategoryName as Name  ", "Category", "IsActive=1");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpCategory.DataSource = DS;
                dpCategory.DataBind();
                dpCategory.Items.Insert(0, new ListItem("--Select Brand--", "0"));
            }
        }
        public void ClearTextBox()
        {
            txtDispQuantity.Text = string.Empty;
            txtGoodQuality.Text = string.Empty;
            txtSampleReturn.Text = string.Empty;
            txtSpotDamaged.Text = string.Empty;
            txtAgentName.Text = string.Empty;
            txtCommodityName.Text = string.Empty;
            //txtOrderDate.Text = string.Empty;
            //txtOrderDetailsId.Text = string.Empty;
            //txtOrderID.Text = string.Empty;
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

                        GetRouteDetailsbyID(Agentid);
                        //btnAddRoute.Visible = false;
                        //btnupdateroute.Visible = true;
                        // upMain.Update();
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "<script type='text/javascript'> $('#myModal').modal('show'); </script>", false);
                        // uprouteList.Update();
                        //  upModal.Update();
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
            dispatch.OrderDate = (Convert.ToDateTime(txtOrderDate.Text)).ToString("dd-MM-yyyy");
            // dispatch.RouteID = Convert.ToInt32(dpagentRoute.SelectedItem.Value);

            DispatchData dispatchData = new DispatchData();
            DataSet DS = new DataSet();
            DS = dispatchData.getDetailsbyDDid(id);

            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                txtOrderID.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["OrderID"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["OrderID"].ToString();
                txtHidden.Text = id.ToString();
                //txtOrderDate.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["OrderDate"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["OrderDate"].ToString();
                txtDispQuantity.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["DD_NewQuantity"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["DD_NewQuantity"].ToString();
                txtSampleReturn.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["DD_ReturnSample"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["DD_ReturnSample"].ToString();
                txtGoodQuality.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["DD_ReturnGoodQuality"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["DD_ReturnGoodQuality"].ToString();
                txtSpotDamaged.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["DD_ReturnSpotDamaged"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["DD_ReturnSpotDamaged"].ToString();
                txtCommodityName.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["ProductName"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["ProductName"].ToString();
                txtAgentName.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["AgentName"].ToString()) ? DS.Tables[0].Rows[0]["EmployeeName"].ToString() : DS.Tables[0].Rows[0]["AgentName"].ToString();

            }
        }


        private void clearlist()
        {
            // DataSet dats = new DataSet();
            rpRouteList.Visible = false;
            // rpRouteList.DataBind();
            uprouteList.Update();
        }



        protected void btnFinalSubmit_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                Dispatch dispatch = new Dispatch();
                dispatch.DispatchDate = (Convert.ToDateTime(txtOrderDate.Text)).ToString("dd-MM-yyyy");
                dispatch.RouteID = Convert.ToInt32(dpagentRoute.SelectedItem.Value);
                DispatchData dispatchData = new DispatchData();
                DataSet DS = new DataSet();

                updateStock();

                DS = dispatchData.GetDetailsForSettlement(dispatch);
                DS.Tables[0].Columns.Add("ReceivedAmount", typeof(double));



                foreach (DataRow dr in DS.Tables[0].Rows)
                {

                    dr["ReceivedAmount"] = 0;

                }




                if (!Comman.Comman.IsDataSetEmpty(DS))
                {
                    string nm = GlobalInfo.UserName;
                    //DS.WriteXml(Server.MapPath("~/Tabs/Dispatch/Fsub"+ nm +".xml"));
                    string consString = ConfigurationManager.ConnectionStrings["projectConnection"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(consString))
                    {
                        using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                        {
                            //Set the database table name
                            sqlBulkCopy.DestinationTableName = "SettlementDb";

                            //[OPTIONAL]: Map the DataTable columns with that of the database table (dsColName, dbColName)
                            sqlBulkCopy.ColumnMappings.Add("DD_DispatchInfoId", "DispatchId");
                            //sqlBulkCopy.ColumnMappings.Add("OrderDetailsID", "DispatchDetailsId");
                            sqlBulkCopy.ColumnMappings.Add("DD_OrderId", "OrderId");
                            // sqlBulkCopy.ColumnMappings.Add("OrderDetailsId", "OrderDetailsId");
                            sqlBulkCopy.ColumnMappings.Add("AgentID", "AgentId");
                            sqlBulkCopy.ColumnMappings.Add("RouteID", "RouteId");
                            sqlBulkCopy.ColumnMappings.Add("AgentName", "AgentName");
                            sqlBulkCopy.ColumnMappings.Add("DispatchDate", "DispatchDate");
                            sqlBulkCopy.ColumnMappings.Add("OrderDate", "OrderDate");
                            sqlBulkCopy.ColumnMappings.Add("PaymentMode", "BillingType");
                            sqlBulkCopy.ColumnMappings.Add("RevisedBill", "FinalBillingAmount");
                            sqlBulkCopy.ColumnMappings.Add("ReceivedAmount", "ReceivedAmount");
                            //sqlBulkCopy.ColumnMappings.Add("Qty", "PendingFlag");
                            //sqlBulkCopy.ColumnMappings.Add("Qty", "BillingType");
                            con.Open();
                            sqlBulkCopy.WriteToServer(DS.Tables[0]);
                            con.Close();
                        }
                    }
                    clearlist();
                    divDanger.Visible = false;
                    divwarning.Visible = false;
                    divSusccess.Visible = true;
                    lblSuccess.Text = "Information Updated  Successfully";


                    pnlError.Update();

                    //upMain.Update();
                    uprouteList.Update();
                }

            }
        }

        private void updateStock()
        {
            Dispatch dispatch = new Dispatch();
            dispatch.DispatchDate = (Convert.ToDateTime(txtOrderDate.Text)).ToString("dd-MM-yyyy");
            dispatch.RouteID = Convert.ToInt32(dpagentRoute.SelectedItem.Value);
            DispatchData dispatchData = new DispatchData();
            DataSet DsStock = new DataSet();

            DsStock = dispatchData.GetStockFromDispatch(dispatch);

            if (!Comman.Comman.IsDataSetEmpty(DsStock))
            {
                string constr = ConfigurationManager.ConnectionStrings["projectConnection"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_StockUpdateReturn"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@tblStock", DsStock.Tables[0]);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
        }
    }
}
