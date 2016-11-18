

<%@ Page Title="" Language="C#" MasterPageFile="/Site.Master" AutoEventWireup="true" CodeBehind="PlaceOrder.aspx.cs" Inherits="Dairy.Tabs.Reception.PlaceOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
 
    <link href="../../Theme/plugins/jQueryUI/jquery-ui.css" rel="stylesheet" />
    <script src="../../Theme/plugins/jQuery/jquery-1.10.2.min.js"></script>
    <script src="../../Theme/plugins/jQueryUI/jquery-ui.min.js"></script>
     
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<%--    <script type="text/javascript">

        $(function () {
            $("#MainContent_txtGentOrderDate").datepicker({ dateFormat: 'dd/mm/yy' });
            $("#MainContent_txtEmployeeOrderDate").datepicker({ dateFormat: 'dd/mm/yy' });

        })
    </script>--%>
    

        <section class="content-header">
          <h1>
             Place Order
            <small>Reception</small> 

          </h1>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Reception</a></li>
            <li class="active">Place Order</li>
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
            
             <asp:RadioButton ID="rbAgent" Checked="true"   runat="server" OnCheckedChanged="rbAgent_chamged" Text="Agent" GroupName="ordertype" AutoPostBack="true"> </asp:RadioButton>&nbsp
             <asp:RadioButton ID="rbEmployee"  OnCheckedChanged="rbEmployee_chamged" runat="server" Text="Employee" GroupName="ordertype" AutoPostBack="true"></asp:RadioButton>
            </div>
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
                       <asp:TextBox ID="txtGentOrderDate" class="form-control" type="date"  runat="server" required></asp:TextBox>                        
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
                      <asp:DropDownList ID="dpAgent" class="form-control" DataTextField="Name" DataValueField="AgentID" runat="server" AutoPostBack="true" OnSelectedIndexChanged = "dpAgentpre_SelectedIndexChanged"  ValidationGroup="Add" > 
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
                      <asp:DropDownList ID="dpBrand" class="form-control" DataTextField="CategoryName" DataValueField="CategoryId" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dpBrand_SelectedIndexChanged" ValidationGroup="Add"> 
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
                      <asp:DropDownList ID="dpAgentProductType" class="form-control" DataTextField="TypeName" DataValueField="TypeID" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dpAgentProductType_OnSelectedIndexChanged" ValidationGroup="Add"> 
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
                      <asp:DropDownList ID="dpAgentProductdetaisl" class="form-control" DataTextField="product" AutoPostBack="true" OnSelectedIndexChanged="dpAgentProductdetaisl_SelectedIndexChanged" DataValueField="productId" runat="server" ValidationGroup="Add" > 
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
                       <asp:TextBox ID="txtagentOrderqty" class="form-control"   placeholder="Quantity " runat="server" ValidationGroup="Add"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
                 </div> 

                    <div class="col-lg-3">
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
                         </div>
                       
                          
                      

                        <div class="col-lg-3 pull-right">
                  <div class="form-group">
                    <div class="input-group">
                     
                      
                   
                        
                     <%-- <asp:TextBox ID="txtAgentAuto" class="form-control"  placeholder="Agent Name " runat="server"  ></asp:TextBox>                        
                        <asp:TextBox ID="txtAgentId" runat="server"  AutoPostBack = "true" />--%>
                   
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                    
                       
                          
                      </div>  <!--autocomplete-->  

                        
                        
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
                             <div class="col-lg-3  pull-right">
                  <div class="form-group">
                    <div class="input-group">
                      
                   
                       
                        <asp:Button ID="btnAddAgentProductItem" class="btn btn-primary" runat="server" CommandName="MoveNext" OnClick="btnAddAgentProductItem_click"   Text="Add" ValidationGroup="Add"   />                    
                     &nbsp;   <asp:Button ID="btnAgentNewOrder" class="btn btn-primary" runat="server" CommandName="MoveNext"  OnClick="btnAgentNewOrder_clcik"    Text="New Order" ValidationGroup="sb"   />                    
                        
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
                                        <th style="text-align:right">Unit Price</th> 
                                        <th style="text-align:right">Total</th> 
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
                        <th style="text-align:right"><asp:Label ID="lblFInaltotal" runat="server" Text='<%# Convert.ToDouble( Eval("Total")).ToString("#0.00")%>'></asp:Label></th> 
                      </tr>
                    </tfoot>

                    </FooterTemplate>
                                             
           </asp:Repeater>
                
           </table>
           <asp:HiddenField ID="hftotalAmout" runat="server" />
       </div> 
                        <div class="col-lg-3 pull-right" style="text-align:right">
                  <div class="form-group">
                    <div class="input-group">
                      
                       <asp:Button ID="btnAgentORderSubmit" class="btn btn-primary" runat="server" CommandName="MoveNext" OnClick="btnAgentORderSubmit_click"   Text="Submit" ValidationGroup="Submit"   />                    
                        &nbsp;
                         <asp:Button ID="btnagentItamsremove" class="btn btn-primary" runat="server" CommandName="MoveNext" OnClick="btnagentItamsremove_click"     Text="Remove Item" ValidationGroup=""   />  
                        
                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 

                     </asp:Panel>

                        <asp:Panel runat="server" ID="pnlEmployee" Visible="false">

                       
  <div class="col-md-12">
                        <div class="col-lg-4">
                  <div cl
                      ass="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtEmployeeOrderDate" class="form-control"  type="date" placeholder="Date" runat="server" required></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 
                            <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <i class="fa fa-road"></i><span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:DropDownList ID="dpEmploueeRoute" class="form-control" DataTextField="Name" DataValueField="RouteID" runat="server"  > 
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->
                         </div>

      <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <i class="fa fa-road"></i><span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:DropDownList ID="dpEmployee" AutoPostBack="true" OnSelectedIndexChanged="dpEmployee_IndexChanged" class="form-control" DataTextField="Name" DataValueField="employeeID" runat="server" ValidationGroup="EMployyeOrder" > 
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->
                         </div>

   <%--    <div class="col-lg-3">
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
                       
           
            
                        
              
              
       </div> 
      <div class="col-md-12">
          <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <i class="fa fa-road"></i><span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:DropDownList ID="dpEmployeeProductType" class="form-control" DataTextField="TypeName"  AutoPostBack="true" OnSelectedIndexChanged="dpEmployeeProducttype_IndexChanged"    DataValueField="TypeID" runat="server"  ValidationGroup="EMployyeOrder"> 
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->
                         </div>
           

           <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <i class="fa fa-road"></i><span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:DropDownList ID="dpEmployeeProductDetails" class="form-control"  AutoPostBack="true" OnSelectedIndexChanged="dpEmployeeProductDetails_IndexChanged"  runat="server" DataTextField="product"    DataValueField="productId"  ValidationGroup="EMployyeOrder"  > 
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
                       <asp:TextBox ID="txtQtyEmployee" class="form-control"   placeholder="Quantity " runat="server" ValidationGroup="EMployyeOrder"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 

           <asp:HiddenField ID="hfEmployeeProductUnitPrice" Value="0" runat="server" />
      
           <asp:HiddenField ID="hfTotalCansume" Value="0" runat="server" />
      
      </div>
  <div class="col-md-12">
                            <%-- <asp:TextBox  ID="txtAgentId" class="form-control" AutoPostBack="true" runat="server" OnTextChanged="hfAgentAuto_Changed"  ></asp:TextBox>                        --%>
                              <div class="col-lg-4 ">

                              </div>
                             <div class="col-lg-4 ">
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="dpEmployeeProductDetails" InitialValue="0" runat="server" ErrorMessage="Please select Product" ValidationGroup="EMployyeOrder" ForeColor="#cc0000"></asp:RequiredFieldValidator>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="dpEmployeeProductType" InitialValue="0" runat="server" ErrorMessage="Please select Type" ValidationGroup="EMployyeOrder" ForeColor="#cc0000"></asp:RequiredFieldValidator>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="dpEmployee" InitialValue="0" runat="server" ErrorMessage="Please select Employee" ValidationGroup="EMployyeOrder" ForeColor="#cc0000"></asp:RequiredFieldValidator>
                                <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ControlToValidate="dpBrand" InitialValue="0" runat="server" ErrorMessage="Please select Brand" ValidationGroup="EMployyeOrder" ForeColor="#cc0000"></asp:RequiredFieldValidator>--%>
                                 <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="txtQtyEmployee" ErrorMessage="Quantity Must be &gt; 0" Operator="GreaterThan" Type="Double" ValueToCompare="0" ValidationGroup="EMployyeOrder" ForeColor="#cc0000"/>
                              </div>
      <div class="col-lg-4 pull-right" style="text-align:right">
                  <div class="form-group">
                    <div class="input-group">
                      
                       <asp:Button ID="btnAddEmployeeOrderItem" class="btn btn-primary" OnClick="btnAddEmployeeOrderItem_clcik" runat="server" CommandName="MoveNext"   Text="Add" ValidationGroup="EMployyeOrder"   />                    
                        &nbsp;
                         <asp:Button ID="btnEmployeeNewOrder" class="btn btn-primary" runat="server" CommandName="MoveNext"  OnClick="btnEmployeeNewOrder_click"      Text="New Order" ValidationGroup="Nothing"   />  
                        
                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 
      </div>
      <div class="col-md-12" runat="server" id="div1">
            <table id="Table1" class="table table-bordered table-striped">'
          <asp:Repeater ID="rpEmployeeDetails" runat="server" OnItemDataBound="rpEmployeeID_OnDataBinding" OnItemCommand="rpEmployeeID_ItemCommand" >
                
               <HeaderTemplate>
                  <thead>
                      <tr>
                         
                                        <th>Product</th>
                                        <th>By Product</th>
                                        <th>Product Code</th>
                                        <th>Quantity</th>
                                        <th style="text-align:right">Unit Price</th> 
                                        <th style="text-align:right">Total</th> 
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
                                <td style="text-align:right"><%# string.Format("{0:##,###.00}", Eval("UnitCost"))%></td>
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
            <asp:HiddenField ID="hfemployeeTotalBill" Value="0" runat="server" />
       </div> 

      <div class="col-lg-4 pull-right" style="text-align:right">
                  <div class="form-group">
                    <div class="input-group">
                      
                       <asp:Button ID="Button1" class="btn btn-primary" runat="server" CommandName="MoveNext" OnClick="btnemployeeOrdersubmit_click"   Text="Submit"     />                    
                        &nbsp;
                         <asp:Button ID="Button2" class="btn btn-primary" runat="server" CommandName="MoveNext"      Text="Remove Item" ValidationGroup="x" OnClick="btnemployeeRemoveAllItem_click"   />  
                        
                        
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


    <script type="text/javascript">
        $(function () {
            $("[id$=txtAgentAuto]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "PlaceOrder.aspx/GetCustomers",
                        data: "{ 'prefix': '" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    label: item.split('-')[0],
                                    val: item.split('-')[1]
                                }
                            }))
                        },
                        error: function (response) {
                            alert(response.responseText);
                        },
                        failure: function (response) {
                            alert(response.responseText);
                        }
                    });
                },
                select: function (e, i) {
                    $("[id$=txtAgentId]").val(i.item.val);
                    
                },
                minLength: 1,
                change: function (event, ui) { Confirm(); }

            });
        });
    </script>

     
    



    <%--<script type = "text/javascript"> //autocomplete confirm
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Do you want Previous Order?")) {
                //confirm_value.value = "Yes";
                PageMethods.OnTextChanged(document.getElementById("<%=txtAgentId.ClientID%>").value);
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>--%>
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

 <%--   <script type="text/javascript">
        function alertMessage() {
            alert('Please Check Stock!!');
        }
    </script>--%>
</asp:Content>
