<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BindSlabExcelUpload.aspx.cs" Inherits="Dairy.Tabs.Administration.BindSlabExcelUpload" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
      <section class="content-header">
          <h1>
             Bind Slab Excel
            <small>Administration</small> 

          </h1> <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Administration</a></li>
            <li class="active">Bind Slab Excel</li>
          </ol>
        </section>

     <section class="content">
     <div class="row">
        <div class="col-md-12">
          <!-- Custom Tabs -->
          <div class="nav-tabs-custom">
            <ul class="nav nav-tabs">
              <li class="active"><a href="#tab_1" data-toggle="tab">Download</a></li>
              <li><a href="#tab_2" data-toggle="tab">Upload</a></li>
            <%--  <li><a href="#tab_3" data-toggle="tab">Tab 3</a></li>--%>
              
              <li class="pull-right"><a href="#" class="text-muted"><i class="fa fa-gear"></i></a></li>
            </ul>
            <div class="tab-content">

              <div class="tab-pane active" id="tab_1">
                  <ul style="list-style: none;">
                      <li><h4>  <b>Steps for Excel Upload:</b> </h4></li>
                      <li style="font-size:16px"><i class="fa fa-circle-o-notch fa-spin fa-fw" style="color:#3d9970"></i> <b>Step 1:</b>&nbsp; Download Bind Slab Excel Sheet &nbsp;&nbsp; <asp:Button runat="server" ID="btnDownoadSheet" OnClick="btnDownoadSheet_Click" Text="Download" CssClass="btn bg-olive"/></li>
                      <li style="font-size:16px"><i class="fa fa-circle-o-notch fa-spin fa-fw" style="color:burlywood"></i> <b>Step 2:</b>&nbsp; Create New Excel Sheet and Copy all data of downloaded sheet into new sheet &nbsp;&nbsp; </li>
                      <li style="font-size:16px"><i class="fa fa-circle-o-notch fa-spin fa-fw" style="color:#3c8dbc"></i> <b>Step 3:</b>&nbsp; Make Changes in New Excel Sheet, Do NOT change/edit Headers &nbsp;&nbsp; </li>
                        
                  </ul>
              
               <p > 
                  
                    
                </p>
              </div>
              <!-- /.tab-pane -->
              <div class="tab-pane" id="tab_2">
                  <div class="row">
                <div class="col-lg-4">
                  <div class="form-group" >
                    <div class="input-group">
                     
                      <asp:FileUpload ID="FileUpload1" runat="server" CssClass="btn btn-flat margin" />
                    </div><!-- /.input group -->
                        
                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 
                      <div class="col-lg-4">
                  <div class="form-group" >
                    <div class="input-group">
                     
                      <asp:Button runat="server" ID="btnUpload" CssClass="btn bg-navy btn-flat margin" Text="Submit" OnClick="btnUpload_Click" OnClientClick="return confirm('Once changes are made it can't be rollback. Are you sure?');"/>
                    </div><!-- /.input group -->
                        
                  </div><!-- /.form group -->

                     
                       
                          
                      </div>  
                      </div>
                     
              </div>
              <!-- /.tab-pane -->
             <%-- <div class="tab-pane" id="tab_3">
                <div class="row">
                    
                </div>
              </div>--%>
              <!-- /.tab-pane -->
            </div>
            <!-- /.tab-content -->
          </div>
          <!-- nav-tabs-custom -->
        </div>
        <!-- /.col -->
         </div>
         </section>
</asp:Content>
