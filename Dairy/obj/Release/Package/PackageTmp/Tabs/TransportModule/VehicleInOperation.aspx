<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VehicleInOperation.aspx.cs" Inherits="Dairy.Tabs.TransportModule.VehicleInOperation" %>
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
             Vehicle In Operations Information
            <small>Administration</small>
          </h1>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Administration</a></li>
            <li class="active">Add  Vehicle In Operations Info</li>
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
              <div class="box">
            <div class="box-header with-border">
              <h3 class="box-title"><asp:Label runat="server" ID="lblHeaderTab" Text="Add Vehicle In Operations"></asp:Label></h3>
              <div class="box-tools pull-right">
                <%--<button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-plus"></i></button>--%>
                
              </div>
            </div>
            <div class="box-body">
               
              
                      <asp:UpdatePanel runat="server" ID="upMain" UpdateMode="Conditional">
                    <ContentTemplate>           
        
               <div class="box box-solid box-default" style="margin-bottom:5px !important;" >
        <div class="box-header" style="padding:0px 0px 0px 10px !important">
          <h3 class="box-title">Vehicle In Operation Information </h3>
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
                 <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="btnSearch_Click"></asp:Button>
                 </fieldset>


  <div class="col-md-8 col-sm-8">
			<div class="panel panel-default">
                	<div class=" panel-heading">Vehicle Operation Details <asp:Label runat="server" ID="lblOperationId" ForeColor="Red"></asp:Label></div>
				<div class="panel-body">
                       <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                           <asp:TextBox ID="txtStartDate"  type="date" class="form-control" placeholder=" Out Date" ToolTip="Out Date" runat="server" ReadOnly="true"></asp:TextBox>       
                    </div><!-- /.input group -->
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Enter Out Date" ControlToValidate="txtStartDate" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 
                
              
         

                <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtStartTime" class="form-control" type="time"        placeholder=" Out Time" ToolTip="Out Time" runat="server" ReadOnly="true" ></asp:TextBox>        
                    </div><!-- /.input group -->
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please Enter Out Time" ControlToValidate="txtStartTime" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 
             

                <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                           <asp:TextBox ID="txtStartKm" class="form-control" placeholder=" Out Kilometer" ToolTip="Out Kilometer" runat="server" ReadOnly="true"></asp:TextBox>       
                    </div><!-- /.input group -->
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please Enter Out Kilometer" ControlToValidate="txtStartKm" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 

                 

               
            
              <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                           <asp:TextBox ID="txtBata" class="form-control" placeholder="Driver Bata amount" ToolTip="Driver Bata Amt." runat="server" ReadOnly="true"></asp:TextBox>       
                    </div><!-- /.input group -->
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Please Enter  Driver Bata Amt." ControlToValidate="txtBata" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->

                     
                       
                          
                      </div>    
            
            
            
                  <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                           <asp:TextBox ID="txtSalesBata" class="form-control" placeholder=" Sales Bata amount" ToolTip="Sales Bata Amt." runat="server" ReadOnly="true"></asp:TextBox>       
                    </div><!-- /.input group -->
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Please Enter  Sales Bata amount" ControlToValidate="txtSalesBata" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->

                     
                       
                          
                      </div>   

             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <i class="fa fa-rode"></i><span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:DropDownList ID="dpOperations" ValidationGroup="Save" class="form-control" DataTextField="Name" DataValueField="ID" runat="server" ToolTip="Operation Type" disabled> 
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                        <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator7" Display="Dynamic" 
    ValidationGroup="Save" runat="server" ControlToValidate="dpOperations" ForeColor="Red"
    ErrorMessage="Please Select Operation Type "></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
                         </div>      
             

           
        
                    </div>
                </div>
      </div>
                  <div class="col-md-4 col-sm-4">
			<div class="panel panel-warning" style="height:100%">
				<div class=" panel-heading">Search Message</div>
				<div class=" panel-body">
					<br>   <asp:Label runat="server" ID="lblShowMessage" ForeColor="Red"></asp:Label><br><br><br><br><br><br><br>
					
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
                           <asp:TextBox ID="txtEndDate" type="date" class="form-control" placeholder=" In Date" ToolTip="Enter In Date" runat="server" ></asp:TextBox>       
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Please Enter  In Date" ControlToValidate="txtEndDate" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 
         
 <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                               <asp:TextBox ID="txtEndTime" class="form-control" type="time"   placeholder=" In Time " ToolTip="Enter In Time" runat="server"  ></asp:TextBox>              
                    </div><!-- /.input group -->
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Please In Time" ControlToValidate="txtEndTime" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 

 <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                           <asp:TextBox ID="txtEndKm" class="form-control" placeholder=" In Kilometer" ToolTip="Enter In Kilometer" runat="server" type="number" ></asp:TextBox>       
                    </div><!-- /.input group -->
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="Please In Kilometer" ControlToValidate="txtEndKm" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
                     </div> 
                 
              <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                           <asp:TextBox ID="txtTollPaid" class="form-control" placeholder=" Toll Paid Amt." ToolTip="Enter Toll Paid Amt." runat="server" type="number"></asp:TextBox>       
                    </div><!-- /.input group -->
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="Please In Kilometer" ControlToValidate="txtEndKm" ForeColor="Red" ValidationGroup="None"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 

               <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <i class="fa fa-rode"></i><span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:DropDownList ID="dpFuelType" ValidationGroup="none" class="form-control" DataTextField="Name" DataValueField="ID" runat="server" ToolTip="Select Fuel Type"  > 
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                      
                  </div><!-- /.form group -->
                         </div> 

  <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                           <asp:TextBox ID="txtFuel" class="form-control" placeholder="Fuel Lts." ToolTip="Enter Fuel Lts" runat="server" type="number"></asp:TextBox>       
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div>
            
   <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                     <asp:TextBox ID="txtPrice"   class="form-control" placeholder="Price" ToolTip="Enter Fuel Price" runat="server" type="number"></asp:TextBox>       
                    
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div>  

   <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                           <asp:TextBox ID="txtFuelAmt" class="form-control" placeholder="Fuel Amount" ToolTip="Enter Fuel Amount" runat="server" type="number"></asp:TextBox>       
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 

   <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                           <asp:TextBox ID="txtBillNo" class="form-control" placeholder="Bill No" ToolTip="Enter Fuel Refeil Bill No" runat="server" type="number"></asp:TextBox>       
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 

   <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:DropDownList ID="dpRegisterpump" class="form-control" runat="server" selected ToolTip="Select Dealer">
                      </asp:DropDownList>
                 
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 
          
                     <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      
                    
                      
                              <asp:Button ID="btnAddInOperation" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Add" ValidationGroup="Save" OnClick="btnClick_btnAddInOperation" />     
                        &nbsp;&nbsp;<asp:Button ID="btnUpdateInOpration" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Update" ValidationGroup="Save" OnClick="btnClick_btnUpdateInOpration" />  
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
              <h3 class="box-title">Out Operation List </h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-minus"></i></button>
                
              </div>
            </div>
            <div class="box-body" id="datalist">
                   
                
                       

                                <asp:UpdatePanel runat="server" ID="uprouteList" UpdateMode="Conditional">
                    <ContentTemplate>

                <table id="example1" class="table table-bordered table-striped">
                   

                 

                <asp:Repeater ID="rpvehicleoperationInfo" runat="server" OnItemCommand="rpRouteList_ItemCommand">
                
               <HeaderTemplate>
                  <thead>
                      <tr>
                            <th>ID</th>
                            <th>Route Name</th>
                            <th>Vehicle Number</th>
                             <th>StartDate</th>
                             <th>StartTime</th>
                            <th>StartKm</th>
                          <th>ScheduleOutTime</th>
                            <th>ScheduleInTime</th>
                           <th>OperationType</th>
                          <th>Driver Bata</th>
                          <th>Salesman Bata</th>
                           <th>Edit</th>
                     
                
                         
                      </tr>
                    </thead>
                    <tbody>
               </HeaderTemplate>
               <ItemTemplate>
                    <tr>
                         <td><%# Eval("VOp")%></td>
                     
                         <td><%# Eval("RouteName")%></td>
                           <td><%# Eval("VehicleNo")%></td>
                         <td><%# Eval("StartDate")%></td>
                         <td><%# Eval("StartTime")%></td>
                         <td><%# Eval("StartKm")%></td>
                           <td><%# Eval("ScheduleTime")%></td>
                         <td><%# Eval("EndScheduleTime")%></td>
                          <td><%# Eval("OperationType")%></td>
                         <td><%# string.Format("{0:##,###.##}",Eval("Bata"))%></td>
                         <td><%# string.Format("{0:##,###.##}",Eval("SMBata"))%></td>
                         
                      
                        
                   <td>

                             <asp:LinkButton ID="lbEdite" AlternateText="Edit" ForeColor="Gray" OnItemCommand="lbEdite_ItemCommand" 
                                                                    ToolTip="Edit" runat="server" CommandArgument='<%#Eval("VOp") %>'
                                                                    CommandName="Edit"><i class="fa fa-edit"></i></asp:LinkButton>

                         </td>
                   
                    </tr>
               </ItemTemplate>
                    <FooterTemplate>

                         </tbody>

                    <tfoot>
                      <tr>
                            <th>DispatchId</th>
                     
                            <th>Vehicle Number</th>
                            <th>Route Name</th>
                          
                            <th>Driver Bata</th>
                             <th>Salesman Bata</th>
                            <th>StartKm</th>
                          <th>StartTime</th>
                            <th>StartDate</th>
                   
                
                           <th>Edit</th>
                      
                      </tr>
                    </FooterTemplate>                                       
           </asp:Repeater>
                    <asp:HiddenField id="hfvoperationId" runat="server" />                 
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

       <script>
           yepnope({ // or Modernizr.load
               test: Modernizr.inputtypes.date,
               nope: [
                   'http://cdnjs.cloudflare.com/ajax/libs/jqueryui/1.11.2/jquery-ui.min.js',

                   'http://cdnjs.cloudflare.com/ajax/libs/jqueryui/1.11.2/jquery-ui.min.css',
                   'http://cdnjs.cloudflare.com/ajax/libs/jqueryui/1.11.2/jquery-ui.structure.min.css',
                   'http://cdnjs.cloudflare.com/ajax/libs/jqueryui/1.11.2/jquery-ui.theme.min.css',

               ],

               callback: function (url) {

                   if (url === 'http://cdnjs.cloudflare.com/ajax/libs/jqueryui/1.11.2/jquery-ui.min.js') {

                       var idx = 0;

                       $('input[type="date"]').each(function () {
                           var _this = $(this),
                               prefix = 'alt' + String(idx++) + '_',
                               _val = _this.val();

                           _this
                           .attr('placeholder', 'dd-MM-yyyy')
                           .attr('autocomplete', 'off')
                           .prop('readonly', true)
                           .after('<input type="text" class="altfield" id="' + prefix + this.attr('id') + '" name="' + this.attr('name') + '" value="' + _val + '">')
                           .removeAttr('name')
                           .val('')
                           .datepicker({
                               altField: '#' + prefix + _this.attr('id'),
                               dateFormat: 'dd-MM-yyyy',
                               altFormat: 'dd-MM-yyyy'
                           });

                           if (_val) {
                               this.datepicker('setDate', $.datepicker.parseDate('dd-MM-yyyy', val));
                           };
                       });


                       // min attribute
                       $('input[type="date"][min]').each(function () {
                           var _this = $(this);
                           this.datepicker("option", "minDate", $.datepicker.parseDate('dd-MM-yyyy', this.attr('min')));
                       });

                       // max attribute
                       $('input[type="date"][max]').each(function () {
                           var _this = $(this);
                           this.datepicker("option", "maxDate", $.datepicker.parseDate('dd-MM-yyyy', this.attr('max')));
                       });
                   }
               }
           }); // end Modernizr.load
        </script>
</asp:Content>
