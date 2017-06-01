<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreamProduction.aspx.cs" Inherits="Dairy.Tabs.Production.CreamProduction" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="../../Theme/plugins/jQueryUI/jquery-ui.css" rel="stylesheet" />
        <script src="../../Theme/plugins/jQuery/jquery-1.10.2.min.js"></script>
        <script src="../../Theme/plugins/jQueryUI/jquery-ui.min.js"></script>
        <style type="text/css">.cntrlbtm {    margin-bottom: 1px;} </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <section class="content-header">
          <h1>  
           Cream Production 
            <small>Details</small>    
          </h1> 
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Administration</a></li>
            <li class="active">Cream Production</li>
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
              <h3 class="box-title"><asp:Label ID="lblHeaderTab" runat="server" Text="ADD CreamProduction"></asp:Label> </h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-plus"></i></button>
                
              </div>
            </div>
            <div class="box-body">

                              <asp:UpdatePanel runat="server" ID="upMain" UpdateMode="Conditional">
              <ContentTemplate>     
                  
     <div class="row">
               <div class="col-lg-3">
                  <div class="form-group ">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label3" runat="server" Text="RMR Batch No"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtBatchNo" class="form-control"   placeholder="RMR Batch No " runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                                              <asp:RequiredFieldValidator  ID="RequiredFieldValidator1" Display="Dynamic" 
                                        ValidationGroup="Save" runat="server" ControlToValidate="txtBatchNo" ForeColor="Red"
                                        ErrorMessage="Pls Enter RMR Batch Number " style="font-size:12px;"></asp:RequiredFieldValidator>

                  </div><!-- /.form group -->
                 </div>
      
        
               <div class="col-lg-3">
                  <div class="form-group ">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="lblDate" runat="server" Text="Date"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtDate" class="form-control" type="date" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
                                        
                          
                      </div> 


               <div class="col-lg-3">
                  <div class="form-group ">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                       <i class="fa fa-road"></i><span style="color:red">&nbsp;*</span>--%>
                        <asp:Label ID="Label1" runat="server" Text="Shift"></asp:Label>

                      </div>
                      <asp:DropDownList ID="dpShiftDetails" class="form-control" DataValueField="ShiftId" DataTextField="Name"   runat="server"  > 
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                          <asp:RequiredFieldValidator InitialValue="0" ID="Req_ID" Display="Dynamic" 
                             ValidationGroup="Save" runat="server" ControlToValidate="dpShiftDetails" ForeColor="Red"
                             ErrorMessage="Pls Select Shift Detail" style="font-size:12px;">
                         </asp:RequiredFieldValidator>

                  </div><!-- /.form group -->
                         </div>

              <div class="col-lg-3">
                  <div class="form-group ">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label2" runat="server" Text="Batch code for cream"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtBatchCodeCream" class="form-control"   placeholder=" Enter batch code" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                                              <asp:RequiredFieldValidator  ID="RequiredFieldValidator2" Display="Dynamic" 
                                        ValidationGroup="Save" runat="server" ControlToValidate="txtBatchCodeCream" ForeColor="Red"
                                        ErrorMessage="Pls Enter Batch Code Cream" style="font-size:12px;"></asp:RequiredFieldValidator>

                  </div><!-- /.form group -->
                 </div>

    </div>

 <div class="row">
                        <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="lblTankerReceipt" runat="server" Text="Cream Qty"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtCreamQty" class="form-control"   placeholder=" Enter Cream Qty " runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                       <asp:RequiredFieldValidator  ID="RFVQty" Display="Dynamic" 
                                        ValidationGroup="Save" runat="server" ControlToValidate="txtCreamQty" ForeColor="Red"
                                        ErrorMessage="Pls Enter Cream Quantity" style="font-size:12px;">
                      </asp:RequiredFieldValidator>
                          <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ValidationExpression= "[0-9]+(\.[0-9][0-9]?)?"
                           ErrorMessage ="Please enter valid number" ControlToValidate="txtCreamQty" ForeColor="Red" style="font-size:12px;" ValidationGroup="Save"/>

                  </div><!-- /.form group -->
                 </div>

              <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="lblTankerNo" runat="server" Text="FAT"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtFAT" class="form-control"   placeholder="Enter FAT " runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                       <asp:RequiredFieldValidator  ID="RequiredFieldValidator3" Display="Dynamic" 
                                        ValidationGroup="Save" runat="server" ControlToValidate="txtFAT" ForeColor="Red"
                                        ErrorMessage="Pls Enter Fat Quantity" style="font-size:12px;">
                      </asp:RequiredFieldValidator>
                          <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationExpression= "[0-9]+(\.[0-9][0-9]?)?"
                           ErrorMessage ="Please enter valid number" ControlToValidate="txtFAT" ForeColor="Red" style="font-size:12px;" ValidationGroup="Save"/>

                  </div><!-- /.form group -->
                 </div>
     
            <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">                    
                        <asp:Label ID="Label17" runat="server" Text="Cream Production"></asp:Label>
                      </div>
                      <asp:DropDownList ID="dpCreamProductionDone" class="form-control" DataValueField="StatusId" DataTextField="StatusName"   runat="server" ValidationGroup="Save" > 
                        
                      </asp:DropDownList>                       
                    </div><!-- /.input group -->
                       <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator4" Display="Dynamic" 
                             ValidationGroup="Save" runat="server" ControlToValidate="dpCreamProductionDone" ForeColor="Red"
                             ErrorMessage="Pls Select Cream Production Done Or Not" style="font-size:12px;">
                         </asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
               </div>

     </div>
              <div class="col-lg-3 pull-right">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      
                    
                      
                        <asp:Button ID="btnAdd" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Add" ValidationGroup="Save" OnClick="btnAdd_Click" /> &nbsp;    
                        <asp:Button ID="btnUpdate" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Update" ValidationGroup="Save" OnClick="btnUpdate_Click" />  &nbsp        
                        <asp:Button ID="btnRefresh" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Refresh" ValidationGroup="Refresh" OnClick="btnRefresh_Click" />             
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
                                    
                      </div>
                        
                    </ContentTemplate>
                </asp:UpdatePanel>

                </div><!-- /.box-body -->            
          </div><!-- /.box -->

           <div class="box ">
            <div class="box-header with-border">
              <h3 class="box-title"> Cream Production List </h3>
              <div class="box-tools pull-right" style="right: 4px; top: 4px">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-minus"></i></button>
                
              </div>
            </div>
                                       <div class="row">
                    <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">

                          <asp:Label ID="Label10" runat="server" Text="Date"></asp:Label>
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
                   

                 
                      <asp:Repeater ID="rpCreamProduction" runat="server" OnItemCommand="rpCreamProduction_ItemCommand">
                
                
               <HeaderTemplate>
                  <thead>
                      <tr>

                                     
                                      <%--  <th>RMRId</th>--%>
                                        <th>CreamProductionDate</th> 
                                        <th>RMR Batch No</th>
                                                                             
                                        <th>Shift Name</th>  
                                        <th>Status</th>                                     
                                        <th>Edit</th>


                      </tr>
                    </thead>
                    <tbody>

                   
               </HeaderTemplate>
               <ItemTemplate>
                    <tr>

                                                            
                                       <%-- <td><%# Eval("RMRId")%></td>     --%>
                                         <td><%# Eval("PastQCDate")%></td> 
                                         <td><%# Eval("BatchNo")%></td>                                       
                                       
                                        <td><%# Eval("ShiftName")%></td>
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
                                        <%--  <th>RMRId</th>--%>
                                        <th>CreamProductionDate</th> 
                                        <th>RMR Batch No</th>
                                                                             
                                        <th>Shift Name</th> 
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
