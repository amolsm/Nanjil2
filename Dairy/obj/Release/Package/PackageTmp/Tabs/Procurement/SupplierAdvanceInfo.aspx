﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SupplierAdvanceInfo.aspx.cs" Inherits="Dairy.Tabs.Procurement.SupplierAdvanceInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css">
    <script src="//code.jquery.com/jquery-1.10.2.js"></script>
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">

        $(function () {
            $("#MainContent_txtAdvanceDate").datepicker({ format: 'dd-MM-yyyy' });
            $("#MainContent_txtDeductDate").datepicker({ format: 'dd-MM-yyyy' });

        })
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
      <script type="text/javascript">
          $(document).ready(function () {
              $calculate = $('.cal');
              $calculate.blur(function () {
                  debugger;
                  var advAmt = 0;
                  var interest = 0;
                  var advdeduct = 0;
                  var advbal = 0;
                  
                  advAmt = $("#MainContent_txtAdvanceAmount").val();
                  interest = $("#MainContent_txtInterest").val();
                  advdeduct = $("#MainContent_txtAdvanceDeducted").val();

                  advbal = parseFloat(advAmt) + parseFloat(interest) - advdeduct;
                  $("#MainContent_txtAdvanceBalance").val(parseFloat(advbal).toFixed(2));

              });
          });

      </script>


    <section class="content-header">
          <h1>
             Vehicle Advance Info
            <small>Procurement</small>
          </h1>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Procurement</a></li>
            <li class="active"> <asp:Label runat="server" ID="lblHeaderTab" Text="Add Vehicle Advance Info"></asp:Label> </li>
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
              <h3 class="box-title"><asp:Label ID="lblTabName" runat="server" Text="Add Vehicle Advance Info"></asp:Label> </h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-plus"></i></button>
                
              </div>
            </div>
            <div class="box-body">
               
              
                      <asp:UpdatePanel runat="server" ID="upMain" UpdateMode="Conditional">
                    <ContentTemplate>           

        <div class="box box-solid box-default" style="margin-bottom:5px !important;" >
        <div class="box-header" style="padding:0px 0px 0px 10px !important">
          <h3 class="box-title">Vehicle Advance Info </h3>
        </div><!-- /.box-header -->
        <div class="box-body">
             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa  fa-code "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtAdvanceDate" class="form-control" placeholder="Advance Date" type="text" runat="server"  ToolTip="Advance Date"></asp:TextBox>                        
                    </div><!-- /.input group -->
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtAdvanceDate"
                     ErrorMessage="Advance Date Required" ValidationGroup="Save" ForeColor="Red"></asp:RequiredFieldValidator> 
                  </div><!-- /.form group -->

                     
                       
                          
                      </div>  
            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:DropDownList ID="dpVehical" class="form-control" DataTextField="Name" DataValueField="VehicleMasterID" runat="server" selected ToolTip="Select Vehical"> 
                       </asp:DropDownList>                               
                    </div><!-- /.input group -->
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="dpVehical"
        ErrorMessage=" Required Vehicle" ValidationGroup="Save" ForeColor="Red" InitialValue="0"></asp:RequiredFieldValidator> 
                  </div><!-- /.form group --> 
                          
                      </div> 
             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtAdvanceAmount" class="cal form-control" placeholder="Advance Amount" runat="server"  ToolTip="Advance Amount" type="number"></asp:TextBox>                        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAdvanceAmount"
                     ErrorMessage="Advance Amount Required" ValidationGroup="Save" ForeColor="Red"></asp:RequiredFieldValidator> 
                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 
            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtInterest" class="cal form-control" placeholder="Interest" runat="server"  ToolTip="Interest" type="number"></asp:TextBox>                        
                    </div><!-- /.input group -->
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtInterest"
                     ErrorMessage="Interest Required" ValidationGroup="Save" ForeColor="Red"></asp:RequiredFieldValidator> 
                  </div><!-- /.form group -->

                     
                       
                          
                      </div>
            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtInstallments" class="form-control" placeholder="No Of Installments" runat="server"  ToolTip="No Of Installments"></asp:TextBox>                        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtInstallments"
                     ErrorMessage="Installments Required" ValidationGroup="Save" ForeColor="Red"></asp:RequiredFieldValidator> 
                  </div><!-- /.form group -->

                     
                       
                          
                      </div>    
            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtInstallAmt" class="form-control" placeholder="Installment Amount" runat="server"  ToolTip="Installment Amount" type="number"></asp:TextBox>                        
                    </div><!-- /.input group -->
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtInstallAmt"
                     ErrorMessage="Install Amt Required" ValidationGroup="Save" ForeColor="Red"></asp:RequiredFieldValidator> 
                  </div><!-- /.form group -->

                     
                       
                          
                      </div>
             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtAdvanceDeducted" class="cal form-control" placeholder="Advance Deducted" runat="server"  ToolTip="Advance Deducted" type="number"></asp:TextBox>                        
                    </div><!-- /.input group -->
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtAdvanceDeducted"
                     ErrorMessage="Advance Deducted  Required" ValidationGroup="Save" ForeColor="Red"></asp:RequiredFieldValidator> 
                  </div><!-- /.form group -->                   
                  </div>  
       

            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtAdvanceBalance" class="cal form-control" placeholder="Advance Balance" runat="server"  ToolTip="Advance Balance" type="number"></asp:TextBox>                        
                    </div><!-- /.input group -->
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtAdvanceBalance"
                     ErrorMessage="Advance Balance Required" ValidationGroup="Save" ForeColor="Red"></asp:RequiredFieldValidator> 
                  </div><!-- /.form group -->
                

                     
                       
                          
                      </div>                        
                 
   <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa  fa-code "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtDeductDate" class="form-control" placeholder=" Last due paid Date" type="text" runat="server"  ToolTip=" Last due paid Date"></asp:TextBox>                        
                    </div><!-- /.input group -->
<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtDeductDate"
                     ErrorMessage="DeductDate Required" ValidationGroup="Save" ForeColor="Red"></asp:RequiredFieldValidator> 
                  </div><!-- /.form group -->

                     
                       
                          
                      </div>
            
            
            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      
                    
                      
                              <asp:Button ID="btnAddAdvanceInfo" class="btn btn-primary" runat="server" CommandName="MoveNext" OnClick="btnAddAdvanceInfo_Click"  Text="Add" ValidationGroup="Save" />     
                           &nbsp;&nbsp; <asp:Button ID="btnupdateAdvanceInfo" class="btn btn-primary" runat="server" CommandName="MoveNext" OnClick="btnupdateAdvanceInfo_Click" Text="Update" ValidationGroup="Save" />   
                           &nbsp;&nbsp;  <asp:Button ID="btnRefresh" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Refresh" ValidationGroup="none"  OnClick="btnRefresh_Click"  />           
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
              <h3 class="box-title"> Advance Info </h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-minus"></i></button>
                
              </div>
            </div>
            <div class="box-body" id="datalist">
                   
                
                       

                                <asp:UpdatePanel runat="server" ID="uprouteList" UpdateMode="Conditional">
                    <ContentTemplate>

                <table id="example1" class="table table-bordered table-striped">
                   

                 

                <asp:Repeater ID="rpAdvanceInfo" runat="server" OnItemCommand="rpAdvanceInfo_ItemCommand">
                
               <HeaderTemplate>
                  <thead>
                      <tr>
                          <th>Vehical No</th>
                        <th>Advance Amount</th>
                        <th>Advance Date</th> 
                        <th> Advance Deducted</th>
                          <th>Advance Balance</th>
                            <th>Deduct Date</th>
                           <th>Edit</th>
                          <%--<th>Delete</th>--%>
                      </tr>
                    </thead>
                    <tbody>

                   
               </HeaderTemplate>
               <ItemTemplate>
                    <tr>
                         <td><%# Eval("VehicleNo")%></td>
                      <td><%# string.Format("{0:n2}",Eval("AdvanceAmount"))%></td>
                      <td><%# Eval("AdvanceDateTime")%></td>
                      <td><%# string.Format("{0:n2}",Eval("AdvanceDeducted"))%></td>
                     
                      <td><%# string.Format("{0:n2}",Eval("AdvanceBalance"))%></td>
                   <td><%# Eval("DeductDateTime")%></td>
                         <td>

                             <asp:LinkButton ID="lbEdite" AlternateText="Edit" ForeColor="Gray" OnItemCommand="lbEdite_ItemCommand" 
                                                                    ToolTip="Edit" runat="server" CommandArgument='<%#Eval("AdvanceID") %>'
                                                                    CommandName="Edit"><i class="fa fa-edit"></i></asp:LinkButton>

                         </td>
                         <%--<td>   <asp:LinkButton ID="lbdelete" AlternateText="delete" ForeColor="Gray" OnItemCommand="lbdelete_ItemCommand" 
                                                                    ToolTip="Delete" runat="server" CommandArgument='<%#Eval("AdvanceID") %>'
                                                                    CommandName="delete"><i class="fa fa-trash"></i></asp:LinkButton>
</td>--%>
                    </tr>
               </ItemTemplate>
                    <FooterTemplate>

                         </tbody>

                    <tfoot>
                      <tr>
                            <th>Vehical No</th>
                        <th>Advance Amount</th>
                        <th>Advance Date</th> 
                        <th> Advance Deducted</th>
                          <th>Advance Balance</th>
                            <th>Deduct Date</th>
                       
                       
                           <th>Edit</th>
                         <%-- <th>Delete</th>--%>
                      </tr>
                    </tfoot>

                    </FooterTemplate>
                                             
           </asp:Repeater>
                    <asp:HiddenField id="hfAdvanceID" runat="server" />
             
                
                  
                     
                   
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
          </div>
        </section>
</asp:Content>
