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
    public partial class AgentSchemeReport : System.Web.UI.Page
    {
        ProductData productData = new ProductData();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DisplayRecords();
            }
        }

       // protected void btnShow_Click(object sender, EventArgs e)
        public void DisplayRecords()
        {
                    DateTime date=new DateTime();
                    date = DateTime.Now;
                    var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
                    var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);            
                    DataSet ds = new DataSet();
                    ds = productData.ReportsAgentSchemReports(firstDayOfMonth.ToString("dd/MM/yyyy"), lastDayOfMonth.ToString("dd/MM/yyyy"));//(StarDate, EndDate);
                    ReportDataSource rd = new ReportDataSource("DataSet1", ds.Tables[0]);
                    ReportViewer1.LocalReport.DataSources.Add(rd);
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("") + "//rdlcFiles//AgentSchemeReport.rdlc";
                    ReportViewer1.LocalReport.Refresh();
        }
    }
}