<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CorrectiveActionOnIssue.aspx.cs" Inherits="Dairy.Tabs.Marketing.CorrectiveActionOnIssue" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
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
             CorrectiveAction  Information
            <small>Marketing</small> 

          </h1> <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> MarketingCorrectiveAction</a></li>
            <li class="active">CorrectiveAction Details</li>
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
                                <asp:Label runat="server" ID="lblSuccess" Text="CorrectiveAction Registered Succesfully"></asp:Label>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                    </div>
          <div class="box collapsed-box">
            <div class="box-header with-border">
              <h3 class="box-title"><asp:Label runat="server" ID="lblHeaderTab" Text="Add CorrectiveAction Details"></asp:Label></h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-plus"></i></button>
                
              </div>
            &nbsp;</div>
            <div class="box-body">
               
              
              
                      <asp:UpdatePanel runat="server" ID="upMain" UpdateMode="Conditional">
                    <ContentTemplate> 
                         <div class="box box-solid box-default" style="margin-bottom:5px !important;" >
        <div class="box-header" style="padding:0px 0px 0px 10px !important">
          <h3 class="box-title"> CorrectiveAction Information </h3>
        </div><!-- /.box-header -->
        <div class="box-body">


            
         
            <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-codiepie"></i><span style="color:red">&nbsp;*</span>
                      </div>
                        <asp:TextBox ID="txtDateToday" class="form-control"  runat="server" required ToolTip="Date" ReadOnly="true"></asp:TextBox>                        
                   </div><!-- /.input group -->
                       </div><!-- /.form group --> 
                          
                      </div> 

            
          
            <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class=""></i><span style="color:red">&nbsp;*</span>
                      </div>

                  <asp:DropDownList ID="dpIssueCode" class="form-control" runat="server" DataValueField="IssueCode" DataTextField="IssueCode" selected ToolTip="Select Issue Code" AutoPostBack="true" OnSelectedIndexChanged="dpIssueCode_Changed" >
                        <%--   <asp:ListItem Value="0">---Issue Code---</asp:ListItem>--%>
                      
                                                    
                       </asp:DropDownList>  
                         </div><!-- /.input group -->

                  </div><!-- /.form group -->

              </div>

              <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class=""></i><span style="color:red">&nbsp;*</span>
                      </div>

                  <asp:TextBox ID="txtIssueRegisteredDate" class="form-control" type="date" runat="server" required ToolTip="Issue Registered Date"  ReadOnly="true"></asp:TextBox>                        
                   
                         </div><!-- /.input group -->

                  </div><!-- /.form group -->

              </div>


             <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:TextBox ID="txtAction" class="form-control" placeholder="What Action To be Taken?"  runat="server" required ToolTip="Enter Action To be Taken" ></asp:TextBox>                        
                   
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
                       
                          
                      </div>
               
              <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtActionTakingDate" class="form-control"  runat="server" required ToolTip="Action to be Taken Date" type="Date" ></asp:TextBox>                        
                       
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->

                     
                       
                          
                      </div>  
             <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-user"></i><span style="color:red">&nbsp;*</span>
                      </div>

                  <asp:DropDownList ID="dpActionAdvisedBy" class="form-control" runat="server" selected ToolTip="Action Advised By">
                           <asp:ListItem Value="0">---Action AdvisedBy---</asp:ListItem>
                      <asp:ListItem Value="1">MD</asp:ListItem>   
                            <asp:ListItem Value="2">Marketing</asp:ListItem>  
                         <asp:ListItem Value="3">Production</asp:ListItem>
                         <asp:ListItem Value="4">QC</asp:ListItem> 
                         <asp:ListItem Value="5">Other</asp:ListItem>                      
                          
                                                    
                       </asp:DropDownList>  
                         </div><!-- /.input group -->

                  </div><!-- /.form group -->

              </div>
            <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-user"></i><span style="color:red">&nbsp;*</span>
                      </div>
                   <asp:DropDownList ID="dpActionTakenBy" class="form-control" runat="server" selected ToolTip="Action Taken By">
                           <asp:ListItem Value="0">---Action TakenBy---</asp:ListItem>  
                            <asp:ListItem Value="1">Marketing</asp:ListItem>  
                         <asp:ListItem Value="2">Production</asp:ListItem>
                         <asp:ListItem Value="3">QC</asp:ListItem> 
                         <asp:ListItem Value="4">Other</asp:ListItem>                      
                          
                                                    
                       </asp:DropDownList>    
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->

                     
                       
                          
                      </div>
            <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <span style="color:red">&nbsp;*</span>
                      </div>
                    <asp:DropDownList ID="dpFeedbackAfterTakenAction" class="form-control" runat="server" selected ToolTip="Select FeedBack After Taken Action">

                           <asp:ListItem Value="0">---FeedBack AfterTakenAction---</asp:ListItem>
                           <asp:ListItem Value="1">Satisfied</asp:ListItem>
                           <asp:ListItem Value="2">Not Satisfied</asp:ListItem>
                               
                       </asp:DropDownList>       
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->
                     
                       
                          
                      </div>           
                   
          
       
             <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      
                    
                      
                        <asp:Button ID="btnAddCorrectiveAction" class="btn btn-primary" runat="server" CommandName="MoveNext"  OnClick="btnAddCorrectiveAction_click"   Text="Submit" ValidationGroup="Save"   /> &nbsp;    
                        <asp:Button ID="btnupdateCorrectiveActiondetail" class="btn btn-primary" runat="server" CommandName="MoveNext" Text="Update" ValidationGroup="Save"  OnClick="btnupdateCorrectiveActiondetail_click"  />   &nbsp;        
                      <asp:Button ID="btnAddNew" class="btn btn-primary" runat="server" CommandName="MoveNext"  OnClick="btnAddNew_click"   Text="AddNew" ValidationGroup="Save"  formnovalidate /> &nbsp;    
                     
                         </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 
                    
        </div><!-- /.box-body -->
      </div>
                     
                    </ContentTemplate>
                </asp:UpdatePanel>
                 
                
            </div><!-- /.box-body -->            
          </div>
           <section>
                <div class="box ">
            <div class="box-header with-border">
              <h3 class="box-title"> CorrectiveAction List </h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-minus"></i></button>
                
              </div>
            </div>
            <div class="box-body" id="datalist">
                
                                <asp:UpdatePanel runat="server" ID="uprouteList" UpdateMode="Conditional">
                    <ContentTemplate>

                <table id="example1" class="table table-bordered table-striped">
                   

                   <%-- <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="rpBankList_ItemCommand">
                --%>
                      <asp:Repeater ID="rp" runat="server" OnItemCommand="rp_ItemCommand" >
                
                
               <HeaderTemplate>
                  <thead>
                      <tr>         
                               <th>IssueCode/Issues</th>
                                     
                                         <th>IssueRegisteredDate</th>
                                        <th>ActionToBeTakenOn</th>
                                       
                                        <th>Edit</th>
                                      
                                        
                          
                      </tr>
                    </thead>
                    <tbody>

                   
               </HeaderTemplate>
               <ItemTemplate>
                    <tr>
                        

                                        <td><%# Eval("IssueCode")%></td>
                                        <td><%# Eval("issueRegistedDate")%></td>    
                                        <td><%# Eval("ActionToBeTakenDate")%></td>
                                        
                                        
                                        
                                        
                       <td>
                             <asp:LinkButton ID="lbEdite" AlternateText="Edit" ForeColor="Gray" OnItemCommand="lbEdite_ItemCommand" 
                                                                    ToolTip="Edit" runat="server" CommandArgument='<%#Eval("ID") %>'
                                                                    CommandName="Edit"><i class="fa fa-edit"></i></asp:LinkButton>

                         </td>
                         <%--<td>   <asp:LinkButton ID="lbdelete" AlternateText="delete" ForeColor="Gray" OnItemCommand="lbdelete_ItemCommand" 
                                                                    ToolTip="Delete" runat="server" CommandArgument='<%#Eval("ID") %>'
                                                                    CommandName="delete"><i class="fa fa-trash"></i></asp:LinkButton>
</td>--%>


                        
                    </tr>
               </ItemTemplate>
                    <FooterTemplate>

                         </tbody>

                    <tfoot>
                      <tr>
                                    <th>Issue</th>                                      
                                          
                            <th>IssueRegisteredDate</th>
                                        <th>ActionToBeTakenOn</th>
                                     
                                        <th>Edit</th>
                                    <%--    <th>Delete</th>--%>

                                      
                                        
                      </tr>
                    </tfoot>

                    </FooterTemplate>
                          </asp:Repeater>    
          
                    <asp:HiddenField id="hCorrectiveActionId" runat="server" />
             
                
                  
                     
                   
                  </table>
             </section>
                
                        </ContentTemplate>
                                              </asp:UpdatePanel>

</asp:Content>
