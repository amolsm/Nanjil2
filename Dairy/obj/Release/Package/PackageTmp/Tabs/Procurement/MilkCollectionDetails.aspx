<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MilkCollectionDetails.aspx.cs" Inherits="Dairy.Tabs.Procurement.MilkCollectionDetails"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">

    
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
            <div class="box-body">
               
              
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
                       <asp:TextBox ID="txtDate" class="form-control" placeholder="Collection Date" runat="server" type="date"  ToolTip="Collection Date"></asp:TextBox>                        
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
                        <asp:DropDownList ID="dpSession" class="form-control"  runat="server" selected ToolTip="Select Session"> 
                            <asp:ListItem Value="0">Morning</asp:ListItem>
                            <asp:ListItem Value="1">Evening</asp:ListItem>
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
                       <asp:TextBox ID="txtBatch" class="form-control" placeholder="Batch" runat="server"  ToolTip="Batch"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group --> 
                          
                      </div>

              

            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                  Supplier
                      </div>
                        <asp:DropDownList ID="dpSupplier" class="form-control" DataTextField="Name" DataValueField="SupplierID" runat="server" selected ToolTip="Select Supplier"> 
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
                       <asp:TextBox ID="txtMilkCan" class="form-control" placeholder="No Of Cans" runat="server"  ToolTip="No Of Cans" Type="number" step="any"></asp:TextBox>                        
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->                   
                  </div> 
             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                 Milk Kg.
                      </div>
                       <asp:TextBox ID="txtMilkInKG" class="form-control" placeholder="Milk In Kg" runat="server" ToolTip="Milk In KG" AutoPostBack="true" OnTextChanged="txtMilkInKG_TextChanged"  Type="number" step="any" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group --> 
                          
                      </div> 
             
          
                 <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                      CLR Reading
                      </div>
                       <asp:TextBox ID="txtCLRReading" class="form-control" placeholder="CLR Reading"  runat="server" ToolTip="CLR Reading" Type="number" step="any"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div>  

              <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                   Fat Perc.
                      </div>
                       <asp:TextBox ID="txtFATPercentage" class="form-control" placeholder="FAT %" runat="server" AutoPostBack="true"  OnTextChanged="txtCLRReading_TextChanged"   ToolTip="FAT %" Type="number" step="any"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div>  
               <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                   Milk Ltr.
                      </div>
                       <asp:TextBox ID="txtMilkInLtr" class="form-control" placeholder="Milk In Liter" runat="server"  ToolTip="Milk In Liter" readonly ></asp:TextBox>                        
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->                   
                  </div>  
            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                  Actual Milk Ltr.
                      </div>
                       <asp:TextBox ID="txtActualMilkInLtr" class="form-control" placeholder="Actual Milk In Liter" runat="server"  ToolTip="Actual Milk In Liter" readonly ></asp:TextBox>                        
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

             <asp:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Conditional">
                     <ContentTemplate>
            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                    SNF %
                      </div>
                       <asp:TextBox ID="txtSNFPercentage" class="form-control" placeholder="SNF %" type="text" runat="server" ToolTip="SNF %"  readonly></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div>
            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                    TS %
                      </div>
                       <asp:TextBox ID="txtTSPercentage" class="form-control" placeholder="TS %" type="text" runat="server"  ToolTip="TS Percentage" readonly></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div>
            
            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                 Fat In Kg.
                      </div>
                       <asp:TextBox ID="txtFATInKG" class="form-control" placeholder="FAT In Kg" type="text" runat="server"  ToolTip="FAT In KG" readonly></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div>     
            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                    SNF In Kg.
                      </div> 
                       <asp:TextBox ID="txtSNFInKG" class="form-control" placeholder="SNF in KG" type="text" runat="server"  ToolTip="SNF In KG" readonly></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div>  
             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                   TS In Kg.
                      </div>
                       <asp:TextBox ID="txtTSKG" class="form-control" placeholder="TS in KG" type="text" runat="server"  ToolTip="TS In KG" readonly></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div>  
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
                      
                    
                      
                              <asp:Button ID="btnAddMilkCollection" class="btn btn-primary" runat="server" CommandName="MoveNext" OnClick="btnAddMilkCollection_Click"   Text="Add" ValidationGroup="Save" />     
                        <asp:Button ID="btnupdateMilkCollection" class="btn btn-primary" runat="server" CommandName="MoveNext"  OnClick="btnupdateMilkCollection_Click"  Text="Update" ValidationGroup="Save" />     
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
                        <th>FATPercentage</th> 
                        <th>FATInKG</th>
    
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
                      <td><%# Eval("MilkInKG")%></td>
                         <td><%# Eval("MilkInLtr")%></td>
                      <td><%# Eval("FATPercentage")%></td>
                     
                      <td><%# Eval("FATInKG")%></td>
                        
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
                        <th>FATPercentage</th> 
                        <th>FATInKG</th>
                          
                       
                       
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
    </script>
</asp:Content>
