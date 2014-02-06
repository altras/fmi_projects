<%@ Page Language="C#" MasterPageFile="~/BalloonShop.master" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="Search" Title="Untitled Page" %>

<%@ Register src="UserControls/ProductsList.ascx" tagname="ProductsList" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <asp:Label CssClass="CatalogTitle" ID="titleLabel" runat="server"></asp:Label>
  <br />
  <asp:Label CssClass="CatalogDescription" ID="descriptionLabel" runat="server"></asp:Label>
  <br />
  <uc1:ProductsList ID="ProductsList1" runat="server" />
</asp:Content>
