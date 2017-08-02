<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IndentMaterial.aspx.cs" Inherits="Dairy.Tabs.Purchase.IndentMaterial" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
     
    <link href="../../Theme/bootstrap/css/bootstrap-select.min.css" rel="stylesheet" />
    <script type="text/javascript" src="../../Theme/bootstrap/js/bootstrap-select.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  
    
        <section class="content-header">
          <h1>
             Indent Material
            <small>Admin</small> 

          </h1>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Indent Material</a></li>
            <li class="active">Admin</li>
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
                    <%--   <div class="col-lg-4">
                 <div class="form-group">
                   <div class="input-group">
                     <div class="input-group-addon">
                       <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                     </div>
                      <asp:TextBox ID="txtIndentDate" class="form-control" type="date"  placeholder="Date" runat="server" required></asp:TextBox>                        
                   </div><!-- /.input group -->

                 </div><!-- /.form group -->

                     
                       
                          
                     </div> --%>

                               <div class="col-lg-4">
                 <div class="form-group">
                   <div class="input-group">
                     <div class="input-group-addon">
                      <asp:Label Text="Req Date" runat="server"></asp:Label>
                     </div>
                      <asp:TextBox ID="txtTillDate" class="form-control" type="date"  placeholder="Date" runat="server" required></asp:TextBox>                        
                   </div><!-- /.input group -->

                 </div><!-- /.form group -->

                     
                       
                          
                     </div> 
                            
                            <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                      <asp:Label Text="Department" runat="server"></asp:Label>
                      </div>
                       <asp:DropDownList ID="dpDepartment" class="form-control selectpicker"  data-live-search="true" DataTextField="Name" DataValueField="ID" runat="server"   > 
                       </asp:DropDownList>
                        
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->
                         </div>

<%--                            <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <i class="fa fa-rode"></i><span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:TextBox ID="txtEmployee" class="form-control" runat="server" disabled></asp:TextBox>                        
                          
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->
                         </div>           --%>
                             
                               <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                      <asp:Label Text="Category" runat="server"></asp:Label>
                      </div>
                       <asp:DropDownList ID="dpCategory" class="form-control "  data-live-search="true" DataTextField="Name" DataValueField="ID" runat="server"  AutoPostBack="true" OnSelectedIndexChanged="dpCategory_SelectedIndexChanged" > 
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
                       <asp:DropDownList ID="dpItem" class="form-control "  data-live-search="true" DataTextField="Name" DataValueField="ID" runat="server"   > 
                        <asp:ListItem Value="0">---Select Category First---</asp:ListItem>
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
                      <asp:TextBox ID="txtQuantity" class="form-control" runat="server" type="number"></asp:TextBox>                        
                          
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->
                         </div>  
                             
                      <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <asp:Label Text="Purpose" runat="server"></asp:Label>
                      </div>
                      <asp:TextBox ID="txtPurpose" class="form-control" runat="server" ></asp:TextBox>                        
                          
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->
                         </div>           
                         
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
                                        <th>Item Desription</th>
                                        <th>Quantity</th>
                                        <th>Remove</th> 
                                       
                      </tr>
                    </thead>
                    <tbody>

                   
               </HeaderTemplate>
               <ItemTemplate>
                    <tr>
                                 
                                <td><%# Eval("srno")%></td>
                                <td><%# Eval("ItemName")%></td>                       
                                <td><%# Eval("ItemDescription")%></td>
                                <td><%# Eval("Quantity")%></td>
                               
                            
                         <td>   <asp:LinkButton ID="lbdelete" AlternateText="delete" ForeColor="Gray" OnItemCommand="lbdelete_ItemCommand" 
                                                                    ToolTip="Delete" runat="server" CommandArgument='<%#Eval("IndentCartId") %>'
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
                        <th style="text-align:right"> </th> 
                       
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
                      
                       <asp:Button ID="btnSubmitIndent" class="btn btn-primary" runat="server" CommandName="MoveNext" OnClick="btnSubmitIndent_Click"   Text="Submit" ValidationGroup="none"   />                    
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
               $("#<% =dpDepartment.ClientID %>").addClass("selectpicker");
               $("#dpDepartment").selectpicker();

               $("#<% =dpCategory.ClientID %>").addClass("selectpicker");
               $("#dpCategory").selectpicker();

                $("#<% =dpItem.ClientID %>").addClass("selectpicker");

           });

          
           </script>
    
  
</asp:Content>


