<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cashier.aspx.cs" Inherits="Dairy.Tabs.Cashier.Cashier" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
      <script type="text/javascript" src="../../Theme/bootstrap/js/bootstrap.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
       <script type="text/javascript" src="../../Theme/bootstrap/js/bootstrap.min.js"></script>
     <script type="text/javascript">
      Sys.WebForms.PageRequestManager.getInstance().add_endRequest(InIEvent);
      function InIEvent() {

          $(function () {
              $("#example1").DataTable();
              $('#example').DataTable({
                  "paging": false,
                  "lengthChange": false,
                  "searching": true,
                  "ordering": true,
                  "info": true,
                  "autoWidth": false
              });
          });
      }
    </script>
   
    <section class="content-header">
          <h1>
             Cashier Settlement
          </h1>

          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Administration</a></li>
            <li class="active">Cashier Settlement</li>
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

          

               <div class="box ">
            <div class="box-header with-border">
                <h3 class="box-title"> Sales List </h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-minus"></i></button>
                
              </div>
            </div>
           
                       
        
               <div class="box-body">
               
              
                      <asp:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Conditional">
                    <ContentTemplate>           
        
               <div class="box  box-default" style="margin-bottom:5px !important;" >
        <div class="box-header" style="padding:0px 0px 0px 10px !important">
          
        </div><!-- /.box-header -->
        <div class="box-body">

             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtOrderDate" class="form-control"  type="date" placeholder="Dispatched Date" ToolTip="Order Date" runat="server" required ValidationGroup="search"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 

            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <i class="fa fa-road"></i><span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:DropDownList ID="dpBrand" class="form-control" DataTextField="Name" DataValueField="Id" runat="server" OnSelectedIndexChanged="dpBrand_SelectedIndexChanged" AutoPostBack="true" > 
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->
                         </div>

            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <i class="fa fa-road"></i><span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:DropDownList ID="dpRoute" class="form-control" DataTextField="Name" DataValueField="Id" runat="server" OnSelectedIndexChanged="dpRoute_SelectedIndexChanged" AutoPostBack="true" > 
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->
                         </div>
           
              <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <i class="fa fa-road"></i><span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:DropDownList ID="dpSalesman" class="form-control" DataTextField="Name" DataValueField="EmployeeId" runat="server"  > 
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->
                         </div>


               <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <asp:Button ID="btnSearch" class="btn btn-primary" ValidationGroup="search" runat="server" CommandName="MoveNext" Text="Search" OnClick="btnSearch_Click" />     
                        &nbsp;&nbsp;&nbsp; <asp:Button ID="btnSubmit" class="btn btn-primary"  runat="server" CommandName="MoveNext"  Text="Payment" OnClick="btnSubmit_Click" />   
                           &nbsp;&nbsp;&nbsp; <asp:Button ID="btnRefress" class="btn btn-primary"  runat="server" CommandName="MoveNext"  Text="Refresh" OnClick="btnRefress_Click" />       
                       
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     <asp:HiddenField ID="hfExcessFlag" runat="server" Value="0" />
                       
                          
                      </div> 

            
                  
        </div><!-- /.box-body -->
      </div>
                     
                    </ContentTemplate>
                </asp:UpdatePanel>
                 
           </div><!-- /.box-body --> 
                       <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
            <ProgressTemplate>
                
                <div class="overlay">
                  <i class="fa fa-refresh fa-spin"></i>
                </div>

            </ProgressTemplate>
            </asp:UpdateProgress>

         <asp:UpdatePanel ID="upModal" runat="server" UpdateMode="Conditional" >  
              <ContentTemplate>         
                      <!-- Modal -->
        <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" data-backdrop="false">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title" id="myModalLabel">Payment Denomination</h4>
      </div>
      <div class="modal-body">
          <div class="box-body">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server" >  
              <ContentTemplate> 
           
              <table class="table table-bordered table-striped">
                  <tr>
                      <td colspan="10"><asp:Label ID="lblvalidate" ForeColor="Red" runat="server"> </asp:Label></td>
                   
                  </tr>
        <tr>
<td><asp:Label ID="lbl2000" runat="server"> </asp:Label></td>
 <td><asp:Label ID="lbl1000" runat="server"></asp:Label></td>
<td><asp:Label ID="lbl500" runat="server" ></asp:Label></td>
 <td><asp:Label ID="lbl100" runat="server"></asp:Label></td>
 <td><asp:Label ID="lbl50" runat="server"></asp:Label></td>
 <td><asp:Label ID="lbl20" runat="server"></asp:Label></td>
 <td><asp:Label ID="lbl10" runat="server"></asp:Label></td>
 <td><asp:Label ID="lbl5" runat="server"></asp:Label></td>
 <td><asp:Label ID="lbl2" runat="server"></asp:Label></td>
 <td><asp:Label ID="lblcoins" runat="server"></asp:Label></td>
 <td>Total Amount: <asp:Label ID="lbltotalamt" runat="server"></asp:Label></td>
        </tr>
                  </table>
         
               <div class="col-lg-6">
                  <div class="form-group" >
                    <div class="input-group">
                      <div class="input-group-addon">
                       NetAmt
                      </div>
                       <asp:TextBox ID="txtNetAmt" class="form-control" step="any" type="number"   ToolTip="Net Amount" placeholder="Net Amount" runat="server" disabled></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
    
                      </div>        <!-- -->
                  <div class="col-lg-6">
                  <div class="form-group" >
                    <div class="input-group">
                      <div class="input-group-addon">
                     PaidAmt
                      </div>
                       <asp:TextBox ID="txttotalPay" class="form-control" step="any"  type="number"  ToolTip="Total Pay Amount" placeholder="Pay Amount" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
    
                      </div>        <!-- -->

               <div class="col-lg-6">
                  <div class="form-group" >
                    <div class="input-group">
                      <div class="input-group-addon">
                      Pending
                      </div>
                       <asp:TextBox ID="txtPendingTotal" class="form-control" step="any" type="number"  ToolTip="Total Pending Amount" placeholder="Pending Amount" runat="server" disabled></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
    
                      </div>
                <div class="col-lg-6">
                  <div class="form-group" >
                    <div class="input-group">
                      <div class="input-group-addon">
                     Rs.2000 *
                      </div>
                       <asp:TextBox ID="txt2000" class="form-control" ToolTip="Pieces" min="0" type="number" placeholder="Pieces" runat="server" OnTextChanged="txt2000_TextChanged"  AutoPostBack="true" > </asp:TextBox>                       
                        </div><!-- /.input group -->
                     </div><!-- /.form group -->
    
                      </div>        <!-- --> 

                    <div class="col-lg-6">
                  <div class="form-group" >
                    <div class="input-group">
                      <div class="input-group-addon">
                      Rs.1000 *
                      </div>
                       <asp:TextBox ID="txt1000" class="form-control"  type="number"  min="0"  ToolTip="Pieces" placeholder="Pieces" OnTextChanged="txt1000_TextChanged" runat="server"  AutoPostBack="true"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
    
                      </div>        <!-- -->

                <div class="col-lg-6">
                  <div class="form-group" >
                    <div class="input-group">
                      <div class="input-group-addon">
                       Rs.500 *
                      </div>
                       <asp:TextBox ID="txt500" class="form-control" type="number"  min="0"  ToolTip="Pieces" placeholder="Pieces" OnTextChanged="txt500_TextChanged" AutoPostBack="true" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
    
                      </div>        <!-- -->

                <div class="col-lg-6">
                  <div class="form-group" >
                    <div class="input-group">
                      <div class="input-group-addon">
                      Rs.100 *
                      </div>
                       <asp:TextBox ID="txt100" ToolTip="Pieces" type="number"  min="0"  class="form-control"   placeholder="Pieces" runat="server" OnTextChanged="txt100_TextChanged" AutoPostBack="true"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
    
                      </div>        <!-- -->

                    <div class="col-lg-6">
                  <div class="form-group" >
                    <div class="input-group">
                      <div class="input-group-addon">
                       Rs.50 *
                      </div>
                       <asp:TextBox ID="txt50" class="form-control" type="number"  min="0"  ToolTip="Pieces" placeholder="Pieces" runat="server" AutoPostBack="true" OnTextChanged="txt50_TextChanged"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
    
                      </div>        <!-- -->

                     <div class="col-lg-6">
                  <div class="form-group" >
                    <div class="input-group">
                      <div class="input-group-addon">
                      Rs.20 *
                      </div>
                       <asp:TextBox ID="txt20" class="form-control" type="number"  min="0"  ToolTip="Pieces" placeholder="Pieces" runat="server" OnTextChanged="txt20_TextChanged" AutoPostBack="true" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
    
                      </div>        <!-- -->
               <div class="col-lg-6">
                  <div class="form-group" >
                    <div class="input-group">
                      <div class="input-group-addon">
                      Rs.10 *
                      </div>
                       <asp:TextBox ID="txt10" class="form-control" type="number"   min="0"  ToolTip="Pieces" placeholder="Pieces" runat="server" OnTextChanged="txt10_TextChanged" AutoPostBack="true" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
    
                      </div>        <!-- -->
                  <div class="col-lg-6">
                  <div class="form-group" >
                    <div class="input-group">
                      <div class="input-group-addon">
                      Rs.5 *
                      </div>
                       <asp:TextBox ID="txt5" class="form-control" type="number"   min="0"  ToolTip="Pieces" placeholder="Pieces" runat="server" OnTextChanged="txt5_TextChanged" AutoPostBack="true" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
    
                      </div>        <!-- -->
                  <div class="col-lg-6">
                  <div class="form-group" >
                    <div class="input-group">
                      <div class="input-group-addon">
                      Rs.2 *
                      </div>
                       <asp:TextBox ID="txt2" class="form-control" type="number"   min="0"  ToolTip="Pieces" placeholder="Pieces" runat="server" OnTextChanged="txt2_TextChanged" AutoPostBack="true" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
    
                      </div>        <!-- -->
                <div class="col-lg-6">
                  <div class="form-group" >
                    <div class="input-group">
                      <div class="input-group-addon">
                   Rs.1 *
                      </div>
                       <asp:TextBox ID="txtCoin" class="form-control" type="number" min="0"  ToolTip="Coins" placeholder="Coins" runat="server" OnTextChanged="txtCoin_TextChanged" AutoPostBack="true" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
    
                      </div>        <!-- -->
                   
          
              
                     <div class="col-lg-6">
                  <div class="form-group" >
                    <div class="input-group">
                      <asp:TextBox ID="txtHidden" class="form-control" Visible="false" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
    
                      </div>        <!-- -->
 </ContentTemplate>
             </asp:UpdatePanel> 
            </div>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
        <%--<button type="button" class="btn btn-primary" >Save changes</button>--%>
          <asp:Button ID="btnUpdate" class="btn btn-primary" runat="server" ValidationGroup="saved" OnClick="btnUpdate_Click" Text="Save changes"  OnClientClick="return confirm('Are u sure?');" />       
      </div>
    </div>
  </div>
</div>     

                  </ContentTemplate>
             </asp:UpdatePanel> 
                       
                <div class="box-body" id="datalist">

                <asp:UpdatePanel runat="server" ID="uprouteList" UpdateMode="Conditional">
                    <ContentTemplate>
<asp:Panel ID="Panel1" runat="server">
    <table class="table table-bordered table-striped">
        <tr>
            <td> Salesman Cr/Dbt: <asp:Label ID="lblSalesmanCr" runat="server" Font-Bold="True"> </asp:Label></td>
<td> Total Sales Amount : <asp:Label ID="Label1" runat="server" > </asp:Label></td>
 <td> Agent Cash Sales : <asp:Label ID="Label4" runat="server" Font-Bold="True" ForeColor="#003300"></asp:Label></td>
<td>Staff A/c :  <asp:Label ID="Label2" runat="server" >
</asp:Label></td>
 <td>  Agent A/C : <asp:Label ID="Label3" runat="server"></asp:Label></td>
 
        </tr>
         
        <tr>
<td colspan="4"> <asp:Label ID="lblerrormsg" runat="server" ForeColor="Red" > </asp:Label></td>
 
 
        </tr>
 
    </table>
 
</asp:Panel>

                <table id="example2" class="table table-bordered table-striped">
                   
                   <caption><b>Cash Sales</b></caption>

                <asp:Repeater ID="rpRouteList" runat="server" OnItemCommand="rpRouteList_ItemCommand">
                 
               <HeaderTemplate>
                  <thead>
                      <tr>
                       <th>Agent</th>
                       <th>Sales Amount</th>
                       <th>Balance Amount</th>
                       <th>Payment Amount</th>
                       <th>Pending Amount</th>
                                            
                      </tr>
                    </thead>
                    <tbody>

                   
               </HeaderTemplate>
               <ItemTemplate>
                    <tr>
                         <asp:HiddenField id="hfAgentId" runat="server" value='<%#Eval("AgentID") %>' />  
                        <asp:HiddenField id="hfDDId" runat="server" value='<%#Eval("OrderId") %>' />
                       <td><%# Eval("AgentCode")%>&nbsp;<%# Eval("AgentName")%></td>
                        
                         <td><%#Convert.ToDecimal(Eval("SalesAmt")).ToString("0.00")%></td>
                        <td><asp:TextBox ID="txtAgencySales" type="number" step="any" runat="server" ReadOnly="true" Text='<%#Convert.ToDecimal(Eval("AgencySale")).ToString("0.00")%>' ></asp:TextBox></td>
                       
                        <td><asp:TextBox ID="txtPayment" type="number" step="any" runat="server" OnTextChanged="txtPayment_TextChanged" AutoPostBack="true" Text='<%#Convert.ToDecimal(Eval("AgencySale")).ToString("0.00")%>'></asp:TextBox></td>
                      
                 
                         <td><asp:TextBox ID="txtPending" type="number" step="any" runat="server" ReadOnly="true" Text="0" ></asp:TextBox></td>
                    
                       
                         
                    </tr>
               </ItemTemplate>
                    <FooterTemplate>
                         <tr id="trEmpty" runat="server" visible="false"><td  align = "left" colspan="4"><h5> No records found.</h5></td> </tr>
                         <tr id="trEmpty1" runat="server" visible="false"><td  align = "left" colspan="4"><h5>Cashier settlement process done for selected salesman on selected date.</h5></td> </tr>
                         </tbody>

                    <tfoot>
                      <tr>
                       <th>Agent</th>
                       <th>Sales Amount</th>
                       <th>Balance Amount</th>
                       <th>Payment Amount</th>
                       <th>Pending Amount</th>
                      </tr>
                    </tfoot>

                    </FooterTemplate>
                                             
           </asp:Repeater>
                    <asp:HiddenField id="hfRow" runat="server" />
             
                
                  
                     
                   
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
     <asp:UpdatePanel ID="hfupdate" runat="server">
          <ContentTemplate>
          <asp:HiddenField ID="hftokanno" runat="server" />
              </ContentTemplate>
      </asp:UpdatePanel>  
     
    <script type="text/javascript">

        $(function () {
            //$("#MainContent_txtOrderDate").datepicker({ dateFormat: 'dd/mm/yy' });
            // $("#MainContent_txtEmployeeOrderDate").datepicker({ dateFormat: 'dd/mm/yy' });
            // $("#MainContent_txtCustamerorderDate").datepicker({ dateFormat: 'dd/mm/yy' });
            $('#myModal').on('shown.bs.modal', function () {
                $('#myInput').focus()
            })
        })
    </script>
    
    <script type="text/javascript">
        yepnope({ // or Modernizr.load
            test: Modernizr.inputtypes.date,
            nope: [
                'http://cdnjs.cloudflare.com/ajax/libs/jqueryui/1.11.2/jquery-ui.min.js',

                'http://cdnjs.cloudflare.com/ajax/libs/jqueryui/1.11.2/jquery-ui.min.css',
                'http://cdnjs.cloudflare.com/ajax/libs/jqueryui/1.11.2/jquery-ui.structure.min.css',
                'http://cdnjs.cloudflare.com/ajax/libs/jqueryui/1.11.2/jquery-ui.theme.min.css',

            ],

            callback: function (url) {

                if (url === 'http://cdnjs.cloudflare.com/ajax/libs/jqueryui/1.11.2/jquery-ui.min.js') {

                    var idx = 0;

                    $('input[type="date"]').each(function () {
                        var _this = $(this),
                            prefix = 'alt' + String(idx++) + '_',
                            _val = _this.val();

                        _this
                        .attr('placeholder', 'gg/mm/aaaa')
                        .attr('autocomplete', 'off')
                        .prop('readonly', true)
                        .after('<input type="text" class="altfield" id="' + prefix + this.attr('id') + '" name="' + this.attr('name') + '" value="' + _val + '">')
                        .removeAttr('name')
                        .val('')
                        .datepicker({
                            altField: '#' + prefix + _this.attr('id'),
                            dateFormat: 'dd-mm-yy',
                            altFormat: 'dd-mm-yy'
                        });

                        if (_val) {
                            this.datepicker('setDate', $.datepicker.parseDate('dd-mm-yy', val));
                        };
                    });


                    // min attribute
                    $('input[type="date"][min]').each(function () {
                        var _this = $(this);
                        this.datepicker("option", "minDate", $.datepicker.parseDate('dd/mm/yy', this.attr('min')));
                    });

                    // max attribute
                    $('input[type="date"][max]').each(function () {
                        var _this = $(this);
                        this.datepicker("option", "maxDate", $.datepicker.parseDate('dd/mm/yy', this.attr('max')));
                    });
                }
            }
        }); // end Modernizr.load
        </script>

   
     
      <script type = "text/javascript">
          function Confirms() {
           
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

        function Closepopup() {
            $('#myModal').modal('hide');

        }

    </script>
</asp:Content>
