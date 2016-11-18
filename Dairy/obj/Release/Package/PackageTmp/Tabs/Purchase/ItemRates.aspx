<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ItemRates.aspx.cs" Inherits="Dairy.Tabs.Purchase.ItemRates" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    
    <!-- jQuery library -->

     <script type="text/javascript" src="../../Theme/bootstrap/js/bootstrap.min.js"></script>
     
     <style type="text/css">
        .listboxl {
            height:100px !important;
        }
       .frmgrp {
       margin-bottom:1px;
       }
       .frmgrp2 {
       margin-bottom:15px;
       }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  
    
        <section class="content-header">
          <h1>
             Item Rates
            <small>Purchase</small> 

          </h1>
          <ol class="breadcrumb"> <script type="text/javascript" src="../../Theme/bootstrap/js/bootstrap.min.js"></script>
            <li><a href="#"><i class="fa fa-dashboard"></i> Item Rates</a></li>
            <li class="active">Purchase</li>
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
                                <asp:Label runat="server" ID="lblSuccess" Text="Indent Placed Successfully"></asp:Label>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>

                <div class="box ">
            <div class="box-header with-border">
           
            </div>
            <div class="box-body">
               
              
                <asp:UpdatePanel runat="server" ID="upMain" UpdateMode="Conditional">

         <ContentTemplate>    

                       <asp:Panel runat="server" ID="pnlAgentOrder" Visible="true">
                     
                         <div class="col-md-12">
                <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                      <asp:Label Text="Vendor" runat="server"></asp:Label>
                      </div>
                       <asp:DropDownList ID="dpVendor" class="form-control selectpicker"  data-live-search="true" DataTextField="Name" DataValueField="Id" runat="server" > 
                       </asp:DropDownList>
                        
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->
                         </div>

        <div class="col-lg-4  ">
                  <div class="form-group">
                    <div class="input-group">
                     <asp:Button ID="btnSearch" class="btn btn-primary" runat="server" CommandName="MoveNext"  Text="Search" ValidationGroup="Add" OnClick="btnSearch_Click"  />                    
                                  
                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div>  
                         
               </div>

                             <div class="col-lg-4  ">
                  <div class="form-group">
                    <div class="input-group">
                     <asp:Button ID="btnAdd" class="btn btn-primary" runat="server" CommandName="MoveNext"  Text="Add New Item Rate" ValidationGroup="Add" OnClick="btnAdd_Click"  />                    
                                  
                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                   
                       
                          
                      </div>  
                    
                              <div class="col-md-12" runat="server" id="divTable">
                                  
                                <asp:UpdatePanel runat="server" ID="uprouteList" UpdateMode="Conditional">
                    <ContentTemplate>
                       
                          <table id="example1" class="table table-bordered table-striped">'
          <asp:Repeater ID="rpItemRatesList" runat="server"  OnItemCommand="rpItemRatesList_ItemCommand" >
                
               <HeaderTemplate>
                  <thead>
                      <tr>
                         
                                        <th>Sr.No</th>
                                        <th>Item</th>
                                        <th>Quantity</th>
                                        <th>Price</th>
                          <th>Total Price</th>
                                        <th>Edit</th> 
                                       
                      </tr>
                    </thead>
                    <tbody>

                   
               </HeaderTemplate>
               <ItemTemplate>
                    <tr>
                                 
                                <td><%# Eval("srno")%></td>
                                <td><%# Eval("ItemName")%></td>                       
                                <td><%# Eval("Quantity") + " " + Eval("UnitName")%></td>
                                <td><%# string.Format("{0:##,###.00}", Eval("Price"))%></td>
                                <td><%# string.Format("{0:##,###.00}", Eval("TotalPrice"))%></td>
                            
                         <td>   <asp:LinkButton ID="lbEdite" AlternateText="Edit" ForeColor="Gray" OnItemCommand="lbEdite_ItemCommand" 
                                                                    ToolTip="Edit" runat="server" CommandArgument='<%#Eval("ItemRateId") %>'
                                                                    CommandName="Edit"><i class="fa fa-edit" ></i></asp:LinkButton>
</td>

                      


       
                    </tr>
               </ItemTemplate>
                    <FooterTemplate>

                         </tbody>

                    <tfoot>
                      <tr>
                        
                                        <th>Sr.No</th>
                                        <th>Item</th>
                                        <th>Quantity</th>
                                        <th>Price</th>
                          <th>Total Price</th>
                                        <th>Edit</th> 
                       
                      </tr>
                    </tfoot>

                    </FooterTemplate>
                                             
           </asp:Repeater>
                  <asp:HiddenField id="hfItemRatesId" runat="server" />     
           </table>
                         </ContentTemplate>
                </asp:UpdatePanel>
         
       </div> 

                            
                                  
       </asp:Panel>

         </ContentTemplate>
                       
                </asp:UpdatePanel>   
                 
                
            </div><!-- /.box-body -->            
          </div><!-- /.box -->
            <asp:UpdatePanel ID="upModal" runat="server" UpdateMode="Conditional" >  
              <ContentTemplate>         
                      <!-- Modal -->
        <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" data-backdrop="false">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title" id="myModalLabel">Item Rates</h4>
      </div>
      <div class="modal-body">
          <div class="box-body">
            
            <div class="row">
               <div class="col-lg-6">
                  <div class="form-group frmgrp2" >
                    <div class="input-group">
                      <div class="input-group-addon">
                        <asp:Label runat="server" Text="Vendor"></asp:Label>
                      </div>
                        <asp:DropDownList ID="dpVendor1" class="form-control" runat="server" selected DataValueField="Id" DataTextField="Name" >

                       </asp:DropDownList>
                    </div><!-- /.input group -->
                       <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator1" Display="Dynamic" 
    ValidationGroup="Save" runat="server" ControlToValidate="dpVendor1" ForeColor="Red"
    ErrorMessage="Please Select Vendor "></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
   
                      </div>        <!-- --> 

              <div class="col-lg-6">
                  <div class="form-group frmgrp2" >
                    <div class="input-group">
                      <div class="input-group-addon">
                        <asp:Label runat="server" Text="Item"></asp:Label>
                      </div>
                        <asp:DropDownList ID="dpItem" class="form-control" runat="server" selected DataValueField="Id" DataTextField="Name" >

                       </asp:DropDownList>
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator2" Display="Dynamic" 
    ValidationGroup="Save" runat="server" ControlToValidate="dpItem" ForeColor="Red"
    ErrorMessage="Please Select Item "></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
    
                      </div>        <!-- --> 
</div>
               <div class="row">
               <div class="col-lg-6">
                  <div class="form-group frmgrp" >
                    <div class="input-group">
                      <div class="input-group-addon">
                       <asp:Label runat="server" Text="Quantity"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtQuantity" class="form-control" ToolTip="Quantity"   runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtQuantity"
        ErrorMessage="Quantity Required" ValidationGroup="Save" ForeColor="Red"></asp:RequiredFieldValidator> 
                  </div><!-- /.form group -->
    
                      </div>        <!-- --> 

             <div class="col-lg-6">
                  <div class="form-group frmgrp" >
                    <div class="input-group">
                      <div class="input-group-addon">
                        <asp:Label runat="server" Text="Unit"></asp:Label>
                      </div>
                        <asp:DropDownList ID="dpUnit" class="form-control" runat="server" selected DataValueField="Id" DataTextField="Name" >

                       </asp:DropDownList>
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator5" Display="Dynamic" 
    ValidationGroup="Save" runat="server" ControlToValidate="dpUnit" ForeColor="Red"
    ErrorMessage="Please Select Unit "></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
    
                      </div>        <!-- --> 
                   </div>
    <div class="row">
     <div class="col-lg-6">
                  <div class="form-group frmgrp" >
                    <div class="input-group">
                      <div class="input-group-addon">
                       <asp:Label runat="server" Text="Price"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtPrice" class="form-control" ToolTip="Price"   runat="server" OnTextChanged="txtPrice_TextChanged" AutoPostBack="true" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPrice"
        ErrorMessage="Price Required" ValidationGroup="Save" ForeColor="Red"></asp:RequiredFieldValidator> 
                  </div><!-- /.form group -->
    
                      </div>        <!-- --> 

     <div class="col-lg-6">
                  <div class="form-group frmgrp" >
                    <div class="input-group">
                      <div class="input-group-addon">
                       <asp:Label runat="server" Text="Shipping"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtShipping" class="form-control" ToolTip="Shipping Charges"   runat="server" type="number" Text="0" AutoPostBack="true" OnTextChanged="txtShipping_TextChanged"></asp:TextBox>                        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtShipping"
        ErrorMessage="Shipping Charges Required" ValidationGroup="Save" ForeColor="Red"></asp:RequiredFieldValidator> 
                  </div><!-- /.form group -->
    
                      </div>        <!-- --> 
  </div>

               <div class="row">
     <div class="col-lg-6">
                  <div class="form-group frmgrp" >
                    <div class="input-group">
                      <div class="input-group-addon">
                       <asp:Label runat="server" Text="Excise %"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtExcise" class="form-control" ToolTip="Excise"   runat="server" AutoPostBack="true" OnTextChanged="txtExcise_TextChanged" Text="0"></asp:TextBox>                        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtExcise"
        ErrorMessage="Excise Required" ValidationGroup="Save" ForeColor="Red"></asp:RequiredFieldValidator> 
                  </div><!-- /.form group -->
    
                      </div>        <!-- --> 

     <div class="col-lg-6">
                  <div class="form-group frmgrp" >
                    <div class="input-group">
                      <div class="input-group-addon">
                       <asp:Label runat="server" Text="CST %"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtCst" class="form-control" ToolTip="CST against Form C"   runat="server" type="number" AutoPostBack="true" OnTextChanged="txtCst_TextChanged" Text="0"></asp:TextBox>                        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtCst"
        ErrorMessage="CST % Required" ValidationGroup="Save" ForeColor="Red"></asp:RequiredFieldValidator> 
                  </div><!-- /.form group -->
    
                      </div>        <!-- --> 
  </div>

                  <div class="row">
     <div class="col-lg-6">
                  <div class="form-group frmgrp" >
                    <div class="input-group">
                      <div class="input-group-addon">
                       <asp:Label runat="server" Text="VAT %"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtVat" class="form-control" ToolTip="VAT"   runat="server" AutoPostBack="true" OnTextChanged="txtVat_TextChanged" Text="0"></asp:TextBox>                        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtVat"
        ErrorMessage="VAT % Required" ValidationGroup="Save" ForeColor="Red"></asp:RequiredFieldValidator> 
                  </div><!-- /.form group -->
    
                      </div>        <!-- --> 

     <div class="col-lg-6">
                  <div class="form-group frmgrp" >
                    <div class="input-group">
                      <div class="input-group-addon">
                       <asp:Label runat="server" Text="Insurance"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtInsurance" class="form-control" ToolTip="Insurance Amount"   runat="server" type="number" AutoPostBack="true" OnTextChanged="txtInsurance_TextChanged" Text="0"></asp:TextBox>                        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtInsurance"
        ErrorMessage="Insurance Required" ValidationGroup="Save" ForeColor="Red"></asp:RequiredFieldValidator> 
                  </div><!-- /.form group -->
    
                      </div>        <!-- --> 
  </div>
 <div class="row">
     <div class="col-lg-6">
                  <div class="form-group frmgrp" >
                    <div class="input-group">
                      <div class="input-group-addon">
                       <asp:Label runat="server" Text="Freight"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtFreight" class="form-control" ToolTip="Freight Charges"   runat="server" AutoPostBack="true" OnTextChanged="txtFreight_TextChanged" Text="0"></asp:TextBox>                        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtFreight"
        ErrorMessage="Frieght Required" ValidationGroup="Save" ForeColor="Red"></asp:RequiredFieldValidator> 
                  </div><!-- /.form group -->
    
                      </div>        <!-- --> 

     <div class="col-lg-6">
                  <div class="form-group frmgrp" >
                    <div class="input-group">
                      <div class="input-group-addon">
                       <asp:Label runat="server" Text="Total"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtTotalPrice" class="form-control" ToolTip="Total Price"   runat="server" type="number"></asp:TextBox>                        
                    </div><!-- /.input group -->
                      
                  </div><!-- /.form group -->
    
                      </div>        <!-- --> 
  </div>
                
            </div>
      </div>
      <div class="modal-footer">
        <%--<button type="button" class="btn btn-default" data-dismiss="modal">Close</button>--%>
       <asp:Button ID="btnCloseModal" class="btn btn-default" runat="server" ValidationGroup="none" OnClick="btnCloseModal_Click" Text="Close" UseSubmitBehavior="false"  data-dismiss="modal"/>       
          <asp:Button ID="btnSubmit" class="btn btn-primary" runat="server" ValidationGroup="Save" OnClick="btnSubmit_Click" Text="Save" UseSubmitBehavior="false"  />       
           <asp:Button ID="btnUpdate" class="btn btn-primary" runat="server" ValidationGroup="Save" OnClick="btnUpdate_Click" Text="Udpate" UseSubmitBehavior="false"  data-dismiss="modal"/>       
      </div>
    </div>
  </div>
</div>     

                  </ContentTemplate>
             </asp:UpdatePanel> 
        </section>
    <asp:HiddenField ID="hftokanno" runat="server" />


     <script type="text/javascript">
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
       

      <script type="text/javascript">
          //function showmodal() {
          //    $('#myModal').modal();
          //};

           $(document).ready(function () {
               $("#<% =dpVendor.ClientID %>").addClass("selectpicker");
               $("#dpVendor").selectpicker();


           });

          
           </script>
    
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
