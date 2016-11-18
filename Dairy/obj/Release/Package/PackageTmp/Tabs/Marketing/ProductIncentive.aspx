<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductIncentive.aspx.cs" Inherits="Dairy.Tabs.Marketing.ProductIncentive" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
   
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
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <section class="content-header">
          <h1>
            Product Incentive
            <small>Administration</small>
          </h1>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Administration</a></li>
            <li class="active">Product Incentive</li>
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
              <div class="box collapsed-box">
            <div class="box-header with-border">
              <h3 class="box-title"><asp:Label runat="server" ID="lblHeaderTab" Text="Incentive Setup "></asp:Label></h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-plus"></i></button>
                
              </div>
            </div>
            <div class="box-body">
               
              
                      <asp:UpdatePanel runat="server" ID="upMain" UpdateMode="Conditional">
                    <ContentTemplate>           
        
               <div class="box box-solid box-default" style="margin-bottom:5px !important;" >
        <div class="box-header" style="padding:0px 0px 0px 10px !important">
          <h3 class="box-title">Incentive Setup </h3>
        </div><!-- /.box-header -->
        <div class="box-body">

               
           

                     <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <i class="fa fa-rode"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:DropDownList ID="dpBrand" class="form-control" DataTextField="Name" DataValueField="CategoryId" runat="server" AutoPostBack="true" OnSelectedIndexChanged = "dpBrand_SelectedIndexChanged" > 
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
                         <asp:DropDownList ID="dpType" class="form-control" DataTextField="Name" DataValueField="TypeID" runat="server" AutoPostBack="true" OnSelectedIndexChanged = "dpType_SelectedIndexChanged" > 
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
                         <asp:DropDownList ID="dpCommodity" class="form-control" DataTextField="Name" DataValueField="CommodityID" runat="server"  > 
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
                       <asp:TextBox ID="txtIncentiveAmt" runat="server" class="form-control" placeholder="Incentive Amt"></asp:TextBox>
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 
           
             <div class="col-lg-3 pull-right">
                  <div class="form-group">
                    <div class="input-group">
                      
                    
                      <asp:Button ID="btnShow" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Show Agents" ValidationGroup="Save" OnClick="btnClick_btnShow" />     
                             &nbsp;  &nbsp; &nbsp; &nbsp;<asp:Button ID="btnAddIncentive" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Save All" ValidationGroup="Save" OnClick="btnClick_btnAddIncentive" />     
                             
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 

              
        </div><!-- /.box-body -->
      </div>
                     
                    </ContentTemplate>
                </asp:UpdatePanel>
                 
                
            </div><!-- /.box-body -->      
                      <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="upMain">
            <ProgressTemplate>
                
                <div class="overlay">
                  <i class="fa fa-refresh fa-spin"></i>
                </div>

            </ProgressTemplate>
            </asp:UpdateProgress>      
          </div><!-- /.box -->
               <div class="box ">
            <div class="box-header with-border">
              <h3 class="box-title"> Insentive Setup List </h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-minus"></i></button>
                
              </div>
            </div>
            <div class="box-body" id="datalist">
                   
                
                       

                                <asp:UpdatePanel runat="server" ID="uprouteList" UpdateMode="Conditional">
                    <ContentTemplate>

                <table id="example1" class="table table-bordered table-striped">
                   

                 

                <asp:Repeater ID="rpBrandInfo" runat="server" OnItemCommand="rpRouteList_ItemCommand">
                
               <HeaderTemplate>
                  <thead>
                      <tr>
                        
                          <th>Product ID</th>
                          <th>Product Name</th>
                             <th>Brand</th>
                           <th>Product Type</th>
                           <th>Commodity</th>
                           <th>IncentiveAmount</th>
                        
                            <th><%--<asp:CheckBox ID="chkHeader" runat="server" />--%>IsActive</th>
                           <th>Save</th>
                        
                      </tr>
                    </thead>
                    <tbody>
               </HeaderTemplate>
               <ItemTemplate>
                    <tr>
                        
                        
                         <td><%# Eval("ProductID")%></td>
                           <td><%# Eval("ProductName")%></td>
                       
                           <td> 
                               <asp:TextBox runat="server" ID="txtBrand" ToolTip="Brand Name" ReadOnly="true" Text='<%#(dpBrand.SelectedItem.Text)%>'/>
                                  </td>
                           <td> <asp:TextBox runat="server" ID="txtType" ToolTip="Product Type Name" ReadOnly="true" Text='<%#(dpType.SelectedItem.Text)%>'/>
                                  </td>
                           <td> <asp:TextBox runat="server" ID="txtCommodity" ToolTip="Commodity Name" ReadOnly="true" Text='<%#(dpCommodity.SelectedItem.Text)%>' />
                                  </td>
                            <td> <asp:TextBox runat="server" ID="txtIncentive" ToolTip="Incentive Amount" onkeypress='return validateQty(this,event);' Text='<%#(txtIncentiveAmt.Text)%>' />
                                  </td>
                        
                     <td> 
                         <asp:CheckBox ID="CheckBox1" runat="server" Checked="true" ></asp:CheckBox>
</td>
                         <td>
                                <asp:HiddenField id="hfProductId" runat="server" value='<%#Eval("ProductID") %>' />                 
                             <asp:LinkButton ID="lbEdite" AlternateText="Save" ForeColor="Gray" OnItemCommand="lbEdite_ItemCommand" 
                                                                    ToolTip="Save" runat="server" CommandArgument='<%#Eval("ProductID") %>'
                                                                    CommandName="Edit"><i class="btn btn-primary"></i></asp:LinkButton>

                         </td>
                        
                    </tr>
               </ItemTemplate>
                    <FooterTemplate>

                         </tbody>

                    <tfoot>
                      <tr>
                           
                        
                          <th>Product ID</th>
                          <th>Product Name</th>
                             <th>Brand</th>
                           <th>Product Type</th>
                           <th>Commodity</th>
                            
                           <th>IncentiveAmount</th>
                      
                              <th>IsActive</th>
                          <th>Save</th>
                         
                      </tr>
                    </tfoot>
                    </FooterTemplate>                                       
           </asp:Repeater>
                    <asp:HiddenField id="hfBrandId" runat="server" />                 
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
     <script type="text/javascript"><!--
    function validateQty(el, evt) {
        var charCode = (evt.which) ? evt.which : event.keyCode
        if (charCode != 45 && charCode != 8 && (charCode != 46) && (charCode < 48 || charCode > 57))
            return false;
        if (charCode == 46) {
            if ((el.value) && (el.value.indexOf('.') >= 0))
                return false;
            else
                return true;
        }
        return true;
        var charCode = (evt.which) ? evt.which : event.keyCode;
        var number = evt.value.split('.');
        if (charCode != 46 && charCode > 31 && (charCode < 48 || charCode > 57)) {
            return false;
        }
    };
    $(function () {
        $("#example1 [id*=chkHeader]").click(function () {
            if ($(this).is(":checked")) {
                $("#example1 [id*=CheckBox1]").attr("checked", "checked");
            } else {
                $("#example1 [id*=CheckBox1]").removeAttr("checked");
            }
        });
        $("#example1 [id*=CheckBox1]").click(function () {
            if ($("#example1 [id*=CheckBox1]").length == $("#tblCustomers [id*=CheckBox1]:checked").length) {
                $("#example1 [id*=chkHeader]").attr("checked", "checked");
            } else {
                $("#example1 [id*=chkHeader]").removeAttr("checked");
            }
        });
    });
   </script>
    
</asp:Content>
