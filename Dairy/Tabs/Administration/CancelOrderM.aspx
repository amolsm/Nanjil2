<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CancelOrderM.aspx.cs" Inherits="Dairy.Tabs.Administration.CancelOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
     <script type="text/javascript" src="../../Theme/bootstrap/js/bootstrap.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript" src="../../Theme/bootstrap/js/bootstrap.min.js"></script>
      <section class="content-header">
          <h1>
             Cancel Orders
            <small>Reception</small> 

          </h1> <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Reception</a></li>
            <li class="active">Cancel Orders</li>
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
              <h3 class="box-title"><asp:Label runat="server" ID="lblHeaderTab" Text="Cancel Order From Booth"></asp:Label></h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-plus"></i></button>
                
              </div>
            &nbsp;</div>
            <div class="box-body">
              <div class="row">

                     <div class="col-lg-3">
                  <div class="form-group" >
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtBillNo" class="form-control"  placeholder="Enter Bill Number" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 
              
                                  
           <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <i class="fa fa-rode"></i><span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:DropDownList ID="dpBillType" class="form-control" runat="server"  > 
                           <asp:ListItem Value="0">---Select Type---</asp:ListItem>
                           <asp:ListItem Value="1">Agency </asp:ListItem>
                           <asp:ListItem Value="2">Employee</asp:ListItem>
                          <asp:ListItem Value="3">Local</asp:ListItem> 
                      </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->
                         </div>
             
                 <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                               <asp:Button ID="btnSearch" class="btn btn-primary" runat="server" CommandName="MoveNext"  OnClick="btnSearch_Click"  Text="Search"    />     
                     
                             &nbsp; <asp:Button ID="btnRefresh" class="btn btn-primary" runat="server" CommandName="MoveNext"  OnClick="btnRefresh_Click"  Text="Refresh"    />     
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 
                  </div>
                <asp:UpdatePanel runat="server" ID="upBooth">
                    <ContentTemplate>
                         <div id="datalistbooth">
                  <table id="example3" class="table table-bordered table-striped">
                      <thead>
                        <tr>
                          <th>Booth</th>              
                          <th>Name</th>
                            <th>Created By</th>
                          <th>Total Bill</th>
                          <th>Cancel</th>   
                        </tr>
                      </thead>
                      <tbody>
                        <tr>
                            <td> <asp:Label ID="lblBoothName" runat="server"></asp:Label></td>
                            <td> <asp:Label ID="lblName" runat="server"></asp:Label></td>
                            <td> <asp:Label ID="lblCreatedBy" runat="server"></asp:Label></td>
                            <td> <asp:Label ID="lblTotalBill" runat="server"></asp:Label></td>
                            <td> <asp:LinkButton runat="server" ID="lblCancelBooth" OnClick="lblCancelBooth_Click" OnClientClick="return alert('Are you Sure?');"></asp:LinkButton> <asp:HiddenField ID="hfBoothOrderId" runat="server" /> </td>
                        </tr>
                      </tbody>
                      <%--<tfoot>
                        <tr>
                          <th>Booth</th>              
                          <th>Name</th>
                          <th>Total Bill</th>
                          <th>Cancel</th>   
                        </tr>
                      </tfoot>--%>
                      </table>
              </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
             
            </div><!-- /.box-body -->   
              
                         
          </div>
      
    
          

   
    <div class="box ">
            <div class="box-header with-border">
              <h3 class="box-title"> Cancel Order From Reception </h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-minus"></i></button>
                
              </div>
            </div>
            <div class="box-body" >
                   
           <div class="row">

                     <div class="col-lg-3">
                  <div class="form-group" >
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtDate" class="form-control"  type="date" placeholder="Date" runat="server" ></asp:TextBox>                        
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
                          <th>Route</th>              
                          <th>Agent/Employee</th>
                          <th>Total Bill</th>
                          <th>Cancel</th>
                                        <%--<th>Delete</th>--%>
                          
                      </tr>
                    </thead>
                    <tbody>

                   
               </HeaderTemplate>
               <ItemTemplate>
                    <tr>
                            

                                <td><%# Eval("RouteName")%></td>
                                <td><%# (String.IsNullOrEmpty(Eval("AgentName").ToString()) ? Eval("EmployeeCode") +" "+ Eval("EmployeeName") : Eval("AgentCode") +" "+  Eval("AgentName"))%></td>
                                <td><%# Eval("TotalBill")%></td>
                                
                         <td>
                             <asp:LinkButton ID="lbEdite" AlternateText="Edit" ForeColor="Gray" OnItemCommand="lbEdite_ItemCommand" 
                                                                    ToolTip="Cancel" runat="server" CommandArgument='<%#Eval("OrderID") %>'
                                                                    CommandName="Edit" OnClientClick="return confirm('Are you sure??');">
                                Cancel
                                 
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
                         <th>Route</th>              
                          <th>Agent/Employee</th>
                          <th>Total Bill</th>
                          <th>Cancel</th>
                                        
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

          </section>
     <script type = "text/javascript">
         function Confirm() {
             var confirm_value = document.createElement("INPUT");
             confirm_value.type = "hidden";
             confirm_value.name = "confirm_value";
             if (confirm("Do you want to save data?")) {
                 confirm_value.value = "Yes";
                 document.forms[0].appendChild(confirm_value);

             } else {
                 confirm_value.value = "No";
                 document.forms[1].appendChild(confirm_value);
             }



         }


         //-->
      </script>
</asp:Content>