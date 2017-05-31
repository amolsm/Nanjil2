<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TraceabilityForMilkQC.aspx.cs" Inherits="Dairy.Tabs.Production.TraceabilityForMilkQC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
     <link href="../../Theme/plugins/jQueryUI/jquery-ui.css" rel="stylesheet" />
        <script src="../../Theme/plugins/jQuery/jquery-1.10.2.min.js"></script>
        <script src="../../Theme/plugins/jQueryUI/jquery-ui.min.js"></script>
        <style type="text/css">.cntrlbtm {    margin-bottom: 1px;} </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section class="content-header">
        <h1>
            Traceability For Milk     
          </h1> 
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Administration</a></li>
            <li class="active">TraceabilityQC</li>
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
              <h3 class="box-title"><asp:Label ID="lblHeaderTab" runat="server" Text="TraceabilityQC Details"></asp:Label> </h3>
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
                      <asp:RequiredFieldValidator ID="RFVBatchNo" runat="server" ErrorMessage="Pls Enter Out Time"  ControlToValidate="txtBatchNo" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
                 </div>

              <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
                          <asp:Label ID="lblDate" runat="server" Text="Skim Date"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtSkimDate" class="form-control" type="date" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
<asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtSkimDate"
                       ErrorMessage="Pls Enter Skim Date" ValidationGroup="Save" ForeColor="Red" ></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
                </div>                
                          
                                     <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
                          <asp:Label ID="Label20" runat="server" Text="Packing Date"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtPackingDate" class="form-control" type="date" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
      <asp:RequiredFieldValidator ID="RFVDate" runat="server" ControlToValidate="txtPackingDate"
                       ErrorMessage="Pls Enter Packing Date" ValidationGroup="Save" ForeColor="Red" ></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
                </div>                


                                     <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label4" runat="server" Text="Tanker Pumping Time  "></asp:Label>
                      </div>
                       <asp:TextBox ID="txtPumpinghr" class="form-control"   placeholder="Hour1" ToolTip="Enter Hour" runat="server" ></asp:TextBox>        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Enter Time" ControlToValidate="txtPumpinghr" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
            </div>


              <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
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

                                <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
                          <asp:Label ID="Label2" runat="server" Text="Tanker Code"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtTankerCode" class="form-control"   placeholder="Enter Tanker Code " runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Please Enter Tanker Code" ControlToValidate="txtTankerCode" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
                 </div>

                                <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
                          <asp:Label ID="Label3" runat="server" Text="SMP Batch code"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtSMPBatchcode" class="form-control"   placeholder="Enter SMP Batch code " runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Please Enter SMP Batch Code" ControlToValidate="txtSMPBatchcode" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
                 </div>

                  

          
                         <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
                          <asp:Label ID="Label6" runat="server" Text="Chilled Milk Silo No"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtChilledMilkSiloNo" class="form-control"   placeholder="Enter Silo No " runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Please Enter Silo No" ControlToValidate="txtChilledMilkSiloNo" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
                 </div>

                  
                                <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
                          <asp:Label ID="Label7" runat="server" Text="Process Silo No "></asp:Label>
                      </div>
                       <asp:TextBox ID="txtProcessSiloNo" class="form-control"   placeholder="Enter Silo No " runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Please Enter Silo No" ControlToValidate="txtProcessSiloNo" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
                 </div>


                   <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
                          <asp:Label ID="Label8" runat="server" Text="Cream Temperature "></asp:Label>
                      </div>
                       <asp:TextBox ID="txtCreamTemperature" class="form-control"   placeholder="Enter Cream Temp " runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
<%--                      <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Please Enter Cream Temp" ControlToValidate="txtCreamTemperature" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>--%>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Pls Enter Temperature"  ControlToValidate="txtCreamTemperature" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationExpression= "[0-9]+(\.[0-9][0-9]?)?"
                           ErrorMessage ="Pls enter valid number"  ControlToValidate="txtCreamTemperature" ForeColor="Red" ValidationGroup="Save"/>
                  </div><!-- /.form group -->
                 </div>


                      <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
                          <asp:Label ID="Label9" runat="server" Text="Skim Temperature"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtSkimTemperature" class="form-control"   placeholder="Enter Skim Temp " runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
<%--                      <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="Please Enter Skim Temp" ControlToValidate="txtSkimTemperature" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>--%>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Pls Enter Temperature"  ControlToValidate="txtSkimTemperature" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ValidationExpression= "[0-9]+(\.[0-9][0-9]?)?"
                           ErrorMessage ="Pls enter valid number"  ControlToValidate="txtSkimTemperature" ForeColor="Red" ValidationGroup="Save"/>
                  </div><!-- /.form group -->
                 </div>


                                 <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
                          <asp:Label ID="Label10" runat="server" Text="FAT"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtFAT" class="form-control"   placeholder="Enter FAT" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
<%--                      <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="Please Enter FAT" ControlToValidate="txtFAT" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>--%>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Pls Enter FAT"  ControlToValidate="txtFAT" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ValidationExpression= "[0-9]+(\.[0-9][0-9]?)?"
                           ErrorMessage ="Pls enter valid number"  ControlToValidate="txtFAT" ForeColor="Red" ValidationGroup="Save"/>
                  </div><!-- /.form group -->
                 </div>


                                <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
                          <asp:Label ID="Label5" runat="server" Text="Taste "></asp:Label>
                      </div>
                       <asp:TextBox ID="txtTaste" class="form-control"   placeholder="Enter Taste " runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="Please Enter Taste" ControlToValidate="txtTaste" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
                 </div>


                                <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
                          <asp:Label ID="Label11" runat="server" Text="Smell"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtSmell" class="form-control"   placeholder="Enter Smell" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="Please Enter Smell" ControlToValidate="txtSmell" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
                 </div>


                                <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
                          <asp:Label ID="Label12" runat="server" Text="Color"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtColor" class="form-control"   placeholder="Enter Color" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage="Please Enter Color" ControlToValidate="txtColor" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
                 </div>



             <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
                          <asp:Label ID="Label18" runat="server" Text="SNF "></asp:Label>
                      </div>
                       <asp:TextBox ID="txtSNF" class="form-control"   placeholder="Enter SNF " runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
<%--                      <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ErrorMessage="Please Enter SNF" ControlToValidate="txtSNF" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>--%>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Pls Enter SNF"  ControlToValidate="txtSNF" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ValidationExpression= "[0-9]+(\.[0-9][0-9]?)?"
                           ErrorMessage ="Pls enter valid number"  ControlToValidate="txtSNF" ForeColor="Red" ValidationGroup="Save"/>
                  </div><!-- /.form group -->
                 </div>






         <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
                          <asp:Label ID="Label13" runat="server" Text="CLR  "></asp:Label>
                      </div>
                       <asp:TextBox ID="txtCLR" class="form-control"   placeholder="Enter CLR  " runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
<%--                      <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ErrorMessage="Please Enter CLR" ControlToValidate="txtCLR" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>--%>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="Pls Enter CLR"  ControlToValidate="txtCLR" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ValidationExpression= "[0-9]+(\.[0-9][0-9]?)?"
                           ErrorMessage ="Pls enter valid number"  ControlToValidate="txtCLR" ForeColor="Red" ValidationGroup="Save"/>
                  </div><!-- /.form group -->
                 </div>


         <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
                          <asp:Label ID="Label16" runat="server" Text="Acidity "></asp:Label>
                      </div>
                       <asp:TextBox ID="txtAcidity" class="form-control"   placeholder="Enter Acidity " runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ErrorMessage="Please Enter Acidity" ControlToValidate="txtAcidity" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                     <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="Pls Enter Acidity"  ControlToValidate="txtAcidity
                           " ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ValidationExpression= "[0-9]+(\.[0-9][0-9]?)?"--%>
<%--                           ErrorMessage ="Pls enter valid number"  ControlToValidate="txtAcidity" ForeColor="Red" ValidationGroup="Save"/>--%>
                  </div><!-- /.form group -->
                 </div>

                  
          <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
                          <asp:Label ID="Label17" runat="server" Text="Packet Code "></asp:Label>
                      </div>
                       <asp:TextBox ID="txtPacketCode" class="form-control"   placeholder="Enter Packet Code " runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ErrorMessage="Please Enter Packet Code" ControlToValidate="txtPacketCode" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
                 </div>


                 <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
                          <asp:Label ID="Label15" runat="server" Text="Phosphatase Test "></asp:Label>
                      </div>
                       <asp:TextBox ID="txtPhosphataseTest" class="form-control"   placeholder="Enter Test " runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ErrorMessage="Please Enter Test" ControlToValidate="txtPhosphataseTest" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
                 </div>



           <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group ">
                      <div class="input-group-addon">
                          <asp:Label ID="Label19" runat="server" Text="Technician "></asp:Label>
                      </div>
                       <asp:TextBox ID="txtTechnician" class="form-control"   placeholder="Enter Technician " runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ErrorMessage="Please Enter Technician" ControlToValidate="txtTechnician" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
                 </div>

              <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
                    <%--   <i class="fa fa-road"></i><span style="color:red">&nbsp;*</span>--%>
                        <asp:Label ID="Label21" runat="server" Text="Status"></asp:Label>

                      </div>
                      <asp:DropDownList ID="dpStatus" class="form-control" DataValueField="StatusId" DataTextField="Name"   runat="server" tooltip="Select Status" > 
                       </asp:DropDownList>
                          
                    </div><!-- /.input group -->
                          <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator11" Display="Dynamic" 
                             ValidationGroup="Save" runat="server" ControlToValidate="dpStatus" ForeColor="Red"
                             ErrorMessage="Pls Select Status" >
                         </asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
            
                         </div>

                   
                <div class="col-lg-3 pull-right">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                        <asp:Button ID="btnAdd" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Add" ValidationGroup="Save" OnClick="btnAdd_Click" /> &nbsp;    
                        <asp:Button ID="btnUpdate" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Update" ValidationGroup="Save" OnClick="btnUpdate_Click" /> &nbsp;    
                        <asp:Button ID="btnRefresh" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Refresh" ValidationGroup="Refresh" OnClick="btnRefresh_Click"  /> &nbsp;                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->                        
                     
  
                </div>
            </ContentTemplate> 
          </asp:UpdatePanel>
                 </div><!-- /.box-body -->            
     </div><!-- /.box -->

              <div class="box ">
            <div class="box-header with-border">
              <h3 class="box-title"> TraceabilityQC Data List </h3>
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
                          <asp:Label ID="Label22" runat="server" Text="Date"></asp:Label>
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
                   

                 
                      <asp:Repeater ID="rpTraceabilityQC" runat="server" OnItemCommand="rpTraceabilityQC_ItemCommand">
                
                
               <HeaderTemplate>
                  <thead>
                      <tr>
                                       <th>RMRId</th>
                                        <th>Batch No</th> 
                                        <th>Tanker Code</th> 
                                        <th>Acidity</th>                                       
                                         <th>Fat</th>
                                          <th>CLR</th>
                                         <th>SNF</th>
                                        <th>Packet code </th>
                                         <th>Pumping Time</th>   
                                        <th>Status</th>
                                        <th>Edit</th>


                      </tr>
                    </thead>
                    <tbody>

                   
               </HeaderTemplate>
               <ItemTemplate>
                    <tr>
                            
                                        <td><%# Eval("RMRId")%></td>   
                                        <td><%# Eval("BatchNo")%></td>
                                        <td><%# Eval("TankerNo")%></td>                                         
                                        <td><%# Eval("Acidity")%></td>                                                                               
                                        <td><%# Eval("Fat")%></td> 
                                       <td><%# Eval("CLR")%></td> 
                                        <td><%# Eval("SNF") %></td>
                                        <td><%# string.Concat(Eval("TankerNo"),Eval("BatchNo")) %></td>
                                        <td><%# Eval("TotalHours")%></td>
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
                                        <th>RMRId</th>
                                        <th>Batch No</th> 
                                        <th>Tanker Code</th>                                         
                                        <th>Acidity</th>                                       
                                         <th>Fat</th>
                                          <th>CLR</th>
                                         <th>SNF</th>
                                        <th>Packet code </th>
                                         <th>Pumping Time</th>   
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
