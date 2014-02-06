<%@ Page Title="SecurityLib Test Page" Language="C#" MasterPageFile="~/BalloonShop.master"
  AutoEventWireup="true" CodeFile="SecurityLibTester.aspx.cs" Inherits="SecurityLibTester" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  Enter your password:<br />
  <asp:TextBox ID="pwdBox1" runat="server" />
  <br />
  Enter your password again:
  <br />
  <asp:TextBox ID="pwdBox2" runat="server" />
  <br />
  <asp:Button ID="processButton" runat="server" Text="Process" OnClick="processButton_Click" />
  <br />
  <asp:Label ID="result" runat="server" />
</asp:Content>
