<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IncentiveTarrif.aspx.cs" Inherits="Dairy.Tabs.Procurement.IncentiveTarrif" %>
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
    </script>
     <section class="content-header">
          <h1>
             Incentive Tariff
            <small>Procurement</small>
          </h1>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Incentive Tariff</a></li>
            <li class="active"> <asp:Label runat="server" ID="lblHeaderTab" Text="Vehicle Tariff"></asp:Label> </li>
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
              <h3 class="box-title"><asp:Label ID="lblTabName" runat="server" Text="Incentive Tariff"></asp:Label> </h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-plus"></i></button>
                
              </div>
            </div>
            <div class="box-body">
               
              
                      <asp:UpdatePanel runat="server" ID="upMain" UpdateMode="Conditional">
                    <ContentTemplate>           

        <div class="box box-solid box-default" style="margin-bottom:5px !important;" >
        <div class="box-header" style="padding:0px 0px 0px 10px !important">
          <h3 class="box-title"> Incentive Tariff</h3>
        </div><!-- /.box-header -->
        <div class="box-body">
            <div class="row">
            <div class="col-lg-4" >
                  <div class="form-group"style="margin-bottom:10px">
                    <div class="input-group">
                      <div class="input-group-addon">
                     Quantity Category
                      </div>
                       <asp:TextBox ID="txtQCat" class="form-control" placeholder="Quantity Category" runat="server"  AutoPostBack="true"></asp:TextBox>                        
                    </div><!-- /.input group -->
                       <asp:RequiredFieldValidator  ID="RequiredFieldValidator4" Display="Dynamic" 
    ValidationGroup="Save" runat="server" ControlToValidate="txtQCat" ForeColor="Red"
    ErrorMessage="Please Enter Quantity Category  "></asp:RequiredFieldValidator>
                  </div><!-- /.form group --> 
                          
                      </div> 
             <div class="col-lg-4">
                  <div class="form-group" style="margin-bottom:10px">
                    <div class="input-group">
                      <div class="input-group-addon">
                        Quantity Low
                      </div>
                         <asp:TextBox ID="txtQLow" class="form-control" placeholder="Quantity Low" runat="server"  type="number" step="any" ></asp:TextBox>                                             
                    </div><!-- /.input group -->
                        <asp:RequiredFieldValidator  ID="RequiredFieldValidator1" Display="Dynamic" 
    ValidationGroup="Save" runat="server" ControlToValidate="txtQLow" ForeColor="Red"
    ErrorMessage="Please Enter Quantity Low   "></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 
             <div class="col-lg-4">
                  <div class="form-group" style="margin-bottom:10px">
                    <div class="input-group">
                      <div class="input-group-addon">
                      Quantity High
                      </div>
                       <asp:TextBox ID="txtQHigh" class="form-control" placeholder="Quantity High" runat="server"  type="number" step="any" ></asp:TextBox>                                             
                    </div><!-- /.input group -->
                        <asp:RequiredFieldValidator  ID="RequiredFieldValidator2" Display="Dynamic" 
    ValidationGroup="Save" runat="server" ControlToValidate="txtQHigh" ForeColor="Red"
    ErrorMessage="Please Enter Quantity High   "></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->                   
                  </div>  
                </div>
             <div class="row">
              <div class="col-lg-4">
                  <div class="form-group" style="margin-bottom:10px">
                    <div class="input-group">
                      <div class="input-group-addon">
                        Quantity Incentive
                      </div>
                       <asp:TextBox ID="txtQIncentive" class="form-control" placeholder="Quantity Incentive" runat="server"  type="number" step="any" ></asp:TextBox>                                             
                    </div><!-- /.input group -->
                       <asp:RequiredFieldValidator  ID="RequiredFieldValidator3" Display="Dynamic" 
    ValidationGroup="Save" runat="server" ControlToValidate="txtQIncentive" ForeColor="Red"
    ErrorMessage="Please Enter Quantity Incentive Amount   "></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->                   
                  </div>  

                              <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       Description
                      </div>
                       <asp:TextBox ID="txtDesc" class="form-control" placeholder="Description" runat="server"  ToolTip="Description"></asp:TextBox>                        
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->                   
                  </div>  


               <div class="col-lg-4">
                  <div class="form-group" style="margin-bottom:10px">
                    <div class="input-group">
                      <div class="input-group-addon">
                 Status
                      </div>
                        <asp:DropDownList ID="dpStatus" class="form-control" runat="server" ToolTip="Select Status">

                           <asp:ListItem Value="0">---Select Status---</asp:ListItem>
                           <asp:ListItem Value="1">Active</asp:ListItem>
                           <asp:ListItem Value="2">Deactive</asp:ListItem>
                       
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                       <asp:CompareValidator ID="CompareValidator" runat="server" ControlToValidate="dpStatus"
        ErrorMessage="Status is Required" Operator="NotEqual" ValidationGroup="Save" ForeColor="Red"
        ValueToCompare="0"></asp:CompareValidator>
                  </div><!-- /.form group -->
                         </div><!-- /.form group -->
                    <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                          <asp:Button ID="btnAddTariff" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Add" ValidationGroup="Save" OnClick="btnAddTariff_Click" />     
                        <asp:Button ID="btnupdateTariff" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Update" ValidationGroup="Save" OnClick="btnupdateTariff_Click" />           
                    &nbsp;&nbsp;&nbsp; <asp:Button ID="btnAddNew" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Add New"  OnClick="btnAddNew_Click" />                      

                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
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
              <h3 class="box-title">Incentive Tariff</h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-minus"></i></button>
                
              </div>
            </div>
            <div class="box-body" id="datalist">
                   
                
                       

                                <asp:UpdatePanel runat="server" ID="uprouteList" UpdateMode="Conditional">
                    <ContentTemplate>

                <table id="example1" class="table table-bordered table-striped">
                   

                 

                <asp:Repeater ID="rpIncentiveTariff" runat="server" OnItemCommand="rpIncentiveTariff_ItemCommand">
                
               <HeaderTemplate>
                  <thead>
                      <tr>
                          <th>ID</th>
                        <th>Quantity Category</th>
                        <th>Quantity Low</th>
                        <th>Quantity High</th>
                        <th>Quantity Incentive</th>
                         <th>IsActive</th>
                        <th>Edit</th>
                       <%-- <th>Delete</th>--%>
                      </tr>
                    </thead>
                    <tbody>

                   
               </HeaderTemplate>
               <ItemTemplate>
                    <tr>
                         <td><%# Eval("ID")%></td>
                      <td><%# Eval("QCat")%></td>
                      <td><%# Eval("QLow")%></td>
                      <td><%# Eval("QHigh")%></td>
                        <td><%# Eval("QIncentive") %></td>
                       
                      <td><%# Eval("IsActive") %></td>
                         <td>

                             <asp:LinkButton ID="lbEdite" AlternateText="Edit" ForeColor="Gray" OnItemCommand="lbEdite_ItemCommand" 
                                                                    ToolTip="Edit" runat="server" CommandArgument='<%#Eval("ID") %>'
                                                                    CommandName="Edit"><i class="fa fa-edit"></i></asp:LinkButton>

                         </td>
                       <%--  <td>   <asp:LinkButton ID="lbdelete" AlternateText="delete" ForeColor="Gray" OnItemCommand="lbdelete_ItemCommand" 
                                                                    ToolTip="Delete" runat="server" CommandArgument='<%#Eval("ID") %>'
                                                                    CommandName="delete"><i class="fa fa-trash"></i></asp:LinkButton>
</td>--%>
                    </tr>
               </ItemTemplate>
                    <FooterTemplate>

                         </tbody>

                    <tfoot>
                      <tr>
                          <th>ID</th>
                        <th>Quantity Category</th>
                        <th>Quantity Low</th>
                        <th>Quantity High</th>
                        <th>Quantity Incentive</th>
                         <th>IsActive</th>
                        <th>Edit</th>
                       <%-- <th>Delete</th>--%>
                      </tr>
                    </tfoot>

                    </FooterTemplate>
                                             
           </asp:Repeater>
                    <asp:HiddenField id="hftariff" runat="server" />
             
                
                  
                     
                   
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
