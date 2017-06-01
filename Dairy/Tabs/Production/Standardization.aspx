<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Standardization.aspx.cs" Inherits="Dairy.Tabs.Production.Standardization" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
     <link href="../../Theme/plugins/jQueryUI/jquery-ui.css" rel="stylesheet" />
        <script src="../../Theme/plugins/jQuery/jquery-1.10.2.min.js"></script>
        <script src="../../Theme/plugins/jQueryUI/jquery-ui.min.js"></script>
        <style type="text/css">.cntrlbtm {    margin-bottom: 1px;} </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section class="content-header">
          <h1>
           	Standardization  Production 
            <small>Details</small>    
          </h1> 
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Administration</a></li>
            <li class="active">Standardization</li>
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
              <h3 class="box-title"><asp:Label ID="lblHeaderTab" runat="server" Text="Standardization  Production"></asp:Label> </h3>
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
                          <asp:Label ID="Label21" runat="server" Text="RMR Batch No"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtBatchNo" class="form-control"   placeholder="RMR Batch No " runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                                    <asp:RequiredFieldValidator  ID="RequiredFieldValidator4" Display="Dynamic" 
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
                        <asp:Label ID="lblShift" runat="server" Text="Shift"></asp:Label>

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
                          <asp:Label ID="lblSiloNo" runat="server" Text="Silo No"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtSiloNo" class="form-control"   placeholder="Silo No " runat="server" ValidationGroup="Save"></asp:TextBox>                        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator  ID="RequiredFieldValidator1" Display="Dynamic" 
                                        ValidationGroup="Save" runat="server" ControlToValidate="txtSiloNo" ForeColor="Red"
                                        ErrorMessage="Pls Enter Silo Number " style="font-size:12px;"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
                 </div>

    </div>
                 
                   <div class="row">

                               <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label3" runat="server" Text="FAT"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtFat" class="form-control"   placeholder="FAT " runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator  ID="RequiredFieldValidator2" Display="Dynamic" 
                                        ValidationGroup="Save" runat="server" ControlToValidate="txtFat" ForeColor="Red"
                                        ErrorMessage="Pls Enter Fat " style="font-size:12px;"></asp:RequiredFieldValidator>
                          <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ValidationExpression= "[0-9]+(\.[0-9][0-9]?)?"
                           ErrorMessage ="Please enter valid number" ControlToValidate="txtFat" ForeColor="Red" style="font-size:12px;" ValidationGroup="Save"/>
                  </div><!-- /.form group -->
                 </div>

            <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label4" runat="server" Text="SNF"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtSnf" class="form-control"   placeholder="SNF " runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                <asp:RequiredFieldValidator  ID="RequiredFieldValidator3" Display="Dynamic" 
                                        ValidationGroup="Save" runat="server" ControlToValidate="txtSnf" ForeColor="Red"
                                        ErrorMessage="Pls Enter SNF " style="font-size:12px;"></asp:RequiredFieldValidator>
                         <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationExpression= "[0-9]+(\.[0-9][0-9]?)?"
                           ErrorMessage ="Please enter valid number" ControlToValidate="txtSnf" ForeColor="Red" style="font-size:12px;" ValidationGroup="Save"/>
                  </div><!-- /.form group -->
                 </div>

            <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label15" runat="server" Text="Type Of Milk"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtTypeOfMilk" class="form-control"   placeholder="Enter Type Of Milk " runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                <asp:RequiredFieldValidator  ID="RequiredFieldValidator17" Display="Dynamic" 
                                        ValidationGroup="Save" runat="server" ControlToValidate="txtTypeOfMilk" ForeColor="Red"
                                        ErrorMessage="Pls Enter Type Of Milk" style="font-size:12px;"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
                 </div>

            <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label14" runat="server" Text="Total Quantity"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtTotalQuantity" class="form-control"   placeholder="Enter Total Quantity " runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                       <asp:RequiredFieldValidator  ID="RequiredFieldValidator16" Display="Dynamic" 
                                        ValidationGroup="Save" runat="server" ControlToValidate="txtTotalQuantity" ForeColor="Red"
                                        ErrorMessage="Pls Enter Total Quantity" style="font-size:12px;"></asp:RequiredFieldValidator>
                      <asp:RegularExpressionValidator ID="RegularExpressionValidator14" runat="server" ValidationExpression= "[0-9]+(\.[0-9][0-9]?)?"
                           ErrorMessage ="Please enter valid number" ControlToValidate="txtTotalQuantity" ForeColor="Red" style="font-size:12px;" ValidationGroup="Save"/>
                  </div><!-- /.form group -->
                 </div>

              <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="lblStandardization" runat="server" Text="Std Start Time "></asp:Label>
                      </div>
                       <asp:TextBox ID="txtStandardizationStartTime" class="form-control"   placeholder="Start Time " runat="server" type="time"></asp:TextBox>                        
                    </div><!-- /.input group -->
                   <asp:RequiredFieldValidator ID="RFVSTDStart" runat="server" ErrorMessage="Please Standardization Start Time" style="font-size:12px;" ControlToValidate="txtStandardizationStartTime" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
                 </div>

                <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="lblStnd" runat="server" Text="Std End Time"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtStandardizationEndTime" class="form-control" type="time"  placeholder="End Time " runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
        <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ErrorMessage="Please Standardization End Time" style="font-size:12px;" ControlToValidate="txtStandardizationEndTime" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
                 </div>


                <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="lblRCMQty" runat="server" Text="RCM Quantity"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtRCMQty" class="form-control"   placeholder="Enter RCM Quantity" runat="server"></asp:TextBox>                        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator  ID="RequiredFieldValidator5" Display="Dynamic" 
                                        ValidationGroup="Save" runat="server" ControlToValidate="txtRCMQty" ForeColor="Red"
                                        ErrorMessage="Pls Enter RCM Qty " style="font-size:12px;"></asp:RequiredFieldValidator>
                         <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ValidationExpression= "[0-9]+(\.[0-9][0-9]?)?"
                           ErrorMessage ="Please enter valid number" ControlToValidate="txtRCMQty" ForeColor="Red" style="font-size:12px;" ValidationGroup="Save"/>
                  </div><!-- /.form group -->
                 </div>




              <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label5" runat="server" Text="Cutting Milk Quantity"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtCuttingMilkQuantity" class="form-control"   placeholder="Enter Cutting Qty " runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator  ID="RequiredFieldValidator6" Display="Dynamic" 
                                        ValidationGroup="Save" runat="server" ControlToValidate="txtCuttingMilkQuantity" ForeColor="Red"
                                        ErrorMessage="Pls Enter Cutting Milk Quantity " style="font-size:12px;"></asp:RequiredFieldValidator>
                       <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ValidationExpression= "[0-9]+(\.[0-9][0-9]?)?"
                           ErrorMessage ="Please enter valid number" ControlToValidate="txtCuttingMilkQuantity" ForeColor="Red" style="font-size:12px;" ValidationGroup="Save"/>
                  </div><!-- /.form group -->
                 </div>


                </div>      
                  
     <div class="row">                  

           

               <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label6" runat="server" Text="Cutting Milk FAT"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtCuttingMilkFat" class="form-control"   placeholder="Enter Cutting Fat " runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator  ID="RequiredFieldValidator7" Display="Dynamic" 
                                        ValidationGroup="Save" runat="server" ControlToValidate="txtCuttingMilkFat" ForeColor="Red"
                                        ErrorMessage="Pls Enter Cutting Milk Fat " style="font-size:12px;"></asp:RequiredFieldValidator>
                     <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ValidationExpression= "[0-9]+(\.[0-9][0-9]?)?"
                           ErrorMessage ="Please enter valid number" ControlToValidate="txtCuttingMilkFat" ForeColor="Red" style="font-size:12px;" ValidationGroup="Save"/>
                  </div><!-- /.form group -->
                 </div>

               <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label7" runat="server" Text="Cutting Milk SNF"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtCuttingMilkSnf" class="form-control"   placeholder="Enter Cutting Snf " runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                       <asp:RequiredFieldValidator  ID="RequiredFieldValidator8" Display="Dynamic" 
                                        ValidationGroup="Save" runat="server" ControlToValidate="txtCuttingMilkSnf" ForeColor="Red"
                                        ErrorMessage="Pls Enter Cutting Milk Snf " style="font-size:12px;"></asp:RequiredFieldValidator>
                      <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ValidationExpression= "[0-9]+(\.[0-9][0-9]?)?"
                           ErrorMessage ="Please enter valid number" ControlToValidate="txtCuttingMilkSnf" ForeColor="Red" style="font-size:12px;" ValidationGroup="Save"/>
                  </div><!-- /.form group -->
                 </div>

              <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label8" runat="server" Text="Skim"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtSkim" class="form-control"   placeholder="Skim " runat="server"  ></asp:TextBox>                        
                    </div><!-- /.input group -->
                       <asp:RequiredFieldValidator  ID="RequiredFieldValidator9" Display="Dynamic" 
                                        ValidationGroup="Save" runat="server" ControlToValidate="txtSkim" ForeColor="Red"
                                        ErrorMessage="Pls Enter Skim" style="font-size:12px;"></asp:RequiredFieldValidator>
                          <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ValidationExpression= "[0-9]+(\.[0-9][0-9]?)?"
                           ErrorMessage ="Please enter valid number" ControlToValidate="txtSkim" ForeColor="Red" style="font-size:12px;" ValidationGroup="Save"/>
                  </div><!-- /.form group -->
                 </div>

            <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label9" runat="server" Text="Skim Fat"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtSkimFat" class="form-control"   placeholder="Enter Skim Fat " runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                       <asp:RequiredFieldValidator  ID="RequiredFieldValidator10" Display="Dynamic" 
                                        ValidationGroup="Save" runat="server" ControlToValidate="txtSkimFat" ForeColor="Red"
                                        ErrorMessage="Pls Enter SkimFat" style="font-size:12px;"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ValidationExpression= "[0-9]+(\.[0-9][0-9]?)?"
                           ErrorMessage ="Please enter valid number" ControlToValidate="txtSkimFat" ForeColor="Red" style="font-size:12px;" ValidationGroup="Save"/>
                  </div><!-- /.form group -->
                 </div>


         </div>

                  <div class="row">

                  
              <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label1" runat="server" Text="Skim Snf"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtSkimSnf" class="form-control"   placeholder="Enter Skim Snf " runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                <asp:RequiredFieldValidator  ID="RequiredFieldValidator11" Display="Dynamic" 
                                        ValidationGroup="Save" runat="server" ControlToValidate="txtSkimSnf" ForeColor="Red"
                                        ErrorMessage="Pls Enter Skim SNF" style="font-size:12px;"></asp:RequiredFieldValidator>
                       <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ValidationExpression= "[0-9]+(\.[0-9][0-9]?)?"
                           ErrorMessage ="Please enter valid number" ControlToValidate="txtSkimSnf" ForeColor="Red" style="font-size:12px;" ValidationGroup="Save"/>
                  </div><!-- /.form group -->
                 </div>


              <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label10" runat="server" Text="RCM"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtRcm" class="form-control"   placeholder="Enter RCM " runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator  ID="RequiredFieldValidator12" Display="Dynamic" 
                                        ValidationGroup="Save" runat="server" ControlToValidate="txtRcm" ForeColor="Red"
                                        ErrorMessage="Pls Enter Skim SNF" style="font-size:12px;"></asp:RequiredFieldValidator>
                      <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server" ValidationExpression= "[0-9]+(\.[0-9][0-9]?)?"
                           ErrorMessage ="Please enter valid number" ControlToValidate="txtRcm" ForeColor="Red" style="font-size:12px;" ValidationGroup="Save"/>
                  </div><!-- /.form group -->
                 </div>

              <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label11" runat="server" Text="SMP Add"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtSmpAdd" class="form-control"   placeholder="SMP Add " runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator  ID="RequiredFieldValidator13" Display="Dynamic" 
                                        ValidationGroup="Save" runat="server" ControlToValidate="txtSmpAdd" ForeColor="Red"
                                        ErrorMessage="Pls Enter SMP " style="font-size:12px;"></asp:RequiredFieldValidator>
                      <asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server" ValidationExpression= "[0-9]+(\.[0-9][0-9]?)?"
                           ErrorMessage ="Please enter valid number" ControlToValidate="txtSmpAdd" ForeColor="Red" style="font-size:12px;" ValidationGroup="Save"/>
                  </div><!-- /.form group -->
                 </div>

           <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label12" runat="server" Text="Cream Add"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtCreamAdd" class="form-control"   placeholder="Enter Cream " runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                <asp:RequiredFieldValidator  ID="RequiredFieldValidator14" Display="Dynamic" 
                                        ValidationGroup="Save" runat="server" ControlToValidate="txtCreamAdd" ForeColor="Red"
                                        ErrorMessage="Pls Enter Cream Add " style="font-size:12px;"></asp:RequiredFieldValidator>
                      <asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server" ValidationExpression= "[0-9]+(\.[0-9][0-9]?)?"
                           ErrorMessage ="Please enter valid number" ControlToValidate="txtCreamAdd" ForeColor="Red" style="font-size:12px;" ValidationGroup="Save"/>
                  </div><!-- /.form group -->
                 </div>


                      </div>

       <div class="row">


           <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label13" runat="server" Text="Cream Produced"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtCreamProduced" class="form-control"   placeholder="Enter Cream Produced " runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                <asp:RequiredFieldValidator  ID="RequiredFieldValidator15" Display="Dynamic" 
                                        ValidationGroup="Save" runat="server" ControlToValidate="txtCreamProduced" ForeColor="Red"
                                        ErrorMessage="Pls Enter Cream Produced" style="font-size:12px;"></asp:RequiredFieldValidator>
                      <asp:RegularExpressionValidator ID="RegularExpressionValidator13" runat="server" ValidationExpression= "[0-9]+(\.[0-9][0-9]?)?"
                           ErrorMessage ="Please enter valid number" ControlToValidate="txtCreamProduced" ForeColor="Red" style="font-size:12px;" ValidationGroup="Save"/>
                  </div><!-- /.form group -->
                 </div>

            <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label16" runat="server" Text="Remarks"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtRemarks" class="form-control"   placeholder="Enter Remarks " runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
                 </div>

                <div Id="hideStdDone" class="col-lg-3" runat="server">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">                    
                        <asp:Label ID="Label17" runat="server" Text="Standardization Process"></asp:Label>
                      </div>
                      <asp:DropDownList ID="dpStandardDone" class="form-control" DataValueField="StatusId" DataTextField="StatusName"   runat="server" ValidationGroup="Save" > 
                        </asp:DropDownList>                       
                    </div><!-- /.input group -->                                                                           
                       <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator19" Display="Dynamic" 
                             ValidationGroup="Save" runat="server" ControlToValidate="dpStandardDone" ForeColor="Red"
                             ErrorMessage="Pls Select Standardization Done Or Not" style="font-size:12px;">
                         </asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
               </div>

           <div Id="txtStatushide" class="col-lg-3" runat="server">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label2" runat="server" Text="Remarks"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtStatus" class="form-control"   placeholder="Status" runat="server" readonly="true"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
                 </div>



           </div>

          <div class="col-lg-3 pull-right">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      
                    
                      
                        <asp:Button ID="btnAddProductionInfo" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Add" ValidationGroup="Save" OnClick="btnAddProductionInfo_Click"/> &nbsp;    
                        <asp:Button ID="btnUpdateProductindetail" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Update" ValidationGroup="Save" OnClick="btnUpdateProductindetail_Click"/>  &nbsp        
                        <asp:Button ID="btnRefresh" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Refresh" OnClick="btnRefresh_Click" />             
                  </div><!-- /.input group -->

                  </div><!-- /.form group -->
                          
                 </div>

                
     <%--       <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                          <asp:Label ID="Label2" runat="server" Text="Custom1"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtCustom1" class="form-control"   placeholder="Custom1 " runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
                 </div>
                
                  <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                          <asp:Label ID="Label17" runat="server" Text="Custom2"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtCustom2" class="form-control"   placeholder="Custom2 " runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
                 </div>
                
                  <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                          <asp:Label ID="Label18" runat="server" Text="Custom3"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtCustom3" class="form-control"   placeholder="Custom3 " runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
                 </div>
                
             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                          <asp:Label ID="Label19" runat="server" Text="Custom4"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtCustom4" class="form-control"   placeholder="Custom4" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
                 </div>
                
                  <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                          <asp:Label ID="Label20" runat="server" Text="Custom5"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtCustom5" class="form-control"   placeholder="Enter Custom5 " runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
                 </div>--%>

                        
                    </ContentTemplate>
                </asp:UpdatePanel>
                 
                 </div><!-- /.box-body -->            
          </div><!-- /.box --> 
     

         <div class="box ">
            <div class="box-header with-border">
              <h3 class="box-title"> Standardization Information List </h3>
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
                          <asp:Label ID="Label18" runat="server" Text="Date"></asp:Label>
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
                   

                 
                      <asp:Repeater ID="rpStandardizationList" runat="server" OnItemCommand="rpStandardizationList_ItemCommand">
                
                
               <HeaderTemplate>
                  <thead>
                      <tr>
                                  <%--<th>RMRId</th>--%>
                                      <%--<th>Qty Id</th>--%>
                                         <th>RMR Date</th>
                                        <th>RMR Batch No</th>
                                        <th>Date</th>
                                        <th>Shift Name</th>
                                         <th>FAT</th>
                                        <th>SNF</th>
                                        <th>Silo No</th> 
                                        <th>Status</th>                                   
                                        <th>Edit</th>
                                                                             
                                      


                      </tr>
                    </thead>
                    <tbody>

                   
               </HeaderTemplate>
               <ItemTemplate>
                    <tr>
                            
                                        <%--<td><%# Eval("RMRId")%></td>   --%>
                                        <%--<td><%# Eval("QualityId")%></td>  --%> 
                                        <td><%# Convert.ToDateTime(Eval("RMRDate")).ToString("dd-MM-yyyy")%></td>  
                                        <td><%# Eval("BatchNo")%></td>   
                                        <td><%# Eval("QualityDate")%></td> 
                                        <td><%# Eval("ShiftName")%></td>                                                                                                                  
                                        <td><%# Eval("FAT")%></td>
                                        <td><%# Eval("SNF")%></td>                                        
                                        <td><%# Eval("SiloNo")%></td>
                                         <td><%# Eval("StatusName")%></td>
                                    <%-- <td></td>--%>
                                            <asp:HiddenField id="hfQualityId" runat="server" value='<%#Eval("QualityId") %>' />    
                                          
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
                                      <%--<th>Qty Id</th>--%>
                                         <th>RMR Date</th>
                                        <th>RMR Batch No</th>
                                        <th>Date</th>
                                        <th>Shift Name</th>
                                         <th>FAT</th>
                                        <th>SNF</th>
                                        <th>Silo No</th> 
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

         <asp:HiddenField id="hfQualityId" runat="server"/>
       

</section>
</asp:Content>

