<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditDispatchs.aspx.cs" Inherits="Dairy.Tabs.Administration.EditDispatchs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    
     <script type="text/javascript" src="../../Theme/bootstrap/js/bootstrap.min.js"></script>
   
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  <script type="text/javascript" src="../../Theme/bootstrap/js/bootstrap.min.js"></script>
   
    <section class="content-header">
          <h1>
             Edit Dispatch Orders
          </h1>

          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Dispatch</a></li>
            <li class="active">Edit Dispatch Orders</li>
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
               
              
                      <asp:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Conditional">
                    <ContentTemplate>           
        
               <div class="box  box-default" style="margin-bottom:5px !important;" >
        <div class="box-header" style="padding:0px 0px 0px 10px !important">
          
        </div><!-- /.box-header -->
        <div class="box-body">
            <div class="col-md-12">

             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <asp:Label runat="server" Text="ID"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtDispatchId" class="form-control" type="number"  placeholder="Enter Dispatch Summary Id" ToolTip="Dispatch Summary ID" runat="server" required ValidationGroup="search"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 

           

             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <asp:Button ID="btnSearch" class="btn btn-primary" ValidationGroup="search" runat="server" CommandName="MoveNext" Text="Search" OnClick="btnSearch_Click" />     
                        
                                               
                    
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 

                <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                     <asp:Button ID="btnSubmitOne" class="btn btn-primary" ValidationGroup="none" runat="server" CommandName="MoveNext" Text="Submit" Visible="false" OnClick="btnSubmitOne_Click" />                       
                    
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 

                </div>
          


              
        </div><!-- /.box-body -->
      </div>
                     
                    </ContentTemplate>
                </asp:UpdatePanel>
                 
                
            </div><!-- /.box-body --> 
                     
               
                       
                <div class="box-body" id="datalist">
               

                <asp:UpdatePanel runat="server" ID="uprouteList" UpdateMode="Conditional">
                    <ContentTemplate>

                <table id="example1" class="table table-bordered table-striped">
                   

                 

                <asp:Repeater ID="rpRouteList" runat="server" OnItemCommand="rpRouteList_ItemCommand">
                
               <HeaderTemplate>
                  <thead>
                      <tr>
                          <%--<th>Order ID</th>--%>
                          <th>Date</th>
                          <th>Dispatch Id</th>
                          <th>Route Name</th>
                          <th>Agent/Employee Name</th>
                          <th>Product Name</th>                        
                          
                          <th>Quantity</th>
                          <th>Edit</th>
                          
                      </tr>
                    </thead>
                    <tbody>

                   
               </HeaderTemplate>
               <ItemTemplate>
                    <tr>
                        <%--<td><%# Eval("OrderId")%></td>--%>
                        <td><%# Eval("DispatchDate")%></td>
                        <td>DS<%# Eval("DI_Id")%></td>
                        <td><%# Eval("RouteName")%></td>
                        
                       <td> <%#  String.IsNullOrEmpty(Eval("AgentName").ToString()) ? Eval("EmployeeCode") +" " + Eval("EmployeeName") : Eval("AgentCode")+" " + Eval("AgentName") %></td>
                        <td><%# Eval("ProductName")%></td>
                       
                        <td><%# Eval("DD_NewQuantity")%></td>
                        <td>

                             <asp:LinkButton ID="lbEdite" AlternateText="Edit" ForeColor="Gray" OnItemCommand="lbEdite_ItemCommand" 
                                                                    ToolTip="Edit" runat="server" CommandArgument='<%#Eval("DispatchDetailsId") %>'
                                                                    CommandName="Edit"><i class="fa fa-edit"></i></asp:LinkButton>

                         </td>
                         
                    </tr>
               </ItemTemplate>
                    <FooterTemplate>

                         </tbody>

                    <tfoot>
                      <tr>
                           <%--<th>Order ID</th>--%>
                          <th>Date</th>
                          <th>Dispatch Id</th>
                          <th>Route Name</th>
                          <th>Agent/Employee Name</th>
                          <th>Product Name</th>                        
                          
                          <th>Quantity</th>
                          <th>Edit</th>
                      </tr>
                    </tfoot>

                    </FooterTemplate>
                                             
           </asp:Repeater>
                    <asp:HiddenField id="hfRow" runat="server" />
             
                
                  
                     
                   
                  </table>
               
                
                        </ContentTemplate>
                </asp:UpdatePanel>
  
               
            


 


            </div><!-- /.box-body --> 
                   <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
            <ProgressTemplate>
                
                <div class="overlay">
                  <i class="fa fa-refresh fa-spin"></i>
                </div>

            </ProgressTemplate>
            </asp:UpdateProgress>
                <asp:UpdateProgress ID="UpdateProgress3" runat="server" AssociatedUpdatePanelID="uprouteList">
            <ProgressTemplate>
                
                <div class="overlay">
                  <i class="fa fa-refresh fa-spin"></i>
                </div>

            </ProgressTemplate>
            </asp:UpdateProgress>
                           
          </div><!-- /.box -->
          <asp:HiddenField ID="hfId" runat="server" />
        </section>

     <!-- Modal -->
        <div class="modal fade" id="myModalEdit" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title">Edit Order Quantity</h4>
      </div>
      <div class="modal-body">
          <div class="box-body">
              
              
              <div class="col-lg-6">
                  <div class="form-group" >
                    <div class="input-group">
                      <div class="input-group-addon">
                       <i class="fa fa-rode"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtProductName" ValidationGroup="mdl1" class="form-control" ToolTip="Product Name" runat="server"  ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
    
                      </div>        <!-- -->

              <div class="col-lg-6">
                  <div class="form-group" >
                    <div class="input-group">
                      <div class="input-group-addon">
                       <i class="fa fa-rode"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtPrvQuantity" ValidationGroup="mdl1" class="form-control" Type="number"  ToolTip="Previous Quantity" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
    
                      </div>        <!-- -->

              <div class="col-lg-6">
                  <div class="form-group" >
                    <div class="input-group">
                      <div class="input-group-addon">
                       <i class="fa fa-rode"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtNewQuantity" ValidationGroup="mdl1" class="form-control" Type="number"  ToolTip="New Quantity"  placeholder="Enter New Quantity" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
    
                      </div>        <!-- -->

              <asp:HiddenField ID="hfDetailsId" runat="server" />
            </div>
         
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
        <%--<button type="button" class="btn btn-primary" >Save changes</button>--%>
          <asp:Button ID="btnEditSubmit" class="btn btn-primary" runat="server" ValidationGroup="mdl1" OnClick="btnEditSubmit_Click" Text="Save changes" OnClientClick="return confirm('Are you sure ?');" />     
      </div>
    </div>
  </div>
</div>
     <!-- Modal 1 -->
    <asp:UpdatePanel ID="upModal" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            
        <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title" id="myModalLabel">Submit Dispatch</h4>
      </div>
      <div class="modal-body">
          <div class="box-body">
              <div class="col-lg-6">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <i class="fa fa-rode"></i><span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:DropDownList ID="dpSalesman" ValidationGroup="mgrp" class="form-control" DataTextField="Name" DataValueField="EmployeeID" runat="server"  > 
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->
                         </div>

              <div class="col-lg-6">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <i class="fa fa-rode"></i><span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:DropDownList ID="dpSalesman2" ValidationGroup="none" class="form-control" DataTextField="Name" DataValueField="EmployeeID" runat="server"  > 
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->
                         </div>

              <div class="col-lg-6">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <i class="fa fa-rode"></i><span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:DropDownList ID="dpDriver" ValidationGroup="mgrp" class="form-control" DataTextField="Name" DataValueField="EmployeeID" runat="server"  > 
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->
                         </div>

              <div class="col-lg-6">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <i class="fa fa-rode"></i><span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:DropDownList ID="dpDriver2" ValidationGroup="none" class="form-control" DataTextField="Name" DataValueField="EmployeeID" runat="server"  > 
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->
                         </div>

              <div class="col-lg-6">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <i class="fa fa-rode"></i><span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:DropDownList ID="dpVehicle" ValidationGroup="mgrp" class="form-control" DataTextField="Name" DataValueField="TM_Id" runat="server"  > 
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->
                         </div>

              <div class="col-lg-6">
                  <div class="form-group" >
                    <div class="input-group">
                      <div class="input-group-addon">
                       <i class="fa fa-rode"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtTraysDispached" ValidationGroup="mgrp" class="form-control" Type="number"  ToolTip="Trays Dispatched" placeholder="Trays Dispatched" runat="server"  ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
    
                      </div>        <!-- -->

              <div class="col-lg-6">
                  <div class="form-group" >
                    <div class="input-group">
                      <div class="input-group-addon">
                       <i class="fa fa-rode"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtIceBox" ValidationGroup="none" class="form-control" Type="number"  ToolTip="Ice Box Dispatched"  placeholder="Ice Box Dispatched" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
    
                      </div>        <!-- -->

              <div class="col-lg-6">
                  <div class="form-group" >
                    <div class="input-group">
                      <div class="input-group-addon">
                       <i class="fa fa-rode"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtCartons" ValidationGroup="none" class="form-control" Type="number"  ToolTip="Cartons/Ice Pads Dispatched"  placeholder="Cartons/Ice Pads Dispatched" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
    
                      </div>        <!-- -->

              <div class="col-lg-6">
                  <div class="form-group" >
                    <div class="input-group">
                      <div class="input-group-addon">
                       <i class="fa fa-rode"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtOthers" ValidationGroup="none" class="form-control" Type="number" ToolTip="Others Dispatched"  placeholder="Others Dispatched" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
    
                      </div>        <!-- -->
           <%--   <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtTraysDispached" runat="server" ErrorMessage="Trays Required"  ValidationGroup="mgrp" ForeColor="#cc0000"></asp:RequiredFieldValidator>
           <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtTraysDispached" ErrorMessage="Trays Must be &gt; 0" Operator="GreaterThan" Type="Double" ValueToCompare="0" ValidationGroup="mgrp" ForeColor="#cc0000"/>
         --%>  
            </div>
         <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="dpSalesman" InitialValue="0" runat="server" ErrorMessage="Please select Salesman"  ValidationGroup="mgrp" ForeColor="#cc0000"></asp:RequiredFieldValidator>
           <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="dpDriver" InitialValue="0" runat="server" ErrorMessage="Please select Driver"  ValidationGroup="mgrp" ForeColor="#cc0000"></asp:RequiredFieldValidator>
           <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="dpVehicle" InitialValue="0" runat="server" ErrorMessage="Please select Vehicle"  ValidationGroup="mgrp" ForeColor="#cc0000"></asp:RequiredFieldValidator>
     --%>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
        <%--<button type="button" class="btn btn-primary" >Save changes</button>--%>
          <asp:Button ID="btnSubmitModal" class="btn btn-primary" runat="server" ValidationGroup="saved" OnClick="btnSubmitModal_Click" Text="Save changes" UseSubmitBehavior="false" OnClientClick="Confirms()" data-dismiss="modal"/>     
      </div>
    </div>
  </div>
</div>
    
        </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript">

        $(function showmodal() {
            $('#myModal').modal();
        })
    </script>

   
      
</asp:Content>
