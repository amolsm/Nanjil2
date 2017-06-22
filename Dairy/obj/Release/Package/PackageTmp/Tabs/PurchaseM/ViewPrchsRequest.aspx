<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewPrchsRequest.aspx.cs" Inherits="Dairy.Tabs.PurchaseM.ViewPrchsRequest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
     <script type="text/javascript" src="../../Theme/bootstrap/js/bootstrap.min.js"></script>
    <link href="../../Theme/bootstrap/css/bootstrap-select.min.css" rel="stylesheet" />
    <script type="text/javascript" src="../../Theme/bootstrap/js/bootstrap-select.min.js"></script>
    <style type="text/css">
        .dispnone {display:none;}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
        <!-- Content Header (Page header) -->
        <section class="content-header">
          <h1>
            View Purchase Request
            <small>Purchase</small>
          </h1>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Purchase Request</a></li>
            <li class="active">Purchase</li>
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
                
                           <asp:Panel runat="server" ID="pnlRequestList" Visible="true">

                                <div class="col-md-12" runat="server" id="divTable">
                          <table id="example1" class="table table-bordered table-striped">
          <asp:Repeater ID="rpRequestList" runat="server" OnItemCommand="rpRequestList_ItemCommand">
                
               <HeaderTemplate>
                  <thead>
                      <tr>
                         
                                        <th>Sr.No</th>
                                        <th>RequestCode</th>
                                        <th>Date</th>
                                        <th>Time</th>
                                        <th>Request BY</th> 
                                        <th>Status</th> 
                                        <th align="center">View </th> 
                      </tr>
                    </thead>
                    <tbody>

                   
               </HeaderTemplate>
               <ItemTemplate>
                    <tr>
                                 
                                <td><%# Eval("srno")%></td>
                                <td>PR<%# Eval("RequestId")%></td>                       
                                <td><%# Eval("RequestDate")%></td>
                                <td><%# Eval("RequestTime")%></td>
                                
                                <td><%# Eval("EmployeeCode") + " " + Eval("EmployeeName")%></td>                       
                                <td><%# Eval("ReqStatus")%></td>
                            
                         <td align="center">   <asp:LinkButton ID="lbView" AlternateText="View" ForeColor="Gray" OnItemCommand="lbView_ItemCommand" 
                                                                    ToolTip="View" runat="server" CommandArgument='<%#Eval("RequestId") %>'
                                                                    CommandName="View"><i class="fa fa-external-link"></i></asp:LinkButton>
</td>

                      


       
                    </tr>
               </ItemTemplate>
                    <FooterTemplate>

                         </tbody>

                    <tfoot>
                      <tr>
                            <th>Sr.No</th>
                             <th>RequestCode</th>
                             <th>Date</th>
                             <th>Time</th>
                             <th>Request BY</th> 
                             <th>Status</th> 
                            <th align="center">View </th> 
                      </tr>
                    </tfoot>

                    </FooterTemplate>
                                             
           </asp:Repeater>
                
           </table>
           <asp:HiddenField ID="hftotalAmout" runat="server" />
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
        <h4 class="modal-title" id="myModalLabel">Purchase Request Details</h4>
      </div>
      <div class="modal-body">
          <div class="box-body">

              <div class="row">
                   <div class="col-lg-4">
                  <div class="form-group frmgrp" >
                    <div class="input-group">
                      <div class="input-group-addon">
                        <asp:Label ID="lblReqStatus" runat="server" Text="Status"></asp:Label>
                      </div>
                        <asp:DropDownList ID="dpReqStatus" class="form-control" runat="server" selected >

                           <asp:ListItem Value="0">---Select Status---</asp:ListItem>
                           <asp:ListItem Value="1">Approved</asp:ListItem>
                           <asp:ListItem Value="2">Rejected</asp:ListItem>
                            <asp:ListItem Value="2">Pending</asp:ListItem>
                            
                       </asp:DropDownList>
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator InitialValue="0" ID="VldIsActive" Display="Dynamic" 
    ValidationGroup="Save" runat="server" ControlToValidate="dpReqStatus" ForeColor="Red"
    ErrorMessage="Please Select Status "></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
    
                      </div>        <!-- --> 
                  <div class="col-lg-4 ">
                  <div class="form-group">
                    <div class="input-group">
                      <asp:Button ID="BtnSubmitStatus" class="btn btn-primary" runat="server" CommandName="MoveNext"  OnClick="BtnSubmitStatus_Click" Text="Submit"  />                 
                     </div><!-- /.input group -->
                    </div><!-- /.form group -->
                    </div>  
                    <div class="col-lg-4 ">
                  <div class="form-group">
                    <div class="input-group">
                      <asp:Button ID="btnPrint" class="btn btn-primary" runat="server" CommandName="MoveNext"  OnClientClick="PrintPanel()" Text="Print"  />                 
                     </div><!-- /.input group -->
                    </div><!-- /.form group -->
                    </div>  
              </div>

              
          <asp:Panel runat="server" ID="pnlRequestDetails" >
                        <asp:Literal runat="server" ID="RequestDetails"></asp:Literal>
              </asp:Panel>
              
              </div>

      </div>
      <div class="modal-footer">
       
       
          </div>
    </div>
  </div>
</div>     

                  </ContentTemplate>
             </asp:UpdatePanel> 
                  
                  </section>
          
     <script type="text/javascript">
        
        

            $(function () {
                $("#example1").DataTable();
                $('#example2').DataTable({
                    "paging": true,
                    "lengthChange": false,
                    "searching": false,
                    "ordering": true,
                    "info": true,
                    "autoWidth": false
                });
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
