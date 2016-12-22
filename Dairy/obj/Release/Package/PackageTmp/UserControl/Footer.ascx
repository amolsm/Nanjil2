<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Footer.ascx.cs" Inherits="Dairy.UserControl.Footer" %>


   

    
    <!-- jQuery 2.1.4 -->
    <%--<script src="../../Theme/plugins/jQuery/jQuery-2.1.4.min.js"></script>--%>
    <!-- Bootstrap 3.3.5 -->
    <%--<script src="/Theme/bootstrap/js/bootstrap.min.js"></script>--%>
    <script src="../../Theme/bootstrap/js/bootstrap.min.js"></script>
    <!-- DataTables -->
    <script src="../../Theme/plugins/datatables/jquery.dataTables.min.js"></script>
    <script src="../../Theme/plugins/datatables/dataTables.bootstrap.min.js"></script>
    <!-- SlimScroll -->
    <script src="../../Theme/plugins/slimScroll/jquery.slimscroll.min.js"></script>
    <!-- FastClick -->
    <script src="../../Theme/plugins/fastclick/fastclick.min.js"></script>
    <!-- AdminLTE App -->
    <script src="../../Theme/dist/js/app.min.js"></script>
    <!-- AdminLTE for demo purposes -->
    <script src="../../Theme/dist/js/demo.js"></script>
    <!-- page script --> 
 <link href="../../Theme/bootstrap/css/bootstrap-select.min.css" rel="stylesheet" />
    <script type="text/javascript" src="../../Theme/bootstrap/js/bootstrap-select.min.js"></script>

   <script>
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
    </script>

 
  
   
 