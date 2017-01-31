<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BindSlabExcel.aspx.cs" Inherits="Dairy.Tabs.Test.BindSlabExcel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  <asp:Button ID="btnDownload" Text="Download" runat="server" OnClick="btnDownload_Click" />
   <asp:FileUpload ID="FileUpload1" runat="server" />
<asp:Button  Text="Upload" OnClick = "Button1_Click" runat="server" />
     
</asp:Content>
