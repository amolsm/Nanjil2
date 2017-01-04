using Bussiness;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dairy.Tabs.Administration
{
    public partial class Cashier : System.Web.UI.Page
    {
        DataSet DS = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                BindDropDwon();
            }

        }
        public void BindDropDwon()
        {
            DS = BindCommanData.BindCommanDropDwon("RouteID ", "RouteCode +' '+RouteName as Name  ", "routeMaster", "IsArchive=1 ");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpagentRoute.DataSource = DS;
                dpagentRoute.DataBind();
                dpagentRoute.Items.Insert(0, new ListItem("--Select Agent Route  --", "0"));
            }
         
        }

        protected void dpagentRoute_SelectedIndexChanged(object sender, EventArgs e)
        {
            DS = BindCommanData.BindTypeDropDwon("distinct EmployeeId", "EmployeeCode+' '+EmployeeName as Name", "DispatchInfo", "EmployeeMaster", "DispatchInfo.DI_SalesmanFirstId = EmployeeMaster.EmployeeId", "DispatchInfo.DI_RouteId =" + Convert.ToInt32(dpagentRoute.SelectedItem.Value));

           
            dpSalesman.DataSource = DS;
            dpSalesman.DataBind();
            dpSalesman.Items.Insert(0, new ListItem("--Select SalesMan  --", "0"));
           
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            DispatchData dispatchData = new DispatchData();
            string Date = Convert.ToDateTime(txtOrderDate.Text).ToString("dd-MM-yyyy");
            int routeid = Convert.ToInt32(dpagentRoute.SelectedItem.Value);
            int salesmanid = Convert.ToInt32(dpSalesman.SelectedItem.Value);
            ds = dispatchData.GetCashier(Date,routeid,salesmanid);
            DataSet tds = new DataSet();
            DataTable tbl = new DataTable();

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        protected void rpRouteList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }
    }
}