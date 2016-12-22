<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IssuesRegistration.aspx.cs" Inherits="Dairy.Tabs.Marketing.IssuesRegistration" %>
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
             Issue  Information
            <small>Marketing</small> 

          </h1> <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Administration</a></li>
            <li class="active">Issue Details</li>
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
                                <asp:Label runat="server" ID="lblSuccess" Text="Issue Registered Succesfully"></asp:Label>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                    </div>
          <div class="box collapsed-box">
            <div class="box-header with-border">
              <h3 class="box-title"><asp:Label runat="server" ID="lblHeaderTab" Text="Add Issue Details"></asp:Label></h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-plus"></i></button>              
              </div>
            &nbsp;</div>
            <div class="box-body">              
                      <asp:UpdatePanel runat="server" ID="upMain" UpdateMode="Conditional">
                    <ContentTemplate> 
                         <div class="box box-solid box-default" style="margin-bottom:5px !important;" >
        <div class="box-header" style="padding:0px 0px 0px 10px !important">
          <h3 class="box-title"> Issues Information </h3>
        </div><!-- /.box-header -->
        <div class="box-body">
            <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-codiepie"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtIssueID" class="form-control" placeholder="Issue ID" runat="server" required ToolTip="Issue ID" ReadOnly="true"></asp:TextBox>                        
                    </div><!-- /.input group -->
                       </div><!-- /.form group --> 
                      </div>  
             <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtIssueRegisteredDate" class="form-control"  runat="server" type="date"  required ToolTip="Issue Registerd Date & Time" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                  </div><!-- /.form group --> 
                      </div>               
              <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <span style="color:red">&nbsp;*</span>
                      </div>
                    <asp:DropDownList ID="dpIssueArisedBy" class="form-control" runat="server" selected ToolTip="Issue Arised From">
                           <asp:ListItem Value="0">---Issue ArisedFrom---</asp:ListItem>
                           <asp:ListItem Value="1">Agent </asp:ListItem>
                           <asp:ListItem Value="2">Costomer</asp:ListItem>
                            <asp:ListItem Value="3">Consumer</asp:ListItem>
                            <asp:ListItem Value="4">Others</asp:ListItem>                            
                       </asp:DropDownList>       
                    </div><!-- /.input group -->
                  </div><!-- /.form group --> 
                      </div>  
             <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-phone-square"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtContactNumber" class="form-control" placeholder="Phone Number"  runat="server" required ToolTip="Enter PhoneNumber" TextMode="Number"  ></asp:TextBox>                        
                                            </div><!-- /.input group -->
                  </div><!-- /.form group -->
              </div>
            <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <span style="color:red">&nbsp;*</span>
                      </div>
                    <asp:DropDownList ID="dpIssues" class="form-control" runat="server" selected ToolTip="Select Issue">
                           <asp:ListItem Value="0">---Select Issue---</asp:ListItem>
                           <asp:ListItem Value="1">Taste </asp:ListItem>
                           <asp:ListItem Value="2">Leakage</asp:ListItem>
                           <asp:ListItem Value="3">Aroma</asp:ListItem>
                           <asp:ListItem Value="4">Spoilage </asp:ListItem>                           
                           <asp:ListItem Value="5">Colour </asp:ListItem>
                           <asp:ListItem Value="6">Shortage </asp:ListItem>                         
                           <asp:ListItem Value="7">Others </asp:ListItem>                          
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
                    <asp:DropDownList ID="dpIssueType" class="form-control" runat="server" selected ToolTip="Select Issue Type">
                           <asp:ListItem Value="0">---Issue Type---</asp:ListItem>
                           <asp:ListItem Value="1">Minor</asp:ListItem>
                           <asp:ListItem Value="2">Major</asp:ListItem>                               
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
                    <asp:DropDownList ID="dpBrand" class="form-control" runat="server" DataValueField="CategoryID" DataTextField="Name" selected ToolTip="Select Brand" AutoPostBack="true"    
    OnSelectedIndexChanged="dpBrand_OnSelectedIndexChanged"  >                                                   
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
                    <asp:DropDownList ID="dpProductType" class="form-control" runat="server" DataValueField="TypeID" DataTextField="Name" selected ToolTip="Select Product">   
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
                    <asp:DropDownList ID="dpCommodity" class="form-control" runat="server" DataValueField="CommodityID" DataTextField="Name" selected ToolTip="Select Commodity">
                       </asp:DropDownList>       
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->  
                      </div>
            <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-list-ol"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtDeviatedQty" class="form-control" placeholder="Deviated Quantity"  runat="server" required ToolTip="Deviated / Wasted Quantity" TextMode="Number"  ></asp:TextBox>                        
                                            </div><!-- /.input group -->
                  </div><!-- /.form group -->
              </div>
            <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <span style="color:red">&nbsp;*</span>
                      </div>
                    <asp:DropDownList ID="dpVerifiedBy" class="form-control" runat="server" selected ToolTip="VerifiedBy">
                           <asp:ListItem Value="0">---VerifiedBy---</asp:ListItem>  
                            <asp:ListItem Value="1">ASO</asp:ListItem>  
                         <asp:ListItem Value="2">QC</asp:ListItem>  
                         <asp:ListItem Value="3">Other</asp:ListItem>   
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
                    <asp:DropDownList ID="dpIssueForwaredTo" class="form-control" runat="server" selected ToolTip="Issue Forward To">
                           <asp:ListItem Value="0">---Issue Forward To---</asp:ListItem>  
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
                       <asp:TextBox ID="txtIssueEnteredBy" class="form-control" placeholder="Issue Entered By"  runat="server"   required ToolTip="Issue Entered By" ReadOnly="true"></asp:TextBox>                        
                    </div><!-- /.input group -->
                  </div><!-- /.form group --> 
                      </div>
             <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">                        
                        <asp:Button ID="btnAddIssueRegisteration" class="btn btn-primary" runat="server" CommandName="MoveNext"  OnClick="btnAddIssueRegisteration_click"   Text="Submit" ValidationGroup="Save"   /> &nbsp;    
                       <asp:Button ID="btnupdateIssuedetail" class="btn btn-primary" runat="server" CommandName="MoveNext" Text="Update" ValidationGroup="Save"  OnClick="btnupdateIssuedetail_click"  />   &nbsp;          
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
              <h3 class="box-title"> IssueInformation List </h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-minus"></i></button>
                
              </div>
            </div>
            <div class="box-body" id="datalist">                
                                <asp:UpdatePanel runat="server" ID="uprouteList" UpdateMode="Conditional">
                    <ContentTemplate>
                <table id="example1" class="table table-bordered table-striped">                   
   <asp:Repeater ID="rp" runat="server" OnItemCommand="rp_ItemCommand" >               
                
               <HeaderTemplate>
                  <thead>
                      <tr>              <th>IssueCode/issue</th>  
                                        <th>IssueType</th>
                                        <th>Date</th>
                                        <th>Edit</th> 
                      </tr>
                    </thead>
                    <tbody>                   
               </HeaderTemplate>
               <ItemTemplate>
                    <tr>             
                                        <td><%# Eval("IssueCode")%></td>    
                                        <td><%# Eval("IssueType")%></td>
                                        <td><%# Eval("IssueDateTime")%></td>                                        
                       <td>
                             <asp:LinkButton ID="lbEdite" AlternateText="Edit" ForeColor="Gray" OnItemCommand="lbEdite_ItemCommand" 
                                                                    ToolTip="Edit" runat="server" CommandArgument='<%#Eval("IssueID") %>'
                                                                    CommandName="Edit"><i class="fa fa-edit"></i></asp:LinkButton>

                         </td>
                        <%-- <td>   <asp:LinkButton ID="lbdelete" AlternateText="delete" ForeColor="Gray" OnItemCommand="lbdelete_ItemCommand" 
                                                                    ToolTip="Delete" runat="server" CommandArgument='<%#Eval("IssueID") %>'
                                                                    CommandName="delete"><i class="fa fa-trash"></i></asp:LinkButton>
</td>--%>
       </tr>
               </ItemTemplate>
                    <FooterTemplate>
                         </tbody>
                    <tfoot>
                      <tr>             <th>IssueCode/Issue</th>                                     
                                        <th>IssueType</th>
                                        <th>Date</th>                                         
                                        <th>Edit</th>   
                                        
                      </tr>
                    </tfoot>
                    </FooterTemplate>
                          </asp:Repeater>  
                    <asp:HiddenField id="hIssueId" runat="server" />
                  </table>
             </section>
                        </ContentTemplate>
                                </asp:UpdatePanel>

</asp:Content>
