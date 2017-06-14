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
using Bussiness;
using Bussiness.Production;
using System.Text;
using Comman;
using Dairy.App_code;
using Dairy;


namespace Dairy.Tabs.Production
{
    public partial class QualityCheck : System.Web.UI.Page
    {
        MQuality qtyMdata;
        BQuality qtyBdata;
        DataSet DS = new DataSet();
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDwon();

                //GetQualityDetails();
                ClearField();
                txtBatchNo.ReadOnly = true;
                txtDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                txtSearchDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                txtDate.ReadOnly = false;
                dpShiftDetails.Enabled = true;
                //dpQCDetails.ClearSelection();
                txtMilkType.ReadOnly = true;
                txtTankerReceipitNo.ReadOnly = true;
                txtTankerNo.ReadOnly = true;
                txtQty.ReadOnly = true;

               
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

            dpQCDetails.DataSource = DS;
            dpQCDetails.DataBind();
            //dpQCDetails.Items.FindByText("Rejected").Enabled = false;
            //dpQCDetails.Items.FindByText("Re-Chilling").Enabled = false;
            dpQCDetails.Items.Insert(0, new ListItem("--Select Status--", "0"));
        }

        public void GetQualityDetails(RMRecieve R)
        {

            qtyBdata = new BQuality();
            DataSet DS = new DataSet();

            DS = qtyBdata.GetQualityDetails(R);

            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                rpQualityList.DataSource = DS;
                rpQualityList.DataBind();
            }
            else if (DS.Tables[0].Rows.Count == 0)
            {
                rpQualityList.DataSource = DS;
                rpQualityList.DataBind();
                //this.BindRepeater(dt);

            }
        }
       private void BindRepeater(DataTable dt)
        {
            rpQualityList.DataSource = dt;
            rpQualityList.DataBind();

            if (dt.Rows.Count == 0)
            {
                Control FooterTemplate = rpQualityList.Controls[rpQualityList.Controls.Count - 1].Controls[0];
                FooterTemplate.FindControl("trEmpty").Visible = true;
            }

        }


    
    protected void rpQualityList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            ClearField();
            btnAdd.Visible = false;
            divDanger.Visible = false;
            divwarning.Visible = false;
            divSusccess.Visible = false;
            pnlError.Update();
            int RMRId = 0;
            RMRId = Convert.ToInt32(e.CommandArgument);
            switch (e.CommandName)
            {
                case ("Edit"):
                    {
                        lblHeaderTab.Text = "Edit Quality Check";
                        hId.Value = RMRId.ToString();
                        RMRId = Convert.ToInt32(hId.Value);
                        GetQualityDetails(RMRId);
                        //GetQualityDetailsbyID(RMRId);
                        hfrid.Value = RMRId.ToString();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "sel3", "$('#bx1').removeClass('collapsed-box');", true);
                        if (dpQCDetails.SelectedItem.Text == "Pending")
                        {
                            btnAdd.Visible = true;
                            btnUpdate.Visible = false;
                            
                        }
                        else if(dpQCDetails.SelectedItem.Text == "Re-Chilling")
                        {
                            btnAdd.Visible = false;
                            btnUpdate.Visible = true;
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "sel3", "$('#bx1').removeClass('collapsed-box');", true);
                        }


                        upMain.Update();
                        uprouteList.Update();


                        break;
                    }
                    ////case ("delete"):
                    ////    {

                    ////        hId.Value = Id.ToString();
                    ////        Id = Convert.ToInt32(hId.Value);
                    ////        DeleteRMRDetails(Id);
                    ////        bindRMRList();
                    ////        upMain.Update();
                    ////        uprouteList.Update();
                    ////        break;

                    //    }
            }
        }



      

        public void GetQualityDetails(int RMRId)
        {
            DataSet DS = new DataSet();
            BQuality qtyBdata = new BQuality();
            //DS = proddata.GetRMRDatabyId(RMRId);
            DS = qtyBdata.GetQualityDetailsById(RMRId);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                txtDate.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["RMRDate"].ToString()) ? string.Empty : Convert.ToDateTime(DS.Tables[0].Rows[0]["RMRDate"]).ToString("yyyy-MM-dd");
                txtBatchNo.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["BatchNo"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["BatchNo"].ToString();
                txtQty.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Qty"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Qty"].ToString();
                string ShiftDetails = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["RMRShiftId"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["RMRShiftId"].ToString();
                dpShiftDetails.ClearSelection();
                if (ShiftDetails=="")
                {
                    dpShiftDetails.SelectedIndex = 0;
                }
                else
                {
                    dpShiftDetails.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["RMRShiftId"]).ToString()).Selected = true;
                }
                //dpShiftDetails.SelectedValue = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["RMRShiftId"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["RMRShiftId"].ToString();
                txtTankerReceipitNo.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["TankMilkReciptNo"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["TankMilkReciptNo"].ToString();
                txtTankerNo.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["TankerNo"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["TankerNo"].ToString();

                txtMilkType.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["TypeOfMilk"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["TypeOfMilk"].ToString();

                txtTemperature.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Temperature"].ToString()) ? "" : DS.Tables[0].Rows[0]["Temperature"].ToString();

                txtAlcohol.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Alcohol"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Alcohol"].ToString();
                txtNeutralizer.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Neutralizer"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Neutralizer"].ToString();
                txtTaste.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Taste"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Taste"].ToString();
                txtSmell.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Smell"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Smell"].ToString();
                txtColor.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Color"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Color"].ToString();
                txtAcidity.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Acidity"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Acidity"].ToString(); ;
                txtHeatStability.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["HeatStability"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["HeatStability"].ToString(); ;
                txtFat.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Fat"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Fat"].ToString(); ;
                txtCLR.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["CLR"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["CLR"].ToString(); ;
                txtSNF.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["SNF"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["SNF"].ToString(); ;
                txtTestedBy.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["TestedBy"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["TestedBy"].ToString(); ;
                txtVerifiedBy.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["VerifiedBy"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["VerifiedBy"].ToString(); ;
                txtOthers.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Others"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Others"].ToString(); ;
                txtRemarks.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Remarks"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Remarks"].ToString(); ;
                dpQCDetails.ClearSelection();
                string QCDetails = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["QCId"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["QCId"].ToString(); 

                if(QCDetails=="")
                {
                    dpQCDetails.SelectedIndex = 1;
                }
                else
                {
                    dpQCDetails.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["QCId"]).ToString()).Selected = true;
                }
                //if (dpQCDetails.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["QCId"]).ToString()) != null)
                //{
                //    dpQCDetails.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["QCId"]).ToString()).Selected = true;
                //}
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try {
                qtyMdata = new MQuality();
                qtyBdata = new BQuality();
                //if (dpQCDetails.SelectedItem.Text == "Accepted" || dpQCDetails.SelectedItem.Text == "Rejected")
                //{
                int Result = 0;
                qtyMdata.QualityId = 0;

                qtyMdata.RMRId = string.IsNullOrEmpty(hfrid.Value) ? 0 : Convert.ToInt32(hfrid.Value);
                //qtydata.QCId = string.IsNullOrEmpty(hId.Value) ? 0 : Convert.ToInt32(hId.Value);
                qtyMdata.RMRShiftId = Convert.ToInt32(dpShiftDetails.SelectedItem.Value);
                //qtyMdata.RMRDate = DateTime.Now.ToString();
                qtyMdata.QualityDate = Convert.ToDateTime(txtDate.Text.ToString());
                qtyMdata.Temperature = string.IsNullOrEmpty(txtTemperature.Text) ? 0 : Convert.ToDouble(txtTemperature.Text);
                qtyMdata.Alcohol = string.IsNullOrEmpty(txtAlcohol.Text) ? 0 : Convert.ToDouble(txtAlcohol.Text);
                qtyMdata.Neutralizer = string.IsNullOrEmpty(txtNeutralizer.Text) ? 0 : Convert.ToDouble(txtNeutralizer.Text);
                qtyMdata.Taste = string.IsNullOrEmpty(txtTaste.Text) ? string.Empty : txtTaste.Text;
                qtyMdata.Smell = string.IsNullOrEmpty(txtSmell.Text) ? string.Empty : txtSmell.Text;
                qtyMdata.Color = string.IsNullOrEmpty(txtColor.Text) ? string.Empty : txtColor.Text;
                qtyMdata.Acidity = string.IsNullOrEmpty(txtAcidity.Text) ? 0 : Convert.ToDouble(txtAcidity.Text);
                qtyMdata.HeatStability = string.IsNullOrEmpty(txtHeatStability.Text) ? 0 : Convert.ToDouble(txtHeatStability.Text);
                qtyMdata.Fat = string.IsNullOrEmpty(txtFat.Text) ? 0 : Convert.ToDouble(txtFat.Text);
                qtyMdata.CLR = string.IsNullOrEmpty(txtCLR.Text) ? 0 : Convert.ToDouble(txtCLR.Text);
                qtyMdata.SNF = string.IsNullOrEmpty(txtSNF.Text) ? 0 : Convert.ToDouble(txtSNF.Text);
                qtyMdata.TestedBy = string.IsNullOrEmpty(txtTestedBy.Text) ? string.Empty : txtTestedBy.Text;
                qtyMdata.VerifiedBy = string.IsNullOrEmpty(txtVerifiedBy.Text) ? string.Empty : txtVerifiedBy.Text;
                qtyMdata.Others = string.IsNullOrEmpty(txtOthers.Text) ? string.Empty : txtOthers.Text;
                qtyMdata.Remarks = string.IsNullOrEmpty(txtRemarks.Text) ? string.Empty : txtRemarks.Text;
                qtyMdata.QCStatus = Convert.ToInt32(dpQCDetails.SelectedItem.Value);
                qtyMdata.flag = "Insert";
                Result = qtyBdata.QualityData(qtyMdata);
                if (Result > 0)
                {
                    divDanger.Visible = false;
                    divwarning.Visible = false;
                    divSusccess.Visible = true;
                    
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "sel3", "$('#bx1').addClass('collapsed-box');", true);
                    //pnlError.Update();
                    ////string dates;
                    ////dates = string.IsNullOrEmpty(txtSearchDate.Text) ? string.Empty : Convert.ToDateTime(txtSearchDate.Text).ToString("dd-MM-yyyy"); 
                    //RMRecieve R = new RMRecieve();
                    //R.RMRDate = Convert.ToDateTime(txtSearchDate.Text);
                    //GetQualityDetails(R);
                    //uprouteList.Update();
                    //ClearField();
                    RMRecieve R = new RMRecieve();
                    R.RMRDate = Convert.ToDateTime(txtDate.Text);
                    GetQualityDetails(R);
                    uprouteList.Update();
                    lblSuccess.Text = "QualityData Added Successfully";
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
            }
            catch(FormatException EX)
            {

                string MSG = EX.ToString();
            }
            }
        
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            qtyMdata = new MQuality();
            qtyBdata = new BQuality();
            //if (dpQCDetails.SelectedItem.Text == "Accepted" || dpQCDetails.SelectedItem.Text == "Rejected")
            //{
            int Result = 0;
            qtyMdata.QualityId = 0;
            qtyMdata.RMRId = string.IsNullOrEmpty(hfrid.Value) ? 0 : Convert.ToInt32(hfrid.Value);
            //qtydata.QCId = string.IsNullOrEmpty(hId.Value) ? 0 : Convert.ToInt32(hId.Value);
            qtyMdata.RMRShiftId = Convert.ToInt32(dpShiftDetails.SelectedItem.Value);
            //qtyMdata.RMRDate = DateTime.Now.ToString();
            qtyMdata.QualityDate = Convert.ToDateTime(txtDate.Text.ToString());
            qtyMdata.Temperature = string.IsNullOrEmpty(txtTemperature.Text) ? 0 : Convert.ToDouble(txtTemperature.Text);
            qtyMdata.Alcohol = string.IsNullOrEmpty(txtAlcohol.Text) ? 0 : Convert.ToDouble(txtAlcohol.Text);
            qtyMdata.Neutralizer = string.IsNullOrEmpty(txtNeutralizer.Text) ? 0 : Convert.ToDouble(txtNeutralizer.Text);
            qtyMdata.Taste = string.IsNullOrEmpty(txtTaste.Text) ? string.Empty : txtTaste.Text;
            qtyMdata.Smell = string.IsNullOrEmpty(txtSmell.Text) ? string.Empty : txtSmell.Text;
            qtyMdata.Color = string.IsNullOrEmpty(txtColor.Text) ? string.Empty : txtColor.Text;
            qtyMdata.Acidity = string.IsNullOrEmpty(txtAcidity.Text) ? 0 : Convert.ToDouble(txtAcidity.Text);
            qtyMdata.HeatStability = string.IsNullOrEmpty(txtHeatStability.Text) ? 0 : Convert.ToDouble(txtHeatStability.Text);
            qtyMdata.Fat = string.IsNullOrEmpty(txtFat.Text) ? 0 : Convert.ToDouble(txtFat.Text);
            qtyMdata.CLR = string.IsNullOrEmpty(txtCLR.Text) ? 0 : Convert.ToDouble(txtCLR.Text);
            qtyMdata.SNF = string.IsNullOrEmpty(txtSNF.Text) ? 0 : Convert.ToDouble(txtSNF.Text);
            qtyMdata.TestedBy = string.IsNullOrEmpty(txtTestedBy.Text) ? string.Empty : txtTestedBy.Text;
            qtyMdata.VerifiedBy = string.IsNullOrEmpty(txtVerifiedBy.Text) ? string.Empty : txtVerifiedBy.Text;
            qtyMdata.Others = string.IsNullOrEmpty(txtOthers.Text) ? string.Empty : txtOthers.Text;
            qtyMdata.Remarks = string.IsNullOrEmpty(txtRemarks.Text) ? string.Empty : txtRemarks.Text;
            qtyMdata.QCStatus = Convert.ToInt32(dpQCDetails.SelectedItem.Value);
            qtyMdata.flag = "Update";
            Result = qtyBdata.QualityData(qtyMdata);

            //btnRefresh_Click(sender, e);

            if (Result > 0)
            {
                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                RMRecieve R = new RMRecieve();
                R.RMRDate = Convert.ToDateTime(txtDate.Text);
                GetQualityDetails(R);
                uprouteList.Update();
                lblSuccess.Text = "QualityData Data Updated Successfully";
                pnlError.Update();
                ClearField();
            }
            else
            {
                divDanger.Visible = false;
                divwarning.Visible = true;
                divSusccess.Visible = false;
                lblSuccess.Text = "Something went wrong plz contact site admin";
                pnlError.Update();
            }

        }
        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }
       

        public void ClearField()
        {
            txtTemperature.Text = string.Empty;
            txtAlcohol.Text = string.Empty;
            txtNeutralizer.Text = string.Empty;
            txtTaste.Text = string.Empty;
            txtSmell.Text = string.Empty;
            txtColor.Text = string.Empty;
            txtAcidity.Text = string.Empty;
            txtHeatStability.Text = string.Empty;
            txtFat.Text = string.Empty;
            txtCLR.Text = string.Empty;
            txtSNF.Text = string.Empty;
            txtTestedBy.Text = string.Empty;
            txtVerifiedBy.Text = string.Empty;
            txtOthers.Text = string.Empty;
            txtRemarks.Text = string.Empty;
            dpQCDetails.SelectedIndex = 0;

            dpShiftDetails.SelectedIndex = 0;
            txtMilkType.Text = string.Empty;
            txtTankerReceipitNo.Text = string.Empty;
            txtTankerNo.Text = string.Empty;
            txtBatchNo.Text = string.Empty;
            txtQty.Text = string.Empty;
            txtDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                RMRecieve R = new RMRecieve();
                R.RMRDate = Convert.ToDateTime(txtSearchDate.Text);
                //string dates = Convert.ToDateTime(txtSearchDate.Text).ToString("dd-MM-yyyy");
                GetQualityDetails(R);
            }
            catch (Exception) { }
        }


        //}



        //    //else if(dpQCDetails.SelectedItem.Text == "Re-Chilling")
        //{
        //    chilldata = new MRechilling();
        //    dachilldata = new DARechilling();
        //    int Result = 0;
        //    chilldata.BatchNo = txtBatchNo.Text;
        //    chilldata.ShiftId = Convert.ToInt32(dpShiftDetails.SelectedItem.Value);
        //    chilldata.Date = Convert.ToDateTime(txtDate.Text).ToString("dd-MM-yyyy");
        //    chilldata.Id = string.IsNullOrEmpty(hfrid.Value) ? 0 : Convert.ToInt32(hfrid.Value);
        //    chilldata.TypeOfMilk = string.IsNullOrEmpty(txtMilkType.Text) ? string.Empty : txtMilkType.Text;
        //    chilldata.Quantity = string.IsNullOrEmpty(txtQty.Text) ? 0 : Convert.ToDouble(txtQty.Text);
        //    chilldata.SiloId = 0;
        //    chilldata.IBTInTemperature = string.IsNullOrEmpty(txtQty.Text) ? 0 : Convert.ToDouble(txtQty.Text);
        //    chilldata.IBTOutTemperature = string.IsNullOrEmpty(txtQty.Text) ? 0 : Convert.ToDouble(txtQty.Text);
        //    chilldata.MilkInTemperature = string.IsNullOrEmpty(txtQty.Text) ? 0 : Convert.ToDouble(txtQty.Text);
        //    chilldata.MilkOutTemperature = string.IsNullOrEmpty(txtQty.Text) ? 0 : Convert.ToDouble(txtQty.Text);
        //    chilldata.RechilledBy = string.IsNullOrEmpty(txtMilkType.Text) ? string.Empty : txtMilkType.Text;
        //    chilldata.flag = "Insert";

        //    Result = dachilldata.RechillingData(chilldata);
        //    if (Result > 0)
        //    {
        //        divDanger.Visible = false;
        //        divwarning.Visible = false;
        //        divSusccess.Visible = true;
        //        lblSuccess.Text = "Data Send to Rechilling Process Successfully";
        //        pnlError.Update();
        //        //GetRechillDetails();
        //    }
        //    else
        //    {
        //        divDanger.Visible = false;
        //        divwarning.Visible = true;
        //        divSusccess.Visible = false;
        //        lblSuccess.Text = "Something went wrong plz contact site admin";
        //        pnlError.Update();
        //    }

        //}
        //else
        //{

        //}
    }



    //protected void txtTemperature_TextChanged(object sender, EventArgs e)
    //{
    //    if (Convert.ToDouble(txtTemperature.Text) > 4.00)
    //    {
    //        dpQCDetails.SelectedIndex = 4;
    //        dpQCDetails.Enabled = false;
    //    }
    //    else
    //    {
    //        //txtTemperature.Text = string.Empty;

    //        dpQCDetails.Enabled = true;
    //        dpQCDetails.ClearSelection();
    //        dpQCDetails.Items.FindByText("Re-Chilling").Enabled = false;
    //    }

    //}

    //public void GetRechillDetails()
    //{

    //    chilldata = new MRechilling();
    //    DataSet DS = new DataSet();
    //    DS = chilldata.

    //    if (!Comman.Comman.IsDataSetEmpty(DS))
    //    {

    //        rpQualityList.DataSource = DS;
    //        rpQualityList.DataBind();
    //    }

   
  

}
 
