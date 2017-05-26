using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using Model;
using Bussiness;
using System.Data;
using Dairy.App_code;

namespace Dairy.Authentication
{
    public partial class LoginT : System.Web.UI.Page
    {
        User user = new User();
        protected void Page_Load(object sender, EventArgs e)
        {
            lblmsg.Visible = false;
            DataSet DS = new DataSet();
            if (!IsPostBack)
            {
                DS = BindCommanData.BindCommanDropDwon("AgentID", "AgentCode+' '+AgentName as Name", "AgentMaster", "IsArchive=0 and Agensytype='Booth'");
                if (!Comman.Comman.IsDataSetEmpty(DS))
                {
                    dpAgent.DataSource = DS;
                    dpAgent.DataBind();
                    dpAgent.Items.Insert(0, new ListItem("--Select Booth--", "0"));

                    dpBooth.DataSource = DS;
                    dpBooth.DataBind();
                    dpBooth.Items.Insert(0, new ListItem("--Select Booth--", "0"));
                }
                DS.Clear();
               
                DS = BindCommanData.BindCommanDropDwon("ShiftId as Id", "ShiftName as Name", "ShiftMaster", "IsActive = 1");
                if (!Comman.Comman.IsDataSetEmpty(DS))
                {
                    dpShift.DataSource = DS;
                    dpShift.DataBind();
                    dpShift.Items.Insert(0, new ListItem("--Select Shift--", "0"));
                }
                DS.Clear();
                DS = BindCommanData.BindCommanDropDwon("CenterID", "CenterCode+' '+CenterName as Name", "tbl_MilkCollectionCenter", "IsActive=1");
                if (!Comman.Comman.IsDataSetEmpty(DS))
                {
                    dpCollectionCenter.DataSource = DS;
                    dpCollectionCenter.DataBind();
                    dpCollectionCenter.Items.Insert(0, new ListItem("--Select Collection Center--", "0"));
                }

            }
        }
        protected void btnLogin_clcik(object sender, EventArgs e)
        {

            ViewState["txtpassword"] = txtpassword.Text;
            UserData userData = new UserData();
            user.UserName = txtUsername.Text;
            user.PassWord = txtpassword.Text;// FormsAuthentication.HashPasswordForStoringInConfigFile(txtpassword.Text, "MD5");
            if (userData.Isauthenticat(user) && checkLoggedIn())
            {
                 if (user.RoleID.ToString() == "Sales")
                {
                    AddCookies();
                    PNLLOGIN.Visible = false;
                    PNLSELECTBOTH.Visible = true;
                    pnlSelectShift.Visible = false;
                    pnlCollectionCenter.Visible = false;
                    pnlOfflineBooth.Visible = false;
                    // CreateAutinticationTikit(user, string.Empty);
                }
                else if (user.RoleID.ToString() == "OfflineBooth")
                {
                    AddCookies();
                    PNLLOGIN.Visible = false;
                    PNLSELECTBOTH.Visible = false;
                    pnlSelectShift.Visible = false;
                    pnlCollectionCenter.Visible = false;
                    pnlOfflineBooth.Visible = true;
                    // CreateAutinticationTikit(user, string.Empty);
                }
                else if (user.RoleID.ToString() == "Despatch")
                {
                    AddCookies();
                    PNLLOGIN.Visible = false;
                    PNLSELECTBOTH.Visible = false;
                    pnlSelectShift.Visible = true;
                    pnlCollectionCenter.Visible = false;
                    pnlOfflineBooth.Visible = false;
                    // CreateAutinticationTikit(user, string.Empty);
                }
                else if (user.RoleID.ToString() == "Procurement")
                {
                    AddCookies();
                    PNLLOGIN.Visible = false;
                    PNLSELECTBOTH.Visible = false;
                    pnlSelectShift.Visible = false;
                    pnlCollectionCenter.Visible = true;
                    pnlOfflineBooth.Visible = false;
                    // CreateAutinticationTikit(user, string.Empty);
                }
                else
                {
                    AddCookies();
                    PNLLOGIN.Visible = true;
                    PNLSELECTBOTH.Visible = false;
                    pnlOfflineBooth.Visible = false;
                    CreateAutinticationTikit(user, string.Empty, string.Empty,string.Empty);


                }
               

            }
            else
            {
                txtUsername.Text = "";
                txtpassword.Text = "";
                lblmsg.Visible = true;
            }
        }
        string username = string.Empty;
        public bool checkLoggedIn()
        {
            
            HttpCookie myCookie = Request.Cookies["myCookie"];
            if (myCookie != null)
            {
                if (!string.IsNullOrEmpty(myCookie.Values["username"]))
                {
                    username = myCookie.Values["username"].ToString();
                }
            }
          List<string> d = Application["UsersLoggedIn"] as List<string>;
            if (d != null)
            {
                lock (d)
                {
                    if (d.Contains(user.UserName))
                    {
                        Int32 temp = 0;
                        try
                        {
                            temp = GlobalInfo.Userid;
                        }
                        catch (Exception) { }

                        if (user.UserID == temp)
                        {
                            return true;
                        }
                        else if (txtUsername.Text== username)
                        {
                            return true;
                        }
                        else
                        { // User is already logged in!!!
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('User already logged in')", true);
                            return false;
                        }
                        
                    }
                    d.Add(user.UserName);
                }
            }
            Session["UserLoggedIn"] = user.UserName;
            return true;
        }
          public void CreateAutinticationTikit(User user,string bothID, string ShiftId,string Coll_CenterId, string offlineBoothDate = "none")
        {
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, txtUsername.Text,
                DateTime.Now, DateTime.Now.AddMinutes(60),
                true, user.UserID.ToString() + ";" + user.RoleID.ToString() + ";" + user.UserName.ToString() + ";" + user.privilege.ToString() + ";" + user.LastLogin+ ";" + bothID + ";" + ShiftId + ";" + offlineBoothDate + ";" + Coll_CenterId,
                FormsAuthentication.FormsCookiePath);
                string hash = FormsAuthentication.Encrypt(ticket);
                HttpCookie cookie = new HttpCookie(
                FormsAuthentication.FormsCookieName, // Name of auth cookie (it's the name specified in web.config)
                hash); // Hashed ticket                        
                Response.Cookies.Add(cookie);
                switch (user.RoleID.ToString())
                {
                      case "Administration":
                        {
                            Response.Redirect("/Tabs/Administration/CreateUser.aspx");
                            break;
                        }
                        case "Reception":
                        {
                            Response.Redirect("/Tabs/Reception/PlaceOrder.aspx");
                            break;
                        }
                        case "Sales":
                        {
                            Response.Redirect("/Tabs/Sales/BoothStockLanding.aspx");
                            break;
                        }
                        case "Despatch":
                        {
                            Response.Redirect("/Tabs/Despatch/DispatchOrders.aspx");
                            break;
                        }   
                        case "Cashier":
                            {
                                Response.Redirect("/Tabs/Cashier/Cashier.aspx");
                                break;
                            }
                        case "Transport":
                            {
                                Response.Redirect("/Tabs/TransportModule/TransportBrandMaster.aspx");
                                break;
                            }
                        case "Purchase":
                            {
                                Response.Redirect("/Tabs/Purchase/Dashboard.aspx");
                                break;
                            }
                       case "Marketing":
                            {
                                Response.Redirect("/Tabs/Marketing/AgentSchemeDetails.aspx");
                                break;
                            }
                      case "Procurement":
                           {
                        Response.Redirect("/Tabs/Procurement/MilkCollectionDetails.aspx");
                        break;
                           }
                case "OfflineBooth":
                    {
                        Response.Redirect("/Tabs/OfflineBooth/BoothStockLanding.aspx");
                        break;
                    }
            }               

            }
              
        public bool boothLoggedIn()
        {
            List<string> d = Application["BoothLoggedIn"] as List<string>;
            if (d != null)
            {
                lock (d)
                {
                    if (d.Contains(dpAgent.SelectedItem.Text))
                    {
                        // User is already logged in!!!
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Booth already logged in')", true);
                        return false;
                    }
                    d.Add(dpAgent.SelectedItem.Text);
                }
            }
            Session["BoothLoggedIn"] = dpAgent.SelectedItem.Text;
            return true;
        }

        public bool collectioncenterLoggedIn()
        {
            List<string> d = Application["CollectionCenterLoggedIn"] as List<string>;
            if (d != null)
            {
                lock (d)
                {
                    if (d.Contains(dpCollectionCenter.SelectedItem.Text))
                    {
                        // User is already logged in!!!
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Collection Center already logged in')", true);
                        return false;
                    }
                    d.Add(dpCollectionCenter.SelectedItem.Text);
                }
            }
            Session["CollectionCenterLoggedIn"] = dpCollectionCenter.SelectedItem.Text;
            return true;
        }
        protected void dpShift_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dpShift.SelectedItem.Value != "0")
            {
                UserData userData = new UserData();
                user.UserName = txtUsername.Text;
                user.PassWord = ViewState["txtpassword"].ToString();//txtpassword.Text;// FormsAuthentication.HashPasswordForStoringInConfigFile(txtpassword.Text, "MD5");
                if (userData.Isauthenticat(user))
                {
                    CreateAutinticationTikit(user, string.Empty, dpShift.SelectedItem.Value,string.Empty);
                }
            }
        }

        protected void dpAgent_TextChanged(object sender, EventArgs e)
        {
            if (dpAgent.SelectedItem.Value != "0")
            {
                UserData userData = new UserData();
                user.UserName = txtUsername.Text;
                user.PassWord = ViewState["txtpassword"].ToString();//txtpassword.Text;// FormsAuthentication.HashPasswordForStoringInConfigFile(txtpassword.Text, "MD5");
                if (userData.Isauthenticat(user) && boothLoggedIn())
                {
                    CreateAutinticationTikit(user, dpAgent.SelectedItem.Value, string.Empty,string.Empty);
                }
            }
        }

        public void AddCookies()
        {
            HttpCookie myCookie = new HttpCookie("myCookie");

            //Add key-values in the cookie
            myCookie.Values.Add("username", txtUsername.Text.ToString());

            //set cookie expiry date-time. Made it to last for next 12 hours.
            myCookie.Expires = DateTime.Now.AddHours(12);

            //Most important, write the cookie to client.
            Response.Cookies.Add(myCookie);
        }

        protected void dpCollectionCenter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dpCollectionCenter.SelectedItem.Value != "0")
            {
                UserData userData = new UserData();
                user.UserName = txtUsername.Text;
                user.PassWord = ViewState["txtpassword"].ToString();//txtpassword.Text;// FormsAuthentication.HashPasswordForStoringInConfigFile(txtpassword.Text, "MD5");
                if (userData.Isauthenticat(user) && collectioncenterLoggedIn())
                {
                    CreateAutinticationTikit(user, string.Empty, string.Empty,dpCollectionCenter.SelectedItem.Value);
                }
            }
        }

        protected void btnOfflineBooth_Click(object sender, EventArgs e)
        {
            string temp;
            try
            {
                temp = (Convert.ToDateTime(txtOfflineBoothDate.Text)).ToString("dd-MM-yyyy");

            }
            catch (Exception) { temp = string.Empty; }
            if (dpBooth.SelectedItem.Value != "0" && temp != string.Empty)
            {
                UserData userData = new UserData();
                user.UserName = txtUsername.Text;
                user.PassWord = ViewState["txtpassword"].ToString();//txtpassword.Text;// FormsAuthentication.HashPasswordForStoringInConfigFile(txtpassword.Text, "MD5");
                if (userData.Isauthenticat(user) && boothLoggedIn())
                {
                    CreateAutinticationTikit(user, dpBooth.SelectedItem.Value, string.Empty, string.Empty, temp);
                }
            }
        }
    }
    }
