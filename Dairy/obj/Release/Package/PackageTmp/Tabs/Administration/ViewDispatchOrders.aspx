<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewDispatchOrders.aspx.cs" Inherits="Dairy.Tabs.Administration.ViewDispatchOrders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" href="http://localhost:2367/code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css">
    
    <script src="//code.jquery.com/jquery-1.10.2.js"></script>
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
     <script type="text/javascript">
         Sys.WebForms.PageRequestManager.getInstance().add_endRequest(InIEvent);
         function InIEvent() {

             $(function () {
                 $("#example1").DataTable();
                 $('#example2').DataTable({
                     "paging": true,
                     "lengthChange": false,
                     "searching": true,
                     "ordering": true,
                     "info": true,
                     "autoWidth": false
                 });
             });
         }
    </script>
   
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  
   
    <section class="content-header">
          <h1>
             View Dispatch Orders
          </h1>

          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Administration</a></li>
            <li class="active">View Dispatch Orders</li>
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
          <!-- Default box -->
             <div class="box collapsed-box" id ="myBox">
            <div class="box-header with-border">
              <h3 class="box-title"><asp:Label ID="lbltital" runat="server" Text="Dispatch Information"></asp:Label> </h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-plus"></i></button>
                
              </div>
            </div>
            <div class="box-body">
               
              
                      <asp:UpdatePanel runat="server" ID="upMain" UpdateMode="Conditional">
                    <ContentTemplate>           
        
               <div class="box box-solid box-default" style="margin-bottom:5px !important;" >
                 <div class="box-body">

                <div class="col-lg-2">
                  <div class="form-group" >
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtOrderID" class="form-control" ToolTip="Order Id"  placeholder="Order ID" runat="server" ValidationGroup="edit" ReadOnly="true" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
    
                      </div>        <!-- --> 

                <div class="col-lg-3">
                  <div class="form-group" >
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtAgentName" class="form-control" ValidationGroup="edit" ToolTip="Agent Name" placeholder="Agent Name" runat="server" ReadOnly="true" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
    
                      </div>        <!-- -->

                <div class="col-lg-2">
                  <div class="form-group" >
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtCommodityName" ToolTip="Commodity Name" class="form-control" ValidationGroup="edit"  placeholder="Commodity Name" runat="server" ReadOnly="true" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
    
                      </div>        <!-- -->

                <div class="col-lg-2">
                  <div class="form-group" >
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtQuantity" class="form-control" ValidationGroup="edit" ToolTip="Quantity" placeholder="Quantity" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
    
                      </div>        <!-- -->
                     

                <div class="col-lg-2">
                  <div class="form-group">
                    <div class="input-group">
                       <asp:Button ID="btnUpdate" class="btn btn-primary" ValidationGroup="edit" runat="server" CommandName="MoveNext" Text="Update" OnClick="btnClick_btnUpdate"/>     
                       
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 

                <div class="col-lg-3">
                  <div class="form-group" >
                    <div class="input-group">
                      
                       <asp:TextBox ID="txtOrderDetailsId" class="form-control"  ValidationGroup="edit" ToolTip="Order Details Id" placeholder="Order Details Id" runat="server"  ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
    
                      </div>        <!-- -->
                
                     
                      </div><!-- /.box-body -->
                </div>
                     
                    </ContentTemplate>
                </asp:UpdatePanel>
                 
                
            </div><!-- /.box-body -->    
                 <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="upMain">
            <ProgressTemplate>
                
                <div class="overlay">
                  <i class="fa fa-refresh fa-spin"></i>
                </div>

            </ProgressTemplate>
            </asp:UpdateProgress>
                       
          </div><!-- /.box -->

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
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtOrderDate" type="date" class="form-control"   placeholder="Order Date" ToolTip="Order Date" runat="server" required ValidationGroup="search"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 

            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <i class="fa fa-rode"></i><span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:DropDownList ID="dpagentRoute" ValidationGroup="search" class="form-control" DataTextField="Name" DataValueField="RouteID" runat="server"  > 
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
                      <asp:DropDownList ID="dpCategory" ValidationGroup="search" class="form-control" DataTextField="Name" DataValueField="CategoryId" runat="server"  > 
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->
                         </div>

             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <asp:Button ID="Button1" class="btn btn-primary" ValidationGroup="search" runat="server" CommandName="MoveNext" Text="Search" OnClick="btnClick_btnSearch" />     
                       &nbsp;
                        <asp:Button ID="btnNewDispatch" class="btn btn-primary" ValidationGroup="none" runat="server" Text="New Dispatch" OnClick="btnNewDispatch_Click" />     
                      
                        
                    
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 

                </div>
            <div class="col-md-12">

                <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                     
                          &nbsp;
                         <button id="btnSubmitModal" runat="server" type="button" class="btn btn-primary btn-lg" data-toggle="modal" data-target="#myModal"  >
                        Submit
                        </button>
                    
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 

            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                     <asp:Button ID="btnPrintSummary" class="btn btn-primary" runat="server" CommandName="MoveNext" Text="Print Dispatch Summary" OnClientClick="return PrintPanel();" />
                         
                    
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 

                <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                    <asp:Button ID="btnPrintGatePass" class="btn btn-primary" runat="server" CommandName="MoveNext" Text="Print Gate Pass" OnClientClick="return PrintPanelGP();" />
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 

                </div>
            
                    <%--   <asp:Button ID="btnSubmitModal" class="btn btn-primary" runat="server" Text="Submit" data-toggle="modal" data-target="#myModal" />     --%>
                   
                

            <!-- Bootstrap Modal Dialog -->
        <!-- Button trigger modal -->


        <!-- Modal -->
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
          <asp:Button ID="btnSubmit" class="btn btn-primary" runat="server" ValidationGroup="saved" OnClick="btnSubmit_Click" Text="Save changes" UseSubmitBehavior="false" OnClientClick="Confirms()" data-dismiss="modal"/>     
      </div>
    </div>
  </div>
</div>
             


              
        </div><!-- /.box-body -->
      </div>
                     
                    </ContentTemplate>
                </asp:UpdatePanel>
                 
                
            </div><!-- /.box-body --> 
                     
                <%--  <div class="box ">
            <div class="box-header with-border">
              <h3 class="box-title"> Dispatch List </h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-minus"></i></button>
                
              </div>
            </div>--%>
                       
                <div class="box-body" id="datalist">
               

                <asp:UpdatePanel runat="server" ID="uprouteList" UpdateMode="Conditional">
                    <ContentTemplate>

                <table id="example1" class="table table-bordered table-striped">
                   

                 

                <asp:Repeater ID="rpRouteList" runat="server" OnItemCommand="rpRouteList_ItemCommand">
                
               <HeaderTemplate>
                  <thead>
                      <tr>
                          <th>Order ID</th>
                          <th>Order Date</th>
                          <th>Route Name</th>
                          <th>Agent/Employee Name</th>
                          <th>Product Name</th>                        
                          <th>Commodity Name</th>
                          <th>Quantity</th>
                          
                      </tr>
                    </thead>
                    <tbody>

                   
               </HeaderTemplate>
               <ItemTemplate>
                    <tr>
                        <td><%# Eval("OrderId")%></td>
                        <td><%# Eval("OrderDate")%></td>
                        <td><%# Eval("RouteName")%></td>
                        <%--<td><%# Eval("AgentName")%></td>--%>

                       <td> <%#(String.IsNullOrEmpty(Eval("AgentName").ToString()) ? Eval("EmployeeName") : Eval("AgentName"))%></td>
                        <td><%# Eval("ProductName")%></td>
                        <td><%# Eval("CommodityName")%></td>
                        <td><%# Eval("Qty")%></td>
                        <td>

                             <asp:LinkButton ID="lbEdite" AlternateText="Edit" ForeColor="Gray" OnItemCommand="lbEdite_ItemCommand" 
                                                                    ToolTip="Edit" runat="server" CommandArgument='<%#Eval("Row") %>'
                                                                    CommandName="Edit"><i class="fa fa-edit"></i></asp:LinkButton>

                         </td>
                         
                    </tr>
               </ItemTemplate>
                    <FooterTemplate>

                         </tbody>

                    <tfoot>
                      <tr>
                          <th>Order ID</th>
                          <th>Order Date</th>
                          <th>Route Name</th>
                           <th>Agent/Employee Name</th>
                          <th>Product Name</th>                        
                          <th>Commodity Name</th>
                          <th>Quantity</th>
                      </tr>
                    </tfoot>

                    </FooterTemplate>
                                             
           </asp:Repeater>
                    <asp:HiddenField id="hfRow" runat="server" />
             
                
                  
                     
                   
                  </table>
               
                
                        </ContentTemplate>
                </asp:UpdatePanel>
  
                <asp:UpdatePanel runat="server" ID="upDispatchSummary" UpdateMode="Conditional">
                    <ContentTemplate>
                    <asp:Panel runat="server" ID="pnlDispatchSummary">
                        <asp:Literal runat="server" ID="DispatchSummary"></asp:Literal>
              </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <asp:UpdatePanel runat="server" ID="upGatePass" UpdateMode="Conditional">
                    <ContentTemplate>
                    <asp:Panel runat="server" ID="pnlGatePass">
                        <asp:Literal runat="server" ID="GatePass"></asp:Literal>
              </asp:Panel>
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
                <asp:UpdateProgress ID="UpdateProgress4" runat="server" AssociatedUpdatePanelID="upDispatchSummary">
            <ProgressTemplate>
                
                <div class="overlay">
                  <i class="fa fa-refresh fa-spin"></i>
                </div>

            </ProgressTemplate>
            </asp:UpdateProgress>
                <asp:UpdateProgress ID="UpdateProgress5" runat="server" AssociatedUpdatePanelID="upGatePass">
            <ProgressTemplate>
                
                <div class="overlay">
                  <i class="fa fa-refresh fa-spin"></i>
                </div>

            </ProgressTemplate>
            </asp:UpdateProgress>
                           
          </div><!-- /.box -->
        </section>
    
    
    <script type="text/javascript">

        $(function () {
            // $("#MainContent_txtOrderDate").datepicker({ dateFormat: 'dd/mm/yy' });
            // $("#MainContent_txtEmployeeOrderDate").datepicker({ dateFormat: 'dd/mm/yy' });
            // $("#MainContent_txtCustamerorderDate").datepicker({ dateFormat: 'dd/mm/yy' });
            $('#myModal').on('shown.bs.modal', function () {
                $('#myInput').focus()
            })
        })
    </script>

    <script type="text/javascript">
        function validate() {
            var driver = document.getElementById('<%=dpDriver.ClientID %>').value;
            var salesman = document.getElementById('<%=dpSalesman.ClientID %>').value;
            var vehicle = document.getElementById('<%=dpVehicle.ClientID %>').value;
            var trays = document.getElementById('<%=txtTraysDispached.ClientID %>').value;

            if (salesman == 0) {
                alert("Please select Salesman");
                return false;
            }
            else if (vehicle == 0) {
                alert("Please select Vehicle");
                return false;
            }
            else if (driver == 0) {
                alert("Please select driver");
                return false;
            }
            else if (trays == "") {
                alert("Trays should not blank");
                return false;
            }
            else if (trays == 0) {
                alert("Trays should be greater than 0");
                return false;
            }
            
        }
    </script>    
    
    <script type = "text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("<%=pnlDispatchSummary.ClientID %>");
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
        function PrintPanelGP() {
            var panel = document.getElementById("<%=pnlGatePass.ClientID %>");
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
    <script type = "text/javascript">
        function Confirms() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";

            var driver = document.getElementById('<%=dpDriver.ClientID %>').value;
            var salesman = document.getElementById('<%=dpSalesman.ClientID %>').value;
            var vehicle = document.getElementById('<%=dpVehicle.ClientID %>').value;
            var trays = document.getElementById('<%=txtTraysDispached.ClientID %>').value;

            if (salesman == 0) {
                alert("Please select Salesman");
                return false;
            }
            else if (vehicle == 0) {
                alert("Please select Vehicle");
                return false;
            }
            else if (driver == 0) {
                alert("Please select driver");
                return false;
            }
            else if (trays == "") {
                alert("Trays should not blank");
                return false;
            }
            else if (trays == 0) {
                alert("Trays should be greater than 0");
                return false;
            }
            
            if (confirm("Do you want to save data?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }

        function Closepopup() {
            $('#myModal').modal('hide');

        }

    </script>
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
    
      
</asp:Content>
