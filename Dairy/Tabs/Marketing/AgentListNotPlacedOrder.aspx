<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgentListNotPlacedOrder.aspx.cs" Inherits="Dairy.Tabs.Marketing.AgentListNotPlacedOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     
      <section class="content-header">
          <h1>
         Agent List Not Placed Order between two dates
             <small>Administration</small>  
          </h1> 
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Administration</a></li>
            <li class="active">  Agent List Not Placed Order between two dates </li>
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



           <div class="box  ">
            <div class="box-header with-border">
              <h3 class="box-title"><asp:Label ID="lbltital" runat="server" Text=" Agent List Not Placed Order "></asp:Label> </h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-plus"></i></button>
                
              </div>
            </div>
            <div class="box-body">
               
              
                      <asp:UpdatePanel runat="server" ID="upMain" UpdateMode="Conditional">
                    <ContentTemplate>           
        
             

             <div class="row">
                 
                             <div class="col-lg-3">
                  <div class="form-group" >
                    <div class="input-group">
                      <div class="input-group-addon">
                       Start Date
                      </div>
                       <asp:TextBox ID="txtStartDate" class="form-control"  type="date" placeholder="Date" runat="server"  ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div>       
                
                      <div class="col-lg-3">
                  <div class="form-group" >
                    <div class="input-group">
                      <div class="input-group-addon">
                       End Date
                      </div>
                       <asp:TextBox ID="txtEndDate" class="form-control"  type="date" placeholder="Date" runat="server"   ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div>       
                                  
           <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       Route
                      </div>
                      <asp:DropDownList ID="dpRoute" class="form-control" DataTextField="Name" DataValueField="RouteID" runat="server"  > 
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->
                         </div>
          
             
            
                 
                 <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                               <asp:Button ID="btnViewDetails" class="btn btn-primary" runat="server" CommandName="MoveNext"  OnClick="btnViewDetails_Click"  Text="View Details"    />     
                        &nbsp; <asp:Button ID="btnPrint" class="btn btn-primary" runat="server" CommandName="MoveNext" OnClientClick="return PrintPanel();"   Text="Print"    />     
                             
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 
                        
                        </div>
                        <asp:Panel runat="server" ID="pnlBill">
                        <asp:Literal runat="server" ID="genratedBIll"></asp:Literal>
              </asp:Panel>
       
                     
                    </ContentTemplate>
                </asp:UpdatePanel>
                 
                
            </div><!-- /.box-body -->            
          </div><!-- /.box -->
          

    </section>
     <script type = "text/javascript">
         function PrintPanel() {
             var panel = document.getElementById("<%=pnlBill.ClientID %>");
             var printWindow = window.open('', '', 'height=600,width=800');
             printWindow.document.write("<html> <head> <style type='text/css'>.style1{border-collapse:collapse;font-size: 14px; font-family: sans-serif;}</style>");
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
                         .attr('placeholder', 'dd-MM-yyyy')
                         .attr('autocomplete', 'off')
                         .prop('readonly', true)
                         .after('<input type="text" class="altfield" id="' + prefix + this.attr('id') + '" name="' + this.attr('name') + '" value="' + _val + '">')
                         .removeAttr('name')
                         .val('')
                         .datepicker({
                             altField: '#' + prefix + _this.attr('id'),
                             dateFormat: 'dd-MM-yyyy',
                             altFormat: 'dd-MM-yyyy'
                         });

                         if (_val) {
                             this.datepicker('setDate', $.datepicker.parseDate('dd-MM-yyyy', val));
                         };
                     });


                     // min attribute
                     $('input[type="date"][min]').each(function () {
                         var _this = $(this);
                         this.datepicker("option", "minDate", $.datepicker.parseDate('dd-MM-yyyy', this.attr('min')));
                     });

                     // max attribute
                     $('input[type="date"][max]').each(function () {
                         var _this = $(this);
                         this.datepicker("option", "maxDate", $.datepicker.parseDate('dd-MM-yyyy', this.attr('max')));
                     });
                 }
             }
         }); // end Modernizr.load
        </script>
</asp:Content>
