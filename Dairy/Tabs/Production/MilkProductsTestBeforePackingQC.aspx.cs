using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using Model.Production;
using System.Data;
using DataAccess.Production;
using Bussiness.Production;
using System.Text;
using Comman;
using Dairy.App_code;
using Dairy;
using Bussiness;

namespace Dairy.Tabs.Production
{
    public partial class MilkProductstestBeforePackingQC : System.Web.UI.Page
    {
        MMilkProductsTestBeforePackingQC mmptbpqc;
        BMilkProductsTestBeforePackingQC bmptbpqc;
        DataSet DS = new DataSet();
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDwon();
                txtDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                txtSearchDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                //GetMilkProductsTestBeforePackingQCDetails();
                txtBatchNo.ReadOnly = true;
                btnUpdate.Visible = false;
            }
        }

        protected void BindDropDwon()
        {
            DS = new DataSet();
            DS = BindCommanData.BindCommanDropDwon("ShiftId", "ShiftName as Name", "ShiftMaster", "IsActive =1");
            dpShiftDetails.DataSource = DS;
            dpShiftDetails.DataBind();
            dpShiftDetails.Items.Insert(0, new ListItem("--Select Shift--", "0"));

            DS = BindCommanData.BindCommanDropDwon("QCId", "Status as Name", "QCDetails", "IsActive =1");

            dpQCStatusId.DataSource = DS;
            dpQCStatusId.DataBind();
            dpQCStatusId.Items.FindByText("Pending").Enabled = false;
            dpQCStatusId.Items.FindByText("Re-Chilling").Enabled = false;
            dpQCStatusId.Items.Insert(0, new ListItem("--Select Status--", "0"));
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            {

                mmptbpqc = new MMilkProductsTestBeforePackingQC();
                bmptbpqc = new BMilkProductsTestBeforePackingQC();
                int Result = 0;
                mmptbpqc.MilkProductsTestBeforePackingQCId = 0;
                mmptbpqc.RMRId = string.IsNullOrEmpty(hId.Value) ? 0 : Convert.ToInt32(hId.Value);
                mmptbpqc.MilkProductsTestBeforePackingQCDate = Convert.ToDateTime(txtDate.Text.ToString());
                mmptbpqc.MilkProductsTestBeforePackingQCShiftId = Convert.ToInt32(dpShiftDetails.SelectedItem.Value);
                mmptbpqc.Particular =string.IsNullOrEmpty(txtparticular.Text) ? string.Empty : txtparticular.Text;
                mmptbpqc.Quantity = string.IsNullOrEmpty(txtQuantity.Text) ? 0 : Convert.ToDouble(txtQuantity.Text);
                mmptbpqc.TestName = string.IsNullOrEmpty(txtTestName.Text) ? string.Empty : txtTestName.Text;
                mmptbpqc.Result=string.IsNullOrEmpty(txtResult.Text) ? string.Empty : txtResult.Text;
                mmptbpqc.Remarks=string.IsNullOrEmpty(txtRemarks.Text) ? string.Empty : txtRemarks.Text;
                mmptbpqc.MilkProdTestBeforePackingQCStatusId = Convert.ToInt32(dpQCStatusId.SelectedItem.Value);
                mmptbpqc.flag = "Insert";
                Result = bmptbpqc.milkproductdata(mmptbpqc);
                if (Result > 0)
                {
                    divDanger.Visible = false;
                    divwarning.Visible = false;
                    divSusccess.Visible = true;
                   
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "sel3", "$('#bx1').addClass('collapsed-box');", true);

                    //string dates;
                    //dates = string.IsNullOrEmpty(txtSearchDate.Text) ? string.Empty : Convert.ToDateTime(txtSearchDate.Text).ToString("dd-MM-yyyy");
                    //GetMilkProductsTestBeforePackingQCDetails(dates);
                    RMRecieve R = new RMRecieve();
                    R.RMRDate = Convert.ToDateTime(txtSearchDate.Text);
                    GetMilkProductsTestBeforePackingQCDetails(R);
                    uprouteList.Update();
                    lblSuccess.Text = "Milk Packing QC Data Added Successfully";
                    pnlError.Update();
                }
                else
                {
                    divDanger.Visible = false;
                    divwarning.Visible = true;
                    divSusccess.Visible = false;
                    lblSuccess.Text = "Something went wrong plz contact site admin";
                    pnlError.Update();
                }

                //return Result;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            {

                mmptbpqc = new MMilkProductsTestBeforePackingQC();
                bmptbpqc = new BMilkProductsTestBeforePackingQC();
                int Result = 0;
                mmptbpqc.MilkProductsTestBeforePackingQCId = 0;
                mmptbpqc.RMRId = string.IsNullOrEmpty(hId.Value) ? 0 : Convert.ToInt32(hId.Value);
                mmptbpqc.MilkProductsTestBeforePackingQCDate = Convert.ToDateTime(txtDate.Text.ToString());
                mmptbpqc.MilkProductsTestBeforePackingQCShiftId = Convert.ToInt32(dpShiftDetails.SelectedItem.Value);
                mmptbpqc.Particular = string.IsNullOrEmpty(txtparticular.Text) ? string.Empty : txtparticular.Text;
                mmptbpqc.Quantity = string.IsNullOrEmpty(txtQuantity.Text) ? 0 : Convert.ToDouble(txtQuantity.Text);
                mmptbpqc.TestName = string.IsNullOrEmpty(txtTestName.Text) ? string.Empty : txtTestName.Text;
                mmptbpqc.Result = string.IsNullOrEmpty(txtResult.Text) ? string.Empty : txtResult.Text;
                mmptbpqc.Remarks = string.IsNullOrEmpty(txtRemarks.Text) ? string.Empty : txtRemarks.Text;
                mmptbpqc.MilkProdTestBeforePackingQCStatusId = Convert.ToInt32(dpQCStatusId.SelectedItem.Value);
                mmptbpqc.flag = "Update";
                Result = bmptbpqc.milkproductdata(mmptbpqc);
                if (Result > 0)
                {
                    divDanger.Visible = false;
                    divwarning.Visible = false;
                    divSusccess.Visible = true;
                 
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "sel3", "$('#bx1').addClass('collapsed-box');", true);
                  
                    //string dates;
                    //dates = string.IsNullOrEmpty(txtSearchDate.Text) ? string.Empty : Convert.ToDateTime(txtSearchDate.Text).ToString("dd-MM-yyyy");
                    //GetMilkProductsTestBeforePackingQCDetails(dates);
                    RMRecieve R = new RMRecieve();
                    R.RMRDate = Convert.ToDateTime(txtSearchDate.Text);
                    GetMilkProductsTestBeforePackingQCDetails(R);
                    uprouteList.Update();
                    lblSuccess.Text = "Milk Packing QC Data Updated Successfully";
                    pnlError.Update();
                }
                else
                {
                    divDanger.Visible = false;
                    divwarning.Visible = true;
                    divSusccess.Visible = false;
                    lblSuccess.Text = "Something went wrong plz contact site admin";
                    pnlError.Update();
                }

                //return Result;
            }
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void rpMilkBeforePackingQC_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            divDanger.Visible = false;
            divwarning.Visible = false;
            divSusccess.Visible = false;
            pnlError.Update();
            int Id = 0;
            Id = Convert.ToInt32(e.CommandArgument);
            switch (e.CommandName)
            {
                case ("Edit"):
                    {
                        
                        hId.Value = Id.ToString();
                        Id = Convert.ToInt32(hId.Value);
                        GetMilkProductsTestBeforePackingQCDetails(Id);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "sel3", "$('#bx1').removeClass('collapsed-box');", true);
                        if (dpQCStatusId.SelectedIndex == 0)
                        {
                            lblHeaderTab.Text = "Add FilmData Details";
                            btnAdd.Visible = true;
                            btnUpdate.Visible = false;
                        }
                        else
                        {
                            lblHeaderTab.Text = "Edit FilmData Details";
                            btnAdd.Visible = false;
                            btnUpdate.Visible = true;
                        }
                        btnRefresh.Visible = true;
                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }
            }
        }

        public void GetMilkProductsTestBeforePackingQCDetails(RMRecieve R)
        {
            bmptbpqc = new BMilkProductsTestBeforePackingQC();
            DataSet DS = new DataSet();
            DS = bmptbpqc.GetMilkProductsTestBeforePackingQCDetails(R);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                rpMilkBeforePackingQC.DataSource = DS;
                rpMilkBeforePackingQC.DataBind();
            }
            else
            {
                rpMilkBeforePackingQC.DataSource = DS;
                rpMilkBeforePackingQC.DataBind();
            }
        }

        public void GetMilkProductsTestBeforePackingQCDetails(int RMRId)
        {
            DataSet DS = new DataSet();
            bmptbpqc = new BMilkProductsTestBeforePackingQC();
            DS = bmptbpqc.GetMilkProductsTestBeforePackingQCDetailsById(RMRId);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                string DATE = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["MilkProductsTestBeforePackingQCDate"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["MilkProductsTestBeforePackingQCDate"].ToString();
                //sky
                if (DATE == "")
                {
                    txtDate.Text = Convert.ToString(DateTime.Now.ToString("yyy-MM-dd"));
                }
                else
                {
                    DateTime date1 = Convert.ToDateTime(DATE, System.Globalization.CultureInfo.GetCultureInfo("ur-PK").DateTimeFormat);
                    txtDate.Text = (Convert.ToDateTime(date1).ToString("yyyy-MM-dd"));
                }
                txtBatchNo.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["BatchNo"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["BatchNo"].ToString();
                dpShiftDetails.ClearSelection();
                string Shift = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["MilkProductsTestBeforePackingQCShiftId"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["MilkProductsTestBeforePackingQCShiftId"].ToString();
                if (Shift == "")
                {
                    dpShiftDetails.SelectedIndex = 0;
                }
                else
                {
                    dpShiftDetails.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["MilkProductsTestBeforePackingQCShiftId"]).ToString()).Selected = true;
                }
                txtparticular.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Particular"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Particular"].ToString();
                txtQuantity.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Quantity"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Quantity"].ToString();
                txtTestName.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["TestName"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["TestName"].ToString();
                txtResult.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Result"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Result"].ToString();
                txtRemarks.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Remarks"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Remarks"].ToString();

                dpQCStatusId.ClearSelection();
                string QCStatusId = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["MilkProdTestBeforePackingQCStatusId"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["MilkProdTestBeforePackingQCStatusId"].ToString();
                if(QCStatusId=="")
                {
                    dpQCStatusId.SelectedIndex = 0;
                }
                else
                {
                    dpQCStatusId.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["MilkProdTestBeforePackingQCStatusId"]).ToString()).Selected = true;
                }
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                //string dates = Convert.ToDateTime(txtSearchDate.Text).ToString("dd-MM-yyyy");
                //GetMilkProductsTestBeforePackingQCDetails(dates);
                RMRecieve R = new RMRecieve();
                ProductionData PD = new ProductionData();
                R.RMRDate = Convert.ToDateTime(txtSearchDate.Text);
                GetMilkProductsTestBeforePackingQCDetails(R);
            }
            catch (Exception)
            {

            }
        }
    }
}