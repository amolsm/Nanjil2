<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgentBilling.aspx.cs" Inherits="Dairy.Tabs.Sales.AgentBilling" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
     <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css">
    <script src="//code.jquery.com/jquery-1.10.2.js"></script>
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
      <style type="text/css">
        .listboxl {
            height:100px !important;
        }
       .frmgrp {
       margin-bottom:1px;
       }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  
    
     <script type = "text/javascript">
         function PrintPanel() {
             var panel = document.getElementById("<%=pnlBills.ClientID %>");
           var printWindow = window.open('', '', 'height=400px,width=800px');
           printWindow.document.write("<html> <head> <style type='text/css'>.style1{border-collapse:collapse;font-size: 12px; font-family: sans-serif;}</style>");
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

        <section class="content-header">
          <h1>
             Agent Sale
            <small>Sales</small> 

          </h1>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Sales</a></li>
            <li class="active">Agent Sale</li>
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
                                <asp:Label runat="server" ID="lblSuccess" Text="Order Received Successfully"></asp:Label>
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
                     
                         <div class="row">
                       <div class="col-lg-4">
                 <div class="form-group">
                   <div class="input-group">
                     <div class="input-group-addon">
                       <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                     </div>
                      <asp:TextBox ID="txtGentOrderDate" class="form-control" type="date"  placeholder="Date" runat="server" disabled></asp:TextBox>                        
                   </div><!-- /.input group -->

                 </div><!-- /.form group -->

                     
                       
                          
                     </div> 
                           

                            <div class="col-lg-4">
                  <div class="form-group frmgrp">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <i class="fa fa-rode"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:DropDownList ID="dpAgent" class="form-control" DataTextField="Name" DataValueField="AgentID" runat="server" AutoPostBack="true" OnSelectedIndexChanged = "dpAgentpre_SelectedIndexChanged"   > 
                       </asp:DropDownList>
                        
                         
                    </div><!-- /.input group -->
                       <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator1" Display="Dynamic" 
    ValidationGroup="asdf" runat="server" ControlToValidate="dpAgent" ForeColor="Red"
    ErrorMessage="Please Select Agent "></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
                         </div>

                         

                             <div class="col-lg-4">
                  <div class="form-group frmgrp">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <i class="fa fa-rode"></i><span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:DropDownList ID="dpAgentProductType" class="form-control" DataTextField="TypeName" DataValueField="TypeID" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dpAgentProductType_OnSelectedIndexChanged"> 
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator2" Display="Dynamic" 
    ValidationGroup="asdf" runat="server" ControlToValidate="dpAgentProductType" ForeColor="Red"
    ErrorMessage="Please Select Type "></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
                         </div>
            
                       
                              </div>
                    <div class="row">
                             
                        
                          
                        
                          <div class="col-lg-4">
                  <div class="form-group frmgrp">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <i class="fa fa-rode"></i><span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:DropDownList ID="dpAgentProductdetaisl" class="form-control" DataTextField="product" AutoPostBack="true" OnSelectedIndexChanged="dpAgentProductdetaisl_SelectedIndexChanged" DataValueField="productId" runat="server"  > 
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator3" Display="Dynamic" 
    ValidationGroup="asdf" runat="server" ControlToValidate="dpAgentProductdetaisl" ForeColor="Red"
    ErrorMessage="Please Select Product "></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
                         </div>
              
             <div class="col-lg-4">
                  <div class="form-group frmgrp">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtagentOrderqty" class="form-control"   placeholder="Quantity " runat="server" ValidationGroup="Add"></asp:TextBox>                        
                    </div><!-- /.input group -->
                      <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtagentOrderqty" ErrorMessage="Quantity Must be &gt; 0" Operator="GreaterThan" Type="Double" ValueToCompare="0" ValidationGroup="asdf" ForeColor="#cc0000"/>
                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 
                           <div class="col-lg-4">
                  <div class="form-group frmgrp">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <i class="fa fa-rode"></i><span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:DropDownList ID="dpAgentShemeApplied" class="form-control"   runat="server" AutoPostBack="true" OnSelectedIndexChanged="dpAgentShemeApplied_SelectedIndexChanged" > 
                          <asp:ListItem Value="0">--Select Agent Scheme--</asp:ListItem>
                          <asp:ListItem Value="1">Apply</asp:ListItem>
                          <asp:ListItem Value="2">Not Apply</asp:ListItem>
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->
                         </div>

                         
            
       
                </div>
                           <div class="row">
                                <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <i class="fa fa-rode"></i><span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:DropDownList ID="dpPaymentMode" class="form-control" DataTextField="PaymentMode" readonly="true" DataValueField="AgentID" runat="server"  > 
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->

                         </div>

                         
                <asp:HiddenField id="hfAgentProductUnitPrice" runat="server" />
                           </div>
             
                         <div class="col-md-12">
                              <div class="col-lg-4  pull-right">
                  <div class="form-group">
                    <div class="input-group">
                      
                   
                       
                        <asp:Button ID="btnAddAgentProductItem" class="btn btn-primary" runat="server" CommandName="MoveNext" OnClick="btnAddAgentProductItem_click"   Text="Add" ValidationGroup="asdf"  />                    
                     &nbsp;   <asp:Button ID="btnAgentNewOrder" class="btn btn-primary" runat="server" CommandName="MoveNext"  OnClick="btnAgentNewOrder_clcik"    Text="New Order" ValidationGroup="none"   />                    
                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div>  
                             </div>
                             <asp:Panel runat="server" ID="pnlBill1">
                          <div class="col-md-12" runat="server" id="divTable">
                          <table id="example1" class="table table-bordered table-striped style1">'
          <asp:Repeater ID="rpAgentOrderdetails" runat="server" OnItemDataBound="rpOrderitam_OnDataBinding" OnItemCommand="rpOrderitam_ItemCommand">
                
               <HeaderTemplate>
                  <thead>
                      <tr class="ln1">
                         
                                        <th>Product</th>
                                        <th>By Product</th>
                                        <th>Product Code</th>
                                        <th>Quantity</th>
                                        <th>Unit Price</th> 
                                        <th>Total</th> 
                                        <th class="rem">Remove</th>
                      </tr>
                    </thead>
                    <tbody>

                   
               </HeaderTemplate>
               <ItemTemplate>
                    <tr>
                                 
                                <td><asp:Label ID="lblType" runat="server" Text='<%# Eval("TypeName")%>'></asp:Label></td>
                                <td><%# Eval("CommodityName")%></td>                       
                                <td><%# Eval("ProductName")%></td>
                                <td><%# Eval("Qty")%></td>
                                <td style="text-align:right"><%# string.Format("{0:##,###.00}", Eval("UnitCost"))%></td>
                                <td style="text-align:right"><asp:Label ID="lbltotal" runat="server" Text='<%# string.Format("{0:##,###.00}",Eval("Total"))%>'></asp:Label></td>
                      
                            
                         <td class="rem">   <asp:LinkButton ID="lbdelete" AlternateText="delete" ForeColor="Gray" OnItemCommand="lbdelete_ItemCommand" 
                                ToolTip="Delete" runat="server" CommandArgument='<%#Eval("TeamID") %>'
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
<th></th>
<th style="text-align:right">Total</th> 
<th style="text-align:right"><asp:Label ID="lblFInaltotal" runat="server" Text='<%# string.Format("{0:##,###.00}",Eval("Total"))%>'></asp:Label></th> 
                      </tr>
                    </tfoot>

                    </FooterTemplate>
                                             
           </asp:Repeater>
                
           </table>
           <asp:HiddenField ID="hftotalAmout" runat="server" />
       </div> 
        </asp:Panel>
                        <div class="col-lg-4 pull-right" style="text-align:right">
                  <div class="form-group">
                    <div class="input-group">
                      
                       <asp:Button ID="btnAgentORderSubmit" class="btn btn-primary" runat="server" CommandName="MoveNext" OnClick="btnAgentORderSubmit_click"   Text="Submit" ValidationGroup="Add"   />                    
                        <asp:Button ID="btnPrintAgent" class="btn btn-primary" runat="server" CommandName="MoveNext" OnClick="btnPrintAgent_click" OnClientClick="PrintPanel()" Text="Print"  />
                        &nbsp;
           <asp:Button ID="btnagentItamsremove" class="btn btn-primary" runat="server" CommandName="MoveNext" OnClick="btnagentItamsremove_click"     Text="Remove Item" ValidationGroup=""   />  
                        
                        
      </div><!-- /.input group -->

    </div><!-- /.form group -->

                     
                       
                          
        </div> 

       </asp:Panel>
                <asp:Panel runat="server" ID="pnlBills" Visible="false">
                        <asp:Literal runat="server" ID="genratedBIll"></asp:Literal>
              </asp:Panel>
         </ContentTemplate>
                       
                </asp:UpdatePanel>   
                 
                
            </div><!-- /.box-body -->            
                    <asp:Label ID="lblUser" runat="server" Visible="False"></asp:Label>
                        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="upMain">
            <ProgressTemplate>
                
                <div class="overlay">
                  <i class="fa fa-refresh fa-spin"></i>
                </div>

            </ProgressTemplate>
            </asp:UpdateProgress>
          </div><!-- /.box -->
       
        </section>
    <asp:HiddenField ID="hftokanno" runat="server" />


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

     <script type = "text/javascript">
         $("#btnAgentNewOrder").click(function (e) {
             // prevent from going to the page
             e.preventDefault();

             // get the href
             var href = $(this).attr("href");
             $("#pnlError").load(href, function () {
                 // do something after content has been loaded
             });
         });
    </script>
    <script type="text/javascript">
        function alertMessage() {
            alert('Please Check Stock!!');
        }
    </script>
</asp:Content>
