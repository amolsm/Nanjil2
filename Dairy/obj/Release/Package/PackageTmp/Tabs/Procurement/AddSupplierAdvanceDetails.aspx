<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddSupplierAdvanceDetails.aspx.cs" Inherits="Dairy.Tabs.Procurement.AddSupplierAdvanceDetails" %>
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
    <section class="content-header">
          <h1>
             Supplier Advance Details
            <small>Procurement</small>
          </h1>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Procurement</a></li>
            <li class="active"> <asp:Label runat="server" ID="lblHeaderTab" Text="Add Supplier Advance Details"></asp:Label> </li>
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
              <h3 class="box-title"><asp:Label ID="lblTabName" runat="server" Text="Add Supplier Advance Details"></asp:Label> </h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-minus"></i></button>
                
              </div>
            </div>
            <div class="box-body">
               
              
                      <asp:UpdatePanel runat="server" ID="upMain" UpdateMode="Conditional">
                    <ContentTemplate>           

        <div class="box box-solid box-default" style="margin-bottom:5px !important;" >
        <div class="box-header" style="padding:0px 0px 0px 10px !important">
          <h3 class="box-title">Supplier Advance Details </h3>
        </div><!-- /.box-header -->
        <div class="box-body">
            <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:DropDownList ID="dpSupplier" class="form-control" DataTextField="Name" DataValueField="SupplierID" runat="server" selected ToolTip="Select supplier"> 
                       </asp:DropDownList>                               
                    </div><!-- /.input group -->

                  </div><!-- /.form group --> 
                          
                      </div> 
             <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtAdvanceAmountPaid" class="form-control" placeholder="Advance Amount Paid" runat="server" required ToolTip="Advance Amount Paid"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 
             <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa  fa-code "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtAdvancePaidDate" class="form-control" placeholder="Advance Paid Date" type="text" runat="server" required ToolTip="Advance Paid Date"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div>  
             <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtAdvancePaidInstr" class="form-control" placeholder="Advance Paid Instrument" runat="server" required ToolTip="Advance Paid Instrument"></asp:TextBox>                        
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->                   
                  </div>  
       

            <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtAdvancePaidInstReff" class="form-control" placeholder="Advance Paid Inst Reference" runat="server" required ToolTip="Advance Paid Inst Reference"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
                

                     
                       
                          
                      </div>                        
                 
            <div class="col-lg-4 pull-right">
                  <div class="form-group">
                    <div class="input-group">
                      
                    
                      
                              <asp:Button ID="btnAddAdvanceDetails" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Add" ValidationGroup="Save" />     
                        <asp:Button ID="btnupdateAdvanceDetails" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Update" ValidationGroup="Save" />           
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div>
            
           
        </div><!-- /.box-body -->
      </div>
               
                     
                    </ContentTemplate>
                </asp:UpdatePanel>
                 
                
            </div><!-- /.box-body -->            
          </div><!-- /.box -->

         <%--<div class="box ">
            <div class="box-header with-border">
              <h3 class="box-title"> Advance Details </h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-minus"></i></button>
                
              </div>
            </div>
            <div class="box-body" id="datalist">
                   
                
                       

                                <asp:UpdatePanel runat="server" ID="uprouteList" UpdateMode="Conditional">
                    <ContentTemplate>

                <table id="example1" class="table table-bordered table-striped">
                   

                 

                <asp:Repeater ID="rpAdvanceDetails" runat="server" OnItemCommand="rpAdvanceDetails_ItemCommand">
                
               <HeaderTemplate>
                  <thead>
                      <tr>
                          <th>SupplierID</th>
                        <th>Advance Amount Paid</th>
                        <th>Advance Paid Date</th> 
                        <th> Advance Paid Instrument</th>
                          <th>Paid Instrument Reference</th>
                           <th>Edit</th>
                          <th>Delete</th>
                      </tr>
                    </thead>
                    <tbody>

                   
               </HeaderTemplate>
               <ItemTemplate>
                    <tr>
                         <td><%# Eval("SupplierID")%></td>
                      <td><%# Eval("AdvAmountPaid")%></td>
                      <td><%# Eval("AdvPaidDate")%></td>
                      <td><%# Eval("AdvPaidInstrument")%></td>
                     
                      <td><%# Eval("AdvPaidInstRef")%></td>
                   
                         <td>

                             <asp:LinkButton ID="lbEdite" AlternateText="Edit" ForeColor="Gray" OnItemCommand="lbEdite_ItemCommand" 
                                                                    ToolTip="Edit" runat="server" CommandArgument='<%#Eval("AdvanceDetailsID") %>'
                                                                    CommandName="Edit"><i class="fa fa-edit"></i></asp:LinkButton>

                         </td>
                         <td>   <asp:LinkButton ID="lbdelete" AlternateText="delete" ForeColor="Gray" OnItemCommand="lbdelete_ItemCommand" 
                                                                    ToolTip="Delete" runat="server" CommandArgument='<%#Eval("AdvanceDetailsID") %>'
                                                                    CommandName="delete"><i class="fa fa-trash"></i></asp:LinkButton>
</td>
                    </tr>
               </ItemTemplate>
                    <FooterTemplate>

                         </tbody>

                    <tfoot>
                      <tr>
                           <th>SupplierID</th>
                        <th>Advance Amount Paid</th>
                        <th>Advance Paid Date</th> 
                        <th> Advance Paid Instrument</th>
                          <th>Paid Instrument Reference</th>
                       
                       
                           <th>Edit</th>
                          <th>Delete</th>
                      </tr>
                    </tfoot>

                    </FooterTemplate>
                                             
           </asp:Repeater>
                    <asp:HiddenField id="hfLoanID" runat="server" />
             
                
                  
                     
                   
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
          </div>--%>
        </section>
</asp:Content>
