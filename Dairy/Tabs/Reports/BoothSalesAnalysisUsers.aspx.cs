using Bussiness;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dairy.Tabs.Reports
{
    public partial class BoothSalesAnalysisUsers : System.Web.UI.Page
    {
        BillData billdata = new BillData();
        DataSet DS = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataSet DS = new DataSet();
                DS = BindCommanData.BindCommanDropDwon("AgentID", "AgentCode+' '+AgentName as Name", "AgentMaster", "IsArchive=0 and Agensytype='Booth'");
                if (!Comman.Comman.IsDataSetEmpty(DS))
                {
                    dpAgent.DataSource = DS;
                    dpAgent.DataBind();
                    dpAgent.Items.Insert(0, new ListItem("--Select Booth --", "0"));
                }
                DS.Clear();
                DS = BindCommanData.BindCommanDropDwon("CategoryId", "CategoryName as Name", "Category", "IsActive=1");
                if (!Comman.Comman.IsDataSetEmpty(DS))
                {
                    dpBrand.DataSource = DS;
                    dpBrand.DataBind();
                    dpBrand.Items.Insert(0, new ListItem("--All Brand--", "0"));
                }
                txtDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
            }
        }
        protected void dpAgent_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet DS = new DataSet();
            DS = BindCommanData.BindBoothUserDropDwon(Convert.ToDateTime(txtDate.Text).ToString("dd-MM-yyyy"), Convert.ToInt32(dpAgent.SelectedItem.Value));
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpEmployee.DataSource = DS;
                dpEmployee.DataBind();
                dpEmployee.Items.Insert(0, new ListItem("--Select Employee--", "0"));
            }
        }
        protected void btngenrateBill_Click(object sender, EventArgs e)
        {
            string result = string.Empty;
            string date = Convert.ToDateTime(txtDate.Text).ToString("dd-MM-yyyy");
            int boothid = Convert.ToInt32(dpAgent.SelectedItem.Value);
            int userid = Convert.ToInt32(dpEmployee.SelectedItem.Value);
            int brandid = Convert.ToInt32(dpBrand.SelectedItem.Value);
            DS = billdata.BoothSalesAnalysisUser(date, boothid, userid,brandid);

            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                //try
                //{
                //    DS.Tables[0].PrimaryKey = new[] { DS.Tables[0].Columns["ProductName"] };
                //}
                //catch (Exception) { }
                ////DS.Tables[0].Rows.Add(1, "Opening");
                //try
                //{
                //    DS.Tables[1].PrimaryKey = new[] { DS.Tables[1].Columns["ProductName"] };
                //}
                //catch (Exception) { }
                //try
                //{
                //    DS.Tables[2].PrimaryKey = new[] { DS.Tables[2].Columns["ProductName"] };
                //}
                //catch (Exception) { }
                //try
                //{
                //    DS.Tables[1].Merge(DS.Tables[0], false, MissingSchemaAction.Add);
                //}
                //catch (Exception) { }
                //try
                //{
                //    DS.Tables[1].Merge(DS.Tables[2], false, MissingSchemaAction.Add);
                //}
                //catch (Exception) { }
                try
                {

                    StringBuilder sb = new StringBuilder();


                    sb.Append("<style type='text / css'>");
                    sb.Append(".tg  { border - collapse:collapse; border - spacing:0; border: none; }");
                    sb.Append(".tg .tg-yw4l{vertical-align:top}");
                    sb.Append(".tg .tg-baqh{text-align:center;vertical-align:top}");
                    sb.Append("</style>");
                    sb.Append("<table class='tg style1' style='page-break-inside:avoid; align:center;'>");
                    sb.Append("<colgroup>");
                    sb.Append("<col style = 'width:120px'>");
                    sb.Append("<col style = 'width:120px'>");
                    sb.Append("<col style = 'width:100px'>");
                    sb.Append("<col style = 'width:100px'>");
                    sb.Append("<col style = 'width:100px'>");

                    sb.Append("<col style = 'width:100px'>");
                    sb.Append("<col style = 'width:100px'>");
                    sb.Append("<col style = 'width:100px'>");
                    sb.Append("<col style = 'width:100px'>");
                    sb.Append("</colgroup>");

                    sb.Append("<tr>");
                    sb.Append("<th class='tg-yw4l' rowspan='2'>");
                    sb.Append("<img src='/Theme/img/logo1.png' class='img-circle' alt='Logo' width='50px' hight='50px'>");
                    sb.Append("</th>");

                    sb.Append("<th class='tg-baqh' colspan='7' style='text-align:center'>");
                    sb.Append("<u> Booth Sales Analysis </u> <br/>");
                    sb.Append("</th>");

                    sb.Append("<th class='tg-yw4l' style='text-align:right'>");

                    sb.Append("TIN:330761667331<br>");
                    sb.Append("</th>");
                    sb.Append("</tr>");

                    sb.Append("<tr style='border-bottom:1px solid'>");
                    sb.Append("<td class='tg-yw4l' colspan='7' style='text-align:center'>");
                    sb.Append("<b>Nanjil Integrated Dairy Development ,Mulagunoodu, K.K.Dt.</b>");
                    sb.Append("</td>");
                    sb.Append("<td class='tg-yw4l' style='text-align:right'>");
                    sb.Append("PH:248370,248605");
                    sb.Append("</td>");
                    sb.Append("</tr>");

                    sb.Append("<tr style='border-bottom:1px solid' > ");
                    sb.Append("<td colspan ='2' style='text-align:left'>");
                    sb.Append(txtDate.Text);
                    sb.Append("</td>");

                    sb.Append("<td colspan ='5' style='text-align:center'>");
                    sb.Append(dpAgent.SelectedItem.Text);
                    sb.Append("</td>");

                    sb.Append("<td colspan ='2' style='text-align:right'>");
                    sb.Append(dpEmployee.SelectedItem.Text);
                    sb.Append("</td>");
                    sb.Append("</tr>");

                    sb.Append("<tr style='border-bottom:1px solid'>");
                    sb.Append("<td>");
                    sb.Append("<b> Type Name </b> ");
                    sb.Append("</td>");

                    sb.Append("<td>");
                    sb.Append("<b> Product Name </b> ");
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l' style='text-align:center'>");
                    sb.Append("<b> Opening Stock </b> ");
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l' style='text-align:center'>");
                    sb.Append("<b> Dispatch </b> ");
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l' style='text-align:center'>");
                    sb.Append("<b> Sales </b> ");
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l' style='text-align:center'>");
                    sb.Append("<b>Return</b> ");
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l' style='text-align:center'>");
                    sb.Append("<b> Spot Damage </b> ");
                    sb.Append("</td>");


                    sb.Append("<td class='tg-yw4l' style='text-align:center'>");
                    sb.Append("<b>Gift/Others</b> ");
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l' style='text-align:center'>");
                    sb.Append("<b>Closing Stock</b> ");
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l' style='text-align:center'>");
                    sb.Append("<b> </b> ");
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l' style='text-align:center'>");
                    sb.Append("<b></b> ");
                    sb.Append("</td>");
                    sb.Append("</tr>");

                    foreach (DataRow row in DS.Tables[0].Rows)
                    {
                        sb.Append("<tr>");
                        sb.Append("<td>");
                        sb.Append(row["TypeName"].ToString());
                        sb.Append("</td>");

                        sb.Append("<td>");
                        sb.Append(row["ProductName"].ToString());
                        sb.Append("</td>");

                        sb.Append("<td class='tg-yw4l' style='text-align:center'>");
                        //if (string.IsNullOrEmpty(row["OpeningQuantity"].ToString()))
                        //{
                        //    sb.Append("0");
                        //}
                        //else
                        //{
                            sb.Append(row["OpeningQuantity"].ToString());
                        //}
                        sb.Append("</td>");

                        sb.Append("<td class='tg-yw4l' style='text-align:center'>");
                        //if ((string.IsNullOrEmpty(row["DispatchQuantity"].ToString()) && string.IsNullOrEmpty(row["OpeningQuantity"].ToString())))
                        //{
                        //    if (!string.IsNullOrEmpty(row["StockAvailable"].ToString()))
                        //        sb.Append(row["StockAvailable"].ToString());
                        //    else
                        //        sb.Append("0");

                        //}
                        //else if ((row["DispatchQuantity"].ToString() == "0" && string.IsNullOrEmpty(row["OpeningQuantity"].ToString())))
                        //{
                        //    if (!string.IsNullOrEmpty(row["StockAvailable"].ToString()))
                        //        sb.Append(row["StockAvailable"].ToString());
                        //    else
                        //        sb.Append("0");
                        //}
                        //else
                        //{
                            sb.Append(row["Dispatch"].ToString());
                        //}

                        sb.Append("</td>");

                        sb.Append("<td class='tg-yw4l' style='text-align:center'>");
                        sb.Append(row["SaleQuantity"].ToString());
                        sb.Append("</td>");

                        sb.Append("<td class='tg-yw4l' style='text-align:center'>");
                        sb.Append(row["ReturnQuantity"].ToString());
                        sb.Append("</td>");

                        sb.Append("<td class='tg-yw4l' style='text-align:center'>");
                        sb.Append(row["SpotDamage"].ToString());
                        sb.Append("</td>");

                        sb.Append("<td class='tg-yw4l' style='text-align:center'>");
                        sb.Append(row["Others"].ToString());
                        sb.Append("</td>");

                        sb.Append("<td class='tg-yw4l' style='text-align:center'>");
                        sb.Append(row["ClosingQuantity"].ToString());
                        sb.Append("</td>");



                        sb.Append("</tr>");
                    }
                    sb.Append("<tr style='border-Top:1px solid' > ");
                    sb.Append("<td colspan ='10' style='text-align:right'>");
                    sb.Append("&nbsp;");
                    sb.Append("</td>");

                    sb.Append("</tr>");

                    result = sb.ToString();
                    genratedBIll.Text = result;
                    Session["ctrl"] = pnlBill;
                }
                catch (Exception ex)
                {
                    result = "No Report Available";
                    genratedBIll.Text = result;
                }

            }
            else
            {
                result = "No Report Available";
                genratedBIll.Text = result;

            }


        }
    }
}