<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ActiveInactiveIssues.aspx.cs" Inherits="Dairy.Tabs.Marketing.ActiveInactiveIssues" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    
     <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css">
            <script src="//code.jquery.com/jquery-1.10.2.js"></script>
            <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <script type="text/javascript">

        $(function () {
            $("#MainContent_txtDate").datepicker({ dateFormat: 'dd/mm/yy' });
           
        })
    </script>
   <script type = "text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("<%=pnlBill.ClientID %>");
            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write
                 ("<html> <head> <style type='text/css'>.tg{border-collapse:collapse; border - spacing:0; border: none;font-size: 12px; font-family: sans-serif;}</style>");


           ////printWindow.document.write('<html><head><title>DIV Contents</title>');
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

    <section class="content-header">
          <h1>
             Active and InActive Issues Report
            <small>Marketing</small>    
          </h1> 
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Marketing</a></li>
            <li class="active">Active and InActive Issues Report</li>
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



           <div class="box  ">
            <div class="box-header with-border">
              <h3 class="box-title"><asp:Label ID="lbltital" runat="server" Text="Active InActive Issues "></asp:Label> </h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-plus"></i></button>
                
              </div>
            </div>
            <div class="box-body">
               
              
                      <asp:UpdatePanel runat="server" ID="upMain" UpdateMode="Conditional">
                    <ContentTemplate>           
        
             

             <div class="row">
                 
                 
                 <div class="col-lg-3">
                  <div class="form-group" >
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class=""></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtStartDate" class="form-control" type="date" runat="server" ToolTip="Start Date" required  ></asp:TextBox>                        
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 

                 
                 
           <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <i class="fa fa-rode"></i><span style="color:red">&nbsp;*</span>
                      </div>
                           <asp:TextBox ID="txtEndDate" class="form-control" type="date" runat="server" ToolTip="End Date" required  ></asp:TextBox>                        
                   
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->
                         </div>
          
              <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <i class="fa fa-rode"></i><span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:DropDownList ID="dpIssue" class="form-control" runat="server" DataValueField="IssueID" DataTextField="Issues"  ToolTip="Select Issue Status"  > 
                       <asp:ListItem Value="0">---SelectIssueStatus---</asp:ListItem>
                           <asp:ListItem Value="1">Active </asp:ListItem>
                           <asp:ListItem Value="2">InActive</asp:ListItem>                           
                           </asp:DropDownList>                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->
                         </div>             
                 
                 <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                               <asp:Button ID="btnView" class="btn btn-primary" runat="server" CommandName="MoveNext" OnClick="btnView_click"   Text="ViewReport"    />     
                        &nbsp; <asp:Button ID="btnPrint" class="btn btn-primary" runat="server" CommandName="MoveNext" OnClientClick="return PrintPanel();"   Text="Print"    />     
                             
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 
                        
                        </div>
                        <asp:Panel runat="server" ID="pnlBill">
                        <asp:Literal runat="server" ID="genratedBIll"></asp:Literal>
              </asp:Panel>
       
                     
                    </ContentTemplate>
                </asp:UpdatePanel>
                 
                
            </div><!-- /.box-body -->            
          </div><!-- /.box -->
          

    </section>
</asp:Content>
