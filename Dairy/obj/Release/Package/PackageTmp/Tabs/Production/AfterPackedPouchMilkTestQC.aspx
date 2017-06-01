<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AfterPackedPouchMilkTestQC.aspx.cs" Inherits="Dairy.Tabs.Production.AfterPackedPouchMilkTestQC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
     <link href="../../Theme/plugins/jQueryUI/jquery-ui.css" rel="stylesheet" />
        <script src="../../Theme/plugins/jQuery/jquery-1.10.2.min.js"></script>
        <script src="../../Theme/plugins/jQueryUI/jquery-ui.min.js"></script>
        <style type="text/css">.cntrlbtm {    margin-bottom: 1px;} </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section class="content-header">
        <h1>
            After Packed Milk QC     
          </h1> 
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Administration</a></li>
            <li class="active">AfterPackedMilkQC</li>
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
              <h3 class="box-title"><asp:Label ID="lblHeaderTab" runat="server" Text="After Packed Milk QC Details"></asp:Label> </h3>
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
                          <asp:Label ID="Label14" runat="server" Text="Batch Code"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtBatchCode" class="form-control"   placeholder="Batch Code " runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ErrorMessage="Please Enter Batch Code" ControlToValidate="txtBatchCode" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
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
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label2" runat="server" Text="Source"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtSource" class="form-control"   placeholder="Enter Source" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Please Enter Source" ControlToValidate="txtSource" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
            </div>


                  
                          <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label3" runat="server" Text="Weight "></asp:Label>
                      </div>
                       <asp:TextBox ID="txtWeight" class="form-control"   placeholder="Enter Weight  " runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Pls Enter Weight"  ControlToValidate="txtWeight" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
<%--                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ValidationExpression= "[0-9]+(\.[0-9][0-9]?)?"
                           ErrorMessage ="Pls enter valid number"  ControlToValidate="txtWeight" ForeColor="Red" ValidationGroup="Save"/>               --%>
                  </div><!-- /.form group -->
            </div>
             
                   <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label5" runat="server" Text="Quantity "></asp:Label>
                      </div>
                       <asp:TextBox ID="txtQuantity" class="form-control"   placeholder="Enter Quantity " runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Pls Enter Quantity"  ControlToValidate="txtQuantity" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationExpression= "[0-9]+(\.[0-9][0-9]?)?"
                           ErrorMessage ="Pls enter valid number"  ControlToValidate="txtQuantity" ForeColor="Red" ValidationGroup="Save"/>
                  </div><!-- /.form group -->
            </div>

                   <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label6" runat="server" Text="Temperature "></asp:Label>
                      </div>
                       <asp:TextBox ID="txtTemperature" class="form-control"   placeholder="Enter Temperature" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Pls Enter Temperature"  ControlToValidate="txtTemperature" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ValidationExpression= "[0-9]+(\.[0-9][0-9]?)?"
                           ErrorMessage ="Pls enter valid number"  ControlToValidate="txtTemperature" ForeColor="Red" ValidationGroup="Save"/> 
                  </div><!-- /.form group -->
            </div>

                  
        <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group ">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label7" runat="server" Text="FAT "></asp:Label>
                      </div>
                       <asp:TextBox ID="txtFAT" class="form-control"   placeholder=" Enter FAT" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Pls Enter FAT"  ControlToValidate="txtFAT" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ValidationExpression= "[0-9]+(\.[0-9][0-9]?)?"
                           ErrorMessage ="Pls enter valid number"  ControlToValidate="txtFAT" ForeColor="Red" ValidationGroup="Save"/>          
                  </div><!-- /.form group -->
            </div>


                   <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label8" runat="server" Text="CLR "></asp:Label>
                      </div>
                       <asp:TextBox ID="txtCLR" class="form-control"   placeholder="Enter CLR " runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Pls Enter CLR"  ControlToValidate="txtCLR" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ValidationExpression= "[0-9]+(\.[0-9][0-9]?)?"
                           ErrorMessage ="Pls enter valid number"  ControlToValidate="txtCLR" ForeColor="Red" ValidationGroup="Save"/>                
                  </div><!-- /.form group -->
            </div>

                  
                                            <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label9" runat="server" Text="SNF"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtSNF" class="form-control"   placeholder="Enter SNF" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Pls Enter SNF"  ControlToValidate="txtSNF" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ValidationExpression= "[0-9]+(\.[0-9][0-9]?)?"
                         ErrorMessage ="Pls enter valid number"  ControlToValidate="txtSNF" ForeColor="Red" ValidationGroup="Save"/>                
                  </div><!-- /.form group -->
            </div>

                  
                          <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label4" runat="server" Text="Keep Qlty Start Time"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtQualityStartTime" class="form-control" type="time"        placeholder="Quality Start Time" ToolTip="Quality Start Time" runat="server" ></asp:TextBox>        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Please Enter Quality Start Time" ControlToValidate="txtQualityStartTime" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
            </div>
                    
                        <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label10" runat="server" Text="1Hour "></asp:Label>
                      </div>
                       <asp:TextBox ID="txt1hr" class="form-control" type="time"        placeholder="Hour1" ToolTip="Enter Hour" runat="server" ></asp:TextBox>        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Please Enter Hour" ControlToValidate="txt1hr" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
            </div>

                  
                          <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label11" runat="server" Text="2Hours "></asp:Label>
                      </div>
                       <asp:TextBox ID="txt2hr" class="form-control" type="time"        placeholder="Hours2" ToolTip="Enter Hour" runat="server" ></asp:TextBox>        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="Please Enter Hours" ControlToValidate="txt2hr" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
            </div>

                    <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label12" runat="server" Text="3Hours"></asp:Label>
                      </div>
                       <asp:TextBox ID="txt3hr" class="form-control" type="time"        placeholder="Hours3" ToolTip="Enter Hour" runat="server" ></asp:TextBox>        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="Please Enter Hours" ControlToValidate="txt3hr" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
            </div>


                          <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label13" runat="server" Text="4Hours"></asp:Label>
                      </div>
                       <asp:TextBox ID="txt4hr" class="form-control" type="time"        placeholder="Hous4" ToolTip="Enter Hour" runat="server" ></asp:TextBox>        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="Please Enter Hours" ControlToValidate="txt4hr" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
            </div>


                          <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label15" runat="server" Text="5Hours"></asp:Label>
                      </div>
                       <asp:TextBox ID="txt5hr" class="form-control" type="time"        placeholder="Hours5" ToolTip="Enter Hour" runat="server" ></asp:TextBox>        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="Please Enter Hours" ControlToValidate="txt5hr" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
            </div>


                          <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label16" runat="server" Text="6Hours"></asp:Label>
                      </div>
                       <asp:TextBox ID="txt6hr" class="form-control" type="time"        placeholder="Hours6" ToolTip="Enter Hour" runat="server" ></asp:TextBox>        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage="Please Enter Hours" ControlToValidate="txt6hr" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
            </div>


                          <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label17" runat="server" Text="7Hours"></asp:Label>
                      </div>
                       <asp:TextBox ID="txt7hr" class="form-control" type="time"        placeholder="Hours7" ToolTip="Enter Hour" runat="server" ></asp:TextBox>        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ErrorMessage="Please Enter Hours" ControlToValidate="txt7hr" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
            </div>


                          <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label18" runat="server" Text="8Hours"></asp:Label>
                      </div>
                       <asp:TextBox ID="txt8hr" class="form-control" type="time"        placeholder="Hours8" ToolTip="Enter Hour" runat="server" ></asp:TextBox>        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ErrorMessage="Please Enter Hours" ControlToValidate="txt8hr" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
            </div>

   
                          <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label19" runat="server" Text="Total Hours "></asp:Label>
                      </div>
                       <asp:TextBox ID="txtTotalHours" class="form-control"         placeholder="TotalHours" ToolTip="Enter Total Hour" runat="server" ></asp:TextBox>        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ErrorMessage="Please Enter Total Hours" ControlToValidate="txtTotalHours" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
            </div>

        <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group ">
                      <div class="input-group-addon">                    
                        <asp:Label ID="Label20" runat="server" Text="Packing Detail"></asp:Label>
                      </div>
                      <asp:DropDownList ID="dpPouchMilkTestStatus" class="form-control" DataValueField="StatusId" DataTextField="StatusName"   runat="server" ValidationGroup="Save" > 
                        
                      </asp:DropDownList>                       
                    </div><!-- /.input group -->
                       <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator19" Display="Dynamic" 
                             ValidationGroup="Save" runat="server" ControlToValidate="dpPouchMilkTestStatus" ForeColor="Red"
                             ErrorMessage="Pls Select Pouch Milk Detail" style="font-size:12px;">
                         </asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
               </div>

                <div class="col-lg-3 pull-right">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                        <asp:Button ID="btnAdd" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Add" ValidationGroup="Save" OnClick="btnAdd_Click"/> &nbsp;    
                        <asp:Button ID="btnUpdate" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Update" ValidationGroup="Save" OnClick="btnUpdate_Click" /> &nbsp;    
                        <asp:Button ID="btnRefresh" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Refresh" ValidationGroup="Refresh" OnClick="btnRefresh_Click" /> &nbsp;                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->                                            
  
                   </div>
               </ContentTemplate> 
             </asp:UpdatePanel>
           </div><!-- /.box-body -->            
     </div><!-- /.box -->

                   <div class="box ">
            <div class="box-header with-border">
              <h3 class="box-title"> Milk QC List </h3>
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
                   

                 
                      <asp:Repeater ID="rpAfterPackedMilkQC" runat="server" OnItemCommand="rpAfterPackedMilkQC_ItemCommand1">
                
                
               <HeaderTemplate>
                  <thead>
                      <tr>
                                    <%-- <th>RMRId</th>      --%>  
                                        <th>Date</th>                                    
                                        <th>RMR Batch No</th> 
                                        <th>Batch Code</th>   
                                       
                                        <th>Cold Room No</th>   
                                        <th>Status</th>                     
                                        <th>Edit</th>


                      </tr>
                    </thead>
                    <tbody>

                   
               </HeaderTemplate>
               <ItemTemplate>
                    <tr>
                            
                                       <%-- <td><%# Eval("RMRId")%></td>  --%>
                          <td><%# Convert.ToDateTime(Eval("PackedDate")).ToString("dd-MM-yyyy")%></td> 
                                      <td><%# Eval("BatchNo")%></td>      
                                        <td><%# Eval("BatchCode")%></td>   
                                                                       
                                      <td><%# Eval("ColdRoomNo")%></td>  
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
                                      <%-- <th>RMRId</th>      --%>  
                                        <th>Date</th>                                    
                                        <th>RMR Batch No</th> 
                                        <th>Batch Code</th>   
                                       
                                        <th>Cold Room No</th>   
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
