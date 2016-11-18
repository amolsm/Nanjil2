<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgencyCloserScreen.aspx.cs" Inherits="Dairy.Tabs.Marketing.AgencyCloserScreen" %>

<%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>--%>
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

        $(document).ready(function () {
            $("#<% =dpAgent.ClientID %>").addClass("selectpicker");
           });

      
           </script>
     
        <script type = "text/javascript">
            function ValidateCheckBox(sender, args) {
                if (document.getElementById("<%=Chkloanpaid.ClientID %>").checked == true) {
                    args.IsValid = true;
                } else {
                    args.IsValid = false;
                }
                if (document.getElementById("<%=ChkSchemepaid.ClientID %>").checked == true) {
                    args.IsValid = true;
                } else {
                    args.IsValid = false;
                }
                if (document.getElementById("<%=ChkIncentivepaid.ClientID %>").checked == true) {
                    args.IsValid = true;
                } else {
                    args.IsValid = false;
                }
                if (document.getElementById("<%=ChkChillpad.ClientID %>").checked == true) {
                    args.IsValid = true;
                } else {
                    args.IsValid = false;
                }
                if (document.getElementById("<%=ChkFreezer.ClientID %>").checked == true) {
                    args.IsValid = true;
                } else {
                    args.IsValid = false;
                }
                if (document.getElementById("<%=ChkTray.ClientID %>").checked == true) {
                    args.IsValid = true;
                } else {
                    args.IsValid = false;
                }
                if (document.getElementById("<%=CheckCloseAgent.ClientID %>").checked == true) {
                    args.IsValid = true;
                } else {
                    args.IsValid = false;
                }
                if (document.getElementById("<%=ChkDepositRefund.ClientID %>").checked == true) {
                    args.IsValid = true;
                } else {
                    args.IsValid = false;
                }
            }
            function uncheckAll() {

                $('input[type="checkbox"]:checked').prop('checked', false);

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
   
    <section class="content-header">
          <h1>
            Agency Closer Screen
            <small>Administration</small> 

          </h1> <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Administration</a></li>
            <li class="active">Agency Closer Screen</li>
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
          <div class="box body-box">
            <div class="box-header with-border">
              <h3 class="box-title"><asp:Label runat="server" ID="lblHeaderTab" Text="Agency Closer Screen"></asp:Label></h3>
              <div class="box-tools pull-right">
           <%--     <button class="btn btn-box-tool" title="Collapse"><i class="fa fa-plus"></i></button>--%>
                
              </div>
            &nbsp;</div>
            <div class="box-body">
               
              
                      <asp:UpdatePanel runat="server" ID="upMain" UpdateMode="Conditional">
                    <ContentTemplate>           
        
               <div class="box box-solid box-default" style="margin-bottom:5px !important;" >
        <div class="box-header" style="padding:0px 0px 0px 10px !important">
          <h3 class="box-title">Agency Closer Screen </h3>
        </div><!-- /.box-header -->
        <div class="box-body">
          

         <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                          <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:DropDownList ID="dpAgent" class="form-control"     DataTextField="Name" DataValueField="AgentID"  runat="server"> 
                       </asp:DropDownList>
                        
                       <!-- CssClass="selectpicker" data-live-search="true"-->
                         
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator InitialValue="0" ID="Req_ID" Display="Dynamic" 
     runat="server" ControlToValidate="dpAgent" ForeColor="Red"
    ErrorMessage="Please Select Agent"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
                
                         </div>

        
                      
                        <asp:Button ID="btnShowAgentDetails" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Show Details" ValidationGroup="Save" onclientclick="return valid()" OnClick="btnShowAgentDetails_click" /> &nbsp;    
                      <%--  <asp:Button ID="btnupdatebankdetail" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Update" ValidationGroup="Save" OnClick="btnupdatebankdetail_click" />--%>           
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                          <div class="box box-dotted box-default" style="margin-bottom:5px !important;" >
        <div class="box-header" style="padding:0px 0px 0px 10px !important">
          <h3 class="box-title">Agency Info </h3>
        </div><!-- /.box-header -->
        <div class="box-body" id="Agentinf">

                                <asp:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Conditional">
                    <ContentTemplate>

                <table id="example1" class="table table-bordered table-striped">
                   

                 

                <asp:Repeater ID="rpAgentInfo" runat="server" OnItemCommand="rpAgentInfo_ItemCommand">
                
               <HeaderTemplate>
                  <thead>
                      <tr>
                        
                          <th>AgentID</th>
                          <th>AgentName</th>
                          <th>Route</th>
                           <th>Joining Date</th>
                         <th>EmailId</th>
                          <th>Address</th>
                          
                          
                        
                      </tr>
                    </thead>
                    <tbody>
               </HeaderTemplate>
               <ItemTemplate>
                    <tr>
                                        <td><%# Eval("AgentCode")%></td>
                                        <td><%# Eval("AgentName")%></td>    
                                        <td><%# Eval("RouteCode")%>&nbsp;<%# Eval("RouteName")%></td>
                                        <td><%# Eval("DateofJoining")%></td>
                                        <td><%# Eval("Email")%></td>
                                         <td><%# Eval("Address1")%><%# Eval("Address2")%><%# Eval("Address3")%></td>
                        
                         <td>
                                <asp:HiddenField id="hfAgentId" runat="server" value='<%#Eval("AgentID") %>' />                 
                             <asp:LinkButton ID="lbEdite"  ForeColor="Gray" OnItemCommand="lbEdite_ItemCommand" 
                                                                    ToolTip="Save" runat="server" CommandArgument='<%#Eval("AgentID") %>'
                                                                    CommandName="Edit"></asp:LinkButton><%--<i class="fa fa-edit" title="Save"></i>--%>

                         </td>
                        
                    </tr>
               </ItemTemplate>
                    <FooterTemplate>

                         </tbody>

                    <tfoot>
                      <tr>
                           
                        <th>AgentID</th>
                          <th>AgentName</th>
                          <th>Route</th>
                           <th>Joining Date</th>
                         <th>EmailId</th>
                    <th>Address</th>
                          
                         
                      </tr>
                    </tfoot>
                    </FooterTemplate>                                       
           </asp:Repeater>
                    <asp:HiddenField id="hfAgentId" runat="server" />                 
                  </table>
                        </ContentTemplate>
                </asp:UpdatePanel>

            </div>
                              </div>
         
                      
                     
                    
                   

                            <div class="box box-dotted box-default" style="margin-bottom:5px !important;" >
        <div class="box-header" style="padding:0px 0px 0px 10px !important">
          <h3 class="box-title">Payment Details </h3>
        </div><!-- /.box-header -->
        <div class="box-body">


         <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
<asp:CheckBox ID="Chkloanpaid"  runat="server" Text="Loan paid" ToolTip="loan paid" TextAlign="Left"  Font-Italic="False"></asp:CheckBox>
                      </div><!-- /.input group -->
                      
                  </div><!-- /.form group -->
                         </div>

             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                       
                 <asp:CheckBox ID="ChkSchemepaid"  runat="server" Text="Scheme paid" ToolTip="Scheme paid" TextAlign="Left"  Font-Italic="False" ></asp:CheckBox>

                    </div><!-- /.input group -->
                   
                  </div><!-- /.form group -->
                         </div>
             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                       
                 <asp:CheckBox ID="ChkIncentivepaid"  runat="server" Text="Incentive paid" ToolTip="Incentive paid" TextAlign="Left"  Font-Italic="False" ></asp:CheckBox>
                        
                    </div><!-- /.input group -->
                      
                  </div><!-- /.form group -->
                         </div>
         
                <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                       
                 <asp:CheckBox ID="ChkDepositRefund"  runat="server" Text="Deposit Refund" ToolTip="Deposit Refund" TextAlign="Left"  Font-Italic="False" ></asp:CheckBox>

                    </div><!-- /.input group -->
                   
                  </div><!-- /.form group -->
                         </div>       
                     
                    
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                          <div class="box box-dotted box-default" style="margin-bottom:5px !important;" >
        <div class="box-header" style="padding:0px 0px 0px 10px !important">
          <h3 class="box-title">Item Returns </h3>
        </div><!-- /.box-header -->
        <div class="box-body">


         <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      
                   <asp:CheckBox ID="ChkFreezer"  runat="server" Text="Freezer Return" ToolTip="Freezer Return" TextAlign="Left"  type="checkbox" Font-Italic="False"></asp:CheckBox>
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->
                         </div>

             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      
               <asp:CheckBox ID="ChkChillpad"  runat="server" Text="Chill pad" ToolTip="Chill pad" TextAlign="Left"  Font-Italic="False"></asp:CheckBox>
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->
                         </div>
             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      
                   <asp:CheckBox ID="ChkTray"  runat="server" Text="Trays" ToolTip="Trays" TextAlign="Left"  Font-Italic="False"></asp:CheckBox>
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->
                         </div>
         
                      
                     
                    
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     <div class="box box-dotted box-default" style="margin-bottom:5px !important;" >
        <div class="box-header" style="padding:0px 0px 0px 10px !important">
          <h3 class="box-title">Deactivate Agent </h3>
        </div><!-- /.box-header -->
        <div class="box-body">
              <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      
                   <asp:CheckBox ID="CheckCloseAgent"  runat="server" Text="Close Agent" ToolTip="Close Agent" TextAlign="Left"  Font-Italic="False"></asp:CheckBox>
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->
                         </div>

             <asp:CustomValidator ID="CustomValidator1" runat="server" ForeColor="Red" ErrorMessage="All CheckBox Required to Checked" ClientValidationFunction = "ValidateCheckBox"></asp:CustomValidator><br />
              <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      
                 <asp:TextBox ID="txtComment" runat="server" TextMode="MultiLine" placeholder="Comments" ToolTip="Comments" Height="87px" Width="371px"></asp:TextBox>
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtComment" ErrorMessage="Please enter comment here" ForeColor="Red"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
                   
               
                  <div class="form-group">
                    <div class="input-group">
                      
                    
                      
                        <asp:Button ID="btnSubmit" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Save"  OnClick="btnSubmit_click" /> &nbsp;    
                        <asp:Button ID="btnReset" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Reset" OnClientClick="uncheckAll()" /> &nbsp;         
                           <asp:Button ID="btnAddNew" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="AddNew" OnClick="btnAddNew_Click" Visible="false" />                
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                  
                         </div>
           
                   
                        
                    
           

                        
               </div><!-- /.input group -->
                        
                         </div><!-- /.form group -->
                   
                          
                          
                      </div> 
                          <div class="col-lg-6 pull-right">
                  <div class="form-group">
                    <div class="input-group">
                    <asp:Button ID="btnPrint" class="btn btn-primary" runat="server" CommandName="MoveNext"  OnClientClick="PrintPanel()"  Text="Print" Visible="false"  />
                        </div>
                      </div>
                       </div>
                          </div><!-- /.box-body -->
   <asp:Panel runat="server" ID="pnlBills" Visible="true">
                        <asp:Literal runat="server" ID="genratedBIll"></asp:Literal>
              </asp:Panel>   
         

              
      
      </div>
                     
                    </ContentTemplate>
                </asp:UpdatePanel>
                 
                
            </div><!-- /.box-body -->   
              <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="upMain">
            <ProgressTemplate>
                
                <div class="overlay">
                  <i class="fa fa-refresh fa-spin"></i>
                </div>

            </ProgressTemplate>
            </asp:UpdateProgress>
                         
          </div>
        <asp:HiddenField ID="hftokanno" runat="server" />
    
          </section>

   
       
       

    
    
</asp:Content>
