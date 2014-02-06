<%@ Page Language="C#" MasterPageFile="~/BalloonShop.master" AutoEventWireup="true"
  CodeFile="Product.aspx.cs" Inherits="Product" Title="BalloonShop: Product Details Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  <p>
    <asp:Label CssClass="CatalogTitle" ID="titleLabel" runat="server" Text="Label"></asp:Label>
  </p>
  <p>
    <asp:Image ID="productImage" runat="server" />
  </p>
  <p>
    <asp:Label ID="descriptionLabel" runat="server" Text="Label"></asp:Label>
  </p>
  <p>
    <b>Price:</b>
    <asp:Label CssClass="ProductPrice" ID="priceLabel" runat="server" Text="Label"></asp:Label>
  </p>
  <p>
    <asp:PlaceHolder ID="attrPlaceHolder" runat="server"></asp:PlaceHolder>
  </p>  
</asp:Content>
