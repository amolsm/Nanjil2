<%@ Page Title="" Language="C#" MasterPageFile="/Site.Master" AutoEventWireup="true" CodeBehind="EmployeeInfo.aspx.cs" Inherits="Dairy.Tabs.Administration.EmployeeInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

                            <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css">
                            <script src="//code.jquery.com/jquery-1.10.2.js"></script>
                            <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<%--    <script type="text/javascript">

        $(function () {
            $("#MainContent_txtJoingDate").datepicker({ dateFormat: 'dd/mm/yy' });
            $("#MainContent_txtActiveFrom").datepicker({ dateFormat: 'dd/mm/yy' });

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
             Employee Information
            <small>Administration</small>
          </h1>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Administration</a></li>
            <li class="active"> <asp:Label runat="server" ID="lblHeaderTab" Text="Add EmployeeInfo Info"></asp:Label> </li>
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
                                    <i class="icon fa fa-warning"></i>Warning!<asp:Label runat="server" ID="lblWarningHead" Text=""></asp:Label></h4>
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
              <h3 class="box-title"><asp:Label ID="lblTabName" runat="server" Text=""></asp:Label> </h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-plus"></i></button>
                
              </div>
            </div>
            <div class="box-body">
               
              
                      <asp:UpdatePanel runat="server" ID="upMain" UpdateMode="Conditional">
                    <ContentTemplate>           
        
               <div class="box box-solid box-default" style="margin-bottom:5px !important;" >
        <div class="box-header" style="padding:0px 0px 0px 10px !important">
          <h3 class="box-title">Employee Information </h3>
        </div><!-- /.box-header -->
        <div class="box-body">

             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtEmpCode" class="form-control" placeholder="EmployeeCode" runat="server" required ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group --> 
                          
                      </div> 
             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtPFNo" class="form-control" placeholder="PF No" runat="server" required ToolTip="PF No"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 
             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtEmpName" class="form-control" placeholder="Employee Name" runat="server" required></asp:TextBox>                        
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->                   
                  </div>  
             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtFatherName" class="form-control" placeholder="Father Name" type="text" runat="server" required></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div>            
             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa  fa-code "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtJoingDate" Type="date" ToolTip="Joining Date" class="form-control" placeholder="Joining Date" value="04-02-2016" runat="server" required></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div>  

          
                      <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:DropDownList ID="dpStatus" class="form-control" runat="server">

                           <asp:ListItem Value="0">---Select Status---</asp:ListItem>
                           <asp:ListItem Value="1">Active</asp:ListItem>
                           <asp:ListItem Value="2">Deactive</asp:ListItem>
                       
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 
              
        </div><!-- /.box-body -->
      </div>

                              <div class="box box-solid box-default" style="margin-bottom:5px !important;" >
        <div class="box-header" style="padding:0px 0px 0px 10px !important">
          <h3 class="box-title">Contact Information </h3>
        </div><!-- /.box-header -->
        <div class="box-body">
            <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-map-marker"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtAddress1" class="form-control" placeholder="Address 1" runat="server" required></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
                

                     
                       
                          
                      </div>                        
                 <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-map-marker"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtAddress2" class="form-control" placeholder="Address 2" runat="server"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div>  
  <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-map-marker"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtAddress3" class="form-control" placeholder="Address 3" runat="server"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 
            
 

              <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-envelope-o"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtEmail" class="form-control" placeholder="Email" runat="server" required AutoCompleteType="Email"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group --> 
                   </div> 
                        <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-mobile"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtMobile" class="form-control" placeholder="Mobile No" runat="server" required Type="number"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div>                        
                 <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-phone"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtTelephone" class="form-control" placeholder="Telephone No" runat="server" required Type="number"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div>  


                        <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-globe"></i><span style="color:red">&nbsp;*</span>
                      </div>
                      <%-- <asp:TextBox ID="txtCity" class="form-control" placeholder="City " runat="server" required></asp:TextBox>--%>                        
                       <asp:DropDownList  ID="dpCity" ToolTip="Select City" class="form-control" DataTextField="Name"  runat="server"  > 
                       </asp:DropDownList></div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 
                               <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-globe"></i><span style="color:red">&nbsp;*</span>
                      </div>
                     <%--  <asp:TextBox ID="txtDistric" class="form-control" placeholder="District " runat="server" required></asp:TextBox> --%>                       
                      <asp:DropDownList  ID="dpDistrict" ToolTip="Select District" class="form-control" DataTextField="Name"  runat="server"  > 
                       </asp:DropDownList></div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 
                      
                      
                  <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <span style="color:red">&nbsp;*</span>
                      </div>
               <%--       <asp:DropDownList ID="dpState" class="form-control" runat="server">

                           <asp:ListItem Value="0">---Select State ---</asp:ListItem>
                          <asp:ListItem Value="1" Selected>TamilNadu</asp:ListItem>
                           <asp:ListItem Value="1">Karnataka</asp:ListItem>
                           <asp:ListItem Value="2">Kerala</asp:ListItem>
                          
                       </asp:DropDownList>--%> <asp:DropDownList  ID="dpState" ToolTip="Select State" class="form-control" DataTextField="Name"  runat="server"  > 
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->

                     
                       
                          
                      </div>  
            
                <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <span style="color:red">&nbsp;*</span>
                      </div>
                     <%-- <asp:DropDownList ID="dpCountry" class="form-control" runat="server">

                           <asp:ListItem Value="0">---Select Country---</asp:ListItem>
                          <asp:ListItem Selected="True" Value="1">India</asp:ListItem>
                           <asp:ListItem Value="2">USA</asp:ListItem>
                       </asp:DropDownList>--%>
                          <asp:DropDownList  ID="dpCountry" ToolTip="Select Country" class="form-control" DataTextField="Name"  runat="server"  > 
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->

                     
                       
                          
                      </div>  
            
        </div><!-- /.box-body -->
      </div>


                            <div class="box box-solid box-default" style="margin-bottom:5px !important;" >
        <div class="box-header" style="padding:0px 0px 0px 10px !important">
          <h3 class="box-title">Bank Information </h3>
        </div><!-- /.box-header -->
        <div class="box-body">


                 
                                       
             
 
                  
         
            
             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-bank"></i><span style="color:red">&nbsp;*</span>
                      </div>
                      <%-- <asp:TextBox ID="txtBankName" class="form-control" placeholder="Bank  Name" runat="server" required></asp:TextBox> --%>                       
                    <asp:DropDownList  ID="dpBankName" ToolTip="Select Bank Name" class="form-control" DataTextField="Name"  runat="server"  > 
                       </asp:DropDownList> </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div>    


              <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-bars"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtAccountNo" class="form-control" placeholder="Account No" runat="server" required type="number"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 
             <div class="col-lg-3">

             

                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-bars"></i><span style="color:red">&nbsp;*</span>
                      </div>
                     <%--  <asp:TextBox ID="txtIfscCode" class="form-control" placeholder="IFSC Code" runat="server" required  ></asp:TextBox> --%>                       
                      <asp:DropDownList  ID="dpbranchName" ToolTip="Select Branch Name" class="form-control" DataTextField="Name"  runat="server"  > 
                       </asp:DropDownList></div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                      </div>
                          
                     
                    
        </div><!-- /.box-body -->
      </div>
<div class="box box-solid box-default" style="margin-bottom:5px !important;" >
        <div class="box-header" style="padding:0px 0px 0px 10px !important">
          <h3 class="box-title">HR Information </h3>
        </div><!-- /.box-header -->
        <div class="box-body">

             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtActiveFrom" class="form-control" ToolTip="Active From" type="date" placeholder="Active From" runat="server" required></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 
            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <i class="fa fa-rode"></i><span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:DropDownList ID="dpDept" ToolTip="Select Department Name" class="form-control" DataTextField="Dept_Name"  runat="server"> 
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 

             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                     <%--  <asp:TextBox ID="txtdesignation" class="form-control" placeholder="Designation" runat="server" required></asp:TextBox>                        
                    </div>--%>
                        <asp:DropDownList  ID="dpdesignation" ToolTip="Select Designation Name" class="form-control" DataTextField="DesigName"  runat="server"  > 
                       </asp:DropDownList></div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div>  
             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtsupervisor" class="form-control" placeholder="Supervisor" type="text" runat="server" required></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div>            
           <%-- <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <i class="fa fa-rode"></i><span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:DropDownList ID="dpRoute" class="form-control" DataTextField="routeName" DataValueField="routeId" runat="server" selected> 
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->

                     
                       
                          
                      </div> --%>
             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      
                    
                      
                              <asp:Button ID="btnEmpadd" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Add" ValidationGroup="Save" OnClick="btnClick_btnAddRoute" />     &nbsp;&nbsp;
                        <asp:Button ID="btnEmpUpdate" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Update" ValidationGroup="Save" OnClick="btnClick_btnUpdate" />           
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
              <h3 class="box-title"> Employee List </h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-minus"></i></button>
                
              </div>
            </div>
            <div class="box-body" id="datalist">
                   
                
                       

                                <asp:UpdatePanel runat="server" ID="uprouteList" UpdateMode="Conditional">
                    <ContentTemplate>

                <table id="example1" class="table table-bordered table-striped">
                   

                 

                <asp:Repeater ID="rpRouteList" runat="server" OnItemCommand="rpRouteList_ItemCommand">
                
               <HeaderTemplate>
                  <thead>
                      <tr>
                                        <th>Employee Code</th>
                                        <th>Employee Name</th>
                                        
                                        <th>Joining Date</th>
                                        <th>Is Active</th>
                                        <th>Address</th>
                                        <th>Email</th>

                                        <th>Mobile</th>
                                        <th>Phone</th>
                                         
                                        <th>Edit</th>
                                        <th>Delete</th>
                          
                      </tr>
                    </thead>
                    <tbody>

                   
               </HeaderTemplate>
               <ItemTemplate>
                    <tr>
                            


                                        <td><%# Eval("EmployeeCode")%></td>
                                        <td><%# Eval("EmployeeName")%></td>    
                                        <td><%# Eval("JoingingDate")%></td>
                                        <td><%# Eval("IsActive")%></td>
                                        <td><%# Eval("Address1")%></td>
                                        <td><%# Eval("Email")%></td>
                                        <td><%# Eval("mobile")%></td>
                                        <td><%# Eval("Phone")%></td>
                                        
                                        
                                        
                         
                         <td>
                             <asp:LinkButton ID="lbEdite" AlternateText="Edit" ForeColor="Gray" OnItemCommand="lbEdite_ItemCommand" 
                                                                    ToolTip="Edit" runat="server" CommandArgument='<%#Eval("EmployeeID") %>'
                                                                    CommandName="Edit"><i class="fa fa-edit"></i></asp:LinkButton>

                         </td>
                         <td>   <asp:LinkButton ID="lbdelete" AlternateText="delete" ForeColor="Gray" OnItemCommand="lbdelete_ItemCommand" 
                                                                    ToolTip="Delete" runat="server" CommandArgument='<%#Eval("EmployeeID") %>'
                                                                    CommandName="delete"><i class="fa fa-trash"></i></asp:LinkButton>
</td>



                    </tr>
               </ItemTemplate>
                    <FooterTemplate>

                         </tbody>

                    <tfoot>
                      <tr>
                                    <th>Employee Code</th>
                                        <th>Employee Name</th>
                                        
                                        <th>Joining Date</th>
                                        <th>Is Active</th>
                                        <th>Address</th>
                                        <th>Email</th>

                                        <th>Mobile</th>
                                        <th>Phone</th>
                                         
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
</asp:Content>
