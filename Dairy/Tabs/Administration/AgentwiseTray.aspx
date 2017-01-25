<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgentwiseTray.aspx.cs" Inherits="Dairy.Tabs.Administration.Agentwise_Tray" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="../../Theme/MyJavaScript/bootstrap-select.min.css" rel="stylesheet" />
    <style type="text/css">
        .textb {
            width:7%;
            text-align:center;
        }
        .text {
            text-align: center;
            color: red;
            font-style: initial;
            font-weight: bold;
        }
    </style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <section class="content-header">
          <h1>
             Agentwise Tray
            <small>Administration</small>
          </h1>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Administration</a></li>
            <li class="active"> Agentwise Tray</li>
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
                            <div class="alert alert-warning alert-dismissable" runat="server" id="divwarning" visible="false">
                                <h4>
                                    <i class="icon fa fa-warning"></i>Warning!</h4>
                                <asp:Label runat="server" ID="lblwarning" Text="Something Went wrong Please Try Again"></asp:Label>
                            </div>
                            <div class="alert alert-success alert-dismissable" runat="server" id="divSusccess" visible="false">
                                <h4>
                                    <i class="icon fa fa-check"></i>Success!</h4>
                                <asp:Label runat="server" ID="lblSuccess" Text="Records Insert Succesfully"></asp:Label>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>          
               <div class="box ">
            <div class="box-header with-border">
              <h3 class="box-title"> Agentwise Tray Info List </h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-minus"></i></button>
                
              </div>
            </div>
            <div class="box-body" id="datalist">
                   
            <asp:UpdatePanel runat="server" ID="upMain" UpdateMode="Conditional">
                    <ContentTemplate>

        <asp:UpdatePanel runat="server" ID="uprouteList" UpdateMode="Conditional">
                    <ContentTemplate>  
    <div class="row">

           <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtAgentwiseTrayDate" class="form-control" type="date"  runat="server"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 


         <div class="col-lg-3 col-md-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label17" runat="server" Text="ID"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtSearchDispatchId" class="form-control" type="number" placeholder="Enter Dispatch Id" required="" runat="server"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
                          
                      </div> 

            <div class="col-lg-3 col-md-3">
                  <div class="form-group">
                    <div class="input-group">
                      
                        <asp:Button ID="btnSearch" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Search" ValidationGroup="Save" OnClick="btnSearch_Click" />    
                         &nbsp;  &nbsp; <asp:Button ID="btnSubmit" class="btn btn-primary" runat="server" CommandName="MoveNext" Text="Save All" ValidationGroup="Save" OnClick="btnSubmit_Click" />    
                    
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
               </div>
        </div>
                        <div class="col-md-12 col-lg-12" style="text-align:left">
                            <asp:Label ID="lblerr" runat="server" CssClass="text" Text="" Visible="false"></asp:Label>
                        </div>
                         <table class="table table-bordered table-striped" style="margin-bottom:0px">  
                        <tr id="TraysInfo" visible="false" runat="server">
                        <td align="right" style="width:50%">
                        Total Dispatched Trays : <asp:Label ID="tdt" runat="server" Text=""></asp:Label> 
                        </td>
                            <td style="width:11%"></td>
                         <td align="left">
                             Total Returned Trays :<asp:Label ID="trt" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                             </table>
                <table class="table table-bordered table-striped">
                    
                       <asp:UpdatePanel runat="server" ID="textc" UpdateMode="Conditional">
                    <ContentTemplate>
                       
                             
                <asp:Repeater ID="rpAgentwiseTrayInfo"  runat="server" OnItemCommand="rpAgentwiseTrayInfo_ItemCommand" OnItemDataBound="rpAgentwiseTrayInfo_ItemDataBound">
               
               <HeaderTemplate>
                  <thead>

                           <tr>
                        
                         <th>DI_Id</th>
                          <th>Agent/Employee Name</th>
                          <th>TraysDispached  </th>
                             
                            <th>Return Trays</th>
                           
                               <th>Excess</th>
                               <th>Short</th>
<%--                              <th>Total Trays Dispatch: <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label></th>--%>
                                  
                          <%--<th id="trTrays" runat="server" visible="false"><%# Eval("TraysDispached")%>  </th>--%>
                        <%-- <th><asp:Label ID="lblHeader" runat="server" Font-Bold = "true" align="right"></asp:Label></th>--%>
                      </tr>
                    </thead>
                    <tbody>
               </HeaderTemplate>
               <ItemTemplate>
                    <tr>
                        
                        
                         <td><%# Eval("DI_Id")%></td>
                           <td><%#(string.IsNullOrEmpty(Eval ("AgentName").ToString()) ? Eval("EmployeeName") : Eval ("AgentName"))%></td>
                              <td> <asp:TextBox ID="txtTraysDispached"  runat="server" OnTextChanged="TraysDispached_TextChanged" Text='<%#(string.IsNullOrEmpty(Eval("Trays_Dispached").ToString()) ? null : Eval("Trays_Dispached")) %>' AutoPostBack="true" onblur="validate(this)"></asp:TextBox></td>
                        <td> <asp:TextBox ID="txtReturnTrays"  runat="server"  OnTextChanged="ReturnTrays_TextChanged" Text='<%#(string.IsNullOrEmpty(Eval("Trays_Return").ToString()) ? null : Eval("Trays_Return")) %>' AutoPostBack="true" onblur="validate(this)"></asp:TextBox></td>
                        
<%--                        <td> <asp:Label ID="TotTrays" runat="server" Text='<%#(string.IsNullOrEmpty(Eval("TotalTrays").ToString()) ? 0 : Eval("TotalTrays")) %>'></asp:Label>--%>
                       <td><asp:Label ID="lblExcess" runat="server" Text='0'></asp:Label></td>
                       <td><asp:Label ID="lblShort" runat="server" Text='0'></asp:Label></td>
                        <asp:HiddenField id="hfDI_Id"  runat="server" value='<%#Eval("DI_Id") %>' />       
                        <asp:HiddenField id="hfagentId" runat="server" value='<%#Eval("AgentID") %>' /> 
                        <asp:HiddenField id="hfemployeeId" runat="server" value='<%#Eval("EmployeeID") %>' /> 
                        <asp:HiddenField id="hfSalesmanId" runat="server" value='<%#Eval("DI_SalesmanFirstId") %>' /> 
                             <asp:HiddenField id="hfDI_RouteId" runat="server" value='<%#Eval("DI_RouteId") %>' /> 
                            </td>
                    </tr>
               </ItemTemplate>
                    <FooterTemplate>

                         </tbody>

                    <tfoot>
                      <tr>
                           
                          <tr id="trEmpty" runat="server" visible="false"><td  align = "left"><b> No records found.</b></td> </tr>
                         

                          <th></th>
                          <th></th>
                            
                          <th id="ttl">Trays Dispached: <asp:Label ID="lblSum" runat="server" Text="0" ></asp:Label></th>
                          <th id="Th1">Return Trays: <asp:Label ID="lblSum1" runat="server" Text="0" ></asp:Label></th>
                         <%-- <th id="Th2">Pending Trays: <asp:Label ID="lblTot" runat="server" Text="0" ></asp:Label></th>--%>
                          <th id="Th3">Excess: <asp:Label ID="lblExc" runat="server" Text="0" ></asp:Label></th>
                           <th id="Th4">Short: <asp:Label ID="lblShrt" runat="server" Text="0" ></asp:Label></th>
                         
                      </tr>
                    </tfoot>
                    </FooterTemplate>                                       
           </asp:Repeater>
                      </ContentTemplate>
                     </asp:UpdatePanel>            
                  </table>
                        <asp:HiddenField id="HiddenField1" runat="server" />    
                        </ContentTemplate>

                </asp:UpdatePanel>
  

            </div><!-- /.box-body -->  
                        </ContentTemplate>
                                  </asp:UpdatePanel> 
                       <asp:UpdateProgress ID="UpdateProgress3" runat="server" AssociatedUpdatePanelID="uprouteList">
            <ProgressTemplate>
                
                <div class="overlay">
                  <i class="fa fa-refresh fa-spin"></i>
                </div>

            </ProgressTemplate>
            </asp:UpdateProgress>         
          </div><!-- /.box -->
                   </div>
        </section>


    <%--    <script type="text/javascript" src="../../Theme/MyJavaScript/bootstrap-select.min.js"></script>--%>
 <script type="text/javascript">
    function validate(c)
        {
            if(c.value=="")
            {
               
                c.focus();
            }
            else
            {
                //$('#txtReturnTrays').css('border-color', '');
            }
            
        }
</script>

</asp:Content>