<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditReturnedTrays.aspx.cs" Inherits="Dairy.Tabs.Administration.EditReturnedTrays" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  
   
    <section class="content-header">
          <h1>
             Edit Returned Trays
          </h1>

          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Dispatch</a></li>
            <li class="active">Manage Returned Trays</li>
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
                       <asp:TextBox ID="txtTraysReturn" class="form-control" ToolTip="Trays Return"  placeholder="Trays Return" runat="server" ValidationGroup="edit" type="number" min="0" ></asp:TextBox>                        
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
                       <asp:TextBox ID="txtIceBoxReturn" class="form-control" ValidationGroup="edit" ToolTip="Ice Box Return" placeholder="Ice Box Return" runat="server" type="number" min="0"></asp:TextBox>                        
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
                       <asp:TextBox ID="txtCartonsReturn" ToolTip="Cartons Return" class="form-control" ValidationGroup="edit"  placeholder="Cartons Return" runat="server" type="number" min="0"></asp:TextBox>                        
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
                       <asp:TextBox ID="txtOtherReturn" class="form-control" ValidationGroup="edit" ToolTip="Other Return" placeholder="Other Return" runat="server" type="number" min="0"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
    
                      </div>        <!-- -->

                     
                     

                <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                       <asp:Button ID="btnUpdate" class="btn btn-primary" ValidationGroup="edit" runat="server" CommandName="MoveNext" Text="Update" OnClick="btnUpdate_Click"/>     
                       
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

            

        

             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <asp:Button ID="btnSearch" class="btn btn-primary" ValidationGroup="search" runat="server" CommandName="MoveNext" Text="Search" OnClick="btnSearch_Click" />     
                       
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 
            
          
                

            <!-- Bootstrap Modal Dialog -->
        <!-- Button trigger modal -->



             


              
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
                          <th>Edit</th>
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
                          <th>Edit</th>
                      </tr>
                    </tfoot>

                    </FooterTemplate>
                                             
           </asp:Repeater>
                    <asp:HiddenField id="hfRow" runat="server" />
             
                
                  
                     
                   
                  </table>
               
                
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
