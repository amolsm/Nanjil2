<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BoothPlaceOrder.aspx.cs" Inherits="Dairy.Tabs.Administration.BoothPlaceOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css">
    <script src="//code.jquery.com/jquery-1.10.2.js"></script>
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
       <section class="content-header">
          <h1>
             Place Order
            <small>Administration</small> 

          </h1>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Administration</a></li>
            <li class="active">Place Order For Booth</li>
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
            <div class="box-header with-border">
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
                       <asp:TextBox ID="txtGentOrderDate" class="form-control" type="date" runat="server" required></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 

                        <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <i class="fa fa-road"></i><span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:DropDownList ID="dpagentRoute" class="form-control" DataTextField="Name" DataValueField="RouteID" runat="server" AutoPostBack="true" OnSelectedIndexChanged = "dpagentRoute_SelectedIndexChanged" > 
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
                      <asp:DropDownList ID="dpAgent" class="form-control" DataTextField="Name" DataValueField="AgentID" runat="server" AutoPostBack="false" OnSelectedIndexChanged = "dpAgentpre_SelectedIndexChanged"   > 
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
                      <asp:DropDownList ID="dpBrand" class="form-control" DataTextField="CategoryName" DataValueField="CategoryId" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dpBrand_SelectedIndexChanged"> 
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->
                         </div>

                        <%--             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <i class="fa fa-rode"></i><span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:DropDownList ID="dpAgentSelasEMployee" class="form-control" DataTextField="Name" DataValueField="employeeID" runat="server"  > 
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->
                         </div>--%> 

                          </div>
                    <div class="col-md-12">
                              
                        <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <i class="fa fa-road"></i><span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:DropDownList ID="dpAgentProductType" class="form-control" DataTextField="TypeName" DataValueField="TypeID" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dpAgentProductType_OnSelectedIndexChanged"> 
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
                      <asp:DropDownList ID="dpAgentProductdetaisl" class="form-control" DataTextField="product"  AutoPostBack="true" OnSelectedIndexChanged="dpAgentProductdetaisl_SelectedIndexChanged" DataValueField="productId" runat="server"  > 
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->
                         </div>
              
             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtagentOrderqty" class="form-control"   placeholder="Quantity " runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
                 </div> 

<%--                    <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <i class="fa fa-road"></i><span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:DropDownList ID="dpAgentShemeApplied" class="form-control"   runat="server" AutoPostBack="true" OnSelectedIndexChanged="dpAgentShemeApplied_SelectedIndexChanged" > 
                          <asp:ListItem Value="0">--Selet Agent Scheme--</asp:ListItem>
                          <asp:ListItem Value="1">Apply</asp:ListItem>
                          <asp:ListItem Value="2">Not Apply</asp:ListItem>
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->
                         </div>--%>
                       
                          
                      

                      <%--  <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                        
                      <asp:TextBox ID="txtAgentAuto" class="form-control"  placeholder="Agent Name " runat="server"  ></asp:TextBox>                        
                        <asp:TextBox ID="txtAgentId" runat="server"  AutoPostBack = "true" />
                   
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                    
                       
                          
                      </div>  <!--autocomplete-->  --%>

                        
                        
                <asp:HiddenField id="hfAgentProductUnitPrice" runat="server" />
            
       
                </div>
             
                         <div class="col-md-12">
                            <%-- <asp:TextBox  ID="txtAgentId" class="form-control" AutoPostBack="true" runat="server" OnTextChanged="hfAgentAuto_Changed"  ></asp:TextBox>                        --%>
                              <div class="col-lg-4 ">

                              </div>
                             <div class="col-lg-4 ">
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="dpAgentProductdetaisl" InitialValue="0" runat="server" ErrorMessage="Please select Product" ValidationGroup="Add" ForeColor="#cc0000"></asp:RequiredFieldValidator>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="dpAgentProductType" InitialValue="0" runat="server" ErrorMessage="Please select Type" ValidationGroup="Add" ForeColor="#cc0000"></asp:RequiredFieldValidator>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="dpAgent" InitialValue="0" runat="server" ErrorMessage="Please select Agent" ValidationGroup="Add" ForeColor="#cc0000"></asp:RequiredFieldValidator>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="dpBrand" InitialValue="0" runat="server" ErrorMessage="Please select Brand" ValidationGroup="Add" ForeColor="#cc0000"></asp:RequiredFieldValidator>
                                 <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtagentOrderqty" ErrorMessage="Quantity Must be &gt; 0" Operator="GreaterThan" Type="Double" ValueToCompare="0" ValidationGroup="Add" ForeColor="#cc0000"/>
                              </div>
                             <div class="col-lg-4  pull-right">
                  <div class="form-group">
                    <div class="input-group">
                      
                   
                       
                        <asp:Button ID="btnAddAgentProductItem" class="btn btn-primary" runat="server" CommandName="MoveNext" OnClick="btnAddAgentProductItem_click"   Text="Add" ValidationGroup="Add"   />                    
                     &nbsp;   <asp:Button ID="btnAgentNewOrder" class="btn btn-primary" runat="server" CommandName="MoveNext"  OnClick="btnAgentNewOrder_clcik"    Text="New Order" ValidationGroup="none"   />                    
                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div>  
                             </div>
                          <div class="col-md-12" runat="server" id="divTable">
                          <table id="example1" class="table table-bordered table-striped">'
          <asp:Repeater ID="rpAgentOrderdetails" runat="server" OnItemDataBound="rpOrderitam_OnDataBinding" OnItemCommand="rpOrderitam_ItemCommand">
                
               <HeaderTemplate>
                  <thead>
                      <tr>
                         
                                        <th>Product</th>
                                        <th>By Product</th>
                                        <th>Product Code</th>
                                        <th>Quantity</th>
                                        <th>Unit Price</th> 
                                        <th>Total</th> 
                                        <th>Remove</th>
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
                                <td style="text-align:right"><asp:Label ID="lbltotal" runat="server" Text='<%# string.Format("{0:##,###.00}",Eval("Total"))%>'></asp:Label></td>
                      
                            
                         <td>   <asp:LinkButton ID="lbdelete" AlternateText="delete" ForeColor="Gray" OnItemCommand="lbdelete_ItemCommand" 
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
                        <div class="col-lg-4 pull-right" style="text-align:right">
                  <div class="form-group">
                    <div class="input-group">
                      
                       <asp:Button ID="btnAgentORderSubmit" class="btn btn-primary" runat="server" CommandName="MoveNext" OnClick="btnAgentORderSubmit_click"   Text="Submit" ValidationGroup="none"   />                    
                        &nbsp;
                         <asp:Button ID="btnagentItamsremove" class="btn btn-primary" runat="server" CommandName="MoveNext" OnClick="btnagentItamsremove_click"     Text="Remove Item" ValidationGroup=""   />  
                        
                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 

                     </asp:Panel>
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
</asp:Content>
