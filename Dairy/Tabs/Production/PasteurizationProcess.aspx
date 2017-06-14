<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PasteurizationProcess.aspx.cs" Inherits="Dairy.Tabs.Production.PasteurizationProcess" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
      <link href="../../Theme/plugins/jQueryUI/jquery-ui.css" rel="stylesheet" />
        <script src="../../Theme/plugins/jQuery/jquery-1.10.2.min.js"></script>
        <script src="../../Theme/plugins/jQueryUI/jquery-ui.min.js"></script>
        <style type="text/css">.cntrlbtm {    margin-bottom: 1px;} </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section class="content-header">
          <h1>
        Pasteurization Process      
          </h1> 
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Administration</a></li>
            <li class="active">Pasteurization</li>
          </ol>
        </section >

        <section class="content">
                           <div class="row">
                <asp:UpdatePanel runat="server" ID="pnlError" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="col-md-12">
                            <div class="alert alert-danger alert-dismissable" runat="server" id="divDanger" visible="false">


                                <h4>
                                    <i class="icon fa fa-ban"></i>Alert!</h4>
                                <asp:Label runat="server" ID="lbldanger" Text="Something went worng Pls try Again"></asp:Label>
                            </div>
                            <div class="alert alert-warning alert-dismissable" runat="server" id="divwarning"
                                visible="false">
                                <h4>
                                    <i class="icon fa fa-warning"></i>Warning!</h4>
                                <asp:Label runat="server" ID="lblwarning" Text="Something Went wrong Pls Try Again"></asp:Label>
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
              <h3 class="box-title"><asp:Label ID="lblHeaderTab" runat="server" Text="Pasteurization Process Details"></asp:Label> </h3>
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
                       <asp:TextBox ID="txtBatchNo" class="form-control"  placeholder="RMR Batch No " runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RFVBatchNo" runat="server" ErrorMessage="Pls Enter Batch No" style="font-size:12px;" ControlToValidate="txtBatchNo" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
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
                        <asp:Label ID="Label1" runat="server" Text="Shift"></asp:Label>
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
                          <asp:Label ID="Label2" runat="server" Text="Pasteurization start time"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtPasteurizationstarttime" class="form-control" type="time"  placeholder="Start Time " runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Pls Enter Start Time" style="font-size:12px;" ControlToValidate="txtPasteurizationstarttime" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
                 </div>



    </div>

                  
<div class="row">


               <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label11" runat="server" Text="Heat1 "></asp:Label>
                      </div>
                       <asp:TextBox ID="txtHeatFirst" class="form-control"   placeholder="Enter Heat1  " runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Pls Enter Heat1" ControlToValidate="txtHeatFirst" style="font-size:12px;" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                      <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationExpression= "[0-9]+(\.[0-9][0-9]?)?"
                           ErrorMessage ="Please enter valid number" ControlToValidate="txtHeatFirst" ForeColor="Red" style="font-size:12px;" ValidationGroup="Save"/>
                  </div><!-- /.form group -->
                 </div>




              <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label12" runat="server" Text="Heat2 "></asp:Label>
                      </div>
                       <asp:TextBox ID="txtHeatSecond" class="form-control"   placeholder="Enter Heat2  " runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Pls Enter Heat2" style="font-size:12px;" ControlToValidate="txtHeatSecond" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ValidationExpression= "[0-9]+(\.[0-9][0-9]?)?"
                           ErrorMessage ="Please enter valid number" ControlToValidate="txtHeatSecond" ForeColor="Red" style="font-size:12px;" ValidationGroup="Save"/>
                  </div><!-- /.form group -->
                 </div>

           <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label13" runat="server" Text="Heat3 "></asp:Label>
                      </div>
                       <asp:TextBox ID="txtHeatThird" class="form-control"   placeholder="Enter Heat3  " runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Pls Enter Heat3" style="font-size:12px;" ControlToValidate="txtHeatThird" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ValidationExpression= "[0-9]+(\.[0-9][0-9]?)?"
                           ErrorMessage ="Please enter valid number" ControlToValidate="txtHeatThird" ForeColor="Red" style="font-size:12px;" ValidationGroup="Save"/>
                  </div><!-- /.form group -->
                 </div>

         <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label15" runat="server" Text="Heat4 "></asp:Label>
                      </div>
                       <asp:TextBox ID="txtHeatForth" class="form-control"   placeholder="Enter Heat4  " runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="Pls Enter Heat4" style="font-size:12px;" ControlToValidate="txtHeatForth" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                       <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ValidationExpression= "[0-9]+(\.[0-9][0-9]?)?"
                           ErrorMessage ="Please enter valid number" ControlToValidate="txtHeatForth" ForeColor="Red" style="font-size:12px;" ValidationGroup="Save"/>
                  </div><!-- /.form group -->
                 </div>


    </div>



                  
<div class="row">

           <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label4" runat="server" Text="Cool1 "></asp:Label>
                      </div>
                       <asp:TextBox ID="txtCool1" class="form-control"   placeholder="Enter Cool1  " runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
<%--                    <asp:RequiredFieldValidator ID="" runat="server" ErrorMessage="" style="font-size:12px;"ControlToValidate="" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>--%>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Pls Enter Cool1" ControlToValidate="txtCool1" style="font-size:12px;" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>

                                       <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ValidationExpression= "[0-9]+(\.[0-9][0-9]?)?"
                           ErrorMessage ="Please enter valid number" ControlToValidate="txtCool1" ForeColor="Red" style="font-size:12px;" ValidationGroup="Save"/>
                  </div><!-- /.form group -->
                 </div>


             <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label5" runat="server" Text="Cool2 "></asp:Label>
                      </div>
                       <asp:TextBox ID="txtCool2" class="form-control"   placeholder="Enter Cool2  " runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Pls Enter Cool2" ControlToValidate="txtCool2" style="font-size:12px;" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                      <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ValidationExpression= "[0-9]+(\.[0-9][0-9]?)?"
                           ErrorMessage ="Please enter valid number" ControlToValidate="txtCool2" ForeColor="Red" style="font-size:12px;" ValidationGroup="Save"/>
                  </div><!-- /.form group -->
                 </div>




           <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label6" runat="server" Text="Cool3 "></asp:Label>
                      </div>
                       <asp:TextBox ID="txtCool3" class="form-control"   placeholder="Enter Cool3  " runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="Pls Enter Cool3" style="font-size:12px;" ControlToValidate="txtCool3" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                     <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ValidationExpression= "[0-9]+(\.[0-9][0-9]?)?"
                           ErrorMessage ="Please enter valid number" ControlToValidate="txtCool3" ForeColor="Red" style="font-size:12px;" ValidationGroup="Save"/>
                  </div><!-- /.form group -->
                 </div>

          <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label7" runat="server" Text="Cool4 "></asp:Label>
                      </div>
                       <asp:TextBox ID="txtCool4" class="form-control"   placeholder="Enter Cool4  " runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="Pls Enter Cool4" style="font-size:12px;" ControlToValidate="txtCool4" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                   <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ValidationExpression= "[0-9]+(\.[0-9][0-9]?)?"
                           ErrorMessage ="Please enter valid number" ControlToValidate="txtCool4" ForeColor="Red" style="font-size:12px;" ValidationGroup="Save"/>
                  </div><!-- /.form group -->
                 </div>


    </div>

                  
<div class="row">


               <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label16" runat="server" Text="Heat5 "></asp:Label>
                      </div>
                       <asp:TextBox ID="txtHeatFive" class="form-control"   placeholder="Enter Heat5  " runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="Pls Enter Heat5" style="font-size:12px;" ControlToValidate="txtHeatFive" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                       <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server" ValidationExpression= "[0-9]+(\.[0-9][0-9]?)?"
                           ErrorMessage ="Please enter valid number" ControlToValidate="txtHeatFive" ForeColor="Red" style="font-size:12px;" ValidationGroup="Save"/>
                  </div><!-- /.form group -->
                 </div>

               <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label3" runat="server" Text="IBT Temperature "></asp:Label>
                      </div>
                       <asp:TextBox ID="txtIBTTemperature" class="form-control"   placeholder="degree celsious  " runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Pls Enter IBT Temp" style="font-size:12px;" ControlToValidate="txtIBTTemperature" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                       <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ValidationExpression= "[0-9]+(\.[0-9][0-9]?)?"
                           ErrorMessage ="Please enter valid number" ControlToValidate="txtIBTTemperature" ForeColor="Red" style="font-size:12px;" ValidationGroup="Save"/>
                  </div><!-- /.form group -->
                 </div>




              <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label10" runat="server" Text="Milk closing time"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtMilkClosingTime" class="form-control" type="time"  placeholder="Enter Closing Time" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ErrorMessage="Pls Enter Milk Closing Time" style="font-size:12px;" ControlToValidate="txtMilkClosingTime" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
            </div>

      <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label9" runat="server" Text="Done By"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtDoneBy" class="form-control"   placeholder="Done By" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ErrorMessage="Pls Enter Done By" style="font-size:12px;" ControlToValidate="txtDoneBy" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
            </div>


    </div>

        <div class ="row">
          <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label8" runat="server" Text="Cool5 "></asp:Label>
                      </div>
                       <asp:TextBox ID="txtCool5" class="form-control"   placeholder="Enter Cool5  " runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage="Pls Enter Cool5" style="font-size:12px;" ControlToValidate="txtCool5" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                       <asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server" ValidationExpression= "[0-9]+(\.[0-9][0-9]?)?"
                           ErrorMessage ="Please enter valid number" ControlToValidate="txtCool5" ForeColor="Red" style="font-size:12px;" ValidationGroup="Save"/>
                  </div><!-- /.form group -->
                 </div>
               
                 
             <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">                    
                        <asp:Label ID="Label17" runat="server" Text="Pasteurization Process "></asp:Label>
                      </div>
                      <asp:DropDownList ID="dpPastProcessDone" class="form-control" DataValueField="StatusId" DataTextField="StatusName"   runat="server" ValidationGroup="Save" > 
                        
                      </asp:DropDownList>                       
                    </div><!-- /.input group -->
                       <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator4" Display="Dynamic" 
                             ValidationGroup="Save" runat="server" ControlToValidate="dpPastProcessDone" ForeColor="Red"
                             ErrorMessage="Pls Select Process Done Or Not" style="font-size:12px;">
                         </asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
               </div>
     
                         

                    <div class="col-lg-3 pull-right">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">                   
                       
                         <asp:Button ID="btnAdd" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Add" ValidationGroup="Save" OnClick="btnAdd_Click"  />  &nbsp  
                        <asp:Button ID="btnUpdate" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Update" ValidationGroup="Save" OnClick="btnUpdate_Click"/>  &nbsp                        
                        <asp:Button ID="btnRefresh" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Refresh" ValidationGroup="Refresh" OnClick="btnRefresh_Click" />             
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->

                              </div>



        </div>
            </ContentTemplate> 
   </asp:UpdatePanel>
                  </div><!-- /.box-body -->            
          </div><!-- /.box -->  

          <div class="box ">
            <div class="box-header with-border">
              <h3 class="box-title"> Pasteurization Process List </h3>
              <div class="box-tools pull-right" style="right: 4px; top: 4px">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-minus"></i></button>
                
              </div>
            </div>
                                      <div class="row">
                    <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">

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
                   

                 
                      <asp:Repeater ID="rpPastProcessList" runat="server" OnItemCommand="rpPastProcessList_ItemCommand">
                
                
               <HeaderTemplate>
                  <thead>
                      <tr>

                                     
                                      <%-- <th>RMRId</th>--%>
                                        <th>StandardDate</th> 
                                       <th>RMR Batch No</th>
                                                                              
                                        <th>Shift Name</th> 
                                       <%-- <th>Pasteurization Process</th>  --%>  
                                        <th>Status</th>                                  
                                        <th>Edit</th>


                      </tr>
                    </thead>
                    <tbody>

                   
               </HeaderTemplate>
               <ItemTemplate>
                    <tr>

                                                            
                                        <%--<td><%# Eval("RMRId")%></td>--%>  
                                     <td><%# Convert.ToDateTime(Eval("StandardDate")).ToString("dd-MM-yyyy")%></td>    
                                        <td><%# Eval("BatchNo")%></td>                       
                                        <td><%# Eval("ShiftName")%></td>
                                        <td><%# Eval("StatusName")%></td>
                                   <asp:HiddenField id="hfStdId" runat="server" value='<%#Eval("StdId") %>' />   
                                    
                                        
                                          
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
                                        <th>StandardDate</th> 
                                       <th>RMR Batch No</th>
                                                                              
                                        <th>Shift Name</th> 
                                       <%-- <th>Pasteurization Process</th>  --%>  
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
