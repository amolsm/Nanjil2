<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MaterialReceived.aspx.cs" Inherits="Dairy.Tabs.Purchase.MaterialReceived" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <%-- <script type="text/javascript" src="../../Theme/bootstrap/js/bootstrap.min.js"></script>--%>
    <link href="../../Theme/bootstrap/css/bootstrap-select.min.css" rel="stylesheet" />
    <script type="text/javascript" src="../../Theme/bootstrap/js/bootstrap-select.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  
    
        <section class="content-header">
          <h1>
             Material Recieved Note
            <small>Purchase</small> 

          </h1>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Material Recieved Note</a></li>
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
                       <asp:DropDownList ID="dpVendor" class="form-control "  data-live-search="true" DataTextField="Name" DataValueField="ID" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dpVendor_SelectedIndexChanged"> 
                       </asp:DropDownList>
                        
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->
                         </div> 
                             
                    <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                      <asp:Label Text="Purchase Order" runat="server"></asp:Label>
                      </div>
                       <asp:DropDownList ID="dpPOCode" class="form-control "  data-live-search="true" DataTextField="Name" DataValueField="ID" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dpPOCode_SelectedIndexChanged1" > 
                       </asp:DropDownList>
                        
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->
                         </div> 

                    <div class="col-lg-4">
                 <div class="form-group">
                   <div class="input-group">
                     <div class="input-group-addon">
                      <asp:Label Text="Bill Date" runat="server"></asp:Label>
                     </div>
                      <asp:TextBox ID="txtBillDate" class="form-control" type="date"  runat="server" required></asp:TextBox>                        
                   </div><!-- /.input group -->

                 </div><!-- /.form group -->

                     
                       
                          
                     </div> 
                            
                    <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                      <asp:Label Text="Bill No" runat="server"></asp:Label>
                         
                      </div>
                      <asp:TextBox ID="txtBillNumber" class="form-control" runat="server" ></asp:TextBox>                        
                         
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->
                         </div>
                             
                    <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                      <asp:Label Text="Vehicle No" runat="server"></asp:Label>
                         
                      </div>
                      <asp:TextBox ID="txtVehicleNo" class="form-control" runat="server" ></asp:TextBox>                        
                         
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->
                         </div>  
                             
                    <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                      <asp:Label Text="P.R. No" runat="server"></asp:Label>
                         
                      </div>
                      <asp:TextBox ID="txtPRNo" class="form-control" runat="server" ></asp:TextBox>                        
                         
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->
                         </div>
                         
               </div>

                      
                   
                              <div class="col-md-12" runat="server" id="divTable" style="padding-top:25px;padding-bottom:25px;">
                          <table id="example3" class="table table-bordered table-striped">
          <asp:Repeater ID="rpAgentOrderdetails" runat="server" OnItemCommand="rpAgentOrderdetails_ItemCommand" OnItemDataBound="rpAgentOrderdetails_ItemDataBound" OnItemCreated="rpAgentOrderdetails_ItemCreated" >
                
               <HeaderTemplate>
                  <thead>
                      <tr>
                         
                                        <th>Sr.No</th>
                                        <th>Item</th>
                                        
                                        <th>Ordered Qty</th>
                                        <th>Received Qty</th>
                                      <th>Accepted Qty</th>
                                      <th>Rejected Qty</th>
                                      <th>Price</th>
                                        <th style="text-align:right">Amount (Tax Included)</th>
                                        
                                       
                      </tr>
                    </thead>
                    <tbody>

                   
               </HeaderTemplate>
               <ItemTemplate>
                    <tr>
                                 
                                <td><%# Eval("srno")%>
                                    <asp:HiddenField ID="hfOrderDetailsId" runat="server" Value='<%# Eval("OrderDetailsId")%>'/>
                                </td>
                                <td><%# Eval("ItemName")%>
                                    <asp:HiddenField ID="hfItemId" runat="server" Value='<%# Eval("ItemId")%>'/>
                                </td>                       
                                
                                <td><asp:Label ID="lblQuantity" runat="server" Text='<%# Eval("Quantity")%>'></asp:Label>
                                    <asp:HiddenField ID="hfCst" runat="server" Value='<%# Eval("CST")%>'/>
                                     <asp:HiddenField ID="hfExcise" runat="server" Value='<%# Eval("Excise")%>'/>
                                     <asp:HiddenField ID="hfVat" runat="server" Value='<%# Eval("VAT")%>'/>
                                </td>
                                <td> 
                                    <asp:TextBox runat="server" ID="txtReceivedQty" ToolTip="Received Quantity" placeholder ="Received Quantity" Type="number" />
                                </td>
                                <td> 
                                    <asp:TextBox runat="server" ID="txtAcceptedQty" ToolTip="Accepted Quantity" placeholder ="Accepted Quantity" Type="number" OnTextChanged="txtAcceptedQty_TextChanged" AutoPostBack="true"/>
                                </td>
                                <td> 
                                    <asp:TextBox runat="server" ID="txtRejectedQty" ToolTip="Rejected Quantity" placeholder ="Rejected Quantity" Type="number"/>
                                </td>
                               
                                <td style="text-align:right"><asp:Label ID="lblPrice" runat="server" Text='<%# string.Format("{0:##,###.00}",Eval("Price"))%>'></asp:Label></td>
                                 <td style="text-align:right"><asp:Label ID="lbltotal" runat="server" Text='<%# string.Format("{0:##,###.00}",Eval("Amt"))%>'></asp:Label></td>
                            
                        
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

                            <div class="col-md-12">
                                <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                      <asp:Label Text="Required For" runat="server"></asp:Label>
                         
                      </div>
                      <asp:TextBox ID="txtRequiredFor" class="form-control" runat="server" ></asp:TextBox>                        
                         
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->
                         </div>

                                <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                      <asp:Label Text="Remarks" runat="server"></asp:Label>
                         
                      </div>
                      <asp:TextBox ID="txtRemarks" class="form-control" runat="server" ></asp:TextBox>                        
                         
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->
                         </div>

                                <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                      <asp:Label Text="ReceivedBy" runat="server"></asp:Label>
                      </div>
                       <asp:DropDownList ID="dpReceivedBy" class="form-control "  data-live-search="true" DataTextField="Name" DataValueField="ID" runat="server" > 
                       </asp:DropDownList>
                        
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->
                         </div> 
                             
                                <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                      <asp:Label Text="QC By" runat="server"></asp:Label>
                      </div>
                       <asp:DropDownList ID="dpQcBy" class="form-control "  data-live-search="true" DataTextField="Name" DataValueField="ID" runat="server" > 
                       </asp:DropDownList>
                        
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->
                         </div>
                                
                                <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                      <asp:Label Text="Finance" runat="server"></asp:Label>
                      </div>
                       <asp:DropDownList ID="dpFinanceMgr" class="form-control "  data-live-search="true" DataTextField="Name" DataValueField="ID" runat="server" > 
                       </asp:DropDownList>
                        
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->
                         </div> 

                                <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                      <asp:Label Text="Approved By" runat="server"></asp:Label>
                      </div>
                       <asp:DropDownList ID="dpApprovedBy" class="form-control "  data-live-search="true" DataTextField="Name" DataValueField="ID" runat="server" > 
                       </asp:DropDownList>
                        
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->
                         </div> 
                </div>

                                <div class="col-lg-4 pull-right" style="text-align:right">
                  <div class="form-group">
                    <div class="input-group">
                      
                       <asp:Button ID="btnSubmit" class="btn btn-primary" runat="server" CommandName="MoveNext"  Text="Submit" ValidationGroup="none" OnClick="btnSubmit_Click"/>                    
                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 

             
                                  
       </asp:Panel>

         </ContentTemplate>
                       
                </asp:UpdatePanel>   
                 
                
            </div><!-- /.box-body -->            
          </div><!-- /.box -->
       
         

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

                $("#<% =dpPOCode.ClientID %>").addClass("selectpicker");
               $("#dpPOCode").selectpicker();
               
                $("#<% =dpReceivedBy.ClientID %>").addClass("selectpicker");
               $("#dpReceivedBy").selectpicker();

                $("#<% =dpQcBy.ClientID %>").addClass("selectpicker");
               $("#dpQcBy").selectpicker();

                $("#<% =dpFinanceMgr.ClientID %>").addClass("selectpicker");
               $("#dpFinanceMgr").selectpicker();

               $("#<% =dpApprovedBy.ClientID %>").addClass("selectpicker");
               $("#dpApprovedBy").selectpicker();
           });

          
           </script>

  
  
</asp:Content>

