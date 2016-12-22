<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SupplierAdvanceInfo.aspx.cs" Inherits="Dairy.Tabs.Procurement.SupplierAdvanceInfo" %>
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
                       <asp:TextBox ID="txtAdvanceDate" class="form-control" placeholder="Advance Date" type="text" runat="server" required ToolTip="Advance Date"></asp:TextBox>                        
                    </div><!-- /.input group -->

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

                  </div><!-- /.form group --> 
                          
                      </div> 
             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtAdvanceAmount" class="form-control" placeholder="Advance Amount" runat="server" required ToolTip="Advance Amount" type="number"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 
            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtInterest" class="form-control" placeholder="Interest" runat="server" required ToolTip="Interest" type="number"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div>
            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtInstallments" class="form-control" placeholder="No Of Installments" runat="server" required ToolTip="No Of Installments"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div>    
            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtInstallAmt" class="form-control" placeholder="Installment Amount" runat="server" required ToolTip="Installment Amount" type="number"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div>
             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtAdvanceDeducted" class="form-control" placeholder="Advance Deducted" runat="server" required ToolTip="Advance Deducted" type="number"></asp:TextBox>                        
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->                   
                  </div>  
       

            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtAdvanceBalance" class="form-control" placeholder="Advance Balance" runat="server" required ToolTip="Advance Balance" type="number"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
                

                     
                       
                          
                      </div>                        
                 
   <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa  fa-code "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtDeductDate" class="form-control" placeholder=" Last due paid Date" type="text" runat="server" required ToolTip=" Last due paid Date"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div>
            
            
            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      
                    
                      
                              <asp:Button ID="btnAddAdvanceInfo" class="btn btn-primary" runat="server" CommandName="MoveNext" OnClick="btnAddAdvanceInfo_Click"  Text="Add" ValidationGroup="Save" />     
                        <asp:Button ID="btnupdateAdvanceInfo" class="btn btn-primary" runat="server" CommandName="MoveNext" OnClick="btnupdateAdvanceInfo_Click" Text="Update" ValidationGroup="Save" />           
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
                          <th>Vehical ID</th>
                        <th>Advance Amount</th>
                        <th>Advance Date</th> 
                        <th> Advance Deducted</th>
                          <th>Advance Balance</th>
                            <th>Deduct Date</th>
                           <th>Edit</th>
                          <th>Delete</th>
                      </tr>
                    </thead>
                    <tbody>

                   
               </HeaderTemplate>
               <ItemTemplate>
                    <tr>
                         <td><%# Eval("VehicalID")%></td>
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
                         <td>   <asp:LinkButton ID="lbdelete" AlternateText="delete" ForeColor="Gray" OnItemCommand="lbdelete_ItemCommand" 
                                                                    ToolTip="Delete" runat="server" CommandArgument='<%#Eval("AdvanceID") %>'
                                                                    CommandName="delete"><i class="fa fa-trash"></i></asp:LinkButton>
</td>
                    </tr>
               </ItemTemplate>
                    <FooterTemplate>

                         </tbody>

                    <tfoot>
                      <tr>
                             <th>Vehical ID</th>
                        <th>Advance Amount</th>
                        <th>Advance Date</th> 
                        <th> Advance Deducted</th>
                          <th>Advance Balance</th>
                            <th>Deduct Date</th>
                       
                       
                           <th>Edit</th>
                          <th>Delete</th>
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
