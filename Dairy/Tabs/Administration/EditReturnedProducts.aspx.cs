using Bussiness;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dairy.Tabs.Administration
{
    public partial class EditReturnedProducts : System.Web.UI.Page
    {
        DataSet DS;
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

      

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Dispatch dispatch = new Dispatch();
          
            dispatch.flag = "Edit";
            dispatch.DispatchId = Convert.ToInt32(txtDispatchId.Text);
            DispatchData dispatchData = new DispatchData();
            DataSet DS = new DataSet();
            
            DS = dispatchData.GetDispatchByAgentID(dispatch);

            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                
                rpRouteList.DataSource = DS;
                rpRouteList.DataBind();
                rpRouteList.Visible = true;
              
               uprouteList.Update();
                
            }
            else
            {
                DataTable dt = new DataTable();
                this.BindRepeater(dt);
                rpRouteList.Visible = true;
                uprouteList.Update();
            }


        }
        private void BindRepeater(DataTable dt)
        {
            rpRouteList.DataSource = dt;
            rpRouteList.DataBind();

            if (dt.Rows.Count == 0)
            {
                Control FooterTemplate = rpRouteList.Controls[rpRouteList.Controls.Count - 1].Controls[0];
                FooterTemplate.FindControl("trEmpty").Visible = true;
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
            
        }
     

        protected void btnSubmitModal_Click(object sender, EventArgs e)
        {
            Dispatch disp = new Dispatch();
            DispatchData dispatchData = new DispatchData();
            double temp = string.IsNullOrEmpty(txtDispQuantity.Text) ? 0 : Convert.ToDouble(txtDispQuantity.Text);
            disp.DispatchId = string.IsNullOrEmpty(txtHidden.Text) ? 0 : Convert.ToInt32(txtHidden.Text);
         
            disp.ReturnSample = string.IsNullOrEmpty(txtSampleReturn.Text) ? 0 : Convert.ToDouble(txtSampleReturn.Text);
            disp.ReturnSpotDamage = string.IsNullOrEmpty(txtSpotDamaged.Text) ? 0 : Convert.ToDouble(txtSpotDamaged.Text);
            disp.ReturnGoodQuality = string.IsNullOrEmpty(txtGoodQuality.Text) ? 0 : Convert.ToDouble(txtGoodQuality.Text);
            if (disp.ReturnSample >= 0 && disp.ReturnSpotDamage >= 0 && disp.ReturnGoodQuality >= 0)
            {
                if (temp < (disp.ReturnSample + disp.ReturnGoodQuality + disp.ReturnSpotDamage))
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
            
            dispatch.DispatchId = Convert.ToInt32(txtDispatchId.Text);
            DispatchData dispatchData = new DispatchData();
            dispatch.flag = "Edit";
            DS = dispatchData.GetDispatchByAgentID(dispatch);

            if (!Comman.Comman.IsDataSetEmpty(DS))
            {

                rpRouteList.DataSource = DS;
                rpRouteList.DataBind();
                rpRouteList.Visible = true;


                uprouteList.Update();


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
                       
                        GetRouteDetailsbyID(Agentid);
                        
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "<script type='text/javascript'> $('#myModal').modal('show'); </script>", false);
                        
                        break;
                    }
                


            }
        }
        public void GetRouteDetailsbyID(int id)
        {
            Dispatch dispatch = new Dispatch();
            
            
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
    }
}