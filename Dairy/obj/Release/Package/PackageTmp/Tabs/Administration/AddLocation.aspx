<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddLocation.aspx.cs" Inherits="Dairy.Tabs.Administration.AddLocation" %>
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
             Location  Information
            <small>Administration</small> 

          </h1> <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Administration</a></li>
            <li class="active">Location Details</li>
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
          <div class="box collapsed-box">
            <div class="box-header with-border">
              <h3 class="box-title"><asp:Label runat="server" ID="lblHeaderTab" Text="Add Location Details"></asp:Label></h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-plus"></i></button>
                
              </div>
            &nbsp;</div>
            <div class="box-body">
               
              
                      <asp:UpdatePanel runat="server" ID="upMain" UpdateMode="Conditional">
                    <ContentTemplate> 
                         <div class="box box-solid box-default" style="margin-bottom:5px !important;" >
        <div class="box-header" style="padding:0px 0px 0px 10px !important">
          <h3 class="box-title"> Location Information </h3>
        </div><!-- /.box-header -->
        <div class="box-body">


            <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="glyphicon glyphicon-globe"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtCountryName" class="form-control" placeholder="Country Name" runat="server" required ToolTip="Enter Country Name"></asp:TextBox>                        
                    </div><!-- /.input group -->
                       </div><!-- /.form group -->

                     
                       
                          
                      </div>  

             <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="glyphicon glyphicon-globe"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtstatename" class="form-control" placeholder="State Name"  runat="server"  required ToolTip="Enter State Name"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div>
               
              <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="glyphicon glyphicon-globe"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtDistrict" class="form-control" placeholder="District Name"  runat="server"  required ToolTip="Enter District Name" TextMode="MultiLine"></asp:TextBox>                        
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->

                     
                       
                          
                      </div>  
             <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="glyphicon glyphicon-globe"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtCity" class="form-control" placeholder="City/Town"  runat="server" required ToolTip="Enter City/Town Name"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

              </div>
             <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      
                    
                      
                        <asp:Button ID="btnAddStateInfo" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Add" ValidationGroup="Save" OnClick="btnAddStateInfo_click" /> &nbsp;    
                        <asp:Button ID="btnupdatestatedetail" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Update" ValidationGroup="Save" OnClick="btnupdatestatedetail_click" />           
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
              <h3 class="box-title"> Location Information List </h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-minus"></i></button>
                
              </div>
            </div>
            <div class="box-body" id="datalist">
                
                                <asp:UpdatePanel runat="server" ID="uprouteList" UpdateMode="Conditional">
                    <ContentTemplate>

                <table id="example1" class="table table-bordered table-striped">
                   

                 
                      <asp:Repeater ID="rpBankList" runat="server" OnItemCommand="rpBankList_ItemCommand">
                
                
               <HeaderTemplate>
                  <thead>
                      <tr>              <th>Country Name</th>
                                        <th>State  Name</th>
                                        
                                        <th>District Name</th>
                                        <th>City/Town</th>
                                        
                          
                      </tr>
                    </thead>
                    <tbody>

                   
               </HeaderTemplate>
               <ItemTemplate>
                    <tr>
                        

                                        <td><%# Eval("Country")%></td>
                                        <td><%# Eval("State")%></td>    
                                        <td><%# Eval("District")%></td>
                                        <td><%# Eval("City")%></td>
                                       
                                        
                                        
                                        
                       <td>
                             <asp:LinkButton ID="lbEdite" AlternateText="Edit" ForeColor="Gray" OnItemCommand="lbEdite_ItemCommand" 
                                                                    ToolTip="Edit" runat="server" CommandArgument='<%#Eval("LocId") %>'
                                                                    CommandName="Edit"><i class="fa fa-edit"></i></asp:LinkButton>

                         </td>
                         <td>   <asp:LinkButton ID="lbdelete" AlternateText="delete" ForeColor="Gray" OnItemCommand="lbdelete_ItemCommand" 
                                                                    ToolTip="Delete" runat="server" CommandArgument='<%#Eval("LocId") %>'
                                                                    CommandName="delete"><i class="fa fa-trash"></i></asp:LinkButton>
</td>


                        
                    </tr>
               </ItemTemplate>
                    <FooterTemplate>

                         </tbody>

                    <tfoot>
                      <tr>
                                     <th>Country Name</th>
                                        <th>State  Name</th>
                                        
                                        <th>District</th>
                                        <th>City</th>
                                         
                                        <th>Edit</th>
                                        <th>Delete</th>

                                      
                                        
                      </tr>
                    </tfoot>

                    </FooterTemplate>
                          </asp:Repeater>    
          
                    <asp:HiddenField id="hStateId" runat="server" />
             
                
                  
                     
                   
                  </table>
             </section>
                
                        </ContentTemplate>
                                              </asp:UpdatePanel>
</asp:Content>
