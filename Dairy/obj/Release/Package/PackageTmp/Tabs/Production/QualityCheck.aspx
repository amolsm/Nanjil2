<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="QualityCheck.aspx.cs" Inherits="Dairy.Tabs.Production.QualityCheck" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
         <link href="../../Theme/plugins/jQueryUI/jquery-ui.css" rel="stylesheet" />
        <script src="../../Theme/plugins/jQuery/jquery-1.10.2.min.js"></script>
        <script src="../../Theme/plugins/jQueryUI/jquery-ui.min.js"></script>
        <style type="text/css">.cntrlbtm {    margin-bottom: 1px;} </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section class="content-header">
          <h1>
           Quality Analysis 
            <small>Details</small>    
          </h1> 
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Administration</a></li>
            <li class="active">Qlty</li>
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
              <h3 class="box-title"><asp:Label ID="lblHeaderTab" runat="server" Text="Milk Quality Details"></asp:Label> </h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-plus"></i></button>
                
              </div>
            </div>
            <div class="box-body">

                      <asp:UpdatePanel runat="server" ID="upMain" UpdateMode="Conditional">
            <ContentTemplate>           
        
         <div class="row">
            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label14" runat="server" Text="RMR Batch No" ></asp:Label>
                      </div>
                       <asp:TextBox ID="txtBatchNo" class="form-control"   placeholder="RMR Batch No " runat="server" ValidationGroup="Save" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator  ID="RequiredFieldValidator4" Display="Dynamic" 
                                        ValidationGroup="Save" runat="server" ControlToValidate="txtBatchNo" ForeColor="Red"
                                        ErrorMessage="Pls Enter RMR Batch Number " style="font-size:12px;"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
                 </div>


               <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="lblDate" runat="server" Text="Date"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtDate" class="form-control" type="date" runat="server" ValidationGroup="Save" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
                                        
                          
                      </div> 

               <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                       <i class="fa fa-road"></i><span style="color:red">&nbsp;*</span>--%>
                        <asp:Label ID="lblShift" runat="server" Text="Shift" ></asp:Label>

                      </div>
                      <asp:DropDownList ID="dpShiftDetails" class="form-control" DataValueField="ShiftId" DataTextField="Name"   runat="server" ValidationGroup="Save"  > 
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                        <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator19" Display="Dynamic" 
                             ValidationGroup="Save" runat="server" ControlToValidate="dpShiftDetails" ForeColor="Red"
                             ErrorMessage="Pls Select Shift Details" style="font-size:12px;">
                         </asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
                         </div>

               <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="lblMilkType" runat="server" Text="Type Of Milk"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtMilkType" class="form-control"   placeholder="Enter Milk Type" runat="server" ValidationGroup="Save" ></asp:TextBox>                        
                    </div><!-- /.input group -->
          <asp:RequiredFieldValidator  ID="RequiredFieldValidator1" Display="Dynamic" 
                                        ValidationGroup="Save" runat="server" ControlToValidate="txtMilkType" ForeColor="Red"
                                        ErrorMessage="Pls Enter Milk Type " style="font-size:12px;"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
                 </div>

             </div>

                  <div class="row">

               <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="lblTankerReceipt" runat="server" Text="Tanker Milk Receipt No"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtTankerReceipitNo" class="form-control"   placeholder="Tanker Milk Receipt No " runat="server" ValidationGroup="Save" ></asp:TextBox>                        
                    </div><!-- /.input group -->
              <asp:RequiredFieldValidator  ID="RequiredFieldValidator2" Display="Dynamic" 
                                        ValidationGroup="Save" runat="server" ControlToValidate="txtTankerReceipitNo" ForeColor="Red"
                                        ErrorMessage="Pls Enter Tanker Receipit No " style="font-size:12px;"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
                 </div>

              <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="lblTankerNo" runat="server" Text="Tanker No"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtTankerNo" class="form-control"   placeholder="Tanker No " runat="server" ValidationGroup="Save" ></asp:TextBox>                        
                    </div><!-- /.input group -->
        <asp:RequiredFieldValidator  ID="RequiredFieldValidator3" Display="Dynamic" 
                                        ValidationGroup="Save" runat="server" ControlToValidate="txtTankerNo" ForeColor="Red"
                                        ErrorMessage="Pls Enter Tanker No " style="font-size:12px;"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
                 </div>

            <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="lblQty" runat="server" Text="Quantity"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtQty" class="form-control"   placeholder="Enter Quantity" runat="server" ValidationGroup="Save"  ></asp:TextBox>                        
                    </div><!-- /.input group -->
        <asp:RequiredFieldValidator  ID="RequiredFieldValidator5" Display="Dynamic" 
                                        ValidationGroup="Save" runat="server" ControlToValidate="txtQty" ForeColor="Red"
                                        ErrorMessage="Pls Enter Qty" style="font-size:12px;"></asp:RequiredFieldValidator>
<asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ValidationExpression= "[0-9]+(\.[0-9][0-9]?)?"
                           ErrorMessage ="Please enter valid number" ControlToValidate="txtQty" ForeColor="Red" style="font-size:12px;" ValidationGroup="Save"/>
                  </div><!-- /.form group -->
                 </div>


               <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="lbltemp" runat="server" Text="Temperature"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtTemperature" class="form-control"   placeholder="Enter Milk Temperature"  runat="server" ValidationGroup="Save"  ></asp:TextBox>                        
                    </div><!-- /.input group -->
        <asp:RequiredFieldValidator  ID="RequiredFieldValidator6" Display="Dynamic" 
                                        ValidationGroup="Save" runat="server" ControlToValidate="txtTemperature" ForeColor="red"
                                        ErrorMessage="Pls Enter Temperature" style="font-size:12px;"></asp:RequiredFieldValidator>
<asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ValidationExpression= "[0-9]+(\.[0-9][0-9]?)?"
                           ErrorMessage ="Please enter valid number" ControlToValidate="txtTemperature" ForeColor="Red" style="font-size:12px;" ValidationGroup="Save"/>
                  </div><!-- /.form group -->
            </div>
</div>

<%--required type="text" data-error-msg="Must enter your name?"--%>
                

  <div class="row">
               <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label1" runat="server" Text="Organoleptic Taste"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtTaste" class="form-control"   placeholder="Enter Taste" runat="server" ></asp:TextBox> 
                        
                    </div><!-- /.input group -->
          <asp:RequiredFieldValidator  ID="RequiredFieldValidator7" Display="Dynamic" 
                                        ValidationGroup="Save" runat="server" ControlToValidate="txtTaste" ForeColor="Red"
                                        ErrorMessage="Pls Enter Organoleptic Taste" style="font-size:12px;"></asp:RequiredFieldValidator>
                      
                  </div><!-- /.form group -->
            </div>

               <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label15" runat="server" Text="Organoleptic Smell"></asp:Label>
                      </div>
                      
                        <asp:TextBox ID="txtSmell" class="form-control"   placeholder="Enter Smell" runat="server" ></asp:TextBox> 
                       
                    </div><!-- /.input group -->
          
                      <asp:RequiredFieldValidator  ID="RequiredFieldValidator21" Display="Dynamic" 
                                        ValidationGroup="Save" runat="server" ControlToValidate="txtSmell" ForeColor="Red"
                                        ErrorMessage="Pls Enter Organoleptic Smell" style="font-size:12px;"></asp:RequiredFieldValidator>
                      
                  </div><!-- /.form group -->
            </div>

        <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label16" runat="server" Text="Organoleptic Color"></asp:Label>
                      </div>
                     
                        <asp:TextBox ID="txtColor" class="form-control"   placeholder="Enter Color" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
        
                      <asp:RequiredFieldValidator  ID="RequiredFieldValidator25" Display="Dynamic" 
                                        ValidationGroup="Save" runat="server" ControlToValidate="txtColor" ForeColor="Red"
                                        ErrorMessage="Pls Enter Organoleptic Color" style="font-size:12px;"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
            </div>



              <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label2" runat="server" Text="Alcohol"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtAlcohol" class="form-control"   placeholder="Enter Alcohol Percentage" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator  ID="RequiredFieldValidator10" Display="Dynamic" 
                                        ValidationGroup="Save" runat="server" ControlToValidate="txtAlcohol" ForeColor="Red"
                                        ErrorMessage="Pls Enter Alcohol" style="font-size:12px;"></asp:RequiredFieldValidator>
                     
 <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationExpression= "[0-9]+(\.[0-9][0-9]?)?"
                           ErrorMessage ="Please enter valid number" ControlToValidate="txtAlcohol" ForeColor="Red" style="font-size:12px;" ValidationGroup="Save"/>
                  </div><!-- /.form group -->
            </div>

      </div>

                  <div class="row">

           <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label3" runat="server" Text="Neutralizer"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtNeutralizer" class="form-control"   placeholder="Enter Neutralizer" runat="server"  ></asp:TextBox>                        
                    </div><!-- /.input group -->
                       <asp:RequiredFieldValidator  ID="RequiredFieldValidator11" Display="Dynamic" 
                                        ValidationGroup="Save" runat="server" ControlToValidate="txtNeutralizer" ForeColor="Red"
                                        ErrorMessage="Pls Enter Neutralizer" style="font-size:12px;"></asp:RequiredFieldValidator>
                      <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ValidationExpression= "[0-9]+(\.[0-9][0-9]?)?"
                           ErrorMessage ="Please enter valid number" ControlToValidate="txtNeutralizer" ForeColor="Red" style="font-size:12px;" ValidationGroup="Save"/>
                  </div><!-- /.form group -->
            </div>

                
               <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label4" runat="server" Text="Acidity"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtAcidity" class="form-control"   placeholder="Enter Acidity" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
 <asp:RequiredFieldValidator  ID="RequiredFieldValidator12" Display="Dynamic" 
                                        ValidationGroup="Save" runat="server" ControlToValidate="txtAcidity" ForeColor="Red"
                                        ErrorMessage="Pls Enter Acidity" style="font-size:12px;"></asp:RequiredFieldValidator>
 <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ValidationExpression= "[0-9]+(\.[0-9][0-9]?)?"
                           ErrorMessage ="Please enter valid number" ControlToValidate="txtAcidity" ForeColor="Red" style="font-size:12px;" ValidationGroup="Save"/>

                  </div><!-- /.form group -->
            </div>

               <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label5" runat="server" Text="Heat Stability"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtHeatStability" class="form-control"   placeholder="Enter Heat Stability" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
<asp:RequiredFieldValidator  ID="RequiredFieldValidator13" Display="Dynamic" 
                                        ValidationGroup="Save" runat="server" ControlToValidate="txtHeatStability" ForeColor="Red"
                                        ErrorMessage="Pls Enter Heat Stability" style="font-size:12px;"></asp:RequiredFieldValidator>
                      <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ValidationExpression= "[0-9]+(\.[0-9][0-9]?)?"
                           ErrorMessage ="Please enter valid number" ControlToValidate="txtHeatStability" ForeColor="Red" style="font-size:12px;" ValidationGroup="Save"/>
                  </div><!-- /.form group -->
            </div>

               <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label6" runat="server" Text="Fat"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtFat" class="form-control"   placeholder="Enter Fat Percentage" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
  <asp:RequiredFieldValidator  ID="RequiredFieldValidator14" Display="Dynamic" 
                                        ValidationGroup="Save" runat="server" ControlToValidate="txtFat" ForeColor="Red"
                                        ErrorMessage="Pls Enter Fat" style="font-size:12px;"></asp:RequiredFieldValidator>
                         <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ValidationExpression= "[0-9]+(\.[0-9][0-9]?)?"
                           ErrorMessage ="Please enter valid number" ControlToValidate="txtFat" ForeColor="Red" style="font-size:12px;" ValidationGroup="Save"/>
                  </div><!-- /.form group -->
            </div>

</div>

                  <div class="row">
               <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label7" runat="server" Text="CLR"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtCLR" class="form-control"   placeholder="Enter CLR" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
 <asp:RequiredFieldValidator  ID="RequiredFieldValidator15" Display="Dynamic" 
                                        ValidationGroup="Save" runat="server" ControlToValidate="txtCLR" ForeColor="Red"
                                        ErrorMessage="Pls Enter CLR" style="font-size:12px;"></asp:RequiredFieldValidator>
                      <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ValidationExpression= "[0-9]+(\.[0-9][0-9]?)?"
                           ErrorMessage ="Please enter valid number" ControlToValidate="txtCLR" ForeColor="Red" style="font-size:12px;" ValidationGroup="Save"/>
                  </div><!-- /.form group -->
            </div>

               <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label8" runat="server" Text="SNF"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtSNF" class="form-control"   placeholder="Enter SNF" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
<asp:RequiredFieldValidator  ID="RequiredFieldValidator16" Display="Dynamic" 
                                        ValidationGroup="Save" runat="server" ControlToValidate="txtSNF" ForeColor="Red"
                                        ErrorMessage="Pls Enter SNF" style="font-size:12px;"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ValidationExpression= "[0-9]+(\.[0-9][0-9]?)?"
                           ErrorMessage ="Please enter valid number" ControlToValidate="txtSNF" ForeColor="Red" style="font-size:12px;" ValidationGroup="Save"/>
                  </div><!-- /.form group -->
            </div>

               <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label9" runat="server" Text="Tested By"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtTestedBy" class="form-control"   placeholder="Tested By" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator  ID="RequiredFieldValidator17" Display="Dynamic" 
                                        ValidationGroup="Save" runat="server" ControlToValidate="txtTestedBy" ForeColor="Red"
                                        ErrorMessage="Pls Enter Tested By" style="font-size:12px;"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
            </div>

               <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label10" runat="server" Text="Verified By"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtVerifiedBy" class="form-control"   placeholder="Verified By" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
          <asp:RequiredFieldValidator  ID="RequiredFieldValidator18" Display="Dynamic" 
                                        ValidationGroup="Save" runat="server" ControlToValidate="txtVerifiedBy" ForeColor="Red"
                                        ErrorMessage="Pls Enter Verified By" style="font-size:12px;"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
            </div>

                      </div>


         <div class="row">
               <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label11" runat="server" Text="Others"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtOthers" class="form-control"   placeholder="Others" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
  
                  </div><!-- /.form group -->
            </div>

               <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label12" runat="server" Text="Remarks"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtRemarks" class="form-control"   placeholder="Remarks" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
            </div>

               <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                       <i class="fa fa-road"></i><span style="color:red">&nbsp;*</span>--%>
                        <asp:Label ID="Label13" runat="server" ValidationGroup="Save" Text="QC Status"></asp:Label>

                      </div>
                      <asp:DropDownList ID="dpQCDetails" class="form-control" DataValueField="QCId" DataTextField="Name"   runat="server"  > 
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                       <asp:RequiredFieldValidator InitialValue="0" ID="Req_ID" Display="Dynamic" 
                             ValidationGroup="Save" runat="server" ControlToValidate="dpQCDetails" ForeColor="Red"
                             ErrorMessage="Pls Select QC Details" style="font-size:12px;">
                         </asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
                         </div>

 </div>
               <div class="col-lg-3 pull-right" >
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                        <asp:Button ID="btnAdd" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Add" ValidationGroup="Save" OnClick="btnAdd_Click"/> &nbsp;    
                        <asp:Button ID="btnUpdate" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Update" ValidationGroup="Save" OnClick="btnUpdate_Click"/> &nbsp;    
                        <asp:Button ID="btnRefresh" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Refresh" ValidationGroup="Refresh" OnClick="btnRefresh_Click"/> &nbsp;    
                         <%--<asp:Button ID="btnRechill" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Re-chill " ValidationGroup="Save" onclick="btnRechill_Click"/> &nbsp;--%>    
                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
                                   
                       
                          
                      </div>
                      
                    
            </ContentTemplate> 
   </asp:UpdatePanel>
                  </div><!-- /.box-body -->            
          </div><!-- /.box -->

           <div class="box ">
            <div class="box-header with-border">
              <h3 class="box-title"> Quality Check Information List </h3>
              <div class="box-tools pull-right" style="right: 4px; top: 4px">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-minus"></i></button>
                
              </div>
            </div>
                                       <div class="row">
                    <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label17" runat="server" Text="Date"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtSearchDate" class="form-control" type="date" runat="server" ValidationGroup="Search" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RFV5" runat="server" ControlToValidate="txtSearchDate"
                       ErrorMessage=" Date is Mandatory" ValidationGroup="Search" ForeColor="Red" ></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
                                        
                          
                      </div> 
                    <div class="col-lg-3" >
                  <div class="form-group ">
                    <div class="input-group">
                        <asp:Button ID="btnSearch" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Search" ValidationGroup="Search" OnClick="btnSearch_Click"/> &nbsp;    
                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
                                   
                       
                          
                      </div>
                            </div>

            <div class="box-body" id="datalist">


           <asp:UpdatePanel runat="server" ID="uprouteList" UpdateMode="Conditional">
                    <ContentTemplate>
                <table id="example1" class="table table-bordered table-striped">
                   

                 
                      <asp:Repeater ID="rpQualityList" runat="server" OnItemCommand="rpQualityList_ItemCommand">
                
                
               <HeaderTemplate>
                  <thead>
                      <tr>
                                    
                                      <%--  <th>Quality Id</th>--%>
                                       <%-- <th>RMRId</th>--%>
                                        <th>Date</th>
                                        <th>RMR Batch No</th>
                                        <th>Shift Name</th>
                                       
                                        <th>Tanker Receipt No</th>
                                        <th>Tanker No</th>
                                        <th>Type Of Milk</th>
                                        <th>Qty</th>
                                        
                                        <th>QC Status</th>
                                        <th>Edit</th>

                      </tr>
                    </thead>
                    <tbody>

                   
               </HeaderTemplate>
               <ItemTemplate>
                    <tr>
                            
                                        <%--<td><%# Eval("QualityId")%></td>   --%>
                                       <%-- <td><%# Eval("RMRId")%></td>   --%>
                                          <td><%# Convert.ToDateTime(Eval("RMRDate")).ToString("dd-MM-yyyy")%></td> 
                                        <td><%# Eval("BatchNo")%></td>   
                                        <td><%# Eval("ShiftName")%></td>
                                      
                                        <td><%# Eval("TankMilkReciptNo")%></td>
                                        <td><%# Eval("TankerNo")%></td>
                                        <td><%# Eval("TypeOfMilk")%></td>
                                        <td><%# Eval("Qty")%></td>
                                        
                                         <td><%# Eval("Status")%></td>
                                        
                                        
                                        
                         
                         <td>
                             <asp:LinkButton ID="lbEdite" AlternateText="Edit" ForeColor="Gray" onItemCommand="lblEdite_ItemCommand" 
                                                                    ToolTip="Edit" runat="server" CommandArgument='<%#Eval("RMRID") %>'
                                                                    CommandName="Edit"><i class="fa fa-edit"></i></asp:LinkButton>

                         </td>
                         



                    </tr>
               </ItemTemplate>
                    <FooterTemplate>

                         </tbody>

                    <tfoot>
                      <tr>
                <tr id="trEmpty" runat="server" visible="false"><td  align = "left"> No records found.</td> </tr>
                                   <%--  <th>Quality Id</th>--%>
                                       <%-- <th>RMRId</th>--%>
                                        <th>Date</th>
                                        <th>RMR Batch No</th>
                                        <th>Shift Name</th>
                                       
                                        <th>Tanker Receipt No</th>
                                        <th>Tanker No</th>
                                        <th>Type Of Milk</th>
                                        <th>Qty</th>
                                        
                                        <th>QC Status</th>
                                        <th>Edit</th>
                                       

                                      
                                        
                      </tr>
                    </tfoot>

                    </FooterTemplate>
                                          </asp:Repeater>    
          
                    <asp:HiddenField Id="hId" runat="server" />
                   
                  </table>
             </section>
                
                        </ContentTemplate>
                                              </asp:UpdatePanel>
                </div>
            <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="uprouteList">
            <ProgressTemplate>
                
                <div class="overlay">
                  <i class="fa fa-refresh fa-spin"></i>
                </div>

            </ProgressTemplate>
            </asp:UpdateProgress>
        </div>
         <asp:HiddenField Id="hfrid" runat="server" />
         </section>

</asp:Content>
