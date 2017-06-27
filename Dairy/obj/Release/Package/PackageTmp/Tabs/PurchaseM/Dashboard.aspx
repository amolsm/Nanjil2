<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Dairy.Tabs.PurchaseM.Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
        <!-- Content Header (Page header) -->
        <section class="content-header">
          <h1>
            Purchase
            <small>Dashboard</small>
          </h1>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Purchase</a></li>
            <li class="active">Dashboard</li>
          </ol>
        </section>

                  <section class="content">
         
 <!-- Small boxes (Stat box) -->

          <asp:Timer ID="TimerCount" runat="server" Interval="125000" OnTick="TimerCount_Tick">
          </asp:Timer>
    
          <asp:UpdatePanel ID="upCountRow" runat="server" UpdateMode="Conditional" 
            ViewStateMode="Enabled">
            <ContentTemplate>

          <div class="row">

            <div class="col-lg-3 col-xs-6">
              <!-- small box -->
              <div class="small-box bg-aqua">
                <div class="inner">
                  <h3><asp:Label runat="server" Text="0" ID="lblNewIndentCount"></asp:Label></h3>
                  <p>New Indents</p>
                </div>
                <div class="icon">
                  <i class="ion ion-ios-cart"></i>
                </div>
               <%-- <a href="#" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>--%>
                  <div class="small-box-footer">
                  <asp:LinkButton id="btnViewIndents" Text="View Indents" OnClick="btnViewIndents_Click" runat="server" ForeColor="White" />
              <i class="fa fa-arrow-circle-right"></i>
                      </div>
              </div>
            </div><!-- ./col -->
            <div class="col-lg-3 col-xs-6">
              <!-- small box -->
              <div class="small-box bg-green">
                <div class="inner">
                  <h3>53<sup style="font-size: 20px">%</sup></h3>
                  <p>Todays Indents</p>
                </div>
                <div class="icon">
                  <i class="ion ion-stats-bars"></i>
                </div>
                <a href="#" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>
              </div>
            </div><!-- ./col -->
            <div class="col-lg-3 col-xs-6">
              <!-- small box -->
              <div class="small-box bg-yellow">
                <div class="inner">
                  <h3>44</h3>
                  <p>Vendor to deliver</p>
                </div>
                <div class="icon">
                  <i class="ion ion-person-add"></i>
                </div>
                <a href="#" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>
              </div>
            </div><!-- ./col -->
            <div class="col-lg-3 col-xs-6">
              <!-- small box -->
              <div class="small-box bg-red">
                <div class="inner">
                  <h3>65</h3>
                  <p>Pending MD Approval</p>
                </div>
                <div class="icon">
                  <i class="ion ion-pie-graph"></i>
                </div>
                <a href="#" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>
              </div>
            </div><!-- ./col -->
          </div><!-- /.row -->
              
                <Triggers>
                <asp:AsyncPostBackTrigger controlid="TimerCount" eventname="Tick" />
            </Triggers>
            </ContentTemplate>
          </asp:UpdatePanel>      
                      
          <div class="box ">
               <asp:UpdatePanel runat="server" ID="upMain" UpdateMode="Conditional">
                      <ContentTemplate>
            <div class="box-header with-border">
               <h4> <asp:Label ID="lblBoxHeader" runat="server"></asp:Label></h4>
            </div>
            <div class="box-body">
                
                           <asp:Panel runat="server" ID="pnlIndentList" Visible="true">

                                <div class="col-md-12" runat="server" id="divTable">
                          <table id="example1" class="table table-bordered table-striped">
          <asp:Repeater ID="rpIndentList" runat="server" OnItemCommand="rpIndentList_ItemCommand">
                
               <HeaderTemplate>
                  <thead>
                      <tr>
                         
                                        <th>Sr.No</th>
                                        <th>IndentCode</th>
                                        <th>Indent Date</th>
                                        <th>Time</th>
                                        <th>Req Date</th> 
                                        <th>Indent BY</th> 
                                        
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
