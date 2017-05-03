<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HardCopyTariff.aspx.cs" Inherits="Dairy.Tabs.Procurement.HardCopyTariff1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <section class="content-header">
          <h1>
             HardCopy Tariff 
            <small>Statement</small>    
          </h1> 
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Administration</a></li>
            <li class="active"> HardCopy Tariff</li>
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



           <div class="box " >
            <div class="box-header with-border">
              <h3 class="box-title"><asp:Label ID="lbltital" runat="server" Text=" HardCopy Tariff Details"></asp:Label> </h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-plus"></i></button>
                
              </div>
            </div>
            <div class="box-body">
               
              
                      <asp:UpdatePanel runat="server" ID="upMain" UpdateMode="Conditional">
                    <ContentTemplate>           
        
             

             <div class="row">
                 
                    <div class="col-lg-3 col-md-3">
                  <div class="form-group" >
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtDate" class="form-control"  type="date" placeholder="Date" runat="server" required ToolTip="Start Date" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 

           <div class="col-lg-3 col-md-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                      <%-- <i class="fa fa-rode"></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="lblTariff" runat="server" Text="Select Tariff"></asp:Label>
                      </div>
                      <asp:DropDownList ID="dpTariff" class="form-control"  runat="server"  > 
                          <asp:ListItem Text="----Select Tariff----" Value="0"></asp:ListItem>
                          <asp:ListItem Text="Transport" Value="1"></asp:ListItem>
                          <asp:ListItem Text="Procurement" Value="2"></asp:ListItem>
                          <asp:ListItem Text="Incentive" Value="3"></asp:ListItem>
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->
           </div>
          
          
                 
                 <div class="col-lg-3 col-md-3">
                  <div class="form-group">
                    <div class="input-group">
                               <asp:Button ID="btngenrateBill" class="btn btn-primary" runat="server" CommandName="MoveNext"   Text="ViewReport"  Onclick="btngenrateBill_Click"  />     
                        &nbsp; <asp:Button ID="btnPrint" class="btn btn-primary" runat="server" CommandName="MoveNext" OnClientClick="return PrintPanel();return true;"   Text="Print"    />     
                             
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
     <script type = "text/javascript">
         function PrintPanel() {
             var panel = document.getElementById("<%=pnlBill.ClientID %>");
            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write("<html> <head> <style type='text/css'>.style1{border-collapse:collapse;font-size:15px;width:100%; font-family: sans-serif;} </style>");
            printWindow.document.write('</head><body >');
            printWindow.document.write(panel.innerHTML);
            printWindow.document.write('</body></html>');
            printWindow.document.close();
            setTimeout(function () {
                printWindow.print();
            }, 500);
            return true;
        }
    </script>
</asp:Content>  

