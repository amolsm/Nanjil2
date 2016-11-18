using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using Bussiness;
using System.Data;
namespace Dairy
{
    public partial class testwithMaster : System.Web.UI.Page
    {
        ProductData productData = new ProductData();
        protected void Page_Load(object sender, EventArgs e)
        {

          

        }
        private void viewReport(string StarDate, string EndDate)
        {
            DataSet ds = new DataSet();
            ds = productData.ReportsProductWiseSeals(StarDate, EndDate);
            ReportDataSource rd = new ReportDataSource("DataSet1", ds.Tables[0]);
            ReportViewer1.LocalReport.DataSources.Add(rd);

            ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports") + "//rdlcFiles//ProductWiseSeals.rdlc";

            ReportParameter[] reportPAra = new ReportParameter[] { 

                new ReportParameter("StarDate",tstStartDate.Text),
                new ReportParameter("EndDate",tstStartDate.Text),
            };

            ReportViewer1.LocalReport.SetParameters(reportPAra);
 
            ReportViewer1.LocalReport.Refresh();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            viewReport(tstStartDate.Text, txtEndDate.Text);
        }
    }
}