<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="JOBCard.aspx.cs" Inherits="Dairy.Tabs.TransportModule.JOBCard" %>
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section class="content-header">
          <h1>
             JOB Card(Complants)
            <small>Administration</small>
          </h1>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Administration</a></li>
            <li class="active">Add JOB Card Info</li>
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
              <h3 class="box-title"><asp:Label runat="server" ID="lblHeaderTab" Text="Add JOB Card Info"></asp:Label></h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-plus"></i></button>
                
              </div>
            </div>
            <div class="box-body">
               
              
                      <asp:UpdatePanel runat="server" ID="upMain" UpdateMode="Conditional">
                    <ContentTemplate>           
        
               <div class="box box-solid box-default" style="margin-bottom:5px !important;" >
        <div class="box-header" style="padding:0px 0px 0px 10px !important">
          <h3 class="box-title">JOB Card Information </h3>
        </div><!-- /.box-header -->
        <div class="box-body">
              <fieldset>
  <legend>Search  Vehicle Operation Details</legend>
            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                    
                        
                         <asp:DropDownList ID="dpVehicleNo" class="form-control" DataTextField="VehicleNo" DataValueField="TM_Id" runat="server" ToolTip="Select VehicleNo" AutoPostBack="true"  OnSelectedIndexChanged = "dpVehicleNo_SelectedIndexChanged" > 
                       </asp:DropDownList>                   
                    </div><!-- /.input group -->
                        <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator1" Display="Dynamic" 
    ValidationGroup="Save" runat="server" ControlToValidate="dpVehicleNo" ForeColor="Red"
    ErrorMessage="Please Select Vehicle No. "></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
   </div> 
                  <asp:Button ID="btnSearch" runat="server" Text="Search" class="btn btn-primary"></asp:Button>
                   </fieldset>
               <div class="col-md-8 col-sm-8">
			<div class="panel panel-default">
                	<div class=" panel-heading">Vehicle Operation Details</div>
				<div class="panel-body">
            
            	
              <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                           <asp:TextBox ID="txtVOpId" class="form-control" placeholder="OperationId" ToolTip="Operation ID" runat="server" ReadOnly="true"></asp:TextBox>       
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div>
             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                           <asp:TextBox ID="txtRouteId" class="form-control" placeholder="Route" ToolTip="Route" runat="server" ReadOnly="true"></asp:TextBox>       
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div>
             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                           <asp:TextBox ID="txtDriver" class="form-control" placeholder="Driver" ToolTip="Driver" runat="server" ReadOnly="true"></asp:TextBox>       
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div>
               <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                           <asp:TextBox ID="txtSalesMan" class="form-control" placeholder="Salesman" ToolTip="Salesman" runat="server" ReadOnly="true"></asp:TextBox>       
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div>
             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                           <asp:TextBox ID="txtOutDate" class="form-control" placeholder="OutDate" ToolTip="OutDate" runat="server" ReadOnly="true"></asp:TextBox>       
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div>
             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                           <asp:TextBox ID="txtInDate" class="form-control" placeholder="InDate" ToolTip="InDate" runat="server" ReadOnly="true"></asp:TextBox>       
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div>
              <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                           <asp:TextBox ID="txtOutTime" class="form-control" placeholder="OuteTime" ToolTip="OutTime" runat="server" ReadOnly="true"></asp:TextBox>       
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div>
               <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                           <asp:TextBox ID="txtInTime" class="form-control" placeholder="In Time" ToolTip="In Time" runat="server" ReadOnly="true"></asp:TextBox>       
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div>
             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                           <asp:TextBox ID="txtOutKM" class="form-control" placeholder="Out Kilometere" ToolTip="Out Kilometere" runat="server" ReadOnly="true"></asp:TextBox>       
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div>
              <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                           <asp:TextBox ID="txtInKM" class="form-control" placeholder="IN Kilometere" ToolTip="IN Kilometere" runat="server" ReadOnly="true"></asp:TextBox>       
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div>
             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                           <asp:TextBox ID="txtRunKM" class="form-control" placeholder="Running Kilometre" ToolTip="Running Kilometre" runat="server" ReadOnly="true"></asp:TextBox>       
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div>
             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                           <asp:TextBox ID="txtDieselLtr" class="form-control" placeholder="Diesel(Ltrs.)" ToolTip="Diesel(Ltrs.)" runat="server" ReadOnly="true"></asp:TextBox>       
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div>
              <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                           <asp:TextBox ID="txtAmt" class="form-control" placeholder="Amount" ToolTip="Amount" runat="server" ReadOnly="true"></asp:TextBox>       
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div>
          <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
           
                        <asp:Label ID="lblShowMessage" runat="server" ForeColor="Red"></asp:Label>
                           </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 
             </div>
                </div>
                   	</div>
		
           <div class="col-md-4 col-sm-4">
			<div class="panel panel-primary" style="height:100%">
				<div class=" panel-heading">Notifications</div>
				<div class=" panel-body">
					<br><br><br><br><br><br><br><br>
					
				</div>
			</div>
		</div>

              <div class="col-md-12 col-sm-12">
			<div class="panel panel-primary">
                
				<div class="panel-body">

            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                           <asp:TextBox ID="txtBrake" class="form-control" placeholder="Brake" ToolTip="Enter Brake related Complaints" runat="server" TextMode="MultiLine"></asp:TextBox>       
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 

             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                           <asp:TextBox ID="txtLight" class="form-control" placeholder="Light's" ToolTip="Enter Light's related Complaints" runat="server" TextMode="MultiLine"></asp:TextBox>       
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 

             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                           <asp:TextBox ID="txtTyreCondition" class="form-control" placeholder="Tyre Condition's" ToolTip="Enter Tyres Condition's related Complaints" TextMode="MultiLine" runat="server"></asp:TextBox>       
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 

             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                           <asp:TextBox ID="txtDamages" class="form-control" placeholder="Damages" ToolTip="Enter Damages related Complaints" TextMode="MultiLine" runat="server"></asp:TextBox>       
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 

              <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                           <asp:TextBox ID="txtOilLevel" class="form-control" placeholder="Oil Level" ToolTip="Enter Oil Level " TextMode="MultiLine" runat="server"></asp:TextBox>       
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 

              <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                           <asp:TextBox ID="txtBattery" class="form-control" placeholder="Battary(Self Condition)" ToolTip="Enter Battary(Self Condition)" TextMode="MultiLine" runat="server"></asp:TextBox>       
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 

              <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                           <asp:TextBox ID="txtCrownnandJointSound" class="form-control" placeholder="Crown Sound & Joint Sound" ToolTip="Enter Crown Sound & Joint Sound" TextMode="MultiLine" runat="server"></asp:TextBox>       
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 

              <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                           <asp:TextBox ID="txtClutchCondition" class="form-control" placeholder="Clutch-Condition" ToolTip="Enter Clutch-Condition" TextMode="MultiLine" runat="server"></asp:TextBox>       
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 

              <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                           <asp:TextBox ID="txtStearingVobling" class="form-control" placeholder="Stearing Vobling(The rod end & kingpin shack)" ToolTip="Enter Stearing Vobling" TextMode="MultiLine" runat="server"></asp:TextBox>       
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 

              <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                           <asp:TextBox ID="txtSuspension" class="form-control" placeholder="Suspension(Springhead)" ToolTip="Enter Suspension" TextMode="MultiLine" runat="server"></asp:TextBox>       
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 

              <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                           <asp:TextBox ID="txtGearBox" class="form-control" placeholder="Gear Box" ToolTip="Enter Gear Box" TextMode="MultiLine" runat="server"></asp:TextBox>       
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 
           <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                           <asp:TextBox ID="txtOthers" class="form-control" placeholder="Others" ToolTip="Enter Other related Complaints" TextMode="MultiLine" runat="server"></asp:TextBox>       
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div>
            
             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      
                    
                      
                              <asp:Button ID="btnAddJobCard" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Add" ValidationGroup="Save" OnClick="btnClick_btnAddJobCard" />     
                        &nbsp;&nbsp;<asp:Button ID="btnUpdateJobCard" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Update" ValidationGroup="Save" OnClick="btnClick_btnUpdateJobCard" />  
                         &nbsp;&nbsp; &nbsp;   <asp:Button ID="btnAddNew" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="AddNew"  OnClick="btnClick_btnAddNew" />                            
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 

</div>
                </div>
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
              <h3 class="box-title"> Job Card List </h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-minus"></i></button>
                
              </div>
            </div>
            <div class="box-body" id="datalist">
                   
                
                       

                                <asp:UpdatePanel runat="server" ID="uprouteList" UpdateMode="Conditional">
                    <ContentTemplate>

                <table id="example1" class="table table-bordered table-striped">
                   

                 

                <asp:Repeater ID="rpJOBCardInfo" runat="server" OnItemCommand="rpJOBCardInfo_ItemCommand">
                
               <HeaderTemplate>
                  <thead>
                      <tr>
                           <th>Id</th>
                         
                          <th>OperationId</th>
                            <th>VehicleNo</th>
                            <th>Break</th>
                             <th>Light</th>
                        <th>Created By</th>
                        <th>Created Date</th>
                           <th>Edit</th>
                     
                      </tr>
                    </thead>
                    <tbody>
               </HeaderTemplate>
               <ItemTemplate>
                    <tr>
                         <td><%# Eval("Id")%></td>
                        
                         <td><%# Eval("VOp")%></td>
                         <td><%# Eval("Brake")%></td>
                         <td><%# Eval("Lights")%></td>
                         <td><%# Eval("TyreCondition")%></td>
                       <td><%# Eval("CreatedBy")%></td>
                      <td><%# Eval("CreatedDate")%></td>
                         <td>

                             <asp:LinkButton ID="lbEdite" AlternateText="Edit" ForeColor="Gray" OnItemCommand="lbEdite_ItemCommand" 
                                                                    ToolTip="Edit" runat="server" CommandArgument='<%#Eval("ID") %>'
                                                                    CommandName="Edit"><i class="fa fa-edit"></i></asp:LinkButton>

                         </td>
                     
                    </tr>
               </ItemTemplate>
                    <FooterTemplate>

                         </tbody>

                    <tfoot>
                      <tr>
                          <th>Id</th>
                         
                          <th>Config Name</th>
                            <th>Config Key</th>
                            <th>Config Value</th>
                             <th>IsActive</th>
                        <th>Created By</th>
                        <th>Created Date</th>
                           <th>Edit</th>
                         <%-- <th>Deactive</th>--%>
                      </tr>
                    </FooterTemplate>                                       
           </asp:Repeater>
                    <asp:HiddenField id="hfJOBCardInfo" runat="server" />                 
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
