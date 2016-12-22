<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SchemeRefund.aspx.cs" Inherits="Dairy.Tabs.Marketing.SchemeRefund" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <script type = "text/javascript">
         function PrintPanel() {
             var panel = document.getElementById("<%=pnlBills.ClientID %>");
           var printWindow = window.open('', '', 'height=600px,width=800px');
           printWindow.document.write("<html> <head> <style type='text/css'>.style1{border-collapse:collapse;font-size: 12px; font-family: sans-serif;}</style>");
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

    <script type="text/ecmascript">
        document.getElementById("test").click();

        </script>


      <section class="content-header">
          <h1>
             Add Scheme Refund Info
            <small>Administration</small>
          </h1>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Administration</a></li>
            <li class="active"> Add Scheme Refund Info</li>
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
              <div  class="box">
            <div class="box-header with-border">
              <h3 class="box-title"><asp:Label runat="server" ID="lblHeaderTab" Text=" Add Scheme Refund Info"></asp:Label></h3>  
              <div class="box-tools pull-right">
             <%--   <button   class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-plus"></i></button>--%>
                
              </div>
            </div>
            <div class="box-body">
               
              
                      <asp:UpdatePanel runat="server" ID="upMain" UpdateMode="Conditional">
                    <ContentTemplate>           
        
               <div class="box box-solid box-default" style="margin-bottom:5px !important;" >
        <div class="box-header" style="padding:0px 0px 0px 10px !important">
          <h3 class="box-title">Scheme Refund Info </h3>
        </div><!-- /.box-header -->
        <div class="box-body">
       <fieldset>
  <legend>Search  Scheme  Info</legend>
        
            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:DropDownList ID="dpRoute"  class=" form-control"  DataTextField="Name" DataValueField="RouteID" runat="server"  AutoPostBack="true" OnSelectedIndexChanged = "dpRoute_SelectedIndexChanged" ToolTip="Select Route" > 
                       </asp:DropDownList>                 
                    </div><!-- /.input group -->
                        <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator1" Display="Dynamic" 
    ValidationGroup="Save" runat="server" ControlToValidate="dpRoute" ForeColor="Red"
    ErrorMessage="Please Select Route "></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 

            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:DropDownList ID="dpAgent" CssClass="form-control"      DataTextField="Name" DataValueField="AgentID" runat="server" AutoPostBack="true" OnSelectedIndexChanged = "dpAgent_SelectedIndexChanged" ToolTip="Select Agent"> 
                       </asp:DropDownList>            
                    </div><!-- /.input group -->
                       <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator2" Display="Dynamic" 
    ValidationGroup="Save" runat="server" ControlToValidate="dpAgent" ForeColor="Red"
    ErrorMessage="Please Select Agent "></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->

                   
                       
                          
                      </div> 
               
                     
                  
            </fieldset>
          
          
              <div class="col-md-12 col-sm-12">
			<div class="panel panel-primary">
                
				<div class="panel-body">
              <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:TextBox ID="txtTotalSchemeAmt" class="form-control" placeholder="Total Scheme Amount"  runat="server" ReadOnly="true" ToolTip="Total Scheme Amount"></asp:TextBox>
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->

                     
                       
                          
                      </div>  

           

                 <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:TextBox ID="txtrefundAmt" class="form-control"  placeholder="Refund Amount" runat="server" AutoPostBack="true" OnTextChanged="txtrefundAmt_TextChanged" type="number" ToolTip="Refund Amount" ></asp:TextBox>                              
                         
                    </div><!-- /.input group -->
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please Enter Refund Amount" ControlToValidate="txtrefundAmt" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->

                     
                       
                          
                      </div>  

             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:TextBox ID="txtbalanceamt" class="form-control"  placeholder="Balance Amount" runat="server"  ReadOnly="true" ToolTip="Balance Amount" ></asp:TextBox>                              
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 
               <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                     <asp:TextBox ID="txtrequesteddate" class="form-control"  type="date" placeholder="Requested Date" runat="server"  ToolTip="Requested Date" ></asp:TextBox>                              
                    </div><!-- /.input group -->
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please Enter Requested Date" ControlToValidate="txtrequesteddate" ForeColor="Red" ValidationGroup="Save" ToolTip="Requested Date"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->

                     
                       
                          
                      </div>  
               <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:TextBox ID="txtrefunddate" class="form-control"  type="date" placeholder="Refund Date" runat="server" ReadOnly="true" ToolTip="Refund Date"  ></asp:TextBox>                              
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->

                     
                       
                          
                      </div>  
           
             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      
                    
                      
                              <asp:Button ID="btnAddSchemeRefund" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Add" ValidationGroup="Save" OnClick="btnAddSchemeRefund_Click" />   &nbsp;  
                          <asp:Button ID="btnAddNew" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="AddNew"  OnClick="btnAddNew_Click" />   &nbsp;  
                      
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 

  
              
        </div><!-- /.box-body -->
      </div>
                   <div class="col-lg-6 pull-right">
                  <div class="form-group">
                    <div class="input-group">
                    <asp:Button ID="btnPrint" class="btn btn-primary" runat="server" CommandName="MoveNext"  OnClientClick="PrintPanel()"  Text="Print" Visible="false"  />
                        </div>
                      </div>
                       </div>
              </div>
             <asp:Panel runat="server" ID="pnlBills" Visible="true">
                        <asp:Literal runat="server" ID="genratedBIll"></asp:Literal>
              </asp:Panel>   
         
            </div>
                   </div>
                             
                    </ContentTemplate>
                </asp:UpdatePanel>
                 
     
                
            </div><!-- /.box-body -->     
                   <asp:Label ID="lblUser" runat="server" Visible="False"></asp:Label>       
          </div><!-- /.box -->
              <%-- <div class="box ">
            <div class="box-header with-border">
              <h3 class="box-title"> Scheme Refund Info </h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-minus"></i></button>
                
              </div>
            </div>
            <div class="box-body" id="datalist">
                   
                
                       

                                <asp:UpdatePanel runat="server" ID="uprouteList" UpdateMode="Conditional">
                    <ContentTemplate>

                <table id="example1" class="table table-bordered table-striped">
                   

                 

                <asp:Repeater ID="rpSchemeRefundInfo" runat="server" OnItemCommand="rpSchemeRefundInfo_ItemCommand">
                
               <HeaderTemplate>
                  <thead>
                      <tr>
                          <th>ID</th>
                         
                         <th>Route</th>
                          
                            <th>Agent</th>
                         
                           <th>RequestDate</th>
                          <th>TotalSchemeAmt</th>
                           <th>RefundDate</th>
                            <th>RefundAmount</th>
                            <th>Balance</th>
                   
                      </tr>
                    </thead>
                    <tbody>

                   
               </HeaderTemplate>
               <ItemTemplate>
                    <tr>
                         <td><%# Eval("ID")%></td>
                      <td><%# Eval("Route")%></td>
                                <td><%# Eval("Agent")%></td>
                         <td><%# Eval("RequestedDate")%></td>
                           <td><%# Eval("TotalSchemeAmt")%></td>
                         <td><%# Eval("RefundDate")%></td>
                           <td><%# Eval("RefundAmt")%></td>
                          <td><%# Eval("Balance")%></td>
                    
                     
                       

                    </tr>
               </ItemTemplate>
                    <FooterTemplate>

                         </tbody>

                    <tfoot>
                      <tr>
                          <th>ID</th>
                         
                         <th>Route</th>
                          
                            <th>Agent</th>
                         
                           <th>RequestDate</th>
                          <th>TotalSchemeAmt</th>
                           <th>RefundDate</th>
                            <th>RefundAmount</th>
                            <th>Balance</th>
                      </tr>
                    </tfoot>

                    </FooterTemplate>
                                             
           </asp:Repeater>
                    <asp:HiddenField id="hfSRID" runat="server" />
             
                
                  
                     
                   
                  </table>
               
                
                        </ContentTemplate>
                </asp:UpdatePanel>
  

            


 


            </div><!-- /.box-body -->            
          </div><!-- /.box -->--%>
        </section>
     <asp:HiddenField ID="hftokanno" runat="server" />
     <script type = "text/javascript">
         function Confirm() {
             var confirm_value = document.createElement("INPUT");
             confirm_value.type = "hidden";
             confirm_value.name = "confirm_value";
             if (confirm("Do you want to save data?")) {
                 confirm_value.value = "Yes";
             } else {
                 confirm_value.value = "No";
             }
             document.forms[0].appendChild(confirm_value);
         }
    </script>
</asp:Content>
