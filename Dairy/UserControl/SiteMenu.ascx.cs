using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dairy.App_code;
namespace Dairy.UserControl
{
    public partial class SiteMenu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                switch(GlobalInfo.UserRole)
                {
                    case "Administration":
                        {
                            pnlAddminitration.Visible = true;
                            pnlReception.Visible = false;
                            pnlSales.Visible = false;
                            pnlDesptach.Visible = false;
                            pnlTransport.Visible = false;
                            pnlPurchase.Visible = false;
                            pnlMarketing.Visible = false;
                            pnlCashier.Visible = false;
                            pnlProcurement.Visible = false;
                            break;                             
                        }
                    case "Reception":
                        {
                            pnlAddminitration.Visible = false;
                            pnlReception.Visible = true;
                            pnlSales.Visible = false;
                            pnlDesptach.Visible = false;
                            pnlTransport.Visible = false;
                            pnlPurchase.Visible = false;
                            pnlMarketing.Visible = false;
                            pnlCashier.Visible = false;
                            pnlProcurement.Visible = false;
                            break;
                        }
                    case "Sales":
                        {
                            pnlAddminitration.Visible = false;
                            pnlReception.Visible = false;
                            pnlSales.Visible = true;
                            pnlDesptach.Visible = false;
                            pnlTransport.Visible = false;
                            pnlPurchase.Visible = false;
                            pnlMarketing.Visible = false;
                            pnlCashier.Visible = false;
                            pnlProcurement.Visible = false;
                            break;
                        }
                    case "Despatch":
                        {
                            pnlAddminitration.Visible = false;
                            pnlReception.Visible = false;
                            pnlSales.Visible = false;
                            pnlDesptach.Visible = true;
                            pnlTransport.Visible = false;
                            pnlPurchase.Visible = false;
                            pnlMarketing.Visible = false;
                            pnlCashier.Visible = false;
                            pnlProcurement.Visible = false;
                            break;
                        }
                    case "Transport":
                        {
                            pnlAddminitration.Visible = false;
                            pnlReception.Visible = false;
                            pnlSales.Visible = false;
                            pnlDesptach.Visible = false;
                            pnlPurchase.Visible = false;
                            pnlMarketing.Visible = false;
                            pnlTransport.Visible = true;
                            pnlCashier.Visible = false;
                            pnlProcurement.Visible = false;

                            break;
                        }
                    case "Purchase":
                        {
                            pnlAddminitration.Visible = false;
                            pnlReception.Visible = false;
                            pnlSales.Visible = false;
                            pnlDesptach.Visible = false;
                            pnlTransport.Visible = false;
                            pnlMarketing.Visible = false;
                            pnlPurchase.Visible = true;
                            pnlCashier.Visible = false;
                            pnlProcurement.Visible = false;
                            break;
                        }
                    case "Marketing":
                        {
                            pnlAddminitration.Visible = false;
                            pnlReception.Visible = false;
                            pnlSales.Visible = false;
                            pnlDesptach.Visible = false;
                            pnlTransport.Visible = false;
                            pnlPurchase.Visible = false;
                            pnlMarketing.Visible = true;
                            pnlCashier.Visible = false;
                            pnlProcurement.Visible = false;
                            break;
                        }
                    case "Cashier":
                        {
                            pnlAddminitration.Visible = false;
                            pnlReception.Visible = false;
                            pnlSales.Visible = false;
                            pnlDesptach.Visible = false;
                            pnlTransport.Visible = false;
                            pnlPurchase.Visible = false;
                            pnlMarketing.Visible = false;
                            pnlCashier.Visible = true;
                            pnlProcurement.Visible = false;
                            break;
                        }
                    case "Procurement":
                        {
                            pnlAddminitration.Visible = false;
                            pnlReception.Visible = false;
                            pnlSales.Visible = false;
                            pnlDesptach.Visible = false;
                            pnlTransport.Visible = false;
                            pnlPurchase.Visible = false;
                            pnlMarketing.Visible = false;
                            pnlCashier.Visible = false;
                            pnlProcurement.Visible = true;
                            break;
                        }
                }
            }

            

        }
    }
}