<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddMilkCollectionCenter.aspx.cs" Inherits="Dairy.Tabs.Procurement.AddMilkCollectionCenter" %>
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
             Milk Collection Center
            <small>Procurement</small>
          </h1>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Procurement</a></li>
            <li class="active"> <asp:Label runat="server" ID="lblHeaderTab" Text="Add Milk Collection Center"></asp:Label> </li>
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
              <h3 class="box-title"><asp:Label ID="lblTabName" runat="server" Text="Add Milk Collection Center"></asp:Label> </h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-plus"></i></button>
                
              </div>
            </div>
            <div class="box-body">
               
              
                      <asp:UpdatePanel runat="server" ID="upMain" UpdateMode="Conditional">
                    <ContentTemplate>           

        <div class="box box-solid box-default" style="margin-bottom:5px !important;" >
        <div class="box-header" style="padding:0px 0px 0px 10px !important">
          <h3 class="box-title">Milk Collection Center Information </h3>
        </div><!-- /.box-header -->
        <div class="box-body">
            <div class="row">
            <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtCenterCode" class="form-control" placeholder="Center Code" runat="server"  ReadOnly="true" ToolTip="CenterCode" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group --> 
                          
                      </div> 
             <div class="col-lg-4">
                  <div class="form-group" style="margin-bottom:1px">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtCenterName" class="form-control" placeholder="Center Name" runat="server"  ToolTip="Center Name" OnTextChanged="txtCenterName_TextChanged" AutoPostBack="true"></asp:TextBox>                        
                    </div><!-- /.input group -->
                        <asp:RequiredFieldValidator  ID="FieldValidator4" Display="Dynamic" 
    ValidationGroup="Save" runat="server" ControlToValidate="txtCenterName" ForeColor="Red"
    ErrorMessage="Please Enter Center Name "></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 
             <%-- <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <i class="fa fa-rode"></i><span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:DropDownList ID="dpRoute" class="form-control" DataTextField="Name" DataValueField="RouteID" runat="server" selected ToolTip="Select Route"> 
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->

                     
                       
                          
                      </div>  --%>
       

            <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-map-marker"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtAddress1" class="form-control" placeholder="Address 1" runat="server"  ToolTip="Address"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
                

                     
                       
                          
                      </div>  
                </div>                      
                 <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-map-marker"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtAddress2" class="form-control" placeholder="Address 2" runat="server" ToolTip="Address 2"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div>  
  <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-map-marker"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtAddress3" class="form-control" placeholder="Address 3" runat="server" ToolTip="Address 3"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 
            
 

              <div class="col-lg-4">
                  <div class="form-group" style="margin-bottom:1px">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-envelope-o"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtEmail" class="form-control" placeholder="Email" runat="server"  AutoCompleteType="Email" ToolTip="Email"></asp:TextBox>                        
                    </div><!-- /.input group -->
                      <asp:RegularExpressionValidator ID="valRegExEmail" runat="server" ControlToValidate="txtEmail"
                           ForeColor="Red"  ErrorMessage="Please give a valid email address" ValidationGroup="Save" ValidationExpression="^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z\.][a-zA-Z]{1,3}$"></asp:RegularExpressionValidator> 
                  </div><!-- /.form group --> 
                   </div> 
            <div class="row">
                        <div class="col-lg-4">
                  <div class="form-group" style="margin-bottom:1px">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-mobile"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtMobile" class="form-control" placeholder="Mobile No" runat="server"  type="number" min="0" ToolTip="Mobile No."></asp:TextBox>                        
                    </div><!-- /.input group -->
                       <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
      ControlToValidate="txtMobile" ErrorMessage="Please enter 10 digit mobile no." ForeColor="Red"
    ValidationExpression="[0-9]{10}" ></asp:RegularExpressionValidator>
                  </div><!-- /.form group -->

                     
                       
                          
                      </div>                        
                 <div class="col-lg-4">
                  <div class="form-group" style="margin-bottom:1px">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-phone"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtTelephone" class="form-control" placeholder="Telephone No" runat="server"  type="number" min="0" ToolTip="Telephone No."></asp:TextBox>                        
                    </div><!-- /.input group -->
                      <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
      ControlToValidate="txtTelephone" ErrorMessage="Please enter telephone no." ForeColor="Red"
    ValidationExpression="^[01]?[- .]?(\([2-9]\d{2}\)|[2-9]\d{2})[- .]?\d{3}[- .]?\d{4}$" ></asp:RegularExpressionValidator>
                  </div><!-- /.form group -->

                     
                       
                          
                      </div>  


                        <div class="col-lg-4">
                  <div class="form-group" style="margin-bottom:1px">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-globe"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:DropDownList  ID="dpCity" ToolTip="Select City" class="form-control" DataTextField="Name"  runat="server"  > 
                       </asp:DropDownList></div><!-- /.input group -->
                       <asp:CompareValidator ID="CompareValidator" runat="server" ControlToValidate="dpCity"
        ErrorMessage="City is Required" Operator="NotEqual" ValidationGroup="Save" ForeColor="Red"
        ValueToCompare="0"></asp:CompareValidator>
                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 
                </div>
                               <div class="col-lg-3">
                  <div class="form-group" style="margin-bottom:1px">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-globe"></i><span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:DropDownList  ID="dpDistrict" ToolTip="Select District" class="form-control" DataTextField="Name"  runat="server" > 
                       </asp:DropDownList></div><!-- /.input group -->
                      <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="dpDistrict"
        ErrorMessage="District is Required" Operator="NotEqual" ValidationGroup="Save" ForeColor="Red"
        ValueToCompare="0"></asp:CompareValidator>
                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 
                      
                      
                  <div class="col-lg-3">
                  <div class="form-group" style="margin-bottom:1px">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <span style="color:red">&nbsp;*</span>
                      </div>
                            <asp:DropDownList  ID="dpState" ToolTip="Select State" class="form-control" DataTextField="Name"  runat="server"  > 
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                      <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="dpState"
        ErrorMessage="State is Required" Operator="NotEqual" ValidationGroup="Save" ForeColor="Red"
        ValueToCompare="0"></asp:CompareValidator>
                  </div><!-- /.form group -->

                     
                       
                          
                      </div>  
            
                <div class="col-lg-3">
                  <div class="form-group" style="margin-bottom:1px">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <span style="color:red">&nbsp;*</span>
                      </div>
                  
                          <asp:DropDownList  ID="dpCountry" ToolTip="Select Country" class="form-control" DataTextField="Name"  runat="server"   > 
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                        <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="dpCountry"
        ErrorMessage="Country is Required" Operator="NotEqual" ValidationGroup="Save" ForeColor="Red"
        ValueToCompare="0"></asp:CompareValidator>
                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 
             <div class="col-lg-3">
                  <div class="form-group" style="margin-bottom:1px">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:DropDownList  ID="dpContactPerson"  class="form-control" DataTextField="Name" DataValueField="EmployeeID"  runat="server" ToolTip="Select Contact Person"  > 
                       </asp:DropDownList>
                    </div><!-- /.input group -->
                           <asp:CompareValidator ID="CompareValidator4" runat="server" ControlToValidate="dpContactPerson"
        ErrorMessage="ContactPerson is Required" Operator="NotEqual" ValidationGroup="Save" ForeColor="Red"
        ValueToCompare="0"></asp:CompareValidator>
                  </div><!-- /.form group --> 
                          
                      </div>            
            
            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                        Freezer Available :&nbsp&nbsp
                        <asp:RadioButton ID="rdYes" runat="server" Text="Yes" GroupName="Freezer" OnCheckedChanged="rdYes_CheckedChanged" AutoPostBack="true"></asp:RadioButton>&nbsp&nbsp&nbsp&nbsp
                        <asp:RadioButton ID="rdNo" runat="server" Text="No" GroupName="Freezer" OnCheckedChanged="rdNo_CheckedChanged" AutoPostBack="true"></asp:RadioButton>
                       
                    </div><!-- /.input group -->

                  </div><!-- /.form group --> 
                          
                      </div> 
            <div id="d1" runat="server">
            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        </i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtFreezerModel" class="form-control" placeholder="Freezer Model" runat="server" ToolTip="Freezer Model"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group --> 
                          
                      </div>           
            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        </i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtQuantity" class="form-control" placeholder="Freezer Quantity" runat="server" ToolTip="Freezer Quantity" type="number" min="0"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group --> 
                          
                      </div>              
              </div>
            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-mobile"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtBMC" class="form-control" placeholder="BMC" runat="server"  type="number" min="0" ToolTip="BMC"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 
            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-mobile"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtMilkCan" class="form-control" placeholder="Milk Can" runat="server"  type="number" min="0" ToolTip="Milk Can"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 
            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-mobile"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtSilo" class="form-control" placeholder="Silo" runat="server"  type="number" min="0" ToolTip="Silo"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 

            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                        IBT :&nbsp&nbsp
                        <asp:RadioButton ID="rdIBTYes" runat="server" Text="Yes" GroupName="ibt"></asp:RadioButton>&nbsp&nbsp&nbsp&nbsp
                        <asp:RadioButton ID="rdIBTNo" runat="server" Text="No" GroupName="ibt"></asp:RadioButton>
                       
                    </div><!-- /.input group -->

                  </div><!-- /.form group --> 
                          
                      </div> 
            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                        ETP :&nbsp&nbsp
                        <asp:RadioButton ID="rdETPYes" runat="server" Text="Yes" GroupName="etp"></asp:RadioButton>&nbsp&nbsp&nbsp&nbsp
                        <asp:RadioButton ID="rdETPNo" runat="server" Text="No" GroupName="etp"></asp:RadioButton>
                       
                    </div><!-- /.input group -->

                  </div><!-- /.form group --> 
                          
                      </div> 
            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                        LAB :&nbsp&nbsp
                        <asp:RadioButton ID="rdLABYes" runat="server" Text="Yes" GroupName="lab"></asp:RadioButton>&nbsp&nbsp&nbsp&nbsp
                        <asp:RadioButton ID="rdLABNo" runat="server" Text="No" GroupName="lab"></asp:RadioButton>
                       
                    </div><!-- /.input group -->

                  </div><!-- /.form group --> 
                          
                      </div> 
            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                        Store :&nbsp&nbsp
                        <asp:RadioButton ID="rdStoreYes" runat="server" Text="Yes" GroupName="store"></asp:RadioButton>&nbsp&nbsp&nbsp&nbsp
                        <asp:RadioButton ID="rdStoreNo" runat="server" Text="No" GroupName="store"></asp:RadioButton>
                       
                    </div><!-- /.input group -->

                  </div><!-- /.form group --> 
                          
                      </div> 
             <div class="col-lg-3">
                  <div class="form-group"  style="margin-bottom:1px">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:DropDownList ID="DropDownList1" class="form-control" runat="server" ToolTip="Status">

                           <asp:ListItem Value="0">---Select Status---</asp:ListItem>
                           <asp:ListItem Value="1">Active</asp:ListItem>
                           <asp:ListItem Value="2">Deactive</asp:ListItem>
                       
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                  <asp:CompareValidator ID="CompareValidator5" runat="server" ControlToValidate="DropDownList1"
        ErrorMessage="Status is Required" Operator="NotEqual" ValidationGroup="Save" ForeColor="Red"
        ValueToCompare="0"></asp:CompareValidator>
                  </div><!-- /.form group -->

                     
                       
                          
                      </div>     
            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      
                    
                      
                              <asp:Button ID="btnAddCollection" class="btn btn-primary" runat="server" CommandName="MoveNext" OnClick="btnClick_btnAddCollection"   Text="Add" ValidationGroup="Save" />     
                        <asp:Button ID="btnupdateCollection" class="btn btn-primary" runat="server" CommandName="MoveNext" OnClick="btnClick_btnupdateCollection"   Text="Update" ValidationGroup="Save" />           
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
              <h3 class="box-title">Milk Collection Center List </h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-minus"></i></button>
                
              </div>
            </div>
            <div class="box-body" id="datalist">
                   
                
                       

                                <asp:UpdatePanel runat="server" ID="uprouteList" UpdateMode="Conditional">
                    <ContentTemplate>

                <table id="example1" class="table table-bordered table-striped">
                   

                 

                <asp:Repeater ID="rpCenterList" runat="server" OnItemCommand="rpCenterList_ItemCommand">
                
               <HeaderTemplate>
                  <thead>
                      <tr>
                          <th>Center Code</th>
                        <th>Center Name</th>
                        <th>Mobile No </th>
                        <th>Email</th> 
                        <th>Address</th>
                           <th>Edit</th>
                          <th>Delete</th>
                      </tr>
                    </thead>
                    <tbody>

                   
               </HeaderTemplate>
               <ItemTemplate>
                    <tr>
                         <td><%# Eval("Centercode")%></td>
                      <td><%# Eval("CenterName")%></td>
                      <td><%# Eval("MobileNo")%></td>
                      <td><%# Eval("Email")%></td>
                     
                      <td><%# Eval("Address1")%></td>
                         <td>

                             <asp:LinkButton ID="lbEdite" AlternateText="Edit" ForeColor="Gray" OnItemCommand="lbEdite_ItemCommand" 
                                                                    ToolTip="Edit" runat="server" CommandArgument='<%#Eval("CenterID") %>'
                                                                    CommandName="Edit"><i class="fa fa-edit"></i></asp:LinkButton>

                         </td>
                         <td>   <asp:LinkButton ID="lbdelete" AlternateText="delete" ForeColor="Gray" OnItemCommand="lbdelete_ItemCommand" 
                                                                    ToolTip="Delete" runat="server" CommandArgument='<%#Eval("CenterID") %>'
                                                                    CommandName="delete"><i class="fa fa-trash"></i></asp:LinkButton>
</td>
                    </tr>
               </ItemTemplate>
                    <FooterTemplate>

                         </tbody>

                    <tfoot>
                      <tr>
                           <th>Center Code</th>
                        <th>Center Name</th>
                        <th>Mobile No</th>
                        <th>Email</th>
                       
                        <th>Address</th>
                           <th>Edit</th>
                          <th>Delete</th>
                      </tr>
                    </tfoot>

                    </FooterTemplate>
                                             
           </asp:Repeater>
                    <asp:HiddenField id="hfcenterID" runat="server" />
             
                
                  
                     
                   
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
