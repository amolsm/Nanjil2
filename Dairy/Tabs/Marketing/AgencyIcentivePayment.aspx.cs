using Bussiness;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Dairy.Tabs.Marketing
{
    public partial class AgencyIcentivePayment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDwon();
            }
        }

        public void BindDropDwon()
        {
            DataSet DS = new DataSet();
            DS = BindCommanData.BindCommanDropDwon("AgentID", "AgentCode+' '+AgentName as Name", "AgentMaster", "IsArchive=0 and Agensytype='Agency' Order by AgentCode");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpAgent.DataSource = DS;
                dpAgent.DataBind();
                dpAgent.Items.Insert(0, new ListItem("--Select Agency  --", "0"));

              

            }
           
        }

        protected void btnShowAgentDetails_click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            DispatchData dispatchdata = new DispatchData();
            int AgentID = Convert.ToInt32(dpAgent.SelectedItem.Value);
            string AgentName = dpAgent.SelectedItem.Text;
            ds = dispatchdata.GetAgentPaymentIncentiveSummary(AgentID);
            if (!Comman.Comman.IsDataSetEmpty(ds))
            {
                DataTable table;
                table = ds.Tables[0];

                // Declare an object variable.
                object sumObjectofQuantity;
                sumObjectofQuantity = table.Compute("Sum(Quantity)", "");

                object sumObjectofreturnqty;
                sumObjectofreturnqty = table.Compute("Sum(totalreturnQuantity)", "");

                double totalqty = Convert.ToDouble(sumObjectofQuantity) - Convert.ToDouble(sumObjectofreturnqty);
                lblAgentId.Visible = true;
                lblAgentId.Text = "Agent ID : "+AgentID.ToString();
                lblTotalqtySales.Visible = true;
                lblTotalqtySales.Text = "Total Quantity Sales. : "+totalqty.ToString();
                double totalincentiveamt = 0.00;
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    double incentiveamt = (Convert.ToDouble(row["Quantity"]) - Convert.ToDouble(row["totalreturnQuantity"])) * Convert.ToDouble(row["AgentIncentive"]);
                    totalincentiveamt += incentiveamt;
                }
                DataTable dt = new DataTable();
                dt.Columns.Add("AgentID");
                dt.Columns.Add("AgentName");
                dt.Columns.Add("TotalQtySales");
                dt.Columns.Add("IncentiveAmt");
                dt.Rows.Add(AgentID, AgentName,totalqty, totalincentiveamt);
                DataSet dataset = new DataSet("AgentIncentiveRecords");
                dataset.Tables.Add(dt);
                rpBrandInfo.DataSource = dataset;
                rpBrandInfo.DataBind();
                //rpBrandInfo.Visible = true;
                uprouteList.Update();
            }
        }
        protected void rpRouteList_ItemCommand(object sender, EventArgs e)
        {
        }
      
    }
}