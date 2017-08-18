<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewPurchaseOrder.aspx.cs" Inherits="Dairy.Tabs.Purchase.ViewPurchaseOrder" %>
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
     <script type="text/javascript" src="../../Theme/bootstrap/js/bootstrap.min.js"></script>
       <!-- Content Header (Page header) -->
        <section class="content-header">
          <h1>
            View Purchase Order
            <small>Purchase</small>
          </h1>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Purchase Order</a></li>
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
                    <div class="col-lg-4">
                 <div class="form-group">
                   <div class="input-group">
                     <div class="input-group-addon">
                      <asp:Label Text="Order Date" runat="server"></asp:Label>
                     </div>
                      <asp:TextBox ID="txtPODate" class="form-control" type="date"  placeholder="Date" runat="server" ></asp:TextBox>                        
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
                            <th>OrderCode</th>
                            <th>Order Date</th>
                            <th>Order Time</th>
                          <th>Till Date</th>
                            <th>Vendor</th>
                            <th>Amount</th>
                            <th>MD Approval</th> 
                            <th>Action</th>                          
                      </tr>
                    </thead>
                    <tbody>

                   
               </HeaderTemplate>
               <ItemTemplate>
                    <tr>
                                 
                                <td><%# Eval("srno")%></td>
                                <td>P0<%# Eval("OrderId")%></td>                       
                                <td><%# Eval("PODate")%></td>
                               <td><%# Eval("POTime")%></td>
                        <td><%# Eval("TillDate")%></td>
                                <td><%# Eval("VendorCode") + " " + Eval("VendorName")%></td>
                                  <td><%# Eval("TotalAmt")%></td>                  
                                 <td><%# Eval("MDApproval")%></td> 
                         <td align="center">   <asp:LinkButton ID="lbView" AlternateText="View" ForeColor="Gray" OnItemCommand="lbView_ItemCommand" 
                                                                    ToolTip="View" runat="server" CommandArgument='<%#Eval("OrderId") %>'
                                                                    CommandName="View"><i class="fa fa-external-link"></i></asp:LinkButton>
</td>
                    </tr>
               </ItemTemplate>
                    <FooterTemplate>

                         </tbody>

                    <tfoot>
                      <tr>
                            <th>Sr.No</th>
                            <th>OrderCode</th>
                            <th>Order Date</th>
                            <th>Order Time</th>
                          <th>Till Date</th>
                            <th>Vendor</th>
                            <th>Amount</th>
                            <th>MD Approval</th> 
                            <th>Action</th>   
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
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(InIEvent);
        function InIEvent() {

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
        }
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
