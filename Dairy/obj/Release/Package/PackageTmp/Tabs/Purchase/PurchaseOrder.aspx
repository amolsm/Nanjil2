<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PurchaseOrder.aspx.cs" Inherits="Dairy.Tabs.Purchase.PurchaseOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <%-- <script type="text/javascript" src="../../Theme/bootstrap/js/bootstrap.min.js"></script>--%>
    <link href="../../Theme/bootstrap/css/bootstrap-select.min.css" rel="stylesheet" />
    <script type="text/javascript" src="../../Theme/bootstrap/js/bootstrap-select.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  
    
        <section class="content-header">
          <h1>
             Purchase Order
            <small>Purchase</small> 

          </h1>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Purchase Order</a></li>
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
                      <asp:Label Text="Till Date" runat="server"></asp:Label>
                     </div>
                      <asp:TextBox ID="txtTillDate" class="form-control" type="date"  placeholder="Date" runat="server" required></asp:TextBox>                        
                   </div><!-- /.input group -->

                 </div><!-- /.form group -->

                     
                       
                          
                     </div> 
                            
                           
                             
                               <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                      <asp:Label Text="Vendor" runat="server"></asp:Label>
                      </div>
                       <asp:DropDownList ID="dpVendor" class="form-control "  data-live-search="true" DataTextField="Name" DataValueField="ID" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dpVendor_SelectedIndexChanged"> 
                       </asp:DropDownList>
                        
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->
                         </div>         

                                 <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <asp:Label Text="Item" runat="server"></asp:Label>
                      </div>
                       <asp:DropDownList ID="dpItem" class="form-control "  data-live-search="true" DataTextField="Name" DataValueField="ID" runat="server"  AutoPostBack="true" OnSelectedIndexChanged="dpItem_SelectedIndexChanged" > 
                        
                       </asp:DropDownList>
                        
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->
                         </div>         

                     <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                      <asp:Label Text="Quantity" runat="server"></asp:Label>
                         
                      </div>
                      <asp:TextBox ID="txtQuantity" class="form-control" runat="server" disabled></asp:TextBox>                        
                          <asp:HiddenField ID="hfQuantity" runat="server" />
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->
                         </div>  
                             
                      <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <asp:Label Text="Price" runat="server"></asp:Label>
                          
                      </div>
                      <asp:TextBox ID="txtPrice" class="form-control" runat="server" disabled></asp:TextBox>                        
                          <div class="input-group-addon">
                          <asp:CheckBox ID="chkPrice" runat="server" AutoPostBack="true" OnCheckedChanged="chkPrice_CheckedChanged" />
                      </div>
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->
                         </div>   
                             
                             <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <asp:Label Text="Excise %" runat="server"></asp:Label>
                          
                      </div>
                      <asp:TextBox ID="txtExcise" class="form-control" runat="server" disabled></asp:TextBox>                        
                          <div class="input-group-addon">
                          <asp:CheckBox ID="chkExcise" runat="server" AutoPostBack="true" OnCheckedChanged="chkExcise_CheckedChanged" />
                      </div>
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->
                         </div>   
                             
                             <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <asp:Label Text="CST %" runat="server"></asp:Label>
                          
                      </div>
                      <asp:TextBox ID="txtCST" class="form-control" runat="server" disabled></asp:TextBox>                        
                          <div class="input-group-addon">
                          <asp:CheckBox ID="chkCST" runat="server" AutoPostBack="true" OnCheckedChanged="chkCST_CheckedChanged" />
                      </div>
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->
                         </div>   
                             
                             <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <asp:Label Text="VAT %" runat="server"></asp:Label>
                          
                      </div>
                      <asp:TextBox ID="txtVat" class="form-control" runat="server" disabled></asp:TextBox>                        
                          <div class="input-group-addon">
                          <asp:CheckBox ID="chkVat" runat="server" AutoPostBack="true" OnCheckedChanged="chkVat_CheckedChanged" />
                      </div>
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->
                         </div>     
                             
                              <%--<div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <asp:Label Text="Insurance" runat="server"></asp:Label>
                          
                      </div>
                      <asp:TextBox ID="txtInsurance" class="form-control" runat="server" disabled></asp:TextBox>                        
                          <div class="input-group-addon">
                          <asp:CheckBox ID="chkInsurance" runat="server" AutoPostBack="true" OnCheckedChanged="chkInsurance_CheckedChanged" Visible="false"/>
                      </div>
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->
                         </div>   --%>        
                         
               </div>

                             <div class="col-lg-4  pull-right">
                  <div class="form-group">
                    <div class="input-group">
                     <asp:Button ID="btnAddItem" class="btn btn-primary" runat="server" CommandName="MoveNext" OnClick="btnAddItem_Click"   Text="Add" ValidationGroup="Add"   />                    
                    <%-- &nbsp;   <asp:Button ID="btnNewIndent" class="btn btn-primary" runat="server" CommandName="MoveNext"  OnClick="btnNewIndent_Click"    Text="New Indent" ValidationGroup="none"   />                    --%>
                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div>  
                   
                              <div class="col-md-12" runat="server" id="divTable">
                          <table id="example1" class="table table-bordered table-striped">'
          <asp:Repeater ID="rpAgentOrderdetails" runat="server" OnItemDataBound="rpAgentOrderdetails_ItemDataBound" OnItemCommand="rpAgentOrderdetails_ItemCommand">
                
               <HeaderTemplate>
                  <thead>
                      <tr>
                         
                                        <th>Sr.No</th>
                                        <th>Item</th>
                                        <th>Price</th>
                                        <th>Quantity</th>
                                        <th style="text-align:right">Amount (Tax Included)</th>
                                        <th style="text-align:center">Remove</th> 
                                       
                      </tr>
                    </thead>
                    <tbody>

                   
               </HeaderTemplate>
               <ItemTemplate>
                    <tr>
                                 
                                <td><%# Eval("srno")%></td>
                                <td><%# Eval("ItemName")%></td>                       
                                <td><%# string.Format("{0:##,###.00}",Eval("Price"))%></td>
                                <td><%# Eval("Quantity")%></td>
                                 <td style="text-align:right"><asp:Label ID="lbltotal" runat="server" Text='<%# string.Format("{0:##,###.00}",Eval("Amt"))%>'></asp:Label></td>
                            
                         <td style="text-align:center">   <asp:LinkButton ID="lbdelete" AlternateText="delete" ForeColor="Gray" OnItemCommand="lbdelete_ItemCommand" 
                                                                    ToolTip="Delete" runat="server" CommandArgument='<%#Eval("OrderCartId") %>'
                                                                    CommandName="delete"><i class="fa fa-trash"></i></asp:LinkButton>
</td>

                      


       
                    </tr>
               </ItemTemplate>
                    <FooterTemplate>

                         </tbody>

                    <tfoot>
                      <tr>
                         <th></th>
                        <th> </th>
                        <th></th>
                     <th style="text-align:right">Total</th> 
<th style="text-align:right"><asp:Label ID="lblFInaltotal" runat="server" Text='<%# string.Format("{0:##,###.00}",Eval("Amt"))%>'></asp:Label></th> 
                       
                      </tr>
                    </tfoot>

                    </FooterTemplate>
                                             
           </asp:Repeater>
                
           </table>
           <asp:HiddenField ID="hftotalAmout" runat="server" />
       </div> 

                                <div class="col-lg-4 pull-right" style="text-align:right">
                  <div class="form-group">
                    <div class="input-group">
                      
                       <asp:Button ID="btnSubmitPO" class="btn btn-primary" runat="server" CommandName="MoveNext" OnClick="btnSubmitPO_Click"   Text="Submit" ValidationGroup="none"  OnClientClick="chkApprovalCondition();" />                    
                        &nbsp;
                        <%-- <asp:Button ID="btnRemoveItem" class="btn btn-primary" runat="server" CommandName="MoveNext" OnClick="btnRemoveItem_Click"     Text="Remove Item" ValidationGroup=""   />  --%>
                        
                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 

             
                                  
       </asp:Panel>

         </ContentTemplate>
                       
                </asp:UpdatePanel>   
                 
                
            </div><!-- /.box-body -->            
          </div><!-- /.box -->
       
           <asp:UpdatePanel ID="upModal" runat="server" UpdateMode="Conditional" >  
              <ContentTemplate>         
                      <!-- Modal -->
        <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title" id="myModalLabel">Categories</h4>
      </div>
      <div class="modal-body">
          <div class="box-body">
            
                <div class="col-lg-6">
                  <div class="form-group" >
                    <div class="input-group">
                      <div class="input-group-addon">
                        <asp:Label runat="server" Text="Frieght"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtFrieght" class="form-control" ToolTip="Frieght"  placeholder="Frieght Charges" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
    
                      </div>        <!-- --> 

                <div class="col-lg-6">
                  <div class="form-group" >
                    <div class="input-group">
                      <div class="input-group-addon">
                        <asp:Label runat="server" Text="Terms"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtTerms" class="form-control" ToolTip="Payment Terms"  placeholder="Payment Terms" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
    
                      </div>        <!-- --> 

              <div class="col-lg-6">
                  <div class="form-group" >
                    <div class="input-group">
                      <div class="input-group-addon">
                        <asp:Label runat="server" Text="Damage"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtTrDamage" class="form-control" ToolTip="Transportation Damage"  placeholder="Transportation Damage" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
    
                      </div>        <!-- --> 

              <div class="col-lg-6">
                  <div class="form-group" >
                    <div class="input-group">
                      <div class="input-group-addon">
                        <asp:Label runat="server" Text="Warranty"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtWarranties" class="form-control" ToolTip="Warranties"  placeholder="Warranties" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
    
                      </div>        <!-- --> 

            </div>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
       
          <asp:Button ID="btnSubmit" class="btn btn-primary" runat="server" ValidationGroup="saved" OnClick="btnSubmit_Click" Text="Save" UseSubmitBehavior="false"  data-dismiss="modal"/>       
           
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
          
           $(document).ready(function () {
              

               $("#<% =dpVendor.ClientID %>").addClass("selectpicker");
               $("#dpCategory").selectpicker();

                $("#<% =dpItem.ClientID %>").addClass("selectpicker");

           });

          
           </script>

  <script type="text/javascript">
      function chkApprovalCondition()
      {
          var tot = document.getElementById('<%=hftotalAmout.ClientID%>').innerText;
          if (tot > 49999) {
              alert('MD Approval Required')
              return true;
          }
          else {
              return true;
          }
      }
  </script>
  
</asp:Content>

