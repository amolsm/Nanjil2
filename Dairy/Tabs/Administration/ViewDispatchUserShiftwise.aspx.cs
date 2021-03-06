﻿using Bussiness;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dairy.Tabs.Administration
{
    public partial class ViewDispatchUserShiftwise : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDwon();
                txtOrderDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));

            }
        }

        private void BindDropDwon()
        {
            DataSet DS = new DataSet();
            DS = new DataSet();
            DS = BindCommanData.BindCommanDropDwon("CategoryId ", "CategoryName as Name  ", "Category", "IsActive=1");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpCategory.DataSource = DS;
                dpCategory.DataBind();
                dpCategory.Items.Insert(0, new ListItem("--Select Brand--", "0"));
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            DataSet DS = new DataSet();
            Dispatch disp = new Dispatch();
            DispatchData dispatchData = new DispatchData();
            string result = string.Empty;
            disp.DispatchDate = Convert.ToDateTime(txtOrderDate.Text).ToString("dd-MM-yyyy");
            disp.UserID = Convert.ToInt32(dpUsers.SelectedItem.Value);
            disp.CategoryId = Convert.ToInt32(dpCategory.SelectedItem.Value);
            DS = dispatchData.GetDispatchUserShiftwise(disp);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                StringBuilder sb = new StringBuilder();


                //sb.Append("<style type='text / css'>");
                //sb.Append(".tg  { border-collapse:collapse; border - spacing:0; border: 0px; }");
                //sb.Append(".tg .tg-yw4l{vertical-align:top}");
                //sb.Append(".tg .tg-baqh{text-align:center;vertical-align:top}");
                //sb.Append("</style>");
                sb.Append("<table class='tg style1' style='page-break-inside:avoid; align:center; '>");
                sb.Append("<colgroup>");
                sb.Append("<col style = 'width:80px'>");
                sb.Append("<col style = 'width:100px'>");
                sb.Append("<col style = 'width:120px'>");
                sb.Append("<col style = 'width:180px'>");
                sb.Append("<col style = 'width:120px'>");
                sb.Append("<col style = 'width:120px'>");
                sb.Append("<col style = 'width:80px'>");
                sb.Append("<col style = 'width:100px'>");
                sb.Append("</colgroup>");

                sb.Append("<tr>");
                sb.Append("<th class='tg-yw4l' rowspan='2'>");
                sb.Append("<img src='/Theme/img/logo1.png' class='img-circle' alt='Logo' width='50px' hight='50px'>");
                sb.Append("</th>");

                sb.Append("<th class='tg-baqh' colspan='6' style='text-align:center'>");
                sb.Append("<b>Nanjil Integrated Dairy Development ,Mulagumoodu, K.K.Dt.</b> <br/>");
                sb.Append("</th>");

                sb.Append("<th class='tg-yw4l' style='text-align:right'>");

                sb.Append("GSTIN:&nbsp;33AAECN2463R1Z2<br>");
                sb.Append("</th>");
                sb.Append("</tr>");

                sb.Append("<tr style='border-bottom:1px solid !important'>");
                sb.Append("<td class='tg-yw4l' colspan='6' style='text-align:center'>");
                sb.Append("<u>  User ShiftWise Report </u>");

                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l' style='text-align:right'>");

                sb.Append("PH:248370,248605");

                sb.Append("</td>");
                sb.Append("<hr>");

                sb.Append("<tr style='border-bottom:0.5px dotted'>");

                sb.Append("<td colspan='2'>");
                sb.Append(dpUsers.SelectedItem.Text.ToString());

                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l' colspan='4' style='text-align:center; border-bottom: 0px'>");
                sb.Append("<b><u> " + dpCategory.SelectedItem.Text.ToString());
                sb.Append("</b></u></td>");


                sb.Append("<td class='tg-yw4l' colspan='2' style='text-align:right'>");
                sb.Append("Date : " + Convert.ToDateTime(txtOrderDate.Text).ToString("dd-MM-yyyy"));
                sb.Append("</td>");


                sb.Append("</tr>");


                sb.Append("<tr style='border-bottom:1px solid'> <td colspan = '8'> &nbsp; </td> </tr>");

                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append("<td class='tg-yw4l' style='text-align:left'>");
                sb.Append("<b> Sr. No: </b> ");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l' colspan='2' style='text-align:left'>");
                sb.Append("<b>Product Name </b>");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l' style='text-align:left'>");
                sb.Append("<b>Commodity </b>");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l'  style='text-align:center'>");
                sb.Append("<b>Quantity </b>");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l'  style='text-align:left'>");
                sb.Append("<b>Unit Type </b>");
                sb.Append("</td>");



                sb.Append("<td class='tg-yw4l'  style='text-align:left'>");
                //sb.Append("<b>Sales </b>");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l' style='text-align:left'>");
                //sb.Append("<b>Return </b>");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l' style='text-align:left'>");
                sb.Append(" ");
                sb.Append("</td>");
                sb.Append("</tr>");
                int cnt = 1;
                foreach (DataRow row in DS.Tables[1].Rows)
                {
                    sb.Append("<tr style='border-bottom:0.5px dotted'>");
                    sb.Append("<td class='tg-yw4l' style='text-align:left'>");
                    sb.Append(cnt.ToString());
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l' colspan='2' style='text-align:left'>");
                    sb.Append(row["ProductName"].ToString());
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l'  style='text-align:left'>");
                    sb.Append(row["CommodityName"].ToString());
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l'  style='text-align:center'>");
                    sb.Append(row["TotalQuantity"].ToString());
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l'  style='text-align:left'>");
                    sb.Append(row["UnitName"].ToString());
                    sb.Append("</td>");



                    sb.Append("<td class='tg-yw4l' style='text-align:left'>");
                    sb.Append(" ");
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l' style='text-align:left'>");
                    sb.Append(" ");
                    sb.Append("</td>");

                    sb.Append("<td class='tg-yw4l' style='text-align:left'>");
                    sb.Append(" ");
                    sb.Append("</td>");
                    sb.Append("</tr>");

                    cnt++;
                }

                sb.Append("<tr style='border-bottom:1px solid'> <td colspan = '8'> &nbsp; </td> </tr>");

                sb.Append("<tr style='border-Top:1px Solid;border-bottom:0.5px dotted'>");


                sb.Append("<td class='tg-yw4l' rowspan='3' style='text-align:left'>");
                sb.Append("<b>Crates Particular </b>");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l'  style='text-align:left'>");
                sb.Append("<b>Item</b>");
                //sb.Append(DS.Tables[0].Rows[0]["ProductName"].ToString());
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l'  style='text-align:left'>");
                sb.Append("<b>Tray</b> ");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l'  style='text-align:left'>");
                sb.Append("<b>Ice Box</b>");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l' colspan='2' style='text-align:left'>");
                sb.Append("<b>Cartons/Ice Pad </b>");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l' colspan='2' style='text-align:left'>");
                sb.Append("<b>Others </b>");
                sb.Append("</td>");

                sb.Append("</tr>");

                sb.Append("<tr style='border-bottom:0.5px dotted'>");


                //sb.Append("<td class='tg-yw4l' rowspan='3' style='text-align:left'>");
                //sb.Append("Crates Perticular ");
                //sb.Append("</td>");

                sb.Append("<td class='tg-yw4l'  style='text-align:left'>");
                sb.Append("<b>Dispatch</b>");
                //sb.Append(DS.Tables[0].Rows[0]["ProductName"].ToString());
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l'  style='text-align:left'>");
                sb.Append(DS.Tables[0].Rows[0]["TraysDispached"].ToString());
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l'  style='text-align:left'>");
                sb.Append(DS.Tables[0].Rows[0]["IceBoxDispached"].ToString());
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l' colspan='2' style='text-align:left'>");
                sb.Append(DS.Tables[0].Rows[0]["CartonsDispached"].ToString());
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l' colspan='2' style='text-align:left'>");
                sb.Append(DS.Tables[0].Rows[0]["OtherDispached"].ToString());
                sb.Append("</td>");




                sb.Append("</tr>");

                sb.Append("<tr style='border-bottom:1px Solid'>");


                //sb.Append("<td class='tg-yw4l' rowspan='3' style='text-align:left'>");
                //sb.Append("Crates Perticular ");
                //sb.Append("</td>");

                sb.Append("<td class='tg-yw4l'  style='text-align:left'>");
                //sb.Append("<b>Returned</b>");
                //sb.Append(DS.Tables[0].Rows[0]["ProductName"].ToString());
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l'  style='text-align:center'>");
                sb.Append("");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l'  style='text-align:Center'>");
                sb.Append("");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l' style='text-align:Center'>");
                sb.Append("");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l'  style='text-align:Center'>");
                sb.Append("");
                sb.Append("</td>");

                sb.Append("</tr>");

                sb.Append("<tr>");
                sb.Append("<td class='tg-yw4l' colspan='8' style='text-align:left'>");
                sb.Append("&nbsp;");
                sb.Append("</td>");
                sb.Append("</tr>");
                sb.Append("<tr>");
                sb.Append("<td class='tg-yw4l' colspan='8' style='text-align:left'>");
                sb.Append("&nbsp;");
                sb.Append("</td>");
                sb.Append("</tr>");
                sb.Append("<tr>");
                sb.Append("<td class='tg-yw4l' colspan='8' style='text-align:left'>");
                sb.Append("&nbsp;");
                sb.Append("</td>");
                sb.Append("</tr>");


                sb.Append("<tr>");
                sb.Append("<td class='tg-yw4l'  colspan='4' style='text-align:left'>");
                sb.Append("Dispatch Clerk ");
                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l'  colspan='4' style='text-align:right'>");
                sb.Append("Production Manager ");
                sb.Append("</td>");

                //sb.Append("<td class='tg-yw4l'  colspan='3' style='text-align:right'>");
                //sb.Append("Sales Man ");
                //sb.Append("</td>");
                sb.Append("</tr>");







                result = sb.ToString();
                DispatchSummary.Text = result;
                //Session["ctrl"] = sb.ToString();
                Session["ctrl"] = pnlDispatchSummary;
                //Response.Redirect("/print.aspx", true);


            }
            else
            {
                result = "Order not FOund";
                DispatchSummary.Text = result;

            }

        }


        protected void dpCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet DS = new DataSet();
            DS = BindCommanData.BindDispatchUserDropDwon(Convert.ToDateTime(txtOrderDate.Text).ToString("dd-MM-yyyy"), Convert.ToInt32(dpCategory.SelectedItem.Value));
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpUsers.DataSource = DS;
                dpUsers.DataBind();
                dpUsers.Items.Insert(0, new ListItem("--All User --", "0"));
            }
        }

    }
}