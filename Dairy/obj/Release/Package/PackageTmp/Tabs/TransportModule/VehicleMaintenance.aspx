<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VehicleMaintenance.aspx.cs" Inherits="Dairy.Tabs.TransportModule.VehicleMaintenance" Culture = "en-GB" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
  <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
  
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
          Vehicle Maintenance
            <small>Administration</small>
          </h1>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Administration</a></li>
            <li class="active">Add Vehicle Maintenance</li>
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
              <h3 class="box-title"><asp:Label runat="server" ID="lblHeaderTab" Text="Add Vehicle Maintenance"></asp:Label></h3>
              <div class="box-tools pull-right">
                <button   class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-plus"></i></button>
                
              </div>
            </div>
            <div class="box-body">
               
              
                      <asp:UpdatePanel runat="server" ID="upMain" UpdateMode="Conditional">
                    <ContentTemplate>           
        
               <div class="box box-solid box-default" style="margin-bottom:5px !important;" >
        <div class="box-header" style="padding:0px 0px 0px 10px !important">
          <h3 class="box-title"> Vehicle Maintenance</h3>
        </div><!-- /.box-header -->
        <div class="box-body">

          

         

                <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                            <asp:DropDownList ID="dpVehicleNo" class="form-control" DataTextField="VehicleNo" DataValueField="TM_Id"    runat="server" ToolTip="Select Vehicle"  > 
                       </asp:DropDownList>     
                    </div><!-- /.input group -->
                          <asp:CompareValidator ID="CompareValidator" runat="server" ControlToValidate="dpVehicleNo"
        ErrorMessage="Vehicle No. is Required" Operator="NotEqual" ValidationGroup="Save" ForeColor="Red"
        ValueToCompare="0" ></asp:CompareValidator>
                  </div><!-- /.form group -->
                   
                     
                       
                          
                      </div> 
        

               <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:DropDownList ID="dpMaintenanceType" class="form-control" DataTextField="Name" DataValueField="ID" runat="server" ToolTip="Select Maintenance Type" > 
                       </asp:DropDownList>                        
                    </div><!-- /.input group -->
 <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="dpMaintenanceType"
        ErrorMessage="Maintenance Selection is Required" Operator="NotEqual" ValidationGroup="Save" ForeColor="Red"
        ValueToCompare="0" ></asp:CompareValidator>
                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 

           

              <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
            <asp:TextBox ID="txtDescription" class="form-control"  ToolTip="Enter Maintenance Description" placeholder="Description" runat="server" TextMode="MultiLine"></asp:TextBox>                        
                 
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 


               <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
            <asp:TextBox ID="txtmaintenancegivendate"  type="date" class="form-control"   ToolTip="Enter Maintenance Given Date" placeholder="Maintenance Given Date" runat="server" ></asp:TextBox>                        
                 
                    </div><!-- /.input group -->
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtmaintenancegivendate"
        ErrorMessage="Maintenance Given Date is required" ValidationGroup="Save" ForeColor="Red" ></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 
                  

               <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
            <asp:TextBox ID="txtmaintenancenextdate" type="date"  class="form-control"  ToolTip="Enter  Next Maintenance Date"  placeholder="Next Maintenance  Date" runat="server" ></asp:TextBox>                        
                 
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtmaintenancenextdate"
        ErrorMessage="Next Maintenance Date" ValidationGroup="Save" ForeColor="Red" ></asp:RequiredFieldValidator>

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 
               

                 <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
            <asp:TextBox ID="txtMaintenanceAmt" class="form-control"  ToolTip="Enter Maintenance Amount"  placeholder="Maintenance Amount" runat="server" type="number"></asp:TextBox>                        
                 
                    </div><!-- /.input group -->
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator" runat="server" ControlToValidate="txtMaintenanceAmt"
        ErrorMessage="Maintenance Amount" ValidationGroup="Save" ForeColor="Red" ></asp:RequiredFieldValidator>

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 
             <asp:CompareValidator ID="CompareValidator2" ValidationGroup = "Save" ForeColor = "Red" runat="server" ControlToValidate = "txtmaintenancegivendate" ControlToCompare = "txtmaintenancenextdate" Operator = "LessThan" Type = "Date" ErrorMessage="Start date must be less than End date."></asp:CompareValidator>
 
                 <%--  <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:DropDownList ID="dpIsActive" class="form-control" runat="server" selected ToolTip="Select Unit Status">
                           <asp:ListItem Value="0">---Type Status---</asp:ListItem>
                           <asp:ListItem Value="1">Active</asp:ListItem>
                           <asp:ListItem Value="2">De-Active</asp:ListItem> 
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->

                     
                       
                          
                      </div>  --%>
               

                   

              <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      
                  
                      
                              <asp:Button ID="btnAddVehicleMaintenanceCost" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Add" ValidationGroup="Save" OnClick="btnClick_btnAddVehicleMaintenanceCost"  />   &nbsp;  
                        <asp:Button ID="btnUpdateMaintenanceCost" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Update" ValidationGroup="Save" OnClick="btnClick_btnUpdateMaintenanceCost" />           
                      &nbsp;&nbsp; &nbsp;   <asp:Button ID="btnAddNew" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="AddNew"  OnClick="btnClick_btnAddNew" />     

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
              <h3 class="box-title"> Vehicle Maintenance List </h3>
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
                          
                            <th>Maint.Type</th>
                            <th>Description</th>
                            <th>Maint.GivenDate</th>
                          <th>NextMaint.Date</th>
                              <th>Maint.Amount</th>
                        
                     <%--     <th>IsActive</th>--%>
                           <th>Edit</th>
                            
                   
                      </tr>
                    </thead>
                    <tbody>

                   
               </HeaderTemplate>
               <ItemTemplate>
                    <tr>
                         <td><%# Eval("ID")%></td>
                      <td><%# Eval("VehicleNo")%></td>
                           <td><%# Eval("CONFIGVALUE")%></td>
                        <td><%# Eval("M_Description")%></td>
                            <td><%# Eval("DateGiven")%></td>
                            <td><%# Eval("NextMaintainenceDate")%></td>
                           <td><%# string.Format("{0:##,###.##}", Eval("MaintanceCost"))%></td>
                         
                      
                       

                      <%--   <td><%# Eval("IsActive")%></td>--%>
                    
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
                          
                            <th>Maint.Type</th>
                            <th>Description</th>
                            <th>Maint.GivenDate</th>
                          <th>NextMaint.Date</th>
                              <th>Maint.Amount</th>
                        
                    <%--      <th>IsActive</th>--%>
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
