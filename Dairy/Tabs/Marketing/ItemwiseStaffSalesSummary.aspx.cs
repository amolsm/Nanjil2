using Bussiness;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dairy.Tabs.Marketing
{
    public partial class ItemwiseStaffSalesSummary : System.Web.UI.Page
    {   DataSet DS = new DataSet();
        Marketings marketing = new Marketings();
        MarketingData marketingdata = new MarketingData();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDown();
                txtStartDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                txtEndDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
             
            }
            
        }

        public void BindDropDown()
        {
            DS = BindCommanData.BindCommanDropDwon("EmployeeID", "EmployeeCode+' '+EmployeeName as Name", "employeemaster", "EmployeeId is not Null");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpEmployee.DataSource = DS;
                dpEmployee.DataBind();
                dpEmployee.Items.Insert(0, new ListItem("--All Employee  --", "0"));



            }


        }

        protected void btngenrateBill_Click(object sender, EventArgs e)
        {
            string flag = "Staff";
                double totalamt = 0;
            string result = string.Empty;
            DS = marketingdata.ItemWiseStaffSalesSummarybyDate((Convert.ToDateTime(txtStartDate.Text)).ToString("dd-MM-yyyy"), (Convert.ToDateTime(txtEndDate.Text)).ToString("dd-MM-yyyy"), Convert.ToInt32(dpEmployee.SelectedItem.Value),flag);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                StringBuilder sb = new StringBuilder();
                try
                {
                    DS.Tables[1].PrimaryKey = new[] { DS.Tables[1].Columns["TypeID"] };
                    DS.Tables[1].PrimaryKey = new[] { DS.Tables[1].Columns["TypeName"] };
                }
                catch (Exception) { }
                try
                {
                    DS.Tables[3].PrimaryKey = new[] { DS.Tables[3].Columns["TypeID"] };
                    DS.Tables[3].PrimaryKey = new[] { DS.Tables[3].Columns["TypeName"] };

                }
                catch (Exception) { }
                try
                {
                    DS.Tables[1].Merge(DS.Tables[3], false, MissingSchemaAction.Add);

                }
                catch (Exception) { }

                //--------for product quantity

                try
                {
                   
                    DS.Tables[0].PrimaryKey = new[] { DS.Tables[0].Columns["TypeID"] };
                    DS.Tables[0].PrimaryKey = new[] { DS.Tables[0].Columns["ITEM"] };
                    DS.Tables[0].PrimaryKey = new[] { DS.Tables[0].Columns["Rate"] };
                    DS.Tables[0].PrimaryKey = new[] { DS.Tables[0].Columns["UnitType"] };
                    DS.Tables[0].PrimaryKey = new[] { DS.Tables[0].Columns["Quantity"] };
                    DS.Tables[0].PrimaryKey = new[] { DS.Tables[0].Columns["Amount"] };
                }
                catch (Exception) { }
                try
                {
                  
                    DS.Tables[2].PrimaryKey = new[] { DS.Tables[2].Columns["TypeID"] };
                    DS.Tables[2].PrimaryKey = new[] { DS.Tables[2].Columns["ITEM"] };
                    DS.Tables[2].PrimaryKey = new[] { DS.Tables[2].Columns["Rate"] };
                    DS.Tables[2].PrimaryKey = new[] { DS.Tables[2].Columns["UnitType"] };
                    DS.Tables[2].PrimaryKey = new[] { DS.Tables[2].Columns["Quantity"] };
                    DS.Tables[2].PrimaryKey = new[] { DS.Tables[2].Columns["Amount"] };
                }
                catch (Exception) { }
                try
                {
                    DS.Tables[0].Merge(DS.Tables[2], false, MissingSchemaAction.Add);
                   
                
                }
                catch (Exception) { }
                try
                {
                   
                   var finaltable = (from row in DS.Tables[0].AsEnumerable()
                                      let type = row.Field<int>("TypeID")
                                      let item = row.Field<string>("ITEM")
                                      let rate = row.Field<decimal>("Rate")
                                      let unite = row.Field<string>("UnitType")
                                      let qty = row.Field<double>("Quantity")
                                      let amt = row.Field<double>("Amount")
                                      group row by new { type, item, rate, unite } into grp
                                      select new
                                      {
                                          TypeID = grp.Key.type,
                                          ITEM = grp.Key.item,
                                          Rate = grp.Key.rate,
                                          UnitType = grp.Key.unite,

                                          Quantity = grp.Sum(r => r.Field<double>("Quantity")),
                                          Amount = grp.Sum(r => r.Field<double>("Amount")),

                                      }).OrderBy(type => type.TypeID).ThenBy(item => item.ITEM).ToList(); 

                    DataTable dat = new DataTable();
                    dat.Columns.Add("TypeID");
                    dat.Columns.Add("ITEM");
                    dat.Columns.Add("Rate");
                    dat.Columns.Add("UnitType");
                    dat.Columns.Add("Quantity");
                    dat.Columns.Add("Amount");
                    DataRow setrows = null;
                    foreach (var rowObj in finaltable)
                    {
                        setrows = dat.NewRow();
                        dat.Rows.Add(rowObj.TypeID, rowObj.ITEM, rowObj.Rate, rowObj.UnitType, rowObj.Quantity, rowObj.Amount);
                    }
                    
                    sb.Append("<style type='text / css'>");
                    sb.Append(".tg  { border - collapse:collapse; border - spacing:0; border: none; }");
                    sb.Append(".tg .tg-yw4l{vertical-align:top}");
                    sb.Append(".tg .tg-baqh{text-align:center;vertical-align:top}");
                    sb.Append("</style>");
                    //sb.Append("<table class='tg style1' style='page-break-inside:avoid; align:center;'>");
                    sb.Append("<table class='tg style1'  style=' position:relative;align:center;'>");
                    sb.Append("<colgroup>");
                    sb.Append("<col style = 'width:120px'>");
                    sb.Append("<col style = 'width:160px'>");
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

                    sb.Append("<th class='tg-baqh' colspan='6' style='text-align:center'>");
                    sb.Append("<b>Nanjil Integrated Dairy Development, Mulagumoodu, K.K.Dt.</b>");
                    sb.Append("</th>");

                    sb.Append("<th class='tg-yw4l' style='text-align:right'>");

                    sb.Append("GSTIN:&nbsp;33AAECN2463R1Z2<br>");
                    sb.Append("</th>");
                    sb.Append("</tr>");

                    sb.Append("<tr style='border-bottom:1px solid'>");
                    sb.Append("<td class='tg-yw4l' colspan='6' style='text-align:center'>");
                   
                    sb.Append("<b><u>Itemwise Staff Sales Summary </u><b> <br/>");
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l' style='text-align:right'>");

                    sb.Append("PH:248370,248605");

                    sb.Append("</td>");

                    sb.Append("<tr>");
                    sb.Append("<td class='tg-yw4l' colspan='6' style='text-align:left'>");
                    sb.Append("Start Date:" + Convert.ToDateTime(txtStartDate.Text).ToString("dd-MM-yyyy"));
                    sb.Append("</td>");
                    sb.Append("<td class='tg-yw4l' colspan='6' style='text-align:right'>");
                    sb.Append("End Date:" + Convert.ToDateTime(txtEndDate.Text).ToString("dd-MM-yyyy"));
                    sb.Append("</td>");
                    sb.Append("<tr style='border-bottom:2px solid'>");
                    sb.Append("<td class='tg-yw4l' colspan='3' style='text-align:left'>");
                    if (Convert.ToInt32(dpEmployee.SelectedItem.Value) == 0)
                    {
                        sb.Append("Employee : " + "All");
                    }
                    else
                    {
                        sb.Append("Employee : " + dpEmployee.SelectedItem.Text.ToString());
                    }
                    sb.Append("</td>");
                    sb.Append("<td class='tg-yw4l' colspan='3' style='text-align:middle'>");
                    //sb.Append("Route : " + "All");
                    sb.Append("</td>");
                    sb.Append("<td class='tg-yw4l' colspan='6'  style='text-align:right'>");
                    sb.Append("Date : " + DateTime.Now.ToString("dd-MM-yyyy"));
                    sb.Append("</td>");
                    sb.Append("</tr>");
                    sb.Append("<tr style='border-bottom:1px solid'style='page-break-inside:avoid; align:center;'> <td colspan = '9'></td> </tr>");
                    sb.Append("<tr style='border-bottom:1px solid'>");
                    sb.Append("<td class='tg-yw4l'  style='text-align:left'>");
                    sb.Append("<b> </b> ");
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l' colspan='2' style='text-align:left'>");
                    sb.Append("<b>ITEM</b>");
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l' colspan='2' style='text-align:left'>");
                    sb.Append("<b>Rate</b>");
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l'  style='text-align:left'>");
                    sb.Append("<b>Quantity</b>");
                    sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append("<b>Unit Type</b>");
                    sb.Append("</td>");
                    sb.Append("<td class='tg-yw4l'  style='text-align:right'>");
                    sb.Append("<b>Amount</b>");
                    sb.Append("</td>");
                    sb.Append("</tr>");

                    foreach (DataRow row2 in DS.Tables[1].Rows)
                    {
                        int count = 0;
                        double totalquantity = 0;
                        double quantity = 0;
                        double amounts = 0;
                        double totalamounts = 0;
                        foreach (DataRow row in dat.Rows)
                        {
                            if (row2["TypeID"].ToString() == row["TypeID"].ToString())
                            {
                                count = count + 1;
                                sb.Append("<tr>");
                                sb.Append("<td class='tg-yw4l'   style='text-align:left'>");
                                sb.Append("");
                                sb.Append("</td>");

                                sb.Append("<td class='tg-yw4l' colspan='2'  style='text-align:left'>");
                                sb.Append(row["ITEM"].ToString());
                                sb.Append("</td>");

                                sb.Append("<td class='tg-yw4l'  style='text-align:left'>");
                                sb.Append((Convert.ToDecimal(row["Rate"]).ToString("#.00")));

                                sb.Append("</td>");
                                sb.Append("<td>");
                                sb.Append("");
                                sb.Append("</td>");
                                sb.Append("<td class='tg-yw4l'  style='text-align:left'>");
                                
                                quantity = Convert.ToDouble(row["Quantity"]);


                                totalquantity += quantity;
                                sb.Append(quantity);
                                sb.Append("</td>");
                                sb.Append("<td>");
                                sb.Append(row["UnitType"].ToString());
                                sb.Append("</td>");
                                sb.Append("<td class='tg-yw4l'  style='text-align:right'>");
                             
                                amounts = Convert.ToDouble(row["Amount"]);

                              
                                totalamounts += amounts;
                                sb.Append((Convert.ToDecimal(amounts).ToString("#.00")));

                                sb.Append("</td>");
                                sb.Append("</tr>");
                            }
                            else { }
                        }


                        sb.Append("<tr style='border-bottom:1px dotted'> <td colspan = '9'> &nbsp; </td> </tr>");
                        sb.Append("<tr style='border-bottom:1px solid'>");
                        sb.Append("<td class='tg-yw4l'   style='text-align:left'>");
                        sb.Append(row2["TypeID"].ToString());
                        sb.Append("</td>");
                        sb.Append("<td class='tg-yw4l'   style='text-align:left'>");
                        sb.Append(row2["TypeName"].ToString());
                        sb.Append("</td>");
                        sb.Append("<td class='tg-yw4l' colspan='3'  style='text-align:left'>");
                        sb.Append("Total");
                        sb.Append("</td>");
                        sb.Append("<td class='tg-yw4l'  colspan='2'    style='text-align:left'>");
                        sb.Append(totalquantity.ToString());
                        sb.Append("</td>");

                        double amt = 0;

                        amt = Convert.ToDouble(totalamounts);
                     



                        sb.Append("<td class='tg-yw4l'  style='text-align:right'>");

                        sb.Append((Convert.ToDecimal(amt).ToString("#.00")));
                        totalamt += amt;
                        sb.Append("</td>");



                    }


                    sb.Append("<tr style='border-bottom:1px solid'>");


                    sb.Append("<td class='tg-yw4l' style='text-align:left'> ");
                    sb.Append("<b>" + "Total" + "</b>");
                    sb.Append("</td>");
                    sb.Append("<td class='tg-yw4l'   style='text-align:left'>");
                    sb.Append("&nbsp;");
                    sb.Append("</td>");
                    sb.Append("<td class='tg-yw4l' colspan='2'style='text-align:right'> ");
                    sb.Append("&nbsp;");
                    sb.Append("</td>");
                    sb.Append("<td class='tg-yw4l'   style='text-align:right'>");
                    sb.Append("&nbsp;");
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l'  colspan='2'  style='text-align:right'> ");
                    sb.Append("<b>" + "Total Amount" + "</b>");
                    sb.Append("</td>");
                    sb.Append("<td class='tg-yw4l'   style='text-align:right'>");

                    sb.Append("<b>" + (Convert.ToDecimal(totalamt).ToString("#.00")) + "</b>");



                    sb.Append("</td>");

                    sb.Append("</tr>");








                    result = sb.ToString();
                    genratedBIll.Text = result;

                    Session["ctrl"] = pnlBill;


                }
                catch (Exception ex)
                {
                    string msg = ex.ToString();
                    result = " Report not found";
                    genratedBIll.Text = result;
                }
            }


            else
            {
                result = "Report not found";
                genratedBIll.Text = result;

            }
        }
        }
    }
