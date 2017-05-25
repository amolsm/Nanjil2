<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MilkCollectionDetails.aspx.cs" Inherits="Dairy.Tabs.Procurement.MilkCollectionDetails"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript" src="Scripts/jquery-1.4.1.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   
 
    <script type="text/javascript">
        $(document).ready(function () {
           
           
            //$("#MainContent_btnAddMilkCollection").click(function () {
            //    debugger;
            //    $('#MainContent_dpSupplier option:selected').next().attr('selected', 'selected');
            //});
            //$("#MainContent_btnAddMilkCollection").on("click", function () {
            //    $optionSelected = $("#MainContent_dpSupplier > option:selected");
            //    $optionSelected.removeAttr("selected");
            //    $optionSelected.next("option").attr("selected", "selected");
            //});
          <%--  function autoHide() {  //hide after 3 seconds  
                debugger;
            setTimeout(function() {document.getlementById("<%=pnlError.ClientID%>").style.display='none';},3000);

}--%>
          

            $('#MainContent_txtCLRReading').change(function () {
            debugger;
                var clrread = 0;
                clrread = $("#MainContent_txtCLRReading").val();
                clrread = BreakUpSingleDecimalPlace(clrread);
                $("#MainContent_txtCLRReading").val(parseFloat(clrread).toFixed(1));

            });

            $('#MainContent_txtFATPercentage').change(function () {
                debugger;
                var fatprc = 0;
                fatprc = $("#MainContent_txtFATPercentage").val();
                fatprc = BreakUpSingleDecimalPlace(fatprc);
                $("#MainContent_txtFATPercentage").val(parseFloat(fatprc).toFixed(1));
            
            });

          
           
         

       
            $calculate = $('.cal');
            $calculate.blur(function () {
                debugger;
                

                var milkinkg = 0;
                var milkinltr = 0;
               
                var sum = 0;
                var afterbreaksum = 0;
                var actualmilkinltr = 0;
                //milkinkg = $("#MainContent_txtMilkInKG").val();
                //sum = milkinkg / 1.03;
                //$("#MainContent_txtMilkInLtr").val(parseFloat(sum).toFixed(2));
                //var milltr=$("#MainContent_txtMilkInLtr").val();
                //actualmilkinltr = BreakUpSingleDecimalPlace(milltr);
                //$("#MainContent_txtActualMilkInLtr").val(actualmilkinltr);
                milkinkg = $("#MainContent_txtMilkInKG").val();
                sum = milkinkg / 1.03;
                $("#MainContent_txtActualMilkInLtr").val(parseFloat(sum).toFixed(2));
                actualmilkinltr = $("#MainContent_txtActualMilkInLtr").val();
                var milltr = 0;
                milltr = BreakUpSingleDecimalPlace(actualmilkinltr);
                $("#MainContent_txtMilkInLtr").val(milltr);

                var fatinkg = 0;
                var fatperc = 0;
                fatperc=$("#MainContent_txtFATPercentage").val();
                fatinkg = (milkinkg * fatperc) / 100;
                $("#MainContent_txtFATInKG").val(parseFloat(fatinkg).toFixed(2));

                var snfperc = 0;
                var clr = 0;
                clr = $("#MainContent_txtCLRReading").val();
                if (clr == "") {
                    snfperc = 0.00;
                } else {
                    snfperc = (clr / 4) + (0.2 * fatperc) + 0.36;
                    debugger;
                    //snfperc = BreakUpSingleDecimalPlace(snfperc);
                    $("#MainContent_txtSNFPercentage").val(parseFloat(snfperc).toFixed(1));
                }

                var snfkg = 0;
                snfkg = (milkinkg * snfperc) / 100;
                $("#MainContent_txtSNFInKG").val(parseFloat(snfkg).toFixed(2));

                var tsperc = 0;
                tsperc = parseFloat(fatperc) + parseFloat(snfperc);
                $("#MainContent_txtTSPercentage").val(parseFloat(tsperc).toFixed(1));

                var tskg = 0;
                tskg = parseFloat(fatinkg) + parseFloat(snfkg);
                $("#MainContent_txtTSKG").val(parseFloat(tskg).toFixed(2));

              
            });
            function BreakUpSingleDecimalPlace(num) {
                var s = num;
                var  parts=[];
                parts = s.toString().split(".");
                var i1 = parts[0];
                var i2 = parts[1];
                debugger;
                var dec = i2.charAt(0);
                num = i1 + "." + dec;
                return num;
            }
        });
        $(function () {
            debugger;
            $('.cal:first').focus();
            var $inp = $('.cal');
            $inp.bind('keypress', function (e) {
                var n = $('.cal').length;
                var key = e.which;
                if (key == 13) {
                    e.preventDefault();
                    var nextIndex = $inp.index(this) + 1;
                    if (nextIndex < n) {
                        $('.cal')[nextIndex].focus();
                    }
                    else {
                      
                        $("#MainContent_btnAddMilkCollection").click();
                        //$("MainContent_dpSupplier").empty();
                                          
                        $("#MainContent_dpSupplier").focus();
                        //$('#MainContent_dpSupplier option:selected').next().attr('selected', 'selected');
                    }
                }
            });
           
            //$(".btnAddMilkCollection").focus(function (e) {
            //    if (e.which === 13) {
            //        $("#MainContent_btnAddMilkCollection").click();
            //    }
            //});

           

        });
    </script>
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
<%--     <script type="text/javascript">
         function calc() {
             var a = document.getElementById('txtMilkInKG');
             var b = (a / 1.03);
             document.getElementById('txtMilkInLtr').Value = b.toString();
             }
     </script>--%>
    <section class="content-header">
          <h1>
            Milk Collection Details
            <small>Procurement</small>
          </h1>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Procurement</a></li>
            <li class="active"> <asp:Label runat="server" ID="lblHeaderTab" Text="Add Milk Collection Details"></asp:Label> </li>
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
              <h3 class="box-title"><asp:Label ID="lblTabName" runat="server" Text="Add Milk Collection Details"></asp:Label> </h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-plus"></i></button>
                
              </div>
            </div>
            <div class="box-body" >
               
              
                      <asp:UpdatePanel runat="server" ID="upMain" UpdateMode="Conditional">
                    <ContentTemplate>           
        
               <div class="box box-solid box-default" style="margin-bottom:5px !important;" >
        <div class="box-header" style="padding:0px 0px 0px 10px !important">
          <h3 class="box-title">Milk Collection Details</h3>
        </div><!-- /.box-header -->
        <div class="box-body">
           

            
            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                      Date
                      </div>
                       <asp:TextBox ID="txtDate" class="form-control" placeholder="Collection Date" runat="server" type="date"  ToolTip="Collection Date"  ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group --> 
                          
                      </div>
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
                Shift
                      </div>
                        <asp:DropDownList ID="dpSession" class="form-control"  runat="server" selected ToolTip="Select Session"  OnSelectedIndexChanged="dpSession_SelectedIndexChanged" > 
                            <asp:ListItem Value="0">Select Session</asp:ListItem>
                            <asp:ListItem Value="1">Morning</asp:ListItem>
                            <asp:ListItem Value="2">Evening</asp:ListItem>
                       </asp:DropDownList>                          
                    </div><!-- /.input group -->

                  </div><!-- /.form group --> 
                          
                      </div> 
            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                   Batch
                      </div>
                       <asp:TextBox ID="txtBatch" class="form-control" placeholder="Batch" runat="server"  ToolTip="Batch"  OnTextChanged="txtBatch_TextChanged"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group --> 
                          
                      </div>

              

            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                  Supplier
                      </div>
                        <asp:DropDownList ID="dpSupplier" class="form-control" DataTextField="Name" DataValueField="SupplierID" runat="server" selected ToolTip="Select Supplier" > 
                       </asp:DropDownList>                          
                    </div><!-- /.input group -->

                  </div><!-- /.form group --> 
                          
                      </div> 
             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                No of Milk Can
                      </div>
                       <asp:TextBox ID="txtMilkCan"  class="form-control" placeholder="No Of Cans" runat="server"  ToolTip="No Of Cans" Type="number" min="0" step="any" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->                   
                  </div> 
             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                 Milk Kg.
                      </div>
                       <asp:TextBox ID="txtMilkInKG"   class="cal form-control"  placeholder="Milk In Kg" runat="server" ToolTip="Milk In KG"    Type="number" min="0" step="any"  ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group --> 
                          
                      </div> 
             
          
                 <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                      CLR Reading
                      </div>
                       <asp:TextBox ID="txtCLRReading"  class="cal form-control"  placeholder="CLR Reading"  runat="server" ToolTip="CLR Reading" Type="number" min="0" step="any"  ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div>  

              <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                   Fat %.
                      </div>
                       <asp:TextBox ID="txtFATPercentage"  class="cal form-control"  placeholder="FAT %" runat="server"   ToolTip="FAT %" Type="number" min="0" step="any"   ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div>  
               <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                           Actual Milk Ltr.
                 
                      </div>
                       <asp:TextBox ID="txtActualMilkInLtr"  class="form-control" placeholder="Actual Milk In Liter" runat="server" style="background-color:#F5F5F5" ToolTip="Actual Milk In Liter"></asp:TextBox>                        
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->                   
                  </div>  
            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                   Milk Ltr.
                      </div>
                       <asp:TextBox ID="txtMilkInLtr"  class="form-control" placeholder="Milk In Liter" runat="server"  style="background-color:#F5F5F5" ToolTip="Milk In Liter" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->                   
                  </div>  
        
           
       
            <%--<div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa  fa-code "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtSNF" class="form-control" placeholder="SNF" type="text" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div>  --%>

           <%--  <asp:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Conditional">
                     <ContentTemplate>--%>
            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        SNF %
                      </div>
                       <asp:TextBox ID="txtSNFPercentage"  class="form-control" placeholder="SNF %" type="text" runat="server" style="background-color:#F5F5F5" ToolTip="SNF %"  ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div>
            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                    TS %
                      </div>
                       <asp:TextBox ID="txtTSPercentage"  class="form-control" placeholder="TS %" type="text" runat="server" style="background-color:#F5F5F5" ToolTip="TS Percentage" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div>
            
            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                 Fat In Kg.
                      </div>
                       <asp:TextBox ID="txtFATInKG"  class="form-control" placeholder="FAT In Kg" type="text" runat="server" style="background-color:#F5F5F5" ToolTip="FAT In KG" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div>     
            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                    SNF In Kg.
                      </div> 
                       <asp:TextBox ID="txtSNFInKG"  class="form-control" placeholder="SNF in KG" type="text" runat="server" style="background-color:#F5F5F5" ToolTip="SNF In KG" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div>  
             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                   TS In Kg.
                      </div>
                       <asp:TextBox ID="txtTSKG"  class="form-control" placeholder="TS in KG" type="text" runat="server" style="background-color:#F5F5F5" ToolTip="TS In KG" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div>  
              <asp:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Conditional">
                     <ContentTemplate>
                             </ContentTemplate>
            </asp:UpdatePanel>
            
           

             <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
            <ProgressTemplate>
                
                <div class="overlay">
                  <i class="fa fa-refresh fa-spin"></i>
                </div>

            </ProgressTemplate>
            </asp:UpdateProgress>    
              <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      
                    
                      
                              <asp:Button ID="btnAddMilkCollection" class="cal btn btn-primary" runat="server" CommandName="MoveNext" OnClick="btnAddMilkCollection_Click"   Text="Add" ValidationGroup="Save" />     
                        <asp:Button ID="btnupdateMilkCollection" class="btn btn-primary" runat="server" CommandName="MoveNext"  OnClick="btnupdateMilkCollection_Click"  Text="Update" ValidationGroup="Save" />     
                         &nbsp;&nbsp;&nbsp; <asp:Button ID="btnAddNew" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Refresh"  OnClick="btnAddNew_Click" />                      
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
              <h3 class="box-title"> Supplier List </h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-minus"></i></button>
                
              </div>
            </div>
              <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                      Date
                      </div>
                       <asp:TextBox ID="txtDate1" class="form-control" placeholder="Collection Date" runat="server" type="date"  ToolTip="Collection Date"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group --> 
                          
                      </div>
            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                           
                  Route
                      </div>
                      <asp:DropDownList ID="dpRoute1" class="form-control" DataTextField="Name" DataValueField="RouteID" runat="server" selected ToolTip="Select Route"> 
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 
             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                Shift
                      </div>
                        <asp:DropDownList ID="dpSession1" class="form-control"  runat="server" selected ToolTip="Select Session"> 
                            <asp:ListItem Value="0">Morning</asp:ListItem>
                            <asp:ListItem Value="1">Evening</asp:ListItem>
                       </asp:DropDownList>                          
                    </div><!-- /.input group -->
        <%--<asp:RequiredFieldValidator InitialValue="0" ID="Req_ID" Display="Dynamic" 
                             ValidationGroup="Save" runat="server" ControlToValidate="dpSession1" ForeColor="Red"
                             ErrorMessage="Pls Select Session" style="font-size:12px;">
            </asp:RequiredFieldValidator>--%>
                  </div><!-- /.form group --> 
                          
                      </div> 
                <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                          <asp:Button ID="btnView" class="btn btn-primary" runat="server" CommandName="MoveNext" OnClick="btnView_Click"   Text="View"  />     
                       </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 
            <div class="box-body" id="datalist">

                                <asp:UpdatePanel runat="server" ID="uprouteList" UpdateMode="Conditional">
                    <ContentTemplate>

                <table id="example1" class="table table-bordered table-striped">
                   

                 

                <asp:Repeater ID="rpMilkCollectionList" runat="server" OnItemCommand="rpMilkCollectionList_ItemCommand">
                
               <HeaderTemplate>
                  <thead>
                      <tr>
                            <th>Date</th>
                          <th>Supplier</th>
                        <th>Route</th>
                        <th>MilkInKG </th>
                            <th>MilkInLtr </th>
                            <th>CLR</th>
                        <th>FATPercentage</th> 
                       <%-- <th>FATInKG</th>--%>
                            <th>SNF %</th>
                           <th>TS %</th>   
                           <th>Edit</th>
                       <%--   <th>Delete</th>--%>
                      </tr>
                    </thead>
                    <tbody>

                   
               </HeaderTemplate>
               <ItemTemplate>
                    <tr>
                          <td><%#  Convert.ToDateTime(Eval("_Date")).ToString("dd-MM-yyyy")%></td>
                         <td><%# Eval("SupplierCode")%>&nbsp;&nbsp;<%# Eval("SupplierName")%></td>
                      <td><%# Eval("RouteCode")%>&nbsp;&nbsp;<%# Eval("RouteName")%></td>
                      <td><%# Convert.ToDecimal(Eval("MilkInKG")).ToString("0.0")%></td>
                         <td><%# Convert.ToDecimal(Eval("MilkInLtr")).ToString("0.0")%></td>
                         <td><%# Convert.ToDecimal(Eval("CLRReading")).ToString("0.0")%></td>
                      <td><%# Convert.ToDecimal(Eval("FATPercentage")).ToString("0.0")%></td>
                        <%-- <td><%# Eval("FATInKG")%></td>--%>
                      <td><%# Convert.ToDecimal(Eval("SNFPercentage")).ToString("0.0")%></td>
                         <td><%# Convert.ToDecimal(Eval("TSPercentage")).ToString("0.0")%></td>
                     
                        
                         <td>

                             <asp:LinkButton ID="lbEdite" AlternateText="Edit" ForeColor="Gray" OnItemCommand="lbEdite_ItemCommand" 
                                                                    ToolTip="Edit" runat="server" CommandArgument='<%#Eval("CollectionID") %>'
                                                                    CommandName="Edit"><i class="fa fa-edit"></i></asp:LinkButton>

                         </td>
                         <%--<td>   <asp:LinkButton ID="lbdelete" AlternateText="delete" ForeColor="Gray" OnItemCommand="lbdelete_ItemCommand" 
                                                                    ToolTip="Delete" runat="server" CommandArgument='<%#Eval("CollectionID") %>'
                                                                    CommandName="delete"><i class="fa fa-trash"></i></asp:LinkButton>
</td>--%>
                    </tr>
               </ItemTemplate>
                    <FooterTemplate>

                         </tbody>

                    <tfoot>
                      <tr><th>Date</th>
                           <th>Supplier</th>
                        <th>Route</th>
                        <th>MilkInKG </th>
                           <th>MilkInLtr </th>
                           <th>CLR</th>
                        <th>FATPercentage</th> 
                       <%-- <th>FATInKG</th>--%>
                        <th>SNF %</th>
                           <th>TS %</th>   
                       
                       
                           <th>Edit</th>
                       <%--   <th>Delete</th>--%>
                      </tr>
                    </tfoot>

                    </FooterTemplate>
                                             
           </asp:Repeater>
                    <asp:HiddenField id="hfMilkCollectionID" runat="server" />
         
                
                  
                     
                   
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
          $("#btnAddNew").click(function (e) {
            // prevent from going to the page
            e.preventDefault();

            // get the href
            var href = $(this).attr("href");
            $("#pnlError").load(href, function () {
                // do something after content has been 
                
            });
          });

          $(document).ready(function () {
              $('#example1').dataTable({
                  "bPaginate": false,
                  "paging": false

              });
          });

          //$('#txtMilkInKG').bind('keyup', function (e) {

          //    if (e.keyCode === 13) { // 13 is enter key

          //        document.getElementById("txtCLRReading").focus();

          //    }

          //});

          //$('#txtCLRReading').bind('keyup', function (e) {

          //    if (e.keyCode === 13) { // 13 is enter key

          //        document.getElementById("txtFATPercentage").focus();

          //    }

          //});

          $('#dpRoute').bind('keyup', function (e) {

                  if (e.keyCode === 13) { // 13 is enter key

                      document.getElementById("dpSession").focus();

                  }

              });
    </script>
   
  

</asp:Content>
