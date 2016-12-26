using Bussiness;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dairy.Tabs.Administration
{
    public partial class EditReturnedTrays : System.Web.UI.Page
    {
        DataSet DS;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                BindDropDown();
                
            }
        }

        private void BindDropDown()
        {
            //DS = new DataSet();
            //DS = BindCommanData.BindCommanDropDwon("EmployeeID ", "EmployeeCode +' '+EmployeeName as Name  ", "EmployeeMaster", "IsActive=1 and Designation='Sales' ");
            //if (!Comman.Comman.IsDataSetEmpty(DS))
            //{
            //    dpSalesman.DataSource = DS;
            //    dpSalesman.DataBind();
            //    dpSalesman.Items.Insert(0, new ListItem("--Select First Salesman--", "0"));

            //    dpSalesman2.DataSource = DS;
            //    dpSalesman2.DataBind();
            //    dpSalesman2.Items.Insert(0, new ListItem("--Select Second Salesman--", "0"));

            //}

            //DS = new DataSet();
            //DS = BindCommanData.BindCommanDropDwon("DriverId", "Dr_Name as Name  ", "tblDriverDetails", "IsActive='True' ");
            //if (!Comman.Comman.IsDataSetEmpty(DS))
            //{
            //    dpDriver.DataSource = DS;
            //    dpDriver.DataBind();
            //    dpDriver.Items.Insert(0, new ListItem("--Select First Driver--", "0"));

            //    dpDriver2.DataSource = DS;
            //    dpDriver2.DataBind();
            //    dpDriver2.Items.Insert(0, new ListItem("--Select Second Driver--", "0"));

            //}
            //DS = new DataSet();
            //DS = BindCommanData.BindCommanDropDwon("TM_Id ", "VehicleNo as Name  ", "tblTransportMaster", "TM_Id is not null");
            //if (!Comman.Comman.IsDataSetEmpty(DS))
            //{
            //    dpVehicle.DataSource = DS;
            //    dpVehicle.DataBind();
            //    dpVehicle.Items.Insert(0, new ListItem("--Select Vehicle No--", "0"));
            //}
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Dispatch disp = new Dispatch();
            DispatchData dispatchData = new DispatchData();


            disp.DispatchId = string.IsNullOrEmpty(txtHidden.Text) ? 0 : Convert.ToInt32(txtHidden.Text);
            disp.Trays = string.IsNullOrEmpty(txtTraysReturn.Text) ? 0 : Convert.ToInt32(txtTraysReturn.Text);
            disp.Cartons = string.IsNullOrEmpty(txtCartonsReturn.Text) ? 0 : Convert.ToInt32(txtCartonsReturn.Text);
            disp.IceBox = string.IsNullOrEmpty(txtIceBoxReturn.Text) ? 0 : Convert.ToInt32(txtIceBoxReturn.Text);
            disp.OtherDisp = string.IsNullOrEmpty(txtOtherReturn.Text) ? 0 : Convert.ToInt32(txtOtherReturn.Text);

            //disp.Quantity = Convert.ToInt32(txtQuantity.Text);

            DS = dispatchData.GetDispatchByID(disp.DispatchId, "Edit");
            int trays = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["TraysDispached"].ToString()) ? 0 : Convert.ToInt32(DS.Tables[0].Rows[0]["TraysDispached"]);
            int icebox = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["IceBoxDispached"].ToString()) ? 0 : Convert.ToInt32(DS.Tables[0].Rows[0]["IceBoxDispached"]);
            int cartons = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["CartonsDispached"].ToString()) ? 0 : Convert.ToInt32(DS.Tables[0].Rows[0]["CartonsDispached"]);
            int other = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["OtherDispached"].ToString()) ? 0 : Convert.ToInt32(DS.Tables[0].Rows[0]["OtherDispached"]);

            int result = 0;

            if (disp.IceBox >= 0 && disp.Trays >= 0 && disp.Cartons >= 0 && disp.OtherDisp >= 0)
            {
                //    if (disp.IceBox <= icebox && disp.Trays <= trays && disp.Cartons <= cartons && disp.OtherDisp <= other)
                //    {

                DataSet ds = new DataSet();
                result = dispatchData.updateReturnTrays(disp);
                //}
                //else
                //{
                //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Enter Valid Quantity')", true);
                //}
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

        private void ClearTextBox()
        {
            txtTraysReturn.Text = string.Empty;
            txtIceBoxReturn.Text = string.Empty;
            txtCartonsReturn.Text = string.Empty;
            txtOtherReturn.Text = string.Empty;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Dispatch dispatch = new Dispatch();

            int id = 0;
            id = Convert.ToInt32(txtDispatchId.Text);

            DispatchData dispatchData = new DispatchData();
            DataSet DS = new DataSet();
            
            DS = dispatchData.GetDispatchByID(id, "Edit");

            if (!Comman.Comman.IsDataSetEmpty(DS))
            {

                rpRouteList.DataSource = DS;
                rpRouteList.DataBind();
                rpRouteList.Visible = true;


                uprouteList.Update();


            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "1", "alert('No record found');", true);
            }
        }

        protected void rpRouteList_ItemCommand(object source, RepeaterCommandEventArgs e)
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
                       
                        hfRow.Value = Agentid.ToString();
                        Agentid = Convert.ToInt32(hfRow.Value);
                       
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myBox", "<script type='text/javascript'> $('#myBox').removeClass('collapsed-box'); </script>", false);
                        GetRouteDetailsbyID(Agentid);
                        
                        uprouteList.Update();
                        break;
                    }
               
            }
        }

        private void GetRouteDetailsbyID(int id)
        {
            Dispatch dispatch = new Dispatch();


            DispatchData dispatchData = new DispatchData();
            DataSet DS = new DataSet();
            StringBuilder sb = new StringBuilder();



            DS = dispatchData.GetDispatchByID(id, "Edit");

            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                txtTraysReturn.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["TraysReturned"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["TraysReturned"].ToString();
                txtIceBoxReturn.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["IceBoxReturned"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["IceBoxReturned"].ToString();
                txtCartonsReturn.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["CartonsReturned"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["CartonsReturned"].ToString();
                txtOtherReturn.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["OtherReturned"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["OtherReturned"].ToString();
                txtHidden.Text = id.ToString();

            }
        }

        
    }
}