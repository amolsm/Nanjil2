<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Rechilling.aspx.cs" Inherits="Dairy.Tabs.Production.Rechilling" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
     <link href="../../Theme/plugins/jQueryUI/jquery-ui.css" rel="stylesheet" />
    <script src="../../Theme/plugins/jQuery/jquery-1.10.2.min.js"></script>
    <script src="../../Theme/plugins/jQueryUI/jquery-ui.min.js"></script>
    <style type="text/css">.cntrlbtm {    margin-bottom: 1px;} </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <section class="content-header">
          <h1>
           Re-chilling Production 
            <small>Details</small>    
          </h1> 
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Administration</a></li>
            <li class="active">Re-chilling</li>
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
              <h3 class="box-title"><asp:Label ID="lblHeaderTab" runat="server" Text="Re-chilling Details"></asp:Label> </h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-plus"></i></button>
                
              </div>
            </div>
            <div class="box-body">
                  <asp:UpdatePanel runat="server" ID="upMain" UpdateMode="Conditional">
            <ContentTemplate>  
                <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label1" runat="server" Text="Batch No "></asp:Label>
                      </div>
                       <asp:TextBox ID="txtBatchNO" class="form-control"   placeholder="Batch No" runat="server" readonly="true"></asp:TextBox>                        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator  ID="RequiredFieldValidator4" Display="Dynamic" 
                                        ValidationGroup="Save" runat="server" ControlToValidate="txtBatchNO" ForeColor="Red"
                                        ErrorMessage="Pls Enter RMR Batch Number " style="font-size:12px;"></asp:RequiredFieldValidator>

                  </div><!-- /.form group -->
            </div>
 

                               <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                       <i class="fa fa-road"></i><span style="color:red">&nbsp;*</span>--%>
                        <asp:Label ID="lblShift" runat="server" Text="Shift"></asp:Label>

                      </div>
                      <asp:DropDownList ID="dpShiftDetails" class="form-control" DataValueField="ShiftId" DataTextField="Name"   runat="server"  > 
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                        <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator19" Display="Dynamic" 
                             ValidationGroup="Save" runat="server" ControlToValidate="dpShiftDetails" ForeColor="Red"
                             ErrorMessage="Pls Select Shift Details" style="font-size:12px;">
                         </asp:RequiredFieldValidator>

                  </div><!-- /.form group -->
                         </div>
               <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="lblDate" runat="server" Text="Date"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtDate" class="form-control" type="date" runat="server" required></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
                                        
                          
                      </div> 



                               <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label12" runat="server" Text="Silo No"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtSiloNo" class="form-control"   placeholder="Silo No" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
          <asp:RequiredFieldValidator  ID="RequiredFieldValidator1" Display="Dynamic" 
                                        ValidationGroup="Save" runat="server" ControlToValidate="txtSiloNo" ForeColor="Red"
                                        ErrorMessage="Pls Enter Silo No" style="font-size:12px;"></asp:RequiredFieldValidator>

                  </div><!-- /.form group -->
            </div>
                               <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label2" runat="server" Text="Type Of Milk"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtTypeOfMilk" class="form-control"   placeholder="RCM" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
          <asp:RequiredFieldValidator  ID="RequiredFieldValidator2" Display="Dynamic" 
                                        ValidationGroup="Save" runat="server" ControlToValidate="txtTypeOfMilk" ForeColor="Red"
                                        ErrorMessage="Pls Enter Milk Type " style="font-size:12px;"></asp:RequiredFieldValidator>

                  </div><!-- /.form group -->
            </div>
             <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label3" runat="server" Text="Quantity"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtQuantity" class="form-control"   placeholder="Quantity" runat="server"  ></asp:TextBox>                        
                    </div><!-- /.input group -->
  <asp:RequiredFieldValidator  ID="RequiredFieldValidator5" Display="Dynamic" 
                                        ValidationGroup="Save" runat="server" ControlToValidate="txtQuantity" ForeColor="Red"
                                        ErrorMessage="Pls Enter Qty" style="font-size:12px;"></asp:RequiredFieldValidator>
<asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ValidationExpression= "[0-9]+(\.[0-9][0-9]?)?"
                           ErrorMessage ="Please enter valid number" ControlToValidate="txtQuantity" ForeColor="Red" style="font-size:12px;" ValidationGroup="Save"/>
                  </div><!-- /.form group -->
            </div>
                               <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label4" runat="server" Text="IBT In Temperature"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtIBTInTemperature" class="form-control"   placeholder="Temperature" runat="server"  ></asp:TextBox>                        
                    </div><!-- /.input group -->
      <asp:RequiredFieldValidator  ID="RequiredFieldValidator6" Display="Dynamic" 
                                        ValidationGroup="Save" runat="server" ControlToValidate="txtIBTInTemperature" ForeColor="red"
                                        ErrorMessage="Pls Enter IBT IN Temperature" style="font-size:12px;"></asp:RequiredFieldValidator>
<asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ValidationExpression= "[0-9]+(\.[0-9][0-9]?)?"
                           ErrorMessage ="Please enter valid number" ControlToValidate="txtIBTInTemperature" ForeColor="Red" style="font-size:12px;" ValidationGroup="Save"/>
                  </div><!-- /.form group -->
            </div>
                               <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label5" runat="server" Text="IBT Out Temperature"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtIBTOutTemperature" class="form-control"   placeholder="Temperature" runat="server"  ></asp:TextBox>                        
                    </div><!-- /.input group -->
     <asp:RequiredFieldValidator  ID="RequiredFieldValidator3" Display="Dynamic" 
                                        ValidationGroup="Save" runat="server" ControlToValidate="txtIBTOutTemperature" ForeColor="red"
                                        ErrorMessage="Pls Enter IBT Out Temperature" style="font-size:12px;"></asp:RequiredFieldValidator>
<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationExpression= "[0-9]+(\.[0-9][0-9]?)?"
                           ErrorMessage ="Please enter valid number" ControlToValidate="txtIBTOutTemperature" ForeColor="Red" style="font-size:12px;" ValidationGroup="Save"/>
                  </div><!-- /.form group -->
            </div>
                               <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label6" runat="server" Text="Milk In Temperature"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtMilkInTemperature" class="form-control"   placeholder="Temperature" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
    <asp:RequiredFieldValidator  ID="RequiredFieldValidator7" Display="Dynamic" 
                                        ValidationGroup="Save" runat="server" ControlToValidate="txtMilkInTemperature" ForeColor="red"
                                        ErrorMessage="Pls Enter Milk In Temperature" style="font-size:12px;"></asp:RequiredFieldValidator>
<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ValidationExpression= "[0-9]+(\.[0-9][0-9]?)?"
                           ErrorMessage ="Please enter valid number" ControlToValidate="txtMilkInTemperature" ForeColor="Red" style="font-size:12px;" ValidationGroup="Save"/>
                  </div><!-- /.form group -->
            </div>
                               <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label7" runat="server" Text="Milk Out Temperature"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtMilkOutTemperature" class="form-control"   placeholder="Temperature" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
 <asp:RequiredFieldValidator  ID="RequiredFieldValidator8" Display="Dynamic" 
                                        ValidationGroup="Save" runat="server" ControlToValidate="txtMilkOutTemperature" ForeColor="red"
                                        ErrorMessage="Pls Enter Milk Out Temperature" style="font-size:12px;"></asp:RequiredFieldValidator>
<asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ValidationExpression= "[0-9]+(\.[0-9][0-9]?)?"
                           ErrorMessage ="Please enter valid number" ControlToValidate="txtMilkOutTemperature" ForeColor="Red" style="font-size:12px;" ValidationGroup="Save"/>
                  </div><!-- /.form group -->
            </div>
                               <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label8" runat="server" Text="Rechilled By"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtRechilledBy" class="form-control"   placeholder="Rechilled By" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
          <asp:RequiredFieldValidator  ID="RequiredFieldValidator9" Display="Dynamic" 
                                        ValidationGroup="Save" runat="server" ControlToValidate="txtRechilledBy" ForeColor="Red"
                                        ErrorMessage="Pls Enter Rechilled by" style="font-size:12px;"></asp:RequiredFieldValidator>

                  </div><!-- /.form group -->
            </div>

               <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                       <i class="fa fa-road"></i><span style="color:red">&nbsp;*</span>--%>
                        <asp:Label ID="Label13" runat="server" ValidationGroup="Save" Text="Status"></asp:Label>

                      </div>
                      <asp:DropDownList ID="dpRechillStatus" class="form-control" DataValueField="QCId" DataTextField="Name"   runat="server"  > 
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                       <asp:RequiredFieldValidator InitialValue="0" ID="Req_ID" Display="Dynamic" 
                             ValidationGroup="Save" runat="server" ControlToValidate="dpRechillStatus" ForeColor="Red"
                             ErrorMessage="Pls Select Rechill Status" style="font-size:12px;">
                         </asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
                         </div>

 

                <div class="col-lg-3 pull-right">
                  <div class="form-group">
                    <div class="input-group">
                                        <asp:Button ID="btnAddRechilling" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Add" ValidationGroup="Save" onclick="btnAddRechilling_Click" /> &nbsp;      
                                        <asp:Button ID="btnUpdate" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Update" ValidationGroup="Save" OnClick="btnUpdate_Click"/> &nbsp;    
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
              <h3 class="box-title"> Rechilling Data Information List </h3>
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
                       <asp:TextBox ID="txtSearchDate" class="form-control" type="date" runat="server" ValidationGroup="Save" ></asp:TextBox>                        
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
                   

                 
                      <asp:Repeater ID="rpRechillingList" runat="server" OnItemCommand="rpRechillingList_ItemCommand">
                
                
               <HeaderTemplate>
                  <thead>
                      <tr>
                                       <%--<th>RMRId</th>--%>
                                        <th>RMR Date</th>
                                        <th>Batch No</th>
                                        <th>Shift Name</th>                                                                              
                                        <th>Milk Type</th>
                                        <th>Quantity</th>
                                        <th>Silo No</th>
                                        <th>IBT In Temp</th>
                                        <th>IBT Out Temp</th>
                                        <th>Milk In Temp </th>
                                        <th>Milk Out Temp </th>
                                        <th>Status</th>
                                        <th>Edit</th>

                      </tr>
                    </thead>
                    <tbody>

                   
               </HeaderTemplate>
               <ItemTemplate>
                    <tr>
                                        <%--<td><%# Eval("RMRId")%></td>--%>  
                                        <td><%# Convert.ToDateTime(Eval("RMRDate")).ToString("dd-MM-yyyy")%></td>    
                                        <td><%# Eval("BatchNo")%></td>   
                                        <td><%# Eval("ShiftName")%></td> 
                                        <td><%# Eval("TypeOfMilk")%></td>
                                        <td><%# Eval("Qty")%></td>
                                        <td><%# Eval("SiloNo")%></td> 
                                        <td><%# Eval("IBTInTemperature")%></td>
                                        <td><%# Eval("IBTOutTemperature")%></td>                                       
                                        <td><%# Eval("MilkInTemperature")%></td>
                                        <td><%# Eval("MilkOutTemperature")%></td>
                                        <td><%# Eval("Status")%></td>
                          
                        <asp:HiddenField id="hfQualityId" runat="server" value='<%#Eval("QualityId") %>' /> 
                                        
                                      
                                       
                                          
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
                                        <th>RMR Date</th>
                                        <th>Batch No</th>
                                        <th>Shift Name</th>                                                                              
                                        <th>Milk Type</th>
                                        <th>Quantity</th>
                                        <th>Silo No</th>
                                        <th>IBT In Temp</th>
                                        <th>IBT Out Temp</th>
                                        <th>Milk In Temp </th>
                                        <th>Milk Out Temp </th>
                                        <th>Status</th>
                                        <th>Edit</th>
                                       

                                      
                                        
                      </tr>
                    </tfoot>

                    </FooterTemplate>
                                          </asp:Repeater>    
          
                     <asp:HiddenField Id="hId" runat="server" />
                   
                  
                     
                   
                  </table>
        
                
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

    <asp:HiddenField Id="hfrid" runat="server" />
         
      </section>


</asp:Content>
                       

