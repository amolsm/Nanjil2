﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TransportPayment.aspx.cs" Inherits="Dairy.Tabs.Procurement.TransportPayment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <section class="content-header">
          <h1>
         Transport Payment Report
            <small>Transport</small>
          </h1>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Transport</a></li>
            <li class="active"> <asp:Label runat="server" ID="lblHeaderTab" Text="Transport Payment Report"></asp:Label> </li>
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
              <div class="box collapsed-box">
            <div class="box-header with-border">
              <h3 class="box-title"><asp:Label ID="lblTabName" runat="server" Text="Transport Payment Report"></asp:Label> </h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-plus"></i></button>
                
              </div>
            </div>
            <div class="box-body">
               
              
                      <asp:UpdatePanel runat="server" ID="upMain" UpdateMode="Conditional">
                    <ContentTemplate>           
        
               <div class="box box-solid box-default" style="margin-bottom:5px !important;" >
        <div class="box-header" style="padding:0px 0px 0px 10px !important">
          <h3 class="box-title">Transport Payment</h3>
        </div><!-- /.box-header -->
        <div class="box-body">

          
             
            
             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       Start Date
                      </div>
                       <asp:TextBox ID="txtStartDate" class="form-control" placeholder="Start Date" ToolTip="Start Date" runat="server" type="date" required></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div>    
             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                      End Date
                      </div>
                       <asp:TextBox ID="txtEndDate" class="form-control" placeholder="End Date" runat="server" type="date" required ToolTip="End Date"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
                          
                      </div> 

        <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                      Vehicle Type
                      </div>
                    <asp:DropDownList ID="dpVehicletype" class="form-control"  ToolTip="Select Vehicle Type" runat="server" selected> 
                        <asp:ListItem Text="----Select Vehicle Type----" Value="0"></asp:ListItem>
                          <asp:ListItem Text="Collection" Value="1"></asp:ListItem>
                          <asp:ListItem Text="Sales" Value="2"></asp:ListItem>
                       </asp:DropDownList>  
                 
                    </div><!-- /.input group -->
                    
                  </div><!-- /.form group -->
                          
                      </div> 
          
         
            
               <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      
                    
                      
                              <asp:Button ID="btnGeneratereport" class="btn btn-primary" runat="server" CommandName="MoveNext"   Text="Generate Report" ValidationGroup="Save" onclick="btnGeneratereport_Click"/>     &nbsp;&nbsp;
                        <asp:Button ID="btnPrint" class="btn btn-primary" runat="server" CommandName="MoveNext" OnClientClick="PrintPanel()"   Text="Print" ValidationGroup="Save" />           
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
   
                          
                      </div> 
        </div><!-- /.box-body -->
      </div>

                    
                    </ContentTemplate>
                </asp:UpdatePanel>
                 
                
            </div><!-- /.box-body -->            
          </div><!-- /.box -->
         <div class="box ">
            <div class="box-header with-border">
              <h3 class="box-title"></h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-minus"></i></button>
                
              </div>

            </div>
                     
            <div class="box-body" id="datalist">
                   
                
                   

                                <asp:UpdatePanel runat="server" ID="uprouteList" UpdateMode="Conditional">
                    <ContentTemplate>
                    
                <br />
                         <asp:Panel runat="server" ID="pnlPayment" >
                        <asp:Literal runat="server" ID="Payment"></asp:Literal>
              </asp:Panel>  

                        </ContentTemplate>
                </asp:UpdatePanel>
            <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="uprouteList">
            <ProgressTemplate>
                
                <div class="overlay">
                <i class="fa fa-refresh fa-spin fa-3x fa-fw"></i>
            <span class="sr-only">Loading...</span>
                </div>

            </ProgressTemplate>
            </asp:UpdateProgress>
                 
       
              </div>
              </div><!-- /.box -->
           </section>
           <script type = "text/javascript">
               function PrintPanel() {
                   var panel = document.getElementById("<%=pnlPayment.ClientID %>");
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

