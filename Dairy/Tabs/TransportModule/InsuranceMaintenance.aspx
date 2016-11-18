<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InsuranceMaintenance.aspx.cs" Inherits="Dairy.Tabs.TransportModule.InsuranceMaintenance" %>
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

    <script type="text/ecmascript">
        document.getElementById("test").click();

        </script>


      <section class="content-header">
          <h1>
          Insurance Maintenance
            <small>Administration</small>
          </h1>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Administration</a></li>
            <li class="active">Add Insurance Maintenance</li>
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
              <div  class="box collapsed-box">
            <div class="box-header with-border">
              <h3 class="box-title"><asp:Label runat="server" ID="lblHeaderTab" Text="Add Insurance Maintenance"></asp:Label></h3>
              <div class="box-tools pull-right">
                <button   class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-plus"></i></button>
                
              </div>
            </div>
            <div class="box-body">
               
              
                      <asp:UpdatePanel runat="server" ID="upMain" UpdateMode="Conditional">
                    <ContentTemplate>           
        
             

                           <div class="box box-solid box-default" style="margin-bottom:5px !important;" >
        <div class="box-header" style="padding:0px 0px 0px 10px !important">
          <h3 class="box-title"> Insurance Maintenance</h3>
        </div><!-- /.box-header -->
        <div class="box-body">
          

              <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                            <asp:DropDownList ID="dpVehicleNo" class="form-control" DataTextField="VehicleNo" DataValueField="TM_Id"  AutoPostBack="true" OnSelectedIndexChanged="dpVehicleNo_IndexChanged"  runat="server" ToolTip="Select Vehicle"  > 
                       </asp:DropDownList>     
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator4" Display="Dynamic" 
    ValidationGroup="Save" runat="server" ControlToValidate="dpVehicleNo" ForeColor="Red"
    ErrorMessage="Please Select Vehicle"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
                   
                     
                       
                          
                      </div> 
               
              <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
      <asp:DropDownList ID="dpVeh_InsProvider" class="form-control" DataTextField="Name" DataValueField="ID" runat="server" ToolTip="Select Insurance Provider" > 
                       </asp:DropDownList>     
                    </div><!-- /.input group -->
                       <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator5" Display="Dynamic" 
    ValidationGroup="Save" runat="server" ControlToValidate="dpVeh_InsProvider" ForeColor="Red"
    ErrorMessage="Please Select Insurance Provider"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 

                  
              <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
<asp:DropDownList ID="dpVeh_InsPolicyNo" class="form-control" DataTextField="Name" DataValueField="TM_Id" runat="server" ToolTip="Select Insurance PolicyNo." > 
                       </asp:DropDownList>                   
                    </div><!-- /.input group -->
<asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator6" Display="Dynamic" 
    ValidationGroup="Save" runat="server" ControlToValidate="dpVeh_InsPolicyNo" ForeColor="Red"
    ErrorMessage="Please Select PolicyNumber"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 
           

               <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
            <asp:TextBox ID="txtInsuransepaidDate"  type="date"  class="form-control"  ToolTip="Enter Premium Paid Date"  placeholder="Premium Paid Date" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtInsuransepaidDate"
        ErrorMessage="Premium Paid Date is required" ValidationGroup="Save" ForeColor="Red" ></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 
             


               <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                              <asp:TextBox ID="txtnextinspaiddate"  type="date"  class="form-control"  ToolTip="Enter Next Premium  Due Date"  placeholder="Next Premium  Due Date" runat="server" ></asp:TextBox>                        
            
                    </div><!-- /.input group -->
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtnextinspaiddate"
        ErrorMessage="Next Premium  Due Date is required" ValidationGroup="Save" ForeColor="Red" ></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->

                     
                         <asp:CompareValidator ID="CompareValidator2" ValidationGroup = "Save" ForeColor = "Red" runat="server" ControlToValidate = "txtInsuransepaidDate" ControlToCompare = "txtnextinspaiddate" Operator = "LessThan" Type = "Date" ErrorMessage="Start date must be less than End date."></asp:CompareValidator>
                          
                      </div> 
          

              <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
            <asp:TextBox ID="txtVehicleInsuraceAmt" class="form-control"  ToolTip="Enter Vehicle Insurance Amount"  placeholder="Insurance Amount" runat="server" type="number"></asp:TextBox>                        
                 
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtVehicleInsuraceAmt"
        ErrorMessage="Vehicle Insurance Amount is required" ValidationGroup="Save" ForeColor="Red"></asp:RequiredFieldValidator>
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

                <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      
                  
                      
                              <asp:Button ID="btnAddVehicleMaintenanceCost" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Add" ValidationGroup="Save" OnClick="btnClick_btnAddVehicleMaintenanceCost"  />   &nbsp;  
                        <asp:Button ID="btnUpdateMaintenanceCost" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Update" ValidationGroup="Save" OnClick="btnClick_btnUpdateMaintenanceCost" />           
                  &nbsp;&nbsp; &nbsp;   <asp:Button ID="btnAddNew" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="AddNew"  OnClick="btnClick_btnAddNew" />                              </div><!-- /.input group -->

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
              <h3 class="box-title"> Vehicle Insurance List </h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-minus"></i></button>
                
              </div>
            </div>
            <div class="box-body" id="datalist">
                   
                
                       

                                <asp:UpdatePanel runat="server" ID="uprouteList" UpdateMode="Conditional">
                    <ContentTemplate>

                <table id="example1" class="table table-bordered table-striped">
                   

                 

                <asp:Repeater ID="rpmaintenanceInfo" runat="server" OnItemCommand="rpRouteList_ItemCommand">
                
               <HeaderTemplate>
                  <thead>
                      <tr>
                           <th>ID</th>
                         
                         <th>VehicleNo.</th>
                          
                         
                           <th>Insurance Paid Date</th>
                              <th>Insurance Due Date</th>
                           
                              <th>Ins.Amount</th>
                            <th>IsActive</th>
                           <th>Edit</th>
                            
                   
                      </tr>
                    </thead>
                    <tbody>

                   
               </HeaderTemplate>
               <ItemTemplate>
                    <tr>
                         <td><%# Eval("ID")%></td>
                      <td><%# Eval("VehicleNo")%></td>
                       
                         <td><%# Eval("InspaidDate")%></td>
                             <td><%#Eval("Insnextduedate")%></td>
                           
                        <td><%# string.Format("{0:#.00}", Eval("InsuranceAmt"))%></td>
                       

                         <td><%# Eval("IsActive")%></td>
                    
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
                          <th>ID</th>
                         
                         <th>VehicleNo.</th>
                          
                         
                           <th>Insurance Paid Date</th>
                              <th>Insurance Due Date</th>
                           
                              <th>Ins.Amount</th>
                            <th>IsActive</th>
                           <th>Edit</th>
                            
                      </tr>
                    </tfoot>

                    </FooterTemplate>
                                             
           </asp:Repeater>
                    <asp:HiddenField id="hfID" runat="server" />
             
                
                  
                     
                   
                  </table>
               
                
                        </ContentTemplate>
                </asp:UpdatePanel>
  

            


 


            </div><!-- /.box-body -->            
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
