<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MilkColdRoomTemperature.aspx.cs" Inherits="Dairy.Tabs.Production.ColdRoomTemperatureForMilk" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
      <link href="../../Theme/plugins/jQueryUI/jquery-ui.css" rel="stylesheet" />
        <script src="../../Theme/plugins/jQuery/jquery-1.10.2.min.js"></script>
        <script src="../../Theme/plugins/jQueryUI/jquery-ui.min.js"></script>
        <style type="text/css">.cntrlbtm {    margin-bottom: 1px;} </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section class="content-header">
            <h1>
              Milk Cold Room Temperature     
              </h1> 
              <ol class="breadcrumb">
                <li><a href="#"><i class="fa fa-dashboard"></i> Administration</a></li>
                <li class="active">MilkColdRoomTemperature</li>
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

       <div id="bx1" class="box collapsed-box">

            <div class="box-header with-border">
              <h3 class="box-title"><asp:Label ID="lblHeaderTab" runat="server" Text="Milk Cold Room Temperature Details"></asp:Label> </h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-plus"></i></button>
                
              </div>
            </div>
            <div class="box-body">

                              <asp:UpdatePanel runat="server" ID="upMain" UpdateMode="Conditional">
              <ContentTemplate>
        
              <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
                          <asp:Label ID="Label14" runat="server" Text="Batch No"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtBatchNo" class="form-control"   placeholder="Batch No " runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Pls Enter Batch No " ControlToValidate="txtBatchNo" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
                 </div>

              <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
                          <asp:Label ID="lblDate" runat="server" Text="Date"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtDate" class="form-control" type="date" runat="server" required></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
                </div>                
                          
                       

              <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group ">
                      <div class="input-group-addon">                    
                        <asp:Label ID="Label1" runat="server" Text="Shift"></asp:Label>

                      </div>
                      <asp:DropDownList ID="dpShiftDetails" class="form-control" DataValueField="ShiftId" DataTextField="Name"   runat="server"  > 
                       </asp:DropDownList>                        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator InitialValue="0" ID="Req_ID" Display="Dynamic" 
                             ValidationGroup="Save" runat="server" ControlToValidate="dpShiftDetails" ForeColor="Red"
                             ErrorMessage="Pls Select Shift Detail" >
                         </asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
               </div>

                 
<%--                      <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                          <asp:Label ID="lblQty" runat="server" Text="Cold Rooms For Milk"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtColdRoomsForMilk" class="form-control"   placeholder="Enter Cold" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Pls Enter Cold Rooms For Milk" ControlToValidate="txtColdRoomsForMilk" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
                 </div>--%>

                  <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label2" runat="server" Text="Cold Room1 "></asp:Label>
                      </div>
                       <asp:TextBox ID="txtColdRoom1" class="form-control"   placeholder="Enter Cold Room1 " runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Pls Enter Cold Room1" ControlToValidate="txtColdRoom1" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
                 </div>
                     
                  
                      <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label3" runat="server" Text="Cold Room2"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtColdRoom2" class="form-control"   placeholder="Enter Cold Room2" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Pls Enter Cold Room2" ControlToValidate="txtColdRoom2" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
                 </div>

                   <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label4" runat="server" Text="Cold Room3"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtColdRoom3" class="form-control"   placeholder="Enter Cold Room3" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Pls Enter Cold Room3" ControlToValidate="txtColdRoom3" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
                 </div>


                      <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label5" runat="server" Text="Checked By"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtCheckedBy" class="form-control"   placeholder="Enter Checked By" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Pls Enter Checked By" ControlToValidate="txtCheckedBy" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
                 </div>


                      <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label6" runat="server" Text="verifier By"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtverifierBy" class="form-control"   placeholder="Enter verifier By" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Pls Enter verifier By" ControlToValidate="txtverifierBy" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
                 </div>

                  <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label8" runat="server" Text="B/D & Services"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtBreakDownAndServices" class="form-control"   placeholder="Enter B/D & Services" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="Pls Enter B/D & Services" ControlToValidate="txtBreakDownAndServices" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
                 </div>

                                <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">                    
                        <asp:Label ID="Label7" runat="server" Text="Status"></asp:Label>

                      </div>
                      <asp:DropDownList ID="dpStatusDetailsId" class="form-control" DataValueField="StatusId" DataTextField="Name"   runat="server"  > 
                       </asp:DropDownList>                        
                    </div><!-- /.input group -->
                    <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator1" Display="Dynamic" 
                             ValidationGroup="Save" runat="server" ControlToValidate="dpStatusDetailsId" ForeColor="Red"
                             ErrorMessage="Pls Select Status Detail" >
                        </asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
               </div>


                 

                <div class="col-lg-3 pull-right">
                  <div class="form-group">
                    <div class="input-group">
                        <asp:Button ID="btnAdd" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Add" ValidationGroup="Save" OnClick="btnAdd_Click" /> &nbsp;    
                        <asp:Button ID="btnUpdate" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Update" ValidationGroup="Save" OnClick="btnUpdate_Click" /> &nbsp;    
                        <asp:Button ID="btnRefresh" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Refresh" ValidationGroup="Refresh" OnClick="btnRefresh_Click" /> &nbsp;                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->                        
                     


  
                 </div>
              </ContentTemplate> 
            </asp:UpdatePanel>
         </div><!-- /.box-body -->            
     </div><!-- /.box -->

                            <div class="box ">
            <div class="box-header with-border">
              <h3 class="box-title"> Milk Cold Room Temperature List </h3>
              <div class="box-tools pull-right" style="right: 4px; top: 4px">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-minus"></i></button>
                
              </div>
            </div>
                                                        <div class="row">
                    <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label17" runat="server" Text="Date"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtSearchDate" class="form-control" type="date" runat="server" ValidationGroup="Search" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                        <asp:RequiredFieldValidator ID="RFV5" runat="server" ControlToValidate="txtSearchDate"
                       ErrorMessage=" Date is Mandatory" ValidationGroup="Search" ForeColor="Red" ></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
                                        
                          
                      </div> 
                    <div class="col-lg-3" >
                  <div class="form-group ">
                    <div class="input-group">
                        <asp:Button ID="btnSearch" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Search" ValidationGroup="Search" OnClick="btnSearch_Click"/> &nbsp;    
                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
                                   
                       
                          
                      </div>
                            </div>

            <div class="box-body" id="datalist">

                                                <asp:UpdatePanel runat="server" ID="uprouteList" UpdateMode="Conditional">
                    <ContentTemplate>

                <table id="example1" class="table table-bordered table-striped">
                   

                 
                      <asp:Repeater ID="rpMilkColdRoomTemperature" runat="server" OnItemCommand="rpMilkColdRoomTemperature_ItemCommand">
                
                
               <HeaderTemplate>
                  <thead>
                      <tr>
                                       <%-- <th>RMRId</th>--%>
                                        <th>Date</th>
                                        <th>Batch No</th>
                                      
                                        <th>Shift Name</th> 
                                       <%-- <th>Cold Rooms For Milk</th>--%>
                                        <th>Cold Room1</th>
                                        <th>Cold Room2</th>
                                        <th>Cold Room3</th>   
                                        <th>Checked By</th>
                                        <th>verifier By</th>   
                                        <th>Status</th>                                                                   
                                        <th>Edit</th>


                      </tr>
                    </thead>
                    <tbody>

                   
               </HeaderTemplate>
               <ItemTemplate>
                    <tr>
                            
                                       <%-- <td><%# Eval("RMRId")%></td> --%>
                         <td><%# String.IsNullOrEmpty(Eval("RMRDate").ToString()) ? "": Convert.ToDateTime( Eval("RMRDate")).ToString("dd-MM-yyyy")%></td>  
                                        <td><%# Eval("BatchNo")%></td>
                                        <td><%# Eval("ShiftName")%></td>
                                        <%--<td><%# Eval("ColdRoomsForMilk")%></td>--%> 
                                        <td><%# Eval("ColdRoom1")%></td>
                                        <td><%# Eval("ColdRoom2")%></td>  
                                        <td><%# Eval("ColdRoom3")%></td>
                                        <td><%# Eval("CheckedBy")%></td> 
                                        <td><%# Eval("verifierBy")%></td>
                                       <td><%# Eval("StatusName") %></td>
                                                                                 
                                       
                                    
                                        
                                          
                         <td>
                             <asp:LinkButton ID="lbEdite" AlternateText="Edit" ForeColor="Gray" onItemCommand="lblEdite_ItemCommand" 
                                                                    ToolTip="Edit" runat="server" CommandArgument='<%#Eval("RMRId") %>'
                                                                    CommandName="Edit"><i class="fa fa-edit"></i></asp:LinkButton>

                         </td>
                         



                    </tr>
               </ItemTemplate>
                    <FooterTemplate>

                         </tbody>

                    <tfoot>
                      <tr>
<tr id="trEmpty" runat="server" visible="false"><td  align = "left"> No records found.</td> </tr>                                                                             
                                        <th>Date</th>
                                        <%--<th>RMRId</th>--%>
                                        <th>Batch No</th>
                                       
                                        <th>Shift Name</th> 
                                       <%-- <th>Cold Rooms For Milk</th>--%>
                                        <th>Cold Room1</th>
                                        <th>Cold Room2</th>
                                        <th>Cold Room3</th>   
                                        <th>Checked By</th>
                                        <th>verifier By</th>   
                                        <th>Status</th>                                                                   
                                        <th>Edit</th>

                                       

                                      
                                        
                      </tr>
                    </tfoot>

                    </FooterTemplate>
                                </asp:Repeater>    
          
                    <asp:HiddenField Id="hId" runat="server" />
                   
                  
                     
                   
                  </table>
             </section>
                
                        </ContentTemplate>
                                              </asp:UpdatePanel>
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
</asp:Content>
