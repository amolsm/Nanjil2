using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls; 
using Microsoft.Reporting.WebForms;
using Bussiness;


namespace Dairy.Reports
{
    public partial class PartyWiseScheme : System.Web.UI.Page
    {
        ProductData productData = new ProductData();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
                PartyWiaseSchem();
        }
        public void PartyWiaseSchem()
        {
            DateTime date = new DateTime();
            date = DateTime.Now;
            var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
            DataSet ds = new DataSet();
            ds = productData.PartyWiaseSchem(firstDayOfMonth.ToString("dd/MM/yyyy"), lastDayOfMonth.ToString("dd/MM/yyyy"));//(StarDate, EndDate);
            ReportDataSource rd = new ReportDataSource("DataSet1", ds.Tables[0]);
            ReportViewer1.LocalReport.DataSources.Add(rd);
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("") + "//rdlcFiles//PartywiseScheme.rdlc";
            ReportViewer1.LocalReport.Refresh();
        }
    }
}