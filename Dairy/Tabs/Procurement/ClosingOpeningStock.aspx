<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ClosingOpeningStock.aspx.cs" Inherits="Dairy.Tabs.Procurement.ClosingOpeningStock" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" href="http://localhost:1873/code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css">
    <script src="//code.jquery.com/jquery-1.10.2.js"></script>
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <section class="content-header">
          <h1>
          Opening/Closing Stock
            <small>Procurement</small>
          </h1>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Procurement</a></li>Procurement</a></li>
            <li class="active"> <asp:Label runat="server" ID="lblHeaderTab" Text="Opening/Closing Stock"></asp:Label> </li>
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
                <div class="box" style="margin-left:15px">
            <div class="box-header with-border">
              <h3 class="box-title"><asp:Label ID="lblTabName" runat="server" Text="Opening/Closing Stock"></asp:Label> </h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-plus"></i></button>
                
              </div>
            </div>
            <div class="box-body">
                      <asp:UpdatePanel runat="server" ID="upMain" UpdateMode="Conditional">
                    <ContentTemplate>           

        <div class="box box-solid box-default" style="margin-bottom:5px !important;" >
        <div class="box-header" style="padding:0px 0px 0px 10px !important">
          <h3 class="box-title">Opening/Closing Stock</h3>
        </div><!-- /.box-header -->
        <div class="box-body">
             <div class="row" style="margin-left:0px">

             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <span>Date</span>
                      </div>
                       <asp:TextBox ID="txtDate" class="form-control" placeholder="Date" runat="server" type="date" AutoPostBack="true" OnTextChanged="txtDate_TextChanged"></asp:TextBox>                        
                    </div>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="Date1" ControlToValidate="txtDate" ForeColor="Red"
                        ErrorMessage="Please Select Date  "></asp:RequiredFieldValidator>
                  </div><!-- /.form group --> 
                          
                      </div>                 
             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <span>Opening Stock</span>
                      </div>
                       <asp:TextBox ID="txtopen" class="form-control" placeholder="Opening Stock" runat="server" ReadOnly="true"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group --> 
                          
                      </div>
             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <span>Morning Collection</span>
                      </div>
                       <asp:TextBox ID="txtmorning" class="form-control" placeholder="Morning Milk Collection" runat="server" ReadOnly="true" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group --> 
                          
                      </div>
             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                      <span>Evening Collection</span>
                      </div>
                       <asp:TextBox ID="txtevening" class="form-control" placeholder="Evening Milk Collection" runat="server" ReadOnly="true"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group --> 
                          
                      </div>    
            
                </div>
             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                      <span>Received Milk</span>
                      </div>
                       <asp:TextBox ID="txtreceived" class="form-control" placeholder="Received Milk Collection" runat="server" ReadOnly="true"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group --> 
                          
                      </div>
             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <span>Disposal Milk</span>
                      </div>
                       <asp:TextBox ID="txtdisposal" class="form-control" placeholder="Disposal Milk" runat="server"  ToolTip="Milk In Liter" ReadOnly="true"></asp:TextBox>                        
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->                   
                  </div>  
             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <span>Closing Stock</span>
                      </div>
                       <asp:TextBox ID="txtclosing" class="form-control" placeholder="Closing Stock" runat="server" ReadOnly="true"></asp:TextBox>                        
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->                   
                  </div>    
             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <span>Total Milk Collection</span>
                      </div>
                       <asp:TextBox ID="txttotalmilk" class="form-control" placeholder="Total Milk Collection" runat="server"  ReadOnly="true"></asp:TextBox>                        
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->                   
                  </div> 
             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa  fa-code "></i>
                      </div>
                       <asp:TextBox ID="txtinput" class="form-control" placeholder="adjustment" type="number"  runat="server" ToolTip="adjustment"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div>                  
             <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                        <asp:Button ID="btnUpdate"  class="btn btn-primary" ValidationGroup="Date1" runat="server" CommandName="MoveNext" OnClick="btnUpdate_Click"   Text="Update" />      
                    &nbsp;&nbsp;&nbsp; <asp:Label ID="lblerror" runat="server" Text="No Record found..!" ForeColor="Red" Visible="false"></asp:Label>             
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div>            
            
      </div>
               
                     
                    </ContentTemplate>
                </asp:UpdatePanel>
                 
                
            </div><!-- /.box-body -->            
          </div><!-- /.box -->
         </section>
        <div class="box-body " style="margin-left:20px; margin-top:-20px; margin-right:-20px">
            <div class="box">
            <div class="box-header with-border">
              <h3 class="box-title">Closing /Opening Stock Details List  </h3>
                <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-minus"></i></button>
                
              </div>
            </div>
                <div class="box-body ">
            <asp:UpdatePanel runat="server" ID="uprouteList" UpdateMode="Conditional">
                    <ContentTemplate>
            <div class="pull-right" id="Div1" runat="server">
                <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                      Date<span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtDate1" class="form-control"  placeholder="Collection Date" runat="server" type="date" ToolTip="Collection Date"></asp:TextBox>   
                          
                        </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="Date" ControlToValidate="txtDate1" ForeColor="Red"
                        ErrorMessage="Please Select Date  "></asp:RequiredFieldValidator>
                  </div><!-- /.form group --> 
                          
                      </div>
                <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                 <div class="input-group-addon">
                      Date<span style="color:red">&nbsp;*</span>
                      </div>
                        <asp:TextBox ID="txtDate2" class="form-control" placeholder="Collection Date" runat="server" type="date"  ToolTip="Collection Date"></asp:TextBox>   
                       
                   </div>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"  ValidationGroup="Date"  ControlToValidate="txtDate2" ForeColor="Red"
                        ErrorMessage="Please Select Date  "></asp:RequiredFieldValidator>
                      </div>
                    </div>
                <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                          <asp:Button ID="btnView" class="btn btn-primary" runat="server" CommandName="MoveNext" OnClick="btnView_Click" Text="View" ValidationGroup="Date" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                        <asp:Button ID="btnreport" OnClientClick="return PrintPanel();return true;" Visible="false"  class="btn btn-primary" runat="server" CommandName="MoveNext" Text="Genrate Report"  />         
                       </div>
                    </div>  
                      </div> 
               
                </div>
            <div class="box-body" id="datalist">
                   
                
                       

                                
                         <asp:Panel runat="server" ID="pnlPayment">
                        <asp:Literal runat="server" ID="Payment"></asp:Literal>
              </asp:Panel>
               <%-- <table id="example1" class="table table-bordered table-striped">
                   

                 

                <asp:Repeater ID="rpBatchWiseMilkCollection" runat="server">
                
               <HeaderTemplate>
                  <thead>
                      <tr>
                         
                        <th>Morning Collection</th>
                        <th>Evening Collection</th>
                        <th>Received Collection</th>
                        <th>Disposal Milk</th>
                        <th>Closing Stock</th>
                        <th>Opening Stock</th>
                       <th>Total Milk Collection</th>
                       <%-- <th>Edit</th>
                        <th>Delete</th>--%
                      </tr>
                    </thead>
                    <tbody>

                   
               </HeaderTemplate>
               <ItemTemplate>
                    <tr>

                        <td><%# Eval("Morningcollection")%></td>
                        <td><%# Eval("eveningcollection")%></td>
                        <td><%# Eval("Receivedcollection")%></td>
                        <td><%# Eval("Disposalcollection")%></td>
                        <td><%# Eval("closingstock") %></td>
                        <td><%# Eval("OpeningStock") %></td>
                        <td><%# Eval("TotalMilkCollection") %></td>


                        <%-- <td>

                             <asp:LinkButton ID="lbEdite" AlternateText="Edit" ForeColor="Gray" OnItemCommand="lbEdite_ItemCommand" 
                                                                    ToolTip="Edit" runat="server" CommandArgument='<%#Eval("StockId") %>'
                                                                    CommandName="Edit"><i class="fa fa-edit"></i></asp:LinkButton>

                         </td>
                         <td>   <asp:LinkButton ID="lbdelete" AlternateText="delete" ForeColor="Gray" OnItemCommand="lbdelete_ItemCommand" 
                                                                    ToolTip="Delete" runat="server" CommandArgument='<%#Eval("StockId") %>'
                                                                    CommandName="delete"><i class="fa fa-trash"></i></asp:LinkButton>
</td>--%>
                   <%-- </tr>
               </ItemTemplate>
                    <FooterTemplate>

                         </tbody>

                    <tfoot>
                      <tr>
                        
                        <th>Morning Collection</th>
                        <th>Evening Collection</th>
                        <th>Received Collection</th>
                        <th>Disposal Milk</th>
                        <th>Closing Stock</th>
                        <th>Opening Stock</th>
                       <th>Total Milk Collection</th>--%>
                        <%--<th>Edit</th>
                        <th>Delete</th>--
                      </tr>
                    </tfoot>

                    </FooterTemplate>
                                             
           </asp:Repeater>
                    <asp:HiddenField id="hfStockID" runat="server" />                  
                  </table>--%>
                       


            </div>
                         </ContentTemplate>
                </asp:UpdatePanel>
                    </div>
  <!-- /.box-body --> 
                       <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="uprouteList">
            <ProgressTemplate>
                
                <div class="overlay">
                  <i class="fa fa-refresh fa-spin"></i>
                </div>

            </ProgressTemplate>
            </asp:UpdateProgress>           
          </div>
            </div><!-- /.box -->
       
    <script type = "text/javascript">
        function PrintPanel() {
            debugger;
            var panel = document.getElementById("<%=pnlPayment.ClientID %>");
             var printWindow = window.open('', '', 'height=400,width=800');
             printWindow.document.write("<html> <head> <style type='text/css'>.style1{border-collapse:collapse;} .control-sidebar{display:none;}</style>");
             printWindow.document.write('</head><body >');
             printWindow.document.write(panel.innerHTML);
             printWindow.document.write('</body></html>');
             printWindow.document.close();
             setTimeout(function () {
                 printWindow.print();
             }, 500);
             return true;
         }
    </script>
</asp:Content>
