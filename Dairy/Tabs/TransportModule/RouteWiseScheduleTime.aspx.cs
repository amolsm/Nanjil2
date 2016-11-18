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
    public partial class RouteWiseScheduleTime : System.Web.UI.Page
    {
        TransportData transportdata;
        Transports transport;
        DataSet DS;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDwon();
                GetScheduleInfo();
            }
            btnAddSchedule.Visible = true;
            btnUpdateSchedule.Visible = false;

        }

        protected void BindDropDwon()
        {
            DS = BindCommanData.BindCommanDropDwon("RouteID ", "RouteCode +' '+RouteName as Name  ", "routeMaster", "IsArchive=1 ");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpRoute.DataSource = DS;
                dpRoute.DataBind();
                dpRoute.Items.Insert(0, new ListItem("--Select Route  --", "0"));
            }
        }

        public void GetScheduleInfo()
        {
            transportdata = new TransportData();
            DataSet DS = new DataSet();
            DS = transportdata.GetScheduleInfo();

            if (!Comman.Comman.IsDataSetEmpty(DS))
            {

                rpSchedulelist.DataSource = DS;
                rpSchedulelist.DataBind();
            }
        }
        protected void btnClick_btnAddSchedule(object sender, EventArgs e)
        {
            transportdata = new TransportData();
            transport = new Transports();
            transport.ID = 0;
            transport.RouteID = Convert.ToInt32(dpRoute.SelectedItem.Value);
            transport.scheduleOuttime = txtScheduleOutTime.Text;
            transport.scheduleIntime = txtScheduleInTime.Text;

            transport.CreatedBy = GlobalInfo.Userid;
            transport.IsActive = true;
            transport.Createddate = DateTime.Now.ToString("dd-MM-yyyy");

            transport.flag = "Insert";
            int Result = 0;
            Result = transportdata.AddTransportScheduleInfo(transport);
            if (Result > 0)
            {

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Schedule  Added  Successfully";

                ClearTextBox();
                GetScheduleInfo();
                pnlError.Update();
                upMain.Update();
                uprouteList.Update();
            }
            else
            {
                divDanger.Visible = false;
                divwarning.Visible = true;
                divSusccess.Visible = false;
                if (Result == -2627)
                {
                    lblwarning.Text = "Data Already Exists";
                }
                else
                {
                    lblwarning.Text = "Please Contact to Site Admin";
                }
                pnlError.Update();

            }
        }
        protected void btnClick_btnUpdateSchedule(object sender, EventArgs e)
        {
            transportdata = new TransportData();
            transport = new Transports();
            transport.ID = string.IsNullOrEmpty(hfScheduleId.Value) ? 0 : Convert.ToInt32(hfScheduleId.Value);
            transport.RouteID = Convert.ToInt32(dpRoute.SelectedItem.Value);
            transport.scheduleOuttime = txtScheduleOutTime.Text;
            transport.scheduleIntime = txtScheduleInTime.Text;

            transport.CreatedBy = GlobalInfo.Userid;
            transport.IsActive = true;
            transport.Createddate = DateTime.Now.ToString("dd-MM-yyyy");

            transport.flag = "Update";
            int Result = 0;
            Result = transportdata.AddTransportScheduleInfo(transport);
            if (Result > 0)
            {

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Schedule  Updated  Successfully";

                ClearTextBox();
                GetScheduleInfo();
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

        protected void rpSchedulelist_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            divDanger.Visible = false;
            divwarning.Visible = false;
            divSusccess.Visible = false;
            pnlError.Update();
            int ID = 0;
            ID = Convert.ToInt32(e.CommandArgument);
            switch (e.CommandName)
            {
                case ("Edit"):
                    {
                        lblHeaderTab.Text = "Edit ScheduleTime";
                        hfScheduleId.Value = ID.ToString();
                        ID = Convert.ToInt32(hfScheduleId.Value);
                        GetScheduleByID(ID);
                       
                        btnAddSchedule.Visible = false;
                        btnUpdateSchedule.Visible = true;

                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }
                case ("delete"):
                    {

                        hfScheduleId.Value = ID.ToString();
                        ID = Convert.ToInt32(hfScheduleId.Value);
                        DeleteScheduleByID(ID);

                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }


            }
        }

        public void DeleteScheduleByID(int ID)
        {

            transportdata = new TransportData();
            transport = new Transports();
            transport.ID = Convert.ToInt32(ID);
            transport.RouteID = 0;
            transport.scheduleOuttime = string.Empty;
            transport.scheduleIntime = string.Empty;

            transport.CreatedBy = GlobalInfo.Userid;
            transport.IsActive = true;
            transport.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
         
            transport.flag = "Delete";
            int Result = 0;
            Result = transportdata.AddTransportScheduleInfo(transport);
            if (Result > 0)
            {

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Schedule Deleted  Successfully";

                ClearTextBox();
                GetScheduleInfo();
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
            dpRoute.ClearSelection();
            txtScheduleOutTime.Text=string.Empty;
            txtScheduleInTime.Text = string.Empty;
            dpIsActive.ClearSelection();
        }

        protected void btnClick_btnAddNew(object sender, EventArgs e)
        {
            Response.Redirect("~/Tabs/TransportModule/RouteWiseScheduleTime.aspx");
        }

        public void GetScheduleByID(int ID)
        {
            transportdata = new TransportData();
            DS = transportdata.GetScheduleByID(ID);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpRoute.ClearSelection();
                if (dpRoute.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["RouteId"]).ToString()) != null)
                {
                    dpRoute.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["RouteId"]).ToString()).Selected = true;
                }
                txtScheduleOutTime.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["ScheduleOutTime"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["ScheduleOutTime"].ToString();
                txtScheduleInTime.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["ScheduleInTime"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["ScheduleInTime"].ToString();
                dpIsActive.ClearSelection();
                if (DS.Tables[0].Rows[0]["IsActive"].ToString() == "True")
                {
                    dpIsActive.Items.FindByValue("1").Selected = true;
                }
                if (DS.Tables[0].Rows[0]["IsActive"].ToString() == "False")
                {
                    dpIsActive.Items.FindByValue("2").Selected = true;
                }

            }
        }
    }
}