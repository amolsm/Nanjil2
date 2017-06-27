<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MilkCollectionTransport.aspx.cs" Inherits="Dairy.Tabs.Procurement.MilkCollectionTransport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
     <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css">
    <script src="//code.jquery.com/jquery-1.10.2.js"></script>
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%--<script type="text/javascript">

        $(function () {
            $("#MainContent_txtDate").datepicker({ format: 'dd-MM-yyyy' });

        })
    </script>--%>
     <script type="text/javascript" src="Scripts/jquery-1.4.1.min.js"></script>
     <script src="https://ajax.googleapis.com/ajax/libs/angularjs/1.4.8/angular.min.js" type="text/javascript"></script>
   <script type="text/javascript">
    var app = angular.module('myApp', []);
    app.controller('myCtrl', function($scope) {
        $scope.count = $scope.a + $scope.b;
    });
    </script>

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
           Vehical In-Out Entry Details
            <small>Procurement</small>
          </h1>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Procurement</a></li>
            <li class="active"> <asp:Label runat="server" ID="lblHeaderTab" Text="Add  Vehical In-Out Entry Details"></asp:Label> </li>
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
              <h3 class="box-title"><asp:Label ID="lblTabName" runat="server" Text=" Add Vehical In-Out Entry Details"></asp:Label> </h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-plus"></i></button>
                
              </div>
            </div>
            <div class="box-body"  ng-app="myApp" ng-controller="myCtrl">>
               
              
                      <asp:UpdatePanel runat="server" ID="upMain" UpdateMode="Conditional">
                    <ContentTemplate>           
        
               <div class="box box-solid box-default" style="margin-bottom:5px !important;" >
        <div class="box-header" style="padding:0px 0px 0px 10px !important">
          <h3 class="box-title">  Vehical In-Out Entry Details</h3>
        </div><!-- /.box-header -->
        <div class="box-body">
           

            
            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                      Collection Date
                      </div>
                       <asp:TextBox ID="txtDate" class="form-control" placeholder="Collection Date" runat="server" type="date" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group --> 
                          
                      </div>
            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       Vehicle No.
                      </div>
                        <asp:DropDownList ID="dpVehicleNo" class="form-control" DataTextField="VehicleNo" DataValueField="VehicleMasterID" ToolTip="Select Vehicle No." runat="server" OnSelectedIndexChanged="dpVehicleNo_SelectedIndexChanged" AutoPostBack="true"> 
                       </asp:DropDownList>                     
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div>  
            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                     Route
                      </div>
                      <asp:DropDownList ID="dpRoute" class="form-control" DataTextField="Name" DataValueField="RouteID" runat="server" selected ToolTip="Select Route"   > 
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 
             
            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                    Morning KM
                      </div>
                       <asp:TextBox ID="txtMorningKM"  class="form-control" placeholder="Morning KM" runat="server" type="number" step="any"  onTextChanged="txtMorningKM_TextChanged" autopostback="true" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group --> 
                          
                      </div>

               <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                     Morning In Time
                      </div>
                       <asp:TextBox ID="txtMorningInTime" class="form-control" placeholder="Morning In Time" runat="server" type="time" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group --> 
                          
                      </div>

              <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                     Morning In Can 
                      </div>
                       <asp:TextBox ID="txtMCanIn" class="form-control" placeholder="Morning In Can" runat="server" type="number" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group --> 
                          
                      </div>
                <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                     Morning Out Time
                      </div>
                       <asp:TextBox ID="txtMorningOutTime" class="form-control" placeholder="Morning Out Time" runat="server" type="time" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group --> 
                          
                      </div>
                <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                     Morning Out Can
                      </div>
                       <asp:TextBox ID="txtMCanOut" class="form-control" placeholder="Morning Out Can" runat="server" type="number" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group --> 
                          
                      </div>

              
             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       Evening KM
                      </div>
                       <asp:TextBox ID="txtEveningKM"  class="form-control" placeholder="Evening KM" runat="server" type="number" step="any"  ToolTip="Evening KM" onTextChanged="txtEveningKM_TextChanged" autopostback="true" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->                   
                  </div> 

                <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                     Evening In Time
                      </div>
                       <asp:TextBox ID="txtEveningInTime" class="form-control" placeholder="Evening In Time" runat="server" type="time" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group --> 
                          
                      </div>

              <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                     Evening In Can 
                      </div>
                       <asp:TextBox ID="txtEInCan" class="form-control" placeholder="Evening In Can" runat="server" type="number" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group --> 
                          
                      </div>

             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                     Evening Out Time
                      </div>
                       <asp:TextBox ID="txtEveningOutTime" class="form-control" placeholder="Evening Out Time" runat="server" type="time"  ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group --> 
                          
                      </div>

              <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                     Evening Out Can 
                      </div>
                       <asp:TextBox ID="txtEOutCan" class="form-control" placeholder="Evening Out Can" runat="server" type="number" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group --> 
                          
                      </div>


               <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                   Driver Name
                      </div>
                       <asp:TextBox ID="txtDriverName" class="form-control" placeholder="DriverName"  runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group --> 
                          
                      </div> 

               <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                      Total KM
                      </div>
                       <asp:TextBox ID="txtTotalKM"  class="form-control" placeholder="Total KM" type="number" step="any" runat="server" ReadOnly="true"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group --> 
                          
                      </div> 
             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       Amount
                      </div>
                       <asp:TextBox ID="txtAmount" class="form-control" placeholder="Amount" type="number" step="any" runat="server" Readonly="true"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group --> 
                          
                      </div> 

             
             
             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                    Bata
                      </div>
                       <asp:TextBox ID="txtBata" class="form-control" placeholder="Bata" runat="server" type="number" step="any"  ToolTip="Bata" ReadOnly="true"></asp:TextBox>                        
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->                   
                  </div>  
             
             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                 Remarks
                      </div>
                       <asp:TextBox ID="txtRemarks" class="form-control" placeholder="Remarks" TextMode="MultiLine"  runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group --> 
                          
                      </div> 
           
            
              <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      
                    
                      
                              <asp:Button ID="btnAddMilkTransport" class="btn btn-primary" runat="server" CommandName="MoveNext" OnClick="btnAddMilkCollection_Click"   Text="Add" ValidationGroup="Save" />     
                        <asp:Button ID="btnupdateMilkTransport" class="btn btn-primary" runat="server" CommandName="MoveNext" OnClick="btnupdateMilkCollection_Click"  Text="Update" ValidationGroup="Save" />  
                          &nbsp;&nbsp;&nbsp; <asp:Button ID="btnAddNew" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Add New"  OnClick="btnAddNew_Click" />                               
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
              <h3 class="box-title"> Milk Collection Transport </h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-minus"></i></button>
                
              </div>
            </div>
           
                   
                           <div class="col-lg-3"> 
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                      Collection Date
                      </div>
                       <asp:TextBox ID="txtDate1" class="form-control" placeholder="Collection Date" runat="server" type="date" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group --> 
                          
                      </div>
            
             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       Vehicle No.
                      </div>
                        <asp:DropDownList ID="dpVehicleNo1" class="form-control" DataTextField="VehicleNo" DataValueField="VehicleMasterID" ToolTip="Select Vehicle No." runat="server" > 
                       </asp:DropDownList>                     
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div>  
            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                     Route
                      </div>
                      <asp:DropDownList ID="dpRoute1" class="form-control" DataTextField="Name" DataValueField="RouteID" runat="server" selected ToolTip="Select Route"   > 
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 
                 
                      <asp:Button ID="btnSearch" class="btn btn-primary" runat="server" CommandName="MoveNext" OnClick="btnSearch_Click"   Text="View" ValidationGroup="Search" />  
                     <div class="box-body" id="datalist1">
                   
                
                       

                                <asp:UpdatePanel runat="server" ID="uprouteList" UpdateMode="Conditional">
                    <ContentTemplate>

                <table id="example2" class="table table-bordered table-striped">   
                <asp:Repeater ID="rpMilkCollectionList" runat="server" OnItemCommand="rpMilkCollectionList_ItemCommand">
                
               <HeaderTemplate>
                  <thead>
                      <tr>
                          <th>Date</th>
                        <th>VehicalNo</th>
                          <th>Route</th>
                        <th>MorningKM </th>
                        <th>EveningKM</th> 
                        <th>Amount</th>
                          <th>Bata</th>
    
                           <th>Edit</th>
                          <th>Delete</th>
                      </tr>
                    </thead>
                    <tbody>

                   
               </HeaderTemplate>
               <ItemTemplate>
                    <tr>
                         <td><%# Convert.ToDateTime(Eval("Date")).ToString("dd-MM-yyyy")%></td>
                      <td><%# Eval("VehicalNo")%></td>
                        <td><%#Eval("RouteName")%></td>

                      <td><%# Eval("MorningKM")%></td>
                     
                      <td><%# Eval("EveningKM")%></td>
                        <td><%# Eval("Amount")%></td>
                        <td><%# Eval("Bata")%></td>
                            
                         <td>

                             <asp:LinkButton ID="lbEdite" AlternateText="Edit" ForeColor="Gray" OnItemCommand="lbEdite_ItemCommand" 
                                                                    ToolTip="Edit" runat="server" CommandArgument='<%#Eval("MilkCollectionTransportID") %>'
                                                                    CommandName="Edit"><i class="fa fa-edit"></i></asp:LinkButton>

                         </td>
                         <td>   <asp:LinkButton ID="lbdelete" AlternateText="delete" ForeColor="Gray" OnItemCommand="lbdelete_ItemCommand" 
                                                                    ToolTip="Delete" runat="server" CommandArgument='<%#Eval("MilkCollectionTransportID") %>'
                                                                    CommandName="delete"><i class="fa fa-trash"></i></asp:LinkButton>
</td>
                    </tr>
               </ItemTemplate>
                    <FooterTemplate>

                         </tbody>

                    <tfoot>
                      <tr>
                          <th>Date</th>
                        <th>VehicalNo</th>
                           <th>Route</th>
                        <th>MorningKM </th>
                        <th>EveningKM</th> 
                        <th>Amount</th>
                          <th>Bata</th>
                          
                       
                       
                           <th>Edit</th>
                          <th>Delete</th>
                      </tr>
                    </tfoot>

                    </FooterTemplate>
                                             
           </asp:Repeater>
                    <asp:HiddenField id="hfMilkCollectionID" runat="server" />
         
                
                  
                     
                   
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
