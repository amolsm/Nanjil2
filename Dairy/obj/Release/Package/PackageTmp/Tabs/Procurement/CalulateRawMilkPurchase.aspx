<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CalulateRawMilkPurchase.aspx.cs" Inherits="Dairy.Tabs.Procurement.CalulateRawMilkPurchase" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css">
    <script src="//code.jquery.com/jquery-1.10.2.js"></script>
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     
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

   
    <section class="content-header">
          <h1>
             Raw Milk Rate Calculation
            <small>Procurement</small>
          </h1>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Procurement</a></li>
            <li class="active"> <asp:Label runat="server" ID="lblHeaderTab" Text="Raw Milk Rate Calculation"></asp:Label> </li>
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
                                <asp:Label runat="server" ID="lblSuccess" Text="Records Insert Succesfully"></asp:Label>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
          <!-- Default box -->
              <div class="box <%--collapsed-box--%>">
            <div class="box-header with-border">
              <h3 class="box-title"><asp:Label ID="lblTabName" runat="server" Text="Raw Milk Rate Calculation"></asp:Label> </h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-plus"></i></button>
                
              </div>
            </div>
            <div class="box-body">
               
              
                      <asp:UpdatePanel runat="server" ID="upMain" UpdateMode="Conditional">
                    <ContentTemplate>           
        
            

              <%-- <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <i class="fa fa-rode"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:DropDownList ID="dpCenter" class="form-control" DataTextField="Name" DataValueField="CenterID" runat="server" selected ToolTip="Select Center"> 
                       </asp:DropDownList>  
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->

                     
                       
                          
                      </div> --%> 
                        <div class="row">
            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <i class="fa fa-rode"></i><span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:DropDownList ID="dpRoute" class="form-control" DataTextField="Name" DataValueField="RouteID" runat="server" selected ToolTip="Select Route"> 
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->

                     
                       
                          
                      </div>  

           
            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtFromDate" class="form-control" placeholder="From Date" runat="server" required ToolTip="From Date" type="date" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group --> 
                          
                      </div>

            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtToDate" class="form-control" placeholder="TO Date" runat="server" required ToolTip="To Date"  type="date"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group --> 
                          
                      </div>
                           
            
                  <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                Shift
                      </div>
                        <asp:DropDownList ID="dpSession" class="form-control"  runat="server" selected ToolTip="Select Session"> 
                            <asp:ListItem Value="0">All Session</asp:ListItem>
                            <asp:ListItem Value="1">Morning</asp:ListItem>
                            <asp:ListItem Value="2">Evening</asp:ListItem>
                       </asp:DropDownList>                          
                    </div><!-- /.input group -->

                  </div><!-- /.form group --> 
                          
                      </div> 
              </div>
                        <div class="row">
            
              <div class="col-lg-3 pull-right">
                  <div class="form-group">
                    <div class="input-group">
                      
                    
                      
                              <asp:Button ID="btnCalculate" class="btn btn-primary" runat="server" CommandName="MoveNext" OnClick="btnCalculate_Click"   Text="Calculate" ValidationGroup="Save" />     
                        &nbsp; &nbsp; &nbsp;<asp:Button ID="btnPrint" class="btn btn-primary" runat="server" CommandName="MoveNext"  OnClientClick="PrintPanel()"    Text="Print"   />   
            
                          

                     
                       
                          
                    
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 


            
          
              
      </div>

                             
                          <asp:Panel runat="server" ID="pnlBill">
                      <%--  <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" Font-Names="Arial"
    Font-Size="11pt" OnPageIndexChanging="GridView1_PageIndexChanging"
    AllowPaging="true" class="table table-bordered table-striped" ShowFooter="true">
                     <Columns>
        <asp:BoundField ItemStyle-Width="150px" DataField="_Date" HeaderText="Date" DataFormatString="{0:d}" />
       <asp:BoundField ItemStyle-Width="150px" DataField="Supplier" HeaderText="Supplier" />
        <asp:BoundField ItemStyle-Width="150px" DataField="Can" HeaderText="Can"  />
        <asp:BoundField ItemStyle-Width="150px" DataField="MilkInLtr" HeaderText="MilkInLtr" DataFormatString="{0:0.0}" />
        <asp:BoundField ItemStyle-Width="150px" DataField="CLRReading" HeaderText="CLR" DataFormatString="{0:0.0}" />
        <asp:BoundField ItemStyle-Width="150px" DataField="FATPercentage" HeaderText="FAT%" DataFormatString="{0:0.0}" />
        <asp:BoundField ItemStyle-Width="150px" DataField="SNFPercentage" HeaderText="SNF%" DataFormatString="{0:0.0}" />
        <asp:BoundField ItemStyle-Width="150px" DataField="TSPercentage" HeaderText="TS%" DataFormatString="{0:0.0}" />
        <asp:BoundField ItemStyle-Width="150px" DataField="RPL" HeaderText="RPL" DataFormatString="{0:n}" />
        <asp:BoundField ItemStyle-Width="150px" DataField="Amount" HeaderText="Amount" DataFormatString="{0:n}" />
    </Columns> <FooterStyle  Font-Bold="True" ForeColor="Black" />
                            <EmptyDataTemplate>
            <asp:Label ID="norecord" Text="no data was found" runat="server"></asp:Label>
        </EmptyDataTemplate>
                        </asp:GridView>--%>
                            <asp:Literal runat="server" ID="Bill"></asp:Literal>
               </asp:Panel>
              
                        

               
                     
                    </ContentTemplate>
                </asp:UpdatePanel>
                 
                
            </div><!-- /.box-body -->            
          </div><!-- /.box -->

        
                   
                
                       

                                
                      
                      
  
                   <%--  <asp:UpdatePanel ID="upModal" runat="server" UpdateMode="Conditional" >  
              <ContentTemplate>         
                      <!-- Modal -->
        <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" data-backdrop="false">
  <div class="modal-dialog" role="document" style="width:75%">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title" id="myModalLabel">Raw Milk Purchase Report</h4>
      </div>
      <div class="modal-body">
          <div class="box-body">

              <div class="row">
                  
                    <div class="col-lg-4 ">
                  <div class="form-group">
                    <div class="input-group">
                      <asp:Button ID="Button1" class="btn btn-primary" runat="server" CommandName="MoveNext"  OnClientClick="PrintPanel()" Text="Print"  />                 
                     </div><!-- /.input group -->
                    </div><!-- /.form group -->
                    </div>  
              
                  </div>
              
          <asp:Panel runat="server" ID="pnlRequestDetails" >
                        <asp:Literal runat="server" ID="RequestDetails"></asp:Literal>
              </asp:Panel>
              </div>
              
             
             
               </div>

      </div>
      <div class="modal-footer">
       
       
          </div>
    </div>
  </div>
</div>     

                  </ContentTemplate>
             </asp:UpdatePanel>   --%>

          
           <script type = "text/javascript">
               function PrintPanel() {
                   var panel = document.getElementById("<%=pnlBill.ClientID %>");
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
       </section>   
</asp:Content>
