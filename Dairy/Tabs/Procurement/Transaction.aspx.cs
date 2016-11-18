using Bussiness;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dairy.Tabs.Procurement
{
    public partial class Transaction : System.Web.UI.Page
    {
        DataSet DS = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDown();
                txtpaymentdate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                
            }
            }
        public void BindDropDown()
        {
            DS = BindCommanData.BindCommanDropDwon("RouteID ", "RouteCode +' '+RouteName as Name  ", "Proc_MilkCollectionRoute", "IsActive=1 ");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpRoute.DataSource = DS;
                dpRoute.DataBind();
                dpRoute.Items.Insert(0, new ListItem("--Select Route  --", "0"));
            }
        }
        protected void dpRoute_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ProcurementData pd = new ProcurementData();
            Model.Procurement p = new Model.Procurement();
            p.RouteID = Convert.ToInt32(dpRoute.SelectedItem.Value);
            p.FomDate = Convert.ToDateTime(txtfromdate.Text);
            p.ToDate = Convert.ToDateTime(txttodate.Text);
            DataSet DS = new DataSet();
            DS = pd.GetTransactionDetails(p);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                try
                {
                    DS.Tables[0].PrimaryKey = new[] { DS.Tables[0].Columns["SupplierID"] };
                }
                catch (Exception) { }
               
                try
                {
                    DS.Tables[2].PrimaryKey = new[] { DS.Tables[2].Columns["SupplierID"] };
                }
                catch (Exception) { }
                try
                {
                    DS.Tables[3].PrimaryKey = new[] { DS.Tables[3].Columns["SupplierID"] };
                }
                catch (Exception) { }
                try
                {
                    DS.Tables[4].PrimaryKey = new[] { DS.Tables[4].Columns["SupplierID"] };
                }
                catch (Exception) { }
                try
                {
                    DS.Tables[5].PrimaryKey = new[] { DS.Tables[5].Columns["SupplierID"] };
                }
                catch (Exception) { }

                try
                {
                    DS.Tables[0].Merge(DS.Tables[2], false, MissingSchemaAction.Add);
                }
                catch (Exception) { }
                try
                {
                    DS.Tables[0].Merge(DS.Tables[3], false, MissingSchemaAction.Add);
                }
                catch (Exception) { }
                try
                {
                    DS.Tables[0].Merge(DS.Tables[4], false, MissingSchemaAction.Add);
                }
                catch (Exception) { }
                try
                {
                    DS.Tables[0].Merge(DS.Tables[5], false, MissingSchemaAction.Add);
                }
                catch (Exception) { }

                try
                {
                    DS.Tables[0].Columns.Add("Scheme", typeof(decimal));
                    DS.Tables[0].Columns.Add("Bonus", typeof(decimal));
                    foreach (DataRow row in DS.Tables[0].Rows)
                    {
                        foreach (DataRow rows in DS.Tables[1].Rows)
                        {
                            if (row["Category"].ToString() == rows["Category"].ToString())
                            {
                                row["Scheme"] = rows["Scheme"];
                                row["Bonus"] = rows["Bonus"];
                            }
                        }
                    }
                    
                    rpRouteList.DataSource = DS;
                    rpRouteList.DataBind();
                    //rpBrandInfo.Visible = true;
                    uprouteList.Update();
                    foreach (RepeaterItem item in rpRouteList.Items)
                    {
                        double amt;
                        double bonus;
                        double scheme;
                        double rd;
                        double canloan;
                        double cashloan;
                        double bankloan;
                        double netamt;
                        TextBox txtAmt = item.FindControl("txtAmt") as TextBox;
                        try { amt = Convert.ToDouble(txtAmt.Text); }
                        catch { amt = 0.00; }
                         
                        TextBox txtBonus = item.FindControl("txtBonus") as TextBox;
                        try { bonus = Convert.ToDouble(txtBonus.Text); }
                        catch { bonus = 0.00; }

                        TextBox txtScheme = item.FindControl("txtScheme") as TextBox;
                         scheme = Convert.ToDouble(txtScheme.Text);

                        TextBox txtRD = item.FindControl("txtRD") as TextBox;
                        try { rd = Convert.ToDouble(txtRD.Text); }
                        catch { rd = 0.00; }
                        
                        TextBox txtcanloan = item.FindControl("txtcanloan") as TextBox;
                        try { canloan = Convert.ToDouble(txtcanloan.Text); }
                        catch { canloan = 0.00; }

                        TextBox txtcashloan = item.FindControl("txtcashloan") as TextBox;
                        try { cashloan = Convert.ToDouble(txtcashloan.Text); }
                        catch { cashloan = 0.00; }

                        TextBox txtbankloan = item.FindControl("txtbankloan") as TextBox;
                        try { bankloan = Convert.ToDouble(txtbankloan.Text); }
                        catch { bankloan = 0.00; }

                        TextBox txtNetAmt = item.FindControl("txtNetAmt") as TextBox;
                         netamt = 0.00;
                        netamt = amt - (bonus + scheme + rd + canloan+cashloan+bankloan);
                        txtNetAmt.Text = Convert.ToString(netamt);

                    }
                }
                catch { }

            }
        }

        protected void rpRouteList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            TextBox txtAmt = e.Item.FindControl("txtAmt") as TextBox;
            TextBox txtBonus = e.Item.FindControl("txtBonus") as TextBox;
            TextBox txtScheme = e.Item.FindControl("txtScheme") as TextBox;
            TextBox txtRD = e.Item.FindControl("txtRD") as TextBox;
            TextBox txtcanloan = e.Item.FindControl("txtcanloan") as TextBox;
            TextBox txtcashloan = e.Item.FindControl("txtcashloan") as TextBox;
            TextBox txtbankloan = e.Item.FindControl("txtbankloan") as TextBox;
            TextBox txtNetAmt = e.Item.FindControl("txtNetAmt") as TextBox;

            HiddenField hdfID = e.Item.FindControl("hfSupplierID") as HiddenField;
            if (hdfID != null)
            {
                Model.Procurement p = new Model.Procurement();
                p.SupplierID = Convert.ToInt32(hdfID.Value);
                p.RouteID = Convert.ToInt32(dpRoute.SelectedItem.Value);
                p.PaymentDateTime = txtpaymentdate.Text;
                p.FomDate = Convert.ToDateTime(txtfromdate.Text);
                p.ToDate = Convert.ToDateTime(txttodate.Text);
                p.Amount = string.IsNullOrEmpty(txtAmt.Text) ? 0 : Convert.ToDouble(txtAmt.Text);
                p.Bonus = string.IsNullOrEmpty(txtBonus.Text) ? 0 : Convert.ToDouble(txtBonus.Text);
                p.Scheme = string.IsNullOrEmpty(txtScheme.Text) ? 0 : Convert.ToDecimal(txtScheme.Text);
                p.RDAmount = string.IsNullOrEmpty(txtRD.Text) ? 0 : Convert.ToDouble(txtRD.Text);
                p.canloan = string.IsNullOrEmpty(txtcanloan.Text) ? 0 : Convert.ToDouble(txtcanloan.Text);
                p.casloan = string.IsNullOrEmpty(txtcashloan.Text) ? 0 : Convert.ToDouble(txtcashloan.Text);
                p.bankloan = string.IsNullOrEmpty(txtbankloan.Text) ? 0 : Convert.ToDouble(txtbankloan.Text);
                p.netamt = string.IsNullOrEmpty(txtNetAmt.Text) ? 0 : Convert.ToDouble(txtNetAmt.Text);

                UpdateRecord(p);
            }
        }

        protected void btnAddTransaction_Click(object sender, EventArgs e)
        {
            foreach (RepeaterItem item in rpRouteList.Items)
            {
                TextBox txtAmt = item.FindControl("txtAmt") as TextBox;
                TextBox txtBonus = item.FindControl("txtBonus") as TextBox;
                TextBox txtScheme = item.FindControl("txtScheme") as TextBox;
                TextBox txtRD = item.FindControl("txtRD") as TextBox;
                TextBox txtcanloan = item.FindControl("txtcanloan") as TextBox;
                TextBox txtcashloan = item.FindControl("txtcashloan") as TextBox;
                TextBox txtbankloan = item.FindControl("txtbankloan") as TextBox;
                TextBox txtNetAmt = item.FindControl("txtNetAmt") as TextBox;

                HiddenField hdfID = item.FindControl("hfSupplierID") as HiddenField;
                if (hdfID != null)
                {
                    Model.Procurement p = new Model.Procurement();
                    p.SupplierID = Convert.ToInt32(hdfID.Value);
                    p.RouteID = Convert.ToInt32(dpRoute.SelectedItem.Value);
                    p.PaymentDateTime = txtpaymentdate.Text;
                    p.FomDate = Convert.ToDateTime(txtfromdate.Text);
                    p.ToDate = Convert.ToDateTime(txttodate.Text);
                    p.Amount = string.IsNullOrEmpty(txtAmt.Text) ? 0 : Convert.ToDouble(txtAmt.Text);
                    p.Bonus = string.IsNullOrEmpty(txtBonus.Text) ? 0 : Convert.ToDouble(txtBonus.Text);
                    p.Scheme = string.IsNullOrEmpty(txtScheme.Text) ? 0 : Convert.ToDecimal(txtScheme.Text);
                    p.RDAmount = string.IsNullOrEmpty(txtRD.Text) ? 0 : Convert.ToDouble(txtRD.Text);
                    p.canloan = string.IsNullOrEmpty(txtcanloan.Text) ? 0 : Convert.ToDouble(txtcanloan.Text);
                    p.casloan = string.IsNullOrEmpty(txtcashloan.Text) ? 0 : Convert.ToDouble(txtcashloan.Text);
                    p.bankloan = string.IsNullOrEmpty(txtbankloan.Text) ? 0 : Convert.ToDouble(txtbankloan.Text);
                    p.netamt = string.IsNullOrEmpty(txtNetAmt.Text) ? 0 : Convert.ToDouble(txtNetAmt.Text);
                   
                    UpdateRecord(p);
                }
            }
        }
        private void UpdateRecord(Model.Procurement p)
        {
            int result = 0;
            ProcurementData pd = new ProcurementData();
            result = pd.AddTransaction(p);
            if (result > 0)
            {

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Transaction Updated  Successfully";
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

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Tabs/Procurement/Transaction.aspx");
        }
    }
}