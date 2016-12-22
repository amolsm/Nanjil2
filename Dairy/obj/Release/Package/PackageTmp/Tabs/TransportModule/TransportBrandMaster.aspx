<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TransportBrandMaster.aspx.cs" Inherits="Dairy.Tabs.TransportModule.TransportBrandMaster" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
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
    <script type="text/javascript">
        function Validate() {
            var val = document.getElementById('txtBrand').value;

            if (!val.match(/^[a-zA-Z]+$/)) {
                alert('Only alphabets are allowed');
                return false;
            }

            return true;
        }
         </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     
    <section class="content-header">
          <h1>
             Transport Brand Information
            <small>Administration</small>
          </h1>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Administration</a></li>
            <li class="active">Add Transport Brand Info</li>
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
              <div class="box collapsed-box">
            <div class="box-header with-border">
              <h3 class="box-title"><asp:Label runat="server" ID="lblHeaderTab" Text="Add Transport Brand"></asp:Label></h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-plus"></i></button>
                
              </div>
            </div>
            <div class="box-body">
               
              
                      <asp:UpdatePanel runat="server" ID="upMain" UpdateMode="Conditional">
                    <ContentTemplate>           
        
               <div class="box box-solid box-default" style="margin-bottom:5px !important;" >
        <div class="box-header" style="padding:0px 0px 0px 10px !important">
          <h3 class="box-title">Transport Brand Information </h3>
        </div><!-- /.box-header -->
        <div class="box-body">

               
             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtBrand" class="form-control" ToolTip="Enter Transport Brand Name"  placeholder="Transport Brand Name" runat="server"  ></asp:TextBox>                        
                    </div><!-- /.input group -->
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please enter brand name" ControlToValidate="txtBrand" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                      
                  </div><!-- /.form group -->

                     <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtBrand"
    ValidationExpression="[a-zA-Z ]*$" ErrorMessage="*Valid characters: Alphabets and space."  ForeColor="Red" />
                       
                          
                      </div> 
                 <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:DropDownList ID="dpIsActive" class="form-control" runat="server" selected ToolTip="Select Type Status">
                           <asp:ListItem Value="0">---Type Status---</asp:ListItem>
                           <asp:ListItem Value="1">Active</asp:ListItem>
                           <asp:ListItem Value="2">De-Active</asp:ListItem> 
                       </asp:DropDownList>
                        
                    </div><!-- /.input group -->
                       <asp:RequiredFieldValidator InitialValue="0" ID="Req_ID" Display="Dynamic" 
    ValidationGroup="Save" runat="server" ControlToValidate="dpIsActive" ForeColor="Red"
    ErrorMessage="Please Select Type Status"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 

             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      
                    
                      
                              <asp:Button ID="btnAddBrand" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Add" ValidationGroup="Save" OnClick="btnClick_btnAddBrandID" /> 
                       
                        <asp:Button ID="btnupdateBrand" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Update" ValidationGroup="Save" OnClick="btnClick_btnUpdateBrandID" /> 
                         &nbsp;&nbsp; &nbsp;   <asp:Button ID="btnAddNew" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="AddNew"  OnClick="btnClick_btnAddNew" />                   
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 


              
        </div><!-- /.box-body -->
      </div>
                     
                    </ContentTemplate>
                </asp:UpdatePanel>
                 
                
            </div><!-- /.box-body -->      
                      <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="upMain">
            <ProgressTemplate>
                
                <div class="overlay">
                  <i class="fa fa-refresh fa-spin"></i>
                </div>

            </ProgressTemplate>
            </asp:UpdateProgress>      
          </div><!-- /.box -->
               <div class="box ">
            <div class="box-header with-border">
              <h3 class="box-title"> Transport Brand List </h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-minus"></i></button>
                
              </div>
            </div>
            <div class="box-body" id="datalist">
                   
                
                       

                                <asp:UpdatePanel runat="server" ID="uprouteList" UpdateMode="Conditional">
                    <ContentTemplate>

                <table id="example1" class="table table-bordered table-striped">
                   

                 

                <asp:Repeater ID="rpBrandInfo" runat="server" OnItemCommand="rpRouteList_ItemCommand">
                
               <HeaderTemplate>
                  <thead>
                      <tr>
                          <th>Brand Id</th>
                         
                          <th>Brand Name</th>
                             <th>IsActive</th>
                        <th>Created By</th>
                        <th>Created Date</th>
                           <th>Edit</th>
                         <%-- <th>Deactivate</th>--%>
                      </tr>
                    </thead>
                    <tbody>
               </HeaderTemplate>
               <ItemTemplate>
                    <tr>
                         <td><%# Eval("tr_brand_Id")%></td>
                        
                         <td><%# Eval("tr_brand_name")%></td>
                         <td><%# Eval("IsActive")%></td>
                       <td><%# Eval("Name")%></td>
                      <td><%# Eval("CreatedDate")%></td>
                         <td>

                             <asp:LinkButton ID="lbEdite" AlternateText="Edit" ForeColor="Gray" OnItemCommand="lbEdite_ItemCommand" 
                                                                    ToolTip="Edit" runat="server" CommandArgument='<%#Eval("tr_brand_Id") %>'
                                                                    CommandName="Edit"><i class="fa fa-edit"></i></asp:LinkButton>

                         </td>
                        <%-- <td>   <asp:LinkButton ID="lbdelete" AlternateText="delete" ForeColor="Gray" OnItemCommand="lbdelete_ItemCommand" 
                                                                    ToolTip="Delete" runat="server" CommandArgument='<%#Eval("tr_brand_Id") %>'
                                                                    CommandName="delete"><i class="fa fa-trash"></i></asp:LinkButton>
</td>--%>
                    </tr>
               </ItemTemplate>
                    <FooterTemplate>

                         </tbody>

                    <tfoot>
                      <tr>
                          <th>Brand Id</th>
                         
                          <th>Brand Name</th>
                             <th>IsActive</th>
                        <th>Created By</th>
                        <th>Created Date</th>
                           <th>Edit</th>
                        <%--  <th>Deactivate</th>--%>
                      </tr>
                    </FooterTemplate>                                       
           </asp:Repeater>
                    <asp:HiddenField id="hfBrandId" runat="server" />                 
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
</asp:Content>
