using Bussiness;
using Dairy.App_code;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dairy.Tabs.Sales
{
    public partial class BoothPlaceOrder : System.Web.UI.Page
    {
        DataSet DS;
        double total = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDwon();
                hftokanno.Value = Comman.Comman.RandomString();
                txtGentOrderDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
            }
        }

        [WebMethod]
        public static void OnTextChanged(int id)
        {
            //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You clicked YES!')", true);
            Invoice invocie = new Invoice();
            InvoiceData invicedata = new InvoiceData();
           // PlaceOrder po = new PlaceOrder();
            //invocie.AgencyID = Convert.ToInt32(dpAgent.SelectedItem.Value);
            //invocie.AgencyID = Convert.ToInt32(po.txtAgentId.Text);
            invocie.AgencyID = id;
            DataSet DS = new DataSet();
            DS = invicedata.GetPreviousDayOrder(invocie);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
            }
        }
        public void BindDropDwon()
        {
            int boothid = GlobalInfo.CurrentbothID;
            DS = new DataSet();
          //  DS = BindCommanData.BindCommanDropDwon("RouteID ", "RouteCode +' '+RouteName as Name  ", "routeMaster", "IsArchive=1 ");
            DS = BindCommanData.BindTypeDropDwon("RouteMaster.RouteID", "RouteMaster.RouteCode+' '+RouteMaster.RouteName as Name  ", "RouteMaster", "AgentMaster", "RouteMaster.RouteID = AgentMaster.RouteID", "RouteMaster.IsArchive=1  and AgentID = " + boothid);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpagentRoute.DataSource = DS;
                dpagentRoute.DataBind();
                //dpagentRoute.Items.Insert(0, new ListItem("--Select Agent Route  --", "0"));
      

            }

            DS = BindCommanData.BindCommanDropDwon("AgentID", "AgentCode+' '+AgentName as Name", "AgentMaster", "IsArchive=0 and AgentID = " + boothid);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpAgent.DataSource = DS;
                dpAgent.DataBind();
               // dpAgent.Items.Insert(0, new ListItem("--Select Booth  --", "0"));
            }
            DS.Clear();
            DS = BindCommanData.BindCommanDropDwon("CategoryId", "CategoryName", "Category", "IsActive=1");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpBrand.DataSource = DS;
                dpBrand.DataBind();
                dpBrand.Items.Insert(0, new ListItem("--Select Brand  --", "0"));
            }
              DS.Clear();
            DS = BindCommanData.BindCommanDropDwon("TypeID", "TypeName", "TypeMaster", "IsArchive=1 ");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpAgentProductType.DataSource = DS;
                dpAgentProductType.DataBind();
                dpAgentProductType.Items.Insert(0, new ListItem("--Select Product Type  --", "0"));

            }
        }
        protected void dpAgentProductType_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            DS = new DataSet();

            //  DS = BindCommanData.BindTypeDropDwon("Products.productId", "ProductName+' '+Productcode as product", " TypeMaster ", " BindSlab", " TypeMaster.TypeID = BindSlab.TypeID ", "BindSlab.AgentID = 110 ");

            DS = BindCommanData.BindTypeDropDwon("Products.productId", "Products.ProductName+' '+Products.Productcode as product", "Products", "BindSlab", "Products.TypeID = Bindslab.TypeID", "Products.TypeID =" + Convert.ToInt32(dpAgentProductType.SelectedItem.Value) + " and BindSlab.AgentID =" + Convert.ToInt32(dpAgent.SelectedItem.Value) + " and BindSlab.SlabID = Products.SlabID order by Products.ProductName");

            // DS = BindCommanData.BindCommanDropDwon("Products.ProductID", "Commodity.CommodityName+' '+Products.ProductName as product", "Commodity, Products", "   Products.CommodityID = Commodity.CommodityID");

            dpAgentProductdetaisl.DataSource = DS;
            dpAgentProductdetaisl.DataBind();
            dpAgentProductdetaisl.Items.Insert(0, new ListItem("--Select Product  --", "0"));
            dpAgentProductdetaisl.Focus();
            upMain.Update();


        }
         protected void dpAgentpre_SelectedIndexChanged(object sender, EventArgs e)
        {
            Invoice invocie = new Invoice();
            InvoiceData invicedata = new InvoiceData();
            invocie.AgencyID = Convert.ToInt32(dpAgent.SelectedItem.Value);

            DS = invicedata.GetPreviousDayOrder(invocie);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {

                RemoveAllItam();
                foreach (DataRow row in DS.Tables[0].Rows)
                {
                    invocie.TokanId = hftokanno.Value;
                    invocie.UserID = GlobalInfo.Userid;
                    invocie.ProductID = Convert.ToInt32(row["ProductID"]);
                    invocie.qty = Convert.ToDouble(row["Qty"]);
                    invocie.UnitCost = Convert.ToDouble(row["UnitCost"]);
                    invocie.totalCoast = Convert.ToDouble(row["Total"]);
                    invocie.TypeID = Convert.ToInt32(row["TypeID"]);
                    invicedata.InsertTempInvoiceItam(invocie);
                    BindAgntTempItam(invocie);

                    // txtGentOrderDate.Text= DateTime.Now.ToString("MM-dd-yyyy");
                    txtagentOrderqty.Text = "0";
                }

            }


            dpAgent.Focus();


        }
         public void BindAgntTempItam(Invoice invocie)
         {
             InvoiceData invicedata = new InvoiceData();
             rpAgentOrderdetails.DataSource = invicedata.GetTempItam(invocie);
             rpAgentOrderdetails.DataBind();
         }

         protected void btnAddAgentProductItem_click(object sender, EventArgs e)
         {

             Invoice invocie = new Invoice();
             InvoiceData invicedata = new InvoiceData();
             invocie.TokanId = hftokanno.Value;
             invocie.UserID = GlobalInfo.Userid;
             invocie.TypeID = Convert.ToInt32(dpAgentProductType.SelectedItem.Value);
             invocie.ProductID = Convert.ToInt32(dpAgentProductdetaisl.SelectedItem.Value);
             invocie.qty = Convert.ToDouble(txtagentOrderqty.Text);
             invocie.UnitCost = Convert.ToDouble(hfAgentProductUnitPrice.Value);
             invocie.totalCoast = Convert.ToDouble(txtagentOrderqty.Text) * Convert.ToDouble(hfAgentProductUnitPrice.Value);
            int flag = 1;
            bool result = invicedata.CheckTempInvoiceItam(invocie, flag);
            if (!result)
            {
                invicedata.InsertTempInvoiceItam(invocie);
                BindAgntTempItam(invocie);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Item already exists')", true);
            }
        }
         public void dpAgentProductdetaisl_SelectedIndexChanged(object sender, EventArgs e)
         {
             hfAgentProductUnitPrice.Value = "0";
         }
         public void btnAgentORderSubmit_click(object sender, EventArgs e)
         {
             int result = 0;
             Invoice inovice = new Invoice();
             InvoiceData invoiceData = new InvoiceData();
             inovice.orderDate = (Convert.ToDateTime(txtGentOrderDate.Text)).ToString("dd-MM-yyyy");
             inovice.AgencyID = Convert.ToInt32(dpAgent.SelectedItem.Value);

             inovice.ROuteID = Convert.ToInt32(dpagentRoute.SelectedItem.Value);
             inovice.SaleEmployeeId = 0;//Convert.ToInt32(dpAgentSelasEMployee.SelectedItem.Value);
             inovice.totalCoast = string.IsNullOrEmpty(hftotalAmout.Value) ? 0 : Comman.Comman.IsValidInteger(hftotalAmout.Value) ? Convert.ToDouble(hftotalAmout.Value) : 0;
             inovice.CreatedBy = GlobalInfo.Userid;
             inovice.CreatedDate = DateTime.Now.ToString("MM-dd-yyyy");
             inovice.TokanId = hftokanno.Value;
            inovice.TotalSchemeAmount = 0;

            inovice.ShecemeApplied = false;

             inovice.orderType = 1;// Agent order
            DataSet chkds = new DataSet();
            int chkflg = 2;
            chkds = invoiceData.CheckBoothTemp(inovice, chkflg);
            if (!Comman.Comman.IsDataSetEmpty(chkds))
            {
                result = invoiceData.InsertOrder(inovice);
            }
             if (result > 0)
             {
                 clearAgentValues();
                 BindAgntTempItam(inovice);
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
         public void clearAgentValues()
         {
             txtagentOrderqty.Text = string.Empty;
             // txtGentOrderDate.Text = string.Empty;
             //dpAgentSelasEMployee.ClearSelection();
             //dpagentRoute.ClearSelection();
             dpAgent.ClearSelection();
             dpAgentProductdetaisl.ClearSelection();
             dpAgentProductType.ClearSelection();
            


         }
         public void btnagentItamsremove_click(object sender, EventArgs e)
         {
             RemoveAllItam();
         }
         public void btnAgentNewOrder_clcik(object sender, EventArgs e)
         {
             clearAgentValues();
             RemoveAllItam();
             upMain.Update();

             divDanger.Visible = false;
             divwarning.Visible = false;
             divSusccess.Visible = false;
             pnlError.Update();


         }
         protected void rpOrderitam_OnDataBinding(object sender, RepeaterItemEventArgs e)
         {
             RepeaterItem item = e.Item;
             if (item.ItemType == ListItemType.AlternatingItem || item.ItemType == ListItemType.Item)
             {
                 // HtmlGenericControl li = (HtmlGenericControl)item.FindControl("li");
                 Label lbltotal = (Label)item.FindControl("lbltotal");
                 //Label lblType = (Label)item.FindControl("lblType");
                 //if (lblType != null && string.IsNullOrEmpty(lblType.Text))
                 //{
                 //    lblType.Text = "Scheme Amount";
                 //}
                 if (lbltotal != null)
                 {
                     total = total + (string.IsNullOrEmpty(lbltotal.Text) ? 0 : Convert.ToDouble(lbltotal.Text));
                 }
             }
             if (item.ItemType == ListItemType.Footer || item.ItemType == ListItemType.Item)
             {
                 // HtmlGenericControl li = (HtmlGenericControl)item.FindControl("li");
                 Label lblFInaltotal = (Label)item.FindControl("lblFInaltotal");
                 if (lblFInaltotal != null)
                 {
                     lblFInaltotal.Text = total.ToString("#0.00");
                     hftotalAmout.Value = total.ToString("#0.00");
                 }

             }
         }
         public void RemoveAllItam()
         {
             Invoice invocie = new Invoice();
             InvoiceData invicedata = new InvoiceData();
             invocie.TokanId = hftokanno.Value;
             invocie.UserID = GlobalInfo.Userid;
             invicedata.DeleteItes(invocie);
             BindAgntTempItam(invocie);
             upMain.Update();
         }
         protected void RemoveTempID(int tempID)
         {
             InvoiceData invicedata = new InvoiceData();
             invicedata.TempDelete(tempID);

         }

         protected void dpagentRoute_SelectedIndexChanged(object sender, EventArgs e)
         {

             DS = BindCommanData.BindCommanDropDwon("AgentID", "AgentCode+' '+AgentName as Name", "AgentMaster", "RouteID=" + dpagentRoute.SelectedItem.Value.ToString()+ "and IsArchive=0 and Agensytype='Booth'");
             if (!Comman.Comman.IsDataSetEmpty(DS))
             {
                 dpAgent.ClearSelection();
                 dpAgent.DataSource = DS;
                 dpAgent.DataBind();
                 dpAgent.Items.Insert(0, new ListItem("--Select Agent  --", "0"));
                 dpAgent.Focus();
             }

         }
         protected void dpBrand_SelectedIndexChanged(object sender, EventArgs e)
         {

             DS = BindCommanData.BindCommanDropDwon("TypeID", "TypeName", "TypeMaster", "IsArchive=1 and CategoryId =" + dpBrand.SelectedItem.Value.ToString());
             if (!Comman.Comman.IsDataSetEmpty(DS))
             {
                 dpAgentProductType.ClearSelection();
                 dpAgentProductType.DataSource = DS;
                 dpAgentProductType.DataBind();
                 dpAgentProductType.Items.Insert(0, new ListItem("--Select Product Type  --", "0"));
                 dpAgentProductType.Focus();

             }
         }
         protected void rpOrderitam_ItemCommand(object sender, RepeaterCommandEventArgs e)
         {

             int TempID = 0;
             TempID = Convert.ToInt32(e.CommandArgument);
             switch (e.CommandName)
             {
                 case ("delete"):
                     {


                         Invoice invocie = new Invoice();
                         RemoveTempID(TempID);
                         invocie.TokanId = hftokanno.Value;
                         invocie.UserID = GlobalInfo.Userid;
                         BindAgntTempItam(invocie);
                         upMain.Update();

                         break;
                     }

             }
         }
    }

}