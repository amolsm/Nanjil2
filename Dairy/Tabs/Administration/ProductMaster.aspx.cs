using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model.Admin;
using DataAccess.Admin;

namespace Dairy.Tabs.Administration
{
    public partial class ProductMaster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            productMaster pm = new productMaster();
            DbProductMaster db = new DbProductMaster();
            pm.Name = txtProduct.Text;
            if (dpStatus.SelectedItem.Value == "1")
                pm.IsActive = true;
            else pm.IsActive = false;

            int result = db.DML(pm);
            if (result > 0)
            {

            }
        

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        protected void rpBrandInfo_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }
    }
}