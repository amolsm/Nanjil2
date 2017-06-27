<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgencyIcentivePayment.aspx.cs" Inherits="Dairy.Tabs.Marketing.AgencyIcentivePayment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
  
   <%--  <link href="../../Theme/MyJavaScript/bootstrap-select.min.css" rel="stylesheet" />
    <script type="text/javascript" src="../../Theme/MyJavaScript/bootstrap-select.min.js"></script>--%>
       
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 
    <section class="content-header">
          <h1>
            Agency Payment Details
            <small>Administration</small>
          </h1>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Administration</a></li>
            <li class="active">  Agency Payment Details</li>
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
              <div class="box collapsed-box">
            <div class="box-header with-border">
              <h3 class="box-title"><asp:Label runat="server" ID="lblHeaderTab" Text="Agency Payment Details"></asp:Label></h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-plus"></i></button>
                
              </div>
            </div>
            <div class="box-body">
               
              
                      <asp:UpdatePanel runat="server" ID="upMain" UpdateMode="Conditional">
                    <ContentTemplate>           
        
               <div class="box box-solid box-default" style="margin-bottom:5px !important;" >
        <div class="box-header" style="padding:0px 0px 0px 10px !important">
          <h3 class="box-title">Agency Payment Details</h3>
        </div><!-- /.box-header -->
        <div class="box-body">


               <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                         <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:DropDownList ID="dpAgent" CssClass="form-control"    data-live-search="true"  DataTextField="Name" DataValueField="AgentID" runat="server"> 
                       </asp:DropDownList>
                       
                         
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->
                         </div>
                <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
               <asp:Button ID="btnShowAgentDetails" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Show Details" ValidationGroup="Save" OnClick="btnShowAgentDetails_click" /> &nbsp;    
                </div>
                      </div>
                 </div>
            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                           <asp:Label ID="lblAgentId" runat="server"  Visible="false"></asp:Label>
                       &nbsp; &nbsp; &nbsp;
                            <asp:Label ID="lblTotalqtySales" runat="server"  Visible="false"></asp:Label>
                        </div>
                      </div>
                 </div>
            <div class="box-body" id="Div1">
                   
                
                       

                                <asp:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Conditional">
                    <ContentTemplate>

                <table id="example1" class="table table-bordered table-striped">
                   

                 

                <asp:Repeater ID="rpBrandInfo" runat="server" OnItemCommand="rpRouteList_ItemCommand">
                
               <HeaderTemplate>
                  <thead>
                      <tr>
                        
                          <th>TotalIncentiveAmt</th>
                          <th>Balance</th>
                          <th>CurrentIncentive</th>
                           <th>IncentivePaid</th>
                         <th>Save</th>
                        
                      </tr>
                    </thead>
                    <tbody>
               </HeaderTemplate>
               <ItemTemplate>
                    <tr>
                        <td>
                             <asp:TextBox runat="server" ID="txtTotalIncentiveAmt" ToolTip="TotalIncentiveAmt" ReadOnly="true" />
                                  </td>
                           <td>  <asp:TextBox runat="server" ID="TextBox1" ToolTip="Balance" ReadOnly="true" />
                                
                              
                                  </td>
                           <td> <asp:TextBox runat="server" ID="txtCurrentInsAmt" ToolTip="CurrentIncentive"  Text='<%#Eval("IncentiveAmt")%>' ReadOnly="true" />
                                  </td>
                            <td>  <asp:TextBox runat="server" ID="txtIncentivePaid" ToolTip="IncentivePaid"   />
                                  </td>
                        
                         <td>
                                <asp:HiddenField id="hfAgentId" runat="server" value='<%#Eval("AgentID") %>' />                 
                             <asp:LinkButton ID="lbEdite" Text="Save" ForeColor="Gray" OnItemCommand="lbEdite_ItemCommand" 
                                                                    ToolTip="Save" runat="server" CommandArgument='<%#Eval("AgentID") %>'
                                                                    CommandName="Edit"><i class="btn btn-primary" title="Save"></i></asp:LinkButton>

                         </td>
                        
                    </tr>
               </ItemTemplate>
                    <FooterTemplate>

                         </tbody>

                    <tfoot>
                      <tr>
                           
                         <th>TotalIncentiveAmt</th>
                          <th>Balance</th>
                          <th>CurrentIncentive</th>
                           <th>IncentivePaid</th>
                         <th>Save</th>
                         
                      </tr>
                    </tfoot>
                    </FooterTemplate>                                       
           </asp:Repeater>
                    <asp:HiddenField id="hfBrandId" runat="server" />                 
                  </table>
                        </ContentTemplate>
                </asp:UpdatePanel>

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
          </div><!-- /.box -->
               <div class="box ">
            <div class="box-header with-border">
              <h3 class="box-title"> Agency Payment ListDetails </h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-minus"></i></button>
                
              </div>
            </div>
            <div class="box-body" id="datalist">
                   
                
                       

                                <asp:UpdatePanel runat="server" ID="uprouteList" UpdateMode="Conditional">
                    <ContentTemplate>

             <%--   <table id="example1" class="table table-bordered table-striped">
                   

                 

                <asp:Repeater ID="rpBrandInfo" runat="server" OnItemCommand="rpRouteList_ItemCommand">
                
               <HeaderTemplate>
                  <thead>
                      <tr>
                          <th>Brand Id</th>
                         
                          <th>Brand Name</th>
                           <th>TIN Number</th>
                        <th>Created By</th>
                        <th>Created Date</th>
                           <th>Edit</th>
                          <th>Delete</th>
                      </tr>
                    </thead>
                    <tbody>
               </HeaderTemplate>
               <ItemTemplate>
                    <tr>
                         <td><%# Eval("CategoryId")%></td>
                        
                         <td><%# Eval("CategoryName")%></td>
                         <td><%# Eval("TinNumber")%></td>
                       <td><%# Eval("Name")%></td>
                      <td><%# Eval("CreatedDate")%></td>
                         <td>

                             <asp:LinkButton ID="lbEdite" AlternateText="Edit" ForeColor="Gray" OnItemCommand="lbEdite_ItemCommand" 
                                                                    ToolTip="Edit" runat="server" CommandArgument='<%#Eval("CategoryId") %>'
                                                                    CommandName="Edit"><i class="fa fa-edit"></i></asp:LinkButton>

                         </td>
                         <td>   <asp:LinkButton ID="lbdelete" AlternateText="delete" ForeColor="Gray" OnItemCommand="lbdelete_ItemCommand" 
                                                                    ToolTip="Delete" runat="server" CommandArgument='<%#Eval("CategoryId") %>'
                                                                    CommandName="delete"><i class="fa fa-trash"></i></asp:LinkButton>
</td>
                    </tr>
               </ItemTemplate>
                    <FooterTemplate>

                         </tbody>

                    <tfoot>
                      <tr>
                           <th>Brand Id</th>
                        
                          <th>Brand Name</th>
                         <th>TIN Number</th>
                        <th>Created By</th>
                        <th>Created Date</th>
                           <th>Edit</th>
                          <th>Delete</th>
                      </tr>
                    </tfoot>
                    </FooterTemplate>                                       
           </asp:Repeater>
                    <asp:HiddenField id="hfBrandId" runat="server" />                 
                  </table>--%>
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
                            dateFormat: 'dd/mm/yy',
                            altFormat: 'dd/mm/yy'
                        });

                        if (_val) {
                            this.datepicker('setDate', $.datepicker.parseDate('dd/mm/yy', val));
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
   
    <script type="text/javascript">
        $(document).ready(function () {
            $('.selectpicker').selectpicker();
        });
         
  $('.selectpicker').selectpicker({
      style:' class="col-lg-3"',
      size: 4
  });
          </script>
</asp:Content>

