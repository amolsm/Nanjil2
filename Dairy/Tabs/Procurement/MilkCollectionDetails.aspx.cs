using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using System.Text;
using System.Data;
using Bussiness;

namespace Dairy.Tabs.Procurement
{
    public partial class MilkCollectionDetails : System.Web.UI.Page
    {
        DataSet DS = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                //BindMilkCollectionList();
                BindDropDown();
                btnAddMilkCollection.Visible = true;
                btnupdateMilkCollection.Visible = false;
                txtDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                txtDate1.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                txtActualMilkInLtr.Attributes.Add("readonly", "readonly");
                txtMilkInLtr.Attributes.Add("readonly", "readonly");
                txtSNFPercentage.Attributes.Add("readonly", "readonly");
                txtTSPercentage.Attributes.Add("readonly", "readonly");
                txtFATInKG.Attributes.Add("readonly", "readonly");
                txtSNFInKG.Attributes.Add("readonly", "readonly");
                txtTSKG.Attributes.Add("readonly", "readonly");
            }

        }

        protected void BindDropDown()
        {
            RouteData routeData = new RouteData();
            DS = BindCommanData.BindCommanDropDwon("RouteID ", "RouteCode +' '+RouteName as Name  ", "Proc_MilkCollectionRoute", "IsActive=1 ");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpRoute.DataSource = DS;
                dpRoute.DataBind();
                dpRoute.Items.Insert(0, new ListItem("--Select Route  --", "0"));

                dpRoute1.DataSource = DS;
                dpRoute1.DataBind();
                dpRoute1.Items.Insert(0, new ListItem("--All Route  --", "0"));
            }

            DS = BindCommanData.BindCommanDropDwon("SupplierID ", "SupplierCode +' '+SupplierName as Name  ", "Proc_MilkSuppliersProfile", "IsActive=1 ");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpSupplier.DataSource = DS;
                dpSupplier.DataBind();
                dpSupplier.Items.Insert(0, new ListItem("--Select Supplier  --", "0"));
            }
        }

        //protected void txtMilkInKG_TextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        double milkInLtr = System.Math.Round((Convert.ToDouble(txtMilkInKG.Text) / 1.03), 2);
        //        txtMilkInLtr.Text = milkInLtr.ToString();
        //        string num = milkInLtr.ToString("0.0");
        //        string outnum = BreakUpSingleDecimalPlace(num);
        //        txtActualMilkInLtr.Text = outnum;
        //        // txtActualMilkInLtr.Text = System.Math.Round(milkInLtr, 1,
        //        //MidpointRounding.ToEven).ToString(); // Rounds to even

        //        ((TextBox)sender).Focus();
        //        ScriptManager manager = ScriptManager.GetCurrent(this);
        //        manager.SetFocus(txtCLRReading);

        //    }
        //    catch (Exception)
        //    {
        //        ((TextBox)sender).Focus();
        //        ScriptManager manager = ScriptManager.GetCurrent(this);
        //        manager.SetFocus(txtCLRReading);
        //    }
        //}



        //public string BreakUpSingleDecimalPlace(string num)
        //{
        //    string s = num;
        //    string[] parts = s.Split('.');
        //    int i1 = int.Parse(parts[0]);
        //    int i2 = int.Parse(parts[1]);
        //    string shortnum = i2.ToString();
        //    if (shortnum.Length > 1)
        //    {
        //        num = num.Remove(num.Length - 1, 1);
        //    }
        //    return num;

        //}

        //protected void txtCLRReading_TextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (txtFATPercentage.Text != string.Empty)
        //        {
        //            txtFATInKG.Text = System.Math.Round(((Convert.ToDouble(txtMilkInKG.Text) * Convert.ToDouble(txtFATPercentage.Text)) / 100), 2).ToString();
        //            string snfpercentage = System.Math.Round((Convert.ToDouble(txtCLRReading.Text) / 4 + (0.2 * Convert.ToDouble(txtFATPercentage.Text)) + 0.36), 2).ToString();
        //            string outsnfpercentage = BreakUpSingleDecimalPlace(snfpercentage);
        //            txtSNFPercentage.Text = outsnfpercentage;
        //            txtSNFInKG.Text = System.Math.Round(((Convert.ToDouble(txtMilkInKG.Text) * Convert.ToDouble(txtSNFPercentage.Text)) / 100), 2).ToString();
        //            string tsPercent = System.Math.Round((Convert.ToDouble(txtFATPercentage.Text) + Convert.ToDouble(txtSNFPercentage.Text)), 2).ToString();
        //            string outtspercent = BreakUpSingleDecimalPlace(tsPercent);
        //            txtTSPercentage.Text = outtspercent;
        //            txtTSKG.Text = System.Math.Round((Convert.ToDouble(txtFATInKG.Text) + Convert.ToDouble(txtSNFInKG.Text)), 2).ToString();



        //        }
        //        else if (txtFATPercentage.Text == string.Empty)
        //        {
        //            //txtFATPercentage.Text = Convert.ToDouble(0).ToString();
        //            ((TextBox)sender).Focus();
        //            ScriptManager managers1 = ScriptManager.GetCurrent(this);
        //            managers1.SetFocus(txtFATPercentage);
        //        }


        //    }
        //    catch (Exception ex)
        //    {
        //        string msg = ex.Message.ToString();

        //        ScriptManager managers2 = ScriptManager.GetCurrent(this);
        //        managers2.SetFocus(txtFATPercentage);
        //    }



        //}

        //protected void txtFATPercentage_TextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {

        //        txtFATInKG.Text = System.Math.Round(((Convert.ToDouble(txtMilkInKG.Text) * Convert.ToDouble(txtFATPercentage.Text)) / 100), 2).ToString();

        //        string snfpercentage = System.Math.Round((Convert.ToDouble(txtCLRReading.Text) / 4 + (0.2 * Convert.ToDouble(txtFATPercentage.Text)) + 0.36), 2).ToString();
        //        string outsnfpercentage = BreakUpSingleDecimalPlace(snfpercentage);
        //        txtSNFPercentage.Text = outsnfpercentage;
        //        txtSNFInKG.Text = System.Math.Round(((Convert.ToDouble(txtMilkInKG.Text) * Convert.ToDouble(txtSNFPercentage.Text)) / 100), 2).ToString();
        //        string tsPercent = System.Math.Round((Convert.ToDouble(txtFATPercentage.Text) + Convert.ToDouble(txtSNFPercentage.Text)), 2).ToString();
        //        string outtspercent = BreakUpSingleDecimalPlace(tsPercent);
        //        txtTSPercentage.Text = outtspercent;

        //        txtTSKG.Text = System.Math.Round((Convert.ToDouble(txtFATInKG.Text) + Convert.ToDouble(txtSNFInKG.Text)), 2).ToString();
        //        //((Button)sender).Focus();
        //        //ScriptManager managers3 = ScriptManager.GetCurrent(this);
        //        //managers3.SetFocus(btnAddMilkCollection);
        //    }
        //    catch (Exception ex)
        //    {
        //        string msg = ex.Message.ToString();



        //    }
        //}

        //protected void calculate()
        //{
        //    try
        //    {
        //        if (txtFATPercentage.Text != "")
        //        {
        //            txtFATInKG.Text = System.Math.Round(((Convert.ToDouble(txtMilkInKG.Text) * Convert.ToDouble(txtFATPercentage.Text)) / 100), 2).ToString();
        //        }
        //        else {
        //            txtFATPercentage.Text = Convert.ToDouble(0).ToString();
        //        }
        //        string snfpercentage = System.Math.Round((Convert.ToDouble(txtCLRReading.Text) / 4 + (0.2 * Convert.ToDouble(txtFATPercentage.Text)) + 0.36), 2).ToString();
        //        string outsnfpercentage = BreakUpSingleDecimalPlace(snfpercentage);
        //        txtSNFPercentage.Text = outsnfpercentage;
        //        txtSNFInKG.Text = System.Math.Round(((Convert.ToDouble(txtMilkInKG.Text) * Convert.ToDouble(txtSNFPercentage.Text)) / 100), 2).ToString();
        //        string tsPercent = System.Math.Round((Convert.ToDouble(txtFATPercentage.Text) + Convert.ToDouble(txtSNFPercentage.Text)), 2).ToString();
        //        string outtspercent = BreakUpSingleDecimalPlace(tsPercent);
        //        txtTSPercentage.Text = outtspercent;

        //        txtTSKG.Text = System.Math.Round((Convert.ToDouble(txtFATInKG.Text) + Convert.ToDouble(txtSNFInKG.Text)), 2).ToString();
        //        //

        //    }
        //    catch (Exception ex)
        //    {
        //        string msg = ex.Message.ToString();

        //        txtFATPercentage.Focus();

        //    }

        //}

        protected void btnAddMilkCollection_Click(object sender, EventArgs e)
        {
            try
            {
                Model.Procurement p1 = new Model.Procurement();
                ProcurementData pd1 = new ProcurementData();
                p1.Date = Convert.ToDateTime(txtDate.Text.ToString());
                p1.Session = dpSession.SelectedItem.Text;
                p1.SupplierID = Convert.ToInt32(dpSupplier.SelectedItem.Value);
                DS = pd1.GetExistingData(p1);
                if (!Comman.Comman.IsDataSetEmpty(DS))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Supplier Already exist for the same date and session.')", true);
                    ClearTextBox();
                    txtMilkCan.Focus();
                    int selectnextvalue = dpSupplier.Items.IndexOf(dpSupplier.Items.FindByValue(dpSupplier.SelectedItem.Value));
                    try
                    {
                        dpSupplier.SelectedIndex = selectnextvalue + 1;

                    }
                    catch { }
                }
                else
                {
                    txtActualMilkInLtr.ReadOnly = false;
                    txtMilkInLtr.ReadOnly = false;
                    txtSNFPercentage.ReadOnly = false;
                    txtTSPercentage.ReadOnly = false;
                    txtFATInKG.ReadOnly = false;
                    txtSNFInKG.ReadOnly = false;
                    txtTSKG.ReadOnly = false;
                    Model.Procurement p = new Model.Procurement();
                    ProcurementData pd = new ProcurementData();
                    p.MilkCollectionID = 0;
                    p.Batch = txtBatch.Text;
                    p.Session = dpSession.SelectedItem.Text;

                    p.Date = Convert.ToDateTime(txtDate.Text.ToString());
                    p.MilkInKG = Convert.ToDecimal(txtMilkInKG.Text);
                    p.MilkInLtr = Convert.ToDecimal(txtMilkInLtr.Text);
                    p.ActualMilkInLtr = Convert.ToDecimal(txtActualMilkInLtr.Text);
                    p.RouteID = Convert.ToInt32(dpRoute.SelectedItem.Value);
                    p.SupplierID = Convert.ToInt32(dpSupplier.SelectedItem.Value);
                    p.FATPercentage = Convert.ToDecimal(txtFATPercentage.Text);
                    p.FATInKG = Convert.ToDecimal(txtFATInKG.Text);
                    p.CLRReading = Convert.ToDecimal(txtCLRReading.Text);
                    //p.SNF = Convert.ToDecimal(txtSNF.Text);
                    p.SNFPercentage = Convert.ToDecimal(txtSNFPercentage.Text);
                    p.SNFInKG = Convert.ToDecimal(txtSNFInKG.Text);
                    p.TSPercentage = Convert.ToDecimal(txtTSPercentage.Text);
                    p.TSInKg = Convert.ToDecimal(txtTSKG.Text);
                    p.MilkCan = Convert.ToInt32(txtMilkCan.Text);
                    p.CreatedBy = App_code.GlobalInfo.Userid;
                    p.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
                    p.ModifiedBy = App_code.GlobalInfo.Userid;
                    p.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");
                    p.flag = "Insert";
                    int Result = 0;
                    Result = pd.InsertMilkCollectionDetails(p);
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
                        txtMilkCan.Focus();

                        int selectnextvalue = dpSupplier.Items.IndexOf(dpSupplier.Items.FindByValue(dpSupplier.SelectedItem.Value));
                        try
                        {
                            dpSupplier.SelectedIndex = selectnextvalue + 1;
                            divwarning.Visible = false;
                            divSusccess.Visible = false;
                            pnlError.Update();
                            upMain.Update();
                            //Page.ClientScript.RegisterStartupScript(this.GetType(), "somekey", "autoHide();", false);

                        }
                        catch { }
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
            catch(Exception ex)
            {
                string msg = ex.Message.ToString();
            }
        }
    
        public void ClearTextBox()
        {
            // txtBatch.Text = string.Empty;
            //txtDate.Text = string.Empty;
            // dpSession.ClearSelection();
            txtTSPercentage.Text = string.Empty;
            txtSNFPercentage.Text = string.Empty;
            txtSNFInKG.Text = string.Empty;
            //txtSNF.Text = string.Empty;
            txtMilkInLtr.Text = string.Empty;
            txtActualMilkInLtr.Text = string.Empty;
            txtMilkInKG.Text = string.Empty;
            txtFATPercentage.Text = string.Empty;
            txtFATInKG.Text = string.Empty;
            txtCLRReading.Text = string.Empty;
            // dpRoute.ClearSelection();
            //dpSupplier.ClearSelection();
            txtMilkCan.Text = string.Empty;
            txtTSKG.Text = string.Empty;
        }
        public void BindMilkCollectionList()
        {

            ProcurementData pd = new ProcurementData();
            DataSet DS = new DataSet();
            StringBuilder sb = new StringBuilder();
            DS = pd.GetAllMilkCollectionDetails();
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                rpMilkCollectionList.DataSource = DS;
                rpMilkCollectionList.DataBind();
            }
        }

        protected void rpMilkCollectionList_ItemCommand(object sender, RepeaterCommandEventArgs e)
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
                        hfMilkCollectionID.Value = MilkCollectionid.ToString();
                        MilkCollectionid = Convert.ToInt32(hfMilkCollectionID.Value);
                        //BindRouteList();
                        GetMilkCollectionDetailsbyID(MilkCollectionid);
                        btnAddMilkCollection.Visible = false;
                        btnupdateMilkCollection.Visible = true;
                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }
                case ("delete"):
                    {

                        hfMilkCollectionID.Value = MilkCollectionid.ToString();
                        MilkCollectionid = Convert.ToInt32(hfMilkCollectionID.Value);
                        DeleteMilkCollectionbyID(MilkCollectionid);
                        //BindMilkCollectionList();
                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }


            }
        }


        public void GetMilkCollectionDetailsbyID(int milkcollectionid)
        {
            DataSet DS = new DataSet();
            ProcurementData pd = new ProcurementData();
            DS = pd.GetMilkCollectionDetailsbyID(milkcollectionid);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                txtCLRReading.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["CLRReading"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["CLRReading"].ToString();
                txtFATInKG.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["FATInKG"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["FATInKG"].ToString();
                txtFATPercentage.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["FATPercentage"].ToString()) ? string.Empty : Convert.ToDecimal(DS.Tables[0].Rows[0]["FATPercentage"]).ToString("0.0");
                txtMilkInKG.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["MilkInKG"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["MilkInKG"].ToString();
                txtMilkInLtr.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["MilkInLtr"].ToString()) ? string.Empty : Convert.ToDecimal(DS.Tables[0].Rows[0]["MilkInLtr"]).ToString("0.0");
                txtActualMilkInLtr.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["ActualMilkInLtr"].ToString()) ? string.Empty : Convert.ToDecimal(DS.Tables[0].Rows[0]["ActualMilkInLtr"]).ToString("0.0");
                //txtSNF.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["SNF"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["SNF"].ToString();
                txtSNFInKG.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["SNFInKG"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["SNFInKG"].ToString();
                txtSNFPercentage.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["SNFPercentage"].ToString()) ? string.Empty : Convert.ToDecimal(DS.Tables[0].Rows[0]["SNFPercentage"]).ToString("0.0");
                txtTSPercentage.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["TSPercentage"].ToString()) ? string.Empty : Convert.ToDecimal(DS.Tables[0].Rows[0]["TSPercentage"]).ToString("0.0");
                dpRoute.ClearSelection();
                if (dpRoute.Items.FindByValue(DS.Tables[0].Rows[0]["RouteID"].ToString()) != null)
                {
                    dpRoute.Items.FindByValue(DS.Tables[0].Rows[0]["RouteID"].ToString()).Selected = true;
                }
                dpSupplier.ClearSelection();
                if (dpSupplier.Items.FindByValue(DS.Tables[0].Rows[0]["SupplierID"].ToString()) != null)
                {
                    dpSupplier.Items.FindByValue(DS.Tables[0].Rows[0]["SupplierID"].ToString()).Selected = true;
                }
                txtBatch.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Batch"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Batch"].ToString();
                txtDate.Text = Convert.ToDateTime(DS.Tables[0].Rows[0]["_Date"]).ToString("yyyy-MM-dd").ToString();

                //dpSession.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["_Session"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["_Session"].ToString();
                txtMilkCan.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Can"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Can"].ToString();
                txtTSKG.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["TSInKg"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["TSInKg"].ToString();
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
        protected void btnupdateMilkCollection_Click(object sender, EventArgs e)
        {
            Model.Procurement p = new Model.Procurement();
            ProcurementData pd = new ProcurementData();
            p.MilkCollectionID = string.IsNullOrEmpty(hfMilkCollectionID.Value) ? 0 : Convert.ToInt32(hfMilkCollectionID.Value);
            p.Batch = txtBatch.Text;
            p.Session = dpSession.SelectedItem.Text;
            p.Date = Convert.ToDateTime(txtDate.Text);
            p.MilkInKG = Convert.ToDecimal(txtMilkInKG.Text);
            p.MilkInLtr = Convert.ToDecimal(txtMilkInLtr.Text);
            p.ActualMilkInLtr = Convert.ToDecimal(txtMilkInLtr.Text);
            p.RouteID = Convert.ToInt32(dpRoute.SelectedItem.Value);
            p.SupplierID = Convert.ToInt32(dpSupplier.SelectedItem.Value);
            p.FATPercentage = Convert.ToDecimal(txtFATPercentage.Text);
            p.FATInKG = Convert.ToDecimal(txtFATInKG.Text);
            p.CLRReading = Convert.ToDecimal(txtCLRReading.Text);
            //p.SNF = Convert.ToDecimal(txtSNF.Text);
            p.SNFPercentage = Convert.ToDecimal(txtSNFPercentage.Text);
            p.SNFInKG = Convert.ToDecimal(txtSNFInKG.Text);
            p.TSPercentage = Convert.ToDecimal(txtTSPercentage.Text);
            p.TSInKg = Convert.ToDecimal(txtTSKG.Text);
            p.MilkCan = Convert.ToInt32(txtMilkCan.Text);
            p.CreatedBy = App_code.GlobalInfo.Userid;
            p.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
            p.ModifiedBy = App_code.GlobalInfo.Userid;
            p.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");
            p.flag = "Update";
            int Result = 0;
            Result = pd.InsertMilkCollectionDetails(p);
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
                btnAddMilkCollection.Visible = true;
                btnupdateMilkCollection.Visible = false;
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

        protected void btnView_Click(object sender, EventArgs e)
        {
            Model.Procurement p = new Model.Procurement();
            ProcurementData pd = new ProcurementData();
            p.Date = Convert.ToDateTime(txtDate1.Text);
            p.RouteID = Convert.ToInt32(dpRoute1.SelectedItem.Value);
            p.Session = dpSession1.SelectedItem.Text.ToString();
            DataSet DS1 = new DataSet();
            DS1 = pd.ViewMilkCollectionDetails(p);
            //if (!Comman.Comman.IsDataSetEmpty(DS1))
            //{

            rpMilkCollectionList.DataSource = DS1;
            rpMilkCollectionList.DataBind();
            uprouteList.Update();
            //}


        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Tabs/Procurement/MilkCollectionDetails.aspx");
            divDanger.Visible = false;
            divwarning.Visible = false;
            divSusccess.Visible = false;
            pnlError.Update();
            upMain.Update();
        }

        protected void dpRoute_SelectedIndexChanged(object sender, EventArgs e)
        {
            dpSupplier.ClearSelection();
            DS = BindCommanData.BindCommanDropDwon("SupplierID ", "SupplierCode +' '+SupplierName as Name  ", "Proc_MilkSuppliersProfile", "IsActive=1 and RouteId=" + dpRoute.SelectedItem.Value);

            dpSupplier.DataSource = DS;
            dpSupplier.DataBind();
            dpSupplier.Items.Insert(0, new ListItem("--Select Supplier  --", "0"));

            //ScriptManager manager = ScriptManager.GetCurrent(this);
            //manager.SetFocus(dpSession);
        }

        protected void dpSession_SelectedIndexChanged(object sender, EventArgs e)
        {
            ScriptManager manager = ScriptManager.GetCurrent(this);
            manager.SetFocus(txtBatch);
        }

        protected void txtBatch_TextChanged(object sender, EventArgs e)
        {
            ScriptManager manager = ScriptManager.GetCurrent(this);
            manager.SetFocus(dpSupplier);
        }

        //protected void dpSupplier_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    divDanger.Visible = false;
        //    divwarning.Visible = false;
        //    divSusccess.Visible = false;
        //    pnlError.Update();
        //    //upMain.Update();
        //    txtMilkCan.Focus();
        //}
    }
}