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
                            break;
                        }
                    case "Transport":
                        {
                            pnlAddminitration.Visible = false;
                            pnlReception.Visible = false;
                            pnlSales.Visible = false;
                            pnlDesptach.Visible = false;
                            pnlPurchase.Visible = false;
                            pnlTransport.Visible = true;
                            break;
                        }
                    case "Purchase":
                        {
                            pnlAddminitration.Visible = false;
                            pnlReception.Visible = false;
                            pnlSales.Visible = false;
                            pnlDesptach.Visible = false;
                            pnlTransport.Visible = false;
                            pnlPurchase.Visible = true;
                            break;
                        }
                }
            }

            

        }
    }
}