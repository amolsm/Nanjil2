<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="dash1.aspx.cs" Inherits="Dairy.Tabs.Purchase.dash1" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../../Theme/plugins/chartjs/Chart.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
        <!-- Content Header (Page header) -->
        <section class="content-header">
          <h1>
            Purchase
            <small>Dashboard</small> <asp:Label ID="lblabc" runat="server"></asp:Label>
          </h1>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Purchase</a></li>
            <li class="active">Dashboard</li>
          </ol>
        </section>

                  <section class="content">
         
 <!-- Small boxes (Stat box) -->

        
          <asp:UpdatePanel ID="upCountRow" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true" ViewStateMode="Enabled">
             
              <ContentTemplate>

          <div class="row">

            <div class="col-lg-3 col-xs-6">
              <!-- small box -->
              <div class="small-box bg-aqua">
                <div class="inner">
                  <h3><asp:Label runat="server" Text="0" ID="lblNewIndentCount"></asp:Label></h3>
                    <asp:Timer ID="Timer1" runat="server" OnTick="Timer1_Tick" Interval="1000" />
                  <p>New Indents</p>
                </div>
                <div class="icon">
                  <i class="ion ion-ios-cart"></i>
                </div>
               <%-- <a href="#" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>--%>
                  <div class="small-box-footer">
                  <asp:LinkButton id="btnViewIndents" Text="View Indents"  runat="server" ForeColor="White" />
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
                  
             </ContentTemplate>

              
          </asp:UpdatePanel>      
                     
          <div class="col-md-6">
              <!-- Custom Tabs (Pulled to the right) -->
              <div class="nav-tabs-custom">
                <ul class="nav nav-tabs pull-right">
                  <li class="active"><a href="#tab_1-1" data-toggle="tab">Tab 1</a></li>
                  <li><a href="#tab_2-2" data-toggle="tab">Tab 2</a></li>
                  <li><a href="#tab_3-2" data-toggle="tab">Tab 3</a></li>
                  <%--<li class="dropdown">
                    <a class="dropdown-toggle" data-toggle="dropdown" href="#">
                      Dropdown <span class="caret"></span>
                    </a>
                    <ul class="dropdown-menu">
                      <li role="presentation"><a role="menuitem" tabindex="-1" href="#">Action</a></li>
                      <li role="presentation"><a role="menuitem" tabindex="-1" href="#">Another action</a></li>
                      <li role="presentation"><a role="menuitem" tabindex="-1" href="#">Something else here</a></li>
                      <li role="presentation" class="divider"></li>
                      <li role="presentation"><a role="menuitem" tabindex="-1" href="#">Separated link</a></li>
                    </ul>
                  </li>--%>
                  <li class="pull-left header"><i class="fa fa-th"></i> Custom Tabs</li>
                </ul>
                <div class="tab-content">
                  <div class="tab-pane active" id="tab_1-1">
                      <!-- Chart -->
                     
                    </div><!-- /.tab-pane -->
                  <div class="tab-pane" id="tab_2-2">
                    The European languages are members of the same family. Their separate existence is a myth.
                    For science, music, sport, etc, Europe uses the same vocabulary. The languages only differ
                    in their grammar, their pronunciation and their most common words. Everyone realizes why a
                    new common language would be desirable: one could refuse to pay expensive translators. To
                    achieve this, it would be necessary to have uniform grammar, pronunciation and more common
                    words. If several languages coalesce, the grammar of the resulting language is more simple
                    and regular than that of the individual languages.
                  </div><!-- /.tab-pane -->
                  <div class="tab-pane" id="tab_3-2">
                    Lorem Ipsum is simply dummy text of the printing and typesetting industry.
                    Lorem Ipsum has been the industry's standard dummy text ever since the 1500s,
                    when an unknown printer took a galley of type and scrambled it to make a type specimen book.
                    It has survived not only five centuries, but also the leap into electronic typesetting,
                    remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset
                    sheets containing Lorem Ipsum passages, and more recently with desktop publishing software
                    like Aldus PageMaker including versions of Lorem Ipsum.
                  </div><!-- /.tab-pane -->
                </div><!-- /.tab-content -->
              </div><!-- nav-tabs-custom -->
            </div><!-- /.col -->
         
 
</asp:Content>