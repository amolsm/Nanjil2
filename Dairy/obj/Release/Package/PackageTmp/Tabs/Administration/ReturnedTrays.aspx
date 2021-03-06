﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReturnedTrays.aspx.cs" Inherits="Dairy.Tabs.Administration.ReturnedTrays" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
   <link href="../../Theme/plugins/jQueryUI/jquery-ui.css" rel="stylesheet" />
    <script src="../../Theme/plugins/jQuery/jquery-1.10.2.min.js"></script>
    <script src="../../Theme/plugins/jQueryUI/jquery-ui.min.js"></script>
      <script type="text/javascript" src="/bower_components/bootstrap/dist/js/bootstrap.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  
   
    <section class="content-header">
          <h1>
             Manage Returned Items
          </h1>

          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Dispatch</a></li>
            <li class="active">Manage Returned Items</li>
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
             <div class="box collapsed-box" id ="myBox">
            <div class="box-header with-border">
              <h3 class="box-title"><asp:Label ID="lbltital" runat="server" Text="Add Returned Quantity"></asp:Label> </h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-plus"></i></button>
                
              </div>
            </div>
            <div class="box-body">
               
              
                      <asp:UpdatePanel runat="server" ID="upMain" UpdateMode="Conditional">
                    <ContentTemplate>           
        
               <div class="box box-solid box-default" style="margin-bottom:5px !important;" >
                 <div class="box-body">

                <div class="col-lg-3">
                  <div class="form-group" >
                    <div class="input-group">
                      <div class="input-group-addon">
                       <%-- <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label runat="server" Text="Trays"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtTraysReturn" class="form-control" ToolTip="Trays Return"  placeholder="Trays Return" runat="server" ValidationGroup="edit" type="number"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
    
                      </div>        <!-- --> 

                <div class="col-lg-3">
                  <div class="form-group" >
                    <div class="input-group">
                      <div class="input-group-addon">
                       <%-- <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label runat="server" Text="IceBox"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtIceBoxReturn" class="form-control" ValidationGroup="edit" ToolTip="Ice Box Return" placeholder="Ice Box Return" runat="server" type="number"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
    
                      </div>        <!-- -->

                <div class="col-lg-3">
                  <div class="form-group" >
                    <div class="input-group">
                      <div class="input-group-addon">
                       <%-- <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label runat="server" Text="Cartons"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtCartonsReturn" ToolTip="Cartons Return" class="form-control" ValidationGroup="edit"  placeholder="Cartons Return" runat="server" type="number" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
    
                      </div>        <!-- -->

                <div class="col-lg-3">
                  <div class="form-group" >
                    <div class="input-group">
                      <div class="input-group-addon">
                        <%--<i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label runat="server" Text="Others"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtOtherReturn" class="form-control" ValidationGroup="edit" ToolTip="Other Return" placeholder="Other Return" runat="server" type="number" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
    
                      </div>        <!-- -->

                     
                     

                <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                       <asp:Button ID="btnUpdate" class="btn btn-primary" ValidationGroup="edit" runat="server" CommandName="MoveNext" Text="Update" OnClick="btnClick_btnUpdate"/>     
                       
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 

                <div class="col-lg-3">
                  <div class="form-group" >
                    <div class="input-group">
                      <asp:TextBox ID="txtHidden" class="form-control" Visible="false" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
    
                      </div>        <!-- -->
                
                     
                      </div><!-- /.box-body -->
                </div>
                     
                    </ContentTemplate>
                </asp:UpdatePanel>
                 
                
            </div><!-- /.box-body -->            
          </div><!-- /.box -->

               <div class="box ">
            <div class="box-header with-border">
                <h3 class="box-title"> Dispatch List </h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-minus"></i></button>
                
              </div>
            </div>
           
                       
        
               <div class="box-body">
               
              
                      <asp:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Conditional">
                    <ContentTemplate>           
        
               <div class="box  box-default" style="margin-bottom:5px !important;" >
        <div class="box-header" style="padding:0px 0px 0px 10px !important">
          
        </div><!-- /.box-header -->
        <div class="box-body">

             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtDispatchId" class="form-control"   placeholder="Dispatch Id" ToolTip="Dispatch Id" runat="server" required ValidationGroup="search" type="number"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 

            

           <%-- <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <i class="fa fa-rode"></i><span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:DropDownList ID="dpagentRoute" ValidationGroup="search" class="form-control" DataTextField="Name" DataValueField="RouteID" runat="server"  > 
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->
                         </div>--%>

             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <asp:Button ID="Button1" class="btn btn-primary" ValidationGroup="search" runat="server" CommandName="MoveNext" Text="Search" OnClick="btnClick_btnSearch" />     
                       
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 
            
            <%--<div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <asp:Button ID="btnSubmitModal" class="btn btn-primary" runat="server" Text="Submit" data-toggle="modal" data-target="#myModal" />     
                    <button id="btnSubmitModal" runat="server" type="button" class="btn btn-primary btn-lg" data-toggle="modal" data-target="#myModal" OnClick="btnSubmit_Click" >
                        Submit
                        </button>
                        <asp:Button ID="btnPrintSummary" class="btn btn-primary" runat="server" CommandName="MoveNext" Text="Print" OnClientClick="return PrintPanel();" />
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
            </div> --%>
                

            <!-- Bootstrap Modal Dialog -->
        <!-- Button trigger modal -->


<!-- Modal -->
<div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title" id="myModalLabel">Submit Dispatch</h4>
      </div>
      <div class="modal-body">
          <div class="box-body">
              <div class="col-lg-6">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <i class="fa fa-rode"></i><span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:DropDownList ID="dpSalesman" ValidationGroup="none" class="form-control" DataTextField="Name" DataValueField="EmployeeID" runat="server"  > 
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->
                         </div>

              <div class="col-lg-6">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <i class="fa fa-rode"></i><span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:DropDownList ID="dpSalesman2" ValidationGroup="none" class="form-control" DataTextField="Name" DataValueField="EmployeeID" runat="server"  > 
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->
                         </div>

              <div class="col-lg-6">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <i class="fa fa-rode"></i><span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:DropDownList ID="dpDriver" ValidationGroup="none" class="form-control" DataTextField="Name" DataValueField="DriverId" runat="server"  > 
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->
                         </div>

              <div class="col-lg-6">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <i class="fa fa-rode"></i><span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:DropDownList ID="dpDriver2" ValidationGroup="none" class="form-control" DataTextField="Name" DataValueField="DriverId" runat="server"  > 
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->
                         </div>

              <div class="col-lg-6">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <i class="fa fa-rode"></i><span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:DropDownList ID="dpVehicle" ValidationGroup="none" class="form-control" DataTextField="Name" DataValueField="TM_Id" runat="server"  > 
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->
                         </div>

              <div class="col-lg-6">
                  <div class="form-group" >
                    <div class="input-group">
                      <div class="input-group-addon">
                       <i class="fa fa-rode"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtTraysDispached" ValidationGroup="none" class="form-control" Type="number"  ToolTip="Trays Dispatched" placeholder="Trays Dispatched" runat="server"  ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
    
                      </div>        <!-- -->

              <div class="col-lg-6">
                  <div class="form-group" >
                    <div class="input-group">
                      <div class="input-group-addon">
                       <i class="fa fa-rode"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtIceBox" ValidationGroup="none" class="form-control" Type="number"  ToolTip="Ice Box Dispatched" placeholder="Ice Box Dispatched" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
    
                      </div>        <!-- -->

              <div class="col-lg-6">
                  <div class="form-group" >
                    <div class="input-group">
                      <div class="input-group-addon">
                       <i class="fa fa-rode"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtCartons" ValidationGroup="none" class="form-control" Type="number"  ToolTip="Cartons/Ice Pads Dispatched" placeholder="Cartons/Ice Pads Dispatched" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
    
                      </div>        <!-- -->

              <div class="col-lg-6">
                  <div class="form-group" >
                    <div class="input-group">
                      <div class="input-group-addon">
                       <i class="fa fa-rode"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtOthers" ValidationGroup="none" class="form-control" Type="number" ToolTip="Others Dispatched" placeholder="Others Dispatched" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
    
                      </div>        <!-- -->

            </div>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
        <%--<button type="button" class="btn btn-primary" >Save changes</button>--%>
          <asp:Button ID="btnSubmit" class="btn btn-primary" runat="server" ValidationGroup="saved" OnClick="btnSubmit_Click" Text="Save changes" UseSubmitBehavior="false" data-dismiss="modal"/>     
      </div>
    </div>
  </div>
</div>
             


              
        </div><!-- /.box-body -->
      </div>
                     
                    </ContentTemplate>
                </asp:UpdatePanel>
                 
                
            </div><!-- /.box-body --> 
                     
                    
                       
                <div class="box-body" id="datalist">

                <asp:UpdatePanel runat="server" ID="uprouteList" UpdateMode="Conditional">
                    <ContentTemplate>

                <table id="example1" class="table table-bordered table-striped">
                   

                 

                <asp:Repeater ID="rpRouteList" runat="server" OnItemCommand="rpRouteList_ItemCommand">
                
               <HeaderTemplate>
                  <thead>
                      <tr>
                          <th>Dispatch ID</th>
                          <th>Trays Dispatched</th>
                          <th>Trays Returned</th>
                          <th>IceBox Dispatched</th>                        
                          <th>IceBox Returned</th>
                          <th>Cartons Dispatched</th>
                          <th>Cartons Returned</th>
                          <th>Other Dispatched</th>
                          <th>Other Returned</th>
                          
                      </tr>
                    </thead>
                    <tbody>

                   
               </HeaderTemplate>
               <ItemTemplate>
                    <tr>
                        <td>DS<%# Eval("DI_Id")%></td>
                        <td><%# Eval("TraysDispached")%></td>
                        <td><%# Eval("TraysReturned")%></td>
                        <td><%# Eval("IceBoxDispached")%></td>
                        <td><%# Eval("IceBoxReturned")%></td>
                        <td><%# Eval("CartonsDispached")%></td>
                        <td><%# Eval("CartonsReturned")%></td>
                        <td><%# Eval("OtherDispached")%></td>
                        <td><%# Eval("OtherReturned")%></td>
                        <td>

                             <asp:LinkButton ID="lbEdite" AlternateText="Edit" ForeColor="Gray" OnItemCommand="lbEdite_ItemCommand" 
                                                                    ToolTip="Edit" runat="server" CommandArgument='<%#Eval("DI_Id") %>'
                                                                    CommandName="Edit"><i class="fa fa-edit"></i></asp:LinkButton>

                         </td>
                         
                    </tr>
               </ItemTemplate>
                    <FooterTemplate>
                          <tr id="trEmpty" runat="server" visible="false"><td  align = "left" colspan="9"><h5> Return Tray Process is completed for this Dispatch ID Or No records found. Please contact Admin.</h5></td> </tr>
                         </tbody>

                    <tfoot>
                      <tr>
                          <th>Dispatch ID</th>
                          <th>Trays Dispatched</th>
                          <th>Trays Returned</th>
                          <th>IceBox Dispatched</th>                        
                          <th>IceBox Returned</th>
                          <th>Cartons Dispatched</th>
                          <th>Cartons Returned</th>
                          <th>Other Dispatched</th>
                          <th>Other Returned</th>
                      </tr>
                    </tfoot>

                    </FooterTemplate>
                                             
           </asp:Repeater>
                    <asp:HiddenField id="hfRow" runat="server" />
             
                
                  
                     
                   
                  </table>
               
                
                        </ContentTemplate>
                </asp:UpdatePanel>
  
                <asp:UpdatePanel runat="server" ID="upDispatchSummary" UpdateMode="Conditional">
                    <ContentTemplate>
                    <asp:Panel runat="server" ID="pnlDispatchSummary">
                        <asp:Literal runat="server" ID="DispatchSummary"></asp:Literal>
              </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>
            


 


            </div><!-- /.box-body -->            
          </div><!-- /.box -->
        </section>
    
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
                 // $("[id$=txtOrderDate]").datepicker({ format: 'dd-MM-yyyy' });
             });
         }
    </script>
    <script type="text/javascript">

        $(function () {
            //$("#MainContent_txtOrderDate").datepicker({ dateFormat: 'dd/mm/yy' });
            // $("#MainContent_txtEmployeeOrderDate").datepicker({ dateFormat: 'dd/mm/yy' });
            // $("#MainContent_txtCustamerorderDate").datepicker({ dateFormat: 'dd/mm/yy' });
            $('#myModal').on('shown.bs.modal', function () {
                $('#myInput').focus()
            })
        })
    </script>
    <script type = "text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("<%=pnlDispatchSummary.ClientID %>");
            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write("<html> <head> <style type='text/css'>.style1{border-collapse:collapse;}</style>");
            printWindow.document.write('</head><body >');
            printWindow.document.write(panel.innerHTML);
            printWindow.document.write('</body></html>');
            printWindow.document.close();
            setTimeout(function () {
                printWindow.print();
            }, 500);
            return false;
        }
    </script>
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