using Bussiness;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dairy.Tabs.Administration
{
    public partial class Agentwise_Tray : System.Web.UI.Page
    {
        MAgentwiseTray mat;
        BAgentwiseTray bat;
        DataSet DS = new DataSet();
        DataTable dt = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //BindDropDwon();
                txtAgentwiseTrayDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
            }
        }


        protected void rpAgentwiseTrayInfo_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

        public void GetAgentwiseTrayDetails(int DispatchId, string DDate)
        {
            bat = new BAgentwiseTray();
            DataSet DS = new DataSet();
            DS = bat.GetAgentwiseTrayDetails(DispatchId, DDate);



            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                if (DS.Tables[0].Rows.Count != 0)
                {
                    //DataTable dtAll = new DataTable();
                    //dtAll = DS.Tables[0].Copy();
                    //dtAll.Merge(DS.Tables[1], true);



                    rpAgentwiseTrayInfo.DataSource = DS;
                    rpAgentwiseTrayInfo.DataBind();

                    foreach (RepeaterItem item in rpAgentwiseTrayInfo.Items)
                    {

                        tdt.Text = DS.Tables[0].Rows[0]["TraysDispached"].ToString();
                        trt.Text = DS.Tables[0].Rows[0]["TraysReturned"].ToString();

                        TextBox textmt = item.FindControl("txtTraysDispached") as TextBox;

                        TraysInfo.Visible = true;
                    }


                }
                else
                {
                    this.BindRepeater(dt);
                    TraysInfo.Visible = false;
                }




            }
            else
            {

                this.BindRepeater(dt);
                TraysInfo.Visible = false;

            }
        }

        private void BindRepeater(DataTable dt)
        {
            rpAgentwiseTrayInfo.DataSource = dt;
            rpAgentwiseTrayInfo.DataBind();

            if (dt.Rows.Count == 0)
            {
                Control FooterTemplate = rpAgentwiseTrayInfo.Controls[rpAgentwiseTrayInfo.Controls.Count - 1].Controls[0];
                FooterTemplate.FindControl("trEmpty").Visible = true;
            }

        }


        protected void btnSearch_Click(object sender, EventArgs e)
        {
            int DispatchId = Convert.ToInt32(txtSearchDispatchId.Text);
            string DDate = Convert.ToDateTime(txtAgentwiseTrayDate.Text).ToString("dd-MM-yyyy");
            GetAgentwiseTrayDetails(DispatchId, DDate);

            divDanger.Visible = false;
            divwarning.Visible = false;
            divSusccess.Visible = false;
            pnlError.Update();
            lblerr.Visible = false;

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            validateTraysDispatched();
            foreach (RepeaterItem item in rpAgentwiseTrayInfo.Items)
            {
                HiddenField hdfID = item.FindControl("hfDI_Id") as HiddenField;
                HiddenField hdfID1 = item.FindControl("hfagentId") as HiddenField;
                HiddenField hdfID2 = item.FindControl("hfemployeeId") as HiddenField;
                HiddenField hdfID3 = item.FindControl("hfSalesmanId") as HiddenField;
                HiddenField hdfID4 = item.FindControl("hfDI_RouteId") as HiddenField;
                TextBox textmt = item.FindControl("txtTraysDispached") as TextBox;
                TextBox textrt = item.FindControl("txtReturnTrays") as TextBox;
                //TextBox txtAgentwiseTrayDate = item.FindControl("txtAgentwiseTrayDate") as TextBox;
                //txtAgentwiseTrayDate.Text;
                //Label lbltot = item.FindControl("TotTrays") as Label;
                Label lblexcess = item.FindControl("lblExcess") as Label;
                Label lblshort = item.FindControl("lblShort") as Label;
                if (hdfID != null)
                {
                    int dispatchid = Convert.ToInt32(hdfID.Value);
                    int AgentId = string.IsNullOrEmpty(hdfID1.Value) ? 0 : Convert.ToInt32(hdfID1.Value);
                    int EmpId = string.IsNullOrEmpty(hdfID2.Value) ? 0 : Convert.ToInt32(hdfID2.Value);
                    int salesmanid = string.IsNullOrEmpty(hdfID3.Value) ? 0 : Convert.ToInt32(hdfID3.Value);
                    int routeid = string.IsNullOrEmpty(hdfID4.Value) ? 0 : Convert.ToInt32(hdfID4.Value);
                    int traydispatched = string.IsNullOrEmpty(textmt.Text) ? 0 : Convert.ToInt32(textmt.Text);
                    int returntrays = string.IsNullOrEmpty(textrt.Text) ? 0 : Convert.ToInt32(textrt.Text);
                    //int totaltrays = string.IsNullOrEmpty(lbltot.Text) ? 0 : Convert.ToInt32(lbltot.Text);
                    int excesstrays = string.IsNullOrEmpty(lblexcess.Text) ? 0 : Convert.ToInt32(lblexcess.Text);
                    int shorttrays = string.IsNullOrEmpty(lblshort.Text) ? 0 : Convert.ToInt32(lblshort.Text);
                    //string Date = string.IsNullOrEmpty(txtAgentwiseTrayDate.ToString("dd-MM-yyyy")) ? 0 : txtAgentwiseTrayDate.Text;
                    string date = Convert.ToDateTime(txtAgentwiseTrayDate.Text).ToString("dd-MM-yyyy");


                    UpdateRecord(dispatchid, AgentId, EmpId, traydispatched, returntrays, salesmanid, routeid, date, excesstrays, shorttrays);
                }

            }

        }
        private void validateTraysDispatched()
        {
            Label lblSum = (Label)rpAgentwiseTrayInfo.FindControl("lblSum");
            Label lbltdt = (Label)rpAgentwiseTrayInfo.FindControl("tdt");
            Label lblerr = (Label)rpAgentwiseTrayInfo.FindControl("lblerr");
            int a = Convert.ToInt32(lblSum.Text);
            int b = Convert.ToInt32(lbltdt.Text);
            if (a < b)
            {
                lblerr.Text = "Less than Total trays Dispatched: " + lbltdt.Text;

            }
        }
        private void UpdateRecord(int dispatchid, int AgentId, int EmpId, int traydispatched, int returntrays, int salesmanid, int routeid, string date, int excesstrays, int shorttrays)
        {
            int result = 0;
            BAgentwiseTray bagentwisetray = new BAgentwiseTray();
            result = bagentwisetray.AddAgentwiseTrayDetails(dispatchid, AgentId, EmpId, traydispatched, returntrays, salesmanid, routeid, date, excesstrays, shorttrays);
            if (result > 0)
            {

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Agentwise Tray Details Updated  Successfully";
                pnlError.Update();
                upMain.Update();
                uprouteList.Update();

            }
            else
            {
                divDanger.Visible = false;
                divwarning.Visible = true;
                divSusccess.Visible = false;
                lblwarning.Text = "Please Contact to Site Admin";
                pnlError.Update();

            }
        }

        protected void rpAgentwiseTrayInfo_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }



        protected void TraysDispached_TextChanged(object sender, EventArgs e)
        {
            int sum = 0;

            for (int index = 0; index < this.rpAgentwiseTrayInfo.Items.Count; index++)
            {
                TextBox textBox = this.rpAgentwiseTrayInfo.Items[index].FindControl("txtTraysDispached") as TextBox;

                Control HeaderTemplate = rpAgentwiseTrayInfo.Controls[0].Controls[0];

                sum += string.IsNullOrEmpty(textBox.Text) ? 0 : Convert.ToInt32(textBox.Text);

                if (sum > Convert.ToInt32(tdt.Text))
                {

                    lblerr.Visible = true;
                    lblerr.Text = "Trays Exceed More than : " + tdt.Text;
                    textBox.Text = string.Empty;
                    //lblHeader.Visible = false;
                }
                else
                {
                    lblerr.Visible = false;
                    //lblHeader.Visible = true;
                }


            }

            (this.rpAgentwiseTrayInfo.Controls[this.rpAgentwiseTrayInfo.Items.Count + 1].FindControl("lblSum") as Label).Text = sum.ToString();

            ((TextBox)sender).Focus();
        }

        protected void ReturnTrays_TextChanged(object sender, EventArgs e)
        {
            int sum1 = 0;
            //int sum2 = 0;
            int sum3 = 0;
            int sum4 = 0;
            TextBox tb1 = ((TextBox)(sender));
            int a, b, c;
            RepeaterItem rp1 = ((RepeaterItem)(tb1.NamingContainer));
            TextBox trayd = (TextBox)rp1.FindControl("txtTraysDispached");
            try { a = Convert.ToInt32(trayd.Text); }
            catch { a = 0; }
            TextBox returntrsy = (TextBox)rp1.FindControl("txtReturnTrays");
            try { b = Convert.ToInt32(returntrsy.Text); }
            catch { b = 0; }

            Label lblExcess = (Label)rp1.FindControl("lblExcess");
            Label lblShort = (Label)rp1.FindControl("lblShort");
            c = a - b;

            //lblTotr.Text = Convert.ToString(c);


            if (c < 0)
            {
                lblExcess.Text = Convert.ToString(c * (-1));
                lblShort.Text = Convert.ToString(0);
            }
            else
            {
                lblShort.Text = Convert.ToString(c);
                lblExcess.Text = Convert.ToString(0);
            }
            for (int index = 0; index < this.rpAgentwiseTrayInfo.Items.Count; index++)
            {
                TextBox textbox = this.rpAgentwiseTrayInfo.Items[index].FindControl("txtTraysDispached") as TextBox;
                TextBox textbox1 = this.rpAgentwiseTrayInfo.Items[index].FindControl("txtReturnTrays") as TextBox;


                Label TotExcess = this.rpAgentwiseTrayInfo.Items[index].FindControl("lblExcess") as Label;
                Label TotShort = this.rpAgentwiseTrayInfo.Items[index].FindControl("lblShort") as Label;
                sum1 += string.IsNullOrEmpty(textbox1.Text) ? 0 : Convert.ToInt32(textbox1.Text);

                if (sum1 > Convert.ToInt32(trt.Text))
                {

                    lblerr.Visible = true;
                    lblerr.Text = "Return Trays Exceed More than : " + trt.Text;
                    lblShort.Text = Convert.ToString(0);
                    lblExcess.Text = Convert.ToString(0);
                    textbox1.Text = string.Empty;

                    //lblHeader.Visible = false;
                }
                else
                {
                    lblerr.Visible = false;
                    //lblHeader.Visible = true;
                }

                sum3 += string.IsNullOrEmpty(TotExcess.Text) ? 0 : Convert.ToInt32(TotExcess.Text);
                sum4 += string.IsNullOrEmpty(TotShort.Text) ? 0 : Convert.ToInt32(TotShort.Text);
            }
            (this.rpAgentwiseTrayInfo.Controls[this.rpAgentwiseTrayInfo.Items.Count + 1].FindControl("lblSum1") as Label).Text = sum1.ToString();

            (this.rpAgentwiseTrayInfo.Controls[this.rpAgentwiseTrayInfo.Items.Count + 1].FindControl("lblExc") as Label).Text = sum3.ToString();

            (this.rpAgentwiseTrayInfo.Controls[this.rpAgentwiseTrayInfo.Items.Count + 1].FindControl("lblShrt") as Label).Text = sum4.ToString();

            ((TextBox)sender).Focus();



        }

    }
}