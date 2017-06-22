<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MachineCondition.aspx.cs" Inherits="Dairy.Tabs.Production.MachineCondition" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   <section class="content-header">
          <h1>
          Machine Condition
           <small>when starting Production</small>
          </h1>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Administration</a></li>
            <li class="active">Machine Condition</li>
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
                                <asp:Label runat="server" ID="lblSuccess" Text="Order Received Succesfully"></asp:Label>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
                   
       <div id="bx1" class="box collapsed-box">

            <div class="box-header with-border">
              <h3 class="box-title"><asp:Label ID="lblHeaderTab" runat="server" Text="Machine Condition"></asp:Label> </h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-plus"></i></button>
                
              </div>
            </div>
            <div class="box-body">

                 <asp:UpdatePanel runat="server" ID="upMain" UpdateMode="Conditional">
              <ContentTemplate> 

 <div class="row">
                    <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
                          <asp:Label ID="lbldatetime" runat="server" Text="Date time"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtdatetime" class="form-control"   placeholder="Datetime" runat="server" ></asp:TextBox>       
                         <span class="input-group-addon">
                        <span class="glyphicon glyphicon-calendar"></span>
                    </span>                 
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator  ID="RequiredFieldValidator1" Display="Dynamic" 
                                        ValidationGroup="Save" runat="server" ControlToValidate="txtBatchNo" ForeColor="Red"
                                        ErrorMessage="Pls Enter RMR Batch Number " style="font-size:12px;"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
                 </div>

                 

                <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
                     <i class="fa fa-road"></i><span style="color:red">&nbsp;*</span>
                 <asp:Label ID="lblMachineName" runat="server" Text="Machine Name"></asp:Label>

                      </div>
                      <asp:DropDownList ID="dpMachineName" class="form-control" DataValueField="MID" DataTextField="Name"   runat="server"  > 
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                        <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator2" Display="Dynamic" 
                             ValidationGroup="Save" runat="server" ControlToValidate="dpShiftDetails" ForeColor="Red"
                             ErrorMessage="Pls Select Machine Details" style="font-size:12px;">
                         </asp:RequiredFieldValidator>

                  </div><!-- /.form group -->
                         </div>


                   
              <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">

                          <asp:Label ID="lblBDTill" runat="server" Text="B.D Till"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtBdTill" class="form-control" type="text"        placeholder="B.D Till" ToolTip="Enter B.D" runat="server" ></asp:TextBox>        
                    </div><!-- /.input group -->
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtBdTill" runat="server" ErrorMessage="Please Enter B.D" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
            </div>

</div>

 <div class="row">

               <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
                 
                          <asp:Label ID="lblReport" runat="server" Text="Report"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtReport" class="form-control"        placeholder="Report" ToolTip="Report" runat="server" ></asp:TextBox>        
                    </div><!-- /.input group -->
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please Enter Report Details"  ControlToValidate="txtReport" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
            </div>

                    <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
                          <asp:Label ID="lblService" runat="server" Text="Service"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtService" class="form-control"   placeholder="Enter Service Name" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
        <asp:RequiredFieldValidator  ID="RequiredFieldValidator5" Display="Dynamic" 
                                        ValidationGroup="Save" runat="server" ControlToValidate="txtService" ForeColor="Red"
                                        ErrorMessage="Pls Enter Service Name" style="font-size:12px;"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
                 </div>
             
     <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
                          <asp:Label ID="lblPending" runat="server" Text="Pending"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtPending" class="form-control"   placeholder="Enter Pending Details" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
     <asp:RequiredFieldValidator  ID="RequiredFieldValidator6" Display="Dynamic" 
                                        ValidationGroup="Save" runat="server" ControlToValidate="txtPending" ForeColor="Red"
                                        ErrorMessage="Pls Enter Pending Details" style="font-size:12px;"></asp:RequiredFieldValidator>
                 
                  </div><!-- /.form group -->
                 </div>


                <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
                     
                        <asp:Label ID="lblCondition" runat="server" Text="Machine Condition"></asp:Label>

                      </div>
                      <asp:DropDownList ID="dpOilLeakage" class="form-control" DataValueField="StatusId" DataTextField="Name"   runat="server"  > 
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                        <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator7" Display="Dynamic" 
                             ValidationGroup="Save" runat="server" ControlToValidate="dpOilLeakage" ForeColor="Red"
                             ErrorMessage="Pls Select Oil Leakage Details" style="font-size:12px;">
                         </asp:RequiredFieldValidator>

                  </div><!-- /.form group -->
                         </div>

</div>

 
             </ContentTemplate>
         </asp:UpdatePanel>
                 </div><!-- /.box-body -->            
     </div><!-- /.box -->

                          

    </section>
</asp:Content>
