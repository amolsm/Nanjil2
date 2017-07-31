<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BulkOrder.aspx.cs" Inherits="Dairy.Tabs.Administration.BulkOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript"  src="../../Theme/bootstrap/js/bootstrap.min.js"></script>
     
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript"  src="../../Theme/bootstrap/js/bootstrap.min.js"></script>
        <section class="content-header">
          <h1>
             Routewise Order
            <small>Reception</small> 

          </h1>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Reception</a></li>
            <li class="active">Routewise Order</li>
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
                                <asp:Label runat="server" ID="lblSuccess" Text="Order Received Succesfully"></asp:Label>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>

                <div class="box ">
            
            <div class="box-body">
               
              
                      <asp:UpdatePanel runat="server" ID="upMain" UpdateMode="Conditional">

                    <ContentTemplate>      
                            
                        <asp:Panel runat="server" ID="pnlAgentOrder" Visible="true">                   

                          <div class="col-md-12">
                        <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtDate" class="form-control" type="date"  runat="server" required></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 

                        <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <i class="fa fa-road"></i><span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:DropDownList ID="dpRoute" class="form-control" DataTextField="Name" DataValueField="RouteID" runat="server"  > 
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->
                         </div>

                        <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <i class="fa fa-road"></i><span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:DropDownList ID="dpType" class="form-control"  runat="server"  > 
                      <asp:ListItem Text="--Select Type--" Value="0"></asp:ListItem>
                          <asp:ListItem Text="Agent" Value="1"></asp:ListItem>
                          <asp:ListItem Text="Employee" Value="2"></asp:ListItem>
                      </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->
                         </div>

                              
                    <div class="col-lg-3  pull-right">
                  <div class="form-group">
                    <div class="input-group">
                       <asp:Button ID="btnGetPreviousOrder" class="btn btn-primary" runat="server" Text="Get Previous Orders" ValidationGroup="Prv" OnClick="btnGetPreviousOrder_Click" />                    
                          &nbsp; 
                        <asp:Button ID="btnSubmit" class="btn btn-primary" runat="server" OnClick="btnSubmit_Click"  Text="Submit" ValidationGroup="Submit"  OnClientClick="return confirm('Are you sure ?');" />                
                            &nbsp; 
                        <asp:Button ID="btnRefresh" class="btn btn-primary" runat="server" OnClick="btnRefresh_Click"  Text="Refresh" ValidationGroup="none"   />                
                       
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                   </div>  

                          </div>
                    
             
                         <div class="col-md-12">
                            <%-- <asp:TextBox  ID="txtAgentId" class="form-control" AutoPostBack="true" runat="server" OnTextChanged="hfAgentAuto_Changed"  ></asp:TextBox>                        --%>
                              
                             
                             </div>
                          <div class="col-md-12" runat="server" id="divTable">
                          <table id="example1" class="table table-bordered table-striped">
          <asp:Repeater ID="rpAgentOrderdetails" runat="server" OnItemCommand="rpAgentOrderdetails_ItemCommand">
                
               <HeaderTemplate>
                  <thead>
                      <tr>
                                        <th>Agent/Employee </th>
                                        <th>Type</th>
                                        <th>Product</th>
                                       
                                        <th>Quantity</th>
                                        <th>Unit Price</th> 
                                        <th>Total</th> 
                                        <th>Edit</th>
                                       <%-- <th>Remove</th>--%>
                      </tr>
                    </thead>
                    <tbody>

                   
               </HeaderTemplate>
               <ItemTemplate>
                    <tr>
                                <td><%#  string.IsNullOrEmpty(Eval("AgentID").ToString()) ? Eval("EmployeeCode") +" "+ Eval("EmployeeName"): Eval("AgentCode") +" "+ Eval("AgentName")%></td>
                       
                                
                                <td><asp:Label ID="lblType" runat="server" Text='<%# Eval("TypeName")%>'></asp:Label></td>
                                
                                <td><%# string.IsNullOrEmpty ( Eval("ProductName").ToString()) ? "Scheme" : Eval("ProductName").ToString()  %></td>
                                <td><%# Eval("Qty")%></td>
                                <td style="text-align:right"><%# string.Format("{0:##,###.00}",Eval("UnitCost"))%></td>
                                <td style="text-align:right"><asp:Label ID="lbltotal" runat="server" Text='<%# string.Format("{0:##,###.00}",Eval("Total"))%>'></asp:Label></td>
                      
                            <td>

                             <asp:LinkButton ID="lbEdite" AlternateText="Edit" ForeColor="Gray" OnItemCommand="lbEdite_ItemCommand" 
                                                                    ToolTip="Edit" runat="server" CommandArgument='<%#Eval("Row") %>'
                                                                    CommandName="Edit"><i class="fa fa-edit"></i></asp:LinkButton>

                         </td>

                         <%--<td>   <asp:LinkButton ID="lbdelete" AlternateText="delete" ForeColor="Gray" OnItemCommand="lbdelete_ItemCommand" 
                                                                    ToolTip="Delete" runat="server" CommandArgument='<%#Eval("Row") %>'
                                                                    CommandName="delete"><i class="fa fa-trash"></i></asp:LinkButton>
</td>--%>

                      


       
                    </tr>
               </ItemTemplate>
                    <FooterTemplate>
  <tr id="trEmpty" runat="server" visible="false"><td  align = "left" colspan="10"><h5> Bulk Routewise Agent Order is completed for this Route Or No records found. Please contact Admin.</h5></td> </tr>
                         </tbody>

                    <tfoot>
                      <tr>
                          <th>Agent/Employee </th>
                                        <th>Type</th>
                                        <th>Product</th>
                                       
                                        <th>Quantity</th>
                                        <th>Unit Price</th> 
                                        <th>Total</th> 
                                        <th>Edit</th>
                                       <%-- <th>Remove</th>--%>
                      </tr>
                    </tfoot>

                    </FooterTemplate>
                                             
           </asp:Repeater>
                
           </table>
           <asp:HiddenField ID="hftotalAmout" runat="server" />
       </div> 

<asp:Literal runat="server" ID="prevorder"></asp:Literal>
                        
                    
                        
                     </asp:Panel>

                        
    
                  </ContentTemplate>
                          
                       
                </asp:UpdatePanel>  
                <asp:UpdatePanel ID="upModal" runat="server" UpdateMode="Conditional" >  
              <ContentTemplate>         
                      <!-- Modal -->
        <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title" id="myModalLabel">Edit Order Item Quantity</h4>
      </div>
      <div class="modal-body">
          <div class="box-body">
            <asp:HiddenField ID="hfRow" runat="server" />
                <div class="col-lg-6">
                  <div class="form-group" >
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtAgent" class="form-control" ToolTip="Agent Id"  placeholder="Agent ID" runat="server" ValidationGroup="edit" disabled></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
    
                      </div>        <!-- --> 

               

                <div class="col-lg-6">
                  <div class="form-group" >
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtProductName" ToolTip="Product Name" class="form-control" ValidationGroup="edit"  placeholder="Product Name" runat="server" disabled ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
    
                      </div>        <!-- -->

                    <div class="col-lg-6">
                  <div class="form-group" >
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtUnitPrice" class="form-control" ValidationGroup="edit" ToolTip="Unit Price" placeholder="Unit Price" runat="server" disabled></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
    
                      </div>        <!-- -->

                     <div class="col-lg-6">
                  <div class="form-group" >
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtQuantity" class="form-control" ValidationGroup="saved" ToolTip="Quantity"  placeholder="Quantity" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
    
                      </div>        <!-- -->

              <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtQuantity" ErrorMessage="Quantity Must be &gt; 0" Operator="GreaterThan" Type="Double" ValueToCompare="0" ValidationGroup="saved" ForeColor="#cc0000"/>

                     <div class="col-lg-6">
                  <div class="form-group" >
                    <div class="input-group">
                      <asp:TextBox ID="txtHidden" class="form-control" Visible="false" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
    
                      </div>        <!-- -->

            </div>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
        <%--<button type="button" class="btn btn-primary" >Save changes</button>--%>
          <asp:Button ID="btnSaveModal" class="btn btn-primary" runat="server" ValidationGroup="Modal" OnClick="btnSaveModal_Click" Text="Save changes" UseSubmitBehavior="false"  data-dismiss="modal"/>       
      </div>
    </div>
  </div>
</div>     

                  </ContentTemplate>
             </asp:UpdatePanel> 
                 
                 <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="upMain">
            <ProgressTemplate>
                
                <div class="overlay">
                  <i class="fa fa-refresh fa-spin"></i>
                </div>

            </ProgressTemplate>
            </asp:UpdateProgress>
                
            </div><!-- /.box-body -->  
                     
                  
                              
          </div><!-- /.box -->
       
      <asp:UpdatePanel ID="hfupdate" runat="server">
          <ContentTemplate>
          <asp:HiddenField ID="hftokanno" runat="server" />
              </ContentTemplate>
      </asp:UpdatePanel>  
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
                         .attr('placeholder', 'gg/mm/aaaa')
                         .attr('autocomplete', 'off')
                         .prop('readonly', false)
                         .after('<input type="text" class="altfield" id="' + prefix + this.attr('id') + '" name="' + this.attr('name') + '" value="' + _val + '">')
                         .removeAttr('name')
                         .val('')
                         .datepicker({
                             altField: '#' + prefix + _this.attr('id'),
                             dateFormat: 'dd/mm/yy',
                             altFormat: 'dd-mm-yy'
                         });

                         if (_val) {
                             this.datepicker('setDate', $.datepicker.parseDate('dd-mm-yy', val));
                         };
                     });


                     // min attribute
                     $('input[type="date"][min]').each(function () {
                         var _this = $(this);
                         this.datepicker("option", "minDate", $.datepicker.parseDate('dd-mm-yy', this.attr('min')));
                     });

                     // max attribute
                     $('input[type="date"][max]').each(function () {
                         var _this = $(this);
                         this.datepicker("option", "maxDate", $.datepicker.parseDate('dd-mm-yy', this.attr('max')));
                     });
                 }
             }
         }); // end Modernizr.load
        </script>
    

</asp:Content>