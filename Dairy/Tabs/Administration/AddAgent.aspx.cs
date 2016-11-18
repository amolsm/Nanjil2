using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using Bussiness;
using System.Data;
using Dairy.App_code;
using Comman;


namespace Dairy.Tabs.Administration
{

    public partial class AddAgent : System.Web.UI.Page
    {


        DataSet DS = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDwon();
                BinDAgentInfo();
                BindActiveAndDeactiveCount();
                btnAddagent.Visible = true;
                btnupdateagent.Visible = false;
                //txtAgentCode.Enabled = false;
                txtDateOfJoing.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                
            }

        }
        protected void BindActiveAndDeactiveCount()
        {

            DS = BindCommanData.GetAllActiveAndDeactiveCount("agentmaster", "Isactive");
            if (DS.Tables[0].Rows.Count != 0)
                lblActiveCount.Text = DS.Tables[0].Rows[0]["Count"].ToString();
            if (DS.Tables[1].Rows.Count != 0)
                lblDeactive.Text = DS.Tables[1].Rows[0]["Count"].ToString();

        }
        protected void BindDropDwon()
        {
            DS = new DataSet();
            DS = BindCommanData.BindCommanDropDwonDistinct("LocId", "City as Name", "StateMaster", "LocId is not null");
            dpCity.DataSource = DS;
            dpCity.DataBind();
            dpCity.Items.Insert(0, new ListItem("--Select City--", "0"));

            DS = new DataSet();
            DS = BindCommanData.BindCommanDropDwonDistinct("LocId", "District as Name", "StateMaster", "LocId is not null");
            dpDistric.DataSource = DS;
            dpDistric.DataBind();
            dpDistric.Items.Insert(0, new ListItem("--Select District--", "0"));

            DS = new DataSet();
            DS = BindCommanData.BindCommanDropDwonDistinct("LocId", "State as Name", "StateMaster", "LocId is not null");
            dpState.DataSource = DS;
            dpState.DataBind();
            dpState.Items.Insert(0, new ListItem("--Select State--", "0"));

            DS = new DataSet();
            DS = BindCommanData.BindCommanDropDwonDistinct("LocId", "Country as Name", "StateMaster", "LocId is not null");
            dpCountry.DataSource = DS;
            dpCountry.DataBind();
            dpCountry.Items.Insert(0, new ListItem("--Select Country--", "0"));

            RouteData routeData = new RouteData();
            DS = BindCommanData.BindCommanDropDwon("RouteID ", "RouteCode +' '+RouteName as Name  ", "routeMaster", "IsArchive=1 ");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpRoute.DataSource = DS;
                dpRoute.DataBind();
                dpRoute.Items.Insert(0, new ListItem("--Select Route  --", "0"));
            }
            DS.Clear();

            DS = new DataSet();
            DS = BindCommanData.BindCommanDropDwonDistinct("ID", "BankName as Name", "BankDetails", "ID is not null");
            dpBankName.DataSource = DS;
            dpBankName.DataBind();
            dpBankName.Items.Insert(0, new ListItem("--Select Bank Name--", "0"));

            DS = new DataSet();
            DS = BindCommanData.BindCommanDropDwonDistinct("ID", "IFSCCode as Name", "BankDetails", "ID is not null");
            dpIfscCode.DataSource = DS;
            dpIfscCode.DataBind();
            dpIfscCode.Items.Insert(0, new ListItem("--Select Ifsc Code--", "0"));


            DS = new DataSet();
            DS = BindCommanData.BindCommanDropDwon("TypeID", "TypeName", "TypeMaster", "IsArchive=1");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpType.DataSource = DS;
                dpType.DataTextField = "TypeName";
                dpType.DataValueField = "TypeID";
                dpType.DataBind();
                dpType.Items.Insert(0, new ListItem("--Select TypeName  --", "0"));

            }
            DS = new DataSet();
            DS = BindCommanData.BindCommanDropDwon("SlabID", "SlabName", "SlabMaster", "IsArchive=0");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpSlab.DataSource = DS;
                dpSlab.DataTextField = "SlabName";
                dpSlab.DataValueField = "SlabID";
                dpSlab.DataBind();
                dpSlab.Items.Insert(0, new ListItem("--Select SlabName  --", "0"));

            }
          
            //EmployeeData empData = new EmployeeData();
            //DS = BindCommanData.BindCommanDropDwon("RouteID ", "RouteCode +' '+RouteName as Name  ", "routeMaster", "IsArchive=0");
            //if (!Comman.Comman.IsDataSetEmpty(DS))
            //{
            //    dpEmployeeID.DataSource = DS;
            //    dpEmployeeID.DataBind();
            //    dpEmployeeID.Items.Insert(0, new ListItem("--Select Employee  --", "0"));
            //}
        }
        protected void BinDAgentInfo()
        {
            AgentInfoData agent = new AgentInfoData();
            DS = agent.GetAllAgentDetails();
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                int count = Convert.ToInt32(DS.Tables[1].Rows[0]["id"]);
                count = count + 1;
                //txtAgentCode.Text = string.Format("A{0:0000}", count++);
                rpAgentINfo.DataSource = DS;
                rpAgentINfo.DataBind();
            }

        }
        protected void btnAddagent_click(object sender, EventArgs e)
        {
            AgentInfo agentInfo = new AgentInfo();
            AgentInfoData agentData = new AgentInfoData();
            int Result = 0;
            agentInfo.AgentID = 0;
            agentInfo.AgentCode = txtAgentCode.Text;
            agentInfo.RouteID = Convert.ToInt32(dpRoute.SelectedItem.Value);
            agentInfo.AgentName = txtAgentName.Text;
            agentInfo.DateofJoining = (Convert.ToDateTime(txtDateOfJoing.Text)).ToString("dd-MM-yyyy"); 
            agentInfo.AppriveBy = txtApprovedBy.Text;
            if (dpStatus.SelectedItem.Value == "1")
            {
                agentInfo.Status = true;
            }
            if (dpStatus.SelectedItem.Value == "2")
            {
                agentInfo.Status = false;
            }
            //agentInfo.EmployeeID = 1;// Convert.ToInt32(dpEmployeeID.SelectedItem.Value);
            agentInfo.Agensytype = dpAgencyType.SelectedItem.Text;
            agentInfo.Address1 = txtAddress1.Text;
            agentInfo.Address2 = txtAddress2.Text;
            agentInfo.Address3 = txtAddress3.Text;
            agentInfo.Email = txtEmail.Text;
            agentInfo.TelephoneNo = txtTelephone.Text; ;
            agentInfo.MobileNo = txtMobile.Text; ;
            agentInfo.City = dpCity.SelectedItem.Text;
            agentInfo.Districk = dpDistric.SelectedItem.Text;
            agentInfo.State = dpState.SelectedItem.Text;
            agentInfo.Country = dpCountry.SelectedItem.Text;
            agentInfo.BillingMethod = dpbillingtype.SelectedItem.Text;
            agentInfo.PaymentType = dppaymenttype.SelectedItem.Text; ;
            agentInfo.DepositAmount = string.IsNullOrEmpty(txtDepositeAmount.Text) ? 0 : Convert.ToDouble(txtDepositeAmount.Text);
            agentInfo.BankName = dpBankName.SelectedItem.Text;
            agentInfo.AccounNo = txtAccountNo.Text;
            agentInfo.AccountType = dpAccountType.SelectedItem.Text;
            agentInfo.IFSCCode = dpIfscCode.SelectedItem.Text;
            agentInfo.Volume = txtValoume.Text;
            agentInfo.NoofTrays = string.IsNullOrEmpty(txtNoOfTrays.Text) ? 0 : Convert.ToInt32(txtNoOfTrays.Text);


            if (dpDoorToDoor.SelectedItem.Value == "1")
            {
                agentInfo.DoortoDoor = true;
            }
            if (dpDoorToDoor.SelectedItem.Value == "1")
            {
                agentInfo.DoortoDoor = false;
            }

            if (rbcFreezerYes.Checked == true)
            {
                agentInfo.FreezerAvailable = true;
            }
            if (rbcFreezerNo.Checked == true)
            {
                agentInfo.FreezerAvailable = false;
            }
            if (rbFreezerRestrunYes.Checked == true)
            {
                agentInfo.FreezerRestrun = true;
            }
            if (rbFreezerRestrunNo.Checked == true)
            {
                agentInfo.FreezerRestrun = false;
            }
            if(txtDeactivedate.Text=="")
            {
               agentInfo.Deactivedate= txtDeactivedate.Text;
            }
            else
            {
            agentInfo.Deactivedate = (Convert.ToDateTime(txtDeactivedate.Text)).ToString("dd-MM-yyyy");
            }
            agentInfo.DeactiveReason = txtDeactiveRession.Text;
            agentInfo.AmountReturned = string.IsNullOrEmpty(txtAmountRetrun.Text) ? 0 : Convert.ToDouble(txtAmountRetrun.Text);
            agentInfo.TraysReturned = string.IsNullOrEmpty(txtAmountRetrun.Text) ? 0 : Convert.ToInt32(txtAmountRetrun.Text);
            agentInfo.SchemeAmount = string.IsNullOrEmpty(txtSchemeAmount.Text) ? 0 : Convert.ToDouble(txtSchemeAmount.Text);
            agentInfo.SchemeTotalAmount = string.IsNullOrEmpty(txtSchemeTotalAmount.Text) ? 0 : Convert.ToDouble(txtSchemeTotalAmount.Text);
            agentInfo.IsArchive = false;
            agentInfo.CreatedBy = GlobalInfo.Userid;
            agentInfo.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
            agentInfo.ModifiedBy = GlobalInfo.Userid;
            agentInfo.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");
            agentInfo.flag = "Insert";
            Result = agentData.InsertAgentInfo(agentInfo);
            if (Result > 0)
            {

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Agent Added  Successfully";
                BinDAgentInfo();
                upMain.Update();
                Clear();
                pnlError.Update();
                uprouteList.Update();
            }
            else
            {
                divDanger.Visible = false;
                divwarning.Visible = true;
                divSusccess.Visible = false;
                lblWarningHead.Text = "   Please Contact to Site Admin";
                lblwarning.Text = Comman.Comman.msg.ToString(); 
                pnlError.Update();

            }



        }
        protected void btnUpdate_click(object sender, EventArgs e)
        {
            AgentInfo agentInfo = new AgentInfo();
            AgentInfoData agentData = new AgentInfoData();
            int Result = 0;
            agentInfo.AgentID = Convert.ToInt32(hfAgentID.Value);
            agentInfo.AgentCode = txtAgentCode.Text;
            agentInfo.RouteID = Convert.ToInt32(dpRoute.SelectedItem.Value);
            agentInfo.AgentName = txtAgentName.Text;
            agentInfo.DateofJoining =txtDateOfJoing.Text;
            agentInfo.AppriveBy = txtApprovedBy.Text;
            if (dpStatus.SelectedItem.Value == "1")
            {
                agentInfo.Status = true;
            }
            if (dpStatus.SelectedItem.Value == "2")
            {
                agentInfo.Status = false;
            }
            //agentInfo.EmployeeID = 1;// Convert.ToInt32(dpEmployeeID.SelectedItem.Value);
            agentInfo.Agensytype = dpAgencyType.SelectedItem.Text;
            agentInfo.Address1 = txtAddress1.Text;
            agentInfo.Address2 = txtAddress2.Text;
            agentInfo.Address3 = txtAddress3.Text;
            agentInfo.Email = txtEmail.Text; ;
            agentInfo.TelephoneNo = txtTelephone.Text; ;
            agentInfo.MobileNo = txtMobile.Text;
            agentInfo.Districk = dpDistric.SelectedItem.Text;
            agentInfo.City = dpCity.SelectedItem.Text;
            agentInfo.State = dpState.SelectedItem.Text;
            agentInfo.Country = dpCountry.SelectedItem.Text;
            agentInfo.BillingMethod = dpbillingtype.SelectedItem.Text;
            agentInfo.PaymentType = dppaymenttype.SelectedItem.Text; ;
            agentInfo.DepositAmount = string.IsNullOrEmpty(txtDepositeAmount.Text) ? 0 : Convert.ToDouble(txtDepositeAmount.Text);
            agentInfo.BankName = dpBankName.SelectedItem.Text;
            agentInfo.AccounNo = txtAccountNo.Text;
            agentInfo.AccountType = dpAccountType.SelectedItem.Text;
            agentInfo.IFSCCode = dpIfscCode.SelectedItem.Text;
            agentInfo.Volume = txtValoume.Text;
            agentInfo.NoofTrays = string.IsNullOrEmpty(txtNoOfTrays.Text) ? 0 : Convert.ToInt32(txtNoOfTrays.Text);
            if (dpDoorToDoor.SelectedItem.Value == "1")
            {
                agentInfo.DoortoDoor = true;
            }
            if (dpDoorToDoor.SelectedItem.Value == "1")
            {
                agentInfo.DoortoDoor = false;
            }

            if (rbcFreezerYes.Checked == true)
            {
                agentInfo.FreezerAvailable = true;
            }
            if (rbcFreezerNo.Checked == true)
            {
                agentInfo.FreezerAvailable = false;
            }
            if (rbFreezerRestrunYes.Checked == true)
            {
                agentInfo.FreezerRestrun = true;
            }
            if (rbFreezerRestrunNo.Checked == true)
            {
                agentInfo.FreezerRestrun = false;
            }
            if (txtDeactivedate.Text == "")
            {
                agentInfo.Deactivedate = txtDeactivedate.Text;
            }
            else
            {
                agentInfo.Deactivedate = (Convert.ToDateTime(txtDeactivedate.Text)).ToString("dd-MM-yyyy");
            }
            agentInfo.DeactiveReason =  Convert.ToString(txtDeactiveRession.Text); 
            agentInfo.AmountReturned = string.IsNullOrEmpty(txtAmountRetrun.Text) ? 0 : Convert.ToDouble(txtAmountRetrun.Text);
            agentInfo.TraysReturned = string.IsNullOrEmpty(txtTraysReturned.Text) ? 0 : Convert.ToInt32(txtTraysReturned.Text);
            agentInfo.SchemeAmount = string.IsNullOrEmpty(txtSchemeAmount.Text) ? 0 : Convert.ToDouble(txtSchemeAmount.Text);
            agentInfo.SchemeTotalAmount = string.IsNullOrEmpty(txtSchemeTotalAmount.Text) ? 0 : Convert.ToDouble(txtSchemeTotalAmount.Text);
            agentInfo.IsArchive = false;
            agentInfo.CreatedBy = GlobalInfo.Userid;
            agentInfo.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
            agentInfo.ModifiedBy = GlobalInfo.Userid;
            agentInfo.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");
            agentInfo.flag = "Update";
            Result = agentData.InsertAgentInfo(agentInfo);
            if (Result > 0)
            {

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Agent Updated  Successfully";
                btnAddagent.Visible = true;
                btnupdateagent.Visible = false;
                Clear();
                BinDAgentInfo();
                upMain.Update();
                pnlError.Update();
                uprouteList.Update();
                //txtAgentCode.Enabled = false;
            }
            else
            {
                divDanger.Visible = false;
                divwarning.Visible = true;
                divSusccess.Visible = false;
                lblWarningHead.Text = "   Please Contact to Site Admin";
                lblwarning.Text = Comman.Comman.msg.ToString(); 
                pnlError.Update();

            }



        }

        protected void rpAgentInfo_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            divDanger.Visible = false;
            divwarning.Visible = false;
            divSusccess.Visible = false;
            pnlError.Update();
            int agentID = 0;
            agentID = Convert.ToInt32(e.CommandArgument);
            switch (e.CommandName)
            {
                case ("Edit"):
                    {
                        lblHeaderTab.Text = "Edit Agent";

                        hfAgentID.Value = agentID.ToString();
                        agentID = Convert.ToInt32(hfAgentID.Value);

                        btnAddagent.Visible = false;
                        btnupdateagent.Visible = true;
                        //BinDAgentInfo();
                        GetAgentbyID(agentID);
                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }
                case ("Delete"):
                    {

                        hfAgentID.Value = agentID.ToString();
                        agentID = Convert.ToInt32(hfAgentID.Value);
                        DeleteAgentbyID(agentID);
                        BinDAgentInfo();
                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }
                case ("MapSlab"):
                    {
                        // lblHeaderTab.Text = "Edit Agent";

                        hfAgentID.Value = agentID.ToString();
                        agentID = Convert.ToInt32(hfAgentID.Value);

                        btnAddagent.Visible = false;
                        btnupdateagent.Visible = true;
                        //BinDAgentInfo();
                        GetAgentbyID(agentID);
                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }

            }
        }
        public void DeleteAgentbyID(int AgentId)
        {

            AgentInfo agentInfo = new AgentInfo();
            AgentInfoData agentData = new AgentInfoData();
            int Result = 0;
            agentInfo.AgentID = Convert.ToInt32(hfAgentID.Value);
            agentInfo.AgentCode = string.Empty;
            agentInfo.RouteID = 0;
            agentInfo.AgentName = string.Empty;
            agentInfo.DateofJoining = string.Empty;
            agentInfo.AppriveBy = string.Empty;
            if (dpStatus.SelectedItem.Value == "1")
            {
                agentInfo.Status = true;
            }
            if (dpStatus.SelectedItem.Value == "2")
            {
                agentInfo.Status = true;
            }
            //agentInfo.EmployeeID = 0;
            agentInfo.Agensytype = string.Empty;
            agentInfo.Address1 = string.Empty;
            agentInfo.Address2 = string.Empty;
            agentInfo.Address3 = string.Empty;
            agentInfo.Email = string.Empty;
            agentInfo.TelephoneNo = string.Empty;
            agentInfo.MobileNo = string.Empty;
            agentInfo.Districk = string.Empty;
            agentInfo.City = string.Empty;
            agentInfo.State = string.Empty;
            agentInfo.Country = string.Empty;
            agentInfo.BillingMethod = string.Empty;
            agentInfo.PaymentType = string.Empty;
            agentInfo.DepositAmount = 0;
            agentInfo.BankName = string.Empty;
            agentInfo.AccounNo = string.Empty;
            agentInfo.AccountType = string.Empty;
            agentInfo.IFSCCode = string.Empty;
            agentInfo.Volume = string.Empty;
            agentInfo.NoofTrays = 0;

            agentInfo.DoortoDoor = false;

            agentInfo.FreezerAvailable = false;

            agentInfo.Deactivedate = string.Empty;
            agentInfo.DeactiveReason = string.Empty;
            agentInfo.AmountReturned = 0;
            agentInfo.TraysReturned = 0;
            agentInfo.SchemeAmount = 0;// string.IsNullOrEmpty(txtAmountRetrun.Text) ? 0 : Convert.ToDouble(txtSchemeAmount.Text);
            agentInfo.SchemeTotalAmount = 0;// string.IsNullOrEmpty(txtAmountRetrun.Text) ? 0 : Convert.ToDouble(txtSchemeAmountShemeTotalAmount.Text);
            agentInfo.IsArchive = true;
            agentInfo.CreatedBy = GlobalInfo.Userid;
            agentInfo.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
            agentInfo.ModifiedBy = GlobalInfo.Userid;
            agentInfo.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");
            agentInfo.flag = "Delete";
            Result = agentData.InsertAgentInfo(agentInfo);
            if (Result > 0)
            {

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Agent Delete  Successfully";
                btnAddagent.Visible = true;
                btnupdateagent.Visible = false;
                BinDAgentInfo();
                pnlError.Update();
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
        public void GetAgentbyID(int dbagentinfo)
        {
            txtAgentCode.Enabled = true;
            AgentInfoData agentInfoData = new AgentInfoData();
            DataSet DS = new DataSet();
            DS = agentInfoData.GetAgentbyID(dbagentinfo);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                txtAgentCode.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["AgentCode"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["AgentCode"].ToString();
                dpRoute.ClearSelection();
                if (dpRoute.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["RouteID"]).ToString()) != null)
                {
                    dpRoute.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["RouteID"]).ToString()).Selected = true;
                }
                txtAgentName.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["AgentName"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["AgentName"].ToString();
                //string DateofJoining = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["DateofJoining"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["DateofJoining"].ToString();
                //if (!string.IsNullOrEmpty(DateofJoining))
                //{
                //    txtDateOfJoing.Text = (Convert.ToDateTime(DateofJoining).ToString("yyyy-MM-dd"));
                //}
                string DateofJoiningstring = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["DateofJoining"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["DateofJoining"].ToString();
                //sky
                DateTime date1 = Convert.ToDateTime(DateofJoiningstring, System.Globalization.CultureInfo.GetCultureInfo("ur-PK").DateTimeFormat);
                txtDateOfJoing.Text = (Convert.ToDateTime(date1).ToString("yyyy-MM-dd"));

                txtApprovedBy.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["AppriveBy"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["AppriveBy"].ToString();
                dpStatus.ClearSelection();
                if (DS.Tables[0].Rows[0]["Isactive"].ToString() == "True")
                {
                    dpStatus.Items.FindByValue("1").Selected = true;
                }
                if (DS.Tables[0].Rows[0]["Isactive"].ToString() == "False")
                {
                    dpStatus.Items.FindByValue("2").Selected = true;
                }
                //dpEmployeeID.ClearSelection();
                //if (dpEmployeeID.Items.FindByValue(DS.Tables[0].Rows[0]["EmployeeID"].ToString()) != null)
                //{
                //    dpEmployeeID.Items.FindByValue(DS.Tables[0].Rows[0]["EmployeeID"].ToString()).Selected = true;
                //}
                dpAgencyType.ClearSelection();
                if (dpAgencyType.Items.FindByText(DS.Tables[0].Rows[0]["Agensytype"].ToString()) != null)
                {
                    dpAgencyType.Items.FindByText(DS.Tables[0].Rows[0]["Agensytype"].ToString()).Selected = true;
                }

                txtAddress1.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Address1"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Address1"].ToString();
                txtAddress2.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Address2"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Address2"].ToString();
                txtAddress3.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Address2"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Address2"].ToString();
                txtEmail.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Email"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Email"].ToString();
                txtTelephone.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["TelephoneNo"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["TelephoneNo"].ToString();
                txtMobile.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["MobileNo"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["MobileNo"].ToString();
                //dpDistrict.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Districk"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Districk"].ToString();
                //txtCity.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["City"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["City"].ToString();
                dpDistric.ClearSelection();
                if (dpDistric.Items.FindByText(DS.Tables[0].Rows[0]["Districk"].ToString()) != null)
                {
                    dpDistric.Items.FindByText(DS.Tables[0].Rows[0]["Districk"].ToString()).Selected = true;
                }
                dpCity.ClearSelection();
                if (dpCity.Items.FindByText(DS.Tables[0].Rows[0]["City"].ToString()) != null)
                {
                    dpCity.Items.FindByText(DS.Tables[0].Rows[0]["City"].ToString()).Selected = true;
                }
                dpState.ClearSelection();
                if (dpState.Items.FindByText(DS.Tables[0].Rows[0]["State"].ToString()) != null)
                {
                    dpState.Items.FindByText(DS.Tables[0].Rows[0]["State"].ToString()).Selected = true;
                }
                dpCountry.ClearSelection();
                if (dpCountry.Items.FindByText(DS.Tables[0].Rows[0]["Country"].ToString()) != null)
                {
                    dpCountry.Items.FindByText(DS.Tables[0].Rows[0]["Country"].ToString()).Selected = true;
                }

                dpbillingtype.ClearSelection();
                if (dpbillingtype.Items.FindByText(DS.Tables[0].Rows[0]["BillingMethod"].ToString()) != null)
                {
                    dpbillingtype.Items.FindByText(DS.Tables[0].Rows[0]["BillingMethod"].ToString()).Selected = true;
                }
                dppaymenttype.ClearSelection();
                if (dppaymenttype.Items.FindByText(DS.Tables[0].Rows[0]["PaymentMode"].ToString()) != null)
                {
                    dppaymenttype.Items.FindByText(DS.Tables[0].Rows[0]["PaymentMode"].ToString()).Selected = true;
                }
                txtDepositeAmount.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["DepositeAmount"].ToString()) ? string.Empty : string.Format("{0:0.#####}", DS.Tables[0].Rows[0]["DepositeAmount"].ToString());
                dpBankName.ClearSelection();
                if (dpBankName.Items.FindByText(DS.Tables[0].Rows[0]["BankName"].ToString()) != null)
                {
                    dpBankName.Items.FindByText(DS.Tables[0].Rows[0]["BankName"].ToString()).Selected = true;
                }
                //txtBankName.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Bankname"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Bankname"].ToString();
                txtAccountNo.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["AccountNo"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["AccountNo"].ToString();
                dpAccountType.ClearSelection();
                if (dpAccountType.Items.FindByText(DS.Tables[0].Rows[0]["AccountType"].ToString()) != null)
                {
                    dpAccountType.Items.FindByText(DS.Tables[0].Rows[0]["AccountType"].ToString()).Selected = true;
                }

                // txtIfscCode.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["IFScode"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["IFScode"].ToString();
                dpIfscCode.ClearSelection();
                if (dpIfscCode.Items.FindByText(DS.Tables[0].Rows[0]["IFScode"].ToString()) != null)
                {
                    dpIfscCode.Items.FindByText(DS.Tables[0].Rows[0]["IFScode"].ToString()).Selected = true;
                }


                txtValoume.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Volume"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Volume"].ToString();
                txtNoOfTrays.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["NoTrays"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["NoTrays"].ToString();
                dpDoorToDoor.ClearSelection();
                if (DS.Tables[0].Rows[0]["DoorToDoor"].ToString() == "True")
                {
                    dpDoorToDoor.Items.FindByValue("1").Selected = true;
                }
                if (DS.Tables[0].Rows[0]["DoorToDoor"].ToString() == "False")
                {
                    dpDoorToDoor.Items.FindByValue("2").Selected = true;
                }

                if (DS.Tables[0].Rows[0]["FreezerAvailable"].ToString() == "True")
                {
                    rbcFreezerYes.Checked = true;
                }
                if (DS.Tables[0].Rows[0]["FreezerAvailable"].ToString() == "False")
                {
                    rbcFreezerNo.Checked = true;
                }


                if (DS.Tables[0].Rows[0]["FreezerRetrun"].ToString() == "True")
                {
                    rbFreezerRestrunYes.Checked = true;
                }
                if (DS.Tables[0].Rows[0]["FreezerRetrun"].ToString() == "False")
                {
                    rbFreezerRestrunNo.Checked = true;
                }

               // string Deactivedate = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Deactivedate"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Deactivedate"].ToString();


                if (DS.Tables[0].Rows[0]["Deactivedate"].ToString() == "")
                {
                    txtDeactivedate.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Deactivedate"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Deactivedate"].ToString();
                }
                else
                {
                    string DateofDeactivation = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Deactivedate"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Deactivedate"].ToString();
                    //sky
                    DateTime date2 = Convert.ToDateTime(DateofDeactivation, System.Globalization.CultureInfo.GetCultureInfo("ur-PK").DateTimeFormat);
                    txtDeactivedate.Text = (Convert.ToDateTime(date2).ToString("yyyy-MM-dd"));
                }
                txtDeactiveRession.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["DeactiveReason"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["DeactiveReason"].ToString();
                txtAmountRetrun.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["AmountReturned"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["AmountReturned"].ToString();
                txtTraysReturned.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["TraysReturned"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["TraysReturned"].ToString();
                txtSchemeAmount.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["SchemeAmount"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["SchemeAmount"].ToString();
                txtSchemeTotalAmount.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["TotalSchemeAmount"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["TotalSchemeAmount"].ToString();

            }
        }
        public void Clear()
        {

            txtAgentCode.Text = string.Empty;
            dpRoute.ClearSelection();
            txtAgentName.Text = string.Empty;
            txtDateOfJoing.Text = string.Empty;
            txtApprovedBy.Text = string.Empty;
            dpStatus.ClearSelection();


            dpAgencyType.ClearSelection();


            txtAddress1.Text = string.Empty;
            txtAddress2.Text = string.Empty;
            txtAddress3.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtTelephone.Text = string.Empty;
            txtMobile.Text = string.Empty;
            dpDistric.ClearSelection();
            dpCity.ClearSelection();

            dpCountry.ClearSelection();


            dpbillingtype.ClearSelection();

            dppaymenttype.ClearSelection();

            txtDepositeAmount.Text = string.Empty;
            dpBankName.ClearSelection();
            txtAccountNo.Text = string.Empty;
            dpAccountType.ClearSelection();


            dpIfscCode.ClearSelection();
            txtValoume.Text = string.Empty;
            txtNoOfTrays.Text = string.Empty;
            dpDoorToDoor.ClearSelection();



            rbcFreezerYes.Checked = false;

            rbcFreezerNo.Checked = false;




            rbFreezerRestrunYes.Checked = false;

            rbFreezerRestrunNo.Checked = false;

            txtDeactivedate.Text = string.Empty;
            txtDeactiveRession.Text = string.Empty;
            txtAmountRetrun.Text = string.Empty;
            txtTraysReturned.Text = string.Empty;
            txtSchemeAmount.Text = string.Empty;
            txtSchemeTotalAmount.Text = string.Empty;

        }


    }
}