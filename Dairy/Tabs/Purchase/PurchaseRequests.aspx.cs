using Bussiness;
using Dairy.App_code;
using Model.Purchase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dairy.Tabs.Purchase
{
    public partial class PurchaseRequests : System.Web.UI.Page
    {
        PurchaseData purchaseData;
        RequestCart requestCart;
        DataSet DS;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDown();
                hftokanno.Value = Comman.Comman.RandomString();
                
            }
        }

        private void BindDropDown()
        {
            DataSet DS = new DataSet();

            DS = BindCommanData.BindCommanDropDwon("ItemId as ID", "ItemName as Name", "Prchs_Items", "IsActive = 1");
            dpItem.DataSource = DS;
            dpItem.DataBind();
            dpItem.Items.Insert(0, new ListItem("--Select Item--", "0"));

            //DS = BindCommanData.BindCommanDropDwon("VendorId as ID", "VendorCode + ' ' +VendorName as Name", "Prchs_Vendor", "IsActive = 1");
            //dpVendor.DataSource = DS;
            //dpVendor.DataBind();
            //dpVendor.Items.Insert(0, new ListItem("--Select vendor--", "0"));

            DS = BindCommanData.BindCommanDropDwon("UnitID as ID", "UnitName as Name", "Unit", "UnitID is not NULL");
            dpUnit.DataSource = DS;
            dpUnit.DataBind();
            dpUnit.Items.Insert(0, new ListItem("--Select Unit--", "0"));
        }

        protected void btnAddItem_Click(object sender, EventArgs e)
        {
            requestCart = new RequestCart();
            purchaseData = new PurchaseData();
            requestCart.Tokan = hftokanno.Value;
            requestCart.RequestBy = GlobalInfo.Userid;

            requestCart.ItemId = Convert.ToInt32(dpItem.SelectedItem.Value);
            //requestCart.VendorId = Convert.ToInt32(dpVendor.SelectedItem.Value);
            requestCart.Quantity = string.IsNullOrEmpty(txtQuantity.Text) ? 0 : Convert.ToDecimal(txtQuantity.Text);
            requestCart.UnitId = Convert.ToInt32(dpUnit.SelectedItem.Value);
            requestCart.Specification = txtSpecification.Text;
            requestCart.Purpose = txtPurpose.Text;
            requestCart.Remark = txtRemark.Text;

            requestCart.Flag = 1; //1 for INSERT 

            bool result = purchaseData.RequestCartDML(requestCart);
            if (result)
            {
                bindCartList(requestCart);
            }
            //dpSelect();
        }

        private void bindCartList(RequestCart requestCart)
        {
            purchaseData = new PurchaseData();
            DS = new DataSet();
            requestCart.Flag = 0; //Get Full List
            rpRequestOrderdetails.DataSource = purchaseData.GetRequestCartList(requestCart);
            rpRequestOrderdetails.DataBind();
        }

        protected void rpRequestOrderdetails_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int TempID = 0;
            TempID = Convert.ToInt32(e.CommandArgument);
            switch (e.CommandName)
            {
                case ("delete"):
                    {

                        requestCart = new RequestCart();
                        purchaseData = new PurchaseData();
                        requestCart.RequestCartId = TempID;
                        requestCart.Tokan = hftokanno.Value;
                        requestCart.RequestBy = GlobalInfo.Userid;
                        requestCart.Purpose = string.Empty;
                        requestCart.Remark = string.Empty;
                        requestCart.Specification = string.Empty;
                        requestCart.Flag = 2; //2 for delete
                        purchaseData.RequestCartDML(requestCart);

                        bindCartList(requestCart);
                        //RemoveTempID(TempID);
                        //invocie.TokanId = hftokanno.Value;
                        //invocie.UserID = GlobalInfo.Userid;
                        //BindAgntTempItam(invocie);
                        upMain.Update();

                        break;
                    }

            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Request request = new Request();
            purchaseData = new PurchaseData();
            RequestCart rc = new RequestCart();

            request.CreatedBy = GlobalInfo.Userid;
            request.ReqStatus = "Pending";
            request.RequestDate = DateTime.Now;
            request.Tokan = hftokanno.Value;
            rc.Tokan = hftokanno.Value;

            bool result = purchaseData.SubmitRequest(request);
            if (result)
            {
                rc.Purpose = string.Empty;
                rc.Specification = string.Empty;
                rc.Remark = string.Empty;
                bindCartList(rc);
                //clearFields();
                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                pnlError.Update();
                upMain.Update();

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
}