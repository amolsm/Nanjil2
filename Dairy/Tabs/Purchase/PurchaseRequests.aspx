<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PurchaseRequests.aspx.cs" Inherits="Dairy.Tabs.Purchase.PurchaseRequests" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
   <%--  <script type="text/javascript" src="../../Theme/bootstrap/js/bootstrap.min.js"></script>--%>
    <link href="../../Theme/bootstrap/css/bootstrap-select.min.css" rel="stylesheet" />
    <script type="text/javascript" src="../../Theme/bootstrap/js/bootstrap-select.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  
    
        <section class="content-header">
          <h1>
             Purchase Request
            <small>Purchase</small> 

          </h1>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Purchase Request</a></li>
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
                       <asp:Label Text="Item" runat="server"></asp:Label>
                      </div>
                       <asp:DropDownList ID="dpItem" class="form-control "  data-live-search="true" DataTextField="Name" DataValueField="ID" runat="server"   > 
                       
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
                       <asp:Label Text="Unit" runat="server"></asp:Label>
                      </div>
                       <asp:DropDownList ID="dpUnit" class="form-control " DataTextField="Name" DataValueField="ID" runat="server"   > 
                       
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
                       <asp:Label Text="Specification" runat="server"></asp:Label>
                      </div>
                      <asp:TextBox ID="txtSpecification" class="form-control" runat="server" ></asp:TextBox>                        
                          
                         
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

       <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <asp:Label Text="Remark" runat="server"></asp:Label>
                      </div>
                      <asp:TextBox ID="txtRemark" class="form-control" runat="server" ></asp:TextBox>                        
                          
                         
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
                          <table id="example1" class="table table-bordered table-striped">
          <asp:Repeater ID="rpRequestOrderdetails" runat="server" OnItemCommand="rpRequestOrderdetails_ItemCommand">
                
               <HeaderTemplate>
                  <thead>
                      <tr>
                         
                                        <th>Sr.No</th>
                                        <th>Item</th>
                                        
                                        <th>Quantity</th>
                                        <th>Store Stock</th>
                                        <th>Remove</th> 
                                       
                      </tr>
                    </thead>
                    <tbody>

                   
               </HeaderTemplate>
               <ItemTemplate>
                    <tr>
                                 
                                <td><%# Eval("srno")%></td>
                                <td><%# Eval("ItemName")%></td>                       
                                
                                <td><%# Eval("Quantity") +" "+Eval("UnitName")%></td>
                               <td><%# Eval("Stock")%></td>
                            
                         <td>   <asp:LinkButton ID="lbdelete" AlternateText="delete" ForeColor="Gray" OnItemCommand="lbdelete_ItemCommand" 
                                                                    ToolTip="Delete" runat="server" CommandArgument='<%#Eval("RequestCartId") %>'
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
                      
                       <asp:Button ID="btnSubmit" class="btn btn-primary" runat="server" CommandName="MoveNext" OnClick="btnSubmit_Click"   Text="Submit" ValidationGroup="none"   />                    
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
          
           $(document).ready(function () {
              

                $("#<% =dpItem.ClientID %>").addClass("selectpicker");
              
           });

          
           </script>
    
  
</asp:Content>

