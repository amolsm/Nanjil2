<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddReturnedItems.aspx.cs" Inherits="Dairy.Tabs.Despatch.AddReturnedItems" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">


   
    
     <script type="text/javascript" src="../../Theme/bootstrap/js/bootstrap.min.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   <script type="text/javascript" src="../../Theme/bootstrap/js/bootstrap.min.js"></script>
   

  
    <section class="content-header">
          <h1>
             Manage Returned Items
          </h1>

          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Dispatch</a></li>
            <li class="active">Manage Returned Items</li>
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
                <h3 class="box-title"> Orders List </h3>
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
                       <asp:TextBox ID="txtDispatchId" class="form-control"   placeholder="Dispatch Id" ToolTip="Dispatch Id" runat="server" required ValidationGroup="search" type="number"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 

          <%--   <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtOrderDate" class="form-control"  type="date" placeholder="Dispatched Date" ToolTip="Order Date" runat="server" required ValidationGroup="search"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> --%>

         <%--   <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <i class="fa fa-road"></i><span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:DropDownList ID="dpagentRoute" class="form-control" DataTextField="Name" DataValueField="RouteID" runat="server" OnSelectedIndexChanged="dpagentRoute_SelectedIndexChanged" AutoPostBack="true"> 
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->
                         </div>--%>

       <%--     <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <i class="fa fa-rode"></i><span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:DropDownList ID="dpCategory" ValidationGroup="search" class="form-control" DataTextField="Name" DataValueField="CategoryId" runat="server"  > 
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->
                         </div>--%>
       <%--        <div class="col-lg-3">
                  <div class="form-group" >
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtCatsearch" class="form-control" ValidationGroup="edit" ToolTip="Sample Return" placeholder="Sample Return" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
    
                      </div>        <!-- -->
            <div class="col-lg-3">
                  <div class="form-group" >
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="hfCustomerId" class="form-control" ValidationGroup="edit" ToolTip="Sample Return" placeholder="Sample Return" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
    
                      </div>        <!-- -->--%>
            
            <%--<div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <i class="fa fa-road"></i><span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:DropDownList ID="dpAgent" class="form-control" DataTextField="Name" DataValueField="AgentID" runat="server" AutoPostBack="true"  > 
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->
                         </div>--%>

           <%-- <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <i class="fa fa-rode"></i><span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:DropDownList ID="dpagentRoute" ValidationGroup="search" class="form-control" DataTextField="Name" DataValueField="RouteID" runat="server"  > 
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->
                         </div>--%>

             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <asp:Button ID="Button1" class="btn btn-primary" ValidationGroup="search" runat="server" CommandName="MoveNext" Text="Search" OnClick="btnClick_btnSearch" />     
                       &nbsp; &nbsp;
                         <asp:Button ID="btnFinalSubmit" class="btn btn-primary" ValidationGroup="search" runat="server" CommandName="MoveNext" Text="Submit" OnClick="btnFinalSubmit_Click" OnClientClick="ConfirmFinal()"/>     
                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 

            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                     
                       
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
            </div> 
                  
        </div><!-- /.box-body -->
      </div>
                     
                    </ContentTemplate>
                </asp:UpdatePanel>
                 
           </div><!-- /.box-body --> 
                       <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
            <ProgressTemplate>
                
                <div class="overlay">
                  <i class="fa fa-refresh fa-spin"></i>
                </div>

            </ProgressTemplate>
            </asp:UpdateProgress>

         <asp:UpdatePanel ID="upModal" runat="server" UpdateMode="Conditional" >  
              <ContentTemplate>         
                      <!-- Modal -->
        <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title" id="myModalLabel">Return Items Quantities</h4>
      </div>
      <div class="modal-body">
          <div class="box-body">
            
                <div class="col-lg-6">
                  <div class="form-group" >
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtOrderID" class="form-control" ToolTip="Order Id"  placeholder="Order ID" runat="server" ValidationGroup="edit" disabled ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
    
                      </div>        <!-- --> 

                <div class="col-lg-6">
                  <div class="form-group" >
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtAgentName" class="form-control" ValidationGroup="edit" ToolTip="Agent Name" placeholder="Agent Name" runat="server" disabled></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
    
                      </div>        <!-- -->

                <div class="col-lg-6">
                  <div class="form-group" >
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtCommodityName" ToolTip="Commodity Name" class="form-control" ValidationGroup="edit"  placeholder="Commodity Name" runat="server" disabled></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
    
                      </div>        <!-- -->

                    <div class="col-lg-6">
                  <div class="form-group" >
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtDispQuantity" class="form-control" ValidationGroup="edit" ToolTip="Dispatched Quantity" placeholder="Dispatched Quantity" runat="server" disabled></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
    
                      </div>        <!-- -->

                     <div class="col-lg-6">
                  <div class="form-group" >
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtSampleReturn" class="form-control" ValidationGroup="edit" ToolTip="Gift/Other"  placeholder="Gift/Other" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
    
                      </div>        <!-- -->

                     <div class="col-lg-6">
                  <div class="form-group" >
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtGoodQuality" class="form-control" ValidationGroup="edit" ToolTip="Return"  placeholder="Return" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
    
                      </div>        <!-- -->

                     <div class="col-lg-6">
                  <div class="form-group" >
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtSpotDamaged" class="form-control" ValidationGroup="edit" ToolTip="Spot Damaged" placeholder="Spot Damaged"  runat="server" ></asp:TextBox>                        
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

            </div>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
        <%--<button type="button" class="btn btn-primary" >Save changes</button>--%>
          <asp:Button ID="Button2" class="btn btn-primary" runat="server" ValidationGroup="saved" OnClick="btnClick_btnUpdate" Text="Save changes" UseSubmitBehavior="false"  data-dismiss="modal"/>       
      </div>
    </div>
  </div>
</div>     

                  </ContentTemplate>
             </asp:UpdatePanel> 
                       
                <div class="box-body" id="datalist">

                <asp:UpdatePanel runat="server" ID="uprouteList" UpdateMode="Conditional">
                    <ContentTemplate>

                <table id="example1" class="table table-bordered table-striped">
                   

                 

                <asp:Repeater ID="rpRouteList" runat="server" OnItemCommand="rpRouteList_ItemCommand">
                
               <HeaderTemplate>
                  <thead>
                      <tr>
                          <th>Dispatch ID</th>
                          <th>Bill No</th>
                          <th>Agent/Employee Name</th>
                                              
                          <th>Commodity Name</th>
                           <th>Product Name</th>   
                          <th>Dispatched Quantity</th>
                          <th>Gift/Other</th>
                          <th>Return</th>
                          <th>Spot Damaged</th>
                          <th>Edit</th>
                      </tr>
                    </thead>
                    <tbody>

                   
               </HeaderTemplate>
               <ItemTemplate>
                    <tr style="text-align:center">
                        <td>DS<%# Eval("DI_Id")%></td>
                        <td><%# Eval("BillNo")%></td>
                          <td> <%#(String.IsNullOrEmpty(Eval("AgentCode").ToString()) ? Eval("EmployeeCode") : Eval("AgentCode")) + " "%>
                              <%#(String.IsNullOrEmpty(Eval("AgentName").ToString()) ? Eval("EmployeeName") : Eval("AgentName"))%>
                          </td>
                          <td><%# Eval("CommodityName")%></td>
                        <td><%# Eval("ProductName")%></td>
                      
                        <td><%# Eval("DD_NewQuantity")%></td>
                        <td><%# Eval("DD_ReturnSample")%></td>
                        <td><%# Eval("DD_ReturnGoodQuality")%></td>
                        <td><%# Eval("DD_ReturnSpotDamaged")%></td>
                        <td>

                             <asp:LinkButton ID="lbEdite" AlternateText="Edit" ForeColor="Gray" OnItemCommand="lbEdite_ItemCommand" 
                                                                    ToolTip="Edit" runat="server" CommandArgument='<%#Eval("DispatchDetailsId") %>'
                                                                    CommandName="Edit" ><i class="fa fa-edit"></i></asp:LinkButton>

                         </td>
                         
                    </tr>
               </ItemTemplate>
                    <FooterTemplate>
                         <tr id="trEmpty" runat="server" visible="false"><td  align = "left" colspan="9"><h5> Manage Return Item Process is completed for this Dispatch ID  Or No records found. Please contact Admin.</h5></td> </tr>
                         </tbody>

                    <tfoot>
                      <tr>
                          <th>Dispatch ID</th>
                          <th>Bill No</th>
                          <th>Agent/Employee Name</th>
                            <th>Commodity Name</th>
                          <th>Product Name</th>                        
                        
                          <th>Dispatched Quantity</th>
                           <th>Gift/Other</th>
                          <th>Return</th>
                          <th>Spot Damaged</th>
                           <th>Edit</th>
                      </tr>
                    </tfoot>

                    </FooterTemplate>
                                             
           </asp:Repeater>
                    <asp:HiddenField id="hfRow" runat="server" />
             
                
                  
                     
                   
                  </table>
               
                
                        </ContentTemplate>
                </asp:UpdatePanel>
  
                <asp:UpdatePanel runat="server" ID="upDispatchSummary" UpdateMode="Conditional">
                    <ContentTemplate>
                    <asp:Panel runat="server" ID="pnlDispatchSummary">
                        <asp:Literal runat="server" ID="DispatchSummary"></asp:Literal>
              </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>
            


 


            </div><!-- /.box-body -->     
                       <asp:UpdateProgress ID="UpdateProgress3" runat="server" AssociatedUpdatePanelID="uprouteList">
            <ProgressTemplate>
                
                <div class="overlay">
                  <i class="fa fa-refresh fa-spin"></i>
                </div>

            </ProgressTemplate>
            </asp:UpdateProgress>       
          </div><!-- /.box -->
        </section>
    
     
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
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";

            <%--var sample = document.getElementById('<%=txtSampleReturn.ClientID %>').value;
            var Gq = document.getElementById('<%=txtGoodQuality.ClientID %>').value;
            var sd = document.getElementById('<%=txtSpotDamaged.ClientID %>').value;
            var dq = document.getElementById('<%=txtDispQuantity.ClientID %>').value;
            var temp = (sample + Gq + sd);

            if (sample < 0 || Gq < 0 || sd < 0) {
                alert("Please enter valid quantity");
                return false;
            }--%>
            //if (temp > dq )
            //{
            //    alert("Please enter valid quantity");
            //    return false;
            //}

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
     
    <script type = "text/javascript">
        function ConfirmFinal() {
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


  <%--  <script type="text/javascript">
        $(function () {
            $("[id$=txtCatsearch]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "AddReturnedItems.aspx/GetCustomers",
                        data: "{ 'prefix': '" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    label: item.split('-')[0],
                                    val: item.split('-')[1]
                                }
                            }))
                        },
                        error: function (response) {
                            alert(response.responseText);
                        },
                        failure: function (response) {
                            alert(response.responseText);
                        }
                    });
                },
                select: function (e, i) {
                    $("[id$=hfCustomerId]").val(i.item.val);
                },
                minLength: 1
            });
        });
    </script>--%>
     <script type = "text/javascript">
        


         //-->

         $(document).ready(function () {
             
             $('#example1').dataTable({
                 "bPaginate": false,
                 "paging": false

             });

         });
    </script>
      <script type = "text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("<%=pnlDispatchSummary.ClientID %>");
            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write("<html> <head> <style type='text/css'>.style1{border-collapse:collapse;}</style>");
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
</asp:Content>
