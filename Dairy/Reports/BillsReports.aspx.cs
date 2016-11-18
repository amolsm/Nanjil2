using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using Bussiness;
using System.Data;
namespace Dairy.Reports
{
    public partial class BillsReports : System.Web.UI.Page
    {
        ProductData productData = new ProductData();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                
            }
        }
        protected void btnShow_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ds = productData.ReportsBilss(tstStartDate.Text,txtEndDate.Text);//(StarDate, EndDate);
            ReportDataSource rd = new ReportDataSource("DataSet2", ds.Tables[0]);
            ReportViewer1.LocalReport.DataSources.Add(rd);
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("") + "//rdlcFiles//BillsReports.rdlc";
            ReportViewer1.LocalReport.Refresh();
        }
        
    }
}