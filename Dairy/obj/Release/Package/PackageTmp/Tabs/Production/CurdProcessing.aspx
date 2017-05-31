<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CurdProcessing.aspx.cs" Inherits="Dairy.Tabs.Production.Curd_Processing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="../../Theme/plugins/jQueryUI/jquery-ui.css" rel="stylesheet" />
        <script src="../../Theme/plugins/jQuery/jquery-1.10.2.min.js"></script>
        <script src="../../Theme/plugins/jQueryUI/jquery-ui.min.js"></script>
        <style type="text/css">.cntrlbtm {    margin-bottom: 1px;} </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <section class="content-header">
          <h1>
           Curd Processing 
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
              <h3 class="box-title"><asp:Label ID="lblHeaderTab" runat="server" Text="ADD Curd Processing Details"></asp:Label> </h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-plus"></i></button>
                
              </div>
            </div>
            <div class="box-body">
               
              
             <asp:UpdatePanel runat="server" ID="upMain" UpdateMode="Conditional">
              <ContentTemplate>     
                  <div class="row">
               <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label3" runat="server" Text="Batch No"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtBatchNo" class="form-control"   placeholder="Batch No " runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
  <asp:RequiredFieldValidator  ID="RequiredFieldValidator4" Display="Dynamic" 
                                        ValidationGroup="Save" runat="server" ControlToValidate="txtBatchNo" ForeColor="Red"
                                        ErrorMessage="Pls Enter Batch Number " style="font-size:12.5px;"></asp:RequiredFieldValidator>

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
                      <%--<i class="fa fa-road"></i><span style="color:red">&nbsp;*</span>--%>
                        <asp:Label ID="lblCurdProcessShift" runat="server" Text="Shift"></asp:Label>

                      </div>
                      <asp:DropDownList ID="dpCurdProcessShiftId" class="form-control" DataValueField="ShiftId" DataTextField="Name"   runat="server"  > 
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                       <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator21" Display="Dynamic" 
                             ValidationGroup="Save" runat="server" ControlToValidate="dpCurdProcessShiftId" ForeColor="Red"
                             ErrorMessage="Pls Select Shift Details" style="font-size:12.5px;">
                           </asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
               </div>

         
               <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="lblMilkType" runat="server" Text="Type Of Milk"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtMilkType" class="form-control"   placeholder="Enter Milk Type" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
<asp:RequiredFieldValidator  ID="RequiredFieldValidator1" Display="Dynamic" 
                                        ValidationGroup="Save" runat="server" ControlToValidate="txtMilkType" ForeColor="Red"
                                        ErrorMessage="Pls Enter Milk Type" style="font-size:12.5px;"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
                 </div>



                      </div>
<div class="row">

                <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="lblQty" runat="server" Text="Quantity"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtQty" class="form-control"   placeholder="Enter Quantity" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
<asp:RequiredFieldValidator  ID="RequiredFieldValidator2" Display="Dynamic" 
                                        ValidationGroup="Save" runat="server" ControlToValidate="txtQty" ForeColor="Red"
                                        ErrorMessage="Pls Enter Milk Qty" style="font-size:12.5px;"></asp:RequiredFieldValidator>
  <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ValidationExpression= "[0-9]+(\.[0-9][0-9]?)?"
                           ErrorMessage ="Please enter valid number" ControlToValidate="txtQty" ForeColor="Red" style="font-size:12px;" ValidationGroup="Save"/>
                  </div><!-- /.form group -->
                 </div>


          <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label1" runat="server" Text="Heating Temperature"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtHeatingTemperature" class="form-control"   placeholder="Enter Heating Temperature" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
<asp:RequiredFieldValidator  ID="RequiredFieldValidator3" Display="Dynamic" 
                                        ValidationGroup="Save" runat="server" ControlToValidate="txtHeatingTemperature" ForeColor="Red"
                                        ErrorMessage="Pls Enter Milk Heating Temperature" style="font-size:12.5px;"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ValidationExpression= "[0-9]+(\.[0-9][0-9]?)?"
                           ErrorMessage ="Please enter valid number" ControlToValidate="txtHeatingTemperature" ForeColor="Red" style="font-size:12px;" ValidationGroup="Save"/>
                  </div><!-- /.form group -->
                 </div>

            <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label2" runat="server" Text="Holding Time"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtHoldingTime" class="form-control" type="time"  placeholder="Enter Holding Time" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
<asp:RequiredFieldValidator  ID="RequiredFieldValidator5" Display="Dynamic" 
                                        ValidationGroup="Save" runat="server" ControlToValidate="txtHoldingTime" ForeColor="Red"
                                        ErrorMessage="Pls Enter Holding Time" style="font-size:12.5px;"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
                 </div>

           <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label4" runat="server" Text="Inoculation Milk temperature "></asp:Label>
                      </div>
                       <asp:TextBox ID="txtInoculation" class="form-control"   placeholder="Inoculation Milk temperature" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
<asp:RequiredFieldValidator  ID="RequiredFieldValidator6" Display="Dynamic" 
                                        ValidationGroup="Save" runat="server" ControlToValidate="txtInoculation" ForeColor="Red"
                                        ErrorMessage="Pls Enter Inoculation" style="font-size:12.5px;"></asp:RequiredFieldValidator>
 <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationExpression= "[0-9]+(\.[0-9][0-9]?)?"
                           ErrorMessage ="Please enter valid number" ControlToValidate="txtInoculation" ForeColor="Red" style="font-size:12px;" ValidationGroup="Save"/>
                  </div><!-- /.form group -->
                 </div>

                      </div>
                  <div class="row">

            <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label5" runat="server" Text="Culture add Name"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtCultureName" class="form-control"   placeholder="Enter Culture add Name" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
<asp:RequiredFieldValidator  ID="RequiredFieldValidator7" Display="Dynamic" 
                                        ValidationGroup="Save" runat="server" ControlToValidate="txtCultureName" ForeColor="Red"
                                        ErrorMessage="Pls Enter CultureName" style="font-size:12.5px;"></asp:RequiredFieldValidator>

                  </div><!-- /.form group -->
                 </div>


            <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label6" runat="server" Text="Culture lot No"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtCulturelotNo" class="form-control"   placeholder="Enter Culture lot No" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
<asp:RequiredFieldValidator  ID="RequiredFieldValidator8" Display="Dynamic" 
                                        ValidationGroup="Save" runat="server" ControlToValidate="txtCulturelotNo" ForeColor="Red"
                                        ErrorMessage="Pls Enter Culture lot No" style="font-size:12.5px;"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
                 </div>

               <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label20" runat="server" Text="Culture Exp Date"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtcultureExpDate" class="form-control" type="date" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
        <asp:RequiredFieldValidator ID="RFVCultureExp" runat="server" Display="Dynamic"
                        ErrorMessage="Select Culture Exp Date" ForeColor="Red" style="font-size:12.5px;" ControlToValidate="txtcultureExpDate" ValidationGroup="Save"> </asp:RequiredFieldValidator>
                       </div><!-- /.form group -->
                                        
                          
                      </div> 


<%--            <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                          <asp:Label ID="Label7" runat="server" Text="Culture Expiry Date"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtcultureExpDate" class="form-control" type="date"  placeholder="Enter Culture Expiry Date" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
                 </div>--%>

            <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label8" runat="server" Text="Incubation Starting Time"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtIncubationStartTime" class="form-control"  type="time" placeholder="Enter Incubation Starting Time" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
 <asp:RequiredFieldValidator ID="RFVIncubationStart" runat="server" ErrorMessage="Please Enter Incubation Start Time" style="font-size:12.5px;" ControlToValidate="txtIncubationStartTime" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
                 </div>

                      </div>
                      <div class="row">

            <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label9" runat="server" Text="Incubation End Time"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtIncubationEndTime" class="form-control"  type="time" placeholder="Enter Incubation End Time" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Please Enter Incubation End Time" style="font-size:12.5px;" ControlToValidate="txtIncubationEndTime" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
                 </div>


            <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label10" runat="server" Text="Qty Milk for Can Curd"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtQtyMilkforCanCurd" class="form-control"   placeholder="Enter Qty Milk for Can Curd" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
            <asp:RequiredFieldValidator  ID="RequiredFieldValidator16" Display="Dynamic" 
                                        ValidationGroup="Save" runat="server" ControlToValidate="txtQtyMilkforCanCurd" ForeColor="Red"
                                        ErrorMessage="Pls Enter Qty Milk for Can Curd" style="font-size:12.5px;"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ValidationExpression= "[0-9]+(\.[0-9][0-9]?)?"
                           ErrorMessage ="Please enter valid number" ControlToValidate="txtQtyMilkforCanCurd" ForeColor="Red" style="font-size:12px;" ValidationGroup="Save"/>
  
                  </div><!-- /.form group -->
                 </div>

            <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label11" runat="server" Text="Qty Milk for Cup/Pouch Curd"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtQtyMilkforCupPouchCurd" class="form-control"   placeholder="Enter Qty Milk for Cup/Pouch Curd" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator  ID="RequiredFieldValidator17" Display="Dynamic" 
                                        ValidationGroup="Save" runat="server" ControlToValidate="txtQtyMilkforCupPouchCurd" ForeColor="Red"
                                        ErrorMessage="Pls Enter Qty Milk for Cup Pouch Curd" style="font-size:12.5px;"></asp:RequiredFieldValidator>
                      <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ValidationExpression= "[0-9]+(\.[0-9][0-9]?)?"
                           ErrorMessage ="Please enter valid number" ControlToValidate="txtQtyMilkforCupPouchCurd" ForeColor="Red" style="font-size:12px;" ValidationGroup="Save"/>
                  </div><!-- /.form group -->
                 </div>

            <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label12" runat="server" Text="Packing Start Time"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtPackingStartTime" class="form-control" type="time"  placeholder="Enter Packing Start Time" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ErrorMessage="Please Enter Packing Start Time" style="font-size:12.5px;" ControlToValidate="txtPackingStartTime" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
                 </div>
     
                          </div>
                  <div class="row">

            <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label13" runat="server" Text="Packing End Time"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtPackingEndTime" class="form-control"  type="time" placeholder="Enter Packing End Time" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
 <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ErrorMessage="Please Enter Packing End Time" style="font-size:12.5px;" ControlToValidate="txtPackingEndTime" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
                 </div>


            <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label14" runat="server" Text="Batch code"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtBatchcode" class="form-control"   placeholder="Enter Batch code " runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
<asp:RequiredFieldValidator  ID="RequiredFieldValidator10" Display="Dynamic" 
                                        ValidationGroup="Save" runat="server" ControlToValidate="txtBatchcode" ForeColor="Red"
                                        ErrorMessage="Pls Enter Batch Code " style="font-size:12.5px;"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
                 </div>
                  
            <div class="col-lg-3"> 
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label15" runat="server" Text="Cold Room Temperature "></asp:Label>
                      </div>
                       <asp:TextBox ID="txtColdRoomTemp" class="form-control"   placeholder="Enter Cold Room Temperature" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                        <asp:RequiredFieldValidator  ID="RequiredFieldValidator11" Display="Dynamic" 
                                        ValidationGroup="Save" runat="server" ControlToValidate="txtColdRoomTemp" ForeColor="Red"
                                        ErrorMessage="Pls Enter Cold Room Temperature" style="font-size:12.5px;"></asp:RequiredFieldValidator>
                       <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ValidationExpression= "[0-9]+(\.[0-9][0-9]?)?"
                           ErrorMessage ="Please enter valid number" ControlToValidate="txtColdRoomTemp" ForeColor="Red" style="font-size:12px;" ValidationGroup="Save"/>
                  </div><!-- /.form group -->
                 </div>

            <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label16" runat="server" Text="Processed by"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtProcessedby" class="form-control"   placeholder="Enter Processed by" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
            <asp:RequiredFieldValidator  ID="RequiredFieldValidator12" Display="Dynamic" 
                                        ValidationGroup="Save" runat="server" ControlToValidate="txtProcessedby" ForeColor="Red"
                                        ErrorMessage="Pls Enter Processed by" style="font-size:12.5px;"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
                 </div>

                      </div>
                  <div class="row">

            <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label17" runat="server" Text="Lab Technician"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtLabTechnician" class="form-control"   placeholder="Enter Lab Technician" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
 <asp:RequiredFieldValidator  ID="RequiredFieldValidator13" Display="Dynamic" 
                                        ValidationGroup="Save" runat="server" ControlToValidate="txtLabTechnician" ForeColor="Red"
                                        ErrorMessage="Pls Enter Lab Technician" style="font-size:12.5px;"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
                 </div>


            <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label19" runat="server" Text="Verified By"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtVerifiedBy" class="form-control"   placeholder="Enter Verified By" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
 <asp:RequiredFieldValidator  ID="RequiredFieldValidator14" Display="Dynamic" 
                                        ValidationGroup="Save" runat="server" ControlToValidate="txtVerifiedBy" ForeColor="Red"
                                        ErrorMessage="Pls Enter Verified By" style="font-size:12.5px;"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
                 </div>


            <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label18" runat="server" Text="Approved By"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtApprovedBy" class="form-control"   placeholder="Enter Approved By" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
            <asp:RequiredFieldValidator  ID="RequiredFieldValidator15" Display="Dynamic" 
                                        ValidationGroup="Save" runat="server" ControlToValidate="txtApprovedBy" ForeColor="Red"
                                        ErrorMessage="Pls Enter Approved By" style="font-size:12.5px;"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
                 </div>

            <div class="col-lg-3">
                  <div class="form-group ">
                    <div class="input-group">
                      <div class="input-group-addon">                    
                        <asp:Label ID="Label7" runat="server" Text="Curd Process Status"></asp:Label>
                      </div>
                      <asp:DropDownList ID="dpCurdProcessingStatusId" class="form-control" DataValueField="StatusId" DataTextField="StatusName"   runat="server" ValidationGroup="Save" > 
                        
                      </asp:DropDownList>                       
                    </div><!-- /.input group -->
                       <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator20" Display="Dynamic" 
                             ValidationGroup="Save" runat="server" ControlToValidate="dpCurdProcessingStatusId" ForeColor="Red"
                             ErrorMessage="Pls Select Curd Process Status" style="font-size:12px;">
                         </asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
               </div>

</div>

              <div class="col-lg-3 pull-right">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      
                    
                      
                        <asp:Button ID="btnAddCurdProcessInfo" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Add" ValidationGroup="Save" Onclick="btnAddCurdProcessInfo_Click" /> &nbsp;    
                        <asp:Button ID="btnUpdateCurdProcessdetail" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Update" ValidationGroup="Save" Onclick="btnUpdateCurdProcessdetail_Click"/>  &nbsp        
                        <asp:Button ID="btnRefresh" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Refresh" ValidationGroup="Refresh" Onclick="btnRefresh_Click" />             
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
                                   
                       
                          
                      </div>
                        
                    </ContentTemplate>
                </asp:UpdatePanel>
                 
                
            </div><!-- /.box-body -->            
          </div><!-- /.box -->

          <div class="box ">
            <div class="box-header with-border">
              <h3 class="box-title"> Curd Processing Information List </h3>
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
                          <asp:Label ID="Label21" runat="server" Text="Date"></asp:Label>
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
                   

                 
                      <asp:Repeater ID="rpCurdProcessingList" runat="server" OnItemCommand="rpCurdProcessingList_ItemCommand" >
                
                
               <HeaderTemplate>
                  <thead>
                      <tr>
                                    <%--   <th>RMRId</th>--%>
                                       <th>RMRDate</th>
                                       <th>Batch No</th>
                                        <th>Type Of Milk</th>
                                        <th>Quantity</th>
                                        <th>Status</th>
                                        <th>Edit</th>

                      </tr>
                    </thead>
                    <tbody>

                   
               </HeaderTemplate>
               <ItemTemplate>
                    <tr>
                            

                                      <%--  <td><%# Eval("RMRId")%></td>  --%> 
                                        <td><%# Convert.ToDateTime(Eval("RMRDate")).ToString("dd-MM-yyyy")%></td>     
                                        <td><%# Eval("BatchNo")%></td>
                                        <td><%# Eval("TypeOfMilk")%></td>
                                        <td><%# Eval("Qty")%></td>
                                         <td><%# Eval("StatusName")%></td>
                                       
                                          
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
                                      <%--<th>RMRId</th>--%>
                                       <th>RMRDate</th>
                                       <th>Batch No</th>
                                        <th>Type Of Milk</th>
                                        <th>Quantity</th>
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

