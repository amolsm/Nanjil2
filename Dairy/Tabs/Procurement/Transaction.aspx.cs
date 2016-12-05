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
            try
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
                        DS.Tables[0].Merge(DS.Tables[2], true, MissingSchemaAction.Add);
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

                      DataSet tds = new DataSet();
                    //Create transaction details  DataTable.
                       DataTable tbl=new DataTable();
                      // tbl = ds.Tables.Add("Transaction");
                       tbl.Columns.Add("SupplierID", typeof(int));
                     //  tbl.PrimaryKey = new DataColumn[] { tbl.Columns["SupplierID"] };

                        tbl.Columns.Add("SupplierCode", typeof(string));
                        tbl.Columns.Add("Amount", typeof(decimal));
                        tbl.Columns.Add("Bonus", typeof(decimal));
                        tbl.Columns.Add("Scheme", typeof(decimal));
                        tbl.Columns.Add("RDAmount", typeof(double));
                        tbl.Columns.Add("CanLoan", typeof(double));
                        tbl.Columns.Add("CashLoan", typeof(double));
                        tbl.Columns.Add("BankLoan", typeof(double));

                    foreach (DataRow row in DS.Tables[0].Rows)
                    {
                        foreach (DataRow rows in DS.Tables[1].Rows)
                       {
                      
                            if (row["SupplierID"].ToString() == rows["SupplierID"].ToString())
                                {
                                    DataRow trow = tbl.NewRow();
                                    trow["SupplierID"] = row["SupplierID"] ;
                                    trow["SupplierCode"] = row["SupplierCode"];
                                    trow["Amount"] = row["Amount"];
                                    trow["Bonus"] = rows["Bonus"];
                                    trow["Scheme"] = rows["Scheme"];
                                    trow["RDAmount"] = row["RDAmount"];
                                    trow["CanLoan"] = row["CanLoan"];
                                    trow["CashLoan"] = row["CashLoan"];
                                    trow["BankLoan"] = row["BankLoan"];
                                    tbl.Rows.Add(trow);
                                   
                                  }
                           
                        }
                        }
                    tds.Tables.Add(tbl);
                    rpRouteList.DataSource = tds;
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
                            netamt = amt - (scheme + rd + canloan + cashloan + bankloan);
                            txtNetAmt.Text = Convert.ToString(netamt);

                        }
                    }
                    catch { }

                }

          
            catch (Exception) {
                rpRouteList.DataSource = null;
                rpRouteList.DataBind();
                Label1.Visible = true;
                uprouteList.Update();

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
                int SupplierID = Convert.ToInt32(hdfID.Value);
                int RouteID = Convert.ToInt32(dpRoute.SelectedItem.Value);
                string PaymentDateTime = txtpaymentdate.Text;
                DateTime FomDate = Convert.ToDateTime(txtfromdate.Text);
                DateTime ToDate = Convert.ToDateTime(txttodate.Text);
                double Amount = string.IsNullOrEmpty(txtAmt.Text) ? 0 : Convert.ToDouble(txtAmt.Text);
                double Bonus = string.IsNullOrEmpty(txtBonus.Text) ? 0 : Convert.ToDouble(txtBonus.Text);
                decimal Scheme = string.IsNullOrEmpty(txtScheme.Text) ? 0 : Convert.ToDecimal(txtScheme.Text);
                double RDAmount = string.IsNullOrEmpty(txtRD.Text) ? 0 : Convert.ToDouble(txtRD.Text);
                double canloan = string.IsNullOrEmpty(txtcanloan.Text) ? 0 : Convert.ToDouble(txtcanloan.Text);
                double casloan = string.IsNullOrEmpty(txtcashloan.Text) ? 0 : Convert.ToDouble(txtcashloan.Text);
                double bankloan = string.IsNullOrEmpty(txtbankloan.Text) ? 0 : Convert.ToDouble(txtbankloan.Text);
                double netamt = string.IsNullOrEmpty(txtNetAmt.Text) ? 0 : Convert.ToDouble(txtNetAmt.Text);

                UpdateRecord(SupplierID, RouteID, PaymentDateTime, FomDate, ToDate, Amount, Bonus, Scheme, RDAmount, canloan, casloan, bankloan, netamt);
            }
        }

        protected void btnAddTransaction_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
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

                        int SupplierID = Convert.ToInt32(hdfID.Value);
                        int RouteID = Convert.ToInt32(dpRoute.SelectedItem.Value);
                        string PaymentDateTime = txtpaymentdate.Text;
                        DateTime FomDate = Convert.ToDateTime(txtfromdate.Text);
                        DateTime ToDate = Convert.ToDateTime(txttodate.Text);
                        double Amount = string.IsNullOrEmpty(txtAmt.Text) ? 0 : Convert.ToDouble(txtAmt.Text);
                        double Bonus = string.IsNullOrEmpty(txtBonus.Text) ? 0 : Convert.ToDouble(txtBonus.Text);
                        decimal Scheme = string.IsNullOrEmpty(txtScheme.Text) ? 0 : Convert.ToDecimal(txtScheme.Text);
                        double RDAmount = string.IsNullOrEmpty(txtRD.Text) ? 0 : Convert.ToDouble(txtRD.Text);
                        double canloan = string.IsNullOrEmpty(txtcanloan.Text) ? 0 : Convert.ToDouble(txtcanloan.Text);
                        double casloan = string.IsNullOrEmpty(txtcashloan.Text) ? 0 : Convert.ToDouble(txtcashloan.Text);
                        double bankloan = string.IsNullOrEmpty(txtbankloan.Text) ? 0 : Convert.ToDouble(txtbankloan.Text);
                        double netamt = string.IsNullOrEmpty(txtNetAmt.Text) ? 0 : Convert.ToDouble(txtNetAmt.Text);

                        UpdateRecord(SupplierID, RouteID, PaymentDateTime, FomDate, ToDate, Amount, Bonus, Scheme, RDAmount, canloan, casloan, bankloan, netamt);


                    }
                }
            }
        }
        private void UpdateRecord(int SupplierID, int RouteID, string PaymentDateTime, DateTime FomDate, DateTime ToDate, double Amount, double Bonus, decimal Scheme, double RDAmount, double canloan, double casloan, double bankloan, double netamt)
        {
            int result = 0;
            ProcurementData pd = new ProcurementData();
            result = pd.AddTransaction(SupplierID, RouteID, PaymentDateTime, FomDate, ToDate, Amount, Bonus, Scheme, RDAmount, canloan, casloan, bankloan, netamt);
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

        protected void txtRD_TextChanged(object sender, EventArgs e)
        {
            double amt;
            double bonus;
            double scheme;
            double rd;
            double canloan;
            double cashloan;
            double bankloan;
            double netamt;
            TextBox tb1 = ((TextBox)(sender));

            RepeaterItem rp1 = ((RepeaterItem)(tb1.NamingContainer));
            TextBox txtAmt = (TextBox)rp1.FindControl("txtAmt");
            try { amt = Convert.ToDouble(txtAmt.Text); }
            catch { amt = 0.00; }
            TextBox txtBonus = (TextBox)rp1.FindControl("txtBonus");
            try { bonus = Convert.ToDouble(txtBonus.Text); }
            catch { bonus = 0.00; }
            TextBox txtScheme = (TextBox)rp1.FindControl("txtScheme");
            try { scheme = Convert.ToDouble(txtScheme.Text); }
            catch { scheme = 0.00; }
            TextBox txtRD = (TextBox)rp1.FindControl("txtRD");
            try { rd = Convert.ToDouble(txtRD.Text); }
            catch { rd = 0.00; }
            TextBox txtcanloan = (TextBox)rp1.FindControl("txtcanloan");
            try { canloan = Convert.ToDouble(txtcanloan.Text); }
            catch { canloan = 0.00; }
            TextBox txtcashloan = (TextBox)rp1.FindControl("txtcashloan");
            try { cashloan = Convert.ToDouble(txtcashloan.Text); }
            catch { cashloan = 0.00; }
            TextBox txtbankloan = (TextBox)rp1.FindControl("txtbankloan");
            try { bankloan = Convert.ToDouble(txtbankloan.Text); }
            catch { bankloan = 0.00; }
            TextBox txtNetAmt = (TextBox)rp1.FindControl("txtNetAmt");
            
            netamt = amt - (scheme + rd + canloan + cashloan + bankloan);
            txtNetAmt.Text = Convert.ToString(netamt);
           
        }

        protected void txtcanloan_TextChanged(object sender, EventArgs e)
        {
            double amt;
            double bonus;
            double scheme;
            double rd;
            double canloan;
            double cashloan;
            double bankloan;
            double netamt;
            TextBox tb1 = ((TextBox)(sender));

            RepeaterItem rp1 = ((RepeaterItem)(tb1.NamingContainer));
            TextBox txtAmt = (TextBox)rp1.FindControl("txtAmt");
            try { amt = Convert.ToDouble(txtAmt.Text); }
            catch { amt = 0.00; }
            TextBox txtBonus = (TextBox)rp1.FindControl("txtBonus");
            try { bonus = Convert.ToDouble(txtBonus.Text); }
            catch { bonus = 0.00; }
            TextBox txtScheme = (TextBox)rp1.FindControl("txtScheme");
            try { scheme = Convert.ToDouble(txtScheme.Text); }
            catch { scheme = 0.00; }
            TextBox txtRD = (TextBox)rp1.FindControl("txtRD");
            try { rd = Convert.ToDouble(txtRD.Text); }
            catch { rd = 0.00; }
            TextBox txtcanloan = (TextBox)rp1.FindControl("txtcanloan");
            try { canloan = Convert.ToDouble(txtcanloan.Text); }
            catch { canloan = 0.00; }
            TextBox txtcashloan = (TextBox)rp1.FindControl("txtcashloan");
            try { cashloan = Convert.ToDouble(txtcashloan.Text); }
            catch { cashloan = 0.00; }
            TextBox txtbankloan = (TextBox)rp1.FindControl("txtbankloan");
            try { bankloan = Convert.ToDouble(txtbankloan.Text); }
            catch { bankloan = 0.00; }
            TextBox txtNetAmt = (TextBox)rp1.FindControl("txtNetAmt");

            netamt = amt - (scheme + rd + canloan + cashloan + bankloan);
            txtNetAmt.Text = Convert.ToString(netamt);

        }

        protected void txtcashloan_TextChanged(object sender, EventArgs e)
        {
            double amt;
            double bonus;
            double scheme;
            double rd;
            double canloan;
            double cashloan;
            double bankloan;
            double netamt;
            TextBox tb1 = ((TextBox)(sender));

            RepeaterItem rp1 = ((RepeaterItem)(tb1.NamingContainer));
            TextBox txtAmt = (TextBox)rp1.FindControl("txtAmt");
            try { amt = Convert.ToDouble(txtAmt.Text); }
            catch { amt = 0.00; }
            TextBox txtBonus = (TextBox)rp1.FindControl("txtBonus");
            try { bonus = Convert.ToDouble(txtBonus.Text); }
            catch { bonus = 0.00; }
            TextBox txtScheme = (TextBox)rp1.FindControl("txtScheme");
            try { scheme = Convert.ToDouble(txtScheme.Text); }
            catch { scheme = 0.00; }
            TextBox txtRD = (TextBox)rp1.FindControl("txtRD");
            try { rd = Convert.ToDouble(txtRD.Text); }
            catch { rd = 0.00; }
            TextBox txtcanloan = (TextBox)rp1.FindControl("txtcanloan");
            try { canloan = Convert.ToDouble(txtcanloan.Text); }
            catch { canloan = 0.00; }
            TextBox txtcashloan = (TextBox)rp1.FindControl("txtcashloan");
            try { cashloan = Convert.ToDouble(txtcashloan.Text); }
            catch { cashloan = 0.00; }
            TextBox txtbankloan = (TextBox)rp1.FindControl("txtbankloan");
            try { bankloan = Convert.ToDouble(txtbankloan.Text); }
            catch { bankloan = 0.00; }
            TextBox txtNetAmt = (TextBox)rp1.FindControl("txtNetAmt");

            netamt = amt - (scheme + rd + canloan + cashloan + bankloan);
            txtNetAmt.Text = Convert.ToString(netamt);

        }

        protected void txtbankloan_TextChanged(object sender, EventArgs e)
        {
            double amt;
            double bonus;
            double scheme;
            double rd;
            double canloan;
            double cashloan;
            double bankloan;
            double netamt;
            TextBox tb1 = ((TextBox)(sender));

            RepeaterItem rp1 = ((RepeaterItem)(tb1.NamingContainer));
            TextBox txtAmt = (TextBox)rp1.FindControl("txtAmt");
            try { amt = Convert.ToDouble(txtAmt.Text); }
            catch { amt = 0.00; }
            TextBox txtBonus = (TextBox)rp1.FindControl("txtBonus");
            try { bonus = Convert.ToDouble(txtBonus.Text); }
            catch { bonus = 0.00; }
            TextBox txtScheme = (TextBox)rp1.FindControl("txtScheme");
            try { scheme = Convert.ToDouble(txtScheme.Text); }
            catch { scheme = 0.00; }
            TextBox txtRD = (TextBox)rp1.FindControl("txtRD");
            try { rd = Convert.ToDouble(txtRD.Text); }
            catch { rd = 0.00; }
            TextBox txtcanloan = (TextBox)rp1.FindControl("txtcanloan");
            try { canloan = Convert.ToDouble(txtcanloan.Text); }
            catch { canloan = 0.00; }
            TextBox txtcashloan = (TextBox)rp1.FindControl("txtcashloan");
            try { cashloan = Convert.ToDouble(txtcashloan.Text); }
            catch { cashloan = 0.00; }
            TextBox txtbankloan = (TextBox)rp1.FindControl("txtbankloan");
            try { bankloan = Convert.ToDouble(txtbankloan.Text); }
            catch { bankloan = 0.00; }
            TextBox txtNetAmt = (TextBox)rp1.FindControl("txtNetAmt");

            netamt = amt - (scheme + rd + canloan + cashloan + bankloan);
            txtNetAmt.Text = Convert.ToString(netamt);

        }

     
    }
}