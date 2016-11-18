<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ComparativeStatement.aspx.cs" Inherits="Dairy.Tabs.Purchase.ComparativeStatement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <link href="../../Theme/bootstrap/css/bootstrap-select.min.css" rel="stylesheet" />
    <script type="text/javascript" src="../../Theme/bootstrap/js/bootstrap-select.min.js"></script>

     <style type="text/css">
.tg  {border-collapse:collapse;border-spacing:0;margin-top:0px;}
.tg td{font-family:Arial, sans-serif;font-size:14px;padding:10px 15px;border-style:solid;border-width:0px;overflow:hidden;word-break:normal;border-top-width:1px;border-bottom-width:1px;}
.tg th{font-family:Arial, sans-serif;font-size:14px;font-weight:normal;padding:10px 5px;border-style:solid;border-width:0px;overflow:hidden;word-break:normal;border-top-width:1px;border-bottom-width:1px;}
.tg .tg-yw4l{vertical-align:top}
</style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  
    
        <section class="content-header">
          <h1>
             Comparative Statement
            <small>Purchase</small> 

          </h1>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Comparative Statement</a></li>
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
            <div class="box-header with-border">
           
            </div>
            <div class="box-body">
               
              
                <asp:UpdatePanel runat="server" ID="upMain" UpdateMode="Conditional">

         <ContentTemplate>    
             <asp:Panel runat="server" >
                  <div class="col-md-12">
                <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                      <asp:Label Text="Item" runat="server"></asp:Label>
                      </div>
                       <asp:DropDownList ID="dpItems" class="form-control selectpicker"  data-live-search="true" DataTextField="Name" DataValueField="Id" runat="server" OnSelectedIndexChanged="dpItems_SelectedIndexChanged" AutoPostBack="true" > 
                       </asp:DropDownList>
                        
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->
                         </div>

                 <div class="col-lg-4 pull-right" style="text-align:right">
                  <div class="form-group">
                    <div class="input-group">
                      <asp:Button ID="btnPrint" class="btn btn-primary" runat="server" CommandName="MoveNext" OnClientClick="PrintPanel()" Text="Print" OnClick="btnPrint_Click" />
                          
      </div><!-- /.input group -->

    </div><!-- /.form group -->

                     
                       
                          
        </div>        
                         
               </div>
             </asp:Panel>
                       <asp:Panel runat="server" ID="pnlStatements" Visible="true">
                     
                   <h4>&nbsp;&nbsp;&nbsp; Item Price Comparison Report</h4>
                              <div class="col-md-12 am1" runat="server" id="divTable">
                                  <div style="width:auto; padding-left:0px; padding-right:0px; " class="col-md-2 ">
                      <table id="tableH" class="tg " style="font-weight:bold">
                          <%--<tr>
                              <td colspan="3"> Price Comparison Report</td>
                          </tr> --%>
                          <tr>
                              <td> Item Name</td>
                          </tr>
                          <tr>
                              <td>Vendor</td>
                          </tr> 
                          <tr>
                              <td>Price</td>
                          </tr>
                          <tr>
                              <td>Quantity</td>
                          </tr>
                          <tr>
                              <td>Shipping</td>
                          </tr>
                          <tr>
                              <td>Excise %</td>
                          </tr>
                          <tr>
                              <td>CST %</td>
                          </tr>
                          <tr>
                              <td>VAT %</td>
                          </tr>
                          <tr>
                              <td>Insurance</td>
                          </tr>
                          <tr>
                              <td>Freight</td>
                          </tr>
                          <tr>
                              <td>Total Price</td>
                          </tr>                    
                      </table>
                  </div>
                          
          <asp:Repeater ID="rpItemRatesList" runat="server"  OnItemCommand="rpItemRatesList_ItemCommand">
                
             
               <ItemTemplate>
                  <div style="width:auto; padding-left:0px; padding-right:0px; " class="col-md-2 ">
                      <table id="table1" class="tg">
                          <%--<tr>
                              <td> &nbsp;</td>
                          </tr> --%>
                           <tr>
                              <td> <%# Eval("ItemName") %></td>
                          </tr> 
                          <tr>
                              <td><%# Eval("VendorCode") + " "+Eval("VendorName") %></td>
                          </tr> 
                          <tr>
                              <td><%# string.Format("{0:##,###.00}",Eval("Price")) %></td>
                          </tr>
                           <tr>
                              <td><%# Eval("Quantity") +""+ Eval("UnitName") %></td>
                          </tr>
                           <tr>
                              <td><%# Eval("Shipping") %></td>
                          </tr>
                           <tr>
                              <td><%# Eval("ExciseDuty") %></td>
                          </tr>
                           <tr>
                              <td><%# Eval("CST") %></td>
                          </tr>
                          <tr>
                              <td><%# Eval("Vat") %></td>
                          </tr>
                           <tr>
                              <td><%# string.Format("{0:##,###.00}",Eval("Insurance")) %></td>
                          </tr>
                           <tr>
                              <td><%# string.Format("{0:##,###.00}",Eval("FreightCharges")) %></td>
                          </tr>
                          <tr>
                              <td style="font-weight:bold"><%# string.Format("{0:##,###.00}",Eval("TotalPrice")) %></td>
                          </tr>                    
                      </table>
                  </div>
               </ItemTemplate>
           
                                             
           </asp:Repeater>
                  <asp:HiddenField id="hfItemRatesId" runat="server" />     
           
         
       </div> 

                            
                                  
       </asp:Panel>

         </ContentTemplate>
                       
                </asp:UpdatePanel>   
                 
                
            </div><!-- /.box-body -->            
          </div><!-- /.box -->
       
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
             var panel = document.getElementById("<%=pnlStatements.ClientID %>");
             var printWindow = window.open('', '', 'height=600px,width=800px');
             printWindow.document.write('<html> <head>');
             printWindow.document.write('<link rel="stylesheet" href="/Theme/bootstrap/css/bootstrap.min.css">');
           printWindow.document.write(" <style type='text/css'>.tg  {border-collapse:collapse;border-spacing:0;margin-top:0px;} ");
           printWindow.document.write(".tg td{font-family:Arial, sans-serif;font-size:14px;padding:10px 15px;border-style:solid;border-width:0px;overflow:hidden;word-break:normal;border-top-width:1px;border-bottom-width:1px;}");
           printWindow.document.write(".tg th{font-family:Arial, sans-serif;font-size:14px;font-weight:normal;padding:10px 5px;border-style:solid;border-width:0px;overflow:hidden;word-break:normal;border-top-width:1px;border-bottom-width:1px;}");
           printWindow.document.write(".tg .tg-yw4l{vertical-align:top} .am1{display: inline-flex;}</style>");
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

