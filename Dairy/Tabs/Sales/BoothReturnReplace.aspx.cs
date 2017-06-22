﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using Bussiness;
using System.Data;
using Comman;
using System.Text;
using Dairy.App_code;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Security;
using System.Web.Services;


namespace Dairy.Tabs.Sales
{
    public partial class BoothReturnReplace : System.Web.UI.Page
    {
        ProductData productdata;
        Product product;
        DataSet DS = new DataSet();
        //static int Id = 0;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindListDetails();

            }
            if (Context.Session != null && Context.Session.IsNewSession == true &&
  Page.Request.Headers["Cookie"] != null &&
  Page.Request.Headers["Cookie"].IndexOf("ASP.NET_SessionId") >= 0)
            {
                // session has timed out, log out the user
                if (Page.Request.IsAuthenticated)
                {
                    FormsAuthentication.SignOut();
                }
                // redirect to timeout page
                Page.Response.Redirect("/Authentication/LoginT.aspx");
            }
        }

        private void BindListDetails()
        {
            int boothid = GlobalInfo.CurrentbothID;
            productdata = new ProductData();
            DataSet DS = new DataSet();
            DS = productdata.GetStockDetails(boothid);

            if (!Comman.Comman.IsDataSetEmpty(DS))
            {

                rpDesigList.DataSource = DS;
                rpDesigList.DataBind();
            }


        }

        protected void rpDesigList_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {

            int ids = 0;
            ids = Convert.ToInt32(e.CommandArgument);
            hfId.Value = ids.ToString();
            switch (e.CommandName)
            {
                case ("Edit"):
                    {
                        openModal();
                        break;
                    }
                case ("delete"):
                    {

                        
                        break;
                    }


            }

        }

        private void openModal()
        {
            int ids = 0;
            ids = Convert.ToInt32(hfId.Value);
            int boothid = GlobalInfo.CurrentbothID;
            productdata = new ProductData();
            DataSet DS = new DataSet();
            DS = productdata.GetStockDetails(boothid);
            // DataTable dt = DS.Tables[0];
            var query = from dts in DS.Tables[0].AsEnumerable()
                        where dts.Field<int>("BoothStockDetailsID") == ids
                        select dts.Field<string>("ProductName");



            var query1 = from dts in DS.Tables[0].AsEnumerable()
                         where dts.Field<int>("BoothStockDetailsID") == ids
                         select dts.Field<decimal>("StockAvailable");

            List<string> pname = query.ToList();
            List<decimal> stockavail = query1.ToList();

            txtProductName.Text = pname[0].ToString();
            txtStockAvail.Text = stockavail[0].ToString();
            txtReturn.Text = string.Empty;

            txtSpotDamaged.Text = string.Empty;
            txtOthers.Text = string.Empty;



            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "<script type='text/javascript'> $('#myModal').modal('show'); </script>", false);
            uprouteList.Update();
            upModal.Update();
        }

        protected void btnClick_btnUpdate(object sender, EventArgs e)
        {
            
                int result = 0;
                double avail = 0;
            try
            {
                Product prod = new Product();
                productdata = new ProductData();
                prod.Return = string.IsNullOrEmpty(txtReturn.Text) ? 0 : Convert.ToDouble(txtReturn.Text);
                prod.Replace = string.IsNullOrEmpty(txtReplace.Text) ? 0 : Convert.ToDouble(txtReplace.Text);
                prod.Other = string.IsNullOrEmpty(txtOthers.Text) ? 0 : Convert.ToDouble(txtOthers.Text);
                prod.Incentive = string.IsNullOrEmpty(txtIncentive.Text) ? 0 : Convert.ToDouble(txtIncentive.Text);
                prod.SpotDamage = string.IsNullOrEmpty(txtSpotDamaged.Text) ? 0 : Convert.ToDouble(txtSpotDamaged.Text);
                prod.ID = Convert.ToInt32(hfId.Value);
                prod.UserID = GlobalInfo.Userid;
                prod.ShiftDate = DateTime.Now.ToString("dd-MM-yyyy");

                DataSet DS1 = new DataSet();
                DS1 = productdata.getStockbyId(Convert.ToInt32(hfId.Value));

                if (prod.Return >= 0 && prod.Replace >= 0 && prod.Other >= 0 && prod.Incentive >= 0 && prod.SpotDamage >= 0)
                {
                    avail = Convert.ToDouble(DS1.Tables[0].Rows[0]["StockAvailable"]);
                    if (avail >= (prod.Return + prod.Replace + prod.Other + prod.Incentive + prod.SpotDamage))
                    {
                        result = productdata.UpdateStockUser(prod);

                        if (result > 0)
                        {
                            divDanger.Visible = false;
                            divwarning.Visible = false;
                            divSusccess.Visible = true;
                            lblSuccess.Text = "Information Updated  Successfully";
                            txtReturn.Text = string.Empty;
                            txtReplace.Text = string.Empty;
                            txtOthers.Text = string.Empty;
                            txtIncentive.Text = string.Empty;
                            txtSpotDamaged.Text = string.Empty;
                            pnlError.Update();

                            BindListDetails();
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
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('More than Stock ')", true);
                        openModal();
                    }
                }
            
                    else { ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Enter Valid Quantity')", true); }
                }
                catch (Exception ex)
                {
                    string a = ex.ToString();
                    lblwarning.Text = "Invalid entry";
                }

            }
            
       
    }


    }
