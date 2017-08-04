<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Items.aspx.cs" Inherits="Dairy.Tabs.Purchase.Items" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
      <script type="text/javascript" src="../../Theme/bootstrap/js/bootstrap.min.js"></script>
    
   <style type="text/css">
        .listboxl {
            height:100px !important;
        }
       .frmgrp {
       margin-bottom:1px;
       }
    </style>

    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript" src="../../Theme/bootstrap/js/bootstrap.min.js"></script>
    <section class="content-header">
          <h1>
              Items 
            <small>Administration</small>
          </h1>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Administration</a></li>
            <li class="active">Items</li>
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
              

               <div class="box ">
            <div class="box-header with-border">
              <h3 class="box-title"> Item List </h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-minus"></i></button>
                
              </div>
            </div>
            <div class="box-body" >
                <div class="row">
                <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <asp:Button ID="btnAdd" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Add New" ValidationGroup="none" OnClick="btnAdd_Click" />     
                       
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 

                    </div>
                 <div id="datalist"> 
                
                       

                                <asp:UpdatePanel runat="server" ID="uprouteList" UpdateMode="Conditional">
                    <ContentTemplate>

                <table id="example1" class="table table-bordered table-striped">
                   

                 

                <asp:Repeater ID="rpBrandInfo" runat="server" OnItemCommand="rpBrandInfo_ItemCommand">
                
               <HeaderTemplate>
                  <thead>
                      <tr>
                          <th>Category Name</th>
                          <th>Item Name</th>
                          <th>Description</th>
                          <th>IsActive</th>
                          <th>Edit</th>
                          
                      </tr>
                    </thead>
                    <tbody>
               </HeaderTemplate>
               <ItemTemplate>
                    <tr>
                         <td><%# Eval("ItemCategoryName")%></td>
                        <td><%# Eval("ItemName")%></td>
                         <td><%# Eval("ItemDescription")%></td>
                         <td><%# Eval("IsActive")%></td>
                       
                         <td>

                             <asp:LinkButton ID="lbEdite" AlternateText="Edit" ForeColor="Gray" OnItemCommand="lbEdite_ItemCommand" 
                                                                    ToolTip="Edit" runat="server" CommandArgument='<%#Eval("ItemId") %>'
                                                                    CommandName="Edit"><i class="fa fa-edit"></i></asp:LinkButton>

                         </td>
                        
                    </tr>
               </ItemTemplate>
                    <FooterTemplate>

                         </tbody>

                    <tfoot>
                      <tr>
                           <th>Category Name</th>
                          <th>Item Name</th>
                          <th>Description</th>
                          <th>IsActive</th>
                          <th>Edit</th>
                          
                      </tr>
                    </tfoot>
                    </FooterTemplate>                                       
           </asp:Repeater>
                    <asp:HiddenField id="hfBrandId" runat="server" />                 
                  </table>
                        </ContentTemplate>
                </asp:UpdatePanel>

            </div>

                   </div> <!-- /.box-body -->   
                       <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="uprouteList">
            <ProgressTemplate>
                
                <div class="overlay">
                  <i class="fa fa-refresh fa-spin"></i>
                </div>

            </ProgressTemplate>
            </asp:UpdateProgress>         
          </div><!-- /.box -->

        <asp:UpdatePanel ID="upModal" runat="server" UpdateMode="Conditional" >  
              <ContentTemplate>         
                      <!-- Modal -->
        <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" data-backdrop="false">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title" id="myModalLabel">Items</h4>
      </div>
      <div class="modal-body">
          <div class="box-body">
            
            <div class="row">
               <div class="col-lg-6">
                  <div class="form-group frmgrp" >
                    <div class="input-group">
                      <div class="input-group-addon">
                        <asp:Label runat="server" Text="Category"></asp:Label>
                      </div>
                        <asp:DropDownList ID="dpCategory" class="form-control" runat="server" selected DataValueField="ItemCategoryId" DataTextField="Name" >

                       </asp:DropDownList>
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator1" Display="Dynamic" 
    ValidationGroup="Save" runat="server" ControlToValidate="dpCategory" ForeColor="Red"
    ErrorMessage="Please Select Category "></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
    
                      </div>        <!-- --> 

                <div class="col-lg-6">
                  <div class="form-group frmgrp" >
                    <div class="input-group">
                      <div class="input-group-addon">
                        <asp:Label runat="server" Text="Item"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtItemName" class="form-control" ToolTip="Item Name"  placeholder="Item Name" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtItemName"
        ErrorMessage="Item Name Required" ValidationGroup="Save" ForeColor="Red"></asp:RequiredFieldValidator> 
                  </div><!-- /.form group -->
    
                      </div>        <!-- --> 
</div>
               <div class="row">
               <div class="col-lg-6">
                  <div class="form-group frmgrp" >
                    <div class="input-group">
                      <div class="input-group-addon">
                       <asp:Label runat="server" Text="Desc"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtDesciption" class="form-control" ToolTip="Description"  placeholder="Description" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtDesciption"
        ErrorMessage="Desciption Required" ValidationGroup="Save" ForeColor="Red"></asp:RequiredFieldValidator> 
                  </div><!-- /.form group -->
    
                      </div>        <!-- --> 

               <div class="col-lg-6">
                  <div class="form-group frmgrp" >
                    <div class="input-group">
                      <div class="input-group-addon">
                        <asp:Label runat="server" Text="Status"></asp:Label>
                      </div>
                        <asp:DropDownList ID="dpIsActive" class="form-control" runat="server" selected >

                           <asp:ListItem Value="0">---Select Status---</asp:ListItem>
                           <asp:ListItem Value="1">Active </asp:ListItem>
                           <asp:ListItem Value="2">Deactive</asp:ListItem>
                            
                       </asp:DropDownList>
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator InitialValue="0" ID="VldIsActive" Display="Dynamic" 
    ValidationGroup="Save" runat="server" ControlToValidate="dpIsActive" ForeColor="Red"
    ErrorMessage="Please Select Status "></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
    
                      </div>        <!-- --> 
                   </div>
 <div class="row">
                <div class="col-lg-6">
                  <div class="form-group frmgrp" >
                    <div class="input-group">
                      <div class="input-group-addon">
                        <asp:Label runat="server" Text="Rack"></asp:Label>
                      </div>
                        <asp:DropDownList ID="dpRack" class="form-control" runat="server"  DataValueField="RackId" DataTextField="Name" OnSelectedIndexChanged="dpRack_SelectedIndexChanged" AutoPostBack="true">

                       </asp:DropDownList>
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator4" Display="Dynamic" 
    ValidationGroup="Save" runat="server" ControlToValidate="dpRack" ForeColor="Red"
    ErrorMessage="Please Select Rack "></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
    
                      </div>        <!-- --> 
           

                  <div class="col-lg-6">
                  <div class="form-group frmgrp" >
                    <div class="input-group ">
                      <div class="input-group-addon">
                        <asp:Label runat="server" Text="Section"></asp:Label>
                      </div>
                        <asp:ListBox ID="lbSection" runat="server"  class="form-control listboxl"  SelectionMode="Multiple" DataValueField="RackSectionId" DataTextField="Name">
    
                        </asp:ListBox>
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
    
                      </div>        <!-- --> 
     </div>
                  <div class="col-lg-12">
                  <div class="form-group frmgrp" >
                    <div class="input-group ">
                      <asp:Label ID ="lblAssignedSecs" runat="server"></asp:Label>
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
    
                      </div>        <!-- --> 
            </div>
      </div>
      <div class="modal-footer">
        <%--<button type="button" class="btn btn-default" data-dismiss="modal">Close</button>--%>
       <asp:Button ID="btnCloseModal" class="btn btn-default" runat="server" ValidationGroup="none" OnClick="btnCloseModal_Click" Text="Close" UseSubmitBehavior="false"  data-dismiss="modal"/>       
          <asp:Button ID="btnSubmit" class="btn btn-primary" runat="server" ValidationGroup="Save" OnClick="btnSubmit_Click" Text="Save" UseSubmitBehavior="false"  />       
           <asp:Button ID="btnUpdate" class="btn btn-primary" runat="server" ValidationGroup="Save" OnClick="btnUpdate_Click" Text="Udpate" UseSubmitBehavior="false"  data-dismiss="modal"/>       
      </div>
    </div>
  </div>
</div>     

                  </ContentTemplate>
             </asp:UpdatePanel> 
        </section>
  

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
</asp:Content>