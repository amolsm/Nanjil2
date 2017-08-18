<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewIndentMaterials.aspx.cs" Inherits="Dairy.Tabs.Purchase.ViewIndentMaterials" %>
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
            View Indent Material
            <small>Purchase</small>
          </h1>
          <ol class="breadcrumb"><script type="text/javascript" src="../../Theme/bootstrap/js/bootstrap.min.js"></script>
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
                                        <th>Req Date</th> 
                                        <th>Indent BY</th> 
                                        <th>Status</th>
                                        <th align="center">View </th> 
                      </tr>
                    </thead>
                    <tbody>

                   
               </HeaderTemplate>
               <ItemTemplate>
                    <tr>
                                 
                                <td><%# Eval("srno")%></td>
                                <td><%# Eval("IndentId")%></td>                       
                                <td><%# Eval("IndentDate")%></td>
                                <td><%# Eval("IndentTime")%></td>
                                <td><%# Eval("TillDate")%></td>
                                <td><%# Eval("EmployeeCode") + " " + Eval("EmployeeName")%></td>                       
                                <td><%# Eval("Delivered").ToString()== "True" ? "Approved" : "Pending" %></td>
                            
                         <td align="center">   <asp:LinkButton ID="lbdelete" AlternateText="View" ForeColor="Gray" OnItemCommand="lbView_ItemCommand" 
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
                            <th>Req Date</th>
                           <th>Indent BY</th> 
                           <th>Status</th> 
                           
                            
                            <th align="center">View </th> 
                      </tr>
                    </tfoot>

                    </FooterTemplate>
                                             
           </asp:Repeater>
                
           </table>
           <asp:HiddenField ID="hfIndentId" runat="server" />
       </div> 
                           </asp:Panel>
                 </div>
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
              
              <table id="example5" class="table table-bordered table-striped">
          <asp:Repeater ID="rpModal" runat="server" >
                
               <HeaderTemplate>
                  <thead>
                      <tr>
                         <th>SrNo</th>
                                        <th>ItemName</th>
                                        <th>Quantity</th>
                                        <th>Stock</th>
                                        <th>Rack</th>
                                        <th>Section</th> 
                                        
                      </tr>
                    </thead>
                    <tbody>

                   
               </HeaderTemplate>
               <ItemTemplate>
                    <tr>
                                 
                                <td><%# Eval("srno")%></td>
                                <td><%# Eval("ItemName")%></td>                       
                                <td><%# Eval("Quantity")%></td>
                                <td><%# Eval("Stock")%></td>
                                <td><%# Eval("RackName")%></td>
                                <td><%# Eval("RackSectionName")%></td>                     
                                
                            
                         

                      


       
                    </tr>
               </ItemTemplate>
                    <FooterTemplate>

                         </tbody>

                   

                    </FooterTemplate>
                                             
           </asp:Repeater>
                
           </table>
              <br /><br /> <asp:HiddenField ID="HiddenField1" runat="server"/>
               <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                      <asp:Label Text="Status" runat="server"></asp:Label>
                      </div>
                       <asp:DropDownList ID="dpStatus" class="form-control "  data-live-search="true" runat="server" > 
                       <asp:ListItem Value="0" Text="Select Status"></asp:ListItem>
                           <asp:ListItem Value="1" Text="Delevered"></asp:ListItem>
                           <asp:ListItem Value="2" Text="Reject"></asp:ListItem>
                       </asp:DropDownList>
                        
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->
                         </div>
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
    
</asp:Content>
