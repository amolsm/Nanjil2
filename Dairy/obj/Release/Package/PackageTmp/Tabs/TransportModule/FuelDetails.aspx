<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FuelDetails.aspx.cs" Inherits="Dairy.Tabs.TransportModule.FuelDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

      <script type="text/javascript" src="/bower_components/jquery/jquery.min.js"></script>
  <script type="text/javascript" src="/bower_components/moment/min/moment.min.js"></script>
  <script type="text/javascript" src="/bower_components/bootstrap/dist/js/bootstrap.min.js"></script>
  <script type="text/javascript" src="/bower_components/eonasdan-bootstrap-datetimepicker/build/js/bootstrap-datetimepicker.min.js"></script>
  <link rel="stylesheet" href="/bower_components/bootstrap/dist/css/bootstrap.min.css" />
  <link rel="stylesheet" href="/bower_components/eonasdan-bootstrap-datetimepicker/build/css/bootstrap-datetimepicker.min.css" />


   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  
     
    <section class="content-header">
          <h1>
             Vehicle Fuel Details Information
            <small>Administration</small>
          </h1>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Administration</a></li>
            <li class="active">Add Vehicle FuelDetails Info</li>
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
              <h3 class="box-title"><asp:Label runat="server" ID="lblHeaderTab" Text="Add Vehicle FuelDetails"></asp:Label></h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-plus"></i></button>
                
              </div>
            </div>
            <div class="box-body">
               
              
                      <asp:UpdatePanel runat="server" ID="upMain" UpdateMode="Conditional">
                    <ContentTemplate>           
        
               <div class="box box-solid box-default" style="margin-bottom:5px !important;" >
        <div class="box-header" style="padding:0px 0px 0px 10px !important">
          <h3 class="box-title">Vehicle FuelDetails Information </h3>
        </div><!-- /.box-header -->
        <div class="box-body">

               
             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                         <asp:DropDownList ID="dpVehicleNo" class="form-control" DataTextField="VehicleNo" DataValueField="TM_Id"  AutoPostBack="true" OnSelectedIndexChanged="dpVehicleNo_IndexChanged" runat="server" ToolTip="Select VehicleNo" > 
                       </asp:DropDownList>
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
                  
                     
                       
                          
                      </div> 
  <asp:CompareValidator ID="CompareValidator" runat="server" ControlToValidate="dpVehicleNo"
        ErrorMessage="Vehicle No. is Required" Operator="NotEqual" ValidationGroup="Save" ForeColor="Red"
        ValueToCompare="0" Display="None"></asp:CompareValidator>
                       


                <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:DropDownList ID="dpFuelType" class="form-control" DataTextField="Name" DataValueField="ID" runat="server" ToolTip="Select Fuel Type" > 
                       </asp:DropDownList>
                    
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="dpFuelType"
        ErrorMessage="Fuel Type is Required" Operator="NotEqual" ValidationGroup="Save" ForeColor="Red"
        ValueToCompare="0" Display="None"></asp:CompareValidator>

              <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                     <asp:TextBox ID="txtDate"  type="date" class="form-control" placeholder=" Date" ToolTip="Enter  Date" runat="server"></asp:TextBox>       
                    
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 

                   <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                         <div class="input-group-addon">
                                <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                                 </div>
                        <asp:TextBox ID="txtTime"  type="time" class="form-control" runat="server" ToolTip="Enter Time"></asp:TextBox>
                     
                        
                    
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 

            


               <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                     <asp:TextBox ID="txtQty"   class="form-control" placeholder=" Quantity" ToolTip="Enter  Ltrs Qty." runat="server" Type="number"></asp:TextBox>       
                    
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator" runat="server" ControlToValidate="txtQty"
        ErrorMessage="Fuel Ltrs Qty. is Required" ValidationGroup="Save" ForeColor="Red" Display="None"></asp:RequiredFieldValidator>
                       
               <div class="col-lg-3">

                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:DropDownList ID="dpUnitType" class="form-control" DataTextField="UnitName" DataValueField="UnitID" runat="server" ToolTip="Select  Unit Type" > 
                       </asp:DropDownList>
                    
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 
                <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="dpUnitType"
        ErrorMessage="Unit Type is Required" Operator="NotEqual" ValidationGroup="Save" ForeColor="Red"
        ValueToCompare="0" Display="None"></asp:CompareValidator>

               <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:DropDownList ID="dpRegisterpump" class="form-control" runat="server" selected ToolTip="Select FuelPump">
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
                     <asp:TextBox ID="txtnonregisteredpump"   class="form-control" placeholder="Non registered pump" ToolTip="Enter  Non registered pump name" runat="server"></asp:TextBox>       
                    
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 

               <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                     <asp:TextBox ID="txtReceiptNo"   class="form-control" placeholder="ReceiptNumber" ToolTip="Enter  Bill Number" runat="server"></asp:TextBox>       
                    
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 

              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtReceiptNo"
        ErrorMessage="Bill No. is Required" ValidationGroup="Save" ForeColor="Red" Display="None"></asp:RequiredFieldValidator>
                       
            
               <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                     <asp:TextBox ID="txtPrice"   class="form-control" placeholder="Price" ToolTip="Enter Price" runat="server" Type="number"></asp:TextBox>       
                    
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 

              <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                     <asp:TextBox ID="txtAmt"   class="form-control" placeholder=" Amount" ToolTip="Enter  Amount" runat="server" Type="number"></asp:TextBox>       
                    
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 

               <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtAmt"
        ErrorMessage="Amount is Required" ValidationGroup="Save" ForeColor="Red" Display="None"></asp:RequiredFieldValidator>
          


             <%--    <div class="col-lg-3">
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
                  </div><!-- /.form group -->

                     
                       
                          
                      </div> --%>

             <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
        ShowSummary="False" ValidationGroup="Save" />
            
             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      
                    
                      
                              <asp:Button ID="btnAddVehicleFuelDetails" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Add" ValidationGroup="Save" OnClick="btnClick_btnAddVehicleFuelDetails" />     
                        <asp:Button ID="btnupdateVehicleFuelDetails" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Update" ValidationGroup="Save" OnClick="btnClick_btnupdateVehicleFuelDetails" />           
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
              <h3 class="box-title"> Vehicle Fuel Details List </h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-minus"></i></button>
                
              </div>
            </div>
            <div class="box-body" id="datalist">
                   
                
                       

                                <asp:UpdatePanel runat="server" ID="uprouteList" UpdateMode="Conditional">
                    <ContentTemplate>

                <table id="example1" class="table table-bordered table-striped">
                   

                 

                <asp:Repeater ID="rpvehiclefueldetailsInfo" runat="server" OnItemCommand="rpRouteList_ItemCommand">
                
               <HeaderTemplate>
                  <thead>
                      <tr>
                          <th>ID</th>
                           <th>Vehicle No.</th>
                         <th>Fuel Refill Date</th>
                           <th>Fuel RefillTime</th>
                         
                           <th>Fuel Type</th>
                            <th>Quantity</th>
                           <th>Fuel Pump Name</th>
                            
                          <th>Price</th>
                          <th>Amount</th>
                             <th>Receipt No.</th>
                           <%--  <th>IsActive</th>--%>
                        <th>Created By</th>
                        <th>Created Date</th>
                           <th>Edit</th>
                       <%--   <th>Delete</th>--%>
                      </tr>
                    </thead>
                    <tbody>
               </HeaderTemplate>
               <ItemTemplate>
                    <tr>
                      <td><%# Eval("Tr_FuelID")%></td>
                             <td><%# Eval("VehicleNo")%></td>
                         <td><%# Eval("FuelRefielDate")%></td>
                         <td><%# Eval("FuelRefielTime")%></td>
                     
                         <td><%# Eval("CONFIGVALUE")%></td>
                         <td><%# Eval("FuelQty")%></td>
                   <%--      <td><%# Eval("fuelpumpname")%></td>--%>
                      <%--    <td><%# Eval("Nonregisterpump")%></td--%>
                            <td> <%#(String.IsNullOrEmpty(Eval("fuelpumpname").ToString()) ? Eval("Nonregisterpump") : Eval("fuelpumpname"))%></td>
                           <td><%# Eval("FuelCostprice")%></td>
                         <td><%# Eval("Amount")%></td>
                          <td><%# Eval("ReceiptNo")%></td>
                       <%--  <td><%# Eval("IsActive")%></td>--%>
                       <td><%# Eval("Name")%></td>
                      <td><%# Eval("CreatedDate")%></td>
                         <td>

                             <asp:LinkButton ID="lbEdite" AlternateText="Edit" ForeColor="Gray" OnItemCommand="lbEdite_ItemCommand" 
                                                                    ToolTip="Edit" runat="server" CommandArgument='<%#Eval("Tr_FuelID") %>'
                                                                    CommandName="Edit"><i class="fa fa-edit"></i></asp:LinkButton>

                         </td>
                       <%--  <td>   <asp:LinkButton ID="lbdelete" AlternateText="delete" ForeColor="Gray" OnItemCommand="lbdelete_ItemCommand" 
                                                                    ToolTip="Delete" runat="server" CommandArgument='<%#Eval("Tr_FuelID") %>'
                                                                    CommandName="delete"><i class="fa fa-trash"></i></asp:LinkButton>
</td>--%>
                    </tr>
               </ItemTemplate>
                    <FooterTemplate>

                         </tbody>

                    <tfoot>
                      <tr>
                     <th>ID</th>
                             <th>Vehicle No.</th>
                      <th>Fuel Refill Date</th>
                           <th>Fuel RefillTime</th>
                       
                           <th>Fuel Type</th>
                            <th>Quantity</th>
                         <th>Fuel Pump Name</th>
                          
                          <th>Price</th>
                          <th>Amount</th>
                             <th>Receipt No.</th>
                           <%--  <th>IsActive</th>--%>
                        <th>Created By</th>
                        <th>Created Date</th>
                           <th>Edit</th>
                       <%--   <th>Delete</th>--%>
                      </tr>
                    </FooterTemplate>                                       
           </asp:Repeater>
                    <asp:HiddenField id="hfvmapId" runat="server" />                 
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
   <%-- <script type="text/javascript">
        $(function () {
            $('#txtTime').data("DateTimePicker").FUNCTION()({
                format: 'LT'
            });
        });
         </script>--%>
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
            $('#txtTime').timepicker();
        </script>
</asp:Content>
