<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VehicleMaster.aspx.cs" Inherits="Dairy.Tabs.Procurement.VehicleMaster" %>
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
             Vehicle Information
            <small>Procurement</small>
          </h1>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Procurement</a></li>
            <li class="active"> <asp:Label runat="server" ID="lblHeaderTab" Text="Vehicle Information"></asp:Label> </li>
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
              <h3 class="box-title"><asp:Label ID="lblTabName" runat="server" Text="Vehicle Information"></asp:Label> </h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-plus"></i></button>
                
              </div>
            </div>
            <div class="box-body">
               
              
                      <asp:UpdatePanel runat="server" ID="upMain" UpdateMode="Conditional">
                    <ContentTemplate>           

        <div class="box box-solid box-default" style="margin-bottom:5px !important;" >
        <div class="box-header" style="padding:0px 0px 0px 10px !important">
          <h3 class="box-title">Add Vehicle Info </h3>
        </div><!-- /.box-header -->
        <div class="box-body">
          
            <div class="row">
             <div class="col-lg-4">
                  <div class="form-group" style="margin-bottom:1px">
                    <div class="input-group">
                      <div class="input-group-addon">
                    Vehicle Model
                      </div>        
                     <asp:DropDownList ID="dpVehicleType" class="form-control" DataTextField="VehicleName" DataValueField="VahicleID" ToolTip="Select Vehicle Model" runat="server" selected> 
                       </asp:DropDownList>

                  </div><!-- /.form group -->

                     
                         <asp:CompareValidator ID="CompareValidator" runat="server" ControlToValidate="dpVehicleType"
        ErrorMessage="Vehicle Model is Required" Operator="NotEqual" ValidationGroup="Save" ForeColor="Red"
        ValueToCompare="0"></asp:CompareValidator>
                          
                      </div> 
                            </div>
             <div class="col-lg-4">
                  <div class="form-group"  style="margin-bottom:1px">
                    <div class="input-group">
                      <div class="input-group-addon">
                     Vehicle No.
                      </div>
                       <asp:TextBox ID="txtVehicleNo" class="form-control" placeholder="Vehicle No" runat="server"  ToolTip="Vehicle No" OnTextChanged="txtVehicleNo_TextChanged" AutoPostBack="true"></asp:TextBox>                        
                    </div><!-- /.input group -->
                       <asp:RequiredFieldValidator  ID="RequiredFieldValidator4" Display="Dynamic" 
    ValidationGroup="Save" runat="server" ControlToValidate="txtVehicleNo" ForeColor="Red"
    ErrorMessage="Please Enter Vehicle Number "></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 
             <div class="col-lg-4">
                  <div class="form-group" >
                    <div class="input-group">
                      <div class="input-group-addon">
                      Vehicle Owner Name
                      </div>
                       <asp:TextBox ID="txtOwnerName" class="form-control" placeholder="Vehicle Owner Name" runat="server"  ToolTip="Vehicle Owner Name"></asp:TextBox>                        
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->                   
                  </div>  
                  
</div>

           <div class="row">             
             <div class="col-lg-4">
                  <div class="form-group" style="margin-bottom:1px">
                    <div class="input-group" >
                      <div class="input-group-addon">
                    Owner Email Id
                      </div>
                       <asp:TextBox ID="txtOwnerEmail" class="form-control" placeholder="Owner Email" runat="server" ToolTip="Owner Email"></asp:TextBox>                        
                    </div><!-- /.input group -->
                       <asp:RegularExpressionValidator ID="valRegExEmail" runat="server" ControlToValidate="txtOwnerEmail"
                           ForeColor="Red"  ErrorMessage="Please give a valid email address" ValidationGroup="Save" ValidationExpression="^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z\.][a-zA-Z]{1,3}$"></asp:RegularExpressionValidator> 
                                       </div><!-- /.form group -->                   
                  </div>  
            <div class="col-lg-4">
                  <div class="form-group" style="margin-bottom:1px">
                    <div class="input-group">
                      <div class="input-group-addon">
                        Owner Mobile no.
                      </div>
                       <asp:TextBox ID="txtOwnerMobileNo" class="form-control" placeholder="Owner Mobile No"  runat="server" type="number" ToolTip="Owner Mobile No"></asp:TextBox>                        
                    </div><!-- /.input group -->
                       <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
      ControlToValidate="txtOwnerMobileNo" ErrorMessage="Please enter 10 digit mobile no." ForeColor="Red"
    ValidationExpression="[0-9]{10}" ></asp:RegularExpressionValidator>
                  </div><!-- /.form group -->                   
                  </div>  

            <%--<div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa  fa-code "></i></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtVehicleSrNo" class="form-control" placeholder="Vehicle Register No" runat="server" required ToolTip="Vehicle SrNo"></asp:TextBox>                        
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->                   
                  </div>  --%>

           
            <div class="col-lg-4">
                  <div class="form-group" >
                    <div class="input-group">
                      <div class="input-group-addon">
                     Driver Name
                      </div>
                       <asp:TextBox ID="txtDriverName" class="form-control" placeholder="Driver Name" runat="server"  ToolTip="Driver Name"></asp:TextBox>                        
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->                   
                  </div>  
               </div>
            <div class="row">
            <div class="col-lg-4">
                  <div class="form-group" style="margin-bottom:1px">
                    <div class="input-group">
                      <div class="input-group-addon">
                       Driver Mobile number
                      </div>
                       <asp:TextBox ID="txtDriverMobile" class="form-control" placeholder="Driver Mobile No" runat="server"  ToolTip="Driver Mobile No" type="number" step="10-11"></asp:TextBox>                        
                    </div><!-- /.input group -->
                         <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
      ControlToValidate="txtDriverMobile" ErrorMessage="Please enter 10 digit mobile no." ForeColor="Red"
    ValidationExpression="[0-9]{10}" ></asp:RegularExpressionValidator>
                  </div><!-- /.form group -->                   
                  </div>  

             <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                      Bank Name
                      </div>
                    <asp:DropDownList  ID="dpBankName" ToolTip="Select Bank Name" class="form-control" DataTextField="Name"  runat="server"  > 
                       </asp:DropDownList> </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div>   
            <div class="col-lg-4">

             

                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        IFSC Code
                      </div>
                     <asp:DropDownList  ID="dpIfscCode" ToolTip="Select IFSC Code" class="form-control" DataTextField="Name"  runat="server"  > 
                       </asp:DropDownList></div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                      </div> 
                </div>
            <div class="row">
                <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                    Branch Name
                      </div>
                       <asp:TextBox ID="txtBranchName" class="form-control" placeholder="Branch Name" runat="server"  ToolTip="Branch Name"></asp:TextBox>                        
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->                   
                  </div>  
            <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       A/C No.
                      </div>
                       <asp:TextBox ID="txtAccNo" class="form-control" placeholder="Account No" runat="server" Type="number"  ToolTip="Account No"></asp:TextBox>                        
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->                   
                  </div>  
         <%--    <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                      Tax Percentage
                      </div>
                       <asp:TextBox ID="txtTax" class="form-control" placeholder="Tax In Percentage" runat="server" required ToolTip="Tax In Percentage" Type="number"></asp:TextBox>                        
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->                   
                  </div>  --%>

                 <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                      Route
                      </div>
                      <asp:DropDownList ID="dpRoute" class="form-control" DataTextField="Name" DataValueField="RouteID" runat="server" selected ToolTip="Select Route"> 
                       </asp:DropDownList>           
                    </div><!-- /.input group -->

                  </div><!-- /.form group --> 
                          
                      </div> 
                </div>
                <div class="row">
                   <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       Transport Type
                      </div>
                      <asp:DropDownList ID="dpTransportType" class="form-control" runat="server" selected>

                           <asp:ListItem Value="0">---Select Transport Type---</asp:ListItem>
                           <asp:ListItem Value="1">Collection</asp:ListItem>
                           <asp:ListItem Value="2">Sales</asp:ListItem>
                       
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->

                     
                       
                          
                      </div>   
            
             <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <span style="color:red">&nbsp;*</span>
                      </div>
                     <asp:TextBox ID="txtTDSPercent" class="form-control" placeholder="TDS In Percentage" runat="server"  ToolTip="TDS In Percentage" type="number" step="any"></asp:TextBox>                        
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->

                     
                       
                          
                      </div>     
             <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:DropDownList ID="DropDownList1" class="form-control" runat="server" selected>

                           <asp:ListItem Value="0">---Select Status---</asp:ListItem>
                           <asp:ListItem Value="1">Active</asp:ListItem>
                           <asp:ListItem Value="2">Deactive</asp:ListItem>
                       
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->

                     
                       
                          
                      </div>   
            
        </div>
            <div class="row">
             
                   <div class="col-lg-3 pull-right">
                  <div class="form-group">
                    <div class="input-group">
                      
                    
                      
                              <asp:Button ID="btnAddVehicle" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Add" ValidationGroup="Save" OnClick="btnAddVehicle_Click" />     
                        <asp:Button ID="btnupdateVehicle" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Update" ValidationGroup="Save" OnClick="btnupdateVehicle_Click" />           
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
              <h3 class="box-title"> Vehical List </h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-minus"></i></button>
                
              </div>
            </div>
            <div class="box-body" id="datalist">
                   
                
                       

                                <asp:UpdatePanel runat="server" ID="uprouteList" UpdateMode="Conditional">
                    <ContentTemplate>

                <table id="example1" class="table table-bordered table-striped">
                   

                 

                <asp:Repeater ID="rpVehicleList" runat="server" OnItemCommand="rpVehicleList_ItemCommand">
                
               <HeaderTemplate>
                  <thead>
                      <tr>
                          <th>Vehicle Model</th>
                        
                        <th>Vehicle No</th>
                        <th>Owner Name</th>
                    
                        <th>Driver Name</th>
                           <th>IsActive</th>
                           <th>Edit</th>
                       <%--   <th>Delete</th>--%>
                      </tr>
                    </thead>
                    <tbody>

                   
               </HeaderTemplate>
               <ItemTemplate>
                    <tr>
                         <td><%# Eval("VehicleType")%></td>
                     
                      <td><%# Eval("VehicleNo")%></td>
                      <td><%# Eval("VehicleOwnerName")%></td>
                        
                     
                      <td><%# Eval("DriverName")%></td>
                           <td><%# Eval("IsActive")%></td>
                         <td>

                             <asp:LinkButton ID="lbEdite" AlternateText="Edit" ForeColor="Gray" OnItemCommand="lbEdite_ItemCommand" 
                                                                    ToolTip="Edit" runat="server" CommandArgument='<%#Eval("VehicleMasterID") %>'
                                                                    CommandName="Edit"><i class="fa fa-edit"></i></asp:LinkButton>

                         </td>
                        <%-- <td>   <asp:LinkButton ID="lbdelete" AlternateText="delete" ForeColor="Gray" OnItemCommand="lbdelete_ItemCommand" 
                                                                    ToolTip="Delete" runat="server" CommandArgument='<%#Eval("VehicleMasterID") %>'
                                                                    CommandName="delete"><i class="fa fa-trash"></i></asp:LinkButton>
</td>--%>
                    </tr>
               </ItemTemplate>
                    <FooterTemplate>

                         </tbody>

                    <tfoot>
                      <tr>
                          <th>Vehicle Model</th>
                       
                        <th>Vehicle No</th>
                        <th>Owner Name</th>
                        
                        <th>Driver Name</th>
                             <th>IsActive</th>
                           <th>Edit</th>
                      <%--    <th>Delete</th>--%>
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
