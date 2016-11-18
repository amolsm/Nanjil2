<%@ Page Title="" Language="C#" MasterPageFile="../../Site.Master" AutoEventWireup="true"
    CodeBehind="AddAgent.aspx.cs" Inherits="Dairy.Tabs.Administration.AddAgent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
       <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css">
            <script src="//code.jquery.com/jquery-1.10.2.js"></script>
            <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   
      <script type="text/javascript">
          function BindSlabDetails(id) {

              $('#hdagentInfo').val(id);



              $.ajax({
                  type: "POST",
                  url: "/WebService/BindAgentSlab.asmx/GetAgentSlabDetailsByAgentID",
                  data: '{id: "' + id + '" }',
                  contentType: "application/json; charset=utf-8",
                  dataType: "json",
                  success: function (response) {
                      $("#AgentSlabdetails").html(response.d)
                  },
                  failure: function (response) {

                      alert(response.d);
                  }
              });
          }
          function AddSlabDetailsss() {



              var agentID = $('#hdagentInfo').val()
              var type = $("#MainContent_dpType option:selected").val();

              var slabID = $("#MainContent_dpSlab option:selected").val();

              var MC = 0;
              var TDC = 0;

              $.ajax({
                  type: "POST",
                  url: "/WebService/BindAgentSlab.asmx/AddagentSlab",
                  data: '{type: "' + type + '" , slabID: "' + slabID + '" , agentID: "' + agentID + '" , MC: "' + MC + '" , TDC: "' + TDC + '" }',
                  contentType: "application/json; charset=utf-8",
                  dataType: "json",
                  success: function (response) {
                      BindSlabDetails(agentID);
                  },
                  failure: function (response) {

                      alert(response.d);
                  }
              });
          }
          //$(function () {
          //    $("#MainContent_txtDateOfJoing").datepicker({ dateFormat: 'dd/mm/yy' });
          //    $("#MainContent_txtDeactivedate").datepicker({ dateFormat: 'dd/mm/yy' });
          //    $("#MainContent_txtEffectivedate").datepicker({ dateFormat: 'dd/mm/yy' });
          //})
    </script>
   
    <section class="content-header">
          <h1>
             Agent Information
            <small>Administration</small>   <span style="font-size:medium"> [ Active Agent=<asp:Label ID="lblActiveCount" runat="server"></asp:Label>]    [ Deactive Agent=<asp:Label ID="lblDeactive" runat="server"></asp:Label>]</span> 
          </h1> 
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Administration</a></li>
            <li class="active">Add Agent Info</li>
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
                                    <i class="icon fa fa-warning"></i>Warning! <asp:Label runat="server" ID="lblWarningHead" Text=""></asp:Label></h4>
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
              <h3 class="box-title"><asp:Label runat="server" ID="lblHeaderTab" Text="Add Agent"></asp:Label></h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-plus"></i></button>
               
              </div>
            </div>
            <div class="box-body">
               
                
                                  <asp:UpdatePanel runat="server" ID="upMain" UpdateMode="Conditional">
                    <ContentTemplate>

                    
        
               <div class="box box-solid box-default" style="margin-bottom:5px !important;" >
        <div class="box-header" style="padding:0px 0px 0px 10px !important">
          <h3 class="box-title">Agent Information </h3>
        </div><!-- /.box-header -->
        <div class="box-body">
            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-lightbulb-o"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtAgentCode"  class="form-control" placeholder="Agent Code" runat="server" required ToolTip="Agent Code"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div>                        
             
   

                  
                  <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <i class="fa fa-rode"></i><span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:DropDownList ID="dpRoute" class="form-control" DataTextField="Name" DataValueField="RouteID" runat="server" selected ToolTip="Select Route"> 
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->

                     
                       
                          
                      </div>  
            
             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-user"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtAgentName" class="form-control" placeholder="Agent Name" runat="server" required ToolTip="Enter Agent Name"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div>  
            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:DropDownList ID="dpAgencyType" class="form-control" runat="server" selected ToolTip="Select Agency Type">

                           <asp:ListItem Value="0">---Select Agency Type---</asp:ListItem>
                           <asp:ListItem Value="1">Booth </asp:ListItem>
                           <asp:ListItem Value="2">Agency</asp:ListItem>
                            
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->

                     
                       
                          
                      </div>   
              <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-calendar"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtDateOfJoing" class="form-control" type = "date" placeholder="Date of Joining" runat="server" required ToolTip="Date of Joining"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 
              <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-check"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtApprovedBy" class="form-control" placeholder="Approved By" runat="server" required ToolTip="Approved By"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div>       
            
             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:DropDownList ID="dpStatus" class="form-control" runat="server" ToolTip="Select Status">

                           <asp:ListItem Value="0">---Select Status---</asp:ListItem>
                           <asp:ListItem Value="1">Active</asp:ListItem>
                           <asp:ListItem Value="2">Deactive</asp:ListItem>
                       
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 

                  <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:DropDownList ID="dpbillingtype" class="form-control" runat="server" ToolTip="Select Billing Type">

                           <asp:ListItem Value="0">---Select Billing Method---</asp:ListItem>
                           <asp:ListItem Value="1">Fixed</asp:ListItem>
                           <asp:ListItem Value="2">Variable</asp:ListItem>
                          
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 

                 <%--           <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:DropDownList ID="dpEmployeeID" class="form-control" runat="server" DataTextField="EmployeeName" DataValueField="EmployeeID" >
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->

                     
                       
                          
                      </div> --%>
  
        </div><!-- /.box-body -->
      </div>
                     
                
                   <div class="box box-solid box-default" style="margin-bottom:5px !important;" >
        <div class="box-header" style="padding:0px 0px 0px 10px !important">
          <h3 class="box-title">Contact Information </h3>
        </div><!-- /.box-header -->
        <div class="box-body">
            <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-map-marker"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtAddress1" class="form-control" placeholder="Address 1" runat="server" required ToolTip="Address 1"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
                

                     
                       
                          
                      </div>                        
                 <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-map-marker"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtAddress2" class="form-control" placeholder="Address 2" ToolTip="Address 2" runat="server"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div>  

            <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-map-marker"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtAddress3" class="form-control" placeholder="Address 3" ToolTip="Address 3" runat="server"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 
            
 

              <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-envelope-o"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtEmail" class="form-control" placeholder="Email" ToolTip="Enter Email" runat="server" required AutoCompleteType="Email"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group --> 
                   </div> 
                        <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-mobile"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtMobile" class="form-control" ToolTip="Enter Mobile No" placeholder="Mobile No" runat="server" required Type="number"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div>                        
                 <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-phone"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtTelephone" class="form-control" ToolTip="Enter Telephone No"  placeholder="Telephone No" runat="server" required Type="number"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div>  


                        <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-globe"></i><span style="color:red">&nbsp;*</span>
                      </div>
                     <%-- <asp:TextBox ID="txtCity" class="form-control" placeholder="City " ToolTip="Enter City" runat="server" required></asp:TextBox>                        --%>
                    <asp:DropDownList  ID="dpCity" ToolTip="Select City" class="form-control" DataTextField="Name"  runat="server"  > 
                       </asp:DropDownList>
                        
                         </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 

                               <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-globe"></i><span style="color:red">&nbsp;*</span>
                      </div>
                      <%-- <asp:TextBox ID="txtDistric" class="form-control" placeholder="District " ToolTip="Enter District" runat="server" required></asp:TextBox>                        --%>
                    <asp:DropDownList  ID="dpDistric" ToolTip="Select District" class="form-control" DataTextField="Name"  runat="server"  > 
                       </asp:DropDownList>
                        
                         </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 
                      
                      
                  <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <span style="color:red">&nbsp;*</span>
                      </div>
                     <%-- <asp:DropDownList ID="dpState" class="form-control" ToolTip="Select State" runat="server">--%>
                         <asp:DropDownList  ID="dpState" ToolTip="Select State" class="form-control" DataTextField="Name"  runat="server"  > 
                       </asp:DropDownList>
                         
                          
                       
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->

                     
                       
                          
                      </div>  
            
                <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <span style="color:red">&nbsp;*</span>
                      </div>
                     <%-- <asp:DropDownList ID="dpCountry" class="form-control" ToolTip="Select Country" runat="server">

                           <asp:ListItem Value="0">---Select Country---</asp:ListItem>
                          <asp:ListItem Selected="True" Value="1">India</asp:ListItem>
                           <asp:ListItem Value="2">USA</asp:ListItem>
                       </asp:DropDownList>--%>
                        <asp:DropDownList  ID="dpCountry" ToolTip="Select Country" class="form-control" DataTextField="Name"  runat="server"  > 
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->

                     
                       
                          
                      </div>
            
        </div><!-- /.box-body -->
      </div>


                       <div class="box box-solid box-default" style="margin-bottom:5px !important;" >
        <div class="box-header" style="padding:0px 0px 0px 10px !important">
          <h3 class="box-title">Bank Information </h3>
        </div><!-- /.box-header -->
        <div class="box-body">


               
               <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:DropDownList ID="dppaymenttype" class="form-control" runat="server" ToolTip="Select Payment Type">

                           <asp:ListItem Value="0">---Select Payment Type---</asp:ListItem>
                           <asp:ListItem Value="1">Daily</asp:ListItem>
                           <asp:ListItem Value="2">Monthly</asp:ListItem>
                            
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->

                     
                       
                          
                      </div>  
            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-inr"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtDepositeAmount" class="form-control" placeholder="Deposit Amount" runat="server" required type="number" ToolTip="Enter Deposit Amount"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div>                        
             
 
                  
         
            
             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-bank"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <%--<asp:TextBox ID="txtBankName" class="form-control" placeholder="Bank  Name" runat="server" required ToolTip="Enter Bank Name"></asp:TextBox>                        --%>
                     <asp:DropDownList  ID="dpBankName" ToolTip="Select Bank Name" class="form-control" DataTextField="Name"  runat="server"  > 
                       </asp:DropDownList>
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div>    


              <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-bars"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtAccountNo" class="form-control" placeholder="Account No" runat="server" required type="number" ToolTip="Enter Bank Account No"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 
            
             <div class="col-lg-3">

                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-bars"></i><span style="color:red">&nbsp;*</span>
                      </div>
                      <%-- <asp:TextBox ID="txtIfscCode" class="form-control" placeholder="IFSC Code" runat="server" required  ToolTip="Enter IFSC code"></asp:TextBox>                        --%>
                     <asp:DropDownList  ID="dpIfscCode" ToolTip="Select IFSC Code" class="form-control" DataTextField="Name"  runat="server"  > 
                       </asp:DropDownList>
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                      </div>
                          
                       <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:DropDownList ID="dpAccountType" class="form-control" runat="server" ToolTip="Select Account Type">

                           <asp:ListItem Value="0">---Select Account type---</asp:ListItem>
                            <asp:ListItem Value="1">Saving</asp:ListItem>
                           <asp:ListItem Value="2">Current</asp:ListItem>
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 
                    
        </div><!-- /.box-body -->
      </div>



                  <div class="box box-solid box-default" style="margin-bottom:5px !important;" >
        <div class="box-header" style="padding:0px 0px 0px 10px !important">
          <h3 class="box-title">Service Information </h3>
        </div><!-- /.box-header -->
        <div class="box-body">
            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-bars"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtValoume" class="form-control" placeholder="Volume" ToolTip="Enter Volume" runat="server"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div>                        
                <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-bars"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtNoOfTrays" class="form-control" placeholder="No. Of Trays" ToolTip="No. of Trays" runat="server"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 

                  
                  <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:DropDownList ID="dpDoorToDoor" class="form-control" runat="server" ToolTip="Select Door to Door">

                           <asp:ListItem Value="0">---Is Door to Door---</asp:ListItem>
                               <asp:ListItem Value="1">Yes</asp:ListItem>
                           <asp:ListItem Value="2">No</asp:ListItem>
                           
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->

                     
                       
                          
                      </div>  
            
             <div class="col-lg-3">
                <div class="form-group">
                    <label>
                         Freezer Available &nbsp;
                         <asp:RadioButton ID="rbcFreezerYes" GroupName="freezer"  class="flat-red" runat="server"></asp:RadioButton>
                      Yes
                    </label>
                    <label>
                      <asp:RadioButton ID="rbcFreezerNo"  GroupName="freezer" class="flat-red" runat="server"></asp:RadioButton>NO
                    </label>
                   
                    
                  

                     
                  </div>

                     
                       
                          
                      </div>    

       
        
        </div><!-- /.box-body -->
      </div>

                 <div class="box box-solid box-default" style="margin-bottom:5px !important;" >
        <div class="box-header" style="padding:0px 0px 0px 10px !important">
          <h3 class="box-title">De-active  Information </h3>
        </div><!-- /.box-header -->
        <div class="box-body">
            <div class="col-lg-2">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-calendar"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtDeactivedate" type="date" class="form-control" placeholder="De-active date" ToolTip="De-active Date" runat="server"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div>                        
                <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-bars"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtDeactiveRession" class="form-control" placeholder=" Deactive Reason" ToolTip="Deactive Reason" runat="server"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 

                     <div class="col-lg-2">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-inr"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtAmountRetrun" class="form-control" placeholder="Amount Retrun" ToolTip="Amount Return" runat="server"  Type="number"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div>                        
                <div class="col-lg-2">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-reply"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtTraysReturned" class="form-control" placeholder="Trays Returned" ToolTip="Trays Returned" runat="server" Type="number"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 
                  
                   <div class="col-lg-2">
                <div class="form-group">
                    <label>
                         Freezer Return &nbsp;
                         <asp:RadioButton ID="rbFreezerRestrunYes" GroupName="freezerRetrun"  class="flat-red" runat="server"></asp:RadioButton>
                      Yes
                    </label>
                    <label>
                      <asp:RadioButton ID="rbFreezerRestrunNo"  GroupName="freezerRetrun" class="flat-red" runat="server"></asp:RadioButton>NO
                    </label>
                   
                    
                  

                     
                  </div>

                     
                       
                          
                      </div>
          
        
        </div><!-- /.box-body -->
      </div>

                    <div class="box box-solid box-default" style="margin-bottom:5px !important;" >
        <div class="box-header" style="padding:0px 0px 0px 10px !important">
          <h3 class="box-title">Scheme  Information </h3>
        </div><!-- /.box-header -->
        <div class="box-body">
            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-calendar"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtSchemeAmount" class="form-control" placeholder="Scheme Amount" ToolTip="Scheme Amount" runat="server"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div>                        
                <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-arrows-alt "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtSchemeTotalAmount" Enabled="false" class="form-control" placeholder="Scheme Total Amount" ToolTip="Total Scheme Amount" runat="server"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 
      
                    <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      
                    
                      
                              <asp:Button ID="btnAddagent" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Add" ValidationGroup="Save" OnClick="btnAddagent_click"  />     
                      &nbsp;&nbsp;  <asp:Button ID="btnupdateagent" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Update" ValidationGroup="Save"  OnClick="btnUpdate_click"  />           
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
              <h3 class="box-title"> Agent List </h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-minus"></i></button>
                
              </div>
            </div>
            <div class="box-body">
                   





                      <asp:UpdatePanel runat="server" ID="uprouteList" UpdateMode="Conditional">
                    <ContentTemplate>

                <table id="example1" class="table table-bordered table-striped">
                   

                 

                <asp:Repeater ID="rpAgentINfo" runat="server" OnItemCommand="rpAgentInfo_ItemCommand">
                
               <HeaderTemplate>
                  <thead>
                      <tr>
                                    <th>Route Name</th>
                                    <th>Agent Code</th>
                          
                                    <th>Agent Name</th>
                                    <th>Agency Type</th>
                                    <th>Mobile No</th>
                                    <th>Address</th>
                                    
                          <th>Map Slab</th>
                          <th>Edit</th>
                          <th>Delete</th>
                                     
                           
                      </tr>
                    </thead>
                    <tbody>

                   
               </HeaderTemplate>
               <ItemTemplate>
                    <tr>
                                                    <td><%# Eval("RouteName")%></td>
                                                    <td><%# Eval("AgentCode")%></td>
                                                    <td><%# Eval("AgentName")%></td>
                                                    <td><%# Eval("Agensytype")%></td>
                                                    <td><%# Eval("MobileNo")%></td>
                                                    <td><%# Eval("Address1")%></td> 
                                                    
                        <td>

                           <a href="#" data-toggle="modal" data-target="#LoginModal" onclick="BindSlabDetails(<%#Eval("AgentID") %>);" >Map slab</a>

                         </td>
                                                    
                         <td>

                             <asp:LinkButton ID="lbEdite" AlternateText="Edit" ForeColor="Gray" OnItemCommand="lbEdite_ItemCommand" 
                                 ToolTip="Edit" runat="server" CommandArgument='<%#Eval("AgentID") %>' CommandName="Edit"><i class="fa fa-edit"></i></asp:LinkButton>

                         </td>

                        <td> 

                             <asp:LinkButton ID="lblDelete" AlternateText="Delete" ForeColor="Gray" OnItemCommand="lbEdite_ItemCommand"
                                  ToolTip="Edit" runat="server" CommandArgument='<%#Eval("AgentID") %>'  CommandName="Delete"><i class="fa fa-trash"></i></asp:LinkButton>

                         </td>
     
                    </tr>
               </ItemTemplate>
                    <FooterTemplate>

                         </tbody>

                    <tfoot>
                      <tr>
                                    <th>RouteName</th>
                                    <th>Agent Code</th>
                                    <th>Agent Name</th>
                                    <th>Agency Type</th>
                                    <th>Mobile No</th>
                                    <th>Address</th>
                                     
                           <th>Edit</th> 
                            <th>Delete</th>                      
                      </tr>
                    </tfoot>

                    </FooterTemplate>
                                             
           </asp:Repeater>
                    <asp:HiddenField id="hfAgentID" runat="server" />
             
                
                  <input id="hdagentInfo" type="hidden" />
                     
                   
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

     <div class="modal fade" id="LoginModal" tabindex="-1" role="dialog" aria-labelledby="helpModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">
                            <span aria-hidden="true">&times;
                            </span><span class="sr-only">
                                     Close</span></button>
                        <h4 class="modal-title" id="H1">
                            Map Slab With Agent</h4>
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            
                             <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <i class="fa fa-rode"></i><span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:DropDownList ID="dpType" class="form-control" DataTextField="routeName" DataValueField="routeId" runat="server" selected> 
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->
                         </div>
                              <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <i class="fa fa-rode"></i><span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:DropDownList ID="dpSlab" class="form-control" DataTextField="routeName" DataValueField="routeId" runat="server" selected> 
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->
                         </div>

                               

                              

                              <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      
                  <input id="btnAddSlab" class="btn btn-default"  onclick="AddSlabDetailsss()" type="button" value="Add" />
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->
                         </div>
                        </div>
                      <div class="row">
 <div id="AgentSlabdetails"></div>
                          </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" 
                        class="btn btn-default" data-dismiss="modal">
                            Close</button>
                    </div>
                </div
            </div>
        </div>


    <script>
        yepnope({ // or Modernizr.load
            test: Modernizr.inputtypes.date,
            nope: [
                'http://cdnjs.cloudflare.com/ajax/libs/jqueryui/1.11.2/jquery-ui.min.js',

                'http://cdnjs.cloudflare.com/ajax/libs/jqueryui/1.11.2/jquery-ui.min.css',
                'http://cdnjs.cloudflare.com/ajax/libs/jqueryui/1.11.2/jquery-ui.structure.min.css',
                'http://cdnjs.cloudflare.com/ajax/libs/jqueryui/1.11.2/jquery-ui.theme.min.css',

            ],

            callback: function (url) {

                if (url === 'http://cdnjs.cloudflare.com/ajax/libs/jqueryui/1.11.2/jquery-ui.min.js') {

                    var idx = 0;

                    $('input[type="date"]').each(function () {
                        var _this = $(this),
                            prefix = 'alt' + String(idx++) + '_',
                            _val = _this.val();

                        _this
                        .attr('placeholder', 'gg/mm/aaaa')
                        .attr('autocomplete', 'off')
                        .prop('readonly', true)
                        .after('<input type="text" class="altfield" id="' + prefix + this.attr('id') + '" name="' + this.attr('name') + '" value="' + _val + '">')
                        .removeAttr('name')
                        .val('')
                        .datepicker({
                            altField: '#' + prefix + _this.attr('id'),
                            dateFormat: 'dd/mm/yy',
                            altFormat: 'dd/mm/yy'
                        });

                        if (_val) {
                            this.datepicker('setDate', $.datepicker.parseDate('dd/mm/yy', val));
                        };
                    });


                    // min attribute
                    $('input[type="date"][min]').each(function () {
                        var _this = $(this);
                        this.datepicker("option", "minDate", $.datepicker.parseDate('dd/mm/yy', this.attr('min')));
                    });

                    // max attribute
                    $('input[type="date"][max]').each(function () {
                        var _this = $(this);
                        this.datepicker("option", "maxDate", $.datepicker.parseDate('dd/mm/yy', this.attr('max')));
                    });
                }
            }
        }); // end Modernizr.load
        </script>
</asp:Content>
