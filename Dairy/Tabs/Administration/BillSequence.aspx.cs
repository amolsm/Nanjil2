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
    public class TypeList
    {
        public TypeList(string id, string value)
        {
            this.Id = id;
            this.Value = value;
        }
        public string Id { get; set; }
        public string Value { get; set; }
    }
    public partial class BillSequence : System.Web.UI.Page
    {
        DataSet DS = new DataSet();
        static Dictionary<string, string> temp = new Dictionary<string, string>();

        static List<TypeList> typeList = new List<TypeList>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DS = BindCommanData.BindCommanDropDwon("RouteID ", "RouteCode +' '+RouteName as Name  ", "routeMaster", "IsArchive=1");
                if (!Comman.Comman.IsDataSetEmpty(DS))
                {
                    dpRoute.DataSource = DS;
                    dpRoute.DataBind();
                    dpRoute.Items.Insert(0, new ListItem("--Select Route--", "0"));
                }
                DS = BindCommanData.BindCommanDropDwon("RouteID ", "RouteCode +' '+RouteName as Name  ", "routeMaster", "IsArchive=1");
                if (!Comman.Comman.IsDataSetEmpty(DS))
                {
                    dpRouteTemp.DataSource = DS;
                    dpRouteTemp.DataBind();
                    dpRouteTemp.Items.Insert(0, new ListItem("--Select Route--", "0"));
                }
                temp.Clear();
            }
            //FirstList.Rows = FirstList.Items.Count;
        }

        protected void dpRoute_SelectedIndexChanged(object sender, EventArgs e)
        {
            //clearing temp list variable
            typeList.Clear();

            string routeid = dpRoute.SelectedItem.Value.ToString();
            //DS = BindCommanData.BindCommanDropDwon("'A' + convert(nvarchar(max),AgentID) as AgentID", " AgentCode +' '+AgentName as Name  ", "AgentMaster", "RouteID = " + routeid.ToString());
            //if (!Comman.Comman.IsDataSetEmpty(DS))
            //{
            //    FirstList.DataValueField = "AgentID";
            //    FirstList.DataTextField = "Name";
            //    FirstList.DataSource = DS;
            //    FirstList.DataBind();
            //    FirstList.Rows = FirstList.Items.Count;
            //    //FirstList.Items.Insert(0, new ListItem("--Select Route--", "0"));
            //}
            //else
            //{
            //    FirstList.Items.Clear();
            //}

            ProductData productdata = new ProductData();
            Product product = new Product();
            
            DS = productdata.GetBillSequence(Convert.ToInt32(routeid));
            
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                SortedList.DataValueField = "Id";
                SortedList.DataTextField = "name";
                SortedList.DataSource = DS;
                SortedList.DataBind();
                //SortedList.Rows = FirstList.Items.Count;
                //FirstList.Items.Insert(0, new ListItem("--Select Route--", "0"));
            }
            else
            {
                SortedList.Items.Clear();
            }

            //add into list variable
            foreach (ListItem li in SortedList.Items)
            {
                
                    try
                    {
                        // temp.Add(li.Value, li.Text);
                        if (!typeList.Any(x => x.Id == li.Value))
                            typeList.Add(new TypeList(li.Value, li.Text));
                    }
                    catch (ArgumentException ex)
                    { }
                
            }
        }

        protected void chkEmp_CheckedChanged(object sender, EventArgs e)
        {
            if(chkEmp.Checked)
            { 
            DS = BindCommanData.BindCommanDropDwon("'E' + convert(nvarchar(max),EmployeeID) as EmployeeID ", " EmployeeCode +' '+EmployeeName as Name  ", "EmployeeMaster", "IsActive = 1");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                FirstList.DataValueField = "EmployeeID";
                FirstList.DataTextField = "Name";
                FirstList.DataSource = DS;
                FirstList.DataBind();
                FirstList.Rows = FirstList.Items.Count;
                //FirstList.Items.Insert(0, new ListItem("--Select Route--", "0"));
            }
            else
            {
                FirstList.Items.Clear();
            }
            }
            else
            {
                FirstList.Items.Clear();

            }
            dpRouteTemp.ClearSelection();
        }

        protected void btnIn_Click(object sender, EventArgs e)
        {
           

            //if (SortedList.Items.Count>0)
            //{ }
            
            foreach (ListItem li in FirstList.Items)
            {
                if (li.Selected)
                {
                    try
                    {
                        // temp.Add(li.Value, li.Text);
                        if (!typeList.Any(x=>x.Id == li.Value))
                        typeList.Add(new TypeList(li.Value,li.Text));
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert(' Already Added in List')", true);
                            //dpAgentShemeApplied.Items.FindByValue("2").Selected = true;
                        }
                    }
                    catch (ArgumentException ex)
                    { }
                }

            }
            SortedList.DataValueField = "Id";
            SortedList.DataTextField = "Value";
            SortedList.DataSource = typeList;
            SortedList.DataBind();
        }

        protected void btnOut_Click(object sender, EventArgs e)
        {
            foreach (ListItem li in SortedList.Items)
            {
                if (li.Selected)
                {
                    try
                    {
                        //temp.Remove(li.Value);
                        //typeList.Add(new TypeList(li.Value, li.Text));
                        //SortedList.Items.Remove(li);
                        typeList.RemoveAll(x => x.Id == li.Value);
                    }
                    catch (ArgumentException ex)
                    { }
                }

            }
            SortedList.DataValueField = "Id";
            SortedList.DataTextField = "Value";
            SortedList.DataSource = typeList;
            SortedList.DataBind();
        }

        protected void btnUp_Click(object sender, EventArgs e)
        {
            int selectedIndex = SortedList.SelectedIndex;
            if (selectedIndex > 0)
            {
                SortedList.Items.Insert(selectedIndex - 1, SortedList.Items[selectedIndex]);
                SortedList.Items.RemoveAt(selectedIndex + 1);
                SortedList.SelectedIndex = selectedIndex - 1;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ProductData productdata = new ProductData();
            Product product = new Product();
            int Result = 0;
            Result = productdata.AddBillSequence(0, Convert.ToInt32(dpRoute.SelectedItem.Value), 0);
            foreach (ListItem li in SortedList.Items)
            {
                string str = li.Value;
                if (str.Contains('A'))
                {
                    string str1 = str.Substring(1);
                    int id = Convert.ToInt32(str1);
                    int routeid = Convert.ToInt32(dpRoute.SelectedItem.Value);
                    int flag = 1;
                   // Result = productdata.AddBankInfo(product);
                    Result = productdata.AddBillSequence(id, routeid, flag);
                }
                else if (str.Contains('E'))
                {
                    string str1 = str.Substring(1);
                    int id = Convert.ToInt32(str1);
                    int routeid = Convert.ToInt32(dpRoute.SelectedItem.Value);
                    int flag = 2;
                    //Result = productdata.AddBankInfo(product);
                    Result = productdata.AddBillSequence(id, routeid, flag);
                }

            }
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Bill Sequence Submitted Successfully')", true);
            SortedList.Items.Clear();
            FirstList.Items.Clear();
            chkEmp.Checked = false;
            dpRoute.ClearSelection();
        }

        protected void btnDown_Click(object sender, EventArgs e)
        {
            int selectedIndex = SortedList.SelectedIndex;
            if (selectedIndex < SortedList.Items.Count - 1 & selectedIndex != -1)
            {
                SortedList.Items.Insert(selectedIndex + 2, SortedList.Items[selectedIndex]);
                SortedList.Items.RemoveAt(selectedIndex);
                SortedList.SelectedIndex = selectedIndex + 1;

            }
        }

        protected void dpRouteTemp_SelectedIndexChanged(object sender, EventArgs e)
        {
            //typeList.Clear();

            string routeid = dpRouteTemp.SelectedItem.Value.ToString();
            DS = BindCommanData.BindCommanDropDwon("'A' + convert(nvarchar(max),AgentID) as AgentID", " AgentCode +' '+AgentName as Name  ", "AgentMaster", "RouteID = " + routeid.ToString());
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                FirstList.DataValueField = "AgentID";
                FirstList.DataTextField = "Name";
                FirstList.DataSource = DS;
                FirstList.DataBind();
                //FirstList.Rows = FirstList.Items.Count;
                //FirstList.Items.Insert(0, new ListItem("--Select Route--", "0"));
            }
            else
            {
                FirstList.Items.Clear();
            }
            chkEmp.Checked = false;
        }
    }
}