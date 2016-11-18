<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewDispatchSummary.aspx.cs" Inherits="Dairy.Tabs.Administration.ViewDispatchSummary" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

     
    
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
             View Dispatch Summary
          </h1>

          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Administration</a></li>
            <li class="active">Dispatch Summary</li>
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
                <h3 class="box-title"> Dispatch Summary </h3>
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
                      <asp:DropDownList ID="dpagentRoute" class="form-control" DataTextField="Name" DataValueField="RouteID" runat="server"  > 
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->
                         </div>

            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <i class="fa fa-rode"></i><span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:DropDownList ID="dpCategory" ValidationGroup="search" class="form-control" DataTextField="Name" DataValueField="CategoryId" runat="server"  > 
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->
                         </div>
 
          
             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <asp:Button ID="btnSearch" class="btn btn-primary" ValidationGroup="search" runat="server" CommandName="MoveNext" Text="Search" OnClick="btnSearch_Click" />     
                       &nbsp;
                        <asp:Button ID="btnPrintSummary" class="btn btn-primary" runat="server" CommandName="MoveNext" Text="Print" OnClientClick="return PrintPanel();" />
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

         
                       
                <div class="box-body" id="datalist">

                <asp:UpdatePanel runat="server" ID="uprouteList" UpdateMode="Conditional">
                    <ContentTemplate>

                <table id="example1" class="table table-bordered table-striped">
                   

                 

                <asp:Repeater ID="rpRouteList" runat="server" OnItemCommand="rpRouteList_ItemCommand">
                
               <HeaderTemplate>
                  <thead>
                      <tr>
                          <th>Dispatch ID</th>
                          <th>Dispatch Date</th>
                          <th>Brand </th>
                          <th>View</th>
                                                     
                      </tr>
                    </thead>
                    <tbody>

                   
               </HeaderTemplate>
               <ItemTemplate>
                    <tr style="text-align:left">
                        <td>DS<%# Eval("DI_Id")%></td>
                        <td><%# Eval("DispatchDate")%></td>
                        <td><%# Eval("CategoryName")%></td>
                        
                        <td>

                             <asp:LinkButton ID="lbEdite" AlternateText="Edit" ForeColor="Gray" OnItemCommand="lbEdite_ItemCommand" 
                                                                    ToolTip="Edit" runat="server" CommandArgument='<%#Eval("DI_Id") %>'
                                                                    CommandName="View" ><i class="fa fa-edit"></i></asp:LinkButton>

                         </td>
                         
                    </tr>
               </ItemTemplate>
                    <FooterTemplate>

                         </tbody>

                    <tfoot>
                      <tr>
                           <th>Dispatch ID</th>
                          <th>Dispatch Date</th>
                          <th>Brand</th>
                          <th>View</th>
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
            
            <asp:UpdatePanel runat="server" ID="upGatePass" UpdateMode="Conditional">
                    <ContentTemplate>
                    <asp:Panel runat="server" ID="pnlGatePass">
                        <asp:Literal runat="server" ID="GatePass"></asp:Literal>
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
    <script type = "text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("<%=pnlDispatchSummary.ClientID %>");
            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write("<html> <head> <style type='text/css'>.style1{border-collapse:collapse;} .control-sidebar{display:none;}</style>");
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
</asp:Content>
