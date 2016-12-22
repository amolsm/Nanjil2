<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddSupplierRDInfo.aspx.cs" Inherits="Dairy.Tabs.Procurement.AddSupplierRDInfo" %>
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
             Supplier RD Information
            <small>Procurement</small>
          </h1>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Procurement</a></li>
            <li class="active"> <asp:Label runat="server" ID="lblHeaderTab" Text="Add Supplier RD Information"></asp:Label> </li>
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
              <div class="box <%--collapsed-box--%>">
            <div class="box-header with-border">
              <h3 class="box-title"><asp:Label ID="lblTabName" runat="server" Text="Add Supplier RD Information"></asp:Label> </h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-plus"></i></button>
                
              </div>
            </div>
            <div class="box-body">
               
              
                      <asp:UpdatePanel runat="server" ID="upMain" UpdateMode="Conditional">
                    <ContentTemplate>           

        <div class="box box-solid box-default" style="margin-bottom:5px !important;" >
        <div class="box-header" style="padding:0px 0px 0px 10px !important">
          <h3 class="box-title">Supplier Advance Information </h3>
        </div><!-- /.box-header -->
        <div class="box-body">

            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                      Route
                      </div>
                      <asp:DropDownList ID="dpRoute" class="form-control" DataTextField="Name" DataValueField="RouteID" runat="server"  ToolTip="Select Route" AutoPostBack="true" OnSelectedIndexChanged="dpRoute_SelectedIndexChanged"> 
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                         <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator2" Display="Dynamic" 
                            ValidationGroup="Save" runat="server" ControlToValidate="dpRoute"
                            Text="Please Select Route" ErrorMessage="Please Select Route" ForeColor="Red"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->

                     
                       
                          
                      </div>  
            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       Supplier
                      </div>
                       <asp:DropDownList ID="dpSupplier" class="form-control" DataTextField="Name" DataValueField="SupplierID" runat="server"  ToolTip="Select supplier"> 
                       </asp:DropDownList>                               
                    </div><!-- /.input group -->
                        <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator1" Display="Dynamic" 
                            ValidationGroup="Save" runat="server" ControlToValidate="dpSupplier"
                            Text="Please Select Supplier" ErrorMessage="Please Select Supplier" ForeColor="Red"></asp:RequiredFieldValidator>
                  </div><!-- /.form group --> 
                          
                      </div> 
           
             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       RD Start Date
                      </div>
                       <asp:TextBox ID="txtRDStartDate" class="form-control" placeholder="RD Start Date" runat="server"  ToolTip="RD Start Date" type="date"></asp:TextBox>                        
                    </div><!-- /.input group -->
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Please Enter RD Start Date" ControlToValidate="txtRDStartDate" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 
             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       RD Maturity Date
                      </div>
                       <asp:TextBox ID="txtRDMaturityDate" class="form-control" placeholder="RD Maturity Date"  runat="server"  ToolTip="RD Maturity Date" type="date"></asp:TextBox>                        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please Enter RD Maturity Date" ControlToValidate="txtRDMaturityDate" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->

                     
                       
                          
                      </div>  
             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                     RD Amount
                      </div>
                       <asp:TextBox ID="txtRDAmount" class="form-control" placeholder="RD Amount" runat="server"  ToolTip="RD AMount" Type="number" step="any"></asp:TextBox>                        
                    </div><!-- /.input group -->
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please Enter RD Amount" ControlToValidate="txtRDAmount" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->                   
                  </div>  
       

            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                    RD RepaymetAmount 
                      </div>
                       <asp:TextBox ID="txtRDRepaymentAmount" class="form-control" placeholder="RD RePaymentAmount" runat="server"  ToolTip="RD RepaymentAmount" Type="number" step="any" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
                

                     
                       
                          
                      </div>                        
                  <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                 RD Status
                      </div>
                      <asp:DropDownList ID="DropDownList1" class="form-control" runat="server">

                           <asp:ListItem>---Select RD Status---</asp:ListItem>
                           <asp:ListItem>Active</asp:ListItem>
                           <asp:ListItem>InActive</asp:ListItem>
                       
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                       <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator5" Display="Dynamic" 
                            ValidationGroup="Save" runat="server" ControlToValidate="DropDownList1"
                            Text="Please Select RD Status" ErrorMessage="Please Select RD Status" ForeColor="Red"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->

                     
                       
                          
                      </div>
            
   <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                 RD RePayment Date
                      </div>
                       <asp:TextBox ID="txtRDPaymentDate" class="form-control" placeholder="RD RePayment Date" type="date" runat="server"  ToolTip="RD RePayment Date"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 
            <div id="divinvisible" runat="server" visible="false">
            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                     Bank Name
                      </div>
                    <asp:DropDownList  ID="dpBankName" ToolTip="Select Bank Name" class="form-control" DataTextField="Name"  runat="server"  > 
                       </asp:DropDownList> </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div>    
            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                     Account Name
                      </div>
                       <asp:TextBox ID="txtAccountName" class="form-control" placeholder="Account Name" ToolTip="Account Name" runat="server"  type="text"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 

              <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                      Account no.
                      </div>
                       <asp:TextBox ID="txtAccountNo" class="form-control" placeholder="Account No" ToolTip="Account No" runat="server"  type="text"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 
             <div class="col-lg-3">

             

                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                      IFSC Code
                      </div>
                     <asp:DropDownList  ID="dpIfscCode" ToolTip="Select IFSC Code" class="form-control" DataTextField="Name"  runat="server"  > 
                       </asp:DropDownList></div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                      </div>
            
            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                   Branch Name
                      </div>
                       <asp:TextBox ID="txtBranchName" class="form-control" placeholder="Branch Name" runat="server"  ToolTip="Branch Name"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div>  
                </div>   
            <div class="col-lg-3 pull-right">
                  <div class="form-group">
                    <div class="input-group">
                      
                    
                      
                              <asp:Button ID="btnAddRDInfo" class="btn btn-primary" runat="server" CommandName="MoveNext" OnClick="btnAddRDInfo_Click"  Text="Add" ValidationGroup="Save" />     
                        <asp:Button ID="btnupdateRDInfo" class="btn btn-primary" runat="server" CommandName="MoveNext" OnClick="btnupdateRDInfo_Click" Text="Update" ValidationGroup="Save" />           
                       &nbsp;&nbsp;&nbsp; <asp:Button ID="btnAddNew" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Add New"  OnClick="btnAddNew_Click" />                      
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
              <h3 class="box-title"> RD List </h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-minus"></i></button>
                
              </div>
            </div>
            <div class="box-body" id="datalist">
                   
                
                       

                                <asp:UpdatePanel runat="server" ID="uprouteList" UpdateMode="Conditional">
                    <ContentTemplate>

                <table id="example1" class="table table-borde table-striped">
                   

                 

                <asp:Repeater ID="rpRDInfo" runat="server" OnItemCommand="rpRDInfo_ItemCommand">
                
               <HeaderTemplate>
                  <thead>
                      <tr>
                          <th>Supplier</th>
                        <th>RD Start Date</th>
                        <th>RD Maturity Date</th> 
                        <th> RD Amount</th>
                          <th>RD RePaymentDate</th>
                            <th>RD STatus</th>
                           <th>Edit</th>
                       <%--   <th>Delete</th>--%>
                      </tr>
                    </thead>
                    <tbody>

                   
               </HeaderTemplate>
               <ItemTemplate>
                    <tr>
                         <td><%# Eval("SupplierCode")%>&nbsp;&nbsp;<%# Eval("SupplierName")%></td>
                      <td><%# Eval("RDStartDate")%></td>
                      <td><%# Eval("RDMaturityDate")%></td>
                      <td><%# string.Format("{0:n2}",Eval("RDAmount"))%></td>
                     
                      <td><%# Eval("RDPaymentDateTime")%></td>
                   <td><%# Eval("RDStatus")%></td>
                         <td>

                             <asp:LinkButton ID="lbEdite" AlternateText="Edit" ForeColor="Gray" OnItemCommand="lbEdite_ItemCommand" 
                                                                    ToolTip="Edit" runat="server" CommandArgument='<%#Eval("RDID") %>'
                                                                    CommandName="Edit"><i class="fa fa-edit"></i></asp:LinkButton>

                         </td>
                         <%--<td>   <asp:LinkButton ID="lbdelete" AlternateText="delete" ForeColor="Gray" OnItemCommand="lbdelete_ItemCommand" 
                                                                    ToolTip="Delete" runat="server" CommandArgument='<%#Eval("RDID") %>'
                                                                    CommandName="delete"><i class="fa fa-trash"></i></asp:LinkButton>
</td>--%>
                    </tr>
               </ItemTemplate>
                    <FooterTemplate>

                         </tbody>

                    <tfoot>
                      <tr>
                             <th>Supplier</th>
                        <th>RD Start Date</th>
                        <th>RD Maturity Date</th> 
                        <th> RD Amount</th>
                          <th>RD RePaymentDate</th>
                            <th>RD STatus</th>
                       
                       
                           <th>Edit</th>
                         <%-- <th>Delete</th>--%>
                      </tr>
                    </tfoot>

                    </FooterTemplate>
                                             
           </asp:Repeater>
                    <asp:HiddenField id="hfRDID" runat="server" />
             
                
                  
                     
                   
                  </table>
               
                
                        </ContentTemplate>
                </asp:UpdatePanel>
  


            </div><!-- /.box-body --> 
                       <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="uprouteList">
            <ProgressTemplate>
                
                <div class="overlay">
                  <i class="fa fa-refresh fa-spin"></i>
                </div>

            </ProgressTemplate>
            </asp:UpdateProgress>           
          </div>
        </section>
    <script type="text/javascript">
     $(document).ready(function () {
              $('#example1').dataTable({
                  "bPaginate": false,
                  "paging": false

              });
          });
    </script>
</asp:Content>
