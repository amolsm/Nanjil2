<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TransportDetails.aspx.cs" Inherits="Dairy.Tabs.TransportModule.TransportDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" href="http://localhost:7360/code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css"/>
            <script  src="//code.jquery.com/jquery-1.10.2.js"></script>
            <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
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

       <script type="text/javascript">
           function BindSlabDetails() {



           }

           $(function () {
               //$("#MainContent_txtVeh_InsDue").datepicker({ dateFormat: 'dd/mm/yy' });
               //$("#MainContent_txtVeh_PUCDue").datepicker({ dateFormat: 'dd/mm/yy' });

               $("#MainContent_txtVeh_Year").datepicker({
                   changeMonth: false,
                   changeYear: true,
                   showButtonPanel: true,
                   dateFormat: 'yy'
               }).focus(function () {
                   var thisCalendar = $(this);
                   $('.ui-datepicker-month').hide();
                   $('.ui-datepicker-calendar').detach();
                   $('.ui-datepicker-close').click(function () {
                       var month = $("#ui-datepicker-div .ui-datepicker-month :selected").val();
                       var year = $("#ui-datepicker-div .ui-datepicker-year :selected").val();
                       thisCalendar.datepicker('setDate', new Date(year, 1));
                   });
               });
           });


    </script>
   
    <section class="content-header">
          <h1>
             Transport  Information
            <small>Administration</small> 

          </h1> <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Administration</a></li>
            <li class="active">Add Transport Details</li>
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
          <div class="box collapsed-box">
            <div class="box-header with-border">
              <h3 class="box-title"><asp:Label runat="server" ID="lblHeaderTab" Text="Add Transport Details"></asp:Label></h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-plus"></i></button>
                
              </div>
            &nbsp;</div>
            <div class="box-body">
               
              
                      <asp:UpdatePanel runat="server" ID="upMain" UpdateMode="Conditional">
                    <ContentTemplate>           
        
               <div class="box box-solid box-default" style="margin-bottom:5px !important;" >
        <div class="box-header" style="padding:0px 0px 0px 10px !important">
          <h3 class="box-title"> Transport Information </h3>
        </div><!-- /.box-header -->
        <div class="box-body">
             <div class="box box-solid box-default" style="margin-bottom:5px !important;" >
        <div class="box-header" style="padding:0px 0px 0px 10px !important">
          <h3 class="box-title"> Vehicle Information </h3>
        </div><!-- /.box-header -->
        <div class="box-body">

            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-car"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtVehicleNo" class="form-control" placeholder="VehicleNo" runat="server" required ToolTip="Enter VehicleNo"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div>  

      
              <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                     <i class="fa fa-car"></i><span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:DropDownList ID="dpVehicleBrand" class="form-control" DataTextField="Name" DataValueField="tr_brand_Id" runat="server" selected AutoPostBack="true" OnSelectedIndexChanged="dpVehicleBrand_SelectedIndexChanged" ToolTip="Select Vehicle Brand" > 
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->
                         </div>

       
               <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                    <i class="fa fa-car"></i><span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:DropDownList ID="dpVeh_Model" class="form-control" DataTextField="Name" DataValueField="tr_model_Id" runat="server"  ToolTip="Select Vehicle Model" > 
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->
                         </div>
          

              <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-car"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtVeh_Year" class="form-control" placeholder="Vehicle Year" runat="server" required ToolTip="Enter Vehicle Year"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div>  


     
            
            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                     <i class="fa fa-car"></i><span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:DropDownList ID="dpVeh_Type" class="form-control" DataTextField="Name" DataValueField="ID" runat="server" ToolTip="Select Vehicle Type"  > 
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->
                         </div>

            
              <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-registered"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtVeh_Reg" class="form-control" placeholder="Vehicle Reg"  runat="server"  required ToolTip="Vehicle Reg" ></asp:TextBox>                        
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->

                     
                       
                          
                      </div>  
        
               <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-car"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtVeh_ChassisNo" class="form-control" placeholder="Vehicle ChassisNo"  runat="server" required ToolTip="Enter Vehicle ChassisNo"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

              </div>

            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-car"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtVeh_EngineNo" class="form-control" placeholder="Vehicle EngineNo"  runat="server" required ToolTip="Enter Vehicle EngineNo"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

              </div>

       <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-car"></i><span style="color:red">&nbsp;*</span>
                      </div>
                      <%-- <asp:TextBox ID="txtVeh_FuelType" class="form-control" placeholder="Vehicle FuelType"  runat="server" required ToolTip="Enter Vehicle FuelType"></asp:TextBox>   --%>                     
                   <asp:DropDownList ID="dpVeh_FuelType" class="form-control" DataTextField="Name" DataValueField="ID" runat="server" ToolTip="Select Vehicle Fuel Type">
                       </asp:DropDownList></div><!-- /.input group --> 

                  </div><!-- /.form group -->

              </div>

              </div><!-- /.box-body -->
      </div>
              <div class="box box-solid box-default" style="margin-bottom:5px !important;" >
        <div class="box-header" style="padding:0px 0px 0px 10px !important">
          <h3 class="box-title"> Vehicle Insurance Information </h3>
        </div><!-- /.box-header -->
        <div class="box-body">

               <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                      <i class="fa fa-car"></i><span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:DropDownList ID="dpVeh_InsProvider" class="form-control" DataTextField="Name" DataValueField="ID" runat="server" ToolTip="Select Insurance Provider "  > 
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->
                         </div>

             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-car"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtVeh_InsPolicyNo" class="form-control" placeholder="Vehicle InsPolicyNo"  runat="server" required ToolTip="Enter Vehicle InsPolicyNo"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

              </div>

           <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-car"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtVeh_InsStart" class="form-control" placeholder="Vehicle Insurance Start Date"  runat="server" type="date" required ToolTip="Enter Vehicle Insurance Start Date"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

              </div>

            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-car"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtVeh_InsLast" class="form-control" placeholder="Vehicle Insurance Last date"  runat="server" type="date" required ToolTip="Enter Vehicle Insurance Last date"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
                 <asp:CompareValidator ID="CompareValidator2" ValidationGroup = "Save" ForeColor = "Red" runat="server" ControlToValidate = "txtVeh_InsStart" ControlToCompare = "txtVeh_InsLast" Operator = "LessThan" Type = "Date" ErrorMessage=" Insurance Start date must be less than End date."></asp:CompareValidator>
              </div>


              <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-car"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtInsAmount" class="form-control" placeholder="Vehicle Insurance Amount"  runat="server"   ToolTip="Enter Vehicle Insurance Amount"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

              </div>

            </div><!-- /.box-body -->
      </div>


            <div class="box box-solid box-default" style="margin-bottom:5px !important;" >
        <div class="box-header" style="padding:0px 0px 0px 10px !important">
          <h3 class="box-title"> Vehicle Owner Information </h3>
        </div><!-- /.box-header -->
        <div class="box-body">
            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-car"></i><span style="color:red">&nbsp;*</span>
                      </div>
                   <asp:DropDownList ID="dpVeh_OwnershipType" class="form-control" DataTextField="Name" DataValueField="ID" runat="server" ToolTip="Select Vehicle OwnershipType" > 
                       </asp:DropDownList>

                  </div><!-- /.form group -->

              </div>
                   </div>
            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-car"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtVeh_OwnerName" class="form-control" placeholder="Vehicle OwnerName"  runat="server" required ToolTip="Enter Vehicle OwnerName"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

              </div>

            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-car"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtVeh_ContactNo" class="form-control" placeholder="Vehicle ContactNo"  runat="server" required ToolTip="Enter Vehicle ContactNo"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

              </div>

            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-car"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtVeh_OwnerAddress" class="form-control" placeholder="Vehicle OwnerAddress"  runat="server" required ToolTip="Enter Vehicle OwnerAddress" TextMode="MultiLine"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

              </div>

              <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-car"></i><span style="color:red">&nbsp;*</span>
                      </div>
                   <asp:DropDownList ID="dpBank" class="form-control" DataTextField="Name" DataValueField="ID" runat="server" ToolTip="Select Bank">
                       </asp:DropDownList></div><!-- /.input group --> 

                  </div><!-- /.form group -->

              </div>

             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-car"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtBankAc" class="form-control" placeholder="Vehicle Owner Bank A/C Number"  runat="server"  ToolTip="Enter Vehicle Owner Bank A/C Number" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

              </div>


        
            </div><!-- /.box-body -->
      </div>

              <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:DropDownList ID="dpIsActive" class="form-control" runat="server" selected ToolTip="Select Type Status">
                           <asp:ListItem Value="0">---Status---</asp:ListItem>
                           <asp:ListItem Value="1">Active</asp:ListItem>
                           <asp:ListItem Value="2">De-Active</asp:ListItem> 
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 


             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      
                    
                      
                        <asp:Button ID="btnAddTransportInfo" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Add" ValidationGroup="Save" OnClick="btnAddTransportInfo_click" /> &nbsp;    
                        <asp:Button ID="btnupdateTransportdetail" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Update" ValidationGroup="Save" OnClick="btnupdateTransportdetail_click" />           
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 


              
        </div><!-- /.box-body -->
      </div>
                     
                    </ContentTemplate>
                </asp:UpdatePanel>
                 
                
            </div><!-- /.box-body -->            
          </div>
        <section>
    
          

   
    <div class="box ">
            <div class="box-header with-border">
              <h3 class="box-title"> Transport Information List </h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-minus"></i></button>
                
              </div>
            </div>
            <div class="box-body" id="datalist">
                   
                
                       

                                <asp:UpdatePanel runat="server" ID="uprouteList" UpdateMode="Conditional">
                    <ContentTemplate>

                <table id="example1" class="table table-bordered table-striped">
                   

                 
                      <asp:Repeater ID="rpTransportList" runat="server" OnItemCommand="rpTransportList_ItemCommand">
                
                
               <HeaderTemplate>
                  <thead>
                      <tr>
                                        <th>TransID</th>
                                        <th>Number</th>
                                        
                                        <th>Brand</th>
                                        <th>Model</th>
                                         
                                        <th>Type</th>
                                        
                                        <th>Reg.No</th>
                                       
                                        
                                        <th>Ins.Paid</th>
                                        
                                        <th>Ins.Due</th>
                                        <th>OwnerShip</th>
                                     
                                        <th>Fuel</th>
                                        <th>IsActive</th>
                                      <%--    <th>User</th>--%>
                                        <th>Date</th>
                                          <th>Edit</th>
                            <th>Delete</th>
                                       
                          
                      </tr>
                    </thead>
                    <tbody>

                   
               </HeaderTemplate>
               <ItemTemplate>
                    <tr>
                            


                                        <td><%# Eval("TM_Id")%></td>
                                        <td><%# Eval("VehicleNo")%></td>    
                                        <td><%# Eval("tr_brand_name")%></td>
                                        <td><%# Eval("tr_model_name")%></td>
                        
                                  
                                        <td><%# Eval("Veh_Type")%></td>    
                                        <td><%# Eval("Veh_Reg")%></td>
                                  
                                      
                                        <td><%# Eval("Veh_InsStart")%></td>
                    
                                        <td><%# Eval("Veh_InsLast")%></td>
                                        <td><%# Eval("Veh_OwnershipType")%></td>    
                                       
                                        <td><%# Eval("CONFIGVALUE")%></td>    
                                        <td><%# Eval("IsActive")%></td>
                                    <%--    <td><%# Eval("Veh_CreateUser")%></td>--%>
                                        <td><%# Eval("Veh_CreateUserDate")%></td>
                                       
                                        
                                      
                                        
                         
                         <td>
                             <asp:LinkButton ID="lbEdite" AlternateText="Edit" ForeColor="Gray" OnItemCommand="lbEdite_ItemCommand" 
                                                                    ToolTip="Edit" runat="server" CommandArgument='<%#Eval("TM_Id") %>'
                                                                    CommandName="Edit"><i class="fa fa-edit"></i></asp:LinkButton>

                         </td>
                         <td>   <asp:LinkButton ID="lbdelete" AlternateText="delete" ForeColor="Gray" OnItemCommand="lbdelete_ItemCommand" 
                                                                    ToolTip="Delete" runat="server" CommandArgument='<%#Eval("TM_Id") %>'
                                                                    CommandName="delete"><i class="fa fa-trash"></i></asp:LinkButton>
</td>



                    </tr>
               </ItemTemplate>
                    <FooterTemplate>

                         </tbody>

                    <tfoot>
                      <tr>
                                       <th>TransID</th>
                                        <th>Number</th>
                                        
                                        <th>Brand</th>
                                        <th>Model</th>
                                         
                                        <th>Type</th>
                                        
                                        <th>Reg.No</th>
                                       
                                        
                                            <th>Ins.Paid</th>
                                        
                                        <th>Ins.Due</th>
                                        <th>OwnerShip</th>
                                     
                                        <th>Fuel</th>
                                         <th>IsActive</th>
                                       <%--   <th>User</th>--%>
                                        <th>Date</th>
                          <th>Edit</th>
                            <th>Delete</th>
                                      
                                        
                      </tr>
                    </tfoot>

                    </FooterTemplate>
                                          </asp:Repeater>    
          
                    <asp:HiddenField id="htransId" runat="server" />
             
                
                  
                     
                   
                  </table>
             </section>
                
                        </ContentTemplate>
                                              </asp:UpdatePanel>
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
                                      .attr('placeholder', 'gg/mm/aaaa')
                                      .attr('autocomplete', 'off')
                                      .prop('readonly', true)
                                      .after('<input type="text" class="altfield" id="' + prefix + this.attr('id') + '" name="' + this.attr('name') + '" value="' + _val + '">')
                                      .removeAttr('name')
                                      .val('')
                                      .datepicker({
                                          altField: '#' + prefix + _this.attr('id'),
                                          dateFormat: 'dd/mm/yy',
                                          altFormat: 'dd/mm/yy'
                                      });



                                      if (_val) {
                                          this.datepicker('setDate', $.datepicker.parseDate('dd/mm/yy', val));
                                      };
                                  });


                                  // min attribute
                                  $('input[type="date"][min]').each(function () {
                                      var _this = $(this);
                                      this.datepicker("option", "minDate", $.datepicker.parseDate('dd/mm/yy', this.attr('min')));
                                  });

                                  // max attribute
                                  $('input[type="date"][max]').each(function () {
                                      var _this = $(this);
                                      this.datepicker("option", "maxDate", $.datepicker.parseDate('dd/mm/yy', this.attr('max')));
                                  });
                              }
                          }
                      }); // end Modernizr.load
        </script>
</asp:Content>
