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
    public partial class AddRount : System.Web.UI.Page
    {
        DataSet DS = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                BindRouteList();
                BindDropDwon();
                BindActiveAndDeactiveCount();
                btnAddRoute.Visible = true;
                btnupdateroute.Visible = false;
            }

        }

        private void BindActiveAndDeactiveCount()
        {
            DS = BindCommanData.GetAllActiveAndDeactiveCount("Userinfo", "Isactive");
            //if (DS.Tables[0].Rows.Count != 0)
            //    lblActiveCount.Text = DS.Tables[0].Rows[0]["Count"].ToString();
            //if (DS.Tables[1].Rows.Count != 0)
            //    lblDeactive.Text = DS.Tables[1].Rows[0]["Count"].ToString();
        }

        protected void btnClick_btnAddRoute(object sender, EventArgs e)
        {
            Route route = new Route();
            RouteData routeDate = new RouteData();
            route.RouteID = 0;
            route.RouteCode = txtRouteCode.Text;
            route.RouteName = txtrouteName.Text;
            route.ASOID = Convert.ToInt32(dpASOID.SelectedItem.Value);
            route.RouteDesc = txtdpRouteDesc.Text;
            route.Discription = txtDsicription.Text;
            route.CreatedBy = GlobalInfo.Userid;
            route.IsActive = true;
            route.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
            route.ModifiedBy = GlobalInfo.Userid;
            route.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");
            route.flag = "Insert";
            int Result = 0;
            Result = routeDate.InsertRoute(route);
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
        protected void btnClick_btnUpdate(object sender, EventArgs e)
        {

            Route route = new Route();
            RouteData routeDate = new RouteData();
            route.RouteID = string.IsNullOrEmpty(hfrouteID.Value) ? 0 : Convert.ToInt32(hfrouteID.Value);
            route.RouteCode = txtRouteCode.Text;
            route.RouteName = txtrouteName.Text;
            route.ASOID = Convert.ToInt32(dpASOID.SelectedItem.Value);
            route.IsActive = true;
            route.RouteDesc = txtdpRouteDesc.Text;
            route.Discription = txtDsicription.Text;
            route.CreatedBy = GlobalInfo.Userid;
            route.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
            route.ModifiedBy = GlobalInfo.Userid;
            route.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");
            route.flag = "Update";
            int Result = 0;
            Result = routeDate.InsertRoute(route);
            if (Result > 0)
            {
                lbltital.Text = "Add Route";
                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Route Updated  Successfully";
                ClearTextBox();
                BindRouteList();
                pnlError.Update();
                btnAddRoute.Visible = true;
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
        public void BindDropDwon()
        {

            DS = BindCommanData.BindCommanDropDwon("EmployeeID", "EmployeeCode+' '+EmployeeName as Name", "employeemaster", "IsArchive=0");
            dpASOID.DataSource = DS;
            dpASOID.DataBind();
            dpASOID.Items.Insert(0, new ListItem("--Select ASOID  --", "0"));

        }
        public void ClearTextBox()
        {
            txtrouteName.Text = string.Empty;
            txtDsicription.Text = string.Empty;
            dpASOID.ClearSelection();
            txtdpRouteDesc.Text = string.Empty;
        }
        public void BindRouteList()
        {

            RouteData routeDate = new RouteData();
            DataSet DS = new DataSet();
            StringBuilder sb = new StringBuilder();
            DS = routeDate.GetAllRouteDetails();
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                int count = Convert.ToInt32(DS.Tables[1].Rows[0]["id"]);
                count = count + 1;
                txtRouteCode.Text = string.Format("R{0:0000}", count);
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
            int routeID = 0;
            routeID = Convert.ToInt32(e.CommandArgument);
            switch (e.CommandName)
            {
                case ("Edit"):
                    {
                        lbltital.Text = "Edit Route";
                        hfrouteID.Value = routeID.ToString();
                        routeID = Convert.ToInt32(hfrouteID.Value);
                        //BindRouteList();
                        GetRouteDetailsbyID(routeID);
                        btnAddRoute.Visible = false;
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
            DS = routeDate.GetRouteDetailsbyID(routeID);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                txtRouteCode.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["routeCode"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["routeCode"].ToString();
                txtrouteName.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["RouteName"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["RouteName"].ToString();
                txtdpRouteDesc.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["RouteDesc"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["RouteDesc"].ToString();
                dpASOID.ClearSelection();
                if (dpASOID.Items.FindByValue(DS.Tables[0].Rows[0]["ASOid"].ToString()) != null)
                {
                    dpASOID.Items.FindByValue(DS.Tables[0].Rows[0]["ASOid"].ToString()).Selected = true;
                }
                txtDsicription.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Discription"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Discription"].ToString();


            }
        }
        public void DeleteRoutebyrouteID(int routeID)
        {

            Route route = new Route();
            RouteData routeDate = new RouteData();
            route.RouteID = string.IsNullOrEmpty(hfrouteID.Value) ? 0 : Convert.ToInt32(hfrouteID.Value);
            route.RouteCode = string.Empty;
            route.RouteName = string.Empty;
            route.ASOID = Convert.ToInt32(dpASOID.SelectedItem.Value);
            route.RouteDesc = string.Empty;
            route.CreatedBy = GlobalInfo.Userid;
            route.Discription = txtDsicription.Text;
            route.IsActive = false;
            route.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
            route.ModifiedBy = GlobalInfo.Userid;
            route.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");
            route.flag = "Delete";
            int Result = 0;
            Result = routeDate.InsertRoute(route);
            if (Result > 0)
            {

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Delete Updated  Successfully";
                ClearTextBox();
                BindRouteList();
                pnlError.Update();
                btnAddRoute.Visible = true;
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
    }
}