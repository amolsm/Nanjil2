<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ApprovedRequestItems.aspx.cs" Inherits="Dairy.Tabs.Purchase.ApprovedRequestItems" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
     
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
            View Approved Request Items
            <small>Purchase</small>
          </h1>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Request Items</a></li>
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
                      <asp:Label Text="Request Date" runat="server"></asp:Label>
                     </div>
                      <asp:TextBox ID="txtRequestDate" class="form-control" type="date"  placeholder="Date" runat="server" ></asp:TextBox>                        
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
          <asp:Repeater ID="rpRequestList" runat="server" >
                
               <HeaderTemplate>
                  <thead>
                      <tr>
                         
                            <th>Sr.No</th>
                            <th>RequestCode</th>
                            <th>Item</th>
                            <th>Quantity</th>
                            <th>Approved By</th> 
                                                        
                      </tr>
                    </thead>
                    <tbody>

                   
               </HeaderTemplate>
               <ItemTemplate>
                    <tr>
                                 
                                <td><%# Eval("srno")%></td>
                                <td>PR<%# Eval("RequestId")%></td>                       
                                <td><%# Eval("ItemName")%></td>
                               
                                <td><%# Eval("Quantity") + " " + Eval("UnitName")%></td>
                                <td><%# Eval("EmployeeCode") + " " + Eval("EmployeeName")%></td>                       
                                
                    </tr>
               </ItemTemplate>
                    <FooterTemplate>

                         </tbody>

                    <tfoot>
                      <tr>
                            <th>Sr.No</th>
                            <th>RequestCode</th>
                            <th>Item</th>
                            <th>Quantity</th>
                            <th>Approved By</th> 
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

 
</asp:Content>
