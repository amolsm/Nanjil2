<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddBank.aspx.cs" Inherits="Dairy.Tabs.Administration.AddBank" %>
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
             Bank  Information
            <small>Administration</small> 

          </h1> <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Administration</a></li>
            <li class="active">Add Bank Details</li>
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
              <h3 class="box-title"><asp:Label runat="server" ID="lblHeaderTab" Text="Add Bank Details"></asp:Label></h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-plus"></i></button>
                
              </div>
            &nbsp;</div>
            <div class="box-body">
               
              
                      <asp:UpdatePanel runat="server" ID="upMain" UpdateMode="Conditional">
                    <ContentTemplate>           
        
               <div class="box box-solid box-default" style="margin-bottom:5px !important;" >
        <div class="box-header" style="padding:0px 0px 0px 10px !important">
          <h3 class="box-title"> Bank Information </h3>
        </div><!-- /.box-header -->
        <div class="box-body">

            <div class="row">
            <div class="col-lg-4">
                  <div class="form-group" >
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-bank"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtBankName" class="form-control" placeholder="Bank Name" runat="server"  ToolTip="Enter Bank Name" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                        <asp:RequiredFieldValidator  ID="FieldValidator4" Display="Dynamic" 
    ValidationGroup="Save" runat="server" ControlToValidate="txtBankName" ForeColor="Red"
    ErrorMessage="Please Enter Bank Name "></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->

                     
                       
                          
                      </div>  

             <div class="col-lg-4" >
                  <div class="form-group" >
                    <div class="input-group">
                      <div class="input-group-addon">
                       <span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtbranchname" class="form-control" placeholder="Branch Name"  runat="server"   ToolTip="Enter Branch Name"></asp:TextBox>                        
                    </div><!-- /.input group -->
                        <asp:RequiredFieldValidator  ID="RequiredFieldValidator1" Display="Dynamic" 
    ValidationGroup="Save" runat="server" ControlToValidate="txtbranchname" ForeColor="Red"
    ErrorMessage="Please Enter Branch Name "></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->

                     
                       
                          
                      </div>
            
         

            
              <div class="col-lg-4">
                  <div class="form-group" >
                    <div class="input-group">
                      <div class="input-group-addon">
                       <span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtBranchAddress" class="form-control" placeholder="Branch Address"  runat="server"   ToolTip="Enter Branch Address" TextMode="MultiLine"></asp:TextBox>                        
                         
                    </div><!-- /.input group -->
                        <asp:RequiredFieldValidator  ID="RequiredFieldValidator2" Display="Dynamic" 
    ValidationGroup="Save" runat="server" ControlToValidate="txtBranchAddress" ForeColor="Red"
    ErrorMessage="Please Enter Branch Address "></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->

                     
                       
                          
                      </div>  
        </div>
              <div class="row">
               <div class="col-lg-4">
                  <div class="form-group" >
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-key"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtIfsc" class="form-control" placeholder="IFSC code"  runat="server"  ToolTip="Enter IFSC code" OnTextChanged="txtIfsc_TextChanged" AutoPostBack="true"></asp:TextBox>                        
                    </div><!-- /.input group -->
                        <asp:RequiredFieldValidator  ID="FieldValidator3" Display="Dynamic" 
    ValidationGroup="Save" runat="server" ControlToValidate="txtIfsc" ForeColor="Red"
    ErrorMessage="Please Enter IFSC Code "></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->

              </div>
                  
             <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      
                    
                      
                        <asp:Button ID="btnAddBankInfo" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Add" ValidationGroup="Save" OnClick="btnAddBankInfo_click" /> &nbsp;    
                        <asp:Button ID="btnupdatebankdetail" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Update" ValidationGroup="Save" OnClick="btnupdatebankdetail_click" />           
                      &nbsp;&nbsp; &nbsp;   <asp:Button ID="btnAddNew" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="AddNew"  OnClick="btnAddNew_Click" />   </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 

            </div>
              
        </div><!-- /.box-body -->
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
      
    
          

   
    <div class="box ">
            <div class="box-header with-border">
              <h3 class="box-title"> BankInformation List </h3>
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
                      <tr>
                                        <th>Bank Name</th>
                                        <th>Branch  Name</th>
                                        
                                        <th>BranchAddress</th>
                                        <th>IFSC Code</th>
                           <th>Edit</th>
                           <th>Delete</th>
                                        
                          
                      </tr>
                    </thead>
                    <tbody>

                   
               </HeaderTemplate>
               <ItemTemplate>
                    <tr>
                            


                                        <td><%# Eval("BankName")%></td>
                                        <td><%# Eval("BranchName")%></td>    
                                        <td><%# Eval("BranchAddress")%></td>
                                        <td><%# Eval("IFSCcode")%></td>
                                       
                                        
                                        
                                        
                         
                         <td>
                             <asp:LinkButton ID="lbEdite" AlternateText="Edit" ForeColor="Gray" OnItemCommand="lbEdite_ItemCommand" 
                                                                    ToolTip="Edit" runat="server" CommandArgument='<%#Eval("ID") %>'
                                                                    CommandName="Edit"><i class="fa fa-edit"></i></asp:LinkButton>

                         </td>
                         <td>   <asp:LinkButton ID="lbdelete" AlternateText="delete" ForeColor="Gray" OnItemCommand="lbdelete_ItemCommand" 
                                                                    ToolTip="Delete" runat="server" CommandArgument='<%#Eval("ID") %>'
                                                                    CommandName="delete"><i class="fa fa-trash"></i></asp:LinkButton>
</td>



                    </tr>
               </ItemTemplate>
                    <FooterTemplate>

                         </tbody>

                    <tfoot>
                      <tr>
                                     <th>Bank Name</th>
                                        <th>Branch  Name</th>
                                        
                                        <th>BranchAddress</th>
                                        <th>IFSC Code</th>
                                         
                                        <th>Edit</th>
                                        <th>Delete</th>

                                      
                                        
                      </tr>
                    </tfoot>

                    </FooterTemplate>
                                          </asp:Repeater>    
          
                    <asp:HiddenField id="hbankId" runat="server" />
             
                
                  
                     
                   
                  </table>
             </section>
                
                        </ContentTemplate>
                                              </asp:UpdatePanel>
                </div>
            <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="uprouteList">
            <ProgressTemplate>
                
                <div class="overlay">
                  <i class="fa fa-refresh fa-spin"></i>
                </div>

            </ProgressTemplate>
            </asp:UpdateProgress>
        </div>
          </section>
</asp:Content>
