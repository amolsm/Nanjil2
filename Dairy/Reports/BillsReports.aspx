<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BillsReports.aspx.cs" Inherits="Dairy.Reports.BillsReports" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
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
             $("#MainContent_tstStartDate").datepicker({ dateFormat: 'dd/mm/yy' });
             $("#MainContent_txtEndDate").datepicker({ dateFormat: 'dd/mm/yy' });
         })

     }
    </script>
    <script type="text/javascript">

        $(function () {
            $("#MainContent_tstStartDate").datepicker({ dateFormat: 'dd/mm/yy' });
            $("#MainContent_txtEndDate").datepicker({ dateFormat: 'dd/mm/yy' });
        })
    </script>
       <section class="content-header">
          <h1>
            Product Sales Summary
            <small>Reports</small>
          </h1>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Product Sales Summary</a></li>
            <li class="active">Reports</li>
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
              <div class="box">
            <div class="box-header with-border">
              <h3 class="box-title"><asp:Label runat="server" ID="lblHeaderTab" Text="Product Sales "></asp:Label> </h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-plus"></i></button>
                
              </div>
            </div>
            <div class="box-body">
               
              
                      <asp:UpdatePanel runat="server" ID="upMain" UpdateMode="Conditional">
                    <ContentTemplate>           
        
               <div class="box box-solid box-default" style="margin-bottom:5px !important;" >
        <div class="box-header" style="padding:0px 0px 0px 10px !important">
          <h3 class="box-title"> </h3>
        </div><!-- /.box-header -->
        <div class="box-body">

             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <i class="fa fa-rode"></i><span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:TextBox ID="tstStartDate" class="form-control"     placeholder="Date Date" runat="server" ></asp:TextBox>   
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->
                         </div>
               <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <i class="fa fa-rode"></i><span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:TextBox ID="txtEndDate"   class="form-control"   placeholder="From Date" runat="server" ></asp:TextBox>   
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->
                         </div>
                <div class="col-lg-3">
                  <div class="form-group">
                    
                   
                   <asp:Button ID="btnShow" class="btn btn-primary"  runat="server" Text="Show" OnClick="btnShow_Click" />
                         
                     
                  </div><!-- /.form group -->
                         </div><!-- /.form group -->
           
          <div class="col-md-12">

                <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt"></rsweb:ReportViewer>
          </div>
        </div><!-- /.box-body -->
      </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                 

                
            </div><!-- /.box-body -->            
          </div><!-- /.box -->
             
        </section>
  

    
   <asp:Label runat="server" ID="lbltest"></asp:Label>
</asp:Content>
