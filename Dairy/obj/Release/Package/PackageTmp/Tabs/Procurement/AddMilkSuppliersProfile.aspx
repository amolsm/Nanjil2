<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddMilkSuppliersProfile.aspx.cs" Inherits="Dairy.Tabs.Procurement.AddMilkSuppliersProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
     
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 
     <script type="text/javascript">
         Sys.WebForms.PageRequestManager.getInstance().add_endRequest(InIEvent);
         function InIEvent() {

             $(function () {
                 $("#example1").DataTable();
                 $('#example2').DataTable({
                     "paging": true,
                     "lengthChange": false,
                     "searching": false,
                     "ordering": true,
                     "info": true,
                     "autoWidth": false
                 });
             });
         }
    </script>
    <section class="content-header">
          <h1>
            Milk Supplier Profile
            <small>Procurement</small>
          </h1>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Procurement</a></li>
            <li class="active"> <asp:Label runat="server" ID="lblHeaderTab" Text="Add Milk Supplier Profile"></asp:Label> </li>
          </ol>
        </section>
    <section class="content">
                <div class="row">
                <asp:UpdatePanel runat="server" ID="pnlError" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="col-md-12">
                            <div class="alert alert-danger alert-dismissable" runat="server" id="divDanger" visible="false">


                                <h4>
                                    <i class="icon fa fa-ban"></i>Alert!</h4>
                                <asp:Label runat="server" ID="lbldanger" Text="Something went worng please try Again"></asp:Label>
                            </div>
                            <div class="alert alert-warning alert-dismissable" runat="server" id="divwarning"
                                visible="false">
                                <h4>
                                    <i class="icon fa fa-warning"></i>Warning!</h4>
                                <asp:Label runat="server" ID="lblwarning" Text="Something Went wrong Please Try Again"></asp:Label>
                            </div>
                            <div class="alert alert-success alert-dismissable" runat="server" id="divSusccess"
                                visible="false">
                                <h4>
                                    <i class="icon fa fa-check"></i>Success!</h4>
                                <asp:Label runat="server" ID="lblSuccess" Text="Records Insert Succesfully"></asp:Label>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
          <!-- Default box -->
              <div class="box <%--collapsed-box--%>">
            <div class="box-header with-border">
              <h3 class="box-title"><asp:Label ID="lblTabName" runat="server" Text="Add Milk Supplier"></asp:Label> </h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-plus"></i></button>
                
              </div>
            </div>
            <div class="box-body">
               
              
                      <asp:UpdatePanel runat="server" ID="upMain" UpdateMode="Conditional">
                    <ContentTemplate>           
        
               <div class="box box-solid box-default" style="margin-bottom:5px !important;" >
        <div class="box-header" style="padding:0px 0px 0px 10px !important">
          <h3 class="box-title">Supplier Information </h3>
        </div><!-- /.box-header -->
        <div class="box-body">
            <div class="row">
             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtSupplierCode" class="form-control" placeholder="SupplierCode" runat="server" ToolTip="Supplier Code" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                       <asp:RequiredFieldValidator  ID="RequiredFieldValidator7" Display="Dynamic" 
    ValidationGroup="Save" runat="server" ControlToValidate="txtSupplierCode" ForeColor="Red"
    ErrorMessage="Please Enter SupplierCode "></asp:RequiredFieldValidator>
                  </div><!-- /.form group --> 
                          
                      </div>
            
              <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:DropDownList ID="dpCenter" class="form-control" DataTextField="Name" DataValueField="CenterID" runat="server" selected ToolTip="Select Center" OnSelectedIndexChanged="dpCenter_SelectedIndexChanged" AutoPostBack="true"> 
                       </asp:DropDownList>  
                 
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator InitialValue="0" ID="Req_ID" Display="Dynamic" 
                            ValidationGroup="Save" runat="server" ControlToValidate="dpCenter"
                            Text="Please Select Center" ErrorMessage="Please Select Center" ForeColor="Red"></asp:RequiredFieldValidator>

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 
             
             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <i class="fa fa-rode"></i><span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:DropDownList ID="dpRoute" class="form-control" DataTextField="Name" DataValueField="RouteID" runat="server" selected ToolTip="Select Route"> 
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator1" Display="Dynamic" 
                            ValidationGroup="Save" runat="server" ControlToValidate="dpRoute"
                            Text="Please Select Route" ErrorMessage="Please Select Route" ForeColor="Red"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->

                     
                       
                          
                      </div>
             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtSupplierName" class="form-control" placeholder="Supplier Name" runat="server"  ToolTip="Supplier Name"></asp:TextBox>                        
                    </div><!-- /.input group -->
                       <asp:RequiredFieldValidator  ID="RequiredFieldValidator8" Display="Dynamic" 
    ValidationGroup="Save" runat="server" ControlToValidate="txtSupplierName" ForeColor="Red"
    ErrorMessage="Please Enter SupplierName "></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->                   
                  </div>  
            </div>
                <div class="row">
            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtSupplierAliasName" class="form-control" placeholder="Supplier Alias Name" runat="server"  ToolTip="Supplier Alias Name"></asp:TextBox>                        
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->                   
                  </div>  
             
             <div class="col-lg-3">
                  <div class="form-group" style="margin-bottom:1px">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa  fa-code "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtJoiningDate" class="form-control" placeholder="Joining Date"  type="date" runat="server" ToolTip="Joining Date" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                       <asp:RequiredFieldValidator  ID="RequiredFieldValidator9" Display="Dynamic" 
    ValidationGroup="Save" runat="server" ControlToValidate="txtJoiningDate" ForeColor="Red"
    ErrorMessage="Please Enter JoiningDate "></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->

                     
                       
                          
                      </div>  
             <div class="col-lg-3">
                  <div class="form-group" style="margin-bottom:1px">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:DropDownList ID="DropDownList1" class="form-control" runat="server" ToolTip="Select Status">

                           <asp:ListItem Value="0">---Select Status---</asp:ListItem>
                           <asp:ListItem Value="1">Active</asp:ListItem>
                           <asp:ListItem Value="2">Deactive</asp:ListItem>
                       
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator2" Display="Dynamic" 
                            ValidationGroup="Save" runat="server" ControlToValidate="DropDownList1"
                            Text="Please Select Status" ErrorMessage="Please Select Status" ForeColor="Red"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->

                     
                       
                          
                      </div>     
          </div>
              
        </div><!-- /.box-body -->
      </div>

                              <div class="box box-solid box-default" style="margin-bottom:5px !important;" >
        <div class="box-header" style="padding:0px 0px 0px 10px !important">
          <h3 class="box-title">Contact Information </h3>
        </div><!-- /.box-header -->
        <div class="box-body">
            <div class="row">
            <div class="col-lg-4">
                  <div class="form-group" style="margin-bottom:1px">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-map-marker"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtAddress1" class="form-control" placeholder="Address 1" runat="server" ToolTip="Address 1" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                       <asp:RequiredFieldValidator  ID="RequiredFieldValidator10" Display="Dynamic" 
    ValidationGroup="Save" runat="server" ControlToValidate="txtAddress1" ForeColor="Red"
    ErrorMessage="Please Enter Address "></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
                

                     
                       
                          
                      </div>                        
                 <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-map-marker"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtAddress2" class="form-control" placeholder="Address 2" runat="server" ToolTip="Address 2"></asp:TextBox>                        
                    </div><!-- /.input group -->
                      
                  </div><!-- /.form group -->

                     
                       
                          
                      </div>  
  <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-map-marker"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtAddress3" class="form-control" placeholder="Address 3" runat="server" ToolTip="Address 3"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 
            </div>
 
           <div class="row">
              <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-envelope-o"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtEmail" class="form-control" placeholder="Email" runat="server"  AutoCompleteType="Email" ToolTip="Email"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group --> 
                   </div> 
                        <div class="col-lg-4">
                  <div class="form-group" style="margin-bottom:1px">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-mobile"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtMobile" class="form-control" placeholder="Mobile No" runat="server"  Type="number" ToolTip="MobileNo."></asp:TextBox>                        
                    </div><!-- /.input group -->
                       <asp:RequiredFieldValidator  ID="RequiredFieldValidator11" Display="Dynamic" 
    ValidationGroup="Save" runat="server" ControlToValidate="txtMobile" ForeColor="Red"
    ErrorMessage="Please Enter Mobile No. "></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->

                     
                       
                          
                      </div>                        
                 <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-phone"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtTelephone" class="form-control" placeholder="Telephone No" runat="server"  Type="number" ToolTip="Telephone No."></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div>  
               </div>
            <div class="row">
                        <div class="col-lg-3">
                  <div class="form-group"style="margin-bottom:1px">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-globe"></i><span style="color:red">&nbsp;*</span>
                      </div>                      
                       <asp:DropDownList  ID="dpCity" ToolTip="Select City" class="form-control" DataTextField="Name"  runat="server"  > 
                       </asp:DropDownList></div><!-- /.input group -->
                        <%--<asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator3" Display="Dynamic" 
                            ValidationGroup="Save" runat="server" ControlToValidate="dpCity"
                            Text="Please Select City" ErrorMessage="Please Select City" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 
                               <div class="col-lg-3">
                  <div class="form-group" style="margin-bottom:1px">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-globe"></i><span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:DropDownList  ID="dpDistrict" ToolTip="Select District" class="form-control" DataTextField="Name"  runat="server"  > 
                       </asp:DropDownList></div><!-- /.input group -->
                        <%--<asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator4" Display="Dynamic" 
                            ValidationGroup="Save" runat="server" ControlToValidate="dpDistrict"
                            Text="Please Select District" ErrorMessage="Please Select District" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 
                      
                      
                  <div class="col-lg-3">
                  <div class="form-group" style="margin-bottom:1px">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <span style="color:red">&nbsp;*</span>
                      </div>
               <asp:DropDownList  ID="dpState" ToolTip="Select State" class="form-control" DataTextField="Name"  runat="server"  > 
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                       <%-- <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator5" Display="Dynamic" 
                            ValidationGroup="Save" runat="server" ControlToValidate="dpState"
                            Text="Please Select State" ErrorMessage="Please Select State" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                  </div><!-- /.form group -->

                     
                       
                          
                      </div>  
            
                <div class="col-lg-3">
                  <div class="form-group" style="margin-bottom:1px">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <span style="color:red">&nbsp;*</span>
                      </div>
                          <asp:DropDownList  ID="dpCountry" ToolTip="Select Country" class="form-control" DataTextField="Name"  runat="server"  > 
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                        <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator6" Display="Dynamic" 
                            ValidationGroup="Save" runat="server" ControlToValidate="dpCountry"
                            Text="Please Select Country" ErrorMessage="Please Select Country" ForeColor="Red"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 
                </div> 
             <%--<div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-bars"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtBankDetailID" class="form-control" placeholder="BankDetail ID" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> --%>
            <%--<div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtIncentive" class="form-control" placeholder="Incentive Till Date" runat="server"  ToolTip="Incentive Till Date"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group --> 
                          
                      </div> 
            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtDeposit" class="form-control" placeholder="Recurring Deposit" runat="server"  ToolTip="Recurring Deposit"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group --> 
                          
                      </div> 
            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtBonus" class="form-control" placeholder="Bonus" runat="server"  ToolTip="Bonus"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group --> 
                          
                      </div> 
            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtAdvanceGiven" class="form-control" placeholder="Advance Given" runat="server"  ToolTip="Advance Given"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group --> 
                          
                      </div> 
             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtScheme" class="form-control" placeholder="Scheme Till Date" runat="server"  ToolTip="Scheme Till Date"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group --> 
                          
                      </div> --%>
            
        </div><!-- /.box-body -->
      </div>
                         <div class="box box-solid box-default" style="margin-bottom:5px !important;" >
        <div class="box-header" style="padding:0px 0px 0px 10px !important">
          <h3 class="box-title">Bank Details </h3>
        </div><!-- /.box-header -->
        <div class="box-body">
            <%--  <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-bank"></i><span style="color:red">&nbsp;*</span>
                      </div>
                    <asp:DropDownList  ID="dpBankName" ToolTip="Select Bank Name" class="form-control" DataTextField="Name"  runat="server"  > 
                       </asp:DropDownList> </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> --%>   
            <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-bars"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtAccountName" class="form-control" placeholder="Account Name" ToolTip="Account Name" runat="server"  type="text"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 

              <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-bars"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtAccountNo" class="form-control" placeholder="Account No" ToolTip="Account No" runat="server"  type="text"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 

           <%--  <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:DropDownList ID="DropDownList2" class="form-control" runat="server" ToolTip="Account Type">

                           <asp:ListItem >---Select Account Type---</asp:ListItem>
                           <asp:ListItem>Current</asp:ListItem>
                           <asp:ListItem>Saving</asp:ListItem>
                       
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->

                     
                       
                          
                      </div> --%>        
             <div class="col-lg-4">

             

                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-bars"></i><span style="color:red">&nbsp;*</span>
                      </div>
                     <asp:DropDownList  ID="dpIfscCode" ToolTip="Select IFSC Code" DataValueField="ID" class="form-control" DataTextField="Name"  runat="server"  > 
                       </asp:DropDownList></div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                      </div>
            <%-- <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-map-marker"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtAddress" class="form-control" placeholder="Bank Address" ToolTip="Bank Address" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
                

                     
                       
                          
                      </div>        --%>        
           <%--  <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtBranchName" class="form-control" placeholder="Branch Name" runat="server"  ToolTip="Branch Name"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> --%>
             <div class="col-lg-4 pull-right">
                  <div class="form-group">
                    <div class="input-group">
                      
                    
                      
                              <asp:Button ID="btnSupplieradd" class="btn btn-primary" runat="server" CommandName="MoveNext" OnClick="btnClick_btnSupplieradd"    Text="Add" ValidationGroup="Save" />     &nbsp;&nbsp;
                        <asp:Button ID="btnSupplierUpdate" class="btn btn-primary" runat="server" CommandName="MoveNext" OnClick="btnClick_btnSupplierUpdate"   Text="Update" ValidationGroup="Save" />           
                          &nbsp;&nbsp; &nbsp;   <asp:Button ID="btnAddNew" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="AddNew"  OnClick="btnClick_btnAddNew" />                   

                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 
               
        </div><!-- /.box-body -->
      </div>
               
                     
                    </ContentTemplate>
                </asp:UpdatePanel>
                 
                
            </div><!-- /.box-body -->            
          </div><!-- /.box -->
              
         <div class="box ">
            <div class="box-header with-border">
              <h3 class="box-title"> Supplier List </h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-minus"></i></button>
                
              </div>
            </div>
            <div class="box-body" id="datalist">
                   
                
                       

                                <asp:UpdatePanel runat="server" ID="uprouteList" UpdateMode="Conditional">
                    <ContentTemplate>

                <table id="example1" class="table table-bordered table-striped">
                   

                 

                <asp:Repeater ID="rpSupplierProfList" runat="server" OnItemCommand="rpSupplierProfList_ItemCommand">
                
               <HeaderTemplate>
                  <thead>
                      <tr>
                          <th>Supplier Code</th>
                        <th>Supplier Name</th>
                        <th>Joining Date </th>
                         <th>Collection Center</th> 
                        <th>Route</th> 
                        <th>MobileNo</th>
                          <th>IsActive</th>
                           <th>Edit</th>
                         <%-- <th>Delete</th>--%>
                      </tr>
                    </thead>
                    <tbody>

                   
               </HeaderTemplate>
               <ItemTemplate>
                    <tr>
                         <td><%# Eval("SupplierCode")%></td>
                      <td><%# Eval("SupplierName")%></td>
                      <td><%# Eval("JoiningDate")%></td>
                         <td><%# Eval("CenterCode")%>&nbsp;&nbsp;<%# Eval("CenterName")%></td>
                      <td><%# Eval("RouteCode")%>&nbsp;&nbsp;<%# Eval("RouteName")%></td>
                     
                      <td><%# Eval("Mobile")%></td>
                       <td><%# Eval("IsActive")%></td>
                         <td>

                             <asp:LinkButton ID="lbEdite" AlternateText="Edit" ForeColor="Gray" OnItemCommand="lbEdite_ItemCommand" 
                                                                    ToolTip="Edit" runat="server" CommandArgument='<%#Eval("SupplierID") %>'
                                                                    CommandName="Edit"><i class="fa fa-edit"></i></asp:LinkButton>

                         </td>
                       <%--  <td>   <asp:LinkButton ID="lbdelete" AlternateText="delete" ForeColor="Gray" OnItemCommand="lbdelete_ItemCommand" 
                                                                    ToolTip="Delete" runat="server" CommandArgument='<%#Eval("SupplierID") %>'
                                                                    CommandName="delete"><i class="fa fa-trash"></i></asp:LinkButton>
</td>--%>
                    </tr>
               </ItemTemplate>
                    <FooterTemplate>

                         </tbody>

                    <tfoot>
                      <tr>
                           <th>Supplier Code</th>
                        <th>Supplier Name</th>
                          <th>Joining Date</th>
                       <th>Collection Center</th> 
                        <th>Route</th> 
                        <th>Mobile No</th>
                       <th>IsActive</th>
                       
                           <th>Edit</th>
                      <%--    <th>Delete</th>--%>
                      </tr>
                    </tfoot>

                    </FooterTemplate>
                                             
           </asp:Repeater>
                    <asp:HiddenField id="hfprofileID" runat="server" />
             <asp:HiddenField id="HiddenField1" runat="server" />
                
                  
                     
                   
                  </table>
               
                
                        </ContentTemplate>
                </asp:UpdatePanel>
  


            </div><!-- /.box-body --> 
                       <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="uprouteList">
            <ProgressTemplate>
                
                <div class="overlay">
                  <i class="fa fa-refresh fa-spin"></i>
                </div>

            </ProgressTemplate>
            </asp:UpdateProgress>           
          </div><!-- /.box -->
        </section>
    <script type="text/javascript">
    
          $(document).ready(function () {
              $('#example1').dataTable({
                  "bPaginate": false,
                  "paging": false

              });
          });
        </script>
</asp:Content>
