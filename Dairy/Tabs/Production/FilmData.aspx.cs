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
    public partial class FilmData : System.Web.UI.Page
    {
        MFilmData mdata;
        BFilmData bdata;
        DataSet DS = new DataSet();
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDwon();
                txtDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                txtSearchDate.Text= Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                //GetFilmDetails();
                txtBatchNo.ReadOnly = true;
                
            }
        }

        protected void BindDropDwon()
        {
            DS = new DataSet();
            DS = BindCommanData.BindCommanDropDwon("ShiftId", "ShiftName as Name", "ShiftMaster", "IsActive =1");
            dpShiftDetails.DataSource = DS;
            dpShiftDetails.DataBind();
            dpShiftDetails.Items.Insert(0, new ListItem("--Select Shift--", "0"));

            DS = BindCommanData.BindCommanDropDwon("StatusId", "StatusName as Name", "Prod_StatusDetails", "IsActive =1");
            dpFilmDetailsStatusId.DataSource = DS;
            dpFilmDetailsStatusId.DataBind();
            dpFilmDetailsStatusId.Items.Insert(0, new ListItem("--Select Status--", "0"));
            dpFilmDetailsStatusId.Items.FindByText("Release").Enabled = false;
            dpFilmDetailsStatusId.Items.FindByText("Hold").Enabled = false;
            dpFilmDetailsStatusId.Items.FindByText("Yes").Enabled = false;
            dpFilmDetailsStatusId.Items.FindByText("No").Enabled = false;
        }

     

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            {

                mdata = new MFilmData();
                bdata = new BFilmData();
                int Result = 0;
                mdata.FilmDataId = 0;
                mdata.RMRId = string.IsNullOrEmpty(hId.Value) ? 0 : Convert.ToInt32(hId.Value);
                mdata.FilmDate = Convert.ToDateTime(txtDate.Text.ToString());
                mdata.ShiftId = Convert.ToInt32(dpShiftDetails.SelectedItem.Value);
                mdata.Product = string.IsNullOrEmpty(txtProduct.Text) ? string.Empty : txtProduct.Text;
                mdata.CommodityWise = string.IsNullOrEmpty(txtCommodityWise.Text) ? string.Empty : (txtCommodityWise.Text);
                mdata.OpeningStock = string.IsNullOrEmpty(txtOpeningStock.Text) ? 0 : Convert.ToDouble(txtOpeningStock.Text);
                mdata.ReceivedQty = string.IsNullOrEmpty(txtReceivedQty.Text) ? 0 : Convert.ToDouble(txtReceivedQty.Text);
                mdata.CalculateConsumedQty = string.IsNullOrEmpty(txtCalculateConsumedQty.Text) ? 0 : Convert.ToDouble(txtCalculateConsumedQty.Text);
                mdata.Wastage = string.IsNullOrEmpty(txtWastage.Text) ? 0 : Convert.ToDouble(txtWastage.Text);
                mdata.ClosingStock = string.IsNullOrEmpty(txtClosingStock.Text) ? 0 : Convert.ToDouble(txtClosingStock.Text);
                mdata.MilkType = string.IsNullOrEmpty(txtMilkType.Text)? string.Empty : txtMilkType.Text;
                mdata.FilmDetailsStatusId = Convert.ToInt32(dpFilmDetailsStatusId.SelectedItem.Value);
                mdata.flag = "Insert";
                Result = bdata.filmdata(mdata);
                if (Result > 0)
                {
                    divDanger.Visible = false;
                    divwarning.Visible = false;
                    divSusccess.Visible = true;
                   
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "sel3", "$('#bx1').addClass('collapsed-box');", true);

                    //string dates = string.IsNullOrEmpty(txtSearchDate.Text) ? string.Empty : Convert.ToDateTime(txtSearchDate.Text).ToString("dd-MM-yyyy");
                    //GetFilmDetails(dates);
                    RMRecieve R = new RMRecieve();
                    R.RMRDate = Convert.ToDateTime(txtSearchDate.Text);
                    GetFilmDetails(R);
                    uprouteList.Update();
                    lblSuccess.Text = "Film Data Added Successfully";
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

                mdata = new MFilmData();
                bdata = new BFilmData();
                int Result = 0;
                mdata.FilmDataId = 0;
                mdata.RMRId = string.IsNullOrEmpty(hId.Value) ? 0 : Convert.ToInt32(hId.Value);
                mdata.FilmDate = Convert.ToDateTime(txtDate.Text.ToString());
                mdata.ShiftId = Convert.ToInt32(dpShiftDetails.SelectedItem.Value);
                mdata.Product = string.IsNullOrEmpty(txtProduct.Text) ? string.Empty : txtProduct.Text;
                mdata.CommodityWise = string.IsNullOrEmpty(txtCommodityWise.Text) ? string.Empty : (txtCommodityWise.Text);
                mdata.OpeningStock = string.IsNullOrEmpty(txtOpeningStock.Text) ? 0 : Convert.ToDouble(txtOpeningStock.Text);
                mdata.ReceivedQty = string.IsNullOrEmpty(txtReceivedQty.Text) ? 0 : Convert.ToDouble(txtReceivedQty.Text);
                mdata.CalculateConsumedQty = string.IsNullOrEmpty(txtCalculateConsumedQty.Text) ? 0 : Convert.ToDouble(txtCalculateConsumedQty.Text);
                mdata.Wastage = string.IsNullOrEmpty(txtWastage.Text) ? 0 : Convert.ToDouble(txtWastage.Text);
                mdata.ClosingStock = string.IsNullOrEmpty(txtClosingStock.Text) ? 0 : Convert.ToDouble(txtClosingStock.Text);
                mdata.MilkType = string.IsNullOrEmpty(txtMilkType.Text) ? string.Empty : txtMilkType.Text;
                mdata.FilmDetailsStatusId = Convert.ToInt32(dpFilmDetailsStatusId.SelectedItem.Value);
                mdata.flag = "Update";
                Result = bdata.filmdata(mdata);
                if (Result > 0)
                {
                    divDanger.Visible = false;
                    divwarning.Visible = false;
                    divSusccess.Visible = true;
                   
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "sel3", "$('#bx1').addClass('collapsed-box');", true);
                   
                    //string dates = string.IsNullOrEmpty(txtSearchDate.Text) ? string.Empty : Convert.ToDateTime(txtSearchDate.Text).ToString("dd-MM-yyyy");
                    //GetFilmDetails(dates);
                    RMRecieve R = new RMRecieve();
                    R.RMRDate = Convert.ToDateTime(txtSearchDate.Text);
                    GetFilmDetails(R);
                    uprouteList.Update();
                    lblSuccess.Text = "Film Data Updated  Successfully";
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

        protected void rpFilmDataList_ItemCommand(object source, RepeaterCommandEventArgs e)
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
                        lblHeaderTab.Text = "Edit FilmData Details";
                        hId.Value = Id.ToString();
                        Id = Convert.ToInt32(hId.Value);
                        GetFilmDetails(Id);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "sel3", "$('#bx1').removeClass('collapsed-box');", true);
                        if (dpFilmDetailsStatusId.SelectedIndex==1)
                        {
                            btnAdd.Visible = false;
                            btnUpdate.Visible = true;
                        }
                        else
                        {
                            btnAdd.Visible = true;
                            btnUpdate.Visible = false;
                        }

                      
                        btnRefresh.Visible = true;
                      
                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }
            }
        }

        public void GetFilmDetails(RMRecieve R)
        {
            bdata = new BFilmData();
            DataSet DS = new DataSet();
            DS = bdata.GetFilmDetails(R);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                rpFilmDataList.DataSource = DS;
                rpFilmDataList.DataBind();
            }
            else if (DS.Tables[0].Rows.Count == 0)
            {
                rpFilmDataList.DataSource = DS;
                rpFilmDataList.DataBind();
            }
        }


        public void GetFilmDetails(int RMRId)
        {
            DataSet DS = new DataSet();
            bdata = new BFilmData();
            DS = bdata.GetFilmDetailsById(RMRId);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                string DATE = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["FilmDate"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["FilmDate"].ToString();
                //sky
                if (DATE == "")
                {
                    txtDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                }
                else
                {
                    DateTime date1 = Convert.ToDateTime(DATE, System.Globalization.CultureInfo.GetCultureInfo("ur-PK").DateTimeFormat);
                    txtDate.Text = (Convert.ToDateTime(date1).ToString("yyyy-MM-dd"));
                }
                txtBatchNo.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["BatchNo"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["BatchNo"].ToString();
                //txtDate.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Date"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Date"].ToString();
                //dpShiftDetails.SelectedValue = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["ShiftId"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["ShiftId"].ToString();
                dpShiftDetails.ClearSelection();
                string ShiftDetails = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["ShiftId"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["ShiftId"].ToString();
                if (ShiftDetails == "")
                {
                    dpShiftDetails.SelectedIndex = 0;
                }
                else
                {                   
                        dpShiftDetails.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["ShiftId"]).ToString()).Selected = true;                   
                }
                txtProduct.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Product"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Product"].ToString();
                txtCommodityWise.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["CommodityWise"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["CommodityWise"].ToString();
                txtOpeningStock.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["OpeningStock"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["OpeningStock"].ToString();
                txtReceivedQty.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["ReceivedQty"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["ReceivedQty"].ToString();
                txtCalculateConsumedQty.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["CalculateConsumedQty"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["CalculateConsumedQty"].ToString();
                txtWastage.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Wastage"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Wastage"].ToString();
                txtClosingStock.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["ClosingStock"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["ClosingStock"].ToString();
                txtMilkType.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["MilkType"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["MilkType"].ToString();

                dpFilmDetailsStatusId.ClearSelection();
                string FilmDetailsStatusId = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["FilmDetailsStatusId"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["FilmDetailsStatusId"].ToString();
                if(FilmDetailsStatusId=="")
                {
                    dpFilmDetailsStatusId.SelectedIndex = 2;
                }
                else
                {
                    dpFilmDetailsStatusId.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["FilmDetailsStatusId"]).ToString()).Selected = true;

                }
            }

        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                //string dates = Convert.ToDateTime(txtSearchDate.Text).ToString("dd-MM-yyyy");
                //GetFilmDetails(dates);
                RMRecieve R = new RMRecieve();
                R.RMRDate = Convert.ToDateTime(txtSearchDate.Text);
                GetFilmDetails(R);
            }
            catch (Exception) { }
        }
    }
  }
