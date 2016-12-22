<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FuelPumpMaster.aspx.cs" Inherits="Dairy.Tabs.TransportModule.FuelPumpMaster" %>
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
             Fuel Dealer 
            <small>Administration</small>
          </h1>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Administration</a></li>
            <li class="active">Add  Fuel Dealer </li>
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
              <h3 class="box-title"><asp:Label runat="server" ID="lblHeaderTab" Text="Add Fuel Dealer"></asp:Label></h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-plus"></i></button>
                
              </div>
            </div>
            <div class="box-body">
               
              
                      <asp:UpdatePanel runat="server" ID="upMain" UpdateMode="Conditional">
                    <ContentTemplate>           
        
               <div class="box box-solid box-default" style="margin-bottom:5px !important;" >
        <div class="box-header" style="padding:0px 0px 0px 10px !important">
          <h3 class="box-title"> Fuel Dealer </h3>
        </div><!-- /.box-header -->
        <div class="box-body">

               
             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:TextBox ID="txtfuelpumpname"  class="form-control" placeholder="Fuel Dealer Name" ToolTip="Enter  Fuel Dealer Name" runat="server"></asp:TextBox>       
                    </div><!-- /.input group -->
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtfuelpumpname"
        ErrorMessage="Fuel Dealer Name is Required" ValidationGroup="Save" ForeColor="Red" ></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 
                   


              <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:TextBox ID="txtpumpaddress"  class="form-control" placeholder="Fuel Dealer Address" ToolTip="Enter Dealer Address" runat="server" TextMode="MultiLine"></asp:TextBox>       
                    </div><!-- /.input group -->
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtpumpaddress"
        ErrorMessage="Fuel  Dealer Address is Required" ValidationGroup="Save" ForeColor="Red"></asp:RequiredFieldValidator> 
                  </div><!-- /.form group -->

                     
                       
                          
                      </div>
             

                <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:DropDownList ID="dproute" class="form-control" DataTextField="Name" DataValueField="RouteID" runat="server" ToolTip="Select  Route" > 
                       </asp:DropDownList>
                    </div><!-- /.input group -->
                       <asp:RequiredFieldValidator InitialValue="0" ID="Req_ID" Display="Dynamic" 
    ValidationGroup="Save" runat="server" ControlToValidate="dproute" ForeColor="Red"
    ErrorMessage="Please Select Route "></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 

             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:DropDownList ID="dpfuelcompany" class="form-control" DataTextField="Name" DataValueField="ID" runat="server" ToolTip="Select  Fuel Company"  > 
                       </asp:DropDownList>
                    </div><!-- /.input group -->
                       <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="dpfuelcompany"
        ErrorMessage="Fuel Company Selection  is Required" Operator="NotEqual" ValidationGroup="Save" ForeColor="Red"
        ValueToCompare="0" ></asp:CompareValidator>
                  </div><!-- /.form group -->

                     
                       
                          
                      </div>

                 

              <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                     <asp:TextBox ID="txtcontractstartdate"  type="date" class="form-control" placeholder=" Date" ToolTip="Enter Contract Start Date" runat="server"></asp:TextBox>       
                    
                    </div><!-- /.input group -->
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtcontractstartdate"
        ErrorMessage="Contract Start Date is Required" ValidationGroup="Save" ForeColor="Red" ></asp:RequiredFieldValidator> 
                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 
             

               <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                     <asp:TextBox ID="txtcontractenddate"  type="date" class="form-control" placeholder=" Date" ToolTip="Enter Contract End Date" runat="server"></asp:TextBox>       
                    
                    </div><!-- /.input group -->
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtcontractenddate"
        ErrorMessage="Contract End Date is Required" ValidationGroup="Save" ForeColor="Red" ></asp:RequiredFieldValidator>  
                         
                  </div><!-- /.form group -->

                 <asp:CompareValidator ID="CompareValidator1" ValidationGroup = "Save" ForeColor = "Red" runat="server" ControlToValidate = "txtcontractstartdate" ControlToCompare = "txtcontractenddate" Operator = "LessThan" Type = "Date" ErrorMessage="Start date must be less than End date."></asp:CompareValidator>
                       
                          
                      </div>
            
          
                   <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                     <asp:TextBox ID="txtregistrationno"   class="form-control" placeholder="RegistrationNo." ToolTip="Enter  RegistrationNo." runat="server"></asp:TextBox>       
                    
                    </div><!-- /.input group -->
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtregistrationno"
        ErrorMessage="RegistrationNo is Required" ValidationGroup="Save" ForeColor="Red" ></asp:RequiredFieldValidator>  
                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 

                   
                <div class="col-lg-3">
                        <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:TextBox ID="txtcontractamt"   class="form-control" placeholder="Contract Amount." ToolTip="Enter  Contract Amount " runat="server" type="number"></asp:TextBox>       
                    
                    </div><!-- /.input group -->
  <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtcontractamt"
        ErrorMessage="Contract Amount is Required" ValidationGroup="Save" ForeColor="Red" ></asp:RequiredFieldValidator>  

                  </div><!-- /.form group -->

                     
                       
                          
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
                      <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator7" Display="Dynamic" 
    ValidationGroup="Save" runat="server" ControlToValidate="dpIsActive" ForeColor="Red"
    ErrorMessage="Please Select Type Status "></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 
                
            
             <div class="col-lg-3 ">
                  <div class="form-group">
                    <div class="input-group">
                      
                    
                      
                              <asp:Button ID="btnAddFuelPumpDetails" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Add" ValidationGroup="Save" OnClick="btnClick_btnAddFuelPumpDetails" />     
                        <asp:Button ID="btnupdateFuelPumpDetails" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Update" ValidationGroup="Save" OnClick="btnClick_btnupdateFuelPumpDetails" />           
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
              <h3 class="box-title"> Fuel Dealer list </h3>
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
                         <th>Fuel Dealer Name</th>
                           <th>Address</th>
                           <th>Route</th>
                             <th>Company</th>
                          <th>Start Date</th>
                           <th>End Date</th>
                            <th>Registration No.</th>
                         
                          <th>Amount</th>
                             
                             <th>IsActive</th>
                        <th>Created By</th>
                        <th>Created Date</th>
                           <th>Edit</th>
                         <%-- <th>Delete</th>--%>
                      </tr>
                    </thead>
                    <tbody>
               </HeaderTemplate>
               <ItemTemplate>
                    <tr>
                      <td><%# Eval("Id")%></td>
                        
                         <td><%# Eval("fuelpumpname")%></td>
                         <td><%# Eval("pumpaddress")%></td>
                           <td><%# Eval("RouteName")%></td>
                          <td><%# Eval("CONFIGVALUE")%></td>
                          <td><%# Eval("contractstartdate")%></td>
                         <td><%# Eval("contractenddate")%></td>
                         <td><%# Eval("registrationno")%></td>
                        
                      <td><%# string.Format("{0:##,###.##}",Eval("contractamt"))%></td>
                         <td><%# Eval("IsActive")%></td>
                       <td><%# Eval("Name")%></td>
                      <td><%# Eval("CreatedDate")%></td>
                         <td>

                             <asp:LinkButton ID="lbEdite" AlternateText="Edit" ForeColor="Gray" OnItemCommand="lbEdite_ItemCommand" 
                                                                    ToolTip="Edit" runat="server" CommandArgument='<%#Eval("Id") %>'
                                                                    CommandName="Edit"><i class="fa fa-edit"></i></asp:LinkButton>

                         </td>
                        <%-- <td>   <asp:LinkButton ID="lbdelete" AlternateText="delete" ForeColor="Gray" OnItemCommand="lbdelete_ItemCommand" 
                                                                    ToolTip="Delete" runat="server" CommandArgument='<%#Eval("Id") %>'
                                                                    CommandName="delete"><i class="fa fa-trash"></i></asp:LinkButton>
</td>--%>
                    </tr>
               </ItemTemplate>
                    <FooterTemplate>

                         </tbody>

                    <tfoot>
                      <tr>
                         <th>ID</th>
                         <th>Fuel Dealer Name</th>
                           <th>Address</th>
                           <th>Route</th>
                           <th>Company</th>
                          <th>Start Date</th>
                           <th>End Date</th>
                            <th>Registration No.</th>
                         
                          <th>Amount</th>
                             
                             <th>IsActive</th>
                        <th>Created By</th>
                        <th>Created Date</th>
                           <th>Edit</th>
                         <%-- <th>Delete</th>--%>
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
</asp:Content>
