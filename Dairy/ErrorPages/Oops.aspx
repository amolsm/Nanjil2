<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Oops.aspx.cs" Inherits="Dairy.ErrorPages.Opps" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
     <link href="customcss.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">



    <div class="header-div">
        <div class="overlay">

            <div class="container">
                <div class="row text-center">
                    <div class="col-md-4">
                       
                    </div>
                    <div class="col-md-8 ">
                        <h1> <strong>Oops ! </strong>An Error Has Occurred</h1>
                        <h2>An unexpected error occurred on our website.The website administrator has been notified.</h2>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- HEADER END -->
    <section class="section-text">
        <div class="container">
            <div class="row">
                <div class="col-md-6">
                    <h3>Possible Causes Of this Error</h3>
                    <ul>
                        <li>The resource you are looking for is not here or has been moved.
                        </li>
                        <li>The page has been deleted for some reason.
                        </li>
                        <li>There are also some other reasons that can't be disclosed here so you should contact admin at 
                       
                        </li>
                    </ul>
                </div>
              <%--  <div class="col-md-3">
                    <div class="alert alert-info">
                        In case of emergency you can contact us at
                      <strong>+90-456-456-9999</strong> and reach us at our headquarters located  : 
                     <strong>230/56 , New Lane City, United Kingdom.</strong>
                    </div>
                </div>--%>
                <div class="col-md-3 text-center">
                    <h2>Quick Links</h2>
                    <hr />
                    <a href="../Authentication/LoginT.aspx" class="btn btn-info">Navigate to Home Page</a>
                    <hr />
                    <a href="#" class="btn  btn-warning">Launch a Quick e-mail</a>
                </div>
            </div>
        </div>
    </section>
    <!-- TEXT SECTION END -->
    <div class="header-div">
        <div class="overlay">

            <div class="container">
                <div class="row text-center">

                    <div class="col-md-12">
                        <h1>Sorry,  <strong>For Inconvenience </strong></h1>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- HEADER DIV REPLICATE END -->
   
    <!-- FOOTER SECTION END -->

<!-- GOOGLE ADD SECTION START -->
    <div id="add-div-main">
    
        <div class="add-wrapper-db">
            <div class="container">
                <div class="row">
                    <div class="col-xs-12 col-sm-12 col-md-4 col-lg-4">
                        <div class="add-block">
                           
                        </div>
                    </div>
                    <div class="col-xs-12 col-sm-12 col-md-8 col-lg-8 text-center">
                        <div class="add-block" id="ftr-large-add"  >



                        </div>
                    </div>
                   
                </div>
            </div>
        </div>
    </div>
    <!-- GOOGLE ADD SECTION END -->


    <!-- REQUIRED SCRIPTS FILES -->
    <!-- CORE JQUERY FILE -->
   

<script type="text/javascript">/* <![CDATA[ */(function(d,s,a,i,j,r,l,m,t){try{l=d.getElementsByTagName('a');t=d.createElement('textarea');for(i=0;l.length-i;i++){try{a=l[i].href;s=a.indexOf('/cdn-cgi/l/email-protection');m=a.length;if(a&&s>-1&&m>28){j=28+s;s='';if(j<m){r='0x'+a.substr(j,2)|0;for(j+=2;j<m&&a.charAt(j)!='X';j+=2)s+='%'+('0'+('0x'+a.substr(j,2)^r).toString(16)).slice(-2);j++;s=decodeURIComponent(s)+a.substr(j,m-j)}t.innerHTML=s.replace(/</g,'&lt;').replace(/>/g,'&gt;');l[i].href='mailto:'+t.value}}catch(e){}}}catch(e){}})(document);/* ]]> */</script>


</asp:Content>
