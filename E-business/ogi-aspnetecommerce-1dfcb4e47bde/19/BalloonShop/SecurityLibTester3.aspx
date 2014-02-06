<%@ Page Title="SecurityLib Test Page 3" Language="C#" MasterPageFile="~/BalloonShop.master"
  AutoEventWireup="true" CodeFile="SecurityLibTester3.aspx.cs" Inherits="SecurityLibTester3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  Card holder:<br />
  <asp:TextBox ID="cardHolderBox" runat="server" />
  <br />
  Card number:<br />
  <asp:TextBox ID="cardNumberBox" runat="server" />
  <br />
  Issue date:<br />
  <asp:TextBox ID="issueDateBox" runat="server" />
  <br />
  Expiry date:<br />
  <asp:TextBox ID="expiryDateBox" runat="server" />
  <br />
  Issue number:<br />
  <asp:TextBox ID="issueNumberBox" runat="server" />
  <br />
  Card type:<br />
  <asp:TextBox ID="cardTypeBox" runat="server" />
  <br />
  <asp:Button ID="processButton" runat="server" Text="Process" OnClick="processButton_Click" />
  <br />
  <asp:Label ID="result" runat="server" />
</asp:Content>
