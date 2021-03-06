﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RawMilkStockRegister.aspx.cs" Inherits="Dairy.Tabs.Procurement.RawMilkStockRegister" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css">
    <script src="//code.jquery.com/jquery-1.10.2.js"></script>
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   <%-- <script type="text/javascript">

        $(function () {
            $("#MainContent_txtDate").datepicker({ format: 'dd-MM-yyyy' });

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
          MilkReceiving/Disposing Details
            <small>Procurement</small>
          </h1>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Procurement</a></li>
            <li class="active"> <asp:Label runat="server" ID="lblHeaderTab" Text="Batch Wise Milk Collection"></asp:Label> </li>
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
              <h3 class="box-title"><asp:Label ID="lblTabName" runat="server" Text="MilkReceiving/Disposing Details"></asp:Label> </h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-plus"></i></button>
                
              </div>
            </div>
            <div class="box-body">
               
              
                      <asp:UpdatePanel runat="server" ID="upMain" UpdateMode="Conditional">
                    <ContentTemplate>           

        <div class="box box-solid box-default" style="margin-bottom:5px !important;" >
        <div class="box-header" style="padding:0px 0px 0px 10px !important">
          <h3 class="box-title">Batch Wise Milk Collection </h3>
        </div><!-- /.box-header -->
        <div class="box-body">
            <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                        Recieving & Disposal :&nbsp&nbsp
                        <asp:RadioButton ID="rdRecieving" runat="server" Text="Recieving" GroupName="grp" AutoPostBack="true" OnCheckedChanged="rdRecieving_CheckedChanged"></asp:RadioButton>&nbsp&nbsp&nbsp&nbsp
                        <asp:RadioButton ID="rdDisposal" runat="server" Text="Disposal" GroupName="grp" AutoPostBack="true" OnCheckedChanged="rdDisposal_CheckedChanged"></asp:RadioButton>
                       
                    </div><!-- /.input group -->

                  </div><!-- /.form group --> 
                          
                      </div>
            
            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtDate" class="form-control" placeholder="Date" runat="server" type="date" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                       
                  </div><!-- /.form group --> 
                          
                      </div> 
            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtTime" class="form-control" placeholder="Time" runat="server"  Type="time"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group --> 
                          
                      </div> 
      <%--     <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                        <asp:DropDownList ID="dpSession" class="form-control"  runat="server" selected ToolTip="Select Session"> 
                            <asp:ListItem Value="0">Morning</asp:ListItem>
                            <asp:ListItem Value="1">Evening</asp:ListItem>
                       </asp:DropDownList>                          
                    </div><!-- /.input group -->

                  </div><!-- /.form group --> 
                          
                      </div> --%>

            

             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <i class="fa fa-rode"></i><span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:DropDownList ID="dpMilkType" class="form-control" runat="server" ToolTip="Select Milk Type"> 
                          <asp:ListItem Value="0">--Select Milk Type--</asp:ListItem>
                          <asp:ListItem Value="1">Can Milk</asp:ListItem>
                          <asp:ListItem Value="2">Loose Milk</asp:ListItem>
                          <asp:ListItem Value="3">Raw Milk</asp:ListItem>
                          <asp:ListItem Value="4">Raw Chilled Milk</asp:ListItem>
                          <asp:ListItem Value="5">skimmed milk</asp:ListItem>
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->

                     
                       
                          
                      </div>  

           <div class="col-lg-3" id="d2" runat="server">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:DropDownList ID="dpParticularreceive" class="form-control" DataTextField="Name" DataValueField="ID" runat="server" ToolTip="Select Particular"> 
                       </asp:DropDownList>                   
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 
           
    <%--        <div class="col-lg-9" id="d1" runat="server">--%>
             <%-- <div class="col-lg-4">--%>
                 <%-- <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <i class="fa fa-rode"></i><span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:DropDownList ID="dpdestination" class="form-control" runat="server" selected ToolTip="Select Disposal Destination"> 
                          <asp:ListItem Value="0">--Select Disposal--</asp:ListItem>
                          <asp:ListItem Value="1">To Nanjil</asp:ListItem>
                          <asp:ListItem Value="2">To NCC</asp:ListItem>
                          <asp:ListItem Value="3">To Other Dairy</asp:ListItem>
                          <asp:ListItem Value="4">Internal Use</asp:ListItem>
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->--%>
            <%--    </div>--%>
               <div class="col-lg-3" id="d1" runat="server">
                        <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <i class="fa fa-rode"></i><span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:DropDownList ID="dpParticulardispose" class="form-control" DataTextField="Name" DataValueField="ID" runat="server" ToolTip="Select Particular"> 
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->
                       
                        </div>

                    <%-- </div>--%>

                      
                          
                   
          

             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtVehicalNo" class="form-control" placeholder="Vehical No" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group --> 
                          
                      </div>

             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtBatch" class="form-control" placeholder="Batch" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group --> 
                          
                      </div>
                 
             
             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtMilkInKG" class="form-control" placeholder="Milk In Kg" runat="server" AutoPostBack="true" OnTextChanged="txtMilkInKG_TextChanged" type="number" step="any" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group --> 
                          
                      </div>
            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtMilkInLtr" class="form-control" placeholder="Milk In Liter" runat="server"  ToolTip="Milk In Liter" ReadOnly="true"></asp:TextBox>                        
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->                   
                  </div>  

            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtTEmp" class="form-control" placeholder="Temp" runat="server"  ToolTip="Temp" type="number" step="any"></asp:TextBox>                        
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->                   
                  </div>  

            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtAcidity" class="form-control" placeholder="Acidity" runat="server"  ToolTip="Acidity" type="number" step="any"></asp:TextBox>                        
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->                   
                  </div> 

            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa  fa-code "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtFATPercentage" class="form-control" placeholder="FAT %"  runat="server" type="number" step="any"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div>  

                <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa  fa-code "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtSNFPercentage" class="form-control" placeholder="SNF %"  runat="server" type="number" step="any" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div>         
             <%--<div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa  fa-code "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtHandlingExcess" class="form-control" placeholder="Handling Excess in Ltr" type="text" runat="server"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div>
            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa  fa-code "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtHandlingLoss" class="form-control" placeholder="Handling Loss in Ltr" type="text" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div>--%>
        <%--    <div id="disp" runat="server">--%>
           <%-- <div class="col-lg-3">--%>
                  <%--<div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa  fa-code "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtInternalConsumption" class="form-control" placeholder="InternalConsumption in Ltr" type="text" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><--%>

                     
                       
                          
                   <%--   </div>--%>
            <%--<div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa  fa-code "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtDamageMilk" class="form-control" placeholder="DamageMilk in Ltr" type="text" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div>--%>
          
             <%--   </div>--%>
              <%--<div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa  fa-code "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="TextBtxtOther" class="form-control" placeholder="Other in Ltr" type="text" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
               
                     </div>--%>
                   <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      
                    
                      
                              <asp:Button ID="btnAddMilk" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Add" ValidationGroup="Save" OnClick="btnAddMilk_Click" />     
                        <asp:Button ID="btnupdateMilk" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Update" ValidationGroup="Save" OnClick="btnupdateMilk_Click" />      
                        &nbsp;&nbsp;&nbsp; <asp:Button ID="btnAddNew" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Add New" ValidationGroup="Save" OnClick="btnAddNew_Click" />                
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
              <h3 class="box-title">MilkReceiving/Disposing Details List </h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-minus"></i></button>
                
              </div>
            </div>
            <div class="pull-right" id="Div1" runat="server">
               <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                      Date
                      </div>
                       <asp:TextBox ID="txtDate1" class="form-control" placeholder="Collection Date" runat="server" type="date"  ToolTip="Collection Date"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group --> 
                          
                      </div>
             <%-- <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                      Collection Center
                      </div>
                 <asp:DropDownList ID="dpCenter" class="form-control" DataTextField="Name" DataValueField="CenterID" runat="server" selected ToolTip="Select Center"> 
                       </asp:DropDownList>
                           </div><!-- /.input group -->

                  </div><!-- /.form group --> 
                          
                      </div>--%>
                  <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                          <asp:Button ID="btnView" class="btn btn-primary" runat="server" CommandName="MoveNext" OnClick="btnView_Click"   Text="View"  />     
                       </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 
                </div>
            <div class="box-body" id="datalist">
                   
                
                       

                                <asp:UpdatePanel runat="server" ID="uprouteList" UpdateMode="Conditional">
                    <ContentTemplate>

                <table id="example1" class="table table-bordered table-striped">
                   

                 

                <asp:Repeater ID="rpBatchWiseMilkCollection" runat="server" OnItemCommand="rpBatchWiseMilkCollection_ItemCommand">
                
               <HeaderTemplate>
                  <thead>
                      <tr>
                         
                        <th>Date</th>
                         <th>TIME</th>
                        <th>CollectionCenter</th>
                  
                        <th>VehicalNo</th>
                        <th>BatchNo</th>
                        <th>Milk In Ltr</th>
                        <th>Temp</th>
                         <th>Acidity</th>
                         <th>FAT Percentage</th>
                         <th>SNF Percentage</th>
                          <th>Edit</th>
                          <th>Delete</th>
                      </tr>
                    </thead>
                    <tbody>

                   
               </HeaderTemplate>
               <ItemTemplate>
                    <tr>
                        
                          <td><%# Convert.ToDateTime(Eval("Date")).ToString("dd-MM-yyyy")%></td>
                           <td><%# Eval("Session")%></td>
                          <td><%# Eval("Center")%></td>
                          <td><%# Eval("VehicalNo")%></td>
                          <td><%# Eval("BatchNo")%></td>
                        <td><%# Eval("MilkInLtr") %></td>
                        <td><%# Eval("Temp") %></td>
                        <td><%# Eval("Acidity") %></td>
                        <td><%# Eval("FATPercentage") %></td>
                        <td><%# Eval("SNFPercentage") %></td>

                         <td>

                             <asp:LinkButton ID="lbEdite" AlternateText="Edit" ForeColor="Gray" OnItemCommand="lbEdite_ItemCommand" 
                                                                    ToolTip="Edit" runat="server" CommandArgument='<%#Eval("BatchWiseMilkCollectionID") %>'
                                                                    CommandName="Edit"><i class="fa fa-edit"></i></asp:LinkButton>

                         </td>
                         <td>   <asp:LinkButton ID="lbdelete" AlternateText="delete" ForeColor="Gray" OnItemCommand="lbdelete_ItemCommand" 
                                                                    ToolTip="Delete" runat="server" CommandArgument='<%#Eval("BatchWiseMilkCollectionID") %>'
                                                                    CommandName="delete"><i class="fa fa-trash"></i></asp:LinkButton>
</td>
                    </tr>
               </ItemTemplate>
                    <FooterTemplate>

                         </tbody>

                    <tfoot>
                      <tr>
                        
                        <th>Date</th>
                           <th>TIME</th>
                        <th>CollectionCenter</th>
                   
                        <th>VehicalNo</th>
                        <th>BatchNo</th>
                        <th>Milk In Ltr</th>
                        <th>Temp</th>
                         <th>Acidity</th>
                         <th>FAT Percentage</th>
                         <th>SNF Percentage</th>
                           <th>Edit</th>
                          <th>Delete</th>
                      </tr>
                    </tfoot>

                    </FooterTemplate>
                                             
           </asp:Repeater>
                    <asp:HiddenField id="hfBatchWiseMilkCollectionID" runat="server" />
             
                
                  
                     
                   
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
