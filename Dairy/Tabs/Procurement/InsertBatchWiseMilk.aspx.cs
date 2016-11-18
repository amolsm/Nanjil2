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
    public partial class InsertBatchWiseMilk : System.Web.UI.Page
    {
        DataSet DS = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //BindMilkCollectionList();
                BindDropDwon();
                btnAddMilk.Visible = true;
                btnupdateMilk.Visible = false;
            }
        }

        public void BindDropDwon()
        {

            RouteData routeData = new RouteData();
            DS = BindCommanData.BindCommanDropDwon("RouteID ", "RouteCode +' '+RouteName as Name  ", "Proc_MilkCollectionRoute", "IsActive=1 ");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpRoute.DataSource = DS;
                dpRoute.DataBind();
                dpRoute.Items.Insert(0, new ListItem("--Select Route  --", "0"));
            }

            DS = BindCommanData.BindCommanDropDwon("CenterID ", "CenterCode +' '+CenterName as Name  ", "tbl_MilkCollectionCenter", "IsActive=1 ");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpCenter.DataSource = DS;
                dpCenter.DataBind();
                dpCenter.Items.Insert(0, new ListItem("--Select Center  --", "0"));
            }
        }

        protected void txtMilkInKG_TextChanged(object sender, EventArgs e)
        {
            txtMilkInLtr.Text = System.Math.Round((Convert.ToDouble(txtMilkInKG.Text) / 1.031), 2).ToString();
        }

        protected void btnAddMilk_Click(object sender, EventArgs e)
        {
            Model.Procurement p = new Model.Procurement();
            ProcurementData pd = new ProcurementData();
            if (rdRecieving.Checked)
            {
                p.flag1 = "Receiving";
            }
            else
            {
                p.flag1 = "Disposal";
            }
            p.BatchWiseMilkCollectionID = 0;
            p.BatchWiseMilkDisposalID = 0;
            p.BatchNo = txtBatch.Text;
            p.VehicleNo = txtVehicalNo.Text;
            p.Session = dpSession.SelectedItem.Text;
            p.Date = Convert.ToDateTime(txtDate.Text);
            p.MilkInKG = Convert.ToDecimal(txtMilkInKG.Text);
            p.ActualMilkInLtr = Convert.ToDecimal(txtMilkInLtr.Text);
            p.RouteID = Convert.ToInt32(dpRoute.SelectedItem.Value);
            p.CenterID = Convert.ToInt32(dpCenter.SelectedItem.Value);
            p.Temp = Convert.ToDecimal(txtTEmp.Text);
            p.Acidity = Convert.ToDecimal(txtAcidity.Text);
            p.FATPercentage = Convert.ToDecimal(txtFATPercentage.Text);
            p.SNFPercentage = Convert.ToDecimal(txtSNFPercentage.Text);
            p.CreatedBy = App_code.GlobalInfo.Userid;
            p.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
            p.ModifiedBy = App_code.GlobalInfo.Userid;
            p.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");
            p.flag = "Insert";

            DS = pd.GetOpeningClosingBal(p.Date,p.CenterID);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                p.BalanceID = Convert.ToInt32(string.IsNullOrEmpty(DS.Tables[0].Rows[0]["BalanceID"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["BalanceID"].ToString());
                decimal OpeningBal =Convert.ToDecimal(string.IsNullOrEmpty(DS.Tables[0].Rows[0]["OpeningBalance"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["OpeningBalance"].ToString());
                decimal ClosingBal = Convert.ToDecimal(string.IsNullOrEmpty(DS.Tables[0].Rows[0]["ClosingBalance"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["ClosingBalance"].ToString());
                if (rdRecieving.Checked)
                {
                    p.ClosingBalance = ClosingBal + p.ActualMilkInLtr;
                }
                else
                {
                    p.ClosingBalance = ClosingBal - p.ActualMilkInLtr;
                }
                p.flag2 = "Update";
            }
            else
            {
                DateTime PrevDate = p.Date.AddDays(-1);
                DS = pd.GetOpeningClosingBal(PrevDate, p.CenterID);
                if (!Comman.Comman.IsDataSetEmpty(DS))
                {
                    if (rdRecieving.Checked)
                    {
                        p.OpeningBalance = Convert.ToDecimal(string.IsNullOrEmpty(DS.Tables[0].Rows[0]["ClosingBalance"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["ClosingBalance"].ToString());
                        p.ClosingBalance = p.OpeningBalance + p.ActualMilkInLtr;
                    }
                    else
                    {
                        p.OpeningBalance = Convert.ToDecimal(string.IsNullOrEmpty(DS.Tables[0].Rows[0]["ClosingBalance"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["ClosingBalance"].ToString());
                        p.ClosingBalance = p.OpeningBalance - p.ActualMilkInLtr;
                    }
                    
                }
                else
                {
                    p.OpeningBalance = 0;
                    p.ClosingBalance = p.ActualMilkInLtr;
                }
                p.BalanceID = 0;
                p.flag2 = "insert";
            }
            int Result = 0;
            Result = pd.InsertBatchWiseMilkCollection(p);
            if (Result > 0)
            {

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Milk Collection Record Add  Successfully";

                ClearTextBox();
                //BindMilkCollectionList();
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
            txtBatch.Text = string.Empty;
            txtDate.Text = string.Empty;
            dpSession.ClearSelection();
            txtAcidity.Text = string.Empty;
            txtSNFPercentage.Text = string.Empty;
            txtTEmp.Text = string.Empty;
            txtVehicalNo.Text = string.Empty;
            txtMilkInLtr.Text = string.Empty;
            txtMilkInKG.Text = string.Empty;
            txtFATPercentage.Text = string.Empty;
            dpRoute.ClearSelection();
            dpCenter.ClearSelection();
            dpSession.ClearSelection();
            rdRecieving.Checked = false;
            rdDisposal.Checked = false;
            rpBatchWiseMilkCollection.DataSource = null;
            rpBatchWiseMilkCollection.DataBind();
        }
        //public void BindMilkCollectionList()
        //{

        //    ProcurementData pd = new ProcurementData();
        //    DataSet DS = new DataSet();
        //    StringBuilder sb = new StringBuilder();
        //    DS = pd.GetAllBatchWiseMilkCollectionDetails();
        //    if (!Comman.Comman.IsDataSetEmpty(DS))
        //    {
        //        rpBatchWiseMilkCollection.DataSource = DS;
        //        rpBatchWiseMilkCollection.DataBind();
        //    }
        //}

        protected void rpBatchWiseMilkCollection_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {

            divDanger.Visible = false;
            divwarning.Visible = false;
            divSusccess.Visible = false;
            pnlError.Update();
            int MilkCollectionid = 0;
            MilkCollectionid = Convert.ToInt32(e.CommandArgument);
            switch (e.CommandName)
            {
                case ("Edit"):
                    {
                        //lbltital.Text = "Edit Route";
                        hfBatchWiseMilkCollectionID.Value = MilkCollectionid.ToString();
                        MilkCollectionid = Convert.ToInt32(hfBatchWiseMilkCollectionID.Value);
                        //BindRouteList();
                        GetBatchWiseMilkCollectionDetailsbyID(MilkCollectionid);
                        btnAddMilk.Visible = false;
                        btnupdateMilk.Visible = true;
                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }
                case ("delete"):
                    {

                        hfBatchWiseMilkCollectionID.Value = MilkCollectionid.ToString();
                        MilkCollectionid = Convert.ToInt32(hfBatchWiseMilkCollectionID.Value);
                        DeleteMilkCollectionbyID(MilkCollectionid);
                        //BindMilkCollectionList();
                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }


            }
        }

        public void GetBatchWiseMilkCollectionDetailsbyID(int milkcollectionid)
        {
            DataSet DS = new DataSet();
            ProcurementData pd = new ProcurementData();
            DS = pd.GetBatchWiseMilkCollectionDetailsbyID(milkcollectionid);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                txtFATPercentage.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["FATPercentage"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["FATPercentage"].ToString();
                txtMilkInKG.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["MilkInKG"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["MilkInKG"].ToString();
                txtMilkInLtr.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["MilkInLtr"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["MilkInLtr"].ToString();
                txtVehicalNo.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["VehicalNo"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["VehicalNo"].ToString();
                txtTEmp.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Temp"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Temp"].ToString();
                txtSNFPercentage.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["SNFPercentage"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["SNFPercentage"].ToString();
                txtAcidity.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Acidity"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Acidity"].ToString();
                dpRoute.ClearSelection();
                if (dpRoute.Items.FindByValue(DS.Tables[0].Rows[0]["RouteID"].ToString()) != null)
                {
                    dpRoute.Items.FindByValue(DS.Tables[0].Rows[0]["RouteID"].ToString()).Selected = true;
                }
                dpCenter.ClearSelection();
                if (dpCenter.Items.FindByValue(DS.Tables[0].Rows[0]["CenterID"].ToString()) != null)
                {
                    dpCenter.Items.FindByValue(DS.Tables[0].Rows[0]["CenterID"].ToString()).Selected = true;
                }
                txtBatch.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["BatchNo"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["BatchNo"].ToString();
                txtDate.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Date"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Date"].ToString();
                dpSession.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Session"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Session"].ToString();
            }
        }
        public void DeleteMilkCollectionbyID(int collectionid)
        {

            //Model.Procurement p = new Model.Procurement();
            //ProcurementData pd = new ProcurementData();
            //p.VehicleMasterID = string.IsNullOrEmpty(hfMilkCollectionID.Value) ? 0 : Convert.ToInt32(hfMilkCollectionID.Value);
            //p.MilkInKG = Convert.ToDecimal(txtMilkInKG.Text);
            //p.MilkInLtr = Convert.ToDecimal(txtMilkInLtr.Text);
            //p.RouteID = Convert.ToInt32(dpRoute.SelectedItem.Value);
            //p.SupplierID = Convert.ToInt32(dpSupplier.SelectedItem.Value);
            //p.FATPercentage = Convert.ToDecimal(txtFATPercentage.Text);
            //p.FATInKG = Convert.ToDecimal(txtFATInKG.Text);
            //p.CLRReading = Convert.ToDecimal(txtCLRReading.Text);
            //p.SNF = Convert.ToDecimal(txtSNF.Text);
            //p.SNFPercentage = Convert.ToDecimal(txtSNFPercentage.Text);
            //p.SNFInKG = Convert.ToDecimal(txtSNFInKG.Text);
            //p.TSPercentage = Convert.ToDecimal(txtTSPercentage.Text);
            //p.IsActive = false;

            //p.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
            //p.ModifiedBy = App_code.GlobalInfo.Userid;
            //p.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");
            //p.flag = "Delete";
            //int Result = 0;
            //Result = pd.InsertVehicleDetails(p);
            //if (Result > 0)
            //{

            //    divDanger.Visible = false;
            //    divwarning.Visible = false;
            //    divSusccess.Visible = true;
            //    lblSuccess.Text = "Delete Updated  Successfully";
            //    ClearTextBox();
            //    BindMilkCollectionList();
            //    pnlError.Update();
            //    btnAddMilkCollection.Visible = true;
            //    btnupdateMilkCollection.Visible = false;
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
        protected void btnupdateMilk_Click(object sender, EventArgs e)
        {
            Model.Procurement p = new Model.Procurement();
            ProcurementData pd = new ProcurementData();
            if (rdRecieving.Checked)
            {
                p.BatchWiseMilkCollectionID = string.IsNullOrEmpty(hfBatchWiseMilkCollectionID.Value) ? 0 : Convert.ToInt32(hfBatchWiseMilkCollectionID.Value);
                p.BatchWiseMilkDisposalID = 0;
                p.flag1 = "Receiving";
            }
            else
            {
                p.BatchWiseMilkDisposalID = string.IsNullOrEmpty(hfBatchWiseMilkCollectionID.Value) ? 0 : Convert.ToInt32(hfBatchWiseMilkCollectionID.Value);
                p.BatchWiseMilkCollectionID = 0;
                p.flag1 = "Disposal";
            }
            
            p.BatchNo = txtBatch.Text;
            p.VehicleNo = txtVehicalNo.Text;
            p.Session = dpSession.SelectedItem.Text;
            p.Date = Convert.ToDateTime(txtDate.Text);
            p.MilkInKG = Convert.ToDecimal(txtMilkInKG.Text);
            p.ActualMilkInLtr = Convert.ToDecimal(txtMilkInLtr.Text);
            p.RouteID = Convert.ToInt32(dpRoute.SelectedItem.Value);
            p.CenterID = Convert.ToInt32(dpCenter.SelectedItem.Value);
            p.Temp = Convert.ToDecimal(txtTEmp.Text);
            p.Acidity = Convert.ToDecimal(txtAcidity.Text);
            p.FATPercentage = Convert.ToDecimal(txtFATPercentage.Text);
            p.SNFPercentage = Convert.ToDecimal(txtSNFPercentage.Text);
            p.CreatedBy = App_code.GlobalInfo.Userid;
            p.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
            p.ModifiedBy = App_code.GlobalInfo.Userid;
            p.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");
            p.flag = "Update";
            int Result = 0;
            Result = pd.InsertBatchWiseMilkCollection(p);
            if (Result > 0)
            {
                //lbltital.Text = "Add Route";
                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Milk Collection Record Updated  Successfully";
                ClearTextBox();
                //BindMilkCollectionList();
                pnlError.Update();
                btnAddMilk.Visible = true;
                btnupdateMilk.Visible = false;
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

        protected void rdRecieving_CheckedChanged(object sender, EventArgs e)
        {
            ProcurementData pd = new ProcurementData();
            DataSet DS = new DataSet();
            StringBuilder sb = new StringBuilder();
            DS = pd.GetAllBatchWiseMilkCollectionDetail();
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                rpBatchWiseMilkCollection.DataSource = DS.Tables[0];
                rpBatchWiseMilkCollection.DataBind();
            }
            uprouteList.Update();
        }

        protected void rdDisposal_CheckedChanged(object sender, EventArgs e)
        {
            ProcurementData pd = new ProcurementData();
            DataSet DS = new DataSet();
            StringBuilder sb = new StringBuilder();
            DS = pd.GetAllBatchWiseMilkCollectionDetail();
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                rpBatchWiseMilkCollection.DataSource = DS.Tables[1];
                rpBatchWiseMilkCollection.DataBind();
            }
            uprouteList.Update();
        }



    }
}