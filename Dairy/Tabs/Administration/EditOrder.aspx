<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditOrder.aspx.cs" Inherits="Dairy.Tabs.Administration.EditOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
     <link href="../../Theme/plugins/jQueryUI/jquery-ui.css" rel="stylesheet" />
    <script src="../../Theme/plugins/jQuery/jquery-1.10.2.min.js"></script>
    <script src="../../Theme/plugins/jQueryUI/jquery-ui.min.js"></script>
      <script type="text/javascript" src="../../Theme/bootstrap/js/bootstrap.min.js"></script>
     
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript" src="../../Theme/bootstrap/js/bootstrap.min.js"></script>
      <section class="content-header">
          <h1>
             Edit Orders
            <small>Reception</small> 

          </h1> <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Reception</a></li>
            <li class="active">Edit Orders</li>
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
                                <asp:Label runat="server" ID="lblSuccess" Text="Records Insert Succesfully"></asp:Label>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>

          <div class="box ">
            <div class="box-header with-border">
              <h3 class="box-title"> Orders List </h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-minus"></i></button>
                
              </div>
            </div>

              <div class="box-body">
              <div class="row">

                     <div class="col-lg-3">
                  <div class="form-group" >
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtDate" class="form-control"  type="date" placeholder="Date" runat="server" required  ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 
               <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <i class="fa fa-rode"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:DropDownList ID="dpBrand" class="form-control" DataTextField="Name" DataValueField="CategoryId" runat="server" > 
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->
                         </div>

                                  
           <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <i class="fa fa-rode"></i><span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:DropDownList ID="dpRoute" class="form-control" DataTextField="Name" DataValueField="RouteID" runat="server"  > 
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->
                         </div>
             
                 <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                               <asp:Button ID="btnViewDetails" class="btn btn-primary" runat="server" CommandName="MoveNext"  OnClick="btnViewDetails_Click"  Text="View Details"    />     
                       <%-- &nbsp; <asp:Button ID="btnPrint" class="btn btn-primary" runat="server" CommandName="MoveNext" OnClientClick="return PrintPanel();"   Text="Print"    />     --%>
                             
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 
                  </div>

            <div  id="datalist">
                   
                
                       

                                <asp:UpdatePanel runat="server" ID="uprouteList" UpdateMode="Conditional">
                    <ContentTemplate>

                <table id="example1" class="table table-bordered table-striped">
                   

                 
                      <asp:Repeater ID="rpOrderList" runat="server" OnItemCommand="rpOrderList_ItemCommand">
                
                
               <HeaderTemplate>
                  <thead>
                      <tr>
                           <th>Sr.No.</th> 
                          <th>Route</th>              
                          <th>Agent/Employee</th>
                                        <th>Product</th>
                           <th>Type</th>             
                                        <th>Quantity</th>
                                        <th>Edit</th>
                                        <%--<th>Delete</th>--%>
                          
                      </tr>
                    </thead>
                    <tbody>

                   
               </HeaderTemplate>
               <ItemTemplate>
                    <tr>
                            
                                <td><%# Container.ItemIndex + 1 %> </td>
                                <td><%# Eval("RouteName")%></td>
                                <td><%# (String.IsNullOrEmpty(Eval("AgentName").ToString()) ? Eval("EmployeeCode") +" "+ Eval("EmployeeName") : Eval("AgentCode") +" "+  Eval("AgentName"))%></td>
                                <td><%# (String.IsNullOrEmpty(Eval("ProductName").ToString()) ? "Scheme" : Eval("ProductName"))%></td>
                                <td><%# Eval("TypeName")%></td>
                                <td><%# ((Eval("Qty").ToString()=="0") ? "-" : Eval("Qty"))%></td>
                                       
                                        
                                        
                                        
                         
                         <td>
                             <asp:LinkButton ID="lbEdite" AlternateText="Edit" ForeColor="Gray" OnItemCommand="lbEdite_ItemCommand" 
                                                                    ToolTip="Edit" runat="server" CommandArgument='<%#Eval("OrderDetailsId") %>'
                                                                    CommandName="Edit">
                                 <%#  (String.IsNullOrEmpty(Eval("ProductName").ToString()) ? "Remove" : "Edit" ) %> 
                                 
                             </asp:LinkButton>

                         </td>
                         <%--<td>   <asp:LinkButton ID="lbdelete" AlternateText="delete" ForeColor="Gray" OnItemCommand="lbdelete_ItemCommand" 
                                                                    ToolTip="Delete" runat="server" CommandArgument='<%#Eval("OrderDetailsId") %>'
                                                                    CommandName="delete"><i class="fa fa-trash"></i></asp:LinkButton>
</td>--%>



                    </tr>
               </ItemTemplate>
                    <FooterTemplate>

                         </tbody>

                    <tfoot>
                      <tr>
                            <th>Sr.No.</th> 
                         <th>Route</th>              
                          <th>Agent/Employee</th>
                           <th>Product</th>
                           <th>Type</th>             
                            <th>Quantity</th>
                             <th>Edit</th>
                            <%-- <th>Delete</th>--%>
                                        
                      </tr>
                    </tfoot>

                    </FooterTemplate>
                                          </asp:Repeater>    
          
                    <asp:HiddenField id="hbankId" runat="server" />
             
                
                  
                     
                   
                  </table>
             </section>
                
                        </ContentTemplate>
                                              </asp:UpdatePanel>
                </div>

                  </div>
            <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="uprouteList">
            <ProgressTemplate>
                
                <div class="overlay">
                  <i class="fa fa-refresh fa-spin"></i>
                </div>

            </ProgressTemplate>
            </asp:UpdateProgress>


        </div>

            <asp:UpdatePanel ID="upModal" runat="server" UpdateMode="Conditional" >  
              <ContentTemplate>         
                      <!-- Modal -->
        <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" data-backdrop="false">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title" id="myModalLabel">Items</h4>
      </div>
      <div class="modal-body">
          <div class="box-body">
            
           
            

                <div class="col-lg-6">
                  <div class="form-group frmgrp" >
                    <div class="input-group">
                      <div class="input-group-addon">
                        <asp:Label runat="server" Text="Name"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtName" class="form-control" ToolTip="Name"  placeholder="Name" runat="server" disabled></asp:TextBox>                        
                    </div><!-- /.input group -->
                     
                  </div><!-- /.form group -->
    
                      </div>        <!-- --> 
                 <div class="col-lg-6">
                  <div class="form-group frmgrp" >
                    <div class="input-group">
                      <div class="input-group-addon">
                        <asp:Label runat="server" Text="Product"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtProductName" class="form-control" ToolTip="Product"  placeholder="Product" runat="server" disabled></asp:TextBox>                        
                    </div><!-- /.input group -->
                     
                  </div><!-- /.form group -->
    
                      </div>        <!-- --> 
                 <div class="col-lg-6">
                  <div class="form-group frmgrp" >
                    <div class="input-group">
                      <div class="input-group-addon">
                        <asp:Label runat="server" Text="Prv Quantity"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtPrvQuantity" class="form-control" ToolTip="Prv Quantity"  placeholder="Prv Quantity" runat="server" disabled></asp:TextBox>                        
                    </div><!-- /.input group -->
                     
                  </div><!-- /.form group -->
    
                      </div>        <!-- --> 
              <div class="col-lg-6">
                  <div class="form-group frmgrp" >
                    <div class="input-group">
                      <div class="input-group-addon">
                        <asp:Label runat="server" Text="Quantity"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtNewQuantity" class="form-control" ToolTip="Quantity"  placeholder="Quantity" runat="server" type="number"></asp:TextBox>                        
                    </div><!-- /.input group -->
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtNewQuantity"
        ErrorMessage="Quantity Required" ValidationGroup="Save" ForeColor="Red"></asp:RequiredFieldValidator>
                  <%--<asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtNewQuantity" ErrorMessage="Quantity Must be &gt; 0" Operator="GreaterThan" Type="Double" ValueToCompare="0" ValidationGroup="Save" ForeColor="#cc0000"/>--%>
                  </div><!-- /.form group -->
    
                      </div>        <!-- --> 

 
            </div>
      </div>
      <div class="modal-footer">
        <%--<button type="button" class="btn btn-default" data-dismiss="modal">Close</button>--%>
       <asp:Button ID="btnCloseModal" class="btn btn-default" runat="server" ValidationGroup="none" OnClick="btnCloseModal_Click" Text="Close" UseSubmitBehavior="false"  data-dismiss="modal"/>       
          <asp:Button ID="btnSubmit" class="btn btn-primary" runat="server" ValidationGroup="Save" OnClick="btnSubmit_Click" Text="Save" UseSubmitBehavior="true"  OnClientClick = "return Confirm('Are u Sure ?)" />       
                
      </div>
    </div>
  </div>
</div>     

                  </ContentTemplate>
             </asp:UpdatePanel> 
         </section>
     <script type = "text/javascript">
        


         //-->

         $(document).ready(function () {
             $('#example1').dataTable({
                 "bPaginate": false,
                 "paging": false

             });
         });
    </script>
  
  
</asp:Content>
