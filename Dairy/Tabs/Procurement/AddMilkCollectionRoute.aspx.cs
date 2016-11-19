using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Bussiness;
using Model;
using System.Text;

namespace Dairy.Tabs.Procurement
{
    public partial class AddMilkCollectionRoute : System.Web.UI.Page
    {
        DataSet DS = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindRouteList();
                BindDropDwon();
                btnAddRout.Visible = true;
                btnupdateroute.Visible = false;
            }
        }
        public void BindDropDwon()
        {
            DS = BindCommanData.BindCommanDropDwon("EmployeeID", "EmployeeCode as Code,EmployeeName as Name", "EmployeeMaster", "EmployeeID is not null");

            DS.Tables[0].Columns.Add("StreetAndPlace", typeof(string), "Code +'-'+ Name");
            dpASOID.DataSource = DS;
            dpASOID.DataTextField = "StreetAndPlace";
            dpASOID.DataBind();
            dpASOID.Items.Insert(0, new ListItem("--Select ASOID  --", "0"));

            DS = BindCommanData.BindCommanDropDwon("CenterID ", "CenterCode +' '+CenterName as Name  ", "tbl_MilkCollectionCenter", "IsActive=1 ");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpCenter.DataSource = DS;
                dpCenter.DataBind();
                dpCenter.Items.Insert(0, new ListItem("--Select Center  --", "0"));
            }
            DS = BindCommanData.BindCommanDropDwon("ID ", "QCat as Name", "Proc_tblIncentiveTariff", "IsActive=1");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpIncentiveTariff.DataSource = DS;
                dpIncentiveTariff.DataBind();
                dpIncentiveTariff.Items.Insert(0, new ListItem("--Select Incentive Tariff  --", "0"));
            }

        }

        protected void btnAddRout_Click(object sender, EventArgs e)
        {
            Route route = new Route();
            RouteData routeDate = new RouteData();
            route.RouteID = 0;
            route.RouteCode = txtRouteCode.Text;
            route.CenterID = Convert.ToInt32(dpCenter.SelectedValue);
            route.RouteName = txtRouteName.Text;
            route.ASOID = Convert.ToInt32(dpASOID.SelectedItem.Value);
            route.Category = Convert.ToInt32(Category.SelectedItem.Value);
            route.RouteDesc = txtRouteDescription.Text;
            route.Discription = txtDesc.Text;
            route.QIncentiveId = Convert.ToInt32(dpIncentiveTariff.SelectedItem.Value);
            route.CreatedBy = App_code.GlobalInfo.Userid;
            if (DropDownList1.SelectedValue == "1")
            {
                route.IsActive = true;
            }
            else if (DropDownList1.SelectedValue == "2")
            {
                route.IsActive = false;
            }
            route.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
            route.ModifiedBy = App_code.GlobalInfo.Userid;
            route.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");
            route.flag = "Insert";
            int Result = 0;
            Result = routeDate.InsertMilkCollectionRoute(route);
            if (Result > 0)
            {

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Route Add  Successfully";

                ClearTextBox();
                BindRouteList();
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
            txtRouteName.Text = string.Empty;
            dpCenter.ClearSelection();
            txtRouteDescription.Text = string.Empty;
            dpASOID.ClearSelection();
            txtDesc.Text = string.Empty;
        }
        public void BindRouteList()
        {

            RouteData routeDate = new RouteData();
            DataSet DS = new DataSet();
            StringBuilder sb = new StringBuilder();
            DS = routeDate.GetAllMilkCollectionRouteDetails();
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                if (!string.IsNullOrEmpty(DS.Tables[1].Rows[0]["id"].ToString()))
                {
                    int count = Convert.ToInt32(DS.Tables[1].Rows[0]["id"]);
                    count = count + 1;
                    txtRouteCode.Text = string.Format("R{0:0000}", count);
                    txtRouteCode.ReadOnly = true;
                    rpRouteList.DataSource = DS;
                    rpRouteList.DataBind();
                }
                else
                {
                    int count = 1;
                    txtRouteCode.Text = string.Format("R{0:0000}", count);
                    txtRouteCode.ReadOnly = true;
                }
            }
        }

        protected void rpRouteList_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {

            divDanger.Visible = false;
            divwarning.Visible = false;
            divSusccess.Visible = false;
            pnlError.Update();
            int routeID = 0;
            routeID = Convert.ToInt32(e.CommandArgument);
            switch (e.CommandName)
            {
                case ("Edit"):
                    {
                        //lbltital.Text = "Edit Route";
                        hfrouteID.Value = routeID.ToString();
                        routeID = Convert.ToInt32(hfrouteID.Value);
                        //BindRouteList();
                        GetRouteDetailsbyID(routeID);
                        btnAddRout.Visible = false;
                        btnupdateroute.Visible = true;
                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }
                case ("delete"):
                    {

                        hfrouteID.Value = routeID.ToString();
                        routeID = Convert.ToInt32(hfrouteID.Value);
                        DeleteRoutebyrouteID(routeID);
                        BindRouteList();
                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }


            }
        }


        public void GetRouteDetailsbyID(int routeID)
        {
            DataSet DS = new DataSet();
            RouteData routeDate = new RouteData();
            DS = routeDate.GetMilkCollectionRouteDetailsbyID(routeID);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                txtRouteCode.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["routeCode"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["routeCode"].ToString();
                txtRouteName.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["RouteName"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["RouteName"].ToString();
                txtRouteDescription.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["RouteDesc"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["RouteDesc"].ToString();
                dpCenter.ClearSelection();
                if (dpCenter.Items.FindByValue(DS.Tables[0].Rows[0]["CenterID"].ToString()) != null)
                {
                    dpCenter.Items.FindByValue(DS.Tables[0].Rows[0]["CenterID"].ToString()).Selected = true;
                }
                dpASOID.ClearSelection();
                if (dpASOID.Items.FindByValue(DS.Tables[0].Rows[0]["ASOid"].ToString()) != null)
                {
                    dpASOID.Items.FindByValue(DS.Tables[0].Rows[0]["ASOid"].ToString()).Selected = true;
                }
                Category.ClearSelection();
                if (Category.Items.FindByValue(DS.Tables[0].Rows[0]["Category"].ToString()) != null)
                {
                    Category.Items.FindByValue(DS.Tables[0].Rows[0]["Category"].ToString()).Selected = true;
                }
                dpIncentiveTariff.ClearSelection();
                if (dpIncentiveTariff.Items.FindByValue(DS.Tables[0].Rows[0]["QIncentivtariffid"].ToString()) != null)
                {
                    dpIncentiveTariff.Items.FindByValue(DS.Tables[0].Rows[0]["QIncentivtariffid"].ToString()).Selected = true;
                }
                txtDesc.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Discription"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Discription"].ToString();
                if (DS.Tables[0].Rows[0]["IsActive"].ToString()=="1")
                {
                    DropDownList1.Items.FindByValue("1").Selected = true;
                }
                else if (DS.Tables[0].Rows[0]["IsActive"].ToString() == "0")
                {
                    DropDownList1.Items.FindByValue("2").Selected = true;
                }

            }
        }
        public void DeleteRoutebyrouteID(int routeID)
        {

            Route route = new Route();
            RouteData routeDate = new RouteData();
            route.RouteID = string.IsNullOrEmpty(hfrouteID.Value) ? 0 : Convert.ToInt32(hfrouteID.Value);
            route.RouteCode = string.Empty;
            route.CenterID = 0;
            route.RouteName = string.Empty;
            route.ASOID = Convert.ToInt32(dpASOID.SelectedItem.Value);
            route.Category = Convert.ToInt32(Category.SelectedItem.Value);
            route.RouteDesc = string.Empty;
            route.QIncentiveId = Convert.ToInt32(dpIncentiveTariff.SelectedItem.Value);
            route.CreatedBy = App_code.GlobalInfo.Userid;
            route.Discription = string.Empty;
            route.IsActive = false;
            route.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
            route.ModifiedBy = App_code.GlobalInfo.Userid;
            route.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");
            route.flag = "Delete";
            int Result = 0;
            Result = routeDate.InsertMilkCollectionRoute(route);
            if (Result > 0)
            {

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Delete Updated  Successfully";
                ClearTextBox();
                BindRouteList();
                pnlError.Update();
                btnAddRout.Visible = true;
                btnupdateroute.Visible = false;
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
        protected void btnupdateroute_Click(object sender, EventArgs e)
        {
            Route route = new Route();
            RouteData routeDate = new RouteData();
            route.RouteID = string.IsNullOrEmpty(hfrouteID.Value) ? 0 : Convert.ToInt32(hfrouteID.Value);
            route.RouteCode = txtRouteCode.Text;
            route.CenterID = Convert.ToInt32(dpCenter.SelectedValue);
            route.RouteName = txtRouteName.Text;
            route.ASOID = Convert.ToInt32(dpASOID.SelectedItem.Value);
            route.Category = Convert.ToInt32(Category.SelectedItem.Value);
            if (DropDownList1.SelectedValue == "1")
            {
                route.IsActive = true;
            }
            else if (DropDownList1.SelectedValue == "2")
            {
                route.IsActive = false;
            }
            route.RouteDesc = txtRouteDescription.Text;
            route.Discription = txtDesc.Text;
            route.QIncentiveId = Convert.ToInt32(dpIncentiveTariff.SelectedItem.Value);
            route.CreatedBy = App_code.GlobalInfo.Userid;
            route.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
            route.ModifiedBy = App_code.GlobalInfo.Userid;
            route.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");
            route.flag = "Update";
            int Result = 0;
            Result = routeDate.InsertMilkCollectionRoute(route);
            if (Result > 0)
            {
                //lbltital.Text = "Add Route";
                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Route Updated  Successfully";
                ClearTextBox();
                BindRouteList();
                pnlError.Update();
                btnAddRout.Visible = true;
                btnupdateroute.Visible = false;
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

        protected void dpCenter_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet DS = new DataSet();
            RouteData routeDate = new RouteData();
            DS = routeDate.GetAllMilkCollectionRouteDetails();
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                foreach(DataRow row in DS.Tables[0].Rows)
                {
                    if (row["RouteName"].ToString() == txtRouteName.Text.Trim().ToString() && row["CenterID"].ToString() == dpCenter.SelectedItem.Value.ToString())
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('RouteName Already Available on this Center')", true);
                        dpCenter.ClearSelection();
                    }
                }
            }

            }
    }
}