<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewIndentMaterials.aspx.cs" Inherits="Dairy.Tabs.Purchase.ViewIndentMaterials" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
     <script type="text/javascript" src="../../Theme/bootstrap/js/bootstrap.min.js"></script>
    <link href="../../Theme/bootstrap/css/bootstrap-select.min.css" rel="stylesheet" />
    <script type="text/javascript" src="../../Theme/bootstrap/js/bootstrap-select.min.js"></script>

    <%--<script type="text/javascript" src="../../Theme/bootstrap/js/bootstrap.min.js"></script>--%>
    <style type="text/css">
        .dispnone {display:none;}

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
       <!-- Content Header (Page header) -->
        <section class="content-header">
          <h1>
            View Indent Material
            <small>Purchase</small>
          </h1>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> View Indent</a></li>
            <li class="active">Indent</li>
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
                                <asp:Label runat="server" ID="lblSuccess" Text="Indent Placed Successfully"></asp:Label>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>

        <div class="box ">
               <asp:UpdatePanel runat="server" ID="upList" UpdateMode="Conditional">
                      <ContentTemplate>
            <div class="box-header with-border">
               <h4> <asp:Label ID="lblBoxHeader" runat="server"></asp:Label></h4>
            </div>
            <div class="box-body">
                    <div class="col-lg-4">
                 <div class="form-group">
                   <div class="input-group">
                     <div class="input-group-addon">
                      <asp:Label Text="Indent Date" runat="server"></asp:Label>
                     </div>
                      <asp:TextBox ID="txtIndDate" class="form-control" type="date"  placeholder="Date" runat="server" ></asp:TextBox>                        
                   </div><!-- /.input group -->

                 </div><!-- /.form group -->

                     
                       
                          
                     </div> 

                   <div class="col-lg-4 ">
                  <div class="form-group">
                    <div class="input-group">
                      <asp:Button ID="btnSearch" class="btn btn-primary" runat="server" CommandName="MoveNext"  OnClick="btnSearch_Click" Text="Search"  />                 
                     </div><!-- /.input group -->
                    </div><!-- /.form group -->
                    </div>  

                
                           <asp:Panel runat="server" ID="pnlRequestList" Visible="true">

                                <div class="col-md-12" runat="server" id="divTable">
                          <table id="example1" class="table table-bordered table-striped">
          <asp:Repeater ID="rpRequestList" runat="server" OnItemCommand="rpRequestList_ItemCommand" >
                
               <HeaderTemplate>
                  <thead>
                      <tr>
                         
                            <th>Sr.No</th>
                            <th>IndentCode</th>
                            <th>Indent Date</th>
                            <th>Time</th>
                          <th>Request Date</th>
                            <th>Indent By</th>
                            <th>Action</th>                          
                      </tr>
                    </thead>
                    <tbody>

                   
               </HeaderTemplate>
               <ItemTemplate>
                    <tr>
                                 
                                <td><%# Eval("srno")%></td>
                                <td>IN0<%# Eval("IndentId")%></td>                       
                                <td><%# Eval("IndentDate")%></td>
                               <td><%# Eval("IndentTime")%></td>
                        <td><%# Eval("TillDate")%></td>
                              <%--  <td><%# Eval("VendorCode") + " " + Eval("VendorName")%></td>--%>
                                  <td><%# Eval("Name")%></td>                  
                               <%--  <td><%# Eval("MDApproval")%></td> --%>
                         <td align="left">   <asp:LinkButton ID="lbView" AlternateText="View" ForeColor="Gray" OnItemCommand="lbView_ItemCommand" 
                                                                    ToolTip="View" runat="server" CommandArgument='<%#Eval("IndentId") %>'
                                                                    CommandName="View"><i class="fa fa-external-link"></i></asp:LinkButton>
</td>
                    </tr>
               </ItemTemplate>
                    <FooterTemplate>

                         </tbody>

                    <tfoot>
                      <tr>
                           <th>Sr.No</th>
                            <th>IndentCode</th>
                            <th>Indent Date</th>
                            <th>Time</th>
                          <th>Request Date</th>
                            <th>Indent By</th>
                            <th>Action</th>   
                      </tr>
                    </tfoot>

                    </FooterTemplate>
                                             
           </asp:Repeater>
                
           </table>
           <asp:HiddenField ID="hfIndentId" runat="server" />
       </div> 
                           </asp:Panel>
                      </ContentTemplate>   
                 </asp:UpdatePanel> 
            </div>

      
         <asp:HiddenField runat="server" ID="hfId" />

                <asp:UpdatePanel ID="upModal" runat="server" UpdateMode="Conditional" >  
              <ContentTemplate>         
                      <!-- Modal -->
        <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" data-backdrop="false">
  <div class="modal-dialog" role="document" style="width:75%">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title" id="myModalLabel">Indent Details</h4>
      </div>
      <div class="modal-body">
          <div class="box-body">
              <div class="col-lg-4">
                  <div class="form-group frmgrp" >
                    <div class="input-group">
                      <div class="input-group-addon">
                        <asp:Label runat="server" Text="Indent Code"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtCode" class="form-control" ToolTip="Indent Code"   runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCode"
        ErrorMessage="Indent Code Required" ValidationGroup="Save" ForeColor="Red"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
    
                      </div>        <!-- -->

                  <div class="col-lg-4">
                  <div class="form-group frmgrp" >
                    <div class="input-group">
                      <div class="input-group-addon">
                        <asp:Label runat="server" Text="Indent Date"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtIndDateModal" class="form-control" type="date" ToolTip="Date"   runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtIndDateModal"
        ErrorMessage="Date is Required" ValidationGroup="Save" ForeColor="Red"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
    
                      </div>        <!-- -->

        <div class="col-lg-4">
                  <div class="form-group frmgrp" >
                    <div class="input-group">
                      <div class="input-group-addon">
                        <asp:Label runat="server" Text="Indent Time"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtIndentTime" class="form-control" ToolTip="Indent Time"   runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtIndentTime"
        ErrorMessage="Indent Time Required" ValidationGroup="Save" ForeColor="Red"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
    
                      </div>        <!-- -->

        <div class="col-lg-4">
                  <div class="form-group frmgrp" >
                    <div class="input-group">
                      <div class="input-group-addon">
                        <asp:Label runat="server" Text="Request Date"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtReqDate" class="form-control" type="date" ToolTip="Date"   runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtReqDate"
        ErrorMessage="Date is Required" ValidationGroup="Save" ForeColor="Red"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
    
                      </div>        <!-- -->

              <div class="col-lg-4">
                  <div class="form-group frmgrp" >
                    <div class="input-group">
                      <div class="input-group-addon">
                        <asp:Label runat="server" Text="Indent By"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtIndBy" class="form-control" ToolTip="IndentBy"   runat="server" readonly></asp:TextBox>                        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtIndBy"
        ErrorMessage="IndentBy is  Required" ValidationGroup="Save" ForeColor="Red"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
    
                      </div>        <!-- -->

         <%--     <div class="row">
                  
                    <div class="col-lg-4 ">
                  <div class="form-group">
                    <div class="input-group">
                      <asp:Button ID="btnPrint" class="btn btn-primary" runat="server" CommandName="MoveNext"  OnClientClick="PrintPanel()" Text="Print"  />                 
                     </div><!-- /.input group -->
                    </div><!-- /.form group -->
                    </div>  
              </div>--%>

              
          <asp:Panel runat="server" ID="pnlRequestDetails" >
                        <asp:Literal runat="server" ID="RequestDetails"></asp:Literal>
              </asp:Panel>
              
              </div>

      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
       
          <asp:Button ID="btnSubmit" class="btn btn-primary" runat="server" ValidationGroup="Save"   Text="Save" UseSubmitBehavior="false"  />       
           <asp:Button ID="btnUpdate" class="btn btn-primary" runat="server" ValidationGroup="saved"  Text="Udpate" UseSubmitBehavior="false"  data-dismiss="modal" Onclick="btnUpdate_Click"/>       
       
          </div>
    </div>
  </div>
</div>     

                  </ContentTemplate>
             </asp:UpdatePanel>   
                  
                  </section>
          
     <script type="text/javascript">
        
         //$(document).ready(function () {
         //    $('#example').DataTable();
         //});

            $(function () {
                $("#example1").DataTable();
                
            });
        
    </script>
    <script type = "text/javascript">
         function PrintPanel() {
             var panel = document.getElementById("<%=pnlRequestDetails.ClientID %>");
           var printWindow = window.open('', '', 'height=600px,width=800px');
           printWindow.document.write("<html> <head> <style type='text/css'>.style1{border-collapse:collapse;font-size: 12px; font-family: sans-serif;} .dispnone {display:none;}</style> ");
           printWindow.document.write('</head><body >');
           printWindow.document.write(panel.innerHTML);
           printWindow.document.write('</body></html>');
           printWindow.document.close();
           setTimeout(function () {
               printWindow.print();
           }, 500);
           return false;
       }
         </script>
</asp:Content>
