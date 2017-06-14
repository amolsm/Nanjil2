<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Homogenizer.aspx.cs" Inherits="Dairy.Tabs.Production.Homogenizer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
     <link href="../../Theme/plugins/jQueryUI/jquery-ui.css" rel="stylesheet" />
        <script src="../../Theme/plugins/jQuery/jquery-1.10.2.min.js"></script>
        <script src="../../Theme/plugins/jQueryUI/jquery-ui.min.js"></script>
        <style type="text/css">.cntrlbtm {    margin-bottom: 1px;} </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <section class="content-header">
          <h1>
           Homogenization Data 
           <small>Details</small>
          </h1>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Administration</a></li>
            <li class="active">Homogenizer</li>
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
              <h3 class="box-title"><asp:Label ID="lblHeaderTab" runat="server" Text="ADD Homogenizer"></asp:Label> </h3>
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
                          <asp:Label ID="Label14" runat="server" Text="RMR Batch No"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtBatchNo" class="form-control"   placeholder="RMR Batch No " runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator  ID="RequiredFieldValidator4" Display="Dynamic" 
                                        ValidationGroup="Save" runat="server" ControlToValidate="txtBatchNo" ForeColor="Red"
                                        ErrorMessage="Pls Enter RMR Batch Number " style="font-size:12px;"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
                 </div>

                   <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
                          <asp:Label ID="lblDate" runat="server" Text="Homogenization Date"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtHomogenizerDate" class="form-control" type="date" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->
                </div>  

                <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
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
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label9" runat="server" Text="Machine Starting Time  "></asp:Label>
                      </div>
                       <asp:TextBox ID="txtStartingTime" class="form-control" type="time"        placeholder="Starting Time" ToolTip="Enter Starting Time" runat="server" ></asp:TextBox>        
                    </div><!-- /.input group -->
                        <asp:RequiredFieldValidator ID="RFVMachineStart" runat="server" ErrorMessage="Please Enter Machine Start Time" style="font-size:12px;" ControlToValidate="txtStartingTime" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
            </div>

</div>

 <div class="row">

               <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label1" runat="server" Text="Machine End Time "></asp:Label>
                      </div>
                       <asp:TextBox ID="txtEndTime" class="form-control" type="time"        placeholder="End Time" ToolTip="End Time" runat="server" ></asp:TextBox>        
                    </div><!-- /.input group -->
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Enter Machine End Time" style="font-size:12px;" ControlToValidate="txtEndTime" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
            </div>

                    <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label2" runat="server" Text="Pressure first Stage"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtPressureFisrtStage" class="form-control"   placeholder="Enter First Stage " runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
        <asp:RequiredFieldValidator  ID="RequiredFieldValidator5" Display="Dynamic" 
                                        ValidationGroup="Save" runat="server" ControlToValidate="txtPressureFisrtStage" ForeColor="Red"
                                        ErrorMessage="Pls Enter Pressure Fisrt Stage" style="font-size:12px;"></asp:RequiredFieldValidator>
<asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ValidationExpression= "[0-9]+(\.[0-9][0-9]?)?"
                           ErrorMessage ="Please enter valid number" ControlToValidate="txtPressureFisrtStage" ForeColor="Red" style="font-size:12px;" ValidationGroup="Save"/>
                  </div><!-- /.form group -->
                 </div>
             
     <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label3" runat="server" Text="Pressure Second Stage"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtPressureSecondStage" class="form-control"   placeholder="Enter Second Stage " runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
     <asp:RequiredFieldValidator  ID="RequiredFieldValidator2" Display="Dynamic" 
                                        ValidationGroup="Save" runat="server" ControlToValidate="txtPressureSecondStage" ForeColor="Red"
                                        ErrorMessage="Pls Enter Pressure Second Stage" style="font-size:12px;"></asp:RequiredFieldValidator>
<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationExpression= "[0-9]+(\.[0-9][0-9]?)?"
                           ErrorMessage ="Please enter valid number" ControlToValidate="txtPressureSecondStage" ForeColor="Red" style="font-size:12px;" ValidationGroup="Save"/>
                 
                  </div><!-- /.form group -->
                 </div>
<%--                                          <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                          <asp:Label ID="Label4" runat="server" Text=" Oil leakage "></asp:Label>
                      </div>
                       <asp:TextBox ID="txtOilleakage" class="form-control"   placeholder="Oil leakage " runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
                 </div>--%>

                <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                       <i class="fa fa-road"></i><span style="color:red">&nbsp;*</span>--%>
                        <asp:Label ID="Label4" runat="server" Text="Machine condition"></asp:Label>

                      </div>
                      <asp:DropDownList ID="dpOilLeakage" class="form-control" DataValueField="StatusId" DataTextField="Name"   runat="server"  > 
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                        <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator3" Display="Dynamic" 
                             ValidationGroup="Save" runat="server" ControlToValidate="dpOilLeakage" ForeColor="Red"
                             ErrorMessage="Pls Select Oil Leakage Details" style="font-size:12px;">
                         </asp:RequiredFieldValidator>

                  </div><!-- /.form group -->
                         </div>

</div>

 <div class="row">

               <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label5" runat="server" Text="Qty Homogenized"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtQtyHomogenized" class="form-control"   placeholder="Qty Homogenized " runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
     <asp:RequiredFieldValidator  ID="RequiredFieldValidator6" Display="Dynamic" 
                                        ValidationGroup="Save" runat="server" ControlToValidate="txtQtyHomogenized" ForeColor="Red"
                                        ErrorMessage="Pls Enter Qty Homogenized" style="font-size:12px;"></asp:RequiredFieldValidator>
<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ValidationExpression= "[0-9]+(\.[0-9][0-9]?)?"
                           ErrorMessage ="Please enter valid number" ControlToValidate="txtQtyHomogenized" ForeColor="Red" style="font-size:12px;" ValidationGroup="Save"/>
                  </div><!-- /.form group -->
                 </div>

              <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label7" runat="server" Text="Technician"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtTechnician" class="form-control"   placeholder="Enter Technician " runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
     <asp:RequiredFieldValidator  ID="RequiredFieldValidator7" Display="Dynamic" 
                                        ValidationGroup="Save" runat="server" ControlToValidate="txtTechnician" ForeColor="Red"
                                        ErrorMessage="Pls Enter Technician Name" style="font-size:12px;"></asp:RequiredFieldValidator>

                  </div><!-- /.form group -->
                 </div>


<%--               <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                          <asp:Label ID="Label8" runat="server" Text="Homogenized"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtHomogenized" class="form-control"   placeholder="Enter Homogenized " runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
     <asp:RequiredFieldValidator  ID="RequiredFieldValidator8" Display="Dynamic" 
                                        ValidationGroup="Save" runat="server" ControlToValidate="txtHomogenized" ForeColor="Red"
                                        ErrorMessage="Pls Enter Homogenized" style="font-size:12px;"></asp:RequiredFieldValidator>

                  </div><!-- /.form group -->
                 </div>--%>


                <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label6" runat="server" Text="Remarks"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtRemarks" class="form-control"   placeholder="Remarks " runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
                 </div>

                       <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                       <i class="fa fa-road"></i><span style="color:red">&nbsp;*</span>--%>
                        <asp:Label ID="Label10" runat="server" Text="Status"></asp:Label>

                      </div>
                      <asp:DropDownList ID="dpStatusDetails" class="form-control" DataValueField="StatusId" DataTextField="Name"   runat="server"  > 
                       </asp:DropDownList>
                      
                    </div><!-- /.input group -->
                        <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator9" Display="Dynamic" 
                             ValidationGroup="Save" runat="server" ControlToValidate="dpStatusDetails" ForeColor="Red"
                             ErrorMessage="Pls Select Status Details" style="font-size:12px;">
                         </asp:RequiredFieldValidator>

                  </div><!-- /.form group -->
                         </div>


 </div>

                <div class="col-lg-3 pull-right">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
               
                        <asp:Button ID="btnAdd" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Add" ValidationGroup="Save" OnClick="btnAdd_Click" /> &nbsp;    
                        <asp:Button ID="btnUpdate" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Update" ValidationGroup="Save" OnClick="btnUpdate_Click"/>  &nbsp        
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
              <h3 class="box-title"> Homogenization Data List </h3>
              <div class="box-tools pull-right" style="right: 4px; top: 4px">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-minus"></i></button>
                
              </div>
            </div>
            <div class="box-body" id="datalist">

                                                <asp:UpdatePanel runat="server" ID="uprouteList" UpdateMode="Conditional">
                    <ContentTemplate>

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

                <table id="example1" class="table table-bordered table-striped">
                   

                 
                      <asp:Repeater ID="rpHomogenizer" runat="server" OnItemCommand="rpHomogenizer_ItemCommand">
                
                
               <HeaderTemplate>
                  <thead>
                      <tr>
                                     <%-- <th>RMRId</th>--%>
                                        <th>RMR Date</th>
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
                            
                                       <%-- <td><%# Eval("RMRId")%></td>  --%> 
                                        <td><%# Convert.ToDateTime(Eval("RMRDate")).ToString("dd-MM-yyyy")%></td> 
                                        <td><%# Eval("BatchNo")%></td>  
                                        <td><%# Eval("ShiftName")%></td>                                       
                                        <td><%# Eval("StatusName")%></td>     
                                    
                                        
                                          
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
                                     <%-- <th>RMRId</th>--%>
                                        <th>RMR Date</th>
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
