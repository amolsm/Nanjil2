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
    public partial class StaffACCSaleSummary : System.Web.UI.Page
    {
        ProductData productData = new ProductData();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                StaffACCSaleSummaryReports();
            }
        }

        public void StaffACCSaleSummaryReports()
        {
            DateTime date = new DateTime();
            date = DateTime.Now;
            var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
            DataSet ds = new DataSet();
            ds = productData.StaffACCSaleSummaryReports(firstDayOfMonth.ToString("dd/MM/yyyy"), lastDayOfMonth.ToString("dd/MM/yyyy"));//(StarDate, EndDate);
            ReportDataSource rd = new ReportDataSource("DataSet1", ds.Tables[0]);
            ReportViewer1.LocalReport.DataSources.Add(rd);
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("") + "//rdlcFiles//StaffACCSaleSummary.rdlc";
            ReportParameter[] reportPAra = new ReportParameter[] { 
                new ReportParameter("StartDate",firstDayOfMonth.ToString("dd/MM/yyyy")),
                new ReportParameter("EndDate",lastDayOfMonth.ToString("dd/MM/yyyy")),
            };

            ReportViewer1.LocalReport.SetParameters(reportPAra);
            ReportViewer1.LocalReport.Refresh();
        }
    }
}