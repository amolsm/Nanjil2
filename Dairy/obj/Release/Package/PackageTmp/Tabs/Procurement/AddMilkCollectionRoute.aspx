<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddMilkCollectionRoute.aspx.cs" Inherits="Dairy.Tabs.Procurement.AddMilkCollectionRoute" %>
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
             Milk Collection Route
            <small>Procurement</small>
          </h1>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Procurement</a></li>
            <li class="active"> <asp:Label runat="server" ID="lblHeaderTab" Text="Add Milk Collection Route"></asp:Label> </li>
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
              <h3 class="box-title"><asp:Label ID="lblTabName" runat="server" Text="Add Milk Collection Route"></asp:Label> </h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-plus"></i></button>
                
              </div>
            </div>
            <div class="box-body">
               
              
                      <asp:UpdatePanel runat="server" ID="upMain" UpdateMode="Conditional">
                    <ContentTemplate>           

        <div class="box box-solid box-default" style="margin-bottom:5px !important;" >
        <div class="box-header" style="padding:0px 0px 0px 10px !important">
          <h3 class="box-title">Milk Collection Route Information </h3>
        </div><!-- /.box-header -->
        <div class="box-body">
            <div class="row">
            <div class="col-lg-3">
                  <div class="form-group" >
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtRouteCode" class="form-control" placeholder="Route Code" runat="server"  ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group --> 
                          
                      </div> 
             <div class="col-lg-3">
                  <div class="form-group" style="margin-bottom:1px">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtRouteName" class="form-control" placeholder="Route Name" runat="server"  ToolTip="Route Name"></asp:TextBox>                        
                    </div><!-- /.input group -->
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Please Enter RouteName" ControlToValidate="txtRouteName" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 
            <div class="col-lg-3">
                  <div class="form-group" style="margin-bottom:1px">
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
                  <div class="form-group" style="margin-bottom:1px">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa  fa-code "></i></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtRouteDescription" class="form-control" placeholder="Route Distance" runat="server" type="number" step="any"  ToolTip="Route Distance"></asp:TextBox>                        
                    </div><!-- /.input group -->
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Please Enter Route Distance" ControlToValidate="txtRouteDescription" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->                   
                  </div>  
                </div>
               <div class="row">
            <div class="col-lg-3">
                  <div class="form-group" style="margin-bottom:1px">
                    <div class="input-group">
                      <div class="input-group-addon">
                      <span style="color:red">&nbsp;*</span>
                      </div>        
                     <asp:DropDownList ID="dpASOID" class="form-control"  DataValueField="EmployeeID" ToolTip="Select ASO Id" runat="server" selected> 
                       </asp:DropDownList>

                  </div><!-- /.form group -->
                      <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator1" Display="Dynamic" 
                            ValidationGroup="Save" runat="server" ControlToValidate="dpASOID"
                            Text="Please Select ASOID" ErrorMessage="Please Select ASOID" ForeColor="Red"></asp:RequiredFieldValidator>
                     
                       
                          
                      </div> 
                            
                            </div>
             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa  fa-code "></i></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtDesc" class="form-control" placeholder="Route Description" runat="server"  ToolTip="Route Description"></asp:TextBox>                        
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->                   
                  </div>  
                     <div class="col-lg-3">
                  <div class="form-group" style="margin-bottom:1px">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:DropDownList ID="Category" class="form-control" runat="server" selected>

                           <asp:ListItem Value="0">---Select Tariff/Rate Category---</asp:ListItem>
                           <asp:ListItem Value="1">A</asp:ListItem>
                           <asp:ListItem Value="2">B</asp:ListItem>
                           <asp:ListItem Value="3">C</asp:ListItem>
                          <asp:ListItem Value="4">D</asp:ListItem>
                          <asp:ListItem Value="5">E</asp:ListItem>
                          <asp:ListItem Value="6">F</asp:ListItem>
                          <asp:ListItem Value="7">G</asp:ListItem>
                          <asp:ListItem Value="8">1</asp:ListItem>
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator2" Display="Dynamic" 
                            ValidationGroup="Save" runat="server" ControlToValidate="Category"
                            Text="Please Select Category" ErrorMessage="Please Select Category" ForeColor="Red"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->

                     
                       
                          
                      </div>  

               <div class="col-lg-3">
                  <div class="form-group" style="margin-bottom:1px">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <span style="color:red">&nbsp;*</span>
                      </div>
                        <asp:DropDownList ID="dpIncentiveTariff" class="form-control" DataTextField="Name" DataValueField="ID" runat="server" selected ToolTip="Select Incentive Tariff"> 
                       </asp:DropDownList>  
                         
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator4" Display="Dynamic" 
                            ValidationGroup="Save" runat="server" ControlToValidate="dpIncentiveTariff"
                            Text="Please Select Incentive Tariff" ErrorMessage="Please Select Tariff" ForeColor="Red"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->

                     
                       
                          
                      </div>  
                   </div>
               <div class="row">
          
          

             <div class="col-lg-3">
                  <div class="form-group" style="margin-bottom:1px">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:DropDownList ID="DropDownList1" class="form-control" runat="server" selected>

                           <asp:ListItem Value="0">---Select Status---</asp:ListItem>
                           <asp:ListItem Value="1">Active</asp:ListItem>
                           <asp:ListItem Value="2">Deactive</asp:ListItem>
                       
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator3" Display="Dynamic" 
                            ValidationGroup="Save" runat="server" ControlToValidate="DropDownList1"
                            Text="Please Select Status" ErrorMessage="Please Select Status" ForeColor="Red"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->

                     
                       
                          
                      </div>  
                     <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      
                    
                      
                              <asp:Button ID="btnAddRout" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Add" ValidationGroup="Save" OnClick="btnAddRout_Click" />     
                        <asp:Button ID="btnupdateroute" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Update" ValidationGroup="Save" OnClick="btnupdateroute_Click" />           
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
              <h3 class="box-title"> Route List </h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-minus"></i></button>
                
              </div>
            </div>
            <div class="box-body" id="datalist">
                   
                
                       

                                <asp:UpdatePanel runat="server" ID="uprouteList" UpdateMode="Conditional">
                    <ContentTemplate>

                <table id="example1" class="table table-bordered table-striped">
                   

                 

                <asp:Repeater ID="rpRouteList" runat="server" OnItemCommand="rpRouteList_ItemCommand">
                
               <HeaderTemplate>
                  <thead>
                      <tr>
                          <th>Route Code</th>
                        <th>Route Name</th>
                        <th>Collection Center</th>
                        <th>ASOID</th>
                        <th>Category</th>
                          <th>IsActive</th>
                        <th>Created Date</th>
                           <th>Edit</th>
                         <%--  <th>Delete</th>--%>
                        
                      </tr>
                    </thead>
                    <tbody>

                   
               </HeaderTemplate>
               <ItemTemplate>
                    <tr>
                         <td><%# Eval("Routecode")%></td>
                      <td><%# Eval("RouteName")%></td>
                      <td><%# Eval("CenterCode")%>&nbsp;&nbsp;<%# Eval("CenterName")%></td>
                      <td><%# Eval("ASOID")%></td>
                        <td><%# Eval("Category") %></td>
                     <td><%# Eval("IsActive") %></td>
                      <td><%# Eval("CreatedDate")%></td>
                         <td>

                             <asp:LinkButton ID="lbEdite" AlternateText="Edit" ForeColor="Gray" OnItemCommand="lbEdite_ItemCommand" 
                                                                    ToolTip="Edit" runat="server" CommandArgument='<%#Eval("routeid") %>'
                                                                    CommandName="Edit"><i class="fa fa-edit"></i></asp:LinkButton>

                         </td>
                        <%-- <td>   <asp:LinkButton ID="lbdelete" AlternateText="delete" ForeColor="Gray" OnItemCommand="lbdelete_ItemCommand" 
                                                                    ToolTip="Delete" runat="server" CommandArgument='<%#Eval("routeid") %>'
                                                                    CommandName="delete"><i class="fa fa-trash"></i></asp:LinkButton>
</td>--%>
                    </tr>
               </ItemTemplate>
                    <FooterTemplate>

                         </tbody>

                    <tfoot>
                      <tr>
                           <th>Route Code</th>
                        <th>Route Name</th>
                        <th>Collection Center</th>
                          <th>ASOID</th>
                        <th>Category</th>
                          <th>IsActive</th>
                        <th>Created Date</th>
                           <th>Edit</th>
                         <%-- <th>Delete</th>--%>
                      </tr>
                    </tfoot>

                    </FooterTemplate>
                                             
           </asp:Repeater>
                    <asp:HiddenField id="hfrouteID" runat="server" />
             
                
                  
                     
                   
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
