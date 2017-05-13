<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateUser.aspx.cs" Inherits="Dairy.Authentication.CreateUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .listboxl {
            height:100px !important;
        }
       .frmgrp {
       margin-bottom:1px;
       }
       .frmgrp2 {
       margin-bottom:15px;
       }
    </style>
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
             User Information
            <small>Administration</small> <span style="font-size:medium"> [ Active User = <asp:Label ID="lblActiveCount" runat="server"></asp:Label>]&nbsp; &nbsp;[ Deactive User = <asp:Label ID="lblDeactive" runat="server"></asp:Label>]</span>
          </h1>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Administration</a></li>
            <li class="active">Create User</li>
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
              <div class="box collapsed-box" id ="myBox">
            <div class="box-header with-border">
              <h3 class="box-title"><asp:Label runat="server" ID="lblHeaderTab" Text="Create User"></asp:Label></h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-plus"></i></button>
                
              </div>
            </div>
            <div class="box-body">
               
              
                      <asp:UpdatePanel runat="server" ID="upMain" UpdateMode="Conditional">
                    <ContentTemplate>           
        
               <div class="box box-solid box-default" style="margin-bottom:5px !important;" >
        <div class="box-header" style="padding:0px 0px 0px 10px !important">
          <h3 class="box-title"> User Information </h3>
        </div><!-- /.box-header -->
        <div class="box-body">

            <div class="row">
            <div class="col-lg-4">
                  <div class="form-group frmgrp">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-user"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtName" class="form-control" placeholder="Name" runat="server"  ToolTip="Enter Name"></asp:TextBox>                        
                    </div><!-- /.input group -->
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtName"
        ErrorMessage="Name is   Required" ValidationGroup="Save" ForeColor="Red"></asp:RequiredFieldValidator> 
              
                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 
                 

             <div class="col-lg-4">
                  <div class="form-group frmgrp">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-envelope-o"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtEmail" class="form-control" placeholder="Email" type="Email" runat="server"   ToolTip="Enter Email"></asp:TextBox>                        
                    </div><!-- /.input group -->
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmail"
        ErrorMessage="Email  Required" ValidationGroup="Save" ForeColor="Red"></asp:RequiredFieldValidator> 
              
                  </div><!-- /.form group -->

                     
                       
                          
                      </div>
            
         
            <div class="col-lg-4">
                  <div class="form-group frmgrp">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <i class="fa fa-rode"></i><span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:DropDownList ID="dpEmployee" AutoPostBack="true"  class="form-control" DataTextField="Name" DataValueField="employeeID" runat="server"  > 
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="dpEmployee"
        ErrorMessage="Employee name is Required" Operator="NotEqual" ValidationGroup="Save" ForeColor="Red"
        ValueToCompare="0"></asp:CompareValidator>
                  </div><!-- /.form group -->
                         </div>
            </div>
              <div class="row">
              <div class="col-lg-4">
                  <div class="form-group frmgrp">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:DropDownList ID="dpIsActive" class="form-control" runat="server" selected ToolTip="Select User Status">
                           <asp:ListItem Value="0">---User Status---</asp:ListItem>
                           <asp:ListItem Value="1">Active</asp:ListItem>
                           <asp:ListItem Value="2">De-Active</asp:ListItem> 
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                        <asp:CompareValidator ID="CompareValidator" runat="server" ControlToValidate="dpIsActive"
        ErrorMessage="Status is Required" Operator="NotEqual" ValidationGroup="Save" ForeColor="Red"
        ValueToCompare="0"></asp:CompareValidator>
                  </div><!-- /.form group -->

                     
                       
                          
                      </div>  
        
               <div class="col-lg-4">
                  <div class="form-group frmgrp">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-key"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtPassword" class="form-control" placeholder="Password" type="password" runat="server"  ToolTip="Enter Password"></asp:TextBox>                        
                    </div><!-- /.input group -->
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword"
        ErrorMessage="Password  Required" ValidationGroup="Save" ForeColor="Red"></asp:RequiredFieldValidator> 
              
                  </div><!-- /.form group -->

                     
                       
                          
                      </div>  

              <div class="col-lg-4">
                  <div class="form-group frmgrp">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-key"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtConfromPasword" class="form-control" placeholder="Confirm Password" type="password" runat="server"  ToolTip="Enter Confirm Password"></asp:TextBox>                        
                    </div><!-- /.input group -->
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtConfromPasword"
        ErrorMessage="Conform Password  Required" ValidationGroup="Save" ForeColor="Red"></asp:RequiredFieldValidator> 
              
                  </div><!-- /.form group -->

                     
                       
                          
                      </div>  
                  </div>
            <div class="row">
             <div class="col-lg-4">
                  <div class="form-group frmgrp">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:DropDownList ID="dproles" class="form-control" runat="server" selected ToolTip="Select User Role">
                            <asp:ListItem Value="0">---Select User Role ---</asp:ListItem>
                            <asp:ListItem Value="1">Administration</asp:ListItem>
                            <asp:ListItem Value="2">Reception</asp:ListItem>
                            <asp:ListItem Value="3">Sales</asp:ListItem>
                            <asp:ListItem Value="4">Despatch</asp:ListItem> 
                            <asp:ListItem Value="5">Transport</asp:ListItem> 
                            <asp:ListItem Value="6">Purchase</asp:ListItem>
                            <asp:ListItem Value="7">Marketing</asp:ListItem>
                            <asp:ListItem Value="8">Cashier</asp:ListItem>
                            <asp:ListItem Value="9">Procurement</asp:ListItem>
                          
                       </asp:DropDownList> 
                    </div><!-- /.input group -->
                       <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="dpEmployee"
        ErrorMessage="Employee name is Required" Operator="NotEqual" ValidationGroup="Save" ForeColor="Red"
        ValueToCompare="0"></asp:CompareValidator>
                  </div><!-- /.form group -->

                     
                       
                          
                      </div>  

             <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:DropDownList ID="dpPrivilege" class="form-control" runat="server" selected ToolTip="Select User Privilege">
                           <asp:ListItem Value="0">---Set  Privilege ---</asp:ListItem>
                           <asp:ListItem Value="1">Read </asp:ListItem>
                           <asp:ListItem Value="2">Read/Write</asp:ListItem>
                         
                        
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 
             <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      
                    
                      
                        <asp:Button ID="btnAddRoute" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Add" ValidationGroup="Save" OnClick="btnaddUser_click" /> &nbsp;    
                        <asp:Button ID="btnupdateroute" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Update" ValidationGroup="Save" OnClick="btnUpdateUser_click" /> 
                            &nbsp;&nbsp;  <asp:Button ID="btnRefresh" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Refresh" ValidationGroup="none"  OnClick="btnRefresh_Click"  />                     
                        <asp:CompareValidator ID="vldPassword" runat="server" ErrorMessage="Confirm Password & Password does not match" ControlToValidate="txtConfromPasword" ControlToCompare="txtPassword" Operator="Equal" Type="String" ForeColor="#0066cc" ValidationGroup="Save"></asp:CompareValidator>
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 
                </div>

              
        </div><!-- /.box-body -->
      </div>
                     
                    </ContentTemplate>
                </asp:UpdatePanel>
                 
                
            </div><!-- /.box-body -->            
          </div><!-- /.box -->
               <div class="box ">
            <div class="box-header with-border">
              <h3 class="box-title"> User List </h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-minus"></i></button>
                
              </div>
            </div>
            <div class="box-body" id="datalist">
                   
               
                       

                           <asp:UpdatePanel runat="server" ID="uprouteList" UpdateMode="Conditional">
                    <ContentTemplate>

                <table id="example1" class="table table-bordered table-striped">
                   

                 

                <asp:Repeater ID="rpUserList" runat="server" OnItemCommand="rpUserList_ItemCommand">
                
               <HeaderTemplate>
                  <thead>
                      <tr>
                            <th>Name</th>
                            <th>User Name</th>
                            <th>Email</th>
                            <th>Is Active</th>
                          <th>Role</th>
                          
                           <th>Created By</th>
                            <th>Created Date</th>
                          <th>Edit</th>
                           
                      </tr>
                    </thead>
                    <tbody>

                   
               </HeaderTemplate>
               <ItemTemplate>
                    <tr>
                      <td><%# Eval("Name")%></td>
                      <td><%# Eval("UserName")%></td>
                        <td><%# Eval("Email")%></td>
                      <td><%# Eval("IsActive")%></td>
                      <td><%# Eval("RoleName")%></td>
                      
                        <td><%# Eval("CreaterName")%></td>
                        <td><%# Eval("CreatedDate")%></td>
                         <td>

                             <asp:LinkButton ID="lbEdite" AlternateText="Edit" ForeColor="Gray" OnItemCommand="lbEdite_ItemCommand" 
                                                                    ToolTip="Edit" runat="server" CommandArgument='<%#Eval("userid") %>'
                                                                    CommandName="Edit"><i class="fa fa-edit"></i></asp:LinkButton>

                         </td>
     
                    </tr>
               </ItemTemplate>
                    <FooterTemplate>

                         </tbody>

                    <tfoot>
                      <tr>
                                    <th>Name</th>
                                    <th>User Name</th>
                                    <th>Email</th>
                                    <th>Is Active</th>
                                    <th>Role</th>
                                     
                                    <th>Created By</th>
                                    <th>Created Date</th>  
                          <th>Edit</th>                         
                      </tr>
                    </tfoot>

                    </FooterTemplate>
                                             
           </asp:Repeater>
                    <asp:HiddenField id="hfUserid" runat="server" />
             
                
                  
                     
                   
                  </table>
               
                
                        </ContentTemplate>
                </asp:UpdatePanel>
  

            
            


 


            </div><!-- /.box-body -->            
          </div><!-- /.box -->
        </section>
</asp:Content>
