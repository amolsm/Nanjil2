<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CurdProcseeingQC.aspx.cs" Inherits="Dairy.Tabs.Production.CurdProcseeingQC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
     <link href="../../Theme/plugins/jQueryUI/jquery-ui.css" rel="stylesheet" />
        <script src="../../Theme/plugins/jQuery/jquery-1.10.2.min.js"></script>
        <script src="../../Theme/plugins/jQueryUI/jquery-ui.min.js"></script>
        <style type="text/css">.cntrlbtm {    margin-bottom: 1px;} </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <section class="content-header">
          <h1>
           Curd Processing Quality Check
            <small>Details</small>    
          </h1> 
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Administration</a></li>
            <li class="active">Admin</li>
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
              <h3 class="box-title"><asp:Label ID="lblHeaderTab" runat="server" Text="ADD Curd Processing QC Details"></asp:Label> </h3>
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
                          <asp:Label ID="Label3" runat="server" Text="Batch No"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtBatchNo" class="form-control"   placeholder="Batch No " runat="server" readonly="true"></asp:TextBox>                        
                    </div><!-- /.input group -->
               <asp:RequiredFieldValidator  ID="RequiredFieldValidator4" Display="Dynamic" 
                                        ValidationGroup="Save" runat="server" ControlToValidate="txtBatchNo" ForeColor="Red"
                                        ErrorMessage="Pls Enter Batch Number " style="font-size:12.5px;"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
                 </div>
      
        
               <div class="col-lg-3">
                  <div class="form-group ">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="lblDate" runat="server" Text="Date"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtCurdQCDate" class="form-control" type="date" runat="server" required></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
                                        
                          
                      </div> 


                <div class="col-lg-3">
                  <div class="form-group ">
                    <div class="input-group">
                      <div class="input-group-addon">
                      <%--<i class="fa fa-road"></i><span style="color:red">&nbsp;*</span>--%>
                        <asp:Label ID="lblCurdQCShift" runat="server" Text="Shift"></asp:Label>

                      </div>
                      <asp:DropDownList ID="dpCurdQCShift" class="form-control" DataValueField="ShiftId" DataTextField="Name"   runat="server"  > 
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                       <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator16" Display="Dynamic" 
                             ValidationGroup="Save" runat="server" ControlToValidate="dpCurdQCShift" ForeColor="Red"
                             ErrorMessage="Pls Select Shift Details" style="font-size:12.5px;">
                           </asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
               </div>

               <div class="col-lg-3">
                  <div class="form-group ">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label15" runat="server" Text="Silo No"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtSiloNo" class="form-control"   placeholder="Silo No " runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
<asp:RequiredFieldValidator  ID="RequiredFieldValidator14" Display="Dynamic" 
                                        ValidationGroup="Save" runat="server" ControlToValidate="txtSiloNo" ForeColor="Red"
                                        ErrorMessage="Pls Enter Silo No" style="font-size:12.5px;"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
                 </div>

         

</div>



<div class="row">
               <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="lblProcessTime" runat="server" Text="Process Time"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtProcessingTime" class="form-control"   placeholder="Enter Processing Time" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ErrorMessage="Pls Enter Processing Time" style="font-size:12.5px;" ControlToValidate="txtProcessingTime" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
                 </div>

                <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="lblQty" runat="server" Text="Process Quantity"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtProcessQty" class="form-control"   placeholder="Enter Process Quantity" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
    <asp:RequiredFieldValidator  ID="RequiredFieldValidator2" Display="Dynamic" 
                                        ValidationGroup="Save" runat="server" ControlToValidate="txtProcessQty" ForeColor="Red"
                                        ErrorMessage="Pls Enter Process Qty" style="font-size:12.5px;"></asp:RequiredFieldValidator>
                           <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ValidationExpression= "[0-9]+(\.[0-9][0-9]?)?"
                           ErrorMessage ="Please enter valid number" ControlToValidate="txtProcessQty" ForeColor="Red" style="font-size:12px;" ValidationGroup="Save"/>
                  </div><!-- /.form group -->
                 </div>

          <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label1" runat="server" Text="Temperature"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtTemperature" class="form-control"   placeholder="Enter Temperature" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
 <asp:RequiredFieldValidator  ID="RequiredFieldValidator3" Display="Dynamic" 
                                        ValidationGroup="Save" runat="server" ControlToValidate="txtTemperature" ForeColor="Red"
                                        ErrorMessage="Pls Enter Temperature" style="font-size:12.5px;"></asp:RequiredFieldValidator>
                          <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationExpression= "[0-9]+(\.[0-9][0-9]?)?"
                           ErrorMessage ="Please enter valid number" ControlToValidate="txtTemperature" ForeColor="Red" style="font-size:12px;" ValidationGroup="Save"/>
                  </div><!-- /.form group -->
                 </div>

    <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label6" runat="server" Text="Fat"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtFat" class="form-control"   placeholder="Enter Fat Percentage" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
     <asp:RequiredFieldValidator  ID="RequiredFieldValidator5" Display="Dynamic" 
                                        ValidationGroup="Save" runat="server" ControlToValidate="txtFat" ForeColor="Red"
                                        ErrorMessage="Pls Enter Fat" style="font-size:12.5px;"></asp:RequiredFieldValidator>
                           <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ValidationExpression= "[0-9]+(\.[0-9][0-9]?)?"
                           ErrorMessage ="Please enter valid number" ControlToValidate="txtFat" ForeColor="Red" style="font-size:12px;" ValidationGroup="Save"/>
                  </div><!-- /.form group -->
            </div>

    </div>

     <div class="row">
               <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label2" runat="server" Text="CLR"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtCLR" class="form-control"   placeholder="Enter CLR" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
<asp:RequiredFieldValidator  ID="RequiredFieldValidator6" Display="Dynamic" 
                                        ValidationGroup="Save" runat="server" ControlToValidate="txtCLR" ForeColor="Red"
                                        ErrorMessage="Pls Enter CLR" style="font-size:12.5px;"></asp:RequiredFieldValidator>
                           <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ValidationExpression= "[0-9]+(\.[0-9][0-9]?)?"
                           ErrorMessage ="Please enter valid number" ControlToValidate="txtCLR" ForeColor="Red" style="font-size:12px;" ValidationGroup="Save"/>
                  </div><!-- /.form group -->
            </div>

               <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label8" runat="server" Text="SNF"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtSNF" class="form-control"   placeholder="Enter SNF" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
<asp:RequiredFieldValidator  ID="RequiredFieldValidator7" Display="Dynamic" 
                                        ValidationGroup="Save" runat="server" ControlToValidate="txtSNF" ForeColor="Red"
                                        ErrorMessage="Pls Enter SNF" style="font-size:12.5px;"></asp:RequiredFieldValidator>
                          <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ValidationExpression= "[0-9]+(\.[0-9][0-9]?)?"
                           ErrorMessage ="Please enter valid number" ControlToValidate="txtSNF" ForeColor="Red" style="font-size:12px;" ValidationGroup="Save"/>
                  </div><!-- /.form group -->
            </div>

            <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label21" runat="server" Text="Acidity"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtAcidity" class="form-control"   placeholder="Enter Acidity" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
<asp:RequiredFieldValidator  ID="RequiredFieldValidator8" Display="Dynamic" 
                                        ValidationGroup="Save" runat="server" ControlToValidate="txtAcidity" ForeColor="Red"
                                        ErrorMessage="Pls Enter Acidity" style="font-size:12.5px;"></asp:RequiredFieldValidator>
                          <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ValidationExpression= "[0-9]+(\.[0-9][0-9]?)?"
                           ErrorMessage ="Please enter valid number" ControlToValidate="txtAcidity" ForeColor="Red" style="font-size:12px;" ValidationGroup="Save"/>
                  </div><!-- /.form group -->
            </div>

               <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label4" runat="server" Text="Hom.efficiency"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtHomEfficiency" class="form-control"   placeholder="Enter Hom.efficiency" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
<asp:RequiredFieldValidator  ID="RequiredFieldValidator9" Display="Dynamic" 
                                        ValidationGroup="Save" runat="server" ControlToValidate="txtHomEfficiency" ForeColor="Red"
                                        ErrorMessage="Pls Enter Hom.Efficiency" style="font-size:12.5px;"></asp:RequiredFieldValidator>
                          
                  </div><!-- /.form group -->
            </div>

</div>
         <div class="row">
               <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label7" runat="server" Text="Organoleptic Taste"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtTaste" class="form-control"   placeholder="Enter Taste" runat="server" ></asp:TextBox> 
                                              
                    </div><!-- /.input group -->
                       <asp:RequiredFieldValidator  ID="RequiredFieldValidator10" Display="Dynamic" 
                                        ValidationGroup="Save" runat="server" ControlToValidate="txtTaste" ForeColor="Red"
                                        ErrorMessage="Pls Enter Organoleptic Taste" style="font-size:12.5px;"></asp:RequiredFieldValidator>
                 </div><!-- /.form group -->
            </div>

                     <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label5" runat="server" Text="Organoleptic Smell"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtSmell" class="form-control"   placeholder="Enter Organoleptic Smell" runat="server" ></asp:TextBox> 
                                              
                    </div><!-- /.input group -->
                       <asp:RequiredFieldValidator  ID="RequiredFieldValidator11" Display="Dynamic" 
                                        ValidationGroup="Save" runat="server" ControlToValidate="txtSmell" ForeColor="Red"
                                        ErrorMessage="Pls Enter Organoleptic Smell" style="font-size:12.5px;"></asp:RequiredFieldValidator>
                 </div><!-- /.form group -->
            </div>

                    <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label9" runat="server" Text="Organoleptic Color"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtColor" class="form-control"   placeholder="Enter Organoleptic Color" runat="server" ></asp:TextBox> 
                                              
                    </div><!-- /.input group -->
                       <asp:RequiredFieldValidator  ID="RequiredFieldValidator12" Display="Dynamic" 
                                        ValidationGroup="Save" runat="server" ControlToValidate="txtColor" ForeColor="Red"
                                        ErrorMessage="Pls Enter Organoleptic Color" style="font-size:12.5px;"></asp:RequiredFieldValidator>
                 </div><!-- /.form group -->
            </div>

               <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label22" runat="server" Text="Phosphatase Start Time"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtPhosphataseStartTime" class="form-control"   placeholder="Enter Start Time" runat="server" type="time"></asp:TextBox> 
                       
                    </div><!-- /.input group -->
                       <asp:RequiredFieldValidator ID="RFVPhosphataseStart" runat="server" ErrorMessage="Pls Enter Phosphatase Start Time" style="font-size:12.5px;" ControlToValidate="txtPhosphataseStartTime" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                       
                  </div><!-- /.form group -->
            </div>

        </div>

   <div class="row">
                 <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label10" runat="server" Text="Phosphatase End Time"></asp:Label>
                      </div>
                     
                        <asp:TextBox ID="txtPhosphataseEndTime" class="form-control"   placeholder="Enter End Time" runat="server" type="time"></asp:TextBox> 
                                              
                    </div><!-- /.input group -->
                      
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ErrorMessage="Pls Enter Phosphatase End Time" style="font-size:12.5px;" ControlToValidate="txtPhosphataseEndTime" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                       
                  </div><!-- /.form group -->
            </div>

                                 <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label11" runat="server" Text="Phosphatase Total hours"></asp:Label>
                      </div>
                      
                        <asp:TextBox ID="txtPhosphataseTotalHours" class="form-control"   placeholder="Enter Total Hours" runat="server" type="time"></asp:TextBox>                        
                    </div><!-- /.input group -->
                       
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ErrorMessage="Pls Enter Phosphatase Total Hours" style="font-size:12.5px;" ControlToValidate="txtPhosphataseTotalHours" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
            </div>



               <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label23" runat="server" Text="MBRT Start Time"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtMBRTStartTime" class="form-control"   placeholder="Enter Start Time" runat="server" type="time" ></asp:TextBox> 
                        
                    </div><!-- /.input group -->
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server"  ErrorMessage="Pls Enter MBRT Start Time" style="font-size:12.5px;" ControlToValidate="txtMBRTStartTime" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                       
                  </div><!-- /.form group -->
            </div>

                                 <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label12" runat="server" Text="MBRT End Time"></asp:Label>
                      </div>
                       
                        <asp:TextBox ID="txtMBRTEndTime" class="form-control"   placeholder="Enter End Time" runat="server" type="time"></asp:TextBox> 
                                              
                    </div><!-- /.input group -->
                        
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ErrorMessage="Pls Enter MBRT End Time" style="font-size:12.5px;" ControlToValidate="txtMBRTEndTime" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                      
                  </div><!-- /.form group -->
            </div>

       </div>

     
              <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label14" runat="server" Text="MBRT Total Hours"></asp:Label>
                      </div>
                      
                        <asp:TextBox ID="txtMBRTTotalHours" class="form-control"   placeholder="Enter Total Hours" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                        
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ErrorMessage="Pls Enter MBRT Total Hours" style="font-size:12.5px;" ControlToValidate="txtMBRTTotalHours" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
            </div>


               <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                       <i class="fa fa-road"></i><span style="color:red">&nbsp;*</span>--%>
                        <asp:Label ID="Label13" runat="server" Text="QC Status"></asp:Label>

                      </div>
                      <asp:DropDownList ID="dpQCDetails" class="form-control" DataValueField="QCId" DataTextField="Name"   runat="server"  > 
                       </asp:DropDownList>
                        
                    </div><!-- /.input group -->
                       <asp:RequiredFieldValidator InitialValue="0" ID="Req_ID" Display="Dynamic" 
                             ValidationGroup="Save" runat="server" ControlToValidate="dpQCDetails" ForeColor="Red"
                             ErrorMessage="Pls Select QC Details" style="font-size:12.5px;">
                         </asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
                         </div>





              <div class="col-lg-3 pull-right">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      
                    
                      
                        <asp:Button ID="btnAddCurdProcessQCInfo" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Add" ValidationGroup="Save" OnClick="btnAddCurdProcessQCInfo_Click"/> &nbsp;    
                        <asp:Button ID="btnUpdateCurdProcessQCdetail" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Update" ValidationGroup="Save" OnClick="btnUpdateCurdProcessQCdetail_Click"/>  &nbsp        
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
              <h3 class="box-title"> Curd Processing QC Information List </h3>
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
                   

                 
                      <asp:Repeater ID="rpCurdProcessingQCList" runat="server" OnItemCommand="rpCurdProcessingQCList_ItemCommand" >
                
                
               <HeaderTemplate>
                  <thead>
                      <tr>
                                      <%-- <th>RMRId</th>--%>
                                       <th>Curd Process Date</th>
                                       <th>Curd Process Shift</th>
                                        <th>Batch Code</th>
                                       <th>Status</th>
                                        <th>Edit</th>

                      </tr>
                    </thead>
                    <tbody>

                   
               </HeaderTemplate>
               <ItemTemplate>
                    <tr>
                            

                                        <%--<td><%# Eval("RMRId")%></td>   --%>
                                        <td><%# Eval("CurdProcessDate")%></td>     
                                        <td><%# Eval("ShiftName")%></td>
                                        <td><%# Eval("BatchCode")%></td>
                                        <td><%# Eval("Status")%></td>

                                        <asp:HiddenField id="hfCurdId" runat="server" value='<%#Eval("CurdId") %>' />               
                                          
                         <td>
                             <asp:LinkButton ID="lbEdite" AlternateText="Edit" ForeColor="Gray" onItemCommand="lblEdite_ItemCommand" 
                                                                    ToolTip="Edit" runat="server" CommandArgument='<%#Eval("RMRID") %>'
                                                                    CommandName="Edit"><i class="fa fa-edit"></i></asp:LinkButton>

                         </td>
                         



                    </tr>
               </ItemTemplate>
                    <FooterTemplate>

                         </tbody>

                    <tfoot>
                      <tr>
                          <tr id="trEmpty" runat="server" visible="false"><td  align = "left"> No records found.</td> </tr>
                                    <%--   <th>RMRId</th>--%>
                                       <th>Curd Process Date</th>
                                       <th>Curd Process Shift</th>
                                        <th>Batch Code</th>
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

