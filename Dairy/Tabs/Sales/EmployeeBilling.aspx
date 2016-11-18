<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmployeeBilling.aspx.cs" Inherits="Dairy.Tabs.Sales.EmployeeBilling" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
     <link rel="stylesheet" href="http://localhost:4888/code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css">
    <script src="//code.jquery.com/jquery-1.10.2.js"></script>
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
 <script type = "text/javascript">
     function PrintPanel() {
         var panel = document.getElementById("<%=pnlBills.ClientID %>");
           var printWindow = window.open('', '', 'height=600px,width=800px');
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
             Employee Sale
            <small>Sales</small> 

          </h1>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Sales</a></li>
            <li class="active">Employee Sale</li>
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
                

                        <asp:Panel runat="server" ID="pnlEmployee" Visible="true">
                       
            <div class="col-md-12">
                        <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtEmployeeOrderDate" type="date" class="form-control"   placeholder="Date" runat="server" required></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 
                        
                        <%-- <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <i class="fa fa-rode"></i><span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:DropDownList ID="dpEmploueeRoute" class="form-control" DataTextField="Name" DataValueField="RouteID" runat="server"  > 
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->
                         </div>--%>

                        <%--<div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <i class="fa fa-rode"></i><span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:DropDownList ID="dpEmploueeSalesPErsion" class="form-control" DataTextField="Name" DataValueField="employeeID" runat="server"  > 
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->
                         </div>--%>

                        <%-- <div class="col-lg-3">
                  <div cl
                      ass="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtEmployeeSalesPerson" class="form-control"   placeholder="Date" runat="server" required ReadOnly="true"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> --%>
                       
                        <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <i class="fa fa-rode"></i><span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:DropDownList ID="dpEmployee" AutoPostBack="true" OnSelectedIndexChanged="dpEmployee_IndexChanged" class="form-control" DataTextField="Name" DataValueField="employeeID" runat="server"  > 
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->
                         </div>
           
                        <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <i class="fa fa-rode"></i><span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:DropDownList ID="dpEmployeeProductType" class="form-control" DataTextField="TypeName"  AutoPostBack="true" OnSelectedIndexChanged="dpEmployeeProducttype_IndexChanged"    DataValueField="TypeID" runat="server"  > 
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->
                         </div>
                        
              
              
       </div>
                             
        <div class="col-md-12">
           
                  <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <i class="fa fa-rode"></i><span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:DropDownList ID="dpEmployeeProductDetails" class="form-control"  AutoPostBack="true" OnSelectedIndexChanged="dpEmployeeProductDetails_IndexChanged"  runat="server" DataTextField="product"    DataValueField="productId"    > 
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->
                         </div>

                  <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtQtyEmployee" class="form-control"   placeholder="Quantity " runat="server" ValidationGroup="Add"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtQtyEmployee" ErrorMessage="Quantity Must be &gt; 0" Operator="GreaterThan" Type="Double" ValueToCompare="0" ValidationGroup="Add" ForeColor="#cc0000"/>

       <asp:HiddenField ID="hfEmployeeProductUnitPrice" Value="0" runat="server" />
      <asp:HiddenField ID="hfTotalCansume" Value="0" runat="server" />
      
      </div>


                       
        <div class="col-lg-3 pull-right" style="text-align:right">
                  <div class="form-group">
                    <div class="input-group">
                      
                       <asp:Button ID="btnAddEmployeeOrderItem" class="btn btn-primary" OnClick="btnAddEmployeeOrderItem_clcik" runat="server" CommandName="MoveNext"   Text="Add" ValidationGroup="Add"   />                    
                        &nbsp;
                         <asp:Button ID="btnEmployeeNewOrder" class="btn btn-primary" runat="server" CommandName="MoveNext"  OnClick="btnEmployeeNewOrder_click"      Text="New Order" ValidationGroup="EMployyeOrder"   />  
                        
                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 

                         
        <asp:Panel runat="server" ID="pnlBill2">
                                           <div class="col-md-12" runat="server" id="div1">
            <table id="Table1" class="table table-bordered table-striped CSSTableGenerator">'
          <asp:Repeater ID="rpEmployeeDetails" runat="server" OnItemDataBound="rpEmployeeID_OnDataBinding" OnItemCommand="rpEmployeeID_ItemCommand" >
                
               <HeaderTemplate>
                  <thead>
                      <tr>
                         
                                        <th>Product</th>
                                        <th>By Product</th>
                                        <th>Product Code</th>
                                        <th>Quantity</th>
                                        <th>Unit Price</th> 
                                        <th>Total</th> 
                                        <th class="tg">Remove</th>
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
                                <td style="text-align:right"><%# string.Format("{0:##,###.00}",Eval("UnitCost"))%></td>
                                <td style="text-align:right"><asp:Label ID="lbltotal" runat="server" Text='<%# string.Format("{0:##,###.00}", Eval("Total"))%>'></asp:Label></td>
                      
                            
                         <td class="tg">   <asp:LinkButton ID="lbdelete" AlternateText="delete" ForeColor="Gray" OnItemCommand="lbdelete_ItemCommand" 
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
                        <th style="text-align:right"><asp:Label ID="lblFInaltotal" runat="server" Text='<%# Eval("Total")%>'></asp:Label></th> 
                      </tr>
                    </tfoot>

                    </FooterTemplate>
                                             
           </asp:Repeater>
               
           </table>
            <asp:HiddenField ID="hfemployeeTotalBill" Value="0" runat="server" />
       </div> 
     </asp:Panel>

         <div class="col-lg-3 pull-right" style="text-align:right">
                  <div class="form-group">
                    <div class="input-group">
                      
                       <asp:Button ID="Button1" class="btn btn-primary" runat="server" CommandName="MoveNext" OnClick="btnemployeeOrdersubmit_click"   Text="Submit"       />                    
                        
                    &nbsp;<asp:Button ID="btnRemoveOrder" class="btn btn-primary" runat="server" CommandName="MoveNext"  OnClick="btnRemoveOrder_click"     Text="Remove Item" ValidationGroup=""   />  
                        &nbsp;<asp:Button ID="btnPrintEmp" runat="server" class="btn btn-primary" CommandName="MoveNext" OnClick="btnPrintEmp_click" OnClientClick="PrintPanel()" Text="Print" />
                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 

                           
                         
                        </asp:Panel>
                       
                         <asp:Panel runat="server" ID="pnlBills" Visible="false" >
                        <asp:Literal runat="server" ID="genratedBIll"></asp:Literal>
              </asp:Panel>
                    </ContentTemplate>
                       
                </asp:UpdatePanel>  
                 
                
            </div><!-- /.box-body -->            
                    <asp:Label ID="lblUser" runat="server" Visible="False"></asp:Label>
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
        $("#btnEmployeeNewOrder").click(function (e) {
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
