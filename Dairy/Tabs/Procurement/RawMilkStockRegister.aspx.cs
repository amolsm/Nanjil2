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
using Dairy.App_code;

namespace Dairy.Tabs.Procurement
{
    public partial class RawMilkStockRegister : System.Web.UI.Page
    {
        string flag;
        DataSet DS = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //BindMilkCollectionList();
                BindDropDwon();
                txtDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
                txtDate1.Text = DateTime.Now.ToString("yyyy/MM/dd");
                txtTime.Text = DateTime.Now.ToString("HH:MM");
                btnAddMilk.Visible = true;
                btnupdateMilk.Visible = false;
                rdRecieving.Checked = true;
                d1.Visible = false;
              //  disp.Visible = false;
            }
        }

        public void BindDropDwon()
        {

            DS = BindCommanData.BindCommanDropDwon("ID ", "particular  as Name  ", "Proc_ReceiveandDisposalMaster", "Purpose='Receive' ");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpParticularreceive.DataSource = DS;
                dpParticularreceive.DataBind();
                dpParticularreceive.Items.Insert(0, new ListItem("--Select Particular  --", "0"));
            }
            DS = BindCommanData.BindCommanDropDwon("ID ", "particular  as Name  ", "Proc_ReceiveandDisposalMaster", "Purpose='Dispose' ");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpParticulardispose.DataSource = DS;
                dpParticulardispose.DataBind();
                dpParticulardispose.Items.Insert(0, new ListItem("--Select Particular  --", "0"));
            }
            //DS = BindCommanData.BindCommanDropDwon("CenterID ", "CenterCode +' '+CenterName as Name  ", "tbl_MilkCollectionCenter", "IsActive=1 ");
            //if (!Comman.Comman.IsDataSetEmpty(DS))
            //{
            //    dpCenter.DataSource = DS;
            //    dpCenter.DataBind();
            //    dpCenter.Items.Insert(0, new ListItem("--Select Center  --", "0"));
            //}

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
                p.ID = Convert.ToInt32(dpParticularreceive.SelectedItem.Value);
            }
            else
            {
                p.flag1 = "Disposal";
                p.ID = Convert.ToInt32(dpParticulardispose.SelectedItem.Value);

            }
            p.BatchWiseMilkCollectionID = 0;
            p.BatchWiseMilkDisposalID = 0;
            p.BatchNo = txtBatch.Text;
            p.VehicleNo = txtVehicalNo.Text;
            p.Session = txtTime.Text;
            p.Date = Convert.ToDateTime(txtDate.Text);
            p.MilkInKG = Convert.ToDecimal(txtMilkInKG.Text);
            p.ActualMilkInLtr = Convert.ToDecimal(txtMilkInLtr.Text);
            p.MilkType = dpMilkType.SelectedItem.Text;
            p.CenterID = 6; //GlobalInfo.Userid;
            p.Temp = Convert.ToDecimal(txtTEmp.Text);
            p.Acidity = Convert.ToDecimal(txtAcidity.Text);
            p.FATPercentage = Convert.ToDecimal(txtFATPercentage.Text);
            p.SNFPercentage = Convert.ToDecimal(txtSNFPercentage.Text);
            p.Time = txtTime.Text;
          //  p.HandlingExcess =!string.IsNullOrEmpty(txtHandlingExcess.Text)?Convert.ToDecimal(txtHandlingExcess.Text):0;
           // p.HandlingLoss = !string.IsNullOrEmpty(txtHandlingLoss.Text)?Convert.ToDecimal(txtHandlingLoss.Text):0;
         //   p.Disposal = dpdestination.SelectedItem.Text;
           // p.InternameConsumption =!string.IsNullOrEmpty(txtInternalConsumption.Text)? Convert.ToDecimal(txtInternalConsumption.Text):0;
          //  p.DamageMilk =!string.IsNullOrEmpty(txtDamageMilk.Text)? Convert.ToDecimal(txtDamageMilk.Text):0;
          //  p.Other =!string.IsNullOrEmpty(TextBtxtOther.Text)? Convert.ToDecimal(TextBtxtOther.Text):0;
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
            txtTime.Text = string.Empty;
            txtAcidity.Text = string.Empty;
            txtSNFPercentage.Text = string.Empty;
            txtTEmp.Text = string.Empty;
            txtVehicalNo.Text = string.Empty;
            txtMilkInLtr.Text = string.Empty;
            txtMilkInKG.Text = string.Empty;
            txtFATPercentage.Text = string.Empty;
            dpMilkType.ClearSelection();
            dpParticulardispose.ClearSelection();
            dpParticularreceive.ClearSelection();
            rdRecieving.Checked = false;
            rdDisposal.Checked = false;
            rpBatchWiseMilkCollection.DataSource = null;
            rpBatchWiseMilkCollection.DataBind();
           //  dpdestination.ClearSelection();
           // txtHandlingExcess.Text = string.Empty;
           // txtHandlingLoss.Text = string.Empty;
           // txtInternalConsumption.Text = string.Empty;
           // txtDamageMilk.Text = string.Empty;
           // TextBtxtOther.Text = string.Empty;
        }
        public void BindMilkCollectionList()
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
            if (rdRecieving.Checked)
            {
                flag = "receive";
            }
            else { flag = "dispose"; }
            DS = pd.GetBatchWiseMilkCollection(milkcollectionid,flag);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                txtFATPercentage.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["FATPercentage"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["FATPercentage"].ToString();
                txtMilkInKG.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["MilkInKG"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["MilkInKG"].ToString();
                txtMilkInLtr.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["MilkInLtr"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["MilkInLtr"].ToString();
                txtVehicalNo.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["VehicalNo"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["VehicalNo"].ToString();
                txtTEmp.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Temp"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Temp"].ToString();
                txtSNFPercentage.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["SNFPercentage"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["SNFPercentage"].ToString();
                txtAcidity.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Acidity"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Acidity"].ToString();
                dpMilkType.ClearSelection();
                if (dpMilkType.Items.FindByText(DS.Tables[0].Rows[0]["MilkType"].ToString()) != null)
                {
                    dpMilkType.Items.FindByText(DS.Tables[0].Rows[0]["MilkType"].ToString()).Selected = true;
                }
                dpParticularreceive.ClearSelection();
                if (rdRecieving.Checked)
                {
                    if (dpParticularreceive.Items.FindByValue(DS.Tables[0].Rows[0]["Particular"].ToString()) != null)
                    {
                        dpParticularreceive.Items.FindByValue(DS.Tables[0].Rows[0]["Particular"].ToString()).Selected = true;
                    }
                }
                dpParticulardispose.ClearSelection();
                if (rdDisposal.Checked)
                {

                    if (dpParticulardispose.Items.FindByValue(DS.Tables[0].Rows[0]["Particular"].ToString()) != null)
                    {
                        dpParticulardispose.Items.FindByValue(DS.Tables[0].Rows[0]["Particular"].ToString()).Selected = true;
                    }
                }
                txtBatch.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["BatchNo"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["BatchNo"].ToString();
                txtDate.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Date"].ToString()) ? string.Empty : Convert.ToDateTime(DS.Tables[0].Rows[0]["Date"]).ToString("yyyy-MM-dd");
                txtTime.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Session"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Session"].ToString();
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
            //    btnAddMilk.Visible = true;
            //    btnupdateMilk.Visible = false;
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
                p.ID = Convert.ToInt32(dpParticularreceive.SelectedItem.Value);
            }
            else
            {
                p.BatchWiseMilkDisposalID = string.IsNullOrEmpty(hfBatchWiseMilkCollectionID.Value) ? 0 : Convert.ToInt32(hfBatchWiseMilkCollectionID.Value);
                p.BatchWiseMilkCollectionID = 0;
                p.flag1 = "Disposal";
                p.ID = Convert.ToInt32(dpParticulardispose.SelectedItem.Value);
            }
            
            p.BatchNo = txtBatch.Text;
            p.VehicleNo = txtVehicalNo.Text;
            p.Session = txtTime.Text;
            p.Date = Convert.ToDateTime(txtDate.Text);
            p.MilkInKG = Convert.ToDecimal(txtMilkInKG.Text);
            p.ActualMilkInLtr = Convert.ToDecimal(txtMilkInLtr.Text);
            p.MilkType = dpMilkType.SelectedItem.Text;
            p.CenterID = 6;//App_code.GlobalInfo.Userid;
            p.Temp = Convert.ToDecimal(txtTEmp.Text);
            p.Acidity = Convert.ToDecimal(txtAcidity.Text);
            p.FATPercentage = Convert.ToDecimal(txtFATPercentage.Text);
            p.SNFPercentage = Convert.ToDecimal(txtSNFPercentage.Text);
            p.Time = txtTime.Text;
           // p.Disposal = dpdestination.SelectedItem.Text;
           // p.HandlingExcess = Convert.ToDecimal(txtHandlingExcess.Text);
           // p.HandlingLoss = Convert.ToDecimal(txtHandlingLoss.Text);
           // p.InternameConsumption = Convert.ToDecimal(txtInternalConsumption.Text);
           // p.DamageMilk = Convert.ToDecimal(txtDamageMilk.Text);
            //p.Other = Convert.ToDecimal(TextBtxtOther.Text);
            p.CreatedBy = App_code.GlobalInfo.Userid;
            p.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
            p.ModifiedBy = App_code.GlobalInfo.Userid;
            p.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");
            p.flag = "Update";
            p.flag2 = "";
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
            if (rdRecieving.Checked)
            {
                d1.Visible = false;
                d2.Visible = true;
                //disp.Visible = false;
            
               
                rpBatchWiseMilkCollection.Dispose();
            }
           
           
        }

        protected void rdDisposal_CheckedChanged(object sender, EventArgs e)
        {
            if (rdDisposal.Checked)
            {
                d1.Visible = true;
                d2.Visible = false;
             //   disp.Visible = true;
               
               
                rpBatchWiseMilkCollection.Dispose();
            }
           
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            ProcurementData pd = new ProcurementData();
            DataSet DS = new DataSet();
            Model.Procurement p = new Model.Procurement();
           
            p.CenterID = 6;//Convert.ToInt32(dpCenter.SelectedItem.Value);
            if (rdDisposal.Checked)
            {
                p.Date = Convert.ToDateTime(txtDate.Text);
                flag = "dispose";
            }
            if (rdRecieving.Checked)
            {
                flag = "receive";
                p.Date = Convert.ToDateTime(txtDate.Text);
            }
            p.flag = flag;
            DS = pd.GetAllBatchWiseMilkCollectionDetails(p);
            try
            {
                rpBatchWiseMilkCollection.DataSource = DS;
                rpBatchWiseMilkCollection.DataBind();
            }
            catch { }
            uprouteList.Update();
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Tabs/Procurement/RawMilkStockRegister.aspx");
        }
    }
    
}