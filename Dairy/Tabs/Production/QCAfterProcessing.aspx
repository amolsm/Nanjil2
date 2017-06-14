<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="QCAfterProcessing.aspx.cs" Inherits="Dairy.Tabs.Production.QCAfterProcessing" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
     <link href="../../Theme/plugins/jQueryUI/jquery-ui.css" rel="stylesheet" />
        <script src="../../Theme/plugins/jQuery/jquery-1.10.2.min.js"></script>
        <script src="../../Theme/plugins/jQueryUI/jquery-ui.min.js"></script>
        <style type="text/css">.cntrlbtm {    margin-bottom: 1px;} </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript">
        $(document).ready(function () {
            $('.cal').change(function () {
                debugger;
                PhosStrTime = $("#MainContent_txtPhosphataseStartingTime").val();
                PhosEndTime = $("#MainContent_txtPhosphataseEndTime").val();
                time1 = PhosStrTime.split(':');
                time2 = PhosEndTime.split(':');
                var hours1 = $.trim(time1[0]) + " hrs";
                var hours2 = $.trim(time2[0]) + " hrs";

                var mins1 = $.trim(time1[1]) + " min";
                var mins2 = $.trim(time2[1]) + " min";

                var hours = parseInt(hours2) - parseInt(hours1), mins = 0;

                if (hours < 0) hours = 24 + hours;
                if (mins2 >= mins1) {
                    mins = parseInt(mins2) - parseInt(mins1);
                }
                else if (mins2 < mins1) {
                    mins = 60 - parseInt(mins1) + parseInt(mins2);
                    hours--;
                }
                else {
                    mins = parseInt(mins2 + 60) - parseInt(mins1);
                    hours--;

                }
                if (hours.toString().length == 1) {
                    hours = "0" + hours;
                }
                if (mins.toString().length == 1) {
                    mins = "0" + mins;
                }

                diff = hours + ":" + mins;
                $("#MainContent_txtPhosphatasetotalhrs").val(diff);

            });
             });
    </script>
      <section class="content-header">
          <h1>
           QC After Processing    
          </h1> 
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Administration</a></li>
            <li class="active">QC after processing</li>
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
              <h3 class="box-title"><asp:Label ID="lblHeaderTab" runat="server" Text="Add QC Details"></asp:Label> </h3>
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
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label12" runat="server" Text="Batch Code"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtBatchCode" class="form-control"   placeholder="Enter Batch Code" runat="server" ValidationGroup="Save" OnTextChanged="txtBatchCode_TextChanged" AutoPostBack="true"></asp:TextBox>                        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RFVBatchcode" runat="server" ErrorMessage="Pls Enter Batch Code" style="font-size:12px;" ControlToValidate="txtBatchCode" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>

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
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Pls Enter Date" style="font-size:12px;" ControlToValidate="txtDate" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>

                  </div><!-- /.form group -->
                </div>                
                          
                       
              <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">                    
                        <asp:Label ID="Label20" runat="server" Text="Shift"></asp:Label>
                      </div>
                      <asp:DropDownList ID="dpShiftDetails" class="form-control" DataValueField="ShiftId" DataTextField="Name"   runat="server" ValidationGroup="Save" > 
                       </asp:DropDownList>                       
                    </div><!-- /.input group -->
                         <asp:RequiredFieldValidator InitialValue="0" ID="Req_ID" Display="Dynamic" 
                             ValidationGroup="Save" runat="server" ControlToValidate="dpShiftDetails" ForeColor="Red"
                             ErrorMessage="Pls Select Shift Detail" style="font-size:12px;">
                         </asp:RequiredFieldValidator>

                  </div><!-- /.form group -->
               </div>

              <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label1" runat="server" Text="Time Of Processing  "></asp:Label>
                      </div>
                       <asp:TextBox ID="txtProcessingTime" class="form-control"  type="time" placeholder="Time Of Processing  " runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Pls Enter Process Time" style="font-size:12px;" ControlToValidate="txtProcessingTime" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>

                  </div><!-- /.form group -->
            </div>

             
 </div>

 <div class="row">
      <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label2" runat="server" Text="Silo No"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtSiloNo" class="form-control"   placeholder="Silo No" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Pls Enter Silo No" ControlToValidate="txtSiloNo" style="font-size:12px;" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>

                  </div><!-- /.form group -->
            </div>

              <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label3" runat="server" Text="Processed Qty "></asp:Label>
                      </div>
                       <asp:TextBox ID="txtProcessQty" class="form-control"   placeholder=" Enter Processed Qty" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Pls Enter Process Quantity" ControlToValidate="txtProcessQty" style="font-size:12px;" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                      <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationExpression= "[0-9]+(\.[0-9][0-9]?)?"
                           ErrorMessage ="Please enter valid number" ControlToValidate="txtProcessQty" ForeColor="Red" style="font-size:12px;" ValidationGroup="Save"/>

                  </div><!-- /.form group -->
            </div>

              <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label4" runat="server" Text="Temperature "></asp:Label>
                      </div>
                       <asp:TextBox ID="txtTemperature" class="form-control"   placeholder="Enter Temperature " runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Pls Enter Temperature" ControlToValidate="txtTemperature" style="font-size:12px;" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                      <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ValidationExpression= "[0-9]+(\.[0-9][0-9]?)?"
                           ErrorMessage ="Please enter valid number" ControlToValidate="txtTemperature" ForeColor="Red" style="font-size:12px;" ValidationGroup="Save"/>
                  </div><!-- /.form group -->
            </div>

              <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label5" runat="server" Text=" Test For Smell"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtOrganolepticTestForSmell" class="form-control"   placeholder="Enter Test For Smell" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Pls Enter Organoleptic Test Smell" ControlToValidate="txtOrganolepticTestForSmell" style="font-size:12px;" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>

                  </div><!-- /.form group -->
            </div>

</div>

 <div class="row">

              <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label6" runat="server" Text=" Test For Taste"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtOrganolepticTestForTaste" class="form-control"   placeholder="Enter Test For Taste" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Pls Enter Organoleptic Test Taste" ControlToValidate="txtOrganolepticTestForTaste" style="font-size:12px;" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>

                  </div><!-- /.form group -->
            </div>

              <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label7" runat="server" Text="Organoleptic Test For Colour "></asp:Label>
                      </div>
                       <asp:TextBox ID="txtOrganolepticTestForColour" class="form-control"   placeholder="Enter Test For Colour" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Pls Enter Organoleptic Test Colour" ControlToValidate="txtOrganolepticTestForColour" style="font-size:12px;" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>

                  </div><!-- /.form group -->
            </div>

              <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label8" runat="server" Text="Acidity "></asp:Label>
                      </div>
                       <asp:TextBox ID="txtAcidity" class="form-control"   placeholder="Enter Acidity " runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="Pls Enter Acidity" ControlToValidate="txtAcidity" style="font-size:12px;" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                      <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ValidationExpression= "[0-9]+(\.[0-9][0-9]?)?"
                           ErrorMessage ="Please enter valid number" ControlToValidate="txtAcidity" ForeColor="Red" style="font-size:12px;" ValidationGroup="Save"/>

                  </div><!-- /.form group -->
            </div>

              <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label9" runat="server" Text="Phosphatase Starting Time"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtPhosphataseStartingTime" class="cal form-control"  type="time" placeholder="Enter Start Time" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ErrorMessage="Pls Enter Phosphatase Start Time" style="font-size:12px;" ControlToValidate="txtPhosphataseStartingTime" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>

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
                       <asp:TextBox ID="txtPhosphataseEndTime" class="cal form-control" type="time"  placeholder="Enter End Time" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="Pls Enter Phosphatase End Time" style="font-size:12px;" ControlToValidate="txtPhosphataseEndTime" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>

                  </div><!-- /.form group -->
            </div>

              <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label19" runat="server" Text="Total Hours"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtPhosphatasetotalhrs" class="form-control"   placeholder="Enter Total hours" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="Pls Enter Phosphatase Total Hours" style="font-size:12px;" ControlToValidate="txtPhosphatasetotalhrs" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>

                  </div><!-- /.form group -->
            </div>


              <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label11" runat="server" Text="MBRT Starting Time "></asp:Label>
                      </div>
                       <asp:TextBox ID="txtMBRTStartTime" class="form-control"   placeholder="Enter start Time" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="Pls Enter MBRT Start Time" style="font-size:12px;" ControlToValidate="txtMBRTStartTime" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>

                  </div><!-- /.form group -->
            </div>

              <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label13" runat="server" Text="MBRT End Time"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtMBRTEndTime" class="form-control"   placeholder="Enter End Time" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage="Pls Enter MBRT End Time" style="font-size:12px;" ControlToValidate="txtMBRTEndTime" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>

                  </div><!-- /.form group -->
            </div>

</div>

 <div class="row">

              <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label14" runat="server" Text="Total hours"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtMBRTTotalHours" class="form-control"   placeholder="Enter Total Hours" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ErrorMessage="Pls Enter MBRT Total Hours" style="font-size:12px;" ControlToValidate="txtMBRTTotalHours" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>

                  </div><!-- /.form group -->
            </div>

              <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label15" runat="server" Text="FAT"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtFAT" class="form-control"   placeholder="Enter FAT" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ErrorMessage="Pls Enter FAT" ControlToValidate="txtFAT" style="font-size:12px;" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                      <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ValidationExpression= "[0-9]+(\.[0-9][0-9]?)?"
                           ErrorMessage ="Please enter valid number" ControlToValidate="txtFAT" ForeColor="Red" style="font-size:12px;" ValidationGroup="Save"/>

                  </div><!-- /.form group -->
            </div>

              <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label16" runat="server" Text="CLR "></asp:Label>
                      </div>
                       <asp:TextBox ID="txtCLR" class="form-control"   placeholder="Enter CLR " runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ErrorMessage="Pls Enter CLR" ControlToValidate="txtCLR" style="font-size:12px;" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                      <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ValidationExpression= "[0-9]+(\.[0-9][0-9]?)?"
                           ErrorMessage ="Please enter valid number" ControlToValidate="txtCLR" ForeColor="Red" style="font-size:12px;" ValidationGroup="Save"/>

                  </div><!-- /.form group -->
            </div>

              <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label17" runat="server" Text="SNF "></asp:Label>
                      </div>
                       <asp:TextBox ID="txtSNF" class="form-control"   placeholder="Enter SNF " runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ErrorMessage="Pls Enter SNF" ControlToValidate="txtSNF" style="font-size:12px;" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                      <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ValidationExpression= "[0-9]+(\.[0-9][0-9]?)?"
                           ErrorMessage ="Please enter valid number" ControlToValidate="txtSNF" ForeColor="Red" style="font-size:12px;" ValidationGroup="Save"/>

                  </div><!-- /.form group -->
            </div>

</div>

 <div class="row">

              <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label18" runat="server" Text="Home Efficiency"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtHomEfficiency" class="form-control"   placeholder="Enter Efficiency " runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ErrorMessage="Pls Enter HomEfficiency" ControlToValidate="txtHomEfficiency" style="font-size:12px;" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>

                  </div><!-- /.form group -->
            </div>

             <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">                    
                        <asp:Label ID="Label21" runat="server" Text="Processing Status "></asp:Label>
                      </div>
                      <asp:DropDownList ID="dpAfterProcessingStatus" class="form-control" DataValueField="StatusId" DataTextField="StatusName"   runat="server" ValidationGroup="Save" > 
                        
                      </asp:DropDownList>                       
                    </div><!-- /.input group -->
                       <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator4" Display="Dynamic" 
                             ValidationGroup="Save" runat="server" ControlToValidate="dpAfterProcessingStatus" ForeColor="Red"
                             ErrorMessage="Pls Select Status" style="font-size:12px;">
                         </asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
               </div>

</div>
                <div class="col-lg-3 pull-right">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      
                    
                      
                        <asp:Button ID="btnAdd" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Add" ValidationGroup="Save" Onclick="btnAdd_Click"/> &nbsp;    
                        <asp:Button ID="btnUpdate" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Update" ValidationGroup="Save" Onclick="btnUpdate_Click"/>  &nbsp        
                        <asp:Button ID="btnRefresh" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Refresh" ValidationGroup="Refresh" Onclick="btnRefresh_Click"/>             
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
                                   
                       
                          
                      </div>



        </ContentTemplate> 
   </asp:UpdatePanel>
    </div><!-- /.box-body -->            
          </div><!-- /.box -->

           <div class="box ">
            <div class="box-header with-border">
              <h3 class="box-title"> QC After Processing Information List </h3>
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
                       <asp:TextBox ID="txtSearchDate" class="form-control" type="date" runat="server" ValidationGroup="Save" ></asp:TextBox>                        
                    </div><!-- /.input group -->
  <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ErrorMessage="Pls Enter Date" style="font-size:12px;" ControlToValidate="txtSearchDate" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
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
                   
                
                       

                <asp:UpdatePanel runat="server" ID="uprouteList" UpdateMode="Conditional" >
                    <ContentTemplate>

                <table id="example1" class="table table-bordered table-striped">
                   

                 
                      <asp:Repeater ID="rpQCAfterProcessingList" runat="server" OnItemCommand="rpQCAfterProcessingList_ItemCommand" >
                
                
               <HeaderTemplate>
                  <thead>
                      <tr>
                                       <%--<th>RMRId</th>--%>
                                        <th>RMR Date</th>
                                        <th>RMR BatchNo</th>
                                       <th>MBRT Start Time</th>
                                       <th>MBRT End Time</th>
                                        <th>Total Hours</th>                                        
                                         <th>Fat</th>
                                         <th>CLR</th>
                                         <th>SNF</th>
                                        <th>Phosphatase Start Time</th>
                                        <th>Phosphatase End Time</th>
                                        <th>Total Hours</th>
                                        <th>Status</th>
                                        <th>Edit</th>

                      </tr>
                    </thead>
                    <tbody>

                   
               </HeaderTemplate>
               <ItemTemplate>
                    <tr>
                            

                                       <%-- <td><%# Eval("RMRId")%></td>   --%>
                                          <td><%# Convert.ToDateTime(Eval("RMRDate")).ToString("dd-MM-yyyy")%></td>  
                                        <td><%# Eval("BatchNo")%></td>  
                                        <td><%# Eval("MBRTStartTime")%></td>     
                                        <td><%# Eval("MBRTEndTime")%></td>
                                        <td><%# Eval("TotalHours")%></td>                                                                            
                                        <td><%# Eval("Fat")%></td>
                                        <td><%# Eval("CLR")%></td>                                       
                                        <td><%# Eval("SNF")%></td>
                                         <td><%# Eval("PhosStartTime")%></td>
                                        <td><%# Eval("PhosEndTime")%></td>
                                        <td><%# Eval("PhosTotalHrs")%></td>
                                         <td><%# Eval("StatusName") %></td>  
                                       
                                          
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
                                        <th>RMR Date</th>
                                        <th>RMR BatchNo</th>
                                       <th>MBRT Start Time</th>
                                       <th>MBRT End Time</th>
                                        <th>Total Hours</th>                                        
                                         <th>Fat</th>
                                         <th>CLR</th>
                                         <th>SNF</th>
                                        <th>Phosphatase Start Time</th>
                                        <th>Phosphatase End Time</th>
                                        <th>Total Hours</th>
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
