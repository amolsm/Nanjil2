﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginT.aspx.cs" Inherits="Dairy.Authentication.LoginT" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

 <html>
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>Nanjil Milk | Log in</title>
    <!-- Tell the browser to be responsive to screen width -->
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport">
    <!-- Bootstrap 3.3.5 -->
    <link rel="stylesheet" href="/Theme/bootstrap/css/bootstrap.min.css">
    <!-- Font Awesome -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.4.0/css/font-awesome.min.css">
    <!-- Ionicons -->
    <link rel="stylesheet" href="https://code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css">
    <!-- Theme style -->
    <link rel="stylesheet" href="/Theme/dist/css/AdminLTE.min.css">
    <!-- iCheck -->
    <link rel="stylesheet" href="/Theme/plugins/iCheck/square/blue.css">

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
        <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
  </head>
  <body style ="background-image:url(/Theme/img/back.jpg); background-size:cover ; ">
   
      <div class="row">
        <div class="col-sm-6 col-md-4 col-md-offset-4 pull-right">
       <div class="login-box">
            <div class="login-logo" ">
        <img src="../Theme/img/logo2.png" alt="logo" />
      </div><!-- /.login-logo -->

      <div class="login-logo">
        <p style="color: #fff"><b>Nanjil Milk Plant </b>ERP</p>
      </div><!-- /.login-logo -->
      <div class="login-box-body" style="background-color:#8C93AF"> 
            <form id="form2" runat="server">

             <asp:Panel runat="server" ID="PNLLOGIN" Visible="true">
        <p class="login-box-msg">Sign in to start your session</p>
        
          <div class="form-group has-feedback">
            <asp:TextBox runat="server" ID="txtUsername" class="form-control" placeholder="Email" type="email" required ></asp:TextBox>
            <span class="glyphicon glyphicon-envelope form-control-feedback"></span>
          </div>
          <div class="form-group has-feedback">
              <asp:TextBox runat="server" ID="txtpassword" class="form-control" TextMode="Password" placeholder="Password" required></asp:TextBox>
            <span class="glyphicon glyphicon-lock form-control-feedback"></span>
          </div>
          <div class="row">
            <div class="col-xs-8">
              <div class="checkbox icheck">
                <label>
                  <input type="checkbox"> Remember Me
                </label>
              </div>
            </div><!-- /.col -->
            <div class="col-xs-4" >
               <asp:Button runat="server" ID="btnLogin" class="btn btn-primary btn-block btn-flat" Text="Sign in" OnClick="btnLogin_clcik"/>
            </div><!-- /.col -->
          </div>
                  <a href="/Authentication/ForgotPassword.aspx"> I forgot my password </a><br>
                    <asp:Label runat="server" ID="lblmsg" Text="Invalid Username or Password" ForeColor="Red"></asp:Label>
                  </asp:Panel>

                 <asp:Panel runat="server" ID="PNLSELECTBOTH" Visible="false">
               <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <i class="fa fa-rode"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:DropDownList ID="dpAgent" class="form-control" DataTextField="Name" DataValueField="AgentID" runat="server" AutoPostBack="true" OnTextChanged="dpAgent_TextChanged"   > 
                       </asp:DropDownList>
                        
                         
                    </div><!-- /.input group -->
                   </div>
           </asp:Panel>

                <asp:Panel runat="server" ID="pnlOfflineBooth" Visible="false">
                   
                 <div class="form-group">
                   <div class="input-group">
                     <div class="input-group-addon">
                       <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                     </div>
                      <asp:TextBox ID="txtOfflineBoothDate" class="form-control" type="date"  placeholder="Date" runat="server" ></asp:TextBox>                        
                   </div><!-- /.input group -->

                 </div><!-- /.form group -->

                   
               <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <i class="fa fa-rode"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:DropDownList ID="dpBooth" class="form-control" DataTextField="Name" DataValueField="AgentID" runat="server" > 
                       </asp:DropDownList>
                        
                         
                    </div><!-- /.input group -->
                   </div>

                    <div class="form-group">
                    <div class="input-group">
                       <asp:Button ID="btnOfflineBooth" class="btn btn-primary" runat="server"  Text="Submit" ValidationGroup="offline"  OnClick="btnOfflineBooth_Click"  />                    
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->



           </asp:Panel>

                <asp:Panel runat="server" ID="pnlSelectShift" Visible="false">
               <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <asp:Label runat="server" Text="Shift"></asp:Label>
                      </div>
                       <asp:DropDownList ID="dpShift" class="form-control" DataTextField="Name" DataValueField="Id" runat="server" AutoPostBack="true" OnSelectedIndexChanged ="dpShift_SelectedIndexChanged"   > 
                       </asp:DropDownList>
                        
                         
                    </div><!-- /.input group -->
                   </div>
           </asp:Panel>

                  <asp:Panel runat="server" ID="pnlCollectionCenter" Visible="false">
               <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <asp:Label runat="server" Text="Collection Center"></asp:Label>
                      </div>
                       <asp:DropDownList ID="dpCollectionCenter" class="form-control" DataTextField="Name" DataValueField="CenterID" runat="server" AutoPostBack="true" OnSelectedIndexChanged ="dpCollectionCenter_SelectedIndexChanged"   > 
                       </asp:DropDownList>
                        
                         
                    </div><!-- /.input group -->
                   </div>
           </asp:Panel>
        </form>

        
       
        
        
      
      </div><!-- /.login-box-body -->
         
    </div><!-- /.login-box -->
     </div>
          </div>

    <!-- jQuery 2.1.4 -->
    <script src="/Theme/plugins/jQuery/jQuery-2.1.4.min.js"></script>
    <!-- Bootstrap 3.3.5 -->
    <script src="/Theme/bootstrap/js/bootstrap.min.js"></script>
    <!-- iCheck -->
    <script src="/Theme/plugins/iCheck/icheck.min.js"></script>
    <script>
        $(function () {
            $('input').iCheck({
                checkboxClass: 'icheckbox_square-blue',
                radioClass: 'iradio_square-blue',
                increaseArea: '20%' // optional
            });
        });
    </script>
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
  </body>
</html>