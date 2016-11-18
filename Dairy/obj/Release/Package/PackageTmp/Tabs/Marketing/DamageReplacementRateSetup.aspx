<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DamageReplacementRateSetup.aspx.cs" Inherits="Dairy.Tabs.Marketing.DamageReplacementRateSetup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <section class="content-header">
          <h1>
             Damage Replacement Rate Setup 
            <small>Administration</small>
          </h1>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Administration</a></li>
            <li class="active"> Damage Replacement Rate Setup   </li>
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
              <h3 class="box-title"><asp:Label runat="server" ID="lblHeaderTab" Text=" Damage Replacement Rate Setup  "></asp:Label></h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-plus"></i></button>
                
              </div>
            </div>
            <div class="box-body">
               
              
                      <asp:UpdatePanel runat="server" ID="upMain" UpdateMode="Conditional">
                    <ContentTemplate>           
        
               <div class="box box-solid box-default" style="margin-bottom:5px !important;" >
        <div class="box-header" style="padding:0px 0px 0px 10px !important">
          <h3 class="box-title">Damage Replacement Rate Setup  </h3>
        </div><!-- /.box-header -->
        <div class="box-body">

               
             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                         <asp:DropDownList ID="dpRoute" data-live-search="true" class="selectpicker form-control" data-toggle="dropdown" DataTextField="Name" DataValueField="RouteID" runat="server" AutoPostBack="true" OnSelectedIndexChanged = "dpRoute_SelectedIndexChanged" ToolTip="Please Select Route" > 
                       </asp:DropDownList>
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 

                     <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <i class="fa fa-rode"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:DropDownList ID="dpBrand" class="form-control" DataTextField="Name" DataValueField="CategoryId" runat="server" AutoPostBack="true" OnSelectedIndexChanged = "dpBrand_SelectedIndexChanged" ToolTip="Please Select Brand" > 
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
                         <asp:DropDownList ID="dpType" class="form-control" DataTextField="Name" DataValueField="TypeID" runat="server" AutoPostBack="true" OnSelectedIndexChanged = "dpType_SelectedIndexChanged" ToolTip="Please Select Product Type" > 
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
                         <asp:DropDownList ID="dpCommodity" class="form-control" DataTextField="Name" DataValueField="CommodityID" runat="server" ToolTip="Please Select Commodity" > 
                       </asp:DropDownList>
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 
              <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                     
                       <asp:TextBox ID="txtDamageReplacementRate" runat="server" class="form-control" placeholder="Damage Replacement Rate Percentage" ToolTip="Enter Damage Replace Rate Percentage"></asp:TextBox>
                      <div class="input-group-addon">
                         <i class="fa fa-percent" ></i><span style="color:red">&nbsp;%</span>
                      </div>
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 
           
             <div class="col-lg-3 pull-right">
                  <div class="form-group">
                    <div class="input-group">
                      
                    
                      <asp:Button ID="btnShow" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Show Agents" ValidationGroup="Save" OnClick="btnClick_btnShow" />     
                             &nbsp;  &nbsp; <asp:Button ID="btnAddIncentive" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Save All" ValidationGroup="Save" OnClick="btnClick_btnAddIncentive" />     
                         &nbsp;  &nbsp;<asp:Button ID="btnAddNew" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Add New"  OnClick="btnAddNew_Click" />     
                             
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
              <h3 class="box-title"> Damage Replacement Rate Setup List </h3>
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
                        
                          <th>AgentCode</th>
                          <th>AgentName</th>
                            <th>Route</th>
                            <th>Brand</th>
                           <th>Product Type</th>
                           <th>Commodity</th>
                           <th>Previous Rate<span style="color:red">&nbsp;%</span></th>
                            <th>ReplacementRate<span style="color:red">&nbsp;%</span></th>
                          
                        
                            <th><%--<asp:CheckBox ID="chkHeader" runat="server" />--%>IsActive</th>
                           <th>Save</th>
                        
                      </tr>
                    </thead>
                    <tbody>
               </HeaderTemplate>
               <ItemTemplate>
                    <tr>
                        
                        
                         <td><%# Eval("AgentCode")%></td>
                           <td><%# Eval("AgentName")%></td>
                         <td><%# dpRoute.SelectedItem.Text%></td>
                           <td> 
                               <asp:TextBox runat="server" ID="txtBrand" ToolTip="Brand Name" ReadOnly="true" Text='<%#(dpBrand.SelectedItem.Text)%>'/>
                                  </td>
                           <td> <asp:TextBox runat="server" ID="txtType" ToolTip="Product Type Name" ReadOnly="true" Text='<%#(dpType.SelectedItem.Text)%>'/>
                                  </td>
                           <td> <asp:TextBox runat="server" ID="txtCommodity" ToolTip="Commodity Name" ReadOnly="true" Text='<%#(dpCommodity.SelectedItem.Text)%>' />
                                  </td>
                          <td> <asp:TextBox runat="server" ID="txtPreviousDRR" ToolTip="Previous Damage Replace Rate" ReadOnly="true" Text='<%#(String.IsNullOrEmpty(Convert.ToDecimal(Eval("Damagereplacementrate")).ToString("###.##")) ? "Not set" : Convert.ToDecimal(Eval("Damagereplacementrate")).ToString("###.##"))%>' />
                                  </td>
                            <td> <asp:TextBox runat="server" ID="txtdamagereplacerate" ToolTip="Damage Replace Rate" onkeypress='return validateQty(this,event);' Text='<%#(Convert.ToDecimal(txtDamageReplacementRate.Text))%>' /> 
                                   
                       </td>
                        
                     <td> 
                         <asp:CheckBox ID="CheckBox1" runat="server" Checked="true" ></asp:CheckBox>
</td>
                         <td>
                                <asp:HiddenField id="hfAgentId" runat="server" value='<%#Eval("AgentID") %>' />                 
                             <asp:LinkButton ID="lbEdite" AlternateText="Save" ForeColor="Gray" OnItemCommand="lbEdite_ItemCommand" 
                                                                    ToolTip="Save" runat="server" CommandArgument='<%#Eval("AgentID") %>'
                                                                    CommandName="Edit"><i class="btn btn-primary"></i></asp:LinkButton>

                         </td>
                        
                    </tr>
               </ItemTemplate>
                    <FooterTemplate>

                         </tbody>

                    <tfoot>
                      <tr>
                           
                          <th>AgentCode</th>
                          <th>AgentName</th>
                              <th>Route</th>
                            <th>Brand</th>
                           <th>Product Type</th>
                           <th>Commodity</th>
                         <th>Previous Rate<span style="color:red">&nbsp;%</span></th>
                            <th>ReplacementRate<span style="color:red">&nbsp;%</span></th>
                      
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
    <script type="text/javascript">
        function pageLoad() {
            $("#<% =dpRoute.ClientID %>").addClass("form-control");
        }


</script> 
  
  
</asp:Content>
