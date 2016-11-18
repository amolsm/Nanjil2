<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Transaction.aspx.cs" Inherits="Dairy.Tabs.Procurement.Transaction" %>
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
    </script>   <section class="content-header">
          <h1>
            Transaction
            <small>Procurement</small>
          </h1>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Procurement</a></li>
            <li class="active"> <asp:Label runat="server" ID="lblHeaderTab" Text="Add  Transaction"></asp:Label> </li>
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
              <h3 class="box-title"><asp:Label ID="lblTabName" runat="server" Text="Add  Transaction"></asp:Label> </h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-plus"></i></button>
                
              </div>
            </div>
            <div class="box-body">
               
              
                      <asp:UpdatePanel runat="server" ID="upMain" UpdateMode="Conditional">
                    <ContentTemplate>           

        <div class="box box-solid box-default" style="margin-bottom:5px !important;" >
        <div class="box-header" style="padding:0px 0px 0px 10px !important">
          <h3 class="box-title"> Transaction List</h3>
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
                   Payment Date
                      </div>
                      <asp:TextBox ID="txtpaymentdate" runat="server" class="form-control"  placeholder="Payment Date" ToolTip="Payment Date" type="date"></asp:TextBox>      
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->                   
                  </div>  
                  


                        <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                     From Date
                      </div>        
                      <asp:TextBox ID="txtfromdate" runat="server" class="form-control"  placeholder="From Date" ToolTip="From Date" type="date"></asp:TextBox>      

                  </div><!-- /.form group -->
                     </div> 
                        </div>
            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                     To Date
                      </div>        
                      <asp:TextBox ID="txttodate" runat="server" class="form-control"  placeholder="To Date" ToolTip="To Date" type="date"></asp:TextBox>      

                  </div><!-- /.form group -->
                     </div> 
                        </div>
              <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                           <asp:Button ID="btnShow" class="btn btn-primary" runat="server" CommandName="MoveNext" OnClick="btnShow_Click"   Text="Show" ValidationGroup="Save" /> 
                          &nbsp;  &nbsp; <asp:Button ID="btnAddTransaction" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Save All" ValidationGroup="Save" OnClick="btnAddTransaction_Click" />     
                         &nbsp;  &nbsp;<asp:Button ID="btnAddNew" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Add New"  OnClick="btnAddNew_Click" />     
                        </div>
                      </div>
                  </div>
        </div><!-- /.box-body -->

      </div>
               
                     
                    </ContentTemplate>
                </asp:UpdatePanel>
                 
                
            </div><!-- /.box-body -->            
          </div><!-- /.box -->

        <div class="box ">
            <div class="box-header with-border">
              <h3 class="box-title"> Transaction List</h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-minus"></i></button>
                
              </div>
            </div>
            <div class="box-body" id="datalist">
                   
                
                       

                                <asp:UpdatePanel runat="server" ID="uprouteList" UpdateMode="Conditional">
                    <ContentTemplate>

                <table id="example1" class="table table-bordered table-striped">
                   

                 

                <asp:Repeater ID="rpRouteList" runat="server" OnItemCommand="rpRouteList_ItemCommand">
                
               <HeaderTemplate>
                  <thead>
                      <tr>
                         
                        <th>SupplierID</th>
                      <%--  <th>PaymentDate</th>
                        <th>FromDate</th>
                        <th>ToDate</th>--%>
                        <th>Amount</th>
                        <th>Bonus</th>
                        <th>Scheme</th>
                        <th>RD</th>
                        <th>Can Loan</th>
                        <th>Cash Loan</th>
                        <th>Bank Loan</th>
                        <th>NetAmount</th>
                        <th>Save</th>
                       
                      </tr>
                    </thead>
                    <tbody>

                   
               </HeaderTemplate>
               <ItemTemplate>
                    <tr>
                            <td><%# Eval("SupplierID")%></td>
                          <%--  <td><%# txtpaymentdate.Text%></td>
                            <td><%# txtfromdate.Text%></td>
                            <td><%# txttodate.Text%></td>--%>
                          
                             <td><asp:TextBox runat="server" ID="txtAmt" style="width: 100px" ToolTip="Amount" class="txt" Text='<%#Eval("Amount")%>'/></td>
                             <td><asp:TextBox runat="server" ID="txtBonus" ToolTip="Bonus" style="width: 100px" class="txt" Text='<%#Eval("Bonus")%>'/></td>
                            <td><asp:TextBox runat="server" ID="txtScheme" ToolTip="Scheme" style="width: 100px" class="txt" Text='<%#Eval("Scheme")%>'/></td>
                            <td><asp:TextBox runat="server" ID="txtRD" ToolTip="RD" style="width: 100px" class="txt" Text='<%#Eval("RDAmount")%>'/></td>
                         <td><asp:TextBox runat="server" ID="txtcanloan" ToolTip="Can Loan" style="width: 100px" class="txt" Text='<%#Eval("CanLoan")%>'/></td>
                         <td><asp:TextBox runat="server" ID="txtcashloan" ToolTip="Can Loan" style="width: 100px" class="txt" Text='<%#Eval("CashLoan")%>'/></td>
                         <td><asp:TextBox runat="server" ID="txtbankloan" ToolTip="Can Loan" style="width: 100px" class="txt" Text='<%#Eval("BankLoan")%>'/></td>
                   
                           <td><asp:TextBox runat="server" ID="txtNetAmt" ToolTip="Net Amount" style="width: 100px" Text=""/></td>

                         <td>
                             <asp:HiddenField id="hfSupplierID" runat="server" value='<%#Eval("SupplierID") %>' /> 
                             <asp:LinkButton ID="lbEdite" AlternateText="Save" ForeColor="Gray" OnItemCommand="lbEdite_ItemCommand" 
                                                                    ToolTip="Save" runat="server" CommandArgument='<%#Eval("SupplierID") %>'
                                                                    CommandName="Edit"><i class="btn btn-primary"></i></asp:LinkButton>

                         </td>
                       
                    </tr>
               </ItemTemplate>
                    <FooterTemplate>

                         </tbody>

                    <tfoot>
                      <tr>
                        
                      <th>SupplierID</th>
                     <%--   <th>PaymentDate</th>
                        <th>FromDate</th>
                        <th>ToDate</th>--%>
                        <th>Amount</th>
                        <th>Bonus</th>
                        <th>Scheme</th>
                        <th>RD</th>
                        <th>Can Loan</th>
                        <th>Cash Loan</th>
                        <th>Bank Loan</th>
                        <th>NetAmount</th>
                        <th>Save</th>
                      </tr>
                    </tfoot>

                    </FooterTemplate>
                                             
           </asp:Repeater>
                    <asp:HiddenField id="hfsuppliersID" runat="server" />
             
                
                  
                     
                   
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
    <script>
        $(document).ready(function(){
            $(".txt").each(function() {

                $(this).keyup(function(){
                    calculateSum();
                });
            });

        });
        function calculateSum() {
            var sum = 0;
            var netamt = 0;
            //iterate through each textboxes and add the values
            $(".txt").each(function () {

                //add only if the value is number
                if (!isNaN(this.value) && this.value.length != 0) {
                    sum += parseFloat(this.value);
                }

            });
            //.toFixed() method will roundoff the final sum to 2 decimal places
            $("#txtNetAmt.Text").html(sum.toFixed(2));
        }
           </script>
</asp:Content>

