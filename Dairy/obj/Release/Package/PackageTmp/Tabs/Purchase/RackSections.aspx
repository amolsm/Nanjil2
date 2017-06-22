<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RackSections.aspx.cs" Inherits="Dairy.Tabs.Purchase.RackSections" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
     <style type="text/css">
        .listboxl {
            height:100px !important;
        }
       .frmgrp {
       margin-bottom:1px;
       }
    </style>
    <script type="text/javascript" src="../../Theme/bootstrap/js/bootstrap.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section class="content-header">
          <h1>
             Rack Sections
            <small>Administration</small>
          </h1>
          <ol class="breadcrumb"><script src="../../Theme/bootstrap/js/bootstrap.min.js"></script>
            <li><a href="#"><i class="fa fa-dashboard"></i> Administration</a></li>
            <li class="active">Rack sections</li>
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
              <h3 class="box-title"> Racks </h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-minus"></i></button>
                
              </div>
            </div>
            <div class="box-body" >
                <div class="row">
             
                <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <asp:Button ID="btnAdd" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Add New" ValidationGroup="None" OnClick="btnAdd_Click" />     
                       
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
                          <th>Sr No</th>
                          <th>Rack Name</th>
                          <th>No of Sections</th>
                          <th>IsActive</th>
                          <th>Edit</th>
                          
                      </tr>
                    </thead>
                    <tbody>
               </HeaderTemplate>
               <ItemTemplate>
                    <tr>
                         <td><%# Eval("srno")%></td>
                        
                         <td><%# Eval("RackName")%></td>
                         <td><%# Eval("SecCount")%></td>
                         <td><%# Eval("IsActive")%></td>
                         <td>

                             <asp:LinkButton ID="lbEdite" AlternateText="Edit" ForeColor="Gray" OnItemCommand="lbEdite_ItemCommand" 
                                                                    ToolTip="Edit" runat="server" CommandArgument='<%#Eval("RackId") %>'
                                                                    CommandName="Edit"><i class="fa fa-edit"></i></asp:LinkButton>

                         </td>
                        
                    </tr>
               </ItemTemplate>
                    <FooterTemplate>

                         </tbody>

                    <tfoot>
                      <tr>
                           <th>Sr No</th>
                          <th>Rack Name</th>
                          <th>No of Sections</th>
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
        <h4 class="modal-title" id="myModalLabel">Rack Sections</h4>
      </div>
      <div class="modal-body">
          <div class="box-body">
            
                   <div class="col-lg-6">
                  <div class="form-group frmgrp" >
                    <div class="input-group">
                      <div class="input-group-addon">
                        <asp:Label runat="server" Text="Rack Name"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtRackName" class="form-control" ToolTip="Rack Name"   runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtRackName"
        ErrorMessage="Rack Name Required" ValidationGroup="Save" ForeColor="Red"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
    
                      </div>        <!-- -->
               

               <div class="col-lg-6">
                  <div class="form-group frmgrp" >
                    <div class="input-group">
                      <div class="input-group-addon">
                        <asp:Label ID="lblSec" runat="server" Text="Sections"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtSectionCount" class="form-control" ToolTip="Enter How many sections"  placeholder="How Many Sections" runat="server" type="number"></asp:TextBox>                        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSectionCount"
        ErrorMessage="Sections Required" ValidationGroup="Save" ForeColor="Red"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
    
                      </div>        <!-- --> 

           <div class="col-lg-6">
                  <div class="form-group frmgrp" >
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
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
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
       
          <asp:Button ID="btnSubmit" class="btn btn-primary" runat="server" ValidationGroup="Save" OnClick="btnSubmit_Click"  Text="Save" UseSubmitBehavior="false"  />       
           <asp:Button ID="btnUpdate" class="btn btn-primary" runat="server" ValidationGroup="saved"  Text="Udpate" UseSubmitBehavior="false"  data-dismiss="modal" OnClick="btnUpdate_Click"/>       
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
