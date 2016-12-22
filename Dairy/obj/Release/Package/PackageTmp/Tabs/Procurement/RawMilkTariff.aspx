<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RawMilkTariff.aspx.cs" Inherits="Dairy.Tabs.Procurement.RawMilkTariff" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css">
    <script src="//code.jquery.com/jquery-1.10.2.js"></script>
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%--<script type="text/javascript">

        $(function () {
            $("#MainContent_txtWEF_DATE").datepicker({ format: 'dd-MM-yyyy' });

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
             Raw Milk Tarrif
            <small>Procurement</small>
          </h1>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Procurement</a></li>
            <li class="active"> <asp:Label runat="server" ID="lblHeaderTab" Text="Raw Milk Tarrif"></asp:Label> </li>
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
              <h3 class="box-title"><asp:Label ID="lblTabName" runat="server" Text="Raw Milk Tarrif"></asp:Label> </h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-plus"></i></button>
                
              </div>
            </div>
            <div class="box-body">
               
              
                      <asp:UpdatePanel runat="server" ID="upMain" UpdateMode="Conditional">
                    <ContentTemplate>           

        <div class="box box-solid box-default" style="margin-bottom:5px !important;" >
        <div class="box-header" style="padding:0px 0px 0px 10px !important">
          <h3 class="box-title">Raw Milk Tarrif </h3>
        </div><!-- /.box-header -->
        <div class="box-body">
             <div class="row">
            <div class="col-lg-4">
               
                  <div class="form-group" style="margin-bottom:1px">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:DropDownList ID="Category" class="form-control" runat="server" selected  OnSelectedIndexChanged="Category_SelectedIndexChanged" AutoPostBack="true">

                           <asp:ListItem Value="0">---Select Category---</asp:ListItem>
                           <asp:ListItem Value="1">A</asp:ListItem>
                           <asp:ListItem Value="2">B</asp:ListItem>
                           <asp:ListItem Value="3">C</asp:ListItem>
                          <asp:ListItem Value="4">D</asp:ListItem>
                          <asp:ListItem Value="5">E</asp:ListItem>
                          <asp:ListItem Value="6">F</asp:ListItem>
                          <asp:ListItem Value="7">G</asp:ListItem>
                          <asp:ListItem Value="8">1</asp:ListItem>
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                          <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="Category"
        ErrorMessage="Category is Required" Operator="NotEqual" ValidationGroup="Save" ForeColor="Red"
        ValueToCompare="0" Display="None"></asp:CompareValidator>
                  </div><!-- /.form group -->

                     
                       
                          
                      </div>  
            <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <span style="color:red">&nbsp;*</span>
                      </div>
                  <asp:TextBox ID="txtTSL" class="form-control" placeholder="TSL" runat="server" type="number" step="any" ToolTip="TSL"></asp:TextBox>                        
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->

                     
                       
                          
                      </div>   
               
            <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <span style="color:red">&nbsp;*</span>
                      </div>
                    <asp:TextBox ID="txtTSH" class="form-control" placeholder="TSH" runat="server" type="number" step="any" ToolTip="TSH" ></asp:TextBox>                        
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->

                     
                       
                          
                      </div>  
          </div>
             
            <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtTSRate" class="form-control" placeholder="TS Rate" runat="server" type="number" step="any" ToolTip="TS Rate" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group --> 
                          
                      </div> 
            
              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTSRate"
        ErrorMessage="TS Rate is Required" ValidationGroup="Save" ForeColor="Red" Display="None"></asp:RequiredFieldValidator>
                       
           <%--  <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtTS_INCR" class="form-control" placeholder="TS_INCR" runat="server" required ToolTip="TS_INCR"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> --%>
             <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa  fa-code "></i></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtIncentive" class="form-control" placeholder="Incentive" runat="server"  ToolTip="Incentive" type="number" step="any"></asp:TextBox>                        
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->                   
                  </div>  
                  


                        <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                      <span style="color:red">&nbsp;*</span>
                      </div>        
                     <asp:TextBox ID="txtIN_FAT" class="form-control" placeholder="IN_FAT" runat="server"  ToolTip="IN_FAT" type="number" step="any"></asp:TextBox>                        

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 
                            </div>
             <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa  fa-code "></i></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtIN_SNF" class="form-control" placeholder="IN_SNF" runat="server"  ToolTip="IN_SNF" type="number" step="any"></asp:TextBox>                        
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->                   
                  </div>  
           

               
            <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:TextBox ID="txtIN_TS" class="form-control" placeholder="IN_TS" runat="server"  ToolTip="IN_TS" type="number" step="any"></asp:TextBox>                        
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->

                     
                       
                          
                      </div>     
            <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:TextBox ID="txtScheme" class="form-control" placeholder="Scheme" runat="server"  ToolTip="Scheme" type="number" step="any"></asp:TextBox>                        
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->

                     
                       
                          
                      </div>     
            <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:TextBox ID="txtBonus" class="form-control" placeholder="Bonus" runat="server"  ToolTip="Bonus" type="number" step="any"></asp:TextBox>                        
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->

                     
                       
                          
                      </div>     
            <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:TextBox ID="txtWEF_DATE" class="form-control" placeholder="WEF_DATE" runat="server" type="date"  ToolTip="WEF_DATE"></asp:TextBox>                        
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->

                     
                       
                          
                      </div>   
             <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
        ShowSummary="False" ValidationGroup="Save" />  
                   <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      
                    
                      
                              <asp:Button ID="btnAddRaw" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Add" ValidationGroup="Save" OnClick="btnAddRaw_Click" />     
                        <asp:Button ID="btnupdateRaw" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Update" ValidationGroup="Save" OnClick="btnupdateRaw_Click" /> 
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
              <h3 class="box-title"> Route List </h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-minus"></i></button>
                
              </div>
            </div>
            <div class="box-body" id="datalist">
                   
                
                       

                                <asp:UpdatePanel runat="server" ID="uprouteList" UpdateMode="Conditional">
                    <ContentTemplate>

                <table id="example1" class="table table-bordered table-striped">
                   

                 

                <asp:Repeater ID="rpRawMilkTarrif" runat="server" OnItemCommand="rpRawMilkTarrif_ItemCommand">
                
               <HeaderTemplate>
                  <thead>
                      <tr>
                          <th>Category</th>
                        <th>TSL</th>
                        <th>TSH</th>
                        <th>TS_RATE</th>
                  <%--      <th>TS_INCR</th>--%>
                        <th>Incentive</th>
                          <th>IN_FAT</th>
                          <th>IN_SNF</th>
                          <th>IN_TS</th>
                          <th>Scheme</th>
                          <th>Bonus</th>
                          <th>WEF_DATE</th>
                           <th>Edit</th>
                          <th>Delete</th>
                      </tr>
                    </thead>
                    <tbody>

                   
               </HeaderTemplate>
               <ItemTemplate>
                    <tr>
                         <td><%# Eval("CategoryName")%></td>
                      <td><%# Eval("TSL")%></td>
                      <td><%# Eval("TSH")%></td>
                      <td><%# Eval("TSRATE")%></td>
                     <%--   <td><%# Eval("TS_INCR") %></td>--%>
                        <td><%# Eval("Incentive") %></td>
                        <td><%# Eval("IN_FAT") %></td>
                        <td><%# Eval("IN_SNF") %></td>
                        <td><%# Eval("IN_TS") %></td>
                        <td><%# Eval("Scheme") %></td>
                      <td><%# Eval("Bonus") %></td>
                        <td><%# Convert.ToDateTime(Eval("WEF_DATE")).ToString("dd-MM-yyyy") %></td>

                         <td>

                             <asp:LinkButton ID="lbEdite" AlternateText="Edit" ForeColor="Gray" OnItemCommand="lbEdite_ItemCommand" 
                                                                    ToolTip="Edit" runat="server" CommandArgument='<%#Eval("RawMilkTarrifID") %>'
                                                                    CommandName="Edit"><i class="fa fa-edit"></i></asp:LinkButton>

                         </td>
                         <td>   <asp:LinkButton ID="lbdelete" AlternateText="delete" ForeColor="Gray" OnItemCommand="lbdelete_ItemCommand" 
                                                                    ToolTip="Delete" runat="server" CommandArgument='<%#Eval("RawMilkTarrifID") %>'
                                                                    CommandName="delete"><i class="fa fa-trash"></i></asp:LinkButton>
</td>
                    </tr>
               </ItemTemplate>
                    <FooterTemplate>

                         </tbody>

                    <tfoot>
                      <tr>
                           <th>Category</th>
                        <th>TSL</th>
                        <th>TSH</th>
                        <th>TS_RATE</th>
                   <%--     <th>TS_INCR</th>--%>
                        <th>Incentive</th>
                          <th>IN_FAT</th>
                          <th>IN_SNF</th>
                          <th>IN_TS</th>
                          <th>Scheme</th>
                          <th>Bonus</th>
                          <th>WEF_DATE</th>
                           <th>Edit</th>
                          <th>Delete</th>
                      </tr>
                    </tfoot>

                    </FooterTemplate>
                                             
           </asp:Repeater>
                    <asp:HiddenField id="hfrouteID" runat="server" />
             
                
                  
                     
                   
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
</asp:Content>
