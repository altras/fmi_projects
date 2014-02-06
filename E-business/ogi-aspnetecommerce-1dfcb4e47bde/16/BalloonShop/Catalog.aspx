<%@ Page Language="C#" MasterPageFile="~/BalloonShop.master" AutoEventWireup="true"
  CodeFile="Catalog.aspx.cs" Inherits="Catalog" Title="BalloonShop: Catalog" %>

<%@ Register src="UserControls/ProductsList.ascx" tagname="ProductsList" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  <h1>
    <asp:Label ID="catalogTitleLabel" CssClass="CatalogTitle" runat="server" />
  </h1>
  <h2>
    <asp:Label ID="catalogDescriptionLabel" CssClass="CatalogDescription" runat="server" />
  </h2>
  <uc1:ProductsList ID="ProductsList1" runat="server" />
</asp:Content>
