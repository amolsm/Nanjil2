using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bussiness;
using System.Data;
using System.Text;

namespace Dairy.Tabs.Procurement
{
    public partial class AddSupplierLoanDetails : System.Web.UI.Page
    {
        DataSet DS = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //BindeSupplierLoanInfo();
                BindDropdown();
                btnLoanDetailsadd.Visible = true;
                btnLoanDetailsUpdate.Visible = false;


            }

        }
        public void BindDropdown()
        {
            DS = BindCommanData.BindCommanDropDwon("SupplierID ", "SupplierCode +' '+SupplierName as Name  ", "Proc_MilkSuppliersProfile", "IsActive=1 ");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpSupplier.DataSource = DS;
                dpSupplier.DataBind();
                dpSupplier.Items.Insert(0, new ListItem("--Select Supplier  --", "0"));
            }
        }
    }
}