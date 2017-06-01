<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MilkProductstestBeforePackingQC.aspx.cs" Inherits="Dairy.Tabs.Production.MilkProductstestBeforePackingQC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
     <link href="../../Theme/plugins/jQueryUI/jquery-ui.css" rel="stylesheet" />
        <script src="../../Theme/plugins/jQuery/jquery-1.10.2.min.js"></script>
        <script src="../../Theme/plugins/jQueryUI/jquery-ui.min.js"></script>
        <style type="text/css">.cntrlbtm {    margin-bottom: 1px;} </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <section class="content-header">
        <h1>
            Milk Products Test Before Packing QC  
          </h1> 
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Administration</a></li>
            <li class="active">MilkTestBeforePackingQC</li>
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
              <h3 class="box-title"><asp:Label ID="lblHeaderTab" runat="server" Text="Milk Products Test Before Packing QC"></asp:Label> </h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-plus"></i></button>
                
              </div>
            </div>
            <div class="box-body">

                     <asp:UpdatePanel runat="server" ID="upMain" UpdateMode="Conditional">
              <ContentTemplate>

 <div class="row">        
                  <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
                          <asp:Label ID="Label14" runat="server" Text="Batch No"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtBatchNo" class="form-control"   placeholder="Batch No " runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Pls Enter Batch No " ControlToValidate="txtBatchNo" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
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
                          
                
<%--                    <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
                      <i class="fa fa-road"></i><span style="color:red">&nbsp;*</span>
                        <asp:Label ID="Label1" runat="server" Text="Shift"></asp:Label>

                      </div>
                      <asp:DropDownList ID="dpShiftDetails" class="form-control" DataValueField="ShiftId" DataTextField="Name"   runat="server" tooltip="Select Shift" > 
                       </asp:DropDownList>
                          
                    </div><!-- /.input group -->
                          <asp:RequiredFieldValidator InitialValue="0" ID="Req_ID" Display="Dynamic" 
                             ValidationGroup="Save" runat="server" ControlToValidate="dpShiftDetails" ForeColor="Red"
                             ErrorMessage="Pls Select Shift Detail" style="font-size:12px;">
                         </asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
            
                         </div>--%>
       
      
              <div  ID="hideShift" class="col-lg-3"  runat="server">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">                    
                        <asp:Label ID="Label1" runat="server" Text="Shift"></asp:Label>

                      </div>
                      <asp:DropDownList ID="dpShiftDetails" class="form-control" DataValueField="ShiftId" DataTextField="Name"   runat="server"  > 
                       </asp:DropDownList>                        
                    </div><!-- /.input group -->
                       <asp:RequiredFieldValidator InitialValue="0" ID="Req_ID" Display="Dynamic"  ValidationGroup="Save" runat="server" ControlToValidate="dpShiftDetails" ForeColor="Red" ErrorMessage="Pls Select Shift" >
                         </asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
               </div>   
     
       <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                       <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label5" runat="server" Text="Test Name"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtTestName" class="form-control"   placeholder="Enter Test Name" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please Enter Test Name" ControlToValidate="txtTestName" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
            </div>



</div>

 <div class="row">
                   <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label3" runat="server" Text="Quantity"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtQuantity" class="form-control"   placeholder="Enter Quantity " runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please Enter Quantity" ControlToValidate="txtQuantity" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
            </div>



                   <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label2" runat="server" Text="particular"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtparticular" class="form-control"   placeholder="Enter Particular" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Enter particular" ControlToValidate="txtparticular" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
               </div>
     
            
                  <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label6" runat="server" Text="Result"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtResult" class="form-control"   placeholder="Enter Result" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group --> 
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Please Enter Result" ControlToValidate="txtResult" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
                 </div>

                   
                   <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label7" runat="server" Text="Remarks"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtRemarks" class="form-control"   placeholder=" Enter Remarks" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Please Enter Remarks" ControlToValidate="txtRemarks" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
                  </div>

</div>

<div class="row">
                <div  class="col-lg-3" >
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                       <i class="fa fa-road"></i><span style="color:red">&nbsp;*</span>--%>
                        <asp:Label ID="Label13" runat="server" Text="Status"></asp:Label>

                      </div>
                      <asp:DropDownList ID="dpQCStatusId" class="form-control" DataValueField="QCId" DataTextField="Name"   runat="server"  > 
                       </asp:DropDownList>                        
                    </div><!-- /.input group -->
                    <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator7" Display="Dynamic" 
                             ValidationGroup="Save" runat="server" ControlToValidate="dpQCStatusId" ForeColor="Red"
                             ErrorMessage="Pls Select QC Detail" style="font-size:12px;">
                         </asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
                         </div>
</div>
                <div class="col-lg-3 pull-right">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                        <asp:Button ID="btnAdd" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Add" ValidationGroup="Save" OnClick="btnAdd_Click" /> &nbsp;    
                        <asp:Button ID="btnUpdate" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Update" ValidationGroup="Save" OnClick="btnUpdate_Click" /> &nbsp;    
                        <asp:Button ID="btnRefresh" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Refresh" ValidationGroup="Refresh" OnClick="btnRefresh_Click"/> &nbsp;                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->                        
                     

                </div>
            </ContentTemplate> 
          </asp:UpdatePanel>
        </div><!-- /.box-body -->            
     </div><!-- /.box -->

                   <div class="box ">
            <div class="box-header with-border">
              <h3 class="box-title">  Milk Products Test Before Packing QC List </h3>
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
                        <asp:Button ID="btnSearch" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Search" ValidationGroup="Search" OnClick="btnSearch_Click" /> &nbsp;    
                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
                                   
                       
                          
                      </div>
                            </div>

            <div class="box-body" id="datalist">

                                                <asp:UpdatePanel runat="server" ID="uprouteList" UpdateMode="Conditional">
                    <ContentTemplate>

                <table id="example1" class="table table-bordered table-striped">
                   

                 
                      <asp:Repeater ID="rpMilkBeforePackingQC" runat="server" OnItemCommand="rpMilkBeforePackingQC_ItemCommand">
                
                
               <HeaderTemplate>
                  <thead>
                      <tr>
                                      
                                        <%-- <th>RMRId</th>--%>
                                         <th>Date </th>
                                         <th>Batch No</th>  
                                      
                                        <th>Shift Name</th>
                                        <th>Particular</th>                                                                                                      
                                        <th>Quantity</th>
                                         <th>TestName</th>
                                        <th>Result</th>
                                        <th>Status</th>
                                        <th>Edit</th>



                      </tr>
                    </thead>
                    <tbody>

                   
               </HeaderTemplate>
               <ItemTemplate>
                    <tr>
                            
                                        <%--<td><%# Eval("RMRId")%></td>   --%>
                         <td><%# String.IsNullOrEmpty(Eval("RMRDate").ToString()) ? "": Convert.ToDateTime(Eval("RMRDate")).ToString("dd-MM-yyyy")%></td> 

                                            <td><%# Eval("BatchNo")%></td>  
                                                                  
                                        <td><%# Eval("ShiftName")%></td>
                                        <td><%# Eval("Particular")%></td>     
                                     <td><%# Eval("Quantity")%></td>  
                                   <td><%# Eval("TestName")%></td>  
                                 <td><%# Eval("Result")%></td>                                      
                                     <td><%# Eval("Status")%></td>     
                                    
                                        
                                          
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
                                         <%--<th>RMRId</th>--%>
                                         <th>Date </th>
                                         <th>Batch No</th>  
                                       
                                        <th>Shift Name</th>
                                        <th>Particular</th>                                                                                                      
                                        <th>Quantity</th>
                                         <th>TestName</th>
                                        <th>Result</th>
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
