<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RMRData.aspx.cs" Inherits="Dairy.Tabs.Production.RMRData" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="../../Theme/plugins/jQueryUI/jquery-ui.css" rel="stylesheet" />
    <script type="text/javascript" src="Scripts/jquery-1.4.1.min.js"></script>
    <script src="../../Theme/plugins/jQuery/jquery-1.10.2.min.js"></script>
    <script src="../../Theme/plugins/jQueryUI/jquery-ui.min.js"></script>
    <style type="text/css">.cntrlbtm {    margin-bottom: 1px;} </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <script type="text/javascript">
         $(document).ready(function () {
             $(".cal").change(function () {
                 debugger;
                
                 //srtdate = $("#MainContent_txtDate").val();
                 //endate = $("#MainContent_txtDate").val();
                 //var startDate = new Date(srtdate);
                 //var endDate = new Date(endate);
                 mbrtstart = $("#MainContent_txtMBRTStartTime").val();
                 mbrtend = $("#MainContent_txtMBRTEndTime").val();
                 time1 = mbrtstart.split(':');
                 time2 = mbrtend.split(':');
                 var hours1 = $.trim(time1[0]) + " hrs";
                 var hours2 = $.trim(time2[0]) + " hrs";

                 var mins1 = $.trim(time1[1]) + " min";                       
                 var mins2 = $.trim(time2[1]) + " min";

                 var hours = parseInt(hours2) - parseInt(hours1), mins = 0;

                 if (hours < 0) hours = 24 + hours;
                 if (mins2 >= mins1) {
                     mins = parseInt(mins2) - parseInt(mins1);
                 }
                 else if (mins2 < mins1)
                 {
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
                 $("#MainContent_txtTotalHours").val(diff);
                               
             });
            
         });
    </script>
    <section class="content-header">
          <h1>
           RMR Data 
            <small>Details</small>    
          </h1> 
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Administration</a></li>
            <li class="active">RMR</li>
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
                   <div class="box">

            <div class="box-header with-border">
              <h3 class="box-title"><asp:Label ID="lblHeaderTab" runat="server" Text="ADD RMReceive" ></asp:Label> </h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-minus"></i></button>
                
              </div>
            </div>
            <div class="box-body">
               
              
             <asp:UpdatePanel runat="server" ID="upMain" UpdateMode="Conditional">
              <ContentTemplate>     
                  
<div class ="row">
     <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="lblDate" runat="server" Text="Date"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtDate" class="form-control" type="date" runat="server" ValidationGroup="Save" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                       <asp:RequiredFieldValidator ID="RFVDate" runat="server" ControlToValidate="txtDate"
                       ErrorMessage="Enter Date is required" ValidationGroup="Save" ForeColor="Red" ></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
                                        
                          
                      </div>
               <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <%-- <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label3" runat="server" Text="RMR Batch No"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtBatchNo" class="form-control"   placeholder="RMR Batch No " runat="server" ValidationGroup="Save" OnTextChanged="txtBatchNo_TextChanged" AutoPostBack="true" ></asp:TextBox>                        
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
                    <%--   <i class="fa fa-road"></i><span style="color:red">&nbsp;*</span>--%>
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
            
                         </div>

             <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="lblMilkType" runat="server" Text="Type Of Milk"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtMilkType" class="form-control"   placeholder="Enter Milk Type" runat="server" ReadOnly="true"></asp:TextBox>                        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator  ID="RFVMilktype" Display="Dynamic" 
                                        ValidationGroup="Save" runat="server" ControlToValidate="txtMilkType" ForeColor="Red"
                                        ErrorMessage="Pls Enter Milk Type" style="font-size:12px;">
                      </asp:RequiredFieldValidator>
                      <asp:RegularExpressionValidator ID="RFVMilktype1" runat="server" ControlToValidate="txtMilkType"
    ValidationExpression="[a-zA-Z ]*$" ErrorMessage="Pls Enter characters Only." ForeColor="Red" style="font-size:12px;"/>
                  </div><!-- /.form group -->
                 </div>



    </div>

<div class="row">
              <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="lblTankerNo" runat="server" Text="Tanker No"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtTankerNo" class="form-control"   placeholder="Tanker No " runat="server"></asp:TextBox>                        
                    </div><!-- /.input group -->
                       <asp:RequiredFieldValidator  ID="RequiredFieldValidator2" Display="Dynamic" 
                                        ValidationGroup="Save" runat="server" ControlToValidate="txtTankerNo" ForeColor="Red"
                                        ErrorMessage="Pls Enter Tanker Number" style="font-size:12px;">
                      </asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
                 </div>
      
               <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="lblTankerReceipt" runat="server" Text="Tanker Receipt No" ></asp:Label>
                      </div>
                       <asp:TextBox ID="txtTankerReceipitNo" class="form-control"   placeholder="Tanker Milk Receipt No " runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                      <asp:RequiredFieldValidator  ID="RequiredFieldValidator1" Display="Dynamic" 
                                        ValidationGroup="Save" runat="server" ControlToValidate="txtTankerReceipitNo" ForeColor="Red"
                                        ErrorMessage="Pls Enter Tanker Receipit No" style="font-size:12px;">
                      </asp:RequiredFieldValidator>

                  </div><!-- /.form group -->
                 </div>


                <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="lblQty" runat="server" Text="Quantity"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtQty" class="form-control"   placeholder="Enter Quantity in Liters" runat="server" Type="number" min="0" step="any"></asp:TextBox>                        
                    </div><!-- /.input group -->
                       <asp:RequiredFieldValidator  ID="RFVQty" Display="Dynamic" 
                                        ValidationGroup="Save" runat="server" ControlToValidate="txtQty" ForeColor="Red"
                                        ErrorMessage="Pls Enter Quantity" style="font-size:12px;">
                      </asp:RequiredFieldValidator>
                          <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ValidationExpression= "[0-9]+(\.[0-9][0-9]?)?"
                           ErrorMessage ="Please enter valid number" ControlToValidate="txtQty" ForeColor="Red" style="font-size:12px;" ValidationGroup="Save"/>
                  </div><!-- /.form group -->
                 </div>
                     
              <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <%--<i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label5" runat="server" Text="MBRT Start Time"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtMBRTStartTime" class="cal form-control" type="time" placeholder=" MBRT Start Time" ToolTip="MBRT Start Time" runat="server" ReadOnly="true"></asp:TextBox>        
                    </div><!-- /.input group -->
                        <asp:RequiredFieldValidator ID="RFVMBRTStart" runat="server" ErrorMessage="Please MBRT Start Time" style="font-size:12px;" ControlToValidate="txtMBRTStartTime" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 


    </div>

                  <div class ="row">
               <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <%--<i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label6" runat="server" Text="MBRT End Time"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtMBRTEndTime" class="cal form-control" type="time"        placeholder=" MBRT End Time" ToolTip="MBRT End Time" runat="server" ReadOnly="true"></asp:TextBox>        
                    </div><!-- /.input group -->
                        <asp:RequiredFieldValidator ID="RFVMBRTEnd" runat="server" ErrorMessage="Please MBRT End Time" style="font-size:12px;" ControlToValidate="txtMBRTEndTime" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 


               

                <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <%--<i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                         <asp:Label ID="Label2" runat="server" Text="Total Hours"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtTotalHours" class="form-control"  placeholder=" Enter Total Hours" ToolTip="Enter Total Hours" runat="server" ReadOnly="true" ></asp:TextBox>        
                    </div><!-- /.input group -->
                        <asp:RequiredFieldValidator ID="RFVTotalHrs" runat="server" ErrorMessage="Please Enter Total Hours" style="font-size:12px;" ControlToValidate="txtTotalHours" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                         <%-- <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationExpression="((\d+)+(\.\d+))$"
                                ErrorMessage ="Please enter valid decimal number" ControlToValidate="txtTotalHours" ForeColor="Red" style="font-size:12px;" ValidationGroup="Save"/>--%>
                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 


              <div ID="hideQCStatus" class="col-lg-3" runat="server">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                      <i class="fa fa-road"></i><span style="color:red">&nbsp;*</span>--%>
                        <asp:Label ID="lblQC" runat="server" Text="QC Status"></asp:Label>

                      </div>
                      <asp:DropDownList ID="dpfinishQC" class="form-control" DataValueField="QCId" DataTextField="Name"   runat="server" required="true" > 
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                      
                  </div><!-- /.form group -->
                         </div>
                 

                <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
                     <%-- <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label4" runat="server" Text="QC Status"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtRMRQCStatus" class="form-control" runat="server" Readonly="true"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
                 </div>
     


        </div>    
  

              <div class="col-lg-3 pull-right">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      
                    
                      
                        <asp:Button ID="btnAddProductionInfo" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Add" ValidationGroup="Save" onclick="btnAddProductionInfo_Click" /> &nbsp;    
                        <asp:Button ID="btnUpdateProductindetail" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Update" ValidationGroup="Save"  onclick="btnUpdateProductindetail_Click"/>  &nbsp        
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
              <h3 class="box-title"> RMR Data Information List </h3>
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
                   

                 
                      <asp:Repeater ID="rpRMRList" runat="server" OnItemCommand="rpRMRList_ItemCommand">
                
                
               <HeaderTemplate>
                  <thead>
                      <tr>
                                        <%--<th>RMRId</th>--%>
                                         <th>Date</th>
                                        <th>RMR Batch No</th>
                                        
                                        <th>Shift</th>  
                                         <th>Tanker No</th>                                    
                                        <th>Tanker Receipt No</th>                                      
                                        <th>Type Of Milk</th>
                                        <th>Qty</th>
                                        <th>QC Status</th>
                                        <th>MBRT Start Time</th>
                                        <th>MBRT End Time</th>
                                        <th>Total Hours</th>
                                        <th>Edit</th>

                      </tr>
                    </thead>
                    <tbody>

                   
               </HeaderTemplate>
               <ItemTemplate>
                    <tr>
                            

                                        <%--<td><%# Eval("RMRId")%></td> --%>
                         <td><%# Convert.ToDateTime(Eval("RMRDate")).ToString("dd-MM-yyyy")%></td> 
                                        <td><%# Eval("BatchNo")%></td> 
                                           
                                        <td><%# Eval("ShiftName")%></td>
                                         <td><%# Eval("TankerNo")%></td>                                          
                                        <td style="text-align:center" ><%# Eval("TankMilkReciptNo")%></td>
                                       
                                        <td><%# Eval("TypeOfMilk")%></td>
                                        <td><%# Eval("Qty")%></td>
                                        
                                         <td><%# Eval("Status")%></td>
                                        <td><%# Eval("MBRTStartTime")%></td>
                                        <td><%# Eval("MBRTEndTime")%></td>
                                         <td><%# Eval("TotalHours")%></td>
                                          
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
                                         <th>Date</th>
                                        <th>RMR Batch No</th>
                                        
                                        <th>Shift</th>  
                                         <th>Tanker No</th>                                    
                                        <th>Tanker Receipt No</th>                                      
                                        <th>Type Of Milk</th>
                                        <th>Qty</th>
                                        <th>QC Status</th>
                                        <th>MBRT Start Time</th>
                                        <th>MBRT End Time</th>
                                        <th>Total Hours</th>
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
