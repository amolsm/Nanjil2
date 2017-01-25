using Bussiness;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dairy.App_code;

namespace Dairy.Tabs.Administration
{
    public partial class Cashier : System.Web.UI.Page
    {
        DataSet DS = new DataSet();
       double totaldenominationamt = 0.00;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hftokanno.Value = Comman.Comman.RandomString();
                BindDropDwon();
            }

        }


        public void BindDropDwon()
        {
            DS = BindCommanData.BindCommanDropDwon("EmployeeID", "EmployeeCode+' '+EmployeeName as Name", "employeemaster", "IsArchive=0 and (Designation='Sales Man' or Designation='Driver')");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpSalesman.DataSource = DS;
                dpSalesman.DataBind();
                dpSalesman.Items.Insert(0, new ListItem("Agent Sales Person", "0"));


            }
            txtOrderDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));

        }


        protected void btnSearch_Click(object sender, EventArgs e)
        {
            double agentcredit = 0.00;
            double emp = 0.00;
            double agentcash = 0.00;
            double totalsales = 0.00;
            DataSet ds = new DataSet();
            DispatchData dispatchData = new DispatchData();
            string Date = Convert.ToDateTime(txtOrderDate.Text).ToString("dd-MM-yyyy");
          
            int salesmanid = Convert.ToInt32(dpSalesman.SelectedItem.Value);
            ds = dispatchData.GetCashier(Date, salesmanid);
            if (!Comman.Comman.IsDataSetEmpty(ds))
            {

                Label1.Text = string.Empty;
                Label2.Text = string.Empty;
                Label3.Text = string.Empty;
                Label4.Text = string.Empty;



                try
                {
                    agentcredit = Convert.ToDouble(ds.Tables[0].Rows[0]["AgencySale"]);
                }
                catch { agentcredit = 0.00; }
                try
                {
                    agentcash = Convert.ToDouble(ds.Tables[1].Rows[0]["AgencySale"]);
                }
                catch { agentcash = 0.00; }
                try
                {
                    emp = Convert.ToDouble(ds.Tables[2].Rows[0]["EmployeeSale"]);
                }
                catch { emp = 0.00; }
                totalsales = agentcredit + agentcash + emp;
                Label1.Text = totalsales.ToString();
                Label2.Text = emp.ToString();
                Label3.Text = agentcredit.ToString();
                Label4.Text = agentcash.ToString();
                rpRouteList.Visible = true;
                uprouteList.Update();

                if (ds.Tables[3].Rows.Count != 0)
                {
                    rpRouteList.DataSource = ds.Tables[3];
                    rpRouteList.DataBind();
                    uprouteList.Update();
                }
                else if (ds.Tables[4].Rows.Count != 0)
                {
                    rpRouteList.DataSource = ds.Tables[4];
                    rpRouteList.DataBind();
                    uprouteList.Update();
                }

                else if (ds.Tables[4].Rows.Count == 0)
                {
                    DataTable dt = new DataTable();
                    if (Label4.Text == "0" || Label4.Text == string.Empty)
                    {
                        this.BindRepeater(dt);
                        rpRouteList.Visible = true;
                        uprouteList.Update();

                    }
                    else
                    {
                        rpRouteList.DataSource = dt;
                        rpRouteList.DataBind();
                        Control FooterTemplate = rpRouteList.Controls[rpRouteList.Controls.Count - 1].Controls[0];
                        FooterTemplate.FindControl("trEmpty1").Visible = true;
                    }


                }


            }
            else
            {
                Label1.Text = string.Empty;
                Label2.Text = string.Empty;
                Label3.Text = string.Empty;
                Label4.Text = string.Empty;
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
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            string totalamt=lbltotalamt.Text.ToString();
            string totalpayamt = txttotalPay.Text.ToString();
            if (confirmValue == "Yes" && totalamt==totalpayamt)
            {
                CashierData cd = new CashierData();
                Model.Cashier cm = new Model.Cashier();
                cm.DispatchDate = Convert.ToDateTime(txtOrderDate.Text).ToString("dd-MM-yyyy");
                cm.Salesmanid = Convert.ToInt32(dpSalesman.SelectedItem.Value);
                cm.trDate = DateTime.Now.ToString("dd-MM-yyyy");
                cm.netamt = string.IsNullOrEmpty(txtNetAmt.Text) ? 0 : Convert.ToDouble(txtNetAmt.Text);
                cm.payamt = string.IsNullOrEmpty(txttotalPay.Text) ? 0 : Convert.ToDouble(txttotalPay.Text);
                cm.rs2000 = string.IsNullOrEmpty(txt2000.Text) ? 0 : Convert.ToInt32(txt2000.Text);
                cm.rs1000 = string.IsNullOrEmpty(txt1000.Text) ? 0 : Convert.ToInt32(txt1000.Text);
                cm.rs500 = string.IsNullOrEmpty(txt500.Text) ? 0 : Convert.ToInt32(txt500.Text);
                cm.rs100 = string.IsNullOrEmpty(txt100.Text) ? 0 : Convert.ToInt32(txt100.Text);
                cm.rs50 = string.IsNullOrEmpty(txt50.Text) ? 0 : Convert.ToInt32(txt50.Text);
                cm.rs20 = string.IsNullOrEmpty(txt20.Text) ? 0 : Convert.ToInt32(txt20.Text);
                cm.rs10 = string.IsNullOrEmpty(txt10.Text) ? 0 : Convert.ToInt32(txt10.Text);
                cm.rscoins = string.IsNullOrEmpty(txtCoin.Text) ? 0 : Convert.ToDouble(txtCoin.Text);
                cm.TokanId = hftokanno.Value;
                cm.createdby = GlobalInfo.Userid;
                cm.flag = "insert";
                DataSet DS = new DataSet();
                DS = cd.AddCashierInfo(cm);
                if (DS.Tables[0].Rows.Count != 0)
                {

                    foreach (RepeaterItem item in rpRouteList.Items)
                    {
                        TextBox txtagencysalesamt = item.FindControl("txtAgencySales") as TextBox;
                        TextBox txtpaymentamt = item.FindControl("txtPayment") as TextBox;
                        HiddenField hdfID = item.FindControl("hfAgentId") as HiddenField;
                        int TrId;
                        TrId = Convert.ToInt32(DS.Tables[0].Rows[0]["TrId"]);
                        if (hdfID != null)
                        {

                            double agencysales;
                            try { agencysales = Convert.ToDouble(txtagencysalesamt.Text); } catch { agencysales = 0.00; }
                            string agentId = hdfID.Value;
                            double paymentsales;
                            try { paymentsales = Convert.ToDouble(txtpaymentamt.Text); } catch { paymentsales = 0.00; }
                            UpdateRecord(TrId, agentId, agencysales, paymentsales);
                        }
                    }
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
            else
            {
              ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                upModal.Update();

                //    //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You clicked NO!')", true);
            }

        }

        private void UpdateRecord(int TrId,string agentId, double agencysales, double paymentsales)
        {
            int result = 0;
            CashierData cashierdata = new CashierData();
            result = cashierdata.AddAgentCashSales(TrId,agentId, agencysales, paymentsales);
            if (result > 0)
            {

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Payment Details Update  Successfully";
                pnlError.Update();
                upModal.Update();
              
                UpdatePanel1.Update();
              
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

        protected void rpRouteList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            divDanger.Visible = false;
            divwarning.Visible = false;
            divSusccess.Visible = false;
            pnlError.Update();
            int salesmanid = 0;
            salesmanid = Convert.ToInt32(e.CommandArgument);


            switch (e.CommandName)
            {
                case ("Edit"):
                    {
                        //lbltital.Text = "Edit Route";
                        hfRow.Value = salesmanid.ToString();
                        salesmanid = Convert.ToInt32(hfRow.Value);
                        //BindRouteList();

                      //  GetRouteDetailsbyID(salesmanid);
                        //btnAddRoute.Visible = false;
                        //btnupdateroute.Visible = true;
                        // upMain.Update();
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "<script type='text/javascript'> $('#myModal').modal('show'); </script>", false);
                        // uprouteList.Update();
                        //  upModal.Update();
                        break;
                    }
                case ("delete"):
                    {

                        //hfrouteID.Value = routeID.ToString();
                        // routeID = Convert.ToInt32(hfrouteID.Value);
                        // DeleteRoutebyrouteID(routeID);
                        // BindRouteList();
                        //upMain.Update();
                        // uprouteList.Update();
                        break;
                    }


            }
        }

        protected void txtPayment_TextChanged(object sender, EventArgs e)
        {
            double salesamt;
            double payamt;
            double pendingamt;
           
            TextBox tb1 = ((TextBox)(sender));

            RepeaterItem rp1 = ((RepeaterItem)(tb1.NamingContainer));
            TextBox txtAgencySales = (TextBox)rp1.FindControl("txtAgencySales");
            try { salesamt = Convert.ToDouble(txtAgencySales.Text); }
            catch { salesamt = 0.00; }
            TextBox txtPaymentamt = (TextBox)rp1.FindControl("txtPayment");
            try { payamt = Convert.ToDouble(txtPaymentamt.Text); }
            catch { payamt = 0.00; }
            TextBox txtPending = (TextBox)rp1.FindControl("txtPending");
            pendingamt = salesamt - payamt;
            if (payamt > salesamt)
            {
                lblerrormsg.Text = "Payment Amount must be less than sales amount";
                txtPaymentamt.Text = string.Empty;
                txtPending.Text = string.Empty;
            }

            else { txtPending.Text = Convert.ToString(pendingamt); lblerrormsg.Text = string.Empty; }
          
            
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
           
          
            lblvalidate.Text = string.Empty;
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "<script type='text/javascript'> $('#myModal').modal('show'); </script>", false);
            txtNetAmt.Text = Label4.Text;
            double totalpaymentamt = 0.00;
            double totalpendingamt = 0.00;

            foreach (RepeaterItem item in rpRouteList.Items)
            {
                TextBox txtpaymentamt = item.FindControl("txtPayment") as TextBox;
                TextBox txtpendingamt = item.FindControl("txtPending") as TextBox;
                double paymentamt;
                try { paymentamt= Convert.ToDouble(txtpaymentamt.Text); } catch { paymentamt = 0.00; }
                double pendingamt;
                try { pendingamt = Convert.ToDouble(txtpendingamt.Text); } catch { pendingamt = 0.00; }
                totalpaymentamt += paymentamt;
                totalpendingamt += pendingamt;
             }
            txtPendingTotal.Text = totalpendingamt.ToString();
            txttotalPay.Text = totalpaymentamt.ToString();
            upModal.Update();


        }
        public bool validate()
        {
            double totalpayment;
            try { totalpayment = Convert.ToDouble(txttotalPay.Text); } catch { totalpayment = 0.00; } 
            if (totaldenominationamt > totalpayment)
            {
                lblvalidate.Text = "Enter Denomination Within Payment Amount";
                
                return true;
            }
            else
            {
                lblvalidate.Text = string.Empty;
                return false;
            }


        }
        protected void txtCoin_TextChanged(object sender, EventArgs e)
        {
           
            double coins;
            try
            {
                coins = Convert.ToDouble(txtCoin.Text);
            } catch { coins = 0.00; }
            lblcoins.Text = coins.ToString();
            try
            {
                coins = Convert.ToDouble(txtCoin.Text);
            }
            catch { coins = 0.00; }
            totaldenominationamt = AddAmount();
            lbltotalamt.Text = totaldenominationamt.ToString();
            bool IsValid = validate();
            if (IsValid == true)
            {
               
                totaldenominationamt -= coins;
                lbltotalamt.Text = totaldenominationamt.ToString();
                txtCoin.Text = string.Empty;
                lblcoins.Text = string.Empty;
            }


        }
       
        protected void txt10_TextChanged(object sender, EventArgs e)
        {
            double amt10;
            double totalamt10;
            try { amt10 = Convert.ToDouble(txt10.Text); } catch { amt10 = 0.00; }
            
            totalamt10=amt10 * 10.00;
            lbl10.Text = totalamt10.ToString();
            totaldenominationamt = AddAmount();
            lbltotalamt.Text = totaldenominationamt.ToString();
            bool IsValid=validate();
            if (IsValid==true)
            {
                
                totaldenominationamt -= totalamt10;
                lbltotalamt.Text = totaldenominationamt.ToString();
                txt10.Text = string.Empty;
                lbl10.Text = string.Empty;
            }
        }

        protected void txt20_TextChanged(object sender, EventArgs e)
        {
            double amt20;
            double totalamt20;
            try { amt20 = Convert.ToDouble(txt20.Text); } catch { amt20 = 0.00; }

            totalamt20 = amt20 * 20.00;
            lbl20.Text = totalamt20.ToString();
            totaldenominationamt = AddAmount();
            lbltotalamt.Text = totaldenominationamt.ToString();
            bool IsValid = validate();
            if (IsValid == true)
            {
               
                totaldenominationamt -= totalamt20;
                lbltotalamt.Text = totaldenominationamt.ToString();
                txt20.Text = string.Empty;
                lbl20.Text = string.Empty;
            }
        }

        protected void txt50_TextChanged(object sender, EventArgs e)
        {
            double amt50;
            double totalamt50;
            try { amt50 = Convert.ToDouble(txt50.Text); } catch { amt50 = 0.00; }

            totalamt50 = amt50 * 50.00;
            lbl50.Text = totalamt50.ToString();
            totaldenominationamt = AddAmount();
            lbltotalamt.Text = totaldenominationamt.ToString();
            bool IsValid = validate();
            if (IsValid == true)
            {
              
                totaldenominationamt -= totalamt50;
                lbltotalamt.Text = totaldenominationamt.ToString();
                txt50.Text = string.Empty;
                lbl50.Text = string.Empty;
            }

        }

        protected void txt100_TextChanged(object sender, EventArgs e)
        {
            double amt100;
            double totalamt100;
            try { amt100 = Convert.ToDouble(txt100.Text); } catch { amt100 = 0.00; }

            totalamt100 = amt100 * 100.00;
            lbl100.Text = totalamt100.ToString();
            totaldenominationamt = AddAmount();
            lbltotalamt.Text = totaldenominationamt.ToString();
            bool IsValid = validate();
            if (IsValid == true)
            {
                
                totaldenominationamt -= totalamt100;
                lbltotalamt.Text = totaldenominationamt.ToString();
                txt100.Text = string.Empty;
                lbl100.Text = string.Empty;
            }
        }

        protected void txt500_TextChanged(object sender, EventArgs e)
        {
            double amt500;
            double totalamt500;
            try { amt500 = Convert.ToDouble(txt500.Text); } catch { amt500 = 0.00; }

            totalamt500 = amt500 * 500.00;
            lbl500.Text = totalamt500.ToString();
            totaldenominationamt = AddAmount();
            lbltotalamt.Text = totaldenominationamt.ToString();
            bool IsValid = validate();
            if (IsValid == true)
            {
                
                totaldenominationamt -= totalamt500;
                lbltotalamt.Text = totaldenominationamt.ToString();
                txt500.Text = string.Empty;
                lbl500.Text = string.Empty;
            }
        }

        protected void txt1000_TextChanged(object sender, EventArgs e)
        {
            double amt1000;
            double totalamt1000;
            try { amt1000 = Convert.ToDouble(txt1000.Text); } catch { amt1000 = 0.00; }

            totalamt1000 = amt1000 * 1000.00;
            lbl1000.Text = totalamt1000.ToString();
            totaldenominationamt = AddAmount();
            lbltotalamt.Text = totaldenominationamt.ToString();
            bool IsValid = validate();
            if (IsValid == true)
            {
               
                totaldenominationamt -= totalamt1000;
                lbltotalamt.Text = totaldenominationamt.ToString();
                txt1000.Text = string.Empty;
                lbl1000.Text = string.Empty;
            }

        }

        protected void txt2000_TextChanged(object sender, EventArgs e)
        {
            double amt2000;
            double totalamt2000;
            try { amt2000 = Convert.ToDouble(txt2000.Text); } catch { amt2000 = 0.00; }

            totalamt2000 = amt2000 * 2000.00;
            lbl2000.Text = totalamt2000.ToString();
            totaldenominationamt = AddAmount();
            lbltotalamt.Text = totaldenominationamt.ToString();
            bool IsValid = validate();
            if (IsValid == true)
            {
               
                totaldenominationamt -= totalamt2000;
                lbltotalamt.Text = totaldenominationamt.ToString();
                txt2000.Text = string.Empty;
                lbl2000.Text = string.Empty;
            }
        }

        public double AddAmount()
        {
            double result = 0.00;
            try
            {
                double coins1;
                try{ coins1 = Convert.ToDouble(lblcoins.Text);}catch { coins1 = 0.00; }
                double amt10s;
            
                try { amt10s = Convert.ToDouble(lbl10.Text); } catch { amt10s = 0.00; }
                double amt20s;

                try { amt20s = Convert.ToDouble(lbl20.Text); } catch { amt20s = 0.00; }
                double amt50s;

                try { amt50s = Convert.ToDouble(lbl50.Text); } catch { amt50s = 0.00; }
                double amt100s;

                try { amt100s = Convert.ToDouble(lbl100.Text); } catch { amt100s = 0.00; }
                double amt500s;

                try { amt500s = Convert.ToDouble(lbl500.Text); } catch { amt500s = 0.00; }
                double amt1000s;

                try { amt1000s = Convert.ToDouble(lbl1000.Text); } catch { amt1000s = 0.00; }
                double amt2000s;

                try { amt2000s = Convert.ToDouble(lbl2000.Text); } catch { amt2000s = 0.00; }

                result = coins1 + amt10s + amt20s + amt50s + amt100s + amt500s + amt1000s + amt2000s;
            }
            catch { }
            return result;

        }

        protected void btnRefress_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Tabs/Administration/Cashier.aspx");
        }
    }

}