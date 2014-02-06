<%@ Page Language="C#" MasterPageFile="~/BalloonShop.master" AutoEventWireup="true"
  CodeFile="Product.aspx.cs" Inherits="Product" Title="BalloonShop: Product Details Page" %>

<%@ Register src="UserControls/ProductRecommendations.ascx" tagname="ProductRecommendations" tagprefix="uc1" %>

<%@ Register src="UserControls/ProductReviews.ascx" tagname="ProductReviews" tagprefix="uc2" %>

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
  <p>
    <asp:LinkButton ID="AddToCartButton" runat="server" 
     onclick="AddToCartButton_Click">Add to Shopping Cart</asp:LinkButton>
  </p>
  <p>
      <uc1:ProductRecommendations ID="recommendations" runat="server" />
      <uc2:ProductReviews ID="ProductReviews1" runat="server" />
  </p>
</asp:Content>
