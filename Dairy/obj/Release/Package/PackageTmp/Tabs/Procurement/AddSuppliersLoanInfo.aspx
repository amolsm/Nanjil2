<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddSuppliersLoanInfo.aspx.cs" Inherits="Dairy.Tabs.Procurement.AddSuppliersLoanInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css">
    <script src="//code.jquery.com/jquery-1.10.2.js"></script>
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
    <script>
        function LoanBalance() {
            var x = document.getElementById('MainContent_txtLoanAmt').value;
            var y = document.getElementById('MainContent_txtInterest').value;
            var result = parseInt(x) + parseInt(y);
            document.getElementById('MainContent_txtLoanBalance').value = result;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 <%--    <script type="text/javascript">

         $(function () {
             $("#MainContent_txtLoanTakenDate").datepicker({ format: 'dd-MM-yyyy' });
         })

         
    </script>--%>
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
             Supplier Loan Information
            <small>Procurement</small>
          </h1>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Procurement</a></li>
            <li class="active"> <asp:Label runat="server" ID="lblHeaderTab" Text="Supplier Loan Info"></asp:Label> </li>
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
              <h3 class="box-title"><asp:Label ID="lblTabName" runat="server" Text="Add Supplier Loan"></asp:Label> </h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-plus"></i></button>
                
              </div>
            </div>
            <div class="box-body">
               
              
                      <asp:UpdatePanel runat="server" ID="upMain" UpdateMode="Conditional">
                    <ContentTemplate>           
        
               <div class="box box-solid box-default" style="margin-bottom:5px !important;" >
        <div class="box-header" style="padding:0px 0px 0px 10px !important">
          <h3 class="box-title">Supplier Loan Information </h3>
        </div><!-- /.box-header -->
        <div class="box-body">

                 <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                      Route
                      </div>
                      <asp:DropDownList ID="dpRoute" class="form-control" DataTextField="Name" DataValueField="RouteID" runat="server" selected ToolTip="Select Route" OnSelectedIndexChanged="dpRoute_SelectedIndexChanged" AutoPostBack="true"> 
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->

                     
                       
                          
                      </div>
             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       Supplier
                      </div>
                       <asp:DropDownList ID="dpSupplier" class="form-control" DataTextField="Name" DataValueField="SupplierID" runat="server" selected ToolTip="Select supplier"> 
                       </asp:DropDownList>                               
                    </div><!-- /.input group -->

                  </div><!-- /.form group --> 
                          
                      </div> 

             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                      Loan Type
                      </div>
                      <asp:DropDownList ID="ddLoanType" class="form-control" runat="server" OnSelectedIndexChanged="ddLoanType_SelectedIndexChanged" AutoPostBack="true">

                           <asp:ListItem>---Select LoanType---</asp:ListItem>
                           <asp:ListItem>Can</asp:ListItem>
                           <asp:ListItem>Cash</asp:ListItem>
                       <asp:ListItem>Bank</asp:ListItem>
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->

                     
                       
                          
                      </div>  
            
             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                     Loan A/C No.
                      </div>
                       <asp:TextBox ID="txtLoanAccountNo" class="form-control" placeholder="Loan Account No" ToolTip="Loan Account No" runat="server" Type="number"  ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div>    
             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        Loan Amount
                      </div>
                       <asp:TextBox ID="txtLoanAmt" class="form-control" placeholder="Loan Amount" runat="server"  ToolTip="Loan Amount" Type="number" step="any"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
                          
                      </div> 
            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                     Loan Taken Date
                      </div>
                       <asp:TextBox ID="txtLoanTakenDate" class="form-control" placeholder="Loan Taken Date" type="date" runat="server" ToolTip="Loan Taken Date" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div>  

             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        Loan Duration In Month
                      </div>
                       <asp:TextBox ID="txtLoanDuration" class="form-control" placeholder="Loan Duration In Months" ToolTip="Loan Duration In Months" runat="server" Type="number" step="any" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->                   
                  </div>  

             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                      Installment Amount
                      </div>
                       <asp:TextBox ID="txtLoadPaid" class="form-control" placeholder="Installment Amount" ToolTip="Installment Amount" Type="number" step="any" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 
            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       Interest
                      </div>
                       <asp:TextBox ID="txtInterest" class="form-control" placeholder="Interest" runat="server" Type="number" step="any" ToolTip="Interest" onblur="LoanBalance()"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div>     
             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       Loan Balance
                      </div>
                       <asp:TextBox ID="txtLoanBalance" class="form-control" placeholder="Loan Balance" runat="server" Type="number" step="any" ToolTip="Loan Balance"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group --> 
                          
                      </div> 
            
             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                      Loan Status
                      </div>
                      <asp:DropDownList ID="DropDownList1" class="form-control" runat="server">

                           <asp:ListItem>---Select Loan Status---</asp:ListItem>
                           <asp:ListItem>Open</asp:ListItem>
                           <asp:ListItem>Closed</asp:ListItem>
                       
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->

                     
                       
                          
                      </div>     
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
            <div class="col-lg-4">

             

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
           
    
               <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      
                    
                      
                              <asp:Button ID="btnLoanadd" class="btn btn-primary" runat="server" CommandName="MoveNext" OnClick="btnClick_btnLoanadd"   Text="Add" ValidationGroup="Save" />     &nbsp;&nbsp;
                        <asp:Button ID="btnLoanUpdate" class="btn btn-primary" runat="server" CommandName="MoveNext" OnClick="btnClick_btnLoanUpdate"   Text="Update" ValidationGroup="Save" />           
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
              <h3 class="box-title"> Suppliers Loan List </h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-minus"></i></button>
                
              </div>
            </div>
            <div class="box-body" id="datalist">
                   
                
                       

                                <asp:UpdatePanel runat="server" ID="uprouteList" UpdateMode="Conditional">
                    <ContentTemplate>

                <table id="example1" class="table table-bordered table-striped">
                   

                 

                <asp:Repeater ID="rpLoanInfoList" runat="server" OnItemCommand="rpLoanInfoList_ItemCommand">
                
               <HeaderTemplate>
                  <thead>
                      <tr>
                          <th>Supplier</th>
                          <th>Loan Type</th>
                        <th>Loan AccountNo</th>
                        <th>Loan Amount</th> 
                        <th>Loan Duration</th>
                          <th>Loan Status</th>
                           <th>Edit</th>
                          <th>Delete</th>
                      </tr>
                    </thead>
                    <tbody>

                   
               </HeaderTemplate>
               <ItemTemplate>
                    <tr>
                          <td><%# Eval("SupplierCode")%>&nbsp;&nbsp;<%# Eval("SupplierName")%></td>
                         <td><%# Eval("LoanType")%></td>
                      <td><%# Eval("LoanAccountNo")%></td>
                      <td><%# string.Format("{0:n2}",Eval("LoanAmount"))%></td>
                      <td><%# Eval("LoanDuration")%></td>
                     
                      <td><%# Eval("LoanStatus")%></td>
                   
                         <td>

                             <asp:LinkButton ID="lbEdite" AlternateText="Edit" ForeColor="Gray" OnItemCommand="lbEdite_ItemCommand" 
                                                                    ToolTip="Edit" runat="server" CommandArgument='<%#Eval("LoanID") %>'
                                                                    CommandName="Edit"><i class="fa fa-edit"></i></asp:LinkButton>

                         </td>
                         <td>   <asp:LinkButton ID="lbdelete" AlternateText="delete" ForeColor="Gray" OnItemCommand="lbdelete_ItemCommand" 
                                                                    ToolTip="Delete" runat="server" CommandArgument='<%#Eval("LoanID") %>'
                                                                  OnClientClick = "Confirm()"  CommandName="delete"><i class="fa fa-trash"></i></asp:LinkButton>
</td>
                    </tr>
               </ItemTemplate>
                    <FooterTemplate>

                         </tbody>

                    <tfoot>
                      <tr> <th>Supplier</th>
                           <th>Loan Type</th>
                        <th>Loan AccountNo</th>
                        
                        <th>Loan Amount</th> 
                        <th>Loan Duration</th>
                          <th>Loan Status</th>
                       
                       
                           <th>Edit</th>
                          <th>Delete</th>
                      </tr>
                    </tfoot>

                    </FooterTemplate>
                                             
           </asp:Repeater>
                    <asp:HiddenField id="hfLoanID" runat="server" />
             
                
                  
                     
                   
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
          </div><!-- /.box -->
        </section>
    <script type = "text/javascript">
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Do you want to delete data?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>
</asp:Content>
